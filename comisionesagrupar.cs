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
   public class comisionesagrupar : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            GXDLAMEDIDASID1X77( A121RubrosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"INVENTARIOID") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAINVENTARIOID1X77( A121RubrosId, A137MedidasID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A121RubrosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A121RubrosId, A137MedidasID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
            A135InventarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "InventarioId"), "."), 18, MidpointRounding.ToEven));
            n135InventarioId = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A121RubrosId, A137MedidasID, A135InventarioId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_rubros") == 0 )
         {
            gxnrGridlevel_rubros_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "comisionesagrupar.aspx")), "comisionesagrupar.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "comisionesagrupar.aspx")))) ;
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
                  AV7ComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "ComisionesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ComisionesID", StringUtil.LTrimStr( (decimal)(AV7ComisionesID), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCOMISIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ComisionesID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Agrupación de Comisiones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_rubros_newrow_invoke( )
      {
         nRC_GXsfl_43 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
         A512ComisionesInventarioEnum = (int)(Math.Round(NumberUtil.Val( GetPar( "ComisionesInventarioEnum"), "."), 18, MidpointRounding.ToEven));
         n512ComisionesInventarioEnum = false;
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_rubros_newrow( ) ;
         /* End function gxnrGridlevel_rubros_newrow_invoke */
      }

      public comisionesagrupar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisionesagrupar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_ComisionesID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ComisionesID = aP1_ComisionesID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbComisionesTipo = new GXCombobox();
         dynMedidasID = new GXCombobox();
         dynInventarioId = new GXCombobox();
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
         if ( cmbComisionesTipo.ItemCount > 0 )
         {
            A505ComisionesTipo = cmbComisionesTipo.getValidValue(A505ComisionesTipo);
            AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbComisionesTipo.CurrentValue = StringUtil.RTrim( A505ComisionesTipo);
            AssignProp("", false, cmbComisionesTipo_Internalname, "Values", cmbComisionesTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtComisionesID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComisionesID_Internalname, context.GetMessage( "Código de la Comisión", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComisionesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A503ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtComisionesID_Enabled!=0) ? context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtComisionesID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ComisionesAgrupar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbComisionesTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbComisionesTipo_Internalname, context.GetMessage( "Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbComisionesTipo, cmbComisionesTipo_Internalname, StringUtil.RTrim( A505ComisionesTipo), 1, cmbComisionesTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbComisionesTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_ComisionesAgrupar.htm");
         cmbComisionesTipo.CurrentValue = StringUtil.RTrim( A505ComisionesTipo);
         AssignProp("", false, cmbComisionesTipo_Internalname, "Values", (string)(cmbComisionesTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtComisionesNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComisionesNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComisionesNombre_Internalname, StringUtil.RTrim( A504ComisionesNombre), StringUtil.RTrim( context.localUtil.Format( A504ComisionesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtComisionesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_ComisionesAgrupar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtComisionesDefault_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComisionesDefault_Internalname, context.GetMessage( "Comisión por Defecto %", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComisionesDefault_Internalname, StringUtil.LTrim( StringUtil.NToC( A506ComisionesDefault, 6, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtComisionesDefault_Enabled!=0) ? context.localUtil.Format( A506ComisionesDefault, "ZZ9.99") : context.localUtil.Format( A506ComisionesDefault, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComisionesDefault_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtComisionesDefault_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ComisionesAgrupar.htm");
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
         GxWebStd.gx_div_start( context, divTableleaflevel_rubros_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_rubros( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ComisionesAgrupar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ComisionesAgrupar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ComisionesAgrupar.htm");
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

      protected void gxdraw_Gridlevel_rubros( )
      {
         /*  Grid Control  */
         StartGridControl43( ) ;
         nGXsfl_43_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount77 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_77 = 1;
               ScanStart1X77( ) ;
               while ( RcdFound77 != 0 )
               {
                  init_level_properties77( ) ;
                  getByPrimaryKey1X77( ) ;
                  AddRow1X77( ) ;
                  ScanNext1X77( ) ;
               }
               ScanEnd1X77( ) ;
               nBlankRcdCount77 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
            AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
            standaloneNotModal1X77( ) ;
            standaloneModal1X77( ) ;
            sMode77 = Gx_mode;
            while ( nGXsfl_43_idx < nRC_GXsfl_43 )
            {
               bGXsfl_43_Refreshing = true;
               ReadRow1X77( ) ;
               edtRubrosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               dynMedidasID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_43_Refreshing);
               dynInventarioId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtInventarioPrecioFinal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOPRECIOFINAL_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtComisionesAgruparRubrosValor_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMISIONESAGRUPARRUBROSVALOR_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtComisionesAgruparRubrosValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesAgruparRubrosValor_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtComisionesAgruparRubrosGan_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMISIONESAGRUPARRUBROSGAN_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtComisionesAgruparRubrosGan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesAgruparRubrosGan_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               imgprompt_121_Link = cgiGet( "PROMPT_121_"+sGXsfl_43_idx+"Link");
               imgprompt_121_Link = cgiGet( "PROMPT_137_"+sGXsfl_43_idx+"Link");
               imgprompt_121_Link = cgiGet( "PROMPT_135_"+sGXsfl_43_idx+"Link");
               if ( ( nRcdExists_77 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1X77( ) ;
               }
               SendRow1X77( ) ;
               bGXsfl_43_Refreshing = false;
            }
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A512ComisionesInventarioEnum = B512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
            AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount77 = 5;
            nRcdExists_77 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1X77( ) ;
               while ( RcdFound77 != 0 )
               {
                  sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_4377( ) ;
                  init_level_properties77( ) ;
                  standaloneNotModal1X77( ) ;
                  getByPrimaryKey1X77( ) ;
                  standaloneModal1X77( ) ;
                  AddRow1X77( ) ;
                  ScanNext1X77( ) ;
               }
               ScanEnd1X77( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode77 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx+1), 4, 0), 4, "0");
            SubsflControlProps_4377( ) ;
            InitAll1X77( ) ;
            init_level_properties77( ) ;
            B512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
            AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
            nRcdExists_77 = 0;
            nIsMod_77 = 0;
            nRcdDeleted_77 = 0;
            nBlankRcdCount77 = (short)(nBlankRcdUsr77+nBlankRcdCount77);
            fRowAdded = 0;
            while ( nBlankRcdCount77 > 0 )
            {
               standaloneNotModal1X77( ) ;
               standaloneModal1X77( ) ;
               AddRow1X77( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount77 = (short)(nBlankRcdCount77-1);
            }
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A512ComisionesInventarioEnum = B512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
            AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_rubrosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_rubros", Gridlevel_rubrosContainer, subGridlevel_rubros_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_rubrosContainerData", Gridlevel_rubrosContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_rubrosContainerData"+"V", Gridlevel_rubrosContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_rubrosContainerData"+"V"+"\" value='"+Gridlevel_rubrosContainer.GridValuesHidden()+"'/>") ;
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
         E111X2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z503ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z503ComisionesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z505ComisionesTipo = cgiGet( "Z505ComisionesTipo");
               Z504ComisionesNombre = cgiGet( "Z504ComisionesNombre");
               Z506ComisionesDefault = context.localUtil.CToN( cgiGet( "Z506ComisionesDefault"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n506ComisionesDefault = ((Convert.ToDecimal(0)==A506ComisionesDefault) ? true : false);
               Z512ComisionesInventarioEnum = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z512ComisionesInventarioEnum"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n512ComisionesInventarioEnum = ((0==A512ComisionesInventarioEnum) ? true : false);
               A512ComisionesInventarioEnum = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z512ComisionesInventarioEnum"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n512ComisionesInventarioEnum = false;
               n512ComisionesInventarioEnum = ((0==A512ComisionesInventarioEnum) ? true : false);
               O512ComisionesInventarioEnum = (int)(Math.Round(context.localUtil.CToN( cgiGet( "O512ComisionesInventarioEnum"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n512ComisionesInventarioEnum = ((0==A512ComisionesInventarioEnum) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCOMISIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A512ComisionesInventarioEnum = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMISIONESINVENTARIOENUM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n512ComisionesInventarioEnum = ((0==A512ComisionesInventarioEnum) ? true : false);
               AV26Pgmname = cgiGet( "vPGMNAME");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A513ComisionesAgruparRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "COMISIONESAGRUPARRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
               A503ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtComisionesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
               cmbComisionesTipo.Name = cmbComisionesTipo_Internalname;
               cmbComisionesTipo.CurrentValue = cgiGet( cmbComisionesTipo_Internalname);
               A505ComisionesTipo = cgiGet( cmbComisionesTipo_Internalname);
               AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
               A504ComisionesNombre = cgiGet( edtComisionesNombre_Internalname);
               AssignAttri("", false, "A504ComisionesNombre", A504ComisionesNombre);
               A506ComisionesDefault = context.localUtil.CToN( cgiGet( edtComisionesDefault_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n506ComisionesDefault = false;
               AssignAttri("", false, "A506ComisionesDefault", StringUtil.LTrimStr( A506ComisionesDefault, 6, 2));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ComisionesAgrupar");
               A503ComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtComisionesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
               forbiddenHiddens.Add("ComisionesID", context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9"));
               A505ComisionesTipo = cgiGet( cmbComisionesTipo_Internalname);
               AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
               forbiddenHiddens.Add("ComisionesTipo", StringUtil.RTrim( context.localUtil.Format( A505ComisionesTipo, "")));
               A504ComisionesNombre = cgiGet( edtComisionesNombre_Internalname);
               AssignAttri("", false, "A504ComisionesNombre", A504ComisionesNombre);
               forbiddenHiddens.Add("ComisionesNombre", StringUtil.RTrim( context.localUtil.Format( A504ComisionesNombre, "")));
               A506ComisionesDefault = context.localUtil.CToN( cgiGet( edtComisionesDefault_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n506ComisionesDefault = false;
               AssignAttri("", false, "A506ComisionesDefault", StringUtil.LTrimStr( A506ComisionesDefault, 6, 2));
               forbiddenHiddens.Add("ComisionesDefault", context.localUtil.Format( A506ComisionesDefault, "ZZ9.99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A503ComisionesID != Z503ComisionesID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("comisionesagrupar:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A503ComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "ComisionesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
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
                     sMode74 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode74;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound74 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1X0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "COMISIONESID");
                        AnyError = 1;
                        GX_FocusControl = edtComisionesID_Internalname;
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
                           E111X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121X2 ();
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
            E121X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1X74( ) ;
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
            DisableAttributes1X74( ) ;
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

      protected void CONFIRM_1X0( )
      {
         BeforeValidate1X74( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1X74( ) ;
            }
            else
            {
               CheckExtendedTable1X74( ) ;
               CloseExtendedTableCursors1X74( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode74 = Gx_mode;
            CONFIRM_1X77( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode74;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_1X77( )
      {
         s512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
         n512ComisionesInventarioEnum = false;
         AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            ReadRow1X77( ) ;
            if ( ( nRcdExists_77 != 0 ) || ( nIsMod_77 != 0 ) )
            {
               GetKey1X77( ) ;
               if ( ( nRcdExists_77 == 0 ) && ( nRcdDeleted_77 == 0 ) )
               {
                  if ( RcdFound77 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1X77( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1X77( ) ;
                        CloseExtendedTableCursors1X77( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
                        n512ComisionesInventarioEnum = false;
                        AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
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
                  if ( RcdFound77 != 0 )
                  {
                     if ( nRcdDeleted_77 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1X77( ) ;
                        Load1X77( ) ;
                        BeforeValidate1X77( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1X77( ) ;
                           O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
                           n512ComisionesInventarioEnum = false;
                           AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_77 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1X77( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1X77( ) ;
                              CloseExtendedTableCursors1X77( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
                              n512ComisionesInventarioEnum = false;
                              AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_77 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( dynMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))) ;
            ChangePostValue( dynInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))) ;
            ChangePostValue( edtInventarioPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtComisionesAgruparRubrosValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A515ComisionesAgruparRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtComisionesAgruparRubrosGan_Internalname, StringUtil.LTrim( StringUtil.NToC( A517ComisionesAgruparRubrosGan, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z513ComisionesAgruparRubrosId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z513ComisionesAgruparRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z515ComisionesAgruparRubrosValor_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( Z515ComisionesAgruparRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_77_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_77), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_77_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_77), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_77_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_77), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_77 != 0 )
            {
               ChangePostValue( "RUBROSID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOPRECIOFINAL_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COMISIONESAGRUPARRUBROSVALOR_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComisionesAgruparRubrosValor_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COMISIONESAGRUPARRUBROSGAN_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComisionesAgruparRubrosGan_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O512ComisionesInventarioEnum = s512ComisionesInventarioEnum;
         n512ComisionesInventarioEnum = false;
         AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1X0( )
      {
      }

      protected void E111X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisionesAgrupar_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisionesAgrupar_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisionesAgrupar_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV26Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E121X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("comisionesagruparww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1X74( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z505ComisionesTipo = T001X8_A505ComisionesTipo[0];
               Z504ComisionesNombre = T001X8_A504ComisionesNombre[0];
               Z506ComisionesDefault = T001X8_A506ComisionesDefault[0];
               Z512ComisionesInventarioEnum = T001X8_A512ComisionesInventarioEnum[0];
            }
            else
            {
               Z505ComisionesTipo = A505ComisionesTipo;
               Z504ComisionesNombre = A504ComisionesNombre;
               Z506ComisionesDefault = A506ComisionesDefault;
               Z512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
            }
         }
         if ( GX_JID == -11 )
         {
            Z503ComisionesID = A503ComisionesID;
            Z505ComisionesTipo = A505ComisionesTipo;
            Z504ComisionesNombre = A504ComisionesNombre;
            Z506ComisionesDefault = A506ComisionesDefault;
            Z512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
         }
      }

      protected void standaloneNotModal( )
      {
         cmbComisionesTipo.Enabled = 0;
         AssignProp("", false, cmbComisionesTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComisionesTipo.Enabled), 5, 0), true);
         edtComisionesNombre_Enabled = 0;
         AssignProp("", false, edtComisionesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesNombre_Enabled), 5, 0), true);
         edtComisionesDefault_Enabled = 0;
         AssignProp("", false, edtComisionesDefault_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesDefault_Enabled), 5, 0), true);
         edtComisionesID_Enabled = 0;
         AssignProp("", false, edtComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         cmbComisionesTipo.Enabled = 0;
         AssignProp("", false, cmbComisionesTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComisionesTipo.Enabled), 5, 0), true);
         edtComisionesNombre_Enabled = 0;
         AssignProp("", false, edtComisionesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesNombre_Enabled), 5, 0), true);
         edtComisionesDefault_Enabled = 0;
         AssignProp("", false, edtComisionesDefault_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesDefault_Enabled), 5, 0), true);
         edtComisionesID_Enabled = 0;
         AssignProp("", false, edtComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesID_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ComisionesID) )
         {
            A503ComisionesID = AV7ComisionesID;
            AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
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
      }

      protected void Load1X74( )
      {
         /* Using cursor T001X9 */
         pr_default.execute(7, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound74 = 1;
            A505ComisionesTipo = T001X9_A505ComisionesTipo[0];
            AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
            A504ComisionesNombre = T001X9_A504ComisionesNombre[0];
            AssignAttri("", false, "A504ComisionesNombre", A504ComisionesNombre);
            A506ComisionesDefault = T001X9_A506ComisionesDefault[0];
            n506ComisionesDefault = T001X9_n506ComisionesDefault[0];
            AssignAttri("", false, "A506ComisionesDefault", StringUtil.LTrimStr( A506ComisionesDefault, 6, 2));
            A512ComisionesInventarioEnum = T001X9_A512ComisionesInventarioEnum[0];
            n512ComisionesInventarioEnum = T001X9_n512ComisionesInventarioEnum[0];
            ZM1X74( -11) ;
         }
         pr_default.close(7);
         OnLoadActions1X74( ) ;
      }

      protected void OnLoadActions1X74( )
      {
         AV26Pgmname = "ComisionesAgrupar";
         AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
      }

      protected void CheckExtendedTable1X74( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV26Pgmname = "ComisionesAgrupar";
         AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
      }

      protected void CloseExtendedTableCursors1X74( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1X74( )
      {
         /* Using cursor T001X10 */
         pr_default.execute(8, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound74 = 1;
         }
         else
         {
            RcdFound74 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001X8 */
         pr_default.execute(6, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM1X74( 11) ;
            RcdFound74 = 1;
            A503ComisionesID = T001X8_A503ComisionesID[0];
            AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
            A505ComisionesTipo = T001X8_A505ComisionesTipo[0];
            AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
            A504ComisionesNombre = T001X8_A504ComisionesNombre[0];
            AssignAttri("", false, "A504ComisionesNombre", A504ComisionesNombre);
            A506ComisionesDefault = T001X8_A506ComisionesDefault[0];
            n506ComisionesDefault = T001X8_n506ComisionesDefault[0];
            AssignAttri("", false, "A506ComisionesDefault", StringUtil.LTrimStr( A506ComisionesDefault, 6, 2));
            A512ComisionesInventarioEnum = T001X8_A512ComisionesInventarioEnum[0];
            n512ComisionesInventarioEnum = T001X8_n512ComisionesInventarioEnum[0];
            O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
            AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
            Z503ComisionesID = A503ComisionesID;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1X74( ) ;
            if ( AnyError == 1 )
            {
               RcdFound74 = 0;
               InitializeNonKey1X74( ) ;
            }
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound74 = 0;
            InitializeNonKey1X74( ) ;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey1X74( ) ;
         if ( RcdFound74 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound74 = 0;
         /* Using cursor T001X11 */
         pr_default.execute(9, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001X11_A503ComisionesID[0] < A503ComisionesID ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001X11_A503ComisionesID[0] > A503ComisionesID ) ) )
            {
               A503ComisionesID = T001X11_A503ComisionesID[0];
               AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
               RcdFound74 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound74 = 0;
         /* Using cursor T001X12 */
         pr_default.execute(10, new Object[] {A503ComisionesID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T001X12_A503ComisionesID[0] > A503ComisionesID ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T001X12_A503ComisionesID[0] < A503ComisionesID ) ) )
            {
               A503ComisionesID = T001X12_A503ComisionesID[0];
               AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
               RcdFound74 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1X74( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
            AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
            Insert1X74( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound74 == 1 )
            {
               if ( A503ComisionesID != Z503ComisionesID )
               {
                  A503ComisionesID = Z503ComisionesID;
                  AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COMISIONESID");
                  AnyError = 1;
                  GX_FocusControl = edtComisionesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
                  n512ComisionesInventarioEnum = false;
                  AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  /* Update record */
                  A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
                  n512ComisionesInventarioEnum = false;
                  AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
                  Update1X74( ) ;
               }
            }
            else
            {
               if ( A503ComisionesID != Z503ComisionesID )
               {
                  /* Insert record */
                  A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
                  n512ComisionesInventarioEnum = false;
                  AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
                  Insert1X74( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COMISIONESID");
                     AnyError = 1;
                     GX_FocusControl = edtComisionesID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
                     n512ComisionesInventarioEnum = false;
                     AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
                     Insert1X74( ) ;
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
         if ( A503ComisionesID != Z503ComisionesID )
         {
            A503ComisionesID = Z503ComisionesID;
            AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COMISIONESID");
            AnyError = 1;
            GX_FocusControl = edtComisionesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
            AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
            delete( ) ;
            AfterTrn( ) ;
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1X74( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001X7 */
            pr_default.execute(5, new Object[] {A503ComisionesID});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Comisiones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(5) == 101) || ( StringUtil.StrCmp(Z505ComisionesTipo, T001X7_A505ComisionesTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z504ComisionesNombre, T001X7_A504ComisionesNombre[0]) != 0 ) || ( Z506ComisionesDefault != T001X7_A506ComisionesDefault[0] ) || ( Z512ComisionesInventarioEnum != T001X7_A512ComisionesInventarioEnum[0] ) )
            {
               if ( StringUtil.StrCmp(Z505ComisionesTipo, T001X7_A505ComisionesTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("comisionesagrupar:[seudo value changed for attri]"+"ComisionesTipo");
                  GXUtil.WriteLogRaw("Old: ",Z505ComisionesTipo);
                  GXUtil.WriteLogRaw("Current: ",T001X7_A505ComisionesTipo[0]);
               }
               if ( StringUtil.StrCmp(Z504ComisionesNombre, T001X7_A504ComisionesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("comisionesagrupar:[seudo value changed for attri]"+"ComisionesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z504ComisionesNombre);
                  GXUtil.WriteLogRaw("Current: ",T001X7_A504ComisionesNombre[0]);
               }
               if ( Z506ComisionesDefault != T001X7_A506ComisionesDefault[0] )
               {
                  GXUtil.WriteLog("comisionesagrupar:[seudo value changed for attri]"+"ComisionesDefault");
                  GXUtil.WriteLogRaw("Old: ",Z506ComisionesDefault);
                  GXUtil.WriteLogRaw("Current: ",T001X7_A506ComisionesDefault[0]);
               }
               if ( Z512ComisionesInventarioEnum != T001X7_A512ComisionesInventarioEnum[0] )
               {
                  GXUtil.WriteLog("comisionesagrupar:[seudo value changed for attri]"+"ComisionesInventarioEnum");
                  GXUtil.WriteLogRaw("Old: ",Z512ComisionesInventarioEnum);
                  GXUtil.WriteLogRaw("Current: ",T001X7_A512ComisionesInventarioEnum[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Comisiones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1X74( )
      {
         BeforeValidate1X74( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X74( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1X74( 0) ;
            CheckOptimisticConcurrency1X74( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X74( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1X74( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001X13 */
                     pr_default.execute(11, new Object[] {A505ComisionesTipo, A504ComisionesNombre, n506ComisionesDefault, A506ComisionesDefault, n512ComisionesInventarioEnum, A512ComisionesInventarioEnum});
                     A503ComisionesID = T001X13_A503ComisionesID[0];
                     AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Comisiones");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1X74( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1X0( ) ;
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
               Load1X74( ) ;
            }
            EndLevel1X74( ) ;
         }
         CloseExtendedTableCursors1X74( ) ;
      }

      protected void Update1X74( )
      {
         BeforeValidate1X74( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X74( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X74( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X74( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1X74( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001X14 */
                     pr_default.execute(12, new Object[] {A505ComisionesTipo, A504ComisionesNombre, n506ComisionesDefault, A506ComisionesDefault, n512ComisionesInventarioEnum, A512ComisionesInventarioEnum, A503ComisionesID});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Comisiones");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Comisiones"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1X74( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1X74( ) ;
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
            EndLevel1X74( ) ;
         }
         CloseExtendedTableCursors1X74( ) ;
      }

      protected void DeferredUpdate1X74( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1X74( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X74( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1X74( ) ;
            AfterConfirm1X74( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1X74( ) ;
               if ( AnyError == 0 )
               {
                  A512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
                  n512ComisionesInventarioEnum = false;
                  AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
                  ScanStart1X77( ) ;
                  while ( RcdFound77 != 0 )
                  {
                     getByPrimaryKey1X77( ) ;
                     Delete1X77( ) ;
                     ScanNext1X77( ) ;
                     O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
                     n512ComisionesInventarioEnum = false;
                     AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
                  }
                  ScanEnd1X77( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001X15 */
                     pr_default.execute(13, new Object[] {A503ComisionesID});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Comisiones");
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
         sMode74 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1X74( ) ;
         Gx_mode = sMode74;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1X74( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV26Pgmname = "ComisionesAgrupar";
            AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001X16 */
            pr_default.execute(14, new Object[] {A503ComisionesID});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T001X17 */
            pr_default.execute(15, new Object[] {A503ComisionesID});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comercio | Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void ProcessNestedLevel1X77( )
      {
         s512ComisionesInventarioEnum = O512ComisionesInventarioEnum;
         n512ComisionesInventarioEnum = false;
         AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            ReadRow1X77( ) ;
            if ( ( nRcdExists_77 != 0 ) || ( nIsMod_77 != 0 ) )
            {
               standaloneNotModal1X77( ) ;
               GetKey1X77( ) ;
               if ( ( nRcdExists_77 == 0 ) && ( nRcdDeleted_77 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1X77( ) ;
               }
               else
               {
                  if ( RcdFound77 != 0 )
                  {
                     if ( ( nRcdDeleted_77 != 0 ) && ( nRcdExists_77 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1X77( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_77 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1X77( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_77 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
               n512ComisionesInventarioEnum = false;
               AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
            }
            ChangePostValue( edtRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( dynMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))) ;
            ChangePostValue( dynInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))) ;
            ChangePostValue( edtInventarioPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtComisionesAgruparRubrosValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A515ComisionesAgruparRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtComisionesAgruparRubrosGan_Internalname, StringUtil.LTrim( StringUtil.NToC( A517ComisionesAgruparRubrosGan, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z513ComisionesAgruparRubrosId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z513ComisionesAgruparRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z515ComisionesAgruparRubrosValor_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( Z515ComisionesAgruparRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_77_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_77), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_77_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_77), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_77_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_77), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_77 != 0 )
            {
               ChangePostValue( "RUBROSID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOPRECIOFINAL_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COMISIONESAGRUPARRUBROSVALOR_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComisionesAgruparRubrosValor_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COMISIONESAGRUPARRUBROSGAN_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComisionesAgruparRubrosGan_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1X77( ) ;
         if ( AnyError != 0 )
         {
            O512ComisionesInventarioEnum = s512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
            AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
         }
         nRcdExists_77 = 0;
         nIsMod_77 = 0;
         nRcdDeleted_77 = 0;
      }

      protected void ProcessLevel1X74( )
      {
         /* Save parent mode. */
         sMode74 = Gx_mode;
         ProcessNestedLevel1X77( ) ;
         if ( AnyError != 0 )
         {
            O512ComisionesInventarioEnum = s512ComisionesInventarioEnum;
            n512ComisionesInventarioEnum = false;
            AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode74;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T001X18 */
         pr_default.execute(16, new Object[] {n512ComisionesInventarioEnum, A512ComisionesInventarioEnum, A503ComisionesID});
         pr_default.close(16);
         pr_default.SmartCacheProvider.SetUpdated("Comisiones");
      }

      protected void EndLevel1X74( )
      {
         pr_default.close(5);
         if ( AnyError == 0 )
         {
            BeforeComplete1X74( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(6);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.close(3);
            pr_default.close(4);
            context.CommitDataStores("comisionesagrupar",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1X0( ) ;
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
            context.RollbackDataStores("comisionesagrupar",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1X74( )
      {
         /* Scan By routine */
         /* Using cursor T001X19 */
         pr_default.execute(17);
         RcdFound74 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound74 = 1;
            A503ComisionesID = T001X19_A503ComisionesID[0];
            AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1X74( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound74 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound74 = 1;
            A503ComisionesID = T001X19_A503ComisionesID[0];
            AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
         }
      }

      protected void ScanEnd1X74( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm1X74( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1X74( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1X74( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1X74( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1X74( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1X74( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1X74( )
      {
         edtComisionesID_Enabled = 0;
         AssignProp("", false, edtComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesID_Enabled), 5, 0), true);
         cmbComisionesTipo.Enabled = 0;
         AssignProp("", false, cmbComisionesTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComisionesTipo.Enabled), 5, 0), true);
         edtComisionesNombre_Enabled = 0;
         AssignProp("", false, edtComisionesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesNombre_Enabled), 5, 0), true);
         edtComisionesDefault_Enabled = 0;
         AssignProp("", false, edtComisionesDefault_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesDefault_Enabled), 5, 0), true);
      }

      protected void ZM1X77( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z515ComisionesAgruparRubrosValor = T001X3_A515ComisionesAgruparRubrosValor[0];
               Z121RubrosId = T001X3_A121RubrosId[0];
               Z137MedidasID = T001X3_A137MedidasID[0];
               Z135InventarioId = T001X3_A135InventarioId[0];
            }
            else
            {
               Z515ComisionesAgruparRubrosValor = A515ComisionesAgruparRubrosValor;
               Z121RubrosId = A121RubrosId;
               Z137MedidasID = A137MedidasID;
               Z135InventarioId = A135InventarioId;
            }
         }
         if ( GX_JID == -12 )
         {
            Z503ComisionesID = A503ComisionesID;
            Z513ComisionesAgruparRubrosId = A513ComisionesAgruparRubrosId;
            Z515ComisionesAgruparRubrosValor = A515ComisionesAgruparRubrosValor;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            Z181InventarioPrecioFinal = A181InventarioPrecioFinal;
         }
      }

      protected void standaloneNotModal1X77( )
      {
      }

      protected void standaloneModal1X77( )
      {
         if ( IsIns( )  )
         {
            A512ComisionesInventarioEnum = (int)(O512ComisionesInventarioEnum+1);
            n512ComisionesInventarioEnum = false;
            AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A513ComisionesAgruparRubrosId = A512ComisionesInventarioEnum;
            AssignAttri("", false, "A513ComisionesAgruparRubrosId", StringUtil.LTrimStr( (decimal)(A513ComisionesAgruparRubrosId), 18, 0));
         }
      }

      protected void Load1X77( )
      {
         /* Using cursor T001X20 */
         pr_default.execute(18, new Object[] {A503ComisionesID, A513ComisionesAgruparRubrosId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound77 = 1;
            A181InventarioPrecioFinal = T001X20_A181InventarioPrecioFinal[0];
            A515ComisionesAgruparRubrosValor = T001X20_A515ComisionesAgruparRubrosValor[0];
            A121RubrosId = T001X20_A121RubrosId[0];
            A137MedidasID = T001X20_A137MedidasID[0];
            n137MedidasID = T001X20_n137MedidasID[0];
            A135InventarioId = T001X20_A135InventarioId[0];
            n135InventarioId = T001X20_n135InventarioId[0];
            ZM1X77( -12) ;
         }
         pr_default.close(18);
         OnLoadActions1X77( ) ;
      }

      protected void OnLoadActions1X77( )
      {
         if ( ( A515ComisionesAgruparRubrosValor > Convert.ToDecimal( 0 )) )
         {
            A517ComisionesAgruparRubrosGan = (decimal)((A181InventarioPrecioFinal*(A515ComisionesAgruparRubrosValor/ (decimal)(100))));
         }
         else
         {
            A517ComisionesAgruparRubrosGan = 0;
         }
         GXAMEDIDASID_html1X77( A121RubrosId) ;
         GXAINVENTARIOID_html1X77( A121RubrosId, A137MedidasID) ;
      }

      protected void CheckExtendedTable1X77( )
      {
         nIsDirty_77 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1X77( ) ;
         /* Using cursor T001X4 */
         pr_default.execute(2, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_43_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T001X5 */
         pr_default.execute(3, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) ) )
            {
               GXCCtl = "MEDIDASID_" + sGXsfl_43_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T001X6 */
         pr_default.execute(4, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) || (0==A135InventarioId) ) )
            {
               GXCCtl = "INVENTARIOID_" + sGXsfl_43_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A181InventarioPrecioFinal = T001X6_A181InventarioPrecioFinal[0];
         pr_default.close(4);
         if ( ( A515ComisionesAgruparRubrosValor > Convert.ToDecimal( 0 )) )
         {
            nIsDirty_77 = 1;
            A517ComisionesAgruparRubrosGan = (decimal)((A181InventarioPrecioFinal*(A515ComisionesAgruparRubrosValor/ (decimal)(100))));
         }
         else
         {
            nIsDirty_77 = 1;
            A517ComisionesAgruparRubrosGan = 0;
         }
         GXAMEDIDASID_html1X77( A121RubrosId) ;
         GXAINVENTARIOID_html1X77( A121RubrosId, A137MedidasID) ;
      }

      protected void CloseExtendedTableCursors1X77( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable1X77( )
      {
      }

      protected void gxLoad_13( short A121RubrosId )
      {
         /* Using cursor T001X21 */
         pr_default.execute(19, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_43_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_14( short A121RubrosId ,
                                long A137MedidasID )
      {
         /* Using cursor T001X22 */
         pr_default.execute(20, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) ) )
            {
               GXCCtl = "MEDIDASID_" + sGXsfl_43_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void gxLoad_15( short A121RubrosId ,
                                long A137MedidasID ,
                                long A135InventarioId )
      {
         /* Using cursor T001X23 */
         pr_default.execute(21, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) || (0==A135InventarioId) ) )
            {
               GXCCtl = "INVENTARIOID_" + sGXsfl_43_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A181InventarioPrecioFinal = T001X23_A181InventarioPrecioFinal[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void GetKey1X77( )
      {
         /* Using cursor T001X24 */
         pr_default.execute(22, new Object[] {A503ComisionesID, A513ComisionesAgruparRubrosId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound77 = 1;
         }
         else
         {
            RcdFound77 = 0;
         }
         pr_default.close(22);
      }

      protected void getByPrimaryKey1X77( )
      {
         /* Using cursor T001X3 */
         pr_default.execute(1, new Object[] {A503ComisionesID, A513ComisionesAgruparRubrosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1X77( 12) ;
            RcdFound77 = 1;
            InitializeNonKey1X77( ) ;
            A513ComisionesAgruparRubrosId = T001X3_A513ComisionesAgruparRubrosId[0];
            A515ComisionesAgruparRubrosValor = T001X3_A515ComisionesAgruparRubrosValor[0];
            A121RubrosId = T001X3_A121RubrosId[0];
            A137MedidasID = T001X3_A137MedidasID[0];
            n137MedidasID = T001X3_n137MedidasID[0];
            A135InventarioId = T001X3_A135InventarioId[0];
            n135InventarioId = T001X3_n135InventarioId[0];
            Z503ComisionesID = A503ComisionesID;
            Z513ComisionesAgruparRubrosId = A513ComisionesAgruparRubrosId;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1X77( ) ;
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound77 = 0;
            InitializeNonKey1X77( ) ;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1X77( ) ;
            Gx_mode = sMode77;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1X77( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1X77( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001X2 */
            pr_default.execute(0, new Object[] {A503ComisionesID, A513ComisionesAgruparRubrosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComisionesAgruparRubros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z515ComisionesAgruparRubrosValor != T001X2_A515ComisionesAgruparRubrosValor[0] ) || ( Z121RubrosId != T001X2_A121RubrosId[0] ) || ( Z137MedidasID != T001X2_A137MedidasID[0] ) || ( Z135InventarioId != T001X2_A135InventarioId[0] ) )
            {
               if ( Z515ComisionesAgruparRubrosValor != T001X2_A515ComisionesAgruparRubrosValor[0] )
               {
                  GXUtil.WriteLog("comisionesagrupar:[seudo value changed for attri]"+"ComisionesAgruparRubrosValor");
                  GXUtil.WriteLogRaw("Old: ",Z515ComisionesAgruparRubrosValor);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A515ComisionesAgruparRubrosValor[0]);
               }
               if ( Z121RubrosId != T001X2_A121RubrosId[0] )
               {
                  GXUtil.WriteLog("comisionesagrupar:[seudo value changed for attri]"+"RubrosId");
                  GXUtil.WriteLogRaw("Old: ",Z121RubrosId);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A121RubrosId[0]);
               }
               if ( Z137MedidasID != T001X2_A137MedidasID[0] )
               {
                  GXUtil.WriteLog("comisionesagrupar:[seudo value changed for attri]"+"MedidasID");
                  GXUtil.WriteLogRaw("Old: ",Z137MedidasID);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A137MedidasID[0]);
               }
               if ( Z135InventarioId != T001X2_A135InventarioId[0] )
               {
                  GXUtil.WriteLog("comisionesagrupar:[seudo value changed for attri]"+"InventarioId");
                  GXUtil.WriteLogRaw("Old: ",Z135InventarioId);
                  GXUtil.WriteLogRaw("Current: ",T001X2_A135InventarioId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ComisionesAgruparRubros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1X77( )
      {
         BeforeValidate1X77( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X77( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1X77( 0) ;
            CheckOptimisticConcurrency1X77( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X77( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1X77( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001X25 */
                     pr_default.execute(23, new Object[] {A503ComisionesID, A513ComisionesAgruparRubrosId, A515ComisionesAgruparRubrosValor, A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
                     pr_default.close(23);
                     pr_default.SmartCacheProvider.SetUpdated("ComisionesAgruparRubros");
                     if ( (pr_default.getStatus(23) == 1) )
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
               Load1X77( ) ;
            }
            EndLevel1X77( ) ;
         }
         CloseExtendedTableCursors1X77( ) ;
      }

      protected void Update1X77( )
      {
         BeforeValidate1X77( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X77( ) ;
         }
         if ( ( nIsMod_77 != 0 ) || ( nIsDirty_77 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1X77( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1X77( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1X77( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001X26 */
                        pr_default.execute(24, new Object[] {A515ComisionesAgruparRubrosValor, A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId, A503ComisionesID, A513ComisionesAgruparRubrosId});
                        pr_default.close(24);
                        pr_default.SmartCacheProvider.SetUpdated("ComisionesAgruparRubros");
                        if ( (pr_default.getStatus(24) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComisionesAgruparRubros"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1X77( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1X77( ) ;
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
               EndLevel1X77( ) ;
            }
         }
         CloseExtendedTableCursors1X77( ) ;
      }

      protected void DeferredUpdate1X77( )
      {
      }

      protected void Delete1X77( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1X77( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X77( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1X77( ) ;
            AfterConfirm1X77( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1X77( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001X27 */
                  pr_default.execute(25, new Object[] {A503ComisionesID, A513ComisionesAgruparRubrosId});
                  pr_default.close(25);
                  pr_default.SmartCacheProvider.SetUpdated("ComisionesAgruparRubros");
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
         sMode77 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1X77( ) ;
         Gx_mode = sMode77;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1X77( )
      {
         standaloneModal1X77( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            GXAMEDIDASID_html1X77( A121RubrosId) ;
            GXAINVENTARIOID_html1X77( A121RubrosId, A137MedidasID) ;
            /* Using cursor T001X28 */
            pr_default.execute(26, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
            A181InventarioPrecioFinal = T001X28_A181InventarioPrecioFinal[0];
            pr_default.close(26);
            if ( ( A515ComisionesAgruparRubrosValor > Convert.ToDecimal( 0 )) )
            {
               A517ComisionesAgruparRubrosGan = (decimal)((A181InventarioPrecioFinal*(A515ComisionesAgruparRubrosValor/ (decimal)(100))));
            }
            else
            {
               A517ComisionesAgruparRubrosGan = 0;
            }
         }
      }

      protected void EndLevel1X77( )
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

      public void ScanStart1X77( )
      {
         /* Scan By routine */
         /* Using cursor T001X29 */
         pr_default.execute(27, new Object[] {A503ComisionesID});
         RcdFound77 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound77 = 1;
            A513ComisionesAgruparRubrosId = T001X29_A513ComisionesAgruparRubrosId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1X77( )
      {
         /* Scan next routine */
         pr_default.readNext(27);
         RcdFound77 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound77 = 1;
            A513ComisionesAgruparRubrosId = T001X29_A513ComisionesAgruparRubrosId[0];
         }
      }

      protected void ScanEnd1X77( )
      {
         pr_default.close(27);
      }

      protected void AfterConfirm1X77( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1X77( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1X77( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1X77( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1X77( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1X77( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1X77( )
      {
         edtRubrosId_Enabled = 0;
         AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         dynMedidasID.Enabled = 0;
         AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_43_Refreshing);
         dynInventarioId.Enabled = 0;
         AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtInventarioPrecioFinal_Enabled = 0;
         AssignProp("", false, edtInventarioPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtComisionesAgruparRubrosValor_Enabled = 0;
         AssignProp("", false, edtComisionesAgruparRubrosValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesAgruparRubrosValor_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtComisionesAgruparRubrosGan_Enabled = 0;
         AssignProp("", false, edtComisionesAgruparRubrosGan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComisionesAgruparRubrosGan_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void send_integrity_lvl_hashes1X77( )
      {
      }

      protected void send_integrity_lvl_hashes1X74( )
      {
      }

      protected void SubsflControlProps_4377( )
      {
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_43_idx;
         imgprompt_121_Internalname = "PROMPT_121_"+sGXsfl_43_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_43_idx;
         imgprompt_137_Internalname = "PROMPT_137_"+sGXsfl_43_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_43_idx;
         imgprompt_135_Internalname = "PROMPT_135_"+sGXsfl_43_idx;
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL_"+sGXsfl_43_idx;
         edtComisionesAgruparRubrosValor_Internalname = "COMISIONESAGRUPARRUBROSVALOR_"+sGXsfl_43_idx;
         edtComisionesAgruparRubrosGan_Internalname = "COMISIONESAGRUPARRUBROSGAN_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_4377( )
      {
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_43_fel_idx;
         imgprompt_121_Internalname = "PROMPT_121_"+sGXsfl_43_fel_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_43_fel_idx;
         imgprompt_137_Internalname = "PROMPT_137_"+sGXsfl_43_fel_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_43_fel_idx;
         imgprompt_135_Internalname = "PROMPT_135_"+sGXsfl_43_fel_idx;
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL_"+sGXsfl_43_fel_idx;
         edtComisionesAgruparRubrosValor_Internalname = "COMISIONESAGRUPARRUBROSVALOR_"+sGXsfl_43_fel_idx;
         edtComisionesAgruparRubrosGan_Internalname = "COMISIONESAGRUPARRUBROSGAN_"+sGXsfl_43_fel_idx;
      }

      protected void AddRow1X77( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_4377( ) ;
         SendRow1X77( ) ;
      }

      protected void SendRow1X77( )
      {
         Gridlevel_rubrosRow = GXWebRow.GetNew(context);
         if ( subGridlevel_rubros_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_rubros_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_rubros_Class, "") != 0 )
            {
               subGridlevel_rubros_Linesclass = subGridlevel_rubros_Class+"Odd";
            }
         }
         else if ( subGridlevel_rubros_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_rubros_Backstyle = 0;
            subGridlevel_rubros_Backcolor = subGridlevel_rubros_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_rubros_Class, "") != 0 )
            {
               subGridlevel_rubros_Linesclass = subGridlevel_rubros_Class+"Uniform";
            }
         }
         else if ( subGridlevel_rubros_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_rubros_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_rubros_Class, "") != 0 )
            {
               subGridlevel_rubros_Linesclass = subGridlevel_rubros_Class+"Odd";
            }
            subGridlevel_rubros_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_rubros_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_rubros_Backstyle = 1;
            if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
            {
               subGridlevel_rubros_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_rubros_Class, "") != 0 )
               {
                  subGridlevel_rubros_Linesclass = subGridlevel_rubros_Class+"Even";
               }
            }
            else
            {
               subGridlevel_rubros_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_rubros_Class, "") != 0 )
               {
                  subGridlevel_rubros_Linesclass = subGridlevel_rubros_Class+"Odd";
               }
            }
         }
         imgprompt_121_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0110.aspx"+"',["+"{Ctrl:gx.dom.el('"+"RUBROSID_"+sGXsfl_43_idx+"'), id:'"+"RUBROSID_"+sGXsfl_43_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_77_"+sGXsfl_43_idx+","+"'', false"+","+"false"+");");
         imgprompt_135_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00r2.aspx"+"',["+"{Ctrl:gx.dom.el('"+"RUBROSID_"+sGXsfl_43_idx+"'), id:'"+"RUBROSID_"+sGXsfl_43_idx+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"MEDIDASID_"+sGXsfl_43_idx+"'), id:'"+"MEDIDASID_"+sGXsfl_43_idx+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"INVENTARIOID_"+sGXsfl_43_idx+"'), id:'"+"INVENTARIOID_"+sGXsfl_43_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_77_"+sGXsfl_43_idx+","+"'', false"+","+"false"+");");
         imgprompt_137_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00q1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"RUBROSID_"+sGXsfl_43_idx+"'), id:'"+"RUBROSID_"+sGXsfl_43_idx+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"MEDIDASID_"+sGXsfl_43_idx+"'), id:'"+"MEDIDASID_"+sGXsfl_43_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_77_"+sGXsfl_43_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_77_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtRubrosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9") : context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtRubrosId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_121_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_121_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_rubrosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_121_Internalname,(string)sImgUrl,(string)imgprompt_121_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_121_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         GXAMEDIDASID_html1X77( A121RubrosId) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_77_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_43_idx + "',43)\"";
         if ( ( dynMedidasID.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "MEDIDASID_" + sGXsfl_43_idx;
            dynMedidasID.Name = GXCCtl;
            dynMedidasID.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynMedidasID,(string)dynMedidasID_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)),(short)1,(string)dynMedidasID_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynMedidasID.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"",(bool)true,(short)0});
         dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         AssignProp("", false, dynMedidasID_Internalname, "Values", (string)(dynMedidasID.ToJavascriptSource()), !bGXsfl_43_Refreshing);
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_137_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_137_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_rubrosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_137_Internalname,(string)sImgUrl,(string)imgprompt_137_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_137_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         GXAINVENTARIOID_html1X77( A121RubrosId, A137MedidasID) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_77_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_43_idx + "',43)\"";
         if ( ( dynInventarioId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "INVENTARIOID_" + sGXsfl_43_idx;
            dynInventarioId.Name = GXCCtl;
            dynInventarioId.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynInventarioId,(string)dynInventarioId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0)),(short)1,(string)dynInventarioId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynInventarioId.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"",(string)"",(bool)true,(short)0});
         dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         AssignProp("", false, dynInventarioId_Internalname, "Values", (string)(dynInventarioId.ToJavascriptSource()), !bGXsfl_43_Refreshing);
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_135_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_135_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_rubrosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_135_Internalname,(string)sImgUrl,(string)imgprompt_135_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_135_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_77_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtInventarioPrecioFinal_Enabled!=0) ? context.localUtil.Format( A181InventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A181InventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,47);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtInventarioPrecioFinal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_77_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtComisionesAgruparRubrosValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A515ComisionesAgruparRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtComisionesAgruparRubrosValor_Enabled!=0) ? context.localUtil.Format( A515ComisionesAgruparRubrosValor, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A515ComisionesAgruparRubrosValor, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,48);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtComisionesAgruparRubrosValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtComisionesAgruparRubrosValor_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_77_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtComisionesAgruparRubrosGan_Internalname,StringUtil.LTrim( StringUtil.NToC( A517ComisionesAgruparRubrosGan, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtComisionesAgruparRubrosGan_Enabled!=0) ? context.localUtil.Format( A517ComisionesAgruparRubrosGan, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A517ComisionesAgruparRubrosGan, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtComisionesAgruparRubrosGan_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtComisionesAgruparRubrosGan_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)43,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_rubrosRow);
         send_integrity_lvl_hashes1X77( ) ;
         GXCCtl = "COMISIONESAGRUPARRUBROSID_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(A513ComisionesAgruparRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z513ComisionesAgruparRubrosId_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z513ComisionesAgruparRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z515ComisionesAgruparRubrosValor_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z515ComisionesAgruparRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z121RubrosId_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z137MedidasID_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z135InventarioId_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_77_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_77), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_77_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_77), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_77_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_77), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_43_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vCOMISIONESID_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "RUBROSID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MEDIDASID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOPRECIOFINAL_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMISIONESAGRUPARRUBROSVALOR_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComisionesAgruparRubrosValor_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMISIONESAGRUPARRUBROSGAN_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComisionesAgruparRubrosGan_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_121_"+sGXsfl_43_idx+"Link", StringUtil.RTrim( imgprompt_121_Link));
         GxWebStd.gx_hidden_field( context, "PROMPT_137_"+sGXsfl_43_idx+"Link", StringUtil.RTrim( imgprompt_137_Link));
         GxWebStd.gx_hidden_field( context, "PROMPT_135_"+sGXsfl_43_idx+"Link", StringUtil.RTrim( imgprompt_135_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_rubrosContainer.AddRow(Gridlevel_rubrosRow);
      }

      protected void ReadRow1X77( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_4377( ) ;
         edtRubrosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynMedidasID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynInventarioId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtInventarioPrecioFinal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOPRECIOFINAL_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtComisionesAgruparRubrosValor_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMISIONESAGRUPARRUBROSVALOR_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtComisionesAgruparRubrosGan_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMISIONESAGRUPARRUBROSGAN_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_121_Link = cgiGet( "PROMPT_121_"+sGXsfl_43_idx+"Link");
         imgprompt_121_Link = cgiGet( "PROMPT_137_"+sGXsfl_43_idx+"Link");
         imgprompt_121_Link = cgiGet( "PROMPT_135_"+sGXsfl_43_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_43_idx;
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
         dynMedidasID.Name = dynMedidasID_Internalname;
         dynMedidasID.CurrentValue = cgiGet( dynMedidasID_Internalname);
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynMedidasID_Internalname), "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         n137MedidasID = ((0==A137MedidasID) ? true : false);
         dynInventarioId.Name = dynInventarioId_Internalname;
         dynInventarioId.CurrentValue = cgiGet( dynInventarioId_Internalname);
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynInventarioId_Internalname), "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         n135InventarioId = ((0==A135InventarioId) ? true : false);
         A181InventarioPrecioFinal = context.localUtil.CToN( cgiGet( edtInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         if ( ( ( context.localUtil.CToN( cgiGet( edtComisionesAgruparRubrosValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComisionesAgruparRubrosValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
         {
            GXCCtl = "COMISIONESAGRUPARRUBROSVALOR_" + sGXsfl_43_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtComisionesAgruparRubrosValor_Internalname;
            wbErr = true;
            A515ComisionesAgruparRubrosValor = 0;
         }
         else
         {
            A515ComisionesAgruparRubrosValor = context.localUtil.CToN( cgiGet( edtComisionesAgruparRubrosValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         }
         A517ComisionesAgruparRubrosGan = context.localUtil.CToN( cgiGet( edtComisionesAgruparRubrosGan_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "COMISIONESAGRUPARRUBROSID_" + sGXsfl_43_idx;
         A513ComisionesAgruparRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z513ComisionesAgruparRubrosId_" + sGXsfl_43_idx;
         Z513ComisionesAgruparRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z515ComisionesAgruparRubrosValor_" + sGXsfl_43_idx;
         Z515ComisionesAgruparRubrosValor = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z121RubrosId_" + sGXsfl_43_idx;
         Z121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z137MedidasID_" + sGXsfl_43_idx;
         Z137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n137MedidasID = ((0==A137MedidasID) ? true : false);
         GXCCtl = "Z135InventarioId_" + sGXsfl_43_idx;
         Z135InventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n135InventarioId = ((0==A135InventarioId) ? true : false);
         GXCCtl = "nRcdDeleted_77_" + sGXsfl_43_idx;
         nRcdDeleted_77 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_77_" + sGXsfl_43_idx;
         nRcdExists_77 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_77_" + sGXsfl_43_idx;
         nIsMod_77 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1X0( )
      {
         nGXsfl_43_idx = 0;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_4377( ) ;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_4377( ) ;
            ChangePostValue( "Z513ComisionesAgruparRubrosId_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z513ComisionesAgruparRubrosId_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z513ComisionesAgruparRubrosId_"+sGXsfl_43_idx) ;
            ChangePostValue( "Z515ComisionesAgruparRubrosValor_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z515ComisionesAgruparRubrosValor_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z515ComisionesAgruparRubrosValor_"+sGXsfl_43_idx) ;
            ChangePostValue( "Z121RubrosId_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z121RubrosId_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_43_idx) ;
            ChangePostValue( "Z137MedidasID_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z137MedidasID_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_43_idx) ;
            ChangePostValue( "Z135InventarioId_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z135InventarioId_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_43_idx) ;
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
         GXEncryptionTmp = "comisionesagrupar.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ComisionesID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("comisionesagrupar.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ComisionesAgrupar");
         forbiddenHiddens.Add("ComisionesID", context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("ComisionesTipo", StringUtil.RTrim( context.localUtil.Format( A505ComisionesTipo, "")));
         forbiddenHiddens.Add("ComisionesNombre", StringUtil.RTrim( context.localUtil.Format( A504ComisionesNombre, "")));
         forbiddenHiddens.Add("ComisionesDefault", context.localUtil.Format( A506ComisionesDefault, "ZZ9.99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("comisionesagrupar:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z503ComisionesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z503ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z505ComisionesTipo", StringUtil.RTrim( Z505ComisionesTipo));
         GxWebStd.gx_hidden_field( context, "Z504ComisionesNombre", StringUtil.RTrim( Z504ComisionesNombre));
         GxWebStd.gx_hidden_field( context, "Z506ComisionesDefault", StringUtil.LTrim( StringUtil.NToC( Z506ComisionesDefault, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z512ComisionesInventarioEnum", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z512ComisionesInventarioEnum), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O512ComisionesInventarioEnum", StringUtil.LTrim( StringUtil.NToC( (decimal)(O512ComisionesInventarioEnum), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_43_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vCOMISIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOMISIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ComisionesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COMISIONESINVENTARIOENUM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A512ComisionesInventarioEnum), 6, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV26Pgmname));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "COMISIONESAGRUPARRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A513ComisionesAgruparRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GXEncryptionTmp = "comisionesagrupar.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ComisionesID,18,0));
         return formatLink("comisionesagrupar.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ComisionesAgrupar" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Agrupación de Comisiones", "") ;
      }

      protected void InitializeNonKey1X74( )
      {
         A505ComisionesTipo = "";
         AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
         A504ComisionesNombre = "";
         AssignAttri("", false, "A504ComisionesNombre", A504ComisionesNombre);
         A506ComisionesDefault = 0;
         n506ComisionesDefault = false;
         AssignAttri("", false, "A506ComisionesDefault", StringUtil.LTrimStr( A506ComisionesDefault, 6, 2));
         n506ComisionesDefault = ((Convert.ToDecimal(0)==A506ComisionesDefault) ? true : false);
         A512ComisionesInventarioEnum = 0;
         n512ComisionesInventarioEnum = false;
         AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
         O512ComisionesInventarioEnum = A512ComisionesInventarioEnum;
         n512ComisionesInventarioEnum = false;
         AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
         Z505ComisionesTipo = "";
         Z504ComisionesNombre = "";
         Z506ComisionesDefault = 0;
         Z512ComisionesInventarioEnum = 0;
      }

      protected void InitAll1X74( )
      {
         A503ComisionesID = 0;
         AssignAttri("", false, "A503ComisionesID", StringUtil.LTrimStr( (decimal)(A503ComisionesID), 18, 0));
         InitializeNonKey1X74( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1X77( )
      {
         A517ComisionesAgruparRubrosGan = 0;
         A121RubrosId = 0;
         A137MedidasID = 0;
         n137MedidasID = false;
         A135InventarioId = 0;
         n135InventarioId = false;
         A181InventarioPrecioFinal = 0;
         A515ComisionesAgruparRubrosValor = 0;
         Z515ComisionesAgruparRubrosValor = 0;
         Z121RubrosId = 0;
         Z137MedidasID = 0;
         Z135InventarioId = 0;
      }

      protected void InitAll1X77( )
      {
         A513ComisionesAgruparRubrosId = 0;
         AssignAttri("", false, "A513ComisionesAgruparRubrosId", StringUtil.LTrimStr( (decimal)(A513ComisionesAgruparRubrosId), 18, 0));
         InitializeNonKey1X77( ) ;
      }

      protected void StandaloneModalInsert1X77( )
      {
         A512ComisionesInventarioEnum = i512ComisionesInventarioEnum;
         n512ComisionesInventarioEnum = false;
         AssignAttri("", false, "A512ComisionesInventarioEnum", StringUtil.LTrimStr( (decimal)(A512ComisionesInventarioEnum), 6, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932083415", true, true, false);
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
         context.AddJavascriptSource("comisionesagrupar.js", "?2026932083415", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties77( )
      {
      }

      protected void StartGridControl43( )
      {
         Gridlevel_rubrosContainer.AddObjectProperty("GridName", "Gridlevel_rubros");
         Gridlevel_rubrosContainer.AddObjectProperty("Header", subGridlevel_rubros_Header);
         Gridlevel_rubrosContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_rubrosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_rubrosContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A515ComisionesAgruparRubrosValor, 18, 2, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComisionesAgruparRubrosValor_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A517ComisionesAgruparRubrosGan, 18, 2, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComisionesAgruparRubrosGan_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Selectedindex), 4, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Allowselection), 1, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Allowhovering), 1, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtComisionesID_Internalname = "COMISIONESID";
         cmbComisionesTipo_Internalname = "COMISIONESTIPO";
         edtComisionesNombre_Internalname = "COMISIONESNOMBRE";
         edtComisionesDefault_Internalname = "COMISIONESDEFAULT";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtRubrosId_Internalname = "RUBROSID";
         dynMedidasID_Internalname = "MEDIDASID";
         dynInventarioId_Internalname = "INVENTARIOID";
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL";
         edtComisionesAgruparRubrosValor_Internalname = "COMISIONESAGRUPARRUBROSVALOR";
         edtComisionesAgruparRubrosGan_Internalname = "COMISIONESAGRUPARRUBROSGAN";
         divTableleaflevel_rubros_Internalname = "TABLELEAFLEVEL_RUBROS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_121_Internalname = "PROMPT_121";
         imgprompt_137_Internalname = "PROMPT_137";
         imgprompt_135_Internalname = "PROMPT_135";
         subGridlevel_rubros_Internalname = "GRIDLEVEL_RUBROS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_rubros_Allowcollapsing = 0;
         subGridlevel_rubros_Allowselection = 0;
         subGridlevel_rubros_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Agrupación de Comisiones", "");
         edtComisionesAgruparRubrosGan_Jsonclick = "";
         edtComisionesAgruparRubrosValor_Jsonclick = "";
         edtInventarioPrecioFinal_Jsonclick = "";
         imgprompt_135_Visible = 1;
         imgprompt_135_Link = "";
         dynInventarioId_Jsonclick = "";
         imgprompt_137_Visible = 1;
         imgprompt_137_Link = "";
         dynMedidasID_Jsonclick = "";
         imgprompt_121_Visible = 1;
         imgprompt_121_Link = "";
         imgprompt_121_Visible = 1;
         edtRubrosId_Jsonclick = "";
         subGridlevel_rubros_Class = "WorkWith";
         subGridlevel_rubros_Backcolorstyle = 0;
         edtComisionesAgruparRubrosGan_Enabled = 0;
         edtComisionesAgruparRubrosValor_Enabled = 1;
         edtInventarioPrecioFinal_Enabled = 0;
         dynInventarioId.Enabled = 1;
         dynMedidasID.Enabled = 1;
         edtRubrosId_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtComisionesDefault_Jsonclick = "";
         edtComisionesDefault_Enabled = 0;
         edtComisionesNombre_Jsonclick = "";
         edtComisionesNombre_Enabled = 0;
         cmbComisionesTipo_Jsonclick = "";
         cmbComisionesTipo.Enabled = 0;
         edtComisionesID_Jsonclick = "";
         edtComisionesID_Enabled = 0;
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
         GXAMEDIDASID_html1X77( A121RubrosId) ;
         GXAINVENTARIOID_html1X77( A121RubrosId, A137MedidasID) ;
         /* End function dynload_actions */
      }

      protected void GXDLAMEDIDASID1X77( short A121RubrosId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMEDIDASID_data1X77( A121RubrosId) ;
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

      protected void GXAMEDIDASID_html1X77( short A121RubrosId )
      {
         long gxdynajaxvalue;
         GXDLAMEDIDASID_data1X77( A121RubrosId) ;
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

      protected void GXDLAMEDIDASID_data1X77( short A121RubrosId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T001X30 */
         pr_default.execute(28, new Object[] {A121RubrosId});
         while ( (pr_default.getStatus(28) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001X30_A137MedidasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T001X30_A138MedidasNombre[0]));
            pr_default.readNext(28);
         }
         pr_default.close(28);
      }

      protected void GXDLAINVENTARIOID1X77( short A121RubrosId ,
                                            long A137MedidasID )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAINVENTARIOID_data1X77( A121RubrosId, A137MedidasID) ;
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

      protected void GXAINVENTARIOID_html1X77( short A121RubrosId ,
                                               long A137MedidasID )
      {
         long gxdynajaxvalue;
         GXDLAINVENTARIOID_data1X77( A121RubrosId, A137MedidasID) ;
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

      protected void GXDLAINVENTARIOID_data1X77( short A121RubrosId ,
                                                 long A137MedidasID )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T001X31 */
         pr_default.execute(29, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         while ( (pr_default.getStatus(29) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001X31_A135InventarioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T001X31_A136InventarioNombre[0]));
            pr_default.readNext(29);
         }
         pr_default.close(29);
      }

      protected void gxnrGridlevel_rubros_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_4377( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1X77( ) ;
            standaloneModal1X77( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1X77( ) ;
            nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_4377( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_rubrosContainer)) ;
         /* End function gxnrGridlevel_rubros_newrow */
      }

      protected void init_web_controls( )
      {
         cmbComisionesTipo.Name = "COMISIONESTIPO";
         cmbComisionesTipo.WebTags = "";
         cmbComisionesTipo.addItem("P", context.GetMessage( "Profesional", ""), 0);
         cmbComisionesTipo.addItem("C", context.GetMessage( "Comercio", ""), 0);
         cmbComisionesTipo.addItem("Z", context.GetMessage( "Zona", ""), 0);
         if ( cmbComisionesTipo.ItemCount > 0 )
         {
            A505ComisionesTipo = cmbComisionesTipo.getValidValue(A505ComisionesTipo);
            AssignAttri("", false, "A505ComisionesTipo", A505ComisionesTipo);
         }
         GXCCtl = "MEDIDASID_" + sGXsfl_43_idx;
         dynMedidasID.Name = GXCCtl;
         dynMedidasID.WebTags = "";
         GXCCtl = "INVENTARIOID_" + sGXsfl_43_idx;
         dynInventarioId.Name = GXCCtl;
         dynInventarioId.WebTags = "";
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

      public void Valid_Rubrosid( )
      {
         n137MedidasID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         n135InventarioId = false;
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         /* Using cursor T001X32 */
         pr_default.execute(30, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
         }
         pr_default.close(30);
         dynload_actions( ) ;
         if ( dynMedidasID.ItemCount > 0 )
         {
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         }
         if ( dynInventarioId.ItemCount > 0 )
         {
            A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n135InventarioId = false;
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
         n137MedidasID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         n135InventarioId = false;
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         /* Using cursor T001X33 */
         pr_default.execute(31, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         if ( (pr_default.getStatus(31) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDIDASID");
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
            }
         }
         pr_default.close(31);
         dynload_actions( ) ;
         if ( dynInventarioId.ItemCount > 0 )
         {
            A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n135InventarioId = false;
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
         n137MedidasID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         n135InventarioId = false;
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         /* Using cursor T001X34 */
         pr_default.execute(32, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) || (0==A135InventarioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "INVENTARIOID");
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
            }
         }
         A181InventarioPrecioFinal = T001X34_A181InventarioPrecioFinal[0];
         pr_default.close(32);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A181InventarioPrecioFinal", StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ComisionesID',fld:'vCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ComisionesID',fld:'vCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A503ComisionesID',fld:'COMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbComisionesTipo'},{av:'A505ComisionesTipo',fld:'COMISIONESTIPO',pic:'',type:'char'},{av:'A504ComisionesNombre',fld:'COMISIONESNOMBRE',pic:'',type:'char'},{av:'A506ComisionesDefault',fld:'COMISIONESDEFAULT',pic:'ZZ9.99',type:'decimal'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121X2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_COMISIONESID","{handler:'Valid_Comisionesid',iparms:[]");
         setEventMetadata("VALID_COMISIONESID",",oparms:[]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_RUBROSID",",oparms:[{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_INVENTARIOID","{handler:'Valid_Inventarioid',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A181InventarioPrecioFinal',fld:'INVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]");
         setEventMetadata("VALID_INVENTARIOID",",oparms:[{av:'A181InventarioPrecioFinal',fld:'INVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]}");
         setEventMetadata("VALID_INVENTARIOPRECIOFINAL","{handler:'Valid_Inventariopreciofinal',iparms:[]");
         setEventMetadata("VALID_INVENTARIOPRECIOFINAL",",oparms:[]}");
         setEventMetadata("VALID_COMISIONESAGRUPARRUBROSVALOR","{handler:'Valid_Comisionesagruparrubrosvalor',iparms:[]");
         setEventMetadata("VALID_COMISIONESAGRUPARRUBROSVALOR",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Comisionesagruparrubrosgan',iparms:[]");
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
         pr_default.close(31);
         pr_default.close(32);
         pr_default.close(26);
         pr_default.close(30);
         pr_default.close(6);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z505ComisionesTipo = "";
         Z504ComisionesNombre = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         A505ComisionesTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A504ComisionesNombre = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_rubrosContainer = new GXWebGrid( context);
         sMode77 = "";
         GX_FocusControl = "";
         sStyleString = "";
         AV26Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode74 = "";
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
         T001X9_A503ComisionesID = new long[1] ;
         T001X9_A505ComisionesTipo = new string[] {""} ;
         T001X9_A504ComisionesNombre = new string[] {""} ;
         T001X9_A506ComisionesDefault = new decimal[1] ;
         T001X9_n506ComisionesDefault = new bool[] {false} ;
         T001X9_A512ComisionesInventarioEnum = new int[1] ;
         T001X9_n512ComisionesInventarioEnum = new bool[] {false} ;
         T001X10_A503ComisionesID = new long[1] ;
         T001X8_A503ComisionesID = new long[1] ;
         T001X8_A505ComisionesTipo = new string[] {""} ;
         T001X8_A504ComisionesNombre = new string[] {""} ;
         T001X8_A506ComisionesDefault = new decimal[1] ;
         T001X8_n506ComisionesDefault = new bool[] {false} ;
         T001X8_A512ComisionesInventarioEnum = new int[1] ;
         T001X8_n512ComisionesInventarioEnum = new bool[] {false} ;
         T001X11_A503ComisionesID = new long[1] ;
         T001X12_A503ComisionesID = new long[1] ;
         T001X7_A503ComisionesID = new long[1] ;
         T001X7_A505ComisionesTipo = new string[] {""} ;
         T001X7_A504ComisionesNombre = new string[] {""} ;
         T001X7_A506ComisionesDefault = new decimal[1] ;
         T001X7_n506ComisionesDefault = new bool[] {false} ;
         T001X7_A512ComisionesInventarioEnum = new int[1] ;
         T001X7_n512ComisionesInventarioEnum = new bool[] {false} ;
         T001X13_A503ComisionesID = new long[1] ;
         T001X16_A503ComisionesID = new long[1] ;
         T001X16_A120ProfesionalesId = new string[] {""} ;
         T001X17_A503ComisionesID = new long[1] ;
         T001X17_A133ProveedorID = new long[1] ;
         T001X19_A503ComisionesID = new long[1] ;
         T001X20_A503ComisionesID = new long[1] ;
         T001X20_A513ComisionesAgruparRubrosId = new long[1] ;
         T001X20_A181InventarioPrecioFinal = new decimal[1] ;
         T001X20_A515ComisionesAgruparRubrosValor = new decimal[1] ;
         T001X20_A121RubrosId = new short[1] ;
         T001X20_A137MedidasID = new long[1] ;
         T001X20_n137MedidasID = new bool[] {false} ;
         T001X20_A135InventarioId = new long[1] ;
         T001X20_n135InventarioId = new bool[] {false} ;
         T001X4_A121RubrosId = new short[1] ;
         GXCCtl = "";
         T001X5_A121RubrosId = new short[1] ;
         T001X6_A181InventarioPrecioFinal = new decimal[1] ;
         T001X21_A121RubrosId = new short[1] ;
         T001X22_A121RubrosId = new short[1] ;
         T001X23_A181InventarioPrecioFinal = new decimal[1] ;
         T001X24_A503ComisionesID = new long[1] ;
         T001X24_A513ComisionesAgruparRubrosId = new long[1] ;
         T001X3_A503ComisionesID = new long[1] ;
         T001X3_A513ComisionesAgruparRubrosId = new long[1] ;
         T001X3_A515ComisionesAgruparRubrosValor = new decimal[1] ;
         T001X3_A121RubrosId = new short[1] ;
         T001X3_A137MedidasID = new long[1] ;
         T001X3_n137MedidasID = new bool[] {false} ;
         T001X3_A135InventarioId = new long[1] ;
         T001X3_n135InventarioId = new bool[] {false} ;
         T001X2_A503ComisionesID = new long[1] ;
         T001X2_A513ComisionesAgruparRubrosId = new long[1] ;
         T001X2_A515ComisionesAgruparRubrosValor = new decimal[1] ;
         T001X2_A121RubrosId = new short[1] ;
         T001X2_A137MedidasID = new long[1] ;
         T001X2_n137MedidasID = new bool[] {false} ;
         T001X2_A135InventarioId = new long[1] ;
         T001X2_n135InventarioId = new bool[] {false} ;
         T001X28_A181InventarioPrecioFinal = new decimal[1] ;
         T001X29_A503ComisionesID = new long[1] ;
         T001X29_A513ComisionesAgruparRubrosId = new long[1] ;
         Gridlevel_rubrosRow = new GXWebRow();
         subGridlevel_rubros_Linesclass = "";
         ROClassString = "";
         imgprompt_121_gximage = "";
         sImgUrl = "";
         imgprompt_137_gximage = "";
         imgprompt_135_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_rubrosColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T001X30_A121RubrosId = new short[1] ;
         T001X30_A137MedidasID = new long[1] ;
         T001X30_n137MedidasID = new bool[] {false} ;
         T001X30_A138MedidasNombre = new string[] {""} ;
         T001X30_A139MedidasEstado = new string[] {""} ;
         T001X30_n139MedidasEstado = new bool[] {false} ;
         T001X31_A121RubrosId = new short[1] ;
         T001X31_A137MedidasID = new long[1] ;
         T001X31_n137MedidasID = new bool[] {false} ;
         T001X31_A135InventarioId = new long[1] ;
         T001X31_n135InventarioId = new bool[] {false} ;
         T001X31_A136InventarioNombre = new string[] {""} ;
         T001X31_A107EstadosTipo = new string[] {""} ;
         T001X31_A108EstadosGenericosId = new int[1] ;
         T001X32_A121RubrosId = new short[1] ;
         T001X33_A121RubrosId = new short[1] ;
         T001X34_A181InventarioPrecioFinal = new decimal[1] ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.comisionesagrupar__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesagrupar__default(),
            new Object[][] {
                new Object[] {
               T001X2_A503ComisionesID, T001X2_A513ComisionesAgruparRubrosId, T001X2_A515ComisionesAgruparRubrosValor, T001X2_A121RubrosId, T001X2_A137MedidasID, T001X2_n137MedidasID, T001X2_A135InventarioId, T001X2_n135InventarioId
               }
               , new Object[] {
               T001X3_A503ComisionesID, T001X3_A513ComisionesAgruparRubrosId, T001X3_A515ComisionesAgruparRubrosValor, T001X3_A121RubrosId, T001X3_A137MedidasID, T001X3_n137MedidasID, T001X3_A135InventarioId, T001X3_n135InventarioId
               }
               , new Object[] {
               T001X4_A121RubrosId
               }
               , new Object[] {
               T001X5_A121RubrosId
               }
               , new Object[] {
               T001X6_A181InventarioPrecioFinal
               }
               , new Object[] {
               T001X7_A503ComisionesID, T001X7_A505ComisionesTipo, T001X7_A504ComisionesNombre, T001X7_A506ComisionesDefault, T001X7_n506ComisionesDefault, T001X7_A512ComisionesInventarioEnum, T001X7_n512ComisionesInventarioEnum
               }
               , new Object[] {
               T001X8_A503ComisionesID, T001X8_A505ComisionesTipo, T001X8_A504ComisionesNombre, T001X8_A506ComisionesDefault, T001X8_n506ComisionesDefault, T001X8_A512ComisionesInventarioEnum, T001X8_n512ComisionesInventarioEnum
               }
               , new Object[] {
               T001X9_A503ComisionesID, T001X9_A505ComisionesTipo, T001X9_A504ComisionesNombre, T001X9_A506ComisionesDefault, T001X9_n506ComisionesDefault, T001X9_A512ComisionesInventarioEnum, T001X9_n512ComisionesInventarioEnum
               }
               , new Object[] {
               T001X10_A503ComisionesID
               }
               , new Object[] {
               T001X11_A503ComisionesID
               }
               , new Object[] {
               T001X12_A503ComisionesID
               }
               , new Object[] {
               T001X13_A503ComisionesID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001X16_A503ComisionesID, T001X16_A120ProfesionalesId
               }
               , new Object[] {
               T001X17_A503ComisionesID, T001X17_A133ProveedorID
               }
               , new Object[] {
               }
               , new Object[] {
               T001X19_A503ComisionesID
               }
               , new Object[] {
               T001X20_A503ComisionesID, T001X20_A513ComisionesAgruparRubrosId, T001X20_A181InventarioPrecioFinal, T001X20_A515ComisionesAgruparRubrosValor, T001X20_A121RubrosId, T001X20_A137MedidasID, T001X20_n137MedidasID, T001X20_A135InventarioId, T001X20_n135InventarioId
               }
               , new Object[] {
               T001X21_A121RubrosId
               }
               , new Object[] {
               T001X22_A121RubrosId
               }
               , new Object[] {
               T001X23_A181InventarioPrecioFinal
               }
               , new Object[] {
               T001X24_A503ComisionesID, T001X24_A513ComisionesAgruparRubrosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001X28_A181InventarioPrecioFinal
               }
               , new Object[] {
               T001X29_A503ComisionesID, T001X29_A513ComisionesAgruparRubrosId
               }
               , new Object[] {
               T001X30_A121RubrosId, T001X30_A137MedidasID, T001X30_A138MedidasNombre, T001X30_A139MedidasEstado, T001X30_n139MedidasEstado
               }
               , new Object[] {
               T001X31_A121RubrosId, T001X31_A137MedidasID, T001X31_A135InventarioId, T001X31_A136InventarioNombre, T001X31_A107EstadosTipo, T001X31_A108EstadosGenericosId
               }
               , new Object[] {
               T001X32_A121RubrosId
               }
               , new Object[] {
               T001X33_A121RubrosId
               }
               , new Object[] {
               T001X34_A181InventarioPrecioFinal
               }
            }
         );
         AV26Pgmname = "ComisionesAgrupar";
      }

      private short nIsMod_77 ;
      private short Z121RubrosId ;
      private short nRcdDeleted_77 ;
      private short nRcdExists_77 ;
      private short GxWebError ;
      private short A121RubrosId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount77 ;
      private short RcdFound77 ;
      private short nBlankRcdUsr77 ;
      private short RcdFound74 ;
      private short nIsDirty_77 ;
      private short subGridlevel_rubros_Backcolorstyle ;
      private short subGridlevel_rubros_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_rubros_Allowselection ;
      private short subGridlevel_rubros_Allowhovering ;
      private short subGridlevel_rubros_Allowcollapsing ;
      private short subGridlevel_rubros_Collapsed ;
      private int Z512ComisionesInventarioEnum ;
      private int O512ComisionesInventarioEnum ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int trnEnded ;
      private int A512ComisionesInventarioEnum ;
      private int edtComisionesID_Enabled ;
      private int edtComisionesNombre_Enabled ;
      private int edtComisionesDefault_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int B512ComisionesInventarioEnum ;
      private int edtRubrosId_Enabled ;
      private int edtInventarioPrecioFinal_Enabled ;
      private int edtComisionesAgruparRubrosValor_Enabled ;
      private int edtComisionesAgruparRubrosGan_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int s512ComisionesInventarioEnum ;
      private int subGridlevel_rubros_Backcolor ;
      private int subGridlevel_rubros_Allbackcolor ;
      private int imgprompt_121_Visible ;
      private int imgprompt_137_Visible ;
      private int imgprompt_135_Visible ;
      private int i512ComisionesInventarioEnum ;
      private int idxLst ;
      private int subGridlevel_rubros_Selectedindex ;
      private int subGridlevel_rubros_Selectioncolor ;
      private int subGridlevel_rubros_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long wcpOAV7ComisionesID ;
      private long Z503ComisionesID ;
      private long Z513ComisionesAgruparRubrosId ;
      private long Z137MedidasID ;
      private long Z135InventarioId ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long AV7ComisionesID ;
      private long A503ComisionesID ;
      private long A513ComisionesAgruparRubrosId ;
      private long GRIDLEVEL_RUBROS_nFirstRecordOnPage ;
      private decimal Z506ComisionesDefault ;
      private decimal Z515ComisionesAgruparRubrosValor ;
      private decimal A506ComisionesDefault ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A515ComisionesAgruparRubrosValor ;
      private decimal A517ComisionesAgruparRubrosGan ;
      private decimal Z181InventarioPrecioFinal ;
      private string sPrefix ;
      private string sGXsfl_43_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z505ComisionesTipo ;
      private string Z504ComisionesNombre ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string A505ComisionesTipo ;
      private string cmbComisionesTipo_Internalname ;
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
      private string edtComisionesID_Internalname ;
      private string TempTags ;
      private string edtComisionesID_Jsonclick ;
      private string cmbComisionesTipo_Jsonclick ;
      private string edtComisionesNombre_Internalname ;
      private string A504ComisionesNombre ;
      private string edtComisionesNombre_Jsonclick ;
      private string edtComisionesDefault_Internalname ;
      private string edtComisionesDefault_Jsonclick ;
      private string divTableleaflevel_rubros_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode77 ;
      private string edtRubrosId_Internalname ;
      private string dynMedidasID_Internalname ;
      private string dynInventarioId_Internalname ;
      private string edtInventarioPrecioFinal_Internalname ;
      private string edtComisionesAgruparRubrosValor_Internalname ;
      private string edtComisionesAgruparRubrosGan_Internalname ;
      private string imgprompt_121_Link ;
      private string GX_FocusControl ;
      private string sStyleString ;
      private string subGridlevel_rubros_Internalname ;
      private string AV26Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode74 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string GXCCtl ;
      private string imgprompt_121_Internalname ;
      private string imgprompt_137_Internalname ;
      private string imgprompt_135_Internalname ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string subGridlevel_rubros_Class ;
      private string subGridlevel_rubros_Linesclass ;
      private string imgprompt_135_Link ;
      private string imgprompt_137_Link ;
      private string ROClassString ;
      private string edtRubrosId_Jsonclick ;
      private string imgprompt_121_gximage ;
      private string sImgUrl ;
      private string dynMedidasID_Jsonclick ;
      private string imgprompt_137_gximage ;
      private string dynInventarioId_Jsonclick ;
      private string imgprompt_135_gximage ;
      private string edtInventarioPrecioFinal_Jsonclick ;
      private string edtComisionesAgruparRubrosValor_Jsonclick ;
      private string edtComisionesAgruparRubrosGan_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_rubros_Header ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n137MedidasID ;
      private bool n135InventarioId ;
      private bool wbErr ;
      private bool n512ComisionesInventarioEnum ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool n506ComisionesDefault ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool gxdyncontrolsrefreshing ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_rubrosContainer ;
      private GXWebRow Gridlevel_rubrosRow ;
      private GXWebColumn Gridlevel_rubrosColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbComisionesTipo ;
      private GXCombobox dynMedidasID ;
      private GXCombobox dynInventarioId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T001X9_A503ComisionesID ;
      private string[] T001X9_A505ComisionesTipo ;
      private string[] T001X9_A504ComisionesNombre ;
      private decimal[] T001X9_A506ComisionesDefault ;
      private bool[] T001X9_n506ComisionesDefault ;
      private int[] T001X9_A512ComisionesInventarioEnum ;
      private bool[] T001X9_n512ComisionesInventarioEnum ;
      private long[] T001X10_A503ComisionesID ;
      private long[] T001X8_A503ComisionesID ;
      private string[] T001X8_A505ComisionesTipo ;
      private string[] T001X8_A504ComisionesNombre ;
      private decimal[] T001X8_A506ComisionesDefault ;
      private bool[] T001X8_n506ComisionesDefault ;
      private int[] T001X8_A512ComisionesInventarioEnum ;
      private bool[] T001X8_n512ComisionesInventarioEnum ;
      private long[] T001X11_A503ComisionesID ;
      private long[] T001X12_A503ComisionesID ;
      private long[] T001X7_A503ComisionesID ;
      private string[] T001X7_A505ComisionesTipo ;
      private string[] T001X7_A504ComisionesNombre ;
      private decimal[] T001X7_A506ComisionesDefault ;
      private bool[] T001X7_n506ComisionesDefault ;
      private int[] T001X7_A512ComisionesInventarioEnum ;
      private bool[] T001X7_n512ComisionesInventarioEnum ;
      private long[] T001X13_A503ComisionesID ;
      private long[] T001X16_A503ComisionesID ;
      private string[] T001X16_A120ProfesionalesId ;
      private long[] T001X17_A503ComisionesID ;
      private long[] T001X17_A133ProveedorID ;
      private long[] T001X19_A503ComisionesID ;
      private long[] T001X20_A503ComisionesID ;
      private long[] T001X20_A513ComisionesAgruparRubrosId ;
      private decimal[] T001X20_A181InventarioPrecioFinal ;
      private decimal[] T001X20_A515ComisionesAgruparRubrosValor ;
      private short[] T001X20_A121RubrosId ;
      private long[] T001X20_A137MedidasID ;
      private bool[] T001X20_n137MedidasID ;
      private long[] T001X20_A135InventarioId ;
      private bool[] T001X20_n135InventarioId ;
      private short[] T001X4_A121RubrosId ;
      private short[] T001X5_A121RubrosId ;
      private decimal[] T001X6_A181InventarioPrecioFinal ;
      private short[] T001X21_A121RubrosId ;
      private short[] T001X22_A121RubrosId ;
      private decimal[] T001X23_A181InventarioPrecioFinal ;
      private long[] T001X24_A503ComisionesID ;
      private long[] T001X24_A513ComisionesAgruparRubrosId ;
      private long[] T001X3_A503ComisionesID ;
      private long[] T001X3_A513ComisionesAgruparRubrosId ;
      private decimal[] T001X3_A515ComisionesAgruparRubrosValor ;
      private short[] T001X3_A121RubrosId ;
      private long[] T001X3_A137MedidasID ;
      private bool[] T001X3_n137MedidasID ;
      private long[] T001X3_A135InventarioId ;
      private bool[] T001X3_n135InventarioId ;
      private long[] T001X2_A503ComisionesID ;
      private long[] T001X2_A513ComisionesAgruparRubrosId ;
      private decimal[] T001X2_A515ComisionesAgruparRubrosValor ;
      private short[] T001X2_A121RubrosId ;
      private long[] T001X2_A137MedidasID ;
      private bool[] T001X2_n137MedidasID ;
      private long[] T001X2_A135InventarioId ;
      private bool[] T001X2_n135InventarioId ;
      private decimal[] T001X28_A181InventarioPrecioFinal ;
      private long[] T001X29_A503ComisionesID ;
      private long[] T001X29_A513ComisionesAgruparRubrosId ;
      private short[] T001X30_A121RubrosId ;
      private long[] T001X30_A137MedidasID ;
      private bool[] T001X30_n137MedidasID ;
      private string[] T001X30_A138MedidasNombre ;
      private string[] T001X30_A139MedidasEstado ;
      private bool[] T001X30_n139MedidasEstado ;
      private short[] T001X31_A121RubrosId ;
      private long[] T001X31_A137MedidasID ;
      private bool[] T001X31_n137MedidasID ;
      private long[] T001X31_A135InventarioId ;
      private bool[] T001X31_n135InventarioId ;
      private string[] T001X31_A136InventarioNombre ;
      private string[] T001X31_A107EstadosTipo ;
      private int[] T001X31_A108EstadosGenericosId ;
      private short[] T001X32_A121RubrosId ;
      private short[] T001X33_A121RubrosId ;
      private decimal[] T001X34_A181InventarioPrecioFinal ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class comisionesagrupar__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class comisionesagrupar__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001X2;
        prmT001X2 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmT001X3;
        prmT001X3 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmT001X4;
        prmT001X4 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT001X5;
        prmT001X5 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001X6;
        prmT001X6 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001X7;
        prmT001X7 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001X8;
        prmT001X8 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001X9;
        prmT001X9 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001X10;
        prmT001X10 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001X11;
        prmT001X11 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001X12;
        prmT001X12 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001X13;
        prmT001X13 = new Object[] {
        new ParDef("@ComisionesTipo",GXType.NChar,1,0) ,
        new ParDef("@ComisionesNombre",GXType.NChar,80,0) ,
        new ParDef("@ComisionesDefault",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@ComisionesInventarioEnum",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001X14;
        prmT001X14 = new Object[] {
        new ParDef("@ComisionesTipo",GXType.NChar,1,0) ,
        new ParDef("@ComisionesNombre",GXType.NChar,80,0) ,
        new ParDef("@ComisionesDefault",GXType.Decimal,6,2){Nullable=true} ,
        new ParDef("@ComisionesInventarioEnum",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001X15;
        prmT001X15 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001X16;
        prmT001X16 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001X17;
        prmT001X17 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001X18;
        prmT001X18 = new Object[] {
        new ParDef("@ComisionesInventarioEnum",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001X19;
        prmT001X19 = new Object[] {
        };
        Object[] prmT001X20;
        prmT001X20 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmT001X21;
        prmT001X21 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT001X22;
        prmT001X22 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001X23;
        prmT001X23 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001X24;
        prmT001X24 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmT001X25;
        prmT001X25 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosValor",GXType.Decimal,18,2) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001X26;
        prmT001X26 = new Object[] {
        new ParDef("@ComisionesAgruparRubrosValor",GXType.Decimal,18,2) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmT001X27;
        prmT001X27 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ComisionesAgruparRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmT001X28;
        prmT001X28 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001X29;
        prmT001X29 = new Object[] {
        new ParDef("@ComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001X30;
        prmT001X30 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT001X31;
        prmT001X31 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001X32;
        prmT001X32 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT001X33;
        prmT001X33 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001X34;
        prmT001X34 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T001X2", "SELECT [ComisionesID], [ComisionesAgruparRubrosId], [ComisionesAgruparRubrosValor], [RubrosId], [MedidasID], [InventarioId] FROM [ComisionesAgruparRubros] WITH (UPDLOCK) WHERE [ComisionesID] = @ComisionesID AND [ComisionesAgruparRubrosId] = @ComisionesAgruparRubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X3", "SELECT [ComisionesID], [ComisionesAgruparRubrosId], [ComisionesAgruparRubrosValor], [RubrosId], [MedidasID], [InventarioId] FROM [ComisionesAgruparRubros] WHERE [ComisionesID] = @ComisionesID AND [ComisionesAgruparRubrosId] = @ComisionesAgruparRubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X4", "SELECT [RubrosId] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X5", "SELECT [RubrosId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X6", "SELECT [InventarioPrecioFinal] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X7", "SELECT [ComisionesID], [ComisionesTipo], [ComisionesNombre], [ComisionesDefault], [ComisionesInventarioEnum] FROM [Comisiones] WITH (UPDLOCK) WHERE [ComisionesID] = @ComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X8", "SELECT [ComisionesID], [ComisionesTipo], [ComisionesNombre], [ComisionesDefault], [ComisionesInventarioEnum] FROM [Comisiones] WHERE [ComisionesID] = @ComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X9", "SELECT TM1.[ComisionesID], TM1.[ComisionesTipo], TM1.[ComisionesNombre], TM1.[ComisionesDefault], TM1.[ComisionesInventarioEnum] FROM [Comisiones] TM1 WHERE TM1.[ComisionesID] = @ComisionesID ORDER BY TM1.[ComisionesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001X9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X10", "SELECT [ComisionesID] FROM [Comisiones] WHERE [ComisionesID] = @ComisionesID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001X10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X11", "SELECT TOP 1 [ComisionesID] FROM [Comisiones] WHERE ( [ComisionesID] > @ComisionesID) ORDER BY [ComisionesID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001X11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001X12", "SELECT TOP 1 [ComisionesID] FROM [Comisiones] WHERE ( [ComisionesID] < @ComisionesID) ORDER BY [ComisionesID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001X12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001X13", "INSERT INTO [Comisiones]([ComisionesTipo], [ComisionesNombre], [ComisionesDefault], [ComisionesInventarioEnum], [ComisionesImagen], [ComisionesImagen_GXI], [ComisionesGlobal], [ComisionesFechaAlta], [ComisionesEspermanente], [ComisionesFechaVigencia], [ComisionesFechaVencimiento], [ComisionesEstado], [ComisionesComentario]) VALUES(@ComisionesTipo, @ComisionesNombre, @ComisionesDefault, @ComisionesInventarioEnum, CONVERT(varbinary(1), ''), '', convert(bit, 0), convert( DATETIME, '17530101', 112 ), convert(bit, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', ''); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001X13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001X14", "UPDATE [Comisiones] SET [ComisionesTipo]=@ComisionesTipo, [ComisionesNombre]=@ComisionesNombre, [ComisionesDefault]=@ComisionesDefault, [ComisionesInventarioEnum]=@ComisionesInventarioEnum  WHERE [ComisionesID] = @ComisionesID", GxErrorMask.GX_NOMASK,prmT001X14)
           ,new CursorDef("T001X15", "DELETE FROM [Comisiones]  WHERE [ComisionesID] = @ComisionesID", GxErrorMask.GX_NOMASK,prmT001X15)
           ,new CursorDef("T001X16", "SELECT TOP 1 [ComisionesID], [ProfesionalesId] FROM [ComisionesProfesionales] WHERE [ComisionesID] = @ComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001X17", "SELECT TOP 1 [ComisionesID], [ProveedorID] FROM [ComisionesProveedores] WHERE [ComisionesID] = @ComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001X18", "UPDATE [Comisiones] SET [ComisionesInventarioEnum]=@ComisionesInventarioEnum  WHERE [ComisionesID] = @ComisionesID", GxErrorMask.GX_NOMASK,prmT001X18)
           ,new CursorDef("T001X19", "SELECT [ComisionesID] FROM [Comisiones] ORDER BY [ComisionesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001X19,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X20", "SELECT T1.[ComisionesID], T1.[ComisionesAgruparRubrosId], T2.[InventarioPrecioFinal], T1.[ComisionesAgruparRubrosValor], T1.[RubrosId], T1.[MedidasID], T1.[InventarioId] FROM ([ComisionesAgruparRubros] T1 LEFT JOIN [Inventario] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID] AND T2.[InventarioId] = T1.[InventarioId]) WHERE T1.[ComisionesID] = @ComisionesID and T1.[ComisionesAgruparRubrosId] = @ComisionesAgruparRubrosId ORDER BY T1.[ComisionesID], T1.[ComisionesAgruparRubrosId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X20,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X21", "SELECT [RubrosId] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X22", "SELECT [RubrosId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X23", "SELECT [InventarioPrecioFinal] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X24", "SELECT [ComisionesID], [ComisionesAgruparRubrosId] FROM [ComisionesAgruparRubros] WHERE [ComisionesID] = @ComisionesID AND [ComisionesAgruparRubrosId] = @ComisionesAgruparRubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X25", "INSERT INTO [ComisionesAgruparRubros]([ComisionesID], [ComisionesAgruparRubrosId], [ComisionesAgruparRubrosValor], [RubrosId], [MedidasID], [InventarioId]) VALUES(@ComisionesID, @ComisionesAgruparRubrosId, @ComisionesAgruparRubrosValor, @RubrosId, @MedidasID, @InventarioId)", GxErrorMask.GX_NOMASK,prmT001X25)
           ,new CursorDef("T001X26", "UPDATE [ComisionesAgruparRubros] SET [ComisionesAgruparRubrosValor]=@ComisionesAgruparRubrosValor, [RubrosId]=@RubrosId, [MedidasID]=@MedidasID, [InventarioId]=@InventarioId  WHERE [ComisionesID] = @ComisionesID AND [ComisionesAgruparRubrosId] = @ComisionesAgruparRubrosId", GxErrorMask.GX_NOMASK,prmT001X26)
           ,new CursorDef("T001X27", "DELETE FROM [ComisionesAgruparRubros]  WHERE [ComisionesID] = @ComisionesID AND [ComisionesAgruparRubrosId] = @ComisionesAgruparRubrosId", GxErrorMask.GX_NOMASK,prmT001X27)
           ,new CursorDef("T001X28", "SELECT [InventarioPrecioFinal] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X29", "SELECT [ComisionesID], [ComisionesAgruparRubrosId] FROM [ComisionesAgruparRubros] WHERE [ComisionesID] = @ComisionesID ORDER BY [ComisionesID], [ComisionesAgruparRubrosId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X29,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X30", "SELECT [RubrosId], [MedidasID], [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE ([RubrosId] = @RubrosId) AND ([MedidasEstado] <> 'DES') ORDER BY [MedidasNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X30,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X31", "SELECT [RubrosId], [MedidasID], [InventarioId], [InventarioNombre], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE ([RubrosId] = @RubrosId and [MedidasID] = @MedidasID) AND ([EstadosGenericosId] = 1) ORDER BY [InventarioNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X31,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X32", "SELECT [RubrosId] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X33", "SELECT [RubrosId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001X34", "SELECT [InventarioPrecioFinal] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001X34,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((int[]) buf[5])[0] = rslt.getInt(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((int[]) buf[5])[0] = rslt.getInt(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((int[]) buf[5])[0] = rslt.getInt(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
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
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((long[]) buf[7])[0] = rslt.getLong(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 19 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 20 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 21 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 26 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 28 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 29 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((int[]) buf[5])[0] = rslt.getInt(6);
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 31 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 32 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
     }
  }

}

}

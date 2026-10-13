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
   public class his_solicitudes : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "his_solicitudes.aspx")), "his_solicitudes.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "his_solicitudes.aspx")))) ;
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
                  AV7HistorialID = (int)(Math.Round(NumberUtil.Val( GetPar( "HistorialID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7HistorialID", StringUtil.LTrimStr( (decimal)(AV7HistorialID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vHISTORIALID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7HistorialID), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "HIS_Solicitudes", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSolicitudesID2_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public his_solicitudes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public his_solicitudes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_HistorialID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7HistorialID = aP1_HistorialID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistorialID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistorialID_Internalname, context.GetMessage( "Historial ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistorialID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A909HistorialID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistorialID_Enabled!=0) ? context.localUtil.Format( (decimal)(A909HistorialID), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A909HistorialID), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistorialID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistorialID_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HIS_Solicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSolicitudesID2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSolicitudesID2_Internalname, context.GetMessage( "Solicitudes ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSolicitudesID2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A910SolicitudesID2), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtSolicitudesID2_Enabled!=0) ? context.localUtil.Format( (decimal)(A910SolicitudesID2), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A910SolicitudesID2), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSolicitudesID2_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSolicitudesID2_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HIS_Solicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuario_Internalname, context.GetMessage( "Usuario", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuario_Internalname, A912Usuario, StringUtil.RTrim( context.localUtil.Format( A912Usuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuario_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUsuario_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HIS_Solicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFechaCambio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFechaCambio_Internalname, context.GetMessage( "Fecha Cambio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFechaCambio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFechaCambio_Internalname, context.localUtil.TToC( A911FechaCambio, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A911FechaCambio, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'"+context.GetLanguageProperty( "date_fmt")+"',8,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFechaCambio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtFechaCambio_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HIS_Solicitudes.htm");
         GxWebStd.gx_bitmap( context, edtFechaCambio_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFechaCambio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_HIS_Solicitudes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTipoOperacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoOperacion_Internalname, context.GetMessage( "Tipo Operacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoOperacion_Internalname, StringUtil.RTrim( A913TipoOperacion), StringUtil.RTrim( context.localUtil.Format( A913TipoOperacion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoOperacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTipoOperacion_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HIS_Solicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCampoModificado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCampoModificado_Internalname, context.GetMessage( "Campo Modificado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCampoModificado_Internalname, A914CampoModificado, StringUtil.RTrim( context.localUtil.Format( A914CampoModificado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCampoModificado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCampoModificado_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HIS_Solicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtValorAnterior_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtValorAnterior_Internalname, context.GetMessage( "Valor Anterior", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtValorAnterior_Internalname, A915ValorAnterior, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", 0, 1, edtValorAnterior_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HIS_Solicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtValorNuevo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtValorNuevo_Internalname, context.GetMessage( "Valor Nuevo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtValorNuevo_Internalname, A916ValorNuevo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", 0, 1, edtValorNuevo_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HIS_Solicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtComentario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComentario_Internalname, context.GetMessage( "Comentario", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtComentario_Internalname, A917Comentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", 0, 1, edtComentario_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HIS_Solicitudes.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_HIS_Solicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_HIS_Solicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_HIS_Solicitudes.htm");
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
         E112T2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z909HistorialID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z909HistorialID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z910SolicitudesID2 = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z910SolicitudesID2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z912Usuario = cgiGet( "Z912Usuario");
               Z911FechaCambio = context.localUtil.CToT( cgiGet( "Z911FechaCambio"), 0);
               Z913TipoOperacion = cgiGet( "Z913TipoOperacion");
               Z914CampoModificado = cgiGet( "Z914CampoModificado");
               n914CampoModificado = (String.IsNullOrEmpty(StringUtil.RTrim( A914CampoModificado)) ? true : false);
               Z915ValorAnterior = cgiGet( "Z915ValorAnterior");
               n915ValorAnterior = (String.IsNullOrEmpty(StringUtil.RTrim( A915ValorAnterior)) ? true : false);
               Z916ValorNuevo = cgiGet( "Z916ValorNuevo");
               n916ValorNuevo = (String.IsNullOrEmpty(StringUtil.RTrim( A916ValorNuevo)) ? true : false);
               Z917Comentario = cgiGet( "Z917Comentario");
               n917Comentario = (String.IsNullOrEmpty(StringUtil.RTrim( A917Comentario)) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7HistorialID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vHISTORIALID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Pgmname = cgiGet( "vPGMNAME");
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
               A909HistorialID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtHistorialID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtSolicitudesID2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSolicitudesID2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOLICITUDESID2");
                  AnyError = 1;
                  GX_FocusControl = edtSolicitudesID2_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A910SolicitudesID2 = 0;
                  AssignAttri("", false, "A910SolicitudesID2", StringUtil.LTrimStr( (decimal)(A910SolicitudesID2), 18, 0));
               }
               else
               {
                  A910SolicitudesID2 = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesID2_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A910SolicitudesID2", StringUtil.LTrimStr( (decimal)(A910SolicitudesID2), 18, 0));
               }
               A912Usuario = cgiGet( edtUsuario_Internalname);
               AssignAttri("", false, "A912Usuario", A912Usuario);
               if ( context.localUtil.VCDateTime( cgiGet( edtFechaCambio_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha Cambio", "")}), 1, "FECHACAMBIO");
                  AnyError = 1;
                  GX_FocusControl = edtFechaCambio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A911FechaCambio = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A911FechaCambio", context.localUtil.TToC( A911FechaCambio, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A911FechaCambio = context.localUtil.CToT( cgiGet( edtFechaCambio_Internalname));
                  AssignAttri("", false, "A911FechaCambio", context.localUtil.TToC( A911FechaCambio, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               A913TipoOperacion = cgiGet( edtTipoOperacion_Internalname);
               AssignAttri("", false, "A913TipoOperacion", A913TipoOperacion);
               A914CampoModificado = cgiGet( edtCampoModificado_Internalname);
               n914CampoModificado = false;
               AssignAttri("", false, "A914CampoModificado", A914CampoModificado);
               n914CampoModificado = (String.IsNullOrEmpty(StringUtil.RTrim( A914CampoModificado)) ? true : false);
               A915ValorAnterior = cgiGet( edtValorAnterior_Internalname);
               n915ValorAnterior = false;
               AssignAttri("", false, "A915ValorAnterior", A915ValorAnterior);
               n915ValorAnterior = (String.IsNullOrEmpty(StringUtil.RTrim( A915ValorAnterior)) ? true : false);
               A916ValorNuevo = cgiGet( edtValorNuevo_Internalname);
               n916ValorNuevo = false;
               AssignAttri("", false, "A916ValorNuevo", A916ValorNuevo);
               n916ValorNuevo = (String.IsNullOrEmpty(StringUtil.RTrim( A916ValorNuevo)) ? true : false);
               A917Comentario = cgiGet( edtComentario_Internalname);
               n917Comentario = false;
               AssignAttri("", false, "A917Comentario", A917Comentario);
               n917Comentario = (String.IsNullOrEmpty(StringUtil.RTrim( A917Comentario)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"HIS_Solicitudes");
               A909HistorialID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtHistorialID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
               forbiddenHiddens.Add("HistorialID", context.localUtil.Format( (decimal)(A909HistorialID), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A909HistorialID != Z909HistorialID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("his_solicitudes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A909HistorialID = (int)(Math.Round(NumberUtil.Val( GetPar( "HistorialID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
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
                     sMode133 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode133;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound133 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2T0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "HISTORIALID");
                        AnyError = 1;
                        GX_FocusControl = edtHistorialID_Internalname;
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
                           E112T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122T2 ();
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
            E122T2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2T133( ) ;
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
            DisableAttributes2T133( ) ;
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

      protected void CONFIRM_2T0( )
      {
         BeforeValidate2T133( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2T133( ) ;
            }
            else
            {
               CheckExtendedTable2T133( ) ;
               CloseExtendedTableCursors2T133( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2T0( )
      {
      }

      protected void E112T2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHIS_Solicitudes_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHIS_Solicitudes_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHIS_Solicitudes_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV13Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E122T2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("his_solicitudesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM2T133( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z910SolicitudesID2 = T002T3_A910SolicitudesID2[0];
               Z912Usuario = T002T3_A912Usuario[0];
               Z911FechaCambio = T002T3_A911FechaCambio[0];
               Z913TipoOperacion = T002T3_A913TipoOperacion[0];
               Z914CampoModificado = T002T3_A914CampoModificado[0];
               Z915ValorAnterior = T002T3_A915ValorAnterior[0];
               Z916ValorNuevo = T002T3_A916ValorNuevo[0];
               Z917Comentario = T002T3_A917Comentario[0];
            }
            else
            {
               Z910SolicitudesID2 = A910SolicitudesID2;
               Z912Usuario = A912Usuario;
               Z911FechaCambio = A911FechaCambio;
               Z913TipoOperacion = A913TipoOperacion;
               Z914CampoModificado = A914CampoModificado;
               Z915ValorAnterior = A915ValorAnterior;
               Z916ValorNuevo = A916ValorNuevo;
               Z917Comentario = A917Comentario;
            }
         }
         if ( GX_JID == -4 )
         {
            Z909HistorialID = A909HistorialID;
            Z910SolicitudesID2 = A910SolicitudesID2;
            Z912Usuario = A912Usuario;
            Z911FechaCambio = A911FechaCambio;
            Z913TipoOperacion = A913TipoOperacion;
            Z914CampoModificado = A914CampoModificado;
            Z915ValorAnterior = A915ValorAnterior;
            Z916ValorNuevo = A916ValorNuevo;
            Z917Comentario = A917Comentario;
         }
      }

      protected void standaloneNotModal( )
      {
         edtHistorialID_Enabled = 0;
         AssignProp("", false, edtHistorialID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistorialID_Enabled), 5, 0), true);
         edtHistorialID_Enabled = 0;
         AssignProp("", false, edtHistorialID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistorialID_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7HistorialID) )
         {
            A909HistorialID = AV7HistorialID;
            AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
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

      protected void Load2T133( )
      {
         /* Using cursor T002T4 */
         pr_datastore1.execute(2, new Object[] {A909HistorialID});
         if ( (pr_datastore1.getStatus(2) != 101) )
         {
            RcdFound133 = 1;
            A910SolicitudesID2 = T002T4_A910SolicitudesID2[0];
            AssignAttri("", false, "A910SolicitudesID2", StringUtil.LTrimStr( (decimal)(A910SolicitudesID2), 18, 0));
            A912Usuario = T002T4_A912Usuario[0];
            AssignAttri("", false, "A912Usuario", A912Usuario);
            A911FechaCambio = T002T4_A911FechaCambio[0];
            AssignAttri("", false, "A911FechaCambio", context.localUtil.TToC( A911FechaCambio, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A913TipoOperacion = T002T4_A913TipoOperacion[0];
            AssignAttri("", false, "A913TipoOperacion", A913TipoOperacion);
            A914CampoModificado = T002T4_A914CampoModificado[0];
            n914CampoModificado = T002T4_n914CampoModificado[0];
            AssignAttri("", false, "A914CampoModificado", A914CampoModificado);
            A915ValorAnterior = T002T4_A915ValorAnterior[0];
            n915ValorAnterior = T002T4_n915ValorAnterior[0];
            AssignAttri("", false, "A915ValorAnterior", A915ValorAnterior);
            A916ValorNuevo = T002T4_A916ValorNuevo[0];
            n916ValorNuevo = T002T4_n916ValorNuevo[0];
            AssignAttri("", false, "A916ValorNuevo", A916ValorNuevo);
            A917Comentario = T002T4_A917Comentario[0];
            n917Comentario = T002T4_n917Comentario[0];
            AssignAttri("", false, "A917Comentario", A917Comentario);
            ZM2T133( -4) ;
         }
         pr_datastore1.close(2);
         OnLoadActions2T133( ) ;
      }

      protected void OnLoadActions2T133( )
      {
         AV13Pgmname = "HIS_Solicitudes";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable2T133( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "HIS_Solicitudes";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         if ( ! ( (DateTime.MinValue==A911FechaCambio) || ( A911FechaCambio >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha Cambio", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "FECHACAMBIO");
            AnyError = 1;
            GX_FocusControl = edtFechaCambio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2T133( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2T133( )
      {
         /* Using cursor T002T5 */
         pr_datastore1.execute(3, new Object[] {A909HistorialID});
         if ( (pr_datastore1.getStatus(3) != 101) )
         {
            RcdFound133 = 1;
         }
         else
         {
            RcdFound133 = 0;
         }
         pr_datastore1.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002T3 */
         pr_datastore1.execute(1, new Object[] {A909HistorialID});
         if ( (pr_datastore1.getStatus(1) != 101) )
         {
            ZM2T133( 4) ;
            RcdFound133 = 1;
            A909HistorialID = T002T3_A909HistorialID[0];
            AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
            A910SolicitudesID2 = T002T3_A910SolicitudesID2[0];
            AssignAttri("", false, "A910SolicitudesID2", StringUtil.LTrimStr( (decimal)(A910SolicitudesID2), 18, 0));
            A912Usuario = T002T3_A912Usuario[0];
            AssignAttri("", false, "A912Usuario", A912Usuario);
            A911FechaCambio = T002T3_A911FechaCambio[0];
            AssignAttri("", false, "A911FechaCambio", context.localUtil.TToC( A911FechaCambio, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A913TipoOperacion = T002T3_A913TipoOperacion[0];
            AssignAttri("", false, "A913TipoOperacion", A913TipoOperacion);
            A914CampoModificado = T002T3_A914CampoModificado[0];
            n914CampoModificado = T002T3_n914CampoModificado[0];
            AssignAttri("", false, "A914CampoModificado", A914CampoModificado);
            A915ValorAnterior = T002T3_A915ValorAnterior[0];
            n915ValorAnterior = T002T3_n915ValorAnterior[0];
            AssignAttri("", false, "A915ValorAnterior", A915ValorAnterior);
            A916ValorNuevo = T002T3_A916ValorNuevo[0];
            n916ValorNuevo = T002T3_n916ValorNuevo[0];
            AssignAttri("", false, "A916ValorNuevo", A916ValorNuevo);
            A917Comentario = T002T3_A917Comentario[0];
            n917Comentario = T002T3_n917Comentario[0];
            AssignAttri("", false, "A917Comentario", A917Comentario);
            Z909HistorialID = A909HistorialID;
            sMode133 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2T133( ) ;
            if ( AnyError == 1 )
            {
               RcdFound133 = 0;
               InitializeNonKey2T133( ) ;
            }
            Gx_mode = sMode133;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound133 = 0;
            InitializeNonKey2T133( ) ;
            sMode133 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode133;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_datastore1.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2T133( ) ;
         if ( RcdFound133 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound133 = 0;
         /* Using cursor T002T6 */
         pr_datastore1.execute(4, new Object[] {A909HistorialID});
         if ( (pr_datastore1.getStatus(4) != 101) )
         {
            while ( (pr_datastore1.getStatus(4) != 101) && ( ( T002T6_A909HistorialID[0] < A909HistorialID ) ) )
            {
               pr_datastore1.readNext(4);
            }
            if ( (pr_datastore1.getStatus(4) != 101) && ( ( T002T6_A909HistorialID[0] > A909HistorialID ) ) )
            {
               A909HistorialID = T002T6_A909HistorialID[0];
               AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
               RcdFound133 = 1;
            }
         }
         pr_datastore1.close(4);
      }

      protected void move_previous( )
      {
         RcdFound133 = 0;
         /* Using cursor T002T7 */
         pr_datastore1.execute(5, new Object[] {A909HistorialID});
         if ( (pr_datastore1.getStatus(5) != 101) )
         {
            while ( (pr_datastore1.getStatus(5) != 101) && ( ( T002T7_A909HistorialID[0] > A909HistorialID ) ) )
            {
               pr_datastore1.readNext(5);
            }
            if ( (pr_datastore1.getStatus(5) != 101) && ( ( T002T7_A909HistorialID[0] < A909HistorialID ) ) )
            {
               A909HistorialID = T002T7_A909HistorialID[0];
               AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
               RcdFound133 = 1;
            }
         }
         pr_datastore1.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2T133( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSolicitudesID2_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2T133( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound133 == 1 )
            {
               if ( A909HistorialID != Z909HistorialID )
               {
                  A909HistorialID = Z909HistorialID;
                  AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "HISTORIALID");
                  AnyError = 1;
                  GX_FocusControl = edtHistorialID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSolicitudesID2_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2T133( ) ;
                  GX_FocusControl = edtSolicitudesID2_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A909HistorialID != Z909HistorialID )
               {
                  /* Insert record */
                  GX_FocusControl = edtSolicitudesID2_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2T133( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "HISTORIALID");
                     AnyError = 1;
                     GX_FocusControl = edtHistorialID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSolicitudesID2_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2T133( ) ;
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
         if ( A909HistorialID != Z909HistorialID )
         {
            A909HistorialID = Z909HistorialID;
            AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "HISTORIALID");
            AnyError = 1;
            GX_FocusControl = edtHistorialID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSolicitudesID2_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2T133( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002T2 */
            pr_datastore1.execute(0, new Object[] {A909HistorialID});
            if ( (pr_datastore1.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HIS_Solicitudes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_datastore1.getStatus(0) == 101) || ( Z910SolicitudesID2 != T002T2_A910SolicitudesID2[0] ) || ( StringUtil.StrCmp(Z912Usuario, T002T2_A912Usuario[0]) != 0 ) || ( Z911FechaCambio != T002T2_A911FechaCambio[0] ) || ( StringUtil.StrCmp(Z913TipoOperacion, T002T2_A913TipoOperacion[0]) != 0 ) || ( StringUtil.StrCmp(Z914CampoModificado, T002T2_A914CampoModificado[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z915ValorAnterior, T002T2_A915ValorAnterior[0]) != 0 ) || ( StringUtil.StrCmp(Z916ValorNuevo, T002T2_A916ValorNuevo[0]) != 0 ) || ( StringUtil.StrCmp(Z917Comentario, T002T2_A917Comentario[0]) != 0 ) )
            {
               if ( Z910SolicitudesID2 != T002T2_A910SolicitudesID2[0] )
               {
                  GXUtil.WriteLog("his_solicitudes:[seudo value changed for attri]"+"SolicitudesID2");
                  GXUtil.WriteLogRaw("Old: ",Z910SolicitudesID2);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A910SolicitudesID2[0]);
               }
               if ( StringUtil.StrCmp(Z912Usuario, T002T2_A912Usuario[0]) != 0 )
               {
                  GXUtil.WriteLog("his_solicitudes:[seudo value changed for attri]"+"Usuario");
                  GXUtil.WriteLogRaw("Old: ",Z912Usuario);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A912Usuario[0]);
               }
               if ( Z911FechaCambio != T002T2_A911FechaCambio[0] )
               {
                  GXUtil.WriteLog("his_solicitudes:[seudo value changed for attri]"+"FechaCambio");
                  GXUtil.WriteLogRaw("Old: ",Z911FechaCambio);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A911FechaCambio[0]);
               }
               if ( StringUtil.StrCmp(Z913TipoOperacion, T002T2_A913TipoOperacion[0]) != 0 )
               {
                  GXUtil.WriteLog("his_solicitudes:[seudo value changed for attri]"+"TipoOperacion");
                  GXUtil.WriteLogRaw("Old: ",Z913TipoOperacion);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A913TipoOperacion[0]);
               }
               if ( StringUtil.StrCmp(Z914CampoModificado, T002T2_A914CampoModificado[0]) != 0 )
               {
                  GXUtil.WriteLog("his_solicitudes:[seudo value changed for attri]"+"CampoModificado");
                  GXUtil.WriteLogRaw("Old: ",Z914CampoModificado);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A914CampoModificado[0]);
               }
               if ( StringUtil.StrCmp(Z915ValorAnterior, T002T2_A915ValorAnterior[0]) != 0 )
               {
                  GXUtil.WriteLog("his_solicitudes:[seudo value changed for attri]"+"ValorAnterior");
                  GXUtil.WriteLogRaw("Old: ",Z915ValorAnterior);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A915ValorAnterior[0]);
               }
               if ( StringUtil.StrCmp(Z916ValorNuevo, T002T2_A916ValorNuevo[0]) != 0 )
               {
                  GXUtil.WriteLog("his_solicitudes:[seudo value changed for attri]"+"ValorNuevo");
                  GXUtil.WriteLogRaw("Old: ",Z916ValorNuevo);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A916ValorNuevo[0]);
               }
               if ( StringUtil.StrCmp(Z917Comentario, T002T2_A917Comentario[0]) != 0 )
               {
                  GXUtil.WriteLog("his_solicitudes:[seudo value changed for attri]"+"Comentario");
                  GXUtil.WriteLogRaw("Old: ",Z917Comentario);
                  GXUtil.WriteLogRaw("Current: ",T002T2_A917Comentario[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"HIS_Solicitudes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2T133( )
      {
         BeforeValidate2T133( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2T133( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2T133( 0) ;
            CheckOptimisticConcurrency2T133( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2T133( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2T133( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002T8 */
                     pr_datastore1.execute(6, new Object[] {A910SolicitudesID2, A912Usuario, A911FechaCambio, A913TipoOperacion, n914CampoModificado, A914CampoModificado, n915ValorAnterior, A915ValorAnterior, n916ValorNuevo, A916ValorNuevo, n917Comentario, A917Comentario});
                     A909HistorialID = T002T8_A909HistorialID[0];
                     AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
                     pr_datastore1.close(6);
                     pr_datastore1.SmartCacheProvider.SetUpdated("HIS_Solicitudes");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2T0( ) ;
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
               Load2T133( ) ;
            }
            EndLevel2T133( ) ;
         }
         CloseExtendedTableCursors2T133( ) ;
      }

      protected void Update2T133( )
      {
         BeforeValidate2T133( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2T133( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2T133( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2T133( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2T133( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002T9 */
                     pr_datastore1.execute(7, new Object[] {A910SolicitudesID2, A912Usuario, A911FechaCambio, A913TipoOperacion, n914CampoModificado, A914CampoModificado, n915ValorAnterior, A915ValorAnterior, n916ValorNuevo, A916ValorNuevo, n917Comentario, A917Comentario, A909HistorialID});
                     pr_datastore1.close(7);
                     pr_datastore1.SmartCacheProvider.SetUpdated("HIS_Solicitudes");
                     if ( (pr_datastore1.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HIS_Solicitudes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2T133( ) ;
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
            EndLevel2T133( ) ;
         }
         CloseExtendedTableCursors2T133( ) ;
      }

      protected void DeferredUpdate2T133( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2T133( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2T133( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2T133( ) ;
            AfterConfirm2T133( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2T133( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002T10 */
                  pr_datastore1.execute(8, new Object[] {A909HistorialID});
                  pr_datastore1.close(8);
                  pr_datastore1.SmartCacheProvider.SetUpdated("HIS_Solicitudes");
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
         sMode133 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2T133( ) ;
         Gx_mode = sMode133;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2T133( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "HIS_Solicitudes";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
      }

      protected void EndLevel2T133( )
      {
         if ( ! IsIns( ) )
         {
            pr_datastore1.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2T133( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_datastore1.close(1);
            context.CommitDataStores("his_solicitudes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_datastore1.close(1);
            context.RollbackDataStores("his_solicitudes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2T133( )
      {
         /* Scan By routine */
         /* Using cursor T002T11 */
         pr_datastore1.execute(9);
         RcdFound133 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound133 = 1;
            A909HistorialID = T002T11_A909HistorialID[0];
            AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2T133( )
      {
         /* Scan next routine */
         pr_datastore1.readNext(9);
         RcdFound133 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound133 = 1;
            A909HistorialID = T002T11_A909HistorialID[0];
            AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
         }
      }

      protected void ScanEnd2T133( )
      {
         pr_datastore1.close(9);
      }

      protected void AfterConfirm2T133( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2T133( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2T133( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2T133( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2T133( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2T133( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2T133( )
      {
         edtHistorialID_Enabled = 0;
         AssignProp("", false, edtHistorialID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistorialID_Enabled), 5, 0), true);
         edtSolicitudesID2_Enabled = 0;
         AssignProp("", false, edtSolicitudesID2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSolicitudesID2_Enabled), 5, 0), true);
         edtUsuario_Enabled = 0;
         AssignProp("", false, edtUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuario_Enabled), 5, 0), true);
         edtFechaCambio_Enabled = 0;
         AssignProp("", false, edtFechaCambio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFechaCambio_Enabled), 5, 0), true);
         edtTipoOperacion_Enabled = 0;
         AssignProp("", false, edtTipoOperacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoOperacion_Enabled), 5, 0), true);
         edtCampoModificado_Enabled = 0;
         AssignProp("", false, edtCampoModificado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCampoModificado_Enabled), 5, 0), true);
         edtValorAnterior_Enabled = 0;
         AssignProp("", false, edtValorAnterior_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtValorAnterior_Enabled), 5, 0), true);
         edtValorNuevo_Enabled = 0;
         AssignProp("", false, edtValorNuevo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtValorNuevo_Enabled), 5, 0), true);
         edtComentario_Enabled = 0;
         AssignProp("", false, edtComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComentario_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2T133( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2T0( )
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
         GXEncryptionTmp = "his_solicitudes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7HistorialID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("his_solicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"HIS_Solicitudes");
         forbiddenHiddens.Add("HistorialID", context.localUtil.Format( (decimal)(A909HistorialID), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("his_solicitudes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z909HistorialID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z909HistorialID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z910SolicitudesID2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z910SolicitudesID2), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z912Usuario", Z912Usuario);
         GxWebStd.gx_hidden_field( context, "Z911FechaCambio", context.localUtil.TToC( Z911FechaCambio, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z913TipoOperacion", StringUtil.RTrim( Z913TipoOperacion));
         GxWebStd.gx_hidden_field( context, "Z914CampoModificado", Z914CampoModificado);
         GxWebStd.gx_hidden_field( context, "Z915ValorAnterior", Z915ValorAnterior);
         GxWebStd.gx_hidden_field( context, "Z916ValorNuevo", Z916ValorNuevo);
         GxWebStd.gx_hidden_field( context, "Z917Comentario", Z917Comentario);
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
         GxWebStd.gx_hidden_field( context, "vHISTORIALID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7HistorialID), 9, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vHISTORIALID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7HistorialID), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
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
         GXEncryptionTmp = "his_solicitudes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7HistorialID,9,0));
         return formatLink("his_solicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "HIS_Solicitudes" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "HIS_Solicitudes", "") ;
      }

      protected void InitializeNonKey2T133( )
      {
         A910SolicitudesID2 = 0;
         AssignAttri("", false, "A910SolicitudesID2", StringUtil.LTrimStr( (decimal)(A910SolicitudesID2), 18, 0));
         A912Usuario = "";
         AssignAttri("", false, "A912Usuario", A912Usuario);
         A911FechaCambio = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A911FechaCambio", context.localUtil.TToC( A911FechaCambio, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A913TipoOperacion = "";
         AssignAttri("", false, "A913TipoOperacion", A913TipoOperacion);
         A914CampoModificado = "";
         n914CampoModificado = false;
         AssignAttri("", false, "A914CampoModificado", A914CampoModificado);
         n914CampoModificado = (String.IsNullOrEmpty(StringUtil.RTrim( A914CampoModificado)) ? true : false);
         A915ValorAnterior = "";
         n915ValorAnterior = false;
         AssignAttri("", false, "A915ValorAnterior", A915ValorAnterior);
         n915ValorAnterior = (String.IsNullOrEmpty(StringUtil.RTrim( A915ValorAnterior)) ? true : false);
         A916ValorNuevo = "";
         n916ValorNuevo = false;
         AssignAttri("", false, "A916ValorNuevo", A916ValorNuevo);
         n916ValorNuevo = (String.IsNullOrEmpty(StringUtil.RTrim( A916ValorNuevo)) ? true : false);
         A917Comentario = "";
         n917Comentario = false;
         AssignAttri("", false, "A917Comentario", A917Comentario);
         n917Comentario = (String.IsNullOrEmpty(StringUtil.RTrim( A917Comentario)) ? true : false);
         Z910SolicitudesID2 = 0;
         Z912Usuario = "";
         Z911FechaCambio = (DateTime)(DateTime.MinValue);
         Z913TipoOperacion = "";
         Z914CampoModificado = "";
         Z915ValorAnterior = "";
         Z916ValorNuevo = "";
         Z917Comentario = "";
      }

      protected void InitAll2T133( )
      {
         A909HistorialID = 0;
         AssignAttri("", false, "A909HistorialID", StringUtil.LTrimStr( (decimal)(A909HistorialID), 9, 0));
         InitializeNonKey2T133( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021164171", true, true, false);
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
         context.AddJavascriptSource("his_solicitudes.js", "?202673021164171", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtHistorialID_Internalname = "HISTORIALID";
         edtSolicitudesID2_Internalname = "SOLICITUDESID2";
         edtUsuario_Internalname = "USUARIO";
         edtFechaCambio_Internalname = "FECHACAMBIO";
         edtTipoOperacion_Internalname = "TIPOOPERACION";
         edtCampoModificado_Internalname = "CAMPOMODIFICADO";
         edtValorAnterior_Internalname = "VALORANTERIOR";
         edtValorNuevo_Internalname = "VALORNUEVO";
         edtComentario_Internalname = "COMENTARIO";
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
         Form.Caption = context.GetMessage( "HIS_Solicitudes", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtComentario_Enabled = 1;
         edtValorNuevo_Enabled = 1;
         edtValorAnterior_Enabled = 1;
         edtCampoModificado_Jsonclick = "";
         edtCampoModificado_Enabled = 1;
         edtTipoOperacion_Jsonclick = "";
         edtTipoOperacion_Enabled = 1;
         edtFechaCambio_Jsonclick = "";
         edtFechaCambio_Enabled = 1;
         edtUsuario_Jsonclick = "";
         edtUsuario_Enabled = 1;
         edtSolicitudesID2_Jsonclick = "";
         edtSolicitudesID2_Enabled = 1;
         edtHistorialID_Jsonclick = "";
         edtHistorialID_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7HistorialID',fld:'vHISTORIALID',pic:'ZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7HistorialID',fld:'vHISTORIALID',pic:'ZZZZZZZZ9',hsh:true,type:'int'},{av:'A909HistorialID',fld:'HISTORIALID',pic:'ZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E122T2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_HISTORIALID","{handler:'Valid_Historialid',iparms:[]");
         setEventMetadata("VALID_HISTORIALID",",oparms:[]}");
         setEventMetadata("VALID_FECHACAMBIO","{handler:'Valid_Fechacambio',iparms:[]");
         setEventMetadata("VALID_FECHACAMBIO",",oparms:[]}");
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
         pr_datastore1.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z912Usuario = "";
         Z911FechaCambio = (DateTime)(DateTime.MinValue);
         Z913TipoOperacion = "";
         Z914CampoModificado = "";
         Z915ValorAnterior = "";
         Z916ValorNuevo = "";
         Z917Comentario = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A912Usuario = "";
         A911FechaCambio = (DateTime)(DateTime.MinValue);
         A913TipoOperacion = "";
         A914CampoModificado = "";
         A915ValorAnterior = "";
         A916ValorNuevo = "";
         A917Comentario = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV13Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode133 = "";
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
         T002T4_A909HistorialID = new int[1] ;
         T002T4_A910SolicitudesID2 = new long[1] ;
         T002T4_A912Usuario = new string[] {""} ;
         T002T4_A911FechaCambio = new DateTime[] {DateTime.MinValue} ;
         T002T4_A913TipoOperacion = new string[] {""} ;
         T002T4_A914CampoModificado = new string[] {""} ;
         T002T4_n914CampoModificado = new bool[] {false} ;
         T002T4_A915ValorAnterior = new string[] {""} ;
         T002T4_n915ValorAnterior = new bool[] {false} ;
         T002T4_A916ValorNuevo = new string[] {""} ;
         T002T4_n916ValorNuevo = new bool[] {false} ;
         T002T4_A917Comentario = new string[] {""} ;
         T002T4_n917Comentario = new bool[] {false} ;
         T002T5_A909HistorialID = new int[1] ;
         T002T3_A909HistorialID = new int[1] ;
         T002T3_A910SolicitudesID2 = new long[1] ;
         T002T3_A912Usuario = new string[] {""} ;
         T002T3_A911FechaCambio = new DateTime[] {DateTime.MinValue} ;
         T002T3_A913TipoOperacion = new string[] {""} ;
         T002T3_A914CampoModificado = new string[] {""} ;
         T002T3_n914CampoModificado = new bool[] {false} ;
         T002T3_A915ValorAnterior = new string[] {""} ;
         T002T3_n915ValorAnterior = new bool[] {false} ;
         T002T3_A916ValorNuevo = new string[] {""} ;
         T002T3_n916ValorNuevo = new bool[] {false} ;
         T002T3_A917Comentario = new string[] {""} ;
         T002T3_n917Comentario = new bool[] {false} ;
         T002T6_A909HistorialID = new int[1] ;
         T002T7_A909HistorialID = new int[1] ;
         T002T2_A909HistorialID = new int[1] ;
         T002T2_A910SolicitudesID2 = new long[1] ;
         T002T2_A912Usuario = new string[] {""} ;
         T002T2_A911FechaCambio = new DateTime[] {DateTime.MinValue} ;
         T002T2_A913TipoOperacion = new string[] {""} ;
         T002T2_A914CampoModificado = new string[] {""} ;
         T002T2_n914CampoModificado = new bool[] {false} ;
         T002T2_A915ValorAnterior = new string[] {""} ;
         T002T2_n915ValorAnterior = new bool[] {false} ;
         T002T2_A916ValorNuevo = new string[] {""} ;
         T002T2_n916ValorNuevo = new bool[] {false} ;
         T002T2_A917Comentario = new string[] {""} ;
         T002T2_n917Comentario = new bool[] {false} ;
         T002T8_A909HistorialID = new int[1] ;
         T002T11_A909HistorialID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.his_solicitudes__datastore1(),
            new Object[][] {
                new Object[] {
               T002T2_A909HistorialID, T002T2_A910SolicitudesID2, T002T2_A912Usuario, T002T2_A911FechaCambio, T002T2_A913TipoOperacion, T002T2_A914CampoModificado, T002T2_n914CampoModificado, T002T2_A915ValorAnterior, T002T2_n915ValorAnterior, T002T2_A916ValorNuevo,
               T002T2_n916ValorNuevo, T002T2_A917Comentario, T002T2_n917Comentario
               }
               , new Object[] {
               T002T3_A909HistorialID, T002T3_A910SolicitudesID2, T002T3_A912Usuario, T002T3_A911FechaCambio, T002T3_A913TipoOperacion, T002T3_A914CampoModificado, T002T3_n914CampoModificado, T002T3_A915ValorAnterior, T002T3_n915ValorAnterior, T002T3_A916ValorNuevo,
               T002T3_n916ValorNuevo, T002T3_A917Comentario, T002T3_n917Comentario
               }
               , new Object[] {
               T002T4_A909HistorialID, T002T4_A910SolicitudesID2, T002T4_A912Usuario, T002T4_A911FechaCambio, T002T4_A913TipoOperacion, T002T4_A914CampoModificado, T002T4_n914CampoModificado, T002T4_A915ValorAnterior, T002T4_n915ValorAnterior, T002T4_A916ValorNuevo,
               T002T4_n916ValorNuevo, T002T4_A917Comentario, T002T4_n917Comentario
               }
               , new Object[] {
               T002T5_A909HistorialID
               }
               , new Object[] {
               T002T6_A909HistorialID
               }
               , new Object[] {
               T002T7_A909HistorialID
               }
               , new Object[] {
               T002T8_A909HistorialID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002T11_A909HistorialID
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.his_solicitudes__default(),
            new Object[][] {
            }
         );
         AV13Pgmname = "HIS_Solicitudes";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound133 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7HistorialID ;
      private int Z909HistorialID ;
      private int AV7HistorialID ;
      private int trnEnded ;
      private int A909HistorialID ;
      private int edtHistorialID_Enabled ;
      private int edtSolicitudesID2_Enabled ;
      private int edtUsuario_Enabled ;
      private int edtFechaCambio_Enabled ;
      private int edtTipoOperacion_Enabled ;
      private int edtCampoModificado_Enabled ;
      private int edtValorAnterior_Enabled ;
      private int edtValorNuevo_Enabled ;
      private int edtComentario_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long Z910SolicitudesID2 ;
      private long A910SolicitudesID2 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z913TipoOperacion ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSolicitudesID2_Internalname ;
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
      private string edtHistorialID_Internalname ;
      private string TempTags ;
      private string edtHistorialID_Jsonclick ;
      private string edtSolicitudesID2_Jsonclick ;
      private string edtUsuario_Internalname ;
      private string edtUsuario_Jsonclick ;
      private string edtFechaCambio_Internalname ;
      private string edtFechaCambio_Jsonclick ;
      private string edtTipoOperacion_Internalname ;
      private string A913TipoOperacion ;
      private string edtTipoOperacion_Jsonclick ;
      private string edtCampoModificado_Internalname ;
      private string edtCampoModificado_Jsonclick ;
      private string edtValorAnterior_Internalname ;
      private string edtValorNuevo_Internalname ;
      private string edtComentario_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode133 ;
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
      private DateTime Z911FechaCambio ;
      private DateTime A911FechaCambio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n914CampoModificado ;
      private bool n915ValorAnterior ;
      private bool n916ValorNuevo ;
      private bool n917Comentario ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private string Z912Usuario ;
      private string Z914CampoModificado ;
      private string Z915ValorAnterior ;
      private string Z916ValorNuevo ;
      private string Z917Comentario ;
      private string A912Usuario ;
      private string A914CampoModificado ;
      private string A915ValorAnterior ;
      private string A916ValorNuevo ;
      private string A917Comentario ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] T002T4_A909HistorialID ;
      private long[] T002T4_A910SolicitudesID2 ;
      private string[] T002T4_A912Usuario ;
      private DateTime[] T002T4_A911FechaCambio ;
      private string[] T002T4_A913TipoOperacion ;
      private string[] T002T4_A914CampoModificado ;
      private bool[] T002T4_n914CampoModificado ;
      private string[] T002T4_A915ValorAnterior ;
      private bool[] T002T4_n915ValorAnterior ;
      private string[] T002T4_A916ValorNuevo ;
      private bool[] T002T4_n916ValorNuevo ;
      private string[] T002T4_A917Comentario ;
      private bool[] T002T4_n917Comentario ;
      private int[] T002T5_A909HistorialID ;
      private int[] T002T3_A909HistorialID ;
      private long[] T002T3_A910SolicitudesID2 ;
      private string[] T002T3_A912Usuario ;
      private DateTime[] T002T3_A911FechaCambio ;
      private string[] T002T3_A913TipoOperacion ;
      private string[] T002T3_A914CampoModificado ;
      private bool[] T002T3_n914CampoModificado ;
      private string[] T002T3_A915ValorAnterior ;
      private bool[] T002T3_n915ValorAnterior ;
      private string[] T002T3_A916ValorNuevo ;
      private bool[] T002T3_n916ValorNuevo ;
      private string[] T002T3_A917Comentario ;
      private bool[] T002T3_n917Comentario ;
      private int[] T002T6_A909HistorialID ;
      private int[] T002T7_A909HistorialID ;
      private int[] T002T2_A909HistorialID ;
      private long[] T002T2_A910SolicitudesID2 ;
      private string[] T002T2_A912Usuario ;
      private DateTime[] T002T2_A911FechaCambio ;
      private string[] T002T2_A913TipoOperacion ;
      private string[] T002T2_A914CampoModificado ;
      private bool[] T002T2_n914CampoModificado ;
      private string[] T002T2_A915ValorAnterior ;
      private bool[] T002T2_n915ValorAnterior ;
      private string[] T002T2_A916ValorNuevo ;
      private bool[] T002T2_n916ValorNuevo ;
      private string[] T002T2_A917Comentario ;
      private bool[] T002T2_n917Comentario ;
      private int[] T002T8_A909HistorialID ;
      private IDataStoreProvider pr_default ;
      private int[] T002T11_A909HistorialID ;
   }

   public class his_solicitudes__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002T2;
          prmT002T2 = new Object[] {
          new ParDef("@HistorialID",GXType.Int32,9,0)
          };
          Object[] prmT002T3;
          prmT002T3 = new Object[] {
          new ParDef("@HistorialID",GXType.Int32,9,0)
          };
          Object[] prmT002T4;
          prmT002T4 = new Object[] {
          new ParDef("@HistorialID",GXType.Int32,9,0)
          };
          Object[] prmT002T5;
          prmT002T5 = new Object[] {
          new ParDef("@HistorialID",GXType.Int32,9,0)
          };
          Object[] prmT002T6;
          prmT002T6 = new Object[] {
          new ParDef("@HistorialID",GXType.Int32,9,0)
          };
          Object[] prmT002T7;
          prmT002T7 = new Object[] {
          new ParDef("@HistorialID",GXType.Int32,9,0)
          };
          Object[] prmT002T8;
          prmT002T8 = new Object[] {
          new ParDef("@SolicitudesID2",GXType.Decimal,18,0) ,
          new ParDef("@Usuario",GXType.NVarChar,100,0) ,
          new ParDef("@FechaCambio",GXType.DateTime,10,8) ,
          new ParDef("@TipoOperacion",GXType.NChar,1,0) ,
          new ParDef("@CampoModificado",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@ValorAnterior",GXType.NVarChar,500,0){Nullable=true} ,
          new ParDef("@ValorNuevo",GXType.NVarChar,500,0){Nullable=true} ,
          new ParDef("@Comentario",GXType.NVarChar,200,0){Nullable=true}
          };
          Object[] prmT002T9;
          prmT002T9 = new Object[] {
          new ParDef("@SolicitudesID2",GXType.Decimal,18,0) ,
          new ParDef("@Usuario",GXType.NVarChar,100,0) ,
          new ParDef("@FechaCambio",GXType.DateTime,10,8) ,
          new ParDef("@TipoOperacion",GXType.NChar,1,0) ,
          new ParDef("@CampoModificado",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@ValorAnterior",GXType.NVarChar,500,0){Nullable=true} ,
          new ParDef("@ValorNuevo",GXType.NVarChar,500,0){Nullable=true} ,
          new ParDef("@Comentario",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@HistorialID",GXType.Int32,9,0)
          };
          Object[] prmT002T10;
          prmT002T10 = new Object[] {
          new ParDef("@HistorialID",GXType.Int32,9,0)
          };
          Object[] prmT002T11;
          prmT002T11 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002T2", "SELECT [HistorialID], [SolicitudesID], [Usuario], [FechaCambio], [TipoOperacion], [CampoModificado], [ValorAnterior], [ValorNuevo], [Comentario] FROM dbo.[HIS_Solicitudes] WITH (UPDLOCK) WHERE [HistorialID] = @HistorialID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002T3", "SELECT [HistorialID], [SolicitudesID], [Usuario], [FechaCambio], [TipoOperacion], [CampoModificado], [ValorAnterior], [ValorNuevo], [Comentario] FROM dbo.[HIS_Solicitudes] WHERE [HistorialID] = @HistorialID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002T3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002T4", "SELECT TM1.[HistorialID], TM1.[SolicitudesID], TM1.[Usuario], TM1.[FechaCambio], TM1.[TipoOperacion], TM1.[CampoModificado], TM1.[ValorAnterior], TM1.[ValorNuevo], TM1.[Comentario] FROM dbo.[HIS_Solicitudes] TM1 WHERE TM1.[HistorialID] = @HistorialID ORDER BY TM1.[HistorialID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002T4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002T5", "SELECT [HistorialID] FROM dbo.[HIS_Solicitudes] WHERE [HistorialID] = @HistorialID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002T5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002T6", "SELECT TOP 1 [HistorialID] FROM dbo.[HIS_Solicitudes] WHERE ( [HistorialID] > @HistorialID) ORDER BY [HistorialID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002T6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002T7", "SELECT TOP 1 [HistorialID] FROM dbo.[HIS_Solicitudes] WHERE ( [HistorialID] < @HistorialID) ORDER BY [HistorialID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002T7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002T8", "INSERT INTO dbo.[HIS_Solicitudes]([SolicitudesID], [Usuario], [FechaCambio], [TipoOperacion], [CampoModificado], [ValorAnterior], [ValorNuevo], [Comentario]) VALUES(@SolicitudesID2, @Usuario, @FechaCambio, @TipoOperacion, @CampoModificado, @ValorAnterior, @ValorNuevo, @Comentario); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT002T8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002T9", "UPDATE dbo.[HIS_Solicitudes] SET [SolicitudesID]=@SolicitudesID2, [Usuario]=@Usuario, [FechaCambio]=@FechaCambio, [TipoOperacion]=@TipoOperacion, [CampoModificado]=@CampoModificado, [ValorAnterior]=@ValorAnterior, [ValorNuevo]=@ValorNuevo, [Comentario]=@Comentario  WHERE [HistorialID] = @HistorialID", GxErrorMask.GX_NOMASK,prmT002T9)
             ,new CursorDef("T002T10", "DELETE FROM dbo.[HIS_Solicitudes]  WHERE [HistorialID] = @HistorialID", GxErrorMask.GX_NOMASK,prmT002T10)
             ,new CursorDef("T002T11", "SELECT [HistorialID] FROM dbo.[HIS_Solicitudes] ORDER BY [HistorialID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002T11,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class his_solicitudes__default : DataStoreHelperBase, IDataStoreHelper
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

}

}

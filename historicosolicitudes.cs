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
   public class historicosolicitudes : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_29") == 0 )
         {
            A130EstadosSolTipo = GetPar( "EstadosSolTipo");
            AssignAttri("", false, "A130EstadosSolTipo", A130EstadosSolTipo);
            A131EstadosSolId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosSolId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_29( A130EstadosSolTipo, A131EstadosSolId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
         {
            A128MetodoPagosID = (long)(Math.Round(NumberUtil.Val( GetPar( "MetodoPagosID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_28( A128MetodoPagosID) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_items") == 0 )
         {
            gxnrGridlevel_items_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "historicosolicitudes.aspx")), "historicosolicitudes.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "historicosolicitudes.aspx")))) ;
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
                  AV7HistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "HistoricoSolicitudesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(AV7HistoricoSolicitudesID), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vHISTORICOSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Historico Solicitudes", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_items_newrow_invoke( )
      {
         nRC_GXsfl_168 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_168"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_168_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_168_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_168_idx = GetPar( "sGXsfl_168_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_items_newrow( ) ;
         /* End function gxnrGridlevel_items_newrow_invoke */
      }

      public historicosolicitudes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public historicosolicitudes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_HistoricoSolicitudesID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7HistoricoSolicitudesID = aP1_HistoricoSolicitudesID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbHistoricoSolicitudesPagado = new GXCombobox();
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
         if ( cmbHistoricoSolicitudesPagado.ItemCount > 0 )
         {
            A442HistoricoSolicitudesPagado = cmbHistoricoSolicitudesPagado.getValidValue(A442HistoricoSolicitudesPagado);
            AssignAttri("", false, "A442HistoricoSolicitudesPagado", A442HistoricoSolicitudesPagado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbHistoricoSolicitudesPagado.CurrentValue = StringUtil.RTrim( A442HistoricoSolicitudesPagado);
            AssignProp("", false, cmbHistoricoSolicitudesPagado_Internalname, "Values", cmbHistoricoSolicitudesPagado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesID_Internalname, context.GetMessage( "Solicitudes ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesID_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesNombre_Internalname, context.GetMessage( "Solicitudes Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesNombre_Internalname, StringUtil.RTrim( A288HistoricoSolicitudesNombre), StringUtil.RTrim( context.localUtil.Format( A288HistoricoSolicitudesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesTelefono_Internalname, context.GetMessage( "Solicitudes Telefono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A289HistoricoSolicitudesTelefono);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesTelefono_Internalname, StringUtil.RTrim( A289HistoricoSolicitudesTelefono), StringUtil.RTrim( context.localUtil.Format( A289HistoricoSolicitudesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtHistoricoSolicitudesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesMail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesMail_Internalname, context.GetMessage( "Solicitudes Mail", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesMail_Internalname, A290HistoricoSolicitudesMail, StringUtil.RTrim( context.localUtil.Format( A290HistoricoSolicitudesMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A290HistoricoSolicitudesMail, "", "", "", edtHistoricoSolicitudesMail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesMail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoPaisID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoPaisID_Internalname, context.GetMessage( "Pais ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoPaisID_Internalname, StringUtil.RTrim( A315HistoricoPaisID), StringUtil.RTrim( context.localUtil.Format( A315HistoricoPaisID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoPaisID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoPaisID_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoDepartamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoDepartamentoId_Internalname, context.GetMessage( "Departamento Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A316HistoricoDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoDepartamentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A316HistoricoDepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A316HistoricoDepartamentoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoDepartamentoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoDepartamentoId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoDepartamentoMunicipio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoDepartamentoMunicipio_Internalname, context.GetMessage( "Municipio Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoDepartamentoMunicipio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoDepartamentoMunicipio_Enabled!=0) ? context.localUtil.Format( (decimal)(A317HistoricoDepartamentoMunicipio), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A317HistoricoDepartamentoMunicipio), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoDepartamentoMunicipio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoDepartamentoMunicipio_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoZonasID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoZonasID_Internalname, context.GetMessage( "Zonas ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoZonasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A318HistoricoZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoZonasID_Enabled!=0) ? context.localUtil.Format( (decimal)(A318HistoricoZonasID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A318HistoricoZonasID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoZonasID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoZonasID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesDireccion_Internalname, context.GetMessage( "Solicitudes Direccion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtHistoricoSolicitudesDireccion_Internalname, A291HistoricoSolicitudesDireccion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", 0, 1, edtHistoricoSolicitudesDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesAutoEnumer_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesAutoEnumer_Internalname, context.GetMessage( "Auto Enumerar", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesAutoEnumer_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoSolicitudesAutoEnumer_Enabled!=0) ? context.localUtil.Format( (decimal)(A292HistoricoSolicitudesAutoEnumer), "ZZZ9") : context.localUtil.Format( (decimal)(A292HistoricoSolicitudesAutoEnumer), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesAutoEnumer_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesAutoEnumer_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesCotizacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesCotizacion_Internalname, context.GetMessage( "Solicitudes Cotizacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesCotizacion_Internalname, StringUtil.LTrim( StringUtil.NToC( A299HistoricoSolicitudesCotizacion, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoSolicitudesCotizacion_Enabled!=0) ? context.localUtil.Format( A299HistoricoSolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A299HistoricoSolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesCotizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesCotizacion_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesTotal_Internalname, context.GetMessage( "Solicitudes Total", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A300HistoricoSolicitudesTotal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoSolicitudesTotal_Enabled!=0) ? context.localUtil.Format( A300HistoricoSolicitudesTotal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A300HistoricoSolicitudesTotal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesTotal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesTotal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudServicioSolC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudServicioSolC_Internalname, context.GetMessage( "Sol Coti", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudServicioSolC_Internalname, StringUtil.RTrim( A301HistoricoSolicitudServicioSolC), StringUtil.RTrim( context.localUtil.Format( A301HistoricoSolicitudServicioSolC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudServicioSolC_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudServicioSolC_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudServicioPFin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudServicioPFin_Internalname, context.GetMessage( "Servicio PFinal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudServicioPFin_Internalname, StringUtil.LTrim( StringUtil.NToC( A302HistoricoSolicitudServicioPFin, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoSolicitudServicioPFin_Enabled!=0) ? context.localUtil.Format( A302HistoricoSolicitudServicioPFin, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A302HistoricoSolicitudServicioPFin, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudServicioPFin_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudServicioPFin_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosSolTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadosSolTipo_Internalname, context.GetMessage( "Sol Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosSolTipo_Internalname, StringUtil.RTrim( A130EstadosSolTipo), StringUtil.RTrim( context.localUtil.Format( A130EstadosSolTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosSolTipo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosSolTipo_Enabled, 1, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosSolId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadosSolId_Internalname, context.GetMessage( "Sol Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosSolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A131EstadosSolId), "ZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosSolId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosSolId_Enabled, 1, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_130_131_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_130_131_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_130_131_Internalname, sImgUrl, imgprompt_130_131_Link, "", "", context.GetTheme( ), imgprompt_130_131_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesOtros1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesOtros1_Internalname, context.GetMessage( "Solicitudes Otros1", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesOtros1_Internalname, StringUtil.RTrim( A303HistoricoSolicitudesOtros1), StringUtil.RTrim( context.localUtil.Format( A303HistoricoSolicitudesOtros1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesOtros1_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesOtros1_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesOtros2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesOtros2_Internalname, context.GetMessage( "Solicitudes Otros2", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtHistoricoSolicitudesOtros2_Internalname, StringUtil.RTrim( A304HistoricoSolicitudesOtros2), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", 0, 1, edtHistoricoSolicitudesOtros2_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesOtros3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesOtros3_Internalname, context.GetMessage( "Solicitudes Otros3", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtHistoricoSolicitudesOtros3_Internalname, StringUtil.RTrim( A305HistoricoSolicitudesOtros3), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,112);\"", 0, 1, edtHistoricoSolicitudesOtros3_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesFechaAlta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesFechaAlta_Internalname, context.GetMessage( "Fecha Alta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtHistoricoSolicitudesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesFechaAlta_Internalname, context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99"), context.localUtil.Format( A306HistoricoSolicitudesFechaAlta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesFechaAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesFechaAlta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_bitmap( context, edtHistoricoSolicitudesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHistoricoSolicitudesFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_HistoricoSolicitudes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesFechaActua_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesFechaActua_Internalname, context.GetMessage( "Fecha Actualizacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtHistoricoSolicitudesFechaActua_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesFechaActua_Internalname, context.localUtil.TToC( A307HistoricoSolicitudesFechaActua, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A307HistoricoSolicitudesFechaActua, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,122);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesFechaActua_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesFechaActua_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_bitmap( context, edtHistoricoSolicitudesFechaActua_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHistoricoSolicitudesFechaActua_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_HistoricoSolicitudes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesFechaInsta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesFechaInsta_Internalname, context.GetMessage( "Fecha Instalacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtHistoricoSolicitudesFechaInsta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesFechaInsta_Internalname, context.localUtil.Format(A308HistoricoSolicitudesFechaInsta, "99/99/99"), context.localUtil.Format( A308HistoricoSolicitudesFechaInsta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesFechaInsta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesFechaInsta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_bitmap( context, edtHistoricoSolicitudesFechaInsta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHistoricoSolicitudesFechaInsta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_HistoricoSolicitudes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesHoraInstal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesHoraInstal_Internalname, context.GetMessage( "Hora Instalacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesHoraInstal_Internalname, StringUtil.RTrim( A309HistoricoSolicitudesHoraInstal), StringUtil.RTrim( context.localUtil.Format( A309HistoricoSolicitudesHoraInstal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesHoraInstal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesHoraInstal_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesComentario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesComentario_Internalname, context.GetMessage( "Solicitudes Comentario", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtHistoricoSolicitudesComentario_Internalname, A310HistoricoSolicitudesComentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,137);\"", 0, 1, edtHistoricoSolicitudesComentario_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMetodoPagosID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMetodoPagosID_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMetodoPagosID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A128MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,142);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetodoPagosID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMetodoPagosID_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoSolicitudes.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_128_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_128_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_128_Internalname, sImgUrl, imgprompt_128_Link, "", "", context.GetTheme( ), imgprompt_128_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesNota_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesNota_Internalname, context.GetMessage( "Solicitudes Nota", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtHistoricoSolicitudesNota_Internalname, StringUtil.RTrim( A311HistoricoSolicitudesNota), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,147);\"", 0, 1, edtHistoricoSolicitudesNota_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesNotificaci_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesNotificaci_Internalname, context.GetMessage( "Solicitudes Notificacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesNotificaci_Internalname, StringUtil.RTrim( A312HistoricoSolicitudesNotificaci), StringUtil.RTrim( context.localUtil.Format( A312HistoricoSolicitudesNotificaci, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesNotificaci_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesNotificaci_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesOrigenPago_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoricoSolicitudesOrigenPago_Internalname, context.GetMessage( "Origen Pago", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesOrigenPago_Internalname, StringUtil.RTrim( A439HistoricoSolicitudesOrigenPago), StringUtil.RTrim( context.localUtil.Format( A439HistoricoSolicitudesOrigenPago, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesOrigenPago_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesOrigenPago_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbHistoricoSolicitudesPagado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbHistoricoSolicitudesPagado_Internalname, context.GetMessage( "Solicitudes Pagado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbHistoricoSolicitudesPagado, cmbHistoricoSolicitudesPagado_Internalname, StringUtil.RTrim( A442HistoricoSolicitudesPagado), 1, cmbHistoricoSolicitudesPagado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbHistoricoSolicitudesPagado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,162);\"", "", true, 0, "HLP_HistoricoSolicitudes.htm");
         cmbHistoricoSolicitudesPagado.CurrentValue = StringUtil.RTrim( A442HistoricoSolicitudesPagado);
         AssignProp("", false, cmbHistoricoSolicitudesPagado_Internalname, "Values", (string)(cmbHistoricoSolicitudesPagado.ToJavascriptSource()), true);
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
         GxWebStd.gx_div_start( context, divTableleaflevel_items_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_items( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoricoSolicitudes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoricoSolicitudes.htm");
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

      protected void gxdraw_Gridlevel_items( )
      {
         /*  Grid Control  */
         StartGridControl168( ) ;
         nGXsfl_168_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount43 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_43 = 1;
               ScanStart1143( ) ;
               while ( RcdFound43 != 0 )
               {
                  init_level_properties43( ) ;
                  getByPrimaryKey1143( ) ;
                  AddRow1143( ) ;
                  ScanNext1143( ) ;
               }
               ScanEnd1143( ) ;
               nBlankRcdCount43 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B300HistoricoSolicitudesTotal = A300HistoricoSolicitudesTotal;
            AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
            standaloneNotModal1143( ) ;
            standaloneModal1143( ) ;
            sMode43 = Gx_mode;
            while ( nGXsfl_168_idx < nRC_GXsfl_168 )
            {
               bGXsfl_168_Refreshing = true;
               ReadRow1143( ) ;
               edtHistoricoSolicitudesItemsID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESITEMSID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHistoricoSolicitudesItemsID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesItemsID_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtHItemsRubrosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSRUBROSID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHItemsRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsRubrosId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtHItemsRubrosNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSRUBROSNOMBRE_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHItemsRubrosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsRubrosNombre_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtHItemsMedidasID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSMEDIDASID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHItemsMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsMedidasID_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtHItemsInventarioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSINVENTARIOID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHItemsInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsInventarioId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtHItemsInventarioNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSINVENTARIONOMBRE_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHItemsInventarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsInventarioNombre_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtHItemsInventarioPrecioFinal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSINVENTARIOPRECIOFINAL_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHItemsInventarioPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsInventarioPrecioFinal_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtHItemsSolicitudesItemsCantidad_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSSOLICITUDESITEMSCANTIDAD_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHItemsSolicitudesItemsCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsSolicitudesItemsCantidad_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtHistoricoSolicitudesItemsSR_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESITEMSSR_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHistoricoSolicitudesItemsSR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesItemsSR_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtHistoricoSolicitudesItemsCT_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESITEMSCT_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHistoricoSolicitudesItemsCT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesItemsCT_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtHistoricoSolicitudesItemsComis_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESITEMSCOMIS_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHistoricoSolicitudesItemsComis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesItemsComis_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtHItemsSolicitudesItemsPrecioIn_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSSOLICITUDESITEMSPRECIOIN_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHItemsSolicitudesItemsPrecioIn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsSolicitudesItemsPrecioIn_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               edtHItemsSolicitudesMonedaId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSSOLICITUDESMONEDAID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtHItemsSolicitudesMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsSolicitudesMonedaId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
               if ( ( nRcdExists_43 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1143( ) ;
               }
               SendRow1143( ) ;
               bGXsfl_168_Refreshing = false;
            }
            Gx_mode = sMode43;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A300HistoricoSolicitudesTotal = B300HistoricoSolicitudesTotal;
            AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount43 = 5;
            nRcdExists_43 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1143( ) ;
               while ( RcdFound43 != 0 )
               {
                  sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_16843( ) ;
                  init_level_properties43( ) ;
                  standaloneNotModal1143( ) ;
                  getByPrimaryKey1143( ) ;
                  standaloneModal1143( ) ;
                  AddRow1143( ) ;
                  ScanNext1143( ) ;
               }
               ScanEnd1143( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode43 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx+1), 4, 0), 4, "0");
            SubsflControlProps_16843( ) ;
            InitAll1143( ) ;
            init_level_properties43( ) ;
            B300HistoricoSolicitudesTotal = A300HistoricoSolicitudesTotal;
            AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
            nRcdExists_43 = 0;
            nIsMod_43 = 0;
            nRcdDeleted_43 = 0;
            nBlankRcdCount43 = (short)(nBlankRcdUsr43+nBlankRcdCount43);
            fRowAdded = 0;
            while ( nBlankRcdCount43 > 0 )
            {
               standaloneNotModal1143( ) ;
               standaloneModal1143( ) ;
               AddRow1143( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtHistoricoSolicitudesItemsID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount43 = (short)(nBlankRcdCount43-1);
            }
            Gx_mode = sMode43;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A300HistoricoSolicitudesTotal = B300HistoricoSolicitudesTotal;
            AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_itemsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_items", Gridlevel_itemsContainer, subGridlevel_items_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_itemsContainerData", Gridlevel_itemsContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_itemsContainerData"+"V", Gridlevel_itemsContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_itemsContainerData"+"V"+"\" value='"+Gridlevel_itemsContainer.GridValuesHidden()+"'/>") ;
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
         E11112 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z153HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z153HistoricoSolicitudesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z288HistoricoSolicitudesNombre = cgiGet( "Z288HistoricoSolicitudesNombre");
               Z289HistoricoSolicitudesTelefono = cgiGet( "Z289HistoricoSolicitudesTelefono");
               Z290HistoricoSolicitudesMail = cgiGet( "Z290HistoricoSolicitudesMail");
               n290HistoricoSolicitudesMail = (String.IsNullOrEmpty(StringUtil.RTrim( A290HistoricoSolicitudesMail)) ? true : false);
               Z315HistoricoPaisID = cgiGet( "Z315HistoricoPaisID");
               Z316HistoricoDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z316HistoricoDepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z317HistoricoDepartamentoMunicipio = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z317HistoricoDepartamentoMunicipio"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z318HistoricoZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z318HistoricoZonasID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n318HistoricoZonasID = ((0==A318HistoricoZonasID) ? true : false);
               Z291HistoricoSolicitudesDireccion = cgiGet( "Z291HistoricoSolicitudesDireccion");
               Z292HistoricoSolicitudesAutoEnumer = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z292HistoricoSolicitudesAutoEnumer"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z299HistoricoSolicitudesCotizacion = context.localUtil.CToN( cgiGet( "Z299HistoricoSolicitudesCotizacion"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z301HistoricoSolicitudServicioSolC = cgiGet( "Z301HistoricoSolicitudServicioSolC");
               Z303HistoricoSolicitudesOtros1 = cgiGet( "Z303HistoricoSolicitudesOtros1");
               Z304HistoricoSolicitudesOtros2 = cgiGet( "Z304HistoricoSolicitudesOtros2");
               Z305HistoricoSolicitudesOtros3 = cgiGet( "Z305HistoricoSolicitudesOtros3");
               Z306HistoricoSolicitudesFechaAlta = context.localUtil.CToD( cgiGet( "Z306HistoricoSolicitudesFechaAlta"), 0);
               Z307HistoricoSolicitudesFechaActua = context.localUtil.CToT( cgiGet( "Z307HistoricoSolicitudesFechaActua"), 0);
               Z308HistoricoSolicitudesFechaInsta = context.localUtil.CToD( cgiGet( "Z308HistoricoSolicitudesFechaInsta"), 0);
               Z309HistoricoSolicitudesHoraInstal = cgiGet( "Z309HistoricoSolicitudesHoraInstal");
               Z311HistoricoSolicitudesNota = cgiGet( "Z311HistoricoSolicitudesNota");
               Z312HistoricoSolicitudesNotificaci = cgiGet( "Z312HistoricoSolicitudesNotificaci");
               Z439HistoricoSolicitudesOrigenPago = cgiGet( "Z439HistoricoSolicitudesOrigenPago");
               Z442HistoricoSolicitudesPagado = cgiGet( "Z442HistoricoSolicitudesPagado");
               Z623HistoricoSolicitudesComProv = context.localUtil.CToN( cgiGet( "Z623HistoricoSolicitudesComProv"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z626HistoricoSolicitudesComProvP = context.localUtil.CToN( cgiGet( "Z626HistoricoSolicitudesComProvP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z627HistoricoSolicitudesComALM = context.localUtil.CToN( cgiGet( "Z627HistoricoSolicitudesComALM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z628HistoricoSolicitudesComALMP = context.localUtil.CToN( cgiGet( "Z628HistoricoSolicitudesComALMP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z624HistoricoSolicitudesNombreAux = cgiGet( "Z624HistoricoSolicitudesNombreAux");
               Z625HistoricoSolicitudesSubTipo = cgiGet( "Z625HistoricoSolicitudesSubTipo");
               Z633HistoricoSolicitudesProvID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z633HistoricoSolicitudesProvID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z634HistoricoSolicitudesProvNombre = cgiGet( "Z634HistoricoSolicitudesProvNombre");
               Z128MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z128MetodoPagosID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z130EstadosSolTipo = cgiGet( "Z130EstadosSolTipo");
               Z131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z131EstadosSolId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A623HistoricoSolicitudesComProv = context.localUtil.CToN( cgiGet( "Z623HistoricoSolicitudesComProv"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A626HistoricoSolicitudesComProvP = context.localUtil.CToN( cgiGet( "Z626HistoricoSolicitudesComProvP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A627HistoricoSolicitudesComALM = context.localUtil.CToN( cgiGet( "Z627HistoricoSolicitudesComALM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A628HistoricoSolicitudesComALMP = context.localUtil.CToN( cgiGet( "Z628HistoricoSolicitudesComALMP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A624HistoricoSolicitudesNombreAux = cgiGet( "Z624HistoricoSolicitudesNombreAux");
               A625HistoricoSolicitudesSubTipo = cgiGet( "Z625HistoricoSolicitudesSubTipo");
               A633HistoricoSolicitudesProvID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z633HistoricoSolicitudesProvID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A634HistoricoSolicitudesProvNombre = cgiGet( "Z634HistoricoSolicitudesProvNombre");
               O300HistoricoSolicitudesTotal = context.localUtil.CToN( cgiGet( "O300HistoricoSolicitudesTotal"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_168 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_168"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N130EstadosSolTipo = cgiGet( "N130EstadosSolTipo");
               N131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N131EstadosSolId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N128MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N128MetodoPagosID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A623HistoricoSolicitudesComProv = context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESCOMPROV"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A627HistoricoSolicitudesComALM = context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESCOMALM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A629HistoricoSolicitudesComPro = context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESCOMPRO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A626HistoricoSolicitudesComProvP = context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESCOMPROVP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A628HistoricoSolicitudesComALMP = context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESCOMALMP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A630HistoricoSolicitudesComProP = context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESCOMPROP"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AV7HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vHISTORICOSOLICITUDESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV11Insert_EstadosSolTipo = cgiGet( "vINSERT_ESTADOSSOLTIPO");
               AssignAttri("", false, "AV11Insert_EstadosSolTipo", AV11Insert_EstadosSolTipo);
               AV12Insert_EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ESTADOSSOLID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_EstadosSolId", StringUtil.LTrimStr( (decimal)(AV12Insert_EstadosSolId), 5, 0));
               AV13Insert_MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_METODOPAGOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13Insert_MetodoPagosID", StringUtil.LTrimStr( (decimal)(AV13Insert_MetodoPagosID), 18, 0));
               A624HistoricoSolicitudesNombreAux = cgiGet( "HISTORICOSOLICITUDESNOMBREAUX");
               A625HistoricoSolicitudesSubTipo = cgiGet( "HISTORICOSOLICITUDESSUBTIPO");
               A633HistoricoSolicitudesProvID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESPROVID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A634HistoricoSolicitudesProvNombre = cgiGet( "HISTORICOSOLICITUDESPROVNOMBRE");
               A129MetodoPagosNombre = cgiGet( "METODOPAGOSNOMBRE");
               A132EstadosSolNombre = cgiGet( "ESTADOSSOLNOMBRE");
               AV31Pgmname = cgiGet( "vPGMNAME");
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HISTORICOSOLICITUDESID");
                  AnyError = 1;
                  GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A153HistoricoSolicitudesID = 0;
                  AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
               }
               else
               {
                  A153HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
               }
               A288HistoricoSolicitudesNombre = cgiGet( edtHistoricoSolicitudesNombre_Internalname);
               AssignAttri("", false, "A288HistoricoSolicitudesNombre", A288HistoricoSolicitudesNombre);
               A289HistoricoSolicitudesTelefono = cgiGet( edtHistoricoSolicitudesTelefono_Internalname);
               AssignAttri("", false, "A289HistoricoSolicitudesTelefono", A289HistoricoSolicitudesTelefono);
               A290HistoricoSolicitudesMail = cgiGet( edtHistoricoSolicitudesMail_Internalname);
               n290HistoricoSolicitudesMail = false;
               AssignAttri("", false, "A290HistoricoSolicitudesMail", A290HistoricoSolicitudesMail);
               n290HistoricoSolicitudesMail = (String.IsNullOrEmpty(StringUtil.RTrim( A290HistoricoSolicitudesMail)) ? true : false);
               A315HistoricoPaisID = cgiGet( edtHistoricoPaisID_Internalname);
               AssignAttri("", false, "A315HistoricoPaisID", A315HistoricoPaisID);
               if ( ( ( context.localUtil.CToN( cgiGet( edtHistoricoDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHistoricoDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HISTORICODEPARTAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtHistoricoDepartamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A316HistoricoDepartamentoId = 0;
                  AssignAttri("", false, "A316HistoricoDepartamentoId", StringUtil.LTrimStr( (decimal)(A316HistoricoDepartamentoId), 18, 0));
               }
               else
               {
                  A316HistoricoDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A316HistoricoDepartamentoId", StringUtil.LTrimStr( (decimal)(A316HistoricoDepartamentoId), 18, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtHistoricoDepartamentoMunicipio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHistoricoDepartamentoMunicipio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HISTORICODEPARTAMENTOMUNICIPIO");
                  AnyError = 1;
                  GX_FocusControl = edtHistoricoDepartamentoMunicipio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A317HistoricoDepartamentoMunicipio = 0;
                  AssignAttri("", false, "A317HistoricoDepartamentoMunicipio", StringUtil.LTrimStr( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0));
               }
               else
               {
                  A317HistoricoDepartamentoMunicipio = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoDepartamentoMunicipio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A317HistoricoDepartamentoMunicipio", StringUtil.LTrimStr( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtHistoricoZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHistoricoZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HISTORICOZONASID");
                  AnyError = 1;
                  GX_FocusControl = edtHistoricoZonasID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A318HistoricoZonasID = 0;
                  n318HistoricoZonasID = false;
                  AssignAttri("", false, "A318HistoricoZonasID", StringUtil.LTrimStr( (decimal)(A318HistoricoZonasID), 18, 0));
               }
               else
               {
                  A318HistoricoZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n318HistoricoZonasID = false;
                  AssignAttri("", false, "A318HistoricoZonasID", StringUtil.LTrimStr( (decimal)(A318HistoricoZonasID), 18, 0));
               }
               n318HistoricoZonasID = ((0==A318HistoricoZonasID) ? true : false);
               A291HistoricoSolicitudesDireccion = cgiGet( edtHistoricoSolicitudesDireccion_Internalname);
               AssignAttri("", false, "A291HistoricoSolicitudesDireccion", A291HistoricoSolicitudesDireccion);
               if ( ( ( context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesAutoEnumer_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesAutoEnumer_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HISTORICOSOLICITUDESAUTOENUMER");
                  AnyError = 1;
                  GX_FocusControl = edtHistoricoSolicitudesAutoEnumer_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A292HistoricoSolicitudesAutoEnumer = 0;
                  AssignAttri("", false, "A292HistoricoSolicitudesAutoEnumer", StringUtil.LTrimStr( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0));
               }
               else
               {
                  A292HistoricoSolicitudesAutoEnumer = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesAutoEnumer_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A292HistoricoSolicitudesAutoEnumer", StringUtil.LTrimStr( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesCotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesCotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HISTORICOSOLICITUDESCOTIZACION");
                  AnyError = 1;
                  GX_FocusControl = edtHistoricoSolicitudesCotizacion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A299HistoricoSolicitudesCotizacion = 0;
                  AssignAttri("", false, "A299HistoricoSolicitudesCotizacion", StringUtil.LTrimStr( A299HistoricoSolicitudesCotizacion, 18, 2));
               }
               else
               {
                  A299HistoricoSolicitudesCotizacion = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesCotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A299HistoricoSolicitudesCotizacion", StringUtil.LTrimStr( A299HistoricoSolicitudesCotizacion, 18, 2));
               }
               A300HistoricoSolicitudesTotal = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
               A301HistoricoSolicitudServicioSolC = cgiGet( edtHistoricoSolicitudServicioSolC_Internalname);
               AssignAttri("", false, "A301HistoricoSolicitudServicioSolC", A301HistoricoSolicitudServicioSolC);
               A302HistoricoSolicitudServicioPFin = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudServicioPFin_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
               A130EstadosSolTipo = cgiGet( edtEstadosSolTipo_Internalname);
               AssignAttri("", false, "A130EstadosSolTipo", A130EstadosSolTipo);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESTADOSSOLID");
                  AnyError = 1;
                  GX_FocusControl = edtEstadosSolId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A131EstadosSolId = 0;
                  AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
               }
               else
               {
                  A131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
               }
               A303HistoricoSolicitudesOtros1 = cgiGet( edtHistoricoSolicitudesOtros1_Internalname);
               AssignAttri("", false, "A303HistoricoSolicitudesOtros1", A303HistoricoSolicitudesOtros1);
               A304HistoricoSolicitudesOtros2 = cgiGet( edtHistoricoSolicitudesOtros2_Internalname);
               AssignAttri("", false, "A304HistoricoSolicitudesOtros2", A304HistoricoSolicitudesOtros2);
               A305HistoricoSolicitudesOtros3 = cgiGet( edtHistoricoSolicitudesOtros3_Internalname);
               AssignAttri("", false, "A305HistoricoSolicitudesOtros3", A305HistoricoSolicitudesOtros3);
               if ( context.localUtil.VCDate( cgiGet( edtHistoricoSolicitudesFechaAlta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Historico Solicitudes Fecha Alta", "")}), 1, "HISTORICOSOLICITUDESFECHAALTA");
                  AnyError = 1;
                  GX_FocusControl = edtHistoricoSolicitudesFechaAlta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A306HistoricoSolicitudesFechaAlta = DateTime.MinValue;
                  AssignAttri("", false, "A306HistoricoSolicitudesFechaAlta", context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99"));
               }
               else
               {
                  A306HistoricoSolicitudesFechaAlta = context.localUtil.CToD( cgiGet( edtHistoricoSolicitudesFechaAlta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A306HistoricoSolicitudesFechaAlta", context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99"));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtHistoricoSolicitudesFechaActua_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Historico Solicitudes Fecha Actualizacion", "")}), 1, "HISTORICOSOLICITUDESFECHAACTUA");
                  AnyError = 1;
                  GX_FocusControl = edtHistoricoSolicitudesFechaActua_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A307HistoricoSolicitudesFechaActua = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A307HistoricoSolicitudesFechaActua", context.localUtil.TToC( A307HistoricoSolicitudesFechaActua, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A307HistoricoSolicitudesFechaActua = context.localUtil.CToT( cgiGet( edtHistoricoSolicitudesFechaActua_Internalname));
                  AssignAttri("", false, "A307HistoricoSolicitudesFechaActua", context.localUtil.TToC( A307HistoricoSolicitudesFechaActua, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHistoricoSolicitudesFechaInsta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Historico Solicitudes Fecha Instalacion", "")}), 1, "HISTORICOSOLICITUDESFECHAINSTA");
                  AnyError = 1;
                  GX_FocusControl = edtHistoricoSolicitudesFechaInsta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A308HistoricoSolicitudesFechaInsta = DateTime.MinValue;
                  AssignAttri("", false, "A308HistoricoSolicitudesFechaInsta", context.localUtil.Format(A308HistoricoSolicitudesFechaInsta, "99/99/99"));
               }
               else
               {
                  A308HistoricoSolicitudesFechaInsta = context.localUtil.CToD( cgiGet( edtHistoricoSolicitudesFechaInsta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AssignAttri("", false, "A308HistoricoSolicitudesFechaInsta", context.localUtil.Format(A308HistoricoSolicitudesFechaInsta, "99/99/99"));
               }
               A309HistoricoSolicitudesHoraInstal = cgiGet( edtHistoricoSolicitudesHoraInstal_Internalname);
               AssignAttri("", false, "A309HistoricoSolicitudesHoraInstal", A309HistoricoSolicitudesHoraInstal);
               A310HistoricoSolicitudesComentario = cgiGet( edtHistoricoSolicitudesComentario_Internalname);
               AssignAttri("", false, "A310HistoricoSolicitudesComentario", A310HistoricoSolicitudesComentario);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMetodoPagosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMetodoPagosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "METODOPAGOSID");
                  AnyError = 1;
                  GX_FocusControl = edtMetodoPagosID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A128MetodoPagosID = 0;
                  AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
               }
               else
               {
                  A128MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMetodoPagosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
               }
               A311HistoricoSolicitudesNota = cgiGet( edtHistoricoSolicitudesNota_Internalname);
               AssignAttri("", false, "A311HistoricoSolicitudesNota", A311HistoricoSolicitudesNota);
               A312HistoricoSolicitudesNotificaci = cgiGet( edtHistoricoSolicitudesNotificaci_Internalname);
               AssignAttri("", false, "A312HistoricoSolicitudesNotificaci", A312HistoricoSolicitudesNotificaci);
               A439HistoricoSolicitudesOrigenPago = cgiGet( edtHistoricoSolicitudesOrigenPago_Internalname);
               AssignAttri("", false, "A439HistoricoSolicitudesOrigenPago", A439HistoricoSolicitudesOrigenPago);
               cmbHistoricoSolicitudesPagado.Name = cmbHistoricoSolicitudesPagado_Internalname;
               cmbHistoricoSolicitudesPagado.CurrentValue = cgiGet( cmbHistoricoSolicitudesPagado_Internalname);
               A442HistoricoSolicitudesPagado = cgiGet( cmbHistoricoSolicitudesPagado_Internalname);
               AssignAttri("", false, "A442HistoricoSolicitudesPagado", A442HistoricoSolicitudesPagado);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"HistoricoSolicitudes");
               forbiddenHiddens.Add("Insert_EstadosSolTipo", StringUtil.RTrim( context.localUtil.Format( AV11Insert_EstadosSolTipo, "")));
               forbiddenHiddens.Add("Insert_EstadosSolId", context.localUtil.Format( (decimal)(AV12Insert_EstadosSolId), "ZZZZ9"));
               forbiddenHiddens.Add("Insert_MetodoPagosID", context.localUtil.Format( (decimal)(AV13Insert_MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("HistoricoSolicitudesComProv", context.localUtil.Format( A623HistoricoSolicitudesComProv, "ZZZZZZZZZZZZZZ9.99"));
               forbiddenHiddens.Add("HistoricoSolicitudesComProvP", context.localUtil.Format( A626HistoricoSolicitudesComProvP, "ZZ9.99"));
               forbiddenHiddens.Add("HistoricoSolicitudesComALM", context.localUtil.Format( A627HistoricoSolicitudesComALM, "ZZZZZZZZZZZZZZ9.99"));
               forbiddenHiddens.Add("HistoricoSolicitudesComALMP", context.localUtil.Format( A628HistoricoSolicitudesComALMP, "ZZ9.99"));
               forbiddenHiddens.Add("HistoricoSolicitudesNombreAux", StringUtil.RTrim( context.localUtil.Format( A624HistoricoSolicitudesNombreAux, "")));
               forbiddenHiddens.Add("HistoricoSolicitudesSubTipo", StringUtil.RTrim( context.localUtil.Format( A625HistoricoSolicitudesSubTipo, "")));
               forbiddenHiddens.Add("HistoricoSolicitudesProvID", context.localUtil.Format( (decimal)(A633HistoricoSolicitudesProvID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("HistoricoSolicitudesProvNombre", StringUtil.RTrim( context.localUtil.Format( A634HistoricoSolicitudesProvNombre, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A153HistoricoSolicitudesID != Z153HistoricoSolicitudesID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("historicosolicitudes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A153HistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "HistoricoSolicitudesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
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
                     sMode42 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode42;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound42 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_110( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "HISTORICOSOLICITUDESID");
                        AnyError = 1;
                        GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
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
                           E11112 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12112 ();
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
            E12112 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1142( ) ;
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
            DisableAttributes1142( ) ;
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

      protected void CONFIRM_110( )
      {
         BeforeValidate1142( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1142( ) ;
            }
            else
            {
               CheckExtendedTable1142( ) ;
               CloseExtendedTableCursors1142( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode42 = Gx_mode;
            CONFIRM_1143( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode42;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_1143( )
      {
         s300HistoricoSolicitudesTotal = O300HistoricoSolicitudesTotal;
         AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
         s629HistoricoSolicitudesComPro = O629HistoricoSolicitudesComPro;
         AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
         s302HistoricoSolicitudServicioPFin = O302HistoricoSolicitudServicioPFin;
         AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
         nGXsfl_168_idx = 0;
         while ( nGXsfl_168_idx < nRC_GXsfl_168 )
         {
            ReadRow1143( ) ;
            if ( ( nRcdExists_43 != 0 ) || ( nIsMod_43 != 0 ) )
            {
               GetKey1143( ) ;
               if ( ( nRcdExists_43 == 0 ) && ( nRcdDeleted_43 == 0 ) )
               {
                  if ( RcdFound43 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1143( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1143( ) ;
                        CloseExtendedTableCursors1143( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O300HistoricoSolicitudesTotal = A300HistoricoSolicitudesTotal;
                        AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
                        O629HistoricoSolicitudesComPro = A629HistoricoSolicitudesComPro;
                        AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
                        O302HistoricoSolicitudServicioPFin = A302HistoricoSolicitudServicioPFin;
                        AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
                     }
                  }
                  else
                  {
                     GXCCtl = "HISTORICOSOLICITUDESITEMSID_" + sGXsfl_168_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtHistoricoSolicitudesItemsID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound43 != 0 )
                  {
                     if ( nRcdDeleted_43 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1143( ) ;
                        Load1143( ) ;
                        BeforeValidate1143( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1143( ) ;
                           O300HistoricoSolicitudesTotal = A300HistoricoSolicitudesTotal;
                           AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
                           O629HistoricoSolicitudesComPro = A629HistoricoSolicitudesComPro;
                           AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
                           O302HistoricoSolicitudServicioPFin = A302HistoricoSolicitudServicioPFin;
                           AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
                        }
                     }
                     else
                     {
                        if ( nIsMod_43 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1143( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1143( ) ;
                              CloseExtendedTableCursors1143( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O300HistoricoSolicitudesTotal = A300HistoricoSolicitudesTotal;
                              AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
                              O629HistoricoSolicitudesComPro = A629HistoricoSolicitudesComPro;
                              AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
                              O302HistoricoSolicitudServicioPFin = A302HistoricoSolicitudServicioPFin;
                              AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_43 == 0 )
                     {
                        GXCCtl = "HISTORICOSOLICITUDESITEMSID_" + sGXsfl_168_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtHistoricoSolicitudesItemsID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtHistoricoSolicitudesItemsID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A154HistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A330HItemsRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsRubrosNombre_Internalname, StringUtil.RTrim( A331HItemsRubrosNombre)) ;
            ChangePostValue( edtHItemsMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A327HItemsMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A328HItemsInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsInventarioNombre_Internalname, StringUtil.RTrim( A329HItemsInventarioNombre)) ;
            ChangePostValue( edtHItemsInventarioPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A295HItemsInventarioPrecioFinal), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsSolicitudesItemsCantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A293HItemsSolicitudesItemsCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHistoricoSolicitudesItemsSR_Internalname, StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)) ;
            ChangePostValue( edtHistoricoSolicitudesItemsCT_Internalname, StringUtil.RTrim( A297HistoricoSolicitudesItemsCT)) ;
            ChangePostValue( edtHistoricoSolicitudesItemsComis_Internalname, StringUtil.LTrim( StringUtil.NToC( A298HistoricoSolicitudesItemsComis, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsSolicitudesItemsPrecioIn_Internalname, StringUtil.LTrim( StringUtil.NToC( A294HItemsSolicitudesItemsPrecioIn, 21, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsSolicitudesMonedaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A319HItemsSolicitudesMonedaId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z154HistoricoSolicitudesItemsID_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z154HistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z330HItemsRubrosId_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z330HItemsRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z331HItemsRubrosNombre_"+sGXsfl_168_idx, StringUtil.RTrim( Z331HItemsRubrosNombre)) ;
            ChangePostValue( "ZT_"+"Z327HItemsMedidasID_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z327HItemsMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z328HItemsInventarioId_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z328HItemsInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z329HItemsInventarioNombre_"+sGXsfl_168_idx, StringUtil.RTrim( Z329HItemsInventarioNombre)) ;
            ChangePostValue( "ZT_"+"Z295HItemsInventarioPrecioFinal_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z295HItemsInventarioPrecioFinal), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z293HItemsSolicitudesItemsCantidad_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z293HItemsSolicitudesItemsCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z296HistoricoSolicitudesItemsSR_"+sGXsfl_168_idx, StringUtil.RTrim( Z296HistoricoSolicitudesItemsSR)) ;
            ChangePostValue( "ZT_"+"Z297HistoricoSolicitudesItemsCT_"+sGXsfl_168_idx, StringUtil.RTrim( Z297HistoricoSolicitudesItemsCT)) ;
            ChangePostValue( "ZT_"+"Z298HistoricoSolicitudesItemsComis_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( Z298HistoricoSolicitudesItemsComis, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z319HItemsSolicitudesMonedaId_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z319HItemsSolicitudesMonedaId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "T294HItemsSolicitudesItemsPrecioIn_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( O294HItemsSolicitudesItemsPrecioIn, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_43_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_43), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_43_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_43), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_43_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_43), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_43 != 0 )
            {
               ChangePostValue( "HISTORICOSOLICITUDESITEMSID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSRUBROSID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsRubrosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSRUBROSNOMBRE_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsRubrosNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSMEDIDASID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsMedidasID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSINVENTARIOID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsInventarioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSINVENTARIONOMBRE_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsInventarioNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSINVENTARIOPRECIOFINAL_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsInventarioPrecioFinal_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSSOLICITUDESITEMSCANTIDAD_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsSolicitudesItemsCantidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICOSOLICITUDESITEMSSR_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsSR_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICOSOLICITUDESITEMSCT_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsCT_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICOSOLICITUDESITEMSCOMIS_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsComis_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSSOLICITUDESITEMSPRECIOIN_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsSolicitudesItemsPrecioIn_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSSOLICITUDESMONEDAID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsSolicitudesMonedaId_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O300HistoricoSolicitudesTotal = s300HistoricoSolicitudesTotal;
         AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
         O629HistoricoSolicitudesComPro = s629HistoricoSolicitudesComPro;
         AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
         O302HistoricoSolicitudServicioPFin = s302HistoricoSolicitudServicioPFin;
         AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption110( )
      {
      }

      protected void E11112( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV15WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoSolicitudes_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoSolicitudes_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoSolicitudes_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV31Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV31Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV32GXV1 = 1;
            AssignAttri("", false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            while ( AV32GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV32GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "EstadosSolTipo") == 0 )
               {
                  AV11Insert_EstadosSolTipo = AV14TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV11Insert_EstadosSolTipo", AV11Insert_EstadosSolTipo);
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "EstadosSolId") == 0 )
               {
                  AV12Insert_EstadosSolId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_EstadosSolId", StringUtil.LTrimStr( (decimal)(AV12Insert_EstadosSolId), 5, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "MetodoPagosID") == 0 )
               {
                  AV13Insert_MetodoPagosID = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_MetodoPagosID", StringUtil.LTrimStr( (decimal)(AV13Insert_MetodoPagosID), 18, 0));
               }
               AV32GXV1 = (int)(AV32GXV1+1);
               AssignAttri("", false, "AV32GXV1", StringUtil.LTrimStr( (decimal)(AV32GXV1), 8, 0));
            }
         }
      }

      protected void E12112( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("historicosolicitudesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1142( short GX_JID )
      {
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z288HistoricoSolicitudesNombre = T00115_A288HistoricoSolicitudesNombre[0];
               Z289HistoricoSolicitudesTelefono = T00115_A289HistoricoSolicitudesTelefono[0];
               Z290HistoricoSolicitudesMail = T00115_A290HistoricoSolicitudesMail[0];
               Z315HistoricoPaisID = T00115_A315HistoricoPaisID[0];
               Z316HistoricoDepartamentoId = T00115_A316HistoricoDepartamentoId[0];
               Z317HistoricoDepartamentoMunicipio = T00115_A317HistoricoDepartamentoMunicipio[0];
               Z318HistoricoZonasID = T00115_A318HistoricoZonasID[0];
               Z291HistoricoSolicitudesDireccion = T00115_A291HistoricoSolicitudesDireccion[0];
               Z292HistoricoSolicitudesAutoEnumer = T00115_A292HistoricoSolicitudesAutoEnumer[0];
               Z299HistoricoSolicitudesCotizacion = T00115_A299HistoricoSolicitudesCotizacion[0];
               Z301HistoricoSolicitudServicioSolC = T00115_A301HistoricoSolicitudServicioSolC[0];
               Z303HistoricoSolicitudesOtros1 = T00115_A303HistoricoSolicitudesOtros1[0];
               Z304HistoricoSolicitudesOtros2 = T00115_A304HistoricoSolicitudesOtros2[0];
               Z305HistoricoSolicitudesOtros3 = T00115_A305HistoricoSolicitudesOtros3[0];
               Z306HistoricoSolicitudesFechaAlta = T00115_A306HistoricoSolicitudesFechaAlta[0];
               Z307HistoricoSolicitudesFechaActua = T00115_A307HistoricoSolicitudesFechaActua[0];
               Z308HistoricoSolicitudesFechaInsta = T00115_A308HistoricoSolicitudesFechaInsta[0];
               Z309HistoricoSolicitudesHoraInstal = T00115_A309HistoricoSolicitudesHoraInstal[0];
               Z311HistoricoSolicitudesNota = T00115_A311HistoricoSolicitudesNota[0];
               Z312HistoricoSolicitudesNotificaci = T00115_A312HistoricoSolicitudesNotificaci[0];
               Z439HistoricoSolicitudesOrigenPago = T00115_A439HistoricoSolicitudesOrigenPago[0];
               Z442HistoricoSolicitudesPagado = T00115_A442HistoricoSolicitudesPagado[0];
               Z623HistoricoSolicitudesComProv = T00115_A623HistoricoSolicitudesComProv[0];
               Z626HistoricoSolicitudesComProvP = T00115_A626HistoricoSolicitudesComProvP[0];
               Z627HistoricoSolicitudesComALM = T00115_A627HistoricoSolicitudesComALM[0];
               Z628HistoricoSolicitudesComALMP = T00115_A628HistoricoSolicitudesComALMP[0];
               Z624HistoricoSolicitudesNombreAux = T00115_A624HistoricoSolicitudesNombreAux[0];
               Z625HistoricoSolicitudesSubTipo = T00115_A625HistoricoSolicitudesSubTipo[0];
               Z633HistoricoSolicitudesProvID = T00115_A633HistoricoSolicitudesProvID[0];
               Z634HistoricoSolicitudesProvNombre = T00115_A634HistoricoSolicitudesProvNombre[0];
               Z128MetodoPagosID = T00115_A128MetodoPagosID[0];
               Z130EstadosSolTipo = T00115_A130EstadosSolTipo[0];
               Z131EstadosSolId = T00115_A131EstadosSolId[0];
            }
            else
            {
               Z288HistoricoSolicitudesNombre = A288HistoricoSolicitudesNombre;
               Z289HistoricoSolicitudesTelefono = A289HistoricoSolicitudesTelefono;
               Z290HistoricoSolicitudesMail = A290HistoricoSolicitudesMail;
               Z315HistoricoPaisID = A315HistoricoPaisID;
               Z316HistoricoDepartamentoId = A316HistoricoDepartamentoId;
               Z317HistoricoDepartamentoMunicipio = A317HistoricoDepartamentoMunicipio;
               Z318HistoricoZonasID = A318HistoricoZonasID;
               Z291HistoricoSolicitudesDireccion = A291HistoricoSolicitudesDireccion;
               Z292HistoricoSolicitudesAutoEnumer = A292HistoricoSolicitudesAutoEnumer;
               Z299HistoricoSolicitudesCotizacion = A299HistoricoSolicitudesCotizacion;
               Z301HistoricoSolicitudServicioSolC = A301HistoricoSolicitudServicioSolC;
               Z303HistoricoSolicitudesOtros1 = A303HistoricoSolicitudesOtros1;
               Z304HistoricoSolicitudesOtros2 = A304HistoricoSolicitudesOtros2;
               Z305HistoricoSolicitudesOtros3 = A305HistoricoSolicitudesOtros3;
               Z306HistoricoSolicitudesFechaAlta = A306HistoricoSolicitudesFechaAlta;
               Z307HistoricoSolicitudesFechaActua = A307HistoricoSolicitudesFechaActua;
               Z308HistoricoSolicitudesFechaInsta = A308HistoricoSolicitudesFechaInsta;
               Z309HistoricoSolicitudesHoraInstal = A309HistoricoSolicitudesHoraInstal;
               Z311HistoricoSolicitudesNota = A311HistoricoSolicitudesNota;
               Z312HistoricoSolicitudesNotificaci = A312HistoricoSolicitudesNotificaci;
               Z439HistoricoSolicitudesOrigenPago = A439HistoricoSolicitudesOrigenPago;
               Z442HistoricoSolicitudesPagado = A442HistoricoSolicitudesPagado;
               Z623HistoricoSolicitudesComProv = A623HistoricoSolicitudesComProv;
               Z626HistoricoSolicitudesComProvP = A626HistoricoSolicitudesComProvP;
               Z627HistoricoSolicitudesComALM = A627HistoricoSolicitudesComALM;
               Z628HistoricoSolicitudesComALMP = A628HistoricoSolicitudesComALMP;
               Z624HistoricoSolicitudesNombreAux = A624HistoricoSolicitudesNombreAux;
               Z625HistoricoSolicitudesSubTipo = A625HistoricoSolicitudesSubTipo;
               Z633HistoricoSolicitudesProvID = A633HistoricoSolicitudesProvID;
               Z634HistoricoSolicitudesProvNombre = A634HistoricoSolicitudesProvNombre;
               Z128MetodoPagosID = A128MetodoPagosID;
               Z130EstadosSolTipo = A130EstadosSolTipo;
               Z131EstadosSolId = A131EstadosSolId;
            }
         }
         if ( GX_JID == -27 )
         {
            Z153HistoricoSolicitudesID = A153HistoricoSolicitudesID;
            Z288HistoricoSolicitudesNombre = A288HistoricoSolicitudesNombre;
            Z289HistoricoSolicitudesTelefono = A289HistoricoSolicitudesTelefono;
            Z290HistoricoSolicitudesMail = A290HistoricoSolicitudesMail;
            Z315HistoricoPaisID = A315HistoricoPaisID;
            Z316HistoricoDepartamentoId = A316HistoricoDepartamentoId;
            Z317HistoricoDepartamentoMunicipio = A317HistoricoDepartamentoMunicipio;
            Z318HistoricoZonasID = A318HistoricoZonasID;
            Z291HistoricoSolicitudesDireccion = A291HistoricoSolicitudesDireccion;
            Z292HistoricoSolicitudesAutoEnumer = A292HistoricoSolicitudesAutoEnumer;
            Z299HistoricoSolicitudesCotizacion = A299HistoricoSolicitudesCotizacion;
            Z301HistoricoSolicitudServicioSolC = A301HistoricoSolicitudServicioSolC;
            Z303HistoricoSolicitudesOtros1 = A303HistoricoSolicitudesOtros1;
            Z304HistoricoSolicitudesOtros2 = A304HistoricoSolicitudesOtros2;
            Z305HistoricoSolicitudesOtros3 = A305HistoricoSolicitudesOtros3;
            Z306HistoricoSolicitudesFechaAlta = A306HistoricoSolicitudesFechaAlta;
            Z307HistoricoSolicitudesFechaActua = A307HistoricoSolicitudesFechaActua;
            Z308HistoricoSolicitudesFechaInsta = A308HistoricoSolicitudesFechaInsta;
            Z309HistoricoSolicitudesHoraInstal = A309HistoricoSolicitudesHoraInstal;
            Z310HistoricoSolicitudesComentario = A310HistoricoSolicitudesComentario;
            Z311HistoricoSolicitudesNota = A311HistoricoSolicitudesNota;
            Z312HistoricoSolicitudesNotificaci = A312HistoricoSolicitudesNotificaci;
            Z439HistoricoSolicitudesOrigenPago = A439HistoricoSolicitudesOrigenPago;
            Z442HistoricoSolicitudesPagado = A442HistoricoSolicitudesPagado;
            Z623HistoricoSolicitudesComProv = A623HistoricoSolicitudesComProv;
            Z626HistoricoSolicitudesComProvP = A626HistoricoSolicitudesComProvP;
            Z627HistoricoSolicitudesComALM = A627HistoricoSolicitudesComALM;
            Z628HistoricoSolicitudesComALMP = A628HistoricoSolicitudesComALMP;
            Z624HistoricoSolicitudesNombreAux = A624HistoricoSolicitudesNombreAux;
            Z625HistoricoSolicitudesSubTipo = A625HistoricoSolicitudesSubTipo;
            Z633HistoricoSolicitudesProvID = A633HistoricoSolicitudesProvID;
            Z634HistoricoSolicitudesProvNombre = A634HistoricoSolicitudesProvNombre;
            Z128MetodoPagosID = A128MetodoPagosID;
            Z130EstadosSolTipo = A130EstadosSolTipo;
            Z131EstadosSolId = A131EstadosSolId;
            Z132EstadosSolNombre = A132EstadosSolNombre;
            Z129MetodoPagosNombre = A129MetodoPagosNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_130_131_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00o0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESTADOSSOLTIPO"+"'), id:'"+"ESTADOSSOLTIPO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"ESTADOSSOLID"+"'), id:'"+"ESTADOSSOLID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_128_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0150.aspx"+"',["+"{Ctrl:gx.dom.el('"+"METODOPAGOSID"+"'), id:'"+"METODOPAGOSID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7HistoricoSolicitudesID) )
         {
            A153HistoricoSolicitudesID = AV7HistoricoSolicitudesID;
            AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
         }
         if ( ! (0==AV7HistoricoSolicitudesID) )
         {
            edtHistoricoSolicitudesID_Enabled = 0;
            AssignProp("", false, edtHistoricoSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Enabled), 5, 0), true);
         }
         else
         {
            edtHistoricoSolicitudesID_Enabled = 1;
            AssignProp("", false, edtHistoricoSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7HistoricoSolicitudesID) )
         {
            edtHistoricoSolicitudesID_Enabled = 0;
            AssignProp("", false, edtHistoricoSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_EstadosSolTipo)) )
         {
            edtEstadosSolTipo_Enabled = 0;
            AssignProp("", false, edtEstadosSolTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolTipo_Enabled), 5, 0), true);
         }
         else
         {
            edtEstadosSolTipo_Enabled = 1;
            AssignProp("", false, edtEstadosSolTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolTipo_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_EstadosSolId) )
         {
            edtEstadosSolId_Enabled = 0;
            AssignProp("", false, edtEstadosSolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolId_Enabled), 5, 0), true);
         }
         else
         {
            edtEstadosSolId_Enabled = 1;
            AssignProp("", false, edtEstadosSolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_MetodoPagosID) )
         {
            edtMetodoPagosID_Enabled = 0;
            AssignProp("", false, edtMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Enabled), 5, 0), true);
         }
         else
         {
            edtMetodoPagosID_Enabled = 1;
            AssignProp("", false, edtMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_MetodoPagosID) )
         {
            A128MetodoPagosID = AV13Insert_MetodoPagosID;
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_EstadosSolId) )
         {
            A131EstadosSolId = AV12Insert_EstadosSolId;
            AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_EstadosSolTipo)) )
         {
            A130EstadosSolTipo = AV11Insert_EstadosSolTipo;
            AssignAttri("", false, "A130EstadosSolTipo", A130EstadosSolTipo);
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
            GetHistoricoSolicitudesTotal( A153HistoricoSolicitudesID) ;
            O300HistoricoSolicitudesTotal = A300HistoricoSolicitudesTotal;
            AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
            AV31Pgmname = "HistoricoSolicitudes";
            AssignAttri("", false, "AV31Pgmname", AV31Pgmname);
            /* Using cursor T00116 */
            pr_default.execute(4, new Object[] {A128MetodoPagosID});
            A129MetodoPagosNombre = T00116_A129MetodoPagosNombre[0];
            pr_default.close(4);
            /* Using cursor T00117 */
            pr_default.execute(5, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
            A132EstadosSolNombre = T00117_A132EstadosSolNombre[0];
            pr_default.close(5);
         }
      }

      protected void Load1142( )
      {
         /* Using cursor T00118 */
         pr_default.execute(6, new Object[] {A153HistoricoSolicitudesID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound42 = 1;
            A288HistoricoSolicitudesNombre = T00118_A288HistoricoSolicitudesNombre[0];
            AssignAttri("", false, "A288HistoricoSolicitudesNombre", A288HistoricoSolicitudesNombre);
            A289HistoricoSolicitudesTelefono = T00118_A289HistoricoSolicitudesTelefono[0];
            AssignAttri("", false, "A289HistoricoSolicitudesTelefono", A289HistoricoSolicitudesTelefono);
            A290HistoricoSolicitudesMail = T00118_A290HistoricoSolicitudesMail[0];
            n290HistoricoSolicitudesMail = T00118_n290HistoricoSolicitudesMail[0];
            AssignAttri("", false, "A290HistoricoSolicitudesMail", A290HistoricoSolicitudesMail);
            A315HistoricoPaisID = T00118_A315HistoricoPaisID[0];
            AssignAttri("", false, "A315HistoricoPaisID", A315HistoricoPaisID);
            A316HistoricoDepartamentoId = T00118_A316HistoricoDepartamentoId[0];
            AssignAttri("", false, "A316HistoricoDepartamentoId", StringUtil.LTrimStr( (decimal)(A316HistoricoDepartamentoId), 18, 0));
            A317HistoricoDepartamentoMunicipio = T00118_A317HistoricoDepartamentoMunicipio[0];
            AssignAttri("", false, "A317HistoricoDepartamentoMunicipio", StringUtil.LTrimStr( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0));
            A318HistoricoZonasID = T00118_A318HistoricoZonasID[0];
            n318HistoricoZonasID = T00118_n318HistoricoZonasID[0];
            AssignAttri("", false, "A318HistoricoZonasID", StringUtil.LTrimStr( (decimal)(A318HistoricoZonasID), 18, 0));
            A291HistoricoSolicitudesDireccion = T00118_A291HistoricoSolicitudesDireccion[0];
            AssignAttri("", false, "A291HistoricoSolicitudesDireccion", A291HistoricoSolicitudesDireccion);
            A292HistoricoSolicitudesAutoEnumer = T00118_A292HistoricoSolicitudesAutoEnumer[0];
            AssignAttri("", false, "A292HistoricoSolicitudesAutoEnumer", StringUtil.LTrimStr( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0));
            A299HistoricoSolicitudesCotizacion = T00118_A299HistoricoSolicitudesCotizacion[0];
            AssignAttri("", false, "A299HistoricoSolicitudesCotizacion", StringUtil.LTrimStr( A299HistoricoSolicitudesCotizacion, 18, 2));
            A301HistoricoSolicitudServicioSolC = T00118_A301HistoricoSolicitudServicioSolC[0];
            AssignAttri("", false, "A301HistoricoSolicitudServicioSolC", A301HistoricoSolicitudServicioSolC);
            A132EstadosSolNombre = T00118_A132EstadosSolNombre[0];
            A303HistoricoSolicitudesOtros1 = T00118_A303HistoricoSolicitudesOtros1[0];
            AssignAttri("", false, "A303HistoricoSolicitudesOtros1", A303HistoricoSolicitudesOtros1);
            A304HistoricoSolicitudesOtros2 = T00118_A304HistoricoSolicitudesOtros2[0];
            AssignAttri("", false, "A304HistoricoSolicitudesOtros2", A304HistoricoSolicitudesOtros2);
            A305HistoricoSolicitudesOtros3 = T00118_A305HistoricoSolicitudesOtros3[0];
            AssignAttri("", false, "A305HistoricoSolicitudesOtros3", A305HistoricoSolicitudesOtros3);
            A306HistoricoSolicitudesFechaAlta = T00118_A306HistoricoSolicitudesFechaAlta[0];
            AssignAttri("", false, "A306HistoricoSolicitudesFechaAlta", context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99"));
            A307HistoricoSolicitudesFechaActua = T00118_A307HistoricoSolicitudesFechaActua[0];
            AssignAttri("", false, "A307HistoricoSolicitudesFechaActua", context.localUtil.TToC( A307HistoricoSolicitudesFechaActua, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A308HistoricoSolicitudesFechaInsta = T00118_A308HistoricoSolicitudesFechaInsta[0];
            AssignAttri("", false, "A308HistoricoSolicitudesFechaInsta", context.localUtil.Format(A308HistoricoSolicitudesFechaInsta, "99/99/99"));
            A309HistoricoSolicitudesHoraInstal = T00118_A309HistoricoSolicitudesHoraInstal[0];
            AssignAttri("", false, "A309HistoricoSolicitudesHoraInstal", A309HistoricoSolicitudesHoraInstal);
            A310HistoricoSolicitudesComentario = T00118_A310HistoricoSolicitudesComentario[0];
            AssignAttri("", false, "A310HistoricoSolicitudesComentario", A310HistoricoSolicitudesComentario);
            A129MetodoPagosNombre = T00118_A129MetodoPagosNombre[0];
            A311HistoricoSolicitudesNota = T00118_A311HistoricoSolicitudesNota[0];
            AssignAttri("", false, "A311HistoricoSolicitudesNota", A311HistoricoSolicitudesNota);
            A312HistoricoSolicitudesNotificaci = T00118_A312HistoricoSolicitudesNotificaci[0];
            AssignAttri("", false, "A312HistoricoSolicitudesNotificaci", A312HistoricoSolicitudesNotificaci);
            A439HistoricoSolicitudesOrigenPago = T00118_A439HistoricoSolicitudesOrigenPago[0];
            AssignAttri("", false, "A439HistoricoSolicitudesOrigenPago", A439HistoricoSolicitudesOrigenPago);
            A442HistoricoSolicitudesPagado = T00118_A442HistoricoSolicitudesPagado[0];
            AssignAttri("", false, "A442HistoricoSolicitudesPagado", A442HistoricoSolicitudesPagado);
            A623HistoricoSolicitudesComProv = T00118_A623HistoricoSolicitudesComProv[0];
            A626HistoricoSolicitudesComProvP = T00118_A626HistoricoSolicitudesComProvP[0];
            A627HistoricoSolicitudesComALM = T00118_A627HistoricoSolicitudesComALM[0];
            A628HistoricoSolicitudesComALMP = T00118_A628HistoricoSolicitudesComALMP[0];
            A624HistoricoSolicitudesNombreAux = T00118_A624HistoricoSolicitudesNombreAux[0];
            A625HistoricoSolicitudesSubTipo = T00118_A625HistoricoSolicitudesSubTipo[0];
            A633HistoricoSolicitudesProvID = T00118_A633HistoricoSolicitudesProvID[0];
            A634HistoricoSolicitudesProvNombre = T00118_A634HistoricoSolicitudesProvNombre[0];
            A128MetodoPagosID = T00118_A128MetodoPagosID[0];
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
            A130EstadosSolTipo = T00118_A130EstadosSolTipo[0];
            AssignAttri("", false, "A130EstadosSolTipo", A130EstadosSolTipo);
            A131EstadosSolId = T00118_A131EstadosSolId[0];
            AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
            ZM1142( -27) ;
         }
         pr_default.close(6);
         OnLoadActions1142( ) ;
      }

      protected void OnLoadActions1142( )
      {
         AV31Pgmname = "HistoricoSolicitudes";
         AssignAttri("", false, "AV31Pgmname", AV31Pgmname);
         GetHistoricoSolicitudesTotal( A153HistoricoSolicitudesID) ;
         O300HistoricoSolicitudesTotal = A300HistoricoSolicitudesTotal;
         AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
         if ( ( A299HistoricoSolicitudesCotizacion == Convert.ToDecimal( 0 )) )
         {
            A302HistoricoSolicitudServicioPFin = A300HistoricoSolicitudesTotal;
            AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
         }
         else
         {
            if ( ( A299HistoricoSolicitudesCotizacion > Convert.ToDecimal( 0 )) )
            {
               A302HistoricoSolicitudServicioPFin = A299HistoricoSolicitudesCotizacion;
               AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            }
            else
            {
               A302HistoricoSolicitudServicioPFin = 0;
               AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            }
         }
         A629HistoricoSolicitudesComPro = (decimal)(A302HistoricoSolicitudServicioPFin-(A623HistoricoSolicitudesComProv+A627HistoricoSolicitudesComALM));
         AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
         A630HistoricoSolicitudesComProP = (decimal)(100-(A626HistoricoSolicitudesComProvP+A628HistoricoSolicitudesComALMP));
         AssignAttri("", false, "A630HistoricoSolicitudesComProP", StringUtil.LTrimStr( A630HistoricoSolicitudesComProP, 6, 2));
      }

      protected void CheckExtendedTable1142( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV31Pgmname = "HistoricoSolicitudes";
         AssignAttri("", false, "AV31Pgmname", AV31Pgmname);
         GetHistoricoSolicitudesTotal( A153HistoricoSolicitudesID) ;
         if ( ( A299HistoricoSolicitudesCotizacion == Convert.ToDecimal( 0 )) )
         {
            A302HistoricoSolicitudServicioPFin = A300HistoricoSolicitudesTotal;
            AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
         }
         else
         {
            if ( ( A299HistoricoSolicitudesCotizacion > Convert.ToDecimal( 0 )) )
            {
               A302HistoricoSolicitudServicioPFin = A299HistoricoSolicitudesCotizacion;
               AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            }
            else
            {
               A302HistoricoSolicitudServicioPFin = 0;
               AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            }
         }
         A629HistoricoSolicitudesComPro = (decimal)(A302HistoricoSolicitudServicioPFin-(A623HistoricoSolicitudesComProv+A627HistoricoSolicitudesComALM));
         AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
         if ( ! ( GxRegex.IsMatch(A290HistoricoSolicitudesMail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A290HistoricoSolicitudesMail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Historico Solicitudes Mail", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "HISTORICOSOLICITUDESMAIL");
            AnyError = 1;
            GX_FocusControl = edtHistoricoSolicitudesMail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00117 */
         pr_default.execute(5, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Solicitudes", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSSOLID");
            AnyError = 1;
            GX_FocusControl = edtEstadosSolTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A132EstadosSolNombre = T00117_A132EstadosSolNombre[0];
         pr_default.close(5);
         if ( ! ( (DateTime.MinValue==A306HistoricoSolicitudesFechaAlta) || ( DateTimeUtil.ResetTime ( A306HistoricoSolicitudesFechaAlta ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Historico Solicitudes Fecha Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "HISTORICOSOLICITUDESFECHAALTA");
            AnyError = 1;
            GX_FocusControl = edtHistoricoSolicitudesFechaAlta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A307HistoricoSolicitudesFechaActua) || ( A307HistoricoSolicitudesFechaActua >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Historico Solicitudes Fecha Actualizacion", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "HISTORICOSOLICITUDESFECHAACTUA");
            AnyError = 1;
            GX_FocusControl = edtHistoricoSolicitudesFechaActua_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A308HistoricoSolicitudesFechaInsta) || ( DateTimeUtil.ResetTime ( A308HistoricoSolicitudesFechaInsta ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Historico Solicitudes Fecha Instalacion", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "HISTORICOSOLICITUDESFECHAINSTA");
            AnyError = 1;
            GX_FocusControl = edtHistoricoSolicitudesFechaInsta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00116 */
         pr_default.execute(4, new Object[] {A128MetodoPagosID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Metodo Pagos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "METODOPAGOSID");
            AnyError = 1;
            GX_FocusControl = edtMetodoPagosID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A129MetodoPagosNombre = T00116_A129MetodoPagosNombre[0];
         pr_default.close(4);
         A630HistoricoSolicitudesComProP = (decimal)(100-(A626HistoricoSolicitudesComProvP+A628HistoricoSolicitudesComALMP));
         AssignAttri("", false, "A630HistoricoSolicitudesComProP", StringUtil.LTrimStr( A630HistoricoSolicitudesComProP, 6, 2));
      }

      protected void CloseExtendedTableCursors1142( )
      {
         pr_default.close(5);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_29( string A130EstadosSolTipo ,
                                int A131EstadosSolId )
      {
         /* Using cursor T00119 */
         pr_default.execute(7, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Solicitudes", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSSOLID");
            AnyError = 1;
            GX_FocusControl = edtEstadosSolTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A132EstadosSolNombre = T00119_A132EstadosSolNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A132EstadosSolNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_28( long A128MetodoPagosID )
      {
         /* Using cursor T001110 */
         pr_default.execute(8, new Object[] {A128MetodoPagosID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Metodo Pagos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "METODOPAGOSID");
            AnyError = 1;
            GX_FocusControl = edtMetodoPagosID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A129MetodoPagosNombre = T001110_A129MetodoPagosNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A129MetodoPagosNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey1142( )
      {
         /* Using cursor T001111 */
         pr_default.execute(9, new Object[] {A153HistoricoSolicitudesID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound42 = 1;
         }
         else
         {
            RcdFound42 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00115 */
         pr_default.execute(3, new Object[] {A153HistoricoSolicitudesID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1142( 27) ;
            RcdFound42 = 1;
            A153HistoricoSolicitudesID = T00115_A153HistoricoSolicitudesID[0];
            AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
            A288HistoricoSolicitudesNombre = T00115_A288HistoricoSolicitudesNombre[0];
            AssignAttri("", false, "A288HistoricoSolicitudesNombre", A288HistoricoSolicitudesNombre);
            A289HistoricoSolicitudesTelefono = T00115_A289HistoricoSolicitudesTelefono[0];
            AssignAttri("", false, "A289HistoricoSolicitudesTelefono", A289HistoricoSolicitudesTelefono);
            A290HistoricoSolicitudesMail = T00115_A290HistoricoSolicitudesMail[0];
            n290HistoricoSolicitudesMail = T00115_n290HistoricoSolicitudesMail[0];
            AssignAttri("", false, "A290HistoricoSolicitudesMail", A290HistoricoSolicitudesMail);
            A315HistoricoPaisID = T00115_A315HistoricoPaisID[0];
            AssignAttri("", false, "A315HistoricoPaisID", A315HistoricoPaisID);
            A316HistoricoDepartamentoId = T00115_A316HistoricoDepartamentoId[0];
            AssignAttri("", false, "A316HistoricoDepartamentoId", StringUtil.LTrimStr( (decimal)(A316HistoricoDepartamentoId), 18, 0));
            A317HistoricoDepartamentoMunicipio = T00115_A317HistoricoDepartamentoMunicipio[0];
            AssignAttri("", false, "A317HistoricoDepartamentoMunicipio", StringUtil.LTrimStr( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0));
            A318HistoricoZonasID = T00115_A318HistoricoZonasID[0];
            n318HistoricoZonasID = T00115_n318HistoricoZonasID[0];
            AssignAttri("", false, "A318HistoricoZonasID", StringUtil.LTrimStr( (decimal)(A318HistoricoZonasID), 18, 0));
            A291HistoricoSolicitudesDireccion = T00115_A291HistoricoSolicitudesDireccion[0];
            AssignAttri("", false, "A291HistoricoSolicitudesDireccion", A291HistoricoSolicitudesDireccion);
            A292HistoricoSolicitudesAutoEnumer = T00115_A292HistoricoSolicitudesAutoEnumer[0];
            AssignAttri("", false, "A292HistoricoSolicitudesAutoEnumer", StringUtil.LTrimStr( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0));
            A299HistoricoSolicitudesCotizacion = T00115_A299HistoricoSolicitudesCotizacion[0];
            AssignAttri("", false, "A299HistoricoSolicitudesCotizacion", StringUtil.LTrimStr( A299HistoricoSolicitudesCotizacion, 18, 2));
            A301HistoricoSolicitudServicioSolC = T00115_A301HistoricoSolicitudServicioSolC[0];
            AssignAttri("", false, "A301HistoricoSolicitudServicioSolC", A301HistoricoSolicitudServicioSolC);
            A303HistoricoSolicitudesOtros1 = T00115_A303HistoricoSolicitudesOtros1[0];
            AssignAttri("", false, "A303HistoricoSolicitudesOtros1", A303HistoricoSolicitudesOtros1);
            A304HistoricoSolicitudesOtros2 = T00115_A304HistoricoSolicitudesOtros2[0];
            AssignAttri("", false, "A304HistoricoSolicitudesOtros2", A304HistoricoSolicitudesOtros2);
            A305HistoricoSolicitudesOtros3 = T00115_A305HistoricoSolicitudesOtros3[0];
            AssignAttri("", false, "A305HistoricoSolicitudesOtros3", A305HistoricoSolicitudesOtros3);
            A306HistoricoSolicitudesFechaAlta = T00115_A306HistoricoSolicitudesFechaAlta[0];
            AssignAttri("", false, "A306HistoricoSolicitudesFechaAlta", context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99"));
            A307HistoricoSolicitudesFechaActua = T00115_A307HistoricoSolicitudesFechaActua[0];
            AssignAttri("", false, "A307HistoricoSolicitudesFechaActua", context.localUtil.TToC( A307HistoricoSolicitudesFechaActua, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A308HistoricoSolicitudesFechaInsta = T00115_A308HistoricoSolicitudesFechaInsta[0];
            AssignAttri("", false, "A308HistoricoSolicitudesFechaInsta", context.localUtil.Format(A308HistoricoSolicitudesFechaInsta, "99/99/99"));
            A309HistoricoSolicitudesHoraInstal = T00115_A309HistoricoSolicitudesHoraInstal[0];
            AssignAttri("", false, "A309HistoricoSolicitudesHoraInstal", A309HistoricoSolicitudesHoraInstal);
            A310HistoricoSolicitudesComentario = T00115_A310HistoricoSolicitudesComentario[0];
            AssignAttri("", false, "A310HistoricoSolicitudesComentario", A310HistoricoSolicitudesComentario);
            A311HistoricoSolicitudesNota = T00115_A311HistoricoSolicitudesNota[0];
            AssignAttri("", false, "A311HistoricoSolicitudesNota", A311HistoricoSolicitudesNota);
            A312HistoricoSolicitudesNotificaci = T00115_A312HistoricoSolicitudesNotificaci[0];
            AssignAttri("", false, "A312HistoricoSolicitudesNotificaci", A312HistoricoSolicitudesNotificaci);
            A439HistoricoSolicitudesOrigenPago = T00115_A439HistoricoSolicitudesOrigenPago[0];
            AssignAttri("", false, "A439HistoricoSolicitudesOrigenPago", A439HistoricoSolicitudesOrigenPago);
            A442HistoricoSolicitudesPagado = T00115_A442HistoricoSolicitudesPagado[0];
            AssignAttri("", false, "A442HistoricoSolicitudesPagado", A442HistoricoSolicitudesPagado);
            A623HistoricoSolicitudesComProv = T00115_A623HistoricoSolicitudesComProv[0];
            A626HistoricoSolicitudesComProvP = T00115_A626HistoricoSolicitudesComProvP[0];
            A627HistoricoSolicitudesComALM = T00115_A627HistoricoSolicitudesComALM[0];
            A628HistoricoSolicitudesComALMP = T00115_A628HistoricoSolicitudesComALMP[0];
            A624HistoricoSolicitudesNombreAux = T00115_A624HistoricoSolicitudesNombreAux[0];
            A625HistoricoSolicitudesSubTipo = T00115_A625HistoricoSolicitudesSubTipo[0];
            A633HistoricoSolicitudesProvID = T00115_A633HistoricoSolicitudesProvID[0];
            A634HistoricoSolicitudesProvNombre = T00115_A634HistoricoSolicitudesProvNombre[0];
            A128MetodoPagosID = T00115_A128MetodoPagosID[0];
            AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
            A130EstadosSolTipo = T00115_A130EstadosSolTipo[0];
            AssignAttri("", false, "A130EstadosSolTipo", A130EstadosSolTipo);
            A131EstadosSolId = T00115_A131EstadosSolId[0];
            AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
            Z153HistoricoSolicitudesID = A153HistoricoSolicitudesID;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1142( ) ;
            if ( AnyError == 1 )
            {
               RcdFound42 = 0;
               InitializeNonKey1142( ) ;
            }
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound42 = 0;
            InitializeNonKey1142( ) ;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1142( ) ;
         if ( RcdFound42 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound42 = 0;
         /* Using cursor T001112 */
         pr_default.execute(10, new Object[] {A153HistoricoSolicitudesID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T001112_A153HistoricoSolicitudesID[0] < A153HistoricoSolicitudesID ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T001112_A153HistoricoSolicitudesID[0] > A153HistoricoSolicitudesID ) ) )
            {
               A153HistoricoSolicitudesID = T001112_A153HistoricoSolicitudesID[0];
               AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
               RcdFound42 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound42 = 0;
         /* Using cursor T001113 */
         pr_default.execute(11, new Object[] {A153HistoricoSolicitudesID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T001113_A153HistoricoSolicitudesID[0] > A153HistoricoSolicitudesID ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T001113_A153HistoricoSolicitudesID[0] < A153HistoricoSolicitudesID ) ) )
            {
               A153HistoricoSolicitudesID = T001113_A153HistoricoSolicitudesID[0];
               AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
               RcdFound42 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1142( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A300HistoricoSolicitudesTotal = O300HistoricoSolicitudesTotal;
            AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
            A629HistoricoSolicitudesComPro = O629HistoricoSolicitudesComPro;
            AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
            A302HistoricoSolicitudServicioPFin = O302HistoricoSolicitudServicioPFin;
            AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1142( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound42 == 1 )
            {
               if ( A153HistoricoSolicitudesID != Z153HistoricoSolicitudesID )
               {
                  A153HistoricoSolicitudesID = Z153HistoricoSolicitudesID;
                  AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "HISTORICOSOLICITUDESID");
                  AnyError = 1;
                  GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A300HistoricoSolicitudesTotal = O300HistoricoSolicitudesTotal;
                  AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
                  A629HistoricoSolicitudesComPro = O629HistoricoSolicitudesComPro;
                  AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
                  A302HistoricoSolicitudServicioPFin = O302HistoricoSolicitudServicioPFin;
                  AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A300HistoricoSolicitudesTotal = O300HistoricoSolicitudesTotal;
                  AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
                  A629HistoricoSolicitudesComPro = O629HistoricoSolicitudesComPro;
                  AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
                  A302HistoricoSolicitudServicioPFin = O302HistoricoSolicitudServicioPFin;
                  AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
                  Update1142( ) ;
                  GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A153HistoricoSolicitudesID != Z153HistoricoSolicitudesID )
               {
                  /* Insert record */
                  A300HistoricoSolicitudesTotal = O300HistoricoSolicitudesTotal;
                  AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
                  A629HistoricoSolicitudesComPro = O629HistoricoSolicitudesComPro;
                  AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
                  A302HistoricoSolicitudServicioPFin = O302HistoricoSolicitudServicioPFin;
                  AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
                  GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1142( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "HISTORICOSOLICITUDESID");
                     AnyError = 1;
                     GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A300HistoricoSolicitudesTotal = O300HistoricoSolicitudesTotal;
                     AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
                     A629HistoricoSolicitudesComPro = O629HistoricoSolicitudesComPro;
                     AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
                     A302HistoricoSolicitudServicioPFin = O302HistoricoSolicitudServicioPFin;
                     AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
                     GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1142( ) ;
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
         if ( A153HistoricoSolicitudesID != Z153HistoricoSolicitudesID )
         {
            A153HistoricoSolicitudesID = Z153HistoricoSolicitudesID;
            AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "HISTORICOSOLICITUDESID");
            AnyError = 1;
            GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A300HistoricoSolicitudesTotal = O300HistoricoSolicitudesTotal;
            AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
            A629HistoricoSolicitudesComPro = O629HistoricoSolicitudesComPro;
            AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
            A302HistoricoSolicitudServicioPFin = O302HistoricoSolicitudServicioPFin;
            AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtHistoricoSolicitudesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1142( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00114 */
            pr_default.execute(2, new Object[] {A153HistoricoSolicitudesID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistoricoSolicitudes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z288HistoricoSolicitudesNombre, T00114_A288HistoricoSolicitudesNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z289HistoricoSolicitudesTelefono, T00114_A289HistoricoSolicitudesTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z290HistoricoSolicitudesMail, T00114_A290HistoricoSolicitudesMail[0]) != 0 ) || ( StringUtil.StrCmp(Z315HistoricoPaisID, T00114_A315HistoricoPaisID[0]) != 0 ) || ( Z316HistoricoDepartamentoId != T00114_A316HistoricoDepartamentoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z317HistoricoDepartamentoMunicipio != T00114_A317HistoricoDepartamentoMunicipio[0] ) || ( Z318HistoricoZonasID != T00114_A318HistoricoZonasID[0] ) || ( StringUtil.StrCmp(Z291HistoricoSolicitudesDireccion, T00114_A291HistoricoSolicitudesDireccion[0]) != 0 ) || ( Z292HistoricoSolicitudesAutoEnumer != T00114_A292HistoricoSolicitudesAutoEnumer[0] ) || ( Z299HistoricoSolicitudesCotizacion != T00114_A299HistoricoSolicitudesCotizacion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z301HistoricoSolicitudServicioSolC, T00114_A301HistoricoSolicitudServicioSolC[0]) != 0 ) || ( StringUtil.StrCmp(Z303HistoricoSolicitudesOtros1, T00114_A303HistoricoSolicitudesOtros1[0]) != 0 ) || ( StringUtil.StrCmp(Z304HistoricoSolicitudesOtros2, T00114_A304HistoricoSolicitudesOtros2[0]) != 0 ) || ( StringUtil.StrCmp(Z305HistoricoSolicitudesOtros3, T00114_A305HistoricoSolicitudesOtros3[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z306HistoricoSolicitudesFechaAlta ) != DateTimeUtil.ResetTime ( T00114_A306HistoricoSolicitudesFechaAlta[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z307HistoricoSolicitudesFechaActua != T00114_A307HistoricoSolicitudesFechaActua[0] ) || ( DateTimeUtil.ResetTime ( Z308HistoricoSolicitudesFechaInsta ) != DateTimeUtil.ResetTime ( T00114_A308HistoricoSolicitudesFechaInsta[0] ) ) || ( StringUtil.StrCmp(Z309HistoricoSolicitudesHoraInstal, T00114_A309HistoricoSolicitudesHoraInstal[0]) != 0 ) || ( StringUtil.StrCmp(Z311HistoricoSolicitudesNota, T00114_A311HistoricoSolicitudesNota[0]) != 0 ) || ( StringUtil.StrCmp(Z312HistoricoSolicitudesNotificaci, T00114_A312HistoricoSolicitudesNotificaci[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z439HistoricoSolicitudesOrigenPago, T00114_A439HistoricoSolicitudesOrigenPago[0]) != 0 ) || ( StringUtil.StrCmp(Z442HistoricoSolicitudesPagado, T00114_A442HistoricoSolicitudesPagado[0]) != 0 ) || ( Z623HistoricoSolicitudesComProv != T00114_A623HistoricoSolicitudesComProv[0] ) || ( Z626HistoricoSolicitudesComProvP != T00114_A626HistoricoSolicitudesComProvP[0] ) || ( Z627HistoricoSolicitudesComALM != T00114_A627HistoricoSolicitudesComALM[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z628HistoricoSolicitudesComALMP != T00114_A628HistoricoSolicitudesComALMP[0] ) || ( StringUtil.StrCmp(Z624HistoricoSolicitudesNombreAux, T00114_A624HistoricoSolicitudesNombreAux[0]) != 0 ) || ( StringUtil.StrCmp(Z625HistoricoSolicitudesSubTipo, T00114_A625HistoricoSolicitudesSubTipo[0]) != 0 ) || ( Z633HistoricoSolicitudesProvID != T00114_A633HistoricoSolicitudesProvID[0] ) || ( StringUtil.StrCmp(Z634HistoricoSolicitudesProvNombre, T00114_A634HistoricoSolicitudesProvNombre[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z128MetodoPagosID != T00114_A128MetodoPagosID[0] ) || ( StringUtil.StrCmp(Z130EstadosSolTipo, T00114_A130EstadosSolTipo[0]) != 0 ) || ( Z131EstadosSolId != T00114_A131EstadosSolId[0] ) )
            {
               if ( StringUtil.StrCmp(Z288HistoricoSolicitudesNombre, T00114_A288HistoricoSolicitudesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z288HistoricoSolicitudesNombre);
                  GXUtil.WriteLogRaw("Current: ",T00114_A288HistoricoSolicitudesNombre[0]);
               }
               if ( StringUtil.StrCmp(Z289HistoricoSolicitudesTelefono, T00114_A289HistoricoSolicitudesTelefono[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z289HistoricoSolicitudesTelefono);
                  GXUtil.WriteLogRaw("Current: ",T00114_A289HistoricoSolicitudesTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z290HistoricoSolicitudesMail, T00114_A290HistoricoSolicitudesMail[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesMail");
                  GXUtil.WriteLogRaw("Old: ",Z290HistoricoSolicitudesMail);
                  GXUtil.WriteLogRaw("Current: ",T00114_A290HistoricoSolicitudesMail[0]);
               }
               if ( StringUtil.StrCmp(Z315HistoricoPaisID, T00114_A315HistoricoPaisID[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoPaisID");
                  GXUtil.WriteLogRaw("Old: ",Z315HistoricoPaisID);
                  GXUtil.WriteLogRaw("Current: ",T00114_A315HistoricoPaisID[0]);
               }
               if ( Z316HistoricoDepartamentoId != T00114_A316HistoricoDepartamentoId[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoDepartamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z316HistoricoDepartamentoId);
                  GXUtil.WriteLogRaw("Current: ",T00114_A316HistoricoDepartamentoId[0]);
               }
               if ( Z317HistoricoDepartamentoMunicipio != T00114_A317HistoricoDepartamentoMunicipio[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoDepartamentoMunicipio");
                  GXUtil.WriteLogRaw("Old: ",Z317HistoricoDepartamentoMunicipio);
                  GXUtil.WriteLogRaw("Current: ",T00114_A317HistoricoDepartamentoMunicipio[0]);
               }
               if ( Z318HistoricoZonasID != T00114_A318HistoricoZonasID[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoZonasID");
                  GXUtil.WriteLogRaw("Old: ",Z318HistoricoZonasID);
                  GXUtil.WriteLogRaw("Current: ",T00114_A318HistoricoZonasID[0]);
               }
               if ( StringUtil.StrCmp(Z291HistoricoSolicitudesDireccion, T00114_A291HistoricoSolicitudesDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z291HistoricoSolicitudesDireccion);
                  GXUtil.WriteLogRaw("Current: ",T00114_A291HistoricoSolicitudesDireccion[0]);
               }
               if ( Z292HistoricoSolicitudesAutoEnumer != T00114_A292HistoricoSolicitudesAutoEnumer[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesAutoEnumer");
                  GXUtil.WriteLogRaw("Old: ",Z292HistoricoSolicitudesAutoEnumer);
                  GXUtil.WriteLogRaw("Current: ",T00114_A292HistoricoSolicitudesAutoEnumer[0]);
               }
               if ( Z299HistoricoSolicitudesCotizacion != T00114_A299HistoricoSolicitudesCotizacion[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesCotizacion");
                  GXUtil.WriteLogRaw("Old: ",Z299HistoricoSolicitudesCotizacion);
                  GXUtil.WriteLogRaw("Current: ",T00114_A299HistoricoSolicitudesCotizacion[0]);
               }
               if ( StringUtil.StrCmp(Z301HistoricoSolicitudServicioSolC, T00114_A301HistoricoSolicitudServicioSolC[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudServicioSolC");
                  GXUtil.WriteLogRaw("Old: ",Z301HistoricoSolicitudServicioSolC);
                  GXUtil.WriteLogRaw("Current: ",T00114_A301HistoricoSolicitudServicioSolC[0]);
               }
               if ( StringUtil.StrCmp(Z303HistoricoSolicitudesOtros1, T00114_A303HistoricoSolicitudesOtros1[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesOtros1");
                  GXUtil.WriteLogRaw("Old: ",Z303HistoricoSolicitudesOtros1);
                  GXUtil.WriteLogRaw("Current: ",T00114_A303HistoricoSolicitudesOtros1[0]);
               }
               if ( StringUtil.StrCmp(Z304HistoricoSolicitudesOtros2, T00114_A304HistoricoSolicitudesOtros2[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesOtros2");
                  GXUtil.WriteLogRaw("Old: ",Z304HistoricoSolicitudesOtros2);
                  GXUtil.WriteLogRaw("Current: ",T00114_A304HistoricoSolicitudesOtros2[0]);
               }
               if ( StringUtil.StrCmp(Z305HistoricoSolicitudesOtros3, T00114_A305HistoricoSolicitudesOtros3[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesOtros3");
                  GXUtil.WriteLogRaw("Old: ",Z305HistoricoSolicitudesOtros3);
                  GXUtil.WriteLogRaw("Current: ",T00114_A305HistoricoSolicitudesOtros3[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z306HistoricoSolicitudesFechaAlta ) != DateTimeUtil.ResetTime ( T00114_A306HistoricoSolicitudesFechaAlta[0] ) )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z306HistoricoSolicitudesFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T00114_A306HistoricoSolicitudesFechaAlta[0]);
               }
               if ( Z307HistoricoSolicitudesFechaActua != T00114_A307HistoricoSolicitudesFechaActua[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesFechaActua");
                  GXUtil.WriteLogRaw("Old: ",Z307HistoricoSolicitudesFechaActua);
                  GXUtil.WriteLogRaw("Current: ",T00114_A307HistoricoSolicitudesFechaActua[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z308HistoricoSolicitudesFechaInsta ) != DateTimeUtil.ResetTime ( T00114_A308HistoricoSolicitudesFechaInsta[0] ) )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesFechaInsta");
                  GXUtil.WriteLogRaw("Old: ",Z308HistoricoSolicitudesFechaInsta);
                  GXUtil.WriteLogRaw("Current: ",T00114_A308HistoricoSolicitudesFechaInsta[0]);
               }
               if ( StringUtil.StrCmp(Z309HistoricoSolicitudesHoraInstal, T00114_A309HistoricoSolicitudesHoraInstal[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesHoraInstal");
                  GXUtil.WriteLogRaw("Old: ",Z309HistoricoSolicitudesHoraInstal);
                  GXUtil.WriteLogRaw("Current: ",T00114_A309HistoricoSolicitudesHoraInstal[0]);
               }
               if ( StringUtil.StrCmp(Z311HistoricoSolicitudesNota, T00114_A311HistoricoSolicitudesNota[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesNota");
                  GXUtil.WriteLogRaw("Old: ",Z311HistoricoSolicitudesNota);
                  GXUtil.WriteLogRaw("Current: ",T00114_A311HistoricoSolicitudesNota[0]);
               }
               if ( StringUtil.StrCmp(Z312HistoricoSolicitudesNotificaci, T00114_A312HistoricoSolicitudesNotificaci[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesNotificaci");
                  GXUtil.WriteLogRaw("Old: ",Z312HistoricoSolicitudesNotificaci);
                  GXUtil.WriteLogRaw("Current: ",T00114_A312HistoricoSolicitudesNotificaci[0]);
               }
               if ( StringUtil.StrCmp(Z439HistoricoSolicitudesOrigenPago, T00114_A439HistoricoSolicitudesOrigenPago[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesOrigenPago");
                  GXUtil.WriteLogRaw("Old: ",Z439HistoricoSolicitudesOrigenPago);
                  GXUtil.WriteLogRaw("Current: ",T00114_A439HistoricoSolicitudesOrigenPago[0]);
               }
               if ( StringUtil.StrCmp(Z442HistoricoSolicitudesPagado, T00114_A442HistoricoSolicitudesPagado[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesPagado");
                  GXUtil.WriteLogRaw("Old: ",Z442HistoricoSolicitudesPagado);
                  GXUtil.WriteLogRaw("Current: ",T00114_A442HistoricoSolicitudesPagado[0]);
               }
               if ( Z623HistoricoSolicitudesComProv != T00114_A623HistoricoSolicitudesComProv[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesComProv");
                  GXUtil.WriteLogRaw("Old: ",Z623HistoricoSolicitudesComProv);
                  GXUtil.WriteLogRaw("Current: ",T00114_A623HistoricoSolicitudesComProv[0]);
               }
               if ( Z626HistoricoSolicitudesComProvP != T00114_A626HistoricoSolicitudesComProvP[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesComProvP");
                  GXUtil.WriteLogRaw("Old: ",Z626HistoricoSolicitudesComProvP);
                  GXUtil.WriteLogRaw("Current: ",T00114_A626HistoricoSolicitudesComProvP[0]);
               }
               if ( Z627HistoricoSolicitudesComALM != T00114_A627HistoricoSolicitudesComALM[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesComALM");
                  GXUtil.WriteLogRaw("Old: ",Z627HistoricoSolicitudesComALM);
                  GXUtil.WriteLogRaw("Current: ",T00114_A627HistoricoSolicitudesComALM[0]);
               }
               if ( Z628HistoricoSolicitudesComALMP != T00114_A628HistoricoSolicitudesComALMP[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesComALMP");
                  GXUtil.WriteLogRaw("Old: ",Z628HistoricoSolicitudesComALMP);
                  GXUtil.WriteLogRaw("Current: ",T00114_A628HistoricoSolicitudesComALMP[0]);
               }
               if ( StringUtil.StrCmp(Z624HistoricoSolicitudesNombreAux, T00114_A624HistoricoSolicitudesNombreAux[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesNombreAux");
                  GXUtil.WriteLogRaw("Old: ",Z624HistoricoSolicitudesNombreAux);
                  GXUtil.WriteLogRaw("Current: ",T00114_A624HistoricoSolicitudesNombreAux[0]);
               }
               if ( StringUtil.StrCmp(Z625HistoricoSolicitudesSubTipo, T00114_A625HistoricoSolicitudesSubTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesSubTipo");
                  GXUtil.WriteLogRaw("Old: ",Z625HistoricoSolicitudesSubTipo);
                  GXUtil.WriteLogRaw("Current: ",T00114_A625HistoricoSolicitudesSubTipo[0]);
               }
               if ( Z633HistoricoSolicitudesProvID != T00114_A633HistoricoSolicitudesProvID[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesProvID");
                  GXUtil.WriteLogRaw("Old: ",Z633HistoricoSolicitudesProvID);
                  GXUtil.WriteLogRaw("Current: ",T00114_A633HistoricoSolicitudesProvID[0]);
               }
               if ( StringUtil.StrCmp(Z634HistoricoSolicitudesProvNombre, T00114_A634HistoricoSolicitudesProvNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesProvNombre");
                  GXUtil.WriteLogRaw("Old: ",Z634HistoricoSolicitudesProvNombre);
                  GXUtil.WriteLogRaw("Current: ",T00114_A634HistoricoSolicitudesProvNombre[0]);
               }
               if ( Z128MetodoPagosID != T00114_A128MetodoPagosID[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"MetodoPagosID");
                  GXUtil.WriteLogRaw("Old: ",Z128MetodoPagosID);
                  GXUtil.WriteLogRaw("Current: ",T00114_A128MetodoPagosID[0]);
               }
               if ( StringUtil.StrCmp(Z130EstadosSolTipo, T00114_A130EstadosSolTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"EstadosSolTipo");
                  GXUtil.WriteLogRaw("Old: ",Z130EstadosSolTipo);
                  GXUtil.WriteLogRaw("Current: ",T00114_A130EstadosSolTipo[0]);
               }
               if ( Z131EstadosSolId != T00114_A131EstadosSolId[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"EstadosSolId");
                  GXUtil.WriteLogRaw("Old: ",Z131EstadosSolId);
                  GXUtil.WriteLogRaw("Current: ",T00114_A131EstadosSolId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"HistoricoSolicitudes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1142( )
      {
         BeforeValidate1142( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1142( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1142( 0) ;
            CheckOptimisticConcurrency1142( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1142( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1142( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001114 */
                     pr_default.execute(12, new Object[] {A153HistoricoSolicitudesID, A288HistoricoSolicitudesNombre, A289HistoricoSolicitudesTelefono, n290HistoricoSolicitudesMail, A290HistoricoSolicitudesMail, A315HistoricoPaisID, A316HistoricoDepartamentoId, A317HistoricoDepartamentoMunicipio, n318HistoricoZonasID, A318HistoricoZonasID, A291HistoricoSolicitudesDireccion, A292HistoricoSolicitudesAutoEnumer, A299HistoricoSolicitudesCotizacion, A301HistoricoSolicitudServicioSolC, A303HistoricoSolicitudesOtros1, A304HistoricoSolicitudesOtros2, A305HistoricoSolicitudesOtros3, A306HistoricoSolicitudesFechaAlta, A307HistoricoSolicitudesFechaActua, A308HistoricoSolicitudesFechaInsta, A309HistoricoSolicitudesHoraInstal, A310HistoricoSolicitudesComentario, A311HistoricoSolicitudesNota, A312HistoricoSolicitudesNotificaci, A439HistoricoSolicitudesOrigenPago, A442HistoricoSolicitudesPagado, A623HistoricoSolicitudesComProv, A626HistoricoSolicitudesComProvP, A627HistoricoSolicitudesComALM, A628HistoricoSolicitudesComALMP, A624HistoricoSolicitudesNombreAux, A625HistoricoSolicitudesSubTipo, A633HistoricoSolicitudesProvID, A634HistoricoSolicitudesProvNombre, A128MetodoPagosID, A130EstadosSolTipo, A131EstadosSolId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("HistoricoSolicitudes");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ProcessLevel1142( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption110( ) ;
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
               Load1142( ) ;
            }
            EndLevel1142( ) ;
         }
         CloseExtendedTableCursors1142( ) ;
      }

      protected void Update1142( )
      {
         BeforeValidate1142( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1142( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1142( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1142( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1142( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001115 */
                     pr_default.execute(13, new Object[] {A288HistoricoSolicitudesNombre, A289HistoricoSolicitudesTelefono, n290HistoricoSolicitudesMail, A290HistoricoSolicitudesMail, A315HistoricoPaisID, A316HistoricoDepartamentoId, A317HistoricoDepartamentoMunicipio, n318HistoricoZonasID, A318HistoricoZonasID, A291HistoricoSolicitudesDireccion, A292HistoricoSolicitudesAutoEnumer, A299HistoricoSolicitudesCotizacion, A301HistoricoSolicitudServicioSolC, A303HistoricoSolicitudesOtros1, A304HistoricoSolicitudesOtros2, A305HistoricoSolicitudesOtros3, A306HistoricoSolicitudesFechaAlta, A307HistoricoSolicitudesFechaActua, A308HistoricoSolicitudesFechaInsta, A309HistoricoSolicitudesHoraInstal, A310HistoricoSolicitudesComentario, A311HistoricoSolicitudesNota, A312HistoricoSolicitudesNotificaci, A439HistoricoSolicitudesOrigenPago, A442HistoricoSolicitudesPagado, A623HistoricoSolicitudesComProv, A626HistoricoSolicitudesComProvP, A627HistoricoSolicitudesComALM, A628HistoricoSolicitudesComALMP, A624HistoricoSolicitudesNombreAux, A625HistoricoSolicitudesSubTipo, A633HistoricoSolicitudesProvID, A634HistoricoSolicitudesProvNombre, A128MetodoPagosID, A130EstadosSolTipo, A131EstadosSolId, A153HistoricoSolicitudesID});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("HistoricoSolicitudes");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistoricoSolicitudes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1142( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1142( ) ;
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
            EndLevel1142( ) ;
         }
         CloseExtendedTableCursors1142( ) ;
      }

      protected void DeferredUpdate1142( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1142( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1142( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1142( ) ;
            AfterConfirm1142( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1142( ) ;
               if ( AnyError == 0 )
               {
                  A300HistoricoSolicitudesTotal = O300HistoricoSolicitudesTotal;
                  AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
                  A629HistoricoSolicitudesComPro = O629HistoricoSolicitudesComPro;
                  AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
                  A302HistoricoSolicitudServicioPFin = O302HistoricoSolicitudServicioPFin;
                  AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
                  ScanStart1143( ) ;
                  while ( RcdFound43 != 0 )
                  {
                     getByPrimaryKey1143( ) ;
                     Delete1143( ) ;
                     ScanNext1143( ) ;
                     O300HistoricoSolicitudesTotal = A300HistoricoSolicitudesTotal;
                     AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
                     O629HistoricoSolicitudesComPro = A629HistoricoSolicitudesComPro;
                     AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
                     O302HistoricoSolicitudServicioPFin = A302HistoricoSolicitudServicioPFin;
                     AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
                  }
                  ScanEnd1143( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001116 */
                     pr_default.execute(14, new Object[] {A153HistoricoSolicitudesID});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("HistoricoSolicitudes");
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
         sMode42 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1142( ) ;
         Gx_mode = sMode42;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1142( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV31Pgmname = "HistoricoSolicitudes";
            AssignAttri("", false, "AV31Pgmname", AV31Pgmname);
            GetHistoricoSolicitudesTotal( A153HistoricoSolicitudesID) ;
            if ( ( A299HistoricoSolicitudesCotizacion == Convert.ToDecimal( 0 )) )
            {
               A302HistoricoSolicitudServicioPFin = A300HistoricoSolicitudesTotal;
               AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            }
            else
            {
               if ( ( A299HistoricoSolicitudesCotizacion > Convert.ToDecimal( 0 )) )
               {
                  A302HistoricoSolicitudServicioPFin = A299HistoricoSolicitudesCotizacion;
                  AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
               }
               else
               {
                  A302HistoricoSolicitudServicioPFin = 0;
                  AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
               }
            }
            /* Using cursor T001117 */
            pr_default.execute(15, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
            A132EstadosSolNombre = T001117_A132EstadosSolNombre[0];
            pr_default.close(15);
            /* Using cursor T001118 */
            pr_default.execute(16, new Object[] {A128MetodoPagosID});
            A129MetodoPagosNombre = T001118_A129MetodoPagosNombre[0];
            pr_default.close(16);
            A629HistoricoSolicitudesComPro = (decimal)(A302HistoricoSolicitudServicioPFin-(A623HistoricoSolicitudesComProv+A627HistoricoSolicitudesComALM));
            AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
            A630HistoricoSolicitudesComProP = (decimal)(100-(A626HistoricoSolicitudesComProvP+A628HistoricoSolicitudesComALMP));
            AssignAttri("", false, "A630HistoricoSolicitudesComProP", StringUtil.LTrimStr( A630HistoricoSolicitudesComProP, 6, 2));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001119 */
            pr_default.execute(17, new Object[] {A153HistoricoSolicitudesID});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel1143( )
      {
         s300HistoricoSolicitudesTotal = O300HistoricoSolicitudesTotal;
         AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
         s629HistoricoSolicitudesComPro = O629HistoricoSolicitudesComPro;
         AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
         s302HistoricoSolicitudServicioPFin = O302HistoricoSolicitudServicioPFin;
         AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
         nGXsfl_168_idx = 0;
         while ( nGXsfl_168_idx < nRC_GXsfl_168 )
         {
            ReadRow1143( ) ;
            if ( ( nRcdExists_43 != 0 ) || ( nIsMod_43 != 0 ) )
            {
               standaloneNotModal1143( ) ;
               GetKey1143( ) ;
               if ( ( nRcdExists_43 == 0 ) && ( nRcdDeleted_43 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1143( ) ;
               }
               else
               {
                  if ( RcdFound43 != 0 )
                  {
                     if ( ( nRcdDeleted_43 != 0 ) && ( nRcdExists_43 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1143( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_43 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1143( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_43 == 0 )
                     {
                        GXCCtl = "HISTORICOSOLICITUDESITEMSID_" + sGXsfl_168_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtHistoricoSolicitudesItemsID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O300HistoricoSolicitudesTotal = A300HistoricoSolicitudesTotal;
               AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
               O629HistoricoSolicitudesComPro = A629HistoricoSolicitudesComPro;
               AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
               O302HistoricoSolicitudServicioPFin = A302HistoricoSolicitudServicioPFin;
               AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            }
            ChangePostValue( edtHistoricoSolicitudesItemsID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A154HistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A330HItemsRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsRubrosNombre_Internalname, StringUtil.RTrim( A331HItemsRubrosNombre)) ;
            ChangePostValue( edtHItemsMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A327HItemsMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A328HItemsInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsInventarioNombre_Internalname, StringUtil.RTrim( A329HItemsInventarioNombre)) ;
            ChangePostValue( edtHItemsInventarioPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A295HItemsInventarioPrecioFinal), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsSolicitudesItemsCantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A293HItemsSolicitudesItemsCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHistoricoSolicitudesItemsSR_Internalname, StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)) ;
            ChangePostValue( edtHistoricoSolicitudesItemsCT_Internalname, StringUtil.RTrim( A297HistoricoSolicitudesItemsCT)) ;
            ChangePostValue( edtHistoricoSolicitudesItemsComis_Internalname, StringUtil.LTrim( StringUtil.NToC( A298HistoricoSolicitudesItemsComis, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsSolicitudesItemsPrecioIn_Internalname, StringUtil.LTrim( StringUtil.NToC( A294HItemsSolicitudesItemsPrecioIn, 21, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtHItemsSolicitudesMonedaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A319HItemsSolicitudesMonedaId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z154HistoricoSolicitudesItemsID_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z154HistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z330HItemsRubrosId_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z330HItemsRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z331HItemsRubrosNombre_"+sGXsfl_168_idx, StringUtil.RTrim( Z331HItemsRubrosNombre)) ;
            ChangePostValue( "ZT_"+"Z327HItemsMedidasID_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z327HItemsMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z328HItemsInventarioId_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z328HItemsInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z329HItemsInventarioNombre_"+sGXsfl_168_idx, StringUtil.RTrim( Z329HItemsInventarioNombre)) ;
            ChangePostValue( "ZT_"+"Z295HItemsInventarioPrecioFinal_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z295HItemsInventarioPrecioFinal), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z293HItemsSolicitudesItemsCantidad_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z293HItemsSolicitudesItemsCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z296HistoricoSolicitudesItemsSR_"+sGXsfl_168_idx, StringUtil.RTrim( Z296HistoricoSolicitudesItemsSR)) ;
            ChangePostValue( "ZT_"+"Z297HistoricoSolicitudesItemsCT_"+sGXsfl_168_idx, StringUtil.RTrim( Z297HistoricoSolicitudesItemsCT)) ;
            ChangePostValue( "ZT_"+"Z298HistoricoSolicitudesItemsComis_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( Z298HistoricoSolicitudesItemsComis, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z319HItemsSolicitudesMonedaId_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z319HItemsSolicitudesMonedaId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "T294HItemsSolicitudesItemsPrecioIn_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( O294HItemsSolicitudesItemsPrecioIn, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_43_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_43), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_43_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_43), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_43_"+sGXsfl_168_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_43), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_43 != 0 )
            {
               ChangePostValue( "HISTORICOSOLICITUDESITEMSID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSRUBROSID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsRubrosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSRUBROSNOMBRE_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsRubrosNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSMEDIDASID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsMedidasID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSINVENTARIOID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsInventarioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSINVENTARIONOMBRE_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsInventarioNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSINVENTARIOPRECIOFINAL_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsInventarioPrecioFinal_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSSOLICITUDESITEMSCANTIDAD_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsSolicitudesItemsCantidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICOSOLICITUDESITEMSSR_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsSR_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICOSOLICITUDESITEMSCT_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsCT_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HISTORICOSOLICITUDESITEMSCOMIS_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsComis_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSSOLICITUDESITEMSPRECIOIN_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsSolicitudesItemsPrecioIn_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "HITEMSSOLICITUDESMONEDAID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsSolicitudesMonedaId_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1143( ) ;
         if ( AnyError != 0 )
         {
            O300HistoricoSolicitudesTotal = s300HistoricoSolicitudesTotal;
            AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
            O629HistoricoSolicitudesComPro = s629HistoricoSolicitudesComPro;
            AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
            O302HistoricoSolicitudServicioPFin = s302HistoricoSolicitudServicioPFin;
            AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
         }
         nRcdExists_43 = 0;
         nIsMod_43 = 0;
         nRcdDeleted_43 = 0;
      }

      protected void ProcessLevel1142( )
      {
         /* Save parent mode. */
         sMode42 = Gx_mode;
         ProcessNestedLevel1143( ) ;
         if ( AnyError != 0 )
         {
            O300HistoricoSolicitudesTotal = s300HistoricoSolicitudesTotal;
            AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
            O629HistoricoSolicitudesComPro = s629HistoricoSolicitudesComPro;
            AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
            O302HistoricoSolicitudServicioPFin = s302HistoricoSolicitudServicioPFin;
            AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
         }
         /* Restore parent mode. */
         Gx_mode = sMode42;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1142( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1142( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(16);
            pr_default.close(15);
            context.CommitDataStores("historicosolicitudes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues110( ) ;
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
            pr_default.close(16);
            pr_default.close(15);
            context.RollbackDataStores("historicosolicitudes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1142( )
      {
         /* Scan By routine */
         /* Using cursor T001120 */
         pr_default.execute(18);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound42 = 1;
            A153HistoricoSolicitudesID = T001120_A153HistoricoSolicitudesID[0];
            AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1142( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound42 = 1;
            A153HistoricoSolicitudesID = T001120_A153HistoricoSolicitudesID[0];
            AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
         }
      }

      protected void ScanEnd1142( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm1142( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1142( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1142( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1142( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1142( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1142( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1142( )
      {
         edtHistoricoSolicitudesID_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Enabled), 5, 0), true);
         edtHistoricoSolicitudesNombre_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesNombre_Enabled), 5, 0), true);
         edtHistoricoSolicitudesTelefono_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesTelefono_Enabled), 5, 0), true);
         edtHistoricoSolicitudesMail_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesMail_Enabled), 5, 0), true);
         edtHistoricoPaisID_Enabled = 0;
         AssignProp("", false, edtHistoricoPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoPaisID_Enabled), 5, 0), true);
         edtHistoricoDepartamentoId_Enabled = 0;
         AssignProp("", false, edtHistoricoDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoDepartamentoId_Enabled), 5, 0), true);
         edtHistoricoDepartamentoMunicipio_Enabled = 0;
         AssignProp("", false, edtHistoricoDepartamentoMunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoDepartamentoMunicipio_Enabled), 5, 0), true);
         edtHistoricoZonasID_Enabled = 0;
         AssignProp("", false, edtHistoricoZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoZonasID_Enabled), 5, 0), true);
         edtHistoricoSolicitudesDireccion_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesDireccion_Enabled), 5, 0), true);
         edtHistoricoSolicitudesAutoEnumer_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesAutoEnumer_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesAutoEnumer_Enabled), 5, 0), true);
         edtHistoricoSolicitudesCotizacion_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesCotizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesCotizacion_Enabled), 5, 0), true);
         edtHistoricoSolicitudesTotal_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesTotal_Enabled), 5, 0), true);
         edtHistoricoSolicitudServicioSolC_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudServicioSolC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudServicioSolC_Enabled), 5, 0), true);
         edtHistoricoSolicitudServicioPFin_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudServicioPFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudServicioPFin_Enabled), 5, 0), true);
         edtEstadosSolTipo_Enabled = 0;
         AssignProp("", false, edtEstadosSolTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolTipo_Enabled), 5, 0), true);
         edtEstadosSolId_Enabled = 0;
         AssignProp("", false, edtEstadosSolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolId_Enabled), 5, 0), true);
         edtHistoricoSolicitudesOtros1_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesOtros1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesOtros1_Enabled), 5, 0), true);
         edtHistoricoSolicitudesOtros2_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesOtros2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesOtros2_Enabled), 5, 0), true);
         edtHistoricoSolicitudesOtros3_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesOtros3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesOtros3_Enabled), 5, 0), true);
         edtHistoricoSolicitudesFechaAlta_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesFechaAlta_Enabled), 5, 0), true);
         edtHistoricoSolicitudesFechaActua_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesFechaActua_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesFechaActua_Enabled), 5, 0), true);
         edtHistoricoSolicitudesFechaInsta_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesFechaInsta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesFechaInsta_Enabled), 5, 0), true);
         edtHistoricoSolicitudesHoraInstal_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesHoraInstal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesHoraInstal_Enabled), 5, 0), true);
         edtHistoricoSolicitudesComentario_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesComentario_Enabled), 5, 0), true);
         edtMetodoPagosID_Enabled = 0;
         AssignProp("", false, edtMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Enabled), 5, 0), true);
         edtHistoricoSolicitudesNota_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesNota_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesNota_Enabled), 5, 0), true);
         edtHistoricoSolicitudesNotificaci_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesNotificaci_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesNotificaci_Enabled), 5, 0), true);
         edtHistoricoSolicitudesOrigenPago_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesOrigenPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesOrigenPago_Enabled), 5, 0), true);
         cmbHistoricoSolicitudesPagado.Enabled = 0;
         AssignProp("", false, cmbHistoricoSolicitudesPagado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbHistoricoSolicitudesPagado.Enabled), 5, 0), true);
      }

      protected void ZM1143( short GX_JID )
      {
         if ( ( GX_JID == 30 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z330HItemsRubrosId = T00113_A330HItemsRubrosId[0];
               Z331HItemsRubrosNombre = T00113_A331HItemsRubrosNombre[0];
               Z327HItemsMedidasID = T00113_A327HItemsMedidasID[0];
               Z328HItemsInventarioId = T00113_A328HItemsInventarioId[0];
               Z329HItemsInventarioNombre = T00113_A329HItemsInventarioNombre[0];
               Z295HItemsInventarioPrecioFinal = T00113_A295HItemsInventarioPrecioFinal[0];
               Z293HItemsSolicitudesItemsCantidad = T00113_A293HItemsSolicitudesItemsCantidad[0];
               Z296HistoricoSolicitudesItemsSR = T00113_A296HistoricoSolicitudesItemsSR[0];
               Z297HistoricoSolicitudesItemsCT = T00113_A297HistoricoSolicitudesItemsCT[0];
               Z298HistoricoSolicitudesItemsComis = T00113_A298HistoricoSolicitudesItemsComis[0];
               Z319HItemsSolicitudesMonedaId = T00113_A319HItemsSolicitudesMonedaId[0];
            }
            else
            {
               Z330HItemsRubrosId = A330HItemsRubrosId;
               Z331HItemsRubrosNombre = A331HItemsRubrosNombre;
               Z327HItemsMedidasID = A327HItemsMedidasID;
               Z328HItemsInventarioId = A328HItemsInventarioId;
               Z329HItemsInventarioNombre = A329HItemsInventarioNombre;
               Z295HItemsInventarioPrecioFinal = A295HItemsInventarioPrecioFinal;
               Z293HItemsSolicitudesItemsCantidad = A293HItemsSolicitudesItemsCantidad;
               Z296HistoricoSolicitudesItemsSR = A296HistoricoSolicitudesItemsSR;
               Z297HistoricoSolicitudesItemsCT = A297HistoricoSolicitudesItemsCT;
               Z298HistoricoSolicitudesItemsComis = A298HistoricoSolicitudesItemsComis;
               Z319HItemsSolicitudesMonedaId = A319HItemsSolicitudesMonedaId;
            }
         }
         if ( GX_JID == -30 )
         {
            Z153HistoricoSolicitudesID = A153HistoricoSolicitudesID;
            Z154HistoricoSolicitudesItemsID = A154HistoricoSolicitudesItemsID;
            Z330HItemsRubrosId = A330HItemsRubrosId;
            Z331HItemsRubrosNombre = A331HItemsRubrosNombre;
            Z327HItemsMedidasID = A327HItemsMedidasID;
            Z328HItemsInventarioId = A328HItemsInventarioId;
            Z329HItemsInventarioNombre = A329HItemsInventarioNombre;
            Z295HItemsInventarioPrecioFinal = A295HItemsInventarioPrecioFinal;
            Z293HItemsSolicitudesItemsCantidad = A293HItemsSolicitudesItemsCantidad;
            Z296HistoricoSolicitudesItemsSR = A296HistoricoSolicitudesItemsSR;
            Z297HistoricoSolicitudesItemsCT = A297HistoricoSolicitudesItemsCT;
            Z298HistoricoSolicitudesItemsComis = A298HistoricoSolicitudesItemsComis;
            Z319HItemsSolicitudesMonedaId = A319HItemsSolicitudesMonedaId;
         }
      }

      protected void standaloneNotModal1143( )
      {
      }

      protected void standaloneModal1143( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtHistoricoSolicitudesItemsID_Enabled = 0;
            AssignProp("", false, edtHistoricoSolicitudesItemsID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesItemsID_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         }
         else
         {
            edtHistoricoSolicitudesItemsID_Enabled = 1;
            AssignProp("", false, edtHistoricoSolicitudesItemsID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesItemsID_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            if ( ( A299HistoricoSolicitudesCotizacion == Convert.ToDecimal( 0 )) )
            {
               A302HistoricoSolicitudServicioPFin = A300HistoricoSolicitudesTotal;
               AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            }
            else
            {
               if ( ( A299HistoricoSolicitudesCotizacion > Convert.ToDecimal( 0 )) )
               {
                  A302HistoricoSolicitudServicioPFin = A299HistoricoSolicitudesCotizacion;
                  AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
               }
               else
               {
                  A302HistoricoSolicitudServicioPFin = 0;
                  AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
               }
            }
            A629HistoricoSolicitudesComPro = (decimal)(A302HistoricoSolicitudServicioPFin-(A623HistoricoSolicitudesComProv+A627HistoricoSolicitudesComALM));
            AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
         }
      }

      protected void Load1143( )
      {
         /* Using cursor T001121 */
         pr_default.execute(19, new Object[] {A153HistoricoSolicitudesID, A154HistoricoSolicitudesItemsID});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound43 = 1;
            A330HItemsRubrosId = T001121_A330HItemsRubrosId[0];
            A331HItemsRubrosNombre = T001121_A331HItemsRubrosNombre[0];
            A327HItemsMedidasID = T001121_A327HItemsMedidasID[0];
            A328HItemsInventarioId = T001121_A328HItemsInventarioId[0];
            A329HItemsInventarioNombre = T001121_A329HItemsInventarioNombre[0];
            A295HItemsInventarioPrecioFinal = T001121_A295HItemsInventarioPrecioFinal[0];
            A293HItemsSolicitudesItemsCantidad = T001121_A293HItemsSolicitudesItemsCantidad[0];
            A296HistoricoSolicitudesItemsSR = T001121_A296HistoricoSolicitudesItemsSR[0];
            A297HistoricoSolicitudesItemsCT = T001121_A297HistoricoSolicitudesItemsCT[0];
            A298HistoricoSolicitudesItemsComis = T001121_A298HistoricoSolicitudesItemsComis[0];
            A319HItemsSolicitudesMonedaId = T001121_A319HItemsSolicitudesMonedaId[0];
            ZM1143( -30) ;
         }
         pr_default.close(19);
         OnLoadActions1143( ) ;
      }

      protected void OnLoadActions1143( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)) || ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "N", "")) == 0 ) )
         {
            A294HItemsSolicitudesItemsPrecioIn = (decimal)(A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad);
         }
         else
         {
            if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
            }
            else
            {
               if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                     }
                     else
                     {
                        A294HItemsSolicitudesItemsPrecioIn = 0;
                     }
                  }
               }
            }
         }
         O294HItemsSolicitudesItemsPrecioIn = A294HItemsSolicitudesItemsPrecioIn;
      }

      protected void CheckExtendedTable1143( )
      {
         nIsDirty_43 = 0;
         Gx_BScreen = 1;
         standaloneModal1143( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)) || ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "N", "")) == 0 ) )
         {
            nIsDirty_43 = 1;
            A294HItemsSolicitudesItemsPrecioIn = (decimal)(A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad);
         }
         else
         {
            if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
            {
               nIsDirty_43 = 1;
               A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
            }
            else
            {
               if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
               {
                  nIsDirty_43 = 1;
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
                  {
                     nIsDirty_43 = 1;
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                     {
                        nIsDirty_43 = 1;
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                     }
                     else
                     {
                        nIsDirty_43 = 1;
                        A294HItemsSolicitudesItemsPrecioIn = 0;
                     }
                  }
               }
            }
         }
         if ( IsIns( )  )
         {
            nIsDirty_43 = 1;
            A300HistoricoSolicitudesTotal = (decimal)(O300HistoricoSolicitudesTotal+A294HItemsSolicitudesItemsPrecioIn);
            AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_43 = 1;
               A300HistoricoSolicitudesTotal = (decimal)(O300HistoricoSolicitudesTotal+A294HItemsSolicitudesItemsPrecioIn-O294HItemsSolicitudesItemsPrecioIn);
               AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_43 = 1;
                  A300HistoricoSolicitudesTotal = (decimal)(O300HistoricoSolicitudesTotal-O294HItemsSolicitudesItemsPrecioIn);
                  AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
               }
            }
         }
         if ( ( A299HistoricoSolicitudesCotizacion == Convert.ToDecimal( 0 )) )
         {
            nIsDirty_43 = 1;
            A302HistoricoSolicitudServicioPFin = A300HistoricoSolicitudesTotal;
            AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
         }
         else
         {
            if ( ( A299HistoricoSolicitudesCotizacion > Convert.ToDecimal( 0 )) )
            {
               nIsDirty_43 = 1;
               A302HistoricoSolicitudServicioPFin = A299HistoricoSolicitudesCotizacion;
               AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            }
            else
            {
               nIsDirty_43 = 1;
               A302HistoricoSolicitudServicioPFin = 0;
               AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            }
         }
         nIsDirty_43 = 1;
         A629HistoricoSolicitudesComPro = (decimal)(A302HistoricoSolicitudServicioPFin-(A623HistoricoSolicitudesComProv+A627HistoricoSolicitudesComALM));
         AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
      }

      protected void CloseExtendedTableCursors1143( )
      {
      }

      protected void enableDisable1143( )
      {
      }

      protected void GetKey1143( )
      {
         /* Using cursor T001122 */
         pr_default.execute(20, new Object[] {A153HistoricoSolicitudesID, A154HistoricoSolicitudesItemsID});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound43 = 1;
         }
         else
         {
            RcdFound43 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey1143( )
      {
         /* Using cursor T00113 */
         pr_default.execute(1, new Object[] {A153HistoricoSolicitudesID, A154HistoricoSolicitudesItemsID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1143( 30) ;
            RcdFound43 = 1;
            InitializeNonKey1143( ) ;
            A154HistoricoSolicitudesItemsID = T00113_A154HistoricoSolicitudesItemsID[0];
            A330HItemsRubrosId = T00113_A330HItemsRubrosId[0];
            A331HItemsRubrosNombre = T00113_A331HItemsRubrosNombre[0];
            A327HItemsMedidasID = T00113_A327HItemsMedidasID[0];
            A328HItemsInventarioId = T00113_A328HItemsInventarioId[0];
            A329HItemsInventarioNombre = T00113_A329HItemsInventarioNombre[0];
            A295HItemsInventarioPrecioFinal = T00113_A295HItemsInventarioPrecioFinal[0];
            A293HItemsSolicitudesItemsCantidad = T00113_A293HItemsSolicitudesItemsCantidad[0];
            A296HistoricoSolicitudesItemsSR = T00113_A296HistoricoSolicitudesItemsSR[0];
            A297HistoricoSolicitudesItemsCT = T00113_A297HistoricoSolicitudesItemsCT[0];
            A298HistoricoSolicitudesItemsComis = T00113_A298HistoricoSolicitudesItemsComis[0];
            A319HItemsSolicitudesMonedaId = T00113_A319HItemsSolicitudesMonedaId[0];
            Z153HistoricoSolicitudesID = A153HistoricoSolicitudesID;
            Z154HistoricoSolicitudesItemsID = A154HistoricoSolicitudesItemsID;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1143( ) ;
            Gx_mode = sMode43;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound43 = 0;
            InitializeNonKey1143( ) ;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1143( ) ;
            Gx_mode = sMode43;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1143( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1143( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00112 */
            pr_default.execute(0, new Object[] {A153HistoricoSolicitudesID, A154HistoricoSolicitudesItemsID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistoricoSolicitudesItems"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z330HItemsRubrosId != T00112_A330HItemsRubrosId[0] ) || ( StringUtil.StrCmp(Z331HItemsRubrosNombre, T00112_A331HItemsRubrosNombre[0]) != 0 ) || ( Z327HItemsMedidasID != T00112_A327HItemsMedidasID[0] ) || ( Z328HItemsInventarioId != T00112_A328HItemsInventarioId[0] ) || ( StringUtil.StrCmp(Z329HItemsInventarioNombre, T00112_A329HItemsInventarioNombre[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z295HItemsInventarioPrecioFinal != T00112_A295HItemsInventarioPrecioFinal[0] ) || ( Z293HItemsSolicitudesItemsCantidad != T00112_A293HItemsSolicitudesItemsCantidad[0] ) || ( StringUtil.StrCmp(Z296HistoricoSolicitudesItemsSR, T00112_A296HistoricoSolicitudesItemsSR[0]) != 0 ) || ( StringUtil.StrCmp(Z297HistoricoSolicitudesItemsCT, T00112_A297HistoricoSolicitudesItemsCT[0]) != 0 ) || ( Z298HistoricoSolicitudesItemsComis != T00112_A298HistoricoSolicitudesItemsComis[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z319HItemsSolicitudesMonedaId != T00112_A319HItemsSolicitudesMonedaId[0] ) )
            {
               if ( Z330HItemsRubrosId != T00112_A330HItemsRubrosId[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HItemsRubrosId");
                  GXUtil.WriteLogRaw("Old: ",Z330HItemsRubrosId);
                  GXUtil.WriteLogRaw("Current: ",T00112_A330HItemsRubrosId[0]);
               }
               if ( StringUtil.StrCmp(Z331HItemsRubrosNombre, T00112_A331HItemsRubrosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HItemsRubrosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z331HItemsRubrosNombre);
                  GXUtil.WriteLogRaw("Current: ",T00112_A331HItemsRubrosNombre[0]);
               }
               if ( Z327HItemsMedidasID != T00112_A327HItemsMedidasID[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HItemsMedidasID");
                  GXUtil.WriteLogRaw("Old: ",Z327HItemsMedidasID);
                  GXUtil.WriteLogRaw("Current: ",T00112_A327HItemsMedidasID[0]);
               }
               if ( Z328HItemsInventarioId != T00112_A328HItemsInventarioId[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HItemsInventarioId");
                  GXUtil.WriteLogRaw("Old: ",Z328HItemsInventarioId);
                  GXUtil.WriteLogRaw("Current: ",T00112_A328HItemsInventarioId[0]);
               }
               if ( StringUtil.StrCmp(Z329HItemsInventarioNombre, T00112_A329HItemsInventarioNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HItemsInventarioNombre");
                  GXUtil.WriteLogRaw("Old: ",Z329HItemsInventarioNombre);
                  GXUtil.WriteLogRaw("Current: ",T00112_A329HItemsInventarioNombre[0]);
               }
               if ( Z295HItemsInventarioPrecioFinal != T00112_A295HItemsInventarioPrecioFinal[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HItemsInventarioPrecioFinal");
                  GXUtil.WriteLogRaw("Old: ",Z295HItemsInventarioPrecioFinal);
                  GXUtil.WriteLogRaw("Current: ",T00112_A295HItemsInventarioPrecioFinal[0]);
               }
               if ( Z293HItemsSolicitudesItemsCantidad != T00112_A293HItemsSolicitudesItemsCantidad[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HItemsSolicitudesItemsCantidad");
                  GXUtil.WriteLogRaw("Old: ",Z293HItemsSolicitudesItemsCantidad);
                  GXUtil.WriteLogRaw("Current: ",T00112_A293HItemsSolicitudesItemsCantidad[0]);
               }
               if ( StringUtil.StrCmp(Z296HistoricoSolicitudesItemsSR, T00112_A296HistoricoSolicitudesItemsSR[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesItemsSR");
                  GXUtil.WriteLogRaw("Old: ",Z296HistoricoSolicitudesItemsSR);
                  GXUtil.WriteLogRaw("Current: ",T00112_A296HistoricoSolicitudesItemsSR[0]);
               }
               if ( StringUtil.StrCmp(Z297HistoricoSolicitudesItemsCT, T00112_A297HistoricoSolicitudesItemsCT[0]) != 0 )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesItemsCT");
                  GXUtil.WriteLogRaw("Old: ",Z297HistoricoSolicitudesItemsCT);
                  GXUtil.WriteLogRaw("Current: ",T00112_A297HistoricoSolicitudesItemsCT[0]);
               }
               if ( Z298HistoricoSolicitudesItemsComis != T00112_A298HistoricoSolicitudesItemsComis[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HistoricoSolicitudesItemsComis");
                  GXUtil.WriteLogRaw("Old: ",Z298HistoricoSolicitudesItemsComis);
                  GXUtil.WriteLogRaw("Current: ",T00112_A298HistoricoSolicitudesItemsComis[0]);
               }
               if ( Z319HItemsSolicitudesMonedaId != T00112_A319HItemsSolicitudesMonedaId[0] )
               {
                  GXUtil.WriteLog("historicosolicitudes:[seudo value changed for attri]"+"HItemsSolicitudesMonedaId");
                  GXUtil.WriteLogRaw("Old: ",Z319HItemsSolicitudesMonedaId);
                  GXUtil.WriteLogRaw("Current: ",T00112_A319HItemsSolicitudesMonedaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"HistoricoSolicitudesItems"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1143( )
      {
         BeforeValidate1143( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1143( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1143( 0) ;
            CheckOptimisticConcurrency1143( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1143( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1143( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001123 */
                     pr_default.execute(21, new Object[] {A153HistoricoSolicitudesID, A154HistoricoSolicitudesItemsID, A330HItemsRubrosId, A331HItemsRubrosNombre, A327HItemsMedidasID, A328HItemsInventarioId, A329HItemsInventarioNombre, A295HItemsInventarioPrecioFinal, A293HItemsSolicitudesItemsCantidad, A296HistoricoSolicitudesItemsSR, A297HistoricoSolicitudesItemsCT, A298HistoricoSolicitudesItemsComis, A319HItemsSolicitudesMonedaId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("HistoricoSolicitudesItems");
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
               Load1143( ) ;
            }
            EndLevel1143( ) ;
         }
         CloseExtendedTableCursors1143( ) ;
      }

      protected void Update1143( )
      {
         BeforeValidate1143( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1143( ) ;
         }
         if ( ( nIsMod_43 != 0 ) || ( nIsDirty_43 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1143( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1143( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1143( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001124 */
                        pr_default.execute(22, new Object[] {A330HItemsRubrosId, A331HItemsRubrosNombre, A327HItemsMedidasID, A328HItemsInventarioId, A329HItemsInventarioNombre, A295HItemsInventarioPrecioFinal, A293HItemsSolicitudesItemsCantidad, A296HistoricoSolicitudesItemsSR, A297HistoricoSolicitudesItemsCT, A298HistoricoSolicitudesItemsComis, A319HItemsSolicitudesMonedaId, A153HistoricoSolicitudesID, A154HistoricoSolicitudesItemsID});
                        pr_default.close(22);
                        pr_default.SmartCacheProvider.SetUpdated("HistoricoSolicitudesItems");
                        if ( (pr_default.getStatus(22) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistoricoSolicitudesItems"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1143( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1143( ) ;
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
               EndLevel1143( ) ;
            }
         }
         CloseExtendedTableCursors1143( ) ;
      }

      protected void DeferredUpdate1143( )
      {
      }

      protected void Delete1143( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1143( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1143( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1143( ) ;
            AfterConfirm1143( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1143( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001125 */
                  pr_default.execute(23, new Object[] {A153HistoricoSolicitudesID, A154HistoricoSolicitudesItemsID});
                  pr_default.close(23);
                  pr_default.SmartCacheProvider.SetUpdated("HistoricoSolicitudesItems");
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
         sMode43 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1143( ) ;
         Gx_mode = sMode43;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1143( )
      {
         standaloneModal1143( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)) || ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "N", "")) == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad);
            }
            else
            {
               if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "F", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+(A298HistoricoSolicitudesItemsComis*A293HItemsSolicitudesItemsCantidad));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "R", "")) == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)-((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(A297HistoricoSolicitudesItemsCT, context.GetMessage( "P", "")) == 0 ) && ( StringUtil.StrCmp(A296HistoricoSolicitudesItemsSR, context.GetMessage( "S", "")) == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)+((A295HItemsInventarioPrecioFinal*A293HItemsSolicitudesItemsCantidad)*(A298HistoricoSolicitudesItemsComis/ (decimal)(100))));
                        }
                        else
                        {
                           A294HItemsSolicitudesItemsPrecioIn = 0;
                        }
                     }
                  }
               }
            }
            if ( IsIns( )  )
            {
               A300HistoricoSolicitudesTotal = (decimal)(O300HistoricoSolicitudesTotal+A294HItemsSolicitudesItemsPrecioIn);
               AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A300HistoricoSolicitudesTotal = (decimal)(O300HistoricoSolicitudesTotal+A294HItemsSolicitudesItemsPrecioIn-O294HItemsSolicitudesItemsPrecioIn);
                  AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A300HistoricoSolicitudesTotal = (decimal)(O300HistoricoSolicitudesTotal-O294HItemsSolicitudesItemsPrecioIn);
                     AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
                  }
               }
            }
            if ( ( A299HistoricoSolicitudesCotizacion == Convert.ToDecimal( 0 )) )
            {
               A302HistoricoSolicitudServicioPFin = A300HistoricoSolicitudesTotal;
               AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            }
            else
            {
               if ( ( A299HistoricoSolicitudesCotizacion > Convert.ToDecimal( 0 )) )
               {
                  A302HistoricoSolicitudServicioPFin = A299HistoricoSolicitudesCotizacion;
                  AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
               }
               else
               {
                  A302HistoricoSolicitudServicioPFin = 0;
                  AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
               }
            }
            A629HistoricoSolicitudesComPro = (decimal)(A302HistoricoSolicitudServicioPFin-(A623HistoricoSolicitudesComProv+A627HistoricoSolicitudesComALM));
            AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
         }
      }

      protected void EndLevel1143( )
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

      public void ScanStart1143( )
      {
         /* Scan By routine */
         /* Using cursor T001126 */
         pr_default.execute(24, new Object[] {A153HistoricoSolicitudesID});
         RcdFound43 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound43 = 1;
            A154HistoricoSolicitudesItemsID = T001126_A154HistoricoSolicitudesItemsID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1143( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound43 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound43 = 1;
            A154HistoricoSolicitudesItemsID = T001126_A154HistoricoSolicitudesItemsID[0];
         }
      }

      protected void ScanEnd1143( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm1143( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1143( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1143( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1143( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1143( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1143( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1143( )
      {
         edtHistoricoSolicitudesItemsID_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesItemsID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesItemsID_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtHItemsRubrosId_Enabled = 0;
         AssignProp("", false, edtHItemsRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsRubrosId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtHItemsRubrosNombre_Enabled = 0;
         AssignProp("", false, edtHItemsRubrosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsRubrosNombre_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtHItemsMedidasID_Enabled = 0;
         AssignProp("", false, edtHItemsMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsMedidasID_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtHItemsInventarioId_Enabled = 0;
         AssignProp("", false, edtHItemsInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsInventarioId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtHItemsInventarioNombre_Enabled = 0;
         AssignProp("", false, edtHItemsInventarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsInventarioNombre_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtHItemsInventarioPrecioFinal_Enabled = 0;
         AssignProp("", false, edtHItemsInventarioPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsInventarioPrecioFinal_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtHItemsSolicitudesItemsCantidad_Enabled = 0;
         AssignProp("", false, edtHItemsSolicitudesItemsCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsSolicitudesItemsCantidad_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtHistoricoSolicitudesItemsSR_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesItemsSR_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesItemsSR_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtHistoricoSolicitudesItemsCT_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesItemsCT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesItemsCT_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtHistoricoSolicitudesItemsComis_Enabled = 0;
         AssignProp("", false, edtHistoricoSolicitudesItemsComis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesItemsComis_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtHItemsSolicitudesItemsPrecioIn_Enabled = 0;
         AssignProp("", false, edtHItemsSolicitudesItemsPrecioIn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsSolicitudesItemsPrecioIn_Enabled), 5, 0), !bGXsfl_168_Refreshing);
         edtHItemsSolicitudesMonedaId_Enabled = 0;
         AssignProp("", false, edtHItemsSolicitudesMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHItemsSolicitudesMonedaId_Enabled), 5, 0), !bGXsfl_168_Refreshing);
      }

      protected void send_integrity_lvl_hashes1143( )
      {
      }

      protected void send_integrity_lvl_hashes1142( )
      {
      }

      protected void SubsflControlProps_16843( )
      {
         edtHistoricoSolicitudesItemsID_Internalname = "HISTORICOSOLICITUDESITEMSID_"+sGXsfl_168_idx;
         edtHItemsRubrosId_Internalname = "HITEMSRUBROSID_"+sGXsfl_168_idx;
         edtHItemsRubrosNombre_Internalname = "HITEMSRUBROSNOMBRE_"+sGXsfl_168_idx;
         edtHItemsMedidasID_Internalname = "HITEMSMEDIDASID_"+sGXsfl_168_idx;
         edtHItemsInventarioId_Internalname = "HITEMSINVENTARIOID_"+sGXsfl_168_idx;
         edtHItemsInventarioNombre_Internalname = "HITEMSINVENTARIONOMBRE_"+sGXsfl_168_idx;
         edtHItemsInventarioPrecioFinal_Internalname = "HITEMSINVENTARIOPRECIOFINAL_"+sGXsfl_168_idx;
         edtHItemsSolicitudesItemsCantidad_Internalname = "HITEMSSOLICITUDESITEMSCANTIDAD_"+sGXsfl_168_idx;
         edtHistoricoSolicitudesItemsSR_Internalname = "HISTORICOSOLICITUDESITEMSSR_"+sGXsfl_168_idx;
         edtHistoricoSolicitudesItemsCT_Internalname = "HISTORICOSOLICITUDESITEMSCT_"+sGXsfl_168_idx;
         edtHistoricoSolicitudesItemsComis_Internalname = "HISTORICOSOLICITUDESITEMSCOMIS_"+sGXsfl_168_idx;
         edtHItemsSolicitudesItemsPrecioIn_Internalname = "HITEMSSOLICITUDESITEMSPRECIOIN_"+sGXsfl_168_idx;
         edtHItemsSolicitudesMonedaId_Internalname = "HITEMSSOLICITUDESMONEDAID_"+sGXsfl_168_idx;
      }

      protected void SubsflControlProps_fel_16843( )
      {
         edtHistoricoSolicitudesItemsID_Internalname = "HISTORICOSOLICITUDESITEMSID_"+sGXsfl_168_fel_idx;
         edtHItemsRubrosId_Internalname = "HITEMSRUBROSID_"+sGXsfl_168_fel_idx;
         edtHItemsRubrosNombre_Internalname = "HITEMSRUBROSNOMBRE_"+sGXsfl_168_fel_idx;
         edtHItemsMedidasID_Internalname = "HITEMSMEDIDASID_"+sGXsfl_168_fel_idx;
         edtHItemsInventarioId_Internalname = "HITEMSINVENTARIOID_"+sGXsfl_168_fel_idx;
         edtHItemsInventarioNombre_Internalname = "HITEMSINVENTARIONOMBRE_"+sGXsfl_168_fel_idx;
         edtHItemsInventarioPrecioFinal_Internalname = "HITEMSINVENTARIOPRECIOFINAL_"+sGXsfl_168_fel_idx;
         edtHItemsSolicitudesItemsCantidad_Internalname = "HITEMSSOLICITUDESITEMSCANTIDAD_"+sGXsfl_168_fel_idx;
         edtHistoricoSolicitudesItemsSR_Internalname = "HISTORICOSOLICITUDESITEMSSR_"+sGXsfl_168_fel_idx;
         edtHistoricoSolicitudesItemsCT_Internalname = "HISTORICOSOLICITUDESITEMSCT_"+sGXsfl_168_fel_idx;
         edtHistoricoSolicitudesItemsComis_Internalname = "HISTORICOSOLICITUDESITEMSCOMIS_"+sGXsfl_168_fel_idx;
         edtHItemsSolicitudesItemsPrecioIn_Internalname = "HITEMSSOLICITUDESITEMSPRECIOIN_"+sGXsfl_168_fel_idx;
         edtHItemsSolicitudesMonedaId_Internalname = "HITEMSSOLICITUDESMONEDAID_"+sGXsfl_168_fel_idx;
      }

      protected void AddRow1143( )
      {
         nGXsfl_168_idx = (int)(nGXsfl_168_idx+1);
         sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx), 4, 0), 4, "0");
         SubsflControlProps_16843( ) ;
         SendRow1143( ) ;
      }

      protected void SendRow1143( )
      {
         Gridlevel_itemsRow = GXWebRow.GetNew(context);
         if ( subGridlevel_items_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_items_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_items_Class, "") != 0 )
            {
               subGridlevel_items_Linesclass = subGridlevel_items_Class+"Odd";
            }
         }
         else if ( subGridlevel_items_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_items_Backstyle = 0;
            subGridlevel_items_Backcolor = subGridlevel_items_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_items_Class, "") != 0 )
            {
               subGridlevel_items_Linesclass = subGridlevel_items_Class+"Uniform";
            }
         }
         else if ( subGridlevel_items_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_items_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_items_Class, "") != 0 )
            {
               subGridlevel_items_Linesclass = subGridlevel_items_Class+"Odd";
            }
            subGridlevel_items_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_items_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_items_Backstyle = 1;
            if ( ((int)((nGXsfl_168_idx) % (2))) == 0 )
            {
               subGridlevel_items_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_items_Class, "") != 0 )
               {
                  subGridlevel_items_Linesclass = subGridlevel_items_Class+"Even";
               }
            }
            else
            {
               subGridlevel_items_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_items_Class, "") != 0 )
               {
                  subGridlevel_items_Linesclass = subGridlevel_items_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 169,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesItemsID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A154HistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A154HistoricoSolicitudesItemsID), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,169);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesItemsID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHistoricoSolicitudesItemsID_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 170,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A330HItemsRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtHItemsRubrosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A330HItemsRubrosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A330HItemsRubrosId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,170);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHItemsRubrosId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 171,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsRubrosNombre_Internalname,StringUtil.RTrim( A331HItemsRubrosNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsRubrosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHItemsRubrosNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 172,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsMedidasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A327HItemsMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtHItemsMedidasID_Enabled!=0) ? context.localUtil.Format( (decimal)(A327HItemsMedidasID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A327HItemsMedidasID), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,172);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsMedidasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHItemsMedidasID_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 173,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsInventarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A328HItemsInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtHItemsInventarioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A328HItemsInventarioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A328HItemsInventarioId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,173);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsInventarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHItemsInventarioId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 174,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsInventarioNombre_Internalname,StringUtil.RTrim( A329HItemsInventarioNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsInventarioNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHItemsInventarioNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 175,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsInventarioPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A295HItemsInventarioPrecioFinal), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtHItemsInventarioPrecioFinal_Enabled!=0) ? context.localUtil.Format( (decimal)(A295HItemsInventarioPrecioFinal), "ZZZ9") : context.localUtil.Format( (decimal)(A295HItemsInventarioPrecioFinal), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,175);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsInventarioPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHItemsInventarioPrecioFinal_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 176,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsSolicitudesItemsCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A293HItemsSolicitudesItemsCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtHItemsSolicitudesItemsCantidad_Enabled!=0) ? context.localUtil.Format( (decimal)(A293HItemsSolicitudesItemsCantidad), "ZZZ9") : context.localUtil.Format( (decimal)(A293HItemsSolicitudesItemsCantidad), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,176);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsSolicitudesItemsCantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHItemsSolicitudesItemsCantidad_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 177,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesItemsSR_Internalname,StringUtil.RTrim( A296HistoricoSolicitudesItemsSR),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,177);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesItemsSR_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHistoricoSolicitudesItemsSR_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 178,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesItemsCT_Internalname,StringUtil.RTrim( A297HistoricoSolicitudesItemsCT),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,178);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesItemsCT_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHistoricoSolicitudesItemsCT_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 179,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesItemsComis_Internalname,StringUtil.LTrim( StringUtil.NToC( A298HistoricoSolicitudesItemsComis, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtHistoricoSolicitudesItemsComis_Enabled!=0) ? context.localUtil.Format( A298HistoricoSolicitudesItemsComis, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A298HistoricoSolicitudesItemsComis, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,179);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesItemsComis_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHistoricoSolicitudesItemsComis_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 180,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsSolicitudesItemsPrecioIn_Internalname,StringUtil.LTrim( StringUtil.NToC( A294HItemsSolicitudesItemsPrecioIn, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtHItemsSolicitudesItemsPrecioIn_Enabled!=0) ? context.localUtil.Format( A294HItemsSolicitudesItemsPrecioIn, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A294HItemsSolicitudesItemsPrecioIn, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,180);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsSolicitudesItemsPrecioIn_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHItemsSolicitudesItemsPrecioIn_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_43_" + sGXsfl_168_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 181,'',false,'" + sGXsfl_168_idx + "',168)\"";
         ROClassString = "Attribute";
         Gridlevel_itemsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsSolicitudesMonedaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A319HItemsSolicitudesMonedaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtHItemsSolicitudesMonedaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A319HItemsSolicitudesMonedaId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A319HItemsSolicitudesMonedaId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,181);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsSolicitudesMonedaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtHItemsSolicitudesMonedaId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)168,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_itemsRow);
         send_integrity_lvl_hashes1143( ) ;
         GXCCtl = "Z154HistoricoSolicitudesItemsID_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z154HistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z330HItemsRubrosId_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z330HItemsRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z331HItemsRubrosNombre_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z331HItemsRubrosNombre));
         GXCCtl = "Z327HItemsMedidasID_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z327HItemsMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z328HItemsInventarioId_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z328HItemsInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z329HItemsInventarioNombre_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z329HItemsInventarioNombre));
         GXCCtl = "Z295HItemsInventarioPrecioFinal_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z295HItemsInventarioPrecioFinal), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z293HItemsSolicitudesItemsCantidad_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z293HItemsSolicitudesItemsCantidad), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z296HistoricoSolicitudesItemsSR_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z296HistoricoSolicitudesItemsSR));
         GXCCtl = "Z297HistoricoSolicitudesItemsCT_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z297HistoricoSolicitudesItemsCT));
         GXCCtl = "Z298HistoricoSolicitudesItemsComis_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z298HistoricoSolicitudesItemsComis, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z319HItemsSolicitudesMonedaId_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z319HItemsSolicitudesMonedaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "O294HItemsSolicitudesItemsPrecioIn_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( O294HItemsSolicitudesItemsPrecioIn, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_43_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_43), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_43_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_43), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_43_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_43), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_168_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vHISTORICOSOLICITUDESID_" + sGXsfl_168_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESITEMSID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HITEMSRUBROSID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsRubrosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HITEMSRUBROSNOMBRE_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsRubrosNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HITEMSMEDIDASID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsMedidasID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HITEMSINVENTARIOID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsInventarioId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HITEMSINVENTARIONOMBRE_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsInventarioNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HITEMSINVENTARIOPRECIOFINAL_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsInventarioPrecioFinal_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HITEMSSOLICITUDESITEMSCANTIDAD_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsSolicitudesItemsCantidad_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESITEMSSR_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsSR_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESITEMSCT_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsCT_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESITEMSCOMIS_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsComis_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HITEMSSOLICITUDESITEMSPRECIOIN_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsSolicitudesItemsPrecioIn_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HITEMSSOLICITUDESMONEDAID_"+sGXsfl_168_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsSolicitudesMonedaId_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_itemsContainer.AddRow(Gridlevel_itemsRow);
      }

      protected void ReadRow1143( )
      {
         nGXsfl_168_idx = (int)(nGXsfl_168_idx+1);
         sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx), 4, 0), 4, "0");
         SubsflControlProps_16843( ) ;
         edtHistoricoSolicitudesItemsID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESITEMSID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHItemsRubrosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSRUBROSID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHItemsRubrosNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSRUBROSNOMBRE_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHItemsMedidasID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSMEDIDASID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHItemsInventarioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSINVENTARIOID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHItemsInventarioNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSINVENTARIONOMBRE_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHItemsInventarioPrecioFinal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSINVENTARIOPRECIOFINAL_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHItemsSolicitudesItemsCantidad_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSSOLICITUDESITEMSCANTIDAD_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHistoricoSolicitudesItemsSR_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESITEMSSR_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHistoricoSolicitudesItemsCT_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESITEMSCT_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHistoricoSolicitudesItemsComis_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HISTORICOSOLICITUDESITEMSCOMIS_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHItemsSolicitudesItemsPrecioIn_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSSOLICITUDESITEMSPRECIOIN_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtHItemsSolicitudesMonedaId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "HITEMSSOLICITUDESMONEDAID_"+sGXsfl_168_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesItemsID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesItemsID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "HISTORICOSOLICITUDESITEMSID_" + sGXsfl_168_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHistoricoSolicitudesItemsID_Internalname;
            wbErr = true;
            A154HistoricoSolicitudesItemsID = 0;
         }
         else
         {
            A154HistoricoSolicitudesItemsID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesItemsID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtHItemsRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHItemsRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "HITEMSRUBROSID_" + sGXsfl_168_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHItemsRubrosId_Internalname;
            wbErr = true;
            A330HItemsRubrosId = 0;
         }
         else
         {
            A330HItemsRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A331HItemsRubrosNombre = cgiGet( edtHItemsRubrosNombre_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtHItemsMedidasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHItemsMedidasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "HITEMSMEDIDASID_" + sGXsfl_168_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHItemsMedidasID_Internalname;
            wbErr = true;
            A327HItemsMedidasID = 0;
         }
         else
         {
            A327HItemsMedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsMedidasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtHItemsInventarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHItemsInventarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "HITEMSINVENTARIOID_" + sGXsfl_168_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHItemsInventarioId_Internalname;
            wbErr = true;
            A328HItemsInventarioId = 0;
         }
         else
         {
            A328HItemsInventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsInventarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A329HItemsInventarioNombre = cgiGet( edtHItemsInventarioNombre_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtHItemsInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHItemsInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "HITEMSINVENTARIOPRECIOFINAL_" + sGXsfl_168_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHItemsInventarioPrecioFinal_Internalname;
            wbErr = true;
            A295HItemsInventarioPrecioFinal = 0;
         }
         else
         {
            A295HItemsInventarioPrecioFinal = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtHItemsSolicitudesItemsCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHItemsSolicitudesItemsCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "HITEMSSOLICITUDESITEMSCANTIDAD_" + sGXsfl_168_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHItemsSolicitudesItemsCantidad_Internalname;
            wbErr = true;
            A293HItemsSolicitudesItemsCantidad = 0;
         }
         else
         {
            A293HItemsSolicitudesItemsCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsSolicitudesItemsCantidad_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A296HistoricoSolicitudesItemsSR = cgiGet( edtHistoricoSolicitudesItemsSR_Internalname);
         A297HistoricoSolicitudesItemsCT = cgiGet( edtHistoricoSolicitudesItemsCT_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesItemsComis_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesItemsComis_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
         {
            GXCCtl = "HISTORICOSOLICITUDESITEMSCOMIS_" + sGXsfl_168_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHistoricoSolicitudesItemsComis_Internalname;
            wbErr = true;
            A298HistoricoSolicitudesItemsComis = 0;
         }
         else
         {
            A298HistoricoSolicitudesItemsComis = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesItemsComis_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         }
         A294HItemsSolicitudesItemsPrecioIn = context.localUtil.CToN( cgiGet( edtHItemsSolicitudesItemsPrecioIn_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         if ( ( ( context.localUtil.CToN( cgiGet( edtHItemsSolicitudesMonedaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHItemsSolicitudesMonedaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "HITEMSSOLICITUDESMONEDAID_" + sGXsfl_168_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtHItemsSolicitudesMonedaId_Internalname;
            wbErr = true;
            A319HItemsSolicitudesMonedaId = 0;
         }
         else
         {
            A319HItemsSolicitudesMonedaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsSolicitudesMonedaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "Z154HistoricoSolicitudesItemsID_" + sGXsfl_168_idx;
         Z154HistoricoSolicitudesItemsID = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z330HItemsRubrosId_" + sGXsfl_168_idx;
         Z330HItemsRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z331HItemsRubrosNombre_" + sGXsfl_168_idx;
         Z331HItemsRubrosNombre = cgiGet( GXCCtl);
         GXCCtl = "Z327HItemsMedidasID_" + sGXsfl_168_idx;
         Z327HItemsMedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z328HItemsInventarioId_" + sGXsfl_168_idx;
         Z328HItemsInventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z329HItemsInventarioNombre_" + sGXsfl_168_idx;
         Z329HItemsInventarioNombre = cgiGet( GXCCtl);
         GXCCtl = "Z295HItemsInventarioPrecioFinal_" + sGXsfl_168_idx;
         Z295HItemsInventarioPrecioFinal = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z293HItemsSolicitudesItemsCantidad_" + sGXsfl_168_idx;
         Z293HItemsSolicitudesItemsCantidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z296HistoricoSolicitudesItemsSR_" + sGXsfl_168_idx;
         Z296HistoricoSolicitudesItemsSR = cgiGet( GXCCtl);
         GXCCtl = "Z297HistoricoSolicitudesItemsCT_" + sGXsfl_168_idx;
         Z297HistoricoSolicitudesItemsCT = cgiGet( GXCCtl);
         GXCCtl = "Z298HistoricoSolicitudesItemsComis_" + sGXsfl_168_idx;
         Z298HistoricoSolicitudesItemsComis = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z319HItemsSolicitudesMonedaId_" + sGXsfl_168_idx;
         Z319HItemsSolicitudesMonedaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "O294HItemsSolicitudesItemsPrecioIn_" + sGXsfl_168_idx;
         O294HItemsSolicitudesItemsPrecioIn = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "nRcdDeleted_43_" + sGXsfl_168_idx;
         nRcdDeleted_43 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_43_" + sGXsfl_168_idx;
         nRcdExists_43 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_43_" + sGXsfl_168_idx;
         nIsMod_43 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtHistoricoSolicitudesItemsID_Enabled = edtHistoricoSolicitudesItemsID_Enabled;
      }

      protected void ConfirmValues110( )
      {
         nGXsfl_168_idx = 0;
         sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx), 4, 0), 4, "0");
         SubsflControlProps_16843( ) ;
         while ( nGXsfl_168_idx < nRC_GXsfl_168 )
         {
            nGXsfl_168_idx = (int)(nGXsfl_168_idx+1);
            sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx), 4, 0), 4, "0");
            SubsflControlProps_16843( ) ;
            ChangePostValue( "Z154HistoricoSolicitudesItemsID_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z154HistoricoSolicitudesItemsID_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z154HistoricoSolicitudesItemsID_"+sGXsfl_168_idx) ;
            ChangePostValue( "Z330HItemsRubrosId_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z330HItemsRubrosId_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z330HItemsRubrosId_"+sGXsfl_168_idx) ;
            ChangePostValue( "Z331HItemsRubrosNombre_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z331HItemsRubrosNombre_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z331HItemsRubrosNombre_"+sGXsfl_168_idx) ;
            ChangePostValue( "Z327HItemsMedidasID_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z327HItemsMedidasID_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z327HItemsMedidasID_"+sGXsfl_168_idx) ;
            ChangePostValue( "Z328HItemsInventarioId_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z328HItemsInventarioId_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z328HItemsInventarioId_"+sGXsfl_168_idx) ;
            ChangePostValue( "Z329HItemsInventarioNombre_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z329HItemsInventarioNombre_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z329HItemsInventarioNombre_"+sGXsfl_168_idx) ;
            ChangePostValue( "Z295HItemsInventarioPrecioFinal_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z295HItemsInventarioPrecioFinal_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z295HItemsInventarioPrecioFinal_"+sGXsfl_168_idx) ;
            ChangePostValue( "Z293HItemsSolicitudesItemsCantidad_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z293HItemsSolicitudesItemsCantidad_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z293HItemsSolicitudesItemsCantidad_"+sGXsfl_168_idx) ;
            ChangePostValue( "Z296HistoricoSolicitudesItemsSR_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z296HistoricoSolicitudesItemsSR_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z296HistoricoSolicitudesItemsSR_"+sGXsfl_168_idx) ;
            ChangePostValue( "Z297HistoricoSolicitudesItemsCT_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z297HistoricoSolicitudesItemsCT_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z297HistoricoSolicitudesItemsCT_"+sGXsfl_168_idx) ;
            ChangePostValue( "Z298HistoricoSolicitudesItemsComis_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z298HistoricoSolicitudesItemsComis_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z298HistoricoSolicitudesItemsComis_"+sGXsfl_168_idx) ;
            ChangePostValue( "Z319HItemsSolicitudesMonedaId_"+sGXsfl_168_idx, cgiGet( "ZT_"+"Z319HItemsSolicitudesMonedaId_"+sGXsfl_168_idx)) ;
            DeletePostValue( "ZT_"+"Z319HItemsSolicitudesMonedaId_"+sGXsfl_168_idx) ;
         }
         ChangePostValue( "O294HItemsSolicitudesItemsPrecioIn", cgiGet( "T294HItemsSolicitudesItemsPrecioIn")) ;
         DeletePostValue( "T294HItemsSolicitudesItemsPrecioIn") ;
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
         GXEncryptionTmp = "historicosolicitudes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7HistoricoSolicitudesID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("historicosolicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"HistoricoSolicitudes");
         forbiddenHiddens.Add("Insert_EstadosSolTipo", StringUtil.RTrim( context.localUtil.Format( AV11Insert_EstadosSolTipo, "")));
         forbiddenHiddens.Add("Insert_EstadosSolId", context.localUtil.Format( (decimal)(AV12Insert_EstadosSolId), "ZZZZ9"));
         forbiddenHiddens.Add("Insert_MetodoPagosID", context.localUtil.Format( (decimal)(AV13Insert_MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("HistoricoSolicitudesComProv", context.localUtil.Format( A623HistoricoSolicitudesComProv, "ZZZZZZZZZZZZZZ9.99"));
         forbiddenHiddens.Add("HistoricoSolicitudesComProvP", context.localUtil.Format( A626HistoricoSolicitudesComProvP, "ZZ9.99"));
         forbiddenHiddens.Add("HistoricoSolicitudesComALM", context.localUtil.Format( A627HistoricoSolicitudesComALM, "ZZZZZZZZZZZZZZ9.99"));
         forbiddenHiddens.Add("HistoricoSolicitudesComALMP", context.localUtil.Format( A628HistoricoSolicitudesComALMP, "ZZ9.99"));
         forbiddenHiddens.Add("HistoricoSolicitudesNombreAux", StringUtil.RTrim( context.localUtil.Format( A624HistoricoSolicitudesNombreAux, "")));
         forbiddenHiddens.Add("HistoricoSolicitudesSubTipo", StringUtil.RTrim( context.localUtil.Format( A625HistoricoSolicitudesSubTipo, "")));
         forbiddenHiddens.Add("HistoricoSolicitudesProvID", context.localUtil.Format( (decimal)(A633HistoricoSolicitudesProvID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("HistoricoSolicitudesProvNombre", StringUtil.RTrim( context.localUtil.Format( A634HistoricoSolicitudesProvNombre, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("historicosolicitudes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z153HistoricoSolicitudesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z288HistoricoSolicitudesNombre", StringUtil.RTrim( Z288HistoricoSolicitudesNombre));
         GxWebStd.gx_hidden_field( context, "Z289HistoricoSolicitudesTelefono", StringUtil.RTrim( Z289HistoricoSolicitudesTelefono));
         GxWebStd.gx_hidden_field( context, "Z290HistoricoSolicitudesMail", Z290HistoricoSolicitudesMail);
         GxWebStd.gx_hidden_field( context, "Z315HistoricoPaisID", StringUtil.RTrim( Z315HistoricoPaisID));
         GxWebStd.gx_hidden_field( context, "Z316HistoricoDepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z316HistoricoDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z317HistoricoDepartamentoMunicipio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z317HistoricoDepartamentoMunicipio), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z318HistoricoZonasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z318HistoricoZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z291HistoricoSolicitudesDireccion", Z291HistoricoSolicitudesDireccion);
         GxWebStd.gx_hidden_field( context, "Z292HistoricoSolicitudesAutoEnumer", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z292HistoricoSolicitudesAutoEnumer), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z299HistoricoSolicitudesCotizacion", StringUtil.LTrim( StringUtil.NToC( Z299HistoricoSolicitudesCotizacion, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z301HistoricoSolicitudServicioSolC", StringUtil.RTrim( Z301HistoricoSolicitudServicioSolC));
         GxWebStd.gx_hidden_field( context, "Z303HistoricoSolicitudesOtros1", StringUtil.RTrim( Z303HistoricoSolicitudesOtros1));
         GxWebStd.gx_hidden_field( context, "Z304HistoricoSolicitudesOtros2", StringUtil.RTrim( Z304HistoricoSolicitudesOtros2));
         GxWebStd.gx_hidden_field( context, "Z305HistoricoSolicitudesOtros3", StringUtil.RTrim( Z305HistoricoSolicitudesOtros3));
         GxWebStd.gx_hidden_field( context, "Z306HistoricoSolicitudesFechaAlta", context.localUtil.DToC( Z306HistoricoSolicitudesFechaAlta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z307HistoricoSolicitudesFechaActua", context.localUtil.TToC( Z307HistoricoSolicitudesFechaActua, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z308HistoricoSolicitudesFechaInsta", context.localUtil.DToC( Z308HistoricoSolicitudesFechaInsta, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z309HistoricoSolicitudesHoraInstal", StringUtil.RTrim( Z309HistoricoSolicitudesHoraInstal));
         GxWebStd.gx_hidden_field( context, "Z311HistoricoSolicitudesNota", StringUtil.RTrim( Z311HistoricoSolicitudesNota));
         GxWebStd.gx_hidden_field( context, "Z312HistoricoSolicitudesNotificaci", StringUtil.RTrim( Z312HistoricoSolicitudesNotificaci));
         GxWebStd.gx_hidden_field( context, "Z439HistoricoSolicitudesOrigenPago", StringUtil.RTrim( Z439HistoricoSolicitudesOrigenPago));
         GxWebStd.gx_hidden_field( context, "Z442HistoricoSolicitudesPagado", StringUtil.RTrim( Z442HistoricoSolicitudesPagado));
         GxWebStd.gx_hidden_field( context, "Z623HistoricoSolicitudesComProv", StringUtil.LTrim( StringUtil.NToC( Z623HistoricoSolicitudesComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z626HistoricoSolicitudesComProvP", StringUtil.LTrim( StringUtil.NToC( Z626HistoricoSolicitudesComProvP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z627HistoricoSolicitudesComALM", StringUtil.LTrim( StringUtil.NToC( Z627HistoricoSolicitudesComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z628HistoricoSolicitudesComALMP", StringUtil.LTrim( StringUtil.NToC( Z628HistoricoSolicitudesComALMP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z624HistoricoSolicitudesNombreAux", StringUtil.RTrim( Z624HistoricoSolicitudesNombreAux));
         GxWebStd.gx_hidden_field( context, "Z625HistoricoSolicitudesSubTipo", StringUtil.RTrim( Z625HistoricoSolicitudesSubTipo));
         GxWebStd.gx_hidden_field( context, "Z633HistoricoSolicitudesProvID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z633HistoricoSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z634HistoricoSolicitudesProvNombre", StringUtil.RTrim( Z634HistoricoSolicitudesProvNombre));
         GxWebStd.gx_hidden_field( context, "Z128MetodoPagosID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z130EstadosSolTipo", StringUtil.RTrim( Z130EstadosSolTipo));
         GxWebStd.gx_hidden_field( context, "Z131EstadosSolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O300HistoricoSolicitudesTotal", StringUtil.LTrim( StringUtil.NToC( O300HistoricoSolicitudesTotal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_168", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_168_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N130EstadosSolTipo", StringUtil.RTrim( A130EstadosSolTipo));
         GxWebStd.gx_hidden_field( context, "N131EstadosSolId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N128MetodoPagosID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A128MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESCOMPROV", StringUtil.LTrim( StringUtil.NToC( A623HistoricoSolicitudesComProv, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESCOMALM", StringUtil.LTrim( StringUtil.NToC( A627HistoricoSolicitudesComALM, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESCOMPRO", StringUtil.LTrim( StringUtil.NToC( A629HistoricoSolicitudesComPro, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESCOMPROVP", StringUtil.LTrim( StringUtil.NToC( A626HistoricoSolicitudesComProvP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESCOMALMP", StringUtil.LTrim( StringUtil.NToC( A628HistoricoSolicitudesComALMP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESCOMPROP", StringUtil.LTrim( StringUtil.NToC( A630HistoricoSolicitudesComProP, 6, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vHISTORICOSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vHISTORICOSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESTADOSSOLTIPO", StringUtil.RTrim( AV11Insert_EstadosSolTipo));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESTADOSSOLID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_METODOPAGOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESNOMBREAUX", StringUtil.RTrim( A624HistoricoSolicitudesNombreAux));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESSUBTIPO", StringUtil.RTrim( A625HistoricoSolicitudesSubTipo));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESPROVID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A633HistoricoSolicitudesProvID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESPROVNOMBRE", StringUtil.RTrim( A634HistoricoSolicitudesProvNombre));
         GxWebStd.gx_hidden_field( context, "METODOPAGOSNOMBRE", StringUtil.RTrim( A129MetodoPagosNombre));
         GxWebStd.gx_hidden_field( context, "ESTADOSSOLNOMBRE", StringUtil.RTrim( A132EstadosSolNombre));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV31Pgmname));
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
         GXEncryptionTmp = "historicosolicitudes.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7HistoricoSolicitudesID,18,0));
         return formatLink("historicosolicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "HistoricoSolicitudes" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Historico Solicitudes", "") ;
      }

      protected void InitializeNonKey1142( )
      {
         A130EstadosSolTipo = "";
         AssignAttri("", false, "A130EstadosSolTipo", A130EstadosSolTipo);
         A131EstadosSolId = 0;
         AssignAttri("", false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
         A128MetodoPagosID = 0;
         AssignAttri("", false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
         A630HistoricoSolicitudesComProP = 0;
         AssignAttri("", false, "A630HistoricoSolicitudesComProP", StringUtil.LTrimStr( A630HistoricoSolicitudesComProP, 6, 2));
         A629HistoricoSolicitudesComPro = 0;
         AssignAttri("", false, "A629HistoricoSolicitudesComPro", StringUtil.LTrimStr( A629HistoricoSolicitudesComPro, 18, 2));
         A302HistoricoSolicitudServicioPFin = 0;
         AssignAttri("", false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
         A288HistoricoSolicitudesNombre = "";
         AssignAttri("", false, "A288HistoricoSolicitudesNombre", A288HistoricoSolicitudesNombre);
         A289HistoricoSolicitudesTelefono = "";
         AssignAttri("", false, "A289HistoricoSolicitudesTelefono", A289HistoricoSolicitudesTelefono);
         A290HistoricoSolicitudesMail = "";
         n290HistoricoSolicitudesMail = false;
         AssignAttri("", false, "A290HistoricoSolicitudesMail", A290HistoricoSolicitudesMail);
         n290HistoricoSolicitudesMail = (String.IsNullOrEmpty(StringUtil.RTrim( A290HistoricoSolicitudesMail)) ? true : false);
         A315HistoricoPaisID = "";
         AssignAttri("", false, "A315HistoricoPaisID", A315HistoricoPaisID);
         A316HistoricoDepartamentoId = 0;
         AssignAttri("", false, "A316HistoricoDepartamentoId", StringUtil.LTrimStr( (decimal)(A316HistoricoDepartamentoId), 18, 0));
         A317HistoricoDepartamentoMunicipio = 0;
         AssignAttri("", false, "A317HistoricoDepartamentoMunicipio", StringUtil.LTrimStr( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0));
         A318HistoricoZonasID = 0;
         n318HistoricoZonasID = false;
         AssignAttri("", false, "A318HistoricoZonasID", StringUtil.LTrimStr( (decimal)(A318HistoricoZonasID), 18, 0));
         n318HistoricoZonasID = ((0==A318HistoricoZonasID) ? true : false);
         A291HistoricoSolicitudesDireccion = "";
         AssignAttri("", false, "A291HistoricoSolicitudesDireccion", A291HistoricoSolicitudesDireccion);
         A292HistoricoSolicitudesAutoEnumer = 0;
         AssignAttri("", false, "A292HistoricoSolicitudesAutoEnumer", StringUtil.LTrimStr( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0));
         A299HistoricoSolicitudesCotizacion = 0;
         AssignAttri("", false, "A299HistoricoSolicitudesCotizacion", StringUtil.LTrimStr( A299HistoricoSolicitudesCotizacion, 18, 2));
         A300HistoricoSolicitudesTotal = 0;
         AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
         A301HistoricoSolicitudServicioSolC = "";
         AssignAttri("", false, "A301HistoricoSolicitudServicioSolC", A301HistoricoSolicitudServicioSolC);
         A132EstadosSolNombre = "";
         AssignAttri("", false, "A132EstadosSolNombre", A132EstadosSolNombre);
         A303HistoricoSolicitudesOtros1 = "";
         AssignAttri("", false, "A303HistoricoSolicitudesOtros1", A303HistoricoSolicitudesOtros1);
         A304HistoricoSolicitudesOtros2 = "";
         AssignAttri("", false, "A304HistoricoSolicitudesOtros2", A304HistoricoSolicitudesOtros2);
         A305HistoricoSolicitudesOtros3 = "";
         AssignAttri("", false, "A305HistoricoSolicitudesOtros3", A305HistoricoSolicitudesOtros3);
         A306HistoricoSolicitudesFechaAlta = DateTime.MinValue;
         AssignAttri("", false, "A306HistoricoSolicitudesFechaAlta", context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99"));
         A307HistoricoSolicitudesFechaActua = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A307HistoricoSolicitudesFechaActua", context.localUtil.TToC( A307HistoricoSolicitudesFechaActua, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A308HistoricoSolicitudesFechaInsta = DateTime.MinValue;
         AssignAttri("", false, "A308HistoricoSolicitudesFechaInsta", context.localUtil.Format(A308HistoricoSolicitudesFechaInsta, "99/99/99"));
         A309HistoricoSolicitudesHoraInstal = "";
         AssignAttri("", false, "A309HistoricoSolicitudesHoraInstal", A309HistoricoSolicitudesHoraInstal);
         A310HistoricoSolicitudesComentario = "";
         AssignAttri("", false, "A310HistoricoSolicitudesComentario", A310HistoricoSolicitudesComentario);
         A129MetodoPagosNombre = "";
         AssignAttri("", false, "A129MetodoPagosNombre", A129MetodoPagosNombre);
         A311HistoricoSolicitudesNota = "";
         AssignAttri("", false, "A311HistoricoSolicitudesNota", A311HistoricoSolicitudesNota);
         A312HistoricoSolicitudesNotificaci = "";
         AssignAttri("", false, "A312HistoricoSolicitudesNotificaci", A312HistoricoSolicitudesNotificaci);
         A439HistoricoSolicitudesOrigenPago = "";
         AssignAttri("", false, "A439HistoricoSolicitudesOrigenPago", A439HistoricoSolicitudesOrigenPago);
         A442HistoricoSolicitudesPagado = "";
         AssignAttri("", false, "A442HistoricoSolicitudesPagado", A442HistoricoSolicitudesPagado);
         A623HistoricoSolicitudesComProv = 0;
         AssignAttri("", false, "A623HistoricoSolicitudesComProv", StringUtil.LTrimStr( A623HistoricoSolicitudesComProv, 18, 2));
         A626HistoricoSolicitudesComProvP = 0;
         AssignAttri("", false, "A626HistoricoSolicitudesComProvP", StringUtil.LTrimStr( A626HistoricoSolicitudesComProvP, 6, 2));
         A627HistoricoSolicitudesComALM = 0;
         AssignAttri("", false, "A627HistoricoSolicitudesComALM", StringUtil.LTrimStr( A627HistoricoSolicitudesComALM, 18, 2));
         A628HistoricoSolicitudesComALMP = 0;
         AssignAttri("", false, "A628HistoricoSolicitudesComALMP", StringUtil.LTrimStr( A628HistoricoSolicitudesComALMP, 6, 2));
         A624HistoricoSolicitudesNombreAux = "";
         AssignAttri("", false, "A624HistoricoSolicitudesNombreAux", A624HistoricoSolicitudesNombreAux);
         A625HistoricoSolicitudesSubTipo = "";
         AssignAttri("", false, "A625HistoricoSolicitudesSubTipo", A625HistoricoSolicitudesSubTipo);
         A633HistoricoSolicitudesProvID = 0;
         AssignAttri("", false, "A633HistoricoSolicitudesProvID", StringUtil.LTrimStr( (decimal)(A633HistoricoSolicitudesProvID), 18, 0));
         A634HistoricoSolicitudesProvNombre = "";
         AssignAttri("", false, "A634HistoricoSolicitudesProvNombre", A634HistoricoSolicitudesProvNombre);
         O300HistoricoSolicitudesTotal = A300HistoricoSolicitudesTotal;
         AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
         Z288HistoricoSolicitudesNombre = "";
         Z289HistoricoSolicitudesTelefono = "";
         Z290HistoricoSolicitudesMail = "";
         Z315HistoricoPaisID = "";
         Z316HistoricoDepartamentoId = 0;
         Z317HistoricoDepartamentoMunicipio = 0;
         Z318HistoricoZonasID = 0;
         Z291HistoricoSolicitudesDireccion = "";
         Z292HistoricoSolicitudesAutoEnumer = 0;
         Z299HistoricoSolicitudesCotizacion = 0;
         Z301HistoricoSolicitudServicioSolC = "";
         Z303HistoricoSolicitudesOtros1 = "";
         Z304HistoricoSolicitudesOtros2 = "";
         Z305HistoricoSolicitudesOtros3 = "";
         Z306HistoricoSolicitudesFechaAlta = DateTime.MinValue;
         Z307HistoricoSolicitudesFechaActua = (DateTime)(DateTime.MinValue);
         Z308HistoricoSolicitudesFechaInsta = DateTime.MinValue;
         Z309HistoricoSolicitudesHoraInstal = "";
         Z311HistoricoSolicitudesNota = "";
         Z312HistoricoSolicitudesNotificaci = "";
         Z439HistoricoSolicitudesOrigenPago = "";
         Z442HistoricoSolicitudesPagado = "";
         Z623HistoricoSolicitudesComProv = 0;
         Z626HistoricoSolicitudesComProvP = 0;
         Z627HistoricoSolicitudesComALM = 0;
         Z628HistoricoSolicitudesComALMP = 0;
         Z624HistoricoSolicitudesNombreAux = "";
         Z625HistoricoSolicitudesSubTipo = "";
         Z633HistoricoSolicitudesProvID = 0;
         Z634HistoricoSolicitudesProvNombre = "";
         Z128MetodoPagosID = 0;
         Z130EstadosSolTipo = "";
         Z131EstadosSolId = 0;
      }

      protected void InitAll1142( )
      {
         A153HistoricoSolicitudesID = 0;
         AssignAttri("", false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
         InitializeNonKey1142( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1143( )
      {
         A294HItemsSolicitudesItemsPrecioIn = 0;
         A330HItemsRubrosId = 0;
         A331HItemsRubrosNombre = "";
         A327HItemsMedidasID = 0;
         A328HItemsInventarioId = 0;
         A329HItemsInventarioNombre = "";
         A295HItemsInventarioPrecioFinal = 0;
         A293HItemsSolicitudesItemsCantidad = 0;
         A296HistoricoSolicitudesItemsSR = "";
         A297HistoricoSolicitudesItemsCT = "";
         A298HistoricoSolicitudesItemsComis = 0;
         A319HItemsSolicitudesMonedaId = 0;
         O294HItemsSolicitudesItemsPrecioIn = A294HItemsSolicitudesItemsPrecioIn;
         Z330HItemsRubrosId = 0;
         Z331HItemsRubrosNombre = "";
         Z327HItemsMedidasID = 0;
         Z328HItemsInventarioId = 0;
         Z329HItemsInventarioNombre = "";
         Z295HItemsInventarioPrecioFinal = 0;
         Z293HItemsSolicitudesItemsCantidad = 0;
         Z296HistoricoSolicitudesItemsSR = "";
         Z297HistoricoSolicitudesItemsCT = "";
         Z298HistoricoSolicitudesItemsComis = 0;
         Z319HItemsSolicitudesMonedaId = 0;
      }

      protected void InitAll1143( )
      {
         A154HistoricoSolicitudesItemsID = 0;
         InitializeNonKey1143( ) ;
      }

      protected void StandaloneModalInsert1143( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20268622385881", true, true, false);
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
         context.AddJavascriptSource("historicosolicitudes.js", "?20268622385881", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties43( )
      {
         edtHistoricoSolicitudesItemsID_Enabled = defedtHistoricoSolicitudesItemsID_Enabled;
         AssignProp("", false, edtHistoricoSolicitudesItemsID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesItemsID_Enabled), 5, 0), !bGXsfl_168_Refreshing);
      }

      protected void StartGridControl168( )
      {
         Gridlevel_itemsContainer.AddObjectProperty("GridName", "Gridlevel_items");
         Gridlevel_itemsContainer.AddObjectProperty("Header", subGridlevel_items_Header);
         Gridlevel_itemsContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_itemsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_itemsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_itemsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_items_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_itemsContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_itemsContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A154HistoricoSolicitudesItemsID), 4, 0, ".", ""))));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsID_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A330HItemsRubrosId), 18, 0, ".", ""))));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsRubrosId_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A331HItemsRubrosNombre)));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsRubrosNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A327HItemsMedidasID), 18, 0, ".", ""))));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsMedidasID_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A328HItemsInventarioId), 18, 0, ".", ""))));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsInventarioId_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A329HItemsInventarioNombre)));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsInventarioNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A295HItemsInventarioPrecioFinal), 4, 0, ".", ""))));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsInventarioPrecioFinal_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A293HItemsSolicitudesItemsCantidad), 4, 0, ".", ""))));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsSolicitudesItemsCantidad_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A296HistoricoSolicitudesItemsSR)));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsSR_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A297HistoricoSolicitudesItemsCT)));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsCT_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A298HistoricoSolicitudesItemsComis, 18, 2, ".", ""))));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHistoricoSolicitudesItemsComis_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A294HItemsSolicitudesItemsPrecioIn, 21, 2, ".", ""))));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsSolicitudesItemsPrecioIn_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A319HItemsSolicitudesMonedaId), 18, 0, ".", ""))));
         Gridlevel_itemsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtHItemsSolicitudesMonedaId_Enabled), 5, 0, ".", "")));
         Gridlevel_itemsContainer.AddColumnProperties(Gridlevel_itemsColumn);
         Gridlevel_itemsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_items_Selectedindex), 4, 0, ".", "")));
         Gridlevel_itemsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_items_Allowselection), 1, 0, ".", "")));
         Gridlevel_itemsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_items_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_itemsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_items_Allowhovering), 1, 0, ".", "")));
         Gridlevel_itemsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_items_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_itemsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_items_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_itemsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_items_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtHistoricoSolicitudesID_Internalname = "HISTORICOSOLICITUDESID";
         edtHistoricoSolicitudesNombre_Internalname = "HISTORICOSOLICITUDESNOMBRE";
         edtHistoricoSolicitudesTelefono_Internalname = "HISTORICOSOLICITUDESTELEFONO";
         edtHistoricoSolicitudesMail_Internalname = "HISTORICOSOLICITUDESMAIL";
         edtHistoricoPaisID_Internalname = "HISTORICOPAISID";
         edtHistoricoDepartamentoId_Internalname = "HISTORICODEPARTAMENTOID";
         edtHistoricoDepartamentoMunicipio_Internalname = "HISTORICODEPARTAMENTOMUNICIPIO";
         edtHistoricoZonasID_Internalname = "HISTORICOZONASID";
         edtHistoricoSolicitudesDireccion_Internalname = "HISTORICOSOLICITUDESDIRECCION";
         edtHistoricoSolicitudesAutoEnumer_Internalname = "HISTORICOSOLICITUDESAUTOENUMER";
         edtHistoricoSolicitudesCotizacion_Internalname = "HISTORICOSOLICITUDESCOTIZACION";
         edtHistoricoSolicitudesTotal_Internalname = "HISTORICOSOLICITUDESTOTAL";
         edtHistoricoSolicitudServicioSolC_Internalname = "HISTORICOSOLICITUDSERVICIOSOLC";
         edtHistoricoSolicitudServicioPFin_Internalname = "HISTORICOSOLICITUDSERVICIOPFIN";
         edtEstadosSolTipo_Internalname = "ESTADOSSOLTIPO";
         edtEstadosSolId_Internalname = "ESTADOSSOLID";
         edtHistoricoSolicitudesOtros1_Internalname = "HISTORICOSOLICITUDESOTROS1";
         edtHistoricoSolicitudesOtros2_Internalname = "HISTORICOSOLICITUDESOTROS2";
         edtHistoricoSolicitudesOtros3_Internalname = "HISTORICOSOLICITUDESOTROS3";
         edtHistoricoSolicitudesFechaAlta_Internalname = "HISTORICOSOLICITUDESFECHAALTA";
         edtHistoricoSolicitudesFechaActua_Internalname = "HISTORICOSOLICITUDESFECHAACTUA";
         edtHistoricoSolicitudesFechaInsta_Internalname = "HISTORICOSOLICITUDESFECHAINSTA";
         edtHistoricoSolicitudesHoraInstal_Internalname = "HISTORICOSOLICITUDESHORAINSTAL";
         edtHistoricoSolicitudesComentario_Internalname = "HISTORICOSOLICITUDESCOMENTARIO";
         edtMetodoPagosID_Internalname = "METODOPAGOSID";
         edtHistoricoSolicitudesNota_Internalname = "HISTORICOSOLICITUDESNOTA";
         edtHistoricoSolicitudesNotificaci_Internalname = "HISTORICOSOLICITUDESNOTIFICACI";
         edtHistoricoSolicitudesOrigenPago_Internalname = "HISTORICOSOLICITUDESORIGENPAGO";
         cmbHistoricoSolicitudesPagado_Internalname = "HISTORICOSOLICITUDESPAGADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtHistoricoSolicitudesItemsID_Internalname = "HISTORICOSOLICITUDESITEMSID";
         edtHItemsRubrosId_Internalname = "HITEMSRUBROSID";
         edtHItemsRubrosNombre_Internalname = "HITEMSRUBROSNOMBRE";
         edtHItemsMedidasID_Internalname = "HITEMSMEDIDASID";
         edtHItemsInventarioId_Internalname = "HITEMSINVENTARIOID";
         edtHItemsInventarioNombre_Internalname = "HITEMSINVENTARIONOMBRE";
         edtHItemsInventarioPrecioFinal_Internalname = "HITEMSINVENTARIOPRECIOFINAL";
         edtHItemsSolicitudesItemsCantidad_Internalname = "HITEMSSOLICITUDESITEMSCANTIDAD";
         edtHistoricoSolicitudesItemsSR_Internalname = "HISTORICOSOLICITUDESITEMSSR";
         edtHistoricoSolicitudesItemsCT_Internalname = "HISTORICOSOLICITUDESITEMSCT";
         edtHistoricoSolicitudesItemsComis_Internalname = "HISTORICOSOLICITUDESITEMSCOMIS";
         edtHItemsSolicitudesItemsPrecioIn_Internalname = "HITEMSSOLICITUDESITEMSPRECIOIN";
         edtHItemsSolicitudesMonedaId_Internalname = "HITEMSSOLICITUDESMONEDAID";
         divTableleaflevel_items_Internalname = "TABLELEAFLEVEL_ITEMS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_130_131_Internalname = "PROMPT_130_131";
         imgprompt_128_Internalname = "PROMPT_128";
         subGridlevel_items_Internalname = "GRIDLEVEL_ITEMS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_items_Allowcollapsing = 0;
         subGridlevel_items_Allowselection = 0;
         subGridlevel_items_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Historico Solicitudes", "");
         edtHItemsSolicitudesMonedaId_Jsonclick = "";
         edtHItemsSolicitudesItemsPrecioIn_Jsonclick = "";
         edtHistoricoSolicitudesItemsComis_Jsonclick = "";
         edtHistoricoSolicitudesItemsCT_Jsonclick = "";
         edtHistoricoSolicitudesItemsSR_Jsonclick = "";
         edtHItemsSolicitudesItemsCantidad_Jsonclick = "";
         edtHItemsInventarioPrecioFinal_Jsonclick = "";
         edtHItemsInventarioNombre_Jsonclick = "";
         edtHItemsInventarioId_Jsonclick = "";
         edtHItemsMedidasID_Jsonclick = "";
         edtHItemsRubrosNombre_Jsonclick = "";
         edtHItemsRubrosId_Jsonclick = "";
         edtHistoricoSolicitudesItemsID_Jsonclick = "";
         subGridlevel_items_Class = "WorkWith";
         subGridlevel_items_Backcolorstyle = 0;
         edtHItemsSolicitudesMonedaId_Enabled = 1;
         edtHItemsSolicitudesItemsPrecioIn_Enabled = 0;
         edtHistoricoSolicitudesItemsComis_Enabled = 1;
         edtHistoricoSolicitudesItemsCT_Enabled = 1;
         edtHistoricoSolicitudesItemsSR_Enabled = 1;
         edtHItemsSolicitudesItemsCantidad_Enabled = 1;
         edtHItemsInventarioPrecioFinal_Enabled = 1;
         edtHItemsInventarioNombre_Enabled = 1;
         edtHItemsInventarioId_Enabled = 1;
         edtHItemsMedidasID_Enabled = 1;
         edtHItemsRubrosNombre_Enabled = 1;
         edtHItemsRubrosId_Enabled = 1;
         edtHistoricoSolicitudesItemsID_Enabled = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbHistoricoSolicitudesPagado_Jsonclick = "";
         cmbHistoricoSolicitudesPagado.Enabled = 1;
         edtHistoricoSolicitudesOrigenPago_Jsonclick = "";
         edtHistoricoSolicitudesOrigenPago_Enabled = 1;
         edtHistoricoSolicitudesNotificaci_Jsonclick = "";
         edtHistoricoSolicitudesNotificaci_Enabled = 1;
         edtHistoricoSolicitudesNota_Enabled = 1;
         imgprompt_128_Visible = 1;
         imgprompt_128_Link = "";
         edtMetodoPagosID_Jsonclick = "";
         edtMetodoPagosID_Enabled = 1;
         edtHistoricoSolicitudesComentario_Enabled = 1;
         edtHistoricoSolicitudesHoraInstal_Jsonclick = "";
         edtHistoricoSolicitudesHoraInstal_Enabled = 1;
         edtHistoricoSolicitudesFechaInsta_Jsonclick = "";
         edtHistoricoSolicitudesFechaInsta_Enabled = 1;
         edtHistoricoSolicitudesFechaActua_Jsonclick = "";
         edtHistoricoSolicitudesFechaActua_Enabled = 1;
         edtHistoricoSolicitudesFechaAlta_Jsonclick = "";
         edtHistoricoSolicitudesFechaAlta_Enabled = 1;
         edtHistoricoSolicitudesOtros3_Enabled = 1;
         edtHistoricoSolicitudesOtros2_Enabled = 1;
         edtHistoricoSolicitudesOtros1_Jsonclick = "";
         edtHistoricoSolicitudesOtros1_Enabled = 1;
         imgprompt_130_131_Visible = 1;
         imgprompt_130_131_Link = "";
         edtEstadosSolId_Jsonclick = "";
         edtEstadosSolId_Enabled = 1;
         edtEstadosSolTipo_Jsonclick = "";
         edtEstadosSolTipo_Enabled = 1;
         edtHistoricoSolicitudServicioPFin_Jsonclick = "";
         edtHistoricoSolicitudServicioPFin_Enabled = 0;
         edtHistoricoSolicitudServicioSolC_Jsonclick = "";
         edtHistoricoSolicitudServicioSolC_Enabled = 1;
         edtHistoricoSolicitudesTotal_Jsonclick = "";
         edtHistoricoSolicitudesTotal_Enabled = 0;
         edtHistoricoSolicitudesCotizacion_Jsonclick = "";
         edtHistoricoSolicitudesCotizacion_Enabled = 1;
         edtHistoricoSolicitudesAutoEnumer_Jsonclick = "";
         edtHistoricoSolicitudesAutoEnumer_Enabled = 1;
         edtHistoricoSolicitudesDireccion_Enabled = 1;
         edtHistoricoZonasID_Jsonclick = "";
         edtHistoricoZonasID_Enabled = 1;
         edtHistoricoDepartamentoMunicipio_Jsonclick = "";
         edtHistoricoDepartamentoMunicipio_Enabled = 1;
         edtHistoricoDepartamentoId_Jsonclick = "";
         edtHistoricoDepartamentoId_Enabled = 1;
         edtHistoricoPaisID_Jsonclick = "";
         edtHistoricoPaisID_Enabled = 1;
         edtHistoricoSolicitudesMail_Jsonclick = "";
         edtHistoricoSolicitudesMail_Enabled = 1;
         edtHistoricoSolicitudesTelefono_Jsonclick = "";
         edtHistoricoSolicitudesTelefono_Enabled = 1;
         edtHistoricoSolicitudesNombre_Jsonclick = "";
         edtHistoricoSolicitudesNombre_Enabled = 1;
         edtHistoricoSolicitudesID_Jsonclick = "";
         edtHistoricoSolicitudesID_Enabled = 1;
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

      protected void gxnrGridlevel_items_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_16843( ) ;
         while ( nGXsfl_168_idx <= nRC_GXsfl_168 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1143( ) ;
            standaloneModal1143( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1143( ) ;
            nGXsfl_168_idx = (int)(nGXsfl_168_idx+1);
            sGXsfl_168_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_168_idx), 4, 0), 4, "0");
            SubsflControlProps_16843( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_itemsContainer)) ;
         /* End function gxnrGridlevel_items_newrow */
      }

      protected void init_web_controls( )
      {
         cmbHistoricoSolicitudesPagado.Name = "HISTORICOSOLICITUDESPAGADO";
         cmbHistoricoSolicitudesPagado.WebTags = "";
         cmbHistoricoSolicitudesPagado.addItem("S", context.GetMessage( "Pagado", ""), 0);
         cmbHistoricoSolicitudesPagado.addItem("N", context.GetMessage( "Pendiente de Pago", ""), 0);
         if ( cmbHistoricoSolicitudesPagado.ItemCount > 0 )
         {
            A442HistoricoSolicitudesPagado = cmbHistoricoSolicitudesPagado.getValidValue(A442HistoricoSolicitudesPagado);
            AssignAttri("", false, "A442HistoricoSolicitudesPagado", A442HistoricoSolicitudesPagado);
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

      protected void GetHistoricoSolicitudesTotal( long A153HistoricoSolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A300HistoricoSolicitudesTotal = 0;
         /* Using cursor T001127 */
         pr_default.execute(25, new Object[] {A153HistoricoSolicitudesID});
         while ( (pr_default.getStatus(25) != 101) && ( T001127_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( T001127_A296HistoricoSolicitudesItemsSR[0])) || ( StringUtil.StrCmp(T001127_A297HistoricoSolicitudesItemsCT[0], "N") == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(T001127_A295HItemsInventarioPrecioFinal[0]*T001127_A293HItemsSolicitudesItemsCantidad[0]);
            }
            else
            {
               if ( ( StringUtil.StrCmp(T001127_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(T001127_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((T001127_A295HItemsInventarioPrecioFinal[0]*T001127_A293HItemsSolicitudesItemsCantidad[0])-(T001127_A298HistoricoSolicitudesItemsComis[0]*T001127_A293HItemsSolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(T001127_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(T001127_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((T001127_A295HItemsInventarioPrecioFinal[0]*T001127_A293HItemsSolicitudesItemsCantidad[0])+(T001127_A298HistoricoSolicitudesItemsComis[0]*T001127_A293HItemsSolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(T001127_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(T001127_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((T001127_A295HItemsInventarioPrecioFinal[0]*T001127_A293HItemsSolicitudesItemsCantidad[0])-((T001127_A295HItemsInventarioPrecioFinal[0]*T001127_A293HItemsSolicitudesItemsCantidad[0])*(T001127_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(T001127_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(T001127_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((T001127_A295HItemsInventarioPrecioFinal[0]*T001127_A293HItemsSolicitudesItemsCantidad[0])+((T001127_A295HItemsInventarioPrecioFinal[0]*T001127_A293HItemsSolicitudesItemsCantidad[0])*(T001127_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A294HItemsSolicitudesItemsPrecioIn = 0;
                        }
                     }
                  }
               }
            }
            A300HistoricoSolicitudesTotal = (decimal)(A300HistoricoSolicitudesTotal+A294HItemsSolicitudesItemsPrecioIn);
            AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
            pr_default.readNext(25);
         }
         pr_default.close(25);
      }

      public void Valid_Historicosolicitudesid( )
      {
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A300HistoricoSolicitudesTotal", StringUtil.LTrim( StringUtil.NToC( A300HistoricoSolicitudesTotal, 18, 2, ".", "")));
      }

      public void Valid_Estadossolid( )
      {
         /* Using cursor T001117 */
         pr_default.execute(15, new Object[] {A130EstadosSolTipo, A131EstadosSolId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Solicitudes", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSSOLID");
            AnyError = 1;
            GX_FocusControl = edtEstadosSolTipo_Internalname;
         }
         A132EstadosSolNombre = T001117_A132EstadosSolNombre[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A132EstadosSolNombre", StringUtil.RTrim( A132EstadosSolNombre));
      }

      public void Valid_Metodopagosid( )
      {
         /* Using cursor T001118 */
         pr_default.execute(16, new Object[] {A128MetodoPagosID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Metodo Pagos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "METODOPAGOSID");
            AnyError = 1;
            GX_FocusControl = edtMetodoPagosID_Internalname;
         }
         A129MetodoPagosNombre = T001118_A129MetodoPagosNombre[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A129MetodoPagosNombre", StringUtil.RTrim( A129MetodoPagosNombre));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7HistoricoSolicitudesID',fld:'vHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV11Insert_EstadosSolTipo',fld:'vINSERT_ESTADOSSOLTIPO',pic:'',type:'char'},{av:'AV12Insert_EstadosSolId',fld:'vINSERT_ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'AV13Insert_MetodoPagosID',fld:'vINSERT_METODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A623HistoricoSolicitudesComProv',fld:'HISTORICOSOLICITUDESCOMPROV',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A626HistoricoSolicitudesComProvP',fld:'HISTORICOSOLICITUDESCOMPROVP',pic:'ZZ9.99',type:'decimal'},{av:'A627HistoricoSolicitudesComALM',fld:'HISTORICOSOLICITUDESCOMALM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A628HistoricoSolicitudesComALMP',fld:'HISTORICOSOLICITUDESCOMALMP',pic:'ZZ9.99',type:'decimal'},{av:'A624HistoricoSolicitudesNombreAux',fld:'HISTORICOSOLICITUDESNOMBREAUX',pic:'',type:'char'},{av:'A625HistoricoSolicitudesSubTipo',fld:'HISTORICOSOLICITUDESSUBTIPO',pic:'',type:'char'},{av:'A633HistoricoSolicitudesProvID',fld:'HISTORICOSOLICITUDESPROVID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A634HistoricoSolicitudesProvNombre',fld:'HISTORICOSOLICITUDESPROVNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12112',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESID","{handler:'Valid_Historicosolicitudesid',iparms:[{av:'A153HistoricoSolicitudesID',fld:'HISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A300HistoricoSolicitudesTotal',fld:'HISTORICOSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESID",",oparms:[{av:'A300HistoricoSolicitudesTotal',fld:'HISTORICOSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESMAIL","{handler:'Valid_Historicosolicitudesmail',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESMAIL",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESCOTIZACION","{handler:'Valid_Historicosolicitudescotizacion',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESCOTIZACION",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESTOTAL","{handler:'Valid_Historicosolicitudestotal',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESTOTAL",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDSERVICIOPFIN","{handler:'Valid_Historicosolicitudserviciopfin',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDSERVICIOPFIN",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSSOLTIPO","{handler:'Valid_Estadossoltipo',iparms:[]");
         setEventMetadata("VALID_ESTADOSSOLTIPO",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSSOLID","{handler:'Valid_Estadossolid',iparms:[{av:'A130EstadosSolTipo',fld:'ESTADOSSOLTIPO',pic:'',type:'char'},{av:'A131EstadosSolId',fld:'ESTADOSSOLID',pic:'ZZZZ9',type:'int'},{av:'A132EstadosSolNombre',fld:'ESTADOSSOLNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_ESTADOSSOLID",",oparms:[{av:'A132EstadosSolNombre',fld:'ESTADOSSOLNOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESFECHAALTA","{handler:'Valid_Historicosolicitudesfechaalta',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESFECHAALTA",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESFECHAACTUA","{handler:'Valid_Historicosolicitudesfechaactua',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESFECHAACTUA",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESFECHAINSTA","{handler:'Valid_Historicosolicitudesfechainsta',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESFECHAINSTA",",oparms:[]}");
         setEventMetadata("VALID_METODOPAGOSID","{handler:'Valid_Metodopagosid',iparms:[{av:'A128MetodoPagosID',fld:'METODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A129MetodoPagosNombre',fld:'METODOPAGOSNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_METODOPAGOSID",",oparms:[{av:'A129MetodoPagosNombre',fld:'METODOPAGOSNOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSID","{handler:'Valid_Historicosolicitudesitemsid',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSID",",oparms:[]}");
         setEventMetadata("VALID_HITEMSINVENTARIOPRECIOFINAL","{handler:'Valid_Hitemsinventariopreciofinal',iparms:[]");
         setEventMetadata("VALID_HITEMSINVENTARIOPRECIOFINAL",",oparms:[]}");
         setEventMetadata("VALID_HITEMSSOLICITUDESITEMSCANTIDAD","{handler:'Valid_Hitemssolicitudesitemscantidad',iparms:[]");
         setEventMetadata("VALID_HITEMSSOLICITUDESITEMSCANTIDAD",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSSR","{handler:'Valid_Historicosolicitudesitemssr',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSSR",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSCT","{handler:'Valid_Historicosolicitudesitemsct',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSCT",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSCOMIS","{handler:'Valid_Historicosolicitudesitemscomis',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESITEMSCOMIS",",oparms:[]}");
         setEventMetadata("VALID_HITEMSSOLICITUDESITEMSPRECIOIN","{handler:'Valid_Hitemssolicitudesitemsprecioin',iparms:[]");
         setEventMetadata("VALID_HITEMSSOLICITUDESITEMSPRECIOIN",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Hitemssolicitudesmonedaid',iparms:[]");
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
         pr_default.close(16);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z288HistoricoSolicitudesNombre = "";
         Z289HistoricoSolicitudesTelefono = "";
         Z290HistoricoSolicitudesMail = "";
         Z315HistoricoPaisID = "";
         Z291HistoricoSolicitudesDireccion = "";
         Z301HistoricoSolicitudServicioSolC = "";
         Z303HistoricoSolicitudesOtros1 = "";
         Z304HistoricoSolicitudesOtros2 = "";
         Z305HistoricoSolicitudesOtros3 = "";
         Z306HistoricoSolicitudesFechaAlta = DateTime.MinValue;
         Z307HistoricoSolicitudesFechaActua = (DateTime)(DateTime.MinValue);
         Z308HistoricoSolicitudesFechaInsta = DateTime.MinValue;
         Z309HistoricoSolicitudesHoraInstal = "";
         Z311HistoricoSolicitudesNota = "";
         Z312HistoricoSolicitudesNotificaci = "";
         Z439HistoricoSolicitudesOrigenPago = "";
         Z442HistoricoSolicitudesPagado = "";
         Z624HistoricoSolicitudesNombreAux = "";
         Z625HistoricoSolicitudesSubTipo = "";
         Z634HistoricoSolicitudesProvNombre = "";
         Z130EstadosSolTipo = "";
         N130EstadosSolTipo = "";
         Z331HItemsRubrosNombre = "";
         Z329HItemsInventarioNombre = "";
         Z296HistoricoSolicitudesItemsSR = "";
         Z297HistoricoSolicitudesItemsCT = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A130EstadosSolTipo = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A442HistoricoSolicitudesPagado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A288HistoricoSolicitudesNombre = "";
         gxphoneLink = "";
         A289HistoricoSolicitudesTelefono = "";
         A290HistoricoSolicitudesMail = "";
         A315HistoricoPaisID = "";
         A291HistoricoSolicitudesDireccion = "";
         A301HistoricoSolicitudServicioSolC = "";
         imgprompt_130_131_gximage = "";
         sImgUrl = "";
         A303HistoricoSolicitudesOtros1 = "";
         A304HistoricoSolicitudesOtros2 = "";
         A305HistoricoSolicitudesOtros3 = "";
         A306HistoricoSolicitudesFechaAlta = DateTime.MinValue;
         A307HistoricoSolicitudesFechaActua = (DateTime)(DateTime.MinValue);
         A308HistoricoSolicitudesFechaInsta = DateTime.MinValue;
         A309HistoricoSolicitudesHoraInstal = "";
         A310HistoricoSolicitudesComentario = "";
         imgprompt_128_gximage = "";
         A311HistoricoSolicitudesNota = "";
         A312HistoricoSolicitudesNotificaci = "";
         A439HistoricoSolicitudesOrigenPago = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_itemsContainer = new GXWebGrid( context);
         sMode43 = "";
         sStyleString = "";
         A624HistoricoSolicitudesNombreAux = "";
         A625HistoricoSolicitudesSubTipo = "";
         A634HistoricoSolicitudesProvNombre = "";
         AV11Insert_EstadosSolTipo = "";
         A129MetodoPagosNombre = "";
         A132EstadosSolNombre = "";
         AV31Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode42 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A331HItemsRubrosNombre = "";
         A329HItemsInventarioNombre = "";
         A296HistoricoSolicitudesItemsSR = "";
         A297HistoricoSolicitudesItemsCT = "";
         AV15WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z310HistoricoSolicitudesComentario = "";
         Z132EstadosSolNombre = "";
         Z129MetodoPagosNombre = "";
         T00116_A129MetodoPagosNombre = new string[] {""} ;
         T00117_A132EstadosSolNombre = new string[] {""} ;
         T00118_A153HistoricoSolicitudesID = new long[1] ;
         T00118_A288HistoricoSolicitudesNombre = new string[] {""} ;
         T00118_A289HistoricoSolicitudesTelefono = new string[] {""} ;
         T00118_A290HistoricoSolicitudesMail = new string[] {""} ;
         T00118_n290HistoricoSolicitudesMail = new bool[] {false} ;
         T00118_A315HistoricoPaisID = new string[] {""} ;
         T00118_A316HistoricoDepartamentoId = new long[1] ;
         T00118_A317HistoricoDepartamentoMunicipio = new long[1] ;
         T00118_A318HistoricoZonasID = new long[1] ;
         T00118_n318HistoricoZonasID = new bool[] {false} ;
         T00118_A291HistoricoSolicitudesDireccion = new string[] {""} ;
         T00118_A292HistoricoSolicitudesAutoEnumer = new short[1] ;
         T00118_A299HistoricoSolicitudesCotizacion = new decimal[1] ;
         T00118_A301HistoricoSolicitudServicioSolC = new string[] {""} ;
         T00118_A132EstadosSolNombre = new string[] {""} ;
         T00118_A303HistoricoSolicitudesOtros1 = new string[] {""} ;
         T00118_A304HistoricoSolicitudesOtros2 = new string[] {""} ;
         T00118_A305HistoricoSolicitudesOtros3 = new string[] {""} ;
         T00118_A306HistoricoSolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00118_A307HistoricoSolicitudesFechaActua = new DateTime[] {DateTime.MinValue} ;
         T00118_A308HistoricoSolicitudesFechaInsta = new DateTime[] {DateTime.MinValue} ;
         T00118_A309HistoricoSolicitudesHoraInstal = new string[] {""} ;
         T00118_A310HistoricoSolicitudesComentario = new string[] {""} ;
         T00118_A129MetodoPagosNombre = new string[] {""} ;
         T00118_A311HistoricoSolicitudesNota = new string[] {""} ;
         T00118_A312HistoricoSolicitudesNotificaci = new string[] {""} ;
         T00118_A439HistoricoSolicitudesOrigenPago = new string[] {""} ;
         T00118_A442HistoricoSolicitudesPagado = new string[] {""} ;
         T00118_A623HistoricoSolicitudesComProv = new decimal[1] ;
         T00118_A626HistoricoSolicitudesComProvP = new decimal[1] ;
         T00118_A627HistoricoSolicitudesComALM = new decimal[1] ;
         T00118_A628HistoricoSolicitudesComALMP = new decimal[1] ;
         T00118_A624HistoricoSolicitudesNombreAux = new string[] {""} ;
         T00118_A625HistoricoSolicitudesSubTipo = new string[] {""} ;
         T00118_A633HistoricoSolicitudesProvID = new long[1] ;
         T00118_A634HistoricoSolicitudesProvNombre = new string[] {""} ;
         T00118_A128MetodoPagosID = new long[1] ;
         T00118_A130EstadosSolTipo = new string[] {""} ;
         T00118_A131EstadosSolId = new int[1] ;
         T00119_A132EstadosSolNombre = new string[] {""} ;
         T001110_A129MetodoPagosNombre = new string[] {""} ;
         T001111_A153HistoricoSolicitudesID = new long[1] ;
         T00115_A153HistoricoSolicitudesID = new long[1] ;
         T00115_A288HistoricoSolicitudesNombre = new string[] {""} ;
         T00115_A289HistoricoSolicitudesTelefono = new string[] {""} ;
         T00115_A290HistoricoSolicitudesMail = new string[] {""} ;
         T00115_n290HistoricoSolicitudesMail = new bool[] {false} ;
         T00115_A315HistoricoPaisID = new string[] {""} ;
         T00115_A316HistoricoDepartamentoId = new long[1] ;
         T00115_A317HistoricoDepartamentoMunicipio = new long[1] ;
         T00115_A318HistoricoZonasID = new long[1] ;
         T00115_n318HistoricoZonasID = new bool[] {false} ;
         T00115_A291HistoricoSolicitudesDireccion = new string[] {""} ;
         T00115_A292HistoricoSolicitudesAutoEnumer = new short[1] ;
         T00115_A299HistoricoSolicitudesCotizacion = new decimal[1] ;
         T00115_A301HistoricoSolicitudServicioSolC = new string[] {""} ;
         T00115_A303HistoricoSolicitudesOtros1 = new string[] {""} ;
         T00115_A304HistoricoSolicitudesOtros2 = new string[] {""} ;
         T00115_A305HistoricoSolicitudesOtros3 = new string[] {""} ;
         T00115_A306HistoricoSolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00115_A307HistoricoSolicitudesFechaActua = new DateTime[] {DateTime.MinValue} ;
         T00115_A308HistoricoSolicitudesFechaInsta = new DateTime[] {DateTime.MinValue} ;
         T00115_A309HistoricoSolicitudesHoraInstal = new string[] {""} ;
         T00115_A310HistoricoSolicitudesComentario = new string[] {""} ;
         T00115_A311HistoricoSolicitudesNota = new string[] {""} ;
         T00115_A312HistoricoSolicitudesNotificaci = new string[] {""} ;
         T00115_A439HistoricoSolicitudesOrigenPago = new string[] {""} ;
         T00115_A442HistoricoSolicitudesPagado = new string[] {""} ;
         T00115_A623HistoricoSolicitudesComProv = new decimal[1] ;
         T00115_A626HistoricoSolicitudesComProvP = new decimal[1] ;
         T00115_A627HistoricoSolicitudesComALM = new decimal[1] ;
         T00115_A628HistoricoSolicitudesComALMP = new decimal[1] ;
         T00115_A624HistoricoSolicitudesNombreAux = new string[] {""} ;
         T00115_A625HistoricoSolicitudesSubTipo = new string[] {""} ;
         T00115_A633HistoricoSolicitudesProvID = new long[1] ;
         T00115_A634HistoricoSolicitudesProvNombre = new string[] {""} ;
         T00115_A128MetodoPagosID = new long[1] ;
         T00115_A130EstadosSolTipo = new string[] {""} ;
         T00115_A131EstadosSolId = new int[1] ;
         T001112_A153HistoricoSolicitudesID = new long[1] ;
         T001113_A153HistoricoSolicitudesID = new long[1] ;
         T00114_A153HistoricoSolicitudesID = new long[1] ;
         T00114_A288HistoricoSolicitudesNombre = new string[] {""} ;
         T00114_A289HistoricoSolicitudesTelefono = new string[] {""} ;
         T00114_A290HistoricoSolicitudesMail = new string[] {""} ;
         T00114_n290HistoricoSolicitudesMail = new bool[] {false} ;
         T00114_A315HistoricoPaisID = new string[] {""} ;
         T00114_A316HistoricoDepartamentoId = new long[1] ;
         T00114_A317HistoricoDepartamentoMunicipio = new long[1] ;
         T00114_A318HistoricoZonasID = new long[1] ;
         T00114_n318HistoricoZonasID = new bool[] {false} ;
         T00114_A291HistoricoSolicitudesDireccion = new string[] {""} ;
         T00114_A292HistoricoSolicitudesAutoEnumer = new short[1] ;
         T00114_A299HistoricoSolicitudesCotizacion = new decimal[1] ;
         T00114_A301HistoricoSolicitudServicioSolC = new string[] {""} ;
         T00114_A303HistoricoSolicitudesOtros1 = new string[] {""} ;
         T00114_A304HistoricoSolicitudesOtros2 = new string[] {""} ;
         T00114_A305HistoricoSolicitudesOtros3 = new string[] {""} ;
         T00114_A306HistoricoSolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00114_A307HistoricoSolicitudesFechaActua = new DateTime[] {DateTime.MinValue} ;
         T00114_A308HistoricoSolicitudesFechaInsta = new DateTime[] {DateTime.MinValue} ;
         T00114_A309HistoricoSolicitudesHoraInstal = new string[] {""} ;
         T00114_A310HistoricoSolicitudesComentario = new string[] {""} ;
         T00114_A311HistoricoSolicitudesNota = new string[] {""} ;
         T00114_A312HistoricoSolicitudesNotificaci = new string[] {""} ;
         T00114_A439HistoricoSolicitudesOrigenPago = new string[] {""} ;
         T00114_A442HistoricoSolicitudesPagado = new string[] {""} ;
         T00114_A623HistoricoSolicitudesComProv = new decimal[1] ;
         T00114_A626HistoricoSolicitudesComProvP = new decimal[1] ;
         T00114_A627HistoricoSolicitudesComALM = new decimal[1] ;
         T00114_A628HistoricoSolicitudesComALMP = new decimal[1] ;
         T00114_A624HistoricoSolicitudesNombreAux = new string[] {""} ;
         T00114_A625HistoricoSolicitudesSubTipo = new string[] {""} ;
         T00114_A633HistoricoSolicitudesProvID = new long[1] ;
         T00114_A634HistoricoSolicitudesProvNombre = new string[] {""} ;
         T00114_A128MetodoPagosID = new long[1] ;
         T00114_A130EstadosSolTipo = new string[] {""} ;
         T00114_A131EstadosSolId = new int[1] ;
         T001117_A132EstadosSolNombre = new string[] {""} ;
         T001118_A129MetodoPagosNombre = new string[] {""} ;
         T001119_A153HistoricoSolicitudesID = new long[1] ;
         T001119_A156HistoricoRelacionesId = new long[1] ;
         T001120_A153HistoricoSolicitudesID = new long[1] ;
         T001121_A153HistoricoSolicitudesID = new long[1] ;
         T001121_A154HistoricoSolicitudesItemsID = new short[1] ;
         T001121_A330HItemsRubrosId = new long[1] ;
         T001121_A331HItemsRubrosNombre = new string[] {""} ;
         T001121_A327HItemsMedidasID = new long[1] ;
         T001121_A328HItemsInventarioId = new long[1] ;
         T001121_A329HItemsInventarioNombre = new string[] {""} ;
         T001121_A295HItemsInventarioPrecioFinal = new short[1] ;
         T001121_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         T001121_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         T001121_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         T001121_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         T001121_A319HItemsSolicitudesMonedaId = new long[1] ;
         T001122_A153HistoricoSolicitudesID = new long[1] ;
         T001122_A154HistoricoSolicitudesItemsID = new short[1] ;
         T00113_A153HistoricoSolicitudesID = new long[1] ;
         T00113_A154HistoricoSolicitudesItemsID = new short[1] ;
         T00113_A330HItemsRubrosId = new long[1] ;
         T00113_A331HItemsRubrosNombre = new string[] {""} ;
         T00113_A327HItemsMedidasID = new long[1] ;
         T00113_A328HItemsInventarioId = new long[1] ;
         T00113_A329HItemsInventarioNombre = new string[] {""} ;
         T00113_A295HItemsInventarioPrecioFinal = new short[1] ;
         T00113_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         T00113_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         T00113_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         T00113_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         T00113_A319HItemsSolicitudesMonedaId = new long[1] ;
         T00112_A153HistoricoSolicitudesID = new long[1] ;
         T00112_A154HistoricoSolicitudesItemsID = new short[1] ;
         T00112_A330HItemsRubrosId = new long[1] ;
         T00112_A331HItemsRubrosNombre = new string[] {""} ;
         T00112_A327HItemsMedidasID = new long[1] ;
         T00112_A328HItemsInventarioId = new long[1] ;
         T00112_A329HItemsInventarioNombre = new string[] {""} ;
         T00112_A295HItemsInventarioPrecioFinal = new short[1] ;
         T00112_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         T00112_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         T00112_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         T00112_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         T00112_A319HItemsSolicitudesMonedaId = new long[1] ;
         T001126_A153HistoricoSolicitudesID = new long[1] ;
         T001126_A154HistoricoSolicitudesItemsID = new short[1] ;
         Gridlevel_itemsRow = new GXWebRow();
         subGridlevel_items_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_itemsColumn = new GXWebColumn();
         T001127_A153HistoricoSolicitudesID = new long[1] ;
         T001127_A154HistoricoSolicitudesItemsID = new short[1] ;
         T001127_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         T001127_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         T001127_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         T001127_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         T001127_A295HItemsInventarioPrecioFinal = new short[1] ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.historicosolicitudes__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicosolicitudes__default(),
            new Object[][] {
                new Object[] {
               T00112_A153HistoricoSolicitudesID, T00112_A154HistoricoSolicitudesItemsID, T00112_A330HItemsRubrosId, T00112_A331HItemsRubrosNombre, T00112_A327HItemsMedidasID, T00112_A328HItemsInventarioId, T00112_A329HItemsInventarioNombre, T00112_A295HItemsInventarioPrecioFinal, T00112_A293HItemsSolicitudesItemsCantidad, T00112_A296HistoricoSolicitudesItemsSR,
               T00112_A297HistoricoSolicitudesItemsCT, T00112_A298HistoricoSolicitudesItemsComis, T00112_A319HItemsSolicitudesMonedaId
               }
               , new Object[] {
               T00113_A153HistoricoSolicitudesID, T00113_A154HistoricoSolicitudesItemsID, T00113_A330HItemsRubrosId, T00113_A331HItemsRubrosNombre, T00113_A327HItemsMedidasID, T00113_A328HItemsInventarioId, T00113_A329HItemsInventarioNombre, T00113_A295HItemsInventarioPrecioFinal, T00113_A293HItemsSolicitudesItemsCantidad, T00113_A296HistoricoSolicitudesItemsSR,
               T00113_A297HistoricoSolicitudesItemsCT, T00113_A298HistoricoSolicitudesItemsComis, T00113_A319HItemsSolicitudesMonedaId
               }
               , new Object[] {
               T00114_A153HistoricoSolicitudesID, T00114_A288HistoricoSolicitudesNombre, T00114_A289HistoricoSolicitudesTelefono, T00114_A290HistoricoSolicitudesMail, T00114_n290HistoricoSolicitudesMail, T00114_A315HistoricoPaisID, T00114_A316HistoricoDepartamentoId, T00114_A317HistoricoDepartamentoMunicipio, T00114_A318HistoricoZonasID, T00114_n318HistoricoZonasID,
               T00114_A291HistoricoSolicitudesDireccion, T00114_A292HistoricoSolicitudesAutoEnumer, T00114_A299HistoricoSolicitudesCotizacion, T00114_A301HistoricoSolicitudServicioSolC, T00114_A303HistoricoSolicitudesOtros1, T00114_A304HistoricoSolicitudesOtros2, T00114_A305HistoricoSolicitudesOtros3, T00114_A306HistoricoSolicitudesFechaAlta, T00114_A307HistoricoSolicitudesFechaActua, T00114_A308HistoricoSolicitudesFechaInsta,
               T00114_A309HistoricoSolicitudesHoraInstal, T00114_A310HistoricoSolicitudesComentario, T00114_A311HistoricoSolicitudesNota, T00114_A312HistoricoSolicitudesNotificaci, T00114_A439HistoricoSolicitudesOrigenPago, T00114_A442HistoricoSolicitudesPagado, T00114_A623HistoricoSolicitudesComProv, T00114_A626HistoricoSolicitudesComProvP, T00114_A627HistoricoSolicitudesComALM, T00114_A628HistoricoSolicitudesComALMP,
               T00114_A624HistoricoSolicitudesNombreAux, T00114_A625HistoricoSolicitudesSubTipo, T00114_A633HistoricoSolicitudesProvID, T00114_A634HistoricoSolicitudesProvNombre, T00114_A128MetodoPagosID, T00114_A130EstadosSolTipo, T00114_A131EstadosSolId
               }
               , new Object[] {
               T00115_A153HistoricoSolicitudesID, T00115_A288HistoricoSolicitudesNombre, T00115_A289HistoricoSolicitudesTelefono, T00115_A290HistoricoSolicitudesMail, T00115_n290HistoricoSolicitudesMail, T00115_A315HistoricoPaisID, T00115_A316HistoricoDepartamentoId, T00115_A317HistoricoDepartamentoMunicipio, T00115_A318HistoricoZonasID, T00115_n318HistoricoZonasID,
               T00115_A291HistoricoSolicitudesDireccion, T00115_A292HistoricoSolicitudesAutoEnumer, T00115_A299HistoricoSolicitudesCotizacion, T00115_A301HistoricoSolicitudServicioSolC, T00115_A303HistoricoSolicitudesOtros1, T00115_A304HistoricoSolicitudesOtros2, T00115_A305HistoricoSolicitudesOtros3, T00115_A306HistoricoSolicitudesFechaAlta, T00115_A307HistoricoSolicitudesFechaActua, T00115_A308HistoricoSolicitudesFechaInsta,
               T00115_A309HistoricoSolicitudesHoraInstal, T00115_A310HistoricoSolicitudesComentario, T00115_A311HistoricoSolicitudesNota, T00115_A312HistoricoSolicitudesNotificaci, T00115_A439HistoricoSolicitudesOrigenPago, T00115_A442HistoricoSolicitudesPagado, T00115_A623HistoricoSolicitudesComProv, T00115_A626HistoricoSolicitudesComProvP, T00115_A627HistoricoSolicitudesComALM, T00115_A628HistoricoSolicitudesComALMP,
               T00115_A624HistoricoSolicitudesNombreAux, T00115_A625HistoricoSolicitudesSubTipo, T00115_A633HistoricoSolicitudesProvID, T00115_A634HistoricoSolicitudesProvNombre, T00115_A128MetodoPagosID, T00115_A130EstadosSolTipo, T00115_A131EstadosSolId
               }
               , new Object[] {
               T00116_A129MetodoPagosNombre
               }
               , new Object[] {
               T00117_A132EstadosSolNombre
               }
               , new Object[] {
               T00118_A153HistoricoSolicitudesID, T00118_A288HistoricoSolicitudesNombre, T00118_A289HistoricoSolicitudesTelefono, T00118_A290HistoricoSolicitudesMail, T00118_n290HistoricoSolicitudesMail, T00118_A315HistoricoPaisID, T00118_A316HistoricoDepartamentoId, T00118_A317HistoricoDepartamentoMunicipio, T00118_A318HistoricoZonasID, T00118_n318HistoricoZonasID,
               T00118_A291HistoricoSolicitudesDireccion, T00118_A292HistoricoSolicitudesAutoEnumer, T00118_A299HistoricoSolicitudesCotizacion, T00118_A301HistoricoSolicitudServicioSolC, T00118_A132EstadosSolNombre, T00118_A303HistoricoSolicitudesOtros1, T00118_A304HistoricoSolicitudesOtros2, T00118_A305HistoricoSolicitudesOtros3, T00118_A306HistoricoSolicitudesFechaAlta, T00118_A307HistoricoSolicitudesFechaActua,
               T00118_A308HistoricoSolicitudesFechaInsta, T00118_A309HistoricoSolicitudesHoraInstal, T00118_A310HistoricoSolicitudesComentario, T00118_A129MetodoPagosNombre, T00118_A311HistoricoSolicitudesNota, T00118_A312HistoricoSolicitudesNotificaci, T00118_A439HistoricoSolicitudesOrigenPago, T00118_A442HistoricoSolicitudesPagado, T00118_A623HistoricoSolicitudesComProv, T00118_A626HistoricoSolicitudesComProvP,
               T00118_A627HistoricoSolicitudesComALM, T00118_A628HistoricoSolicitudesComALMP, T00118_A624HistoricoSolicitudesNombreAux, T00118_A625HistoricoSolicitudesSubTipo, T00118_A633HistoricoSolicitudesProvID, T00118_A634HistoricoSolicitudesProvNombre, T00118_A128MetodoPagosID, T00118_A130EstadosSolTipo, T00118_A131EstadosSolId
               }
               , new Object[] {
               T00119_A132EstadosSolNombre
               }
               , new Object[] {
               T001110_A129MetodoPagosNombre
               }
               , new Object[] {
               T001111_A153HistoricoSolicitudesID
               }
               , new Object[] {
               T001112_A153HistoricoSolicitudesID
               }
               , new Object[] {
               T001113_A153HistoricoSolicitudesID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001117_A132EstadosSolNombre
               }
               , new Object[] {
               T001118_A129MetodoPagosNombre
               }
               , new Object[] {
               T001119_A153HistoricoSolicitudesID, T001119_A156HistoricoRelacionesId
               }
               , new Object[] {
               T001120_A153HistoricoSolicitudesID
               }
               , new Object[] {
               T001121_A153HistoricoSolicitudesID, T001121_A154HistoricoSolicitudesItemsID, T001121_A330HItemsRubrosId, T001121_A331HItemsRubrosNombre, T001121_A327HItemsMedidasID, T001121_A328HItemsInventarioId, T001121_A329HItemsInventarioNombre, T001121_A295HItemsInventarioPrecioFinal, T001121_A293HItemsSolicitudesItemsCantidad, T001121_A296HistoricoSolicitudesItemsSR,
               T001121_A297HistoricoSolicitudesItemsCT, T001121_A298HistoricoSolicitudesItemsComis, T001121_A319HItemsSolicitudesMonedaId
               }
               , new Object[] {
               T001122_A153HistoricoSolicitudesID, T001122_A154HistoricoSolicitudesItemsID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001126_A153HistoricoSolicitudesID, T001126_A154HistoricoSolicitudesItemsID
               }
               , new Object[] {
               T001127_A153HistoricoSolicitudesID, T001127_A154HistoricoSolicitudesItemsID, T001127_A298HistoricoSolicitudesItemsComis, T001127_A297HistoricoSolicitudesItemsCT, T001127_A296HistoricoSolicitudesItemsSR, T001127_A293HItemsSolicitudesItemsCantidad, T001127_A295HItemsInventarioPrecioFinal
               }
            }
         );
         AV31Pgmname = "HistoricoSolicitudes";
      }

      private short Z292HistoricoSolicitudesAutoEnumer ;
      private short Z154HistoricoSolicitudesItemsID ;
      private short Z295HItemsInventarioPrecioFinal ;
      private short Z293HItemsSolicitudesItemsCantidad ;
      private short nRcdDeleted_43 ;
      private short nRcdExists_43 ;
      private short nIsMod_43 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A292HistoricoSolicitudesAutoEnumer ;
      private short nBlankRcdCount43 ;
      private short RcdFound43 ;
      private short nBlankRcdUsr43 ;
      private short RcdFound42 ;
      private short A154HistoricoSolicitudesItemsID ;
      private short A295HItemsInventarioPrecioFinal ;
      private short A293HItemsSolicitudesItemsCantidad ;
      private short Gx_BScreen ;
      private short nIsDirty_43 ;
      private short subGridlevel_items_Backcolorstyle ;
      private short subGridlevel_items_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_items_Allowselection ;
      private short subGridlevel_items_Allowhovering ;
      private short subGridlevel_items_Allowcollapsing ;
      private short subGridlevel_items_Collapsed ;
      private int Z131EstadosSolId ;
      private int nRC_GXsfl_168 ;
      private int nGXsfl_168_idx=1 ;
      private int N131EstadosSolId ;
      private int A131EstadosSolId ;
      private int trnEnded ;
      private int edtHistoricoSolicitudesID_Enabled ;
      private int edtHistoricoSolicitudesNombre_Enabled ;
      private int edtHistoricoSolicitudesTelefono_Enabled ;
      private int edtHistoricoSolicitudesMail_Enabled ;
      private int edtHistoricoPaisID_Enabled ;
      private int edtHistoricoDepartamentoId_Enabled ;
      private int edtHistoricoDepartamentoMunicipio_Enabled ;
      private int edtHistoricoZonasID_Enabled ;
      private int edtHistoricoSolicitudesDireccion_Enabled ;
      private int edtHistoricoSolicitudesAutoEnumer_Enabled ;
      private int edtHistoricoSolicitudesCotizacion_Enabled ;
      private int edtHistoricoSolicitudesTotal_Enabled ;
      private int edtHistoricoSolicitudServicioSolC_Enabled ;
      private int edtHistoricoSolicitudServicioPFin_Enabled ;
      private int edtEstadosSolTipo_Enabled ;
      private int edtEstadosSolId_Enabled ;
      private int imgprompt_130_131_Visible ;
      private int edtHistoricoSolicitudesOtros1_Enabled ;
      private int edtHistoricoSolicitudesOtros2_Enabled ;
      private int edtHistoricoSolicitudesOtros3_Enabled ;
      private int edtHistoricoSolicitudesFechaAlta_Enabled ;
      private int edtHistoricoSolicitudesFechaActua_Enabled ;
      private int edtHistoricoSolicitudesFechaInsta_Enabled ;
      private int edtHistoricoSolicitudesHoraInstal_Enabled ;
      private int edtHistoricoSolicitudesComentario_Enabled ;
      private int edtMetodoPagosID_Enabled ;
      private int imgprompt_128_Visible ;
      private int edtHistoricoSolicitudesNota_Enabled ;
      private int edtHistoricoSolicitudesNotificaci_Enabled ;
      private int edtHistoricoSolicitudesOrigenPago_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtHistoricoSolicitudesItemsID_Enabled ;
      private int edtHItemsRubrosId_Enabled ;
      private int edtHItemsRubrosNombre_Enabled ;
      private int edtHItemsMedidasID_Enabled ;
      private int edtHItemsInventarioId_Enabled ;
      private int edtHItemsInventarioNombre_Enabled ;
      private int edtHItemsInventarioPrecioFinal_Enabled ;
      private int edtHItemsSolicitudesItemsCantidad_Enabled ;
      private int edtHistoricoSolicitudesItemsSR_Enabled ;
      private int edtHistoricoSolicitudesItemsCT_Enabled ;
      private int edtHistoricoSolicitudesItemsComis_Enabled ;
      private int edtHItemsSolicitudesItemsPrecioIn_Enabled ;
      private int edtHItemsSolicitudesMonedaId_Enabled ;
      private int fRowAdded ;
      private int AV12Insert_EstadosSolId ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV32GXV1 ;
      private int subGridlevel_items_Backcolor ;
      private int subGridlevel_items_Allbackcolor ;
      private int defedtHistoricoSolicitudesItemsID_Enabled ;
      private int idxLst ;
      private int subGridlevel_items_Selectedindex ;
      private int subGridlevel_items_Selectioncolor ;
      private int subGridlevel_items_Hoveringcolor ;
      private long wcpOAV7HistoricoSolicitudesID ;
      private long Z153HistoricoSolicitudesID ;
      private long Z316HistoricoDepartamentoId ;
      private long Z317HistoricoDepartamentoMunicipio ;
      private long Z318HistoricoZonasID ;
      private long Z633HistoricoSolicitudesProvID ;
      private long Z128MetodoPagosID ;
      private long N128MetodoPagosID ;
      private long Z330HItemsRubrosId ;
      private long Z327HItemsMedidasID ;
      private long Z328HItemsInventarioId ;
      private long Z319HItemsSolicitudesMonedaId ;
      private long A128MetodoPagosID ;
      private long AV7HistoricoSolicitudesID ;
      private long A153HistoricoSolicitudesID ;
      private long A316HistoricoDepartamentoId ;
      private long A317HistoricoDepartamentoMunicipio ;
      private long A318HistoricoZonasID ;
      private long A633HistoricoSolicitudesProvID ;
      private long AV13Insert_MetodoPagosID ;
      private long GRIDLEVEL_ITEMS_nFirstRecordOnPage ;
      private long A330HItemsRubrosId ;
      private long A327HItemsMedidasID ;
      private long A328HItemsInventarioId ;
      private long A319HItemsSolicitudesMonedaId ;
      private decimal Z299HistoricoSolicitudesCotizacion ;
      private decimal Z623HistoricoSolicitudesComProv ;
      private decimal Z626HistoricoSolicitudesComProvP ;
      private decimal Z627HistoricoSolicitudesComALM ;
      private decimal Z628HistoricoSolicitudesComALMP ;
      private decimal O300HistoricoSolicitudesTotal ;
      private decimal Z298HistoricoSolicitudesItemsComis ;
      private decimal O294HItemsSolicitudesItemsPrecioIn ;
      private decimal A299HistoricoSolicitudesCotizacion ;
      private decimal A300HistoricoSolicitudesTotal ;
      private decimal A302HistoricoSolicitudServicioPFin ;
      private decimal B300HistoricoSolicitudesTotal ;
      private decimal A623HistoricoSolicitudesComProv ;
      private decimal A626HistoricoSolicitudesComProvP ;
      private decimal A627HistoricoSolicitudesComALM ;
      private decimal A628HistoricoSolicitudesComALMP ;
      private decimal A629HistoricoSolicitudesComPro ;
      private decimal A630HistoricoSolicitudesComProP ;
      private decimal s300HistoricoSolicitudesTotal ;
      private decimal s629HistoricoSolicitudesComPro ;
      private decimal O629HistoricoSolicitudesComPro ;
      private decimal s302HistoricoSolicitudServicioPFin ;
      private decimal O302HistoricoSolicitudServicioPFin ;
      private decimal A298HistoricoSolicitudesItemsComis ;
      private decimal A294HItemsSolicitudesItemsPrecioIn ;
      private decimal T294HItemsSolicitudesItemsPrecioIn ;
      private decimal Z300HistoricoSolicitudesTotal ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z288HistoricoSolicitudesNombre ;
      private string Z289HistoricoSolicitudesTelefono ;
      private string Z315HistoricoPaisID ;
      private string Z301HistoricoSolicitudServicioSolC ;
      private string Z303HistoricoSolicitudesOtros1 ;
      private string Z304HistoricoSolicitudesOtros2 ;
      private string Z305HistoricoSolicitudesOtros3 ;
      private string Z309HistoricoSolicitudesHoraInstal ;
      private string Z311HistoricoSolicitudesNota ;
      private string Z312HistoricoSolicitudesNotificaci ;
      private string Z439HistoricoSolicitudesOrigenPago ;
      private string Z442HistoricoSolicitudesPagado ;
      private string Z624HistoricoSolicitudesNombreAux ;
      private string Z625HistoricoSolicitudesSubTipo ;
      private string Z634HistoricoSolicitudesProvNombre ;
      private string Z130EstadosSolTipo ;
      private string N130EstadosSolTipo ;
      private string Z331HItemsRubrosNombre ;
      private string Z329HItemsInventarioNombre ;
      private string Z296HistoricoSolicitudesItemsSR ;
      private string Z297HistoricoSolicitudesItemsCT ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A130EstadosSolTipo ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtHistoricoSolicitudesID_Internalname ;
      private string sGXsfl_168_idx="0001" ;
      private string A442HistoricoSolicitudesPagado ;
      private string cmbHistoricoSolicitudesPagado_Internalname ;
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
      private string edtHistoricoSolicitudesID_Jsonclick ;
      private string edtHistoricoSolicitudesNombre_Internalname ;
      private string A288HistoricoSolicitudesNombre ;
      private string edtHistoricoSolicitudesNombre_Jsonclick ;
      private string edtHistoricoSolicitudesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A289HistoricoSolicitudesTelefono ;
      private string edtHistoricoSolicitudesTelefono_Jsonclick ;
      private string edtHistoricoSolicitudesMail_Internalname ;
      private string edtHistoricoSolicitudesMail_Jsonclick ;
      private string edtHistoricoPaisID_Internalname ;
      private string A315HistoricoPaisID ;
      private string edtHistoricoPaisID_Jsonclick ;
      private string edtHistoricoDepartamentoId_Internalname ;
      private string edtHistoricoDepartamentoId_Jsonclick ;
      private string edtHistoricoDepartamentoMunicipio_Internalname ;
      private string edtHistoricoDepartamentoMunicipio_Jsonclick ;
      private string edtHistoricoZonasID_Internalname ;
      private string edtHistoricoZonasID_Jsonclick ;
      private string edtHistoricoSolicitudesDireccion_Internalname ;
      private string edtHistoricoSolicitudesAutoEnumer_Internalname ;
      private string edtHistoricoSolicitudesAutoEnumer_Jsonclick ;
      private string edtHistoricoSolicitudesCotizacion_Internalname ;
      private string edtHistoricoSolicitudesCotizacion_Jsonclick ;
      private string edtHistoricoSolicitudesTotal_Internalname ;
      private string edtHistoricoSolicitudesTotal_Jsonclick ;
      private string edtHistoricoSolicitudServicioSolC_Internalname ;
      private string A301HistoricoSolicitudServicioSolC ;
      private string edtHistoricoSolicitudServicioSolC_Jsonclick ;
      private string edtHistoricoSolicitudServicioPFin_Internalname ;
      private string edtHistoricoSolicitudServicioPFin_Jsonclick ;
      private string edtEstadosSolTipo_Internalname ;
      private string edtEstadosSolTipo_Jsonclick ;
      private string edtEstadosSolId_Internalname ;
      private string edtEstadosSolId_Jsonclick ;
      private string imgprompt_130_131_gximage ;
      private string sImgUrl ;
      private string imgprompt_130_131_Internalname ;
      private string imgprompt_130_131_Link ;
      private string edtHistoricoSolicitudesOtros1_Internalname ;
      private string A303HistoricoSolicitudesOtros1 ;
      private string edtHistoricoSolicitudesOtros1_Jsonclick ;
      private string edtHistoricoSolicitudesOtros2_Internalname ;
      private string A304HistoricoSolicitudesOtros2 ;
      private string edtHistoricoSolicitudesOtros3_Internalname ;
      private string A305HistoricoSolicitudesOtros3 ;
      private string edtHistoricoSolicitudesFechaAlta_Internalname ;
      private string edtHistoricoSolicitudesFechaAlta_Jsonclick ;
      private string edtHistoricoSolicitudesFechaActua_Internalname ;
      private string edtHistoricoSolicitudesFechaActua_Jsonclick ;
      private string edtHistoricoSolicitudesFechaInsta_Internalname ;
      private string edtHistoricoSolicitudesFechaInsta_Jsonclick ;
      private string edtHistoricoSolicitudesHoraInstal_Internalname ;
      private string A309HistoricoSolicitudesHoraInstal ;
      private string edtHistoricoSolicitudesHoraInstal_Jsonclick ;
      private string edtHistoricoSolicitudesComentario_Internalname ;
      private string edtMetodoPagosID_Internalname ;
      private string edtMetodoPagosID_Jsonclick ;
      private string imgprompt_128_gximage ;
      private string imgprompt_128_Internalname ;
      private string imgprompt_128_Link ;
      private string edtHistoricoSolicitudesNota_Internalname ;
      private string A311HistoricoSolicitudesNota ;
      private string edtHistoricoSolicitudesNotificaci_Internalname ;
      private string A312HistoricoSolicitudesNotificaci ;
      private string edtHistoricoSolicitudesNotificaci_Jsonclick ;
      private string edtHistoricoSolicitudesOrigenPago_Internalname ;
      private string A439HistoricoSolicitudesOrigenPago ;
      private string edtHistoricoSolicitudesOrigenPago_Jsonclick ;
      private string cmbHistoricoSolicitudesPagado_Jsonclick ;
      private string divTableleaflevel_items_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode43 ;
      private string edtHistoricoSolicitudesItemsID_Internalname ;
      private string edtHItemsRubrosId_Internalname ;
      private string edtHItemsRubrosNombre_Internalname ;
      private string edtHItemsMedidasID_Internalname ;
      private string edtHItemsInventarioId_Internalname ;
      private string edtHItemsInventarioNombre_Internalname ;
      private string edtHItemsInventarioPrecioFinal_Internalname ;
      private string edtHItemsSolicitudesItemsCantidad_Internalname ;
      private string edtHistoricoSolicitudesItemsSR_Internalname ;
      private string edtHistoricoSolicitudesItemsCT_Internalname ;
      private string edtHistoricoSolicitudesItemsComis_Internalname ;
      private string edtHItemsSolicitudesItemsPrecioIn_Internalname ;
      private string edtHItemsSolicitudesMonedaId_Internalname ;
      private string sStyleString ;
      private string subGridlevel_items_Internalname ;
      private string A624HistoricoSolicitudesNombreAux ;
      private string A625HistoricoSolicitudesSubTipo ;
      private string A634HistoricoSolicitudesProvNombre ;
      private string AV11Insert_EstadosSolTipo ;
      private string A129MetodoPagosNombre ;
      private string A132EstadosSolNombre ;
      private string AV31Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode42 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A331HItemsRubrosNombre ;
      private string A329HItemsInventarioNombre ;
      private string A296HistoricoSolicitudesItemsSR ;
      private string A297HistoricoSolicitudesItemsCT ;
      private string GXEncryptionTmp ;
      private string Z132EstadosSolNombre ;
      private string Z129MetodoPagosNombre ;
      private string sGXsfl_168_fel_idx="0001" ;
      private string subGridlevel_items_Class ;
      private string subGridlevel_items_Linesclass ;
      private string ROClassString ;
      private string edtHistoricoSolicitudesItemsID_Jsonclick ;
      private string edtHItemsRubrosId_Jsonclick ;
      private string edtHItemsRubrosNombre_Jsonclick ;
      private string edtHItemsMedidasID_Jsonclick ;
      private string edtHItemsInventarioId_Jsonclick ;
      private string edtHItemsInventarioNombre_Jsonclick ;
      private string edtHItemsInventarioPrecioFinal_Jsonclick ;
      private string edtHItemsSolicitudesItemsCantidad_Jsonclick ;
      private string edtHistoricoSolicitudesItemsSR_Jsonclick ;
      private string edtHistoricoSolicitudesItemsCT_Jsonclick ;
      private string edtHistoricoSolicitudesItemsComis_Jsonclick ;
      private string edtHItemsSolicitudesItemsPrecioIn_Jsonclick ;
      private string edtHItemsSolicitudesMonedaId_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_items_Header ;
      private DateTime Z307HistoricoSolicitudesFechaActua ;
      private DateTime A307HistoricoSolicitudesFechaActua ;
      private DateTime Z306HistoricoSolicitudesFechaAlta ;
      private DateTime Z308HistoricoSolicitudesFechaInsta ;
      private DateTime A306HistoricoSolicitudesFechaAlta ;
      private DateTime A308HistoricoSolicitudesFechaInsta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool bGXsfl_168_Refreshing=false ;
      private bool n290HistoricoSolicitudesMail ;
      private bool n318HistoricoZonasID ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private string A310HistoricoSolicitudesComentario ;
      private string Z310HistoricoSolicitudesComentario ;
      private string Z290HistoricoSolicitudesMail ;
      private string Z291HistoricoSolicitudesDireccion ;
      private string A290HistoricoSolicitudesMail ;
      private string A291HistoricoSolicitudesDireccion ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_itemsContainer ;
      private GXWebRow Gridlevel_itemsRow ;
      private GXWebColumn Gridlevel_itemsColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbHistoricoSolicitudesPagado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV15WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00116_A129MetodoPagosNombre ;
      private string[] T00117_A132EstadosSolNombre ;
      private long[] T00118_A153HistoricoSolicitudesID ;
      private string[] T00118_A288HistoricoSolicitudesNombre ;
      private string[] T00118_A289HistoricoSolicitudesTelefono ;
      private string[] T00118_A290HistoricoSolicitudesMail ;
      private bool[] T00118_n290HistoricoSolicitudesMail ;
      private string[] T00118_A315HistoricoPaisID ;
      private long[] T00118_A316HistoricoDepartamentoId ;
      private long[] T00118_A317HistoricoDepartamentoMunicipio ;
      private long[] T00118_A318HistoricoZonasID ;
      private bool[] T00118_n318HistoricoZonasID ;
      private string[] T00118_A291HistoricoSolicitudesDireccion ;
      private short[] T00118_A292HistoricoSolicitudesAutoEnumer ;
      private decimal[] T00118_A299HistoricoSolicitudesCotizacion ;
      private string[] T00118_A301HistoricoSolicitudServicioSolC ;
      private string[] T00118_A132EstadosSolNombre ;
      private string[] T00118_A303HistoricoSolicitudesOtros1 ;
      private string[] T00118_A304HistoricoSolicitudesOtros2 ;
      private string[] T00118_A305HistoricoSolicitudesOtros3 ;
      private DateTime[] T00118_A306HistoricoSolicitudesFechaAlta ;
      private DateTime[] T00118_A307HistoricoSolicitudesFechaActua ;
      private DateTime[] T00118_A308HistoricoSolicitudesFechaInsta ;
      private string[] T00118_A309HistoricoSolicitudesHoraInstal ;
      private string[] T00118_A310HistoricoSolicitudesComentario ;
      private string[] T00118_A129MetodoPagosNombre ;
      private string[] T00118_A311HistoricoSolicitudesNota ;
      private string[] T00118_A312HistoricoSolicitudesNotificaci ;
      private string[] T00118_A439HistoricoSolicitudesOrigenPago ;
      private string[] T00118_A442HistoricoSolicitudesPagado ;
      private decimal[] T00118_A623HistoricoSolicitudesComProv ;
      private decimal[] T00118_A626HistoricoSolicitudesComProvP ;
      private decimal[] T00118_A627HistoricoSolicitudesComALM ;
      private decimal[] T00118_A628HistoricoSolicitudesComALMP ;
      private string[] T00118_A624HistoricoSolicitudesNombreAux ;
      private string[] T00118_A625HistoricoSolicitudesSubTipo ;
      private long[] T00118_A633HistoricoSolicitudesProvID ;
      private string[] T00118_A634HistoricoSolicitudesProvNombre ;
      private long[] T00118_A128MetodoPagosID ;
      private string[] T00118_A130EstadosSolTipo ;
      private int[] T00118_A131EstadosSolId ;
      private string[] T00119_A132EstadosSolNombre ;
      private string[] T001110_A129MetodoPagosNombre ;
      private long[] T001111_A153HistoricoSolicitudesID ;
      private long[] T00115_A153HistoricoSolicitudesID ;
      private string[] T00115_A288HistoricoSolicitudesNombre ;
      private string[] T00115_A289HistoricoSolicitudesTelefono ;
      private string[] T00115_A290HistoricoSolicitudesMail ;
      private bool[] T00115_n290HistoricoSolicitudesMail ;
      private string[] T00115_A315HistoricoPaisID ;
      private long[] T00115_A316HistoricoDepartamentoId ;
      private long[] T00115_A317HistoricoDepartamentoMunicipio ;
      private long[] T00115_A318HistoricoZonasID ;
      private bool[] T00115_n318HistoricoZonasID ;
      private string[] T00115_A291HistoricoSolicitudesDireccion ;
      private short[] T00115_A292HistoricoSolicitudesAutoEnumer ;
      private decimal[] T00115_A299HistoricoSolicitudesCotizacion ;
      private string[] T00115_A301HistoricoSolicitudServicioSolC ;
      private string[] T00115_A303HistoricoSolicitudesOtros1 ;
      private string[] T00115_A304HistoricoSolicitudesOtros2 ;
      private string[] T00115_A305HistoricoSolicitudesOtros3 ;
      private DateTime[] T00115_A306HistoricoSolicitudesFechaAlta ;
      private DateTime[] T00115_A307HistoricoSolicitudesFechaActua ;
      private DateTime[] T00115_A308HistoricoSolicitudesFechaInsta ;
      private string[] T00115_A309HistoricoSolicitudesHoraInstal ;
      private string[] T00115_A310HistoricoSolicitudesComentario ;
      private string[] T00115_A311HistoricoSolicitudesNota ;
      private string[] T00115_A312HistoricoSolicitudesNotificaci ;
      private string[] T00115_A439HistoricoSolicitudesOrigenPago ;
      private string[] T00115_A442HistoricoSolicitudesPagado ;
      private decimal[] T00115_A623HistoricoSolicitudesComProv ;
      private decimal[] T00115_A626HistoricoSolicitudesComProvP ;
      private decimal[] T00115_A627HistoricoSolicitudesComALM ;
      private decimal[] T00115_A628HistoricoSolicitudesComALMP ;
      private string[] T00115_A624HistoricoSolicitudesNombreAux ;
      private string[] T00115_A625HistoricoSolicitudesSubTipo ;
      private long[] T00115_A633HistoricoSolicitudesProvID ;
      private string[] T00115_A634HistoricoSolicitudesProvNombre ;
      private long[] T00115_A128MetodoPagosID ;
      private string[] T00115_A130EstadosSolTipo ;
      private int[] T00115_A131EstadosSolId ;
      private long[] T001112_A153HistoricoSolicitudesID ;
      private long[] T001113_A153HistoricoSolicitudesID ;
      private long[] T00114_A153HistoricoSolicitudesID ;
      private string[] T00114_A288HistoricoSolicitudesNombre ;
      private string[] T00114_A289HistoricoSolicitudesTelefono ;
      private string[] T00114_A290HistoricoSolicitudesMail ;
      private bool[] T00114_n290HistoricoSolicitudesMail ;
      private string[] T00114_A315HistoricoPaisID ;
      private long[] T00114_A316HistoricoDepartamentoId ;
      private long[] T00114_A317HistoricoDepartamentoMunicipio ;
      private long[] T00114_A318HistoricoZonasID ;
      private bool[] T00114_n318HistoricoZonasID ;
      private string[] T00114_A291HistoricoSolicitudesDireccion ;
      private short[] T00114_A292HistoricoSolicitudesAutoEnumer ;
      private decimal[] T00114_A299HistoricoSolicitudesCotizacion ;
      private string[] T00114_A301HistoricoSolicitudServicioSolC ;
      private string[] T00114_A303HistoricoSolicitudesOtros1 ;
      private string[] T00114_A304HistoricoSolicitudesOtros2 ;
      private string[] T00114_A305HistoricoSolicitudesOtros3 ;
      private DateTime[] T00114_A306HistoricoSolicitudesFechaAlta ;
      private DateTime[] T00114_A307HistoricoSolicitudesFechaActua ;
      private DateTime[] T00114_A308HistoricoSolicitudesFechaInsta ;
      private string[] T00114_A309HistoricoSolicitudesHoraInstal ;
      private string[] T00114_A310HistoricoSolicitudesComentario ;
      private string[] T00114_A311HistoricoSolicitudesNota ;
      private string[] T00114_A312HistoricoSolicitudesNotificaci ;
      private string[] T00114_A439HistoricoSolicitudesOrigenPago ;
      private string[] T00114_A442HistoricoSolicitudesPagado ;
      private decimal[] T00114_A623HistoricoSolicitudesComProv ;
      private decimal[] T00114_A626HistoricoSolicitudesComProvP ;
      private decimal[] T00114_A627HistoricoSolicitudesComALM ;
      private decimal[] T00114_A628HistoricoSolicitudesComALMP ;
      private string[] T00114_A624HistoricoSolicitudesNombreAux ;
      private string[] T00114_A625HistoricoSolicitudesSubTipo ;
      private long[] T00114_A633HistoricoSolicitudesProvID ;
      private string[] T00114_A634HistoricoSolicitudesProvNombre ;
      private long[] T00114_A128MetodoPagosID ;
      private string[] T00114_A130EstadosSolTipo ;
      private int[] T00114_A131EstadosSolId ;
      private string[] T001117_A132EstadosSolNombre ;
      private string[] T001118_A129MetodoPagosNombre ;
      private long[] T001119_A153HistoricoSolicitudesID ;
      private long[] T001119_A156HistoricoRelacionesId ;
      private long[] T001120_A153HistoricoSolicitudesID ;
      private long[] T001121_A153HistoricoSolicitudesID ;
      private short[] T001121_A154HistoricoSolicitudesItemsID ;
      private long[] T001121_A330HItemsRubrosId ;
      private string[] T001121_A331HItemsRubrosNombre ;
      private long[] T001121_A327HItemsMedidasID ;
      private long[] T001121_A328HItemsInventarioId ;
      private string[] T001121_A329HItemsInventarioNombre ;
      private short[] T001121_A295HItemsInventarioPrecioFinal ;
      private short[] T001121_A293HItemsSolicitudesItemsCantidad ;
      private string[] T001121_A296HistoricoSolicitudesItemsSR ;
      private string[] T001121_A297HistoricoSolicitudesItemsCT ;
      private decimal[] T001121_A298HistoricoSolicitudesItemsComis ;
      private long[] T001121_A319HItemsSolicitudesMonedaId ;
      private long[] T001122_A153HistoricoSolicitudesID ;
      private short[] T001122_A154HistoricoSolicitudesItemsID ;
      private long[] T00113_A153HistoricoSolicitudesID ;
      private short[] T00113_A154HistoricoSolicitudesItemsID ;
      private long[] T00113_A330HItemsRubrosId ;
      private string[] T00113_A331HItemsRubrosNombre ;
      private long[] T00113_A327HItemsMedidasID ;
      private long[] T00113_A328HItemsInventarioId ;
      private string[] T00113_A329HItemsInventarioNombre ;
      private short[] T00113_A295HItemsInventarioPrecioFinal ;
      private short[] T00113_A293HItemsSolicitudesItemsCantidad ;
      private string[] T00113_A296HistoricoSolicitudesItemsSR ;
      private string[] T00113_A297HistoricoSolicitudesItemsCT ;
      private decimal[] T00113_A298HistoricoSolicitudesItemsComis ;
      private long[] T00113_A319HItemsSolicitudesMonedaId ;
      private long[] T00112_A153HistoricoSolicitudesID ;
      private short[] T00112_A154HistoricoSolicitudesItemsID ;
      private long[] T00112_A330HItemsRubrosId ;
      private string[] T00112_A331HItemsRubrosNombre ;
      private long[] T00112_A327HItemsMedidasID ;
      private long[] T00112_A328HItemsInventarioId ;
      private string[] T00112_A329HItemsInventarioNombre ;
      private short[] T00112_A295HItemsInventarioPrecioFinal ;
      private short[] T00112_A293HItemsSolicitudesItemsCantidad ;
      private string[] T00112_A296HistoricoSolicitudesItemsSR ;
      private string[] T00112_A297HistoricoSolicitudesItemsCT ;
      private decimal[] T00112_A298HistoricoSolicitudesItemsComis ;
      private long[] T00112_A319HItemsSolicitudesMonedaId ;
      private long[] T001126_A153HistoricoSolicitudesID ;
      private short[] T001126_A154HistoricoSolicitudesItemsID ;
      private long[] T001127_A153HistoricoSolicitudesID ;
      private short[] T001127_A154HistoricoSolicitudesItemsID ;
      private decimal[] T001127_A298HistoricoSolicitudesItemsComis ;
      private string[] T001127_A297HistoricoSolicitudesItemsCT ;
      private string[] T001127_A296HistoricoSolicitudesItemsSR ;
      private short[] T001127_A293HItemsSolicitudesItemsCantidad ;
      private short[] T001127_A295HItemsInventarioPrecioFinal ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class historicosolicitudes__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class historicosolicitudes__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00112;
        prmT00112 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoSolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmT00113;
        prmT00113 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoSolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmT00114;
        prmT00114 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT00115;
        prmT00115 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT00116;
        prmT00116 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT00117;
        prmT00117 = new Object[] {
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0)
        };
        Object[] prmT00118;
        prmT00118 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT00119;
        prmT00119 = new Object[] {
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0)
        };
        Object[] prmT001110;
        prmT001110 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT001111;
        prmT001111 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT001112;
        prmT001112 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT001113;
        prmT001113 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT001114;
        prmT001114 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoSolicitudesNombre",GXType.NChar,100,0) ,
        new ParDef("@HistoricoSolicitudesTelefono",GXType.NChar,20,0) ,
        new ParDef("@HistoricoSolicitudesMail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@HistoricoPaisID",GXType.NChar,2,0) ,
        new ParDef("@HistoricoDepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoDepartamentoMunicipio",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@HistoricoSolicitudesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@HistoricoSolicitudesAutoEnumer",GXType.Int16,4,0) ,
        new ParDef("@HistoricoSolicitudesCotizacion",GXType.Decimal,18,2) ,
        new ParDef("@HistoricoSolicitudServicioSolC",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesOtros1",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesOtros2",GXType.NChar,1000,0) ,
        new ParDef("@HistoricoSolicitudesOtros3",GXType.NChar,500,0) ,
        new ParDef("@HistoricoSolicitudesFechaAlta",GXType.Date,8,0) ,
        new ParDef("@HistoricoSolicitudesFechaActua",GXType.DateTime,8,5) ,
        new ParDef("@HistoricoSolicitudesFechaInsta",GXType.Date,8,0) ,
        new ParDef("@HistoricoSolicitudesHoraInstal",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@HistoricoSolicitudesNota",GXType.NChar,500,0) ,
        new ParDef("@HistoricoSolicitudesNotificaci",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesOrigenPago",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesPagado",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesComProv",GXType.Decimal,18,2) ,
        new ParDef("@HistoricoSolicitudesComProvP",GXType.Decimal,6,2) ,
        new ParDef("@HistoricoSolicitudesComALM",GXType.Decimal,18,2) ,
        new ParDef("@HistoricoSolicitudesComALMP",GXType.Decimal,6,2) ,
        new ParDef("@HistoricoSolicitudesNombreAux",GXType.NChar,80,0) ,
        new ParDef("@HistoricoSolicitudesSubTipo",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesProvID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoSolicitudesProvNombre",GXType.NChar,120,0) ,
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0) ,
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0)
        };
        string cmdBufferT001114;
        cmdBufferT001114=" INSERT INTO [HistoricoSolicitudes]([HistoricoSolicitudesID], [HistoricoSolicitudesNombre], [HistoricoSolicitudesTelefono], [HistoricoSolicitudesMail], [HistoricoPaisID], [HistoricoDepartamentoId], [HistoricoDepartamentoMunicipio], [HistoricoZonasID], [HistoricoSolicitudesDireccion], [HistoricoSolicitudesAutoEnumer], [HistoricoSolicitudesCotizacion], [HistoricoSolicitudServicioSolC], [HistoricoSolicitudesOtros1], [HistoricoSolicitudesOtros2], [HistoricoSolicitudesOtros3], [HistoricoSolicitudesFechaAlta], [HistoricoSolicitudesFechaActua], [HistoricoSolicitudesFechaInsta], [HistoricoSolicitudesHoraInstal], [HistoricoSolicitudesComentario], [HistoricoSolicitudesNota], [HistoricoSolicitudesNotificaci], [HistoricoSolicitudesOrigenPago], [HistoricoSolicitudesPagado], [HistoricoSolicitudesComProv], [HistoricoSolicitudesComProvP], [HistoricoSolicitudesComALM], [HistoricoSolicitudesComALMP], [HistoricoSolicitudesNombreAux], [HistoricoSolicitudesSubTipo], [HistoricoSolicitudesProvID], [HistoricoSolicitudesProvNombre], [MetodoPagosID], [EstadosSolTipo], [EstadosSolId]) VALUES(@HistoricoSolicitudesID, @HistoricoSolicitudesNombre, @HistoricoSolicitudesTelefono, @HistoricoSolicitudesMail, @HistoricoPaisID, @HistoricoDepartamentoId, @HistoricoDepartamentoMunicipio, @HistoricoZonasID, @HistoricoSolicitudesDireccion, @HistoricoSolicitudesAutoEnumer, @HistoricoSolicitudesCotizacion, @HistoricoSolicitudServicioSolC, @HistoricoSolicitudesOtros1, @HistoricoSolicitudesOtros2, @HistoricoSolicitudesOtros3, @HistoricoSolicitudesFechaAlta, @HistoricoSolicitudesFechaActua, @HistoricoSolicitudesFechaInsta, @HistoricoSolicitudesHoraInstal, @HistoricoSolicitudesComentario, @HistoricoSolicitudesNota, @HistoricoSolicitudesNotificaci, @HistoricoSolicitudesOrigenPago, @HistoricoSolicitudesPagado, @HistoricoSolicitudesComProv, "
        + " @HistoricoSolicitudesComProvP, @HistoricoSolicitudesComALM, @HistoricoSolicitudesComALMP, @HistoricoSolicitudesNombreAux, @HistoricoSolicitudesSubTipo, @HistoricoSolicitudesProvID, @HistoricoSolicitudesProvNombre, @MetodoPagosID, @EstadosSolTipo, @EstadosSolId)" ;
        Object[] prmT001115;
        prmT001115 = new Object[] {
        new ParDef("@HistoricoSolicitudesNombre",GXType.NChar,100,0) ,
        new ParDef("@HistoricoSolicitudesTelefono",GXType.NChar,20,0) ,
        new ParDef("@HistoricoSolicitudesMail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@HistoricoPaisID",GXType.NChar,2,0) ,
        new ParDef("@HistoricoDepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoDepartamentoMunicipio",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@HistoricoSolicitudesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@HistoricoSolicitudesAutoEnumer",GXType.Int16,4,0) ,
        new ParDef("@HistoricoSolicitudesCotizacion",GXType.Decimal,18,2) ,
        new ParDef("@HistoricoSolicitudServicioSolC",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesOtros1",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesOtros2",GXType.NChar,1000,0) ,
        new ParDef("@HistoricoSolicitudesOtros3",GXType.NChar,500,0) ,
        new ParDef("@HistoricoSolicitudesFechaAlta",GXType.Date,8,0) ,
        new ParDef("@HistoricoSolicitudesFechaActua",GXType.DateTime,8,5) ,
        new ParDef("@HistoricoSolicitudesFechaInsta",GXType.Date,8,0) ,
        new ParDef("@HistoricoSolicitudesHoraInstal",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@HistoricoSolicitudesNota",GXType.NChar,500,0) ,
        new ParDef("@HistoricoSolicitudesNotificaci",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesOrigenPago",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesPagado",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesComProv",GXType.Decimal,18,2) ,
        new ParDef("@HistoricoSolicitudesComProvP",GXType.Decimal,6,2) ,
        new ParDef("@HistoricoSolicitudesComALM",GXType.Decimal,18,2) ,
        new ParDef("@HistoricoSolicitudesComALMP",GXType.Decimal,6,2) ,
        new ParDef("@HistoricoSolicitudesNombreAux",GXType.NChar,80,0) ,
        new ParDef("@HistoricoSolicitudesSubTipo",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesProvID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoSolicitudesProvNombre",GXType.NChar,120,0) ,
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0) ,
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        string cmdBufferT001115;
        cmdBufferT001115=" UPDATE [HistoricoSolicitudes] SET [HistoricoSolicitudesNombre]=@HistoricoSolicitudesNombre, [HistoricoSolicitudesTelefono]=@HistoricoSolicitudesTelefono, [HistoricoSolicitudesMail]=@HistoricoSolicitudesMail, [HistoricoPaisID]=@HistoricoPaisID, [HistoricoDepartamentoId]=@HistoricoDepartamentoId, [HistoricoDepartamentoMunicipio]=@HistoricoDepartamentoMunicipio, [HistoricoZonasID]=@HistoricoZonasID, [HistoricoSolicitudesDireccion]=@HistoricoSolicitudesDireccion, [HistoricoSolicitudesAutoEnumer]=@HistoricoSolicitudesAutoEnumer, [HistoricoSolicitudesCotizacion]=@HistoricoSolicitudesCotizacion, [HistoricoSolicitudServicioSolC]=@HistoricoSolicitudServicioSolC, [HistoricoSolicitudesOtros1]=@HistoricoSolicitudesOtros1, [HistoricoSolicitudesOtros2]=@HistoricoSolicitudesOtros2, [HistoricoSolicitudesOtros3]=@HistoricoSolicitudesOtros3, [HistoricoSolicitudesFechaAlta]=@HistoricoSolicitudesFechaAlta, [HistoricoSolicitudesFechaActua]=@HistoricoSolicitudesFechaActua, [HistoricoSolicitudesFechaInsta]=@HistoricoSolicitudesFechaInsta, [HistoricoSolicitudesHoraInstal]=@HistoricoSolicitudesHoraInstal, [HistoricoSolicitudesComentario]=@HistoricoSolicitudesComentario, [HistoricoSolicitudesNota]=@HistoricoSolicitudesNota, [HistoricoSolicitudesNotificaci]=@HistoricoSolicitudesNotificaci, [HistoricoSolicitudesOrigenPago]=@HistoricoSolicitudesOrigenPago, [HistoricoSolicitudesPagado]=@HistoricoSolicitudesPagado, [HistoricoSolicitudesComProv]=@HistoricoSolicitudesComProv, [HistoricoSolicitudesComProvP]=@HistoricoSolicitudesComProvP, [HistoricoSolicitudesComALM]=@HistoricoSolicitudesComALM, [HistoricoSolicitudesComALMP]=@HistoricoSolicitudesComALMP, [HistoricoSolicitudesNombreAux]=@HistoricoSolicitudesNombreAux, [HistoricoSolicitudesSubTipo]=@HistoricoSolicitudesSubTipo, [HistoricoSolicitudesProvID]=@HistoricoSolicitudesProvID, "
        + " [HistoricoSolicitudesProvNombre]=@HistoricoSolicitudesProvNombre, [MetodoPagosID]=@MetodoPagosID, [EstadosSolTipo]=@EstadosSolTipo, [EstadosSolId]=@EstadosSolId  WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID" ;
        Object[] prmT001116;
        prmT001116 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT001117;
        prmT001117 = new Object[] {
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0)
        };
        Object[] prmT001118;
        prmT001118 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0)
        };
        Object[] prmT001119;
        prmT001119 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT001120;
        prmT001120 = new Object[] {
        };
        Object[] prmT001121;
        prmT001121 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoSolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmT001122;
        prmT001122 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoSolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmT001123;
        prmT001123 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoSolicitudesItemsID",GXType.Int16,4,0) ,
        new ParDef("@HItemsRubrosId",GXType.Decimal,18,0) ,
        new ParDef("@HItemsRubrosNombre",GXType.NChar,100,0) ,
        new ParDef("@HItemsMedidasID",GXType.Decimal,18,0) ,
        new ParDef("@HItemsInventarioId",GXType.Decimal,18,0) ,
        new ParDef("@HItemsInventarioNombre",GXType.NChar,100,0) ,
        new ParDef("@HItemsInventarioPrecioFinal",GXType.Int16,4,0) ,
        new ParDef("@HItemsSolicitudesItemsCantidad",GXType.Int16,4,0) ,
        new ParDef("@HistoricoSolicitudesItemsSR",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesItemsCT",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesItemsComis",GXType.Decimal,18,2) ,
        new ParDef("@HItemsSolicitudesMonedaId",GXType.Decimal,18,0)
        };
        Object[] prmT001124;
        prmT001124 = new Object[] {
        new ParDef("@HItemsRubrosId",GXType.Decimal,18,0) ,
        new ParDef("@HItemsRubrosNombre",GXType.NChar,100,0) ,
        new ParDef("@HItemsMedidasID",GXType.Decimal,18,0) ,
        new ParDef("@HItemsInventarioId",GXType.Decimal,18,0) ,
        new ParDef("@HItemsInventarioNombre",GXType.NChar,100,0) ,
        new ParDef("@HItemsInventarioPrecioFinal",GXType.Int16,4,0) ,
        new ParDef("@HItemsSolicitudesItemsCantidad",GXType.Int16,4,0) ,
        new ParDef("@HistoricoSolicitudesItemsSR",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesItemsCT",GXType.NChar,1,0) ,
        new ParDef("@HistoricoSolicitudesItemsComis",GXType.Decimal,18,2) ,
        new ParDef("@HItemsSolicitudesMonedaId",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoSolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmT001125;
        prmT001125 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0) ,
        new ParDef("@HistoricoSolicitudesItemsID",GXType.Int16,4,0)
        };
        Object[] prmT001126;
        prmT001126 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmT001127;
        prmT001127 = new Object[] {
        new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00112", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID], [HItemsRubrosId], [HItemsRubrosNombre], [HItemsMedidasID], [HItemsInventarioId], [HItemsInventarioNombre], [HItemsInventarioPrecioFinal], [HItemsSolicitudesItemsCantidad], [HistoricoSolicitudesItemsSR], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsComis], [HItemsSolicitudesMonedaId] FROM [HistoricoSolicitudesItems] WITH (UPDLOCK) WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID AND [HistoricoSolicitudesItemsID] = @HistoricoSolicitudesItemsID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00112,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00113", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID], [HItemsRubrosId], [HItemsRubrosNombre], [HItemsMedidasID], [HItemsInventarioId], [HItemsInventarioNombre], [HItemsInventarioPrecioFinal], [HItemsSolicitudesItemsCantidad], [HistoricoSolicitudesItemsSR], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsComis], [HItemsSolicitudesMonedaId] FROM [HistoricoSolicitudesItems] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID AND [HistoricoSolicitudesItemsID] = @HistoricoSolicitudesItemsID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00113,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00114", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesNombre], [HistoricoSolicitudesTelefono], [HistoricoSolicitudesMail], [HistoricoPaisID], [HistoricoDepartamentoId], [HistoricoDepartamentoMunicipio], [HistoricoZonasID], [HistoricoSolicitudesDireccion], [HistoricoSolicitudesAutoEnumer], [HistoricoSolicitudesCotizacion], [HistoricoSolicitudServicioSolC], [HistoricoSolicitudesOtros1], [HistoricoSolicitudesOtros2], [HistoricoSolicitudesOtros3], [HistoricoSolicitudesFechaAlta], [HistoricoSolicitudesFechaActua], [HistoricoSolicitudesFechaInsta], [HistoricoSolicitudesHoraInstal], [HistoricoSolicitudesComentario], [HistoricoSolicitudesNota], [HistoricoSolicitudesNotificaci], [HistoricoSolicitudesOrigenPago], [HistoricoSolicitudesPagado], [HistoricoSolicitudesComProv], [HistoricoSolicitudesComProvP], [HistoricoSolicitudesComALM], [HistoricoSolicitudesComALMP], [HistoricoSolicitudesNombreAux], [HistoricoSolicitudesSubTipo], [HistoricoSolicitudesProvID], [HistoricoSolicitudesProvNombre], [MetodoPagosID], [EstadosSolTipo] AS EstadosSolTipo, [EstadosSolId] AS EstadosSolId FROM [HistoricoSolicitudes] WITH (UPDLOCK) WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00114,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00115", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesNombre], [HistoricoSolicitudesTelefono], [HistoricoSolicitudesMail], [HistoricoPaisID], [HistoricoDepartamentoId], [HistoricoDepartamentoMunicipio], [HistoricoZonasID], [HistoricoSolicitudesDireccion], [HistoricoSolicitudesAutoEnumer], [HistoricoSolicitudesCotizacion], [HistoricoSolicitudServicioSolC], [HistoricoSolicitudesOtros1], [HistoricoSolicitudesOtros2], [HistoricoSolicitudesOtros3], [HistoricoSolicitudesFechaAlta], [HistoricoSolicitudesFechaActua], [HistoricoSolicitudesFechaInsta], [HistoricoSolicitudesHoraInstal], [HistoricoSolicitudesComentario], [HistoricoSolicitudesNota], [HistoricoSolicitudesNotificaci], [HistoricoSolicitudesOrigenPago], [HistoricoSolicitudesPagado], [HistoricoSolicitudesComProv], [HistoricoSolicitudesComProvP], [HistoricoSolicitudesComALM], [HistoricoSolicitudesComALMP], [HistoricoSolicitudesNombreAux], [HistoricoSolicitudesSubTipo], [HistoricoSolicitudesProvID], [HistoricoSolicitudesProvNombre], [MetodoPagosID], [EstadosSolTipo] AS EstadosSolTipo, [EstadosSolId] AS EstadosSolId FROM [HistoricoSolicitudes] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00115,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00116", "SELECT [MetodoPagosNombre] FROM [MetodoPagos] WHERE [MetodoPagosID] = @MetodoPagosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00116,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00117", "SELECT [EstadosGenericosNombre] AS EstadosSolNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosSolTipo AND [EstadosGenericosId] = @EstadosSolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00117,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00118", "SELECT TM1.[HistoricoSolicitudesID], TM1.[HistoricoSolicitudesNombre], TM1.[HistoricoSolicitudesTelefono], TM1.[HistoricoSolicitudesMail], TM1.[HistoricoPaisID], TM1.[HistoricoDepartamentoId], TM1.[HistoricoDepartamentoMunicipio], TM1.[HistoricoZonasID], TM1.[HistoricoSolicitudesDireccion], TM1.[HistoricoSolicitudesAutoEnumer], TM1.[HistoricoSolicitudesCotizacion], TM1.[HistoricoSolicitudServicioSolC], T2.[EstadosGenericosNombre] AS EstadosSolNombre, TM1.[HistoricoSolicitudesOtros1], TM1.[HistoricoSolicitudesOtros2], TM1.[HistoricoSolicitudesOtros3], TM1.[HistoricoSolicitudesFechaAlta], TM1.[HistoricoSolicitudesFechaActua], TM1.[HistoricoSolicitudesFechaInsta], TM1.[HistoricoSolicitudesHoraInstal], TM1.[HistoricoSolicitudesComentario], T3.[MetodoPagosNombre], TM1.[HistoricoSolicitudesNota], TM1.[HistoricoSolicitudesNotificaci], TM1.[HistoricoSolicitudesOrigenPago], TM1.[HistoricoSolicitudesPagado], TM1.[HistoricoSolicitudesComProv], TM1.[HistoricoSolicitudesComProvP], TM1.[HistoricoSolicitudesComALM], TM1.[HistoricoSolicitudesComALMP], TM1.[HistoricoSolicitudesNombreAux], TM1.[HistoricoSolicitudesSubTipo], TM1.[HistoricoSolicitudesProvID], TM1.[HistoricoSolicitudesProvNombre], TM1.[MetodoPagosID], TM1.[EstadosSolTipo] AS EstadosSolTipo, TM1.[EstadosSolId] AS EstadosSolId FROM (([HistoricoSolicitudes] TM1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = TM1.[EstadosSolTipo] AND T2.[EstadosGenericosId] = TM1.[EstadosSolId]) INNER JOIN [MetodoPagos] T3 ON T3.[MetodoPagosID] = TM1.[MetodoPagosID]) WHERE TM1.[HistoricoSolicitudesID] = @HistoricoSolicitudesID ORDER BY TM1.[HistoricoSolicitudesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00118,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00119", "SELECT [EstadosGenericosNombre] AS EstadosSolNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosSolTipo AND [EstadosGenericosId] = @EstadosSolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00119,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001110", "SELECT [MetodoPagosNombre] FROM [MetodoPagos] WHERE [MetodoPagosID] = @MetodoPagosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001110,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001111", "SELECT [HistoricoSolicitudesID] FROM [HistoricoSolicitudes] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001111,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001112", "SELECT TOP 1 [HistoricoSolicitudesID] FROM [HistoricoSolicitudes] WHERE ( [HistoricoSolicitudesID] > @HistoricoSolicitudesID) ORDER BY [HistoricoSolicitudesID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001112,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001113", "SELECT TOP 1 [HistoricoSolicitudesID] FROM [HistoricoSolicitudes] WHERE ( [HistoricoSolicitudesID] < @HistoricoSolicitudesID) ORDER BY [HistoricoSolicitudesID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001113,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001114", cmdBufferT001114, GxErrorMask.GX_NOMASK,prmT001114)
           ,new CursorDef("T001115", cmdBufferT001115, GxErrorMask.GX_NOMASK,prmT001115)
           ,new CursorDef("T001116", "DELETE FROM [HistoricoSolicitudes]  WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID", GxErrorMask.GX_NOMASK,prmT001116)
           ,new CursorDef("T001117", "SELECT [EstadosGenericosNombre] AS EstadosSolNombre FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosSolTipo AND [EstadosGenericosId] = @EstadosSolId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001117,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001118", "SELECT [MetodoPagosNombre] FROM [MetodoPagos] WHERE [MetodoPagosID] = @MetodoPagosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001118,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001119", "SELECT TOP 1 [HistoricoSolicitudesID], [HistoricoRelacionesId] FROM [HistoricoRelacionesRelaciones] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001119,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001120", "SELECT [HistoricoSolicitudesID] FROM [HistoricoSolicitudes] ORDER BY [HistoricoSolicitudesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001120,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001121", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID], [HItemsRubrosId], [HItemsRubrosNombre], [HItemsMedidasID], [HItemsInventarioId], [HItemsInventarioNombre], [HItemsInventarioPrecioFinal], [HItemsSolicitudesItemsCantidad], [HistoricoSolicitudesItemsSR], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsComis], [HItemsSolicitudesMonedaId] FROM [HistoricoSolicitudesItems] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID and [HistoricoSolicitudesItemsID] = @HistoricoSolicitudesItemsID ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001121,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001122", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID] FROM [HistoricoSolicitudesItems] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID AND [HistoricoSolicitudesItemsID] = @HistoricoSolicitudesItemsID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001122,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001123", "INSERT INTO [HistoricoSolicitudesItems]([HistoricoSolicitudesID], [HistoricoSolicitudesItemsID], [HItemsRubrosId], [HItemsRubrosNombre], [HItemsMedidasID], [HItemsInventarioId], [HItemsInventarioNombre], [HItemsInventarioPrecioFinal], [HItemsSolicitudesItemsCantidad], [HistoricoSolicitudesItemsSR], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsComis], [HItemsSolicitudesMonedaId]) VALUES(@HistoricoSolicitudesID, @HistoricoSolicitudesItemsID, @HItemsRubrosId, @HItemsRubrosNombre, @HItemsMedidasID, @HItemsInventarioId, @HItemsInventarioNombre, @HItemsInventarioPrecioFinal, @HItemsSolicitudesItemsCantidad, @HistoricoSolicitudesItemsSR, @HistoricoSolicitudesItemsCT, @HistoricoSolicitudesItemsComis, @HItemsSolicitudesMonedaId)", GxErrorMask.GX_NOMASK,prmT001123)
           ,new CursorDef("T001124", "UPDATE [HistoricoSolicitudesItems] SET [HItemsRubrosId]=@HItemsRubrosId, [HItemsRubrosNombre]=@HItemsRubrosNombre, [HItemsMedidasID]=@HItemsMedidasID, [HItemsInventarioId]=@HItemsInventarioId, [HItemsInventarioNombre]=@HItemsInventarioNombre, [HItemsInventarioPrecioFinal]=@HItemsInventarioPrecioFinal, [HItemsSolicitudesItemsCantidad]=@HItemsSolicitudesItemsCantidad, [HistoricoSolicitudesItemsSR]=@HistoricoSolicitudesItemsSR, [HistoricoSolicitudesItemsCT]=@HistoricoSolicitudesItemsCT, [HistoricoSolicitudesItemsComis]=@HistoricoSolicitudesItemsComis, [HItemsSolicitudesMonedaId]=@HItemsSolicitudesMonedaId  WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID AND [HistoricoSolicitudesItemsID] = @HistoricoSolicitudesItemsID", GxErrorMask.GX_NOMASK,prmT001124)
           ,new CursorDef("T001125", "DELETE FROM [HistoricoSolicitudesItems]  WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID AND [HistoricoSolicitudesItemsID] = @HistoricoSolicitudesItemsID", GxErrorMask.GX_NOMASK,prmT001125)
           ,new CursorDef("T001126", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID] FROM [HistoricoSolicitudesItems] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001126,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001127", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ORDER BY [HistoricoSolicitudesID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001127,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 1);
              ((string[]) buf[10])[0] = rslt.getString(11, 1);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 1);
              ((string[]) buf[10])[0] = rslt.getString(11, 1);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 2);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((long[]) buf[7])[0] = rslt.getLong(7);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((short[]) buf[11])[0] = rslt.getShort(10);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 1);
              ((string[]) buf[14])[0] = rslt.getString(13, 1);
              ((string[]) buf[15])[0] = rslt.getString(14, 1000);
              ((string[]) buf[16])[0] = rslt.getString(15, 500);
              ((DateTime[]) buf[17])[0] = rslt.getGXDate(16);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(17);
              ((DateTime[]) buf[19])[0] = rslt.getGXDate(18);
              ((string[]) buf[20])[0] = rslt.getString(19, 1);
              ((string[]) buf[21])[0] = rslt.getLongVarchar(20);
              ((string[]) buf[22])[0] = rslt.getString(21, 500);
              ((string[]) buf[23])[0] = rslt.getString(22, 1);
              ((string[]) buf[24])[0] = rslt.getString(23, 1);
              ((string[]) buf[25])[0] = rslt.getString(24, 1);
              ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
              ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
              ((string[]) buf[30])[0] = rslt.getString(29, 80);
              ((string[]) buf[31])[0] = rslt.getString(30, 1);
              ((long[]) buf[32])[0] = rslt.getLong(31);
              ((string[]) buf[33])[0] = rslt.getString(32, 120);
              ((long[]) buf[34])[0] = rslt.getLong(33);
              ((string[]) buf[35])[0] = rslt.getString(34, 3);
              ((int[]) buf[36])[0] = rslt.getInt(35);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 2);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((long[]) buf[7])[0] = rslt.getLong(7);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((short[]) buf[11])[0] = rslt.getShort(10);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 1);
              ((string[]) buf[14])[0] = rslt.getString(13, 1);
              ((string[]) buf[15])[0] = rslt.getString(14, 1000);
              ((string[]) buf[16])[0] = rslt.getString(15, 500);
              ((DateTime[]) buf[17])[0] = rslt.getGXDate(16);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(17);
              ((DateTime[]) buf[19])[0] = rslt.getGXDate(18);
              ((string[]) buf[20])[0] = rslt.getString(19, 1);
              ((string[]) buf[21])[0] = rslt.getLongVarchar(20);
              ((string[]) buf[22])[0] = rslt.getString(21, 500);
              ((string[]) buf[23])[0] = rslt.getString(22, 1);
              ((string[]) buf[24])[0] = rslt.getString(23, 1);
              ((string[]) buf[25])[0] = rslt.getString(24, 1);
              ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
              ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
              ((string[]) buf[30])[0] = rslt.getString(29, 80);
              ((string[]) buf[31])[0] = rslt.getString(30, 1);
              ((long[]) buf[32])[0] = rslt.getLong(31);
              ((string[]) buf[33])[0] = rslt.getString(32, 120);
              ((long[]) buf[34])[0] = rslt.getLong(33);
              ((string[]) buf[35])[0] = rslt.getString(34, 3);
              ((int[]) buf[36])[0] = rslt.getInt(35);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 2);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((long[]) buf[7])[0] = rslt.getLong(7);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((short[]) buf[11])[0] = rslt.getShort(10);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 1);
              ((string[]) buf[14])[0] = rslt.getString(13, 80);
              ((string[]) buf[15])[0] = rslt.getString(14, 1);
              ((string[]) buf[16])[0] = rslt.getString(15, 1000);
              ((string[]) buf[17])[0] = rslt.getString(16, 500);
              ((DateTime[]) buf[18])[0] = rslt.getGXDate(17);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(18);
              ((DateTime[]) buf[20])[0] = rslt.getGXDate(19);
              ((string[]) buf[21])[0] = rslt.getString(20, 1);
              ((string[]) buf[22])[0] = rslt.getLongVarchar(21);
              ((string[]) buf[23])[0] = rslt.getString(22, 80);
              ((string[]) buf[24])[0] = rslt.getString(23, 500);
              ((string[]) buf[25])[0] = rslt.getString(24, 1);
              ((string[]) buf[26])[0] = rslt.getString(25, 1);
              ((string[]) buf[27])[0] = rslt.getString(26, 1);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
              ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
              ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
              ((decimal[]) buf[31])[0] = rslt.getDecimal(30);
              ((string[]) buf[32])[0] = rslt.getString(31, 80);
              ((string[]) buf[33])[0] = rslt.getString(32, 1);
              ((long[]) buf[34])[0] = rslt.getLong(33);
              ((string[]) buf[35])[0] = rslt.getString(34, 120);
              ((long[]) buf[36])[0] = rslt.getLong(35);
              ((string[]) buf[37])[0] = rslt.getString(36, 3);
              ((int[]) buf[38])[0] = rslt.getInt(37);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
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
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 1);
              ((string[]) buf[10])[0] = rslt.getString(11, 1);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              return;
     }
  }

}

}

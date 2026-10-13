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
   public class estadosnotificacion : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A107EstadosTipo = GetPar( "EstadosTipo");
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A107EstadosTipo) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "estadosnotificacion.aspx")), "estadosnotificacion.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "estadosnotificacion.aspx")))) ;
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
                  AV7EstadosTipo = GetPar( "EstadosTipo");
                  AssignAttri("", false, "AV7EstadosTipo", AV7EstadosTipo);
                  GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7EstadosTipo, "")), context));
                  AV8EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV8EstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV8EstadosGenericosId), 5, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSGENERICOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8EstadosGenericosId), "ZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Estados Notificacion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public estadosnotificacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public estadosnotificacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_EstadosTipo ,
                           int aP2_EstadosGenericosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EstadosTipo = aP1_EstadosTipo;
         this.AV8EstadosGenericosId = aP2_EstadosGenericosId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkEstadosNotificacionCliente = new GXCheckbox();
         chkEstadosNotificacionProfesional = new GXCheckbox();
         chkEstadosNotificacionOperador = new GXCheckbox();
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
         A263EstadosNotificacionCliente = ((StringUtil.StrCmp(StringUtil.RTrim( A263EstadosNotificacionCliente), "S")==0) ? "S" : "N");
         AssignAttri("", false, "A263EstadosNotificacionCliente", A263EstadosNotificacionCliente);
         A264EstadosNotificacionProfesional = ((StringUtil.StrCmp(StringUtil.RTrim( A264EstadosNotificacionProfesional), "S")==0) ? "S" : "N");
         AssignAttri("", false, "A264EstadosNotificacionProfesional", A264EstadosNotificacionProfesional);
         A265EstadosNotificacionOperador = ((StringUtil.StrCmp(StringUtil.RTrim( A265EstadosNotificacionOperador), "S")==0) ? "S" : "N");
         AssignAttri("", false, "A265EstadosNotificacionOperador", A265EstadosNotificacionOperador);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadosTipo_Internalname, context.GetMessage( "Tipo de Estados", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo), StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosTipo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosTipo_Enabled, 1, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_EstadosNotificacion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_107_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_107_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_107_Internalname, sImgUrl, imgprompt_107_Link, "", "", context.GetTheme( ), imgprompt_107_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_EstadosNotificacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosGenericosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadosGenericosId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosGenericosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosGenericosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosGenericosId_Enabled, 1, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_EstadosNotificacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosGenericosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadosGenericosNombre_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosGenericosNombre_Internalname, StringUtil.RTrim( A109EstadosGenericosNombre), StringUtil.RTrim( context.localUtil.Format( A109EstadosGenericosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosGenericosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosGenericosNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_EstadosNotificacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkEstadosNotificacionCliente_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkEstadosNotificacionCliente_Internalname, context.GetMessage( "Notificar al cliente el nuevo estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkEstadosNotificacionCliente_Internalname, A263EstadosNotificacionCliente, "", context.GetMessage( "Notificar al cliente el nuevo estado", ""), 1, chkEstadosNotificacionCliente.Enabled, "S", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(37, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,37);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkEstadosNotificacionProfesional_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkEstadosNotificacionProfesional_Internalname, context.GetMessage( "Notificar al profesional el nuevo estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkEstadosNotificacionProfesional_Internalname, A264EstadosNotificacionProfesional, "", context.GetMessage( "Notificar al profesional el nuevo estado", ""), 1, chkEstadosNotificacionProfesional.Enabled, "S", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(42, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,42);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkEstadosNotificacionOperador_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkEstadosNotificacionOperador_Internalname, context.GetMessage( "Notificar al operador el nuevo estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkEstadosNotificacionOperador_Internalname, A265EstadosNotificacionOperador, "", context.GetMessage( "Notificar al operador el nuevo estado", ""), 1, chkEstadosNotificacionOperador.Enabled, "S", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(47, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,47);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadosNotificacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadosNotificacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadosNotificacion.htm");
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
         E11182 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z107EstadosTipo = cgiGet( "Z107EstadosTipo");
               Z108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z108EstadosGenericosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z109EstadosGenericosNombre = cgiGet( "Z109EstadosGenericosNombre");
               Z263EstadosNotificacionCliente = cgiGet( "Z263EstadosNotificacionCliente");
               Z264EstadosNotificacionProfesional = cgiGet( "Z264EstadosNotificacionProfesional");
               Z265EstadosNotificacionOperador = cgiGet( "Z265EstadosNotificacionOperador");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7EstadosTipo = cgiGet( "vESTADOSTIPO");
               AV8EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vESTADOSGENERICOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV15Pgmname = cgiGet( "vPGMNAME");
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
               A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
               AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESTADOSGENERICOSID");
                  AnyError = 1;
                  GX_FocusControl = edtEstadosGenericosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A108EstadosGenericosId = 0;
                  AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
               }
               else
               {
                  A108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
               }
               A109EstadosGenericosNombre = cgiGet( edtEstadosGenericosNombre_Internalname);
               AssignAttri("", false, "A109EstadosGenericosNombre", A109EstadosGenericosNombre);
               A263EstadosNotificacionCliente = ((StringUtil.StrCmp(cgiGet( chkEstadosNotificacionCliente_Internalname), "S")==0) ? "S" : "N");
               AssignAttri("", false, "A263EstadosNotificacionCliente", A263EstadosNotificacionCliente);
               A264EstadosNotificacionProfesional = ((StringUtil.StrCmp(cgiGet( chkEstadosNotificacionProfesional_Internalname), "S")==0) ? "S" : "N");
               AssignAttri("", false, "A264EstadosNotificacionProfesional", A264EstadosNotificacionProfesional);
               A265EstadosNotificacionOperador = ((StringUtil.StrCmp(cgiGet( chkEstadosNotificacionOperador_Internalname), "S")==0) ? "S" : "N");
               AssignAttri("", false, "A265EstadosNotificacionOperador", A265EstadosNotificacionOperador);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"EstadosNotificacion");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A107EstadosTipo, Z107EstadosTipo) != 0 ) || ( A108EstadosGenericosId != Z108EstadosGenericosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("estadosnotificacion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A107EstadosTipo = GetPar( "EstadosTipo");
                  AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
                  A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
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
                     sMode24 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode24;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound24 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_180( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ESTADOSTIPO");
                        AnyError = 1;
                        GX_FocusControl = edtEstadosTipo_Internalname;
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
                           E11182 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12182 ();
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
            E12182 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1824( ) ;
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
            DisableAttributes1824( ) ;
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

      protected void CONFIRM_180( )
      {
         BeforeValidate1824( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1824( ) ;
            }
            else
            {
               CheckExtendedTable1824( ) ;
               CloseExtendedTableCursors1824( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption180( )
      {
      }

      protected void E11182( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10IsAuthorized = true;
         AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion_Insert", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion_Update", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV10IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWEstadosNotificacion_Delete", out  GXt_boolean1) ;
            AV10IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV10IsAuthorized", AV10IsAuthorized);
         }
         if ( ! AV10IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV15Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12182( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("estadosnotificacionww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1824( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z109EstadosGenericosNombre = T00183_A109EstadosGenericosNombre[0];
               Z263EstadosNotificacionCliente = T00183_A263EstadosNotificacionCliente[0];
               Z264EstadosNotificacionProfesional = T00183_A264EstadosNotificacionProfesional[0];
               Z265EstadosNotificacionOperador = T00183_A265EstadosNotificacionOperador[0];
            }
            else
            {
               Z109EstadosGenericosNombre = A109EstadosGenericosNombre;
               Z263EstadosNotificacionCliente = A263EstadosNotificacionCliente;
               Z264EstadosNotificacionProfesional = A264EstadosNotificacionProfesional;
               Z265EstadosNotificacionOperador = A265EstadosNotificacionOperador;
            }
         }
         if ( GX_JID == -10 )
         {
            Z108EstadosGenericosId = A108EstadosGenericosId;
            Z109EstadosGenericosNombre = A109EstadosGenericosNombre;
            Z263EstadosNotificacionCliente = A263EstadosNotificacionCliente;
            Z264EstadosNotificacionProfesional = A264EstadosNotificacionProfesional;
            Z265EstadosNotificacionOperador = A265EstadosNotificacionOperador;
            Z107EstadosTipo = A107EstadosTipo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_107_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00n0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESTADOSTIPO"+"'), id:'"+"ESTADOSTIPO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"true"+");");
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7EstadosTipo)) )
         {
            A107EstadosTipo = AV7EstadosTipo;
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7EstadosTipo)) )
         {
            edtEstadosTipo_Enabled = 0;
            AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         }
         else
         {
            edtEstadosTipo_Enabled = 1;
            AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7EstadosTipo)) )
         {
            edtEstadosTipo_Enabled = 0;
            AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8EstadosGenericosId) )
         {
            A108EstadosGenericosId = AV8EstadosGenericosId;
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         }
         if ( ! (0==AV8EstadosGenericosId) )
         {
            edtEstadosGenericosId_Enabled = 0;
            AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), true);
         }
         else
         {
            edtEstadosGenericosId_Enabled = 1;
            AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8EstadosGenericosId) )
         {
            edtEstadosGenericosId_Enabled = 0;
            AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), true);
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A263EstadosNotificacionCliente)) && ( Gx_BScreen == 0 ) )
         {
            A263EstadosNotificacionCliente = context.GetMessage( context.GetMessage( "N", ""), "");
            AssignAttri("", false, "A263EstadosNotificacionCliente", A263EstadosNotificacionCliente);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A264EstadosNotificacionProfesional)) && ( Gx_BScreen == 0 ) )
         {
            A264EstadosNotificacionProfesional = context.GetMessage( context.GetMessage( "N", ""), "");
            AssignAttri("", false, "A264EstadosNotificacionProfesional", A264EstadosNotificacionProfesional);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A265EstadosNotificacionOperador)) && ( Gx_BScreen == 0 ) )
         {
            A265EstadosNotificacionOperador = context.GetMessage( context.GetMessage( "N", ""), "");
            AssignAttri("", false, "A265EstadosNotificacionOperador", A265EstadosNotificacionOperador);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV15Pgmname = "EstadosNotificacion";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         }
      }

      protected void Load1824( )
      {
         /* Using cursor T00185 */
         pr_default.execute(3, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound24 = 1;
            A109EstadosGenericosNombre = T00185_A109EstadosGenericosNombre[0];
            AssignAttri("", false, "A109EstadosGenericosNombre", A109EstadosGenericosNombre);
            A263EstadosNotificacionCliente = T00185_A263EstadosNotificacionCliente[0];
            AssignAttri("", false, "A263EstadosNotificacionCliente", A263EstadosNotificacionCliente);
            A264EstadosNotificacionProfesional = T00185_A264EstadosNotificacionProfesional[0];
            AssignAttri("", false, "A264EstadosNotificacionProfesional", A264EstadosNotificacionProfesional);
            A265EstadosNotificacionOperador = T00185_A265EstadosNotificacionOperador[0];
            AssignAttri("", false, "A265EstadosNotificacionOperador", A265EstadosNotificacionOperador);
            ZM1824( -10) ;
         }
         pr_default.close(3);
         OnLoadActions1824( ) ;
      }

      protected void OnLoadActions1824( )
      {
         AV15Pgmname = "EstadosNotificacion";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable1824( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV15Pgmname = "EstadosNotificacion";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         /* Using cursor T00184 */
         pr_default.execute(2, new Object[] {A107EstadosTipo});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSTIPO");
            AnyError = 1;
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1824( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_11( string A107EstadosTipo )
      {
         /* Using cursor T00186 */
         pr_default.execute(4, new Object[] {A107EstadosTipo});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSTIPO");
            AnyError = 1;
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1824( )
      {
         /* Using cursor T00187 */
         pr_default.execute(5, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00183 */
         pr_default.execute(1, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1824( 10) ;
            RcdFound24 = 1;
            A108EstadosGenericosId = T00183_A108EstadosGenericosId[0];
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            A109EstadosGenericosNombre = T00183_A109EstadosGenericosNombre[0];
            AssignAttri("", false, "A109EstadosGenericosNombre", A109EstadosGenericosNombre);
            A263EstadosNotificacionCliente = T00183_A263EstadosNotificacionCliente[0];
            AssignAttri("", false, "A263EstadosNotificacionCliente", A263EstadosNotificacionCliente);
            A264EstadosNotificacionProfesional = T00183_A264EstadosNotificacionProfesional[0];
            AssignAttri("", false, "A264EstadosNotificacionProfesional", A264EstadosNotificacionProfesional);
            A265EstadosNotificacionOperador = T00183_A265EstadosNotificacionOperador[0];
            AssignAttri("", false, "A265EstadosNotificacionOperador", A265EstadosNotificacionOperador);
            A107EstadosTipo = T00183_A107EstadosTipo[0];
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1824( ) ;
            if ( AnyError == 1 )
            {
               RcdFound24 = 0;
               InitializeNonKey1824( ) ;
            }
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey1824( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1824( ) ;
         if ( RcdFound24 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound24 = 0;
         /* Using cursor T00188 */
         pr_default.execute(6, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00188_A107EstadosTipo[0], A107EstadosTipo) < 0 ) || ( StringUtil.StrCmp(T00188_A107EstadosTipo[0], A107EstadosTipo) == 0 ) && ( T00188_A108EstadosGenericosId[0] < A108EstadosGenericosId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00188_A107EstadosTipo[0], A107EstadosTipo) > 0 ) || ( StringUtil.StrCmp(T00188_A107EstadosTipo[0], A107EstadosTipo) == 0 ) && ( T00188_A108EstadosGenericosId[0] > A108EstadosGenericosId ) ) )
            {
               A107EstadosTipo = T00188_A107EstadosTipo[0];
               AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
               A108EstadosGenericosId = T00188_A108EstadosGenericosId[0];
               AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
               RcdFound24 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound24 = 0;
         /* Using cursor T00189 */
         pr_default.execute(7, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00189_A107EstadosTipo[0], A107EstadosTipo) > 0 ) || ( StringUtil.StrCmp(T00189_A107EstadosTipo[0], A107EstadosTipo) == 0 ) && ( T00189_A108EstadosGenericosId[0] > A108EstadosGenericosId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00189_A107EstadosTipo[0], A107EstadosTipo) < 0 ) || ( StringUtil.StrCmp(T00189_A107EstadosTipo[0], A107EstadosTipo) == 0 ) && ( T00189_A108EstadosGenericosId[0] < A108EstadosGenericosId ) ) )
            {
               A107EstadosTipo = T00189_A107EstadosTipo[0];
               AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
               A108EstadosGenericosId = T00189_A108EstadosGenericosId[0];
               AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
               RcdFound24 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1824( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1824( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound24 == 1 )
            {
               if ( ( StringUtil.StrCmp(A107EstadosTipo, Z107EstadosTipo) != 0 ) || ( A108EstadosGenericosId != Z108EstadosGenericosId ) )
               {
                  A107EstadosTipo = Z107EstadosTipo;
                  AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
                  A108EstadosGenericosId = Z108EstadosGenericosId;
                  AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ESTADOSTIPO");
                  AnyError = 1;
                  GX_FocusControl = edtEstadosTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEstadosTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1824( ) ;
                  GX_FocusControl = edtEstadosTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A107EstadosTipo, Z107EstadosTipo) != 0 ) || ( A108EstadosGenericosId != Z108EstadosGenericosId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtEstadosTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1824( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ESTADOSTIPO");
                     AnyError = 1;
                     GX_FocusControl = edtEstadosTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEstadosTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1824( ) ;
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
         if ( ( StringUtil.StrCmp(A107EstadosTipo, Z107EstadosTipo) != 0 ) || ( A108EstadosGenericosId != Z108EstadosGenericosId ) )
         {
            A107EstadosTipo = Z107EstadosTipo;
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            A108EstadosGenericosId = Z108EstadosGenericosId;
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ESTADOSTIPO");
            AnyError = 1;
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1824( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00182 */
            pr_default.execute(0, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EstadosGenericos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z109EstadosGenericosNombre, T00182_A109EstadosGenericosNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z263EstadosNotificacionCliente, T00182_A263EstadosNotificacionCliente[0]) != 0 ) || ( StringUtil.StrCmp(Z264EstadosNotificacionProfesional, T00182_A264EstadosNotificacionProfesional[0]) != 0 ) || ( StringUtil.StrCmp(Z265EstadosNotificacionOperador, T00182_A265EstadosNotificacionOperador[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z109EstadosGenericosNombre, T00182_A109EstadosGenericosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("estadosnotificacion:[seudo value changed for attri]"+"EstadosGenericosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z109EstadosGenericosNombre);
                  GXUtil.WriteLogRaw("Current: ",T00182_A109EstadosGenericosNombre[0]);
               }
               if ( StringUtil.StrCmp(Z263EstadosNotificacionCliente, T00182_A263EstadosNotificacionCliente[0]) != 0 )
               {
                  GXUtil.WriteLog("estadosnotificacion:[seudo value changed for attri]"+"EstadosNotificacionCliente");
                  GXUtil.WriteLogRaw("Old: ",Z263EstadosNotificacionCliente);
                  GXUtil.WriteLogRaw("Current: ",T00182_A263EstadosNotificacionCliente[0]);
               }
               if ( StringUtil.StrCmp(Z264EstadosNotificacionProfesional, T00182_A264EstadosNotificacionProfesional[0]) != 0 )
               {
                  GXUtil.WriteLog("estadosnotificacion:[seudo value changed for attri]"+"EstadosNotificacionProfesional");
                  GXUtil.WriteLogRaw("Old: ",Z264EstadosNotificacionProfesional);
                  GXUtil.WriteLogRaw("Current: ",T00182_A264EstadosNotificacionProfesional[0]);
               }
               if ( StringUtil.StrCmp(Z265EstadosNotificacionOperador, T00182_A265EstadosNotificacionOperador[0]) != 0 )
               {
                  GXUtil.WriteLog("estadosnotificacion:[seudo value changed for attri]"+"EstadosNotificacionOperador");
                  GXUtil.WriteLogRaw("Old: ",Z265EstadosNotificacionOperador);
                  GXUtil.WriteLogRaw("Current: ",T00182_A265EstadosNotificacionOperador[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EstadosGenericos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1824( )
      {
         BeforeValidate1824( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1824( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1824( 0) ;
            CheckOptimisticConcurrency1824( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1824( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1824( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001810 */
                     pr_default.execute(8, new Object[] {A108EstadosGenericosId, A109EstadosGenericosNombre, A263EstadosNotificacionCliente, A264EstadosNotificacionProfesional, A265EstadosNotificacionOperador, A107EstadosTipo});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("EstadosGenericos");
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
                           ResetCaption180( ) ;
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
               Load1824( ) ;
            }
            EndLevel1824( ) ;
         }
         CloseExtendedTableCursors1824( ) ;
      }

      protected void Update1824( )
      {
         BeforeValidate1824( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1824( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1824( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1824( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1824( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001811 */
                     pr_default.execute(9, new Object[] {A109EstadosGenericosNombre, A263EstadosNotificacionCliente, A264EstadosNotificacionProfesional, A265EstadosNotificacionOperador, A107EstadosTipo, A108EstadosGenericosId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("EstadosGenericos");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EstadosGenericos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1824( ) ;
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
            EndLevel1824( ) ;
         }
         CloseExtendedTableCursors1824( ) ;
      }

      protected void DeferredUpdate1824( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1824( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1824( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1824( ) ;
            AfterConfirm1824( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1824( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001812 */
                  pr_default.execute(10, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("EstadosGenericos");
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
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1824( ) ;
         Gx_mode = sMode24;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1824( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "EstadosNotificacion";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001813 */
            pr_default.execute(11, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T001814 */
            pr_default.execute(12, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T001815 */
            pr_default.execute(13, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Historico Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T001816 */
            pr_default.execute(14, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T001817 */
            pr_default.execute(15, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T001818 */
            pr_default.execute(16, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Metodo Pagos", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T001819 */
            pr_default.execute(17, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T001820 */
            pr_default.execute(18, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Inventario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel1824( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1824( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("estadosnotificacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues180( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("estadosnotificacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1824( )
      {
         /* Scan By routine */
         /* Using cursor T001821 */
         pr_default.execute(19);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound24 = 1;
            A107EstadosTipo = T001821_A107EstadosTipo[0];
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            A108EstadosGenericosId = T001821_A108EstadosGenericosId[0];
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1824( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound24 = 1;
            A107EstadosTipo = T001821_A107EstadosTipo[0];
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            A108EstadosGenericosId = T001821_A108EstadosGenericosId[0];
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         }
      }

      protected void ScanEnd1824( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm1824( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1824( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1824( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1824( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1824( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1824( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1824( )
      {
         edtEstadosTipo_Enabled = 0;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         edtEstadosGenericosId_Enabled = 0;
         AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), true);
         edtEstadosGenericosNombre_Enabled = 0;
         AssignProp("", false, edtEstadosGenericosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0), true);
         chkEstadosNotificacionCliente.Enabled = 0;
         AssignProp("", false, chkEstadosNotificacionCliente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEstadosNotificacionCliente.Enabled), 5, 0), true);
         chkEstadosNotificacionProfesional.Enabled = 0;
         AssignProp("", false, chkEstadosNotificacionProfesional_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEstadosNotificacionProfesional.Enabled), 5, 0), true);
         chkEstadosNotificacionOperador.Enabled = 0;
         AssignProp("", false, chkEstadosNotificacionOperador_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEstadosNotificacionOperador.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1824( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues180( )
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
         GXEncryptionTmp = "estadosnotificacion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV8EstadosGenericosId,5,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("estadosnotificacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"EstadosNotificacion");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("estadosnotificacion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z107EstadosTipo", StringUtil.RTrim( Z107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "Z108EstadosGenericosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z109EstadosGenericosNombre", StringUtil.RTrim( Z109EstadosGenericosNombre));
         GxWebStd.gx_hidden_field( context, "Z263EstadosNotificacionCliente", StringUtil.RTrim( Z263EstadosNotificacionCliente));
         GxWebStd.gx_hidden_field( context, "Z264EstadosNotificacionProfesional", StringUtil.RTrim( Z264EstadosNotificacionProfesional));
         GxWebStd.gx_hidden_field( context, "Z265EstadosNotificacionOperador", StringUtil.RTrim( Z265EstadosNotificacionOperador));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vESTADOSTIPO", StringUtil.RTrim( AV7EstadosTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7EstadosTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "vESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOSGENERICOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8EstadosGenericosId), "ZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
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
         GXEncryptionTmp = "estadosnotificacion.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7EstadosTipo)) + "," + UrlEncode(StringUtil.LTrimStr(AV8EstadosGenericosId,5,0));
         return formatLink("estadosnotificacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "EstadosNotificacion" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Estados Notificacion", "") ;
      }

      protected void InitializeNonKey1824( )
      {
         A109EstadosGenericosNombre = "";
         AssignAttri("", false, "A109EstadosGenericosNombre", A109EstadosGenericosNombre);
         A263EstadosNotificacionCliente = context.GetMessage( "N", "");
         AssignAttri("", false, "A263EstadosNotificacionCliente", A263EstadosNotificacionCliente);
         A264EstadosNotificacionProfesional = context.GetMessage( "N", "");
         AssignAttri("", false, "A264EstadosNotificacionProfesional", A264EstadosNotificacionProfesional);
         A265EstadosNotificacionOperador = context.GetMessage( "N", "");
         AssignAttri("", false, "A265EstadosNotificacionOperador", A265EstadosNotificacionOperador);
         Z109EstadosGenericosNombre = "";
         Z263EstadosNotificacionCliente = "";
         Z264EstadosNotificacionProfesional = "";
         Z265EstadosNotificacionOperador = "";
      }

      protected void InitAll1824( )
      {
         A107EstadosTipo = "";
         AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         A108EstadosGenericosId = 0;
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         InitializeNonKey1824( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A263EstadosNotificacionCliente = i263EstadosNotificacionCliente;
         AssignAttri("", false, "A263EstadosNotificacionCliente", A263EstadosNotificacionCliente);
         A264EstadosNotificacionProfesional = i264EstadosNotificacionProfesional;
         AssignAttri("", false, "A264EstadosNotificacionProfesional", A264EstadosNotificacionProfesional);
         A265EstadosNotificacionOperador = i265EstadosNotificacionOperador;
         AssignAttri("", false, "A265EstadosNotificacionOperador", A265EstadosNotificacionOperador);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021113678", true, true, false);
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
         context.AddJavascriptSource("estadosnotificacion.js", "?202673021113678", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtEstadosTipo_Internalname = "ESTADOSTIPO";
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID";
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE";
         chkEstadosNotificacionCliente_Internalname = "ESTADOSNOTIFICACIONCLIENTE";
         chkEstadosNotificacionProfesional_Internalname = "ESTADOSNOTIFICACIONPROFESIONAL";
         chkEstadosNotificacionOperador_Internalname = "ESTADOSNOTIFICACIONOPERADOR";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_107_Internalname = "PROMPT_107";
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
         Form.Caption = context.GetMessage( "Estados Notificacion", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkEstadosNotificacionOperador.Enabled = 1;
         chkEstadosNotificacionProfesional.Enabled = 1;
         chkEstadosNotificacionCliente.Enabled = 1;
         edtEstadosGenericosNombre_Jsonclick = "";
         edtEstadosGenericosNombre_Enabled = 1;
         edtEstadosGenericosId_Jsonclick = "";
         edtEstadosGenericosId_Enabled = 1;
         imgprompt_107_Visible = 1;
         imgprompt_107_Link = "";
         edtEstadosTipo_Jsonclick = "";
         edtEstadosTipo_Enabled = 1;
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
         chkEstadosNotificacionCliente.Name = "ESTADOSNOTIFICACIONCLIENTE";
         chkEstadosNotificacionCliente.WebTags = "";
         chkEstadosNotificacionCliente.Caption = context.GetMessage( "Notificar al cliente el nuevo estado", "");
         AssignProp("", false, chkEstadosNotificacionCliente_Internalname, "TitleCaption", chkEstadosNotificacionCliente.Caption, true);
         chkEstadosNotificacionCliente.CheckedValue = "N";
         if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A263EstadosNotificacionCliente)) )
         {
            A263EstadosNotificacionCliente = context.GetMessage( "N", "");
            AssignAttri("", false, "A263EstadosNotificacionCliente", A263EstadosNotificacionCliente);
         }
         chkEstadosNotificacionProfesional.Name = "ESTADOSNOTIFICACIONPROFESIONAL";
         chkEstadosNotificacionProfesional.WebTags = "";
         chkEstadosNotificacionProfesional.Caption = context.GetMessage( "Notificar al profesional el nuevo estado", "");
         AssignProp("", false, chkEstadosNotificacionProfesional_Internalname, "TitleCaption", chkEstadosNotificacionProfesional.Caption, true);
         chkEstadosNotificacionProfesional.CheckedValue = "N";
         if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A264EstadosNotificacionProfesional)) )
         {
            A264EstadosNotificacionProfesional = context.GetMessage( "N", "");
            AssignAttri("", false, "A264EstadosNotificacionProfesional", A264EstadosNotificacionProfesional);
         }
         chkEstadosNotificacionOperador.Name = "ESTADOSNOTIFICACIONOPERADOR";
         chkEstadosNotificacionOperador.WebTags = "";
         chkEstadosNotificacionOperador.Caption = context.GetMessage( "Notificar al operador el nuevo estado", "");
         AssignProp("", false, chkEstadosNotificacionOperador_Internalname, "TitleCaption", chkEstadosNotificacionOperador.Caption, true);
         chkEstadosNotificacionOperador.CheckedValue = "N";
         if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A265EstadosNotificacionOperador)) )
         {
            A265EstadosNotificacionOperador = context.GetMessage( "N", "");
            AssignAttri("", false, "A265EstadosNotificacionOperador", A265EstadosNotificacionOperador);
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

      public void Valid_Estadostipo( )
      {
         /* Using cursor T001822 */
         pr_default.execute(20, new Object[] {A107EstadosTipo});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSTIPO");
            AnyError = 1;
            GX_FocusControl = edtEstadosTipo_Internalname;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7EstadosTipo',fld:'vESTADOSTIPO',pic:'',hsh:true,type:'char'},{av:'AV8EstadosGenericosId',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',hsh:true,type:'int'},{av:'A263EstadosNotificacionCliente',fld:'ESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'A264EstadosNotificacionProfesional',fld:'ESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'A265EstadosNotificacionOperador',fld:'ESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A263EstadosNotificacionCliente',fld:'ESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'A264EstadosNotificacionProfesional',fld:'ESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'A265EstadosNotificacionOperador',fld:'ESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7EstadosTipo',fld:'vESTADOSTIPO',pic:'',hsh:true,type:'char'},{av:'AV8EstadosGenericosId',fld:'vESTADOSGENERICOSID',pic:'ZZZZ9',hsh:true,type:'int'},{av:'A263EstadosNotificacionCliente',fld:'ESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'A264EstadosNotificacionProfesional',fld:'ESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'A265EstadosNotificacionOperador',fld:'ESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A263EstadosNotificacionCliente',fld:'ESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'A264EstadosNotificacionProfesional',fld:'ESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'A265EstadosNotificacionOperador',fld:'ESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12182',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A263EstadosNotificacionCliente',fld:'ESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'A264EstadosNotificacionProfesional',fld:'ESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'A265EstadosNotificacionOperador',fld:'ESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A263EstadosNotificacionCliente',fld:'ESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'A264EstadosNotificacionProfesional',fld:'ESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'A265EstadosNotificacionOperador',fld:'ESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]}");
         setEventMetadata("VALID_ESTADOSTIPO","{handler:'Valid_Estadostipo',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A263EstadosNotificacionCliente',fld:'ESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'A264EstadosNotificacionProfesional',fld:'ESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'A265EstadosNotificacionOperador',fld:'ESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]");
         setEventMetadata("VALID_ESTADOSTIPO",",oparms:[{av:'A263EstadosNotificacionCliente',fld:'ESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'A264EstadosNotificacionProfesional',fld:'ESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'A265EstadosNotificacionOperador',fld:'ESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]}");
         setEventMetadata("VALID_ESTADOSGENERICOSID","{handler:'Valid_Estadosgenericosid',iparms:[{av:'A263EstadosNotificacionCliente',fld:'ESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'A264EstadosNotificacionProfesional',fld:'ESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'A265EstadosNotificacionOperador',fld:'ESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]");
         setEventMetadata("VALID_ESTADOSGENERICOSID",",oparms:[{av:'A263EstadosNotificacionCliente',fld:'ESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'A264EstadosNotificacionProfesional',fld:'ESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'A265EstadosNotificacionOperador',fld:'ESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]}");
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
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7EstadosTipo = "";
         Z107EstadosTipo = "";
         Z109EstadosGenericosNombre = "";
         Z263EstadosNotificacionCliente = "";
         Z264EstadosNotificacionProfesional = "";
         Z265EstadosNotificacionOperador = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A107EstadosTipo = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A263EstadosNotificacionCliente = "";
         A264EstadosNotificacionProfesional = "";
         A265EstadosNotificacionOperador = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         imgprompt_107_gximage = "";
         sImgUrl = "";
         A109EstadosGenericosNombre = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV15Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode24 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         T00185_A108EstadosGenericosId = new int[1] ;
         T00185_A109EstadosGenericosNombre = new string[] {""} ;
         T00185_A263EstadosNotificacionCliente = new string[] {""} ;
         T00185_A264EstadosNotificacionProfesional = new string[] {""} ;
         T00185_A265EstadosNotificacionOperador = new string[] {""} ;
         T00185_A107EstadosTipo = new string[] {""} ;
         T00184_A107EstadosTipo = new string[] {""} ;
         T00186_A107EstadosTipo = new string[] {""} ;
         T00187_A107EstadosTipo = new string[] {""} ;
         T00187_A108EstadosGenericosId = new int[1] ;
         T00183_A108EstadosGenericosId = new int[1] ;
         T00183_A109EstadosGenericosNombre = new string[] {""} ;
         T00183_A263EstadosNotificacionCliente = new string[] {""} ;
         T00183_A264EstadosNotificacionProfesional = new string[] {""} ;
         T00183_A265EstadosNotificacionOperador = new string[] {""} ;
         T00183_A107EstadosTipo = new string[] {""} ;
         T00188_A107EstadosTipo = new string[] {""} ;
         T00188_A108EstadosGenericosId = new int[1] ;
         T00189_A107EstadosTipo = new string[] {""} ;
         T00189_A108EstadosGenericosId = new int[1] ;
         T00182_A108EstadosGenericosId = new int[1] ;
         T00182_A109EstadosGenericosNombre = new string[] {""} ;
         T00182_A263EstadosNotificacionCliente = new string[] {""} ;
         T00182_A264EstadosNotificacionProfesional = new string[] {""} ;
         T00182_A265EstadosNotificacionOperador = new string[] {""} ;
         T00182_A107EstadosTipo = new string[] {""} ;
         T001813_A153HistoricoSolicitudesID = new long[1] ;
         T001813_A156HistoricoRelacionesId = new long[1] ;
         T001814_A127SolicitudesID = new long[1] ;
         T001814_A140RelacionesId = new long[1] ;
         T001815_A153HistoricoSolicitudesID = new long[1] ;
         T001816_A127SolicitudesID = new long[1] ;
         T001817_A120ProfesionalesId = new string[] {""} ;
         T001817_A121RubrosId = new short[1] ;
         T001818_A128MetodoPagosID = new long[1] ;
         T001819_A120ProfesionalesId = new string[] {""} ;
         T001820_A121RubrosId = new short[1] ;
         T001820_A137MedidasID = new long[1] ;
         T001820_A135InventarioId = new long[1] ;
         T001821_A107EstadosTipo = new string[] {""} ;
         T001821_A108EstadosGenericosId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i263EstadosNotificacionCliente = "";
         i264EstadosNotificacionProfesional = "";
         i265EstadosNotificacionOperador = "";
         T001822_A107EstadosTipo = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.estadosnotificacion__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadosnotificacion__default(),
            new Object[][] {
                new Object[] {
               T00182_A108EstadosGenericosId, T00182_A109EstadosGenericosNombre, T00182_A263EstadosNotificacionCliente, T00182_A264EstadosNotificacionProfesional, T00182_A265EstadosNotificacionOperador, T00182_A107EstadosTipo
               }
               , new Object[] {
               T00183_A108EstadosGenericosId, T00183_A109EstadosGenericosNombre, T00183_A263EstadosNotificacionCliente, T00183_A264EstadosNotificacionProfesional, T00183_A265EstadosNotificacionOperador, T00183_A107EstadosTipo
               }
               , new Object[] {
               T00184_A107EstadosTipo
               }
               , new Object[] {
               T00185_A108EstadosGenericosId, T00185_A109EstadosGenericosNombre, T00185_A263EstadosNotificacionCliente, T00185_A264EstadosNotificacionProfesional, T00185_A265EstadosNotificacionOperador, T00185_A107EstadosTipo
               }
               , new Object[] {
               T00186_A107EstadosTipo
               }
               , new Object[] {
               T00187_A107EstadosTipo, T00187_A108EstadosGenericosId
               }
               , new Object[] {
               T00188_A107EstadosTipo, T00188_A108EstadosGenericosId
               }
               , new Object[] {
               T00189_A107EstadosTipo, T00189_A108EstadosGenericosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001813_A153HistoricoSolicitudesID, T001813_A156HistoricoRelacionesId
               }
               , new Object[] {
               T001814_A127SolicitudesID, T001814_A140RelacionesId
               }
               , new Object[] {
               T001815_A153HistoricoSolicitudesID
               }
               , new Object[] {
               T001816_A127SolicitudesID
               }
               , new Object[] {
               T001817_A120ProfesionalesId, T001817_A121RubrosId
               }
               , new Object[] {
               T001818_A128MetodoPagosID
               }
               , new Object[] {
               T001819_A120ProfesionalesId
               }
               , new Object[] {
               T001820_A121RubrosId, T001820_A137MedidasID, T001820_A135InventarioId
               }
               , new Object[] {
               T001821_A107EstadosTipo, T001821_A108EstadosGenericosId
               }
               , new Object[] {
               T001822_A107EstadosTipo
               }
            }
         );
         AV15Pgmname = "EstadosNotificacion";
         Z265EstadosNotificacionOperador = context.GetMessage( "N", "");
         A265EstadosNotificacionOperador = context.GetMessage( "N", "");
         i265EstadosNotificacionOperador = context.GetMessage( "N", "");
         Z264EstadosNotificacionProfesional = context.GetMessage( "N", "");
         A264EstadosNotificacionProfesional = context.GetMessage( "N", "");
         i264EstadosNotificacionProfesional = context.GetMessage( "N", "");
         Z263EstadosNotificacionCliente = context.GetMessage( "N", "");
         A263EstadosNotificacionCliente = context.GetMessage( "N", "");
         i263EstadosNotificacionCliente = context.GetMessage( "N", "");
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound24 ;
      private short gxajaxcallmode ;
      private int wcpOAV8EstadosGenericosId ;
      private int Z108EstadosGenericosId ;
      private int AV8EstadosGenericosId ;
      private int trnEnded ;
      private int edtEstadosTipo_Enabled ;
      private int imgprompt_107_Visible ;
      private int A108EstadosGenericosId ;
      private int edtEstadosGenericosId_Enabled ;
      private int edtEstadosGenericosNombre_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7EstadosTipo ;
      private string Z107EstadosTipo ;
      private string Z109EstadosGenericosNombre ;
      private string Z263EstadosNotificacionCliente ;
      private string Z264EstadosNotificacionProfesional ;
      private string Z265EstadosNotificacionOperador ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A107EstadosTipo ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7EstadosTipo ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEstadosTipo_Internalname ;
      private string A263EstadosNotificacionCliente ;
      private string A264EstadosNotificacionProfesional ;
      private string A265EstadosNotificacionOperador ;
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
      private string edtEstadosTipo_Jsonclick ;
      private string imgprompt_107_gximage ;
      private string sImgUrl ;
      private string imgprompt_107_Internalname ;
      private string imgprompt_107_Link ;
      private string edtEstadosGenericosId_Internalname ;
      private string edtEstadosGenericosId_Jsonclick ;
      private string edtEstadosGenericosNombre_Internalname ;
      private string A109EstadosGenericosNombre ;
      private string edtEstadosGenericosNombre_Jsonclick ;
      private string chkEstadosNotificacionCliente_Internalname ;
      private string chkEstadosNotificacionProfesional_Internalname ;
      private string chkEstadosNotificacionOperador_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV15Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode24 ;
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
      private string i263EstadosNotificacionCliente ;
      private string i264EstadosNotificacionProfesional ;
      private string i265EstadosNotificacionOperador ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV10IsAuthorized ;
      private bool GXt_boolean1 ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkEstadosNotificacionCliente ;
      private GXCheckbox chkEstadosNotificacionProfesional ;
      private GXCheckbox chkEstadosNotificacionOperador ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] T00185_A108EstadosGenericosId ;
      private string[] T00185_A109EstadosGenericosNombre ;
      private string[] T00185_A263EstadosNotificacionCliente ;
      private string[] T00185_A264EstadosNotificacionProfesional ;
      private string[] T00185_A265EstadosNotificacionOperador ;
      private string[] T00185_A107EstadosTipo ;
      private string[] T00184_A107EstadosTipo ;
      private string[] T00186_A107EstadosTipo ;
      private string[] T00187_A107EstadosTipo ;
      private int[] T00187_A108EstadosGenericosId ;
      private int[] T00183_A108EstadosGenericosId ;
      private string[] T00183_A109EstadosGenericosNombre ;
      private string[] T00183_A263EstadosNotificacionCliente ;
      private string[] T00183_A264EstadosNotificacionProfesional ;
      private string[] T00183_A265EstadosNotificacionOperador ;
      private string[] T00183_A107EstadosTipo ;
      private string[] T00188_A107EstadosTipo ;
      private int[] T00188_A108EstadosGenericosId ;
      private string[] T00189_A107EstadosTipo ;
      private int[] T00189_A108EstadosGenericosId ;
      private int[] T00182_A108EstadosGenericosId ;
      private string[] T00182_A109EstadosGenericosNombre ;
      private string[] T00182_A263EstadosNotificacionCliente ;
      private string[] T00182_A264EstadosNotificacionProfesional ;
      private string[] T00182_A265EstadosNotificacionOperador ;
      private string[] T00182_A107EstadosTipo ;
      private long[] T001813_A153HistoricoSolicitudesID ;
      private long[] T001813_A156HistoricoRelacionesId ;
      private long[] T001814_A127SolicitudesID ;
      private long[] T001814_A140RelacionesId ;
      private long[] T001815_A153HistoricoSolicitudesID ;
      private long[] T001816_A127SolicitudesID ;
      private string[] T001817_A120ProfesionalesId ;
      private short[] T001817_A121RubrosId ;
      private long[] T001818_A128MetodoPagosID ;
      private string[] T001819_A120ProfesionalesId ;
      private short[] T001820_A121RubrosId ;
      private long[] T001820_A137MedidasID ;
      private long[] T001820_A135InventarioId ;
      private string[] T001821_A107EstadosTipo ;
      private int[] T001821_A108EstadosGenericosId ;
      private string[] T001822_A107EstadosTipo ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class estadosnotificacion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class estadosnotificacion__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00182;
        prmT00182 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT00183;
        prmT00183 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT00184;
        prmT00184 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT00185;
        prmT00185 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT00186;
        prmT00186 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT00187;
        prmT00187 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT00188;
        prmT00188 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT00189;
        prmT00189 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001810;
        prmT001810 = new Object[] {
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
        new ParDef("@EstadosGenericosNombre",GXType.NChar,80,0) ,
        new ParDef("@EstadosNotificacionCliente",GXType.NChar,1,0) ,
        new ParDef("@EstadosNotificacionProfesional",GXType.NChar,1,0) ,
        new ParDef("@EstadosNotificacionOperador",GXType.NChar,1,0) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT001811;
        prmT001811 = new Object[] {
        new ParDef("@EstadosGenericosNombre",GXType.NChar,80,0) ,
        new ParDef("@EstadosNotificacionCliente",GXType.NChar,1,0) ,
        new ParDef("@EstadosNotificacionProfesional",GXType.NChar,1,0) ,
        new ParDef("@EstadosNotificacionOperador",GXType.NChar,1,0) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001812;
        prmT001812 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001813;
        prmT001813 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001814;
        prmT001814 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001815;
        prmT001815 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001816;
        prmT001816 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001817;
        prmT001817 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001818;
        prmT001818 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001819;
        prmT001819 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001820;
        prmT001820 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001821;
        prmT001821 = new Object[] {
        };
        Object[] prmT001822;
        prmT001822 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00182", "SELECT [EstadosGenericosId], [EstadosGenericosNombre], [EstadosNotificacionCliente], [EstadosNotificacionProfesional], [EstadosNotificacionOperador], [EstadosTipo] FROM [EstadosGenericos] WITH (UPDLOCK) WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00182,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00183", "SELECT [EstadosGenericosId], [EstadosGenericosNombre], [EstadosNotificacionCliente], [EstadosNotificacionProfesional], [EstadosNotificacionOperador], [EstadosTipo] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00183,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00184", "SELECT [EstadosTipo] FROM [Estados] WHERE [EstadosTipo] = @EstadosTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00184,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00185", "SELECT TM1.[EstadosGenericosId], TM1.[EstadosGenericosNombre], TM1.[EstadosNotificacionCliente], TM1.[EstadosNotificacionProfesional], TM1.[EstadosNotificacionOperador], TM1.[EstadosTipo] FROM [EstadosGenericos] TM1 WHERE TM1.[EstadosTipo] = @EstadosTipo and TM1.[EstadosGenericosId] = @EstadosGenericosId ORDER BY TM1.[EstadosTipo], TM1.[EstadosGenericosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00185,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00186", "SELECT [EstadosTipo] FROM [Estados] WHERE [EstadosTipo] = @EstadosTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00186,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00187", "SELECT [EstadosTipo], [EstadosGenericosId] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00187,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00188", "SELECT TOP 1 [EstadosTipo], [EstadosGenericosId] FROM [EstadosGenericos] WHERE ( [EstadosTipo] > @EstadosTipo or [EstadosTipo] = @EstadosTipo and [EstadosGenericosId] > @EstadosGenericosId) ORDER BY [EstadosTipo], [EstadosGenericosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00188,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00189", "SELECT TOP 1 [EstadosTipo], [EstadosGenericosId] FROM [EstadosGenericos] WHERE ( [EstadosTipo] < @EstadosTipo or [EstadosTipo] = @EstadosTipo and [EstadosGenericosId] < @EstadosGenericosId) ORDER BY [EstadosTipo] DESC, [EstadosGenericosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00189,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001810", "INSERT INTO [EstadosGenericos]([EstadosGenericosId], [EstadosGenericosNombre], [EstadosNotificacionCliente], [EstadosNotificacionProfesional], [EstadosNotificacionOperador], [EstadosTipo]) VALUES(@EstadosGenericosId, @EstadosGenericosNombre, @EstadosNotificacionCliente, @EstadosNotificacionProfesional, @EstadosNotificacionOperador, @EstadosTipo)", GxErrorMask.GX_NOMASK,prmT001810)
           ,new CursorDef("T001811", "UPDATE [EstadosGenericos] SET [EstadosGenericosNombre]=@EstadosGenericosNombre, [EstadosNotificacionCliente]=@EstadosNotificacionCliente, [EstadosNotificacionProfesional]=@EstadosNotificacionProfesional, [EstadosNotificacionOperador]=@EstadosNotificacionOperador  WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId", GxErrorMask.GX_NOMASK,prmT001811)
           ,new CursorDef("T001812", "DELETE FROM [EstadosGenericos]  WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId", GxErrorMask.GX_NOMASK,prmT001812)
           ,new CursorDef("T001813", "SELECT TOP 1 [HistoricoSolicitudesID], [HistoricoRelacionesId] FROM [HistoricoRelacionesRelaciones] WHERE [EstadoSGTipo] = @EstadosTipo AND [EstadoSGId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001813,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001814", "SELECT TOP 1 [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [EstadoSGTipo] = @EstadosTipo AND [EstadoSGId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001814,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001815", "SELECT TOP 1 [HistoricoSolicitudesID] FROM [HistoricoSolicitudes] WHERE [EstadosSolTipo] = @EstadosTipo AND [EstadosSolId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001815,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001816", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [EstadosSolTipo] = @EstadosTipo AND [EstadosSolId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001816,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001817", "SELECT TOP 1 [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [EstadosProfRubTipo] = @EstadosTipo AND [EstadosProfRubId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001817,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001818", "SELECT TOP 1 [MetodoPagosID] FROM [MetodoPagos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001818,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001819", "SELECT TOP 1 [ProfesionalesId] FROM [Profesionales] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001819,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001820", "SELECT TOP 1 [RubrosId], [MedidasID], [InventarioId] FROM [Inventario] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001820,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001821", "SELECT [EstadosTipo], [EstadosGenericosId] FROM [EstadosGenericos] ORDER BY [EstadosTipo], [EstadosGenericosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001821,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001822", "SELECT [EstadosTipo] FROM [Estados] WHERE [EstadosTipo] = @EstadosTipo ",true, GxErrorMask.GX_NOMASK, false, this,prmT001822,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 18 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}

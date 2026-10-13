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
   public class profcomisiones : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"RUBROSID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLARUBROSID1O67( ) ;
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
            GXDLAMEDIDASID1O67( A121RubrosId) ;
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
            GXDLAINVENTARIOID1O67( A121RubrosId, A137MedidasID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A120ProfesionalesId = GetPar( "ProfesionalesId");
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A120ProfesionalesId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A133ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
            n133ProveedorID = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A133ProveedorID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
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
            gxLoad_22( A121RubrosId, A137MedidasID, A135InventarioId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "profcomisiones.aspx")), "profcomisiones.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "profcomisiones.aspx")))) ;
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
                  AV7ProfComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProfComisionesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ProfComisionesID", StringUtil.LTrimStr( (decimal)(AV7ProfComisionesID), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROFCOMISIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProfComisionesID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Comisiones para Profesionales", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         nRC_GXsfl_68 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_68"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_68_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_68_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_68_idx = GetPar( "sGXsfl_68_idx");
         A451ProfComisionesAutoEnun = (short)(Math.Round(NumberUtil.Val( GetPar( "ProfComisionesAutoEnun"), "."), 18, MidpointRounding.ToEven));
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

      public profcomisiones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profcomisiones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_ProfComisionesID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProfComisionesID = aP1_ProfComisionesID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynRubrosId = new GXCombobox();
         dynMedidasID = new GXCombobox();
         dynInventarioId = new GXCombobox();
         cmbProfComisionesRubrosTipo = new GXCombobox();
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfComisionesID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfComisionesID_Internalname, context.GetMessage( "Comisiones ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfComisionesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A450ProfComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProfComisionesID_Enabled!=0) ? context.localUtil.Format( (decimal)(A450ProfComisionesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A450ProfComisionesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfComisionesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfComisionesID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ProfComisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTb1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesId_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId), StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtProfesionalesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesId_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NoIdentidad", "start", true, "", "HLP_ProfComisiones.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_120_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_120_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_120_Internalname, sImgUrl, imgprompt_120_Link, "", "", context.GetTheme( ), imgprompt_120_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_ProfComisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesPrimerNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesPrimerNombre_Internalname, context.GetMessage( "Primer Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre), StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesPrimerNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesPrimerNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfComisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesSegundoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesSegundoNombre_Internalname, context.GetMessage( "Segundo Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesSegundoNombre_Internalname, StringUtil.RTrim( A191ProfesionalesSegundoNombre), StringUtil.RTrim( context.localUtil.Format( A191ProfesionalesSegundoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesSegundoNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesSegundoNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfComisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesApellidoPrimero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesApellidoPrimero_Internalname, context.GetMessage( "Primero Apellido ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero), StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesApellidoPrimero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesApellidoPrimero_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfComisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesApellidoSegundo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesApellidoSegundo_Internalname, context.GetMessage( "Segundo Apellido ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesApellidoSegundo_Internalname, StringUtil.RTrim( A192ProfesionalesApellidoSegundo), StringUtil.RTrim( context.localUtil.Format( A192ProfesionalesApellidoSegundo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesApellidoSegundo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesApellidoSegundo_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfComisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesTelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A170ProfesionalesTelefono);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesTelefono_Internalname, StringUtil.RTrim( A170ProfesionalesTelefono), StringUtil.RTrim( context.localUtil.Format( A170ProfesionalesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProfesionalesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_ProfComisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTb2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProfesionalesPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A169ProfesionalesPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProfesionalesPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.PathToRelativeUrl( A169ProfesionalesPhoto));
         GxWebStd.gx_bitmap( context, imgProfesionalesPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProfesionalesPhoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "", "", "", 0, A169ProfesionalesPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfComisiones.htm");
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.PathToRelativeUrl( A169ProfesionalesPhoto)), true);
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A169ProfesionalesPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfComisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfComisiones.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfComisiones.htm");
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
         StartGridControl68( ) ;
         nGXsfl_68_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount67 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_67 = 1;
               ScanStart1O67( ) ;
               while ( RcdFound67 != 0 )
               {
                  init_level_properties67( ) ;
                  getByPrimaryKey1O67( ) ;
                  AddRow1O67( ) ;
                  ScanNext1O67( ) ;
               }
               ScanEnd1O67( ) ;
               nBlankRcdCount67 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B451ProfComisionesAutoEnun = A451ProfComisionesAutoEnun;
            AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
            standaloneNotModal1O67( ) ;
            standaloneModal1O67( ) ;
            sMode67 = Gx_mode;
            while ( nGXsfl_68_idx < nRC_GXsfl_68 )
            {
               bGXsfl_68_Refreshing = true;
               ReadRow1O67( ) ;
               edtProfComisionesRubrosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFCOMISIONESRUBROSID_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfComisionesRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesRubrosId_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               edtProveedorID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORID_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               edtProveedorNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORNOMBRE_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               dynRubrosId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), !bGXsfl_68_Refreshing);
               dynMedidasID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASID_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_68_Refreshing);
               dynInventarioId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOID_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_68_Refreshing);
               edtInventarioPrecioFinal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOPRECIOFINAL_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               cmbProfComisionesRubrosTipo.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFCOMISIONESRUBROSTIPO_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbProfComisionesRubrosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProfComisionesRubrosTipo.Enabled), 5, 0), !bGXsfl_68_Refreshing);
               edtProfComisionesRubrosValor_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFCOMISIONESRUBROSVALOR_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfComisionesRubrosValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesRubrosValor_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               edtProfComisionesRubrosGanPRF_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFCOMISIONESRUBROSGANPRF_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfComisionesRubrosGanPRF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesRubrosGanPRF_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               edtProfComisionesRubrosGan_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFCOMISIONESRUBROSGAN_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfComisionesRubrosGan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesRubrosGan_Enabled), 5, 0), !bGXsfl_68_Refreshing);
               imgprompt_120_Link = cgiGet( "PROMPT_133_"+sGXsfl_68_idx+"Link");
               if ( ( nRcdExists_67 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1O67( ) ;
               }
               SendRow1O67( ) ;
               bGXsfl_68_Refreshing = false;
            }
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A451ProfComisionesAutoEnun = B451ProfComisionesAutoEnun;
            AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount67 = 5;
            nRcdExists_67 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1O67( ) ;
               while ( RcdFound67 != 0 )
               {
                  sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_6867( ) ;
                  init_level_properties67( ) ;
                  standaloneNotModal1O67( ) ;
                  getByPrimaryKey1O67( ) ;
                  standaloneModal1O67( ) ;
                  AddRow1O67( ) ;
                  ScanNext1O67( ) ;
               }
               ScanEnd1O67( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode67 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx+1), 4, 0), 4, "0");
            SubsflControlProps_6867( ) ;
            InitAll1O67( ) ;
            init_level_properties67( ) ;
            B451ProfComisionesAutoEnun = A451ProfComisionesAutoEnun;
            AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
            nRcdExists_67 = 0;
            nIsMod_67 = 0;
            nRcdDeleted_67 = 0;
            nBlankRcdCount67 = (short)(nBlankRcdUsr67+nBlankRcdCount67);
            fRowAdded = 0;
            while ( nBlankRcdCount67 > 0 )
            {
               standaloneNotModal1O67( ) ;
               standaloneModal1O67( ) ;
               AddRow1O67( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount67 = (short)(nBlankRcdCount67-1);
            }
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A451ProfComisionesAutoEnun = B451ProfComisionesAutoEnun;
            AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
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
         E111O2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z450ProfComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z450ProfComisionesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z451ProfComisionesAutoEnun = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z451ProfComisionesAutoEnun"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z120ProfesionalesId = cgiGet( "Z120ProfesionalesId");
               A451ProfComisionesAutoEnun = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z451ProfComisionesAutoEnun"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O451ProfComisionesAutoEnun = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O451ProfComisionesAutoEnun"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_68 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_68"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N120ProfesionalesId = cgiGet( "N120ProfesionalesId");
               AV7ProfComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vPROFCOMISIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV11Insert_ProfesionalesId = cgiGet( "vINSERT_PROFESIONALESID");
               AssignAttri("", false, "AV11Insert_ProfesionalesId", AV11Insert_ProfesionalesId);
               A451ProfComisionesAutoEnun = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROFCOMISIONESAUTOENUN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40000ProfesionalesPhoto_GXI = cgiGet( "PROFESIONALESPHOTO_GXI");
               AV28Pgmname = cgiGet( "vPGMNAME");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A190InventarioCosto = context.localUtil.CToN( cgiGet( "INVENTARIOCOSTO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
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
               A450ProfComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
               A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
               AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
               A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
               AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
               A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
               AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
               A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
               AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
               A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
               AssignAttri("", false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
               A170ProfesionalesTelefono = cgiGet( edtProfesionalesTelefono_Internalname);
               AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
               A169ProfesionalesPhoto = cgiGet( imgProfesionalesPhoto_Internalname);
               AssignAttri("", false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProfesionalesPhoto_Internalname, ref  A169ProfesionalesPhoto, ref  A40000ProfesionalesPhoto_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ProfComisiones");
               A450ProfComisionesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
               forbiddenHiddens.Add("ProfComisionesID", context.localUtil.Format( (decimal)(A450ProfComisionesID), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ProfesionalesId", StringUtil.RTrim( context.localUtil.Format( AV11Insert_ProfesionalesId, "")));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A450ProfComisionesID != Z450ProfComisionesID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("profcomisiones:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A450ProfComisionesID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProfComisionesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
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
                     sMode66 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode66;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound66 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1O0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROFCOMISIONESID");
                        AnyError = 1;
                        GX_FocusControl = edtProfComisionesID_Internalname;
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
                           E111O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121O2 ();
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
            E121O2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1O66( ) ;
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
            DisableAttributes1O66( ) ;
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

      protected void CONFIRM_1O0( )
      {
         BeforeValidate1O66( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1O66( ) ;
            }
            else
            {
               CheckExtendedTable1O66( ) ;
               CloseExtendedTableCursors1O66( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode66 = Gx_mode;
            CONFIRM_1O67( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode66;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode66;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_1O67( )
      {
         s451ProfComisionesAutoEnun = O451ProfComisionesAutoEnun;
         AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
         nGXsfl_68_idx = 0;
         while ( nGXsfl_68_idx < nRC_GXsfl_68 )
         {
            ReadRow1O67( ) ;
            if ( ( nRcdExists_67 != 0 ) || ( nIsMod_67 != 0 ) )
            {
               GetKey1O67( ) ;
               if ( ( nRcdExists_67 == 0 ) && ( nRcdDeleted_67 == 0 ) )
               {
                  if ( RcdFound67 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1O67( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1O67( ) ;
                        CloseExtendedTableCursors1O67( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O451ProfComisionesAutoEnun = A451ProfComisionesAutoEnun;
                        AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
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
                  if ( RcdFound67 != 0 )
                  {
                     if ( nRcdDeleted_67 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1O67( ) ;
                        Load1O67( ) ;
                        BeforeValidate1O67( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1O67( ) ;
                           O451ProfComisionesAutoEnun = A451ProfComisionesAutoEnun;
                           AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_67 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1O67( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1O67( ) ;
                              CloseExtendedTableCursors1O67( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O451ProfComisionesAutoEnun = A451ProfComisionesAutoEnun;
                              AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_67 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtProfComisionesRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A452ProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre)) ;
            ChangePostValue( dynRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))) ;
            ChangePostValue( dynMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))) ;
            ChangePostValue( dynInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))) ;
            ChangePostValue( edtInventarioPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbProfComisionesRubrosTipo_Internalname, StringUtil.RTrim( A453ProfComisionesRubrosTipo)) ;
            ChangePostValue( edtProfComisionesRubrosValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A454ProfComisionesRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProfComisionesRubrosGanPRF_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A457ProfComisionesRubrosGanPRF), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProfComisionesRubrosGan_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A456ProfComisionesRubrosGan), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z452ProfComisionesRubrosId_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z452ProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z453ProfComisionesRubrosTipo_"+sGXsfl_68_idx, StringUtil.RTrim( Z453ProfComisionesRubrosTipo)) ;
            ChangePostValue( "ZT_"+"Z454ProfComisionesRubrosValor_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( Z454ProfComisionesRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z133ProveedorID_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_67_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_67), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_67_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_67), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_67_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_67), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_67 != 0 )
            {
               ChangePostValue( "PROFCOMISIONESRUBROSID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORNOMBRE_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynRubrosId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOPRECIOFINAL_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFCOMISIONESRUBROSTIPO_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProfComisionesRubrosTipo.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFCOMISIONESRUBROSVALOR_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosValor_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFCOMISIONESRUBROSGANPRF_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosGanPRF_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFCOMISIONESRUBROSGAN_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosGan_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O451ProfComisionesAutoEnun = s451ProfComisionesAutoEnun;
         AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1O0( )
      {
      }

      protected void E111O2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV13WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfComisiones_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfComisiones_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfComisiones_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV28Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV28Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV29GXV1 = 1;
            AssignAttri("", false, "AV29GXV1", StringUtil.LTrimStr( (decimal)(AV29GXV1), 8, 0));
            while ( AV29GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV29GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ProfesionalesId") == 0 )
               {
                  AV11Insert_ProfesionalesId = AV12TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV11Insert_ProfesionalesId", AV11Insert_ProfesionalesId);
               }
               AV29GXV1 = (int)(AV29GXV1+1);
               AssignAttri("", false, "AV29GXV1", StringUtil.LTrimStr( (decimal)(AV29GXV1), 8, 0));
            }
         }
      }

      protected void E121O2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("profcomisionesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1O66( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z451ProfComisionesAutoEnun = T001O7_A451ProfComisionesAutoEnun[0];
               Z120ProfesionalesId = T001O7_A120ProfesionalesId[0];
            }
            else
            {
               Z451ProfComisionesAutoEnun = A451ProfComisionesAutoEnun;
               Z120ProfesionalesId = A120ProfesionalesId;
            }
         }
         if ( GX_JID == -18 )
         {
            Z450ProfComisionesID = A450ProfComisionesID;
            Z451ProfComisionesAutoEnun = A451ProfComisionesAutoEnun;
            Z120ProfesionalesId = A120ProfesionalesId;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z192ProfesionalesApellidoSegundo = A192ProfesionalesApellidoSegundo;
            Z169ProfesionalesPhoto = A169ProfesionalesPhoto;
            Z40000ProfesionalesPhoto_GXI = A40000ProfesionalesPhoto_GXI;
            Z170ProfesionalesTelefono = A170ProfesionalesTelefono;
         }
      }

      protected void standaloneNotModal( )
      {
         edtProfComisionesID_Enabled = 0;
         AssignProp("", false, edtProfComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_120_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"profesionalesprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROFESIONALESID"+"'), id:'"+"PROFESIONALESID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"PROFESIONALESPRIMERNOMBRE"+"'), id:'"+"PROFESIONALESPRIMERNOMBRE"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtProfComisionesID_Enabled = 0;
         AssignProp("", false, edtProfComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesID_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ProfComisionesID) )
         {
            A450ProfComisionesID = AV7ProfComisionesID;
            AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_ProfesionalesId)) )
         {
            edtProfesionalesId_Enabled = 0;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         }
         else
         {
            edtProfesionalesId_Enabled = 1;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_ProfesionalesId)) )
         {
            A120ProfesionalesId = AV11Insert_ProfesionalesId;
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
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
            AV28Pgmname = "ProfComisiones";
            AssignAttri("", false, "AV28Pgmname", AV28Pgmname);
            /* Using cursor T001O8 */
            pr_default.execute(6, new Object[] {A120ProfesionalesId});
            A166ProfesionalesPrimerNombre = T001O8_A166ProfesionalesPrimerNombre[0];
            AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A191ProfesionalesSegundoNombre = T001O8_A191ProfesionalesSegundoNombre[0];
            AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
            A167ProfesionalesApellidoPrimero = T001O8_A167ProfesionalesApellidoPrimero[0];
            AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            A192ProfesionalesApellidoSegundo = T001O8_A192ProfesionalesApellidoSegundo[0];
            AssignAttri("", false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
            A40000ProfesionalesPhoto_GXI = T001O8_A40000ProfesionalesPhoto_GXI[0];
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A170ProfesionalesTelefono = T001O8_A170ProfesionalesTelefono[0];
            AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
            A169ProfesionalesPhoto = T001O8_A169ProfesionalesPhoto[0];
            AssignAttri("", false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            pr_default.close(6);
         }
      }

      protected void Load1O66( )
      {
         /* Using cursor T001O9 */
         pr_default.execute(7, new Object[] {A450ProfComisionesID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound66 = 1;
            A166ProfesionalesPrimerNombre = T001O9_A166ProfesionalesPrimerNombre[0];
            AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A191ProfesionalesSegundoNombre = T001O9_A191ProfesionalesSegundoNombre[0];
            AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
            A167ProfesionalesApellidoPrimero = T001O9_A167ProfesionalesApellidoPrimero[0];
            AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            A192ProfesionalesApellidoSegundo = T001O9_A192ProfesionalesApellidoSegundo[0];
            AssignAttri("", false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
            A40000ProfesionalesPhoto_GXI = T001O9_A40000ProfesionalesPhoto_GXI[0];
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A170ProfesionalesTelefono = T001O9_A170ProfesionalesTelefono[0];
            AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
            A451ProfComisionesAutoEnun = T001O9_A451ProfComisionesAutoEnun[0];
            A120ProfesionalesId = T001O9_A120ProfesionalesId[0];
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
            A169ProfesionalesPhoto = T001O9_A169ProfesionalesPhoto[0];
            AssignAttri("", false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            ZM1O66( -18) ;
         }
         pr_default.close(7);
         OnLoadActions1O66( ) ;
      }

      protected void OnLoadActions1O66( )
      {
         AV28Pgmname = "ProfComisiones";
         AssignAttri("", false, "AV28Pgmname", AV28Pgmname);
      }

      protected void CheckExtendedTable1O66( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV28Pgmname = "ProfComisiones";
         AssignAttri("", false, "AV28Pgmname", AV28Pgmname);
         /* Using cursor T001O8 */
         pr_default.execute(6, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A166ProfesionalesPrimerNombre = T001O8_A166ProfesionalesPrimerNombre[0];
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
         A191ProfesionalesSegundoNombre = T001O8_A191ProfesionalesSegundoNombre[0];
         AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
         A167ProfesionalesApellidoPrimero = T001O8_A167ProfesionalesApellidoPrimero[0];
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
         A192ProfesionalesApellidoSegundo = T001O8_A192ProfesionalesApellidoSegundo[0];
         AssignAttri("", false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
         A40000ProfesionalesPhoto_GXI = T001O8_A40000ProfesionalesPhoto_GXI[0];
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
         A170ProfesionalesTelefono = T001O8_A170ProfesionalesTelefono[0];
         AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
         A169ProfesionalesPhoto = T001O8_A169ProfesionalesPhoto[0];
         AssignAttri("", false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors1O66( )
      {
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_19( string A120ProfesionalesId )
      {
         /* Using cursor T001O10 */
         pr_default.execute(8, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A166ProfesionalesPrimerNombre = T001O10_A166ProfesionalesPrimerNombre[0];
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
         A191ProfesionalesSegundoNombre = T001O10_A191ProfesionalesSegundoNombre[0];
         AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
         A167ProfesionalesApellidoPrimero = T001O10_A167ProfesionalesApellidoPrimero[0];
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
         A192ProfesionalesApellidoSegundo = T001O10_A192ProfesionalesApellidoSegundo[0];
         AssignAttri("", false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
         A40000ProfesionalesPhoto_GXI = T001O10_A40000ProfesionalesPhoto_GXI[0];
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
         A170ProfesionalesTelefono = T001O10_A170ProfesionalesTelefono[0];
         AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
         A169ProfesionalesPhoto = T001O10_A169ProfesionalesPhoto[0];
         AssignAttri("", false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A166ProfesionalesPrimerNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A191ProfesionalesSegundoNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A167ProfesionalesApellidoPrimero))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A192ProfesionalesApellidoSegundo))+"\""+","+"\""+GXUtil.EncodeJSConstant( A169ProfesionalesPhoto)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000ProfesionalesPhoto_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A170ProfesionalesTelefono))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey1O66( )
      {
         /* Using cursor T001O11 */
         pr_default.execute(9, new Object[] {A450ProfComisionesID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound66 = 1;
         }
         else
         {
            RcdFound66 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001O7 */
         pr_default.execute(5, new Object[] {A450ProfComisionesID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM1O66( 18) ;
            RcdFound66 = 1;
            A450ProfComisionesID = T001O7_A450ProfComisionesID[0];
            AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
            A451ProfComisionesAutoEnun = T001O7_A451ProfComisionesAutoEnun[0];
            A120ProfesionalesId = T001O7_A120ProfesionalesId[0];
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
            O451ProfComisionesAutoEnun = A451ProfComisionesAutoEnun;
            AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
            Z450ProfComisionesID = A450ProfComisionesID;
            sMode66 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1O66( ) ;
            if ( AnyError == 1 )
            {
               RcdFound66 = 0;
               InitializeNonKey1O66( ) ;
            }
            Gx_mode = sMode66;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound66 = 0;
            InitializeNonKey1O66( ) ;
            sMode66 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode66;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey1O66( ) ;
         if ( RcdFound66 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound66 = 0;
         /* Using cursor T001O12 */
         pr_default.execute(10, new Object[] {A450ProfComisionesID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T001O12_A450ProfComisionesID[0] < A450ProfComisionesID ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T001O12_A450ProfComisionesID[0] > A450ProfComisionesID ) ) )
            {
               A450ProfComisionesID = T001O12_A450ProfComisionesID[0];
               AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
               RcdFound66 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound66 = 0;
         /* Using cursor T001O13 */
         pr_default.execute(11, new Object[] {A450ProfComisionesID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T001O13_A450ProfComisionesID[0] > A450ProfComisionesID ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T001O13_A450ProfComisionesID[0] < A450ProfComisionesID ) ) )
            {
               A450ProfComisionesID = T001O13_A450ProfComisionesID[0];
               AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
               RcdFound66 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1O66( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A451ProfComisionesAutoEnun = O451ProfComisionesAutoEnun;
            AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1O66( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound66 == 1 )
            {
               if ( A450ProfComisionesID != Z450ProfComisionesID )
               {
                  A450ProfComisionesID = Z450ProfComisionesID;
                  AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROFCOMISIONESID");
                  AnyError = 1;
                  GX_FocusControl = edtProfComisionesID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A451ProfComisionesAutoEnun = O451ProfComisionesAutoEnun;
                  AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A451ProfComisionesAutoEnun = O451ProfComisionesAutoEnun;
                  AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
                  Update1O66( ) ;
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A450ProfComisionesID != Z450ProfComisionesID )
               {
                  /* Insert record */
                  A451ProfComisionesAutoEnun = O451ProfComisionesAutoEnun;
                  AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1O66( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROFCOMISIONESID");
                     AnyError = 1;
                     GX_FocusControl = edtProfComisionesID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A451ProfComisionesAutoEnun = O451ProfComisionesAutoEnun;
                     AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
                     GX_FocusControl = edtProfesionalesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1O66( ) ;
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
         if ( A450ProfComisionesID != Z450ProfComisionesID )
         {
            A450ProfComisionesID = Z450ProfComisionesID;
            AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROFCOMISIONESID");
            AnyError = 1;
            GX_FocusControl = edtProfComisionesID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A451ProfComisionesAutoEnun = O451ProfComisionesAutoEnun;
            AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1O66( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001O6 */
            pr_default.execute(4, new Object[] {A450ProfComisionesID});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfComisiones"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( Z451ProfComisionesAutoEnun != T001O6_A451ProfComisionesAutoEnun[0] ) || ( StringUtil.StrCmp(Z120ProfesionalesId, T001O6_A120ProfesionalesId[0]) != 0 ) )
            {
               if ( Z451ProfComisionesAutoEnun != T001O6_A451ProfComisionesAutoEnun[0] )
               {
                  GXUtil.WriteLog("profcomisiones:[seudo value changed for attri]"+"ProfComisionesAutoEnun");
                  GXUtil.WriteLogRaw("Old: ",Z451ProfComisionesAutoEnun);
                  GXUtil.WriteLogRaw("Current: ",T001O6_A451ProfComisionesAutoEnun[0]);
               }
               if ( StringUtil.StrCmp(Z120ProfesionalesId, T001O6_A120ProfesionalesId[0]) != 0 )
               {
                  GXUtil.WriteLog("profcomisiones:[seudo value changed for attri]"+"ProfesionalesId");
                  GXUtil.WriteLogRaw("Old: ",Z120ProfesionalesId);
                  GXUtil.WriteLogRaw("Current: ",T001O6_A120ProfesionalesId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProfComisiones"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1O66( )
      {
         BeforeValidate1O66( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1O66( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1O66( 0) ;
            CheckOptimisticConcurrency1O66( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1O66( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1O66( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001O14 */
                     pr_default.execute(12, new Object[] {A451ProfComisionesAutoEnun, A120ProfesionalesId});
                     A450ProfComisionesID = T001O14_A450ProfComisionesID[0];
                     AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("ProfComisiones");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1O66( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1O0( ) ;
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
               Load1O66( ) ;
            }
            EndLevel1O66( ) ;
         }
         CloseExtendedTableCursors1O66( ) ;
      }

      protected void Update1O66( )
      {
         BeforeValidate1O66( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1O66( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1O66( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1O66( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1O66( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001O15 */
                     pr_default.execute(13, new Object[] {A451ProfComisionesAutoEnun, A120ProfesionalesId, A450ProfComisionesID});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("ProfComisiones");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfComisiones"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1O66( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1O66( ) ;
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
            EndLevel1O66( ) ;
         }
         CloseExtendedTableCursors1O66( ) ;
      }

      protected void DeferredUpdate1O66( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1O66( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1O66( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1O66( ) ;
            AfterConfirm1O66( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1O66( ) ;
               if ( AnyError == 0 )
               {
                  A451ProfComisionesAutoEnun = O451ProfComisionesAutoEnun;
                  AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
                  ScanStart1O67( ) ;
                  while ( RcdFound67 != 0 )
                  {
                     getByPrimaryKey1O67( ) ;
                     Delete1O67( ) ;
                     ScanNext1O67( ) ;
                     O451ProfComisionesAutoEnun = A451ProfComisionesAutoEnun;
                     AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
                  }
                  ScanEnd1O67( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001O16 */
                     pr_default.execute(14, new Object[] {A450ProfComisionesID});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("ProfComisiones");
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
         sMode66 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1O66( ) ;
         Gx_mode = sMode66;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1O66( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV28Pgmname = "ProfComisiones";
            AssignAttri("", false, "AV28Pgmname", AV28Pgmname);
            /* Using cursor T001O17 */
            pr_default.execute(15, new Object[] {A120ProfesionalesId});
            A166ProfesionalesPrimerNombre = T001O17_A166ProfesionalesPrimerNombre[0];
            AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A191ProfesionalesSegundoNombre = T001O17_A191ProfesionalesSegundoNombre[0];
            AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
            A167ProfesionalesApellidoPrimero = T001O17_A167ProfesionalesApellidoPrimero[0];
            AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            A192ProfesionalesApellidoSegundo = T001O17_A192ProfesionalesApellidoSegundo[0];
            AssignAttri("", false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
            A40000ProfesionalesPhoto_GXI = T001O17_A40000ProfesionalesPhoto_GXI[0];
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A170ProfesionalesTelefono = T001O17_A170ProfesionalesTelefono[0];
            AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
            A169ProfesionalesPhoto = T001O17_A169ProfesionalesPhoto[0];
            AssignAttri("", false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            pr_default.close(15);
         }
      }

      protected void ProcessNestedLevel1O67( )
      {
         s451ProfComisionesAutoEnun = O451ProfComisionesAutoEnun;
         AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
         nGXsfl_68_idx = 0;
         while ( nGXsfl_68_idx < nRC_GXsfl_68 )
         {
            ReadRow1O67( ) ;
            if ( ( nRcdExists_67 != 0 ) || ( nIsMod_67 != 0 ) )
            {
               standaloneNotModal1O67( ) ;
               GetKey1O67( ) ;
               if ( ( nRcdExists_67 == 0 ) && ( nRcdDeleted_67 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1O67( ) ;
               }
               else
               {
                  if ( RcdFound67 != 0 )
                  {
                     if ( ( nRcdDeleted_67 != 0 ) && ( nRcdExists_67 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1O67( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_67 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1O67( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_67 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O451ProfComisionesAutoEnun = A451ProfComisionesAutoEnun;
               AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
            }
            ChangePostValue( edtProfComisionesRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A452ProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre)) ;
            ChangePostValue( dynRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))) ;
            ChangePostValue( dynMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))) ;
            ChangePostValue( dynInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))) ;
            ChangePostValue( edtInventarioPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbProfComisionesRubrosTipo_Internalname, StringUtil.RTrim( A453ProfComisionesRubrosTipo)) ;
            ChangePostValue( edtProfComisionesRubrosValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A454ProfComisionesRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProfComisionesRubrosGanPRF_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A457ProfComisionesRubrosGanPRF), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProfComisionesRubrosGan_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A456ProfComisionesRubrosGan), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z452ProfComisionesRubrosId_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z452ProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z453ProfComisionesRubrosTipo_"+sGXsfl_68_idx, StringUtil.RTrim( Z453ProfComisionesRubrosTipo)) ;
            ChangePostValue( "ZT_"+"Z454ProfComisionesRubrosValor_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( Z454ProfComisionesRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z133ProveedorID_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_67_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_67), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_67_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_67), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_67_"+sGXsfl_68_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_67), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_67 != 0 )
            {
               ChangePostValue( "PROFCOMISIONESRUBROSID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORNOMBRE_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynRubrosId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOPRECIOFINAL_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFCOMISIONESRUBROSTIPO_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProfComisionesRubrosTipo.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFCOMISIONESRUBROSVALOR_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosValor_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFCOMISIONESRUBROSGANPRF_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosGanPRF_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFCOMISIONESRUBROSGAN_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosGan_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1O67( ) ;
         if ( AnyError != 0 )
         {
            O451ProfComisionesAutoEnun = s451ProfComisionesAutoEnun;
            AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
         }
         nRcdExists_67 = 0;
         nIsMod_67 = 0;
         nRcdDeleted_67 = 0;
      }

      protected void ProcessLevel1O66( )
      {
         /* Save parent mode. */
         sMode66 = Gx_mode;
         ProcessNestedLevel1O67( ) ;
         if ( AnyError != 0 )
         {
            O451ProfComisionesAutoEnun = s451ProfComisionesAutoEnun;
            AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode66;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T001O18 */
         pr_default.execute(16, new Object[] {A451ProfComisionesAutoEnun, A450ProfComisionesID});
         pr_default.close(16);
         pr_default.SmartCacheProvider.SetUpdated("ProfComisiones");
      }

      protected void EndLevel1O66( )
      {
         pr_default.close(4);
         if ( AnyError == 0 )
         {
            BeforeComplete1O66( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(15);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("profcomisiones",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(15);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("profcomisiones",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1O66( )
      {
         /* Scan By routine */
         /* Using cursor T001O19 */
         pr_default.execute(17);
         RcdFound66 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound66 = 1;
            A450ProfComisionesID = T001O19_A450ProfComisionesID[0];
            AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1O66( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound66 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound66 = 1;
            A450ProfComisionesID = T001O19_A450ProfComisionesID[0];
            AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
         }
      }

      protected void ScanEnd1O66( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm1O66( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1O66( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1O66( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1O66( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1O66( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1O66( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1O66( )
      {
         edtProfComisionesID_Enabled = 0;
         AssignProp("", false, edtProfComisionesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesID_Enabled), 5, 0), true);
         edtProfesionalesId_Enabled = 0;
         AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         edtProfesionalesPrimerNombre_Enabled = 0;
         AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0), true);
         edtProfesionalesSegundoNombre_Enabled = 0;
         AssignProp("", false, edtProfesionalesSegundoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0), true);
         edtProfesionalesApellidoPrimero_Enabled = 0;
         AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0), true);
         edtProfesionalesApellidoSegundo_Enabled = 0;
         AssignProp("", false, edtProfesionalesApellidoSegundo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0), true);
         edtProfesionalesTelefono_Enabled = 0;
         AssignProp("", false, edtProfesionalesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesTelefono_Enabled), 5, 0), true);
         imgProfesionalesPhoto_Enabled = 0;
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProfesionalesPhoto_Enabled), 5, 0), true);
      }

      protected void ZM1O67( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z453ProfComisionesRubrosTipo = T001O3_A453ProfComisionesRubrosTipo[0];
               Z454ProfComisionesRubrosValor = T001O3_A454ProfComisionesRubrosValor[0];
               Z133ProveedorID = T001O3_A133ProveedorID[0];
               Z121RubrosId = T001O3_A121RubrosId[0];
               Z137MedidasID = T001O3_A137MedidasID[0];
               Z135InventarioId = T001O3_A135InventarioId[0];
            }
            else
            {
               Z453ProfComisionesRubrosTipo = A453ProfComisionesRubrosTipo;
               Z454ProfComisionesRubrosValor = A454ProfComisionesRubrosValor;
               Z133ProveedorID = A133ProveedorID;
               Z121RubrosId = A121RubrosId;
               Z137MedidasID = A137MedidasID;
               Z135InventarioId = A135InventarioId;
            }
         }
         if ( GX_JID == -20 )
         {
            Z450ProfComisionesID = A450ProfComisionesID;
            Z452ProfComisionesRubrosId = A452ProfComisionesRubrosId;
            Z453ProfComisionesRubrosTipo = A453ProfComisionesRubrosTipo;
            Z454ProfComisionesRubrosValor = A454ProfComisionesRubrosValor;
            Z133ProveedorID = A133ProveedorID;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z190InventarioCosto = A190InventarioCosto;
            Z181InventarioPrecioFinal = A181InventarioPrecioFinal;
         }
      }

      protected void standaloneNotModal1O67( )
      {
         GXARUBROSID_html1O67( ) ;
         edtProfComisionesRubrosId_Enabled = 0;
         AssignProp("", false, edtProfComisionesRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesRubrosId_Enabled), 5, 0), !bGXsfl_68_Refreshing);
      }

      protected void standaloneModal1O67( )
      {
         if ( IsIns( )  )
         {
            A451ProfComisionesAutoEnun = (short)(O451ProfComisionesAutoEnun+1);
            AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A452ProfComisionesRubrosId = A451ProfComisionesAutoEnun;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A453ProfComisionesRubrosTipo)) && ( Gx_BScreen == 0 ) )
         {
            A453ProfComisionesRubrosTipo = context.GetMessage( context.GetMessage( "F", ""), "");
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            GXAMEDIDASID_html1O67( A121RubrosId) ;
            GXAINVENTARIOID_html1O67( A121RubrosId, A137MedidasID) ;
            /* Using cursor T001O5 */
            pr_default.execute(3, new Object[] {A121RubrosId, A137MedidasID, A135InventarioId});
            A190InventarioCosto = T001O5_A190InventarioCosto[0];
            A181InventarioPrecioFinal = T001O5_A181InventarioPrecioFinal[0];
            pr_default.close(3);
         }
      }

      protected void Load1O67( )
      {
         /* Using cursor T001O20 */
         pr_default.execute(18, new Object[] {A450ProfComisionesID, A452ProfComisionesRubrosId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound67 = 1;
            A453ProfComisionesRubrosTipo = T001O20_A453ProfComisionesRubrosTipo[0];
            A454ProfComisionesRubrosValor = T001O20_A454ProfComisionesRubrosValor[0];
            A282ProveedorNombre = T001O20_A282ProveedorNombre[0];
            A190InventarioCosto = T001O20_A190InventarioCosto[0];
            A181InventarioPrecioFinal = T001O20_A181InventarioPrecioFinal[0];
            A133ProveedorID = T001O20_A133ProveedorID[0];
            n133ProveedorID = T001O20_n133ProveedorID[0];
            A121RubrosId = T001O20_A121RubrosId[0];
            A137MedidasID = T001O20_A137MedidasID[0];
            A135InventarioId = T001O20_A135InventarioId[0];
            ZM1O67( -20) ;
         }
         pr_default.close(18);
         OnLoadActions1O67( ) ;
      }

      protected void OnLoadActions1O67( )
      {
         if ( true /* After */ && ( A190InventarioCosto > Convert.ToDecimal( 0 )) && ( A454ProfComisionesRubrosValor == Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            A454ProfComisionesRubrosValor = A190InventarioCosto;
         }
         if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "F", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
         {
            A457ProfComisionesRubrosGanPRF = (long)(Math.Round(A454ProfComisionesRubrosValor, 18, MidpointRounding.ToEven));
         }
         else
         {
            if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "P", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
            {
               A457ProfComisionesRubrosGanPRF = (long)(A181InventarioPrecioFinal*(A454ProfComisionesRubrosValor/ (decimal)(100)));
            }
            else
            {
               A457ProfComisionesRubrosGanPRF = 0;
            }
         }
         A456ProfComisionesRubrosGan = (long)(A181InventarioPrecioFinal-A457ProfComisionesRubrosGanPRF);
         GXAMEDIDASID_html1O67( A121RubrosId) ;
         GXAINVENTARIOID_html1O67( A121RubrosId, A137MedidasID) ;
      }

      protected void CheckExtendedTable1O67( )
      {
         nIsDirty_67 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal1O67( ) ;
         /* Using cursor T001O4 */
         pr_default.execute(2, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A133ProveedorID) ) )
            {
               GXCCtl = "PROVEEDORID_" + sGXsfl_68_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtProveedorID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A282ProveedorNombre = T001O4_A282ProveedorNombre[0];
         pr_default.close(2);
         /* Using cursor T001O5 */
         pr_default.execute(3, new Object[] {A121RubrosId, A137MedidasID, A135InventarioId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "INVENTARIOID_" + sGXsfl_68_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A190InventarioCosto = T001O5_A190InventarioCosto[0];
         A181InventarioPrecioFinal = T001O5_A181InventarioPrecioFinal[0];
         pr_default.close(3);
         if ( true /* After */ && ( A190InventarioCosto > Convert.ToDecimal( 0 )) && ( A454ProfComisionesRubrosValor == Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            nIsDirty_67 = 1;
            A454ProfComisionesRubrosValor = A190InventarioCosto;
         }
         if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "F", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
         {
            nIsDirty_67 = 1;
            A457ProfComisionesRubrosGanPRF = (long)(Math.Round(A454ProfComisionesRubrosValor, 18, MidpointRounding.ToEven));
         }
         else
         {
            if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "P", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
            {
               nIsDirty_67 = 1;
               A457ProfComisionesRubrosGanPRF = (long)(A181InventarioPrecioFinal*(A454ProfComisionesRubrosValor/ (decimal)(100)));
            }
            else
            {
               nIsDirty_67 = 1;
               A457ProfComisionesRubrosGanPRF = 0;
            }
         }
         nIsDirty_67 = 1;
         A456ProfComisionesRubrosGan = (long)(A181InventarioPrecioFinal-A457ProfComisionesRubrosGanPRF);
         GXAMEDIDASID_html1O67( A121RubrosId) ;
         GXAINVENTARIOID_html1O67( A121RubrosId, A137MedidasID) ;
      }

      protected void CloseExtendedTableCursors1O67( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable1O67( )
      {
      }

      protected void gxLoad_21( long A133ProveedorID )
      {
         /* Using cursor T001O21 */
         pr_default.execute(19, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A133ProveedorID) ) )
            {
               GXCCtl = "PROVEEDORID_" + sGXsfl_68_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtProveedorID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A282ProveedorNombre = T001O21_A282ProveedorNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A282ProveedorNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_22( short A121RubrosId ,
                                long A137MedidasID ,
                                long A135InventarioId )
      {
         /* Using cursor T001O22 */
         pr_default.execute(20, new Object[] {A121RubrosId, A137MedidasID, A135InventarioId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GXCCtl = "INVENTARIOID_" + sGXsfl_68_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A190InventarioCosto = T001O22_A190InventarioCosto[0];
         A181InventarioPrecioFinal = T001O22_A181InventarioPrecioFinal[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A190InventarioCosto, 18, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey1O67( )
      {
         /* Using cursor T001O23 */
         pr_default.execute(21, new Object[] {A450ProfComisionesID, A452ProfComisionesRubrosId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound67 = 1;
         }
         else
         {
            RcdFound67 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey1O67( )
      {
         /* Using cursor T001O3 */
         pr_default.execute(1, new Object[] {A450ProfComisionesID, A452ProfComisionesRubrosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1O67( 20) ;
            RcdFound67 = 1;
            InitializeNonKey1O67( ) ;
            A452ProfComisionesRubrosId = T001O3_A452ProfComisionesRubrosId[0];
            A453ProfComisionesRubrosTipo = T001O3_A453ProfComisionesRubrosTipo[0];
            A454ProfComisionesRubrosValor = T001O3_A454ProfComisionesRubrosValor[0];
            A133ProveedorID = T001O3_A133ProveedorID[0];
            n133ProveedorID = T001O3_n133ProveedorID[0];
            A121RubrosId = T001O3_A121RubrosId[0];
            A137MedidasID = T001O3_A137MedidasID[0];
            A135InventarioId = T001O3_A135InventarioId[0];
            Z450ProfComisionesID = A450ProfComisionesID;
            Z452ProfComisionesRubrosId = A452ProfComisionesRubrosId;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1O67( ) ;
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound67 = 0;
            InitializeNonKey1O67( ) ;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1O67( ) ;
            Gx_mode = sMode67;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1O67( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1O67( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001O2 */
            pr_default.execute(0, new Object[] {A450ProfComisionesID, A452ProfComisionesRubrosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfComisionesRubros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z453ProfComisionesRubrosTipo, T001O2_A453ProfComisionesRubrosTipo[0]) != 0 ) || ( Z454ProfComisionesRubrosValor != T001O2_A454ProfComisionesRubrosValor[0] ) || ( Z133ProveedorID != T001O2_A133ProveedorID[0] ) || ( Z121RubrosId != T001O2_A121RubrosId[0] ) || ( Z137MedidasID != T001O2_A137MedidasID[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z135InventarioId != T001O2_A135InventarioId[0] ) )
            {
               if ( StringUtil.StrCmp(Z453ProfComisionesRubrosTipo, T001O2_A453ProfComisionesRubrosTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("profcomisiones:[seudo value changed for attri]"+"ProfComisionesRubrosTipo");
                  GXUtil.WriteLogRaw("Old: ",Z453ProfComisionesRubrosTipo);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A453ProfComisionesRubrosTipo[0]);
               }
               if ( Z454ProfComisionesRubrosValor != T001O2_A454ProfComisionesRubrosValor[0] )
               {
                  GXUtil.WriteLog("profcomisiones:[seudo value changed for attri]"+"ProfComisionesRubrosValor");
                  GXUtil.WriteLogRaw("Old: ",Z454ProfComisionesRubrosValor);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A454ProfComisionesRubrosValor[0]);
               }
               if ( Z133ProveedorID != T001O2_A133ProveedorID[0] )
               {
                  GXUtil.WriteLog("profcomisiones:[seudo value changed for attri]"+"ProveedorID");
                  GXUtil.WriteLogRaw("Old: ",Z133ProveedorID);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A133ProveedorID[0]);
               }
               if ( Z121RubrosId != T001O2_A121RubrosId[0] )
               {
                  GXUtil.WriteLog("profcomisiones:[seudo value changed for attri]"+"RubrosId");
                  GXUtil.WriteLogRaw("Old: ",Z121RubrosId);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A121RubrosId[0]);
               }
               if ( Z137MedidasID != T001O2_A137MedidasID[0] )
               {
                  GXUtil.WriteLog("profcomisiones:[seudo value changed for attri]"+"MedidasID");
                  GXUtil.WriteLogRaw("Old: ",Z137MedidasID);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A137MedidasID[0]);
               }
               if ( Z135InventarioId != T001O2_A135InventarioId[0] )
               {
                  GXUtil.WriteLog("profcomisiones:[seudo value changed for attri]"+"InventarioId");
                  GXUtil.WriteLogRaw("Old: ",Z135InventarioId);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A135InventarioId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProfComisionesRubros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1O67( )
      {
         BeforeValidate1O67( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1O67( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1O67( 0) ;
            CheckOptimisticConcurrency1O67( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1O67( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1O67( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001O24 */
                     pr_default.execute(22, new Object[] {A450ProfComisionesID, A452ProfComisionesRubrosId, A453ProfComisionesRubrosTipo, A454ProfComisionesRubrosValor, n133ProveedorID, A133ProveedorID, A121RubrosId, A137MedidasID, A135InventarioId});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("ProfComisionesRubros");
                     if ( (pr_default.getStatus(22) == 1) )
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
               Load1O67( ) ;
            }
            EndLevel1O67( ) ;
         }
         CloseExtendedTableCursors1O67( ) ;
      }

      protected void Update1O67( )
      {
         BeforeValidate1O67( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1O67( ) ;
         }
         if ( ( nIsMod_67 != 0 ) || ( nIsDirty_67 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1O67( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1O67( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1O67( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001O25 */
                        pr_default.execute(23, new Object[] {A453ProfComisionesRubrosTipo, A454ProfComisionesRubrosValor, n133ProveedorID, A133ProveedorID, A121RubrosId, A137MedidasID, A135InventarioId, A450ProfComisionesID, A452ProfComisionesRubrosId});
                        pr_default.close(23);
                        pr_default.SmartCacheProvider.SetUpdated("ProfComisionesRubros");
                        if ( (pr_default.getStatus(23) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfComisionesRubros"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1O67( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1O67( ) ;
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
               EndLevel1O67( ) ;
            }
         }
         CloseExtendedTableCursors1O67( ) ;
      }

      protected void DeferredUpdate1O67( )
      {
      }

      protected void Delete1O67( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1O67( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1O67( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1O67( ) ;
            AfterConfirm1O67( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1O67( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001O26 */
                  pr_default.execute(24, new Object[] {A450ProfComisionesID, A452ProfComisionesRubrosId});
                  pr_default.close(24);
                  pr_default.SmartCacheProvider.SetUpdated("ProfComisionesRubros");
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
         sMode67 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1O67( ) ;
         Gx_mode = sMode67;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1O67( )
      {
         standaloneModal1O67( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001O27 */
            pr_default.execute(25, new Object[] {n133ProveedorID, A133ProveedorID});
            A282ProveedorNombre = T001O27_A282ProveedorNombre[0];
            pr_default.close(25);
            GXAMEDIDASID_html1O67( A121RubrosId) ;
            GXAINVENTARIOID_html1O67( A121RubrosId, A137MedidasID) ;
            /* Using cursor T001O28 */
            pr_default.execute(26, new Object[] {A121RubrosId, A137MedidasID, A135InventarioId});
            A190InventarioCosto = T001O28_A190InventarioCosto[0];
            A181InventarioPrecioFinal = T001O28_A181InventarioPrecioFinal[0];
            pr_default.close(26);
            if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "F", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
            {
               A457ProfComisionesRubrosGanPRF = (long)(Math.Round(A454ProfComisionesRubrosValor, 18, MidpointRounding.ToEven));
            }
            else
            {
               if ( ( StringUtil.StrCmp(A453ProfComisionesRubrosTipo, context.GetMessage( "P", "")) == 0 ) && ( A454ProfComisionesRubrosValor > Convert.ToDecimal( 0 )) )
               {
                  A457ProfComisionesRubrosGanPRF = (long)(A181InventarioPrecioFinal*(A454ProfComisionesRubrosValor/ (decimal)(100)));
               }
               else
               {
                  A457ProfComisionesRubrosGanPRF = 0;
               }
            }
            A456ProfComisionesRubrosGan = (long)(A181InventarioPrecioFinal-A457ProfComisionesRubrosGanPRF);
         }
      }

      protected void EndLevel1O67( )
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

      public void ScanStart1O67( )
      {
         /* Scan By routine */
         /* Using cursor T001O29 */
         pr_default.execute(27, new Object[] {A450ProfComisionesID});
         RcdFound67 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound67 = 1;
            A452ProfComisionesRubrosId = T001O29_A452ProfComisionesRubrosId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1O67( )
      {
         /* Scan next routine */
         pr_default.readNext(27);
         RcdFound67 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound67 = 1;
            A452ProfComisionesRubrosId = T001O29_A452ProfComisionesRubrosId[0];
         }
      }

      protected void ScanEnd1O67( )
      {
         pr_default.close(27);
      }

      protected void AfterConfirm1O67( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1O67( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1O67( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1O67( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1O67( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1O67( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1O67( )
      {
         edtProfComisionesRubrosId_Enabled = 0;
         AssignProp("", false, edtProfComisionesRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesRubrosId_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         dynRubrosId.Enabled = 0;
         AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), !bGXsfl_68_Refreshing);
         dynMedidasID.Enabled = 0;
         AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_68_Refreshing);
         dynInventarioId.Enabled = 0;
         AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtInventarioPrecioFinal_Enabled = 0;
         AssignProp("", false, edtInventarioPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         cmbProfComisionesRubrosTipo.Enabled = 0;
         AssignProp("", false, cmbProfComisionesRubrosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProfComisionesRubrosTipo.Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtProfComisionesRubrosValor_Enabled = 0;
         AssignProp("", false, edtProfComisionesRubrosValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesRubrosValor_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtProfComisionesRubrosGanPRF_Enabled = 0;
         AssignProp("", false, edtProfComisionesRubrosGanPRF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesRubrosGanPRF_Enabled), 5, 0), !bGXsfl_68_Refreshing);
         edtProfComisionesRubrosGan_Enabled = 0;
         AssignProp("", false, edtProfComisionesRubrosGan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesRubrosGan_Enabled), 5, 0), !bGXsfl_68_Refreshing);
      }

      protected void send_integrity_lvl_hashes1O67( )
      {
      }

      protected void send_integrity_lvl_hashes1O66( )
      {
      }

      protected void SubsflControlProps_6867( )
      {
         edtProfComisionesRubrosId_Internalname = "PROFCOMISIONESRUBROSID_"+sGXsfl_68_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_68_idx;
         imgprompt_133_Internalname = "PROMPT_133_"+sGXsfl_68_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_68_idx;
         dynRubrosId_Internalname = "RUBROSID_"+sGXsfl_68_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_68_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_68_idx;
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL_"+sGXsfl_68_idx;
         cmbProfComisionesRubrosTipo_Internalname = "PROFCOMISIONESRUBROSTIPO_"+sGXsfl_68_idx;
         edtProfComisionesRubrosValor_Internalname = "PROFCOMISIONESRUBROSVALOR_"+sGXsfl_68_idx;
         edtProfComisionesRubrosGanPRF_Internalname = "PROFCOMISIONESRUBROSGANPRF_"+sGXsfl_68_idx;
         edtProfComisionesRubrosGan_Internalname = "PROFCOMISIONESRUBROSGAN_"+sGXsfl_68_idx;
      }

      protected void SubsflControlProps_fel_6867( )
      {
         edtProfComisionesRubrosId_Internalname = "PROFCOMISIONESRUBROSID_"+sGXsfl_68_fel_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_68_fel_idx;
         imgprompt_133_Internalname = "PROMPT_133_"+sGXsfl_68_fel_idx;
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE_"+sGXsfl_68_fel_idx;
         dynRubrosId_Internalname = "RUBROSID_"+sGXsfl_68_fel_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_68_fel_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_68_fel_idx;
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL_"+sGXsfl_68_fel_idx;
         cmbProfComisionesRubrosTipo_Internalname = "PROFCOMISIONESRUBROSTIPO_"+sGXsfl_68_fel_idx;
         edtProfComisionesRubrosValor_Internalname = "PROFCOMISIONESRUBROSVALOR_"+sGXsfl_68_fel_idx;
         edtProfComisionesRubrosGanPRF_Internalname = "PROFCOMISIONESRUBROSGANPRF_"+sGXsfl_68_fel_idx;
         edtProfComisionesRubrosGan_Internalname = "PROFCOMISIONESRUBROSGAN_"+sGXsfl_68_fel_idx;
      }

      protected void AddRow1O67( )
      {
         nGXsfl_68_idx = (int)(nGXsfl_68_idx+1);
         sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
         SubsflControlProps_6867( ) ;
         SendRow1O67( ) ;
      }

      protected void SendRow1O67( )
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
            if ( ((int)((nGXsfl_68_idx) % (2))) == 0 )
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
         imgprompt_133_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"proveedorprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROVEEDORID_"+sGXsfl_68_idx+"'), id:'"+"PROVEEDORID_"+sGXsfl_68_idx+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"PROVEEDORNOMBRE_"+sGXsfl_68_idx+"'), id:'"+"PROVEEDORNOMBRE_"+sGXsfl_68_idx+"'"+",IOType:'inout'}"+"],"+"gx.dom.form()."+"nIsMod_67_"+sGXsfl_68_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A452ProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProfComisionesRubrosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A452ProfComisionesRubrosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A452ProfComisionesRubrosId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,69);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfComisionesRubrosId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProveedorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,70);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorID_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_133_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_133_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_rubrosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_133_Internalname,(string)sImgUrl,(string)imgprompt_133_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_133_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorNombre_Internalname,StringUtil.RTrim( A282ProveedorNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         GXARUBROSID_html1O67( ) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_68_idx + "',68)\"";
         if ( ( dynRubrosId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_68_idx;
            dynRubrosId.Name = GXCCtl;
            dynRubrosId.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynRubrosId,(string)dynRubrosId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0)),(short)1,(string)dynRubrosId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynRubrosId.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"",(string)"",(bool)true,(short)0});
         dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
         AssignProp("", false, dynRubrosId_Internalname, "Values", (string)(dynRubrosId.ToJavascriptSource()), !bGXsfl_68_Refreshing);
         GXAMEDIDASID_html1O67( A121RubrosId) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_68_idx + "',68)\"";
         if ( ( dynMedidasID.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "MEDIDASID_" + sGXsfl_68_idx;
            dynMedidasID.Name = GXCCtl;
            dynMedidasID.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynMedidasID,(string)dynMedidasID_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)),(short)1,(string)dynMedidasID_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynMedidasID.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"",(string)"",(bool)true,(short)0});
         dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         AssignProp("", false, dynMedidasID_Internalname, "Values", (string)(dynMedidasID.ToJavascriptSource()), !bGXsfl_68_Refreshing);
         GXAINVENTARIOID_html1O67( A121RubrosId, A137MedidasID) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_68_idx + "',68)\"";
         if ( ( dynInventarioId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "INVENTARIOID_" + sGXsfl_68_idx;
            dynInventarioId.Name = GXCCtl;
            dynInventarioId.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynInventarioId,(string)dynInventarioId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0)),(short)1,(string)dynInventarioId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynInventarioId.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"",(string)"",(bool)true,(short)0});
         dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         AssignProp("", false, dynInventarioId_Internalname, "Values", (string)(dynInventarioId.ToJavascriptSource()), !bGXsfl_68_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtInventarioPrecioFinal_Enabled!=0) ? context.localUtil.Format( A181InventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A181InventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,75);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtInventarioPrecioFinal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_68_idx + "',68)\"";
         GXCCtl = "PROFCOMISIONESRUBROSTIPO_" + sGXsfl_68_idx;
         cmbProfComisionesRubrosTipo.Name = GXCCtl;
         cmbProfComisionesRubrosTipo.WebTags = "";
         cmbProfComisionesRubrosTipo.addItem("F", context.GetMessage( "Valor Fijo", ""), 0);
         cmbProfComisionesRubrosTipo.addItem("P", context.GetMessage( "Porcentaje", ""), 0);
         if ( cmbProfComisionesRubrosTipo.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A453ProfComisionesRubrosTipo)) )
            {
               A453ProfComisionesRubrosTipo = context.GetMessage( "F", "");
            }
         }
         /* ComboBox */
         Gridlevel_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProfComisionesRubrosTipo,(string)cmbProfComisionesRubrosTipo_Internalname,StringUtil.RTrim( A453ProfComisionesRubrosTipo),(short)1,(string)cmbProfComisionesRubrosTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbProfComisionesRubrosTipo.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"",(string)"",(bool)true,(short)0});
         cmbProfComisionesRubrosTipo.CurrentValue = StringUtil.RTrim( A453ProfComisionesRubrosTipo);
         AssignProp("", false, cmbProfComisionesRubrosTipo_Internalname, "Values", (string)(cmbProfComisionesRubrosTipo.ToJavascriptSource()), !bGXsfl_68_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesRubrosValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A454ProfComisionesRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProfComisionesRubrosValor_Enabled!=0) ? context.localUtil.Format( A454ProfComisionesRubrosValor, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A454ProfComisionesRubrosValor, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,77);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesRubrosValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfComisionesRubrosValor_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesRubrosGanPRF_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A457ProfComisionesRubrosGanPRF), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProfComisionesRubrosGanPRF_Enabled!=0) ? context.localUtil.Format( (decimal)(A457ProfComisionesRubrosGanPRF), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A457ProfComisionesRubrosGanPRF), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,78);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesRubrosGanPRF_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfComisionesRubrosGanPRF_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_67_" + sGXsfl_68_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_68_idx + "',68)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfComisionesRubrosGan_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A456ProfComisionesRubrosGan), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProfComisionesRubrosGan_Enabled!=0) ? context.localUtil.Format( (decimal)(A456ProfComisionesRubrosGan), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A456ProfComisionesRubrosGan), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,79);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfComisionesRubrosGan_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfComisionesRubrosGan_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)68,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_rubrosRow);
         send_integrity_lvl_hashes1O67( ) ;
         GXCCtl = "Z452ProfComisionesRubrosId_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z452ProfComisionesRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z453ProfComisionesRubrosTipo_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z453ProfComisionesRubrosTipo));
         GXCCtl = "Z454ProfComisionesRubrosValor_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z454ProfComisionesRubrosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z133ProveedorID_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z121RubrosId_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z137MedidasID_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z135InventarioId_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_67_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_67), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_67_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_67), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_67_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_67), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_68_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPROFCOMISIONESID_" + sGXsfl_68_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProfComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROFCOMISIONESRUBROSID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORNOMBRE_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RUBROSID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynRubrosId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MEDIDASID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOID_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOPRECIOFINAL_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFCOMISIONESRUBROSTIPO_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProfComisionesRubrosTipo.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFCOMISIONESRUBROSVALOR_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosValor_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFCOMISIONESRUBROSGANPRF_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosGanPRF_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFCOMISIONESRUBROSGAN_"+sGXsfl_68_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosGan_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_133_"+sGXsfl_68_idx+"Link", StringUtil.RTrim( imgprompt_133_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_rubrosContainer.AddRow(Gridlevel_rubrosRow);
      }

      protected void ReadRow1O67( )
      {
         nGXsfl_68_idx = (int)(nGXsfl_68_idx+1);
         sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
         SubsflControlProps_6867( ) ;
         edtProfComisionesRubrosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFCOMISIONESRUBROSID_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORID_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORNOMBRE_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynRubrosId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynMedidasID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASID_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynInventarioId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOID_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtInventarioPrecioFinal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOPRECIOFINAL_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbProfComisionesRubrosTipo.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFCOMISIONESRUBROSTIPO_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfComisionesRubrosValor_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFCOMISIONESRUBROSVALOR_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfComisionesRubrosGanPRF_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFCOMISIONESRUBROSGANPRF_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfComisionesRubrosGan_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFCOMISIONESRUBROSGAN_"+sGXsfl_68_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_120_Link = cgiGet( "PROMPT_133_"+sGXsfl_68_idx+"Link");
         A452ProfComisionesRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "PROVEEDORID_" + sGXsfl_68_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            wbErr = true;
            A133ProveedorID = 0;
            n133ProveedorID = false;
         }
         else
         {
            A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n133ProveedorID = false;
         }
         n133ProveedorID = ((0==A133ProveedorID) ? true : false);
         A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
         dynRubrosId.Name = dynRubrosId_Internalname;
         dynRubrosId.CurrentValue = cgiGet( dynRubrosId_Internalname);
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynRubrosId_Internalname), "."), 18, MidpointRounding.ToEven));
         dynMedidasID.Name = dynMedidasID_Internalname;
         dynMedidasID.CurrentValue = cgiGet( dynMedidasID_Internalname);
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynMedidasID_Internalname), "."), 18, MidpointRounding.ToEven));
         dynInventarioId.Name = dynInventarioId_Internalname;
         dynInventarioId.CurrentValue = cgiGet( dynInventarioId_Internalname);
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynInventarioId_Internalname), "."), 18, MidpointRounding.ToEven));
         A181InventarioPrecioFinal = context.localUtil.CToN( cgiGet( edtInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         cmbProfComisionesRubrosTipo.Name = cmbProfComisionesRubrosTipo_Internalname;
         cmbProfComisionesRubrosTipo.CurrentValue = cgiGet( cmbProfComisionesRubrosTipo_Internalname);
         A453ProfComisionesRubrosTipo = cgiGet( cmbProfComisionesRubrosTipo_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtProfComisionesRubrosValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProfComisionesRubrosValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
         {
            GXCCtl = "PROFCOMISIONESRUBROSVALOR_" + sGXsfl_68_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfComisionesRubrosValor_Internalname;
            wbErr = true;
            A454ProfComisionesRubrosValor = 0;
         }
         else
         {
            A454ProfComisionesRubrosValor = context.localUtil.CToN( cgiGet( edtProfComisionesRubrosValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         }
         A457ProfComisionesRubrosGanPRF = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesRubrosGanPRF_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A456ProfComisionesRubrosGan = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfComisionesRubrosGan_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z452ProfComisionesRubrosId_" + sGXsfl_68_idx;
         Z452ProfComisionesRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z453ProfComisionesRubrosTipo_" + sGXsfl_68_idx;
         Z453ProfComisionesRubrosTipo = cgiGet( GXCCtl);
         GXCCtl = "Z454ProfComisionesRubrosValor_" + sGXsfl_68_idx;
         Z454ProfComisionesRubrosValor = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z133ProveedorID_" + sGXsfl_68_idx;
         Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n133ProveedorID = ((0==A133ProveedorID) ? true : false);
         GXCCtl = "Z121RubrosId_" + sGXsfl_68_idx;
         Z121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z137MedidasID_" + sGXsfl_68_idx;
         Z137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z135InventarioId_" + sGXsfl_68_idx;
         Z135InventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_67_" + sGXsfl_68_idx;
         nRcdDeleted_67 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_67_" + sGXsfl_68_idx;
         nRcdExists_67 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_67_" + sGXsfl_68_idx;
         nIsMod_67 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtProfComisionesRubrosId_Enabled = edtProfComisionesRubrosId_Enabled;
      }

      protected void ConfirmValues1O0( )
      {
         nGXsfl_68_idx = 0;
         sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
         SubsflControlProps_6867( ) ;
         while ( nGXsfl_68_idx < nRC_GXsfl_68 )
         {
            nGXsfl_68_idx = (int)(nGXsfl_68_idx+1);
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_6867( ) ;
            ChangePostValue( "Z452ProfComisionesRubrosId_"+sGXsfl_68_idx, cgiGet( "ZT_"+"Z452ProfComisionesRubrosId_"+sGXsfl_68_idx)) ;
            DeletePostValue( "ZT_"+"Z452ProfComisionesRubrosId_"+sGXsfl_68_idx) ;
            ChangePostValue( "Z453ProfComisionesRubrosTipo_"+sGXsfl_68_idx, cgiGet( "ZT_"+"Z453ProfComisionesRubrosTipo_"+sGXsfl_68_idx)) ;
            DeletePostValue( "ZT_"+"Z453ProfComisionesRubrosTipo_"+sGXsfl_68_idx) ;
            ChangePostValue( "Z454ProfComisionesRubrosValor_"+sGXsfl_68_idx, cgiGet( "ZT_"+"Z454ProfComisionesRubrosValor_"+sGXsfl_68_idx)) ;
            DeletePostValue( "ZT_"+"Z454ProfComisionesRubrosValor_"+sGXsfl_68_idx) ;
            ChangePostValue( "Z133ProveedorID_"+sGXsfl_68_idx, cgiGet( "ZT_"+"Z133ProveedorID_"+sGXsfl_68_idx)) ;
            DeletePostValue( "ZT_"+"Z133ProveedorID_"+sGXsfl_68_idx) ;
            ChangePostValue( "Z121RubrosId_"+sGXsfl_68_idx, cgiGet( "ZT_"+"Z121RubrosId_"+sGXsfl_68_idx)) ;
            DeletePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_68_idx) ;
            ChangePostValue( "Z137MedidasID_"+sGXsfl_68_idx, cgiGet( "ZT_"+"Z137MedidasID_"+sGXsfl_68_idx)) ;
            DeletePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_68_idx) ;
            ChangePostValue( "Z135InventarioId_"+sGXsfl_68_idx, cgiGet( "ZT_"+"Z135InventarioId_"+sGXsfl_68_idx)) ;
            DeletePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_68_idx) ;
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
         GXEncryptionTmp = "profcomisiones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ProfComisionesID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profcomisiones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ProfComisiones");
         forbiddenHiddens.Add("ProfComisionesID", context.localUtil.Format( (decimal)(A450ProfComisionesID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ProfesionalesId", StringUtil.RTrim( context.localUtil.Format( AV11Insert_ProfesionalesId, "")));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("profcomisiones:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z450ProfComisionesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z450ProfComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z451ProfComisionesAutoEnun", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z451ProfComisionesAutoEnun), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z120ProfesionalesId", StringUtil.RTrim( Z120ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "O451ProfComisionesAutoEnun", StringUtil.LTrim( StringUtil.NToC( (decimal)(O451ProfComisionesAutoEnun), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_68", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_68_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N120ProfesionalesId", StringUtil.RTrim( A120ProfesionalesId));
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
         GxWebStd.gx_hidden_field( context, "vPROFCOMISIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProfComisionesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFCOMISIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProfComisionesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROFESIONALESID", StringUtil.RTrim( AV11Insert_ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "PROFCOMISIONESAUTOENUN", StringUtil.LTrim( StringUtil.NToC( (decimal)(A451ProfComisionesAutoEnun), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESPHOTO_GXI", A40000ProfesionalesPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOCOSTO", StringUtil.LTrim( StringUtil.NToC( A190InventarioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtlgxBlob = "PROFESIONALESPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A169ProfesionalesPhoto);
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
         GXEncryptionTmp = "profcomisiones.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ProfComisionesID,18,0));
         return formatLink("profcomisiones.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ProfComisiones" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Comisiones para Profesionales", "") ;
      }

      protected void InitializeNonKey1O66( )
      {
         A120ProfesionalesId = "";
         AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
         A166ProfesionalesPrimerNombre = "";
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
         A191ProfesionalesSegundoNombre = "";
         AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
         A167ProfesionalesApellidoPrimero = "";
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
         A192ProfesionalesApellidoSegundo = "";
         AssignAttri("", false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
         A169ProfesionalesPhoto = "";
         AssignAttri("", false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
         A40000ProfesionalesPhoto_GXI = "";
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
         A170ProfesionalesTelefono = "";
         AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
         A451ProfComisionesAutoEnun = 0;
         AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
         O451ProfComisionesAutoEnun = A451ProfComisionesAutoEnun;
         AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
         Z451ProfComisionesAutoEnun = 0;
         Z120ProfesionalesId = "";
      }

      protected void InitAll1O66( )
      {
         A450ProfComisionesID = 0;
         AssignAttri("", false, "A450ProfComisionesID", StringUtil.LTrimStr( (decimal)(A450ProfComisionesID), 18, 0));
         InitializeNonKey1O66( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1O67( )
      {
         A454ProfComisionesRubrosValor = 0;
         A456ProfComisionesRubrosGan = 0;
         A457ProfComisionesRubrosGanPRF = 0;
         A133ProveedorID = 0;
         n133ProveedorID = false;
         A282ProveedorNombre = "";
         A121RubrosId = 0;
         A137MedidasID = 0;
         A135InventarioId = 0;
         A190InventarioCosto = 0;
         AssignAttri("", false, "A190InventarioCosto", StringUtil.LTrimStr( A190InventarioCosto, 18, 2));
         A181InventarioPrecioFinal = 0;
         A453ProfComisionesRubrosTipo = context.GetMessage( "F", "");
         Z453ProfComisionesRubrosTipo = "";
         Z454ProfComisionesRubrosValor = 0;
         Z133ProveedorID = 0;
         Z121RubrosId = 0;
         Z137MedidasID = 0;
         Z135InventarioId = 0;
      }

      protected void InitAll1O67( )
      {
         A452ProfComisionesRubrosId = 0;
         InitializeNonKey1O67( ) ;
      }

      protected void StandaloneModalInsert1O67( )
      {
         A451ProfComisionesAutoEnun = i451ProfComisionesAutoEnun;
         AssignAttri("", false, "A451ProfComisionesAutoEnun", StringUtil.LTrimStr( (decimal)(A451ProfComisionesAutoEnun), 4, 0));
         A453ProfComisionesRubrosTipo = i453ProfComisionesRubrosTipo;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932042897", true, true, false);
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
         context.AddJavascriptSource("profcomisiones.js", "?2026932042897", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties67( )
      {
         edtProfComisionesRubrosId_Enabled = defedtProfComisionesRubrosId_Enabled;
         AssignProp("", false, edtProfComisionesRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfComisionesRubrosId_Enabled), 5, 0), !bGXsfl_68_Refreshing);
      }

      protected void StartGridControl68( )
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
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A452ProfComisionesRubrosId), 18, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosId_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorID_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A282ProveedorNombre)));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynRubrosId.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A453ProfComisionesRubrosTipo)));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProfComisionesRubrosTipo.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A454ProfComisionesRubrosValor, 18, 2, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosValor_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A457ProfComisionesRubrosGanPRF), 18, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosGanPRF_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A456ProfComisionesRubrosGan), 18, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfComisionesRubrosGan_Enabled), 5, 0, ".", "")));
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
         edtProfComisionesID_Internalname = "PROFCOMISIONESID";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO";
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO";
         divTb1_Internalname = "TB1";
         imgProfesionalesPhoto_Internalname = "PROFESIONALESPHOTO";
         divTb2_Internalname = "TB2";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtProfComisionesRubrosId_Internalname = "PROFCOMISIONESRUBROSID";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         dynRubrosId_Internalname = "RUBROSID";
         dynMedidasID_Internalname = "MEDIDASID";
         dynInventarioId_Internalname = "INVENTARIOID";
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL";
         cmbProfComisionesRubrosTipo_Internalname = "PROFCOMISIONESRUBROSTIPO";
         edtProfComisionesRubrosValor_Internalname = "PROFCOMISIONESRUBROSVALOR";
         edtProfComisionesRubrosGanPRF_Internalname = "PROFCOMISIONESRUBROSGANPRF";
         edtProfComisionesRubrosGan_Internalname = "PROFCOMISIONESRUBROSGAN";
         divTableleaflevel_rubros_Internalname = "TABLELEAFLEVEL_RUBROS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_120_Internalname = "PROMPT_120";
         imgprompt_133_Internalname = "PROMPT_133";
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
         Form.Caption = context.GetMessage( "Comisiones para Profesionales", "");
         edtProfComisionesRubrosGan_Jsonclick = "";
         edtProfComisionesRubrosGanPRF_Jsonclick = "";
         edtProfComisionesRubrosValor_Jsonclick = "";
         cmbProfComisionesRubrosTipo_Jsonclick = "";
         edtInventarioPrecioFinal_Jsonclick = "";
         dynInventarioId_Jsonclick = "";
         dynMedidasID_Jsonclick = "";
         dynRubrosId_Jsonclick = "";
         edtProveedorNombre_Jsonclick = "";
         imgprompt_133_Visible = 1;
         imgprompt_133_Link = "";
         imgprompt_120_Visible = 1;
         edtProveedorID_Jsonclick = "";
         edtProfComisionesRubrosId_Jsonclick = "";
         subGridlevel_rubros_Class = "WorkWith";
         subGridlevel_rubros_Backcolorstyle = 0;
         edtProfComisionesRubrosGan_Enabled = 0;
         edtProfComisionesRubrosGanPRF_Enabled = 0;
         edtProfComisionesRubrosValor_Enabled = 1;
         cmbProfComisionesRubrosTipo.Enabled = 1;
         edtInventarioPrecioFinal_Enabled = 0;
         dynInventarioId.Enabled = 1;
         dynMedidasID.Enabled = 1;
         dynRubrosId.Enabled = 1;
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Enabled = 1;
         edtProfComisionesRubrosId_Enabled = 0;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         imgProfesionalesPhoto_Enabled = 0;
         edtProfesionalesTelefono_Jsonclick = "";
         edtProfesionalesTelefono_Enabled = 0;
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Enabled = 0;
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Enabled = 0;
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesSegundoNombre_Enabled = 0;
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Enabled = 0;
         imgprompt_120_Visible = 1;
         imgprompt_120_Link = "";
         edtProfesionalesId_Jsonclick = "";
         edtProfesionalesId_Enabled = 1;
         edtProfComisionesID_Jsonclick = "";
         edtProfComisionesID_Enabled = 0;
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
         GXAMEDIDASID_html1O67( A121RubrosId) ;
         GXAINVENTARIOID_html1O67( A121RubrosId, A137MedidasID) ;
         /* End function dynload_actions */
      }

      protected void GXDLARUBROSID1O67( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLARUBROSID_data1O67( ) ;
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

      protected void GXARUBROSID_html1O67( )
      {
         short gxdynajaxvalue;
         GXDLARUBROSID_data1O67( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynRubrosId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynRubrosId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLARUBROSID_data1O67( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T001O30 */
         pr_default.execute(28);
         while ( (pr_default.getStatus(28) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001O30_A121RubrosId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T001O30_A122RubrosNombre[0]));
            pr_default.readNext(28);
         }
         pr_default.close(28);
      }

      protected void GXDLAMEDIDASID1O67( short A121RubrosId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMEDIDASID_data1O67( A121RubrosId) ;
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

      protected void GXAMEDIDASID_html1O67( short A121RubrosId )
      {
         long gxdynajaxvalue;
         GXDLAMEDIDASID_data1O67( A121RubrosId) ;
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

      protected void GXDLAMEDIDASID_data1O67( short A121RubrosId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T001O31 */
         pr_default.execute(29, new Object[] {A121RubrosId});
         while ( (pr_default.getStatus(29) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001O31_A137MedidasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T001O31_A138MedidasNombre[0]));
            pr_default.readNext(29);
         }
         pr_default.close(29);
      }

      protected void GXDLAINVENTARIOID1O67( short A121RubrosId ,
                                            long A137MedidasID )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAINVENTARIOID_data1O67( A121RubrosId, A137MedidasID) ;
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

      protected void GXAINVENTARIOID_html1O67( short A121RubrosId ,
                                               long A137MedidasID )
      {
         long gxdynajaxvalue;
         GXDLAINVENTARIOID_data1O67( A121RubrosId, A137MedidasID) ;
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

      protected void GXDLAINVENTARIOID_data1O67( short A121RubrosId ,
                                                 long A137MedidasID )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T001O32 */
         pr_default.execute(30, new Object[] {A121RubrosId, A137MedidasID});
         while ( (pr_default.getStatus(30) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001O32_A135InventarioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T001O32_A136InventarioNombre[0]));
            pr_default.readNext(30);
         }
         pr_default.close(30);
      }

      protected void gxnrGridlevel_rubros_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_6867( ) ;
         while ( nGXsfl_68_idx <= nRC_GXsfl_68 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1O67( ) ;
            standaloneModal1O67( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1O67( ) ;
            nGXsfl_68_idx = (int)(nGXsfl_68_idx+1);
            sGXsfl_68_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_68_idx), 4, 0), 4, "0");
            SubsflControlProps_6867( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_rubrosContainer)) ;
         /* End function gxnrGridlevel_rubros_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "RUBROSID_" + sGXsfl_68_idx;
         dynRubrosId.Name = GXCCtl;
         dynRubrosId.WebTags = "";
         GXCCtl = "MEDIDASID_" + sGXsfl_68_idx;
         dynMedidasID.Name = GXCCtl;
         dynMedidasID.WebTags = "";
         GXCCtl = "INVENTARIOID_" + sGXsfl_68_idx;
         dynInventarioId.Name = GXCCtl;
         dynInventarioId.WebTags = "";
         GXCCtl = "PROFCOMISIONESRUBROSTIPO_" + sGXsfl_68_idx;
         cmbProfComisionesRubrosTipo.Name = GXCCtl;
         cmbProfComisionesRubrosTipo.WebTags = "";
         cmbProfComisionesRubrosTipo.addItem("F", context.GetMessage( "Valor Fijo", ""), 0);
         cmbProfComisionesRubrosTipo.addItem("P", context.GetMessage( "Porcentaje", ""), 0);
         if ( cmbProfComisionesRubrosTipo.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A453ProfComisionesRubrosTipo)) )
            {
               A453ProfComisionesRubrosTipo = context.GetMessage( "F", "");
            }
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

      public void Valid_Profesionalesid( )
      {
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T001O17 */
         pr_default.execute(15, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesionales", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
         }
         A166ProfesionalesPrimerNombre = T001O17_A166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T001O17_A191ProfesionalesSegundoNombre[0];
         A167ProfesionalesApellidoPrimero = T001O17_A167ProfesionalesApellidoPrimero[0];
         A192ProfesionalesApellidoSegundo = T001O17_A192ProfesionalesApellidoSegundo[0];
         A40000ProfesionalesPhoto_GXI = T001O17_A40000ProfesionalesPhoto_GXI[0];
         A170ProfesionalesTelefono = T001O17_A170ProfesionalesTelefono[0];
         A169ProfesionalesPhoto = T001O17_A169ProfesionalesPhoto[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", StringUtil.RTrim( A166ProfesionalesPrimerNombre));
         AssignAttri("", false, "A191ProfesionalesSegundoNombre", StringUtil.RTrim( A191ProfesionalesSegundoNombre));
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", StringUtil.RTrim( A167ProfesionalesApellidoPrimero));
         AssignAttri("", false, "A192ProfesionalesApellidoSegundo", StringUtil.RTrim( A192ProfesionalesApellidoSegundo));
         AssignAttri("", false, "A169ProfesionalesPhoto", context.PathToRelativeUrl( A169ProfesionalesPhoto));
         GXCCtlgxBlob = "PROFESIONALESPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A169ProfesionalesPhoto));
         AssignAttri("", false, "A40000ProfesionalesPhoto_GXI", A40000ProfesionalesPhoto_GXI);
         AssignAttri("", false, "A170ProfesionalesTelefono", StringUtil.RTrim( A170ProfesionalesTelefono));
      }

      public void Valid_Proveedorid( )
      {
         n133ProveedorID = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T001O33 */
         pr_default.execute(31, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(31) == 101) )
         {
            if ( ! ( (0==A133ProveedorID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
               AnyError = 1;
               GX_FocusControl = edtProveedorID_Internalname;
            }
         }
         A282ProveedorNombre = T001O33_A282ProveedorNombre[0];
         pr_default.close(31);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A282ProveedorNombre", StringUtil.RTrim( A282ProveedorNombre));
      }

      public void Valid_Rubrosid( )
      {
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
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
         AssignAttri("", false, "A137MedidasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", "")));
         dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         AssignProp("", false, dynMedidasID_Internalname, "Values", dynMedidasID.ToJavascriptSource(), true);
         AssignAttri("", false, "A135InventarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", "")));
         dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         AssignProp("", false, dynInventarioId_Internalname, "Values", dynInventarioId.ToJavascriptSource(), true);
      }

      public void Valid_Medidasid( )
      {
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         dynload_actions( ) ;
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
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T001O34 */
         pr_default.execute(32, new Object[] {A121RubrosId, A137MedidasID, A135InventarioId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "INVENTARIOID");
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
         }
         A190InventarioCosto = T001O34_A190InventarioCosto[0];
         A181InventarioPrecioFinal = T001O34_A181InventarioPrecioFinal[0];
         pr_default.close(32);
         if ( true /* After */ && ( A190InventarioCosto > Convert.ToDecimal( 0 )) && ( A454ProfComisionesRubrosValor == Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            A454ProfComisionesRubrosValor = A190InventarioCosto;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A190InventarioCosto", StringUtil.LTrim( StringUtil.NToC( A190InventarioCosto, 18, 2, ".", "")));
         AssignAttri("", false, "A181InventarioPrecioFinal", StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", "")));
         AssignAttri("", false, "A454ProfComisionesRubrosValor", StringUtil.LTrim( StringUtil.NToC( A454ProfComisionesRubrosValor, 18, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ProfComisionesID',fld:'vPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ProfComisionesID',fld:'vPROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A450ProfComisionesID',fld:'PROFCOMISIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11Insert_ProfesionalesId',fld:'vINSERT_PROFESIONALESID',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121O2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PROFCOMISIONESID","{handler:'Valid_Profcomisionesid',iparms:[]");
         setEventMetadata("VALID_PROFCOMISIONESID",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A191ProfesionalesSegundoNombre',fld:'PROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'A192ProfesionalesApellidoSegundo',fld:'PROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'A169ProfesionalesPhoto',fld:'PROFESIONALESPHOTO',pic:'',type:'bits'},{av:'A40000ProfesionalesPhoto_GXI',fld:'PROFESIONALESPHOTO_GXI',pic:'',type:'svchar'},{av:'A170ProfesionalesTelefono',fld:'PROFESIONALESTELEFONO',pic:'',type:'char'}]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A191ProfesionalesSegundoNombre',fld:'PROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'A192ProfesionalesApellidoSegundo',fld:'PROFESIONALESAPELLIDOSEGUNDO',pic:'',type:'char'},{av:'A169ProfesionalesPhoto',fld:'PROFESIONALESPHOTO',pic:'',type:'bits'},{av:'A40000ProfesionalesPhoto_GXI',fld:'PROFESIONALESPHOTO_GXI',pic:'',type:'svchar'},{av:'A170ProfesionalesTelefono',fld:'PROFESIONALESTELEFONO',pic:'',type:'char'}]}");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSID","{handler:'Valid_Profcomisionesrubrosid',iparms:[]");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSID",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'}]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'}]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_RUBROSID",",oparms:[{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_INVENTARIOID","{handler:'Valid_Inventarioid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'A190InventarioCosto',fld:'INVENTARIOCOSTO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A181InventarioPrecioFinal',fld:'INVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A454ProfComisionesRubrosValor',fld:'PROFCOMISIONESRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]");
         setEventMetadata("VALID_INVENTARIOID",",oparms:[{av:'A190InventarioCosto',fld:'INVENTARIOCOSTO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A181InventarioPrecioFinal',fld:'INVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A454ProfComisionesRubrosValor',fld:'PROFCOMISIONESRUBROSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'}]}");
         setEventMetadata("VALID_INVENTARIOPRECIOFINAL","{handler:'Valid_Inventariopreciofinal',iparms:[]");
         setEventMetadata("VALID_INVENTARIOPRECIOFINAL",",oparms:[]}");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSTIPO","{handler:'Valid_Profcomisionesrubrostipo',iparms:[]");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSTIPO",",oparms:[]}");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSVALOR","{handler:'Valid_Profcomisionesrubrosvalor',iparms:[]");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSVALOR",",oparms:[]}");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSGANPRF","{handler:'Valid_Profcomisionesrubrosganprf',iparms:[]");
         setEventMetadata("VALID_PROFCOMISIONESRUBROSGANPRF",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Profcomisionesrubrosgan',iparms:[]");
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
         pr_default.close(25);
         pr_default.close(32);
         pr_default.close(26);
         pr_default.close(5);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z120ProfesionalesId = "";
         N120ProfesionalesId = "";
         Z453ProfComisionesRubrosTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A120ProfesionalesId = "";
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
         imgprompt_120_gximage = "";
         sImgUrl = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         gxphoneLink = "";
         A170ProfesionalesTelefono = "";
         A169ProfesionalesPhoto = "";
         A40000ProfesionalesPhoto_GXI = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_rubrosContainer = new GXWebGrid( context);
         sMode67 = "";
         sStyleString = "";
         AV11Insert_ProfesionalesId = "";
         AV28Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode66 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A282ProveedorNombre = "";
         A453ProfComisionesRubrosTipo = "";
         AV13WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z166ProfesionalesPrimerNombre = "";
         Z191ProfesionalesSegundoNombre = "";
         Z167ProfesionalesApellidoPrimero = "";
         Z192ProfesionalesApellidoSegundo = "";
         Z169ProfesionalesPhoto = "";
         Z40000ProfesionalesPhoto_GXI = "";
         Z170ProfesionalesTelefono = "";
         T001O8_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T001O8_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T001O8_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T001O8_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T001O8_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         T001O8_A170ProfesionalesTelefono = new string[] {""} ;
         T001O8_A169ProfesionalesPhoto = new string[] {""} ;
         T001O9_A450ProfComisionesID = new long[1] ;
         T001O9_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T001O9_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T001O9_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T001O9_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T001O9_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         T001O9_A170ProfesionalesTelefono = new string[] {""} ;
         T001O9_A451ProfComisionesAutoEnun = new short[1] ;
         T001O9_A120ProfesionalesId = new string[] {""} ;
         T001O9_A169ProfesionalesPhoto = new string[] {""} ;
         T001O10_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T001O10_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T001O10_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T001O10_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T001O10_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         T001O10_A170ProfesionalesTelefono = new string[] {""} ;
         T001O10_A169ProfesionalesPhoto = new string[] {""} ;
         T001O11_A450ProfComisionesID = new long[1] ;
         T001O7_A450ProfComisionesID = new long[1] ;
         T001O7_A451ProfComisionesAutoEnun = new short[1] ;
         T001O7_A120ProfesionalesId = new string[] {""} ;
         T001O12_A450ProfComisionesID = new long[1] ;
         T001O13_A450ProfComisionesID = new long[1] ;
         T001O6_A450ProfComisionesID = new long[1] ;
         T001O6_A451ProfComisionesAutoEnun = new short[1] ;
         T001O6_A120ProfesionalesId = new string[] {""} ;
         T001O14_A450ProfComisionesID = new long[1] ;
         T001O17_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T001O17_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T001O17_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T001O17_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T001O17_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         T001O17_A170ProfesionalesTelefono = new string[] {""} ;
         T001O17_A169ProfesionalesPhoto = new string[] {""} ;
         T001O19_A450ProfComisionesID = new long[1] ;
         Z282ProveedorNombre = "";
         T001O5_A190InventarioCosto = new decimal[1] ;
         T001O5_A181InventarioPrecioFinal = new decimal[1] ;
         T001O20_A450ProfComisionesID = new long[1] ;
         T001O20_A452ProfComisionesRubrosId = new long[1] ;
         T001O20_A453ProfComisionesRubrosTipo = new string[] {""} ;
         T001O20_A454ProfComisionesRubrosValor = new decimal[1] ;
         T001O20_A282ProveedorNombre = new string[] {""} ;
         T001O20_A190InventarioCosto = new decimal[1] ;
         T001O20_A181InventarioPrecioFinal = new decimal[1] ;
         T001O20_A133ProveedorID = new long[1] ;
         T001O20_n133ProveedorID = new bool[] {false} ;
         T001O20_A121RubrosId = new short[1] ;
         T001O20_A137MedidasID = new long[1] ;
         T001O20_A135InventarioId = new long[1] ;
         T001O4_A282ProveedorNombre = new string[] {""} ;
         GXCCtl = "";
         T001O21_A282ProveedorNombre = new string[] {""} ;
         T001O22_A190InventarioCosto = new decimal[1] ;
         T001O22_A181InventarioPrecioFinal = new decimal[1] ;
         T001O23_A450ProfComisionesID = new long[1] ;
         T001O23_A452ProfComisionesRubrosId = new long[1] ;
         T001O3_A450ProfComisionesID = new long[1] ;
         T001O3_A452ProfComisionesRubrosId = new long[1] ;
         T001O3_A453ProfComisionesRubrosTipo = new string[] {""} ;
         T001O3_A454ProfComisionesRubrosValor = new decimal[1] ;
         T001O3_A133ProveedorID = new long[1] ;
         T001O3_n133ProveedorID = new bool[] {false} ;
         T001O3_A121RubrosId = new short[1] ;
         T001O3_A137MedidasID = new long[1] ;
         T001O3_A135InventarioId = new long[1] ;
         T001O2_A450ProfComisionesID = new long[1] ;
         T001O2_A452ProfComisionesRubrosId = new long[1] ;
         T001O2_A453ProfComisionesRubrosTipo = new string[] {""} ;
         T001O2_A454ProfComisionesRubrosValor = new decimal[1] ;
         T001O2_A133ProveedorID = new long[1] ;
         T001O2_n133ProveedorID = new bool[] {false} ;
         T001O2_A121RubrosId = new short[1] ;
         T001O2_A137MedidasID = new long[1] ;
         T001O2_A135InventarioId = new long[1] ;
         T001O27_A282ProveedorNombre = new string[] {""} ;
         T001O28_A190InventarioCosto = new decimal[1] ;
         T001O28_A181InventarioPrecioFinal = new decimal[1] ;
         T001O29_A450ProfComisionesID = new long[1] ;
         T001O29_A452ProfComisionesRubrosId = new long[1] ;
         Gridlevel_rubrosRow = new GXWebRow();
         subGridlevel_rubros_Linesclass = "";
         ROClassString = "";
         imgprompt_133_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i453ProfComisionesRubrosTipo = "";
         Gridlevel_rubrosColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T001O30_A121RubrosId = new short[1] ;
         T001O30_A122RubrosNombre = new string[] {""} ;
         T001O30_A123RubrosEstado = new string[] {""} ;
         T001O30_n123RubrosEstado = new bool[] {false} ;
         T001O31_A121RubrosId = new short[1] ;
         T001O31_A137MedidasID = new long[1] ;
         T001O31_A138MedidasNombre = new string[] {""} ;
         T001O31_A139MedidasEstado = new string[] {""} ;
         T001O31_n139MedidasEstado = new bool[] {false} ;
         T001O32_A121RubrosId = new short[1] ;
         T001O32_A137MedidasID = new long[1] ;
         T001O32_A135InventarioId = new long[1] ;
         T001O32_A136InventarioNombre = new string[] {""} ;
         T001O32_A107EstadosTipo = new string[] {""} ;
         T001O32_A108EstadosGenericosId = new int[1] ;
         T001O33_A282ProveedorNombre = new string[] {""} ;
         T001O34_A190InventarioCosto = new decimal[1] ;
         T001O34_A181InventarioPrecioFinal = new decimal[1] ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.profcomisiones__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profcomisiones__default(),
            new Object[][] {
                new Object[] {
               T001O2_A450ProfComisionesID, T001O2_A452ProfComisionesRubrosId, T001O2_A453ProfComisionesRubrosTipo, T001O2_A454ProfComisionesRubrosValor, T001O2_A133ProveedorID, T001O2_n133ProveedorID, T001O2_A121RubrosId, T001O2_A137MedidasID, T001O2_A135InventarioId
               }
               , new Object[] {
               T001O3_A450ProfComisionesID, T001O3_A452ProfComisionesRubrosId, T001O3_A453ProfComisionesRubrosTipo, T001O3_A454ProfComisionesRubrosValor, T001O3_A133ProveedorID, T001O3_n133ProveedorID, T001O3_A121RubrosId, T001O3_A137MedidasID, T001O3_A135InventarioId
               }
               , new Object[] {
               T001O4_A282ProveedorNombre
               }
               , new Object[] {
               T001O5_A190InventarioCosto, T001O5_A181InventarioPrecioFinal
               }
               , new Object[] {
               T001O6_A450ProfComisionesID, T001O6_A451ProfComisionesAutoEnun, T001O6_A120ProfesionalesId
               }
               , new Object[] {
               T001O7_A450ProfComisionesID, T001O7_A451ProfComisionesAutoEnun, T001O7_A120ProfesionalesId
               }
               , new Object[] {
               T001O8_A166ProfesionalesPrimerNombre, T001O8_A191ProfesionalesSegundoNombre, T001O8_A167ProfesionalesApellidoPrimero, T001O8_A192ProfesionalesApellidoSegundo, T001O8_A40000ProfesionalesPhoto_GXI, T001O8_A170ProfesionalesTelefono, T001O8_A169ProfesionalesPhoto
               }
               , new Object[] {
               T001O9_A450ProfComisionesID, T001O9_A166ProfesionalesPrimerNombre, T001O9_A191ProfesionalesSegundoNombre, T001O9_A167ProfesionalesApellidoPrimero, T001O9_A192ProfesionalesApellidoSegundo, T001O9_A40000ProfesionalesPhoto_GXI, T001O9_A170ProfesionalesTelefono, T001O9_A451ProfComisionesAutoEnun, T001O9_A120ProfesionalesId, T001O9_A169ProfesionalesPhoto
               }
               , new Object[] {
               T001O10_A166ProfesionalesPrimerNombre, T001O10_A191ProfesionalesSegundoNombre, T001O10_A167ProfesionalesApellidoPrimero, T001O10_A192ProfesionalesApellidoSegundo, T001O10_A40000ProfesionalesPhoto_GXI, T001O10_A170ProfesionalesTelefono, T001O10_A169ProfesionalesPhoto
               }
               , new Object[] {
               T001O11_A450ProfComisionesID
               }
               , new Object[] {
               T001O12_A450ProfComisionesID
               }
               , new Object[] {
               T001O13_A450ProfComisionesID
               }
               , new Object[] {
               T001O14_A450ProfComisionesID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001O17_A166ProfesionalesPrimerNombre, T001O17_A191ProfesionalesSegundoNombre, T001O17_A167ProfesionalesApellidoPrimero, T001O17_A192ProfesionalesApellidoSegundo, T001O17_A40000ProfesionalesPhoto_GXI, T001O17_A170ProfesionalesTelefono, T001O17_A169ProfesionalesPhoto
               }
               , new Object[] {
               }
               , new Object[] {
               T001O19_A450ProfComisionesID
               }
               , new Object[] {
               T001O20_A450ProfComisionesID, T001O20_A452ProfComisionesRubrosId, T001O20_A453ProfComisionesRubrosTipo, T001O20_A454ProfComisionesRubrosValor, T001O20_A282ProveedorNombre, T001O20_A190InventarioCosto, T001O20_A181InventarioPrecioFinal, T001O20_A133ProveedorID, T001O20_n133ProveedorID, T001O20_A121RubrosId,
               T001O20_A137MedidasID, T001O20_A135InventarioId
               }
               , new Object[] {
               T001O21_A282ProveedorNombre
               }
               , new Object[] {
               T001O22_A190InventarioCosto, T001O22_A181InventarioPrecioFinal
               }
               , new Object[] {
               T001O23_A450ProfComisionesID, T001O23_A452ProfComisionesRubrosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001O27_A282ProveedorNombre
               }
               , new Object[] {
               T001O28_A190InventarioCosto, T001O28_A181InventarioPrecioFinal
               }
               , new Object[] {
               T001O29_A450ProfComisionesID, T001O29_A452ProfComisionesRubrosId
               }
               , new Object[] {
               T001O30_A121RubrosId, T001O30_A122RubrosNombre, T001O30_A123RubrosEstado, T001O30_n123RubrosEstado
               }
               , new Object[] {
               T001O31_A121RubrosId, T001O31_A137MedidasID, T001O31_A138MedidasNombre, T001O31_A139MedidasEstado, T001O31_n139MedidasEstado
               }
               , new Object[] {
               T001O32_A121RubrosId, T001O32_A137MedidasID, T001O32_A135InventarioId, T001O32_A136InventarioNombre, T001O32_A107EstadosTipo, T001O32_A108EstadosGenericosId
               }
               , new Object[] {
               T001O33_A282ProveedorNombre
               }
               , new Object[] {
               T001O34_A190InventarioCosto, T001O34_A181InventarioPrecioFinal
               }
            }
         );
         AV28Pgmname = "ProfComisiones";
         Z453ProfComisionesRubrosTipo = context.GetMessage( "F", "");
         A453ProfComisionesRubrosTipo = context.GetMessage( "F", "");
         i453ProfComisionesRubrosTipo = context.GetMessage( "F", "");
      }

      private short nIsMod_67 ;
      private short Z451ProfComisionesAutoEnun ;
      private short O451ProfComisionesAutoEnun ;
      private short Z121RubrosId ;
      private short nRcdDeleted_67 ;
      private short nRcdExists_67 ;
      private short GxWebError ;
      private short A121RubrosId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A451ProfComisionesAutoEnun ;
      private short Gx_BScreen ;
      private short nBlankRcdCount67 ;
      private short RcdFound67 ;
      private short B451ProfComisionesAutoEnun ;
      private short nBlankRcdUsr67 ;
      private short RcdFound66 ;
      private short s451ProfComisionesAutoEnun ;
      private short nIsDirty_67 ;
      private short subGridlevel_rubros_Backcolorstyle ;
      private short subGridlevel_rubros_Backstyle ;
      private short gxajaxcallmode ;
      private short i451ProfComisionesAutoEnun ;
      private short subGridlevel_rubros_Allowselection ;
      private short subGridlevel_rubros_Allowhovering ;
      private short subGridlevel_rubros_Allowcollapsing ;
      private short subGridlevel_rubros_Collapsed ;
      private int nRC_GXsfl_68 ;
      private int nGXsfl_68_idx=1 ;
      private int trnEnded ;
      private int edtProfComisionesID_Enabled ;
      private int edtProfesionalesId_Enabled ;
      private int imgprompt_120_Visible ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int edtProfesionalesTelefono_Enabled ;
      private int imgProfesionalesPhoto_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtProfComisionesRubrosId_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtInventarioPrecioFinal_Enabled ;
      private int edtProfComisionesRubrosValor_Enabled ;
      private int edtProfComisionesRubrosGanPRF_Enabled ;
      private int edtProfComisionesRubrosGan_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV29GXV1 ;
      private int subGridlevel_rubros_Backcolor ;
      private int subGridlevel_rubros_Allbackcolor ;
      private int imgprompt_133_Visible ;
      private int defedtProfComisionesRubrosId_Enabled ;
      private int idxLst ;
      private int subGridlevel_rubros_Selectedindex ;
      private int subGridlevel_rubros_Selectioncolor ;
      private int subGridlevel_rubros_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long wcpOAV7ProfComisionesID ;
      private long Z450ProfComisionesID ;
      private long Z452ProfComisionesRubrosId ;
      private long Z133ProveedorID ;
      private long Z137MedidasID ;
      private long Z135InventarioId ;
      private long A137MedidasID ;
      private long A133ProveedorID ;
      private long A135InventarioId ;
      private long AV7ProfComisionesID ;
      private long A450ProfComisionesID ;
      private long GRIDLEVEL_RUBROS_nFirstRecordOnPage ;
      private long A452ProfComisionesRubrosId ;
      private long A457ProfComisionesRubrosGanPRF ;
      private long A456ProfComisionesRubrosGan ;
      private decimal Z454ProfComisionesRubrosValor ;
      private decimal A190InventarioCosto ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A454ProfComisionesRubrosValor ;
      private decimal Z190InventarioCosto ;
      private decimal Z181InventarioPrecioFinal ;
      private string sPrefix ;
      private string sGXsfl_68_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z120ProfesionalesId ;
      private string N120ProfesionalesId ;
      private string Z453ProfComisionesRubrosTipo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A120ProfesionalesId ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProfesionalesId_Internalname ;
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
      private string edtProfComisionesID_Internalname ;
      private string TempTags ;
      private string edtProfComisionesID_Jsonclick ;
      private string divTb1_Internalname ;
      private string edtProfesionalesId_Jsonclick ;
      private string imgprompt_120_gximage ;
      private string sImgUrl ;
      private string imgprompt_120_Internalname ;
      private string imgprompt_120_Link ;
      private string edtProfesionalesPrimerNombre_Internalname ;
      private string A166ProfesionalesPrimerNombre ;
      private string edtProfesionalesPrimerNombre_Jsonclick ;
      private string edtProfesionalesSegundoNombre_Internalname ;
      private string A191ProfesionalesSegundoNombre ;
      private string edtProfesionalesSegundoNombre_Jsonclick ;
      private string edtProfesionalesApellidoPrimero_Internalname ;
      private string A167ProfesionalesApellidoPrimero ;
      private string edtProfesionalesApellidoPrimero_Jsonclick ;
      private string edtProfesionalesApellidoSegundo_Internalname ;
      private string A192ProfesionalesApellidoSegundo ;
      private string edtProfesionalesApellidoSegundo_Jsonclick ;
      private string edtProfesionalesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A170ProfesionalesTelefono ;
      private string edtProfesionalesTelefono_Jsonclick ;
      private string divTb2_Internalname ;
      private string imgProfesionalesPhoto_Internalname ;
      private string divTableleaflevel_rubros_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode67 ;
      private string edtProfComisionesRubrosId_Internalname ;
      private string edtProveedorID_Internalname ;
      private string edtProveedorNombre_Internalname ;
      private string dynRubrosId_Internalname ;
      private string dynMedidasID_Internalname ;
      private string dynInventarioId_Internalname ;
      private string edtInventarioPrecioFinal_Internalname ;
      private string cmbProfComisionesRubrosTipo_Internalname ;
      private string edtProfComisionesRubrosValor_Internalname ;
      private string edtProfComisionesRubrosGanPRF_Internalname ;
      private string edtProfComisionesRubrosGan_Internalname ;
      private string sStyleString ;
      private string subGridlevel_rubros_Internalname ;
      private string AV11Insert_ProfesionalesId ;
      private string AV28Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode66 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A282ProveedorNombre ;
      private string A453ProfComisionesRubrosTipo ;
      private string GXEncryptionTmp ;
      private string Z166ProfesionalesPrimerNombre ;
      private string Z191ProfesionalesSegundoNombre ;
      private string Z167ProfesionalesApellidoPrimero ;
      private string Z192ProfesionalesApellidoSegundo ;
      private string Z170ProfesionalesTelefono ;
      private string Z282ProveedorNombre ;
      private string GXCCtl ;
      private string imgprompt_133_Internalname ;
      private string sGXsfl_68_fel_idx="0001" ;
      private string subGridlevel_rubros_Class ;
      private string subGridlevel_rubros_Linesclass ;
      private string imgprompt_133_Link ;
      private string ROClassString ;
      private string edtProfComisionesRubrosId_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string imgprompt_133_gximage ;
      private string edtProveedorNombre_Jsonclick ;
      private string dynRubrosId_Jsonclick ;
      private string dynMedidasID_Jsonclick ;
      private string dynInventarioId_Jsonclick ;
      private string edtInventarioPrecioFinal_Jsonclick ;
      private string cmbProfComisionesRubrosTipo_Jsonclick ;
      private string edtProfComisionesRubrosValor_Jsonclick ;
      private string edtProfComisionesRubrosGanPRF_Jsonclick ;
      private string edtProfComisionesRubrosGan_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string i453ProfComisionesRubrosTipo ;
      private string subGridlevel_rubros_Header ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n133ProveedorID ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A169ProfesionalesPhoto_IsBlob ;
      private bool bGXsfl_68_Refreshing=false ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string Z40000ProfesionalesPhoto_GXI ;
      private string A169ProfesionalesPhoto ;
      private string Z169ProfesionalesPhoto ;
      private IGxSession AV10WebSession ;
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
      private GXCombobox dynRubrosId ;
      private GXCombobox dynMedidasID ;
      private GXCombobox dynInventarioId ;
      private GXCombobox cmbProfComisionesRubrosTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV13WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T001O8_A166ProfesionalesPrimerNombre ;
      private string[] T001O8_A191ProfesionalesSegundoNombre ;
      private string[] T001O8_A167ProfesionalesApellidoPrimero ;
      private string[] T001O8_A192ProfesionalesApellidoSegundo ;
      private string[] T001O8_A40000ProfesionalesPhoto_GXI ;
      private string[] T001O8_A170ProfesionalesTelefono ;
      private string[] T001O8_A169ProfesionalesPhoto ;
      private long[] T001O9_A450ProfComisionesID ;
      private string[] T001O9_A166ProfesionalesPrimerNombre ;
      private string[] T001O9_A191ProfesionalesSegundoNombre ;
      private string[] T001O9_A167ProfesionalesApellidoPrimero ;
      private string[] T001O9_A192ProfesionalesApellidoSegundo ;
      private string[] T001O9_A40000ProfesionalesPhoto_GXI ;
      private string[] T001O9_A170ProfesionalesTelefono ;
      private short[] T001O9_A451ProfComisionesAutoEnun ;
      private string[] T001O9_A120ProfesionalesId ;
      private string[] T001O9_A169ProfesionalesPhoto ;
      private string[] T001O10_A166ProfesionalesPrimerNombre ;
      private string[] T001O10_A191ProfesionalesSegundoNombre ;
      private string[] T001O10_A167ProfesionalesApellidoPrimero ;
      private string[] T001O10_A192ProfesionalesApellidoSegundo ;
      private string[] T001O10_A40000ProfesionalesPhoto_GXI ;
      private string[] T001O10_A170ProfesionalesTelefono ;
      private string[] T001O10_A169ProfesionalesPhoto ;
      private long[] T001O11_A450ProfComisionesID ;
      private long[] T001O7_A450ProfComisionesID ;
      private short[] T001O7_A451ProfComisionesAutoEnun ;
      private string[] T001O7_A120ProfesionalesId ;
      private long[] T001O12_A450ProfComisionesID ;
      private long[] T001O13_A450ProfComisionesID ;
      private long[] T001O6_A450ProfComisionesID ;
      private short[] T001O6_A451ProfComisionesAutoEnun ;
      private string[] T001O6_A120ProfesionalesId ;
      private long[] T001O14_A450ProfComisionesID ;
      private string[] T001O17_A166ProfesionalesPrimerNombre ;
      private string[] T001O17_A191ProfesionalesSegundoNombre ;
      private string[] T001O17_A167ProfesionalesApellidoPrimero ;
      private string[] T001O17_A192ProfesionalesApellidoSegundo ;
      private string[] T001O17_A40000ProfesionalesPhoto_GXI ;
      private string[] T001O17_A170ProfesionalesTelefono ;
      private string[] T001O17_A169ProfesionalesPhoto ;
      private long[] T001O19_A450ProfComisionesID ;
      private decimal[] T001O5_A190InventarioCosto ;
      private decimal[] T001O5_A181InventarioPrecioFinal ;
      private long[] T001O20_A450ProfComisionesID ;
      private long[] T001O20_A452ProfComisionesRubrosId ;
      private string[] T001O20_A453ProfComisionesRubrosTipo ;
      private decimal[] T001O20_A454ProfComisionesRubrosValor ;
      private string[] T001O20_A282ProveedorNombre ;
      private decimal[] T001O20_A190InventarioCosto ;
      private decimal[] T001O20_A181InventarioPrecioFinal ;
      private long[] T001O20_A133ProveedorID ;
      private bool[] T001O20_n133ProveedorID ;
      private short[] T001O20_A121RubrosId ;
      private long[] T001O20_A137MedidasID ;
      private long[] T001O20_A135InventarioId ;
      private string[] T001O4_A282ProveedorNombre ;
      private string[] T001O21_A282ProveedorNombre ;
      private decimal[] T001O22_A190InventarioCosto ;
      private decimal[] T001O22_A181InventarioPrecioFinal ;
      private long[] T001O23_A450ProfComisionesID ;
      private long[] T001O23_A452ProfComisionesRubrosId ;
      private long[] T001O3_A450ProfComisionesID ;
      private long[] T001O3_A452ProfComisionesRubrosId ;
      private string[] T001O3_A453ProfComisionesRubrosTipo ;
      private decimal[] T001O3_A454ProfComisionesRubrosValor ;
      private long[] T001O3_A133ProveedorID ;
      private bool[] T001O3_n133ProveedorID ;
      private short[] T001O3_A121RubrosId ;
      private long[] T001O3_A137MedidasID ;
      private long[] T001O3_A135InventarioId ;
      private long[] T001O2_A450ProfComisionesID ;
      private long[] T001O2_A452ProfComisionesRubrosId ;
      private string[] T001O2_A453ProfComisionesRubrosTipo ;
      private decimal[] T001O2_A454ProfComisionesRubrosValor ;
      private long[] T001O2_A133ProveedorID ;
      private bool[] T001O2_n133ProveedorID ;
      private short[] T001O2_A121RubrosId ;
      private long[] T001O2_A137MedidasID ;
      private long[] T001O2_A135InventarioId ;
      private string[] T001O27_A282ProveedorNombre ;
      private decimal[] T001O28_A190InventarioCosto ;
      private decimal[] T001O28_A181InventarioPrecioFinal ;
      private long[] T001O29_A450ProfComisionesID ;
      private long[] T001O29_A452ProfComisionesRubrosId ;
      private short[] T001O30_A121RubrosId ;
      private string[] T001O30_A122RubrosNombre ;
      private string[] T001O30_A123RubrosEstado ;
      private bool[] T001O30_n123RubrosEstado ;
      private short[] T001O31_A121RubrosId ;
      private long[] T001O31_A137MedidasID ;
      private string[] T001O31_A138MedidasNombre ;
      private string[] T001O31_A139MedidasEstado ;
      private bool[] T001O31_n139MedidasEstado ;
      private short[] T001O32_A121RubrosId ;
      private long[] T001O32_A137MedidasID ;
      private long[] T001O32_A135InventarioId ;
      private string[] T001O32_A136InventarioNombre ;
      private string[] T001O32_A107EstadosTipo ;
      private int[] T001O32_A108EstadosGenericosId ;
      private string[] T001O33_A282ProveedorNombre ;
      private decimal[] T001O34_A190InventarioCosto ;
      private decimal[] T001O34_A181InventarioPrecioFinal ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class profcomisiones__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class profcomisiones__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new ForEachCursor(def[25])
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
        Object[] prmT001O2;
        prmT001O2 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfComisionesRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmT001O3;
        prmT001O3 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfComisionesRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmT001O4;
        prmT001O4 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001O5;
        prmT001O5 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT001O6;
        prmT001O6 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001O7;
        prmT001O7 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001O8;
        prmT001O8 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001O9;
        prmT001O9 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001O10;
        prmT001O10 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001O11;
        prmT001O11 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001O12;
        prmT001O12 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001O13;
        prmT001O13 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001O14;
        prmT001O14 = new Object[] {
        new ParDef("@ProfComisionesAutoEnun",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001O15;
        prmT001O15 = new Object[] {
        new ParDef("@ProfComisionesAutoEnun",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001O16;
        prmT001O16 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001O17;
        prmT001O17 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001O18;
        prmT001O18 = new Object[] {
        new ParDef("@ProfComisionesAutoEnun",GXType.Int16,4,0) ,
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001O19;
        prmT001O19 = new Object[] {
        };
        Object[] prmT001O20;
        prmT001O20 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfComisionesRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmT001O21;
        prmT001O21 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001O22;
        prmT001O22 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT001O23;
        prmT001O23 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfComisionesRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmT001O24;
        prmT001O24 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfComisionesRubrosId",GXType.Decimal,18,0) ,
        new ParDef("@ProfComisionesRubrosTipo",GXType.NChar,1,0) ,
        new ParDef("@ProfComisionesRubrosValor",GXType.Decimal,18,2) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT001O25;
        prmT001O25 = new Object[] {
        new ParDef("@ProfComisionesRubrosTipo",GXType.NChar,1,0) ,
        new ParDef("@ProfComisionesRubrosValor",GXType.Decimal,18,2) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0) ,
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfComisionesRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmT001O26;
        prmT001O26 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0) ,
        new ParDef("@ProfComisionesRubrosId",GXType.Decimal,18,0)
        };
        Object[] prmT001O27;
        prmT001O27 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001O28;
        prmT001O28 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        Object[] prmT001O29;
        prmT001O29 = new Object[] {
        new ParDef("@ProfComisionesID",GXType.Decimal,18,0)
        };
        Object[] prmT001O30;
        prmT001O30 = new Object[] {
        };
        Object[] prmT001O31;
        prmT001O31 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT001O32;
        prmT001O32 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT001O33;
        prmT001O33 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001O34;
        prmT001O34 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001O2", "SELECT [ProfComisionesID], [ProfComisionesRubrosId], [ProfComisionesRubrosTipo], [ProfComisionesRubrosValor], [ProveedorID], [RubrosId], [MedidasID], [InventarioId] FROM [ProfComisionesRubros] WITH (UPDLOCK) WHERE [ProfComisionesID] = @ProfComisionesID AND [ProfComisionesRubrosId] = @ProfComisionesRubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O3", "SELECT [ProfComisionesID], [ProfComisionesRubrosId], [ProfComisionesRubrosTipo], [ProfComisionesRubrosValor], [ProveedorID], [RubrosId], [MedidasID], [InventarioId] FROM [ProfComisionesRubros] WHERE [ProfComisionesID] = @ProfComisionesID AND [ProfComisionesRubrosId] = @ProfComisionesRubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O4", "SELECT [ProveedorNombre] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O5", "SELECT [InventarioCosto], [InventarioPrecioFinal] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O6", "SELECT [ProfComisionesID], [ProfComisionesAutoEnun], [ProfesionalesId] FROM [ProfComisiones] WITH (UPDLOCK) WHERE [ProfComisionesID] = @ProfComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O7", "SELECT [ProfComisionesID], [ProfComisionesAutoEnun], [ProfesionalesId] FROM [ProfComisiones] WHERE [ProfComisionesID] = @ProfComisionesID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O8", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesPhoto] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O9", "SELECT TM1.[ProfComisionesID], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesPhoto_GXI], T2.[ProfesionalesTelefono], TM1.[ProfComisionesAutoEnun], TM1.[ProfesionalesId], T2.[ProfesionalesPhoto] FROM ([ProfComisiones] TM1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = TM1.[ProfesionalesId]) WHERE TM1.[ProfComisionesID] = @ProfComisionesID ORDER BY TM1.[ProfComisionesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001O9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O10", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesPhoto] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O11", "SELECT [ProfComisionesID] FROM [ProfComisiones] WHERE [ProfComisionesID] = @ProfComisionesID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001O11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O12", "SELECT TOP 1 [ProfComisionesID] FROM [ProfComisiones] WHERE ( [ProfComisionesID] > @ProfComisionesID) ORDER BY [ProfComisionesID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001O12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001O13", "SELECT TOP 1 [ProfComisionesID] FROM [ProfComisiones] WHERE ( [ProfComisionesID] < @ProfComisionesID) ORDER BY [ProfComisionesID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001O13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001O14", "INSERT INTO [ProfComisiones]([ProfComisionesAutoEnun], [ProfesionalesId]) VALUES(@ProfComisionesAutoEnun, @ProfesionalesId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001O14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001O15", "UPDATE [ProfComisiones] SET [ProfComisionesAutoEnun]=@ProfComisionesAutoEnun, [ProfesionalesId]=@ProfesionalesId  WHERE [ProfComisionesID] = @ProfComisionesID", GxErrorMask.GX_NOMASK,prmT001O15)
           ,new CursorDef("T001O16", "DELETE FROM [ProfComisiones]  WHERE [ProfComisionesID] = @ProfComisionesID", GxErrorMask.GX_NOMASK,prmT001O16)
           ,new CursorDef("T001O17", "SELECT [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesPhoto] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O18", "UPDATE [ProfComisiones] SET [ProfComisionesAutoEnun]=@ProfComisionesAutoEnun  WHERE [ProfComisionesID] = @ProfComisionesID", GxErrorMask.GX_NOMASK,prmT001O18)
           ,new CursorDef("T001O19", "SELECT [ProfComisionesID] FROM [ProfComisiones] ORDER BY [ProfComisionesID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001O19,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O20", "SELECT T1.[ProfComisionesID], T1.[ProfComisionesRubrosId], T1.[ProfComisionesRubrosTipo], T1.[ProfComisionesRubrosValor], T2.[ProveedorNombre], T3.[InventarioCosto], T3.[InventarioPrecioFinal], T1.[ProveedorID], T1.[RubrosId], T1.[MedidasID], T1.[InventarioId] FROM (([ProfComisionesRubros] T1 LEFT JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) INNER JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId]) WHERE T1.[ProfComisionesID] = @ProfComisionesID and T1.[ProfComisionesRubrosId] = @ProfComisionesRubrosId ORDER BY T1.[ProfComisionesID], T1.[ProfComisionesRubrosId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O20,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O21", "SELECT [ProveedorNombre] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O22", "SELECT [InventarioCosto], [InventarioPrecioFinal] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O23", "SELECT [ProfComisionesID], [ProfComisionesRubrosId] FROM [ProfComisionesRubros] WHERE [ProfComisionesID] = @ProfComisionesID AND [ProfComisionesRubrosId] = @ProfComisionesRubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O24", "INSERT INTO [ProfComisionesRubros]([ProfComisionesID], [ProfComisionesRubrosId], [ProfComisionesRubrosTipo], [ProfComisionesRubrosValor], [ProveedorID], [RubrosId], [MedidasID], [InventarioId]) VALUES(@ProfComisionesID, @ProfComisionesRubrosId, @ProfComisionesRubrosTipo, @ProfComisionesRubrosValor, @ProveedorID, @RubrosId, @MedidasID, @InventarioId)", GxErrorMask.GX_NOMASK,prmT001O24)
           ,new CursorDef("T001O25", "UPDATE [ProfComisionesRubros] SET [ProfComisionesRubrosTipo]=@ProfComisionesRubrosTipo, [ProfComisionesRubrosValor]=@ProfComisionesRubrosValor, [ProveedorID]=@ProveedorID, [RubrosId]=@RubrosId, [MedidasID]=@MedidasID, [InventarioId]=@InventarioId  WHERE [ProfComisionesID] = @ProfComisionesID AND [ProfComisionesRubrosId] = @ProfComisionesRubrosId", GxErrorMask.GX_NOMASK,prmT001O25)
           ,new CursorDef("T001O26", "DELETE FROM [ProfComisionesRubros]  WHERE [ProfComisionesID] = @ProfComisionesID AND [ProfComisionesRubrosId] = @ProfComisionesRubrosId", GxErrorMask.GX_NOMASK,prmT001O26)
           ,new CursorDef("T001O27", "SELECT [ProveedorNombre] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O28", "SELECT [InventarioCosto], [InventarioPrecioFinal] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O29", "SELECT [ProfComisionesID], [ProfComisionesRubrosId] FROM [ProfComisionesRubros] WHERE [ProfComisionesID] = @ProfComisionesID ORDER BY [ProfComisionesID], [ProfComisionesRubrosId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O29,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O30", "SELECT [RubrosId], [RubrosNombre], [RubrosEstado] FROM [Rubros] WHERE [RubrosEstado] = 'HAB' ORDER BY [RubrosNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O30,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O31", "SELECT [RubrosId], [MedidasID], [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE ([RubrosId] = @RubrosId) AND ([MedidasEstado] <> 'DES') ORDER BY [MedidasNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O31,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O32", "SELECT [RubrosId], [MedidasID], [InventarioId], [InventarioNombre], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE ([RubrosId] = @RubrosId and [MedidasID] = @MedidasID) AND ([EstadosGenericosId] = 1) ORDER BY [InventarioNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O32,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O33", "SELECT [ProveedorNombre] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001O34", "SELECT [InventarioCosto], [InventarioPrecioFinal] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O34,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((long[]) buf[7])[0] = rslt.getLong(7);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((long[]) buf[7])[0] = rslt.getLong(7);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 3 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(5));
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getString(5, 30);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(6));
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(5));
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
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((string[]) buf[1])[0] = rslt.getString(2, 30);
              ((string[]) buf[2])[0] = rslt.getString(3, 30);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(5));
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((short[]) buf[9])[0] = rslt.getShort(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 20 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 26 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 28 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 29 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 32 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
     }
  }

}

}

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
   public class profesionaleszonas : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         gxfirstwebparm = GetFirstPar( "ProfesionalesId");
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
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A112DepartamentoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A112DepartamentoId, A114DepartamentoMunicipioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A110ZonasID = (long)(Math.Round(NumberUtil.Val( GetPar( "ZonasID"), "."), 18, MidpointRounding.ToEven));
            n110ZonasID = false;
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A110ZonasID, A112DepartamentoId, A114DepartamentoMunicipioId) ;
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
            gxfirstwebparm = GetFirstPar( "ProfesionalesId");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "ProfesionalesId");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridprofesionaleszonas_zonas") == 0 )
         {
            gxnrGridprofesionaleszonas_zonas_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "profesionaleszonas.aspx")), "profesionaleszonas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "profesionaleszonas.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "ProfesionalesId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               A120ProfesionalesId = gxfirstwebparm;
               AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  Gx_mode = GetPar( "Mode");
                  AssignAttri("", false, "Gx_mode", Gx_mode);
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
         Form.Meta.addItem("description", context.GetMessage( "Profesionales Zonas", ""), 0) ;
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

      protected void gxnrGridprofesionaleszonas_zonas_newrow_invoke( )
      {
         nRC_GXsfl_27 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_27"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_27_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_27_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_27_idx = GetPar( "sGXsfl_27_idx");
         A197ProfesionalesAutoEnuZona = (short)(Math.Round(NumberUtil.Val( GetPar( "ProfesionalesAutoEnuZona"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridprofesionaleszonas_zonas_newrow( ) ;
         /* End function gxnrGridprofesionaleszonas_zonas_newrow_invoke */
      }

      public profesionaleszonas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionaleszonas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProfesionalesId ,
                           ref string aP1_Gx_mode )
      {
         this.A120ProfesionalesId = aP0_ProfesionalesId;
         this.Gx_mode = aP1_Gx_mode;
         ExecutePrivate();
         aP0_ProfesionalesId=this.A120ProfesionalesId;
         aP1_Gx_mode=this.Gx_mode;
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
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "|||", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesZonas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Zonas de Trabajo", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesZonas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divZonastable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlezonas_Internalname, context.GetMessage( "Seleccione la zona de trabajo", ""), "", "", lblTitlezonas_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesZonas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridprofesionaleszonas_zonas( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
         /* Static images/pictures */
         ClassString = "Image" + " " + ((StringUtil.StrCmp(imgImage1_gximage, "")==0) ? "GX_Image_ComboArrow_Class" : "GX_Image_"+imgImage1_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "5dcddcce-df89-424f-8cbe-19c24b6a0567", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage1_Visible, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesZonas.htm");
         GxWebStd.gx_div_end( context, "end", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesZonas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesZonas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesZonas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
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

      protected void gxdraw_Gridprofesionaleszonas_zonas( )
      {
         /*  Grid Control  */
         StartGridControl27( ) ;
         nGXsfl_27_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount36 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_36 = 1;
               ScanStart0X36( ) ;
               while ( RcdFound36 != 0 )
               {
                  init_level_properties36( ) ;
                  getByPrimaryKey0X36( ) ;
                  AddRow0X36( ) ;
                  ScanNext0X36( ) ;
               }
               ScanEnd0X36( ) ;
               nBlankRcdCount36 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            standaloneNotModal0X36( ) ;
            standaloneModal0X36( ) ;
            sMode36 = Gx_mode;
            while ( nGXsfl_27_idx < nRC_GXsfl_27 )
            {
               bGXsfl_27_Refreshing = true;
               ReadRow0X36( ) ;
               edtProfesionalesZonasCorrelativo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_27_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesZonasCorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0), !bGXsfl_27_Refreshing);
               edtDepartamentoId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOID_"+sGXsfl_27_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), !bGXsfl_27_Refreshing);
               edtDepartamentoMunicipioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_27_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0), !bGXsfl_27_Refreshing);
               edtZonasID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ZONASID_"+sGXsfl_27_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonasID_Enabled), 5, 0), !bGXsfl_27_Refreshing);
               edtZonasID_Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ZONASID_"+sGXsfl_27_idx+"Visible"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtZonasID_Visible), 5, 0), !bGXsfl_27_Refreshing);
               imgprompt_112_Link = cgiGet( "PROMPT_112_"+sGXsfl_27_idx+"Link");
               imgprompt_112_Link = cgiGet( "PROMPT_114_"+sGXsfl_27_idx+"Link");
               imgprompt_112_Link = cgiGet( "PROMPT_110_"+sGXsfl_27_idx+"Link");
               if ( ( nRcdExists_36 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0X36( ) ;
               }
               SendRow0X36( ) ;
               bGXsfl_27_Refreshing = false;
            }
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A197ProfesionalesAutoEnuZona = B197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount36 = 5;
            nRcdExists_36 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0X36( ) ;
               while ( RcdFound36 != 0 )
               {
                  sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_2736( ) ;
                  init_level_properties36( ) ;
                  standaloneNotModal0X36( ) ;
                  getByPrimaryKey0X36( ) ;
                  standaloneModal0X36( ) ;
                  AddRow0X36( ) ;
                  ScanNext0X36( ) ;
               }
               ScanEnd0X36( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode36 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx+1), 4, 0), 4, "0");
            SubsflControlProps_2736( ) ;
            InitAll0X36( ) ;
            init_level_properties36( ) ;
            B197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            nRcdExists_36 = 0;
            nIsMod_36 = 0;
            nRcdDeleted_36 = 0;
            nBlankRcdCount36 = (short)(nBlankRcdUsr36+nBlankRcdCount36);
            fRowAdded = 0;
            while ( nBlankRcdCount36 > 0 )
            {
               standaloneNotModal0X36( ) ;
               standaloneModal0X36( ) ;
               AddRow0X36( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtDepartamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount36 = (short)(nBlankRcdCount36-1);
            }
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A197ProfesionalesAutoEnuZona = B197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridprofesionaleszonas_zonasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridprofesionaleszonas_zonas", Gridprofesionaleszonas_zonasContainer, subGridprofesionaleszonas_zonas_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridprofesionaleszonas_zonasContainerData", Gridprofesionaleszonas_zonasContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridprofesionaleszonas_zonasContainerData"+"V", Gridprofesionaleszonas_zonasContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridprofesionaleszonas_zonasContainerData"+"V"+"\" value='"+Gridprofesionaleszonas_zonasContainer.GridValuesHidden()+"'/>") ;
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z120ProfesionalesId = cgiGet( "Z120ProfesionalesId");
            Z197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z197ProfesionalesAutoEnuZona"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z197ProfesionalesAutoEnuZona"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            O197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O197ProfesionalesAutoEnuZona"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_27 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_27"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A120ProfesionalesId = cgiGet( "PROFESIONALESID");
            A197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAUTOENUZONA"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A113DepartamentoDepartamento = cgiGet( "DEPARTAMENTODEPARTAMENTO");
            A116PaisID = cgiGet( "PAISID");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"ProfesionalesZonas");
            forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("profesionaleszonas:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A120ProfesionalesId = GetPar( "ProfesionalesId");
               AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
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
                  sMode34 = Gx_mode;
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Gx_mode = sMode34;
                  AssignAttri("", false, "Gx_mode", Gx_mode);
               }
               standaloneModal( ) ;
               if ( ! IsIns( ) )
               {
                  getByPrimaryKey( ) ;
                  if ( RcdFound34 == 1 )
                  {
                     if ( IsDlt( ) )
                     {
                        /* Confirm record */
                        CONFIRM_0X0( ) ;
                        if ( AnyError == 0 )
                        {
                           GX_FocusControl = bttBtn_enter_Internalname;
                           AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "");
                     AnyError = 1;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0X34( ) ;
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
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0X34( ) ;
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

      protected void CONFIRM_0X0( )
      {
         BeforeValidate0X34( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0X34( ) ;
            }
            else
            {
               CheckExtendedTable0X34( ) ;
               CloseExtendedTableCursors0X34( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode34 = Gx_mode;
            CONFIRM_0X36( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode34;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0X36( )
      {
         s197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
         AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         nGXsfl_27_idx = 0;
         while ( nGXsfl_27_idx < nRC_GXsfl_27 )
         {
            ReadRow0X36( ) ;
            if ( ( nRcdExists_36 != 0 ) || ( nIsMod_36 != 0 ) )
            {
               GetKey0X36( ) ;
               if ( ( nRcdExists_36 == 0 ) && ( nRcdDeleted_36 == 0 ) )
               {
                  if ( RcdFound36 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0X36( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0X36( ) ;
                        CloseExtendedTableCursors0X36( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
                        AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
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
                  if ( RcdFound36 != 0 )
                  {
                     if ( nRcdDeleted_36 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0X36( ) ;
                        Load0X36( ) ;
                        BeforeValidate0X36( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0X36( ) ;
                           O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
                           AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_36 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0X36( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0X36( ) ;
                              CloseExtendedTableCursors0X36( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
                              AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_36 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtProfesionalesZonasCorrelativo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A126ProfesionalesZonasCorrelativo), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtDepartamentoMunicipioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtZonasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z126ProfesionalesZonasCorrelativo_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126ProfesionalesZonasCorrelativo), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z112DepartamentoId_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z114DepartamentoMunicipioId_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z110ZonasID_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_36_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_36), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_36_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_36), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_36_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_36), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_36 != 0 )
            {
               ChangePostValue( "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_27_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOID_"+sGXsfl_27_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_27_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ZONASID_"+sGXsfl_27_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtZonasID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ZONASID_"+sGXsfl_27_idx+"Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtZonasID_Visible), 5, 0, ".", ""))) ;
            }
         }
         O197ProfesionalesAutoEnuZona = s197ProfesionalesAutoEnuZona;
         AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0X0( )
      {
      }

      protected void ZM0X34( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z197ProfesionalesAutoEnuZona = T000X8_A197ProfesionalesAutoEnuZona[0];
            }
            else
            {
               Z197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            }
         }
         if ( GX_JID == -5 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
            Z197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0X34( )
      {
         /* Using cursor T000X9 */
         pr_default.execute(7, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound34 = 1;
            A197ProfesionalesAutoEnuZona = T000X9_A197ProfesionalesAutoEnuZona[0];
            ZM0X34( -5) ;
         }
         pr_default.close(7);
         OnLoadActions0X34( ) ;
      }

      protected void OnLoadActions0X34( )
      {
      }

      protected void CheckExtendedTable0X34( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0X34( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0X34( )
      {
         /* Using cursor T000X10 */
         pr_default.execute(8, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000X8 */
         pr_default.execute(6, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(T000X8_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
         {
            ZM0X34( 5) ;
            RcdFound34 = 1;
            A197ProfesionalesAutoEnuZona = T000X8_A197ProfesionalesAutoEnuZona[0];
            O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            Z120ProfesionalesId = A120ProfesionalesId;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0X34( ) ;
            if ( AnyError == 1 )
            {
               RcdFound34 = 0;
               InitializeNonKey0X34( ) ;
            }
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey0X34( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey0X34( ) ;
         if ( RcdFound34 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound34 = 0;
         /* Using cursor T000X11 */
         pr_default.execute(9, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( StringUtil.StrCmp(T000X11_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( StringUtil.StrCmp(T000X11_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
            {
               RcdFound34 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound34 = 0;
         /* Using cursor T000X12 */
         pr_default.execute(10, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( StringUtil.StrCmp(T000X12_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( StringUtil.StrCmp(T000X12_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
            {
               RcdFound34 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0X34( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            Insert0X34( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound34 == 1 )
            {
               if ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                  AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  /* Update record */
                  A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                  AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                  Update0X34( ) ;
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 )
               {
                  /* Insert record */
                  A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                  AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                  Insert0X34( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                     AnyError = 1;
                  }
                  else
                  {
                     /* Insert record */
                     A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                     AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                     Insert0X34( ) ;
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
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "");
            AnyError = 1;
         }
         else
         {
            A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0X34( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000X7 */
            pr_default.execute(5, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Profesionales"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(5) == 101) || ( Z197ProfesionalesAutoEnuZona != T000X7_A197ProfesionalesAutoEnuZona[0] ) )
            {
               if ( Z197ProfesionalesAutoEnuZona != T000X7_A197ProfesionalesAutoEnuZona[0] )
               {
                  GXUtil.WriteLog("profesionaleszonas:[seudo value changed for attri]"+"ProfesionalesAutoEnuZona");
                  GXUtil.WriteLogRaw("Old: ",Z197ProfesionalesAutoEnuZona);
                  GXUtil.WriteLogRaw("Current: ",T000X7_A197ProfesionalesAutoEnuZona[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Profesionales"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0X34( )
      {
         BeforeValidate0X34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X34( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0X34( 0) ;
            CheckOptimisticConcurrency0X34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0X34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X13 */
                     pr_default.execute(11, new Object[] {A120ProfesionalesId, A197ProfesionalesAutoEnuZona});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Profesionales");
                     if ( (pr_default.getStatus(11) == 1) )
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
                           ProcessLevel0X34( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
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
            else
            {
               Load0X34( ) ;
            }
            EndLevel0X34( ) ;
         }
         CloseExtendedTableCursors0X34( ) ;
      }

      protected void Update0X34( )
      {
         BeforeValidate0X34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X34( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0X34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X14 */
                     pr_default.execute(12, new Object[] {A197ProfesionalesAutoEnuZona, A120ProfesionalesId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Profesionales");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Profesionales"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0X34( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0X34( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
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
            EndLevel0X34( ) ;
         }
         CloseExtendedTableCursors0X34( ) ;
      }

      protected void DeferredUpdate0X34( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0X34( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X34( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0X34( ) ;
            AfterConfirm0X34( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0X34( ) ;
               if ( AnyError == 0 )
               {
                  A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                  AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                  ScanStart0X36( ) ;
                  while ( RcdFound36 != 0 )
                  {
                     getByPrimaryKey0X36( ) ;
                     Delete0X36( ) ;
                     ScanNext0X36( ) ;
                     O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
                     AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                  }
                  ScanEnd0X36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X15 */
                     pr_default.execute(13, new Object[] {A120ProfesionalesId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Profesionales");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
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
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0X34( ) ;
         Gx_mode = sMode34;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0X34( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000X16 */
            pr_default.execute(14, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Detalles", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000X17 */
            pr_default.execute(15, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "ProfesionalesRestriccion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000X18 */
            pr_default.execute(16, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Prof Comisiones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000X19 */
            pr_default.execute(17, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000X20 */
            pr_default.execute(18, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "ProfesionalesServicios", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000X21 */
            pr_default.execute(19, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000X22 */
            pr_default.execute(20, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupacion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T000X23 */
            pr_default.execute(21, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T000X24 */
            pr_default.execute(22, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
         }
      }

      protected void ProcessNestedLevel0X36( )
      {
         s197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
         AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         nGXsfl_27_idx = 0;
         while ( nGXsfl_27_idx < nRC_GXsfl_27 )
         {
            ReadRow0X36( ) ;
            if ( ( nRcdExists_36 != 0 ) || ( nIsMod_36 != 0 ) )
            {
               standaloneNotModal0X36( ) ;
               GetKey0X36( ) ;
               if ( ( nRcdExists_36 == 0 ) && ( nRcdDeleted_36 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0X36( ) ;
               }
               else
               {
                  if ( RcdFound36 != 0 )
                  {
                     if ( ( nRcdDeleted_36 != 0 ) && ( nRcdExists_36 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0X36( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_36 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0X36( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_36 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
               AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            }
            ChangePostValue( edtProfesionalesZonasCorrelativo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A126ProfesionalesZonasCorrelativo), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtDepartamentoMunicipioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtZonasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z126ProfesionalesZonasCorrelativo_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126ProfesionalesZonasCorrelativo), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z112DepartamentoId_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z114DepartamentoMunicipioId_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z110ZonasID_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_36_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_36), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_36_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_36), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_36_"+sGXsfl_27_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_36), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_36 != 0 )
            {
               ChangePostValue( "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_27_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOID_"+sGXsfl_27_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_27_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ZONASID_"+sGXsfl_27_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtZonasID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ZONASID_"+sGXsfl_27_idx+"Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtZonasID_Visible), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0X36( ) ;
         if ( AnyError != 0 )
         {
            O197ProfesionalesAutoEnuZona = s197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         nRcdExists_36 = 0;
         nIsMod_36 = 0;
         nRcdDeleted_36 = 0;
      }

      protected void ProcessLevel0X34( )
      {
         /* Save parent mode. */
         sMode34 = Gx_mode;
         ProcessNestedLevel0X36( ) ;
         if ( AnyError != 0 )
         {
            O197ProfesionalesAutoEnuZona = s197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode34;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000X25 */
         pr_default.execute(23, new Object[] {A197ProfesionalesAutoEnuZona, A120ProfesionalesId});
         pr_default.close(23);
         pr_default.SmartCacheProvider.SetUpdated("Profesionales");
      }

      protected void EndLevel0X34( )
      {
         pr_default.close(5);
         if ( AnyError == 0 )
         {
            BeforeComplete0X34( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(6);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.close(3);
            pr_default.close(4);
            context.CommitDataStores("profesionaleszonas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0X0( ) ;
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
            context.RollbackDataStores("profesionaleszonas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0X34( )
      {
         this.A120ProfesionalesId = A120ProfesionalesId ;
         /* Scan By routine */
         /* Using cursor T000X26 */
         pr_default.execute(24, new Object[] {A120ProfesionalesId});
         RcdFound34 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound34 = 1;
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0X34( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound34 = 1;
         }
      }

      protected void ScanEnd0X34( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm0X34( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0X34( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0X34( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0X34( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0X34( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0X34( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0X34( )
      {
      }

      protected void ZM0X36( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z112DepartamentoId = T000X3_A112DepartamentoId[0];
               Z114DepartamentoMunicipioId = T000X3_A114DepartamentoMunicipioId[0];
               Z110ZonasID = T000X3_A110ZonasID[0];
            }
            else
            {
               Z112DepartamentoId = A112DepartamentoId;
               Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
               Z110ZonasID = A110ZonasID;
            }
         }
         if ( GX_JID == -6 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
            Z126ProfesionalesZonasCorrelativo = A126ProfesionalesZonasCorrelativo;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z110ZonasID = A110ZonasID;
            Z113DepartamentoDepartamento = A113DepartamentoDepartamento;
            Z116PaisID = A116PaisID;
         }
      }

      protected void standaloneNotModal0X36( )
      {
         edtProfesionalesZonasCorrelativo_Enabled = 0;
         AssignProp("", false, edtProfesionalesZonasCorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0), !bGXsfl_27_Refreshing);
      }

      protected void standaloneModal0X36( )
      {
         if ( IsIns( )  )
         {
            A197ProfesionalesAutoEnuZona = (short)(O197ProfesionalesAutoEnuZona+1);
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A126ProfesionalesZonasCorrelativo = A197ProfesionalesAutoEnuZona;
         }
         else
         {
            if ( IsIns( )  && (0==A126ProfesionalesZonasCorrelativo) && ( Gx_BScreen == 0 ) )
            {
               A126ProfesionalesZonasCorrelativo = 0;
            }
         }
      }

      protected void Load0X36( )
      {
         /* Using cursor T000X27 */
         pr_default.execute(25, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound36 = 1;
            A113DepartamentoDepartamento = T000X27_A113DepartamentoDepartamento[0];
            A112DepartamentoId = T000X27_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = T000X27_A114DepartamentoMunicipioId[0];
            A110ZonasID = T000X27_A110ZonasID[0];
            n110ZonasID = T000X27_n110ZonasID[0];
            A116PaisID = T000X27_A116PaisID[0];
            ZM0X36( -6) ;
         }
         pr_default.close(25);
         OnLoadActions0X36( ) ;
      }

      protected void OnLoadActions0X36( )
      {
         if ( ( A112DepartamentoId == 1 ) && true /* After */ )
         {
            edtZonasID_Visible = 0;
            AssignProp("", false, edtZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtZonasID_Visible), 5, 0), !bGXsfl_27_Refreshing);
         }
         else
         {
            if ( ( A112DepartamentoId >= 2 ) && true /* After */ )
            {
               edtZonasID_Visible = 1;
               AssignProp("", false, edtZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtZonasID_Visible), 5, 0), !bGXsfl_27_Refreshing);
            }
         }
      }

      protected void CheckExtendedTable0X36( )
      {
         nIsDirty_36 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0X36( ) ;
         /* Using cursor T000X4 */
         pr_default.execute(2, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "DEPARTAMENTOID_" + sGXsfl_27_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A113DepartamentoDepartamento = T000X4_A113DepartamentoDepartamento[0];
         A116PaisID = T000X4_A116PaisID[0];
         pr_default.close(2);
         /* Using cursor T000X5 */
         pr_default.execute(3, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "DEPARTAMENTOMUNICIPIOID_" + sGXsfl_27_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T000X6 */
         pr_default.execute(4, new Object[] {n110ZonasID, A110ZonasID, A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A110ZonasID) || (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GXCCtl = "DEPARTAMENTOMUNICIPIOID_" + sGXsfl_27_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Zonas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtZonasID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         if ( ( A112DepartamentoId == 1 ) && true /* After */ )
         {
            edtZonasID_Visible = 0;
            AssignProp("", false, edtZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtZonasID_Visible), 5, 0), !bGXsfl_27_Refreshing);
         }
         else
         {
            if ( ( A112DepartamentoId >= 2 ) && true /* After */ )
            {
               edtZonasID_Visible = 1;
               AssignProp("", false, edtZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtZonasID_Visible), 5, 0), !bGXsfl_27_Refreshing);
            }
         }
      }

      protected void CloseExtendedTableCursors0X36( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable0X36( )
      {
      }

      protected void gxLoad_7( long A112DepartamentoId )
      {
         /* Using cursor T000X28 */
         pr_default.execute(26, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GXCCtl = "DEPARTAMENTOID_" + sGXsfl_27_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A113DepartamentoDepartamento = T000X28_A113DepartamentoDepartamento[0];
         A116PaisID = T000X28_A116PaisID[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A113DepartamentoDepartamento))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A116PaisID))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(26) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(26);
      }

      protected void gxLoad_8( long A112DepartamentoId ,
                               long A114DepartamentoMunicipioId )
      {
         /* Using cursor T000X29 */
         pr_default.execute(27, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GXCCtl = "DEPARTAMENTOMUNICIPIOID_" + sGXsfl_27_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(27) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(27);
      }

      protected void gxLoad_9( long A110ZonasID ,
                               long A112DepartamentoId ,
                               long A114DepartamentoMunicipioId )
      {
         /* Using cursor T000X30 */
         pr_default.execute(28, new Object[] {n110ZonasID, A110ZonasID, A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            if ( ! ( (0==A110ZonasID) || (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GXCCtl = "DEPARTAMENTOMUNICIPIOID_" + sGXsfl_27_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Zonas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtZonasID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(28) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(28);
      }

      protected void GetKey0X36( )
      {
         /* Using cursor T000X31 */
         pr_default.execute(29, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound36 = 1;
         }
         else
         {
            RcdFound36 = 0;
         }
         pr_default.close(29);
      }

      protected void getByPrimaryKey0X36( )
      {
         /* Using cursor T000X3 */
         pr_default.execute(1, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
         if ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(T000X3_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
         {
            ZM0X36( 6) ;
            RcdFound36 = 1;
            InitializeNonKey0X36( ) ;
            A126ProfesionalesZonasCorrelativo = T000X3_A126ProfesionalesZonasCorrelativo[0];
            A112DepartamentoId = T000X3_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = T000X3_A114DepartamentoMunicipioId[0];
            A110ZonasID = T000X3_A110ZonasID[0];
            n110ZonasID = T000X3_n110ZonasID[0];
            Z120ProfesionalesId = A120ProfesionalesId;
            Z126ProfesionalesZonasCorrelativo = A126ProfesionalesZonasCorrelativo;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0X36( ) ;
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound36 = 0;
            InitializeNonKey0X36( ) ;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0X36( ) ;
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0X36( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0X36( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000X2 */
            pr_default.execute(0, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesZonas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z112DepartamentoId != T000X2_A112DepartamentoId[0] ) || ( Z114DepartamentoMunicipioId != T000X2_A114DepartamentoMunicipioId[0] ) || ( Z110ZonasID != T000X2_A110ZonasID[0] ) )
            {
               if ( Z112DepartamentoId != T000X2_A112DepartamentoId[0] )
               {
                  GXUtil.WriteLog("profesionaleszonas:[seudo value changed for attri]"+"DepartamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z112DepartamentoId);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A112DepartamentoId[0]);
               }
               if ( Z114DepartamentoMunicipioId != T000X2_A114DepartamentoMunicipioId[0] )
               {
                  GXUtil.WriteLog("profesionaleszonas:[seudo value changed for attri]"+"DepartamentoMunicipioId");
                  GXUtil.WriteLogRaw("Old: ",Z114DepartamentoMunicipioId);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A114DepartamentoMunicipioId[0]);
               }
               if ( Z110ZonasID != T000X2_A110ZonasID[0] )
               {
                  GXUtil.WriteLog("profesionaleszonas:[seudo value changed for attri]"+"ZonasID");
                  GXUtil.WriteLogRaw("Old: ",Z110ZonasID);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A110ZonasID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProfesionalesZonas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0X36( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0X36( 0) ;
            CheckOptimisticConcurrency0X36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0X36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X32 */
                     pr_default.execute(30, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo, A112DepartamentoId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID});
                     pr_default.close(30);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesZonas");
                     if ( (pr_default.getStatus(30) == 1) )
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
               Load0X36( ) ;
            }
            EndLevel0X36( ) ;
         }
         CloseExtendedTableCursors0X36( ) ;
      }

      protected void Update0X36( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X36( ) ;
         }
         if ( ( nIsMod_36 != 0 ) || ( nIsDirty_36 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0X36( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0X36( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0X36( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000X33 */
                        pr_default.execute(31, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID, A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
                        pr_default.close(31);
                        pr_default.SmartCacheProvider.SetUpdated("ProfesionalesZonas");
                        if ( (pr_default.getStatus(31) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesZonas"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0X36( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0X36( ) ;
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
               EndLevel0X36( ) ;
            }
         }
         CloseExtendedTableCursors0X36( ) ;
      }

      protected void DeferredUpdate0X36( )
      {
      }

      protected void Delete0X36( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0X36( ) ;
            AfterConfirm0X36( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0X36( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000X34 */
                  pr_default.execute(32, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
                  pr_default.close(32);
                  pr_default.SmartCacheProvider.SetUpdated("ProfesionalesZonas");
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
         sMode36 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0X36( ) ;
         Gx_mode = sMode36;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0X36( )
      {
         standaloneModal0X36( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000X35 */
            pr_default.execute(33, new Object[] {A112DepartamentoId});
            A113DepartamentoDepartamento = T000X35_A113DepartamentoDepartamento[0];
            A116PaisID = T000X35_A116PaisID[0];
            pr_default.close(33);
            if ( ( A112DepartamentoId == 1 ) && true /* After */ )
            {
               edtZonasID_Visible = 0;
               AssignProp("", false, edtZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtZonasID_Visible), 5, 0), !bGXsfl_27_Refreshing);
            }
            else
            {
               if ( ( A112DepartamentoId >= 2 ) && true /* After */ )
               {
                  edtZonasID_Visible = 1;
                  AssignProp("", false, edtZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtZonasID_Visible), 5, 0), !bGXsfl_27_Refreshing);
               }
            }
         }
      }

      protected void EndLevel0X36( )
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

      public void ScanStart0X36( )
      {
         /* Scan By routine */
         /* Using cursor T000X36 */
         pr_default.execute(34, new Object[] {A120ProfesionalesId});
         RcdFound36 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound36 = 1;
            A126ProfesionalesZonasCorrelativo = T000X36_A126ProfesionalesZonasCorrelativo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0X36( )
      {
         /* Scan next routine */
         pr_default.readNext(34);
         RcdFound36 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound36 = 1;
            A126ProfesionalesZonasCorrelativo = T000X36_A126ProfesionalesZonasCorrelativo[0];
         }
      }

      protected void ScanEnd0X36( )
      {
         pr_default.close(34);
      }

      protected void AfterConfirm0X36( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0X36( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0X36( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0X36( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0X36( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0X36( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0X36( )
      {
         edtProfesionalesZonasCorrelativo_Enabled = 0;
         AssignProp("", false, edtProfesionalesZonasCorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtDepartamentoId_Enabled = 0;
         AssignProp("", false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtDepartamentoMunicipioId_Enabled = 0;
         AssignProp("", false, edtDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtZonasID_Enabled = 0;
         AssignProp("", false, edtZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonasID_Enabled), 5, 0), !bGXsfl_27_Refreshing);
      }

      protected void send_integrity_lvl_hashes0X36( )
      {
      }

      protected void send_integrity_lvl_hashes0X34( )
      {
      }

      protected void SubsflControlProps_2736( )
      {
         edtProfesionalesZonasCorrelativo_Internalname = "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_27_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_27_idx;
         imgprompt_112_Internalname = "PROMPT_112_"+sGXsfl_27_idx;
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_27_idx;
         imgprompt_114_Internalname = "PROMPT_114_"+sGXsfl_27_idx;
         edtZonasID_Internalname = "ZONASID_"+sGXsfl_27_idx;
         imgprompt_110_Internalname = "PROMPT_110_"+sGXsfl_27_idx;
      }

      protected void SubsflControlProps_fel_2736( )
      {
         edtProfesionalesZonasCorrelativo_Internalname = "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_27_fel_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_27_fel_idx;
         imgprompt_112_Internalname = "PROMPT_112_"+sGXsfl_27_fel_idx;
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_27_fel_idx;
         imgprompt_114_Internalname = "PROMPT_114_"+sGXsfl_27_fel_idx;
         edtZonasID_Internalname = "ZONASID_"+sGXsfl_27_fel_idx;
         imgprompt_110_Internalname = "PROMPT_110_"+sGXsfl_27_fel_idx;
      }

      protected void AddRow0X36( )
      {
         nGXsfl_27_idx = (int)(nGXsfl_27_idx+1);
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_2736( ) ;
         SendRow0X36( ) ;
      }

      protected void SendRow0X36( )
      {
         Gridprofesionaleszonas_zonasRow = GXWebRow.GetNew(context);
         if ( subGridprofesionaleszonas_zonas_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridprofesionaleszonas_zonas_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridprofesionaleszonas_zonas_Class, "") != 0 )
            {
               subGridprofesionaleszonas_zonas_Linesclass = subGridprofesionaleszonas_zonas_Class+"Odd";
            }
         }
         else if ( subGridprofesionaleszonas_zonas_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridprofesionaleszonas_zonas_Backstyle = 0;
            subGridprofesionaleszonas_zonas_Backcolor = subGridprofesionaleszonas_zonas_Allbackcolor;
            if ( StringUtil.StrCmp(subGridprofesionaleszonas_zonas_Class, "") != 0 )
            {
               subGridprofesionaleszonas_zonas_Linesclass = subGridprofesionaleszonas_zonas_Class+"Uniform";
            }
         }
         else if ( subGridprofesionaleszonas_zonas_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridprofesionaleszonas_zonas_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridprofesionaleszonas_zonas_Class, "") != 0 )
            {
               subGridprofesionaleszonas_zonas_Linesclass = subGridprofesionaleszonas_zonas_Class+"Odd";
            }
            subGridprofesionaleszonas_zonas_Backcolor = (int)(0x0);
         }
         else if ( subGridprofesionaleszonas_zonas_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridprofesionaleszonas_zonas_Backstyle = 1;
            if ( ((int)((nGXsfl_27_idx) % (2))) == 0 )
            {
               subGridprofesionaleszonas_zonas_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridprofesionaleszonas_zonas_Class, "") != 0 )
               {
                  subGridprofesionaleszonas_zonas_Linesclass = subGridprofesionaleszonas_zonas_Class+"Even";
               }
            }
            else
            {
               subGridprofesionaleszonas_zonas_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridprofesionaleszonas_zonas_Class, "") != 0 )
               {
                  subGridprofesionaleszonas_zonas_Linesclass = subGridprofesionaleszonas_zonas_Class+"Odd";
               }
            }
         }
         imgprompt_110_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0121_2.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ZONASID_"+sGXsfl_27_idx+"'), id:'"+"ZONASID_"+sGXsfl_27_idx+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOID_"+sGXsfl_27_idx+"'), id:'"+"DEPARTAMENTOID_"+sGXsfl_27_idx+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOMUNICIPIOID_"+sGXsfl_27_idx+"'), id:'"+"DEPARTAMENTOMUNICIPIOID_"+sGXsfl_27_idx+"'"+",IOType:'in'}"+"],"+"gx.dom.form()."+"nIsMod_36_"+sGXsfl_27_idx+","+"'', false"+","+"false"+");");
         imgprompt_114_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00m1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOID_"+sGXsfl_27_idx+"'), id:'"+"DEPARTAMENTOID_"+sGXsfl_27_idx+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOMUNICIPIOID_"+sGXsfl_27_idx+"'), id:'"+"DEPARTAMENTOMUNICIPIOID_"+sGXsfl_27_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_36_"+sGXsfl_27_idx+","+"'', false"+","+"false"+");");
         imgprompt_112_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00l0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"DEPARTAMENTOID_"+sGXsfl_27_idx+"'), id:'"+"DEPARTAMENTOID_"+sGXsfl_27_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_36_"+sGXsfl_27_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_36_" + sGXsfl_27_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_27_idx + "',27)\"";
         ROClassString = "Attribute";
         Gridprofesionaleszonas_zonasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesZonasCorrelativo_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A126ProfesionalesZonasCorrelativo), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProfesionalesZonasCorrelativo_Enabled!=0) ? context.localUtil.Format( (decimal)(A126ProfesionalesZonasCorrelativo), "ZZZ9") : context.localUtil.Format( (decimal)(A126ProfesionalesZonasCorrelativo), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,28);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesZonasCorrelativo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProfesionalesZonasCorrelativo_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_36_" + sGXsfl_27_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_27_idx + "',27)\"";
         ROClassString = "Attribute";
         Gridprofesionaleszonas_zonasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtDepartamentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,29);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtDepartamentoId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_112_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_112_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridprofesionaleszonas_zonasRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_112_Internalname,(string)sImgUrl,(string)imgprompt_112_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_112_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_36_" + sGXsfl_27_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_27_idx + "',27)\"";
         ROClassString = "Attribute";
         Gridprofesionaleszonas_zonasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoMunicipioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtDepartamentoMunicipioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,30);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoMunicipioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtDepartamentoMunicipioId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_114_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_114_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridprofesionaleszonas_zonasRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_114_Internalname,(string)sImgUrl,(string)imgprompt_114_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_114_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_36_" + sGXsfl_27_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 31,'',false,'" + sGXsfl_27_idx + "',27)\"";
         ROClassString = "Attribute";
         Gridprofesionaleszonas_zonasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtZonasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtZonasID_Enabled!=0) ? context.localUtil.Format( (decimal)(A110ZonasID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A110ZonasID), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,31);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",context.GetMessage( "Seleccione su Zona", ""),(string)edtZonasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtZonasID_Visible,(int)edtZonasID_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)27,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_110_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_110_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridprofesionaleszonas_zonasRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_110_Internalname,(string)sImgUrl,(string)imgprompt_110_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_110_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         context.httpAjaxContext.ajax_sending_grid_row(Gridprofesionaleszonas_zonasRow);
         send_integrity_lvl_hashes0X36( ) ;
         GXCCtl = "Z126ProfesionalesZonasCorrelativo_" + sGXsfl_27_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126ProfesionalesZonasCorrelativo), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z112DepartamentoId_" + sGXsfl_27_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z114DepartamentoMunicipioId_" + sGXsfl_27_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z110ZonasID_" + sGXsfl_27_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_36_" + sGXsfl_27_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_36), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_36_" + sGXsfl_27_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_36), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_36_" + sGXsfl_27_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_36), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "PROFESIONALESID_" + sGXsfl_27_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( A120ProfesionalesId));
         GXCCtl = "vMODE_" + sGXsfl_27_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_27_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOID_"+sGXsfl_27_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_27_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ZONASID_"+sGXsfl_27_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtZonasID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ZONASID_"+sGXsfl_27_idx+"Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtZonasID_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_112_"+sGXsfl_27_idx+"Link", StringUtil.RTrim( imgprompt_112_Link));
         GxWebStd.gx_hidden_field( context, "PROMPT_114_"+sGXsfl_27_idx+"Link", StringUtil.RTrim( imgprompt_114_Link));
         GxWebStd.gx_hidden_field( context, "PROMPT_110_"+sGXsfl_27_idx+"Link", StringUtil.RTrim( imgprompt_110_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridprofesionaleszonas_zonasContainer.AddRow(Gridprofesionaleszonas_zonasRow);
      }

      protected void ReadRow0X36( )
      {
         nGXsfl_27_idx = (int)(nGXsfl_27_idx+1);
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_2736( ) ;
         edtProfesionalesZonasCorrelativo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_27_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtDepartamentoId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOID_"+sGXsfl_27_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtDepartamentoMunicipioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_27_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtZonasID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ZONASID_"+sGXsfl_27_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtZonasID_Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ZONASID_"+sGXsfl_27_idx+"Visible"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_112_Link = cgiGet( "PROMPT_112_"+sGXsfl_27_idx+"Link");
         imgprompt_112_Link = cgiGet( "PROMPT_114_"+sGXsfl_27_idx+"Link");
         imgprompt_112_Link = cgiGet( "PROMPT_110_"+sGXsfl_27_idx+"Link");
         A126ProfesionalesZonasCorrelativo = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesZonasCorrelativo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "DEPARTAMENTOID_" + sGXsfl_27_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
            wbErr = true;
            A112DepartamentoId = 0;
         }
         else
         {
            A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "DEPARTAMENTOMUNICIPIOID_" + sGXsfl_27_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtDepartamentoMunicipioId_Internalname;
            wbErr = true;
            A114DepartamentoMunicipioId = 0;
         }
         else
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "ZONASID_" + sGXsfl_27_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtZonasID_Internalname;
            wbErr = true;
            A110ZonasID = 0;
            n110ZonasID = false;
         }
         else
         {
            A110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n110ZonasID = false;
         }
         n110ZonasID = ((0==A110ZonasID) ? true : false);
         GXCCtl = "Z126ProfesionalesZonasCorrelativo_" + sGXsfl_27_idx;
         Z126ProfesionalesZonasCorrelativo = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z112DepartamentoId_" + sGXsfl_27_idx;
         Z112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z114DepartamentoMunicipioId_" + sGXsfl_27_idx;
         Z114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z110ZonasID_" + sGXsfl_27_idx;
         Z110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n110ZonasID = ((0==A110ZonasID) ? true : false);
         GXCCtl = "nRcdDeleted_36_" + sGXsfl_27_idx;
         nRcdDeleted_36 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_36_" + sGXsfl_27_idx;
         nRcdExists_36 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_36_" + sGXsfl_27_idx;
         nIsMod_36 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtZonasID_Visible = edtZonasID_Visible;
         defedtProfesionalesZonasCorrelativo_Enabled = edtProfesionalesZonasCorrelativo_Enabled;
      }

      protected void ConfirmValues0X0( )
      {
         nGXsfl_27_idx = 0;
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_2736( ) ;
         while ( nGXsfl_27_idx < nRC_GXsfl_27 )
         {
            nGXsfl_27_idx = (int)(nGXsfl_27_idx+1);
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_2736( ) ;
            ChangePostValue( "Z126ProfesionalesZonasCorrelativo_"+sGXsfl_27_idx, cgiGet( "ZT_"+"Z126ProfesionalesZonasCorrelativo_"+sGXsfl_27_idx)) ;
            DeletePostValue( "ZT_"+"Z126ProfesionalesZonasCorrelativo_"+sGXsfl_27_idx) ;
            ChangePostValue( "Z112DepartamentoId_"+sGXsfl_27_idx, cgiGet( "ZT_"+"Z112DepartamentoId_"+sGXsfl_27_idx)) ;
            DeletePostValue( "ZT_"+"Z112DepartamentoId_"+sGXsfl_27_idx) ;
            ChangePostValue( "Z114DepartamentoMunicipioId_"+sGXsfl_27_idx, cgiGet( "ZT_"+"Z114DepartamentoMunicipioId_"+sGXsfl_27_idx)) ;
            DeletePostValue( "ZT_"+"Z114DepartamentoMunicipioId_"+sGXsfl_27_idx) ;
            ChangePostValue( "Z110ZonasID_"+sGXsfl_27_idx, cgiGet( "ZT_"+"Z110ZonasID_"+sGXsfl_27_idx)) ;
            DeletePostValue( "ZT_"+"Z110ZonasID_"+sGXsfl_27_idx) ;
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
         GXEncryptionTmp = "profesionaleszonas.aspx"+UrlEncode(StringUtil.RTrim(A120ProfesionalesId)) + "," + UrlEncode(StringUtil.RTrim(Gx_mode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profesionaleszonas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ProfesionalesZonas");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("profesionaleszonas:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z120ProfesionalesId", StringUtil.RTrim( Z120ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "Z197ProfesionalesAutoEnuZona", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z197ProfesionalesAutoEnuZona), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O197ProfesionalesAutoEnuZona", StringUtil.LTrim( StringUtil.NToC( (decimal)(O197ProfesionalesAutoEnuZona), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_27", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_27_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESID", StringUtil.RTrim( A120ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAUTOENUZONA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTODEPARTAMENTO", StringUtil.RTrim( A113DepartamentoDepartamento));
         GxWebStd.gx_hidden_field( context, "PAISID", StringUtil.RTrim( A116PaisID));
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
         GXEncryptionTmp = "profesionaleszonas.aspx"+UrlEncode(StringUtil.RTrim(A120ProfesionalesId)) + "," + UrlEncode(StringUtil.RTrim(Gx_mode));
         return formatLink("profesionaleszonas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ProfesionalesZonas" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Profesionales Zonas", "") ;
      }

      protected void InitializeNonKey0X34( )
      {
         A197ProfesionalesAutoEnuZona = 0;
         AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
         AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         Z197ProfesionalesAutoEnuZona = 0;
      }

      protected void InitAll0X34( )
      {
         InitializeNonKey0X34( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0X36( )
      {
         A116PaisID = "";
         AssignAttri("", false, "A116PaisID", A116PaisID);
         A112DepartamentoId = 0;
         A113DepartamentoDepartamento = "";
         AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
         A114DepartamentoMunicipioId = 0;
         A110ZonasID = 0;
         n110ZonasID = false;
         Z112DepartamentoId = 0;
         Z114DepartamentoMunicipioId = 0;
         Z110ZonasID = 0;
      }

      protected void InitAll0X36( )
      {
         A126ProfesionalesZonasCorrelativo = 0;
         InitializeNonKey0X36( ) ;
      }

      protected void StandaloneModalInsert0X36( )
      {
         A197ProfesionalesAutoEnuZona = i197ProfesionalesAutoEnuZona;
         AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932143075", true, true, false);
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
         context.AddJavascriptSource("profesionaleszonas.js", "?2026932143075", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties36( )
      {
         edtZonasID_Visible = defedtZonasID_Visible;
         AssignProp("", false, edtZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtZonasID_Visible), 5, 0), !bGXsfl_27_Refreshing);
         edtProfesionalesZonasCorrelativo_Enabled = defedtProfesionalesZonasCorrelativo_Enabled;
         AssignProp("", false, edtProfesionalesZonasCorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0), !bGXsfl_27_Refreshing);
      }

      protected void StartGridControl27( )
      {
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("GridName", "Gridprofesionaleszonas_zonas");
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("Header", subGridprofesionaleszonas_zonas_Header);
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("Class", "Grid");
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionaleszonas_zonas_Backcolorstyle), 1, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("CmpContext", "");
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("InMasterPage", "false");
         Gridprofesionaleszonas_zonasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionaleszonas_zonasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A126ProfesionalesZonasCorrelativo), 4, 0, ".", ""))));
         Gridprofesionaleszonas_zonasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddColumnProperties(Gridprofesionaleszonas_zonasColumn);
         Gridprofesionaleszonas_zonasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionaleszonas_zonasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", ""))));
         Gridprofesionaleszonas_zonasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoId_Enabled), 5, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddColumnProperties(Gridprofesionaleszonas_zonasColumn);
         Gridprofesionaleszonas_zonasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionaleszonas_zonasContainer.AddColumnProperties(Gridprofesionaleszonas_zonasColumn);
         Gridprofesionaleszonas_zonasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionaleszonas_zonasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", ""))));
         Gridprofesionaleszonas_zonasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDepartamentoMunicipioId_Enabled), 5, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddColumnProperties(Gridprofesionaleszonas_zonasColumn);
         Gridprofesionaleszonas_zonasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionaleszonas_zonasContainer.AddColumnProperties(Gridprofesionaleszonas_zonasColumn);
         Gridprofesionaleszonas_zonasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionaleszonas_zonasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, ".", ""))));
         Gridprofesionaleszonas_zonasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtZonasID_Enabled), 5, 0, ".", "")));
         Gridprofesionaleszonas_zonasColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtZonasID_Visible), 5, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddColumnProperties(Gridprofesionaleszonas_zonasColumn);
         Gridprofesionaleszonas_zonasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionaleszonas_zonasContainer.AddColumnProperties(Gridprofesionaleszonas_zonasColumn);
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionaleszonas_zonas_Selectedindex), 4, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionaleszonas_zonas_Allowselection), 1, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionaleszonas_zonas_Selectioncolor), 9, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionaleszonas_zonas_Allowhovering), 1, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionaleszonas_zonas_Hoveringcolor), 9, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionaleszonas_zonas_Allowcollapsing), 1, 0, ".", "")));
         Gridprofesionaleszonas_zonasContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionaleszonas_zonas_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         lblTitle_Internalname = "TITLE";
         lblTitlezonas_Internalname = "TITLEZONAS";
         edtProfesionalesZonasCorrelativo_Internalname = "PROFESIONALESZONASCORRELATIVO";
         edtDepartamentoId_Internalname = "DEPARTAMENTOID";
         edtDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID";
         edtZonasID_Internalname = "ZONASID";
         imgImage1_Internalname = "IMAGE1";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divZonastable_Internalname = "ZONASTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_112_Internalname = "PROMPT_112";
         imgprompt_114_Internalname = "PROMPT_114";
         imgprompt_110_Internalname = "PROMPT_110";
         subGridprofesionaleszonas_zonas_Internalname = "GRIDPROFESIONALESZONAS_ZONAS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridprofesionaleszonas_zonas_Allowcollapsing = 0;
         subGridprofesionaleszonas_zonas_Allowselection = 0;
         subGridprofesionaleszonas_zonas_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Profesionales Zonas", "");
         imgprompt_110_Visible = 1;
         imgprompt_110_Link = "";
         edtZonasID_Jsonclick = "";
         imgprompt_114_Visible = 1;
         imgprompt_114_Link = "";
         edtDepartamentoMunicipioId_Jsonclick = "";
         imgprompt_112_Visible = 1;
         imgprompt_112_Link = "";
         imgprompt_112_Visible = 1;
         edtDepartamentoId_Jsonclick = "";
         edtProfesionalesZonasCorrelativo_Jsonclick = "";
         subGridprofesionaleszonas_zonas_Class = "Grid";
         subGridprofesionaleszonas_zonas_Backcolorstyle = 0;
         edtZonasID_Visible = -1;
         edtZonasID_Enabled = 1;
         edtDepartamentoMunicipioId_Enabled = 1;
         edtDepartamentoId_Enabled = 1;
         edtProfesionalesZonasCorrelativo_Enabled = 0;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgImage1_Visible = 1;
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

      protected void gxnrGridprofesionaleszonas_zonas_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_2736( ) ;
         while ( nGXsfl_27_idx <= nRC_GXsfl_27 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0X36( ) ;
            standaloneModal0X36( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0X36( ) ;
            nGXsfl_27_idx = (int)(nGXsfl_27_idx+1);
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_2736( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridprofesionaleszonas_zonasContainer)) ;
         /* End function gxnrGridprofesionaleszonas_zonas_newrow */
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

      public void Valid_Departamentoid( )
      {
         /* Using cursor T000X35 */
         pr_default.execute(33, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(33) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
         }
         A113DepartamentoDepartamento = T000X35_A113DepartamentoDepartamento[0];
         A116PaisID = T000X35_A116PaisID[0];
         pr_default.close(33);
         if ( ( A112DepartamentoId == 1 ) && true /* After */ )
         {
            edtZonasID_Visible = 0;
         }
         else
         {
            if ( ( A112DepartamentoId >= 2 ) && true /* After */ )
            {
               edtZonasID_Visible = 1;
            }
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A113DepartamentoDepartamento", StringUtil.RTrim( A113DepartamentoDepartamento));
         AssignAttri("", false, "A116PaisID", StringUtil.RTrim( A116PaisID));
         AssignProp("", false, edtZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtZonasID_Visible), 5, 0), !bGXsfl_27_Refreshing);
      }

      public void Valid_Departamentomunicipioid( )
      {
         /* Using cursor T000X37 */
         pr_default.execute(35, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(35) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoId_Internalname;
         }
         pr_default.close(35);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Zonasid( )
      {
         n110ZonasID = false;
         /* Using cursor T000X38 */
         pr_default.execute(36, new Object[] {n110ZonasID, A110ZonasID, A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(36) == 101) )
         {
            if ( ! ( (0==A110ZonasID) || (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Zonas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
               AnyError = 1;
               GX_FocusControl = edtZonasID_Internalname;
            }
         }
         pr_default.close(36);
         O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A120ProfesionalesId',fld:'PROFESIONALESID',pic:'',type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESZONASCORRELATIVO","{handler:'Valid_Profesionaleszonascorrelativo',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESZONASCORRELATIVO",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A113DepartamentoDepartamento',fld:'DEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'}]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[{av:'A113DepartamentoDepartamento',fld:'DEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'},{av:'edtZonasID_Visible',ctrl:'ZONASID',prop:'Visible'}]}");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID","{handler:'Valid_Departamentomunicipioid',iparms:[{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID",",oparms:[]}");
         setEventMetadata("VALID_ZONASID","{handler:'Valid_Zonasid',iparms:[{av:'A197ProfesionalesAutoEnuZona',fld:'PROFESIONALESAUTOENUZONA',pic:'ZZZ9',type:'int'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_ZONASID",",oparms:[]}");
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
         pr_default.close(33);
         pr_default.close(35);
         pr_default.close(36);
         pr_default.close(6);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOA120ProfesionalesId = "";
         wcpOGx_mode = "";
         Z120ProfesionalesId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         lblTextblock1_Jsonclick = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTitlezonas_Jsonclick = "";
         imgImage1_gximage = "";
         sImgUrl = "";
         TempTags = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridprofesionaleszonas_zonasContainer = new GXWebGrid( context);
         sMode36 = "";
         GX_FocusControl = "";
         sStyleString = "";
         A113DepartamentoDepartamento = "";
         A116PaisID = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode34 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T000X9_A120ProfesionalesId = new string[] {""} ;
         T000X9_A197ProfesionalesAutoEnuZona = new short[1] ;
         T000X10_A120ProfesionalesId = new string[] {""} ;
         T000X8_A120ProfesionalesId = new string[] {""} ;
         T000X8_A197ProfesionalesAutoEnuZona = new short[1] ;
         T000X11_A120ProfesionalesId = new string[] {""} ;
         T000X12_A120ProfesionalesId = new string[] {""} ;
         T000X7_A120ProfesionalesId = new string[] {""} ;
         T000X7_A197ProfesionalesAutoEnuZona = new short[1] ;
         T000X16_A461CentroCostosId = new long[1] ;
         T000X16_A466CentroCostosDetallesId = new long[1] ;
         T000X17_A976ProfesionalesRestriccionId = new long[1] ;
         T000X18_A450ProfComisionesID = new long[1] ;
         T000X19_A127SolicitudesID = new long[1] ;
         T000X19_A140RelacionesId = new long[1] ;
         T000X20_A120ProfesionalesId = new string[] {""} ;
         T000X20_A993ProfesionalServicioId = new long[1] ;
         T000X21_A422PostulacionesId = new long[1] ;
         T000X21_A120ProfesionalesId = new string[] {""} ;
         T000X22_A590Listaid = new long[1] ;
         T000X22_A133ProveedorID = new long[1] ;
         T000X22_A120ProfesionalesId = new string[] {""} ;
         T000X23_A503ComisionesID = new long[1] ;
         T000X23_A120ProfesionalesId = new string[] {""} ;
         T000X24_A120ProfesionalesId = new string[] {""} ;
         T000X24_A121RubrosId = new short[1] ;
         T000X26_A120ProfesionalesId = new string[] {""} ;
         Z113DepartamentoDepartamento = "";
         Z116PaisID = "";
         T000X27_A120ProfesionalesId = new string[] {""} ;
         T000X27_A126ProfesionalesZonasCorrelativo = new short[1] ;
         T000X27_A113DepartamentoDepartamento = new string[] {""} ;
         T000X27_A112DepartamentoId = new long[1] ;
         T000X27_A114DepartamentoMunicipioId = new long[1] ;
         T000X27_A110ZonasID = new long[1] ;
         T000X27_n110ZonasID = new bool[] {false} ;
         T000X27_A116PaisID = new string[] {""} ;
         T000X4_A113DepartamentoDepartamento = new string[] {""} ;
         T000X4_A116PaisID = new string[] {""} ;
         GXCCtl = "";
         T000X5_A112DepartamentoId = new long[1] ;
         T000X6_A110ZonasID = new long[1] ;
         T000X6_n110ZonasID = new bool[] {false} ;
         T000X28_A113DepartamentoDepartamento = new string[] {""} ;
         T000X28_A116PaisID = new string[] {""} ;
         T000X29_A112DepartamentoId = new long[1] ;
         T000X30_A110ZonasID = new long[1] ;
         T000X30_n110ZonasID = new bool[] {false} ;
         T000X31_A120ProfesionalesId = new string[] {""} ;
         T000X31_A126ProfesionalesZonasCorrelativo = new short[1] ;
         T000X3_A120ProfesionalesId = new string[] {""} ;
         T000X3_A126ProfesionalesZonasCorrelativo = new short[1] ;
         T000X3_A112DepartamentoId = new long[1] ;
         T000X3_A114DepartamentoMunicipioId = new long[1] ;
         T000X3_A110ZonasID = new long[1] ;
         T000X3_n110ZonasID = new bool[] {false} ;
         T000X2_A120ProfesionalesId = new string[] {""} ;
         T000X2_A126ProfesionalesZonasCorrelativo = new short[1] ;
         T000X2_A112DepartamentoId = new long[1] ;
         T000X2_A114DepartamentoMunicipioId = new long[1] ;
         T000X2_A110ZonasID = new long[1] ;
         T000X2_n110ZonasID = new bool[] {false} ;
         T000X35_A113DepartamentoDepartamento = new string[] {""} ;
         T000X35_A116PaisID = new string[] {""} ;
         T000X36_A120ProfesionalesId = new string[] {""} ;
         T000X36_A126ProfesionalesZonasCorrelativo = new short[1] ;
         Gridprofesionaleszonas_zonasRow = new GXWebRow();
         subGridprofesionaleszonas_zonas_Linesclass = "";
         ROClassString = "";
         imgprompt_112_gximage = "";
         imgprompt_114_gximage = "";
         imgprompt_110_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         Gridprofesionaleszonas_zonasColumn = new GXWebColumn();
         T000X37_A112DepartamentoId = new long[1] ;
         T000X38_A110ZonasID = new long[1] ;
         T000X38_n110ZonasID = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.profesionaleszonas__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionaleszonas__default(),
            new Object[][] {
                new Object[] {
               T000X2_A120ProfesionalesId, T000X2_A126ProfesionalesZonasCorrelativo, T000X2_A112DepartamentoId, T000X2_A114DepartamentoMunicipioId, T000X2_A110ZonasID, T000X2_n110ZonasID
               }
               , new Object[] {
               T000X3_A120ProfesionalesId, T000X3_A126ProfesionalesZonasCorrelativo, T000X3_A112DepartamentoId, T000X3_A114DepartamentoMunicipioId, T000X3_A110ZonasID, T000X3_n110ZonasID
               }
               , new Object[] {
               T000X4_A113DepartamentoDepartamento, T000X4_A116PaisID
               }
               , new Object[] {
               T000X5_A112DepartamentoId
               }
               , new Object[] {
               T000X6_A110ZonasID
               }
               , new Object[] {
               T000X7_A120ProfesionalesId, T000X7_A197ProfesionalesAutoEnuZona
               }
               , new Object[] {
               T000X8_A120ProfesionalesId, T000X8_A197ProfesionalesAutoEnuZona
               }
               , new Object[] {
               T000X9_A120ProfesionalesId, T000X9_A197ProfesionalesAutoEnuZona
               }
               , new Object[] {
               T000X10_A120ProfesionalesId
               }
               , new Object[] {
               T000X11_A120ProfesionalesId
               }
               , new Object[] {
               T000X12_A120ProfesionalesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000X16_A461CentroCostosId, T000X16_A466CentroCostosDetallesId
               }
               , new Object[] {
               T000X17_A976ProfesionalesRestriccionId
               }
               , new Object[] {
               T000X18_A450ProfComisionesID
               }
               , new Object[] {
               T000X19_A127SolicitudesID, T000X19_A140RelacionesId
               }
               , new Object[] {
               T000X20_A120ProfesionalesId, T000X20_A993ProfesionalServicioId
               }
               , new Object[] {
               T000X21_A422PostulacionesId, T000X21_A120ProfesionalesId
               }
               , new Object[] {
               T000X22_A590Listaid, T000X22_A133ProveedorID, T000X22_A120ProfesionalesId
               }
               , new Object[] {
               T000X23_A503ComisionesID, T000X23_A120ProfesionalesId
               }
               , new Object[] {
               T000X24_A120ProfesionalesId, T000X24_A121RubrosId
               }
               , new Object[] {
               }
               , new Object[] {
               T000X26_A120ProfesionalesId
               }
               , new Object[] {
               T000X27_A120ProfesionalesId, T000X27_A126ProfesionalesZonasCorrelativo, T000X27_A113DepartamentoDepartamento, T000X27_A112DepartamentoId, T000X27_A114DepartamentoMunicipioId, T000X27_A110ZonasID, T000X27_n110ZonasID, T000X27_A116PaisID
               }
               , new Object[] {
               T000X28_A113DepartamentoDepartamento, T000X28_A116PaisID
               }
               , new Object[] {
               T000X29_A112DepartamentoId
               }
               , new Object[] {
               T000X30_A110ZonasID
               }
               , new Object[] {
               T000X31_A120ProfesionalesId, T000X31_A126ProfesionalesZonasCorrelativo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000X35_A113DepartamentoDepartamento, T000X35_A116PaisID
               }
               , new Object[] {
               T000X36_A120ProfesionalesId, T000X36_A126ProfesionalesZonasCorrelativo
               }
               , new Object[] {
               T000X37_A112DepartamentoId
               }
               , new Object[] {
               T000X38_A110ZonasID
               }
            }
         );
         Z120ProfesionalesId = "";
         A120ProfesionalesId = "";
         Z126ProfesionalesZonasCorrelativo = 0;
         A126ProfesionalesZonasCorrelativo = 0;
      }

      private short nIsMod_36 ;
      private short Z197ProfesionalesAutoEnuZona ;
      private short O197ProfesionalesAutoEnuZona ;
      private short Z126ProfesionalesZonasCorrelativo ;
      private short nRcdDeleted_36 ;
      private short nRcdExists_36 ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A197ProfesionalesAutoEnuZona ;
      private short Gx_BScreen ;
      private short nBlankRcdCount36 ;
      private short RcdFound36 ;
      private short B197ProfesionalesAutoEnuZona ;
      private short nBlankRcdUsr36 ;
      private short RcdFound34 ;
      private short s197ProfesionalesAutoEnuZona ;
      private short A126ProfesionalesZonasCorrelativo ;
      private short nIsDirty_36 ;
      private short subGridprofesionaleszonas_zonas_Backcolorstyle ;
      private short subGridprofesionaleszonas_zonas_Backstyle ;
      private short gxajaxcallmode ;
      private short i197ProfesionalesAutoEnuZona ;
      private short subGridprofesionaleszonas_zonas_Allowselection ;
      private short subGridprofesionaleszonas_zonas_Allowhovering ;
      private short subGridprofesionaleszonas_zonas_Allowcollapsing ;
      private short subGridprofesionaleszonas_zonas_Collapsed ;
      private int nRC_GXsfl_27 ;
      private int nGXsfl_27_idx=1 ;
      private int trnEnded ;
      private int imgImage1_Visible ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProfesionalesZonasCorrelativo_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int edtDepartamentoMunicipioId_Enabled ;
      private int edtZonasID_Enabled ;
      private int edtZonasID_Visible ;
      private int fRowAdded ;
      private int subGridprofesionaleszonas_zonas_Backcolor ;
      private int subGridprofesionaleszonas_zonas_Allbackcolor ;
      private int imgprompt_112_Visible ;
      private int imgprompt_114_Visible ;
      private int imgprompt_110_Visible ;
      private int defedtZonasID_Visible ;
      private int defedtProfesionalesZonasCorrelativo_Enabled ;
      private int idxLst ;
      private int subGridprofesionaleszonas_zonas_Selectedindex ;
      private int subGridprofesionaleszonas_zonas_Selectioncolor ;
      private int subGridprofesionaleszonas_zonas_Hoveringcolor ;
      private long Z112DepartamentoId ;
      private long Z114DepartamentoMunicipioId ;
      private long Z110ZonasID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long GRIDPROFESIONALESZONAS_ZONAS_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_27_idx="0001" ;
      private string wcpOA120ProfesionalesId ;
      private string wcpOGx_mode ;
      private string Z120ProfesionalesId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string A120ProfesionalesId ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divFormcontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divZonastable_Internalname ;
      private string lblTitlezonas_Internalname ;
      private string lblTitlezonas_Jsonclick ;
      private string imgImage1_gximage ;
      private string sImgUrl ;
      private string imgImage1_Internalname ;
      private string TempTags ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode36 ;
      private string edtProfesionalesZonasCorrelativo_Internalname ;
      private string edtDepartamentoId_Internalname ;
      private string edtDepartamentoMunicipioId_Internalname ;
      private string edtZonasID_Internalname ;
      private string imgprompt_112_Link ;
      private string GX_FocusControl ;
      private string sStyleString ;
      private string subGridprofesionaleszonas_zonas_Internalname ;
      private string A113DepartamentoDepartamento ;
      private string A116PaisID ;
      private string hsh ;
      private string sMode34 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z113DepartamentoDepartamento ;
      private string Z116PaisID ;
      private string GXCCtl ;
      private string imgprompt_112_Internalname ;
      private string imgprompt_114_Internalname ;
      private string imgprompt_110_Internalname ;
      private string sGXsfl_27_fel_idx="0001" ;
      private string subGridprofesionaleszonas_zonas_Class ;
      private string subGridprofesionaleszonas_zonas_Linesclass ;
      private string imgprompt_110_Link ;
      private string imgprompt_114_Link ;
      private string ROClassString ;
      private string edtProfesionalesZonasCorrelativo_Jsonclick ;
      private string edtDepartamentoId_Jsonclick ;
      private string imgprompt_112_gximage ;
      private string edtDepartamentoMunicipioId_Jsonclick ;
      private string imgprompt_114_gximage ;
      private string edtZonasID_Jsonclick ;
      private string imgprompt_110_gximage ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string subGridprofesionaleszonas_zonas_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n110ZonasID ;
      private bool wbErr ;
      private bool bGXsfl_27_Refreshing=false ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridprofesionaleszonas_zonasContainer ;
      private GXWebRow Gridprofesionaleszonas_zonasRow ;
      private GXWebColumn Gridprofesionaleszonas_zonasColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProfesionalesId ;
      private string aP1_Gx_mode ;
      private IDataStoreProvider pr_default ;
      private string[] T000X9_A120ProfesionalesId ;
      private short[] T000X9_A197ProfesionalesAutoEnuZona ;
      private string[] T000X10_A120ProfesionalesId ;
      private string[] T000X8_A120ProfesionalesId ;
      private short[] T000X8_A197ProfesionalesAutoEnuZona ;
      private string[] T000X11_A120ProfesionalesId ;
      private string[] T000X12_A120ProfesionalesId ;
      private string[] T000X7_A120ProfesionalesId ;
      private short[] T000X7_A197ProfesionalesAutoEnuZona ;
      private long[] T000X16_A461CentroCostosId ;
      private long[] T000X16_A466CentroCostosDetallesId ;
      private long[] T000X17_A976ProfesionalesRestriccionId ;
      private long[] T000X18_A450ProfComisionesID ;
      private long[] T000X19_A127SolicitudesID ;
      private long[] T000X19_A140RelacionesId ;
      private string[] T000X20_A120ProfesionalesId ;
      private long[] T000X20_A993ProfesionalServicioId ;
      private long[] T000X21_A422PostulacionesId ;
      private string[] T000X21_A120ProfesionalesId ;
      private long[] T000X22_A590Listaid ;
      private long[] T000X22_A133ProveedorID ;
      private string[] T000X22_A120ProfesionalesId ;
      private long[] T000X23_A503ComisionesID ;
      private string[] T000X23_A120ProfesionalesId ;
      private string[] T000X24_A120ProfesionalesId ;
      private short[] T000X24_A121RubrosId ;
      private string[] T000X26_A120ProfesionalesId ;
      private string[] T000X27_A120ProfesionalesId ;
      private short[] T000X27_A126ProfesionalesZonasCorrelativo ;
      private string[] T000X27_A113DepartamentoDepartamento ;
      private long[] T000X27_A112DepartamentoId ;
      private long[] T000X27_A114DepartamentoMunicipioId ;
      private long[] T000X27_A110ZonasID ;
      private bool[] T000X27_n110ZonasID ;
      private string[] T000X27_A116PaisID ;
      private string[] T000X4_A113DepartamentoDepartamento ;
      private string[] T000X4_A116PaisID ;
      private long[] T000X5_A112DepartamentoId ;
      private long[] T000X6_A110ZonasID ;
      private bool[] T000X6_n110ZonasID ;
      private string[] T000X28_A113DepartamentoDepartamento ;
      private string[] T000X28_A116PaisID ;
      private long[] T000X29_A112DepartamentoId ;
      private long[] T000X30_A110ZonasID ;
      private bool[] T000X30_n110ZonasID ;
      private string[] T000X31_A120ProfesionalesId ;
      private short[] T000X31_A126ProfesionalesZonasCorrelativo ;
      private string[] T000X3_A120ProfesionalesId ;
      private short[] T000X3_A126ProfesionalesZonasCorrelativo ;
      private long[] T000X3_A112DepartamentoId ;
      private long[] T000X3_A114DepartamentoMunicipioId ;
      private long[] T000X3_A110ZonasID ;
      private bool[] T000X3_n110ZonasID ;
      private string[] T000X2_A120ProfesionalesId ;
      private short[] T000X2_A126ProfesionalesZonasCorrelativo ;
      private long[] T000X2_A112DepartamentoId ;
      private long[] T000X2_A114DepartamentoMunicipioId ;
      private long[] T000X2_A110ZonasID ;
      private bool[] T000X2_n110ZonasID ;
      private string[] T000X35_A113DepartamentoDepartamento ;
      private string[] T000X35_A116PaisID ;
      private string[] T000X36_A120ProfesionalesId ;
      private short[] T000X36_A126ProfesionalesZonasCorrelativo ;
      private long[] T000X37_A112DepartamentoId ;
      private long[] T000X38_A110ZonasID ;
      private bool[] T000X38_n110ZonasID ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class profesionaleszonas__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class profesionaleszonas__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new UpdateCursor(def[30])
       ,new UpdateCursor(def[31])
       ,new UpdateCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000X2;
        prmT000X2 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmT000X3;
        prmT000X3 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmT000X4;
        prmT000X4 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000X5;
        prmT000X5 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000X6;
        prmT000X6 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000X7;
        prmT000X7 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X8;
        prmT000X8 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X9;
        prmT000X9 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X10;
        prmT000X10 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X11;
        prmT000X11 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X12;
        prmT000X12 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X13;
        prmT000X13 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesAutoEnuZona",GXType.Int16,4,0)
        };
        Object[] prmT000X14;
        prmT000X14 = new Object[] {
        new ParDef("@ProfesionalesAutoEnuZona",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X15;
        prmT000X15 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X16;
        prmT000X16 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X17;
        prmT000X17 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X18;
        prmT000X18 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X19;
        prmT000X19 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X20;
        prmT000X20 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X21;
        prmT000X21 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X22;
        prmT000X22 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X23;
        prmT000X23 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X24;
        prmT000X24 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X25;
        prmT000X25 = new Object[] {
        new ParDef("@ProfesionalesAutoEnuZona",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X26;
        prmT000X26 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X27;
        prmT000X27 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmT000X28;
        prmT000X28 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000X29;
        prmT000X29 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000X30;
        prmT000X30 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000X31;
        prmT000X31 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmT000X32;
        prmT000X32 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000X33;
        prmT000X33 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmT000X34;
        prmT000X34 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmT000X35;
        prmT000X35 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000X36;
        prmT000X36 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000X37;
        prmT000X37 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000X38;
        prmT000X38 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000X2", "SELECT [ProfesionalesId], [ProfesionalesZonasCorrelativo], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID] FROM [ProfesionalesZonas] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X3", "SELECT [ProfesionalesId], [ProfesionalesZonasCorrelativo], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID] FROM [ProfesionalesZonas] WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X4", "SELECT [DepartamentoDepartamento], [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X4,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X5", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X5,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X6", "SELECT [ZonasID] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X7", "SELECT [ProfesionalesId], [ProfesionalesAutoEnuZona] FROM [Profesionales] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X8", "SELECT [ProfesionalesId], [ProfesionalesAutoEnuZona] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X9", "SELECT TM1.[ProfesionalesId], TM1.[ProfesionalesAutoEnuZona] FROM [Profesionales] TM1 WHERE TM1.[ProfesionalesId] = @ProfesionalesId ORDER BY TM1.[ProfesionalesId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000X9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X10", "SELECT [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000X10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X11", "SELECT TOP 1 [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000X11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X12", "SELECT TOP 1 [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000X12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X13", "INSERT INTO [Profesionales]([ProfesionalesId], [ProfesionalesAutoEnuZona], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesEmail], [ProfesionalesDireccion], [ProfesionalesVerDatPerSol], [ProfesionalesPerAltShop], [ProfesionalesAutoEnumerar], [EstadosTipo], [EstadosGenericosId], [ProfesionalesFechaAlta], [ProfesionalesFechaActualizado], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [ProfesionalesLimitOSF], [ProfesionalesEsRUT], [ProfesionalesExperiencia], [ProfesionalesAceptoTerminos], [ProfesionalesDeclaroDatosV], [ProfesionalesCuentaBancaria], [BancoId], [ProfesionalesCapacidadProducti], [ProfesionalesFechaNacimiento], [ProfesionalesRUT], [ProfesionalesTipoEmpresa]) VALUES(@ProfesionalesId, @ProfesionalesAutoEnuZona, '', '', '', '', CONVERT(varbinary(1), ''), '', '', '', '', '', '', convert(int, 0), '', convert(int, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(int, 0), convert(int, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', convert(int, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), '', convert(int, 0))", GxErrorMask.GX_NOMASK,prmT000X13)
           ,new CursorDef("T000X14", "UPDATE [Profesionales] SET [ProfesionalesAutoEnuZona]=@ProfesionalesAutoEnuZona  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT000X14)
           ,new CursorDef("T000X15", "DELETE FROM [Profesionales]  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT000X15)
           ,new CursorDef("T000X16", "SELECT TOP 1 [CentroCostosId], [CentroCostosDetallesId] FROM [CentroCostosDetalles] WHERE [CCDetallesProfId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X17", "SELECT TOP 1 [ProfesionalesRestriccionId] FROM [ProfesionalesRestriccion] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X18", "SELECT TOP 1 [ProfComisionesID] FROM [ProfComisiones] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X19", "SELECT TOP 1 [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X20", "SELECT TOP 1 [ProfesionalesId], [ProfesionalServicioId] FROM [ProfesionalesServicios] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X21", "SELECT TOP 1 [PostulacionesId], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X22", "SELECT TOP 1 [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X23", "SELECT TOP 1 [ComisionesID], [ProfesionalesId] FROM [ComisionesProfesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X24", "SELECT TOP 1 [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X25", "UPDATE [Profesionales] SET [ProfesionalesAutoEnuZona]=@ProfesionalesAutoEnuZona  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT000X25)
           ,new CursorDef("T000X26", "SELECT [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000X26,100, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X27", "SELECT T1.[ProfesionalesId], T1.[ProfesionalesZonasCorrelativo], T2.[DepartamentoDepartamento], T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasID], T2.[PaisID] FROM ([ProfesionalesZonas] T1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) WHERE T1.[ProfesionalesId] = @ProfesionalesId and T1.[ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo ORDER BY T1.[ProfesionalesId], T1.[ProfesionalesZonasCorrelativo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X27,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X28", "SELECT [DepartamentoDepartamento], [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X29", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X30", "SELECT [ZonasID] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X31", "SELECT [ProfesionalesId], [ProfesionalesZonasCorrelativo] FROM [ProfesionalesZonas] WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X32", "INSERT INTO [ProfesionalesZonas]([ProfesionalesId], [ProfesionalesZonasCorrelativo], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID]) VALUES(@ProfesionalesId, @ProfesionalesZonasCorrelativo, @DepartamentoId, @DepartamentoMunicipioId, @ZonasID)", GxErrorMask.GX_NOMASK,prmT000X32)
           ,new CursorDef("T000X33", "UPDATE [ProfesionalesZonas] SET [DepartamentoId]=@DepartamentoId, [DepartamentoMunicipioId]=@DepartamentoMunicipioId, [ZonasID]=@ZonasID  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo", GxErrorMask.GX_NOMASK,prmT000X33)
           ,new CursorDef("T000X34", "DELETE FROM [ProfesionalesZonas]  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo", GxErrorMask.GX_NOMASK,prmT000X34)
           ,new CursorDef("T000X35", "SELECT [DepartamentoDepartamento], [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X36", "SELECT [ProfesionalesId], [ProfesionalesZonasCorrelativo] FROM [ProfesionalesZonas] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId], [ProfesionalesZonasCorrelativo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X36,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X37", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X37,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X38", "SELECT [ZonasID] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X38,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 2);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 34 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 35 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 36 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}

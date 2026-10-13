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
   public class profesionalrubros : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"ESTADOSPROFRUBID") == 0 )
         {
            A124EstadosProfRubTipo = GetPar( "EstadosProfRubTipo");
            AssignAttri("", false, "A124EstadosProfRubTipo", A124EstadosProfRubTipo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAESTADOSPROFRUBID0V35( A124EstadosProfRubTipo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A121RubrosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A124EstadosProfRubTipo = GetPar( "EstadosProfRubTipo");
            AssignAttri("", false, "A124EstadosProfRubTipo", A124EstadosProfRubTipo);
            A125EstadosProfRubId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosProfRubId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A124EstadosProfRubTipo, A125EstadosProfRubId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridprofesionalrubros_rubros") == 0 )
         {
            gxnrGridprofesionalrubros_rubros_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "profesionalrubros.aspx")), "profesionalrubros.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "profesionalrubros.aspx")))) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Profesional Rubros", ""), 0) ;
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

      protected void gxnrGridprofesionalrubros_rubros_newrow_invoke( )
      {
         nRC_GXsfl_24 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_24"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_24_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_24_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_24_idx = GetPar( "sGXsfl_24_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridprofesionalrubros_rubros_newrow( ) ;
         /* End function gxnrGridprofesionalrubros_rubros_newrow_invoke */
      }

      public profesionalrubros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionalrubros( IGxContext context )
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
         dynEstadosProfRubId = new GXCombobox();
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "|||", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ProfesionalRubros.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Configuración de Rubros", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ProfesionalRubros.htm");
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
         GxWebStd.gx_div_start( context, divRubrostable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridprofesionalrubros_rubros( ) ;
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
         GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage1_Visible, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalRubros.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalRubros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalRubros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalRubros.htm");
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

      protected void gxdraw_Gridprofesionalrubros_rubros( )
      {
         /*  Grid Control  */
         StartGridControl24( ) ;
         nGXsfl_24_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount35 = 1;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_35 = 1;
               ScanStart0V35( ) ;
               while ( RcdFound35 != 0 )
               {
                  init_level_properties35( ) ;
                  getByPrimaryKey0V35( ) ;
                  AddRow0V35( ) ;
                  ScanNext0V35( ) ;
               }
               ScanEnd0V35( ) ;
               nBlankRcdCount35 = 1;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0V35( ) ;
            standaloneModal0V35( ) ;
            sMode35 = Gx_mode;
            while ( nGXsfl_24_idx < nRC_GXsfl_24 )
            {
               bGXsfl_24_Refreshing = true;
               ReadRow0V35( ) ;
               edtRubrosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_24_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_24_Refreshing);
               edtRubrosImagen_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSIMAGEN_"+sGXsfl_24_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtRubrosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosImagen_Enabled), 5, 0), !bGXsfl_24_Refreshing);
               dynEstadosProfRubId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSPROFRUBID_"+sGXsfl_24_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynEstadosProfRubId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosProfRubId.Enabled), 5, 0), !bGXsfl_24_Refreshing);
               imgprompt_121_Link = cgiGet( "PROMPT_121_"+sGXsfl_24_idx+"Link");
               if ( ( nRcdExists_35 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0V35( ) ;
               }
               SendRow0V35( ) ;
               bGXsfl_24_Refreshing = false;
            }
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount35 = 1;
            nRcdExists_35 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0V35( ) ;
               while ( RcdFound35 != 0 )
               {
                  sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_2435( ) ;
                  init_level_properties35( ) ;
                  standaloneNotModal0V35( ) ;
                  getByPrimaryKey0V35( ) ;
                  standaloneModal0V35( ) ;
                  AddRow0V35( ) ;
                  ScanNext0V35( ) ;
               }
               ScanEnd0V35( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode35 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx+1), 4, 0), 4, "0");
            SubsflControlProps_2435( ) ;
            InitAll0V35( ) ;
            init_level_properties35( ) ;
            nRcdExists_35 = 0;
            nIsMod_35 = 0;
            nRcdDeleted_35 = 0;
            nBlankRcdCount35 = (short)(nBlankRcdUsr35+nBlankRcdCount35);
            fRowAdded = 0;
            while ( nBlankRcdCount35 > 0 )
            {
               standaloneNotModal0V35( ) ;
               standaloneModal0V35( ) ;
               AddRow0V35( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount35 = (short)(nBlankRcdCount35-1);
            }
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridprofesionalrubros_rubrosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridprofesionalrubros_rubros", Gridprofesionalrubros_rubrosContainer, subGridprofesionalrubros_rubros_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridprofesionalrubros_rubrosContainerData", Gridprofesionalrubros_rubrosContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridprofesionalrubros_rubrosContainerData"+"V", Gridprofesionalrubros_rubrosContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridprofesionalrubros_rubrosContainerData"+"V"+"\" value='"+Gridprofesionalrubros_rubrosContainer.GridValuesHidden()+"'/>") ;
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
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_24 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_24"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A120ProfesionalesId = cgiGet( "PROFESIONALESID");
            A124EstadosProfRubTipo = cgiGet( "ESTADOSPROFRUBTIPO");
            A122RubrosNombre = cgiGet( "RUBROSNOMBRE");
            A40000RubrosImagen_GXI = cgiGet( "RUBROSIMAGEN_GXI");
            A221EstadosProfRubNomb = cgiGet( "ESTADOSPROFRUBNOMB");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"ProfesionalRubros");
            forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("profesionalrubros:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                        CONFIRM_0V0( ) ;
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
               InitAll0V34( ) ;
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
            DisableAttributes0V34( ) ;
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

      protected void CONFIRM_0V0( )
      {
         BeforeValidate0V34( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0V34( ) ;
            }
            else
            {
               CheckExtendedTable0V34( ) ;
               CloseExtendedTableCursors0V34( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode34 = Gx_mode;
            CONFIRM_0V35( ) ;
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

      protected void CONFIRM_0V35( )
      {
         nGXsfl_24_idx = 0;
         while ( nGXsfl_24_idx < nRC_GXsfl_24 )
         {
            ReadRow0V35( ) ;
            if ( ( nRcdExists_35 != 0 ) || ( nIsMod_35 != 0 ) )
            {
               GetKey0V35( ) ;
               if ( ( nRcdExists_35 == 0 ) && ( nRcdDeleted_35 == 0 ) )
               {
                  if ( RcdFound35 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0V35( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0V35( ) ;
                        CloseExtendedTableCursors0V35( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "RUBROSID_" + sGXsfl_24_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtRubrosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound35 != 0 )
                  {
                     if ( nRcdDeleted_35 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0V35( ) ;
                        Load0V35( ) ;
                        BeforeValidate0V35( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0V35( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_35 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0V35( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0V35( ) ;
                              CloseExtendedTableCursors0V35( ) ;
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
                     if ( nRcdDeleted_35 == 0 )
                     {
                        GXCCtl = "RUBROSID_" + sGXsfl_24_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtRubrosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtRubrosImagen_Internalname, A168RubrosImagen) ;
            ChangePostValue( dynEstadosProfRubId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A125EstadosProfRubId), 5, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z124EstadosProfRubTipo_"+sGXsfl_24_idx, StringUtil.RTrim( Z124EstadosProfRubTipo)) ;
            ChangePostValue( "ZT_"+"Z125EstadosProfRubId_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125EstadosProfRubId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_35_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_35), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_35_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_35), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_35_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_35), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_35 != 0 )
            {
               ChangePostValue( "RUBROSID_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSIMAGEN_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSPROFRUBID_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadosProfRubId.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0V0( )
      {
      }

      protected void ZM0V34( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -4 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
         }
      }

      protected void standaloneNotModal( )
      {
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

      protected void Load0V34( )
      {
         /* Using cursor T000V8 */
         pr_default.execute(6, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound34 = 1;
            ZM0V34( -4) ;
         }
         pr_default.close(6);
         OnLoadActions0V34( ) ;
      }

      protected void OnLoadActions0V34( )
      {
      }

      protected void CheckExtendedTable0V34( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0V34( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0V34( )
      {
         /* Using cursor T000V9 */
         pr_default.execute(7, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000V7 */
         pr_default.execute(5, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(T000V7_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
         {
            ZM0V34( 4) ;
            RcdFound34 = 1;
            Z120ProfesionalesId = A120ProfesionalesId;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0V34( ) ;
            if ( AnyError == 1 )
            {
               RcdFound34 = 0;
               InitializeNonKey0V34( ) ;
            }
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey0V34( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0V34( ) ;
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
         /* Using cursor T000V10 */
         pr_default.execute(8, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( StringUtil.StrCmp(T000V10_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( StringUtil.StrCmp(T000V10_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
            {
               RcdFound34 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound34 = 0;
         /* Using cursor T000V11 */
         pr_default.execute(9, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( StringUtil.StrCmp(T000V11_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( StringUtil.StrCmp(T000V11_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
            {
               RcdFound34 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0V34( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0V34( ) ;
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
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  /* Update record */
                  Update0V34( ) ;
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 )
               {
                  /* Insert record */
                  Insert0V34( ) ;
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
                     Insert0V34( ) ;
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
            delete( ) ;
            AfterTrn( ) ;
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0V34( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000V6 */
            pr_default.execute(4, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Profesionales"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Profesionales"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0V34( )
      {
         BeforeValidate0V34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V34( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0V34( 0) ;
            CheckOptimisticConcurrency0V34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0V34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000V12 */
                     pr_default.execute(10, new Object[] {A120ProfesionalesId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Profesionales");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ProcessLevel0V34( ) ;
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
               Load0V34( ) ;
            }
            EndLevel0V34( ) ;
         }
         CloseExtendedTableCursors0V34( ) ;
      }

      protected void Update0V34( )
      {
         BeforeValidate0V34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V34( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0V34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [Profesionales] */
                     DeferredUpdate0V34( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0V34( ) ;
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
            EndLevel0V34( ) ;
         }
         CloseExtendedTableCursors0V34( ) ;
      }

      protected void DeferredUpdate0V34( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0V34( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V34( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0V34( ) ;
            AfterConfirm0V34( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0V34( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0V35( ) ;
                  while ( RcdFound35 != 0 )
                  {
                     getByPrimaryKey0V35( ) ;
                     Delete0V35( ) ;
                     ScanNext0V35( ) ;
                  }
                  ScanEnd0V35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000V13 */
                     pr_default.execute(11, new Object[] {A120ProfesionalesId});
                     pr_default.close(11);
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
         EndLevel0V34( ) ;
         Gx_mode = sMode34;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0V34( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000V14 */
            pr_default.execute(12, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Detalles", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000V15 */
            pr_default.execute(13, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "ProfesionalesRestriccion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000V16 */
            pr_default.execute(14, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Prof Comisiones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000V17 */
            pr_default.execute(15, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000V18 */
            pr_default.execute(16, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "ProfesionalesServicios", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000V19 */
            pr_default.execute(17, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000V20 */
            pr_default.execute(18, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupacion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000V21 */
            pr_default.execute(19, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000V22 */
            pr_default.execute(20, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Seleccione la zona de trabajo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void ProcessNestedLevel0V35( )
      {
         nGXsfl_24_idx = 0;
         while ( nGXsfl_24_idx < nRC_GXsfl_24 )
         {
            ReadRow0V35( ) ;
            if ( ( nRcdExists_35 != 0 ) || ( nIsMod_35 != 0 ) )
            {
               standaloneNotModal0V35( ) ;
               GetKey0V35( ) ;
               if ( ( nRcdExists_35 == 0 ) && ( nRcdDeleted_35 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0V35( ) ;
               }
               else
               {
                  if ( RcdFound35 != 0 )
                  {
                     if ( ( nRcdDeleted_35 != 0 ) && ( nRcdExists_35 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0V35( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_35 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0V35( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_35 == 0 )
                     {
                        GXCCtl = "RUBROSID_" + sGXsfl_24_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtRubrosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtRubrosImagen_Internalname, A168RubrosImagen) ;
            ChangePostValue( dynEstadosProfRubId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A125EstadosProfRubId), 5, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z124EstadosProfRubTipo_"+sGXsfl_24_idx, StringUtil.RTrim( Z124EstadosProfRubTipo)) ;
            ChangePostValue( "ZT_"+"Z125EstadosProfRubId_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125EstadosProfRubId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_35_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_35), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_35_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_35), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_35_"+sGXsfl_24_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_35), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_35 != 0 )
            {
               ChangePostValue( "RUBROSID_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSIMAGEN_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSPROFRUBID_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadosProfRubId.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0V35( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_35 = 0;
         nIsMod_35 = 0;
         nRcdDeleted_35 = 0;
      }

      protected void ProcessLevel0V34( )
      {
         /* Save parent mode. */
         sMode34 = Gx_mode;
         ProcessNestedLevel0V35( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode34;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0V34( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0V34( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("profesionalrubros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0V0( ) ;
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
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("profesionalrubros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0V34( )
      {
         this.A120ProfesionalesId = A120ProfesionalesId ;
         /* Scan By routine */
         /* Using cursor T000V23 */
         pr_default.execute(21, new Object[] {A120ProfesionalesId});
         RcdFound34 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound34 = 1;
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0V34( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound34 = 1;
         }
      }

      protected void ScanEnd0V34( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0V34( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0V34( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0V34( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0V34( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0V34( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0V34( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0V34( )
      {
      }

      protected void ZM0V35( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z124EstadosProfRubTipo = T000V3_A124EstadosProfRubTipo[0];
               Z125EstadosProfRubId = T000V3_A125EstadosProfRubId[0];
            }
            else
            {
               Z124EstadosProfRubTipo = A124EstadosProfRubTipo;
               Z125EstadosProfRubId = A125EstadosProfRubId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
            Z121RubrosId = A121RubrosId;
            Z124EstadosProfRubTipo = A124EstadosProfRubTipo;
            Z125EstadosProfRubId = A125EstadosProfRubId;
            Z122RubrosNombre = A122RubrosNombre;
            Z168RubrosImagen = A168RubrosImagen;
            Z40000RubrosImagen_GXI = A40000RubrosImagen_GXI;
            Z221EstadosProfRubNomb = A221EstadosProfRubNomb;
         }
      }

      protected void standaloneNotModal0V35( )
      {
      }

      protected void standaloneModal0V35( )
      {
         A124EstadosProfRubTipo = context.GetMessage( context.GetMessage( "STS", ""), "");
         AssignAttri("", false, "A124EstadosProfRubTipo", A124EstadosProfRubTipo);
         if ( IsIns( )  )
         {
            A125EstadosProfRubId = 1;
         }
         GXAESTADOSPROFRUBID_html0V35( A124EstadosProfRubTipo) ;
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtRubrosId_Enabled = 0;
            AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         }
         else
         {
            edtRubrosId_Enabled = 1;
            AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000V5 */
            pr_default.execute(3, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
            A221EstadosProfRubNomb = T000V5_A221EstadosProfRubNomb[0];
            pr_default.close(3);
         }
      }

      protected void Load0V35( )
      {
         /* Using cursor T000V24 */
         pr_default.execute(22, new Object[] {A120ProfesionalesId, A121RubrosId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound35 = 1;
            A122RubrosNombre = T000V24_A122RubrosNombre[0];
            A40000RubrosImagen_GXI = T000V24_A40000RubrosImagen_GXI[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_24_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A221EstadosProfRubNomb = T000V24_A221EstadosProfRubNomb[0];
            A124EstadosProfRubTipo = T000V24_A124EstadosProfRubTipo[0];
            A125EstadosProfRubId = T000V24_A125EstadosProfRubId[0];
            A168RubrosImagen = T000V24_A168RubrosImagen[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_24_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            ZM0V35( -5) ;
         }
         pr_default.close(22);
         OnLoadActions0V35( ) ;
      }

      protected void OnLoadActions0V35( )
      {
      }

      protected void CheckExtendedTable0V35( )
      {
         nIsDirty_35 = 0;
         Gx_BScreen = 1;
         standaloneModal0V35( ) ;
         /* Using cursor T000V4 */
         pr_default.execute(2, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_24_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A122RubrosNombre = T000V4_A122RubrosNombre[0];
         A40000RubrosImagen_GXI = T000V4_A40000RubrosImagen_GXI[0];
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_24_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A168RubrosImagen = T000V4_A168RubrosImagen[0];
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_24_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         pr_default.close(2);
         /* Using cursor T000V5 */
         pr_default.execute(3, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "ESTADOSPROFRUBID_" + sGXsfl_24_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Prof Rub", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynEstadosProfRubId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A221EstadosProfRubNomb = T000V5_A221EstadosProfRubNomb[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0V35( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0V35( )
      {
      }

      protected void gxLoad_6( short A121RubrosId )
      {
         /* Using cursor T000V25 */
         pr_default.execute(23, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_24_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A122RubrosNombre = T000V25_A122RubrosNombre[0];
         A40000RubrosImagen_GXI = T000V25_A40000RubrosImagen_GXI[0];
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_24_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A168RubrosImagen = T000V25_A168RubrosImagen[0];
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_24_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A122RubrosNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( A168RubrosImagen)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000RubrosImagen_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(23) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(23);
      }

      protected void gxLoad_7( string A124EstadosProfRubTipo ,
                               int A125EstadosProfRubId )
      {
         /* Using cursor T000V26 */
         pr_default.execute(24, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GXCCtl = "ESTADOSPROFRUBID_" + sGXsfl_24_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Prof Rub", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynEstadosProfRubId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A221EstadosProfRubNomb = T000V26_A221EstadosProfRubNomb[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A221EstadosProfRubNomb))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void GetKey0V35( )
      {
         /* Using cursor T000V27 */
         pr_default.execute(25, new Object[] {A120ProfesionalesId, A121RubrosId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound35 = 1;
         }
         else
         {
            RcdFound35 = 0;
         }
         pr_default.close(25);
      }

      protected void getByPrimaryKey0V35( )
      {
         /* Using cursor T000V3 */
         pr_default.execute(1, new Object[] {A120ProfesionalesId, A121RubrosId});
         if ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(T000V3_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
         {
            ZM0V35( 5) ;
            RcdFound35 = 1;
            InitializeNonKey0V35( ) ;
            A121RubrosId = T000V3_A121RubrosId[0];
            A124EstadosProfRubTipo = T000V3_A124EstadosProfRubTipo[0];
            A125EstadosProfRubId = T000V3_A125EstadosProfRubId[0];
            Z120ProfesionalesId = A120ProfesionalesId;
            Z121RubrosId = A121RubrosId;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0V35( ) ;
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound35 = 0;
            InitializeNonKey0V35( ) ;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0V35( ) ;
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0V35( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0V35( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000V2 */
            pr_default.execute(0, new Object[] {A120ProfesionalesId, A121RubrosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesRubros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z124EstadosProfRubTipo, T000V2_A124EstadosProfRubTipo[0]) != 0 ) || ( Z125EstadosProfRubId != T000V2_A125EstadosProfRubId[0] ) )
            {
               if ( StringUtil.StrCmp(Z124EstadosProfRubTipo, T000V2_A124EstadosProfRubTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalrubros:[seudo value changed for attri]"+"EstadosProfRubTipo");
                  GXUtil.WriteLogRaw("Old: ",Z124EstadosProfRubTipo);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A124EstadosProfRubTipo[0]);
               }
               if ( Z125EstadosProfRubId != T000V2_A125EstadosProfRubId[0] )
               {
                  GXUtil.WriteLog("profesionalrubros:[seudo value changed for attri]"+"EstadosProfRubId");
                  GXUtil.WriteLogRaw("Old: ",Z125EstadosProfRubId);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A125EstadosProfRubId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProfesionalesRubros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0V35( )
      {
         BeforeValidate0V35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V35( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0V35( 0) ;
            CheckOptimisticConcurrency0V35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0V35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000V28 */
                     pr_default.execute(26, new Object[] {A120ProfesionalesId, A121RubrosId, A124EstadosProfRubTipo, A125EstadosProfRubId});
                     pr_default.close(26);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRubros");
                     if ( (pr_default.getStatus(26) == 1) )
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
               Load0V35( ) ;
            }
            EndLevel0V35( ) ;
         }
         CloseExtendedTableCursors0V35( ) ;
      }

      protected void Update0V35( )
      {
         BeforeValidate0V35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V35( ) ;
         }
         if ( ( nIsMod_35 != 0 ) || ( nIsDirty_35 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0V35( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0V35( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0V35( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000V29 */
                        pr_default.execute(27, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId, A120ProfesionalesId, A121RubrosId});
                        pr_default.close(27);
                        pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRubros");
                        if ( (pr_default.getStatus(27) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesRubros"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0V35( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0V35( ) ;
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
               EndLevel0V35( ) ;
            }
         }
         CloseExtendedTableCursors0V35( ) ;
      }

      protected void DeferredUpdate0V35( )
      {
      }

      protected void Delete0V35( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0V35( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V35( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0V35( ) ;
            AfterConfirm0V35( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0V35( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000V30 */
                  pr_default.execute(28, new Object[] {A120ProfesionalesId, A121RubrosId});
                  pr_default.close(28);
                  pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRubros");
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
         sMode35 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0V35( ) ;
         Gx_mode = sMode35;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0V35( )
      {
         standaloneModal0V35( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000V31 */
            pr_default.execute(29, new Object[] {A121RubrosId});
            A122RubrosNombre = T000V31_A122RubrosNombre[0];
            A40000RubrosImagen_GXI = T000V31_A40000RubrosImagen_GXI[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_24_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A168RubrosImagen = T000V31_A168RubrosImagen[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_24_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            pr_default.close(29);
            /* Using cursor T000V32 */
            pr_default.execute(30, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
            A221EstadosProfRubNomb = T000V32_A221EstadosProfRubNomb[0];
            pr_default.close(30);
         }
      }

      protected void EndLevel0V35( )
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

      public void ScanStart0V35( )
      {
         /* Scan By routine */
         /* Using cursor T000V33 */
         pr_default.execute(31, new Object[] {A120ProfesionalesId});
         RcdFound35 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound35 = 1;
            A121RubrosId = T000V33_A121RubrosId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0V35( )
      {
         /* Scan next routine */
         pr_default.readNext(31);
         RcdFound35 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound35 = 1;
            A121RubrosId = T000V33_A121RubrosId[0];
         }
      }

      protected void ScanEnd0V35( )
      {
         pr_default.close(31);
      }

      protected void AfterConfirm0V35( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0V35( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0V35( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0V35( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0V35( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0V35( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0V35( )
      {
         edtRubrosId_Enabled = 0;
         AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         edtRubrosImagen_Enabled = 0;
         AssignProp("", false, edtRubrosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosImagen_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         dynEstadosProfRubId.Enabled = 0;
         AssignProp("", false, dynEstadosProfRubId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosProfRubId.Enabled), 5, 0), !bGXsfl_24_Refreshing);
      }

      protected void send_integrity_lvl_hashes0V35( )
      {
      }

      protected void send_integrity_lvl_hashes0V34( )
      {
      }

      protected void SubsflControlProps_2435( )
      {
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_24_idx;
         edtRubrosImagen_Internalname = "RUBROSIMAGEN_"+sGXsfl_24_idx;
         dynEstadosProfRubId_Internalname = "ESTADOSPROFRUBID_"+sGXsfl_24_idx;
         imgprompt_121_Internalname = "PROMPT_121_"+sGXsfl_24_idx;
      }

      protected void SubsflControlProps_fel_2435( )
      {
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_24_fel_idx;
         edtRubrosImagen_Internalname = "RUBROSIMAGEN_"+sGXsfl_24_fel_idx;
         dynEstadosProfRubId_Internalname = "ESTADOSPROFRUBID_"+sGXsfl_24_fel_idx;
         imgprompt_121_Internalname = "PROMPT_121_"+sGXsfl_24_fel_idx;
      }

      protected void AddRow0V35( )
      {
         nGXsfl_24_idx = (int)(nGXsfl_24_idx+1);
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_2435( ) ;
         SendRow0V35( ) ;
      }

      protected void SendRow0V35( )
      {
         Gridprofesionalrubros_rubrosRow = GXWebRow.GetNew(context);
         if ( subGridprofesionalrubros_rubros_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridprofesionalrubros_rubros_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridprofesionalrubros_rubros_Class, "") != 0 )
            {
               subGridprofesionalrubros_rubros_Linesclass = subGridprofesionalrubros_rubros_Class+"Odd";
            }
         }
         else if ( subGridprofesionalrubros_rubros_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridprofesionalrubros_rubros_Backstyle = 0;
            subGridprofesionalrubros_rubros_Backcolor = subGridprofesionalrubros_rubros_Allbackcolor;
            if ( StringUtil.StrCmp(subGridprofesionalrubros_rubros_Class, "") != 0 )
            {
               subGridprofesionalrubros_rubros_Linesclass = subGridprofesionalrubros_rubros_Class+"Uniform";
            }
         }
         else if ( subGridprofesionalrubros_rubros_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridprofesionalrubros_rubros_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridprofesionalrubros_rubros_Class, "") != 0 )
            {
               subGridprofesionalrubros_rubros_Linesclass = subGridprofesionalrubros_rubros_Class+"Odd";
            }
            subGridprofesionalrubros_rubros_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridprofesionalrubros_rubros_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridprofesionalrubros_rubros_Backstyle = 1;
            if ( ((int)((nGXsfl_24_idx) % (2))) == 0 )
            {
               subGridprofesionalrubros_rubros_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridprofesionalrubros_rubros_Class, "") != 0 )
               {
                  subGridprofesionalrubros_rubros_Linesclass = subGridprofesionalrubros_rubros_Class+"Even";
               }
            }
            else
            {
               subGridprofesionalrubros_rubros_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridprofesionalrubros_rubros_Class, "") != 0 )
               {
                  subGridprofesionalrubros_rubros_Linesclass = subGridprofesionalrubros_rubros_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Gridprofesionalrubros_rubrosContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridprofesionalrubros_rubros_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_24_idx+"\">") ;
         }
         imgprompt_121_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0110.aspx"+"',["+"{Ctrl:gx.dom.el('"+"RUBROSID_"+sGXsfl_24_idx+"'), id:'"+"RUBROSID_"+sGXsfl_24_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_35_"+sGXsfl_24_idx+","+"'', false"+","+"false"+");");
         GXAESTADOSPROFRUBID_html0V35( A124EstadosProfRubTipo) ;
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table_Internalname+"_"+sGXsfl_24_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTable1_Internalname+"_"+sGXsfl_24_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"LoginContainer",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,context.GetMessage( "Rubros Identificador ", ""),(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_35_" + sGXsfl_24_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_24_idx + "',24)\"";
         ROClassString = "Attribute";
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtRubrosId_Enabled,(short)1,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)24,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_121_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_121_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_121_Internalname,(string)sImgUrl,(string)imgprompt_121_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_121_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+edtRubrosImagen_Internalname+"\"",(string)"",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Static Bitmap Variable */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_35_" + sGXsfl_24_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_24_idx + "',24)\"";
         ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
         StyleString = "";
         A168RubrosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000RubrosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen));
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(int)edtRubrosImagen_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"",(string)"",(string)"",(short)0,(bool)A168RubrosImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
         AssignProp("", false, edtRubrosImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen)), !bGXsfl_24_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A168RubrosImagen_IsBlob), !bGXsfl_24_Refreshing);
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"end",(string)"Middle",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"start",(string)"top",(string)""+" data-gx-for=\""+dynEstadosProfRubId_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)dynEstadosProfRubId_Internalname,context.GetMessage( "Estados", ""),(string)"col-sm-3 AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_35_" + sGXsfl_24_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_24_idx + "',24)\"";
         if ( ( dynEstadosProfRubId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "ESTADOSPROFRUBID_" + sGXsfl_24_idx;
            dynEstadosProfRubId.Name = GXCCtl;
            dynEstadosProfRubId.WebTags = "";
         }
         /* ComboBox */
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynEstadosProfRubId,(string)dynEstadosProfRubId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A125EstadosProfRubId), 5, 0)),(short)1,(string)dynEstadosProfRubId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)1,dynEstadosProfRubId.Enabled,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"",(bool)true,(short)0});
         dynEstadosProfRubId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A125EstadosProfRubId), 5, 0));
         AssignProp("", false, dynEstadosProfRubId_Internalname, "Values", (string)(dynEstadosProfRubId.ToJavascriptSource()), !bGXsfl_24_Refreshing);
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"end",(string)"Middle",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         Gridprofesionalrubros_rubrosRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         context.httpAjaxContext.ajax_sending_grid_row(Gridprofesionalrubros_rubrosRow);
         send_integrity_lvl_hashes0V35( ) ;
         GXCCtl = "Z121RubrosId_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z124EstadosProfRubTipo_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z124EstadosProfRubTipo));
         GXCCtl = "Z125EstadosProfRubId_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125EstadosProfRubId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "ESTADOSPROFRUBTIPO_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( A124EstadosProfRubTipo));
         GXCCtl = "nRcdDeleted_35_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_35), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_35_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_35), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_35_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_35), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "PROFESIONALESID_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( A120ProfesionalesId));
         GXCCtl = "vMODE_" + sGXsfl_24_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "RUBROSIMAGEN_" + sGXsfl_24_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A168RubrosImagen);
         GxWebStd.gx_hidden_field( context, "RUBROSID_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RUBROSIMAGEN_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSPROFRUBID_"+sGXsfl_24_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadosProfRubId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_121_"+sGXsfl_24_idx+"Link", StringUtil.RTrim( imgprompt_121_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         /* End of Columns property logic. */
         Gridprofesionalrubros_rubrosContainer.AddRow(Gridprofesionalrubros_rubrosRow);
      }

      protected void ReadRow0V35( )
      {
         nGXsfl_24_idx = (int)(nGXsfl_24_idx+1);
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_2435( ) ;
         edtRubrosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_24_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtRubrosImagen_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSIMAGEN_"+sGXsfl_24_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynEstadosProfRubId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSPROFRUBID_"+sGXsfl_24_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_121_Link = cgiGet( "PROMPT_121_"+sGXsfl_24_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_24_idx;
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
         A168RubrosImagen = cgiGet( edtRubrosImagen_Internalname);
         dynEstadosProfRubId.Name = dynEstadosProfRubId_Internalname;
         dynEstadosProfRubId.CurrentValue = cgiGet( dynEstadosProfRubId_Internalname);
         A125EstadosProfRubId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynEstadosProfRubId_Internalname), "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z121RubrosId_" + sGXsfl_24_idx;
         Z121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z124EstadosProfRubTipo_" + sGXsfl_24_idx;
         Z124EstadosProfRubTipo = cgiGet( GXCCtl);
         GXCCtl = "Z125EstadosProfRubId_" + sGXsfl_24_idx;
         Z125EstadosProfRubId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z124EstadosProfRubTipo_" + sGXsfl_24_idx;
         A124EstadosProfRubTipo = cgiGet( GXCCtl);
         GXCCtl = "ESTADOSPROFRUBTIPO_" + sGXsfl_24_idx;
         A124EstadosProfRubTipo = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_35_" + sGXsfl_24_idx;
         nRcdDeleted_35 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_35_" + sGXsfl_24_idx;
         nRcdExists_35 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_35_" + sGXsfl_24_idx;
         nIsMod_35 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         getMultimediaValue(edtRubrosImagen_Internalname, ref  A168RubrosImagen, ref  A40000RubrosImagen_GXI);
      }

      protected void assign_properties_default( )
      {
         defedtRubrosId_Enabled = edtRubrosId_Enabled;
      }

      protected void ConfirmValues0V0( )
      {
         nGXsfl_24_idx = 0;
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_2435( ) ;
         while ( nGXsfl_24_idx < nRC_GXsfl_24 )
         {
            nGXsfl_24_idx = (int)(nGXsfl_24_idx+1);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_2435( ) ;
            ChangePostValue( "Z121RubrosId_"+sGXsfl_24_idx, cgiGet( "ZT_"+"Z121RubrosId_"+sGXsfl_24_idx)) ;
            DeletePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_24_idx) ;
            ChangePostValue( "Z124EstadosProfRubTipo_"+sGXsfl_24_idx, cgiGet( "ZT_"+"Z124EstadosProfRubTipo_"+sGXsfl_24_idx)) ;
            DeletePostValue( "ZT_"+"Z124EstadosProfRubTipo_"+sGXsfl_24_idx) ;
            ChangePostValue( "Z125EstadosProfRubId_"+sGXsfl_24_idx, cgiGet( "ZT_"+"Z125EstadosProfRubId_"+sGXsfl_24_idx)) ;
            DeletePostValue( "ZT_"+"Z125EstadosProfRubId_"+sGXsfl_24_idx) ;
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
         GXEncryptionTmp = "profesionalrubros.aspx"+UrlEncode(StringUtil.RTrim(A120ProfesionalesId)) + "," + UrlEncode(StringUtil.RTrim(Gx_mode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profesionalrubros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ProfesionalRubros");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("profesionalrubros:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z120ProfesionalesId", StringUtil.RTrim( Z120ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_24", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_24_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESID", StringUtil.RTrim( A120ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "ESTADOSPROFRUBTIPO", StringUtil.RTrim( A124EstadosProfRubTipo));
         GxWebStd.gx_hidden_field( context, "RUBROSNOMBRE", StringUtil.RTrim( A122RubrosNombre));
         GxWebStd.gx_hidden_field( context, "RUBROSIMAGEN_GXI", A40000RubrosImagen_GXI);
         GxWebStd.gx_hidden_field( context, "ESTADOSPROFRUBNOMB", StringUtil.RTrim( A221EstadosProfRubNomb));
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
         GXEncryptionTmp = "profesionalrubros.aspx"+UrlEncode(StringUtil.RTrim(A120ProfesionalesId)) + "," + UrlEncode(StringUtil.RTrim(Gx_mode));
         return formatLink("profesionalrubros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ProfesionalRubros" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Profesional Rubros", "") ;
      }

      protected void InitializeNonKey0V34( )
      {
      }

      protected void InitAll0V34( )
      {
         InitializeNonKey0V34( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0V35( )
      {
         A124EstadosProfRubTipo = "";
         AssignAttri("", false, "A124EstadosProfRubTipo", A124EstadosProfRubTipo);
         A125EstadosProfRubId = 0;
         A122RubrosNombre = "";
         AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
         A168RubrosImagen = "";
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_24_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A40000RubrosImagen_GXI = "";
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_24_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A221EstadosProfRubNomb = "";
         AssignAttri("", false, "A221EstadosProfRubNomb", A221EstadosProfRubNomb);
         Z124EstadosProfRubTipo = "";
         Z125EstadosProfRubId = 0;
      }

      protected void InitAll0V35( )
      {
         A121RubrosId = 0;
         InitializeNonKey0V35( ) ;
      }

      protected void StandaloneModalInsert0V35( )
      {
         A124EstadosProfRubTipo = i124EstadosProfRubTipo;
         AssignAttri("", false, "A124EstadosProfRubTipo", A124EstadosProfRubTipo);
         A125EstadosProfRubId = i125EstadosProfRubId;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932142111", true, true, false);
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
         context.AddJavascriptSource("profesionalrubros.js", "?2026932142112", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties35( )
      {
         edtRubrosId_Enabled = defedtRubrosId_Enabled;
         AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_24_Refreshing);
      }

      protected void StartGridControl24( )
      {
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("GridName", "Gridprofesionalrubros_rubros");
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Header", subGridprofesionalrubros_rubros_Header);
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Class", "FreeStyleGrid");
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionalrubros_rubros_Backcolorstyle), 1, 0, ".", "")));
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("CmpContext", "");
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("InMasterPage", "false");
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
         Gridprofesionalrubros_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", "")));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosColumn.AddObjectProperty("Value", context.convertURL( A168RubrosImagen));
         Gridprofesionalrubros_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Enabled), 5, 0, ".", "")));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A125EstadosProfRubId), 5, 0, ".", ""))));
         Gridprofesionalrubros_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadosProfRubId.Enabled), 5, 0, ".", "")));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridprofesionalrubros_rubrosContainer.AddColumnProperties(Gridprofesionalrubros_rubrosColumn);
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionalrubros_rubros_Selectedindex), 4, 0, ".", "")));
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionalrubros_rubros_Allowselection), 1, 0, ".", "")));
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionalrubros_rubros_Selectioncolor), 9, 0, ".", "")));
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionalrubros_rubros_Allowhovering), 1, 0, ".", "")));
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionalrubros_rubros_Hoveringcolor), 9, 0, ".", "")));
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionalrubros_rubros_Allowcollapsing), 1, 0, ".", "")));
         Gridprofesionalrubros_rubrosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridprofesionalrubros_rubros_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         lblTitle_Internalname = "TITLE";
         edtRubrosId_Internalname = "RUBROSID";
         edtRubrosImagen_Internalname = "RUBROSIMAGEN";
         dynEstadosProfRubId_Internalname = "ESTADOSPROFRUBID";
         divTable1_Internalname = "TABLE1";
         divGrid1table_Internalname = "GRID1TABLE";
         imgImage1_Internalname = "IMAGE1";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divRubrostable_Internalname = "RUBROSTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_121_Internalname = "PROMPT_121";
         subGridprofesionalrubros_rubros_Internalname = "GRIDPROFESIONALRUBROS_RUBROS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridprofesionalrubros_rubros_Allowcollapsing = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Profesional Rubros", "");
         dynEstadosProfRubId_Jsonclick = "";
         imgprompt_121_Visible = 1;
         imgprompt_121_Link = "";
         edtRubrosId_Jsonclick = "";
         subGridprofesionalrubros_rubros_Class = "FreeStyleGrid";
         subGridprofesionalrubros_rubros_Backcolorstyle = 0;
         dynEstadosProfRubId.Enabled = 1;
         edtRubrosImagen_Enabled = 0;
         edtRubrosId_Enabled = 1;
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

      protected void GXDLAESTADOSPROFRUBID0V35( string A124EstadosProfRubTipo )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAESTADOSPROFRUBID_data0V35( A124EstadosProfRubTipo) ;
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

      protected void GXAESTADOSPROFRUBID_html0V35( string A124EstadosProfRubTipo )
      {
         int gxdynajaxvalue;
         GXDLAESTADOSPROFRUBID_data0V35( A124EstadosProfRubTipo) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynEstadosProfRubId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynEstadosProfRubId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 5, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAESTADOSPROFRUBID_data0V35( string A124EstadosProfRubTipo )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000V34 */
         pr_default.execute(32);
         while ( (pr_default.getStatus(32) != 101) )
         {
            if ( StringUtil.StrCmp(A124EstadosProfRubTipo, context.GetMessage( "STS", "")) == 0 )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000V34_A125EstadosProfRubId[0]), 5, 0, ".", "")));
               gxdynajaxctrldescr.Add(StringUtil.RTrim( T000V34_A221EstadosProfRubNomb[0]));
            }
            pr_default.readNext(32);
         }
         pr_default.close(32);
      }

      protected void gxnrGridprofesionalrubros_rubros_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_2435( ) ;
         while ( nGXsfl_24_idx <= nRC_GXsfl_24 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0V35( ) ;
            standaloneModal0V35( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0V35( ) ;
            nGXsfl_24_idx = (int)(nGXsfl_24_idx+1);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_2435( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridprofesionalrubros_rubrosContainer)) ;
         /* End function gxnrGridprofesionalrubros_rubros_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "ESTADOSPROFRUBID_" + sGXsfl_24_idx;
         dynEstadosProfRubId.Name = GXCCtl;
         dynEstadosProfRubId.WebTags = "";
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
         A125EstadosProfRubId = (int)(Math.Round(NumberUtil.Val( dynEstadosProfRubId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000V35 */
         pr_default.execute(33, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(33) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
         }
         A122RubrosNombre = T000V35_A122RubrosNombre[0];
         A40000RubrosImagen_GXI = T000V35_A40000RubrosImagen_GXI[0];
         A168RubrosImagen = T000V35_A168RubrosImagen[0];
         pr_default.close(33);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A122RubrosNombre", StringUtil.RTrim( A122RubrosNombre));
         AssignAttri("", false, "A168RubrosImagen", context.PathToRelativeUrl( A168RubrosImagen));
         GXCCtl = "RUBROSIMAGEN_" + sGXsfl_24_idx;
         AssignAttri("", false, "GXCCtl", GXCCtl);
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A168RubrosImagen));
         AssignAttri("", false, "A40000RubrosImagen_GXI", A40000RubrosImagen_GXI);
      }

      public void Valid_Estadosprofrubid( )
      {
         A125EstadosProfRubId = (int)(Math.Round(NumberUtil.Val( dynEstadosProfRubId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000V36 */
         pr_default.execute(34, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
         if ( (pr_default.getStatus(34) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Prof Rub", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSPROFRUBID");
            AnyError = 1;
            GX_FocusControl = dynEstadosProfRubId_Internalname;
         }
         A221EstadosProfRubNomb = T000V36_A221EstadosProfRubNomb[0];
         pr_default.close(34);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A221EstadosProfRubNomb", StringUtil.RTrim( A221EstadosProfRubNomb));
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
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'A124EstadosProfRubTipo',fld:'ESTADOSPROFRUBTIPO',pic:'',type:'char'},{av:'dynEstadosProfRubId'},{av:'A125EstadosProfRubId',fld:'ESTADOSPROFRUBID',pic:'ZZZZ9',type:'int'},{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'A168RubrosImagen',fld:'RUBROSIMAGEN',pic:'',type:'bits'},{av:'A40000RubrosImagen_GXI',fld:'RUBROSIMAGEN_GXI',pic:'',type:'svchar'}]");
         setEventMetadata("VALID_RUBROSID",",oparms:[{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'A168RubrosImagen',fld:'RUBROSIMAGEN',pic:'',type:'bits'},{av:'A40000RubrosImagen_GXI',fld:'RUBROSIMAGEN_GXI',pic:'',type:'svchar'}]}");
         setEventMetadata("VALID_ESTADOSPROFRUBID","{handler:'Valid_Estadosprofrubid',iparms:[{av:'A124EstadosProfRubTipo',fld:'ESTADOSPROFRUBTIPO',pic:'',type:'char'},{av:'dynEstadosProfRubId'},{av:'A125EstadosProfRubId',fld:'ESTADOSPROFRUBID',pic:'ZZZZ9',type:'int'},{av:'A221EstadosProfRubNomb',fld:'ESTADOSPROFRUBNOMB',pic:'',type:'char'}]");
         setEventMetadata("VALID_ESTADOSPROFRUBID",",oparms:[{av:'A221EstadosProfRubNomb',fld:'ESTADOSPROFRUBNOMB',pic:'',type:'char'}]}");
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
         pr_default.close(29);
         pr_default.close(34);
         pr_default.close(30);
         pr_default.close(5);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOA120ProfesionalesId = "";
         wcpOGx_mode = "";
         Z120ProfesionalesId = "";
         Z124EstadosProfRubTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A124EstadosProfRubTipo = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         lblTextblock1_Jsonclick = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         imgImage1_gximage = "";
         sImgUrl = "";
         TempTags = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridprofesionalrubros_rubrosContainer = new GXWebGrid( context);
         sMode35 = "";
         GX_FocusControl = "";
         sStyleString = "";
         A122RubrosNombre = "";
         A40000RubrosImagen_GXI = "";
         A221EstadosProfRubNomb = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode34 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A168RubrosImagen = "";
         T000V8_A120ProfesionalesId = new string[] {""} ;
         T000V9_A120ProfesionalesId = new string[] {""} ;
         T000V7_A120ProfesionalesId = new string[] {""} ;
         T000V10_A120ProfesionalesId = new string[] {""} ;
         T000V11_A120ProfesionalesId = new string[] {""} ;
         T000V6_A120ProfesionalesId = new string[] {""} ;
         T000V14_A461CentroCostosId = new long[1] ;
         T000V14_A466CentroCostosDetallesId = new long[1] ;
         T000V15_A976ProfesionalesRestriccionId = new long[1] ;
         T000V16_A450ProfComisionesID = new long[1] ;
         T000V17_A127SolicitudesID = new long[1] ;
         T000V17_A140RelacionesId = new long[1] ;
         T000V18_A120ProfesionalesId = new string[] {""} ;
         T000V18_A993ProfesionalServicioId = new long[1] ;
         T000V19_A422PostulacionesId = new long[1] ;
         T000V19_A120ProfesionalesId = new string[] {""} ;
         T000V20_A590Listaid = new long[1] ;
         T000V20_A133ProveedorID = new long[1] ;
         T000V20_A120ProfesionalesId = new string[] {""} ;
         T000V21_A503ComisionesID = new long[1] ;
         T000V21_A120ProfesionalesId = new string[] {""} ;
         T000V22_A120ProfesionalesId = new string[] {""} ;
         T000V22_A126ProfesionalesZonasCorrelativo = new short[1] ;
         T000V23_A120ProfesionalesId = new string[] {""} ;
         Z122RubrosNombre = "";
         Z168RubrosImagen = "";
         Z40000RubrosImagen_GXI = "";
         Z221EstadosProfRubNomb = "";
         T000V5_A221EstadosProfRubNomb = new string[] {""} ;
         T000V24_A120ProfesionalesId = new string[] {""} ;
         T000V24_A122RubrosNombre = new string[] {""} ;
         T000V24_A40000RubrosImagen_GXI = new string[] {""} ;
         T000V24_A221EstadosProfRubNomb = new string[] {""} ;
         T000V24_A121RubrosId = new short[1] ;
         T000V24_A124EstadosProfRubTipo = new string[] {""} ;
         T000V24_A125EstadosProfRubId = new int[1] ;
         T000V24_A168RubrosImagen = new string[] {""} ;
         T000V4_A122RubrosNombre = new string[] {""} ;
         T000V4_A40000RubrosImagen_GXI = new string[] {""} ;
         T000V4_A168RubrosImagen = new string[] {""} ;
         T000V25_A122RubrosNombre = new string[] {""} ;
         T000V25_A40000RubrosImagen_GXI = new string[] {""} ;
         T000V25_A168RubrosImagen = new string[] {""} ;
         T000V26_A221EstadosProfRubNomb = new string[] {""} ;
         T000V27_A120ProfesionalesId = new string[] {""} ;
         T000V27_A121RubrosId = new short[1] ;
         T000V3_A120ProfesionalesId = new string[] {""} ;
         T000V3_A121RubrosId = new short[1] ;
         T000V3_A124EstadosProfRubTipo = new string[] {""} ;
         T000V3_A125EstadosProfRubId = new int[1] ;
         T000V2_A120ProfesionalesId = new string[] {""} ;
         T000V2_A121RubrosId = new short[1] ;
         T000V2_A124EstadosProfRubTipo = new string[] {""} ;
         T000V2_A125EstadosProfRubId = new int[1] ;
         T000V31_A122RubrosNombre = new string[] {""} ;
         T000V31_A40000RubrosImagen_GXI = new string[] {""} ;
         T000V31_A168RubrosImagen = new string[] {""} ;
         T000V32_A221EstadosProfRubNomb = new string[] {""} ;
         T000V33_A120ProfesionalesId = new string[] {""} ;
         T000V33_A121RubrosId = new short[1] ;
         Gridprofesionalrubros_rubrosRow = new GXWebRow();
         subGridprofesionalrubros_rubros_Linesclass = "";
         ROClassString = "";
         imgprompt_121_gximage = "";
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i124EstadosProfRubTipo = "";
         subGridprofesionalrubros_rubros_Header = "";
         Gridprofesionalrubros_rubrosColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000V34_A124EstadosProfRubTipo = new string[] {""} ;
         T000V34_A125EstadosProfRubId = new int[1] ;
         T000V34_A221EstadosProfRubNomb = new string[] {""} ;
         T000V35_A122RubrosNombre = new string[] {""} ;
         T000V35_A40000RubrosImagen_GXI = new string[] {""} ;
         T000V35_A168RubrosImagen = new string[] {""} ;
         T000V36_A221EstadosProfRubNomb = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.profesionalrubros__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalrubros__default(),
            new Object[][] {
                new Object[] {
               T000V2_A120ProfesionalesId, T000V2_A121RubrosId, T000V2_A124EstadosProfRubTipo, T000V2_A125EstadosProfRubId
               }
               , new Object[] {
               T000V3_A120ProfesionalesId, T000V3_A121RubrosId, T000V3_A124EstadosProfRubTipo, T000V3_A125EstadosProfRubId
               }
               , new Object[] {
               T000V4_A122RubrosNombre, T000V4_A40000RubrosImagen_GXI, T000V4_A168RubrosImagen
               }
               , new Object[] {
               T000V5_A221EstadosProfRubNomb
               }
               , new Object[] {
               T000V6_A120ProfesionalesId
               }
               , new Object[] {
               T000V7_A120ProfesionalesId
               }
               , new Object[] {
               T000V8_A120ProfesionalesId
               }
               , new Object[] {
               T000V9_A120ProfesionalesId
               }
               , new Object[] {
               T000V10_A120ProfesionalesId
               }
               , new Object[] {
               T000V11_A120ProfesionalesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000V14_A461CentroCostosId, T000V14_A466CentroCostosDetallesId
               }
               , new Object[] {
               T000V15_A976ProfesionalesRestriccionId
               }
               , new Object[] {
               T000V16_A450ProfComisionesID
               }
               , new Object[] {
               T000V17_A127SolicitudesID, T000V17_A140RelacionesId
               }
               , new Object[] {
               T000V18_A120ProfesionalesId, T000V18_A993ProfesionalServicioId
               }
               , new Object[] {
               T000V19_A422PostulacionesId, T000V19_A120ProfesionalesId
               }
               , new Object[] {
               T000V20_A590Listaid, T000V20_A133ProveedorID, T000V20_A120ProfesionalesId
               }
               , new Object[] {
               T000V21_A503ComisionesID, T000V21_A120ProfesionalesId
               }
               , new Object[] {
               T000V22_A120ProfesionalesId, T000V22_A126ProfesionalesZonasCorrelativo
               }
               , new Object[] {
               T000V23_A120ProfesionalesId
               }
               , new Object[] {
               T000V24_A120ProfesionalesId, T000V24_A122RubrosNombre, T000V24_A40000RubrosImagen_GXI, T000V24_A221EstadosProfRubNomb, T000V24_A121RubrosId, T000V24_A124EstadosProfRubTipo, T000V24_A125EstadosProfRubId, T000V24_A168RubrosImagen
               }
               , new Object[] {
               T000V25_A122RubrosNombre, T000V25_A40000RubrosImagen_GXI, T000V25_A168RubrosImagen
               }
               , new Object[] {
               T000V26_A221EstadosProfRubNomb
               }
               , new Object[] {
               T000V27_A120ProfesionalesId, T000V27_A121RubrosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000V31_A122RubrosNombre, T000V31_A40000RubrosImagen_GXI, T000V31_A168RubrosImagen
               }
               , new Object[] {
               T000V32_A221EstadosProfRubNomb
               }
               , new Object[] {
               T000V33_A120ProfesionalesId, T000V33_A121RubrosId
               }
               , new Object[] {
               T000V34_A124EstadosProfRubTipo, T000V34_A125EstadosProfRubId, T000V34_A221EstadosProfRubNomb
               }
               , new Object[] {
               T000V35_A122RubrosNombre, T000V35_A40000RubrosImagen_GXI, T000V35_A168RubrosImagen
               }
               , new Object[] {
               T000V36_A221EstadosProfRubNomb
               }
            }
         );
         Z120ProfesionalesId = "";
         A120ProfesionalesId = "";
      }

      private short nIsMod_35 ;
      private short Z121RubrosId ;
      private short nRcdDeleted_35 ;
      private short nRcdExists_35 ;
      private short GxWebError ;
      private short A121RubrosId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount35 ;
      private short RcdFound35 ;
      private short nBlankRcdUsr35 ;
      private short RcdFound34 ;
      private short Gx_BScreen ;
      private short nIsDirty_35 ;
      private short subGridprofesionalrubros_rubros_Backcolorstyle ;
      private short subGridprofesionalrubros_rubros_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridprofesionalrubros_rubros_Allowselection ;
      private short subGridprofesionalrubros_rubros_Allowhovering ;
      private short subGridprofesionalrubros_rubros_Allowcollapsing ;
      private short subGridprofesionalrubros_rubros_Collapsed ;
      private int nRC_GXsfl_24 ;
      private int nGXsfl_24_idx=1 ;
      private int Z125EstadosProfRubId ;
      private int A125EstadosProfRubId ;
      private int trnEnded ;
      private int imgImage1_Visible ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtRubrosId_Enabled ;
      private int edtRubrosImagen_Enabled ;
      private int fRowAdded ;
      private int subGridprofesionalrubros_rubros_Backcolor ;
      private int subGridprofesionalrubros_rubros_Allbackcolor ;
      private int imgprompt_121_Visible ;
      private int defedtRubrosId_Enabled ;
      private int i125EstadosProfRubId ;
      private int idxLst ;
      private int subGridprofesionalrubros_rubros_Selectedindex ;
      private int subGridprofesionalrubros_rubros_Selectioncolor ;
      private int subGridprofesionalrubros_rubros_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long GRIDPROFESIONALRUBROS_RUBROS_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_24_idx="0001" ;
      private string wcpOA120ProfesionalesId ;
      private string wcpOGx_mode ;
      private string Z120ProfesionalesId ;
      private string Z124EstadosProfRubTipo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A124EstadosProfRubTipo ;
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
      private string divRubrostable_Internalname ;
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
      private string sMode35 ;
      private string edtRubrosId_Internalname ;
      private string edtRubrosImagen_Internalname ;
      private string dynEstadosProfRubId_Internalname ;
      private string imgprompt_121_Link ;
      private string GX_FocusControl ;
      private string sStyleString ;
      private string subGridprofesionalrubros_rubros_Internalname ;
      private string A122RubrosNombre ;
      private string A221EstadosProfRubNomb ;
      private string hsh ;
      private string sMode34 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string Z122RubrosNombre ;
      private string Z221EstadosProfRubNomb ;
      private string imgprompt_121_Internalname ;
      private string sGXsfl_24_fel_idx="0001" ;
      private string subGridprofesionalrubros_rubros_Class ;
      private string subGridprofesionalrubros_rubros_Linesclass ;
      private string divGrid1table_Internalname ;
      private string divTable1_Internalname ;
      private string ROClassString ;
      private string edtRubrosId_Jsonclick ;
      private string imgprompt_121_gximage ;
      private string dynEstadosProfRubId_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string i124EstadosProfRubTipo ;
      private string subGridprofesionalrubros_rubros_Header ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_24_Refreshing=false ;
      private bool A168RubrosImagen_IsBlob ;
      private bool gxdyncontrolsrefreshing ;
      private string A40000RubrosImagen_GXI ;
      private string Z40000RubrosImagen_GXI ;
      private string A168RubrosImagen ;
      private string Z168RubrosImagen ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridprofesionalrubros_rubrosContainer ;
      private GXWebRow Gridprofesionalrubros_rubrosRow ;
      private GXWebColumn Gridprofesionalrubros_rubrosColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProfesionalesId ;
      private string aP1_Gx_mode ;
      private GXCombobox dynEstadosProfRubId ;
      private IDataStoreProvider pr_default ;
      private string[] T000V8_A120ProfesionalesId ;
      private string[] T000V9_A120ProfesionalesId ;
      private string[] T000V7_A120ProfesionalesId ;
      private string[] T000V10_A120ProfesionalesId ;
      private string[] T000V11_A120ProfesionalesId ;
      private string[] T000V6_A120ProfesionalesId ;
      private long[] T000V14_A461CentroCostosId ;
      private long[] T000V14_A466CentroCostosDetallesId ;
      private long[] T000V15_A976ProfesionalesRestriccionId ;
      private long[] T000V16_A450ProfComisionesID ;
      private long[] T000V17_A127SolicitudesID ;
      private long[] T000V17_A140RelacionesId ;
      private string[] T000V18_A120ProfesionalesId ;
      private long[] T000V18_A993ProfesionalServicioId ;
      private long[] T000V19_A422PostulacionesId ;
      private string[] T000V19_A120ProfesionalesId ;
      private long[] T000V20_A590Listaid ;
      private long[] T000V20_A133ProveedorID ;
      private string[] T000V20_A120ProfesionalesId ;
      private long[] T000V21_A503ComisionesID ;
      private string[] T000V21_A120ProfesionalesId ;
      private string[] T000V22_A120ProfesionalesId ;
      private short[] T000V22_A126ProfesionalesZonasCorrelativo ;
      private string[] T000V23_A120ProfesionalesId ;
      private string[] T000V5_A221EstadosProfRubNomb ;
      private string[] T000V24_A120ProfesionalesId ;
      private string[] T000V24_A122RubrosNombre ;
      private string[] T000V24_A40000RubrosImagen_GXI ;
      private string[] T000V24_A221EstadosProfRubNomb ;
      private short[] T000V24_A121RubrosId ;
      private string[] T000V24_A124EstadosProfRubTipo ;
      private int[] T000V24_A125EstadosProfRubId ;
      private string[] T000V24_A168RubrosImagen ;
      private string[] T000V4_A122RubrosNombre ;
      private string[] T000V4_A40000RubrosImagen_GXI ;
      private string[] T000V4_A168RubrosImagen ;
      private string[] T000V25_A122RubrosNombre ;
      private string[] T000V25_A40000RubrosImagen_GXI ;
      private string[] T000V25_A168RubrosImagen ;
      private string[] T000V26_A221EstadosProfRubNomb ;
      private string[] T000V27_A120ProfesionalesId ;
      private short[] T000V27_A121RubrosId ;
      private string[] T000V3_A120ProfesionalesId ;
      private short[] T000V3_A121RubrosId ;
      private string[] T000V3_A124EstadosProfRubTipo ;
      private int[] T000V3_A125EstadosProfRubId ;
      private string[] T000V2_A120ProfesionalesId ;
      private short[] T000V2_A121RubrosId ;
      private string[] T000V2_A124EstadosProfRubTipo ;
      private int[] T000V2_A125EstadosProfRubId ;
      private string[] T000V31_A122RubrosNombre ;
      private string[] T000V31_A40000RubrosImagen_GXI ;
      private string[] T000V31_A168RubrosImagen ;
      private string[] T000V32_A221EstadosProfRubNomb ;
      private string[] T000V33_A120ProfesionalesId ;
      private short[] T000V33_A121RubrosId ;
      private string[] T000V34_A124EstadosProfRubTipo ;
      private int[] T000V34_A125EstadosProfRubId ;
      private string[] T000V34_A221EstadosProfRubNomb ;
      private string[] T000V35_A122RubrosNombre ;
      private string[] T000V35_A40000RubrosImagen_GXI ;
      private string[] T000V35_A168RubrosImagen ;
      private string[] T000V36_A221EstadosProfRubNomb ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class profesionalrubros__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class profesionalrubros__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new UpdateCursor(def[27])
       ,new UpdateCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000V2;
        prmT000V2 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000V3;
        prmT000V3 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000V4;
        prmT000V4 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000V5;
        prmT000V5 = new Object[] {
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
        };
        Object[] prmT000V6;
        prmT000V6 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V7;
        prmT000V7 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V8;
        prmT000V8 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V9;
        prmT000V9 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V10;
        prmT000V10 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V11;
        prmT000V11 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V12;
        prmT000V12 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V13;
        prmT000V13 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V14;
        prmT000V14 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V15;
        prmT000V15 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V16;
        prmT000V16 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V17;
        prmT000V17 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V18;
        prmT000V18 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V19;
        prmT000V19 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V20;
        prmT000V20 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V21;
        prmT000V21 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V22;
        prmT000V22 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V23;
        prmT000V23 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V24;
        prmT000V24 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000V25;
        prmT000V25 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000V26;
        prmT000V26 = new Object[] {
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
        };
        Object[] prmT000V27;
        prmT000V27 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000V28;
        prmT000V28 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
        };
        Object[] prmT000V29;
        prmT000V29 = new Object[] {
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000V30;
        prmT000V30 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000V31;
        prmT000V31 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000V32;
        prmT000V32 = new Object[] {
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
        };
        Object[] prmT000V33;
        prmT000V33 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000V34;
        prmT000V34 = new Object[] {
        };
        Object[] prmT000V35;
        prmT000V35 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000V36;
        prmT000V36 = new Object[] {
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000V2", "SELECT [ProfesionalesId], [RubrosId], [EstadosProfRubTipo] AS EstadosProfRubTipo, [EstadosProfRubId] AS EstadosProfRubId FROM [ProfesionalesRubros] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V3", "SELECT [ProfesionalesId], [RubrosId], [EstadosProfRubTipo] AS EstadosProfRubTipo, [EstadosProfRubId] AS EstadosProfRubId FROM [ProfesionalesRubros] WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V4", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V4,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V5", "SELECT [EstadosGenericosNombre] AS EstadosProfRubNomb FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosProfRubTipo AND [EstadosGenericosId] = @EstadosProfRubId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V5,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V6", "SELECT [ProfesionalesId] FROM [Profesionales] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V7", "SELECT [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V8", "SELECT TM1.[ProfesionalesId] FROM [Profesionales] TM1 WHERE TM1.[ProfesionalesId] = @ProfesionalesId ORDER BY TM1.[ProfesionalesId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V9", "SELECT [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V10", "SELECT TOP 1 [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V11", "SELECT TOP 1 [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V12", "INSERT INTO [Profesionales]([ProfesionalesId], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesEmail], [ProfesionalesDireccion], [ProfesionalesVerDatPerSol], [ProfesionalesPerAltShop], [ProfesionalesAutoEnumerar], [ProfesionalesAutoEnuZona], [EstadosTipo], [EstadosGenericosId], [ProfesionalesFechaAlta], [ProfesionalesFechaActualizado], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [ProfesionalesLimitOSF], [ProfesionalesEsRUT], [ProfesionalesExperiencia], [ProfesionalesAceptoTerminos], [ProfesionalesDeclaroDatosV], [ProfesionalesCuentaBancaria], [BancoId], [ProfesionalesCapacidadProducti], [ProfesionalesFechaNacimiento], [ProfesionalesRUT], [ProfesionalesTipoEmpresa]) VALUES(@ProfesionalesId, '', '', '', '', CONVERT(varbinary(1), ''), '', '', '', '', '', '', convert(int, 0), convert(int, 0), '', convert(int, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(int, 0), convert(int, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', convert(int, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), '', convert(int, 0))", GxErrorMask.GX_NOMASK,prmT000V12)
           ,new CursorDef("T000V13", "DELETE FROM [Profesionales]  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT000V13)
           ,new CursorDef("T000V14", "SELECT TOP 1 [CentroCostosId], [CentroCostosDetallesId] FROM [CentroCostosDetalles] WHERE [CCDetallesProfId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V15", "SELECT TOP 1 [ProfesionalesRestriccionId] FROM [ProfesionalesRestriccion] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V16", "SELECT TOP 1 [ProfComisionesID] FROM [ProfComisiones] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V17", "SELECT TOP 1 [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V18", "SELECT TOP 1 [ProfesionalesId], [ProfesionalServicioId] FROM [ProfesionalesServicios] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V19", "SELECT TOP 1 [PostulacionesId], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V20", "SELECT TOP 1 [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V21", "SELECT TOP 1 [ComisionesID], [ProfesionalesId] FROM [ComisionesProfesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V22", "SELECT TOP 1 [ProfesionalesId], [ProfesionalesZonasCorrelativo] FROM [ProfesionalesZonas] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V23", "SELECT [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V23,100, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V24", "SELECT T1.[ProfesionalesId], T2.[RubrosNombre], T2.[RubrosImagen_GXI], T3.[EstadosGenericosNombre] AS EstadosProfRubNomb, T1.[RubrosId], T1.[EstadosProfRubTipo] AS EstadosProfRubTipo, T1.[EstadosProfRubId] AS EstadosProfRubId, T2.[RubrosImagen] FROM (([ProfesionalesRubros] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosProfRubTipo] AND T3.[EstadosGenericosId] = T1.[EstadosProfRubId]) WHERE T1.[ProfesionalesId] = @ProfesionalesId and T1.[RubrosId] = @RubrosId ORDER BY T1.[ProfesionalesId], T1.[RubrosId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V24,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V25", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V26", "SELECT [EstadosGenericosNombre] AS EstadosProfRubNomb FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosProfRubTipo AND [EstadosGenericosId] = @EstadosProfRubId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V27", "SELECT [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V28", "INSERT INTO [ProfesionalesRubros]([ProfesionalesId], [RubrosId], [EstadosProfRubTipo], [EstadosProfRubId]) VALUES(@ProfesionalesId, @RubrosId, @EstadosProfRubTipo, @EstadosProfRubId)", GxErrorMask.GX_NOMASK,prmT000V28)
           ,new CursorDef("T000V29", "UPDATE [ProfesionalesRubros] SET [EstadosProfRubTipo]=@EstadosProfRubTipo, [EstadosProfRubId]=@EstadosProfRubId  WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmT000V29)
           ,new CursorDef("T000V30", "DELETE FROM [ProfesionalesRubros]  WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmT000V30)
           ,new CursorDef("T000V31", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V32", "SELECT [EstadosGenericosNombre] AS EstadosProfRubNomb FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosProfRubTipo AND [EstadosGenericosId] = @EstadosProfRubId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V33", "SELECT [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId], [RubrosId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V33,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V34", "SELECT [EstadosTipo] AS EstadosProfRubTipo, [EstadosGenericosId] AS EstadosProfRubId, [EstadosGenericosNombre] AS EstadosProfRubNomb FROM [EstadosGenericos] ORDER BY [EstadosGenericosNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V34,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V35", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V36", "SELECT [EstadosGenericosNombre] AS EstadosProfRubNomb FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosProfRubTipo AND [EstadosGenericosId] = @EstadosProfRubId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V36,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 3);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
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
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
              return;
           case 34 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
     }
  }

}

}

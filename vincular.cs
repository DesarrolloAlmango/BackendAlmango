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
   public class vincular : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "vincular.aspx")), "vincular.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "vincular.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "ProveedorID");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV9ProveedorID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9ProveedorID", StringUtil.LTrimStr( (decimal)(AV9ProveedorID), 18, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11VincularTrnSolidicutd = (long)(Math.Round(NumberUtil.Val( GetPar( "VincularTrnSolidicutd"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11VincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(AV11VincularTrnSolidicutd), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vVINCULARTRNSOLIDICUTD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9"), context));
                  AV10VincularTrnNombreSol = GetPar( "VincularTrnNombreSol");
                  AssignAttri("", false, "AV10VincularTrnNombreSol", AV10VincularTrnNombreSol);
                  GxWebStd.gx_hidden_field( context, "gxhash_vVINCULARTRNNOMBRESOL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10VincularTrnNombreSol, "")), context));
                  AV12VincularTrnTelefonoSol = GetPar( "VincularTrnTelefonoSol");
                  AssignAttri("", false, "AV12VincularTrnTelefonoSol", AV12VincularTrnTelefonoSol);
                  GxWebStd.gx_hidden_field( context, "gxhash_vVINCULARTRNTELEFONOSOL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12VincularTrnTelefonoSol, "")), context));
                  AV7ProfesionalesId = GetPar( "ProfesionalesId");
                  AssignAttri("", false, "AV7ProfesionalesId", AV7ProfesionalesId);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ProfesionalesId, "")), context));
                  AV61SolicitudesMail = GetPar( "SolicitudesMail");
                  AssignAttri("", false, "AV61SolicitudesMail", AV61SolicitudesMail);
                  GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61SolicitudesMail, "")), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Vincular", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = imgVincularTrnImagen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public vincular( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public vincular( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID ,
                           long aP1_VincularTrnSolidicutd ,
                           string aP2_VincularTrnNombreSol ,
                           string aP3_VincularTrnTelefonoSol ,
                           string aP4_ProfesionalesId ,
                           string aP5_SolicitudesMail )
      {
         this.AV9ProveedorID = aP0_ProveedorID;
         this.AV11VincularTrnSolidicutd = aP1_VincularTrnSolidicutd;
         this.AV10VincularTrnNombreSol = aP2_VincularTrnNombreSol;
         this.AV12VincularTrnTelefonoSol = aP3_VincularTrnTelefonoSol;
         this.AV7ProfesionalesId = aP4_ProfesionalesId;
         this.AV61SolicitudesMail = aP5_SolicitudesMail;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Vincular", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Vincular.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVincularTrnId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVincularTrnId_Internalname, context.GetMessage( "Nro", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVincularTrnId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A491VincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtVincularTrnId_Enabled!=0) ? context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A491VincularTrnId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVincularTrnId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVincularTrnId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Vincular.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorID_Internalname, context.GetMessage( "Comercio", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProveedorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProveedorID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Vincular.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorNombre_Internalname, context.GetMessage( "Proveedor Nombre", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Vincular.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVincularTrnSolidicutd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVincularTrnSolidicutd_Internalname, context.GetMessage( "Solicitud", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVincularTrnSolidicutd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A492VincularTrnSolidicutd), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtVincularTrnSolidicutd_Enabled!=0) ? context.localUtil.Format( (decimal)(A492VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A492VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVincularTrnSolidicutd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVincularTrnSolidicutd_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Vincular.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVincularTrnNombreSol_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVincularTrnNombreSol_Internalname, context.GetMessage( "Nombre del Cliente", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVincularTrnNombreSol_Internalname, StringUtil.RTrim( A493VincularTrnNombreSol), StringUtil.RTrim( context.localUtil.Format( A493VincularTrnNombreSol, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVincularTrnNombreSol_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVincularTrnNombreSol_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Vincular.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVincularTrnTelefonoSol_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVincularTrnTelefonoSol_Internalname, context.GetMessage( "Teléfono del Cliente", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A494VincularTrnTelefonoSol);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVincularTrnTelefonoSol_Internalname, StringUtil.RTrim( A494VincularTrnTelefonoSol), StringUtil.RTrim( context.localUtil.Format( A494VincularTrnTelefonoSol, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtVincularTrnTelefonoSol_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVincularTrnTelefonoSol_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Vincular.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocumentacionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocumentacionId_Internalname, context.GetMessage( "Nombre del Documento", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentacionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtDocumentacionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentacionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocumentacionId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Vincular.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Icono", ""), "col-sm-3 ImageAttributeLabel", 0, true, "");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A498DocumentacionIcono_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001DocumentacionIcono_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.PathToRelativeUrl( A498DocumentacionIcono));
         GxWebStd.gx_bitmap( context, imgDocumentacionIcono_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgDocumentacionIcono_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", "", "", 0, A498DocumentacionIcono_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Vincular.htm");
         AssignProp("", false, imgDocumentacionIcono_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.PathToRelativeUrl( A498DocumentacionIcono)), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "IsBlob", StringUtil.BoolToStr( A498DocumentacionIcono_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgVincularTrnImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Fotografia", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A495VincularTrnImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000VincularTrnImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.PathToRelativeUrl( A495VincularTrnImagen));
         GxWebStd.gx_bitmap( context, imgVincularTrnImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgVincularTrnImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "", "", "", 0, A495VincularTrnImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Vincular.htm");
         AssignProp("", false, imgVincularTrnImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.PathToRelativeUrl( A495VincularTrnImagen)), true);
         AssignProp("", false, imgVincularTrnImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A495VincularTrnImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVincularTrnComentario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVincularTrnComentario_Internalname, context.GetMessage( "Comentario", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtVincularTrnComentario_Internalname, A497VincularTrnComentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", 0, 1, edtVincularTrnComentario_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Vincular.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVincularTrnFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVincularTrnFecha_Internalname, context.GetMessage( "Fecha", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVincularTrnFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVincularTrnFecha_Internalname, context.localUtil.Format(A496VincularTrnFecha, "99/99/99"), context.localUtil.Format( A496VincularTrnFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVincularTrnFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVincularTrnFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Vincular.htm");
         GxWebStd.gx_bitmap( context, edtVincularTrnFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVincularTrnFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Vincular.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttCancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vincular.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttEnter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vincular.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucToastr1.Render(context, "toastr", Toastr1_Internalname, "TOASTR1Container");
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
         E111U2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z491VincularTrnId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z491VincularTrnId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z492VincularTrnSolidicutd = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z492VincularTrnSolidicutd"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z493VincularTrnNombreSol = cgiGet( "Z493VincularTrnNombreSol");
               Z494VincularTrnTelefonoSol = cgiGet( "Z494VincularTrnTelefonoSol");
               Z496VincularTrnFecha = context.localUtil.CToD( cgiGet( "Z496VincularTrnFecha"), 0);
               Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV9ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV11VincularTrnSolidicutd = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vVINCULARTRNSOLIDICUTD"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV10VincularTrnNombreSol = cgiGet( "vVINCULARTRNNOMBRESOL");
               AV12VincularTrnTelefonoSol = cgiGet( "vVINCULARTRNTELEFONOSOL");
               A40000VincularTrnImagen_GXI = cgiGet( "VINCULARTRNIMAGEN_GXI");
               A40001DocumentacionIcono_GXI = cgiGet( "DOCUMENTACIONICONO_GXI");
               Toastr1_Objectcall = cgiGet( "TOASTR1_Objectcall");
               Toastr1_Class = cgiGet( "TOASTR1_Class");
               Toastr1_Enabled = StringUtil.StrToBool( cgiGet( "TOASTR1_Enabled"));
               Toastr1_Position = cgiGet( "TOASTR1_Position");
               Toastr1_Closebutton = StringUtil.StrToBool( cgiGet( "TOASTR1_Closebutton"));
               Toastr1_Progressbar = StringUtil.StrToBool( cgiGet( "TOASTR1_Progressbar"));
               Toastr1_Preventduplicate = StringUtil.StrToBool( cgiGet( "TOASTR1_Preventduplicate"));
               Toastr1_Newestontop = StringUtil.StrToBool( cgiGet( "TOASTR1_Newestontop"));
               Toastr1_Showeasing = cgiGet( "TOASTR1_Showeasing");
               Toastr1_Hideeasing = cgiGet( "TOASTR1_Hideeasing");
               Toastr1_Showmethod = cgiGet( "TOASTR1_Showmethod");
               Toastr1_Hidemethod = cgiGet( "TOASTR1_Hidemethod");
               Toastr1_Showduration = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TOASTR1_Showduration"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Toastr1_Hideduration = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TOASTR1_Hideduration"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Toastr1_Timeout = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TOASTR1_Timeout"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Toastr1_Extendedtimeout = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TOASTR1_Extendedtimeout"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Toastr1_Visible = StringUtil.StrToBool( cgiGet( "TOASTR1_Visible"));
               /* Read variables values. */
               A491VincularTrnId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVincularTrnId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
               AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
               A492VincularTrnSolidicutd = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVincularTrnSolidicutd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A492VincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(A492VincularTrnSolidicutd), 18, 0));
               A493VincularTrnNombreSol = cgiGet( edtVincularTrnNombreSol_Internalname);
               AssignAttri("", false, "A493VincularTrnNombreSol", A493VincularTrnNombreSol);
               A494VincularTrnTelefonoSol = cgiGet( edtVincularTrnTelefonoSol_Internalname);
               AssignAttri("", false, "A494VincularTrnTelefonoSol", A494VincularTrnTelefonoSol);
               A488DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDocumentacionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n488DocumentacionId = false;
               AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
               A498DocumentacionIcono = cgiGet( imgDocumentacionIcono_Internalname);
               AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
               A495VincularTrnImagen = cgiGet( imgVincularTrnImagen_Internalname);
               AssignAttri("", false, "A495VincularTrnImagen", A495VincularTrnImagen);
               A497VincularTrnComentario = cgiGet( edtVincularTrnComentario_Internalname);
               AssignAttri("", false, "A497VincularTrnComentario", A497VincularTrnComentario);
               A496VincularTrnFecha = context.localUtil.CToD( cgiGet( edtVincularTrnFecha_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgDocumentacionIcono_Internalname, ref  A498DocumentacionIcono, ref  A40001DocumentacionIcono_GXI);
               getMultimediaValue(imgVincularTrnImagen_Internalname, ref  A495VincularTrnImagen, ref  A40000VincularTrnImagen_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Vincular");
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               forbiddenHiddens.Add("ProveedorID", context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
               A492VincularTrnSolidicutd = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVincularTrnSolidicutd_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A492VincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(A492VincularTrnSolidicutd), 18, 0));
               forbiddenHiddens.Add("VincularTrnSolidicutd", context.localUtil.Format( (decimal)(A492VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9"));
               A493VincularTrnNombreSol = cgiGet( edtVincularTrnNombreSol_Internalname);
               AssignAttri("", false, "A493VincularTrnNombreSol", A493VincularTrnNombreSol);
               forbiddenHiddens.Add("VincularTrnNombreSol", StringUtil.RTrim( context.localUtil.Format( A493VincularTrnNombreSol, "")));
               A494VincularTrnTelefonoSol = cgiGet( edtVincularTrnTelefonoSol_Internalname);
               AssignAttri("", false, "A494VincularTrnTelefonoSol", A494VincularTrnTelefonoSol);
               forbiddenHiddens.Add("VincularTrnTelefonoSol", StringUtil.RTrim( context.localUtil.Format( A494VincularTrnTelefonoSol, "")));
               A496VincularTrnFecha = context.localUtil.CToD( cgiGet( edtVincularTrnFecha_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
               forbiddenHiddens.Add("VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A491VincularTrnId != Z491VincularTrnId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("vincular:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A491VincularTrnId = (long)(Math.Round(NumberUtil.Val( GetPar( "VincularTrnId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons_dsp( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal( ) ;
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
                           E111U2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121U2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            E121U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1U73( ) ;
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
      }

      protected void disable_std_buttons_dsp( )
      {
         if ( IsDsp( ) )
         {
            bttEnter_Visible = 0;
            AssignProp("", false, bttEnter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnter_Visible), 5, 0), true);
         }
         DisableAttributes1U73( ) ;
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

      protected void ResetCaption1U0( )
      {
      }

      protected void E111U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new loadcontext(context ).execute( out  AV19context) ;
      }

      protected void E121U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV48NuevoEstadoId = 6;
         AssignAttri("", false, "AV48NuevoEstadoId", StringUtil.LTrimStr( (decimal)(AV48NuevoEstadoId), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vNUEVOESTADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48NuevoEstadoId), "ZZZZZZZZZZZZZZZZZ9"), context));
         AV49NuevoEstadoNomb = context.GetMessage( "Finalizada", "");
         AssignAttri("", false, "AV49NuevoEstadoNomb", AV49NuevoEstadoNomb);
         GxWebStd.gx_hidden_field( context, "gxhash_vNUEVOESTADONOMB", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49NuevoEstadoNomb, "")), context));
         AV60SolicitudesID = AV11VincularTrnSolidicutd;
         AssignAttri("", false, "AV60SolicitudesID", StringUtil.LTrimStr( (decimal)(AV60SolicitudesID), 18, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV60SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         AV62SolicitudesNombre = AV10VincularTrnNombreSol;
         AssignAttri("", false, "AV62SolicitudesNombre", AV62SolicitudesNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESNOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV62SolicitudesNombre, "")), context));
         /* Execute user subroutine: 'CARGARSDTNOTI' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new cambstssolicitudes(context ).execute(  AV11VincularTrnSolidicutd,  6,  AV7ProfesionalesId,  AV8SDTCNotificaciones,  AV75UsuariosId, out  AV15CambioSTSOK) ;
         if ( StringUtil.StrCmp(AV15CambioSTSOK, context.GetMessage( "S", "")) == 0 )
         {
            AV66Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV60SolicitudesID), 10, 0));
            this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"success",context.GetMessage( "Trabajo Finalizado.", ""),(string)AV66Titulo});
         }
         else
         {
            AV66Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV60SolicitudesID), 10, 0));
            this.executeUsercontrolMethod("", false, "TOASTR1Container", "Msg", "", new Object[] {(string)"success",context.GetMessage( "No fue posible procesar la solicitud, intente más tarde.", ""),(string)AV66Titulo});
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8SDTCNotificaciones", AV8SDTCNotificaciones);
      }

      protected void S112( )
      {
         /* 'CARGARSDTNOTI' Routine */
         returnInSub = false;
         AV8SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV8SDTCNotificaciones.gxTpr_Solicitudesid = AV60SolicitudesID;
         AV8SDTCNotificaciones.gxTpr_Maildesignid = 2;
         AV8SDTCNotificaciones.gxTpr_Estadosgenericosid = (int)(AV48NuevoEstadoId);
         AV8SDTCNotificaciones.gxTpr_Nuevoestado = AV49NuevoEstadoNomb;
         AV8SDTCNotificaciones.gxTpr_Emailcliente = AV61SolicitudesMail;
         AV8SDTCNotificaciones.gxTpr_Nombrecliente = AV62SolicitudesNombre;
         AV8SDTCNotificaciones.gxTpr_Emailprofesional = AV19context.gxTpr_Usuarioscorreo;
         AV8SDTCNotificaciones.gxTpr_Nombreprofesional = StringUtil.Trim( AV19context.gxTpr_Usuariosnombre);
         new omailsetting(context ).execute(  1, out  AV45MailDireccion, out  AV44MailCuentaNombre) ;
         AV8SDTCNotificaciones.gxTpr_Emailoperador = AV45MailDireccion;
         AV8SDTCNotificaciones.gxTpr_Nombreoperador = AV44MailCuentaNombre;
      }

      protected void ZM1U73( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z492VincularTrnSolidicutd = T001U3_A492VincularTrnSolidicutd[0];
               Z493VincularTrnNombreSol = T001U3_A493VincularTrnNombreSol[0];
               Z494VincularTrnTelefonoSol = T001U3_A494VincularTrnTelefonoSol[0];
               Z496VincularTrnFecha = T001U3_A496VincularTrnFecha[0];
               Z133ProveedorID = T001U3_A133ProveedorID[0];
            }
            else
            {
               Z492VincularTrnSolidicutd = A492VincularTrnSolidicutd;
               Z493VincularTrnNombreSol = A493VincularTrnNombreSol;
               Z494VincularTrnTelefonoSol = A494VincularTrnTelefonoSol;
               Z496VincularTrnFecha = A496VincularTrnFecha;
               Z133ProveedorID = A133ProveedorID;
            }
         }
         if ( GX_JID == -13 )
         {
            Z491VincularTrnId = A491VincularTrnId;
            Z492VincularTrnSolidicutd = A492VincularTrnSolidicutd;
            Z493VincularTrnNombreSol = A493VincularTrnNombreSol;
            Z494VincularTrnTelefonoSol = A494VincularTrnTelefonoSol;
            Z496VincularTrnFecha = A496VincularTrnFecha;
            Z495VincularTrnImagen = A495VincularTrnImagen;
            Z497VincularTrnComentario = A497VincularTrnComentario;
            Z40000VincularTrnImagen_GXI = A40000VincularTrnImagen_GXI;
            Z133ProveedorID = A133ProveedorID;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z488DocumentacionId = A488DocumentacionId;
            Z498DocumentacionIcono = A498DocumentacionIcono;
            Z40001DocumentacionIcono_GXI = A40001DocumentacionIcono_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtVincularTrnSolidicutd_Enabled = 0;
         AssignProp("", false, edtVincularTrnSolidicutd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnSolidicutd_Enabled), 5, 0), true);
         edtVincularTrnNombreSol_Enabled = 0;
         AssignProp("", false, edtVincularTrnNombreSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnNombreSol_Enabled), 5, 0), true);
         edtVincularTrnTelefonoSol_Enabled = 0;
         AssignProp("", false, edtVincularTrnTelefonoSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnTelefonoSol_Enabled), 5, 0), true);
         edtVincularTrnFecha_Enabled = 0;
         AssignProp("", false, edtVincularTrnFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnFecha_Enabled), 5, 0), true);
         edtVincularTrnId_Enabled = 0;
         AssignProp("", false, edtVincularTrnId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnId_Enabled), 5, 0), true);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtVincularTrnSolidicutd_Enabled = 0;
         AssignProp("", false, edtVincularTrnSolidicutd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnSolidicutd_Enabled), 5, 0), true);
         edtVincularTrnNombreSol_Enabled = 0;
         AssignProp("", false, edtVincularTrnNombreSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnNombreSol_Enabled), 5, 0), true);
         edtVincularTrnTelefonoSol_Enabled = 0;
         AssignProp("", false, edtVincularTrnTelefonoSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnTelefonoSol_Enabled), 5, 0), true);
         edtVincularTrnFecha_Enabled = 0;
         AssignProp("", false, edtVincularTrnFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnFecha_Enabled), 5, 0), true);
         edtVincularTrnId_Enabled = 0;
         AssignProp("", false, edtVincularTrnId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnId_Enabled), 5, 0), true);
      }

      protected void standaloneModal( )
      {
         A496VincularTrnFecha = DateTimeUtil.Today( context);
         AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
         A494VincularTrnTelefonoSol = AV12VincularTrnTelefonoSol;
         AssignAttri("", false, "A494VincularTrnTelefonoSol", A494VincularTrnTelefonoSol);
         A493VincularTrnNombreSol = AV10VincularTrnNombreSol;
         AssignAttri("", false, "A493VincularTrnNombreSol", A493VincularTrnNombreSol);
         A492VincularTrnSolidicutd = AV11VincularTrnSolidicutd;
         AssignAttri("", false, "A492VincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(A492VincularTrnSolidicutd), 18, 0));
         A133ProveedorID = AV9ProveedorID;
         AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         /* Using cursor T001U4 */
         pr_default.execute(2, new Object[] {A133ProveedorID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Proveedor", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORID");
            AnyError = 1;
         }
         A282ProveedorNombre = T001U4_A282ProveedorNombre[0];
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A488DocumentacionId = T001U4_A488DocumentacionId[0];
         n488DocumentacionId = T001U4_n488DocumentacionId[0];
         AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
         pr_default.close(2);
         /* Using cursor T001U5 */
         pr_default.execute(3, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A488DocumentacionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Documentacion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DOCUMENTACIONID");
               AnyError = 1;
            }
         }
         A40001DocumentacionIcono_GXI = T001U5_A40001DocumentacionIcono_GXI[0];
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         A498DocumentacionIcono = T001U5_A498DocumentacionIcono[0];
         AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         pr_default.close(3);
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttEnter_Enabled = 0;
            AssignProp("", false, bttEnter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnter_Enabled), 5, 0), true);
         }
         else
         {
            bttEnter_Enabled = 1;
            AssignProp("", false, bttEnter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnter_Enabled), 5, 0), true);
         }
      }

      protected void Load1U73( )
      {
         /* Using cursor T001U6 */
         pr_default.execute(4, new Object[] {A491VincularTrnId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound73 = 1;
            A492VincularTrnSolidicutd = T001U6_A492VincularTrnSolidicutd[0];
            AssignAttri("", false, "A492VincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(A492VincularTrnSolidicutd), 18, 0));
            A493VincularTrnNombreSol = T001U6_A493VincularTrnNombreSol[0];
            AssignAttri("", false, "A493VincularTrnNombreSol", A493VincularTrnNombreSol);
            A494VincularTrnTelefonoSol = T001U6_A494VincularTrnTelefonoSol[0];
            AssignAttri("", false, "A494VincularTrnTelefonoSol", A494VincularTrnTelefonoSol);
            A496VincularTrnFecha = T001U6_A496VincularTrnFecha[0];
            AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
            A282ProveedorNombre = T001U6_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A40001DocumentacionIcono_GXI = T001U6_A40001DocumentacionIcono_GXI[0];
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A497VincularTrnComentario = T001U6_A497VincularTrnComentario[0];
            AssignAttri("", false, "A497VincularTrnComentario", A497VincularTrnComentario);
            A40000VincularTrnImagen_GXI = T001U6_A40000VincularTrnImagen_GXI[0];
            AssignProp("", false, imgVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), true);
            AssignProp("", false, imgVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
            A133ProveedorID = T001U6_A133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            A488DocumentacionId = T001U6_A488DocumentacionId[0];
            n488DocumentacionId = T001U6_n488DocumentacionId[0];
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
            A498DocumentacionIcono = T001U6_A498DocumentacionIcono[0];
            AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A495VincularTrnImagen = T001U6_A495VincularTrnImagen[0];
            AssignAttri("", false, "A495VincularTrnImagen", A495VincularTrnImagen);
            AssignProp("", false, imgVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), true);
            AssignProp("", false, imgVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
            ZM1U73( -13) ;
         }
         pr_default.close(4);
         OnLoadActions1U73( ) ;
      }

      protected void OnLoadActions1U73( )
      {
      }

      protected void CheckExtendedTable1U73( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1U73( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1U73( )
      {
         /* Using cursor T001U7 */
         pr_default.execute(5, new Object[] {A491VincularTrnId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound73 = 1;
         }
         else
         {
            RcdFound73 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001U3 */
         pr_default.execute(1, new Object[] {A491VincularTrnId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1U73( 13) ;
            RcdFound73 = 1;
            A491VincularTrnId = T001U3_A491VincularTrnId[0];
            AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
            A492VincularTrnSolidicutd = T001U3_A492VincularTrnSolidicutd[0];
            AssignAttri("", false, "A492VincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(A492VincularTrnSolidicutd), 18, 0));
            A493VincularTrnNombreSol = T001U3_A493VincularTrnNombreSol[0];
            AssignAttri("", false, "A493VincularTrnNombreSol", A493VincularTrnNombreSol);
            A494VincularTrnTelefonoSol = T001U3_A494VincularTrnTelefonoSol[0];
            AssignAttri("", false, "A494VincularTrnTelefonoSol", A494VincularTrnTelefonoSol);
            A496VincularTrnFecha = T001U3_A496VincularTrnFecha[0];
            AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
            A497VincularTrnComentario = T001U3_A497VincularTrnComentario[0];
            AssignAttri("", false, "A497VincularTrnComentario", A497VincularTrnComentario);
            A40000VincularTrnImagen_GXI = T001U3_A40000VincularTrnImagen_GXI[0];
            AssignProp("", false, imgVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), true);
            AssignProp("", false, imgVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
            A133ProveedorID = T001U3_A133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            A495VincularTrnImagen = T001U3_A495VincularTrnImagen[0];
            AssignAttri("", false, "A495VincularTrnImagen", A495VincularTrnImagen);
            AssignProp("", false, imgVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), true);
            AssignProp("", false, imgVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
            Z491VincularTrnId = A491VincularTrnId;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1U73( ) ;
            if ( AnyError == 1 )
            {
               RcdFound73 = 0;
               InitializeNonKey1U73( ) ;
            }
            Gx_mode = sMode73;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound73 = 0;
            InitializeNonKey1U73( ) ;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode73;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1U73( ) ;
         if ( RcdFound73 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound73 = 0;
         /* Using cursor T001U8 */
         pr_default.execute(6, new Object[] {A491VincularTrnId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T001U8_A491VincularTrnId[0] < A491VincularTrnId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T001U8_A491VincularTrnId[0] > A491VincularTrnId ) ) )
            {
               A491VincularTrnId = T001U8_A491VincularTrnId[0];
               AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
               RcdFound73 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound73 = 0;
         /* Using cursor T001U9 */
         pr_default.execute(7, new Object[] {A491VincularTrnId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T001U9_A491VincularTrnId[0] > A491VincularTrnId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T001U9_A491VincularTrnId[0] < A491VincularTrnId ) ) )
            {
               A491VincularTrnId = T001U9_A491VincularTrnId[0];
               AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
               RcdFound73 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1U73( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = imgVincularTrnImagen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1U73( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound73 == 1 )
            {
               if ( A491VincularTrnId != Z491VincularTrnId )
               {
                  A491VincularTrnId = Z491VincularTrnId;
                  AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VINCULARTRNID");
                  AnyError = 1;
                  GX_FocusControl = edtVincularTrnId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = imgVincularTrnImagen_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1U73( ) ;
                  GX_FocusControl = imgVincularTrnImagen_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A491VincularTrnId != Z491VincularTrnId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = imgVincularTrnImagen_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1U73( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VINCULARTRNID");
                     AnyError = 1;
                     GX_FocusControl = edtVincularTrnId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = imgVincularTrnImagen_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1U73( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( A491VincularTrnId != Z491VincularTrnId )
         {
            A491VincularTrnId = Z491VincularTrnId;
            AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VINCULARTRNID");
            AnyError = 1;
            GX_FocusControl = edtVincularTrnId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = imgVincularTrnImagen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "VINCULARTRNID");
            AnyError = 1;
            GX_FocusControl = edtVincularTrnId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = imgVincularTrnImagen_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1U73( ) ;
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgVincularTrnImagen_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1U73( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgVincularTrnImagen_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgVincularTrnImagen_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1U73( ) ;
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound73 != 0 )
            {
               ScanNext1U73( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgVincularTrnImagen_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1U73( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1U73( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001U2 */
            pr_default.execute(0, new Object[] {A491VincularTrnId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"VincularTrn"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z492VincularTrnSolidicutd != T001U2_A492VincularTrnSolidicutd[0] ) || ( StringUtil.StrCmp(Z493VincularTrnNombreSol, T001U2_A493VincularTrnNombreSol[0]) != 0 ) || ( StringUtil.StrCmp(Z494VincularTrnTelefonoSol, T001U2_A494VincularTrnTelefonoSol[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z496VincularTrnFecha ) != DateTimeUtil.ResetTime ( T001U2_A496VincularTrnFecha[0] ) ) || ( Z133ProveedorID != T001U2_A133ProveedorID[0] ) )
            {
               if ( Z492VincularTrnSolidicutd != T001U2_A492VincularTrnSolidicutd[0] )
               {
                  GXUtil.WriteLog("vincular:[seudo value changed for attri]"+"VincularTrnSolidicutd");
                  GXUtil.WriteLogRaw("Old: ",Z492VincularTrnSolidicutd);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A492VincularTrnSolidicutd[0]);
               }
               if ( StringUtil.StrCmp(Z493VincularTrnNombreSol, T001U2_A493VincularTrnNombreSol[0]) != 0 )
               {
                  GXUtil.WriteLog("vincular:[seudo value changed for attri]"+"VincularTrnNombreSol");
                  GXUtil.WriteLogRaw("Old: ",Z493VincularTrnNombreSol);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A493VincularTrnNombreSol[0]);
               }
               if ( StringUtil.StrCmp(Z494VincularTrnTelefonoSol, T001U2_A494VincularTrnTelefonoSol[0]) != 0 )
               {
                  GXUtil.WriteLog("vincular:[seudo value changed for attri]"+"VincularTrnTelefonoSol");
                  GXUtil.WriteLogRaw("Old: ",Z494VincularTrnTelefonoSol);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A494VincularTrnTelefonoSol[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z496VincularTrnFecha ) != DateTimeUtil.ResetTime ( T001U2_A496VincularTrnFecha[0] ) )
               {
                  GXUtil.WriteLog("vincular:[seudo value changed for attri]"+"VincularTrnFecha");
                  GXUtil.WriteLogRaw("Old: ",Z496VincularTrnFecha);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A496VincularTrnFecha[0]);
               }
               if ( Z133ProveedorID != T001U2_A133ProveedorID[0] )
               {
                  GXUtil.WriteLog("vincular:[seudo value changed for attri]"+"ProveedorID");
                  GXUtil.WriteLogRaw("Old: ",Z133ProveedorID);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A133ProveedorID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"VincularTrn"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1U73( )
      {
         BeforeValidate1U73( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U73( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1U73( 0) ;
            CheckOptimisticConcurrency1U73( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U73( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1U73( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001U10 */
                     pr_default.execute(8, new Object[] {A492VincularTrnSolidicutd, A493VincularTrnNombreSol, A494VincularTrnTelefonoSol, A496VincularTrnFecha, A495VincularTrnImagen, A497VincularTrnComentario, A40000VincularTrnImagen_GXI, A133ProveedorID});
                     A491VincularTrnId = T001U10_A491VincularTrnId[0];
                     AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("VincularTrn");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1U0( ) ;
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
               Load1U73( ) ;
            }
            EndLevel1U73( ) ;
         }
         CloseExtendedTableCursors1U73( ) ;
      }

      protected void Update1U73( )
      {
         BeforeValidate1U73( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U73( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U73( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U73( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1U73( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001U11 */
                     pr_default.execute(9, new Object[] {A492VincularTrnSolidicutd, A493VincularTrnNombreSol, A494VincularTrnTelefonoSol, A496VincularTrnFecha, A497VincularTrnComentario, A133ProveedorID, A491VincularTrnId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("VincularTrn");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"VincularTrn"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1U73( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1U0( ) ;
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
            EndLevel1U73( ) ;
         }
         CloseExtendedTableCursors1U73( ) ;
      }

      protected void DeferredUpdate1U73( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001U12 */
            pr_default.execute(10, new Object[] {A495VincularTrnImagen, A40000VincularTrnImagen_GXI, A491VincularTrnId});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("VincularTrn");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1U73( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U73( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1U73( ) ;
            AfterConfirm1U73( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1U73( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001U13 */
                  pr_default.execute(11, new Object[] {A491VincularTrnId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("VincularTrn");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound73 == 0 )
                        {
                           InitAll1U73( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption1U0( ) ;
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
         sMode73 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1U73( ) ;
         Gx_mode = sMode73;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1U73( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1U73( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1U73( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("vincular",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("vincular",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1U73( )
      {
         /* Scan By routine */
         /* Using cursor T001U14 */
         pr_default.execute(12);
         RcdFound73 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound73 = 1;
            A491VincularTrnId = T001U14_A491VincularTrnId[0];
            AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1U73( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound73 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound73 = 1;
            A491VincularTrnId = T001U14_A491VincularTrnId[0];
            AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
         }
      }

      protected void ScanEnd1U73( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1U73( )
      {
         /* After Confirm Rules */
         if ( ( String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) && String.IsNullOrEmpty(StringUtil.RTrim( A40000VincularTrnImagen_GXI)) ) && true /* After */ )
         {
            GX_msglist.addItem(context.GetMessage( "Error, debe ingresar una imagen de la documentación requerida", ""), 1, "VINCULARTRNIMAGEN");
            AnyError = 1;
            GX_FocusControl = imgVincularTrnImagen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            return  ;
         }
      }

      protected void BeforeInsert1U73( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1U73( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1U73( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1U73( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1U73( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1U73( )
      {
         edtVincularTrnId_Enabled = 0;
         AssignProp("", false, edtVincularTrnId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnId_Enabled), 5, 0), true);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         edtVincularTrnSolidicutd_Enabled = 0;
         AssignProp("", false, edtVincularTrnSolidicutd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnSolidicutd_Enabled), 5, 0), true);
         edtVincularTrnNombreSol_Enabled = 0;
         AssignProp("", false, edtVincularTrnNombreSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnNombreSol_Enabled), 5, 0), true);
         edtVincularTrnTelefonoSol_Enabled = 0;
         AssignProp("", false, edtVincularTrnTelefonoSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnTelefonoSol_Enabled), 5, 0), true);
         edtDocumentacionId_Enabled = 0;
         AssignProp("", false, edtDocumentacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentacionId_Enabled), 5, 0), true);
         imgDocumentacionIcono_Enabled = 0;
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgDocumentacionIcono_Enabled), 5, 0), true);
         imgVincularTrnImagen_Enabled = 0;
         AssignProp("", false, imgVincularTrnImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgVincularTrnImagen_Enabled), 5, 0), true);
         edtVincularTrnComentario_Enabled = 0;
         AssignProp("", false, edtVincularTrnComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnComentario_Enabled), 5, 0), true);
         edtVincularTrnFecha_Enabled = 0;
         AssignProp("", false, edtVincularTrnFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVincularTrnFecha_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1U73( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1U0( )
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
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
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
         GXEncryptionTmp = "vincular.aspx"+UrlEncode(StringUtil.LTrimStr(AV9ProveedorID,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV11VincularTrnSolidicutd,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV10VincularTrnNombreSol)) + "," + UrlEncode(StringUtil.RTrim(AV12VincularTrnTelefonoSol)) + "," + UrlEncode(StringUtil.RTrim(AV7ProfesionalesId)) + "," + UrlEncode(StringUtil.RTrim(AV61SolicitudesMail));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("vincular.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Vincular");
         forbiddenHiddens.Add("ProveedorID", context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("VincularTrnSolidicutd", context.localUtil.Format( (decimal)(A492VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("VincularTrnNombreSol", StringUtil.RTrim( context.localUtil.Format( A493VincularTrnNombreSol, "")));
         forbiddenHiddens.Add("VincularTrnTelefonoSol", StringUtil.RTrim( context.localUtil.Format( A494VincularTrnTelefonoSol, "")));
         forbiddenHiddens.Add("VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("vincular:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z491VincularTrnId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z491VincularTrnId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z492VincularTrnSolidicutd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z492VincularTrnSolidicutd), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z493VincularTrnNombreSol", StringUtil.RTrim( Z493VincularTrnNombreSol));
         GxWebStd.gx_hidden_field( context, "Z494VincularTrnTelefonoSol", StringUtil.RTrim( Z494VincularTrnTelefonoSol));
         GxWebStd.gx_hidden_field( context, "Z496VincularTrnFecha", context.localUtil.DToC( Z496VincularTrnFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV7ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ProfesionalesId, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTCNOTIFICACIONES", AV8SDTCNotificaciones);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTCNOTIFICACIONES", AV8SDTCNotificaciones);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTCNOTIFICACIONES", GetSecureSignedToken( "", AV8SDTCNotificaciones, context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSID", StringUtil.RTrim( AV75UsuariosId));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOSID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV75UsuariosId, "")), context));
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV60SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNUEVOESTADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48NuevoEstadoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNUEVOESTADOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV48NuevoEstadoId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNUEVOESTADONOMB", StringUtil.RTrim( AV49NuevoEstadoNomb));
         GxWebStd.gx_hidden_field( context, "gxhash_vNUEVOESTADONOMB", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49NuevoEstadoNomb, "")), context));
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESMAIL", AV61SolicitudesMail);
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV61SolicitudesMail, "")), context));
         GxWebStd.gx_hidden_field( context, "vSOLICITUDESNOMBRE", StringUtil.RTrim( AV62SolicitudesNombre));
         GxWebStd.gx_hidden_field( context, "gxhash_vSOLICITUDESNOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV62SolicitudesNombre, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTEXT", AV19context);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTEXT", AV19context);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vCONTEXT", GetSecureSignedToken( "", AV19context, context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vVINCULARTRNSOLIDICUTD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11VincularTrnSolidicutd), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vVINCULARTRNSOLIDICUTD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11VincularTrnSolidicutd), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vVINCULARTRNNOMBRESOL", StringUtil.RTrim( AV10VincularTrnNombreSol));
         GxWebStd.gx_hidden_field( context, "gxhash_vVINCULARTRNNOMBRESOL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10VincularTrnNombreSol, "")), context));
         GxWebStd.gx_hidden_field( context, "vVINCULARTRNTELEFONOSOL", StringUtil.RTrim( AV12VincularTrnTelefonoSol));
         GxWebStd.gx_hidden_field( context, "gxhash_vVINCULARTRNTELEFONOSOL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV12VincularTrnTelefonoSol, "")), context));
         GxWebStd.gx_hidden_field( context, "VINCULARTRNIMAGEN_GXI", A40000VincularTrnImagen_GXI);
         GxWebStd.gx_hidden_field( context, "DOCUMENTACIONICONO_GXI", A40001DocumentacionIcono_GXI);
         GXCCtlgxBlob = "DOCUMENTACIONICONO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A498DocumentacionIcono);
         GXCCtlgxBlob = "VINCULARTRNIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A495VincularTrnImagen);
         GxWebStd.gx_hidden_field( context, "TOASTR1_Objectcall", StringUtil.RTrim( Toastr1_Objectcall));
         GxWebStd.gx_hidden_field( context, "TOASTR1_Enabled", StringUtil.BoolToStr( Toastr1_Enabled));
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
         GXEncryptionTmp = "vincular.aspx"+UrlEncode(StringUtil.LTrimStr(AV9ProveedorID,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV11VincularTrnSolidicutd,18,0)) + "," + UrlEncode(StringUtil.RTrim(AV10VincularTrnNombreSol)) + "," + UrlEncode(StringUtil.RTrim(AV12VincularTrnTelefonoSol)) + "," + UrlEncode(StringUtil.RTrim(AV7ProfesionalesId)) + "," + UrlEncode(StringUtil.RTrim(AV61SolicitudesMail));
         return formatLink("vincular.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Vincular" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Vincular", "") ;
      }

      protected void InitializeNonKey1U73( )
      {
         A133ProveedorID = 0;
         AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         A492VincularTrnSolidicutd = 0;
         AssignAttri("", false, "A492VincularTrnSolidicutd", StringUtil.LTrimStr( (decimal)(A492VincularTrnSolidicutd), 18, 0));
         A493VincularTrnNombreSol = "";
         AssignAttri("", false, "A493VincularTrnNombreSol", A493VincularTrnNombreSol);
         A494VincularTrnTelefonoSol = "";
         AssignAttri("", false, "A494VincularTrnTelefonoSol", A494VincularTrnTelefonoSol);
         A496VincularTrnFecha = DateTime.MinValue;
         AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
         A282ProveedorNombre = "";
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A488DocumentacionId = 0;
         n488DocumentacionId = false;
         AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
         A498DocumentacionIcono = "";
         AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         A40001DocumentacionIcono_GXI = "";
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         A495VincularTrnImagen = "";
         AssignAttri("", false, "A495VincularTrnImagen", A495VincularTrnImagen);
         AssignProp("", false, imgVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), true);
         AssignProp("", false, imgVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
         A497VincularTrnComentario = "";
         AssignAttri("", false, "A497VincularTrnComentario", A497VincularTrnComentario);
         A40000VincularTrnImagen_GXI = "";
         AssignProp("", false, imgVincularTrnImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A495VincularTrnImagen)) ? A40000VincularTrnImagen_GXI : context.convertURL( context.PathToRelativeUrl( A495VincularTrnImagen))), true);
         AssignProp("", false, imgVincularTrnImagen_Internalname, "SrcSet", context.GetImageSrcSet( A495VincularTrnImagen), true);
         Z492VincularTrnSolidicutd = 0;
         Z493VincularTrnNombreSol = "";
         Z494VincularTrnTelefonoSol = "";
         Z496VincularTrnFecha = DateTime.MinValue;
         Z133ProveedorID = 0;
      }

      protected void InitAll1U73( )
      {
         A491VincularTrnId = 0;
         AssignAttri("", false, "A491VincularTrnId", StringUtil.LTrimStr( (decimal)(A491VincularTrnId), 18, 0));
         InitializeNonKey1U73( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A496VincularTrnFecha = i496VincularTrnFecha;
         AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("Toastr/toastr.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932073179", true, true, false);
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
         context.AddJavascriptSource("vincular.js", "?2026932073180", false, true, false);
         context.AddJavascriptSource("Toastr/toastr.min.js", "", false, true, false);
         context.AddJavascriptSource("Toastr/ToastrRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         edtVincularTrnId_Internalname = "VINCULARTRNID";
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         edtVincularTrnSolidicutd_Internalname = "VINCULARTRNSOLIDICUTD";
         edtVincularTrnNombreSol_Internalname = "VINCULARTRNNOMBRESOL";
         edtVincularTrnTelefonoSol_Internalname = "VINCULARTRNTELEFONOSOL";
         edtDocumentacionId_Internalname = "DOCUMENTACIONID";
         imgDocumentacionIcono_Internalname = "DOCUMENTACIONICONO";
         imgVincularTrnImagen_Internalname = "VINCULARTRNIMAGEN";
         edtVincularTrnComentario_Internalname = "VINCULARTRNCOMENTARIO";
         edtVincularTrnFecha_Internalname = "VINCULARTRNFECHA";
         bttCancel_Internalname = "CANCEL";
         bttEnter_Internalname = "ENTER";
         divTable1_Internalname = "TABLE1";
         Toastr1_Internalname = "TOASTR1";
         divFormcontainer_Internalname = "FORMCONTAINER";
         divMaintable_Internalname = "MAINTABLE";
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
         Form.Caption = context.GetMessage( "Vincular", "");
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         bttCancel_Visible = 1;
         edtVincularTrnFecha_Jsonclick = "";
         edtVincularTrnFecha_Enabled = 0;
         edtVincularTrnComentario_Enabled = 1;
         imgVincularTrnImagen_Enabled = 1;
         imgDocumentacionIcono_Enabled = 0;
         edtDocumentacionId_Jsonclick = "";
         edtDocumentacionId_Enabled = 0;
         edtVincularTrnTelefonoSol_Jsonclick = "";
         edtVincularTrnTelefonoSol_Enabled = 0;
         edtVincularTrnNombreSol_Jsonclick = "";
         edtVincularTrnNombreSol_Enabled = 0;
         edtVincularTrnSolidicutd_Jsonclick = "";
         edtVincularTrnSolidicutd_Enabled = 0;
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Jsonclick = "";
         edtProveedorID_Enabled = 0;
         edtVincularTrnId_Jsonclick = "";
         edtVincularTrnId_Enabled = 0;
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

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = imgVincularTrnImagen_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Vinculartrnid( )
      {
         n488DocumentacionId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", "")));
         AssignAttri("", false, "A492VincularTrnSolidicutd", StringUtil.LTrim( StringUtil.NToC( (decimal)(A492VincularTrnSolidicutd), 18, 0, ".", "")));
         AssignAttri("", false, "A493VincularTrnNombreSol", StringUtil.RTrim( A493VincularTrnNombreSol));
         AssignAttri("", false, "A494VincularTrnTelefonoSol", StringUtil.RTrim( A494VincularTrnTelefonoSol));
         AssignAttri("", false, "A496VincularTrnFecha", context.localUtil.Format(A496VincularTrnFecha, "99/99/99"));
         AssignAttri("", false, "A282ProveedorNombre", StringUtil.RTrim( A282ProveedorNombre));
         AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, ".", "")));
         AssignAttri("", false, "A498DocumentacionIcono", context.PathToRelativeUrl( A498DocumentacionIcono));
         GXCCtlgxBlob = "DOCUMENTACIONICONO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A498DocumentacionIcono));
         AssignAttri("", false, "A40001DocumentacionIcono_GXI", A40001DocumentacionIcono_GXI);
         AssignAttri("", false, "A495VincularTrnImagen", context.PathToRelativeUrl( A495VincularTrnImagen));
         GXCCtlgxBlob = "VINCULARTRNIMAGEN" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A495VincularTrnImagen));
         AssignAttri("", false, "A497VincularTrnComentario", A497VincularTrnComentario);
         AssignAttri("", false, "A40000VincularTrnImagen_GXI", A40000VincularTrnImagen_GXI);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z491VincularTrnId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z491VincularTrnId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z492VincularTrnSolidicutd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z492VincularTrnSolidicutd), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z493VincularTrnNombreSol", StringUtil.RTrim( Z493VincularTrnNombreSol));
         GxWebStd.gx_hidden_field( context, "Z494VincularTrnTelefonoSol", StringUtil.RTrim( Z494VincularTrnTelefonoSol));
         GxWebStd.gx_hidden_field( context, "Z496VincularTrnFecha", context.localUtil.Format(Z496VincularTrnFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z282ProveedorNombre", StringUtil.RTrim( Z282ProveedorNombre));
         GxWebStd.gx_hidden_field( context, "Z488DocumentacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z488DocumentacionId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z498DocumentacionIcono", context.PathToRelativeUrl( Z498DocumentacionIcono));
         GxWebStd.gx_hidden_field( context, "Z40001DocumentacionIcono_GXI", Z40001DocumentacionIcono_GXI);
         GxWebStd.gx_hidden_field( context, "Z495VincularTrnImagen", context.PathToRelativeUrl( Z495VincularTrnImagen));
         GxWebStd.gx_hidden_field( context, "Z497VincularTrnComentario", Z497VincularTrnComentario);
         GxWebStd.gx_hidden_field( context, "Z40000VincularTrnImagen_GXI", Z40000VincularTrnImagen_GXI);
         AssignProp("", false, bttEnter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'AV9ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV11VincularTrnSolidicutd',fld:'vVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV10VincularTrnNombreSol',fld:'vVINCULARTRNNOMBRESOL',pic:'',hsh:true,type:'char'},{av:'AV12VincularTrnTelefonoSol',fld:'vVINCULARTRNTELEFONOSOL',pic:'',hsh:true,type:'char'},{av:'AV7ProfesionalesId',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'AV61SolicitudesMail',fld:'vSOLICITUDESMAIL',pic:'',hsh:true,type:'svchar'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV7ProfesionalesId',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'AV8SDTCNotificaciones',fld:'vSDTCNOTIFICACIONES',pic:'',hsh:true},{av:'AV75UsuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'AV60SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV48NuevoEstadoId',fld:'vNUEVOESTADOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV49NuevoEstadoNomb',fld:'vNUEVOESTADONOMB',pic:'',hsh:true,type:'char'},{av:'AV61SolicitudesMail',fld:'vSOLICITUDESMAIL',pic:'',hsh:true,type:'svchar'},{av:'AV62SolicitudesNombre',fld:'vSOLICITUDESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV19context',fld:'vCONTEXT',pic:'',hsh:true},{av:'AV9ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV11VincularTrnSolidicutd',fld:'vVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV10VincularTrnNombreSol',fld:'vVINCULARTRNNOMBRESOL',pic:'',hsh:true,type:'char'},{av:'AV12VincularTrnTelefonoSol',fld:'vVINCULARTRNTELEFONOSOL',pic:'',hsh:true,type:'char'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A492VincularTrnSolidicutd',fld:'VINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A493VincularTrnNombreSol',fld:'VINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'A494VincularTrnTelefonoSol',fld:'VINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'A496VincularTrnFecha',fld:'VINCULARTRNFECHA',pic:'',type:'date'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E121U2',iparms:[{av:'AV11VincularTrnSolidicutd',fld:'vVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV10VincularTrnNombreSol',fld:'vVINCULARTRNNOMBRESOL',pic:'',hsh:true,type:'char'},{av:'AV7ProfesionalesId',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'AV8SDTCNotificaciones',fld:'vSDTCNOTIFICACIONES',pic:'',hsh:true},{av:'AV75UsuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'AV60SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV48NuevoEstadoId',fld:'vNUEVOESTADOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV49NuevoEstadoNomb',fld:'vNUEVOESTADONOMB',pic:'',hsh:true,type:'char'},{av:'AV61SolicitudesMail',fld:'vSOLICITUDESMAIL',pic:'',hsh:true,type:'svchar'},{av:'AV62SolicitudesNombre',fld:'vSOLICITUDESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV19context',fld:'vCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV48NuevoEstadoId',fld:'vNUEVOESTADOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV49NuevoEstadoNomb',fld:'vNUEVOESTADONOMB',pic:'',hsh:true,type:'char'},{av:'AV60SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV62SolicitudesNombre',fld:'vSOLICITUDESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV8SDTCNotificaciones',fld:'vSDTCNOTIFICACIONES',pic:'',hsh:true}]}");
         setEventMetadata("VALID_VINCULARTRNID","{handler:'Valid_Vinculartrnid',iparms:[{av:'AV19context',fld:'vCONTEXT',pic:'',hsh:true},{av:'AV62SolicitudesNombre',fld:'vSOLICITUDESNOMBRE',pic:'',hsh:true,type:'char'},{av:'AV49NuevoEstadoNomb',fld:'vNUEVOESTADONOMB',pic:'',hsh:true,type:'char'},{av:'AV48NuevoEstadoId',fld:'vNUEVOESTADOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV60SolicitudesID',fld:'vSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV75UsuariosId',fld:'vUSUARIOSID',pic:'',hsh:true,type:'char'},{av:'AV8SDTCNotificaciones',fld:'vSDTCNOTIFICACIONES',pic:'',hsh:true},{av:'AV61SolicitudesMail',fld:'vSOLICITUDESMAIL',pic:'',hsh:true,type:'svchar'},{av:'AV7ProfesionalesId',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A491VincularTrnId',fld:'VINCULARTRNID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV12VincularTrnTelefonoSol',fld:'vVINCULARTRNTELEFONOSOL',pic:'',hsh:true,type:'char'},{av:'AV10VincularTrnNombreSol',fld:'vVINCULARTRNNOMBRESOL',pic:'',hsh:true,type:'char'},{av:'AV11VincularTrnSolidicutd',fld:'vVINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV9ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A488DocumentacionId',fld:'DOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'A496VincularTrnFecha',fld:'VINCULARTRNFECHA',pic:'',type:'date'},{av:'A494VincularTrnTelefonoSol',fld:'VINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'A493VincularTrnNombreSol',fld:'VINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'A492VincularTrnSolidicutd',fld:'VINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_VINCULARTRNID",",oparms:[{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A492VincularTrnSolidicutd',fld:'VINCULARTRNSOLIDICUTD',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A493VincularTrnNombreSol',fld:'VINCULARTRNNOMBRESOL',pic:'',type:'char'},{av:'A494VincularTrnTelefonoSol',fld:'VINCULARTRNTELEFONOSOL',pic:'',type:'char'},{av:'A496VincularTrnFecha',fld:'VINCULARTRNFECHA',pic:'',type:'date'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'A488DocumentacionId',fld:'DOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A498DocumentacionIcono',fld:'DOCUMENTACIONICONO',pic:'',type:'bits'},{av:'A40001DocumentacionIcono_GXI',fld:'DOCUMENTACIONICONO_GXI',pic:'',type:'svchar'},{av:'A495VincularTrnImagen',fld:'VINCULARTRNIMAGEN',pic:'',type:'bits'},{av:'A497VincularTrnComentario',fld:'VINCULARTRNCOMENTARIO',pic:'',type:'vchar'},{av:'A40000VincularTrnImagen_GXI',fld:'VINCULARTRNIMAGEN_GXI',pic:'',type:'svchar'},{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'Z491VincularTrnId',type:'int'},{av:'Z133ProveedorID',type:'int'},{av:'Z492VincularTrnSolidicutd',type:'int'},{av:'Z493VincularTrnNombreSol',type:'char'},{av:'Z494VincularTrnTelefonoSol',type:'char'},{av:'Z496VincularTrnFecha',type:'date'},{av:'Z282ProveedorNombre',type:'char'},{av:'Z488DocumentacionId',type:'int'},{av:'Z498DocumentacionIcono',type:'bits'},{av:'Z40001DocumentacionIcono_GXI',type:'svchar'},{av:'Z495VincularTrnImagen',type:'bits'},{av:'Z497VincularTrnComentario',type:'vchar'},{av:'Z40000VincularTrnImagen_GXI',type:'svchar'},{ctrl:'ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_DOCUMENTACIONID","{handler:'Valid_Documentacionid',iparms:[]");
         setEventMetadata("VALID_DOCUMENTACIONID",",oparms:[]}");
         setEventMetadata("VALID_VINCULARTRNIMAGEN","{handler:'Valid_Vinculartrnimagen',iparms:[]");
         setEventMetadata("VALID_VINCULARTRNIMAGEN",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOAV10VincularTrnNombreSol = "";
         wcpOAV12VincularTrnTelefonoSol = "";
         wcpOAV7ProfesionalesId = "";
         wcpOAV61SolicitudesMail = "";
         Z493VincularTrnNombreSol = "";
         Z494VincularTrnTelefonoSol = "";
         Z496VincularTrnFecha = DateTime.MinValue;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A282ProveedorNombre = "";
         A493VincularTrnNombreSol = "";
         gxphoneLink = "";
         A494VincularTrnTelefonoSol = "";
         A498DocumentacionIcono = "";
         A40001DocumentacionIcono_GXI = "";
         sImgUrl = "";
         A495VincularTrnImagen = "";
         A40000VincularTrnImagen_GXI = "";
         A497VincularTrnComentario = "";
         A496VincularTrnFecha = DateTime.MinValue;
         bttCancel_Jsonclick = "";
         bttEnter_Jsonclick = "";
         ucToastr1 = new GXUserControl();
         Gx_mode = "";
         Toastr1_Objectcall = "";
         Toastr1_Class = "";
         Toastr1_Position = "";
         Toastr1_Showeasing = "";
         Toastr1_Hideeasing = "";
         Toastr1_Showmethod = "";
         Toastr1_Hidemethod = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV19context = new SdtContext(context);
         AV49NuevoEstadoNomb = "";
         AV62SolicitudesNombre = "";
         AV8SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV75UsuariosId = "";
         AV15CambioSTSOK = "";
         AV66Titulo = "";
         AV45MailDireccion = "";
         AV44MailCuentaNombre = "";
         Z495VincularTrnImagen = "";
         Z497VincularTrnComentario = "";
         Z40000VincularTrnImagen_GXI = "";
         Z282ProveedorNombre = "";
         Z498DocumentacionIcono = "";
         Z40001DocumentacionIcono_GXI = "";
         T001U4_A282ProveedorNombre = new string[] {""} ;
         T001U4_A488DocumentacionId = new long[1] ;
         T001U4_n488DocumentacionId = new bool[] {false} ;
         T001U5_A40001DocumentacionIcono_GXI = new string[] {""} ;
         T001U5_A498DocumentacionIcono = new string[] {""} ;
         T001U6_A491VincularTrnId = new long[1] ;
         T001U6_A492VincularTrnSolidicutd = new long[1] ;
         T001U6_A493VincularTrnNombreSol = new string[] {""} ;
         T001U6_A494VincularTrnTelefonoSol = new string[] {""} ;
         T001U6_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         T001U6_A282ProveedorNombre = new string[] {""} ;
         T001U6_A40001DocumentacionIcono_GXI = new string[] {""} ;
         T001U6_A497VincularTrnComentario = new string[] {""} ;
         T001U6_A40000VincularTrnImagen_GXI = new string[] {""} ;
         T001U6_A133ProveedorID = new long[1] ;
         T001U6_A488DocumentacionId = new long[1] ;
         T001U6_n488DocumentacionId = new bool[] {false} ;
         T001U6_A498DocumentacionIcono = new string[] {""} ;
         T001U6_A495VincularTrnImagen = new string[] {""} ;
         T001U7_A491VincularTrnId = new long[1] ;
         T001U3_A491VincularTrnId = new long[1] ;
         T001U3_A492VincularTrnSolidicutd = new long[1] ;
         T001U3_A493VincularTrnNombreSol = new string[] {""} ;
         T001U3_A494VincularTrnTelefonoSol = new string[] {""} ;
         T001U3_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         T001U3_A497VincularTrnComentario = new string[] {""} ;
         T001U3_A40000VincularTrnImagen_GXI = new string[] {""} ;
         T001U3_A133ProveedorID = new long[1] ;
         T001U3_A495VincularTrnImagen = new string[] {""} ;
         sMode73 = "";
         T001U8_A491VincularTrnId = new long[1] ;
         T001U9_A491VincularTrnId = new long[1] ;
         T001U2_A491VincularTrnId = new long[1] ;
         T001U2_A492VincularTrnSolidicutd = new long[1] ;
         T001U2_A493VincularTrnNombreSol = new string[] {""} ;
         T001U2_A494VincularTrnTelefonoSol = new string[] {""} ;
         T001U2_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         T001U2_A497VincularTrnComentario = new string[] {""} ;
         T001U2_A40000VincularTrnImagen_GXI = new string[] {""} ;
         T001U2_A133ProveedorID = new long[1] ;
         T001U2_A495VincularTrnImagen = new string[] {""} ;
         T001U10_A491VincularTrnId = new long[1] ;
         T001U14_A491VincularTrnId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         i496VincularTrnFecha = DateTime.MinValue;
         ZZ493VincularTrnNombreSol = "";
         ZZ494VincularTrnTelefonoSol = "";
         ZZ496VincularTrnFecha = DateTime.MinValue;
         ZZ282ProveedorNombre = "";
         ZZ498DocumentacionIcono = "";
         ZZ40001DocumentacionIcono_GXI = "";
         ZZ495VincularTrnImagen = "";
         ZZ497VincularTrnComentario = "";
         ZZ40000VincularTrnImagen_GXI = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.vincular__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.vincular__default(),
            new Object[][] {
                new Object[] {
               T001U2_A491VincularTrnId, T001U2_A492VincularTrnSolidicutd, T001U2_A493VincularTrnNombreSol, T001U2_A494VincularTrnTelefonoSol, T001U2_A496VincularTrnFecha, T001U2_A497VincularTrnComentario, T001U2_A40000VincularTrnImagen_GXI, T001U2_A133ProveedorID, T001U2_A495VincularTrnImagen
               }
               , new Object[] {
               T001U3_A491VincularTrnId, T001U3_A492VincularTrnSolidicutd, T001U3_A493VincularTrnNombreSol, T001U3_A494VincularTrnTelefonoSol, T001U3_A496VincularTrnFecha, T001U3_A497VincularTrnComentario, T001U3_A40000VincularTrnImagen_GXI, T001U3_A133ProveedorID, T001U3_A495VincularTrnImagen
               }
               , new Object[] {
               T001U4_A282ProveedorNombre, T001U4_A488DocumentacionId, T001U4_n488DocumentacionId
               }
               , new Object[] {
               T001U5_A40001DocumentacionIcono_GXI, T001U5_A498DocumentacionIcono
               }
               , new Object[] {
               T001U6_A491VincularTrnId, T001U6_A492VincularTrnSolidicutd, T001U6_A493VincularTrnNombreSol, T001U6_A494VincularTrnTelefonoSol, T001U6_A496VincularTrnFecha, T001U6_A282ProveedorNombre, T001U6_A40001DocumentacionIcono_GXI, T001U6_A497VincularTrnComentario, T001U6_A40000VincularTrnImagen_GXI, T001U6_A133ProveedorID,
               T001U6_A488DocumentacionId, T001U6_n488DocumentacionId, T001U6_A498DocumentacionIcono, T001U6_A495VincularTrnImagen
               }
               , new Object[] {
               T001U7_A491VincularTrnId
               }
               , new Object[] {
               T001U8_A491VincularTrnId
               }
               , new Object[] {
               T001U9_A491VincularTrnId
               }
               , new Object[] {
               T001U10_A491VincularTrnId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001U14_A491VincularTrnId
               }
            }
         );
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound73 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtVincularTrnId_Enabled ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtVincularTrnSolidicutd_Enabled ;
      private int edtVincularTrnNombreSol_Enabled ;
      private int edtVincularTrnTelefonoSol_Enabled ;
      private int edtDocumentacionId_Enabled ;
      private int imgDocumentacionIcono_Enabled ;
      private int imgVincularTrnImagen_Enabled ;
      private int edtVincularTrnComentario_Enabled ;
      private int edtVincularTrnFecha_Enabled ;
      private int bttCancel_Visible ;
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int Toastr1_Showduration ;
      private int Toastr1_Hideduration ;
      private int Toastr1_Timeout ;
      private int Toastr1_Extendedtimeout ;
      private int idxLst ;
      private long wcpOAV9ProveedorID ;
      private long wcpOAV11VincularTrnSolidicutd ;
      private long Z491VincularTrnId ;
      private long Z492VincularTrnSolidicutd ;
      private long Z133ProveedorID ;
      private long AV9ProveedorID ;
      private long AV11VincularTrnSolidicutd ;
      private long A491VincularTrnId ;
      private long A133ProveedorID ;
      private long A492VincularTrnSolidicutd ;
      private long A488DocumentacionId ;
      private long AV48NuevoEstadoId ;
      private long AV60SolicitudesID ;
      private long Z488DocumentacionId ;
      private long ZZ491VincularTrnId ;
      private long ZZ133ProveedorID ;
      private long ZZ492VincularTrnSolidicutd ;
      private long ZZ488DocumentacionId ;
      private string sPrefix ;
      private string wcpOAV10VincularTrnNombreSol ;
      private string wcpOAV12VincularTrnTelefonoSol ;
      private string wcpOAV7ProfesionalesId ;
      private string Z493VincularTrnNombreSol ;
      private string Z494VincularTrnTelefonoSol ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string AV10VincularTrnNombreSol ;
      private string AV12VincularTrnTelefonoSol ;
      private string AV7ProfesionalesId ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string imgVincularTrnImagen_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string edtVincularTrnId_Internalname ;
      private string TempTags ;
      private string edtVincularTrnId_Jsonclick ;
      private string edtProveedorID_Internalname ;
      private string edtProveedorID_Jsonclick ;
      private string edtProveedorNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtVincularTrnSolidicutd_Internalname ;
      private string edtVincularTrnSolidicutd_Jsonclick ;
      private string edtVincularTrnNombreSol_Internalname ;
      private string A493VincularTrnNombreSol ;
      private string edtVincularTrnNombreSol_Jsonclick ;
      private string edtVincularTrnTelefonoSol_Internalname ;
      private string gxphoneLink ;
      private string A494VincularTrnTelefonoSol ;
      private string edtVincularTrnTelefonoSol_Jsonclick ;
      private string edtDocumentacionId_Internalname ;
      private string edtDocumentacionId_Jsonclick ;
      private string sImgUrl ;
      private string imgDocumentacionIcono_Internalname ;
      private string edtVincularTrnComentario_Internalname ;
      private string edtVincularTrnFecha_Internalname ;
      private string edtVincularTrnFecha_Jsonclick ;
      private string divTable1_Internalname ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string bttEnter_Internalname ;
      private string bttEnter_Jsonclick ;
      private string Toastr1_Internalname ;
      private string Gx_mode ;
      private string Toastr1_Objectcall ;
      private string Toastr1_Class ;
      private string Toastr1_Position ;
      private string Toastr1_Showeasing ;
      private string Toastr1_Hideeasing ;
      private string Toastr1_Showmethod ;
      private string Toastr1_Hidemethod ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV49NuevoEstadoNomb ;
      private string AV62SolicitudesNombre ;
      private string AV75UsuariosId ;
      private string AV15CambioSTSOK ;
      private string AV66Titulo ;
      private string AV44MailCuentaNombre ;
      private string Z282ProveedorNombre ;
      private string sMode73 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXCCtlgxBlob ;
      private string ZZ493VincularTrnNombreSol ;
      private string ZZ494VincularTrnTelefonoSol ;
      private string ZZ282ProveedorNombre ;
      private DateTime Z496VincularTrnFecha ;
      private DateTime A496VincularTrnFecha ;
      private DateTime i496VincularTrnFecha ;
      private DateTime ZZ496VincularTrnFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A498DocumentacionIcono_IsBlob ;
      private bool A495VincularTrnImagen_IsBlob ;
      private bool Toastr1_Enabled ;
      private bool Toastr1_Closebutton ;
      private bool Toastr1_Progressbar ;
      private bool Toastr1_Preventduplicate ;
      private bool Toastr1_Newestontop ;
      private bool Toastr1_Visible ;
      private bool n488DocumentacionId ;
      private bool returnInSub ;
      private string A497VincularTrnComentario ;
      private string Z497VincularTrnComentario ;
      private string ZZ497VincularTrnComentario ;
      private string wcpOAV61SolicitudesMail ;
      private string AV61SolicitudesMail ;
      private string A40001DocumentacionIcono_GXI ;
      private string A40000VincularTrnImagen_GXI ;
      private string AV45MailDireccion ;
      private string Z40000VincularTrnImagen_GXI ;
      private string Z40001DocumentacionIcono_GXI ;
      private string ZZ40001DocumentacionIcono_GXI ;
      private string ZZ40000VincularTrnImagen_GXI ;
      private string A498DocumentacionIcono ;
      private string A495VincularTrnImagen ;
      private string Z495VincularTrnImagen ;
      private string Z498DocumentacionIcono ;
      private string ZZ498DocumentacionIcono ;
      private string ZZ495VincularTrnImagen ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucToastr1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtContext AV19context ;
      private SdtSDTCNotificaciones AV8SDTCNotificaciones ;
      private IDataStoreProvider pr_default ;
      private string[] T001U4_A282ProveedorNombre ;
      private long[] T001U4_A488DocumentacionId ;
      private bool[] T001U4_n488DocumentacionId ;
      private string[] T001U5_A40001DocumentacionIcono_GXI ;
      private string[] T001U5_A498DocumentacionIcono ;
      private long[] T001U6_A491VincularTrnId ;
      private long[] T001U6_A492VincularTrnSolidicutd ;
      private string[] T001U6_A493VincularTrnNombreSol ;
      private string[] T001U6_A494VincularTrnTelefonoSol ;
      private DateTime[] T001U6_A496VincularTrnFecha ;
      private string[] T001U6_A282ProveedorNombre ;
      private string[] T001U6_A40001DocumentacionIcono_GXI ;
      private string[] T001U6_A497VincularTrnComentario ;
      private string[] T001U6_A40000VincularTrnImagen_GXI ;
      private long[] T001U6_A133ProveedorID ;
      private long[] T001U6_A488DocumentacionId ;
      private bool[] T001U6_n488DocumentacionId ;
      private string[] T001U6_A498DocumentacionIcono ;
      private string[] T001U6_A495VincularTrnImagen ;
      private long[] T001U7_A491VincularTrnId ;
      private long[] T001U3_A491VincularTrnId ;
      private long[] T001U3_A492VincularTrnSolidicutd ;
      private string[] T001U3_A493VincularTrnNombreSol ;
      private string[] T001U3_A494VincularTrnTelefonoSol ;
      private DateTime[] T001U3_A496VincularTrnFecha ;
      private string[] T001U3_A497VincularTrnComentario ;
      private string[] T001U3_A40000VincularTrnImagen_GXI ;
      private long[] T001U3_A133ProveedorID ;
      private string[] T001U3_A495VincularTrnImagen ;
      private long[] T001U8_A491VincularTrnId ;
      private long[] T001U9_A491VincularTrnId ;
      private long[] T001U2_A491VincularTrnId ;
      private long[] T001U2_A492VincularTrnSolidicutd ;
      private string[] T001U2_A493VincularTrnNombreSol ;
      private string[] T001U2_A494VincularTrnTelefonoSol ;
      private DateTime[] T001U2_A496VincularTrnFecha ;
      private string[] T001U2_A497VincularTrnComentario ;
      private string[] T001U2_A40000VincularTrnImagen_GXI ;
      private long[] T001U2_A133ProveedorID ;
      private string[] T001U2_A495VincularTrnImagen ;
      private long[] T001U10_A491VincularTrnId ;
      private long[] T001U14_A491VincularTrnId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class vincular__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class vincular__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001U2;
        prmT001U2 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001U3;
        prmT001U3 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001U4;
        prmT001U4 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001U5;
        prmT001U5 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT001U6;
        prmT001U6 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001U7;
        prmT001U7 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001U8;
        prmT001U8 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001U9;
        prmT001U9 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001U10;
        prmT001U10 = new Object[] {
        new ParDef("@VincularTrnSolidicutd",GXType.Decimal,18,0) ,
        new ParDef("@VincularTrnNombreSol",GXType.NChar,80,0) ,
        new ParDef("@VincularTrnTelefonoSol",GXType.NChar,20,0) ,
        new ParDef("@VincularTrnFecha",GXType.Date,8,0) ,
        new ParDef("@VincularTrnImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@VincularTrnComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@VincularTrnImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="VincularTrn", Fld="VincularTrnImagen"} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0)
        };
        Object[] prmT001U11;
        prmT001U11 = new Object[] {
        new ParDef("@VincularTrnSolidicutd",GXType.Decimal,18,0) ,
        new ParDef("@VincularTrnNombreSol",GXType.NChar,80,0) ,
        new ParDef("@VincularTrnTelefonoSol",GXType.NChar,20,0) ,
        new ParDef("@VincularTrnFecha",GXType.Date,8,0) ,
        new ParDef("@VincularTrnComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001U12;
        prmT001U12 = new Object[] {
        new ParDef("@VincularTrnImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@VincularTrnImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="VincularTrn", Fld="VincularTrnImagen"} ,
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001U13;
        prmT001U13 = new Object[] {
        new ParDef("@VincularTrnId",GXType.Decimal,18,0)
        };
        Object[] prmT001U14;
        prmT001U14 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001U2", "SELECT [VincularTrnId], [VincularTrnSolidicutd], [VincularTrnNombreSol], [VincularTrnTelefonoSol], [VincularTrnFecha], [VincularTrnComentario], [VincularTrnImagen_GXI], [ProveedorID], [VincularTrnImagen] FROM [VincularTrn] WITH (UPDLOCK) WHERE [VincularTrnId] = @VincularTrnId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U3", "SELECT [VincularTrnId], [VincularTrnSolidicutd], [VincularTrnNombreSol], [VincularTrnTelefonoSol], [VincularTrnFecha], [VincularTrnComentario], [VincularTrnImagen_GXI], [ProveedorID], [VincularTrnImagen] FROM [VincularTrn] WHERE [VincularTrnId] = @VincularTrnId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U4", "SELECT [ProveedorNombre], [DocumentacionId] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U5", "SELECT [DocumentacionIcono_GXI], [DocumentacionIcono] FROM [Documentacion] WHERE [DocumentacionId] = @DocumentacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U6", "SELECT TM1.[VincularTrnId], TM1.[VincularTrnSolidicutd], TM1.[VincularTrnNombreSol], TM1.[VincularTrnTelefonoSol], TM1.[VincularTrnFecha], T2.[ProveedorNombre], T3.[DocumentacionIcono_GXI], TM1.[VincularTrnComentario], TM1.[VincularTrnImagen_GXI], TM1.[ProveedorID], T2.[DocumentacionId], T3.[DocumentacionIcono], TM1.[VincularTrnImagen] FROM (([VincularTrn] TM1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = TM1.[ProveedorID]) LEFT JOIN [Documentacion] T3 ON T3.[DocumentacionId] = T2.[DocumentacionId]) WHERE TM1.[VincularTrnId] = @VincularTrnId ORDER BY TM1.[VincularTrnId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001U6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U7", "SELECT [VincularTrnId] FROM [VincularTrn] WHERE [VincularTrnId] = @VincularTrnId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001U7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U8", "SELECT TOP 1 [VincularTrnId] FROM [VincularTrn] WHERE ( [VincularTrnId] > @VincularTrnId) ORDER BY [VincularTrnId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001U8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001U9", "SELECT TOP 1 [VincularTrnId] FROM [VincularTrn] WHERE ( [VincularTrnId] < @VincularTrnId) ORDER BY [VincularTrnId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001U9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001U10", "INSERT INTO [VincularTrn]([VincularTrnSolidicutd], [VincularTrnNombreSol], [VincularTrnTelefonoSol], [VincularTrnFecha], [VincularTrnImagen], [VincularTrnComentario], [VincularTrnImagen_GXI], [ProveedorID]) VALUES(@VincularTrnSolidicutd, @VincularTrnNombreSol, @VincularTrnTelefonoSol, @VincularTrnFecha, @VincularTrnImagen, @VincularTrnComentario, @VincularTrnImagen_GXI, @ProveedorID); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT001U10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001U11", "UPDATE [VincularTrn] SET [VincularTrnSolidicutd]=@VincularTrnSolidicutd, [VincularTrnNombreSol]=@VincularTrnNombreSol, [VincularTrnTelefonoSol]=@VincularTrnTelefonoSol, [VincularTrnFecha]=@VincularTrnFecha, [VincularTrnComentario]=@VincularTrnComentario, [ProveedorID]=@ProveedorID  WHERE [VincularTrnId] = @VincularTrnId", GxErrorMask.GX_NOMASK,prmT001U11)
           ,new CursorDef("T001U12", "UPDATE [VincularTrn] SET [VincularTrnImagen]=@VincularTrnImagen, [VincularTrnImagen_GXI]=@VincularTrnImagen_GXI  WHERE [VincularTrnId] = @VincularTrnId", GxErrorMask.GX_NOMASK,prmT001U12)
           ,new CursorDef("T001U13", "DELETE FROM [VincularTrn]  WHERE [VincularTrnId] = @VincularTrnId", GxErrorMask.GX_NOMASK,prmT001U13)
           ,new CursorDef("T001U14", "SELECT [VincularTrnId] FROM [VincularTrn] ORDER BY [VincularTrnId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001U14,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(7));
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(7));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 80);
              ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((long[]) buf[10])[0] = rslt.getLong(11);
              ((bool[]) buf[11])[0] = rslt.wasNull(11);
              ((string[]) buf[12])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(7));
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(9));
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
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}

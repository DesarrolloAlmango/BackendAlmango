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
namespace GeneXus.Programs.wwpbaseobjects {
   public class login : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public login( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public login( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageempty", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageempty", new Object[] {context});
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

      public override short ExecuteStartEvent( )
      {
         PA112( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START112( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true, false);
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
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal FormBackgroundImage\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormBackgroundImage\" data-gx-class=\"form-horizontal FormBackgroundImage\" novalidate action=\""+formatLink("wwpbaseobjects.login.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormBackgroundImage", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vUSER", StringUtil.RTrim( AV23User));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23User, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vTIPOUSUARIO", StringUtil.RTrim( AV33tipoUsuario));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSESTADO", StringUtil.RTrim( AV27usuariosEstado));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSNOMBRE", StringUtil.RTrim( AV29usuariosNombre));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vWWPCONTEXT", AV12WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT", AV12WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "vPAISID", StringUtil.RTrim( AV18paisid));
         GxWebStd.gx_hidden_field( context, "vUSER", StringUtil.RTrim( AV23User));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23User, "")), context));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV20ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSCORREO", AV24usuariosCorreo);
         GxWebStd.gx_hidden_field( context, "vUSUARIOSDIRECCION", AV26usuariosDireccion);
         GxWebStd.gx_hidden_field( context, "vUSUARIOSCPOSTAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25UsuariosCPostal), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSTELEFONO", StringUtil.RTrim( AV30UsuariosTelefono));
         GxWebStd.gx_hidden_field( context, "vUSUARIOSIMAGEN", AV28usuariosImagen);
         GxWebStd.gx_hidden_field( context, "vUSUARIOSIMAGEN_GXI", AV35Usuariosimagen_GXI);
         GxWebStd.gx_hidden_field( context, "vUSUARIOURL", AV31UsuarioURL);
         GxWebStd.gx_hidden_field( context, "vSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTROLES", AV34SdtRoles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTROLES", AV34SdtRoles);
         }
         GxWebStd.gx_hidden_field( context, "vMENSAJE", StringUtil.RTrim( AV15mensaje));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_Enablefixobjectfitcover", StringUtil.BoolToStr( Wwputilities_Enablefixobjectfitcover));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_Enableconvertcombotobootstrapselect", StringUtil.BoolToStr( Wwputilities_Enableconvertcombotobootstrapselect));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_Allowcolumnresizing", StringUtil.BoolToStr( Wwputilities_Allowcolumnresizing));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_Allowcolumnreordering", StringUtil.BoolToStr( Wwputilities_Allowcolumnreordering));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_Allowcolumnsrestore", StringUtil.BoolToStr( Wwputilities_Allowcolumnsrestore));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_Comboloadtype", StringUtil.RTrim( Wwputilities_Comboloadtype));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormBackgroundImage" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE112( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT112( ) ;
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
         return formatLink("wwpbaseobjects.login.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.LogIn" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Log In", "") ;
      }

      protected void WB110( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginLoginImageLeft", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelogincontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingLeft30", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelogin_Internalname, 1, 0, "px", 0, "px", "TableLoginTransparency", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgLogologin_gximage, "")==0) ? "GX_Image_LogoMagenta_Class" : "GX_Image_"+imgLogologin_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "4e255709-a98d-4cdb-b571-7337902f48d0", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLogologin_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_WWPBaseObjects/LogIn.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellLogin CellPaddingLogin CellLoginUserName", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername_Internalname, context.GetMessage( "Sec User Name", ""), "col-sm-3 AttributeLoginImageLeftLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername_Internalname, AV7SecUserName, StringUtil.RTrim( context.localUtil.Format( AV7SecUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Usuario", ""), edtavSecusername_Jsonclick, 0, "AttributeLoginImageLeft", "", "", "", "", 1, edtavSecusername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/LogIn.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellLogin CellPaddingLogin CellLoginPassword", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecuserpassword_Internalname, context.GetMessage( "Sec User Password", ""), "col-sm-3 AttributeLoginImageLeftLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecuserpassword_Internalname, AV8SecUserPassword, StringUtil.RTrim( context.localUtil.Format( AV8SecUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_GAM_Password", ""), edtavSecuserpassword_Jsonclick, 0, "AttributeLoginImageLeft", "", "", "", "", 1, edtavSecuserpassword_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, -1, 0, 0, 0, 0, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/LogIn.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellLogin CellPaddingLogin", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblForgotpassword_Internalname, context.GetMessage( "WWP_GAM_ForgotPassword", ""), "", "", lblForgotpassword_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescriptionLogin", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/LogIn.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellLogin CellPaddingLogin", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            ClassString = "ButtonMaterial ButtonLogin";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", context.GetMessage( "WWP_GAM_Login", ""), bttBtnenter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/LogIn.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellLogin CellPaddingLogin", "start", "top", "", "", "div");
            wb_table1_35_112( true) ;
         }
         else
         {
            wb_table1_35_112( false) ;
         }
         return  ;
      }

      protected void wb_table1_35_112e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucWwputilities.SetProperty("EnableFixObjectFitCover", Wwputilities_Enablefixobjectfitcover);
            ucWwputilities.SetProperty("EnableConvertComboToBootstrapSelect", Wwputilities_Enableconvertcombotobootstrapselect);
            ucWwputilities.SetProperty("AllowColumnResizing", Wwputilities_Allowcolumnresizing);
            ucWwputilities.SetProperty("AllowColumnReordering", Wwputilities_Allowcolumnreordering);
            ucWwputilities.SetProperty("AllowColumnsRestore", Wwputilities_Allowcolumnsrestore);
            ucWwputilities.SetProperty("ComboLoadType", Wwputilities_Comboloadtype);
            ucWwputilities.Render(context, "wwp.workwithplusutilities_fal", Wwputilities_Internalname, "WWPUTILITIESContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START112( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Log In", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP110( ) ;
      }

      protected void WS112( )
      {
         START112( ) ;
         EVT112( ) ;
      }

      protected void EVT112( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E11112 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E12112 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13112 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
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

      protected void WE112( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA112( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavSecusername_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF112( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF112( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13112 ();
            WB110( ) ;
         }
      }

      protected void send_integrity_lvl_hashes112( )
      {
         GxWebStd.gx_hidden_field( context, "vUSER", StringUtil.RTrim( AV23User));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSER", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23User, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP110( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11112 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Wwputilities_Enablefixobjectfitcover = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Enablefixobjectfitcover"));
            Wwputilities_Enableconvertcombotobootstrapselect = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Enableconvertcombotobootstrapselect"));
            Wwputilities_Allowcolumnresizing = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Allowcolumnresizing"));
            Wwputilities_Allowcolumnreordering = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Allowcolumnreordering"));
            Wwputilities_Allowcolumnsrestore = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_Allowcolumnsrestore"));
            Wwputilities_Comboloadtype = cgiGet( "WWPUTILITIES_Comboloadtype");
            /* Read variables values. */
            AV7SecUserName = cgiGet( edtavSecusername_Internalname);
            AssignAttri("", false, "AV7SecUserName", AV7SecUserName);
            AV8SecUserPassword = cgiGet( edtavSecuserpassword_Internalname);
            AssignAttri("", false, "AV8SecUserPassword", AV8SecUserPassword);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11112 ();
         if (returnInSub) return;
      }

      protected void E11112( )
      {
         /* Start Routine */
         returnInSub = false;
         AV10WebSession.Clear();
         divLayoutmaintable_Class = "MainContainerNoBackground";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         lblRegisteruser_Linktarget = context.GetMessage( "_Blank", "");
         AssignProp("", false, lblRegisteruser_Internalname, "Linktarget", lblRegisteruser_Linktarget, true);
         lblRegisteruser_Link = context.GetMessage( "https://almango.com.uy/altas/", "");
         AssignProp("", false, lblRegisteruser_Internalname, "Link", lblRegisteruser_Link, true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E12112 ();
         if (returnInSub) return;
      }

      protected void E12112( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV9LogInSuccessful = false;
         /* Execute user subroutine: 'VERIFICAR LOGIN' */
         S112 ();
         if (returnInSub) return;
         if ( AV9LogInSuccessful )
         {
            if ( ( ( StringUtil.StrCmp(AV33tipoUsuario, context.GetMessage( "A", "")) == 0 ) || ( StringUtil.StrCmp(AV33tipoUsuario, context.GetMessage( "P", "")) == 0 ) ) && ( StringUtil.StrCmp(AV27usuariosEstado, context.GetMessage( "HAB", "")) == 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "Log In Successful!", ""));
               AV12WWPContext.gxTpr_Usuariosnombre = StringUtil.Trim( StringUtil.Upper( AV29usuariosNombre));
               AV12WWPContext.gxTpr_Usuariotipo = AV33tipoUsuario;
               AV12WWPContext.gxTpr_Usuariopaisid = AV18paisid;
               AV12WWPContext.gxTpr_Usuariosid = StringUtil.Trim( AV23User);
               AV12WWPContext.gxTpr_Profesionalesid = StringUtil.Trim( AV20ProfesionalesId);
               AV12WWPContext.gxTpr_Usuarioscorreo = AV24usuariosCorreo;
               AV12WWPContext.gxTpr_Usuariosdireccion = AV26usuariosDireccion;
               AV12WWPContext.gxTpr_Usuarioscpostal = AV25UsuariosCPostal;
               AV12WWPContext.gxTpr_Usuariostelefono = AV30UsuariosTelefono;
               AV12WWPContext.gxTpr_Usuariosimagen = AV28usuariosImagen;
               AV12WWPContext.gxTpr_Usuariosimagen_gxi = AV35Usuariosimagen_GXI;
               AV12WWPContext.gxTpr_Usuariourl = AV31UsuarioURL;
               new oprovdoc(context ).execute(  AV20ProfesionalesId, out  AV21ProveedorID) ;
               AV12WWPContext.gxTpr_Proveedorid = AV21ProveedorID;
               new oclidoc(context ).execute(  AV20ProfesionalesId, out  AV13ClientesId) ;
               AV12WWPContext.gxTpr_Clientesid = AV13ClientesId;
               AV12WWPContext.gxTpr_Usuariosestado = AV27usuariosEstado;
            }
            AV12WWPContext.gxTpr_Userid = AV11SecUserId;
            AV12WWPContext.gxTpr_Username = AV7SecUserName;
            AV12WWPContext.gxTpr_Roles.FromJSonString(AV34SdtRoles.ToJSonString(false, true), null);
            new GeneXus.Programs.wwpbaseobjects.setwwpcontext(context ).execute(  AV12WWPContext) ;
            CallWebObject(formatLink("home.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV7SecUserName)) ) && ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV8SecUserPassword)) ) )
            {
               GX_msglist.addItem(AV15mensaje);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "Incorrect User/Password", ""));
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12WWPContext", AV12WWPContext);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34SdtRoles", AV34SdtRoles);
      }

      protected void S112( )
      {
         /* 'VERIFICAR LOGIN' Routine */
         returnInSub = false;
         AV17ok = context.GetMessage( "N", "");
         AV15mensaje = context.GetMessage( "Usuario incorrecto", "");
         AssignAttri("", false, "AV15mensaje", AV15mensaje);
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV7SecUserName)) ) )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8SecUserPassword)) )
            {
               new loginverificar(context ).execute( ref  AV7SecUserName, ref  AV8SecUserPassword, out  AV15mensaje, out  AV17ok, out  AV11SecUserId, out  AV29usuariosNombre, out  AV18paisid, out  AV33tipoUsuario, out  AV20ProfesionalesId, out  AV24usuariosCorreo, out  AV26usuariosDireccion, out  AV25UsuariosCPostal, out  AV30UsuariosTelefono, out  AV28usuariosImagen, out  AV31UsuarioURL, out  AV27usuariosEstado, out  AV34SdtRoles) ;
               AssignAttri("", false, "AV7SecUserName", AV7SecUserName);
               AssignAttri("", false, "AV8SecUserPassword", AV8SecUserPassword);
               AssignAttri("", false, "AV15mensaje", AV15mensaje);
               AssignAttri("", false, "AV11SecUserId", StringUtil.LTrimStr( (decimal)(AV11SecUserId), 10, 0));
               AssignAttri("", false, "AV29usuariosNombre", AV29usuariosNombre);
               AssignAttri("", false, "AV18paisid", AV18paisid);
               AssignAttri("", false, "AV33tipoUsuario", AV33tipoUsuario);
               AssignAttri("", false, "AV20ProfesionalesId", AV20ProfesionalesId);
               AssignAttri("", false, "AV24usuariosCorreo", AV24usuariosCorreo);
               AssignAttri("", false, "AV26usuariosDireccion", AV26usuariosDireccion);
               AssignAttri("", false, "AV25UsuariosCPostal", StringUtil.LTrimStr( (decimal)(AV25UsuariosCPostal), 5, 0));
               AssignAttri("", false, "AV30UsuariosTelefono", AV30UsuariosTelefono);
               AssignAttri("", false, "AV28usuariosImagen", AV28usuariosImagen);
               AssignAttri("", false, "AV31UsuarioURL", AV31UsuarioURL);
               AssignAttri("", false, "AV27usuariosEstado", AV27usuariosEstado);
            }
         }
         if ( StringUtil.StrCmp(AV17ok, context.GetMessage( "S", "")) != 0 )
         {
            AV9LogInSuccessful = false;
         }
         else
         {
            AV9LogInSuccessful = true;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E13112( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_35_112( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtable2_Internalname, tblUnnamedtable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNoaccount_Internalname, context.GetMessage( "WWP_GAM_DontHaveAccount", ""), "", "", lblNoaccount_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/LogIn.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblRegisteruser_Internalname, context.GetMessage( "WWP_GAM_CreateOneNow", ""), lblRegisteruser_Link, lblRegisteruser_Linktarget, lblRegisteruser_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescriptionLogin", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/LogIn.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_35_112e( true) ;
         }
         else
         {
            wb_table1_35_112e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA112( ) ;
         WS112( ) ;
         WE112( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/Bootstrap/Shared/fontawesome_vlatest/css/all.min.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932012127", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/login.js", "?2026932012127", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgLogologin_Internalname = "LOGOLOGIN";
         edtavSecusername_Internalname = "vSECUSERNAME";
         edtavSecuserpassword_Internalname = "vSECUSERPASSWORD";
         lblForgotpassword_Internalname = "FORGOTPASSWORD";
         bttBtnenter_Internalname = "BTNENTER";
         lblNoaccount_Internalname = "NOACCOUNT";
         lblRegisteruser_Internalname = "REGISTERUSER";
         tblUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablelogin_Internalname = "TABLELOGIN";
         divTablelogincontent_Internalname = "TABLELOGINCONTENT";
         Wwputilities_Internalname = "WWPUTILITIES";
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
         lblRegisteruser_Linktarget = "";
         lblRegisteruser_Link = "";
         edtavSecuserpassword_Jsonclick = "";
         edtavSecuserpassword_Enabled = 1;
         edtavSecusername_Jsonclick = "";
         edtavSecusername_Enabled = 1;
         divLayoutmaintable_Class = "Table";
         Wwputilities_Comboloadtype = "InfiniteScrolling";
         Wwputilities_Allowcolumnsrestore = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnreordering = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnresizing = Convert.ToBoolean( -1);
         Wwputilities_Enableconvertcombotobootstrapselect = Convert.ToBoolean( -1);
         Wwputilities_Enablefixobjectfitcover = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Log In", "");
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV23User',fld:'vUSER',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E12112',iparms:[{av:'AV33tipoUsuario',fld:'vTIPOUSUARIO',pic:'',type:'char'},{av:'AV27usuariosEstado',fld:'vUSUARIOSESTADO',pic:'',type:'char'},{av:'AV29usuariosNombre',fld:'vUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV12WWPContext',fld:'vWWPCONTEXT',pic:''},{av:'AV18paisid',fld:'vPAISID',pic:'',type:'char'},{av:'AV23User',fld:'vUSER',pic:'',hsh:true,type:'char'},{av:'AV20ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'AV24usuariosCorreo',fld:'vUSUARIOSCORREO',pic:'',type:'svchar'},{av:'AV26usuariosDireccion',fld:'vUSUARIOSDIRECCION',pic:'',type:'svchar'},{av:'AV25UsuariosCPostal',fld:'vUSUARIOSCPOSTAL',pic:'ZZZZ9',type:'int'},{av:'AV30UsuariosTelefono',fld:'vUSUARIOSTELEFONO',pic:'',type:'char'},{av:'AV28usuariosImagen',fld:'vUSUARIOSIMAGEN',pic:'',type:'bits'},{av:'AV35Usuariosimagen_GXI',fld:'vUSUARIOSIMAGEN_GXI',pic:'',type:'svchar'},{av:'AV31UsuarioURL',fld:'vUSUARIOURL',pic:'',type:'svchar'},{av:'AV11SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV7SecUserName',fld:'vSECUSERNAME',pic:'',type:'svchar'},{av:'AV34SdtRoles',fld:'vSDTROLES',pic:''},{av:'AV8SecUserPassword',fld:'vSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV15mensaje',fld:'vMENSAJE',pic:'',type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12WWPContext',fld:'vWWPCONTEXT',pic:''},{av:'AV15mensaje',fld:'vMENSAJE',pic:'',type:'char'},{av:'AV34SdtRoles',fld:'vSDTROLES',pic:''},{av:'AV27usuariosEstado',fld:'vUSUARIOSESTADO',pic:'',type:'char'},{av:'AV31UsuarioURL',fld:'vUSUARIOURL',pic:'',type:'svchar'},{av:'AV28usuariosImagen',fld:'vUSUARIOSIMAGEN',pic:'',type:'bits'},{av:'AV30UsuariosTelefono',fld:'vUSUARIOSTELEFONO',pic:'',type:'char'},{av:'AV25UsuariosCPostal',fld:'vUSUARIOSCPOSTAL',pic:'ZZZZ9',type:'int'},{av:'AV26usuariosDireccion',fld:'vUSUARIOSDIRECCION',pic:'',type:'svchar'},{av:'AV24usuariosCorreo',fld:'vUSUARIOSCORREO',pic:'',type:'svchar'},{av:'AV20ProfesionalesId',fld:'vPROFESIONALESID',pic:'',type:'char'},{av:'AV33tipoUsuario',fld:'vTIPOUSUARIO',pic:'',type:'char'},{av:'AV18paisid',fld:'vPAISID',pic:'',type:'char'},{av:'AV29usuariosNombre',fld:'vUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV11SecUserId',fld:'vSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV8SecUserPassword',fld:'vSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV7SecUserName',fld:'vSECUSERNAME',pic:'',type:'svchar'}]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV23User = "";
         GXKey = "";
         AV33tipoUsuario = "";
         AV27usuariosEstado = "";
         AV29usuariosNombre = "";
         AV12WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV18paisid = "";
         AV20ProfesionalesId = "";
         AV24usuariosCorreo = "";
         AV26usuariosDireccion = "";
         AV30UsuariosTelefono = "";
         AV28usuariosImagen = "";
         AV35Usuariosimagen_GXI = "";
         AV31UsuarioURL = "";
         AV34SdtRoles = new SdtSDTRoles(context);
         AV15mensaje = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         imgLogologin_gximage = "";
         StyleString = "";
         sImgUrl = "";
         TempTags = "";
         AV7SecUserName = "";
         AV8SecUserPassword = "";
         lblForgotpassword_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         ucWwputilities = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV10WebSession = context.GetSession();
         AV17ok = "";
         sStyleString = "";
         lblNoaccount_Jsonclick = "";
         lblRegisteruser_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV25UsuariosCPostal ;
      private int edtavSecusername_Enabled ;
      private int edtavSecuserpassword_Enabled ;
      private int idxLst ;
      private long AV11SecUserId ;
      private long AV21ProveedorID ;
      private long AV13ClientesId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV23User ;
      private string GXKey ;
      private string AV33tipoUsuario ;
      private string AV27usuariosEstado ;
      private string AV29usuariosNombre ;
      private string AV18paisid ;
      private string AV20ProfesionalesId ;
      private string AV30UsuariosTelefono ;
      private string AV15mensaje ;
      private string Wwputilities_Comboloadtype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTablelogincontent_Internalname ;
      private string divTablelogin_Internalname ;
      private string ClassString ;
      private string imgLogologin_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgLogologin_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtavSecusername_Internalname ;
      private string TempTags ;
      private string edtavSecusername_Jsonclick ;
      private string edtavSecuserpassword_Internalname ;
      private string edtavSecuserpassword_Jsonclick ;
      private string lblForgotpassword_Internalname ;
      private string lblForgotpassword_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string Wwputilities_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string lblRegisteruser_Linktarget ;
      private string lblRegisteruser_Internalname ;
      private string lblRegisteruser_Link ;
      private string AV17ok ;
      private string sStyleString ;
      private string tblUnnamedtable2_Internalname ;
      private string lblNoaccount_Internalname ;
      private string lblNoaccount_Jsonclick ;
      private string lblRegisteruser_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Wwputilities_Enablefixobjectfitcover ;
      private bool Wwputilities_Enableconvertcombotobootstrapselect ;
      private bool Wwputilities_Allowcolumnresizing ;
      private bool Wwputilities_Allowcolumnreordering ;
      private bool Wwputilities_Allowcolumnsrestore ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9LogInSuccessful ;
      private string AV24usuariosCorreo ;
      private string AV26usuariosDireccion ;
      private string AV35Usuariosimagen_GXI ;
      private string AV31UsuarioURL ;
      private string AV7SecUserName ;
      private string AV8SecUserPassword ;
      private string AV28usuariosImagen ;
      private GXUserControl ucWwputilities ;
      private IGxSession AV10WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV12WWPContext ;
      private SdtSDTRoles AV34SdtRoles ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}

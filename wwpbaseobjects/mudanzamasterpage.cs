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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class mudanzamasterpage : GXMasterPage, System.Web.SessionState.IRequiresSessionState
   {
      public mudanzamasterpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public mudanzamasterpage( IGxContext context )
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
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            PAGF2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WSGF2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WEGF2( ) ;
               }
            }
         }
         cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            GXWebForm.AddResponsiveMetaHeaders((getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta);
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vDVELOP_MENU_MPAGE", AV30DVelop_Menu);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDVELOP_MENU_MPAGE", AV30DVelop_Menu);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDVELOP_MENU_MPAGE", GetSecureSignedToken( "gxmpage_", AV30DVelop_Menu, context));
         GxWebStd.gx_hidden_field( context, "vBREADCRUMB_MPAGE", AV34Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV34Breadcrumb, "")), context));
         GxWebStd.gx_hidden_field( context, "vINDEXTOADDITEMS_MPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15IndexToAddItems), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV15IndexToAddItems), "ZZZ9"), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vDVELOP_MENU_MPAGE", AV30DVelop_Menu);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDVELOP_MENU_MPAGE", AV30DVelop_Menu);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vDVELOP_MENU_MPAGE", GetSecureSignedToken( "gxmpage_", AV30DVelop_Menu, context));
         GxWebStd.gx_hidden_field( context, "vBREADCRUMB_MPAGE", AV34Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV34Breadcrumb, "")), context));
         GxWebStd.gx_hidden_field( context, "vINDEXTOADDITEMS_MPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15IndexToAddItems), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV15IndexToAddItems), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTOTAL_MPAGE", StringUtil.LTrim( StringUtil.NToC( AV45Total, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vOCULTAR_MPAGE", AV47Ocultar);
         GxWebStd.gx_hidden_field( context, "vTAMANOVEHICULO_MPAGE", AV50TamanoVehiculo);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vNOTIFICATIONINFO_MPAGE", AV18NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO_MPAGE", AV18NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDID_MPAGE", StringUtil.RTrim( A1WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "vUDPARG1_MPAGE", StringUtil.RTrim( AV55Udparg1));
         GxWebStd.gx_boolean_hidden_field( context, "WWPNOTIFICATIONISREAD_MPAGE", A91WWPNotificationIsRead);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vWWPCONTEXT_MPAGE", AV5WWPContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vWWPCONTEXT_MPAGE", AV5WWPContext);
         }
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Stoponerror", StringUtil.BoolToStr( Ucmessage_Stoponerror));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enablefixobjectfitcover", StringUtil.BoolToStr( Wwputilities_Enablefixobjectfitcover));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enablefloatinglabels", StringUtil.BoolToStr( Wwputilities_Enablefloatinglabels));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Empowertabs", StringUtil.BoolToStr( Wwputilities_Empowertabs));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enableupdaterowselectionstatus", StringUtil.BoolToStr( Wwputilities_Enableupdaterowselectionstatus));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enableconvertcombotobootstrapselect", StringUtil.BoolToStr( Wwputilities_Enableconvertcombotobootstrapselect));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnresizing", StringUtil.BoolToStr( Wwputilities_Allowcolumnresizing));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnreordering", StringUtil.BoolToStr( Wwputilities_Allowcolumnreordering));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumndragging", StringUtil.BoolToStr( Wwputilities_Allowcolumndragging));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnsrestore", StringUtil.BoolToStr( Wwputilities_Allowcolumnsrestore));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Pagbarincludegoto", StringUtil.BoolToStr( Wwputilities_Pagbarincludegoto));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Comboloadtype", StringUtil.RTrim( Wwputilities_Comboloadtype));
         GxWebStd.gx_hidden_field( context, "vHTTPREQUEST_MPAGE_Baseurl", StringUtil.RTrim( AV38Httprequest.BaseURL));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONINFO_MPAGE_Message", AV18NotificationInfo.gxTpr_Message);
      }

      protected void RenderHtmlCloseFormGF2( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((string)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Tooltip/BootstrapTooltipRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DatePicker/DatePickerRender.js", "", false, true, false);
         context.AddJavascriptSource("wwpbaseobjects/mudanzamasterpage.js", "?20269212253368", false, true, false);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.MudanzaMasterPage" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Master Page", "") ;
      }

      protected void WBGF0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MasterHeaderCell navbar-fixed-top", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "TableHeader", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "HeaderImageCell", "start", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "ImageTop" + " " + ((StringUtil.StrCmp(imgHeader_gximage, "")==0) ? "GX_Image_logoBlanco_Class" : "GX_Image_"+imgHeader_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "6d6ce347-47c5-435c-997c-4658165957fb", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgHeader_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_WWPBaseObjects/MudanzaMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablevehiculo_Internalname, divTablevehiculo_Visible, 150, "px", 50, "px", "Table", "start", "top", " "+"data-gx-canvas"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-canvas-cell"+" ", "position:absolute;z-index:0;display:inline-block;right:0px;left:0px;top:0px;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "aligncenter", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, divUnnamedtable5_Width, "px", divUnnamedtable5_Height, "px", "Table", "start", "top", " "+"data-gx-canvas"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-canvas-cell"+" ", "position:absolute;z-index:1;display:inline-block;right:0px;left:-60px;top:24px;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTamano_Internalname, lblTamano_Caption, "", "", lblTamano_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "color:"+context.BuildHTMLColor( lblTamano_Forecolor)+";", "AttributeSizeLarge AttributeWeightBold AttributeColorWarning", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/MudanzaMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, divUnnamedtable6_Width, "px", divUnnamedtable6_Height, "px", "Table", "start", "top", " "+"data-gx-canvas"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-canvas-cell"+" ", "position:absolute;z-index:0;display:inline-block;right:0px;left:-20px;top:-10px;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", context.GetMessage( "Vehiculo Imagen", ""), "gx-form-item AttributeFLLabel", 0, true, "width: 25%;");
            /* Static Bitmap Variable */
            ClassString = "AttributeFL" + " " + ((StringUtil.StrCmp(imgavVehiculoimagen_gximage, "")==0) ? "" : "GX_Image_"+imgavVehiculoimagen_gximage+"_Class");
            StyleString = "";
            AV49VehiculoImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV49VehiculoImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( AV53Vehiculoimagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV49VehiculoImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV49VehiculoImagen)) ? AV53Vehiculoimagen_GXI : context.PathToRelativeUrl( AV49VehiculoImagen));
            GxWebStd.gx_bitmap( context, imgavVehiculoimagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV49VehiculoImagen_IsBlob, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_WWPBaseObjects/MudanzaMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:2;align-self:flex-start;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletotal_Internalname, divTabletotal_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, divUnnamedtable3_Width, "px", divUnnamedtable3_Height, "px", "Table", "start", "top", " "+"data-gx-canvas"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-canvas-cell"+" ", "position:absolute;z-index:1;display:inline-block;right:0px;left:85px;top:24px;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTotal2_Internalname, context.GetMessage( "Total: ", ""), "", "", lblTotal2_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "font-size:"+StringUtil.Str( (decimal)(lblTotal2_Fontsize), 3, 0)+"pt;"+"color:"+context.BuildHTMLColor( lblTotal2_Forecolor)+";", "AttributeColorDanger AttributeSizeLarge AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/MudanzaMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-canvas-cell"+" ", "position:absolute;z-index:2;display:inline-block;right:0px;left:145px;top:23px;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTotalvalor_Internalname, lblTotalvalor_Caption, "", "", lblTotalvalor_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "font-size:"+StringUtil.Str( (decimal)(lblTotalvalor_Fontsize), 3, 0)+"pt;"+((lblTotalvalor_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;"), "TextBlock AttributeSizeLarge", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/MudanzaMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableuserrole_Internalname, 1, 0, "px", 0, "px", "CellHeaderBar hidden-xs", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellAttributeSearch", "start", "top", "", "align-self:center;", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellTableContentMaster CellTableContentWithFooter", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "page-content MaterialStyle page-content2", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellContentHolder left-50", "start", "top", "", "", "div");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MasterFooterCellVM page-content", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefooter_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfooter_Internalname, context.GetMessage( "Almango Systems | Desing by Azmita", ""), "", "", lblTextblockfooter_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "FooterText", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/MudanzaMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcmessage.SetProperty("StopOnError", Ucmessage_Stoponerror);
            ucUcmessage.Render(context, "dvelop.dvmessage", Ucmessage_Internalname, "UCMESSAGE_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUctooltip.Render(context, "dvelop.gxbootstrap.tooltip", Uctooltip_Internalname, "UCTOOLTIP_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucWwputilities.SetProperty("EnableFixObjectFitCover", Wwputilities_Enablefixobjectfitcover);
            ucWwputilities.SetProperty("EnableFloatingLabels", Wwputilities_Enablefloatinglabels);
            ucWwputilities.SetProperty("EmpowerTabs", Wwputilities_Empowertabs);
            ucWwputilities.SetProperty("EnableUpdateRowSelectionStatus", Wwputilities_Enableupdaterowselectionstatus);
            ucWwputilities.SetProperty("EnableConvertComboToBootstrapSelect", Wwputilities_Enableconvertcombotobootstrapselect);
            ucWwputilities.SetProperty("AllowColumnResizing", Wwputilities_Allowcolumnresizing);
            ucWwputilities.SetProperty("AllowColumnReordering", Wwputilities_Allowcolumnreordering);
            ucWwputilities.SetProperty("AllowColumnDragging", Wwputilities_Allowcolumndragging);
            ucWwputilities.SetProperty("AllowColumnsRestore", Wwputilities_Allowcolumnsrestore);
            ucWwputilities.SetProperty("PagBarIncludeGoTo", Wwputilities_Pagbarincludegoto);
            ucWwputilities.SetProperty("ComboLoadType", Wwputilities_Comboloadtype);
            ucWwputilities.Render(context, "wwp.workwithplusutilities_fal", Wwputilities_Internalname, "WWPUTILITIES_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucWwpdatepicker.Render(context, "wwp.datepicker", Wwpdatepicker_Internalname, "WWPDATEPICKER_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblHtml_Internalname, lblHtml_Caption, "", "", lblHtml_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", lblHtml_Visible, 1, 0, 1, "HLP_WWPBaseObjects/MudanzaMasterPage.htm");
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
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',true,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavPickerdummyvariable_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavPickerdummyvariable_Internalname, context.localUtil.Format(AV42PickerDummyVariable, "99/99/99"), context.localUtil.Format( AV42PickerDummyVariable, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "", "", "", edtavPickerdummyvariable_Jsonclick, 0, "Invisible", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/MudanzaMasterPage.htm");
            GxWebStd.gx_bitmap( context, edtavPickerdummyvariable_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_WWPBaseObjects/MudanzaMasterPage.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void STARTGF2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPGF0( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WSGF2( )
      {
         STARTGF2( ) ;
         EVTGF2( ) ;
      }

      protected void EVTGF2( )
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
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11GF2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E12GF2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Onmessage_gx1 */
                           E13GF2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E14GF2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS_MPAGE.ACTUALIZARTOTAL_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E15GF2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS_MPAGE.ACTUALIZARVEHICULO_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E16GF2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E17GF2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                              }
                              dynload_actions( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Onmessage_gx1 */
                           E13GF2 ();
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WEGF2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormGF2( ) ;
            }
         }
      }

      protected void PAGF2( )
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
               GX_FocusControl = edtavPickerdummyvariable_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
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
         RFGF2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFGF2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            /* Execute user event: Refresh */
            E12GF2 ();
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E17GF2 ();
            WBGF0( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashesGF2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUPGF0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11GF2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO_MPAGE"), AV18NotificationInfo);
            /* Read saved values. */
            AV47Ocultar = StringUtil.StrToBool( cgiGet( "vOCULTAR_MPAGE"));
            Ucmessage_Stoponerror = StringUtil.StrToBool( cgiGet( "UCMESSAGE_MPAGE_Stoponerror"));
            Wwputilities_Enablefixobjectfitcover = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enablefixobjectfitcover"));
            Wwputilities_Enablefloatinglabels = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enablefloatinglabels"));
            Wwputilities_Empowertabs = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Empowertabs"));
            Wwputilities_Enableupdaterowselectionstatus = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enableupdaterowselectionstatus"));
            Wwputilities_Enableconvertcombotobootstrapselect = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enableconvertcombotobootstrapselect"));
            Wwputilities_Allowcolumnresizing = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnresizing"));
            Wwputilities_Allowcolumnreordering = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnreordering"));
            Wwputilities_Allowcolumndragging = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumndragging"));
            Wwputilities_Allowcolumnsrestore = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnsrestore"));
            Wwputilities_Pagbarincludegoto = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Pagbarincludegoto"));
            Wwputilities_Comboloadtype = cgiGet( "WWPUTILITIES_MPAGE_Comboloadtype");
            /* Read variables values. */
            AV49VehiculoImagen = cgiGet( imgavVehiculoimagen_Internalname);
            if ( context.localUtil.VCDate( cgiGet( edtavPickerdummyvariable_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Picker Dummy Variable", "")}), 1, "vPICKERDUMMYVARIABLE_MPAGE");
               GX_FocusControl = edtavPickerdummyvariable_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV42PickerDummyVariable = DateTime.MinValue;
               AssignAttri("", true, "AV42PickerDummyVariable", context.localUtil.Format(AV42PickerDummyVariable, "99/99/99"));
            }
            else
            {
               AV42PickerDummyVariable = context.localUtil.CToD( cgiGet( edtavPickerdummyvariable_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", true, "AV42PickerDummyVariable", context.localUtil.Format(AV42PickerDummyVariable, "99/99/99"));
            }
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
         E11GF2 ();
         if (returnInSub) return;
      }

      protected void E11GF2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblHtml_Visible = 0;
         AssignProp("", true, lblHtml_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblHtml_Visible), 5, 0), true);
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\""+context.convertURL( (string)(context.GetImagePath( "068ed6aa-27b2-425c-8e58-76bddef87f12", "", context.GetTheme( ))))+"\">";
         divLayoutmaintable_Class = "MainContainerWithFooter";
         AssignProp("", true, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         divTabletotal_Visible = 0;
         AssignProp("", true, divTabletotal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTabletotal_Visible), 5, 0), true);
         lblTamano_Forecolor = GXUtil.RGB( 255, 255, 255);
         AssignProp("", true, lblTamano_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTamano_Forecolor), 9, 0), true);
         divUnnamedtable3_Width = 170;
         AssignProp("", true, divUnnamedtable3_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divUnnamedtable3_Width), 9, 0), true);
         divUnnamedtable3_Height = 50;
         AssignProp("", true, divUnnamedtable3_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divUnnamedtable3_Height), 9, 0), true);
         divUnnamedtable6_Width = 60;
         AssignProp("", true, divUnnamedtable6_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divUnnamedtable6_Width), 9, 0), true);
         divUnnamedtable6_Height = 45;
         AssignProp("", true, divUnnamedtable6_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divUnnamedtable6_Height), 9, 0), true);
         divUnnamedtable5_Width = 170;
         AssignProp("", true, divUnnamedtable5_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divUnnamedtable5_Width), 9, 0), true);
         divUnnamedtable5_Height = 50;
         AssignProp("", true, divUnnamedtable5_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divUnnamedtable5_Height), 9, 0), true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV5WWPContext) ;
         AV31UserName = AV5WWPContext.gxTpr_Username;
         AV32RolesDescriptions = "";
         GXt_objcol_int1 = AV7SecRoleIdCollection;
         new GeneXus.Programs.wwpbaseobjects.secgetrolesfromloggeduser(context ).execute( out  GXt_objcol_int1) ;
         AV7SecRoleIdCollection = GXt_objcol_int1;
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV7SecRoleIdCollection.Count )
         {
            AV8SecRoleId = (short)(AV7SecRoleIdCollection.GetNumeric(AV51GXV1));
            AssignAttri("", true, "AV8SecRoleId", StringUtil.LTrimStr( (decimal)(AV8SecRoleId), 4, 0));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32RolesDescriptions)) )
            {
               AV32RolesDescriptions += ", ";
            }
            /* Using cursor H00GF2 */
            pr_default.execute(0, new Object[] {AV8SecRoleId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A16SecRoleId = H00GF2_A16SecRoleId[0];
               A25SecRoleName = H00GF2_A25SecRoleName[0];
               AV32RolesDescriptions += A25SecRoleName;
               if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A25SecRoleName)), context.GetMessage( "ADMINISTRATOR", "")) == 0 )
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionsdata(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
               }
               else if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A25SecRoleName)), context.GetMessage( "ADM GENERAL", "")) == 0 )
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionsadmin(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
               }
               else if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A25SecRoleName)), context.GetMessage( "ADM EJECUTIVO", "")) == 0 )
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionsadmin(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
               }
               else if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A25SecRoleName)), context.GetMessage( "AGE VENDEDOR", "")) == 0 )
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionsvendedor(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
               }
               else if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A25SecRoleName)), context.GetMessage( "ADM COMERCIO", "")) == 0 )
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionscomercio(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
                  /* Execute user subroutine: 'HTML CONTACTAR' */
                  S113 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               else if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A25SecRoleName)), context.GetMessage( "AGE COMERCIO", "")) == 0 )
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionscomercio(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
                  /* Execute user subroutine: 'HTML CONTACTAR' */
                  S113 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               else
               {
                  GXt_objcol_SdtDVelop_Menu_Item2 = AV30DVelop_Menu;
                  new GeneXus.Programs.wwpbaseobjects.menuoptionsvendedor(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item2) ;
                  AV30DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item2;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         new GeneXus.Programs.wwpbaseobjects.getmenuauthorizedoptions(context ).execute( ref  AV30DVelop_Menu) ;
         if ( new GeneXus.Programs.wwpbaseobjects.wwp_loadlanguageandtheme(context).executeUdp( out  AV33Language) )
         {
            context.DoAjaxRefresh();
         }
         if ( StringUtil.StrCmp(AV35WebSession.Get(context.GetMessage( "ClientInformationSaved", "")), context.GetMessage( "Y", "")) != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_registerwebclient(context ).execute(  new GeneXus.Core.genexus.client.SdtClientInformation(context).gxTpr_Id,  (short)(context.GetBrowserType( )),  context.GetBrowserVersion( ),  new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( )) ;
            AV35WebSession.Set(context.GetMessage( "ClientInformationSaved", ""), context.GetMessage( "Y", ""));
         }
         /* Execute user subroutine: 'LOADNOTIFICATIONS' */
         S122 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV38Httprequest.Method, "GET") == 0 )
         {
            GXt_SdtWWP_DesignSystemSettings3 = AV23WWP_DesignSystemSettings;
            new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings3) ;
            AV23WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings3;
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"base-color",AV23WWP_DesignSystemSettings.gxTpr_Basecolor}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"background-color",AV23WWP_DesignSystemSettings.gxTpr_Backgroundstyle}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"menu-color",AV23WWP_DesignSystemSettings.gxTpr_Menucolor}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"font-size",AV23WWP_DesignSystemSettings.gxTpr_Fontsize}, false);
            this.executeExternalObjectMethod("", true, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
         }
         if ( 0 == 1 )
         {
            if ( StringUtil.StrCmp(StringUtil.Lower( Contentholder.Pgmname), "wwpbaseobjects.notauthorized") != 0 )
            {
               new GeneXus.Programs.wwpbaseobjects.secisauthbyobjectname(context ).execute(  Contentholder.Pgmname, out  AV39IsAuthorized) ;
               if ( ! AV39IsAuthorized )
               {
                  GXKey = Crypto.GetSiteKey( );
                  GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(Contentholder.Pgmname));
                  CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
                  context.wjLocDisableFrm = 1;
               }
            }
         }
         lblTotal2_Fontsize = 14;
         AssignProp("", true, lblTotal2_Internalname, "Fontsize", StringUtil.LTrimStr( (decimal)(lblTotal2_Fontsize), 9, 0), true);
         lblTotal2_Forecolor = GXUtil.RGB( 245, 245, 245);
         AssignProp("", true, lblTotal2_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTotal2_Forecolor), 9, 0), true);
         lblTotalvalor_Fontsize = 14;
         AssignProp("", true, lblTotalvalor_Internalname, "Fontsize", StringUtil.LTrimStr( (decimal)(lblTotalvalor_Fontsize), 9, 0), true);
         lblTotalvalor_Fontbold = 1;
         AssignProp("", true, lblTotalvalor_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTotalvalor_Fontbold), 1, 0), true);
      }

      protected void E12GF2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         GXt_boolean4 = false;
         new GeneXus.Programs.wwpbaseobjects.loadbreadcrumb(context ).execute(  AV30DVelop_Menu,  AV38Httprequest.ScriptName, ref  AV34Breadcrumb, ref  GXt_boolean4) ;
         AssignAttri("", true, "AV34Breadcrumb", AV34Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV34Breadcrumb, "")), context));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV34Breadcrumb))) )
         {
            AV34Breadcrumb = AV35WebSession.Get("LastBreadcrumb");
            AssignAttri("", true, "AV34Breadcrumb", AV34Breadcrumb);
            GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV34Breadcrumb, "")), context));
         }
         else
         {
            AV35WebSession.Set("LastBreadcrumb", AV34Breadcrumb);
         }
         /* Execute user subroutine: 'LOADBOOKMARKS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E13GF2( )
      {
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         if ( StringUtil.StartsWith( AV18NotificationInfo.gxTpr_Id, "WebNotification#") )
         {
            AV19WWP_WebNotification.FromJSonString(AV18NotificationInfo.gxTpr_Message, null);
            if ( ! new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_isreceivedwebnotification(context).executeUdp(  AV19WWP_WebNotification.gxTpr_Wwpwebnotificationid) )
            {
               new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_setwebnotificationreceived(context ).execute(  AV19WWP_WebNotification.gxTpr_Wwpwebnotificationid) ;
               AV20WWP_UserExtended.Load(new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( ));
               if ( AV20WWP_UserExtended.gxTpr_Wwpuserextendeddesktopnotif )
               {
                  GXKey = Crypto.GetSiteKey( );
                  GXEncryptionTmp = "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx"+UrlEncode(StringUtil.LTrimStr(AV19WWP_WebNotification.gxTpr_Wwpnotificationid,10,0));
                  GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetdesktopnotificationmsg(context).executeUdp(  AV19WWP_WebNotification.gxTpr_Wwpwebnotificationtitle,  AV19WWP_WebNotification.gxTpr_Wwpwebnotificationtext,  AV19WWP_WebNotification.gxTpr_Wwpwebnotificationicon,  formatLink("wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)));
               }
            }
         }
         /* Execute user subroutine: 'LOADNOTIFICATIONS' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E14GF2( )
      {
         /* General\GlobalEvents_Master_refreshheader Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E15GF2( )
      {
         /* General\GlobalEvents_Actualizartotal Routine */
         returnInSub = false;
         lblTotalvalor_Caption = context.localUtil.Format( AV45Total, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99");
         AssignProp("", true, lblTotalvalor_Internalname, "Caption", lblTotalvalor_Caption, true);
         /*  Sending Event outputs  */
      }

      protected void E16GF2( )
      {
         /* General\GlobalEvents_Actualizarvehiculo Routine */
         returnInSub = false;
         AV48MudanzaVehiculoSugerido = AV50TamanoVehiculo;
         lblTamano_Caption = StringUtil.Trim( AV48MudanzaVehiculoSugerido);
         AssignProp("", true, lblTamano_Internalname, "Caption", lblTamano_Caption, true);
         if ( StringUtil.StrCmp(AV48MudanzaVehiculoSugerido, context.GetMessage( "CHICO", "")) == 0 )
         {
            imgavVehiculoimagen_gximage = "Chico";
            AssignProp("", true, imgavVehiculoimagen_Internalname, "gximage", imgavVehiculoimagen_gximage, true);
            AV49VehiculoImagen = context.GetImagePath( "03f731fd-d1bc-45db-8b21-d26d9c24586e", "", context.GetTheme( ));
            AssignProp("", true, imgavVehiculoimagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV49VehiculoImagen)) ? AV53Vehiculoimagen_GXI : context.convertURL( context.PathToRelativeUrl( AV49VehiculoImagen))), true);
            AssignProp("", true, imgavVehiculoimagen_Internalname, "SrcSet", context.GetImageSrcSet( AV49VehiculoImagen), true);
            AV53Vehiculoimagen_GXI = GXDbFile.PathToUrl( context.GetImagePath( "03f731fd-d1bc-45db-8b21-d26d9c24586e", "", context.GetTheme( )), context);
            AssignProp("", true, imgavVehiculoimagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV49VehiculoImagen)) ? AV53Vehiculoimagen_GXI : context.convertURL( context.PathToRelativeUrl( AV49VehiculoImagen))), true);
            AssignProp("", true, imgavVehiculoimagen_Internalname, "SrcSet", context.GetImageSrcSet( AV49VehiculoImagen), true);
            divTablevehiculo_Visible = 1;
            AssignProp("", true, divTablevehiculo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablevehiculo_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV48MudanzaVehiculoSugerido, context.GetMessage( "MEDIANO", "")) == 0 )
         {
            imgavVehiculoimagen_gximage = "Mediano";
            AssignProp("", true, imgavVehiculoimagen_Internalname, "gximage", imgavVehiculoimagen_gximage, true);
            AV49VehiculoImagen = context.GetImagePath( "08355b07-7cab-49e4-a0f3-2def6b5f6eee", "", context.GetTheme( ));
            AssignProp("", true, imgavVehiculoimagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV49VehiculoImagen)) ? AV53Vehiculoimagen_GXI : context.convertURL( context.PathToRelativeUrl( AV49VehiculoImagen))), true);
            AssignProp("", true, imgavVehiculoimagen_Internalname, "SrcSet", context.GetImageSrcSet( AV49VehiculoImagen), true);
            AV53Vehiculoimagen_GXI = GXDbFile.PathToUrl( context.GetImagePath( "08355b07-7cab-49e4-a0f3-2def6b5f6eee", "", context.GetTheme( )), context);
            AssignProp("", true, imgavVehiculoimagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV49VehiculoImagen)) ? AV53Vehiculoimagen_GXI : context.convertURL( context.PathToRelativeUrl( AV49VehiculoImagen))), true);
            AssignProp("", true, imgavVehiculoimagen_Internalname, "SrcSet", context.GetImageSrcSet( AV49VehiculoImagen), true);
            divTablevehiculo_Visible = 1;
            AssignProp("", true, divTablevehiculo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablevehiculo_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV48MudanzaVehiculoSugerido, context.GetMessage( "GRANDE", "")) == 0 )
         {
            imgavVehiculoimagen_gximage = "Grande";
            AssignProp("", true, imgavVehiculoimagen_Internalname, "gximage", imgavVehiculoimagen_gximage, true);
            AV49VehiculoImagen = context.GetImagePath( "105141fe-a868-4fa4-8be7-85f060b21aa8", "", context.GetTheme( ));
            AssignProp("", true, imgavVehiculoimagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV49VehiculoImagen)) ? AV53Vehiculoimagen_GXI : context.convertURL( context.PathToRelativeUrl( AV49VehiculoImagen))), true);
            AssignProp("", true, imgavVehiculoimagen_Internalname, "SrcSet", context.GetImageSrcSet( AV49VehiculoImagen), true);
            AV53Vehiculoimagen_GXI = GXDbFile.PathToUrl( context.GetImagePath( "105141fe-a868-4fa4-8be7-85f060b21aa8", "", context.GetTheme( )), context);
            AssignProp("", true, imgavVehiculoimagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV49VehiculoImagen)) ? AV53Vehiculoimagen_GXI : context.convertURL( context.PathToRelativeUrl( AV49VehiculoImagen))), true);
            AssignProp("", true, imgavVehiculoimagen_Internalname, "SrcSet", context.GetImageSrcSet( AV49VehiculoImagen), true);
            divTablevehiculo_Visible = 1;
            AssignProp("", true, divTablevehiculo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablevehiculo_Visible), 5, 0), true);
         }
         else
         {
            divTablevehiculo_Visible = 0;
            AssignProp("", true, divTablevehiculo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablevehiculo_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'DO SPANISHOPTION' Routine */
         returnInSub = false;
         if ( context.SetLanguage( "Spanish") == 0 )
         {
            AV35WebSession.Set("isLangLoaded", "true");
            context.DoAjaxRefresh();
         }
      }

      protected void S152( )
      {
         /* 'DO PORTUGUESEOPTION' Routine */
         returnInSub = false;
         if ( context.SetLanguage( "Portuguese") == 0 )
         {
            AV35WebSession.Set("isLangLoaded", "true");
            context.DoAjaxRefresh();
         }
      }

      protected void S162( )
      {
         /* 'DO ENGLISHOPTION' Routine */
         returnInSub = false;
         if ( context.SetLanguage( "English") == 0 )
         {
            AV35WebSession.Set("isLangLoaded", "true");
            context.DoAjaxRefresh();
         }
      }

      protected void S122( )
      {
         /* 'LOADNOTIFICATIONS' Routine */
         returnInSub = false;
         AV21NotificationsCount = 0;
         AV55Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Optimized group. */
         /* Using cursor H00GF3 */
         pr_default.execute(1, new Object[] {AV55Udparg1});
         cV21NotificationsCount = H00GF3_AV21NotificationsCount[0];
         pr_default.close(1);
         AV21NotificationsCount = (short)(AV21NotificationsCount+cV21NotificationsCount*1);
         /* End optimized group. */
         GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem5 = AV43Notificaciones;
         new onotificaciones(context ).execute(  AV5WWPContext.gxTpr_Usuariosid,  context.GetMessage( "N", ""),  context.GetMessage( "N", ""),  true, out  GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem5) ;
         AV43Notificaciones = GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem5;
         AV21NotificationsCount = (short)(AV43Notificaciones.Count+AV21NotificationsCount);
      }

      protected void S132( )
      {
         /* 'LOADBOOKMARKS' Routine */
         returnInSub = false;
         AV10BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV11BookmarksDataItem.gxTpr_Eventkey = "AddBookmark";
         AV11BookmarksDataItem.gxTpr_Isdivider = false;
         AV10BookmarksData.Add(AV11BookmarksDataItem, 0);
         AV16ProgramDescription = Contentholder.Pgmdesc;
         AV12CurrentURL = AV38Httprequest.BaseURL + AV38Httprequest.ScriptName + (String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV38Httprequest.QueryString))) ? "" : "?"+AV38Httprequest.QueryString);
         AV13GridStateCollection.FromXml(new GeneXus.Programs.wwpbaseobjects.loadmanagefiltersstate(context).executeUdp(  "AppBookmarks"), null, "Items", "");
         AV9BookmarkFound = false;
         AV56GXV2 = 1;
         while ( AV56GXV2 <= AV13GridStateCollection.Count )
         {
            AV14GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV13GridStateCollection.Item(AV56GXV2));
            if ( StringUtil.StrCmp(AV14GridStateCollectionItem.gxTpr_Gridstatexml, AV12CurrentURL) == 0 )
            {
               AV16ProgramDescription = AV14GridStateCollectionItem.gxTpr_Title;
               AV9BookmarkFound = true;
               if (true) break;
            }
            AV56GXV2 = (int)(AV56GXV2+1);
         }
         if ( AV9BookmarkFound )
         {
            AV11BookmarksDataItem.gxTpr_Title = context.GetMessage( "WWP_Bookmark_Edit", "");
            AV11BookmarksDataItem.gxTpr_Fonticon = "fas fa-star "+"FontColorIconBookmarkAdded";
         }
         else
         {
            AV11BookmarksDataItem.gxTpr_Title = context.GetMessage( "WWP_Bookmark_Add", "");
            AV11BookmarksDataItem.gxTpr_Fonticon = "far fa-star "+"FontColorIconBookmark";
         }
         if ( AV13GridStateCollection.Count > 0 )
         {
            AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV11BookmarksDataItem.gxTpr_Isdivider = true;
            AV10BookmarksData.Add(AV11BookmarksDataItem, 0);
            AV57GXV3 = 1;
            while ( AV57GXV3 <= AV13GridStateCollection.Count )
            {
               AV14GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV13GridStateCollection.Item(AV57GXV3));
               AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
               AV11BookmarksDataItem.gxTpr_Title = AV14GridStateCollectionItem.gxTpr_Title;
               AV11BookmarksDataItem.gxTpr_Link = AV14GridStateCollectionItem.gxTpr_Gridstatexml;
               GXt_char6 = AV17FontIcon;
               new GeneXus.Programs.wwpbaseobjects.getbookmarkfonticon(context ).execute(  StringUtil.StringReplace( AV14GridStateCollectionItem.gxTpr_Gridstatexml, AV38Httprequest.BaseURL, ""),  AV30DVelop_Menu, out  GXt_char6) ;
               AV17FontIcon = GXt_char6;
               AV11BookmarksDataItem.gxTpr_Fonticon = ((StringUtil.StrCmp(AV17FontIcon, "")==0) ? "FontColorIconBookmark fas fa-link" : "FontColorIconBookmark"+" "+AV17FontIcon);
               AV11BookmarksDataItem.gxTpr_Isdivider = false;
               AV10BookmarksData.Add(AV11BookmarksDataItem, 0);
               AV15IndexToAddItems = (short)(AV15IndexToAddItems+1);
               AssignAttri("", true, "AV15IndexToAddItems", StringUtil.LTrimStr( (decimal)(AV15IndexToAddItems), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV15IndexToAddItems), "ZZZ9"), context));
               AV57GXV3 = (int)(AV57GXV3+1);
            }
            AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV11BookmarksDataItem.gxTpr_Isdivider = true;
            AV10BookmarksData.Add(AV11BookmarksDataItem, 0);
            AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV11BookmarksDataItem.gxTpr_Title = context.GetMessage( "Bookmark manager", "");
            AV11BookmarksDataItem.gxTpr_Fonticon = "fas fa-cog "+"FontColorIconBookmark";
            AV11BookmarksDataItem.gxTpr_Eventkey = "ManageBookmarks";
            AV11BookmarksDataItem.gxTpr_Isdivider = false;
            AV10BookmarksData.Add(AV11BookmarksDataItem, 0);
         }
      }

      protected void S113( )
      {
         /* 'HTML CONTACTAR' Routine */
         returnInSub = false;
         lblHtml_Visible = 1;
         AssignProp("", true, lblHtml_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblHtml_Visible), 5, 0), true);
         lblHtml_Caption = context.GetMessage( "<a target=\"_blank\" href=\"https://api.whatsapp.com/send?phone=+59892761676&text=Hola soy\" id=\"whatsapp-button\" style=\"position: fixed; width: 50px; z-index: 999; bottom: 50px; right: 21px;\"><img style=\"width:100%;\" src=\"data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTkuMC4wLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iTGF5ZXJfMSIgeD0iMHB4IiB5PSIwcHgiIHZpZXdCb3g9IjAgMCA1MTIgNTEyIiBzdHlsZT0iZW5hYmxlLWJhY2tncm91bmQ6bmV3IDAgMCA1MTIgNTEyOyIgeG1sOnNwYWNlPSJwcmVzZXJ2ZSIgd2lkdGg9IjUxMnB4IiBoZWlnaHQ9IjUxMnB4Ij4KPHBhdGggc3R5bGU9ImZpbGw6I0VERURFRDsiIGQ9Ik0wLDUxMmwzNS4zMS0xMjhDMTIuMzU5LDM0NC4yNzYsMCwzMDAuMTM4LDAsMjU0LjIzNEMwLDExNC43NTksMTE0Ljc1OSwwLDI1NS4xMTcsMCAgUzUxMiwxMTQuNzU5LDUxMiwyNTQuMjM0UzM5NS40NzYsNTEyLDI1NS4xMTcsNTEyYy00NC4xMzgsMC04Ni41MS0xNC4xMjQtMTI0LjQ2OS0zNS4zMUwwLDUxMnoiLz4KPHBhdGggc3R5bGU9ImZpbGw6IzU1Q0Q2QzsiIGQ9Ik0xMzcuNzEsNDMwLjc4Nmw3Ljk0NSw0LjQxNGMzMi42NjIsMjAuMzAzLDcwLjYyMSwzMi42NjIsMTEwLjM0NSwzMi42NjIgIGMxMTUuNjQxLDAsMjExLjg2Mi05Ni4yMjEsMjExLjg2Mi0yMTMuNjI4UzM3MS42NDEsNDQuMTM4LDI1NS4xMTcsNDQuMTM4UzQ0LjEzOCwxMzcuNzEsNDQuMTM4LDI1NC4yMzQgIGMwLDQwLjYwNywxMS40NzYsODAuMzMxLDMyLjY2MiwxMTMuODc2bDUuMjk3LDcuOTQ1bC0yMC4zMDMsNzQuMTUyTDEzNy43MSw0MzAuNzg2eiIvPgo8cGF0aCBzdHlsZT0iZmlsbDojRkVGRUZFOyIgZD0iTTE4Ny4xNDUsMTM1Ljk0NWwtMTYuNzcyLTAuODgzYy01LjI5NywwLTEwLjU5MywxLjc2Ni0xNC4xMjQsNS4yOTcgIGMtNy45NDUsNy4wNjItMjEuMTg2LDIwLjMwMy0yNC43MTcsMzcuOTU5Yy02LjE3OSwyNi40ODMsMy41MzEsNTguMjYyLDI2LjQ4Myw5MC4wNDFzNjcuMDksODIuOTc5LDE0NC43NzIsMTA1LjA0OCAgYzI0LjcxNyw3LjA2Miw0NC4xMzgsMi42NDgsNjAuMDI4LTcuMDYyYzEyLjM1OS03Ljk0NSwyMC4zMDMtMjAuMzAzLDIyLjk1Mi0zMy41NDVsMi42NDgtMTIuMzU5ICBjMC44ODMtMy41MzEtMC44ODMtNy45NDUtNC40MTQtOS43MWwtNTUuNjE0LTI1LjZjLTMuNTMxLTEuNzY2LTcuOTQ1LTAuODgzLTEwLjU5MywyLjY0OGwtMjIuMDY5LDI4LjI0OCAgYy0xLjc2NiwxLjc2Ni00LjQxNCwyLjY0OC03LjA2MiwxLjc2NmMtMTUuMDA3LTUuMjk3LTY1LjMyNC0yNi40ODMtOTIuNjktNzkuNDQ4Yy0wLjg4My0yLjY0OC0wLjg4My01LjI5NywwLjg4My03LjA2MiAgbDIxLjE4Ni0yMy44MzRjMS43NjYtMi42NDgsMi42NDgtNi4xNzksMS43NjYtOC44MjhsLTI1LjYtNTcuMzc5QzE5My4zMjQsMTM4LjU5MywxOTAuNjc2LDEzNS45NDUsMTg3LjE0NSwxMzUuOTQ1Ii8+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+CjxnPgo8L2c+Cjwvc3ZnPgo=\">", "");
         AssignProp("", true, lblHtml_Internalname, "Caption", lblHtml_Caption, true);
      }

      protected void nextLoad( )
      {
      }

      protected void E17GF2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PAGF2( ) ;
         WSGF2( ) ;
         WEGF2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVMessage/DVMessage.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/fontawesome_vlatest/css/all.min.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?20269212253632", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/mudanzamasterpage.js", "?20269212253633", false, true, false);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Tooltip/BootstrapTooltipRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DatePicker/DatePickerRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgHeader_Internalname = "HEADER_MPAGE";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1_MPAGE";
         lblTamano_Internalname = "TAMANO_MPAGE";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5_MPAGE";
         imgavVehiculoimagen_Internalname = "vVEHICULOIMAGEN_MPAGE";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6_MPAGE";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4_MPAGE";
         divTablevehiculo_Internalname = "TABLEVEHICULO_MPAGE";
         lblTotal2_Internalname = "TOTAL2_MPAGE";
         lblTotalvalor_Internalname = "TOTALVALOR_MPAGE";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3_MPAGE";
         divTabletotal_Internalname = "TABLETOTAL_MPAGE";
         divTableuserrole_Internalname = "TABLEUSERROLE_MPAGE";
         divTableheader_Internalname = "TABLEHEADER_MPAGE";
         divTablecontent_Internalname = "TABLECONTENT_MPAGE";
         lblTextblockfooter_Internalname = "TEXTBLOCKFOOTER_MPAGE";
         divTablefooter_Internalname = "TABLEFOOTER_MPAGE";
         Ucmessage_Internalname = "UCMESSAGE_MPAGE";
         Uctooltip_Internalname = "UCTOOLTIP_MPAGE";
         Wwputilities_Internalname = "WWPUTILITIES_MPAGE";
         Wwpdatepicker_Internalname = "WWPDATEPICKER_MPAGE";
         lblHtml_Internalname = "HTML_MPAGE";
         divTablemain_Internalname = "TABLEMAIN_MPAGE";
         edtavPickerdummyvariable_Internalname = "vPICKERDUMMYVARIABLE_MPAGE";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS_MPAGE";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavPickerdummyvariable_Jsonclick = "";
         lblHtml_Caption = context.GetMessage( "HTML", "");
         lblHtml_Visible = 1;
         lblTotalvalor_Fontbold = 0;
         lblTotalvalor_Fontsize = (int)(Math.Round(12.0m, 18, MidpointRounding.ToEven));
         lblTotalvalor_Caption = " 0,00";
         lblTotal2_Forecolor = (int)(0x000000);
         lblTotal2_Fontsize = (int)(Math.Round(12.0m, 18, MidpointRounding.ToEven));
         divUnnamedtable3_Height = 50;
         divUnnamedtable3_Width = 170;
         divTabletotal_Visible = 1;
         imgavVehiculoimagen_gximage = "";
         divUnnamedtable6_Height = 45;
         divUnnamedtable6_Width = 60;
         lblTamano_Forecolor = (int)(0x000000);
         lblTamano_Caption = context.GetMessage( "CHICO", "");
         divUnnamedtable5_Height = 50;
         divUnnamedtable5_Width = 170;
         divTablevehiculo_Visible = 1;
         divLayoutmaintable_Class = "Table";
         Wwputilities_Comboloadtype = "InfiniteScrolling";
         Wwputilities_Pagbarincludegoto = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnsrestore = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumndragging = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnreordering = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnresizing = Convert.ToBoolean( -1);
         Wwputilities_Enableconvertcombotobootstrapselect = Convert.ToBoolean( -1);
         Wwputilities_Enableupdaterowselectionstatus = Convert.ToBoolean( -1);
         Wwputilities_Empowertabs = Convert.ToBoolean( -1);
         Wwputilities_Enablefloatinglabels = Convert.ToBoolean( -1);
         Wwputilities_Enablefixobjectfitcover = Convert.ToBoolean( -1);
         Ucmessage_Stoponerror = Convert.ToBoolean( -1);
         Contentholder.setDataArea(getDataAreaObject());
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
         setEventMetadata("REFRESH_MPAGE","{handler:'Refresh',iparms:[{av:'AV38Httprequest.BaseURL',ctrl:'vHTTPREQUEST_MPAGE',prop:'Baseurl'},{av:'AV30DVelop_Menu',fld:'vDVELOP_MENU_MPAGE',pic:'',hsh:true},{av:'AV34Breadcrumb',fld:'vBREADCRUMB_MPAGE',pic:'',hsh:true,type:'svchar'},{av:'AV15IndexToAddItems',fld:'vINDEXTOADDITEMS_MPAGE',pic:'ZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("REFRESH_MPAGE",",oparms:[{av:'AV34Breadcrumb',fld:'vBREADCRUMB_MPAGE',pic:'',hsh:true,type:'svchar'},{av:'AV15IndexToAddItems',fld:'vINDEXTOADDITEMS_MPAGE',pic:'ZZZ9',hsh:true,type:'int'}]}");
         setEventMetadata("GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE","{handler:'E14GF2',iparms:[]");
         setEventMetadata("GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE",",oparms:[]}");
         setEventMetadata("GLOBALEVENTS_MPAGE.ACTUALIZARTOTAL_MPAGE","{handler:'E15GF2',iparms:[{av:'AV45Total',fld:'vTOTAL_MPAGE',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'}]");
         setEventMetadata("GLOBALEVENTS_MPAGE.ACTUALIZARTOTAL_MPAGE",",oparms:[{av:'lblTotalvalor_Caption',ctrl:'TOTALVALOR_MPAGE',prop:'Caption'}]}");
         setEventMetadata("GLOBALEVENTS_MPAGE.ACTUALIZARVEHICULO_MPAGE","{handler:'E16GF2',iparms:[{av:'AV50TamanoVehiculo',fld:'vTAMANOVEHICULO_MPAGE',pic:'',type:'svchar'}]");
         setEventMetadata("GLOBALEVENTS_MPAGE.ACTUALIZARVEHICULO_MPAGE",",oparms:[{av:'lblTamano_Caption',ctrl:'TAMANO_MPAGE',prop:'Caption'},{av:'AV49VehiculoImagen',fld:'vVEHICULOIMAGEN_MPAGE',pic:'',type:'bits'},{av:'divTablevehiculo_Visible',ctrl:'TABLEVEHICULO_MPAGE',prop:'Visible'}]}");
         setEventMetadata("ONMESSAGE_GX1_MPAGE","{handler:'E13GF2',iparms:[{av:'AV18NotificationInfo',fld:'vNOTIFICATIONINFO_MPAGE',pic:''},{av:'A1WWPUserExtendedId',fld:'WWPUSEREXTENDEDID_MPAGE',pic:'',type:'char'},{av:'AV55Udparg1',fld:'vUDPARG1_MPAGE',pic:'',type:'char'},{av:'A91WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD_MPAGE',pic:'',type:'boolean'},{av:'AV5WWPContext',fld:'vWWPCONTEXT_MPAGE',pic:''}]");
         setEventMetadata("ONMESSAGE_GX1_MPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_PICKERDUMMYVARIABLE","{handler:'Validv_Pickerdummyvariable',iparms:[]");
         setEventMetadata("VALIDV_PICKERDUMMYVARIABLE",",oparms:[]}");
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
         Contentholder = new GXDataAreaControl();
         AV38Httprequest = new GxHttpRequest( context);
         AV18NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV30DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "AlmangoX");
         AV34Breadcrumb = "";
         GXKey = "";
         AV50TamanoVehiculo = "";
         A1WWPUserExtendedId = "";
         AV55Udparg1 = "";
         AV5WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         sPrefix = "";
         ClassString = "";
         imgHeader_gximage = "";
         StyleString = "";
         sImgUrl = "";
         lblTamano_Jsonclick = "";
         AV49VehiculoImagen = "";
         AV53Vehiculoimagen_GXI = "";
         lblTotal2_Jsonclick = "";
         lblTotalvalor_Jsonclick = "";
         lblTextblockfooter_Jsonclick = "";
         ucUcmessage = new GXUserControl();
         ucUctooltip = new GXUserControl();
         ucWwputilities = new GXUserControl();
         ucWwpdatepicker = new GXUserControl();
         lblHtml_Jsonclick = "";
         TempTags = "";
         AV42PickerDummyVariable = DateTime.MinValue;
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GX_FocusControl = "";
         AV31UserName = "";
         AV32RolesDescriptions = "";
         AV7SecRoleIdCollection = new GxSimpleCollection<short>();
         GXt_objcol_int1 = new GxSimpleCollection<short>();
         H00GF2_A16SecRoleId = new short[1] ;
         H00GF2_A25SecRoleName = new string[] {""} ;
         A25SecRoleName = "";
         GXt_objcol_SdtDVelop_Menu_Item2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "AlmangoX");
         AV33Language = "";
         AV35WebSession = context.GetSession();
         AV23WWP_DesignSystemSettings = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         GXt_SdtWWP_DesignSystemSettings3 = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         GXEncryptionTmp = "";
         AV19WWP_WebNotification = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
         AV20WWP_UserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         AV48MudanzaVehiculoSugerido = "";
         H00GF3_AV21NotificationsCount = new short[1] ;
         AV43Notificaciones = new GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem>( context, "NotificacionesSDTItem", "AlmangoX");
         GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem5 = new GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem>( context, "NotificacionesSDTItem", "AlmangoX");
         AV10BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV11BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV16ProgramDescription = "";
         AV12CurrentURL = "";
         AV13GridStateCollection = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item>( context, "Item", "");
         AV14GridStateCollectionItem = new GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item(context);
         AV17FontIcon = "";
         GXt_char6 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mudanzamasterpage__default(),
            new Object[][] {
                new Object[] {
               H00GF2_A16SecRoleId, H00GF2_A25SecRoleName
               }
               , new Object[] {
               H00GF3_AV21NotificationsCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short GxWebError ;
      private short AV15IndexToAddItems ;
      private short wbEnd ;
      private short wbStart ;
      private short lblTotalvalor_Fontbold ;
      private short nDonePA ;
      private short AV8SecRoleId ;
      private short A16SecRoleId ;
      private short AV21NotificationsCount ;
      private short cV21NotificationsCount ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int divTablevehiculo_Visible ;
      private int divUnnamedtable5_Width ;
      private int divUnnamedtable5_Height ;
      private int lblTamano_Forecolor ;
      private int divUnnamedtable6_Width ;
      private int divUnnamedtable6_Height ;
      private int divTabletotal_Visible ;
      private int divUnnamedtable3_Width ;
      private int divUnnamedtable3_Height ;
      private int lblTotal2_Fontsize ;
      private int lblTotal2_Forecolor ;
      private int lblTotalvalor_Fontsize ;
      private int lblHtml_Visible ;
      private int AV51GXV1 ;
      private int AV56GXV2 ;
      private int AV57GXV3 ;
      private int idxLst ;
      private decimal AV45Total ;
      private string GXKey ;
      private string A1WWPUserExtendedId ;
      private string AV55Udparg1 ;
      private string Wwputilities_Comboloadtype ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string ClassString ;
      private string imgHeader_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgHeader_Internalname ;
      private string divTablevehiculo_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string divUnnamedtable5_Internalname ;
      private string lblTamano_Internalname ;
      private string lblTamano_Caption ;
      private string lblTamano_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string imgavVehiculoimagen_gximage ;
      private string imgavVehiculoimagen_Internalname ;
      private string divTabletotal_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string lblTotal2_Internalname ;
      private string lblTotal2_Jsonclick ;
      private string lblTotalvalor_Internalname ;
      private string lblTotalvalor_Caption ;
      private string lblTotalvalor_Jsonclick ;
      private string divTableuserrole_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTablefooter_Internalname ;
      private string lblTextblockfooter_Internalname ;
      private string lblTextblockfooter_Jsonclick ;
      private string Ucmessage_Internalname ;
      private string Uctooltip_Internalname ;
      private string Wwputilities_Internalname ;
      private string Wwpdatepicker_Internalname ;
      private string lblHtml_Internalname ;
      private string lblHtml_Caption ;
      private string lblHtml_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string TempTags ;
      private string edtavPickerdummyvariable_Internalname ;
      private string edtavPickerdummyvariable_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GX_FocusControl ;
      private string GXEncryptionTmp ;
      private string GXt_char6 ;
      private string sDynURL ;
      private DateTime AV42PickerDummyVariable ;
      private bool AV47Ocultar ;
      private bool A91WWPNotificationIsRead ;
      private bool Ucmessage_Stoponerror ;
      private bool Wwputilities_Enablefixobjectfitcover ;
      private bool Wwputilities_Enablefloatinglabels ;
      private bool Wwputilities_Empowertabs ;
      private bool Wwputilities_Enableupdaterowselectionstatus ;
      private bool Wwputilities_Enableconvertcombotobootstrapselect ;
      private bool Wwputilities_Allowcolumnresizing ;
      private bool Wwputilities_Allowcolumnreordering ;
      private bool Wwputilities_Allowcolumndragging ;
      private bool Wwputilities_Allowcolumnsrestore ;
      private bool Wwputilities_Pagbarincludegoto ;
      private bool wbLoad ;
      private bool AV49VehiculoImagen_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV39IsAuthorized ;
      private bool GXt_boolean4 ;
      private bool AV9BookmarkFound ;
      private string AV34Breadcrumb ;
      private string AV50TamanoVehiculo ;
      private string AV53Vehiculoimagen_GXI ;
      private string AV31UserName ;
      private string AV32RolesDescriptions ;
      private string A25SecRoleName ;
      private string AV33Language ;
      private string AV48MudanzaVehiculoSugerido ;
      private string AV16ProgramDescription ;
      private string AV12CurrentURL ;
      private string AV17FontIcon ;
      private string AV49VehiculoImagen ;
      private IGxSession AV35WebSession ;
      private GXUserControl ucUcmessage ;
      private GXUserControl ucUctooltip ;
      private GXUserControl ucWwputilities ;
      private GXUserControl ucWwpdatepicker ;
      private GxHttpRequest AV38Httprequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contentholder ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV18NotificationInfo ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV30DVelop_Menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV5WWPContext ;
      private GxSimpleCollection<short> AV7SecRoleIdCollection ;
      private GxSimpleCollection<short> GXt_objcol_int1 ;
      private IDataStoreProvider pr_default ;
      private short[] H00GF2_A16SecRoleId ;
      private string[] H00GF2_A25SecRoleName ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings AV23WWP_DesignSystemSettings ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings GXt_SdtWWP_DesignSystemSettings3 ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification AV19WWP_WebNotification ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV20WWP_UserExtended ;
      private short[] H00GF3_AV21NotificationsCount ;
      private GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem> AV43Notificaciones ;
      private GXBaseCollection<SdtNotificacionesSDT_NotificacionesSDTItem> GXt_objcol_SdtNotificacionesSDT_NotificacionesSDTItem5 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV10BookmarksData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV11BookmarksDataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item> AV13GridStateCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item AV14GridStateCollectionItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class mudanzamasterpage__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00GF2;
          prmH00GF2 = new Object[] {
          new ParDef("@AV8SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmH00GF3;
          prmH00GF3 = new Object[] {
          new ParDef("@AV55Udparg1",GXType.NChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00GF2", "SELECT TOP 1 [SecRoleId], [SecRoleName] FROM [SecRole] WHERE [SecRoleId] = @AV8SecRoleId ORDER BY [SecRoleId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GF2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00GF3", "SELECT COUNT(*) FROM [WWP_Notification] WHERE ([WWPUserExtendedId] = @AV55Udparg1) AND (Not [WWPNotificationIsRead] = 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00GF3,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}

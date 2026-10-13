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
   public class rubrosmedidas : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            GXDLARUBROSID0U37( ) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_medidas") == 0 )
         {
            gxnrGridlevel_medidas_newrow_invoke( ) ;
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
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7RubrosId", StringUtil.LTrimStr( (decimal)(AV7RubrosId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vRUBROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RubrosId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
         Form.Meta.addItem("description", context.GetMessage( "Rubros Medidas y Precios", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_medidas_newrow_invoke( )
      {
         nRC_GXsfl_38 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_38"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_38_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_38_idx = GetPar( "sGXsfl_38_idx");
         A217RubrosMedidasSerial = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosMedidasSerial"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_medidas_newrow( ) ;
         /* End function gxnrGridlevel_medidas_newrow_invoke */
      }

      public rubrosmedidas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public rubrosmedidas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_RubrosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7RubrosId = aP1_RubrosId;
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
         cmbRubrosEstado = new GXCombobox();
         dynMonedaId = new GXCombobox();
         cmbMedidasEstado = new GXCombobox();
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
         if ( dynRubrosId.ItemCount > 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
            AssignProp("", false, dynRubrosId_Internalname, "Values", dynRubrosId.ToJavascriptSource(), true);
         }
         if ( cmbRubrosEstado.ItemCount > 0 )
         {
            A123RubrosEstado = cmbRubrosEstado.getValidValue(A123RubrosEstado);
            n123RubrosEstado = false;
            AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRubrosEstado.CurrentValue = StringUtil.RTrim( A123RubrosEstado);
            AssignProp("", false, cmbRubrosEstado_Internalname, "Values", cmbRubrosEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynRubrosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynRubrosId_Internalname, context.GetMessage( "Rubro", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynRubrosId, dynRubrosId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0)), 1, dynRubrosId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynRubrosId.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_RubrosMedidas.htm");
         dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
         AssignProp("", false, dynRubrosId_Internalname, "Values", (string)(dynRubrosId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbRubrosEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbRubrosEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbRubrosEstado, cmbRubrosEstado_Internalname, StringUtil.RTrim( A123RubrosEstado), 1, cmbRubrosEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbRubrosEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_RubrosMedidas.htm");
         cmbRubrosEstado.CurrentValue = StringUtil.RTrim( A123RubrosEstado);
         AssignProp("", false, cmbRubrosEstado_Internalname, "Values", (string)(cmbRubrosEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgRubrosImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A168RubrosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000RubrosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen));
         GxWebStd.gx_bitmap( context, imgRubrosImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgRubrosImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", "", "", 0, A168RubrosImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_RubrosMedidas.htm");
         AssignProp("", false, imgRubrosImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen)), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A168RubrosImagen_IsBlob), true);
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
         GxWebStd.gx_div_start( context, divTableleaflevel_medidas_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_medidas( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_RubrosMedidas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_RubrosMedidas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_RubrosMedidas.htm");
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

      protected void gxdraw_Gridlevel_medidas( )
      {
         /*  Grid Control  */
         StartGridControl38( ) ;
         nGXsfl_38_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount26 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_26 = 1;
               ScanStart0U26( ) ;
               while ( RcdFound26 != 0 )
               {
                  init_level_properties26( ) ;
                  getByPrimaryKey0U26( ) ;
                  AddRow0U26( ) ;
                  ScanNext0U26( ) ;
               }
               ScanEnd0U26( ) ;
               nBlankRcdCount26 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B217RubrosMedidasSerial = A217RubrosMedidasSerial;
            AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
            standaloneNotModal0U26( ) ;
            standaloneModal0U26( ) ;
            sMode26 = Gx_mode;
            while ( nGXsfl_38_idx < nRC_GXsfl_38 )
            {
               bGXsfl_38_Refreshing = true;
               ReadRow0U26( ) ;
               edtMedidasID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidasID_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtMedidasNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASNOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMedidasNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidasNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               dynMonedaId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MONEDAID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtRubrosCosto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSCOSTO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtRubrosCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosCosto_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtRubrosPrecioBase_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSPRECIOBASE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtRubrosPrecioBase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosPrecioBase_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               cmbMedidasEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASESTADO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbMedidasEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMedidasEstado.Enabled), 5, 0), !bGXsfl_38_Refreshing);
               edtMedidasImagen_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASIMAGEN_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMedidasImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidasImagen_Enabled), 5, 0), !bGXsfl_38_Refreshing);
               if ( ( nRcdExists_26 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0U26( ) ;
               }
               SendRow0U26( ) ;
               bGXsfl_38_Refreshing = false;
            }
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A217RubrosMedidasSerial = B217RubrosMedidasSerial;
            AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount26 = 5;
            nRcdExists_26 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0U26( ) ;
               while ( RcdFound26 != 0 )
               {
                  sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_3826( ) ;
                  init_level_properties26( ) ;
                  standaloneNotModal0U26( ) ;
                  getByPrimaryKey0U26( ) ;
                  standaloneModal0U26( ) ;
                  AddRow0U26( ) ;
                  ScanNext0U26( ) ;
               }
               ScanEnd0U26( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode26 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx+1), 4, 0), 4, "0");
            SubsflControlProps_3826( ) ;
            InitAll0U26( ) ;
            init_level_properties26( ) ;
            B217RubrosMedidasSerial = A217RubrosMedidasSerial;
            AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
            nRcdExists_26 = 0;
            nIsMod_26 = 0;
            nRcdDeleted_26 = 0;
            nBlankRcdCount26 = (short)(nBlankRcdUsr26+nBlankRcdCount26);
            fRowAdded = 0;
            while ( nBlankRcdCount26 > 0 )
            {
               standaloneNotModal0U26( ) ;
               standaloneModal0U26( ) ;
               AddRow0U26( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtMedidasNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount26 = (short)(nBlankRcdCount26-1);
            }
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A217RubrosMedidasSerial = B217RubrosMedidasSerial;
            AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_medidasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_medidas", Gridlevel_medidasContainer, subGridlevel_medidas_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_medidasContainerData", Gridlevel_medidasContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_medidasContainerData"+"V", Gridlevel_medidasContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_medidasContainerData"+"V"+"\" value='"+Gridlevel_medidasContainer.GridValuesHidden()+"'/>") ;
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
         E110U2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z121RubrosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z122RubrosNombre = cgiGet( "Z122RubrosNombre");
               Z217RubrosMedidasSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z217RubrosMedidasSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z123RubrosEstado = cgiGet( "Z123RubrosEstado");
               n123RubrosEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A123RubrosEstado)) ? true : false);
               A122RubrosNombre = cgiGet( "Z122RubrosNombre");
               A217RubrosMedidasSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z217RubrosMedidasSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O217RubrosMedidasSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O217RubrosMedidasSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_38 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_38"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A122RubrosNombre = cgiGet( "RUBROSNOMBRE");
               A40000RubrosImagen_GXI = cgiGet( "RUBROSIMAGEN_GXI");
               A217RubrosMedidasSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSMEDIDASSERIAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40001MedidasImagen_GXI = cgiGet( "MEDIDASIMAGEN_GXI");
               n40001MedidasImagen_GXI = false;
               n40001MedidasImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40001MedidasImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)) ? true : false);
               A150TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "TEXTOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n150TextosId = false;
               n150TextosId = ((0==A150TextosId) ? true : false);
               A259TextosTitulo = cgiGet( "TEXTOSTITULO");
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
               dynRubrosId.Name = dynRubrosId_Internalname;
               dynRubrosId.CurrentValue = cgiGet( dynRubrosId_Internalname);
               A121RubrosId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynRubrosId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
               cmbRubrosEstado.Name = cmbRubrosEstado_Internalname;
               cmbRubrosEstado.CurrentValue = cgiGet( cmbRubrosEstado_Internalname);
               A123RubrosEstado = cgiGet( cmbRubrosEstado_Internalname);
               n123RubrosEstado = false;
               AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
               n123RubrosEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A123RubrosEstado)) ? true : false);
               A168RubrosImagen = cgiGet( imgRubrosImagen_Internalname);
               AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgRubrosImagen_Internalname, ref  A168RubrosImagen, ref  A40000RubrosImagen_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"RubrosMedidas");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("RubrosNombre", StringUtil.RTrim( context.localUtil.Format( A122RubrosNombre, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A121RubrosId != Z121RubrosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("rubrosmedidas:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
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
                     sMode37 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode37;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound37 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0U0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "RUBROSID");
                        AnyError = 1;
                        GX_FocusControl = dynRubrosId_Internalname;
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
                           E110U2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120U2 ();
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
            E120U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0U37( ) ;
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
            DisableAttributes0U37( ) ;
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

      protected void CONFIRM_0U0( )
      {
         BeforeValidate0U37( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0U37( ) ;
            }
            else
            {
               CheckExtendedTable0U37( ) ;
               CloseExtendedTableCursors0U37( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode37 = Gx_mode;
            CONFIRM_0U26( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode37;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0U26( )
      {
         s217RubrosMedidasSerial = O217RubrosMedidasSerial;
         AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
         nGXsfl_38_idx = 0;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            ReadRow0U26( ) ;
            if ( ( nRcdExists_26 != 0 ) || ( nIsMod_26 != 0 ) )
            {
               GetKey0U26( ) ;
               if ( ( nRcdExists_26 == 0 ) && ( nRcdDeleted_26 == 0 ) )
               {
                  if ( RcdFound26 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0U26( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0U26( ) ;
                        CloseExtendedTableCursors0U26( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O217RubrosMedidasSerial = A217RubrosMedidasSerial;
                        AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "RUBROSID");
                     AnyError = 1;
                     GX_FocusControl = dynRubrosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound26 != 0 )
                  {
                     if ( nRcdDeleted_26 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0U26( ) ;
                        Load0U26( ) ;
                        BeforeValidate0U26( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0U26( ) ;
                           O217RubrosMedidasSerial = A217RubrosMedidasSerial;
                           AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_26 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0U26( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0U26( ) ;
                              CloseExtendedTableCursors0U26( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O217RubrosMedidasSerial = A217RubrosMedidasSerial;
                              AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_26 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RUBROSID");
                        AnyError = 1;
                        GX_FocusControl = dynRubrosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtMedidasNombre_Internalname, StringUtil.RTrim( A138MedidasNombre)) ;
            ChangePostValue( dynMonedaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))) ;
            ChangePostValue( edtRubrosCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A215RubrosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtRubrosPrecioBase_Internalname, StringUtil.LTrim( StringUtil.NToC( A216RubrosPrecioBase, 21, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbMedidasEstado_Internalname, StringUtil.RTrim( A139MedidasEstado)) ;
            ChangePostValue( edtMedidasImagen_Internalname, A842MedidasImagen) ;
            ChangePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z139MedidasEstado_"+sGXsfl_38_idx, StringUtil.RTrim( Z139MedidasEstado)) ;
            ChangePostValue( "ZT_"+"Z138MedidasNombre_"+sGXsfl_38_idx, StringUtil.RTrim( Z138MedidasNombre)) ;
            ChangePostValue( "ZT_"+"Z215RubrosCosto_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( Z215RubrosCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z216RubrosPrecioBase_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( Z216RubrosPrecioBase, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z150TextosId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z150TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z118MonedaId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_26_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_26), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_26_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_26), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_26_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_26), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_26 != 0 )
            {
               ChangePostValue( "MEDIDASID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MONEDAID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMonedaId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSCOSTO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosCosto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSPRECIOBASE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosPrecioBase_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASESTADO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMedidasEstado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASIMAGEN_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasImagen_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O217RubrosMedidasSerial = s217RubrosMedidasSerial;
         AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0U0( )
      {
      }

      protected void E110U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("rubrosmedidasww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0U37( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z122RubrosNombre = T000U7_A122RubrosNombre[0];
               Z217RubrosMedidasSerial = T000U7_A217RubrosMedidasSerial[0];
               Z123RubrosEstado = T000U7_A123RubrosEstado[0];
            }
            else
            {
               Z122RubrosNombre = A122RubrosNombre;
               Z217RubrosMedidasSerial = A217RubrosMedidasSerial;
               Z123RubrosEstado = A123RubrosEstado;
            }
         }
         if ( GX_JID == -10 )
         {
            Z121RubrosId = A121RubrosId;
            Z122RubrosNombre = A122RubrosNombre;
            Z168RubrosImagen = A168RubrosImagen;
            Z40000RubrosImagen_GXI = A40000RubrosImagen_GXI;
            Z217RubrosMedidasSerial = A217RubrosMedidasSerial;
            Z123RubrosEstado = A123RubrosEstado;
         }
      }

      protected void standaloneNotModal( )
      {
         GXARUBROSID_html0U37( ) ;
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7RubrosId) )
         {
            A121RubrosId = AV7RubrosId;
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
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

      protected void Load0U37( )
      {
         /* Using cursor T000U8 */
         pr_default.execute(6, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound37 = 1;
            A122RubrosNombre = T000U8_A122RubrosNombre[0];
            A40000RubrosImagen_GXI = T000U8_A40000RubrosImagen_GXI[0];
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A217RubrosMedidasSerial = T000U8_A217RubrosMedidasSerial[0];
            A123RubrosEstado = T000U8_A123RubrosEstado[0];
            n123RubrosEstado = T000U8_n123RubrosEstado[0];
            AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
            A168RubrosImagen = T000U8_A168RubrosImagen[0];
            AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            ZM0U37( -10) ;
         }
         pr_default.close(6);
         OnLoadActions0U37( ) ;
      }

      protected void OnLoadActions0U37( )
      {
      }

      protected void CheckExtendedTable0U37( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A123RubrosEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A123RubrosEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A123RubrosEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A123RubrosEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A123RubrosEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "RUBROSESTADO");
            AnyError = 1;
            GX_FocusControl = cmbRubrosEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0U37( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0U37( )
      {
         /* Using cursor T000U9 */
         pr_default.execute(7, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound37 = 1;
         }
         else
         {
            RcdFound37 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000U7 */
         pr_default.execute(5, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0U37( 10) ;
            RcdFound37 = 1;
            A121RubrosId = T000U7_A121RubrosId[0];
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            A122RubrosNombre = T000U7_A122RubrosNombre[0];
            A40000RubrosImagen_GXI = T000U7_A40000RubrosImagen_GXI[0];
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A217RubrosMedidasSerial = T000U7_A217RubrosMedidasSerial[0];
            A123RubrosEstado = T000U7_A123RubrosEstado[0];
            n123RubrosEstado = T000U7_n123RubrosEstado[0];
            AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
            A168RubrosImagen = T000U7_A168RubrosImagen[0];
            AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            O217RubrosMedidasSerial = A217RubrosMedidasSerial;
            AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
            Z121RubrosId = A121RubrosId;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0U37( ) ;
            if ( AnyError == 1 )
            {
               RcdFound37 = 0;
               InitializeNonKey0U37( ) ;
            }
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey0U37( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0U37( ) ;
         if ( RcdFound37 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound37 = 0;
         /* Using cursor T000U10 */
         pr_default.execute(8, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000U10_A121RubrosId[0] < A121RubrosId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000U10_A121RubrosId[0] > A121RubrosId ) ) )
            {
               A121RubrosId = T000U10_A121RubrosId[0];
               AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
               RcdFound37 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound37 = 0;
         /* Using cursor T000U11 */
         pr_default.execute(9, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000U11_A121RubrosId[0] > A121RubrosId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000U11_A121RubrosId[0] < A121RubrosId ) ) )
            {
               A121RubrosId = T000U11_A121RubrosId[0];
               AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
               RcdFound37 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0U37( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A217RubrosMedidasSerial = O217RubrosMedidasSerial;
            AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0U37( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound37 == 1 )
            {
               if ( A121RubrosId != Z121RubrosId )
               {
                  A121RubrosId = Z121RubrosId;
                  AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RUBROSID");
                  AnyError = 1;
                  GX_FocusControl = dynRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A217RubrosMedidasSerial = O217RubrosMedidasSerial;
                  AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = dynRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A217RubrosMedidasSerial = O217RubrosMedidasSerial;
                  AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
                  Update0U37( ) ;
                  GX_FocusControl = dynRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A121RubrosId != Z121RubrosId )
               {
                  /* Insert record */
                  A217RubrosMedidasSerial = O217RubrosMedidasSerial;
                  AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
                  GX_FocusControl = dynRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0U37( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RUBROSID");
                     AnyError = 1;
                     GX_FocusControl = dynRubrosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A217RubrosMedidasSerial = O217RubrosMedidasSerial;
                     AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
                     GX_FocusControl = dynRubrosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0U37( ) ;
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
         if ( A121RubrosId != Z121RubrosId )
         {
            A121RubrosId = Z121RubrosId;
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A217RubrosMedidasSerial = O217RubrosMedidasSerial;
            AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0U37( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000U6 */
            pr_default.execute(4, new Object[] {A121RubrosId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Rubros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z122RubrosNombre, T000U6_A122RubrosNombre[0]) != 0 ) || ( Z217RubrosMedidasSerial != T000U6_A217RubrosMedidasSerial[0] ) || ( StringUtil.StrCmp(Z123RubrosEstado, T000U6_A123RubrosEstado[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z122RubrosNombre, T000U6_A122RubrosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("rubrosmedidas:[seudo value changed for attri]"+"RubrosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z122RubrosNombre);
                  GXUtil.WriteLogRaw("Current: ",T000U6_A122RubrosNombre[0]);
               }
               if ( Z217RubrosMedidasSerial != T000U6_A217RubrosMedidasSerial[0] )
               {
                  GXUtil.WriteLog("rubrosmedidas:[seudo value changed for attri]"+"RubrosMedidasSerial");
                  GXUtil.WriteLogRaw("Old: ",Z217RubrosMedidasSerial);
                  GXUtil.WriteLogRaw("Current: ",T000U6_A217RubrosMedidasSerial[0]);
               }
               if ( StringUtil.StrCmp(Z123RubrosEstado, T000U6_A123RubrosEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("rubrosmedidas:[seudo value changed for attri]"+"RubrosEstado");
                  GXUtil.WriteLogRaw("Old: ",Z123RubrosEstado);
                  GXUtil.WriteLogRaw("Current: ",T000U6_A123RubrosEstado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Rubros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U37( )
      {
         BeforeValidate0U37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U37( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U37( 0) ;
            CheckOptimisticConcurrency0U37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U12 */
                     pr_default.execute(10, new Object[] {A122RubrosNombre, A168RubrosImagen, A40000RubrosImagen_GXI, A217RubrosMedidasSerial, n123RubrosEstado, A123RubrosEstado});
                     A121RubrosId = T000U12_A121RubrosId[0];
                     AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Rubros");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0U37( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0U0( ) ;
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
               Load0U37( ) ;
            }
            EndLevel0U37( ) ;
         }
         CloseExtendedTableCursors0U37( ) ;
      }

      protected void Update0U37( )
      {
         BeforeValidate0U37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U37( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0U37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U13 */
                     pr_default.execute(11, new Object[] {A122RubrosNombre, A217RubrosMedidasSerial, n123RubrosEstado, A123RubrosEstado, A121RubrosId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Rubros");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Rubros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0U37( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0U37( ) ;
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
            EndLevel0U37( ) ;
         }
         CloseExtendedTableCursors0U37( ) ;
      }

      protected void DeferredUpdate0U37( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000U14 */
            pr_default.execute(12, new Object[] {A168RubrosImagen, A40000RubrosImagen_GXI, A121RubrosId});
            pr_default.close(12);
            pr_default.SmartCacheProvider.SetUpdated("Rubros");
         }
      }

      protected void delete( )
      {
         BeforeValidate0U37( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U37( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U37( ) ;
            AfterConfirm0U37( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U37( ) ;
               if ( AnyError == 0 )
               {
                  A217RubrosMedidasSerial = O217RubrosMedidasSerial;
                  AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
                  ScanStart0U26( ) ;
                  while ( RcdFound26 != 0 )
                  {
                     getByPrimaryKey0U26( ) ;
                     Delete0U26( ) ;
                     ScanNext0U26( ) ;
                     O217RubrosMedidasSerial = A217RubrosMedidasSerial;
                     AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
                  }
                  ScanEnd0U26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U15 */
                     pr_default.execute(13, new Object[] {A121RubrosId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Rubros");
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
         sMode37 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0U37( ) ;
         Gx_mode = sMode37;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0U37( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000U16 */
            pr_default.execute(14, new Object[] {A121RubrosId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Capacidad Productiva", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000U17 */
            pr_default.execute(15, new Object[] {A121RubrosId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000U18 */
            pr_default.execute(16, new Object[] {A121RubrosId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Inventario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void ProcessNestedLevel0U26( )
      {
         s217RubrosMedidasSerial = O217RubrosMedidasSerial;
         AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
         nGXsfl_38_idx = 0;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            ReadRow0U26( ) ;
            if ( ( nRcdExists_26 != 0 ) || ( nIsMod_26 != 0 ) )
            {
               standaloneNotModal0U26( ) ;
               GetKey0U26( ) ;
               if ( ( nRcdExists_26 == 0 ) && ( nRcdDeleted_26 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0U26( ) ;
               }
               else
               {
                  if ( RcdFound26 != 0 )
                  {
                     if ( ( nRcdDeleted_26 != 0 ) && ( nRcdExists_26 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0U26( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_26 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0U26( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_26 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RUBROSID");
                        AnyError = 1;
                        GX_FocusControl = dynRubrosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O217RubrosMedidasSerial = A217RubrosMedidasSerial;
               AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
            }
            ChangePostValue( edtMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtMedidasNombre_Internalname, StringUtil.RTrim( A138MedidasNombre)) ;
            ChangePostValue( dynMonedaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))) ;
            ChangePostValue( edtRubrosCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A215RubrosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtRubrosPrecioBase_Internalname, StringUtil.LTrim( StringUtil.NToC( A216RubrosPrecioBase, 21, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbMedidasEstado_Internalname, StringUtil.RTrim( A139MedidasEstado)) ;
            ChangePostValue( edtMedidasImagen_Internalname, A842MedidasImagen) ;
            ChangePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z139MedidasEstado_"+sGXsfl_38_idx, StringUtil.RTrim( Z139MedidasEstado)) ;
            ChangePostValue( "ZT_"+"Z138MedidasNombre_"+sGXsfl_38_idx, StringUtil.RTrim( Z138MedidasNombre)) ;
            ChangePostValue( "ZT_"+"Z215RubrosCosto_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( Z215RubrosCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z216RubrosPrecioBase_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( Z216RubrosPrecioBase, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z150TextosId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z150TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z118MonedaId_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_26_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_26), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_26_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_26), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_26_"+sGXsfl_38_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_26), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_26 != 0 )
            {
               ChangePostValue( "MEDIDASID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MONEDAID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMonedaId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSCOSTO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosCosto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSPRECIOBASE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosPrecioBase_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASESTADO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMedidasEstado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASIMAGEN_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasImagen_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0U26( ) ;
         if ( AnyError != 0 )
         {
            O217RubrosMedidasSerial = s217RubrosMedidasSerial;
            AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
         }
         nRcdExists_26 = 0;
         nIsMod_26 = 0;
         nRcdDeleted_26 = 0;
      }

      protected void ProcessLevel0U37( )
      {
         /* Save parent mode. */
         sMode37 = Gx_mode;
         ProcessNestedLevel0U26( ) ;
         if ( AnyError != 0 )
         {
            O217RubrosMedidasSerial = s217RubrosMedidasSerial;
            AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode37;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000U19 */
         pr_default.execute(17, new Object[] {A217RubrosMedidasSerial, A121RubrosId});
         pr_default.close(17);
         pr_default.SmartCacheProvider.SetUpdated("Rubros");
      }

      protected void EndLevel0U37( )
      {
         pr_default.close(4);
         if ( AnyError == 0 )
         {
            BeforeComplete0U37( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("rubrosmedidas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0U0( ) ;
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
            context.RollbackDataStores("rubrosmedidas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0U37( )
      {
         /* Scan By routine */
         /* Using cursor T000U20 */
         pr_default.execute(18);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound37 = 1;
            A121RubrosId = T000U20_A121RubrosId[0];
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0U37( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound37 = 1;
            A121RubrosId = T000U20_A121RubrosId[0];
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
         }
      }

      protected void ScanEnd0U37( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0U37( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U37( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0U37( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0U37( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0U37( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0U37( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U37( )
      {
         dynRubrosId.Enabled = 0;
         AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), true);
         cmbRubrosEstado.Enabled = 0;
         AssignProp("", false, cmbRubrosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRubrosEstado.Enabled), 5, 0), true);
         imgRubrosImagen_Enabled = 0;
         AssignProp("", false, imgRubrosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgRubrosImagen_Enabled), 5, 0), true);
      }

      protected void ZM0U26( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z139MedidasEstado = T000U3_A139MedidasEstado[0];
               Z138MedidasNombre = T000U3_A138MedidasNombre[0];
               Z215RubrosCosto = T000U3_A215RubrosCosto[0];
               Z216RubrosPrecioBase = T000U3_A216RubrosPrecioBase[0];
               Z150TextosId = T000U3_A150TextosId[0];
               Z118MonedaId = T000U3_A118MonedaId[0];
            }
            else
            {
               Z139MedidasEstado = A139MedidasEstado;
               Z138MedidasNombre = A138MedidasNombre;
               Z215RubrosCosto = A215RubrosCosto;
               Z216RubrosPrecioBase = A216RubrosPrecioBase;
               Z150TextosId = A150TextosId;
               Z118MonedaId = A118MonedaId;
            }
         }
         if ( GX_JID == -11 )
         {
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z139MedidasEstado = A139MedidasEstado;
            Z138MedidasNombre = A138MedidasNombre;
            Z842MedidasImagen = A842MedidasImagen;
            Z40001MedidasImagen_GXI = A40001MedidasImagen_GXI;
            Z215RubrosCosto = A215RubrosCosto;
            Z216RubrosPrecioBase = A216RubrosPrecioBase;
            Z150TextosId = A150TextosId;
            Z118MonedaId = A118MonedaId;
            Z259TextosTitulo = A259TextosTitulo;
         }
      }

      protected void standaloneNotModal0U26( )
      {
         edtMedidasID_Enabled = 0;
         AssignProp("", false, edtMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidasID_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         dynMonedaId.Enabled = 0;
         AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void standaloneModal0U26( )
      {
         if ( IsIns( )  )
         {
            A217RubrosMedidasSerial = (short)(O217RubrosMedidasSerial+1);
            AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A137MedidasID = A217RubrosMedidasSerial;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A139MedidasEstado)) && ( Gx_BScreen == 0 ) )
         {
            A139MedidasEstado = "HAB";
            n139MedidasEstado = false;
         }
         /* Using cursor T000U4 */
         pr_default.execute(2, new Object[] {n150TextosId, A150TextosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A150TextosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Textos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TEXTOSID");
               AnyError = 1;
            }
         }
         A259TextosTitulo = T000U4_A259TextosTitulo[0];
         pr_default.close(2);
         /* Using cursor T000U5 */
         pr_default.execute(3, new Object[] {A118MonedaId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "MONEDAID_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( " T12", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         pr_default.close(3);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0U26( )
      {
         /* Using cursor T000U21 */
         pr_default.execute(19, new Object[] {A121RubrosId, A137MedidasID});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound26 = 1;
            A139MedidasEstado = T000U21_A139MedidasEstado[0];
            n139MedidasEstado = T000U21_n139MedidasEstado[0];
            A138MedidasNombre = T000U21_A138MedidasNombre[0];
            A40001MedidasImagen_GXI = T000U21_A40001MedidasImagen_GXI[0];
            n40001MedidasImagen_GXI = T000U21_n40001MedidasImagen_GXI[0];
            AssignProp("", false, edtMedidasImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)) ? A40001MedidasImagen_GXI : context.convertURL( context.PathToRelativeUrl( A842MedidasImagen))), !bGXsfl_38_Refreshing);
            AssignProp("", false, edtMedidasImagen_Internalname, "SrcSet", context.GetImageSrcSet( A842MedidasImagen), true);
            A215RubrosCosto = T000U21_A215RubrosCosto[0];
            A216RubrosPrecioBase = T000U21_A216RubrosPrecioBase[0];
            A259TextosTitulo = T000U21_A259TextosTitulo[0];
            A150TextosId = T000U21_A150TextosId[0];
            n150TextosId = T000U21_n150TextosId[0];
            A118MonedaId = T000U21_A118MonedaId[0];
            A842MedidasImagen = T000U21_A842MedidasImagen[0];
            n842MedidasImagen = T000U21_n842MedidasImagen[0];
            AssignProp("", false, edtMedidasImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)) ? A40001MedidasImagen_GXI : context.convertURL( context.PathToRelativeUrl( A842MedidasImagen))), !bGXsfl_38_Refreshing);
            AssignProp("", false, edtMedidasImagen_Internalname, "SrcSet", context.GetImageSrcSet( A842MedidasImagen), true);
            ZM0U26( -11) ;
         }
         pr_default.close(19);
         OnLoadActions0U26( ) ;
      }

      protected void OnLoadActions0U26( )
      {
      }

      protected void CheckExtendedTable0U26( )
      {
         nIsDirty_26 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0U26( ) ;
         if ( ! ( ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A139MedidasEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A139MedidasEstado)) ) )
         {
            GXCCtl = "MEDIDASESTADO_" + sGXsfl_38_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado de la Lista", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbMedidasEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0U26( )
      {
      }

      protected void enableDisable0U26( )
      {
      }

      protected void GetKey0U26( )
      {
         /* Using cursor T000U22 */
         pr_default.execute(20, new Object[] {A121RubrosId, A137MedidasID});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey0U26( )
      {
         /* Using cursor T000U3 */
         pr_default.execute(1, new Object[] {A121RubrosId, A137MedidasID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0U26( 11) ;
            RcdFound26 = 1;
            InitializeNonKey0U26( ) ;
            A137MedidasID = T000U3_A137MedidasID[0];
            A139MedidasEstado = T000U3_A139MedidasEstado[0];
            n139MedidasEstado = T000U3_n139MedidasEstado[0];
            A138MedidasNombre = T000U3_A138MedidasNombre[0];
            A40001MedidasImagen_GXI = T000U3_A40001MedidasImagen_GXI[0];
            n40001MedidasImagen_GXI = T000U3_n40001MedidasImagen_GXI[0];
            AssignProp("", false, edtMedidasImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)) ? A40001MedidasImagen_GXI : context.convertURL( context.PathToRelativeUrl( A842MedidasImagen))), !bGXsfl_38_Refreshing);
            AssignProp("", false, edtMedidasImagen_Internalname, "SrcSet", context.GetImageSrcSet( A842MedidasImagen), true);
            A215RubrosCosto = T000U3_A215RubrosCosto[0];
            A216RubrosPrecioBase = T000U3_A216RubrosPrecioBase[0];
            A150TextosId = T000U3_A150TextosId[0];
            n150TextosId = T000U3_n150TextosId[0];
            A118MonedaId = T000U3_A118MonedaId[0];
            A842MedidasImagen = T000U3_A842MedidasImagen[0];
            n842MedidasImagen = T000U3_n842MedidasImagen[0];
            AssignProp("", false, edtMedidasImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)) ? A40001MedidasImagen_GXI : context.convertURL( context.PathToRelativeUrl( A842MedidasImagen))), !bGXsfl_38_Refreshing);
            AssignProp("", false, edtMedidasImagen_Internalname, "SrcSet", context.GetImageSrcSet( A842MedidasImagen), true);
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0U26( ) ;
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0U26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0U26( ) ;
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0U26( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0U26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000U2 */
            pr_default.execute(0, new Object[] {A121RubrosId, A137MedidasID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RubrosMedidas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z139MedidasEstado, T000U2_A139MedidasEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z138MedidasNombre, T000U2_A138MedidasNombre[0]) != 0 ) || ( Z215RubrosCosto != T000U2_A215RubrosCosto[0] ) || ( Z216RubrosPrecioBase != T000U2_A216RubrosPrecioBase[0] ) || ( Z150TextosId != T000U2_A150TextosId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z118MonedaId != T000U2_A118MonedaId[0] ) )
            {
               if ( StringUtil.StrCmp(Z139MedidasEstado, T000U2_A139MedidasEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("rubrosmedidas:[seudo value changed for attri]"+"MedidasEstado");
                  GXUtil.WriteLogRaw("Old: ",Z139MedidasEstado);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A139MedidasEstado[0]);
               }
               if ( StringUtil.StrCmp(Z138MedidasNombre, T000U2_A138MedidasNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("rubrosmedidas:[seudo value changed for attri]"+"MedidasNombre");
                  GXUtil.WriteLogRaw("Old: ",Z138MedidasNombre);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A138MedidasNombre[0]);
               }
               if ( Z215RubrosCosto != T000U2_A215RubrosCosto[0] )
               {
                  GXUtil.WriteLog("rubrosmedidas:[seudo value changed for attri]"+"RubrosCosto");
                  GXUtil.WriteLogRaw("Old: ",Z215RubrosCosto);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A215RubrosCosto[0]);
               }
               if ( Z216RubrosPrecioBase != T000U2_A216RubrosPrecioBase[0] )
               {
                  GXUtil.WriteLog("rubrosmedidas:[seudo value changed for attri]"+"RubrosPrecioBase");
                  GXUtil.WriteLogRaw("Old: ",Z216RubrosPrecioBase);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A216RubrosPrecioBase[0]);
               }
               if ( Z150TextosId != T000U2_A150TextosId[0] )
               {
                  GXUtil.WriteLog("rubrosmedidas:[seudo value changed for attri]"+"TextosId");
                  GXUtil.WriteLogRaw("Old: ",Z150TextosId);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A150TextosId[0]);
               }
               if ( Z118MonedaId != T000U2_A118MonedaId[0] )
               {
                  GXUtil.WriteLog("rubrosmedidas:[seudo value changed for attri]"+"MonedaId");
                  GXUtil.WriteLogRaw("Old: ",Z118MonedaId);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A118MonedaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"RubrosMedidas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U26( )
      {
         BeforeValidate0U26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U26( 0) ;
            CheckOptimisticConcurrency0U26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U23 */
                     pr_default.execute(21, new Object[] {A121RubrosId, A137MedidasID, n139MedidasEstado, A139MedidasEstado, A138MedidasNombre, n842MedidasImagen, A842MedidasImagen, n40001MedidasImagen_GXI, A40001MedidasImagen_GXI, A215RubrosCosto, A216RubrosPrecioBase, n150TextosId, A150TextosId, A118MonedaId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("RubrosMedidas");
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
               Load0U26( ) ;
            }
            EndLevel0U26( ) ;
         }
         CloseExtendedTableCursors0U26( ) ;
      }

      protected void Update0U26( )
      {
         BeforeValidate0U26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U26( ) ;
         }
         if ( ( nIsMod_26 != 0 ) || ( nIsDirty_26 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0U26( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0U26( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0U26( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000U24 */
                        pr_default.execute(22, new Object[] {n139MedidasEstado, A139MedidasEstado, A138MedidasNombre, A215RubrosCosto, A216RubrosPrecioBase, n150TextosId, A150TextosId, A118MonedaId, A121RubrosId, A137MedidasID});
                        pr_default.close(22);
                        pr_default.SmartCacheProvider.SetUpdated("RubrosMedidas");
                        if ( (pr_default.getStatus(22) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RubrosMedidas"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0U26( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0U26( ) ;
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
               EndLevel0U26( ) ;
            }
         }
         CloseExtendedTableCursors0U26( ) ;
      }

      protected void DeferredUpdate0U26( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000U25 */
            pr_default.execute(23, new Object[] {n842MedidasImagen, A842MedidasImagen, n40001MedidasImagen_GXI, A40001MedidasImagen_GXI, A121RubrosId, A137MedidasID});
            pr_default.close(23);
            pr_default.SmartCacheProvider.SetUpdated("RubrosMedidas");
         }
      }

      protected void Delete0U26( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0U26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U26( ) ;
            AfterConfirm0U26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000U26 */
                  pr_default.execute(24, new Object[] {A121RubrosId, A137MedidasID});
                  pr_default.close(24);
                  pr_default.SmartCacheProvider.SetUpdated("RubrosMedidas");
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0U26( ) ;
         Gx_mode = sMode26;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0U26( )
      {
         standaloneModal0U26( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000U27 */
            pr_default.execute(25, new Object[] {A121RubrosId, A137MedidasID});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Inventario", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
         }
      }

      protected void EndLevel0U26( )
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

      public void ScanStart0U26( )
      {
         /* Scan By routine */
         /* Using cursor T000U28 */
         pr_default.execute(26, new Object[] {A121RubrosId});
         RcdFound26 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound26 = 1;
            A137MedidasID = T000U28_A137MedidasID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0U26( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound26 = 1;
            A137MedidasID = T000U28_A137MedidasID[0];
         }
      }

      protected void ScanEnd0U26( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm0U26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0U26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0U26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0U26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0U26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U26( )
      {
         edtMedidasID_Enabled = 0;
         AssignProp("", false, edtMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidasID_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtMedidasNombre_Enabled = 0;
         AssignProp("", false, edtMedidasNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidasNombre_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         dynMonedaId.Enabled = 0;
         AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtRubrosCosto_Enabled = 0;
         AssignProp("", false, edtRubrosCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosCosto_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtRubrosPrecioBase_Enabled = 0;
         AssignProp("", false, edtRubrosPrecioBase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosPrecioBase_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         cmbMedidasEstado.Enabled = 0;
         AssignProp("", false, cmbMedidasEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMedidasEstado.Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtMedidasImagen_Enabled = 0;
         AssignProp("", false, edtMedidasImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidasImagen_Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void send_integrity_lvl_hashes0U26( )
      {
      }

      protected void send_integrity_lvl_hashes0U37( )
      {
      }

      protected void SubsflControlProps_3826( )
      {
         edtMedidasID_Internalname = "MEDIDASID_"+sGXsfl_38_idx;
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE_"+sGXsfl_38_idx;
         dynMonedaId_Internalname = "MONEDAID_"+sGXsfl_38_idx;
         edtRubrosCosto_Internalname = "RUBROSCOSTO_"+sGXsfl_38_idx;
         edtRubrosPrecioBase_Internalname = "RUBROSPRECIOBASE_"+sGXsfl_38_idx;
         cmbMedidasEstado_Internalname = "MEDIDASESTADO_"+sGXsfl_38_idx;
         edtMedidasImagen_Internalname = "MEDIDASIMAGEN_"+sGXsfl_38_idx;
      }

      protected void SubsflControlProps_fel_3826( )
      {
         edtMedidasID_Internalname = "MEDIDASID_"+sGXsfl_38_fel_idx;
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE_"+sGXsfl_38_fel_idx;
         dynMonedaId_Internalname = "MONEDAID_"+sGXsfl_38_fel_idx;
         edtRubrosCosto_Internalname = "RUBROSCOSTO_"+sGXsfl_38_fel_idx;
         edtRubrosPrecioBase_Internalname = "RUBROSPRECIOBASE_"+sGXsfl_38_fel_idx;
         cmbMedidasEstado_Internalname = "MEDIDASESTADO_"+sGXsfl_38_fel_idx;
         edtMedidasImagen_Internalname = "MEDIDASIMAGEN_"+sGXsfl_38_fel_idx;
      }

      protected void AddRow0U26( )
      {
         nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_3826( ) ;
         SendRow0U26( ) ;
      }

      protected void SendRow0U26( )
      {
         Gridlevel_medidasRow = GXWebRow.GetNew(context);
         if ( subGridlevel_medidas_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_medidas_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_medidas_Class, "") != 0 )
            {
               subGridlevel_medidas_Linesclass = subGridlevel_medidas_Class+"Odd";
            }
         }
         else if ( subGridlevel_medidas_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_medidas_Backstyle = 0;
            subGridlevel_medidas_Backcolor = subGridlevel_medidas_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_medidas_Class, "") != 0 )
            {
               subGridlevel_medidas_Linesclass = subGridlevel_medidas_Class+"Uniform";
            }
         }
         else if ( subGridlevel_medidas_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_medidas_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_medidas_Class, "") != 0 )
            {
               subGridlevel_medidas_Linesclass = subGridlevel_medidas_Class+"Odd";
            }
            subGridlevel_medidas_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_medidas_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_medidas_Backstyle = 1;
            if ( ((int)((nGXsfl_38_idx) % (2))) == 0 )
            {
               subGridlevel_medidas_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_medidas_Class, "") != 0 )
               {
                  subGridlevel_medidas_Linesclass = subGridlevel_medidas_Class+"Even";
               }
            }
            else
            {
               subGridlevel_medidas_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_medidas_Class, "") != 0 )
               {
                  subGridlevel_medidas_Linesclass = subGridlevel_medidas_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_26_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_medidasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtMedidasID_Enabled!=0) ? context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtMedidasID_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_26_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_medidasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidasNombre_Internalname,StringUtil.RTrim( A138MedidasNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidasNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtMedidasNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( ( dynMonedaId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "MONEDAID_" + sGXsfl_38_idx;
            dynMonedaId.Name = GXCCtl;
            dynMonedaId.WebTags = "";
            dynMonedaId.removeAllItems();
            /* Using cursor T000U29 */
            pr_default.execute(27);
            while ( (pr_default.getStatus(27) != 101) )
            {
               dynMonedaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000U29_A118MonedaId[0]), 4, 0)), T000U29_A119MonedaISOSimbolo[0], 0);
               pr_default.readNext(27);
            }
            pr_default.close(27);
            if ( dynMonedaId.ItemCount > 0 )
            {
               A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            }
         }
         /* ComboBox */
         Gridlevel_medidasRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynMonedaId,(string)dynMonedaId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0)),(short)1,(string)dynMonedaId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)0,dynMonedaId.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"",(bool)true,(short)0});
         dynMonedaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0));
         AssignProp("", false, dynMonedaId_Internalname, "Values", (string)(dynMonedaId.ToJavascriptSource()), !bGXsfl_38_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_26_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_medidasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosCosto_Internalname,StringUtil.LTrim( StringUtil.NToC( A215RubrosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtRubrosCosto_Enabled!=0) ? context.localUtil.Format( A215RubrosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A215RubrosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosCosto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtRubrosCosto_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_26_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ROClassString = "Attribute";
         Gridlevel_medidasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosPrecioBase_Internalname,StringUtil.LTrim( StringUtil.NToC( A216RubrosPrecioBase, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtRubrosPrecioBase_Enabled!=0) ? context.localUtil.Format( A216RubrosPrecioBase, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A216RubrosPrecioBase, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosPrecioBase_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtRubrosPrecioBase_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_26_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_38_idx + "',38)\"";
         GXCCtl = "MEDIDASESTADO_" + sGXsfl_38_idx;
         cmbMedidasEstado.Name = GXCCtl;
         cmbMedidasEstado.WebTags = "";
         cmbMedidasEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbMedidasEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbMedidasEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbMedidasEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbMedidasEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A139MedidasEstado)) )
            {
               A139MedidasEstado = "HAB";
               n139MedidasEstado = false;
            }
         }
         /* ComboBox */
         Gridlevel_medidasRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbMedidasEstado,(string)cmbMedidasEstado_Internalname,StringUtil.RTrim( A139MedidasEstado),(short)1,(string)cmbMedidasEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbMedidasEstado.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"",(string)"",(bool)true,(short)0});
         cmbMedidasEstado.CurrentValue = StringUtil.RTrim( A139MedidasEstado);
         AssignProp("", false, cmbMedidasEstado_Internalname, "Values", (string)(cmbMedidasEstado.ToJavascriptSource()), !bGXsfl_38_Refreshing);
         /* Subfile cell */
         /* Static Bitmap Variable */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_26_" + sGXsfl_38_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_38_idx + "',38)\"";
         ClassString = "Attribute";
         StyleString = "";
         A842MedidasImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001MedidasImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)) ? A40001MedidasImagen_GXI : context.PathToRelativeUrl( A842MedidasImagen));
         Gridlevel_medidasRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidasImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtMedidasImagen_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"",(string)"",(string)"",(short)0,(bool)A842MedidasImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
         AssignProp("", false, edtMedidasImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)) ? A40001MedidasImagen_GXI : context.PathToRelativeUrl( A842MedidasImagen)), !bGXsfl_38_Refreshing);
         AssignProp("", false, edtMedidasImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A842MedidasImagen_IsBlob), !bGXsfl_38_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_medidasRow);
         send_integrity_lvl_hashes0U26( ) ;
         GXCCtl = "Z137MedidasID_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z139MedidasEstado_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z139MedidasEstado));
         GXCCtl = "Z138MedidasNombre_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z138MedidasNombre));
         GXCCtl = "Z215RubrosCosto_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z215RubrosCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z216RubrosPrecioBase_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z216RubrosPrecioBase, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z150TextosId_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z150TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z118MonedaId_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_26_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_26), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_26_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_26), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_26_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_26), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_38_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vRUBROSID_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "TEXTOSTITULO_" + sGXsfl_38_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( A259TextosTitulo));
         GXCCtl = "MEDIDASIMAGEN_" + sGXsfl_38_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A842MedidasImagen);
         GxWebStd.gx_hidden_field( context, "MEDIDASID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MEDIDASNOMBRE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MONEDAID_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMonedaId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RUBROSCOSTO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosCosto_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RUBROSPRECIOBASE_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosPrecioBase_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MEDIDASESTADO_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMedidasEstado.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MEDIDASIMAGEN_"+sGXsfl_38_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasImagen_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_medidasContainer.AddRow(Gridlevel_medidasRow);
      }

      protected void ReadRow0U26( )
      {
         nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_3826( ) ;
         edtMedidasID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtMedidasNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASNOMBRE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynMonedaId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MONEDAID_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtRubrosCosto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSCOSTO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtRubrosPrecioBase_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSPRECIOBASE_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbMedidasEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASESTADO_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtMedidasImagen_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASIMAGEN_"+sGXsfl_38_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMedidasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A138MedidasNombre = cgiGet( edtMedidasNombre_Internalname);
         dynMonedaId.Name = dynMonedaId_Internalname;
         dynMonedaId.CurrentValue = cgiGet( dynMonedaId_Internalname);
         A118MonedaId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynMonedaId_Internalname), "."), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtRubrosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtRubrosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
         {
            GXCCtl = "RUBROSCOSTO_" + sGXsfl_38_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubrosCosto_Internalname;
            wbErr = true;
            A215RubrosCosto = 0;
         }
         else
         {
            A215RubrosCosto = context.localUtil.CToN( cgiGet( edtRubrosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtRubrosPrecioBase_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtRubrosPrecioBase_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
         {
            GXCCtl = "RUBROSPRECIOBASE_" + sGXsfl_38_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubrosPrecioBase_Internalname;
            wbErr = true;
            A216RubrosPrecioBase = 0;
         }
         else
         {
            A216RubrosPrecioBase = context.localUtil.CToN( cgiGet( edtRubrosPrecioBase_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         }
         cmbMedidasEstado.Name = cmbMedidasEstado_Internalname;
         cmbMedidasEstado.CurrentValue = cgiGet( cmbMedidasEstado_Internalname);
         A139MedidasEstado = cgiGet( cmbMedidasEstado_Internalname);
         n139MedidasEstado = false;
         n139MedidasEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A139MedidasEstado)) ? true : false);
         A842MedidasImagen = cgiGet( edtMedidasImagen_Internalname);
         n842MedidasImagen = false;
         n842MedidasImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)) ? true : false);
         GXCCtl = "Z137MedidasID_" + sGXsfl_38_idx;
         Z137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z139MedidasEstado_" + sGXsfl_38_idx;
         Z139MedidasEstado = cgiGet( GXCCtl);
         n139MedidasEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A139MedidasEstado)) ? true : false);
         GXCCtl = "Z138MedidasNombre_" + sGXsfl_38_idx;
         Z138MedidasNombre = cgiGet( GXCCtl);
         GXCCtl = "Z215RubrosCosto_" + sGXsfl_38_idx;
         Z215RubrosCosto = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z216RubrosPrecioBase_" + sGXsfl_38_idx;
         Z216RubrosPrecioBase = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z150TextosId_" + sGXsfl_38_idx;
         Z150TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n150TextosId = ((0==A150TextosId) ? true : false);
         GXCCtl = "Z118MonedaId_" + sGXsfl_38_idx;
         Z118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z150TextosId_" + sGXsfl_38_idx;
         A150TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n150TextosId = false;
         n150TextosId = ((0==A150TextosId) ? true : false);
         GXCCtl = "nRcdDeleted_26_" + sGXsfl_38_idx;
         nRcdDeleted_26 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_26_" + sGXsfl_38_idx;
         nRcdExists_26 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_26_" + sGXsfl_38_idx;
         nIsMod_26 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "TEXTOSTITULO_" + sGXsfl_38_idx;
         A259TextosTitulo = cgiGet( GXCCtl);
         getMultimediaValue(edtMedidasImagen_Internalname, ref  A842MedidasImagen, ref  A40001MedidasImagen_GXI);
         n40001MedidasImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40001MedidasImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)) ? true : false);
         n842MedidasImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)) ? true : false);
      }

      protected void assign_properties_default( )
      {
         defdynMonedaId_Enabled = dynMonedaId.Enabled;
         defedtMedidasID_Enabled = edtMedidasID_Enabled;
      }

      protected void ConfirmValues0U0( )
      {
         nGXsfl_38_idx = 0;
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_3826( ) ;
         while ( nGXsfl_38_idx < nRC_GXsfl_38 )
         {
            nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_3826( ) ;
            ChangePostValue( "Z137MedidasID_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z137MedidasID_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z139MedidasEstado_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z139MedidasEstado_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z139MedidasEstado_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z138MedidasNombre_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z138MedidasNombre_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z138MedidasNombre_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z215RubrosCosto_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z215RubrosCosto_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z215RubrosCosto_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z216RubrosPrecioBase_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z216RubrosPrecioBase_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z216RubrosPrecioBase_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z150TextosId_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z150TextosId_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z150TextosId_"+sGXsfl_38_idx) ;
            ChangePostValue( "Z118MonedaId_"+sGXsfl_38_idx, cgiGet( "ZT_"+"Z118MonedaId_"+sGXsfl_38_idx)) ;
            DeletePostValue( "ZT_"+"Z118MonedaId_"+sGXsfl_38_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("rubrosmedidas.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7RubrosId,4,0))}, new string[] {"Gx_mode","RubrosId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"RubrosMedidas");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("RubrosNombre", StringUtil.RTrim( context.localUtil.Format( A122RubrosNombre, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("rubrosmedidas:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z121RubrosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z122RubrosNombre", StringUtil.RTrim( Z122RubrosNombre));
         GxWebStd.gx_hidden_field( context, "Z217RubrosMedidasSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z217RubrosMedidasSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z123RubrosEstado", StringUtil.RTrim( Z123RubrosEstado));
         GxWebStd.gx_hidden_field( context, "O217RubrosMedidasSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(O217RubrosMedidasSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_38", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_38_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vRUBROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RubrosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RUBROSNOMBRE", StringUtil.RTrim( A122RubrosNombre));
         GxWebStd.gx_hidden_field( context, "RUBROSIMAGEN_GXI", A40000RubrosImagen_GXI);
         GxWebStd.gx_hidden_field( context, "RUBROSMEDIDASSERIAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(A217RubrosMedidasSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "MEDIDASIMAGEN_GXI", A40001MedidasImagen_GXI);
         GxWebStd.gx_hidden_field( context, "TEXTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A150TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "TEXTOSTITULO", StringUtil.RTrim( A259TextosTitulo));
         GXCCtlgxBlob = "RUBROSIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A168RubrosImagen);
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
         return formatLink("rubrosmedidas.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7RubrosId,4,0))}, new string[] {"Gx_mode","RubrosId"})  ;
      }

      public override string GetPgmname( )
      {
         return "RubrosMedidas" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Rubros Medidas y Precios", "") ;
      }

      protected void InitializeNonKey0U37( )
      {
         A122RubrosNombre = "";
         AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
         A168RubrosImagen = "";
         AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
         AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A40000RubrosImagen_GXI = "";
         AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A217RubrosMedidasSerial = 0;
         AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
         A123RubrosEstado = "";
         n123RubrosEstado = false;
         AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
         n123RubrosEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A123RubrosEstado)) ? true : false);
         O217RubrosMedidasSerial = A217RubrosMedidasSerial;
         AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
         Z122RubrosNombre = "";
         Z217RubrosMedidasSerial = 0;
         Z123RubrosEstado = "";
      }

      protected void InitAll0U37( )
      {
         A121RubrosId = 0;
         AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
         InitializeNonKey0U37( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0U26( )
      {
         A138MedidasNombre = "";
         A842MedidasImagen = "";
         n842MedidasImagen = false;
         AssignProp("", false, edtMedidasImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)) ? A40001MedidasImagen_GXI : context.convertURL( context.PathToRelativeUrl( A842MedidasImagen))), !bGXsfl_38_Refreshing);
         AssignProp("", false, edtMedidasImagen_Internalname, "SrcSet", context.GetImageSrcSet( A842MedidasImagen), true);
         A40001MedidasImagen_GXI = "";
         n40001MedidasImagen_GXI = false;
         AssignProp("", false, edtMedidasImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A842MedidasImagen)) ? A40001MedidasImagen_GXI : context.convertURL( context.PathToRelativeUrl( A842MedidasImagen))), !bGXsfl_38_Refreshing);
         AssignProp("", false, edtMedidasImagen_Internalname, "SrcSet", context.GetImageSrcSet( A842MedidasImagen), true);
         A118MonedaId = 0;
         A215RubrosCosto = 0;
         A216RubrosPrecioBase = 0;
         A150TextosId = 0;
         n150TextosId = false;
         AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
         A259TextosTitulo = "";
         AssignAttri("", false, "A259TextosTitulo", A259TextosTitulo);
         A139MedidasEstado = "HAB";
         n139MedidasEstado = false;
         Z139MedidasEstado = "";
         Z138MedidasNombre = "";
         Z215RubrosCosto = 0;
         Z216RubrosPrecioBase = 0;
         Z150TextosId = 0;
         Z118MonedaId = 0;
      }

      protected void InitAll0U26( )
      {
         A137MedidasID = 0;
         InitializeNonKey0U26( ) ;
      }

      protected void StandaloneModalInsert0U26( )
      {
         A217RubrosMedidasSerial = i217RubrosMedidasSerial;
         AssignAttri("", false, "A217RubrosMedidasSerial", StringUtil.LTrimStr( (decimal)(A217RubrosMedidasSerial), 4, 0));
         A139MedidasEstado = i139MedidasEstado;
         n139MedidasEstado = false;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202693202526", true, true, false);
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
         context.AddJavascriptSource("rubrosmedidas.js", "?202693202526", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties26( )
      {
         dynMonedaId.Enabled = defdynMonedaId_Enabled;
         AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), !bGXsfl_38_Refreshing);
         edtMedidasID_Enabled = defedtMedidasID_Enabled;
         AssignProp("", false, edtMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidasID_Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void StartGridControl38( )
      {
         Gridlevel_medidasContainer.AddObjectProperty("GridName", "Gridlevel_medidas");
         Gridlevel_medidasContainer.AddObjectProperty("Header", subGridlevel_medidas_Header);
         Gridlevel_medidasContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_medidasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_medidasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_medidasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_medidas_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_medidasContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_medidasContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_medidasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_medidasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))));
         Gridlevel_medidasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasID_Enabled), 5, 0, ".", "")));
         Gridlevel_medidasContainer.AddColumnProperties(Gridlevel_medidasColumn);
         Gridlevel_medidasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_medidasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A138MedidasNombre)));
         Gridlevel_medidasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_medidasContainer.AddColumnProperties(Gridlevel_medidasColumn);
         Gridlevel_medidasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_medidasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))));
         Gridlevel_medidasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMonedaId.Enabled), 5, 0, ".", "")));
         Gridlevel_medidasContainer.AddColumnProperties(Gridlevel_medidasColumn);
         Gridlevel_medidasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_medidasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A215RubrosCosto, 21, 2, ".", ""))));
         Gridlevel_medidasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosCosto_Enabled), 5, 0, ".", "")));
         Gridlevel_medidasContainer.AddColumnProperties(Gridlevel_medidasColumn);
         Gridlevel_medidasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_medidasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A216RubrosPrecioBase, 21, 2, ".", ""))));
         Gridlevel_medidasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosPrecioBase_Enabled), 5, 0, ".", "")));
         Gridlevel_medidasContainer.AddColumnProperties(Gridlevel_medidasColumn);
         Gridlevel_medidasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_medidasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A139MedidasEstado)));
         Gridlevel_medidasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbMedidasEstado.Enabled), 5, 0, ".", "")));
         Gridlevel_medidasContainer.AddColumnProperties(Gridlevel_medidasColumn);
         Gridlevel_medidasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_medidasColumn.AddObjectProperty("Value", context.convertURL( A842MedidasImagen));
         Gridlevel_medidasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMedidasImagen_Enabled), 5, 0, ".", "")));
         Gridlevel_medidasContainer.AddColumnProperties(Gridlevel_medidasColumn);
         Gridlevel_medidasContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_medidas_Selectedindex), 4, 0, ".", "")));
         Gridlevel_medidasContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_medidas_Allowselection), 1, 0, ".", "")));
         Gridlevel_medidasContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_medidas_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_medidasContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_medidas_Allowhovering), 1, 0, ".", "")));
         Gridlevel_medidasContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_medidas_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_medidasContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_medidas_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_medidasContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_medidas_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         dynRubrosId_Internalname = "RUBROSID";
         cmbRubrosEstado_Internalname = "RUBROSESTADO";
         imgRubrosImagen_Internalname = "RUBROSIMAGEN";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtMedidasID_Internalname = "MEDIDASID";
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE";
         dynMonedaId_Internalname = "MONEDAID";
         edtRubrosCosto_Internalname = "RUBROSCOSTO";
         edtRubrosPrecioBase_Internalname = "RUBROSPRECIOBASE";
         cmbMedidasEstado_Internalname = "MEDIDASESTADO";
         edtMedidasImagen_Internalname = "MEDIDASIMAGEN";
         divTableleaflevel_medidas_Internalname = "TABLELEAFLEVEL_MEDIDAS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_medidas_Internalname = "GRIDLEVEL_MEDIDAS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_medidas_Allowcollapsing = 0;
         subGridlevel_medidas_Allowselection = 0;
         subGridlevel_medidas_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Rubros Medidas y Precios", "");
         cmbMedidasEstado_Jsonclick = "";
         edtRubrosPrecioBase_Jsonclick = "";
         edtRubrosCosto_Jsonclick = "";
         dynMonedaId_Jsonclick = "";
         edtMedidasNombre_Jsonclick = "";
         edtMedidasID_Jsonclick = "";
         subGridlevel_medidas_Class = "WorkWith";
         subGridlevel_medidas_Backcolorstyle = 0;
         edtMedidasImagen_Enabled = 1;
         cmbMedidasEstado.Enabled = 1;
         edtRubrosPrecioBase_Enabled = 1;
         edtRubrosCosto_Enabled = 1;
         dynMonedaId.Enabled = 0;
         edtMedidasNombre_Enabled = 1;
         edtMedidasID_Enabled = 0;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         imgRubrosImagen_Enabled = 1;
         cmbRubrosEstado_Jsonclick = "";
         cmbRubrosEstado.Enabled = 1;
         dynRubrosId_Jsonclick = "";
         dynRubrosId.Enabled = 1;
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

      protected void GXDLARUBROSID0U37( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLARUBROSID_data0U37( ) ;
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

      protected void GXARUBROSID_html0U37( )
      {
         short gxdynajaxvalue;
         GXDLARUBROSID_data0U37( ) ;
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

      protected void GXDLARUBROSID_data0U37( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T000U30 */
         pr_default.execute(28);
         while ( (pr_default.getStatus(28) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000U30_A121RubrosId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000U30_A122RubrosNombre[0]));
            pr_default.readNext(28);
         }
         pr_default.close(28);
      }

      protected void gxnrGridlevel_medidas_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_3826( ) ;
         while ( nGXsfl_38_idx <= nRC_GXsfl_38 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0U26( ) ;
            standaloneModal0U26( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0U26( ) ;
            nGXsfl_38_idx = (int)(nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_3826( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_medidasContainer)) ;
         /* End function gxnrGridlevel_medidas_newrow */
      }

      protected void init_web_controls( )
      {
         dynRubrosId.Name = "RUBROSID";
         dynRubrosId.WebTags = "";
         cmbRubrosEstado.Name = "RUBROSESTADO";
         cmbRubrosEstado.WebTags = "";
         cmbRubrosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbRubrosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbRubrosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbRubrosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbRubrosEstado.ItemCount > 0 )
         {
            A123RubrosEstado = cmbRubrosEstado.getValidValue(A123RubrosEstado);
            n123RubrosEstado = false;
            AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
         }
         GXCCtl = "MONEDAID_" + sGXsfl_38_idx;
         dynMonedaId.Name = GXCCtl;
         dynMonedaId.WebTags = "";
         dynMonedaId.removeAllItems();
         /* Using cursor T000U31 */
         pr_default.execute(29);
         while ( (pr_default.getStatus(29) != 101) )
         {
            dynMonedaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000U31_A118MonedaId[0]), 4, 0)), T000U31_A119MonedaISOSimbolo[0], 0);
            pr_default.readNext(29);
         }
         pr_default.close(29);
         if ( dynMonedaId.ItemCount > 0 )
         {
            A118MonedaId = (short)(Math.Round(NumberUtil.Val( dynMonedaId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "MEDIDASESTADO_" + sGXsfl_38_idx;
         cmbMedidasEstado.Name = GXCCtl;
         cmbMedidasEstado.WebTags = "";
         cmbMedidasEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbMedidasEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbMedidasEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbMedidasEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbMedidasEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A139MedidasEstado)) )
            {
               A139MedidasEstado = "HAB";
               n139MedidasEstado = false;
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7RubrosId',fld:'vRUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7RubrosId',fld:'vRUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("AFTER TRN","{handler:'E120U2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_RUBROSID",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_RUBROSESTADO","{handler:'Valid_Rubrosestado',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_RUBROSESTADO",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_MONEDAID","{handler:'Valid_Monedaid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_MONEDAID",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("VALID_MEDIDASESTADO","{handler:'Valid_Medidasestado',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("VALID_MEDIDASESTADO",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("NULL","{handler:'Valid_Medidasimagen',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]");
         setEventMetadata("NULL",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'}]}");
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
         pr_default.close(5);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z122RubrosNombre = "";
         Z123RubrosEstado = "";
         Z139MedidasEstado = "";
         Z138MedidasNombre = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A123RubrosEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A168RubrosImagen = "";
         A40000RubrosImagen_GXI = "";
         sImgUrl = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_medidasContainer = new GXWebGrid( context);
         sMode26 = "";
         sStyleString = "";
         A122RubrosNombre = "";
         A40001MedidasImagen_GXI = "";
         A842MedidasImagen = "";
         A259TextosTitulo = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode37 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A138MedidasNombre = "";
         A139MedidasEstado = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z168RubrosImagen = "";
         Z40000RubrosImagen_GXI = "";
         T000U8_A121RubrosId = new short[1] ;
         T000U8_A122RubrosNombre = new string[] {""} ;
         T000U8_A40000RubrosImagen_GXI = new string[] {""} ;
         T000U8_A217RubrosMedidasSerial = new short[1] ;
         T000U8_A123RubrosEstado = new string[] {""} ;
         T000U8_n123RubrosEstado = new bool[] {false} ;
         T000U8_A168RubrosImagen = new string[] {""} ;
         T000U9_A121RubrosId = new short[1] ;
         T000U7_A121RubrosId = new short[1] ;
         T000U7_A122RubrosNombre = new string[] {""} ;
         T000U7_A40000RubrosImagen_GXI = new string[] {""} ;
         T000U7_A217RubrosMedidasSerial = new short[1] ;
         T000U7_A123RubrosEstado = new string[] {""} ;
         T000U7_n123RubrosEstado = new bool[] {false} ;
         T000U7_A168RubrosImagen = new string[] {""} ;
         T000U10_A121RubrosId = new short[1] ;
         T000U11_A121RubrosId = new short[1] ;
         T000U6_A121RubrosId = new short[1] ;
         T000U6_A122RubrosNombre = new string[] {""} ;
         T000U6_A40000RubrosImagen_GXI = new string[] {""} ;
         T000U6_A217RubrosMedidasSerial = new short[1] ;
         T000U6_A123RubrosEstado = new string[] {""} ;
         T000U6_n123RubrosEstado = new bool[] {false} ;
         T000U6_A168RubrosImagen = new string[] {""} ;
         T000U12_A121RubrosId = new short[1] ;
         T000U16_A804CapacidadProdId = new long[1] ;
         T000U17_A120ProfesionalesId = new string[] {""} ;
         T000U17_A121RubrosId = new short[1] ;
         T000U18_A121RubrosId = new short[1] ;
         T000U18_A137MedidasID = new long[1] ;
         T000U18_A135InventarioId = new long[1] ;
         T000U20_A121RubrosId = new short[1] ;
         Z842MedidasImagen = "";
         Z40001MedidasImagen_GXI = "";
         Z259TextosTitulo = "";
         T000U4_A259TextosTitulo = new string[] {""} ;
         T000U5_A118MonedaId = new short[1] ;
         GXCCtl = "";
         T000U21_A121RubrosId = new short[1] ;
         T000U21_A137MedidasID = new long[1] ;
         T000U21_A139MedidasEstado = new string[] {""} ;
         T000U21_n139MedidasEstado = new bool[] {false} ;
         T000U21_A138MedidasNombre = new string[] {""} ;
         T000U21_A40001MedidasImagen_GXI = new string[] {""} ;
         T000U21_n40001MedidasImagen_GXI = new bool[] {false} ;
         T000U21_A215RubrosCosto = new decimal[1] ;
         T000U21_A216RubrosPrecioBase = new decimal[1] ;
         T000U21_A259TextosTitulo = new string[] {""} ;
         T000U21_A150TextosId = new long[1] ;
         T000U21_n150TextosId = new bool[] {false} ;
         T000U21_A118MonedaId = new short[1] ;
         T000U21_A842MedidasImagen = new string[] {""} ;
         T000U21_n842MedidasImagen = new bool[] {false} ;
         T000U22_A121RubrosId = new short[1] ;
         T000U22_A137MedidasID = new long[1] ;
         T000U3_A121RubrosId = new short[1] ;
         T000U3_A137MedidasID = new long[1] ;
         T000U3_A139MedidasEstado = new string[] {""} ;
         T000U3_n139MedidasEstado = new bool[] {false} ;
         T000U3_A138MedidasNombre = new string[] {""} ;
         T000U3_A40001MedidasImagen_GXI = new string[] {""} ;
         T000U3_n40001MedidasImagen_GXI = new bool[] {false} ;
         T000U3_A215RubrosCosto = new decimal[1] ;
         T000U3_A216RubrosPrecioBase = new decimal[1] ;
         T000U3_A150TextosId = new long[1] ;
         T000U3_n150TextosId = new bool[] {false} ;
         T000U3_A118MonedaId = new short[1] ;
         T000U3_A842MedidasImagen = new string[] {""} ;
         T000U3_n842MedidasImagen = new bool[] {false} ;
         T000U2_A121RubrosId = new short[1] ;
         T000U2_A137MedidasID = new long[1] ;
         T000U2_A139MedidasEstado = new string[] {""} ;
         T000U2_n139MedidasEstado = new bool[] {false} ;
         T000U2_A138MedidasNombre = new string[] {""} ;
         T000U2_A40001MedidasImagen_GXI = new string[] {""} ;
         T000U2_n40001MedidasImagen_GXI = new bool[] {false} ;
         T000U2_A215RubrosCosto = new decimal[1] ;
         T000U2_A216RubrosPrecioBase = new decimal[1] ;
         T000U2_A150TextosId = new long[1] ;
         T000U2_n150TextosId = new bool[] {false} ;
         T000U2_A118MonedaId = new short[1] ;
         T000U2_A842MedidasImagen = new string[] {""} ;
         T000U2_n842MedidasImagen = new bool[] {false} ;
         T000U27_A121RubrosId = new short[1] ;
         T000U27_A137MedidasID = new long[1] ;
         T000U27_A135InventarioId = new long[1] ;
         T000U28_A121RubrosId = new short[1] ;
         T000U28_A137MedidasID = new long[1] ;
         Gridlevel_medidasRow = new GXWebRow();
         subGridlevel_medidas_Linesclass = "";
         ROClassString = "";
         T000U29_A118MonedaId = new short[1] ;
         T000U29_A119MonedaISOSimbolo = new string[] {""} ;
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i139MedidasEstado = "";
         Gridlevel_medidasColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000U30_A121RubrosId = new short[1] ;
         T000U30_A122RubrosNombre = new string[] {""} ;
         T000U30_A123RubrosEstado = new string[] {""} ;
         T000U30_n123RubrosEstado = new bool[] {false} ;
         T000U31_A118MonedaId = new short[1] ;
         T000U31_A119MonedaISOSimbolo = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.rubrosmedidas__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubrosmedidas__default(),
            new Object[][] {
                new Object[] {
               T000U2_A121RubrosId, T000U2_A137MedidasID, T000U2_A139MedidasEstado, T000U2_n139MedidasEstado, T000U2_A138MedidasNombre, T000U2_A40001MedidasImagen_GXI, T000U2_n40001MedidasImagen_GXI, T000U2_A215RubrosCosto, T000U2_A216RubrosPrecioBase, T000U2_A150TextosId,
               T000U2_n150TextosId, T000U2_A118MonedaId, T000U2_A842MedidasImagen, T000U2_n842MedidasImagen
               }
               , new Object[] {
               T000U3_A121RubrosId, T000U3_A137MedidasID, T000U3_A139MedidasEstado, T000U3_n139MedidasEstado, T000U3_A138MedidasNombre, T000U3_A40001MedidasImagen_GXI, T000U3_n40001MedidasImagen_GXI, T000U3_A215RubrosCosto, T000U3_A216RubrosPrecioBase, T000U3_A150TextosId,
               T000U3_n150TextosId, T000U3_A118MonedaId, T000U3_A842MedidasImagen, T000U3_n842MedidasImagen
               }
               , new Object[] {
               T000U4_A259TextosTitulo
               }
               , new Object[] {
               T000U5_A118MonedaId
               }
               , new Object[] {
               T000U6_A121RubrosId, T000U6_A122RubrosNombre, T000U6_A40000RubrosImagen_GXI, T000U6_A217RubrosMedidasSerial, T000U6_A123RubrosEstado, T000U6_n123RubrosEstado, T000U6_A168RubrosImagen
               }
               , new Object[] {
               T000U7_A121RubrosId, T000U7_A122RubrosNombre, T000U7_A40000RubrosImagen_GXI, T000U7_A217RubrosMedidasSerial, T000U7_A123RubrosEstado, T000U7_n123RubrosEstado, T000U7_A168RubrosImagen
               }
               , new Object[] {
               T000U8_A121RubrosId, T000U8_A122RubrosNombre, T000U8_A40000RubrosImagen_GXI, T000U8_A217RubrosMedidasSerial, T000U8_A123RubrosEstado, T000U8_n123RubrosEstado, T000U8_A168RubrosImagen
               }
               , new Object[] {
               T000U9_A121RubrosId
               }
               , new Object[] {
               T000U10_A121RubrosId
               }
               , new Object[] {
               T000U11_A121RubrosId
               }
               , new Object[] {
               T000U12_A121RubrosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000U16_A804CapacidadProdId
               }
               , new Object[] {
               T000U17_A120ProfesionalesId, T000U17_A121RubrosId
               }
               , new Object[] {
               T000U18_A121RubrosId, T000U18_A137MedidasID, T000U18_A135InventarioId
               }
               , new Object[] {
               }
               , new Object[] {
               T000U20_A121RubrosId
               }
               , new Object[] {
               T000U21_A121RubrosId, T000U21_A137MedidasID, T000U21_A139MedidasEstado, T000U21_n139MedidasEstado, T000U21_A138MedidasNombre, T000U21_A40001MedidasImagen_GXI, T000U21_n40001MedidasImagen_GXI, T000U21_A215RubrosCosto, T000U21_A216RubrosPrecioBase, T000U21_A259TextosTitulo,
               T000U21_A150TextosId, T000U21_n150TextosId, T000U21_A118MonedaId, T000U21_A842MedidasImagen, T000U21_n842MedidasImagen
               }
               , new Object[] {
               T000U22_A121RubrosId, T000U22_A137MedidasID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000U27_A121RubrosId, T000U27_A137MedidasID, T000U27_A135InventarioId
               }
               , new Object[] {
               T000U28_A121RubrosId, T000U28_A137MedidasID
               }
               , new Object[] {
               T000U29_A118MonedaId, T000U29_A119MonedaISOSimbolo
               }
               , new Object[] {
               T000U30_A121RubrosId, T000U30_A122RubrosNombre, T000U30_A123RubrosEstado, T000U30_n123RubrosEstado
               }
               , new Object[] {
               T000U31_A118MonedaId, T000U31_A119MonedaISOSimbolo
               }
            }
         );
         Z139MedidasEstado = "HAB";
         n139MedidasEstado = false;
         A139MedidasEstado = "HAB";
         n139MedidasEstado = false;
         i139MedidasEstado = "HAB";
         n139MedidasEstado = false;
      }

      private short wcpOAV7RubrosId ;
      private short Z121RubrosId ;
      private short Z217RubrosMedidasSerial ;
      private short O217RubrosMedidasSerial ;
      private short Z118MonedaId ;
      private short nRcdDeleted_26 ;
      private short nRcdExists_26 ;
      private short nIsMod_26 ;
      private short GxWebError ;
      private short AV7RubrosId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A217RubrosMedidasSerial ;
      private short Gx_BScreen ;
      private short A121RubrosId ;
      private short nBlankRcdCount26 ;
      private short RcdFound26 ;
      private short B217RubrosMedidasSerial ;
      private short nBlankRcdUsr26 ;
      private short RcdFound37 ;
      private short s217RubrosMedidasSerial ;
      private short A118MonedaId ;
      private short nIsDirty_26 ;
      private short subGridlevel_medidas_Backcolorstyle ;
      private short subGridlevel_medidas_Backstyle ;
      private short gxajaxcallmode ;
      private short i217RubrosMedidasSerial ;
      private short subGridlevel_medidas_Allowselection ;
      private short subGridlevel_medidas_Allowhovering ;
      private short subGridlevel_medidas_Allowcollapsing ;
      private short subGridlevel_medidas_Collapsed ;
      private int nRC_GXsfl_38 ;
      private int nGXsfl_38_idx=1 ;
      private int trnEnded ;
      private int imgRubrosImagen_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtMedidasID_Enabled ;
      private int edtMedidasNombre_Enabled ;
      private int edtRubrosCosto_Enabled ;
      private int edtRubrosPrecioBase_Enabled ;
      private int edtMedidasImagen_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int subGridlevel_medidas_Backcolor ;
      private int subGridlevel_medidas_Allbackcolor ;
      private int defdynMonedaId_Enabled ;
      private int defedtMedidasID_Enabled ;
      private int idxLst ;
      private int subGridlevel_medidas_Selectedindex ;
      private int subGridlevel_medidas_Selectioncolor ;
      private int subGridlevel_medidas_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long Z137MedidasID ;
      private long Z150TextosId ;
      private long A150TextosId ;
      private long GRIDLEVEL_MEDIDAS_nFirstRecordOnPage ;
      private long A137MedidasID ;
      private decimal Z215RubrosCosto ;
      private decimal Z216RubrosPrecioBase ;
      private decimal A215RubrosCosto ;
      private decimal A216RubrosPrecioBase ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z122RubrosNombre ;
      private string Z123RubrosEstado ;
      private string Z139MedidasEstado ;
      private string Z138MedidasNombre ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string dynRubrosId_Internalname ;
      private string sGXsfl_38_idx="0001" ;
      private string A123RubrosEstado ;
      private string cmbRubrosEstado_Internalname ;
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
      private string dynRubrosId_Jsonclick ;
      private string cmbRubrosEstado_Jsonclick ;
      private string imgRubrosImagen_Internalname ;
      private string sImgUrl ;
      private string divTableleaflevel_medidas_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string sMode26 ;
      private string edtMedidasID_Internalname ;
      private string edtMedidasNombre_Internalname ;
      private string dynMonedaId_Internalname ;
      private string edtRubrosCosto_Internalname ;
      private string edtRubrosPrecioBase_Internalname ;
      private string cmbMedidasEstado_Internalname ;
      private string edtMedidasImagen_Internalname ;
      private string sStyleString ;
      private string subGridlevel_medidas_Internalname ;
      private string A122RubrosNombre ;
      private string A259TextosTitulo ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode37 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A138MedidasNombre ;
      private string A139MedidasEstado ;
      private string Z259TextosTitulo ;
      private string GXCCtl ;
      private string sGXsfl_38_fel_idx="0001" ;
      private string subGridlevel_medidas_Class ;
      private string subGridlevel_medidas_Linesclass ;
      private string ROClassString ;
      private string edtMedidasID_Jsonclick ;
      private string edtMedidasNombre_Jsonclick ;
      private string dynMonedaId_Jsonclick ;
      private string edtRubrosCosto_Jsonclick ;
      private string edtRubrosPrecioBase_Jsonclick ;
      private string cmbMedidasEstado_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i139MedidasEstado ;
      private string subGridlevel_medidas_Header ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n123RubrosEstado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A168RubrosImagen_IsBlob ;
      private bool bGXsfl_38_Refreshing=false ;
      private bool n40001MedidasImagen_GXI ;
      private bool n150TextosId ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool n139MedidasEstado ;
      private bool n842MedidasImagen ;
      private bool Gx_longc ;
      private bool A842MedidasImagen_IsBlob ;
      private bool gxdyncontrolsrefreshing ;
      private string A40000RubrosImagen_GXI ;
      private string A40001MedidasImagen_GXI ;
      private string Z40000RubrosImagen_GXI ;
      private string Z40001MedidasImagen_GXI ;
      private string A168RubrosImagen ;
      private string A842MedidasImagen ;
      private string Z168RubrosImagen ;
      private string Z842MedidasImagen ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_medidasContainer ;
      private GXWebRow Gridlevel_medidasRow ;
      private GXWebColumn Gridlevel_medidasColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynRubrosId ;
      private GXCombobox cmbRubrosEstado ;
      private GXCombobox dynMonedaId ;
      private GXCombobox cmbMedidasEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T000U8_A121RubrosId ;
      private string[] T000U8_A122RubrosNombre ;
      private string[] T000U8_A40000RubrosImagen_GXI ;
      private short[] T000U8_A217RubrosMedidasSerial ;
      private string[] T000U8_A123RubrosEstado ;
      private bool[] T000U8_n123RubrosEstado ;
      private string[] T000U8_A168RubrosImagen ;
      private short[] T000U9_A121RubrosId ;
      private short[] T000U7_A121RubrosId ;
      private string[] T000U7_A122RubrosNombre ;
      private string[] T000U7_A40000RubrosImagen_GXI ;
      private short[] T000U7_A217RubrosMedidasSerial ;
      private string[] T000U7_A123RubrosEstado ;
      private bool[] T000U7_n123RubrosEstado ;
      private string[] T000U7_A168RubrosImagen ;
      private short[] T000U10_A121RubrosId ;
      private short[] T000U11_A121RubrosId ;
      private short[] T000U6_A121RubrosId ;
      private string[] T000U6_A122RubrosNombre ;
      private string[] T000U6_A40000RubrosImagen_GXI ;
      private short[] T000U6_A217RubrosMedidasSerial ;
      private string[] T000U6_A123RubrosEstado ;
      private bool[] T000U6_n123RubrosEstado ;
      private string[] T000U6_A168RubrosImagen ;
      private short[] T000U12_A121RubrosId ;
      private long[] T000U16_A804CapacidadProdId ;
      private string[] T000U17_A120ProfesionalesId ;
      private short[] T000U17_A121RubrosId ;
      private short[] T000U18_A121RubrosId ;
      private long[] T000U18_A137MedidasID ;
      private long[] T000U18_A135InventarioId ;
      private short[] T000U20_A121RubrosId ;
      private string[] T000U4_A259TextosTitulo ;
      private short[] T000U5_A118MonedaId ;
      private short[] T000U21_A121RubrosId ;
      private long[] T000U21_A137MedidasID ;
      private string[] T000U21_A139MedidasEstado ;
      private bool[] T000U21_n139MedidasEstado ;
      private string[] T000U21_A138MedidasNombre ;
      private string[] T000U21_A40001MedidasImagen_GXI ;
      private bool[] T000U21_n40001MedidasImagen_GXI ;
      private decimal[] T000U21_A215RubrosCosto ;
      private decimal[] T000U21_A216RubrosPrecioBase ;
      private string[] T000U21_A259TextosTitulo ;
      private long[] T000U21_A150TextosId ;
      private bool[] T000U21_n150TextosId ;
      private short[] T000U21_A118MonedaId ;
      private string[] T000U21_A842MedidasImagen ;
      private bool[] T000U21_n842MedidasImagen ;
      private short[] T000U22_A121RubrosId ;
      private long[] T000U22_A137MedidasID ;
      private short[] T000U3_A121RubrosId ;
      private long[] T000U3_A137MedidasID ;
      private string[] T000U3_A139MedidasEstado ;
      private bool[] T000U3_n139MedidasEstado ;
      private string[] T000U3_A138MedidasNombre ;
      private string[] T000U3_A40001MedidasImagen_GXI ;
      private bool[] T000U3_n40001MedidasImagen_GXI ;
      private decimal[] T000U3_A215RubrosCosto ;
      private decimal[] T000U3_A216RubrosPrecioBase ;
      private long[] T000U3_A150TextosId ;
      private bool[] T000U3_n150TextosId ;
      private short[] T000U3_A118MonedaId ;
      private string[] T000U3_A842MedidasImagen ;
      private bool[] T000U3_n842MedidasImagen ;
      private short[] T000U2_A121RubrosId ;
      private long[] T000U2_A137MedidasID ;
      private string[] T000U2_A139MedidasEstado ;
      private bool[] T000U2_n139MedidasEstado ;
      private string[] T000U2_A138MedidasNombre ;
      private string[] T000U2_A40001MedidasImagen_GXI ;
      private bool[] T000U2_n40001MedidasImagen_GXI ;
      private decimal[] T000U2_A215RubrosCosto ;
      private decimal[] T000U2_A216RubrosPrecioBase ;
      private long[] T000U2_A150TextosId ;
      private bool[] T000U2_n150TextosId ;
      private short[] T000U2_A118MonedaId ;
      private string[] T000U2_A842MedidasImagen ;
      private bool[] T000U2_n842MedidasImagen ;
      private short[] T000U27_A121RubrosId ;
      private long[] T000U27_A137MedidasID ;
      private long[] T000U27_A135InventarioId ;
      private short[] T000U28_A121RubrosId ;
      private long[] T000U28_A137MedidasID ;
      private short[] T000U29_A118MonedaId ;
      private string[] T000U29_A119MonedaISOSimbolo ;
      private short[] T000U30_A121RubrosId ;
      private string[] T000U30_A122RubrosNombre ;
      private string[] T000U30_A123RubrosEstado ;
      private bool[] T000U30_n123RubrosEstado ;
      private short[] T000U31_A118MonedaId ;
      private string[] T000U31_A119MonedaISOSimbolo ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class rubrosmedidas__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class rubrosmedidas__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000U2;
        prmT000U2 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT000U3;
        prmT000U3 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT000U4;
        prmT000U4 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000U5;
        prmT000U5 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmT000U6;
        prmT000U6 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U7;
        prmT000U7 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U8;
        prmT000U8 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U9;
        prmT000U9 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U10;
        prmT000U10 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U11;
        prmT000U11 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U12;
        prmT000U12 = new Object[] {
        new ParDef("@RubrosNombre",GXType.NChar,100,0) ,
        new ParDef("@RubrosImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@RubrosImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Rubros", Fld="RubrosImagen"} ,
        new ParDef("@RubrosMedidasSerial",GXType.Int16,4,0) ,
        new ParDef("@RubrosEstado",GXType.NChar,3,0){Nullable=true}
        };
        Object[] prmT000U13;
        prmT000U13 = new Object[] {
        new ParDef("@RubrosNombre",GXType.NChar,100,0) ,
        new ParDef("@RubrosMedidasSerial",GXType.Int16,4,0) ,
        new ParDef("@RubrosEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U14;
        prmT000U14 = new Object[] {
        new ParDef("@RubrosImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@RubrosImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Rubros", Fld="RubrosImagen"} ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U15;
        prmT000U15 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U16;
        prmT000U16 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U17;
        prmT000U17 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U18;
        prmT000U18 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U19;
        prmT000U19 = new Object[] {
        new ParDef("@RubrosMedidasSerial",GXType.Int16,4,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U20;
        prmT000U20 = new Object[] {
        };
        Object[] prmT000U21;
        prmT000U21 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT000U22;
        prmT000U22 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT000U23;
        prmT000U23 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@MedidasEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@MedidasNombre",GXType.NChar,50,0) ,
        new ParDef("@MedidasImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@MedidasImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=4, Tbl="RubrosMedidas", Fld="MedidasImagen"} ,
        new ParDef("@RubrosCosto",GXType.Decimal,18,2) ,
        new ParDef("@RubrosPrecioBase",GXType.Decimal,18,2) ,
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmT000U24;
        prmT000U24 = new Object[] {
        new ParDef("@MedidasEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@MedidasNombre",GXType.NChar,50,0) ,
        new ParDef("@RubrosCosto",GXType.Decimal,18,2) ,
        new ParDef("@RubrosPrecioBase",GXType.Decimal,18,2) ,
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MonedaId",GXType.Int16,4,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT000U25;
        prmT000U25 = new Object[] {
        new ParDef("@MedidasImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@MedidasImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="RubrosMedidas", Fld="MedidasImagen"} ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT000U26;
        prmT000U26 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT000U27;
        prmT000U27 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT000U28;
        prmT000U28 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000U29;
        prmT000U29 = new Object[] {
        };
        Object[] prmT000U30;
        prmT000U30 = new Object[] {
        };
        Object[] prmT000U31;
        prmT000U31 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000U2", "SELECT [RubrosId], [MedidasID], [MedidasEstado], [MedidasNombre], [MedidasImagen_GXI], [RubrosCosto], [RubrosPrecioBase], [TextosId], [MonedaId], [MedidasImagen] FROM [RubrosMedidas] WITH (UPDLOCK) WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U3", "SELECT [RubrosId], [MedidasID], [MedidasEstado], [MedidasNombre], [MedidasImagen_GXI], [RubrosCosto], [RubrosPrecioBase], [TextosId], [MonedaId], [MedidasImagen] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U4", "SELECT [TextosTitulo] FROM [Textos] WHERE [TextosId] = @TextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U5", "SELECT [MonedaId] FROM [Moneda] WHERE [MonedaId] = @MonedaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U6", "SELECT [RubrosId], [RubrosNombre], [RubrosImagen_GXI], [RubrosMedidasSerial], [RubrosEstado], [RubrosImagen] FROM [Rubros] WITH (UPDLOCK) WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U7", "SELECT [RubrosId], [RubrosNombre], [RubrosImagen_GXI], [RubrosMedidasSerial], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U8", "SELECT TM1.[RubrosId], TM1.[RubrosNombre], TM1.[RubrosImagen_GXI], TM1.[RubrosMedidasSerial], TM1.[RubrosEstado], TM1.[RubrosImagen] FROM [Rubros] TM1 WHERE TM1.[RubrosId] = @RubrosId ORDER BY TM1.[RubrosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U9", "SELECT [RubrosId] FROM [Rubros] WHERE [RubrosId] = @RubrosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U10", "SELECT TOP 1 [RubrosId] FROM [Rubros] WHERE ( [RubrosId] > @RubrosId) ORDER BY [RubrosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U11", "SELECT TOP 1 [RubrosId] FROM [Rubros] WHERE ( [RubrosId] < @RubrosId) ORDER BY [RubrosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U12", "INSERT INTO [Rubros]([RubrosNombre], [RubrosImagen], [RubrosImagen_GXI], [RubrosMedidasSerial], [RubrosEstado], [RubrosDefault], [RubrosImagenURL]) VALUES(@RubrosNombre, @RubrosImagen, @RubrosImagen_GXI, @RubrosMedidasSerial, @RubrosEstado, convert(bit, 0), ''); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000U12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U13", "UPDATE [Rubros] SET [RubrosNombre]=@RubrosNombre, [RubrosMedidasSerial]=@RubrosMedidasSerial, [RubrosEstado]=@RubrosEstado  WHERE [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmT000U13)
           ,new CursorDef("T000U14", "UPDATE [Rubros] SET [RubrosImagen]=@RubrosImagen, [RubrosImagen_GXI]=@RubrosImagen_GXI  WHERE [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmT000U14)
           ,new CursorDef("T000U15", "DELETE FROM [Rubros]  WHERE [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmT000U15)
           ,new CursorDef("T000U16", "SELECT TOP 1 [CapacidadProdId] FROM [CapacidadProductiva] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U17", "SELECT TOP 1 [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U18", "SELECT TOP 1 [RubrosId], [MedidasID], [InventarioId] FROM [Inventario] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U19", "UPDATE [Rubros] SET [RubrosMedidasSerial]=@RubrosMedidasSerial  WHERE [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmT000U19)
           ,new CursorDef("T000U20", "SELECT [RubrosId] FROM [Rubros] ORDER BY [RubrosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000U20,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U21", "SELECT T1.[RubrosId], T1.[MedidasID], T1.[MedidasEstado], T1.[MedidasNombre], T1.[MedidasImagen_GXI], T1.[RubrosCosto], T1.[RubrosPrecioBase], T2.[TextosTitulo], T1.[TextosId], T1.[MonedaId], T1.[MedidasImagen] FROM ([RubrosMedidas] T1 LEFT JOIN [Textos] T2 ON T2.[TextosId] = T1.[TextosId]) WHERE T1.[RubrosId] = @RubrosId and T1.[MedidasID] = @MedidasID ORDER BY T1.[RubrosId], T1.[MedidasID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U21,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U22", "SELECT [RubrosId], [MedidasID] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U23", "INSERT INTO [RubrosMedidas]([RubrosId], [MedidasID], [MedidasEstado], [MedidasNombre], [MedidasImagen], [MedidasImagen_GXI], [RubrosCosto], [RubrosPrecioBase], [TextosId], [MonedaId], [InventarioSerial]) VALUES(@RubrosId, @MedidasID, @MedidasEstado, @MedidasNombre, @MedidasImagen, @MedidasImagen_GXI, @RubrosCosto, @RubrosPrecioBase, @TextosId, @MonedaId, convert(int, 0))", GxErrorMask.GX_NOMASK,prmT000U23)
           ,new CursorDef("T000U24", "UPDATE [RubrosMedidas] SET [MedidasEstado]=@MedidasEstado, [MedidasNombre]=@MedidasNombre, [RubrosCosto]=@RubrosCosto, [RubrosPrecioBase]=@RubrosPrecioBase, [TextosId]=@TextosId, [MonedaId]=@MonedaId  WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID", GxErrorMask.GX_NOMASK,prmT000U24)
           ,new CursorDef("T000U25", "UPDATE [RubrosMedidas] SET [MedidasImagen]=@MedidasImagen, [MedidasImagen_GXI]=@MedidasImagen_GXI  WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID", GxErrorMask.GX_NOMASK,prmT000U25)
           ,new CursorDef("T000U26", "DELETE FROM [RubrosMedidas]  WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID", GxErrorMask.GX_NOMASK,prmT000U26)
           ,new CursorDef("T000U27", "SELECT TOP 1 [RubrosId], [MedidasID], [InventarioId] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U28", "SELECT [RubrosId], [MedidasID] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId ORDER BY [RubrosId], [MedidasID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U28,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U29", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U29,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U30", "SELECT [RubrosId], [RubrosNombre], [RubrosEstado] FROM [Rubros] WHERE [RubrosEstado] <> 'DES' ORDER BY [RubrosNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U30,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U31", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U31,0, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 50);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
              ((long[]) buf[9])[0] = rslt.getLong(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((string[]) buf[12])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 50);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
              ((long[]) buf[9])[0] = rslt.getLong(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((string[]) buf[12])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 10 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 16 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 18 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 19 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 50);
              ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
              ((string[]) buf[9])[0] = rslt.getString(8, 80);
              ((long[]) buf[10])[0] = rslt.getLong(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((short[]) buf[12])[0] = rslt.getShort(10);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              return;
           case 20 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 25 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 26 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 27 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 28 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 29 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
     }
  }

}

}

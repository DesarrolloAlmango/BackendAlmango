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
   public class inventario : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            GXDLARUBROSID0M26( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"MEDIDASID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAMEDIDASID0M26( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"ESTADOSGENERICOSID") == 0 )
         {
            A107EstadosTipo = GetPar( "EstadosTipo");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAESTADOSGENERICOSID0M27( A107EstadosTipo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_29") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_29( A121RubrosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_30") == 0 )
         {
            A150TextosId = (long)(Math.Round(NumberUtil.Val( GetPar( "TextosId"), "."), 18, MidpointRounding.ToEven));
            n150TextosId = false;
            AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_30( A150TextosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_32") == 0 )
         {
            A107EstadosTipo = GetPar( "EstadosTipo");
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_32( A107EstadosTipo, A108EstadosGenericosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_33") == 0 )
         {
            A535InventarioTextosId = (long)(Math.Round(NumberUtil.Val( GetPar( "InventarioTextosId"), "."), 18, MidpointRounding.ToEven));
            n535InventarioTextosId = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_33( A535InventarioTextosId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_lista") == 0 )
         {
            gxnrGridlevel_lista_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "inventario.aspx")), "inventario.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "inventario.aspx")))) ;
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
                  AV17RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV17RubrosId", StringUtil.LTrimStr( (decimal)(AV17RubrosId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vRUBROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17RubrosId), "ZZZ9"), context));
                  AV18MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV18MedidasID", StringUtil.LTrimStr( (decimal)(AV18MedidasID), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMEDIDASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18MedidasID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Inventario", ""), 0) ;
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

      protected void gxnrGridlevel_lista_newrow_invoke( )
      {
         nRC_GXsfl_77 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_77"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_77_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_77_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_77_idx = GetPar( "sGXsfl_77_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         A218InventarioSerial = (short)(Math.Round(NumberUtil.Val( GetPar( "InventarioSerial"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_lista_newrow( ) ;
         /* End function gxnrGridlevel_lista_newrow_invoke */
      }

      public inventario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public inventario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_RubrosId ,
                           long aP2_MedidasID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV17RubrosId = aP1_RubrosId;
         this.AV18MedidasID = aP2_MedidasID;
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
         cmbMedidasEstado = new GXCombobox();
         dynMonedaId = new GXCombobox();
         dynEstadosGenericosId = new GXCombobox();
         chkInventarioEsPresupuestado = new GXCheckbox();
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
         if ( dynMedidasID.ItemCount > 0 )
         {
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
            AssignAttri("", false, "A137MedidasID", StringUtil.LTrimStr( (decimal)(A137MedidasID), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
            AssignProp("", false, dynMedidasID_Internalname, "Values", dynMedidasID.ToJavascriptSource(), true);
         }
         if ( cmbMedidasEstado.ItemCount > 0 )
         {
            A139MedidasEstado = cmbMedidasEstado.getValidValue(A139MedidasEstado);
            n139MedidasEstado = false;
            AssignAttri("", false, "A139MedidasEstado", A139MedidasEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMedidasEstado.CurrentValue = StringUtil.RTrim( A139MedidasEstado);
            AssignProp("", false, cmbMedidasEstado_Internalname, "Values", cmbMedidasEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTb1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynRubrosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynRubrosId_Internalname, context.GetMessage( "Rubro", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynRubrosId, dynRubrosId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0)), 1, dynRubrosId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynRubrosId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "", true, 0, "HLP_Inventario.htm");
         dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
         AssignProp("", false, dynRubrosId_Internalname, "Values", (string)(dynRubrosId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynMedidasID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynMedidasID_Internalname, context.GetMessage( "Items/Característica", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynMedidasID, dynMedidasID_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)), 1, dynMedidasID_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynMedidasID.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_Inventario.htm");
         dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         AssignProp("", false, dynMedidasID_Internalname, "Values", (string)(dynMedidasID.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMedidasNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMedidasNombre_Internalname, context.GetMessage( "Nombre de la Característica", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMedidasNombre_Internalname, StringUtil.RTrim( A138MedidasNombre), StringUtil.RTrim( context.localUtil.Format( A138MedidasNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMedidasNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMedidasNombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbMedidasEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMedidasEstado_Internalname, context.GetMessage( "Estado de la Lista", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMedidasEstado, cmbMedidasEstado_Internalname, StringUtil.RTrim( A139MedidasEstado), 1, cmbMedidasEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbMedidasEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "", true, 0, "HLP_Inventario.htm");
         cmbMedidasEstado.CurrentValue = StringUtil.RTrim( A139MedidasEstado);
         AssignProp("", false, cmbMedidasEstado_Internalname, "Values", (string)(cmbMedidasEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRubrosCosto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubrosCosto_Internalname, context.GetMessage( "Costo Base", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubrosCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A215RubrosCosto, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtRubrosCosto_Enabled!=0) ? context.localUtil.Format( A215RubrosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A215RubrosCosto, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubrosCosto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRubrosCosto_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRubrosPrecioBase_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRubrosPrecioBase_Internalname, context.GetMessage( "Precio Base", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRubrosPrecioBase_Internalname, StringUtil.LTrim( StringUtil.NToC( A216RubrosPrecioBase, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtRubrosPrecioBase_Enabled!=0) ? context.localUtil.Format( A216RubrosPrecioBase, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A216RubrosPrecioBase, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRubrosPrecioBase_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtRubrosPrecioBase_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTb2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgRubrosImagen_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A168RubrosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000RubrosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen));
         GxWebStd.gx_bitmap( context, imgRubrosImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgRubrosImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", "", "", 0, A168RubrosImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Inventario.htm");
         AssignProp("", false, imgRubrosImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen)), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A168RubrosImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTextosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTextosId_Internalname, context.GetMessage( "Textos Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTextosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A150TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A150TextosId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTextosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTextosId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Inventario.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_150_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_150_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_150_Internalname, sImgUrl, imgprompt_150_Link, "", "", context.GetTheme( ), imgprompt_150_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTextosTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTextosTipo_Internalname, context.GetMessage( "Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTextosTipo_Internalname, StringUtil.RTrim( A258TextosTipo), StringUtil.RTrim( context.localUtil.Format( A258TextosTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTextosTipo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTextosTipo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTextosTitulo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTextosTitulo_Internalname, context.GetMessage( "Titulo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTextosTitulo_Internalname, StringUtil.RTrim( A259TextosTitulo), StringUtil.RTrim( context.localUtil.Format( A259TextosTitulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTextosTitulo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTextosTitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Inventario.htm");
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
         GxWebStd.gx_div_start( context, divTableleaflevel_lista_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_lista( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInventarioSerial_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A218InventarioSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtInventarioSerial_Enabled!=0) ? context.localUtil.Format( (decimal)(A218InventarioSerial), "ZZZ9") : context.localUtil.Format( (decimal)(A218InventarioSerial), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInventarioSerial_Jsonclick, 0, "Attribute", "", "", "", "", edtInventarioSerial_Visible, edtInventarioSerial_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Inventario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_lista( )
      {
         /*  Grid Control  */
         StartGridControl77( ) ;
         nGXsfl_77_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount27 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_27 = 1;
               ScanStart0M27( ) ;
               while ( RcdFound27 != 0 )
               {
                  init_level_properties27( ) ;
                  getByPrimaryKey0M27( ) ;
                  AddRow0M27( ) ;
                  ScanNext0M27( ) ;
               }
               ScanEnd0M27( ) ;
               nBlankRcdCount27 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B218InventarioSerial = A218InventarioSerial;
            AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
            standaloneNotModal0M27( ) ;
            standaloneModal0M27( ) ;
            sMode27 = Gx_mode;
            while ( nGXsfl_77_idx < nRC_GXsfl_77 )
            {
               bGXsfl_77_Refreshing = true;
               ReadRow0M27( ) ;
               edtInventarioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOID_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioId_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtInventarioNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIONOMBRE_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioNombre_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtInventarioImagen_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOIMAGEN_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioImagen_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               dynMonedaId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MONEDAID_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtInventarioCosto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOCOSTO_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioCosto_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtInventarioPrecioFinal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOPRECIOFINAL_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtInventarioConsumoProductivo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOCONSUMOPRODUCTIVO_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioConsumoProductivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioConsumoProductivo_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtInventarioTextosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOTEXTOSID_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioTextosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioTextosId_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtInventarioTextosTitulo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOTEXTOSTITULO_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioTextosTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioTextosTitulo_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtEstadosTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSTIPO_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               dynEstadosGenericosId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSID_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosGenericosId.Enabled), 5, 0), !bGXsfl_77_Refreshing);
               edtInventarioRefCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOREFCODE_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioRefCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioRefCode_Enabled), 5, 0), !bGXsfl_77_Refreshing);
               chkInventarioEsPresupuestado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOESPRESUPUESTADO_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, chkInventarioEsPresupuestado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkInventarioEsPresupuestado.Enabled), 5, 0), !bGXsfl_77_Refreshing);
               imgprompt_150_Link = cgiGet( "PROMPT_535_"+sGXsfl_77_idx+"Link");
               imgprompt_150_Link = cgiGet( "PROMPT_108_"+sGXsfl_77_idx+"Link");
               if ( ( nRcdExists_27 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0M27( ) ;
               }
               SendRow0M27( ) ;
               bGXsfl_77_Refreshing = false;
            }
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A218InventarioSerial = B218InventarioSerial;
            AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount27 = 5;
            nRcdExists_27 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0M27( ) ;
               while ( RcdFound27 != 0 )
               {
                  sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_7727( ) ;
                  init_level_properties27( ) ;
                  standaloneNotModal0M27( ) ;
                  getByPrimaryKey0M27( ) ;
                  standaloneModal0M27( ) ;
                  AddRow0M27( ) ;
                  ScanNext0M27( ) ;
               }
               ScanEnd0M27( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode27 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx+1), 4, 0), 4, "0");
            SubsflControlProps_7727( ) ;
            InitAll0M27( ) ;
            init_level_properties27( ) ;
            B218InventarioSerial = A218InventarioSerial;
            AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
            nRcdExists_27 = 0;
            nIsMod_27 = 0;
            nRcdDeleted_27 = 0;
            nBlankRcdCount27 = (short)(nBlankRcdUsr27+nBlankRcdCount27);
            fRowAdded = 0;
            while ( nBlankRcdCount27 > 0 )
            {
               standaloneNotModal0M27( ) ;
               standaloneModal0M27( ) ;
               AddRow0M27( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtInventarioNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount27 = (short)(nBlankRcdCount27-1);
            }
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A218InventarioSerial = B218InventarioSerial;
            AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_listaContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_lista", Gridlevel_listaContainer, subGridlevel_lista_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_listaContainerData", Gridlevel_listaContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_listaContainerData"+"V", Gridlevel_listaContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_listaContainerData"+"V"+"\" value='"+Gridlevel_listaContainer.GridValuesHidden()+"'/>") ;
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
         E110M2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z121RubrosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z137MedidasID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z215RubrosCosto = context.localUtil.CToN( cgiGet( "Z215RubrosCosto"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z138MedidasNombre = cgiGet( "Z138MedidasNombre");
               Z216RubrosPrecioBase = context.localUtil.CToN( cgiGet( "Z216RubrosPrecioBase"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z139MedidasEstado = cgiGet( "Z139MedidasEstado");
               n139MedidasEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A139MedidasEstado)) ? true : false);
               Z218InventarioSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z218InventarioSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z150TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z150TextosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n150TextosId = ((0==A150TextosId) ? true : false);
               Z118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z118MonedaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O218InventarioSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O218InventarioSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_77 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_77"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N150TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N150TextosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n150TextosId = ((0==A150TextosId) ? true : false);
               AV17RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV18MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vMEDIDASID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV19Insert_TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TEXTOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19Insert_TextosId", StringUtil.LTrimStr( (decimal)(AV19Insert_TextosId), 18, 0));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40000RubrosImagen_GXI = cgiGet( "RUBROSIMAGEN_GXI");
               A122RubrosNombre = cgiGet( "RUBROSNOMBRE");
               AV33Pgmname = cgiGet( "vPGMNAME");
               A40001InventarioImagen_GXI = cgiGet( "INVENTARIOIMAGEN_GXI");
               A1004InventarioSKURelacionado = cgiGet( "INVENTARIOSKURELACIONADO");
               n1004InventarioSKURelacionado = false;
               n1004InventarioSKURelacionado = (String.IsNullOrEmpty(StringUtil.RTrim( A1004InventarioSKURelacionado)) ? true : false);
               A802I = (short)(Math.Round(context.localUtil.CToN( cgiGet( "I"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A537InventarioTextosTipo = cgiGet( "INVENTARIOTEXTOSTIPO");
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
               dynMedidasID.Name = dynMedidasID_Internalname;
               dynMedidasID.CurrentValue = cgiGet( dynMedidasID_Internalname);
               A137MedidasID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynMedidasID_Internalname), "."), 18, MidpointRounding.ToEven));
               n137MedidasID = false;
               AssignAttri("", false, "A137MedidasID", StringUtil.LTrimStr( (decimal)(A137MedidasID), 18, 0));
               A138MedidasNombre = cgiGet( edtMedidasNombre_Internalname);
               AssignAttri("", false, "A138MedidasNombre", A138MedidasNombre);
               cmbMedidasEstado.Name = cmbMedidasEstado_Internalname;
               cmbMedidasEstado.CurrentValue = cgiGet( cmbMedidasEstado_Internalname);
               A139MedidasEstado = cgiGet( cmbMedidasEstado_Internalname);
               n139MedidasEstado = false;
               AssignAttri("", false, "A139MedidasEstado", A139MedidasEstado);
               n139MedidasEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A139MedidasEstado)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtRubrosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtRubrosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBROSCOSTO");
                  AnyError = 1;
                  GX_FocusControl = edtRubrosCosto_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A215RubrosCosto = 0;
                  AssignAttri("", false, "A215RubrosCosto", StringUtil.LTrimStr( A215RubrosCosto, 18, 2));
               }
               else
               {
                  A215RubrosCosto = context.localUtil.CToN( cgiGet( edtRubrosCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A215RubrosCosto", StringUtil.LTrimStr( A215RubrosCosto, 18, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtRubrosPrecioBase_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < -99999999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtRubrosPrecioBase_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RUBROSPRECIOBASE");
                  AnyError = 1;
                  GX_FocusControl = edtRubrosPrecioBase_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A216RubrosPrecioBase = 0;
                  AssignAttri("", false, "A216RubrosPrecioBase", StringUtil.LTrimStr( A216RubrosPrecioBase, 18, 2));
               }
               else
               {
                  A216RubrosPrecioBase = context.localUtil.CToN( cgiGet( edtRubrosPrecioBase_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A216RubrosPrecioBase", StringUtil.LTrimStr( A216RubrosPrecioBase, 18, 2));
               }
               A168RubrosImagen = cgiGet( imgRubrosImagen_Internalname);
               AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTextosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTextosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TEXTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtTextosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A150TextosId = 0;
                  n150TextosId = false;
                  AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
               }
               else
               {
                  A150TextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtTextosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n150TextosId = false;
                  AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
               }
               n150TextosId = ((0==A150TextosId) ? true : false);
               A258TextosTipo = cgiGet( edtTextosTipo_Internalname);
               AssignAttri("", false, "A258TextosTipo", A258TextosTipo);
               A259TextosTitulo = cgiGet( edtTextosTitulo_Internalname);
               AssignAttri("", false, "A259TextosTitulo", A259TextosTitulo);
               A218InventarioSerial = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInventarioSerial_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgRubrosImagen_Internalname, ref  A168RubrosImagen, ref  A40000RubrosImagen_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Inventario");
               forbiddenHiddens.Add("Insert_TextosId", context.localUtil.Format( (decimal)(AV19Insert_TextosId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A121RubrosId != Z121RubrosId ) || ( A137MedidasID != Z137MedidasID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("inventario:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A137MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
                  n137MedidasID = false;
                  AssignAttri("", false, "A137MedidasID", StringUtil.LTrimStr( (decimal)(A137MedidasID), 18, 0));
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
                     sMode26 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode26;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound26 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0M0( ) ;
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
                           E110M2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120M2 ();
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
            E120M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0M26( ) ;
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
            DisableAttributes0M26( ) ;
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

      protected void CONFIRM_0M0( )
      {
         BeforeValidate0M26( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0M26( ) ;
            }
            else
            {
               CheckExtendedTable0M26( ) ;
               CloseExtendedTableCursors0M26( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode26 = Gx_mode;
            CONFIRM_0M27( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode26;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0M27( )
      {
         s218InventarioSerial = O218InventarioSerial;
         AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
         s118MonedaId = O118MonedaId;
         nGXsfl_77_idx = 0;
         while ( nGXsfl_77_idx < nRC_GXsfl_77 )
         {
            ReadRow0M27( ) ;
            if ( ( nRcdExists_27 != 0 ) || ( nIsMod_27 != 0 ) )
            {
               GetKey0M27( ) ;
               if ( ( nRcdExists_27 == 0 ) && ( nRcdDeleted_27 == 0 ) )
               {
                  if ( RcdFound27 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0M27( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0M27( ) ;
                        CloseExtendedTableCursors0M27( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O218InventarioSerial = A218InventarioSerial;
                        AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
                        O118MonedaId = A118MonedaId;
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
                  if ( RcdFound27 != 0 )
                  {
                     if ( nRcdDeleted_27 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0M27( ) ;
                        Load0M27( ) ;
                        BeforeValidate0M27( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0M27( ) ;
                           O218InventarioSerial = A218InventarioSerial;
                           AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
                           O118MonedaId = A118MonedaId;
                        }
                     }
                     else
                     {
                        if ( nIsMod_27 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0M27( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0M27( ) ;
                              CloseExtendedTableCursors0M27( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O218InventarioSerial = A218InventarioSerial;
                              AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
                              O118MonedaId = A118MonedaId;
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_27 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RUBROSID");
                        AnyError = 1;
                        GX_FocusControl = dynRubrosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtInventarioNombre_Internalname, StringUtil.RTrim( A136InventarioNombre)) ;
            ChangePostValue( edtInventarioImagen_Internalname, A189InventarioImagen) ;
            ChangePostValue( dynMonedaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))) ;
            ChangePostValue( edtInventarioCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A190InventarioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtInventarioPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtInventarioConsumoProductivo_Internalname, StringUtil.LTrim( StringUtil.NToC( A801InventarioConsumoProductivo, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtInventarioTextosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A535InventarioTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtInventarioTextosTitulo_Internalname, StringUtil.RTrim( A536InventarioTextosTitulo)) ;
            ChangePostValue( edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo)) ;
            ChangePostValue( dynEstadosGenericosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", ""))) ;
            ChangePostValue( edtInventarioRefCode_Internalname, StringUtil.RTrim( A921InventarioRefCode)) ;
            ChangePostValue( chkInventarioEsPresupuestado_Internalname, StringUtil.BoolToStr( A1005InventarioEsPresupuestado)) ;
            ChangePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z136InventarioNombre_"+sGXsfl_77_idx, StringUtil.RTrim( Z136InventarioNombre)) ;
            ChangePostValue( "ZT_"+"Z801InventarioConsumoProductivo_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( Z801InventarioConsumoProductivo, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z190InventarioCosto_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( Z190InventarioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z181InventarioPrecioFinal_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( Z181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z1004InventarioSKURelacionado_"+sGXsfl_77_idx, Z1004InventarioSKURelacionado) ;
            ChangePostValue( "ZT_"+"Z1005InventarioEsPresupuestado_"+sGXsfl_77_idx, StringUtil.BoolToStr( Z1005InventarioEsPresupuestado)) ;
            ChangePostValue( "ZT_"+"Z802I_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z802I), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z107EstadosTipo_"+sGXsfl_77_idx, StringUtil.RTrim( Z107EstadosTipo)) ;
            ChangePostValue( "ZT_"+"Z108EstadosGenericosId_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z535InventarioTextosId_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z535InventarioTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_27_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_27), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_27_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_27), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_27_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_27), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_27 != 0 )
            {
               ChangePostValue( "INVENTARIOID_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIONOMBRE_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOIMAGEN_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioImagen_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MONEDAID_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMonedaId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOCOSTO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioCosto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOPRECIOFINAL_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOCONSUMOPRODUCTIVO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioConsumoProductivo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOTEXTOSID_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioTextosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOTEXTOSTITULO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioTextosTitulo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSTIPO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGENERICOSID_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadosGenericosId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOREFCODE_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioRefCode_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOESPRESUPUESTADO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkInventarioEsPresupuestado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O218InventarioSerial = s218InventarioSerial;
         AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
         O118MonedaId = s118MonedaId;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0M0( )
      {
      }

      protected void E110M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV20WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV33Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV33Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV34GXV1 = 1;
            AssignAttri("", false, "AV34GXV1", StringUtil.LTrimStr( (decimal)(AV34GXV1), 8, 0));
            while ( AV34GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV16TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV34GXV1));
               if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "TextosId") == 0 )
               {
                  AV19Insert_TextosId = (long)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV19Insert_TextosId", StringUtil.LTrimStr( (decimal)(AV19Insert_TextosId), 18, 0));
               }
               AV34GXV1 = (int)(AV34GXV1+1);
               AssignAttri("", false, "AV34GXV1", StringUtil.LTrimStr( (decimal)(AV34GXV1), 8, 0));
            }
         }
         edtInventarioSerial_Visible = 0;
         AssignProp("", false, edtInventarioSerial_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtInventarioSerial_Visible), 5, 0), true);
      }

      protected void E120M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("inventarioww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0M26( short GX_JID )
      {
         if ( ( GX_JID == 28 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z215RubrosCosto = T000M7_A215RubrosCosto[0];
               Z138MedidasNombre = T000M7_A138MedidasNombre[0];
               Z216RubrosPrecioBase = T000M7_A216RubrosPrecioBase[0];
               Z139MedidasEstado = T000M7_A139MedidasEstado[0];
               Z218InventarioSerial = T000M7_A218InventarioSerial[0];
               Z150TextosId = T000M7_A150TextosId[0];
               Z118MonedaId = T000M7_A118MonedaId[0];
            }
            else
            {
               Z215RubrosCosto = A215RubrosCosto;
               Z138MedidasNombre = A138MedidasNombre;
               Z216RubrosPrecioBase = A216RubrosPrecioBase;
               Z139MedidasEstado = A139MedidasEstado;
               Z218InventarioSerial = A218InventarioSerial;
               Z150TextosId = A150TextosId;
               Z118MonedaId = A118MonedaId;
            }
         }
         if ( GX_JID == -28 )
         {
            Z137MedidasID = A137MedidasID;
            Z215RubrosCosto = A215RubrosCosto;
            Z138MedidasNombre = A138MedidasNombre;
            Z216RubrosPrecioBase = A216RubrosPrecioBase;
            Z139MedidasEstado = A139MedidasEstado;
            Z218InventarioSerial = A218InventarioSerial;
            Z121RubrosId = A121RubrosId;
            Z150TextosId = A150TextosId;
            Z118MonedaId = A118MonedaId;
            Z168RubrosImagen = A168RubrosImagen;
            Z40000RubrosImagen_GXI = A40000RubrosImagen_GXI;
            Z122RubrosNombre = A122RubrosNombre;
            Z258TextosTipo = A258TextosTipo;
            Z259TextosTitulo = A259TextosTitulo;
         }
      }

      protected void standaloneNotModal( )
      {
         GXARUBROSID_html0M26( ) ;
         GXAMEDIDASID_html0M26( ) ;
         edtInventarioSerial_Enabled = 0;
         AssignProp("", false, edtInventarioSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioSerial_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_150_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"textosprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TEXTOSID"+"'), id:'"+"TEXTOSID"+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"TEXTOSTIPO"+"'), id:'"+"TEXTOSTIPO"+"'"+",IOType:'inout'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtInventarioSerial_Enabled = 0;
         AssignProp("", false, edtInventarioSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioSerial_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV17RubrosId) )
         {
            A121RubrosId = AV17RubrosId;
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
         }
         if ( ! (0==AV17RubrosId) )
         {
            dynRubrosId.Enabled = 0;
            AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), true);
         }
         else
         {
            dynRubrosId.Enabled = 1;
            AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), true);
         }
         if ( ! (0==AV17RubrosId) )
         {
            dynRubrosId.Enabled = 0;
            AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), true);
         }
         if ( ! (0==AV18MedidasID) )
         {
            A137MedidasID = AV18MedidasID;
            n137MedidasID = false;
            AssignAttri("", false, "A137MedidasID", StringUtil.LTrimStr( (decimal)(A137MedidasID), 18, 0));
         }
         if ( ! (0==AV18MedidasID) )
         {
            dynMedidasID.Enabled = 0;
            AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), true);
         }
         else
         {
            dynMedidasID.Enabled = 1;
            AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), true);
         }
         if ( ! (0==AV18MedidasID) )
         {
            dynMedidasID.Enabled = 0;
            AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV19Insert_TextosId) )
         {
            edtTextosId_Enabled = 0;
            AssignProp("", false, edtTextosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTextosId_Enabled), 5, 0), true);
         }
         else
         {
            edtTextosId_Enabled = 1;
            AssignProp("", false, edtTextosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTextosId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV19Insert_TextosId) )
         {
            A150TextosId = AV19Insert_TextosId;
            n150TextosId = false;
            AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
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
         if ( IsIns( )  && (0==A118MonedaId) && ( Gx_BScreen == 0 ) )
         {
            A118MonedaId = 1;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A139MedidasEstado)) && ( Gx_BScreen == 0 ) )
         {
            A139MedidasEstado = "HAB";
            n139MedidasEstado = false;
            AssignAttri("", false, "A139MedidasEstado", A139MedidasEstado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000M8 */
            pr_default.execute(6, new Object[] {A121RubrosId});
            A40000RubrosImagen_GXI = T000M8_A40000RubrosImagen_GXI[0];
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A122RubrosNombre = T000M8_A122RubrosNombre[0];
            A168RubrosImagen = T000M8_A168RubrosImagen[0];
            AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            pr_default.close(6);
            AV33Pgmname = "Inventario";
            AssignAttri("", false, "AV33Pgmname", AV33Pgmname);
            /* Using cursor T000M9 */
            pr_default.execute(7, new Object[] {n150TextosId, A150TextosId});
            A258TextosTipo = T000M9_A258TextosTipo[0];
            AssignAttri("", false, "A258TextosTipo", A258TextosTipo);
            A259TextosTitulo = T000M9_A259TextosTitulo[0];
            AssignAttri("", false, "A259TextosTitulo", A259TextosTitulo);
            pr_default.close(7);
         }
      }

      protected void Load0M26( )
      {
         /* Using cursor T000M10 */
         pr_default.execute(8, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound26 = 1;
            A40000RubrosImagen_GXI = T000M10_A40000RubrosImagen_GXI[0];
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A122RubrosNombre = T000M10_A122RubrosNombre[0];
            A215RubrosCosto = T000M10_A215RubrosCosto[0];
            AssignAttri("", false, "A215RubrosCosto", StringUtil.LTrimStr( A215RubrosCosto, 18, 2));
            A138MedidasNombre = T000M10_A138MedidasNombre[0];
            AssignAttri("", false, "A138MedidasNombre", A138MedidasNombre);
            A216RubrosPrecioBase = T000M10_A216RubrosPrecioBase[0];
            AssignAttri("", false, "A216RubrosPrecioBase", StringUtil.LTrimStr( A216RubrosPrecioBase, 18, 2));
            A139MedidasEstado = T000M10_A139MedidasEstado[0];
            n139MedidasEstado = T000M10_n139MedidasEstado[0];
            AssignAttri("", false, "A139MedidasEstado", A139MedidasEstado);
            A258TextosTipo = T000M10_A258TextosTipo[0];
            AssignAttri("", false, "A258TextosTipo", A258TextosTipo);
            A259TextosTitulo = T000M10_A259TextosTitulo[0];
            AssignAttri("", false, "A259TextosTitulo", A259TextosTitulo);
            A218InventarioSerial = T000M10_A218InventarioSerial[0];
            AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
            A150TextosId = T000M10_A150TextosId[0];
            n150TextosId = T000M10_n150TextosId[0];
            AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
            A118MonedaId = T000M10_A118MonedaId[0];
            A168RubrosImagen = T000M10_A168RubrosImagen[0];
            AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            ZM0M26( -28) ;
         }
         pr_default.close(8);
         OnLoadActions0M26( ) ;
      }

      protected void OnLoadActions0M26( )
      {
         AV33Pgmname = "Inventario";
         AssignAttri("", false, "AV33Pgmname", AV33Pgmname);
      }

      protected void CheckExtendedTable0M26( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV33Pgmname = "Inventario";
         AssignAttri("", false, "AV33Pgmname", AV33Pgmname);
         /* Using cursor T000M8 */
         pr_default.execute(6, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40000RubrosImagen_GXI = T000M8_A40000RubrosImagen_GXI[0];
         AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A122RubrosNombre = T000M8_A122RubrosNombre[0];
         A168RubrosImagen = T000M8_A168RubrosImagen[0];
         AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
         AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         pr_default.close(6);
         if ( ! ( ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A139MedidasEstado, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A139MedidasEstado)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado de la Lista", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "MEDIDASESTADO");
            AnyError = 1;
            GX_FocusControl = cmbMedidasEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000M9 */
         pr_default.execute(7, new Object[] {n150TextosId, A150TextosId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A150TextosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Textos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TEXTOSID");
               AnyError = 1;
               GX_FocusControl = edtTextosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A258TextosTipo = T000M9_A258TextosTipo[0];
         AssignAttri("", false, "A258TextosTipo", A258TextosTipo);
         A259TextosTitulo = T000M9_A259TextosTitulo[0];
         AssignAttri("", false, "A259TextosTitulo", A259TextosTitulo);
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors0M26( )
      {
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_29( short A121RubrosId )
      {
         /* Using cursor T000M11 */
         pr_default.execute(9, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40000RubrosImagen_GXI = T000M11_A40000RubrosImagen_GXI[0];
         AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A122RubrosNombre = T000M11_A122RubrosNombre[0];
         A168RubrosImagen = T000M11_A168RubrosImagen[0];
         AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
         AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A168RubrosImagen)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000RubrosImagen_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A122RubrosNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_30( long A150TextosId )
      {
         /* Using cursor T000M12 */
         pr_default.execute(10, new Object[] {n150TextosId, A150TextosId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A150TextosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Textos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TEXTOSID");
               AnyError = 1;
               GX_FocusControl = edtTextosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A258TextosTipo = T000M12_A258TextosTipo[0];
         AssignAttri("", false, "A258TextosTipo", A258TextosTipo);
         A259TextosTitulo = T000M12_A259TextosTitulo[0];
         AssignAttri("", false, "A259TextosTitulo", A259TextosTitulo);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A258TextosTipo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A259TextosTitulo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey0M26( )
      {
         /* Using cursor T000M13 */
         pr_default.execute(11, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000M7 */
         pr_default.execute(5, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0M26( 28) ;
            RcdFound26 = 1;
            A137MedidasID = T000M7_A137MedidasID[0];
            n137MedidasID = T000M7_n137MedidasID[0];
            AssignAttri("", false, "A137MedidasID", StringUtil.LTrimStr( (decimal)(A137MedidasID), 18, 0));
            A215RubrosCosto = T000M7_A215RubrosCosto[0];
            AssignAttri("", false, "A215RubrosCosto", StringUtil.LTrimStr( A215RubrosCosto, 18, 2));
            A138MedidasNombre = T000M7_A138MedidasNombre[0];
            AssignAttri("", false, "A138MedidasNombre", A138MedidasNombre);
            A216RubrosPrecioBase = T000M7_A216RubrosPrecioBase[0];
            AssignAttri("", false, "A216RubrosPrecioBase", StringUtil.LTrimStr( A216RubrosPrecioBase, 18, 2));
            A139MedidasEstado = T000M7_A139MedidasEstado[0];
            n139MedidasEstado = T000M7_n139MedidasEstado[0];
            AssignAttri("", false, "A139MedidasEstado", A139MedidasEstado);
            A218InventarioSerial = T000M7_A218InventarioSerial[0];
            AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
            A121RubrosId = T000M7_A121RubrosId[0];
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            A150TextosId = T000M7_A150TextosId[0];
            n150TextosId = T000M7_n150TextosId[0];
            AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
            A118MonedaId = T000M7_A118MonedaId[0];
            O218InventarioSerial = A218InventarioSerial;
            AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0M26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0M26( ) ;
            }
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0M26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M26( ) ;
         if ( RcdFound26 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound26 = 0;
         /* Using cursor T000M14 */
         pr_default.execute(12, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000M14_A121RubrosId[0] < A121RubrosId ) || ( T000M14_A121RubrosId[0] == A121RubrosId ) && ( T000M14_A137MedidasID[0] < A137MedidasID ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000M14_A121RubrosId[0] > A121RubrosId ) || ( T000M14_A121RubrosId[0] == A121RubrosId ) && ( T000M14_A137MedidasID[0] > A137MedidasID ) ) )
            {
               A121RubrosId = T000M14_A121RubrosId[0];
               AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
               A137MedidasID = T000M14_A137MedidasID[0];
               n137MedidasID = T000M14_n137MedidasID[0];
               AssignAttri("", false, "A137MedidasID", StringUtil.LTrimStr( (decimal)(A137MedidasID), 18, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound26 = 0;
         /* Using cursor T000M15 */
         pr_default.execute(13, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000M15_A121RubrosId[0] > A121RubrosId ) || ( T000M15_A121RubrosId[0] == A121RubrosId ) && ( T000M15_A137MedidasID[0] > A137MedidasID ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000M15_A121RubrosId[0] < A121RubrosId ) || ( T000M15_A121RubrosId[0] == A121RubrosId ) && ( T000M15_A137MedidasID[0] < A137MedidasID ) ) )
            {
               A121RubrosId = T000M15_A121RubrosId[0];
               AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
               A137MedidasID = T000M15_A137MedidasID[0];
               n137MedidasID = T000M15_n137MedidasID[0];
               AssignAttri("", false, "A137MedidasID", StringUtil.LTrimStr( (decimal)(A137MedidasID), 18, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0M26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A218InventarioSerial = O218InventarioSerial;
            AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
            A118MonedaId = O118MonedaId;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0M26( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( ( A121RubrosId != Z121RubrosId ) || ( A137MedidasID != Z137MedidasID ) )
               {
                  A121RubrosId = Z121RubrosId;
                  AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
                  A137MedidasID = Z137MedidasID;
                  n137MedidasID = false;
                  AssignAttri("", false, "A137MedidasID", StringUtil.LTrimStr( (decimal)(A137MedidasID), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RUBROSID");
                  AnyError = 1;
                  GX_FocusControl = dynRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A218InventarioSerial = O218InventarioSerial;
                  AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
                  A118MonedaId = O118MonedaId;
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = dynRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A218InventarioSerial = O218InventarioSerial;
                  AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
                  A118MonedaId = O118MonedaId;
                  Update0M26( ) ;
                  GX_FocusControl = dynRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A121RubrosId != Z121RubrosId ) || ( A137MedidasID != Z137MedidasID ) )
               {
                  /* Insert record */
                  A218InventarioSerial = O218InventarioSerial;
                  AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
                  A118MonedaId = O118MonedaId;
                  GX_FocusControl = dynRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0M26( ) ;
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
                     A218InventarioSerial = O218InventarioSerial;
                     AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
                     A118MonedaId = O118MonedaId;
                     GX_FocusControl = dynRubrosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0M26( ) ;
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
         if ( ( A121RubrosId != Z121RubrosId ) || ( A137MedidasID != Z137MedidasID ) )
         {
            A121RubrosId = Z121RubrosId;
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            A137MedidasID = Z137MedidasID;
            n137MedidasID = false;
            AssignAttri("", false, "A137MedidasID", StringUtil.LTrimStr( (decimal)(A137MedidasID), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A218InventarioSerial = O218InventarioSerial;
            AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
            A118MonedaId = O118MonedaId;
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0M26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000M6 */
            pr_default.execute(4, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RubrosMedidas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( Z215RubrosCosto != T000M6_A215RubrosCosto[0] ) || ( StringUtil.StrCmp(Z138MedidasNombre, T000M6_A138MedidasNombre[0]) != 0 ) || ( Z216RubrosPrecioBase != T000M6_A216RubrosPrecioBase[0] ) || ( StringUtil.StrCmp(Z139MedidasEstado, T000M6_A139MedidasEstado[0]) != 0 ) || ( Z218InventarioSerial != T000M6_A218InventarioSerial[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z150TextosId != T000M6_A150TextosId[0] ) || ( Z118MonedaId != T000M6_A118MonedaId[0] ) )
            {
               if ( Z215RubrosCosto != T000M6_A215RubrosCosto[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"RubrosCosto");
                  GXUtil.WriteLogRaw("Old: ",Z215RubrosCosto);
                  GXUtil.WriteLogRaw("Current: ",T000M6_A215RubrosCosto[0]);
               }
               if ( StringUtil.StrCmp(Z138MedidasNombre, T000M6_A138MedidasNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"MedidasNombre");
                  GXUtil.WriteLogRaw("Old: ",Z138MedidasNombre);
                  GXUtil.WriteLogRaw("Current: ",T000M6_A138MedidasNombre[0]);
               }
               if ( Z216RubrosPrecioBase != T000M6_A216RubrosPrecioBase[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"RubrosPrecioBase");
                  GXUtil.WriteLogRaw("Old: ",Z216RubrosPrecioBase);
                  GXUtil.WriteLogRaw("Current: ",T000M6_A216RubrosPrecioBase[0]);
               }
               if ( StringUtil.StrCmp(Z139MedidasEstado, T000M6_A139MedidasEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"MedidasEstado");
                  GXUtil.WriteLogRaw("Old: ",Z139MedidasEstado);
                  GXUtil.WriteLogRaw("Current: ",T000M6_A139MedidasEstado[0]);
               }
               if ( Z218InventarioSerial != T000M6_A218InventarioSerial[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"InventarioSerial");
                  GXUtil.WriteLogRaw("Old: ",Z218InventarioSerial);
                  GXUtil.WriteLogRaw("Current: ",T000M6_A218InventarioSerial[0]);
               }
               if ( Z150TextosId != T000M6_A150TextosId[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"TextosId");
                  GXUtil.WriteLogRaw("Old: ",Z150TextosId);
                  GXUtil.WriteLogRaw("Current: ",T000M6_A150TextosId[0]);
               }
               if ( Z118MonedaId != T000M6_A118MonedaId[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"MonedaId");
                  GXUtil.WriteLogRaw("Old: ",Z118MonedaId);
                  GXUtil.WriteLogRaw("Current: ",T000M6_A118MonedaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"RubrosMedidas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M26( )
      {
         BeforeValidate0M26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M26( 0) ;
            CheckOptimisticConcurrency0M26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M16 */
                     pr_default.execute(14, new Object[] {n137MedidasID, A137MedidasID, A215RubrosCosto, A138MedidasNombre, A216RubrosPrecioBase, n139MedidasEstado, A139MedidasEstado, A218InventarioSerial, A121RubrosId, n150TextosId, A150TextosId, A118MonedaId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("RubrosMedidas");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ProcessLevel0M26( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0M0( ) ;
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
               Load0M26( ) ;
            }
            EndLevel0M26( ) ;
         }
         CloseExtendedTableCursors0M26( ) ;
      }

      protected void Update0M26( )
      {
         BeforeValidate0M26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M17 */
                     pr_default.execute(15, new Object[] {A215RubrosCosto, A138MedidasNombre, A216RubrosPrecioBase, n139MedidasEstado, A139MedidasEstado, A218InventarioSerial, n150TextosId, A150TextosId, A118MonedaId, A121RubrosId, n137MedidasID, A137MedidasID});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("RubrosMedidas");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RubrosMedidas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M26( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0M26( ) ;
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
            EndLevel0M26( ) ;
         }
         CloseExtendedTableCursors0M26( ) ;
      }

      protected void DeferredUpdate0M26( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0M26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M26( ) ;
            AfterConfirm0M26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M26( ) ;
               if ( AnyError == 0 )
               {
                  A218InventarioSerial = O218InventarioSerial;
                  AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
                  A118MonedaId = O118MonedaId;
                  ScanStart0M27( ) ;
                  while ( RcdFound27 != 0 )
                  {
                     getByPrimaryKey0M27( ) ;
                     Delete0M27( ) ;
                     ScanNext0M27( ) ;
                     O218InventarioSerial = A218InventarioSerial;
                     AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
                     O118MonedaId = A118MonedaId;
                  }
                  ScanEnd0M27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M18 */
                     pr_default.execute(16, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("RubrosMedidas");
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0M26( ) ;
         Gx_mode = sMode26;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0M26( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV33Pgmname = "Inventario";
            AssignAttri("", false, "AV33Pgmname", AV33Pgmname);
            /* Using cursor T000M19 */
            pr_default.execute(17, new Object[] {A121RubrosId});
            A40000RubrosImagen_GXI = T000M19_A40000RubrosImagen_GXI[0];
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A122RubrosNombre = T000M19_A122RubrosNombre[0];
            A168RubrosImagen = T000M19_A168RubrosImagen[0];
            AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
            AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
            AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            pr_default.close(17);
            /* Using cursor T000M20 */
            pr_default.execute(18, new Object[] {n150TextosId, A150TextosId});
            A258TextosTipo = T000M20_A258TextosTipo[0];
            AssignAttri("", false, "A258TextosTipo", A258TextosTipo);
            A259TextosTitulo = T000M20_A259TextosTitulo[0];
            AssignAttri("", false, "A259TextosTitulo", A259TextosTitulo);
            pr_default.close(18);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000M21 */
            pr_default.execute(19, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "MapeosListado", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void ProcessNestedLevel0M27( )
      {
         s218InventarioSerial = O218InventarioSerial;
         AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
         s118MonedaId = O118MonedaId;
         nGXsfl_77_idx = 0;
         while ( nGXsfl_77_idx < nRC_GXsfl_77 )
         {
            ReadRow0M27( ) ;
            if ( ( nRcdExists_27 != 0 ) || ( nIsMod_27 != 0 ) )
            {
               standaloneNotModal0M27( ) ;
               GetKey0M27( ) ;
               if ( ( nRcdExists_27 == 0 ) && ( nRcdDeleted_27 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0M27( ) ;
               }
               else
               {
                  if ( RcdFound27 != 0 )
                  {
                     if ( ( nRcdDeleted_27 != 0 ) && ( nRcdExists_27 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0M27( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_27 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0M27( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_27 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RUBROSID");
                        AnyError = 1;
                        GX_FocusControl = dynRubrosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O218InventarioSerial = A218InventarioSerial;
               AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
               O118MonedaId = A118MonedaId;
            }
            ChangePostValue( edtInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtInventarioNombre_Internalname, StringUtil.RTrim( A136InventarioNombre)) ;
            ChangePostValue( edtInventarioImagen_Internalname, A189InventarioImagen) ;
            ChangePostValue( dynMonedaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))) ;
            ChangePostValue( edtInventarioCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A190InventarioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtInventarioPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtInventarioConsumoProductivo_Internalname, StringUtil.LTrim( StringUtil.NToC( A801InventarioConsumoProductivo, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtInventarioTextosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A535InventarioTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtInventarioTextosTitulo_Internalname, StringUtil.RTrim( A536InventarioTextosTitulo)) ;
            ChangePostValue( edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo)) ;
            ChangePostValue( dynEstadosGenericosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", ""))) ;
            ChangePostValue( edtInventarioRefCode_Internalname, StringUtil.RTrim( A921InventarioRefCode)) ;
            ChangePostValue( chkInventarioEsPresupuestado_Internalname, StringUtil.BoolToStr( A1005InventarioEsPresupuestado)) ;
            ChangePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z136InventarioNombre_"+sGXsfl_77_idx, StringUtil.RTrim( Z136InventarioNombre)) ;
            ChangePostValue( "ZT_"+"Z801InventarioConsumoProductivo_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( Z801InventarioConsumoProductivo, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z190InventarioCosto_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( Z190InventarioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z181InventarioPrecioFinal_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( Z181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z1004InventarioSKURelacionado_"+sGXsfl_77_idx, Z1004InventarioSKURelacionado) ;
            ChangePostValue( "ZT_"+"Z1005InventarioEsPresupuestado_"+sGXsfl_77_idx, StringUtil.BoolToStr( Z1005InventarioEsPresupuestado)) ;
            ChangePostValue( "ZT_"+"Z802I_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z802I), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z107EstadosTipo_"+sGXsfl_77_idx, StringUtil.RTrim( Z107EstadosTipo)) ;
            ChangePostValue( "ZT_"+"Z108EstadosGenericosId_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z535InventarioTextosId_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z535InventarioTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_27_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_27), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_27_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_27), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_27_"+sGXsfl_77_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_27), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_27 != 0 )
            {
               ChangePostValue( "INVENTARIOID_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIONOMBRE_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOIMAGEN_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioImagen_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MONEDAID_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMonedaId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOCOSTO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioCosto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOPRECIOFINAL_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOCONSUMOPRODUCTIVO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioConsumoProductivo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOTEXTOSID_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioTextosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOTEXTOSTITULO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioTextosTitulo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSTIPO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGENERICOSID_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadosGenericosId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOREFCODE_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioRefCode_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOESPRESUPUESTADO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkInventarioEsPresupuestado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0M27( ) ;
         if ( AnyError != 0 )
         {
            O218InventarioSerial = s218InventarioSerial;
            AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
            O118MonedaId = s118MonedaId;
         }
         nRcdExists_27 = 0;
         nIsMod_27 = 0;
         nRcdDeleted_27 = 0;
      }

      protected void ProcessLevel0M26( )
      {
         /* Save parent mode. */
         sMode26 = Gx_mode;
         ProcessNestedLevel0M27( ) ;
         if ( AnyError != 0 )
         {
            O218InventarioSerial = s218InventarioSerial;
            AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
            O118MonedaId = s118MonedaId;
         }
         /* Restore parent mode. */
         Gx_mode = sMode26;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000M22 */
         pr_default.execute(20, new Object[] {A118MonedaId, A218InventarioSerial, A121RubrosId, n137MedidasID, A137MedidasID});
         pr_default.close(20);
         pr_default.SmartCacheProvider.SetUpdated("RubrosMedidas");
      }

      protected void EndLevel0M26( )
      {
         pr_default.close(4);
         if ( AnyError == 0 )
         {
            BeforeComplete0M26( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            pr_default.close(18);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("inventario",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0M0( ) ;
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
            pr_default.close(17);
            pr_default.close(18);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("inventario",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0M26( )
      {
         /* Scan By routine */
         /* Using cursor T000M23 */
         pr_default.execute(21);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound26 = 1;
            A121RubrosId = T000M23_A121RubrosId[0];
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            A137MedidasID = T000M23_A137MedidasID[0];
            n137MedidasID = T000M23_n137MedidasID[0];
            AssignAttri("", false, "A137MedidasID", StringUtil.LTrimStr( (decimal)(A137MedidasID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0M26( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound26 = 1;
            A121RubrosId = T000M23_A121RubrosId[0];
            AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
            A137MedidasID = T000M23_A137MedidasID[0];
            n137MedidasID = T000M23_n137MedidasID[0];
            AssignAttri("", false, "A137MedidasID", StringUtil.LTrimStr( (decimal)(A137MedidasID), 18, 0));
         }
      }

      protected void ScanEnd0M26( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0M26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0M26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0M26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0M26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M26( )
      {
         dynRubrosId.Enabled = 0;
         AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), true);
         dynMedidasID.Enabled = 0;
         AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), true);
         edtMedidasNombre_Enabled = 0;
         AssignProp("", false, edtMedidasNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMedidasNombre_Enabled), 5, 0), true);
         cmbMedidasEstado.Enabled = 0;
         AssignProp("", false, cmbMedidasEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMedidasEstado.Enabled), 5, 0), true);
         edtRubrosCosto_Enabled = 0;
         AssignProp("", false, edtRubrosCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosCosto_Enabled), 5, 0), true);
         edtRubrosPrecioBase_Enabled = 0;
         AssignProp("", false, edtRubrosPrecioBase_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosPrecioBase_Enabled), 5, 0), true);
         imgRubrosImagen_Enabled = 0;
         AssignProp("", false, imgRubrosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgRubrosImagen_Enabled), 5, 0), true);
         edtTextosId_Enabled = 0;
         AssignProp("", false, edtTextosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTextosId_Enabled), 5, 0), true);
         edtTextosTipo_Enabled = 0;
         AssignProp("", false, edtTextosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTextosTipo_Enabled), 5, 0), true);
         edtTextosTitulo_Enabled = 0;
         AssignProp("", false, edtTextosTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTextosTitulo_Enabled), 5, 0), true);
         dynMonedaId.Enabled = 0;
         AssignProp("", false, dynMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMonedaId.Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtInventarioSerial_Enabled = 0;
         AssignProp("", false, edtInventarioSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioSerial_Enabled), 5, 0), true);
      }

      protected void ZM0M27( short GX_JID )
      {
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z136InventarioNombre = T000M3_A136InventarioNombre[0];
               Z801InventarioConsumoProductivo = T000M3_A801InventarioConsumoProductivo[0];
               Z190InventarioCosto = T000M3_A190InventarioCosto[0];
               Z181InventarioPrecioFinal = T000M3_A181InventarioPrecioFinal[0];
               Z1004InventarioSKURelacionado = T000M3_A1004InventarioSKURelacionado[0];
               Z1005InventarioEsPresupuestado = T000M3_A1005InventarioEsPresupuestado[0];
               Z802I = T000M3_A802I[0];
               Z107EstadosTipo = T000M3_A107EstadosTipo[0];
               Z108EstadosGenericosId = T000M3_A108EstadosGenericosId[0];
               Z535InventarioTextosId = T000M3_A535InventarioTextosId[0];
            }
            else
            {
               Z136InventarioNombre = A136InventarioNombre;
               Z801InventarioConsumoProductivo = A801InventarioConsumoProductivo;
               Z190InventarioCosto = A190InventarioCosto;
               Z181InventarioPrecioFinal = A181InventarioPrecioFinal;
               Z1004InventarioSKURelacionado = A1004InventarioSKURelacionado;
               Z1005InventarioEsPresupuestado = A1005InventarioEsPresupuestado;
               Z802I = A802I;
               Z107EstadosTipo = A107EstadosTipo;
               Z108EstadosGenericosId = A108EstadosGenericosId;
               Z535InventarioTextosId = A535InventarioTextosId;
            }
         }
         if ( GX_JID == -31 )
         {
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            Z136InventarioNombre = A136InventarioNombre;
            Z189InventarioImagen = A189InventarioImagen;
            Z40001InventarioImagen_GXI = A40001InventarioImagen_GXI;
            Z801InventarioConsumoProductivo = A801InventarioConsumoProductivo;
            Z190InventarioCosto = A190InventarioCosto;
            Z181InventarioPrecioFinal = A181InventarioPrecioFinal;
            Z1004InventarioSKURelacionado = A1004InventarioSKURelacionado;
            Z1005InventarioEsPresupuestado = A1005InventarioEsPresupuestado;
            Z802I = A802I;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
            Z535InventarioTextosId = A535InventarioTextosId;
            Z537InventarioTextosTipo = A537InventarioTextosTipo;
            Z536InventarioTextosTitulo = A536InventarioTextosTitulo;
         }
      }

      protected void standaloneNotModal0M27( )
      {
         edtInventarioId_Enabled = 0;
         AssignProp("", false, edtInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioId_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtEstadosTipo_Enabled = 0;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtInventarioSerial_Enabled = 0;
         AssignProp("", false, edtInventarioSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioSerial_Enabled), 5, 0), true);
         edtInventarioSerial_Enabled = 0;
         AssignProp("", false, edtInventarioSerial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioSerial_Enabled), 5, 0), true);
      }

      protected void standaloneModal0M27( )
      {
         A107EstadosTipo = context.GetMessage( context.GetMessage( "INV", ""), "");
         if ( IsIns( )  )
         {
            A218InventarioSerial = (short)(O218InventarioSerial+1);
            AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
         }
         if ( IsIns( )  && (0==A118MonedaId) && ( Gx_BScreen == 0 ) )
         {
            A118MonedaId = 1;
         }
         if ( IsIns( )  && (0==A108EstadosGenericosId) && ( Gx_BScreen == 0 ) )
         {
            A108EstadosGenericosId = 1;
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A135InventarioId = A218InventarioSerial;
            n135InventarioId = false;
         }
         GXAESTADOSGENERICOSID_html0M27( A107EstadosTipo) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            A921InventarioRefCode = context.GetMessage( "amg", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 10, 0));
         }
      }

      protected void Load0M27( )
      {
         /* Using cursor T000M24 */
         pr_default.execute(22, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound27 = 1;
            A136InventarioNombre = T000M24_A136InventarioNombre[0];
            A40001InventarioImagen_GXI = T000M24_A40001InventarioImagen_GXI[0];
            AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_77_Refreshing);
            AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
            A801InventarioConsumoProductivo = T000M24_A801InventarioConsumoProductivo[0];
            A190InventarioCosto = T000M24_A190InventarioCosto[0];
            A181InventarioPrecioFinal = T000M24_A181InventarioPrecioFinal[0];
            A1004InventarioSKURelacionado = T000M24_A1004InventarioSKURelacionado[0];
            n1004InventarioSKURelacionado = T000M24_n1004InventarioSKURelacionado[0];
            A1005InventarioEsPresupuestado = T000M24_A1005InventarioEsPresupuestado[0];
            n1005InventarioEsPresupuestado = T000M24_n1005InventarioEsPresupuestado[0];
            A537InventarioTextosTipo = T000M24_A537InventarioTextosTipo[0];
            A536InventarioTextosTitulo = T000M24_A536InventarioTextosTitulo[0];
            A802I = T000M24_A802I[0];
            A107EstadosTipo = T000M24_A107EstadosTipo[0];
            A108EstadosGenericosId = T000M24_A108EstadosGenericosId[0];
            A535InventarioTextosId = T000M24_A535InventarioTextosId[0];
            n535InventarioTextosId = T000M24_n535InventarioTextosId[0];
            A189InventarioImagen = T000M24_A189InventarioImagen[0];
            AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_77_Refreshing);
            AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
            ZM0M27( -31) ;
         }
         pr_default.close(22);
         OnLoadActions0M27( ) ;
      }

      protected void OnLoadActions0M27( )
      {
         A921InventarioRefCode = context.GetMessage( "amg", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 10, 0));
      }

      protected void CheckExtendedTable0M27( )
      {
         nIsDirty_27 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0M27( ) ;
         nIsDirty_27 = 1;
         A921InventarioRefCode = context.GetMessage( "amg", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 10, 0));
         /* Using cursor T000M4 */
         pr_default.execute(2, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "ESTADOSGENERICOSID_" + sGXsfl_77_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynEstadosGenericosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000M5 */
         pr_default.execute(3, new Object[] {n535InventarioTextosId, A535InventarioTextosId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A535InventarioTextosId) ) )
            {
               GXCCtl = "INVENTARIOTEXTOSID_" + sGXsfl_77_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario Textos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtInventarioTextosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A537InventarioTextosTipo = T000M5_A537InventarioTextosTipo[0];
         A536InventarioTextosTitulo = T000M5_A536InventarioTextosTitulo[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0M27( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0M27( )
      {
      }

      protected void gxLoad_32( string A107EstadosTipo ,
                                int A108EstadosGenericosId )
      {
         /* Using cursor T000M25 */
         pr_default.execute(23, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GXCCtl = "ESTADOSGENERICOSID_" + sGXsfl_77_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynEstadosGenericosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(23) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(23);
      }

      protected void gxLoad_33( long A535InventarioTextosId )
      {
         /* Using cursor T000M26 */
         pr_default.execute(24, new Object[] {n535InventarioTextosId, A535InventarioTextosId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A535InventarioTextosId) ) )
            {
               GXCCtl = "INVENTARIOTEXTOSID_" + sGXsfl_77_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario Textos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtInventarioTextosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A537InventarioTextosTipo = T000M26_A537InventarioTextosTipo[0];
         A536InventarioTextosTitulo = T000M26_A536InventarioTextosTitulo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A537InventarioTextosTipo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A536InventarioTextosTitulo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void GetKey0M27( )
      {
         /* Using cursor T000M27 */
         pr_default.execute(25, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(25);
      }

      protected void getByPrimaryKey0M27( )
      {
         /* Using cursor T000M3 */
         pr_default.execute(1, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M27( 31) ;
            RcdFound27 = 1;
            InitializeNonKey0M27( ) ;
            A135InventarioId = T000M3_A135InventarioId[0];
            n135InventarioId = T000M3_n135InventarioId[0];
            A136InventarioNombre = T000M3_A136InventarioNombre[0];
            A40001InventarioImagen_GXI = T000M3_A40001InventarioImagen_GXI[0];
            AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_77_Refreshing);
            AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
            A801InventarioConsumoProductivo = T000M3_A801InventarioConsumoProductivo[0];
            A190InventarioCosto = T000M3_A190InventarioCosto[0];
            A181InventarioPrecioFinal = T000M3_A181InventarioPrecioFinal[0];
            A1004InventarioSKURelacionado = T000M3_A1004InventarioSKURelacionado[0];
            n1004InventarioSKURelacionado = T000M3_n1004InventarioSKURelacionado[0];
            A1005InventarioEsPresupuestado = T000M3_A1005InventarioEsPresupuestado[0];
            n1005InventarioEsPresupuestado = T000M3_n1005InventarioEsPresupuestado[0];
            A802I = T000M3_A802I[0];
            A107EstadosTipo = T000M3_A107EstadosTipo[0];
            A108EstadosGenericosId = T000M3_A108EstadosGenericosId[0];
            A535InventarioTextosId = T000M3_A535InventarioTextosId[0];
            n535InventarioTextosId = T000M3_n535InventarioTextosId[0];
            A189InventarioImagen = T000M3_A189InventarioImagen[0];
            AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_77_Refreshing);
            AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0M27( ) ;
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0M27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0M27( ) ;
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0M27( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0M27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000M2 */
            pr_default.execute(0, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Inventario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z136InventarioNombre, T000M2_A136InventarioNombre[0]) != 0 ) || ( Z801InventarioConsumoProductivo != T000M2_A801InventarioConsumoProductivo[0] ) || ( Z190InventarioCosto != T000M2_A190InventarioCosto[0] ) || ( Z181InventarioPrecioFinal != T000M2_A181InventarioPrecioFinal[0] ) || ( StringUtil.StrCmp(Z1004InventarioSKURelacionado, T000M2_A1004InventarioSKURelacionado[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1005InventarioEsPresupuestado != T000M2_A1005InventarioEsPresupuestado[0] ) || ( Z802I != T000M2_A802I[0] ) || ( StringUtil.StrCmp(Z107EstadosTipo, T000M2_A107EstadosTipo[0]) != 0 ) || ( Z108EstadosGenericosId != T000M2_A108EstadosGenericosId[0] ) || ( Z535InventarioTextosId != T000M2_A535InventarioTextosId[0] ) )
            {
               if ( StringUtil.StrCmp(Z136InventarioNombre, T000M2_A136InventarioNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"InventarioNombre");
                  GXUtil.WriteLogRaw("Old: ",Z136InventarioNombre);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A136InventarioNombre[0]);
               }
               if ( Z801InventarioConsumoProductivo != T000M2_A801InventarioConsumoProductivo[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"InventarioConsumoProductivo");
                  GXUtil.WriteLogRaw("Old: ",Z801InventarioConsumoProductivo);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A801InventarioConsumoProductivo[0]);
               }
               if ( Z190InventarioCosto != T000M2_A190InventarioCosto[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"InventarioCosto");
                  GXUtil.WriteLogRaw("Old: ",Z190InventarioCosto);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A190InventarioCosto[0]);
               }
               if ( Z181InventarioPrecioFinal != T000M2_A181InventarioPrecioFinal[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"InventarioPrecioFinal");
                  GXUtil.WriteLogRaw("Old: ",Z181InventarioPrecioFinal);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A181InventarioPrecioFinal[0]);
               }
               if ( StringUtil.StrCmp(Z1004InventarioSKURelacionado, T000M2_A1004InventarioSKURelacionado[0]) != 0 )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"InventarioSKURelacionado");
                  GXUtil.WriteLogRaw("Old: ",Z1004InventarioSKURelacionado);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A1004InventarioSKURelacionado[0]);
               }
               if ( Z1005InventarioEsPresupuestado != T000M2_A1005InventarioEsPresupuestado[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"InventarioEsPresupuestado");
                  GXUtil.WriteLogRaw("Old: ",Z1005InventarioEsPresupuestado);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A1005InventarioEsPresupuestado[0]);
               }
               if ( Z802I != T000M2_A802I[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"I");
                  GXUtil.WriteLogRaw("Old: ",Z802I);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A802I[0]);
               }
               if ( StringUtil.StrCmp(Z107EstadosTipo, T000M2_A107EstadosTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"EstadosTipo");
                  GXUtil.WriteLogRaw("Old: ",Z107EstadosTipo);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A107EstadosTipo[0]);
               }
               if ( Z108EstadosGenericosId != T000M2_A108EstadosGenericosId[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"EstadosGenericosId");
                  GXUtil.WriteLogRaw("Old: ",Z108EstadosGenericosId);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A108EstadosGenericosId[0]);
               }
               if ( Z535InventarioTextosId != T000M2_A535InventarioTextosId[0] )
               {
                  GXUtil.WriteLog("inventario:[seudo value changed for attri]"+"InventarioTextosId");
                  GXUtil.WriteLogRaw("Old: ",Z535InventarioTextosId);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A535InventarioTextosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Inventario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M27( )
      {
         BeforeValidate0M27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M27( 0) ;
            CheckOptimisticConcurrency0M27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M28 */
                     pr_default.execute(26, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId, A136InventarioNombre, A189InventarioImagen, A40001InventarioImagen_GXI, A801InventarioConsumoProductivo, A190InventarioCosto, A181InventarioPrecioFinal, n1004InventarioSKURelacionado, A1004InventarioSKURelacionado, n1005InventarioEsPresupuestado, A1005InventarioEsPresupuestado, A802I, A107EstadosTipo, A108EstadosGenericosId, n535InventarioTextosId, A535InventarioTextosId});
                     pr_default.close(26);
                     pr_default.SmartCacheProvider.SetUpdated("Inventario");
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
               Load0M27( ) ;
            }
            EndLevel0M27( ) ;
         }
         CloseExtendedTableCursors0M27( ) ;
      }

      protected void Update0M27( )
      {
         BeforeValidate0M27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M27( ) ;
         }
         if ( ( nIsMod_27 != 0 ) || ( nIsDirty_27 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0M27( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0M27( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0M27( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000M29 */
                        pr_default.execute(27, new Object[] {A136InventarioNombre, A801InventarioConsumoProductivo, A190InventarioCosto, A181InventarioPrecioFinal, n1004InventarioSKURelacionado, A1004InventarioSKURelacionado, n1005InventarioEsPresupuestado, A1005InventarioEsPresupuestado, A802I, A107EstadosTipo, A108EstadosGenericosId, n535InventarioTextosId, A535InventarioTextosId, A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
                        pr_default.close(27);
                        pr_default.SmartCacheProvider.SetUpdated("Inventario");
                        if ( (pr_default.getStatus(27) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Inventario"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0M27( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0M27( ) ;
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
               EndLevel0M27( ) ;
            }
         }
         CloseExtendedTableCursors0M27( ) ;
      }

      protected void DeferredUpdate0M27( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000M30 */
            pr_default.execute(28, new Object[] {A189InventarioImagen, A40001InventarioImagen_GXI, A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
            pr_default.close(28);
            pr_default.SmartCacheProvider.SetUpdated("Inventario");
         }
      }

      protected void Delete0M27( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0M27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M27( ) ;
            AfterConfirm0M27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000M31 */
                  pr_default.execute(29, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
                  pr_default.close(29);
                  pr_default.SmartCacheProvider.SetUpdated("Inventario");
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
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0M27( ) ;
         Gx_mode = sMode27;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0M27( )
      {
         standaloneModal0M27( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A921InventarioRefCode = context.GetMessage( "amg", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 10, 0)) + "-" + StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 10, 0));
            /* Using cursor T000M32 */
            pr_default.execute(30, new Object[] {n535InventarioTextosId, A535InventarioTextosId});
            A537InventarioTextosTipo = T000M32_A537InventarioTextosTipo[0];
            A536InventarioTextosTitulo = T000M32_A536InventarioTextosTitulo[0];
            pr_default.close(30);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000M33 */
            pr_default.execute(31, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T000M34 */
            pr_default.execute(32, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T000M35 */
            pr_default.execute(33, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T000M36 */
            pr_default.execute(34, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Items", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T000M37 */
            pr_default.execute(35, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comisiones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T000M38 */
            pr_default.execute(36, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "MapeosListado", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
         }
      }

      protected void EndLevel0M27( )
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

      public void ScanStart0M27( )
      {
         /* Scan By routine */
         /* Using cursor T000M39 */
         pr_default.execute(37, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         RcdFound27 = 0;
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound27 = 1;
            A135InventarioId = T000M39_A135InventarioId[0];
            n135InventarioId = T000M39_n135InventarioId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0M27( )
      {
         /* Scan next routine */
         pr_default.readNext(37);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound27 = 1;
            A135InventarioId = T000M39_A135InventarioId[0];
            n135InventarioId = T000M39_n135InventarioId[0];
         }
      }

      protected void ScanEnd0M27( )
      {
         pr_default.close(37);
      }

      protected void AfterConfirm0M27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M27( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0M27( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0M27( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0M27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M27( )
      {
         edtInventarioId_Enabled = 0;
         AssignProp("", false, edtInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioId_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtInventarioNombre_Enabled = 0;
         AssignProp("", false, edtInventarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioNombre_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtInventarioImagen_Enabled = 0;
         AssignProp("", false, edtInventarioImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioImagen_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtInventarioCosto_Enabled = 0;
         AssignProp("", false, edtInventarioCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioCosto_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtInventarioPrecioFinal_Enabled = 0;
         AssignProp("", false, edtInventarioPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtInventarioConsumoProductivo_Enabled = 0;
         AssignProp("", false, edtInventarioConsumoProductivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioConsumoProductivo_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtInventarioTextosId_Enabled = 0;
         AssignProp("", false, edtInventarioTextosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioTextosId_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtInventarioTextosTitulo_Enabled = 0;
         AssignProp("", false, edtInventarioTextosTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioTextosTitulo_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtEstadosTipo_Enabled = 0;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         dynEstadosGenericosId.Enabled = 0;
         AssignProp("", false, dynEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosGenericosId.Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtInventarioRefCode_Enabled = 0;
         AssignProp("", false, edtInventarioRefCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioRefCode_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         chkInventarioEsPresupuestado.Enabled = 0;
         AssignProp("", false, chkInventarioEsPresupuestado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkInventarioEsPresupuestado.Enabled), 5, 0), !bGXsfl_77_Refreshing);
      }

      protected void send_integrity_lvl_hashes0M27( )
      {
      }

      protected void send_integrity_lvl_hashes0M26( )
      {
      }

      protected void SubsflControlProps_7727( )
      {
         edtInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_77_idx;
         edtInventarioNombre_Internalname = "INVENTARIONOMBRE_"+sGXsfl_77_idx;
         edtInventarioImagen_Internalname = "INVENTARIOIMAGEN_"+sGXsfl_77_idx;
         dynMonedaId_Internalname = "MONEDAID_"+sGXsfl_77_idx;
         edtInventarioCosto_Internalname = "INVENTARIOCOSTO_"+sGXsfl_77_idx;
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL_"+sGXsfl_77_idx;
         edtInventarioConsumoProductivo_Internalname = "INVENTARIOCONSUMOPRODUCTIVO_"+sGXsfl_77_idx;
         edtInventarioTextosId_Internalname = "INVENTARIOTEXTOSID_"+sGXsfl_77_idx;
         imgprompt_535_Internalname = "PROMPT_535_"+sGXsfl_77_idx;
         edtInventarioTextosTitulo_Internalname = "INVENTARIOTEXTOSTITULO_"+sGXsfl_77_idx;
         edtEstadosTipo_Internalname = "ESTADOSTIPO_"+sGXsfl_77_idx;
         dynEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_77_idx;
         imgprompt_108_Internalname = "PROMPT_108_"+sGXsfl_77_idx;
         edtInventarioRefCode_Internalname = "INVENTARIOREFCODE_"+sGXsfl_77_idx;
         chkInventarioEsPresupuestado_Internalname = "INVENTARIOESPRESUPUESTADO_"+sGXsfl_77_idx;
      }

      protected void SubsflControlProps_fel_7727( )
      {
         edtInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_77_fel_idx;
         edtInventarioNombre_Internalname = "INVENTARIONOMBRE_"+sGXsfl_77_fel_idx;
         edtInventarioImagen_Internalname = "INVENTARIOIMAGEN_"+sGXsfl_77_fel_idx;
         dynMonedaId_Internalname = "MONEDAID_"+sGXsfl_77_fel_idx;
         edtInventarioCosto_Internalname = "INVENTARIOCOSTO_"+sGXsfl_77_fel_idx;
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL_"+sGXsfl_77_fel_idx;
         edtInventarioConsumoProductivo_Internalname = "INVENTARIOCONSUMOPRODUCTIVO_"+sGXsfl_77_fel_idx;
         edtInventarioTextosId_Internalname = "INVENTARIOTEXTOSID_"+sGXsfl_77_fel_idx;
         imgprompt_535_Internalname = "PROMPT_535_"+sGXsfl_77_fel_idx;
         edtInventarioTextosTitulo_Internalname = "INVENTARIOTEXTOSTITULO_"+sGXsfl_77_fel_idx;
         edtEstadosTipo_Internalname = "ESTADOSTIPO_"+sGXsfl_77_fel_idx;
         dynEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_77_fel_idx;
         imgprompt_108_Internalname = "PROMPT_108_"+sGXsfl_77_fel_idx;
         edtInventarioRefCode_Internalname = "INVENTARIOREFCODE_"+sGXsfl_77_fel_idx;
         chkInventarioEsPresupuestado_Internalname = "INVENTARIOESPRESUPUESTADO_"+sGXsfl_77_fel_idx;
      }

      protected void AddRow0M27( )
      {
         nGXsfl_77_idx = (int)(nGXsfl_77_idx+1);
         sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
         SubsflControlProps_7727( ) ;
         SendRow0M27( ) ;
      }

      protected void SendRow0M27( )
      {
         Gridlevel_listaRow = GXWebRow.GetNew(context);
         if ( subGridlevel_lista_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_lista_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_lista_Class, "") != 0 )
            {
               subGridlevel_lista_Linesclass = subGridlevel_lista_Class+"Odd";
            }
         }
         else if ( subGridlevel_lista_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_lista_Backstyle = 0;
            subGridlevel_lista_Backcolor = subGridlevel_lista_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_lista_Class, "") != 0 )
            {
               subGridlevel_lista_Linesclass = subGridlevel_lista_Class+"Uniform";
            }
         }
         else if ( subGridlevel_lista_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_lista_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_lista_Class, "") != 0 )
            {
               subGridlevel_lista_Linesclass = subGridlevel_lista_Class+"Odd";
            }
            subGridlevel_lista_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_lista_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_lista_Backstyle = 1;
            if ( ((int)((nGXsfl_77_idx) % (2))) == 0 )
            {
               subGridlevel_lista_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_lista_Class, "") != 0 )
               {
                  subGridlevel_lista_Linesclass = subGridlevel_lista_Class+"Even";
               }
            }
            else
            {
               subGridlevel_lista_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_lista_Class, "") != 0 )
               {
                  subGridlevel_lista_Linesclass = subGridlevel_lista_Class+"Odd";
               }
            }
         }
         imgprompt_535_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"textosprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INVENTARIOTEXTOSID_"+sGXsfl_77_idx+"'), id:'"+"INVENTARIOTEXTOSID_"+sGXsfl_77_idx+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"INVENTARIOTEXTOSTIPO"+"'), id:'"+"INVENTARIOTEXTOSTIPO"+"'"+",IOType:'inout'}"+"],"+"gx.dom.form()."+"nIsMod_27_"+sGXsfl_77_idx+","+"'', false"+","+"false"+");");
         imgprompt_108_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00o1.aspx"+"',["+"'"+GXUtil.ValueEncode( StringUtil.StringReplace( StringUtil.RTrim( A107EstadosTipo), "'", "\\'"))+"'"+","+"{Ctrl:gx.dom.el('"+"ESTADOSGENERICOSID_"+sGXsfl_77_idx+"'), id:'"+"ESTADOSGENERICOSID_"+sGXsfl_77_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_27_"+sGXsfl_77_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_77_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_77_idx + "',77)\"";
         ROClassString = "Attribute";
         Gridlevel_listaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtInventarioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A135InventarioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A135InventarioId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,78);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtInventarioId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_77_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_77_idx + "',77)\"";
         ROClassString = "Attribute";
         Gridlevel_listaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioNombre_Internalname,StringUtil.RTrim( A136InventarioNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtInventarioNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Static Bitmap Variable */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_77_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_77_idx + "',77)\"";
         ClassString = "Attribute";
         StyleString = "";
         A189InventarioImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001InventarioImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.PathToRelativeUrl( A189InventarioImagen));
         Gridlevel_listaRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtInventarioImagen_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"",(string)"",(string)"",(string)"",(short)0,(bool)A189InventarioImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
         AssignProp("", false, edtInventarioImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.PathToRelativeUrl( A189InventarioImagen)), !bGXsfl_77_Refreshing);
         AssignProp("", false, edtInventarioImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A189InventarioImagen_IsBlob), !bGXsfl_77_Refreshing);
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_77_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_77_idx + "',77)\"";
         if ( ( dynMonedaId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "MONEDAID_" + sGXsfl_77_idx;
            dynMonedaId.Name = GXCCtl;
            dynMonedaId.WebTags = "";
            dynMonedaId.removeAllItems();
            /* Using cursor T000M40 */
            pr_default.execute(38);
            while ( (pr_default.getStatus(38) != 101) )
            {
               dynMonedaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000M40_A118MonedaId[0]), 4, 0)), T000M40_A119MonedaISOSimbolo[0], 0);
               pr_default.readNext(38);
            }
            pr_default.close(38);
            if ( dynMonedaId.ItemCount > 0 )
            {
               if ( IsIns( ) && (0==A118MonedaId) )
               {
                  A118MonedaId = 1;
               }
            }
         }
         /* ComboBox */
         Gridlevel_listaRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynMonedaId,(string)dynMonedaId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0)),(short)1,(string)dynMonedaId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynMonedaId.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"",(string)"",(bool)true,(short)0});
         dynMonedaId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A118MonedaId), 4, 0));
         AssignProp("", false, dynMonedaId_Internalname, "Values", (string)(dynMonedaId.ToJavascriptSource()), !bGXsfl_77_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_77_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_77_idx + "',77)\"";
         ROClassString = "Attribute";
         Gridlevel_listaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioCosto_Internalname,StringUtil.LTrim( StringUtil.NToC( A190InventarioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtInventarioCosto_Enabled!=0) ? context.localUtil.Format( A190InventarioCosto, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A190InventarioCosto, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,82);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioCosto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtInventarioCosto_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_77_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 83,'',false,'" + sGXsfl_77_idx + "',77)\"";
         ROClassString = "Attribute";
         Gridlevel_listaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtInventarioPrecioFinal_Enabled!=0) ? context.localUtil.Format( A181InventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A181InventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,83);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtInventarioPrecioFinal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_77_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_77_idx + "',77)\"";
         ROClassString = "Attribute";
         Gridlevel_listaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioConsumoProductivo_Internalname,StringUtil.LTrim( StringUtil.NToC( A801InventarioConsumoProductivo, 10, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtInventarioConsumoProductivo_Enabled!=0) ? context.localUtil.Format( A801InventarioConsumoProductivo, "ZZZZZZ9.99") : context.localUtil.Format( A801InventarioConsumoProductivo, "ZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,84);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioConsumoProductivo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtInventarioConsumoProductivo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)0,(bool)true,(string)"HoraCapacidadProductiva",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_77_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_77_idx + "',77)\"";
         ROClassString = "Attribute";
         Gridlevel_listaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioTextosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A535InventarioTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtInventarioTextosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A535InventarioTextosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A535InventarioTextosId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,85);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioTextosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtInventarioTextosId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_535_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_535_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_listaRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_535_Internalname,(string)sImgUrl,(string)imgprompt_535_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_535_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_77_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_77_idx + "',77)\"";
         ROClassString = "Attribute";
         Gridlevel_listaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioTextosTitulo_Internalname,StringUtil.RTrim( A536InventarioTextosTitulo),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioTextosTitulo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtInventarioTextosTitulo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_listaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosTipo_Internalname,StringUtil.RTrim( A107EstadosTipo),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtEstadosTipo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         GXAESTADOSGENERICOSID_html0M27( A107EstadosTipo) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_77_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_77_idx + "',77)\"";
         if ( ( dynEstadosGenericosId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "ESTADOSGENERICOSID_" + sGXsfl_77_idx;
            dynEstadosGenericosId.Name = GXCCtl;
            dynEstadosGenericosId.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_listaRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynEstadosGenericosId,(string)dynEstadosGenericosId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0)),(short)1,(string)dynEstadosGenericosId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynEstadosGenericosId.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"",(string)"",(bool)true,(short)0});
         dynEstadosGenericosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
         AssignProp("", false, dynEstadosGenericosId_Internalname, "Values", (string)(dynEstadosGenericosId.ToJavascriptSource()), !bGXsfl_77_Refreshing);
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_108_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_108_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_listaRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_108_Internalname,(string)sImgUrl,(string)imgprompt_108_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_108_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_77_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_77_idx + "',77)\"";
         ROClassString = "Attribute";
         Gridlevel_listaRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioRefCode_Internalname,StringUtil.RTrim( A921InventarioRefCode),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioRefCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtInventarioRefCode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)77,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_27_" + sGXsfl_77_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_77_idx + "',77)\"";
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "INVENTARIOESPRESUPUESTADO_" + sGXsfl_77_idx;
         chkInventarioEsPresupuestado.Name = GXCCtl;
         chkInventarioEsPresupuestado.WebTags = "";
         chkInventarioEsPresupuestado.Caption = "";
         AssignProp("", false, chkInventarioEsPresupuestado_Internalname, "TitleCaption", chkInventarioEsPresupuestado.Caption, !bGXsfl_77_Refreshing);
         chkInventarioEsPresupuestado.CheckedValue = "false";
         A1005InventarioEsPresupuestado = StringUtil.StrToBool( StringUtil.BoolToStr( A1005InventarioEsPresupuestado));
         n1005InventarioEsPresupuestado = false;
         Gridlevel_listaRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkInventarioEsPresupuestado_Internalname,StringUtil.BoolToStr( A1005InventarioEsPresupuestado),(string)"",(string)"",(short)-1,chkInventarioEsPresupuestado.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(90, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,90);\""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_listaRow);
         send_integrity_lvl_hashes0M27( ) ;
         GXCCtl = "Z135InventarioId_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z136InventarioNombre_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z136InventarioNombre));
         GXCCtl = "Z801InventarioConsumoProductivo_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z801InventarioConsumoProductivo, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z190InventarioCosto_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z190InventarioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z181InventarioPrecioFinal_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z1004InventarioSKURelacionado_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z1004InventarioSKURelacionado);
         GXCCtl = "Z1005InventarioEsPresupuestado_" + sGXsfl_77_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z1005InventarioEsPresupuestado);
         GXCCtl = "Z802I_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z802I), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z107EstadosTipo_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z107EstadosTipo));
         GXCCtl = "Z108EstadosGenericosId_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z535InventarioTextosId_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z535InventarioTextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_27_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_27), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_27_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_27), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_27_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_27), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_77_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vRUBROSID_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMEDIDASID_" + sGXsfl_77_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "INVENTARIOIMAGEN_" + sGXsfl_77_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A189InventarioImagen);
         GxWebStd.gx_hidden_field( context, "INVENTARIOID_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIONOMBRE_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOIMAGEN_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioImagen_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MONEDAID_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMonedaId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOCOSTO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioCosto_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOPRECIOFINAL_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOCONSUMOPRODUCTIVO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioConsumoProductivo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOTEXTOSID_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioTextosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOTEXTOSTITULO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioTextosTitulo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSTIPO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSID_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadosGenericosId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOREFCODE_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioRefCode_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOESPRESUPUESTADO_"+sGXsfl_77_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkInventarioEsPresupuestado.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_535_"+sGXsfl_77_idx+"Link", StringUtil.RTrim( imgprompt_535_Link));
         GxWebStd.gx_hidden_field( context, "PROMPT_108_"+sGXsfl_77_idx+"Link", StringUtil.RTrim( imgprompt_108_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_listaContainer.AddRow(Gridlevel_listaRow);
      }

      protected void ReadRow0M27( )
      {
         nGXsfl_77_idx = (int)(nGXsfl_77_idx+1);
         sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
         SubsflControlProps_7727( ) ;
         edtInventarioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOID_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtInventarioNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIONOMBRE_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtInventarioImagen_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOIMAGEN_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynMonedaId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MONEDAID_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtInventarioCosto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOCOSTO_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtInventarioPrecioFinal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOPRECIOFINAL_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtInventarioConsumoProductivo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOCONSUMOPRODUCTIVO_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtInventarioTextosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOTEXTOSID_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtInventarioTextosTitulo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOTEXTOSTITULO_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtEstadosTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSTIPO_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynEstadosGenericosId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSID_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtInventarioRefCode_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOREFCODE_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         chkInventarioEsPresupuestado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOESPRESUPUESTADO_"+sGXsfl_77_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_150_Link = cgiGet( "PROMPT_535_"+sGXsfl_77_idx+"Link");
         imgprompt_150_Link = cgiGet( "PROMPT_108_"+sGXsfl_77_idx+"Link");
         A135InventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtInventarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         A136InventarioNombre = cgiGet( edtInventarioNombre_Internalname);
         A189InventarioImagen = cgiGet( edtInventarioImagen_Internalname);
         dynMonedaId.Name = dynMonedaId_Internalname;
         dynMonedaId.CurrentValue = cgiGet( dynMonedaId_Internalname);
         A118MonedaId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynMonedaId_Internalname), "."), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtInventarioCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInventarioCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
         {
            GXCCtl = "INVENTARIOCOSTO_" + sGXsfl_77_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInventarioCosto_Internalname;
            wbErr = true;
            A190InventarioCosto = 0;
         }
         else
         {
            A190InventarioCosto = context.localUtil.CToN( cgiGet( edtInventarioCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
         {
            GXCCtl = "INVENTARIOPRECIOFINAL_" + sGXsfl_77_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInventarioPrecioFinal_Internalname;
            wbErr = true;
            A181InventarioPrecioFinal = 0;
         }
         else
         {
            A181InventarioPrecioFinal = context.localUtil.CToN( cgiGet( edtInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtInventarioConsumoProductivo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInventarioConsumoProductivo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
         {
            GXCCtl = "INVENTARIOCONSUMOPRODUCTIVO_" + sGXsfl_77_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInventarioConsumoProductivo_Internalname;
            wbErr = true;
            A801InventarioConsumoProductivo = 0;
         }
         else
         {
            A801InventarioConsumoProductivo = context.localUtil.CToN( cgiGet( edtInventarioConsumoProductivo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtInventarioTextosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInventarioTextosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "INVENTARIOTEXTOSID_" + sGXsfl_77_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInventarioTextosId_Internalname;
            wbErr = true;
            A535InventarioTextosId = 0;
            n535InventarioTextosId = false;
         }
         else
         {
            A535InventarioTextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtInventarioTextosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n535InventarioTextosId = false;
         }
         n535InventarioTextosId = ((0==A535InventarioTextosId) ? true : false);
         A536InventarioTextosTitulo = cgiGet( edtInventarioTextosTitulo_Internalname);
         A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
         dynEstadosGenericosId.Name = dynEstadosGenericosId_Internalname;
         dynEstadosGenericosId.CurrentValue = cgiGet( dynEstadosGenericosId_Internalname);
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynEstadosGenericosId_Internalname), "."), 18, MidpointRounding.ToEven));
         A921InventarioRefCode = cgiGet( edtInventarioRefCode_Internalname);
         A1005InventarioEsPresupuestado = StringUtil.StrToBool( cgiGet( chkInventarioEsPresupuestado_Internalname));
         n1005InventarioEsPresupuestado = false;
         n1005InventarioEsPresupuestado = ((false==A1005InventarioEsPresupuestado) ? true : false);
         GXCCtl = "Z135InventarioId_" + sGXsfl_77_idx;
         Z135InventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z136InventarioNombre_" + sGXsfl_77_idx;
         Z136InventarioNombre = cgiGet( GXCCtl);
         GXCCtl = "Z801InventarioConsumoProductivo_" + sGXsfl_77_idx;
         Z801InventarioConsumoProductivo = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z190InventarioCosto_" + sGXsfl_77_idx;
         Z190InventarioCosto = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z181InventarioPrecioFinal_" + sGXsfl_77_idx;
         Z181InventarioPrecioFinal = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z1004InventarioSKURelacionado_" + sGXsfl_77_idx;
         Z1004InventarioSKURelacionado = cgiGet( GXCCtl);
         n1004InventarioSKURelacionado = (String.IsNullOrEmpty(StringUtil.RTrim( A1004InventarioSKURelacionado)) ? true : false);
         GXCCtl = "Z1005InventarioEsPresupuestado_" + sGXsfl_77_idx;
         Z1005InventarioEsPresupuestado = StringUtil.StrToBool( cgiGet( GXCCtl));
         n1005InventarioEsPresupuestado = ((false==A1005InventarioEsPresupuestado) ? true : false);
         GXCCtl = "Z802I_" + sGXsfl_77_idx;
         Z802I = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z107EstadosTipo_" + sGXsfl_77_idx;
         Z107EstadosTipo = cgiGet( GXCCtl);
         GXCCtl = "Z108EstadosGenericosId_" + sGXsfl_77_idx;
         Z108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z535InventarioTextosId_" + sGXsfl_77_idx;
         Z535InventarioTextosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n535InventarioTextosId = ((0==A535InventarioTextosId) ? true : false);
         GXCCtl = "Z1004InventarioSKURelacionado_" + sGXsfl_77_idx;
         A1004InventarioSKURelacionado = cgiGet( GXCCtl);
         n1004InventarioSKURelacionado = false;
         n1004InventarioSKURelacionado = (String.IsNullOrEmpty(StringUtil.RTrim( A1004InventarioSKURelacionado)) ? true : false);
         GXCCtl = "Z802I_" + sGXsfl_77_idx;
         A802I = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_27_" + sGXsfl_77_idx;
         nRcdDeleted_27 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_27_" + sGXsfl_77_idx;
         nRcdExists_27 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_27_" + sGXsfl_77_idx;
         nIsMod_27 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         getMultimediaValue(edtInventarioImagen_Internalname, ref  A189InventarioImagen, ref  A40001InventarioImagen_GXI);
      }

      protected void assign_properties_default( )
      {
         defedtEstadosTipo_Enabled = edtEstadosTipo_Enabled;
         defedtInventarioId_Enabled = edtInventarioId_Enabled;
      }

      protected void ConfirmValues0M0( )
      {
         nGXsfl_77_idx = 0;
         sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
         SubsflControlProps_7727( ) ;
         while ( nGXsfl_77_idx < nRC_GXsfl_77 )
         {
            nGXsfl_77_idx = (int)(nGXsfl_77_idx+1);
            sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
            SubsflControlProps_7727( ) ;
            ChangePostValue( "Z135InventarioId_"+sGXsfl_77_idx, cgiGet( "ZT_"+"Z135InventarioId_"+sGXsfl_77_idx)) ;
            DeletePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_77_idx) ;
            ChangePostValue( "Z136InventarioNombre_"+sGXsfl_77_idx, cgiGet( "ZT_"+"Z136InventarioNombre_"+sGXsfl_77_idx)) ;
            DeletePostValue( "ZT_"+"Z136InventarioNombre_"+sGXsfl_77_idx) ;
            ChangePostValue( "Z801InventarioConsumoProductivo_"+sGXsfl_77_idx, cgiGet( "ZT_"+"Z801InventarioConsumoProductivo_"+sGXsfl_77_idx)) ;
            DeletePostValue( "ZT_"+"Z801InventarioConsumoProductivo_"+sGXsfl_77_idx) ;
            ChangePostValue( "Z190InventarioCosto_"+sGXsfl_77_idx, cgiGet( "ZT_"+"Z190InventarioCosto_"+sGXsfl_77_idx)) ;
            DeletePostValue( "ZT_"+"Z190InventarioCosto_"+sGXsfl_77_idx) ;
            ChangePostValue( "Z181InventarioPrecioFinal_"+sGXsfl_77_idx, cgiGet( "ZT_"+"Z181InventarioPrecioFinal_"+sGXsfl_77_idx)) ;
            DeletePostValue( "ZT_"+"Z181InventarioPrecioFinal_"+sGXsfl_77_idx) ;
            ChangePostValue( "Z1004InventarioSKURelacionado_"+sGXsfl_77_idx, cgiGet( "ZT_"+"Z1004InventarioSKURelacionado_"+sGXsfl_77_idx)) ;
            DeletePostValue( "ZT_"+"Z1004InventarioSKURelacionado_"+sGXsfl_77_idx) ;
            ChangePostValue( "Z1005InventarioEsPresupuestado_"+sGXsfl_77_idx, cgiGet( "ZT_"+"Z1005InventarioEsPresupuestado_"+sGXsfl_77_idx)) ;
            DeletePostValue( "ZT_"+"Z1005InventarioEsPresupuestado_"+sGXsfl_77_idx) ;
            ChangePostValue( "Z802I_"+sGXsfl_77_idx, cgiGet( "ZT_"+"Z802I_"+sGXsfl_77_idx)) ;
            DeletePostValue( "ZT_"+"Z802I_"+sGXsfl_77_idx) ;
            ChangePostValue( "Z107EstadosTipo_"+sGXsfl_77_idx, cgiGet( "ZT_"+"Z107EstadosTipo_"+sGXsfl_77_idx)) ;
            DeletePostValue( "ZT_"+"Z107EstadosTipo_"+sGXsfl_77_idx) ;
            ChangePostValue( "Z108EstadosGenericosId_"+sGXsfl_77_idx, cgiGet( "ZT_"+"Z108EstadosGenericosId_"+sGXsfl_77_idx)) ;
            DeletePostValue( "ZT_"+"Z108EstadosGenericosId_"+sGXsfl_77_idx) ;
            ChangePostValue( "Z535InventarioTextosId_"+sGXsfl_77_idx, cgiGet( "ZT_"+"Z535InventarioTextosId_"+sGXsfl_77_idx)) ;
            DeletePostValue( "ZT_"+"Z535InventarioTextosId_"+sGXsfl_77_idx) ;
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
         GXEncryptionTmp = "inventario.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV17RubrosId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV18MedidasID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("inventario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Inventario");
         forbiddenHiddens.Add("Insert_TextosId", context.localUtil.Format( (decimal)(AV19Insert_TextosId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("inventario:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z121RubrosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z137MedidasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z215RubrosCosto", StringUtil.LTrim( StringUtil.NToC( Z215RubrosCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z138MedidasNombre", StringUtil.RTrim( Z138MedidasNombre));
         GxWebStd.gx_hidden_field( context, "Z216RubrosPrecioBase", StringUtil.LTrim( StringUtil.NToC( Z216RubrosPrecioBase, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z139MedidasEstado", StringUtil.RTrim( Z139MedidasEstado));
         GxWebStd.gx_hidden_field( context, "Z218InventarioSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z218InventarioSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z150TextosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z150TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z118MonedaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O218InventarioSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(O218InventarioSerial), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_77", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_77_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N150TextosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A150TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vRUBROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17RubrosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMEDIDASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18MedidasID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_TEXTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19Insert_TextosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "RUBROSIMAGEN_GXI", A40000RubrosImagen_GXI);
         GxWebStd.gx_hidden_field( context, "RUBROSNOMBRE", StringUtil.RTrim( A122RubrosNombre));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV33Pgmname));
         GxWebStd.gx_hidden_field( context, "INVENTARIOIMAGEN_GXI", A40001InventarioImagen_GXI);
         GxWebStd.gx_hidden_field( context, "INVENTARIOSKURELACIONADO", A1004InventarioSKURelacionado);
         GxWebStd.gx_hidden_field( context, "I", StringUtil.LTrim( StringUtil.NToC( (decimal)(A802I), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOTEXTOSTIPO", StringUtil.RTrim( A537InventarioTextosTipo));
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "inventario.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV17RubrosId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV18MedidasID,18,0));
         return formatLink("inventario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Inventario" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Inventario", "") ;
      }

      protected void InitializeNonKey0M26( )
      {
         A150TextosId = 0;
         n150TextosId = false;
         AssignAttri("", false, "A150TextosId", StringUtil.LTrimStr( (decimal)(A150TextosId), 18, 0));
         n150TextosId = ((0==A150TextosId) ? true : false);
         A168RubrosImagen = "";
         AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
         AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A40000RubrosImagen_GXI = "";
         AssignProp("", false, imgRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), true);
         AssignProp("", false, imgRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A122RubrosNombre = "";
         AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
         A215RubrosCosto = 0;
         AssignAttri("", false, "A215RubrosCosto", StringUtil.LTrimStr( A215RubrosCosto, 18, 2));
         A138MedidasNombre = "";
         AssignAttri("", false, "A138MedidasNombre", A138MedidasNombre);
         A216RubrosPrecioBase = 0;
         AssignAttri("", false, "A216RubrosPrecioBase", StringUtil.LTrimStr( A216RubrosPrecioBase, 18, 2));
         A258TextosTipo = "";
         AssignAttri("", false, "A258TextosTipo", A258TextosTipo);
         A259TextosTitulo = "";
         AssignAttri("", false, "A259TextosTitulo", A259TextosTitulo);
         A218InventarioSerial = 0;
         AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
         A139MedidasEstado = "HAB";
         n139MedidasEstado = false;
         AssignAttri("", false, "A139MedidasEstado", A139MedidasEstado);
         A118MonedaId = 1;
         O218InventarioSerial = A218InventarioSerial;
         AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
         Z215RubrosCosto = 0;
         Z138MedidasNombre = "";
         Z216RubrosPrecioBase = 0;
         Z139MedidasEstado = "";
         Z218InventarioSerial = 0;
         Z150TextosId = 0;
         Z118MonedaId = 0;
      }

      protected void InitAll0M26( )
      {
         A121RubrosId = 0;
         AssignAttri("", false, "A121RubrosId", StringUtil.LTrimStr( (decimal)(A121RubrosId), 4, 0));
         A137MedidasID = 0;
         n137MedidasID = false;
         AssignAttri("", false, "A137MedidasID", StringUtil.LTrimStr( (decimal)(A137MedidasID), 18, 0));
         InitializeNonKey0M26( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A118MonedaId = i118MonedaId;
         A139MedidasEstado = i139MedidasEstado;
         n139MedidasEstado = false;
         AssignAttri("", false, "A139MedidasEstado", A139MedidasEstado);
      }

      protected void InitializeNonKey0M27( )
      {
         A107EstadosTipo = "";
         A921InventarioRefCode = "";
         A136InventarioNombre = "";
         A189InventarioImagen = "";
         AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_77_Refreshing);
         AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
         A40001InventarioImagen_GXI = "";
         AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40001InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_77_Refreshing);
         AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
         A801InventarioConsumoProductivo = 0;
         A190InventarioCosto = 0;
         A181InventarioPrecioFinal = 0;
         A1004InventarioSKURelacionado = "";
         n1004InventarioSKURelacionado = false;
         AssignAttri("", false, "A1004InventarioSKURelacionado", A1004InventarioSKURelacionado);
         A1005InventarioEsPresupuestado = false;
         n1005InventarioEsPresupuestado = false;
         A535InventarioTextosId = 0;
         n535InventarioTextosId = false;
         A537InventarioTextosTipo = "";
         AssignAttri("", false, "A537InventarioTextosTipo", A537InventarioTextosTipo);
         A536InventarioTextosTitulo = "";
         A802I = 0;
         AssignAttri("", false, "A802I", StringUtil.LTrimStr( (decimal)(A802I), 4, 0));
         A108EstadosGenericosId = 1;
         Z136InventarioNombre = "";
         Z801InventarioConsumoProductivo = 0;
         Z190InventarioCosto = 0;
         Z181InventarioPrecioFinal = 0;
         Z1004InventarioSKURelacionado = "";
         Z1005InventarioEsPresupuestado = false;
         Z802I = 0;
         Z107EstadosTipo = "";
         Z108EstadosGenericosId = 0;
         Z535InventarioTextosId = 0;
      }

      protected void InitAll0M27( )
      {
         A135InventarioId = 0;
         n135InventarioId = false;
         InitializeNonKey0M27( ) ;
      }

      protected void StandaloneModalInsert0M27( )
      {
         A107EstadosTipo = i107EstadosTipo;
         A218InventarioSerial = i218InventarioSerial;
         AssignAttri("", false, "A218InventarioSerial", StringUtil.LTrimStr( (decimal)(A218InventarioSerial), 4, 0));
         A118MonedaId = i118MonedaId;
         A108EstadosGenericosId = i108EstadosGenericosId;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932001838", true, true, false);
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
         context.AddJavascriptSource("inventario.js", "?2026932001838", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties27( )
      {
         edtEstadosTipo_Enabled = defedtEstadosTipo_Enabled;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), !bGXsfl_77_Refreshing);
         edtInventarioId_Enabled = defedtInventarioId_Enabled;
         AssignProp("", false, edtInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioId_Enabled), 5, 0), !bGXsfl_77_Refreshing);
      }

      protected void StartGridControl77( )
      {
         Gridlevel_listaContainer.AddObjectProperty("GridName", "Gridlevel_lista");
         Gridlevel_listaContainer.AddObjectProperty("Header", subGridlevel_lista_Header);
         Gridlevel_listaContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_listaContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_listaContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_listaContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_lista_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_listaContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_listaContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioId_Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A136InventarioNombre)));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", context.convertURL( A189InventarioImagen));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioImagen_Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMonedaId.Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A190InventarioCosto, 18, 2, ".", ""))));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioCosto_Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", ""))));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A801InventarioConsumoProductivo, 10, 2, ".", ""))));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioConsumoProductivo_Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A535InventarioTextosId), 18, 0, ".", ""))));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioTextosId_Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A536InventarioTextosTitulo)));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioTextosTitulo_Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A107EstadosTipo)));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", ""))));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynEstadosGenericosId.Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A921InventarioRefCode)));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioRefCode_Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_listaColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A1005InventarioEsPresupuestado)));
         Gridlevel_listaColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkInventarioEsPresupuestado.Enabled), 5, 0, ".", "")));
         Gridlevel_listaContainer.AddColumnProperties(Gridlevel_listaColumn);
         Gridlevel_listaContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_lista_Selectedindex), 4, 0, ".", "")));
         Gridlevel_listaContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_lista_Allowselection), 1, 0, ".", "")));
         Gridlevel_listaContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_lista_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_listaContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_lista_Allowhovering), 1, 0, ".", "")));
         Gridlevel_listaContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_lista_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_listaContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_lista_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_listaContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_lista_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         dynRubrosId_Internalname = "RUBROSID";
         dynMedidasID_Internalname = "MEDIDASID";
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE";
         cmbMedidasEstado_Internalname = "MEDIDASESTADO";
         edtRubrosCosto_Internalname = "RUBROSCOSTO";
         edtRubrosPrecioBase_Internalname = "RUBROSPRECIOBASE";
         divTb1_Internalname = "TB1";
         imgRubrosImagen_Internalname = "RUBROSIMAGEN";
         divTb2_Internalname = "TB2";
         edtTextosId_Internalname = "TEXTOSID";
         edtTextosTipo_Internalname = "TEXTOSTIPO";
         edtTextosTitulo_Internalname = "TEXTOSTITULO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtInventarioId_Internalname = "INVENTARIOID";
         edtInventarioNombre_Internalname = "INVENTARIONOMBRE";
         edtInventarioImagen_Internalname = "INVENTARIOIMAGEN";
         dynMonedaId_Internalname = "MONEDAID";
         edtInventarioCosto_Internalname = "INVENTARIOCOSTO";
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL";
         edtInventarioConsumoProductivo_Internalname = "INVENTARIOCONSUMOPRODUCTIVO";
         edtInventarioTextosId_Internalname = "INVENTARIOTEXTOSID";
         edtInventarioTextosTitulo_Internalname = "INVENTARIOTEXTOSTITULO";
         edtEstadosTipo_Internalname = "ESTADOSTIPO";
         dynEstadosGenericosId_Internalname = "ESTADOSGENERICOSID";
         edtInventarioRefCode_Internalname = "INVENTARIOREFCODE";
         chkInventarioEsPresupuestado_Internalname = "INVENTARIOESPRESUPUESTADO";
         divTableleaflevel_lista_Internalname = "TABLELEAFLEVEL_LISTA";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtInventarioSerial_Internalname = "INVENTARIOSERIAL";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_150_Internalname = "PROMPT_150";
         imgprompt_535_Internalname = "PROMPT_535";
         imgprompt_108_Internalname = "PROMPT_108";
         subGridlevel_lista_Internalname = "GRIDLEVEL_LISTA";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_lista_Allowcollapsing = 0;
         subGridlevel_lista_Allowselection = 0;
         subGridlevel_lista_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Inventario", "");
         chkInventarioEsPresupuestado.Caption = "";
         edtInventarioRefCode_Jsonclick = "";
         imgprompt_108_Visible = 1;
         imgprompt_108_Link = "";
         dynEstadosGenericosId_Jsonclick = "";
         edtEstadosTipo_Jsonclick = "";
         edtInventarioTextosTitulo_Jsonclick = "";
         imgprompt_535_Visible = 1;
         imgprompt_535_Link = "";
         imgprompt_150_Visible = 1;
         edtInventarioTextosId_Jsonclick = "";
         edtInventarioConsumoProductivo_Jsonclick = "";
         edtInventarioPrecioFinal_Jsonclick = "";
         edtInventarioCosto_Jsonclick = "";
         dynMonedaId_Jsonclick = "";
         edtInventarioNombre_Jsonclick = "";
         edtInventarioId_Jsonclick = "";
         subGridlevel_lista_Class = "WorkWith";
         subGridlevel_lista_Backcolorstyle = 0;
         chkInventarioEsPresupuestado.Enabled = 1;
         edtInventarioRefCode_Enabled = 0;
         dynEstadosGenericosId.Enabled = 1;
         edtEstadosTipo_Enabled = 0;
         edtInventarioTextosTitulo_Enabled = 0;
         edtInventarioTextosId_Enabled = 1;
         edtInventarioConsumoProductivo_Enabled = 1;
         edtInventarioPrecioFinal_Enabled = 1;
         edtInventarioCosto_Enabled = 1;
         dynMonedaId.Enabled = 0;
         edtInventarioImagen_Enabled = 1;
         edtInventarioNombre_Enabled = 1;
         edtInventarioId_Enabled = 0;
         edtInventarioSerial_Jsonclick = "";
         edtInventarioSerial_Enabled = 0;
         edtInventarioSerial_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTextosTitulo_Jsonclick = "";
         edtTextosTitulo_Enabled = 0;
         edtTextosTipo_Jsonclick = "";
         edtTextosTipo_Enabled = 0;
         imgprompt_150_Visible = 1;
         imgprompt_150_Link = "";
         edtTextosId_Jsonclick = "";
         edtTextosId_Enabled = 1;
         imgRubrosImagen_Enabled = 0;
         edtRubrosPrecioBase_Jsonclick = "";
         edtRubrosPrecioBase_Enabled = 1;
         edtRubrosCosto_Jsonclick = "";
         edtRubrosCosto_Enabled = 1;
         cmbMedidasEstado_Jsonclick = "";
         cmbMedidasEstado.Enabled = 1;
         edtMedidasNombre_Jsonclick = "";
         edtMedidasNombre_Enabled = 1;
         dynMedidasID_Jsonclick = "";
         dynMedidasID.Enabled = 1;
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

      protected void GXDLARUBROSID0M26( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLARUBROSID_data0M26( ) ;
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

      protected void GXARUBROSID_html0M26( )
      {
         short gxdynajaxvalue;
         GXDLARUBROSID_data0M26( ) ;
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

      protected void GXDLARUBROSID_data0M26( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T000M41 */
         pr_default.execute(39);
         while ( (pr_default.getStatus(39) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000M41_A121RubrosId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000M41_A122RubrosNombre[0]));
            pr_default.readNext(39);
         }
         pr_default.close(39);
      }

      protected void GXDLAMEDIDASID0M26( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMEDIDASID_data0M26( ) ;
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

      protected void GXAMEDIDASID_html0M26( )
      {
         long gxdynajaxvalue;
         GXDLAMEDIDASID_data0M26( ) ;
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

      protected void GXDLAMEDIDASID_data0M26( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T000M42 */
         pr_default.execute(40);
         while ( (pr_default.getStatus(40) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000M42_A137MedidasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000M42_A138MedidasNombre[0]));
            pr_default.readNext(40);
         }
         pr_default.close(40);
      }

      protected void GXDLAESTADOSGENERICOSID0M27( string A107EstadosTipo )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAESTADOSGENERICOSID_data0M27( A107EstadosTipo) ;
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

      protected void GXAESTADOSGENERICOSID_html0M27( string A107EstadosTipo )
      {
         int gxdynajaxvalue;
         GXDLAESTADOSGENERICOSID_data0M27( A107EstadosTipo) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynEstadosGenericosId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynEstadosGenericosId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 5, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAESTADOSGENERICOSID_data0M27( string A107EstadosTipo )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000M43 */
         pr_default.execute(41, new Object[] {A107EstadosTipo});
         while ( (pr_default.getStatus(41) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000M43_A108EstadosGenericosId[0]), 5, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000M43_A109EstadosGenericosNombre[0]));
            pr_default.readNext(41);
         }
         pr_default.close(41);
      }

      protected void gxnrGridlevel_lista_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_7727( ) ;
         while ( nGXsfl_77_idx <= nRC_GXsfl_77 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0M27( ) ;
            standaloneModal0M27( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0M27( ) ;
            nGXsfl_77_idx = (int)(nGXsfl_77_idx+1);
            sGXsfl_77_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_77_idx), 4, 0), 4, "0");
            SubsflControlProps_7727( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_listaContainer)) ;
         /* End function gxnrGridlevel_lista_newrow */
      }

      protected void init_web_controls( )
      {
         dynRubrosId.Name = "RUBROSID";
         dynRubrosId.WebTags = "";
         dynMedidasID.Name = "MEDIDASID";
         dynMedidasID.WebTags = "";
         cmbMedidasEstado.Name = "MEDIDASESTADO";
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
               AssignAttri("", false, "A139MedidasEstado", A139MedidasEstado);
            }
         }
         GXCCtl = "MONEDAID_" + sGXsfl_77_idx;
         dynMonedaId.Name = GXCCtl;
         dynMonedaId.WebTags = "";
         dynMonedaId.removeAllItems();
         /* Using cursor T000M44 */
         pr_default.execute(42);
         while ( (pr_default.getStatus(42) != 101) )
         {
            dynMonedaId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000M44_A118MonedaId[0]), 4, 0)), T000M44_A119MonedaISOSimbolo[0], 0);
            pr_default.readNext(42);
         }
         pr_default.close(42);
         if ( dynMonedaId.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A118MonedaId) )
            {
               A118MonedaId = 1;
            }
         }
         GXCCtl = "ESTADOSGENERICOSID_" + sGXsfl_77_idx;
         dynEstadosGenericosId.Name = GXCCtl;
         dynEstadosGenericosId.WebTags = "";
         GXCCtl = "INVENTARIOESPRESUPUESTADO_" + sGXsfl_77_idx;
         chkInventarioEsPresupuestado.Name = GXCCtl;
         chkInventarioEsPresupuestado.WebTags = "";
         chkInventarioEsPresupuestado.Caption = "";
         AssignProp("", false, chkInventarioEsPresupuestado_Internalname, "TitleCaption", chkInventarioEsPresupuestado.Caption, !bGXsfl_77_Refreshing);
         chkInventarioEsPresupuestado.CheckedValue = "false";
         A1005InventarioEsPresupuestado = StringUtil.StrToBool( StringUtil.BoolToStr( A1005InventarioEsPresupuestado));
         n1005InventarioEsPresupuestado = false;
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
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000M19 */
         pr_default.execute(17, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
         }
         A40000RubrosImagen_GXI = T000M19_A40000RubrosImagen_GXI[0];
         A122RubrosNombre = T000M19_A122RubrosNombre[0];
         A168RubrosImagen = T000M19_A168RubrosImagen[0];
         pr_default.close(17);
         dynload_actions( ) ;
         if ( dynRubrosId.ItemCount > 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
         }
         if ( dynMedidasID.ItemCount > 0 )
         {
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A168RubrosImagen", context.PathToRelativeUrl( A168RubrosImagen));
         GXCCtlgxBlob = "RUBROSIMAGEN" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A168RubrosImagen));
         AssignAttri("", false, "A40000RubrosImagen_GXI", A40000RubrosImagen_GXI);
         AssignAttri("", false, "A122RubrosNombre", StringUtil.RTrim( A122RubrosNombre));
      }

      public void Valid_Textosid( )
      {
         n150TextosId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000M20 */
         pr_default.execute(18, new Object[] {n150TextosId, A150TextosId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A150TextosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Textos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "TEXTOSID");
               AnyError = 1;
               GX_FocusControl = edtTextosId_Internalname;
            }
         }
         A258TextosTipo = T000M20_A258TextosTipo[0];
         A259TextosTitulo = T000M20_A259TextosTitulo[0];
         pr_default.close(18);
         dynload_actions( ) ;
         if ( dynRubrosId.ItemCount > 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
         }
         if ( dynMedidasID.ItemCount > 0 )
         {
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A258TextosTipo", StringUtil.RTrim( A258TextosTipo));
         AssignAttri("", false, "A259TextosTitulo", StringUtil.RTrim( A259TextosTitulo));
      }

      public void Valid_Inventariotextosid( )
      {
         n535InventarioTextosId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000M32 */
         pr_default.execute(30, new Object[] {n535InventarioTextosId, A535InventarioTextosId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            if ( ! ( (0==A535InventarioTextosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario Textos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "INVENTARIOTEXTOSID");
               AnyError = 1;
               GX_FocusControl = edtInventarioTextosId_Internalname;
            }
         }
         A537InventarioTextosTipo = T000M32_A537InventarioTextosTipo[0];
         A536InventarioTextosTitulo = T000M32_A536InventarioTextosTitulo[0];
         pr_default.close(30);
         dynload_actions( ) ;
         if ( dynRubrosId.ItemCount > 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
         }
         if ( dynMedidasID.ItemCount > 0 )
         {
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A537InventarioTextosTipo", StringUtil.RTrim( A537InventarioTextosTipo));
         AssignAttri("", false, "A536InventarioTextosTitulo", StringUtil.RTrim( A536InventarioTextosTitulo));
      }

      public void Valid_Estadostipo( )
      {
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         dynload_actions( ) ;
         if ( dynRubrosId.ItemCount > 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
         }
         if ( dynMedidasID.ItemCount > 0 )
         {
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         }
         if ( dynEstadosGenericosId.ItemCount > 0 )
         {
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEstadosGenericosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", "")));
         dynEstadosGenericosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
         AssignProp("", false, dynEstadosGenericosId_Internalname, "Values", dynEstadosGenericosId.ToJavascriptSource(), true);
      }

      public void Valid_Estadosgenericosid( )
      {
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000M45 */
         pr_default.execute(43, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(43) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
            AnyError = 1;
            GX_FocusControl = dynEstadosGenericosId_Internalname;
         }
         pr_default.close(43);
         dynload_actions( ) ;
         if ( dynRubrosId.ItemCount > 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
         }
         if ( dynMedidasID.ItemCount > 0 )
         {
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         }
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV17RubrosId',fld:'vRUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV18MedidasID',fld:'vMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV17RubrosId',fld:'vRUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'AV18MedidasID',fld:'vMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV19Insert_TextosId',fld:'vINSERT_TEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("AFTER TRN","{handler:'E120M2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'A168RubrosImagen',fld:'RUBROSIMAGEN',pic:'',type:'bits'},{av:'A40000RubrosImagen_GXI',fld:'RUBROSIMAGEN_GXI',pic:'',type:'svchar'},{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_RUBROSID",",oparms:[{av:'A168RubrosImagen',fld:'RUBROSIMAGEN',pic:'',type:'bits'},{av:'A40000RubrosImagen_GXI',fld:'RUBROSIMAGEN_GXI',pic:'',type:'svchar'},{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_MEDIDASESTADO","{handler:'Valid_Medidasestado',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_MEDIDASESTADO",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_TEXTOSID","{handler:'Valid_Textosid',iparms:[{av:'A150TextosId',fld:'TEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'A258TextosTipo',fld:'TEXTOSTIPO',pic:'',type:'char'},{av:'A259TextosTitulo',fld:'TEXTOSTITULO',pic:'',type:'char'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_TEXTOSID",",oparms:[{av:'A258TextosTipo',fld:'TEXTOSTIPO',pic:'',type:'char'},{av:'A259TextosTitulo',fld:'TEXTOSTITULO',pic:'',type:'char'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_INVENTARIOSERIAL","{handler:'Valid_Inventarioserial',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_INVENTARIOSERIAL",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_INVENTARIOID","{handler:'Valid_Inventarioid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_INVENTARIOID",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_INVENTARIOTEXTOSID","{handler:'Valid_Inventariotextosid',iparms:[{av:'A535InventarioTextosId',fld:'INVENTARIOTEXTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'A537InventarioTextosTipo',fld:'INVENTARIOTEXTOSTIPO',pic:'',type:'char'},{av:'A536InventarioTextosTitulo',fld:'INVENTARIOTEXTOSTITULO',pic:'',type:'char'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_INVENTARIOTEXTOSID",",oparms:[{av:'A537InventarioTextosTipo',fld:'INVENTARIOTEXTOSTIPO',pic:'',type:'char'},{av:'A536InventarioTextosTitulo',fld:'INVENTARIOTEXTOSTITULO',pic:'',type:'char'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_ESTADOSTIPO","{handler:'Valid_Estadostipo',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_ESTADOSTIPO",",oparms:[{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_ESTADOSGENERICOSID","{handler:'Valid_Estadosgenericosid',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_ESTADOSGENERICOSID",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("NULL","{handler:'Valid_Inventarioespresupuestado',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("NULL",",oparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
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
         pr_default.close(43);
         pr_default.close(30);
         pr_default.close(5);
         pr_default.close(17);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z138MedidasNombre = "";
         Z139MedidasEstado = "";
         Z136InventarioNombre = "";
         Z1004InventarioSKURelacionado = "";
         Z107EstadosTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A107EstadosTipo = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A139MedidasEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A138MedidasNombre = "";
         A168RubrosImagen = "";
         A40000RubrosImagen_GXI = "";
         sImgUrl = "";
         imgprompt_150_gximage = "";
         A258TextosTipo = "";
         A259TextosTitulo = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gridlevel_listaContainer = new GXWebGrid( context);
         sMode27 = "";
         sStyleString = "";
         A122RubrosNombre = "";
         AV33Pgmname = "";
         A40001InventarioImagen_GXI = "";
         A1004InventarioSKURelacionado = "";
         A537InventarioTextosTipo = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode26 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A136InventarioNombre = "";
         A189InventarioImagen = "";
         A536InventarioTextosTitulo = "";
         A921InventarioRefCode = "";
         AV20WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV16TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z168RubrosImagen = "";
         Z40000RubrosImagen_GXI = "";
         Z122RubrosNombre = "";
         Z258TextosTipo = "";
         Z259TextosTitulo = "";
         T000M8_A40000RubrosImagen_GXI = new string[] {""} ;
         T000M8_A122RubrosNombre = new string[] {""} ;
         T000M8_A168RubrosImagen = new string[] {""} ;
         T000M9_A258TextosTipo = new string[] {""} ;
         T000M9_A259TextosTitulo = new string[] {""} ;
         T000M10_A137MedidasID = new long[1] ;
         T000M10_n137MedidasID = new bool[] {false} ;
         T000M10_A40000RubrosImagen_GXI = new string[] {""} ;
         T000M10_A122RubrosNombre = new string[] {""} ;
         T000M10_A215RubrosCosto = new decimal[1] ;
         T000M10_A138MedidasNombre = new string[] {""} ;
         T000M10_A216RubrosPrecioBase = new decimal[1] ;
         T000M10_A139MedidasEstado = new string[] {""} ;
         T000M10_n139MedidasEstado = new bool[] {false} ;
         T000M10_A258TextosTipo = new string[] {""} ;
         T000M10_A259TextosTitulo = new string[] {""} ;
         T000M10_A218InventarioSerial = new short[1] ;
         T000M10_A121RubrosId = new short[1] ;
         T000M10_A150TextosId = new long[1] ;
         T000M10_n150TextosId = new bool[] {false} ;
         T000M10_A118MonedaId = new short[1] ;
         T000M10_A168RubrosImagen = new string[] {""} ;
         T000M11_A40000RubrosImagen_GXI = new string[] {""} ;
         T000M11_A122RubrosNombre = new string[] {""} ;
         T000M11_A168RubrosImagen = new string[] {""} ;
         T000M12_A258TextosTipo = new string[] {""} ;
         T000M12_A259TextosTitulo = new string[] {""} ;
         T000M13_A121RubrosId = new short[1] ;
         T000M13_A137MedidasID = new long[1] ;
         T000M13_n137MedidasID = new bool[] {false} ;
         T000M7_A137MedidasID = new long[1] ;
         T000M7_n137MedidasID = new bool[] {false} ;
         T000M7_A215RubrosCosto = new decimal[1] ;
         T000M7_A138MedidasNombre = new string[] {""} ;
         T000M7_A216RubrosPrecioBase = new decimal[1] ;
         T000M7_A139MedidasEstado = new string[] {""} ;
         T000M7_n139MedidasEstado = new bool[] {false} ;
         T000M7_A218InventarioSerial = new short[1] ;
         T000M7_A121RubrosId = new short[1] ;
         T000M7_A150TextosId = new long[1] ;
         T000M7_n150TextosId = new bool[] {false} ;
         T000M7_A118MonedaId = new short[1] ;
         T000M14_A121RubrosId = new short[1] ;
         T000M14_A137MedidasID = new long[1] ;
         T000M14_n137MedidasID = new bool[] {false} ;
         T000M15_A121RubrosId = new short[1] ;
         T000M15_A137MedidasID = new long[1] ;
         T000M15_n137MedidasID = new bool[] {false} ;
         T000M6_A137MedidasID = new long[1] ;
         T000M6_n137MedidasID = new bool[] {false} ;
         T000M6_A215RubrosCosto = new decimal[1] ;
         T000M6_A138MedidasNombre = new string[] {""} ;
         T000M6_A216RubrosPrecioBase = new decimal[1] ;
         T000M6_A139MedidasEstado = new string[] {""} ;
         T000M6_n139MedidasEstado = new bool[] {false} ;
         T000M6_A218InventarioSerial = new short[1] ;
         T000M6_A121RubrosId = new short[1] ;
         T000M6_A150TextosId = new long[1] ;
         T000M6_n150TextosId = new bool[] {false} ;
         T000M6_A118MonedaId = new short[1] ;
         T000M19_A40000RubrosImagen_GXI = new string[] {""} ;
         T000M19_A122RubrosNombre = new string[] {""} ;
         T000M19_A168RubrosImagen = new string[] {""} ;
         T000M20_A258TextosTipo = new string[] {""} ;
         T000M20_A259TextosTitulo = new string[] {""} ;
         T000M21_A918MapeoID = new long[1] ;
         T000M21_A121RubrosId = new short[1] ;
         T000M21_A137MedidasID = new long[1] ;
         T000M21_n137MedidasID = new bool[] {false} ;
         T000M21_A135InventarioId = new long[1] ;
         T000M21_n135InventarioId = new bool[] {false} ;
         T000M23_A121RubrosId = new short[1] ;
         T000M23_A137MedidasID = new long[1] ;
         T000M23_n137MedidasID = new bool[] {false} ;
         Z189InventarioImagen = "";
         Z40001InventarioImagen_GXI = "";
         Z537InventarioTextosTipo = "";
         Z536InventarioTextosTitulo = "";
         T000M24_A121RubrosId = new short[1] ;
         T000M24_A137MedidasID = new long[1] ;
         T000M24_n137MedidasID = new bool[] {false} ;
         T000M24_A135InventarioId = new long[1] ;
         T000M24_n135InventarioId = new bool[] {false} ;
         T000M24_A136InventarioNombre = new string[] {""} ;
         T000M24_A40001InventarioImagen_GXI = new string[] {""} ;
         T000M24_A801InventarioConsumoProductivo = new decimal[1] ;
         T000M24_A190InventarioCosto = new decimal[1] ;
         T000M24_A181InventarioPrecioFinal = new decimal[1] ;
         T000M24_A1004InventarioSKURelacionado = new string[] {""} ;
         T000M24_n1004InventarioSKURelacionado = new bool[] {false} ;
         T000M24_A1005InventarioEsPresupuestado = new bool[] {false} ;
         T000M24_n1005InventarioEsPresupuestado = new bool[] {false} ;
         T000M24_A537InventarioTextosTipo = new string[] {""} ;
         T000M24_A536InventarioTextosTitulo = new string[] {""} ;
         T000M24_A802I = new short[1] ;
         T000M24_A107EstadosTipo = new string[] {""} ;
         T000M24_A108EstadosGenericosId = new int[1] ;
         T000M24_A535InventarioTextosId = new long[1] ;
         T000M24_n535InventarioTextosId = new bool[] {false} ;
         T000M24_A189InventarioImagen = new string[] {""} ;
         T000M4_A107EstadosTipo = new string[] {""} ;
         GXCCtl = "";
         T000M5_A537InventarioTextosTipo = new string[] {""} ;
         T000M5_A536InventarioTextosTitulo = new string[] {""} ;
         T000M25_A107EstadosTipo = new string[] {""} ;
         T000M26_A537InventarioTextosTipo = new string[] {""} ;
         T000M26_A536InventarioTextosTitulo = new string[] {""} ;
         T000M27_A121RubrosId = new short[1] ;
         T000M27_A137MedidasID = new long[1] ;
         T000M27_n137MedidasID = new bool[] {false} ;
         T000M27_A135InventarioId = new long[1] ;
         T000M27_n135InventarioId = new bool[] {false} ;
         T000M3_A121RubrosId = new short[1] ;
         T000M3_A137MedidasID = new long[1] ;
         T000M3_n137MedidasID = new bool[] {false} ;
         T000M3_A135InventarioId = new long[1] ;
         T000M3_n135InventarioId = new bool[] {false} ;
         T000M3_A136InventarioNombre = new string[] {""} ;
         T000M3_A40001InventarioImagen_GXI = new string[] {""} ;
         T000M3_A801InventarioConsumoProductivo = new decimal[1] ;
         T000M3_A190InventarioCosto = new decimal[1] ;
         T000M3_A181InventarioPrecioFinal = new decimal[1] ;
         T000M3_A1004InventarioSKURelacionado = new string[] {""} ;
         T000M3_n1004InventarioSKURelacionado = new bool[] {false} ;
         T000M3_A1005InventarioEsPresupuestado = new bool[] {false} ;
         T000M3_n1005InventarioEsPresupuestado = new bool[] {false} ;
         T000M3_A802I = new short[1] ;
         T000M3_A107EstadosTipo = new string[] {""} ;
         T000M3_A108EstadosGenericosId = new int[1] ;
         T000M3_A535InventarioTextosId = new long[1] ;
         T000M3_n535InventarioTextosId = new bool[] {false} ;
         T000M3_A189InventarioImagen = new string[] {""} ;
         T000M2_A121RubrosId = new short[1] ;
         T000M2_A137MedidasID = new long[1] ;
         T000M2_n137MedidasID = new bool[] {false} ;
         T000M2_A135InventarioId = new long[1] ;
         T000M2_n135InventarioId = new bool[] {false} ;
         T000M2_A136InventarioNombre = new string[] {""} ;
         T000M2_A40001InventarioImagen_GXI = new string[] {""} ;
         T000M2_A801InventarioConsumoProductivo = new decimal[1] ;
         T000M2_A190InventarioCosto = new decimal[1] ;
         T000M2_A181InventarioPrecioFinal = new decimal[1] ;
         T000M2_A1004InventarioSKURelacionado = new string[] {""} ;
         T000M2_n1004InventarioSKURelacionado = new bool[] {false} ;
         T000M2_A1005InventarioEsPresupuestado = new bool[] {false} ;
         T000M2_n1005InventarioEsPresupuestado = new bool[] {false} ;
         T000M2_A802I = new short[1] ;
         T000M2_A107EstadosTipo = new string[] {""} ;
         T000M2_A108EstadosGenericosId = new int[1] ;
         T000M2_A535InventarioTextosId = new long[1] ;
         T000M2_n535InventarioTextosId = new bool[] {false} ;
         T000M2_A189InventarioImagen = new string[] {""} ;
         T000M32_A537InventarioTextosTipo = new string[] {""} ;
         T000M32_A536InventarioTextosTitulo = new string[] {""} ;
         T000M33_A133ProveedorID = new long[1] ;
         T000M33_A713ComercioProductosRubrosID = new long[1] ;
         T000M34_A503ComisionesID = new long[1] ;
         T000M34_A513ComisionesAgruparRubrosId = new long[1] ;
         T000M35_A450ProfComisionesID = new long[1] ;
         T000M35_A452ProfComisionesRubrosId = new long[1] ;
         T000M36_A127SolicitudesID = new long[1] ;
         T000M36_A134SolicitudesItemsID = new short[1] ;
         T000M37_A133ProveedorID = new long[1] ;
         T000M37_A157ProveedorComisionID = new long[1] ;
         T000M38_A918MapeoID = new long[1] ;
         T000M38_A121RubrosId = new short[1] ;
         T000M38_A137MedidasID = new long[1] ;
         T000M38_n137MedidasID = new bool[] {false} ;
         T000M38_A135InventarioId = new long[1] ;
         T000M38_n135InventarioId = new bool[] {false} ;
         T000M39_A121RubrosId = new short[1] ;
         T000M39_A137MedidasID = new long[1] ;
         T000M39_n137MedidasID = new bool[] {false} ;
         T000M39_A135InventarioId = new long[1] ;
         T000M39_n135InventarioId = new bool[] {false} ;
         Gridlevel_listaRow = new GXWebRow();
         subGridlevel_lista_Linesclass = "";
         ROClassString = "";
         T000M40_A118MonedaId = new short[1] ;
         T000M40_A119MonedaISOSimbolo = new string[] {""} ;
         imgprompt_535_gximage = "";
         imgprompt_108_gximage = "";
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i139MedidasEstado = "";
         i107EstadosTipo = "";
         Gridlevel_listaColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000M41_A121RubrosId = new short[1] ;
         T000M41_A122RubrosNombre = new string[] {""} ;
         T000M41_A123RubrosEstado = new string[] {""} ;
         T000M41_n123RubrosEstado = new bool[] {false} ;
         T000M42_A121RubrosId = new short[1] ;
         T000M42_A137MedidasID = new long[1] ;
         T000M42_n137MedidasID = new bool[] {false} ;
         T000M42_A138MedidasNombre = new string[] {""} ;
         T000M42_A139MedidasEstado = new string[] {""} ;
         T000M42_n139MedidasEstado = new bool[] {false} ;
         T000M43_A107EstadosTipo = new string[] {""} ;
         T000M43_A108EstadosGenericosId = new int[1] ;
         T000M43_A109EstadosGenericosNombre = new string[] {""} ;
         T000M44_A118MonedaId = new short[1] ;
         T000M44_A119MonedaISOSimbolo = new string[] {""} ;
         T000M45_A107EstadosTipo = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.inventario__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.inventario__default(),
            new Object[][] {
                new Object[] {
               T000M2_A121RubrosId, T000M2_A137MedidasID, T000M2_A135InventarioId, T000M2_A136InventarioNombre, T000M2_A40001InventarioImagen_GXI, T000M2_A801InventarioConsumoProductivo, T000M2_A190InventarioCosto, T000M2_A181InventarioPrecioFinal, T000M2_A1004InventarioSKURelacionado, T000M2_n1004InventarioSKURelacionado,
               T000M2_A1005InventarioEsPresupuestado, T000M2_n1005InventarioEsPresupuestado, T000M2_A802I, T000M2_A107EstadosTipo, T000M2_A108EstadosGenericosId, T000M2_A535InventarioTextosId, T000M2_n535InventarioTextosId, T000M2_A189InventarioImagen
               }
               , new Object[] {
               T000M3_A121RubrosId, T000M3_A137MedidasID, T000M3_A135InventarioId, T000M3_A136InventarioNombre, T000M3_A40001InventarioImagen_GXI, T000M3_A801InventarioConsumoProductivo, T000M3_A190InventarioCosto, T000M3_A181InventarioPrecioFinal, T000M3_A1004InventarioSKURelacionado, T000M3_n1004InventarioSKURelacionado,
               T000M3_A1005InventarioEsPresupuestado, T000M3_n1005InventarioEsPresupuestado, T000M3_A802I, T000M3_A107EstadosTipo, T000M3_A108EstadosGenericosId, T000M3_A535InventarioTextosId, T000M3_n535InventarioTextosId, T000M3_A189InventarioImagen
               }
               , new Object[] {
               T000M4_A107EstadosTipo
               }
               , new Object[] {
               T000M5_A537InventarioTextosTipo, T000M5_A536InventarioTextosTitulo
               }
               , new Object[] {
               T000M6_A137MedidasID, T000M6_A215RubrosCosto, T000M6_A138MedidasNombre, T000M6_A216RubrosPrecioBase, T000M6_A139MedidasEstado, T000M6_n139MedidasEstado, T000M6_A218InventarioSerial, T000M6_A121RubrosId, T000M6_A150TextosId, T000M6_n150TextosId,
               T000M6_A118MonedaId
               }
               , new Object[] {
               T000M7_A137MedidasID, T000M7_A215RubrosCosto, T000M7_A138MedidasNombre, T000M7_A216RubrosPrecioBase, T000M7_A139MedidasEstado, T000M7_n139MedidasEstado, T000M7_A218InventarioSerial, T000M7_A121RubrosId, T000M7_A150TextosId, T000M7_n150TextosId,
               T000M7_A118MonedaId
               }
               , new Object[] {
               T000M8_A40000RubrosImagen_GXI, T000M8_A122RubrosNombre, T000M8_A168RubrosImagen
               }
               , new Object[] {
               T000M9_A258TextosTipo, T000M9_A259TextosTitulo
               }
               , new Object[] {
               T000M10_A137MedidasID, T000M10_A40000RubrosImagen_GXI, T000M10_A122RubrosNombre, T000M10_A215RubrosCosto, T000M10_A138MedidasNombre, T000M10_A216RubrosPrecioBase, T000M10_A139MedidasEstado, T000M10_n139MedidasEstado, T000M10_A258TextosTipo, T000M10_A259TextosTitulo,
               T000M10_A218InventarioSerial, T000M10_A121RubrosId, T000M10_A150TextosId, T000M10_n150TextosId, T000M10_A118MonedaId, T000M10_A168RubrosImagen
               }
               , new Object[] {
               T000M11_A40000RubrosImagen_GXI, T000M11_A122RubrosNombre, T000M11_A168RubrosImagen
               }
               , new Object[] {
               T000M12_A258TextosTipo, T000M12_A259TextosTitulo
               }
               , new Object[] {
               T000M13_A121RubrosId, T000M13_A137MedidasID
               }
               , new Object[] {
               T000M14_A121RubrosId, T000M14_A137MedidasID
               }
               , new Object[] {
               T000M15_A121RubrosId, T000M15_A137MedidasID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000M19_A40000RubrosImagen_GXI, T000M19_A122RubrosNombre, T000M19_A168RubrosImagen
               }
               , new Object[] {
               T000M20_A258TextosTipo, T000M20_A259TextosTitulo
               }
               , new Object[] {
               T000M21_A918MapeoID, T000M21_A121RubrosId, T000M21_A137MedidasID, T000M21_A135InventarioId
               }
               , new Object[] {
               }
               , new Object[] {
               T000M23_A121RubrosId, T000M23_A137MedidasID
               }
               , new Object[] {
               T000M24_A121RubrosId, T000M24_A137MedidasID, T000M24_A135InventarioId, T000M24_A136InventarioNombre, T000M24_A40001InventarioImagen_GXI, T000M24_A801InventarioConsumoProductivo, T000M24_A190InventarioCosto, T000M24_A181InventarioPrecioFinal, T000M24_A1004InventarioSKURelacionado, T000M24_n1004InventarioSKURelacionado,
               T000M24_A1005InventarioEsPresupuestado, T000M24_n1005InventarioEsPresupuestado, T000M24_A537InventarioTextosTipo, T000M24_A536InventarioTextosTitulo, T000M24_A802I, T000M24_A107EstadosTipo, T000M24_A108EstadosGenericosId, T000M24_A535InventarioTextosId, T000M24_n535InventarioTextosId, T000M24_A189InventarioImagen
               }
               , new Object[] {
               T000M25_A107EstadosTipo
               }
               , new Object[] {
               T000M26_A537InventarioTextosTipo, T000M26_A536InventarioTextosTitulo
               }
               , new Object[] {
               T000M27_A121RubrosId, T000M27_A137MedidasID, T000M27_A135InventarioId
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
               T000M32_A537InventarioTextosTipo, T000M32_A536InventarioTextosTitulo
               }
               , new Object[] {
               T000M33_A133ProveedorID, T000M33_A713ComercioProductosRubrosID
               }
               , new Object[] {
               T000M34_A503ComisionesID, T000M34_A513ComisionesAgruparRubrosId
               }
               , new Object[] {
               T000M35_A450ProfComisionesID, T000M35_A452ProfComisionesRubrosId
               }
               , new Object[] {
               T000M36_A127SolicitudesID, T000M36_A134SolicitudesItemsID
               }
               , new Object[] {
               T000M37_A133ProveedorID, T000M37_A157ProveedorComisionID
               }
               , new Object[] {
               T000M38_A918MapeoID, T000M38_A121RubrosId, T000M38_A137MedidasID, T000M38_A135InventarioId
               }
               , new Object[] {
               T000M39_A121RubrosId, T000M39_A137MedidasID, T000M39_A135InventarioId
               }
               , new Object[] {
               T000M40_A118MonedaId, T000M40_A119MonedaISOSimbolo
               }
               , new Object[] {
               T000M41_A121RubrosId, T000M41_A122RubrosNombre, T000M41_A123RubrosEstado, T000M41_n123RubrosEstado
               }
               , new Object[] {
               T000M42_A121RubrosId, T000M42_A137MedidasID, T000M42_A138MedidasNombre, T000M42_A139MedidasEstado, T000M42_n139MedidasEstado
               }
               , new Object[] {
               T000M43_A107EstadosTipo, T000M43_A108EstadosGenericosId, T000M43_A109EstadosGenericosNombre
               }
               , new Object[] {
               T000M44_A118MonedaId, T000M44_A119MonedaISOSimbolo
               }
               , new Object[] {
               T000M45_A107EstadosTipo
               }
            }
         );
         AV33Pgmname = "Inventario";
         Z139MedidasEstado = "HAB";
         n139MedidasEstado = false;
         A139MedidasEstado = "HAB";
         n139MedidasEstado = false;
         i139MedidasEstado = "HAB";
         n139MedidasEstado = false;
         Z108EstadosGenericosId = 1;
         i108EstadosGenericosId = 1;
         A108EstadosGenericosId = 1;
         Z118MonedaId = 1;
         O118MonedaId = 1;
         A118MonedaId = 1;
         i118MonedaId = 1;
      }

      private short nIsMod_27 ;
      private short wcpOAV17RubrosId ;
      private short Z121RubrosId ;
      private short Z218InventarioSerial ;
      private short Z118MonedaId ;
      private short O218InventarioSerial ;
      private short Z802I ;
      private short nRcdDeleted_27 ;
      private short nRcdExists_27 ;
      private short GxWebError ;
      private short A121RubrosId ;
      private short AV17RubrosId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short A218InventarioSerial ;
      private short nBlankRcdCount27 ;
      private short RcdFound27 ;
      private short B218InventarioSerial ;
      private short nBlankRcdUsr27 ;
      private short A802I ;
      private short RcdFound26 ;
      private short s218InventarioSerial ;
      private short s118MonedaId ;
      private short O118MonedaId ;
      private short A118MonedaId ;
      private short nIsDirty_27 ;
      private short subGridlevel_lista_Backcolorstyle ;
      private short subGridlevel_lista_Backstyle ;
      private short gxajaxcallmode ;
      private short i118MonedaId ;
      private short i218InventarioSerial ;
      private short subGridlevel_lista_Allowselection ;
      private short subGridlevel_lista_Allowhovering ;
      private short subGridlevel_lista_Allowcollapsing ;
      private short subGridlevel_lista_Collapsed ;
      private int nRC_GXsfl_77 ;
      private int nGXsfl_77_idx=1 ;
      private int Z108EstadosGenericosId ;
      private int A108EstadosGenericosId ;
      private int trnEnded ;
      private int edtMedidasNombre_Enabled ;
      private int edtRubrosCosto_Enabled ;
      private int edtRubrosPrecioBase_Enabled ;
      private int imgRubrosImagen_Enabled ;
      private int edtTextosId_Enabled ;
      private int imgprompt_150_Visible ;
      private int edtTextosTipo_Enabled ;
      private int edtTextosTitulo_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtInventarioSerial_Enabled ;
      private int edtInventarioSerial_Visible ;
      private int edtInventarioId_Enabled ;
      private int edtInventarioNombre_Enabled ;
      private int edtInventarioImagen_Enabled ;
      private int edtInventarioCosto_Enabled ;
      private int edtInventarioPrecioFinal_Enabled ;
      private int edtInventarioConsumoProductivo_Enabled ;
      private int edtInventarioTextosId_Enabled ;
      private int edtInventarioTextosTitulo_Enabled ;
      private int edtEstadosTipo_Enabled ;
      private int edtInventarioRefCode_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV34GXV1 ;
      private int subGridlevel_lista_Backcolor ;
      private int subGridlevel_lista_Allbackcolor ;
      private int imgprompt_535_Visible ;
      private int imgprompt_108_Visible ;
      private int defedtEstadosTipo_Enabled ;
      private int defedtInventarioId_Enabled ;
      private int i108EstadosGenericosId ;
      private int idxLst ;
      private int subGridlevel_lista_Selectedindex ;
      private int subGridlevel_lista_Selectioncolor ;
      private int subGridlevel_lista_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long wcpOAV18MedidasID ;
      private long Z137MedidasID ;
      private long Z150TextosId ;
      private long N150TextosId ;
      private long Z135InventarioId ;
      private long Z535InventarioTextosId ;
      private long A150TextosId ;
      private long A535InventarioTextosId ;
      private long AV18MedidasID ;
      private long A137MedidasID ;
      private long AV19Insert_TextosId ;
      private long GRIDLEVEL_LISTA_nFirstRecordOnPage ;
      private long A135InventarioId ;
      private decimal Z215RubrosCosto ;
      private decimal Z216RubrosPrecioBase ;
      private decimal Z801InventarioConsumoProductivo ;
      private decimal Z190InventarioCosto ;
      private decimal Z181InventarioPrecioFinal ;
      private decimal A215RubrosCosto ;
      private decimal A216RubrosPrecioBase ;
      private decimal A190InventarioCosto ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A801InventarioConsumoProductivo ;
      private string sPrefix ;
      private string sGXsfl_77_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z138MedidasNombre ;
      private string Z139MedidasEstado ;
      private string Z136InventarioNombre ;
      private string Z107EstadosTipo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A107EstadosTipo ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string dynRubrosId_Internalname ;
      private string dynMedidasID_Internalname ;
      private string A139MedidasEstado ;
      private string cmbMedidasEstado_Internalname ;
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
      private string divTb1_Internalname ;
      private string TempTags ;
      private string dynRubrosId_Jsonclick ;
      private string dynMedidasID_Jsonclick ;
      private string edtMedidasNombre_Internalname ;
      private string A138MedidasNombre ;
      private string edtMedidasNombre_Jsonclick ;
      private string cmbMedidasEstado_Jsonclick ;
      private string edtRubrosCosto_Internalname ;
      private string edtRubrosCosto_Jsonclick ;
      private string edtRubrosPrecioBase_Internalname ;
      private string edtRubrosPrecioBase_Jsonclick ;
      private string divTb2_Internalname ;
      private string imgRubrosImagen_Internalname ;
      private string sImgUrl ;
      private string edtTextosId_Internalname ;
      private string edtTextosId_Jsonclick ;
      private string imgprompt_150_gximage ;
      private string imgprompt_150_Internalname ;
      private string imgprompt_150_Link ;
      private string edtTextosTipo_Internalname ;
      private string A258TextosTipo ;
      private string edtTextosTipo_Jsonclick ;
      private string edtTextosTitulo_Internalname ;
      private string A259TextosTitulo ;
      private string edtTextosTitulo_Jsonclick ;
      private string divTableleaflevel_lista_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtInventarioSerial_Internalname ;
      private string edtInventarioSerial_Jsonclick ;
      private string sMode27 ;
      private string edtInventarioId_Internalname ;
      private string edtInventarioNombre_Internalname ;
      private string edtInventarioImagen_Internalname ;
      private string dynMonedaId_Internalname ;
      private string edtInventarioCosto_Internalname ;
      private string edtInventarioPrecioFinal_Internalname ;
      private string edtInventarioConsumoProductivo_Internalname ;
      private string edtInventarioTextosId_Internalname ;
      private string edtInventarioTextosTitulo_Internalname ;
      private string edtEstadosTipo_Internalname ;
      private string dynEstadosGenericosId_Internalname ;
      private string edtInventarioRefCode_Internalname ;
      private string chkInventarioEsPresupuestado_Internalname ;
      private string sStyleString ;
      private string subGridlevel_lista_Internalname ;
      private string A122RubrosNombre ;
      private string AV33Pgmname ;
      private string A537InventarioTextosTipo ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode26 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A136InventarioNombre ;
      private string A536InventarioTextosTitulo ;
      private string A921InventarioRefCode ;
      private string GXEncryptionTmp ;
      private string Z122RubrosNombre ;
      private string Z258TextosTipo ;
      private string Z259TextosTitulo ;
      private string Z537InventarioTextosTipo ;
      private string Z536InventarioTextosTitulo ;
      private string GXCCtl ;
      private string imgprompt_535_Internalname ;
      private string imgprompt_108_Internalname ;
      private string sGXsfl_77_fel_idx="0001" ;
      private string subGridlevel_lista_Class ;
      private string subGridlevel_lista_Linesclass ;
      private string imgprompt_535_Link ;
      private string imgprompt_108_Link ;
      private string ROClassString ;
      private string edtInventarioId_Jsonclick ;
      private string edtInventarioNombre_Jsonclick ;
      private string dynMonedaId_Jsonclick ;
      private string edtInventarioCosto_Jsonclick ;
      private string edtInventarioPrecioFinal_Jsonclick ;
      private string edtInventarioConsumoProductivo_Jsonclick ;
      private string edtInventarioTextosId_Jsonclick ;
      private string imgprompt_535_gximage ;
      private string edtInventarioTextosTitulo_Jsonclick ;
      private string edtEstadosTipo_Jsonclick ;
      private string dynEstadosGenericosId_Jsonclick ;
      private string imgprompt_108_gximage ;
      private string edtInventarioRefCode_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i139MedidasEstado ;
      private string i107EstadosTipo ;
      private string subGridlevel_lista_Header ;
      private string gxwrpcisep ;
      private bool Z1005InventarioEsPresupuestado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n150TextosId ;
      private bool n535InventarioTextosId ;
      private bool wbErr ;
      private bool n137MedidasID ;
      private bool n139MedidasEstado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A168RubrosImagen_IsBlob ;
      private bool bGXsfl_77_Refreshing=false ;
      private bool n1004InventarioSKURelacionado ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool A1005InventarioEsPresupuestado ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool n135InventarioId ;
      private bool n1005InventarioEsPresupuestado ;
      private bool A189InventarioImagen_IsBlob ;
      private bool gxdyncontrolsrefreshing ;
      private string Z1004InventarioSKURelacionado ;
      private string A40000RubrosImagen_GXI ;
      private string A40001InventarioImagen_GXI ;
      private string A1004InventarioSKURelacionado ;
      private string Z40000RubrosImagen_GXI ;
      private string Z40001InventarioImagen_GXI ;
      private string A168RubrosImagen ;
      private string A189InventarioImagen ;
      private string Z168RubrosImagen ;
      private string Z189InventarioImagen ;
      private IGxSession AV10WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_listaContainer ;
      private GXWebRow Gridlevel_listaRow ;
      private GXWebColumn Gridlevel_listaColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynRubrosId ;
      private GXCombobox dynMedidasID ;
      private GXCombobox cmbMedidasEstado ;
      private GXCombobox dynMonedaId ;
      private GXCombobox dynEstadosGenericosId ;
      private GXCheckbox chkInventarioEsPresupuestado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV20WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV16TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000M8_A40000RubrosImagen_GXI ;
      private string[] T000M8_A122RubrosNombre ;
      private string[] T000M8_A168RubrosImagen ;
      private string[] T000M9_A258TextosTipo ;
      private string[] T000M9_A259TextosTitulo ;
      private long[] T000M10_A137MedidasID ;
      private bool[] T000M10_n137MedidasID ;
      private string[] T000M10_A40000RubrosImagen_GXI ;
      private string[] T000M10_A122RubrosNombre ;
      private decimal[] T000M10_A215RubrosCosto ;
      private string[] T000M10_A138MedidasNombre ;
      private decimal[] T000M10_A216RubrosPrecioBase ;
      private string[] T000M10_A139MedidasEstado ;
      private bool[] T000M10_n139MedidasEstado ;
      private string[] T000M10_A258TextosTipo ;
      private string[] T000M10_A259TextosTitulo ;
      private short[] T000M10_A218InventarioSerial ;
      private short[] T000M10_A121RubrosId ;
      private long[] T000M10_A150TextosId ;
      private bool[] T000M10_n150TextosId ;
      private short[] T000M10_A118MonedaId ;
      private string[] T000M10_A168RubrosImagen ;
      private string[] T000M11_A40000RubrosImagen_GXI ;
      private string[] T000M11_A122RubrosNombre ;
      private string[] T000M11_A168RubrosImagen ;
      private string[] T000M12_A258TextosTipo ;
      private string[] T000M12_A259TextosTitulo ;
      private short[] T000M13_A121RubrosId ;
      private long[] T000M13_A137MedidasID ;
      private bool[] T000M13_n137MedidasID ;
      private long[] T000M7_A137MedidasID ;
      private bool[] T000M7_n137MedidasID ;
      private decimal[] T000M7_A215RubrosCosto ;
      private string[] T000M7_A138MedidasNombre ;
      private decimal[] T000M7_A216RubrosPrecioBase ;
      private string[] T000M7_A139MedidasEstado ;
      private bool[] T000M7_n139MedidasEstado ;
      private short[] T000M7_A218InventarioSerial ;
      private short[] T000M7_A121RubrosId ;
      private long[] T000M7_A150TextosId ;
      private bool[] T000M7_n150TextosId ;
      private short[] T000M7_A118MonedaId ;
      private short[] T000M14_A121RubrosId ;
      private long[] T000M14_A137MedidasID ;
      private bool[] T000M14_n137MedidasID ;
      private short[] T000M15_A121RubrosId ;
      private long[] T000M15_A137MedidasID ;
      private bool[] T000M15_n137MedidasID ;
      private long[] T000M6_A137MedidasID ;
      private bool[] T000M6_n137MedidasID ;
      private decimal[] T000M6_A215RubrosCosto ;
      private string[] T000M6_A138MedidasNombre ;
      private decimal[] T000M6_A216RubrosPrecioBase ;
      private string[] T000M6_A139MedidasEstado ;
      private bool[] T000M6_n139MedidasEstado ;
      private short[] T000M6_A218InventarioSerial ;
      private short[] T000M6_A121RubrosId ;
      private long[] T000M6_A150TextosId ;
      private bool[] T000M6_n150TextosId ;
      private short[] T000M6_A118MonedaId ;
      private string[] T000M19_A40000RubrosImagen_GXI ;
      private string[] T000M19_A122RubrosNombre ;
      private string[] T000M19_A168RubrosImagen ;
      private string[] T000M20_A258TextosTipo ;
      private string[] T000M20_A259TextosTitulo ;
      private long[] T000M21_A918MapeoID ;
      private short[] T000M21_A121RubrosId ;
      private long[] T000M21_A137MedidasID ;
      private bool[] T000M21_n137MedidasID ;
      private long[] T000M21_A135InventarioId ;
      private bool[] T000M21_n135InventarioId ;
      private short[] T000M23_A121RubrosId ;
      private long[] T000M23_A137MedidasID ;
      private bool[] T000M23_n137MedidasID ;
      private short[] T000M24_A121RubrosId ;
      private long[] T000M24_A137MedidasID ;
      private bool[] T000M24_n137MedidasID ;
      private long[] T000M24_A135InventarioId ;
      private bool[] T000M24_n135InventarioId ;
      private string[] T000M24_A136InventarioNombre ;
      private string[] T000M24_A40001InventarioImagen_GXI ;
      private decimal[] T000M24_A801InventarioConsumoProductivo ;
      private decimal[] T000M24_A190InventarioCosto ;
      private decimal[] T000M24_A181InventarioPrecioFinal ;
      private string[] T000M24_A1004InventarioSKURelacionado ;
      private bool[] T000M24_n1004InventarioSKURelacionado ;
      private bool[] T000M24_A1005InventarioEsPresupuestado ;
      private bool[] T000M24_n1005InventarioEsPresupuestado ;
      private string[] T000M24_A537InventarioTextosTipo ;
      private string[] T000M24_A536InventarioTextosTitulo ;
      private short[] T000M24_A802I ;
      private string[] T000M24_A107EstadosTipo ;
      private int[] T000M24_A108EstadosGenericosId ;
      private long[] T000M24_A535InventarioTextosId ;
      private bool[] T000M24_n535InventarioTextosId ;
      private string[] T000M24_A189InventarioImagen ;
      private string[] T000M4_A107EstadosTipo ;
      private string[] T000M5_A537InventarioTextosTipo ;
      private string[] T000M5_A536InventarioTextosTitulo ;
      private string[] T000M25_A107EstadosTipo ;
      private string[] T000M26_A537InventarioTextosTipo ;
      private string[] T000M26_A536InventarioTextosTitulo ;
      private short[] T000M27_A121RubrosId ;
      private long[] T000M27_A137MedidasID ;
      private bool[] T000M27_n137MedidasID ;
      private long[] T000M27_A135InventarioId ;
      private bool[] T000M27_n135InventarioId ;
      private short[] T000M3_A121RubrosId ;
      private long[] T000M3_A137MedidasID ;
      private bool[] T000M3_n137MedidasID ;
      private long[] T000M3_A135InventarioId ;
      private bool[] T000M3_n135InventarioId ;
      private string[] T000M3_A136InventarioNombre ;
      private string[] T000M3_A40001InventarioImagen_GXI ;
      private decimal[] T000M3_A801InventarioConsumoProductivo ;
      private decimal[] T000M3_A190InventarioCosto ;
      private decimal[] T000M3_A181InventarioPrecioFinal ;
      private string[] T000M3_A1004InventarioSKURelacionado ;
      private bool[] T000M3_n1004InventarioSKURelacionado ;
      private bool[] T000M3_A1005InventarioEsPresupuestado ;
      private bool[] T000M3_n1005InventarioEsPresupuestado ;
      private short[] T000M3_A802I ;
      private string[] T000M3_A107EstadosTipo ;
      private int[] T000M3_A108EstadosGenericosId ;
      private long[] T000M3_A535InventarioTextosId ;
      private bool[] T000M3_n535InventarioTextosId ;
      private string[] T000M3_A189InventarioImagen ;
      private short[] T000M2_A121RubrosId ;
      private long[] T000M2_A137MedidasID ;
      private bool[] T000M2_n137MedidasID ;
      private long[] T000M2_A135InventarioId ;
      private bool[] T000M2_n135InventarioId ;
      private string[] T000M2_A136InventarioNombre ;
      private string[] T000M2_A40001InventarioImagen_GXI ;
      private decimal[] T000M2_A801InventarioConsumoProductivo ;
      private decimal[] T000M2_A190InventarioCosto ;
      private decimal[] T000M2_A181InventarioPrecioFinal ;
      private string[] T000M2_A1004InventarioSKURelacionado ;
      private bool[] T000M2_n1004InventarioSKURelacionado ;
      private bool[] T000M2_A1005InventarioEsPresupuestado ;
      private bool[] T000M2_n1005InventarioEsPresupuestado ;
      private short[] T000M2_A802I ;
      private string[] T000M2_A107EstadosTipo ;
      private int[] T000M2_A108EstadosGenericosId ;
      private long[] T000M2_A535InventarioTextosId ;
      private bool[] T000M2_n535InventarioTextosId ;
      private string[] T000M2_A189InventarioImagen ;
      private string[] T000M32_A537InventarioTextosTipo ;
      private string[] T000M32_A536InventarioTextosTitulo ;
      private long[] T000M33_A133ProveedorID ;
      private long[] T000M33_A713ComercioProductosRubrosID ;
      private long[] T000M34_A503ComisionesID ;
      private long[] T000M34_A513ComisionesAgruparRubrosId ;
      private long[] T000M35_A450ProfComisionesID ;
      private long[] T000M35_A452ProfComisionesRubrosId ;
      private long[] T000M36_A127SolicitudesID ;
      private short[] T000M36_A134SolicitudesItemsID ;
      private long[] T000M37_A133ProveedorID ;
      private long[] T000M37_A157ProveedorComisionID ;
      private long[] T000M38_A918MapeoID ;
      private short[] T000M38_A121RubrosId ;
      private long[] T000M38_A137MedidasID ;
      private bool[] T000M38_n137MedidasID ;
      private long[] T000M38_A135InventarioId ;
      private bool[] T000M38_n135InventarioId ;
      private short[] T000M39_A121RubrosId ;
      private long[] T000M39_A137MedidasID ;
      private bool[] T000M39_n137MedidasID ;
      private long[] T000M39_A135InventarioId ;
      private bool[] T000M39_n135InventarioId ;
      private short[] T000M40_A118MonedaId ;
      private string[] T000M40_A119MonedaISOSimbolo ;
      private short[] T000M41_A121RubrosId ;
      private string[] T000M41_A122RubrosNombre ;
      private string[] T000M41_A123RubrosEstado ;
      private bool[] T000M41_n123RubrosEstado ;
      private short[] T000M42_A121RubrosId ;
      private long[] T000M42_A137MedidasID ;
      private bool[] T000M42_n137MedidasID ;
      private string[] T000M42_A138MedidasNombre ;
      private string[] T000M42_A139MedidasEstado ;
      private bool[] T000M42_n139MedidasEstado ;
      private string[] T000M43_A107EstadosTipo ;
      private int[] T000M43_A108EstadosGenericosId ;
      private string[] T000M43_A109EstadosGenericosNombre ;
      private short[] T000M44_A118MonedaId ;
      private string[] T000M44_A119MonedaISOSimbolo ;
      private string[] T000M45_A107EstadosTipo ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class inventario__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class inventario__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new UpdateCursor(def[27])
       ,new UpdateCursor(def[28])
       ,new UpdateCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new ForEachCursor(def[43])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000M2;
        prmT000M2 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M3;
        prmT000M3 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M4;
        prmT000M4 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000M5;
        prmT000M5 = new Object[] {
        new ParDef("@InventarioTextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M6;
        prmT000M6 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M7;
        prmT000M7 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M8;
        prmT000M8 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000M9;
        prmT000M9 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M10;
        prmT000M10 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M11;
        prmT000M11 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000M12;
        prmT000M12 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M13;
        prmT000M13 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M14;
        prmT000M14 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M15;
        prmT000M15 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M16;
        prmT000M16 = new Object[] {
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@RubrosCosto",GXType.Decimal,18,2) ,
        new ParDef("@MedidasNombre",GXType.NChar,50,0) ,
        new ParDef("@RubrosPrecioBase",GXType.Decimal,18,2) ,
        new ParDef("@MedidasEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@InventarioSerial",GXType.Int16,4,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MonedaId",GXType.Int16,4,0)
        };
        Object[] prmT000M17;
        prmT000M17 = new Object[] {
        new ParDef("@RubrosCosto",GXType.Decimal,18,2) ,
        new ParDef("@MedidasNombre",GXType.NChar,50,0) ,
        new ParDef("@RubrosPrecioBase",GXType.Decimal,18,2) ,
        new ParDef("@MedidasEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@InventarioSerial",GXType.Int16,4,0) ,
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MonedaId",GXType.Int16,4,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M18;
        prmT000M18 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M19;
        prmT000M19 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000M20;
        prmT000M20 = new Object[] {
        new ParDef("@TextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M21;
        prmT000M21 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M22;
        prmT000M22 = new Object[] {
        new ParDef("@MonedaId",GXType.Int16,4,0) ,
        new ParDef("@InventarioSerial",GXType.Int16,4,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M23;
        prmT000M23 = new Object[] {
        };
        Object[] prmT000M24;
        prmT000M24 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M25;
        prmT000M25 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000M26;
        prmT000M26 = new Object[] {
        new ParDef("@InventarioTextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M27;
        prmT000M27 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M28;
        prmT000M28 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioNombre",GXType.NChar,100,0) ,
        new ParDef("@InventarioImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@InventarioImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="Inventario", Fld="InventarioImagen"} ,
        new ParDef("@InventarioConsumoProductivo",GXType.Decimal,10,2) ,
        new ParDef("@InventarioCosto",GXType.Decimal,18,2) ,
        new ParDef("@InventarioPrecioFinal",GXType.Decimal,18,2) ,
        new ParDef("@InventarioSKURelacionado",GXType.NVarChar,40,0){Nullable=true} ,
        new ParDef("@InventarioEsPresupuestado",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@I",GXType.Int16,4,0) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
        new ParDef("@InventarioTextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M29;
        prmT000M29 = new Object[] {
        new ParDef("@InventarioNombre",GXType.NChar,100,0) ,
        new ParDef("@InventarioConsumoProductivo",GXType.Decimal,10,2) ,
        new ParDef("@InventarioCosto",GXType.Decimal,18,2) ,
        new ParDef("@InventarioPrecioFinal",GXType.Decimal,18,2) ,
        new ParDef("@InventarioSKURelacionado",GXType.NVarChar,40,0){Nullable=true} ,
        new ParDef("@InventarioEsPresupuestado",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@I",GXType.Int16,4,0) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
        new ParDef("@InventarioTextosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M30;
        prmT000M30 = new Object[] {
        new ParDef("@InventarioImagen",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@InventarioImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Inventario", Fld="InventarioImagen"} ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M31;
        prmT000M31 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M32;
        prmT000M32 = new Object[] {
        new ParDef("@InventarioTextosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M33;
        prmT000M33 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M34;
        prmT000M34 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M35;
        prmT000M35 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M36;
        prmT000M36 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M37;
        prmT000M37 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M38;
        prmT000M38 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M39;
        prmT000M39 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000M40;
        prmT000M40 = new Object[] {
        };
        Object[] prmT000M41;
        prmT000M41 = new Object[] {
        };
        Object[] prmT000M42;
        prmT000M42 = new Object[] {
        };
        Object[] prmT000M43;
        prmT000M43 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000M44;
        prmT000M44 = new Object[] {
        };
        Object[] prmT000M45;
        prmT000M45 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000M2", "SELECT [RubrosId], [MedidasID], [InventarioId], [InventarioNombre], [InventarioImagen_GXI], [InventarioConsumoProductivo], [InventarioCosto], [InventarioPrecioFinal], [InventarioSKURelacionado], [InventarioEsPresupuestado], [I], [EstadosTipo], [EstadosGenericosId], [InventarioTextosId] AS InventarioTextosId, [InventarioImagen] FROM [Inventario] WITH (UPDLOCK) WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M3", "SELECT [RubrosId], [MedidasID], [InventarioId], [InventarioNombre], [InventarioImagen_GXI], [InventarioConsumoProductivo], [InventarioCosto], [InventarioPrecioFinal], [InventarioSKURelacionado], [InventarioEsPresupuestado], [I], [EstadosTipo], [EstadosGenericosId], [InventarioTextosId] AS InventarioTextosId, [InventarioImagen] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M4", "SELECT [EstadosTipo] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M5", "SELECT [TextosTipo] AS InventarioTextosTipo, [TextosTitulo] AS InventarioTextosTitulo FROM [Textos] WHERE [TextosId] = @InventarioTextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M6", "SELECT [MedidasID], [RubrosCosto], [MedidasNombre], [RubrosPrecioBase], [MedidasEstado], [InventarioSerial], [RubrosId], [TextosId], [MonedaId] FROM [RubrosMedidas] WITH (UPDLOCK) WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M7", "SELECT [MedidasID], [RubrosCosto], [MedidasNombre], [RubrosPrecioBase], [MedidasEstado], [InventarioSerial], [RubrosId], [TextosId], [MonedaId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M8", "SELECT [RubrosImagen_GXI], [RubrosNombre], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M9", "SELECT [TextosTipo], [TextosTitulo] FROM [Textos] WHERE [TextosId] = @TextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M10", "SELECT TM1.[MedidasID], T2.[RubrosImagen_GXI], T2.[RubrosNombre], TM1.[RubrosCosto], TM1.[MedidasNombre], TM1.[RubrosPrecioBase], TM1.[MedidasEstado], T3.[TextosTipo], T3.[TextosTitulo], TM1.[InventarioSerial], TM1.[RubrosId], TM1.[TextosId], TM1.[MonedaId], T2.[RubrosImagen] FROM (([RubrosMedidas] TM1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = TM1.[RubrosId]) LEFT JOIN [Textos] T3 ON T3.[TextosId] = TM1.[TextosId]) WHERE TM1.[RubrosId] = @RubrosId and TM1.[MedidasID] = @MedidasID ORDER BY TM1.[RubrosId], TM1.[MedidasID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M11", "SELECT [RubrosImagen_GXI], [RubrosNombre], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M12", "SELECT [TextosTipo], [TextosTitulo] FROM [Textos] WHERE [TextosId] = @TextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M13", "SELECT [RubrosId], [MedidasID] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M14", "SELECT TOP 1 [RubrosId], [MedidasID] FROM [RubrosMedidas] WHERE ( [RubrosId] > @RubrosId or [RubrosId] = @RubrosId and [MedidasID] > @MedidasID) ORDER BY [RubrosId], [MedidasID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M15", "SELECT TOP 1 [RubrosId], [MedidasID] FROM [RubrosMedidas] WHERE ( [RubrosId] < @RubrosId or [RubrosId] = @RubrosId and [MedidasID] < @MedidasID) ORDER BY [RubrosId] DESC, [MedidasID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M16", "INSERT INTO [RubrosMedidas]([MedidasID], [RubrosCosto], [MedidasNombre], [RubrosPrecioBase], [MedidasEstado], [InventarioSerial], [RubrosId], [TextosId], [MonedaId], [MedidasImagen], [MedidasImagen_GXI]) VALUES(@MedidasID, @RubrosCosto, @MedidasNombre, @RubrosPrecioBase, @MedidasEstado, @InventarioSerial, @RubrosId, @TextosId, @MonedaId, CONVERT(varbinary(1), ''), '')", GxErrorMask.GX_NOMASK,prmT000M16)
           ,new CursorDef("T000M17", "UPDATE [RubrosMedidas] SET [RubrosCosto]=@RubrosCosto, [MedidasNombre]=@MedidasNombre, [RubrosPrecioBase]=@RubrosPrecioBase, [MedidasEstado]=@MedidasEstado, [InventarioSerial]=@InventarioSerial, [TextosId]=@TextosId, [MonedaId]=@MonedaId  WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID", GxErrorMask.GX_NOMASK,prmT000M17)
           ,new CursorDef("T000M18", "DELETE FROM [RubrosMedidas]  WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID", GxErrorMask.GX_NOMASK,prmT000M18)
           ,new CursorDef("T000M19", "SELECT [RubrosImagen_GXI], [RubrosNombre], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M20", "SELECT [TextosTipo], [TextosTitulo] FROM [Textos] WHERE [TextosId] = @TextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M21", "SELECT TOP 1 [MapeoID], [RubrosId], [MedidasID], [InventarioId] FROM [MapeosListado] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M22", "UPDATE [RubrosMedidas] SET [MonedaId]=@MonedaId, [InventarioSerial]=@InventarioSerial  WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID", GxErrorMask.GX_NOMASK,prmT000M22)
           ,new CursorDef("T000M23", "SELECT [RubrosId], [MedidasID] FROM [RubrosMedidas] ORDER BY [RubrosId], [MedidasID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M23,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M24", "SELECT T1.[RubrosId], T1.[MedidasID], T1.[InventarioId], T1.[InventarioNombre], T1.[InventarioImagen_GXI], T1.[InventarioConsumoProductivo], T1.[InventarioCosto], T1.[InventarioPrecioFinal], T1.[InventarioSKURelacionado], T1.[InventarioEsPresupuestado], T2.[TextosTipo] AS InventarioTextosTipo, T2.[TextosTitulo] AS InventarioTextosTitulo, T1.[I], T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[InventarioTextosId] AS InventarioTextosId, T1.[InventarioImagen] FROM ([Inventario] T1 LEFT JOIN [Textos] T2 ON T2.[TextosId] = T1.[InventarioTextosId]) WHERE T1.[RubrosId] = @RubrosId and T1.[MedidasID] = @MedidasID and T1.[InventarioId] = @InventarioId ORDER BY T1.[RubrosId], T1.[MedidasID], T1.[InventarioId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M24,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M25", "SELECT [EstadosTipo] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M26", "SELECT [TextosTipo] AS InventarioTextosTipo, [TextosTitulo] AS InventarioTextosTitulo FROM [Textos] WHERE [TextosId] = @InventarioTextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M27", "SELECT [RubrosId], [MedidasID], [InventarioId] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M28", "INSERT INTO [Inventario]([RubrosId], [MedidasID], [InventarioId], [InventarioNombre], [InventarioImagen], [InventarioImagen_GXI], [InventarioConsumoProductivo], [InventarioCosto], [InventarioPrecioFinal], [InventarioSKURelacionado], [InventarioEsPresupuestado], [I], [EstadosTipo], [EstadosGenericosId], [InventarioTextosId]) VALUES(@RubrosId, @MedidasID, @InventarioId, @InventarioNombre, @InventarioImagen, @InventarioImagen_GXI, @InventarioConsumoProductivo, @InventarioCosto, @InventarioPrecioFinal, @InventarioSKURelacionado, @InventarioEsPresupuestado, @I, @EstadosTipo, @EstadosGenericosId, @InventarioTextosId)", GxErrorMask.GX_NOMASK,prmT000M28)
           ,new CursorDef("T000M29", "UPDATE [Inventario] SET [InventarioNombre]=@InventarioNombre, [InventarioConsumoProductivo]=@InventarioConsumoProductivo, [InventarioCosto]=@InventarioCosto, [InventarioPrecioFinal]=@InventarioPrecioFinal, [InventarioSKURelacionado]=@InventarioSKURelacionado, [InventarioEsPresupuestado]=@InventarioEsPresupuestado, [I]=@I, [EstadosTipo]=@EstadosTipo, [EstadosGenericosId]=@EstadosGenericosId, [InventarioTextosId]=@InventarioTextosId  WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId", GxErrorMask.GX_NOMASK,prmT000M29)
           ,new CursorDef("T000M30", "UPDATE [Inventario] SET [InventarioImagen]=@InventarioImagen, [InventarioImagen_GXI]=@InventarioImagen_GXI  WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId", GxErrorMask.GX_NOMASK,prmT000M30)
           ,new CursorDef("T000M31", "DELETE FROM [Inventario]  WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId", GxErrorMask.GX_NOMASK,prmT000M31)
           ,new CursorDef("T000M32", "SELECT [TextosTipo] AS InventarioTextosTipo, [TextosTitulo] AS InventarioTextosTitulo FROM [Textos] WHERE [TextosId] = @InventarioTextosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M33", "SELECT TOP 1 [ProveedorID], [ComercioProductosRubrosID] FROM [ComercioProductosRubros] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M34", "SELECT TOP 1 [ComisionesID], [ComisionesAgruparRubrosId] FROM [ComisionesAgruparRubros] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M34,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M35", "SELECT TOP 1 [ProfComisionesID], [ProfComisionesRubrosId] FROM [ProfComisionesRubros] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M35,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M36", "SELECT TOP 1 [SolicitudesID], [SolicitudesItemsID] FROM [SolicitudesItems] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M36,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M37", "SELECT TOP 1 [ProveedorID], [ProveedorComisionID] FROM [ProveedorComision] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M37,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M38", "SELECT TOP 1 [MapeoID], [RubrosId], [MedidasID], [InventarioId] FROM [MapeosListado] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M38,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M39", "SELECT [RubrosId], [MedidasID], [InventarioId] FROM [Inventario] WHERE [RubrosId] = @RubrosId and [MedidasID] = @MedidasID ORDER BY [RubrosId], [MedidasID], [InventarioId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M39,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M40", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M40,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M41", "SELECT [RubrosId], [RubrosNombre], [RubrosEstado] FROM [Rubros] WHERE [RubrosEstado] = 'HAB' ORDER BY [RubrosNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M41,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M42", "SELECT [RubrosId], [MedidasID], [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE [MedidasEstado] <> 'DES' ORDER BY [MedidasNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M42,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M43", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo ORDER BY [EstadosGenericosNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M43,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M44", "SELECT [MonedaId], [MonedaISOSimbolo] FROM [Moneda] ORDER BY [MonedaISOSimbolo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M44,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M45", "SELECT [EstadosTipo] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M45,1, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((bool[]) buf[10])[0] = rslt.getBool(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((short[]) buf[12])[0] = rslt.getShort(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 3);
              ((int[]) buf[14])[0] = rslt.getInt(13);
              ((long[]) buf[15])[0] = rslt.getLong(14);
              ((bool[]) buf[16])[0] = rslt.wasNull(14);
              ((string[]) buf[17])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((bool[]) buf[10])[0] = rslt.getBool(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((short[]) buf[12])[0] = rslt.getShort(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 3);
              ((int[]) buf[14])[0] = rslt.getInt(13);
              ((long[]) buf[15])[0] = rslt.getLong(14);
              ((bool[]) buf[16])[0] = rslt.wasNull(14);
              ((string[]) buf[17])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((short[]) buf[10])[0] = rslt.getShort(9);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((short[]) buf[7])[0] = rslt.getShort(7);
              ((long[]) buf[8])[0] = rslt.getLong(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((short[]) buf[10])[0] = rslt.getShort(9);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 50);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 3);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((string[]) buf[8])[0] = rslt.getString(8, 20);
              ((string[]) buf[9])[0] = rslt.getString(9, 80);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((short[]) buf[11])[0] = rslt.getShort(11);
              ((long[]) buf[12])[0] = rslt.getLong(12);
              ((bool[]) buf[13])[0] = rslt.wasNull(12);
              ((short[]) buf[14])[0] = rslt.getShort(13);
              ((string[]) buf[15])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(2));
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 11 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 21 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 22 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((bool[]) buf[10])[0] = rslt.getBool(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((string[]) buf[12])[0] = rslt.getString(11, 20);
              ((string[]) buf[13])[0] = rslt.getString(12, 80);
              ((short[]) buf[14])[0] = rslt.getShort(13);
              ((string[]) buf[15])[0] = rslt.getString(14, 3);
              ((int[]) buf[16])[0] = rslt.getInt(15);
              ((long[]) buf[17])[0] = rslt.getLong(16);
              ((bool[]) buf[18])[0] = rslt.wasNull(16);
              ((string[]) buf[19])[0] = rslt.getMultimediaFile(17, rslt.getVarchar(5));
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 25 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 31 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 32 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 33 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 34 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 35 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 36 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              return;
           case 37 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 38 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 39 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 40 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 41 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              return;
           case 42 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              return;
           case 43 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}

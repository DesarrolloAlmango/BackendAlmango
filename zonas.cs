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
   public class zonas : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"DEPARTAMENTOMUNICIPIOID") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLADEPARTAMENTOMUNICIPIOID0W38( A112DepartamentoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
            n114DepartamentoMunicipioId = false;
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A112DepartamentoId, A114DepartamentoMunicipioId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "zonas.aspx")), "zonas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "zonas.aspx")))) ;
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
                  AV11DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11DepartamentoId", StringUtil.LTrimStr( (decimal)(AV11DepartamentoId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vDEPARTAMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"), context));
                  AV12DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV12DepartamentoMunicipioId), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vDEPARTAMENTOMUNICIPIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"), context));
                  AV10ZonasID = (long)(Math.Round(NumberUtil.Val( GetPar( "ZonasID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV10ZonasID", StringUtil.LTrimStr( (decimal)(AV10ZonasID), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vZONASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10ZonasID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Zonas", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = dynDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public zonas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public zonas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_DepartamentoId ,
                           long aP2_DepartamentoMunicipioId ,
                           long aP3_ZonasID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV11DepartamentoId = aP1_DepartamentoId;
         this.AV12DepartamentoMunicipioId = aP2_DepartamentoMunicipioId;
         this.AV10ZonasID = aP3_ZonasID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynDepartamentoId = new GXCombobox();
         dynDepartamentoMunicipioId = new GXCombobox();
         cmbZonasEstado = new GXCombobox();
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
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
            AssignProp("", false, dynDepartamentoId_Internalname, "Values", dynDepartamentoId.ToJavascriptSource(), true);
         }
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n114DepartamentoMunicipioId = false;
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Values", dynDepartamentoMunicipioId.ToJavascriptSource(), true);
         }
         if ( cmbZonasEstado.ItemCount > 0 )
         {
            A906ZonasEstado = cmbZonasEstado.getValidValue(A906ZonasEstado);
            n906ZonasEstado = false;
            AssignAttri("", false, "A906ZonasEstado", A906ZonasEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbZonasEstado.CurrentValue = StringUtil.RTrim( A906ZonasEstado);
            AssignProp("", false, cmbZonasEstado_Internalname, "Values", cmbZonasEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynDepartamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynDepartamentoId_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynDepartamentoId, dynDepartamentoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0)), 1, dynDepartamentoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDepartamentoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_Zonas.htm");
         dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
         AssignProp("", false, dynDepartamentoId_Internalname, "Values", (string)(dynDepartamentoId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynDepartamentoMunicipioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynDepartamentoMunicipioId_Internalname, context.GetMessage( "Municipio", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynDepartamentoMunicipioId, dynDepartamentoMunicipioId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0)), 1, dynDepartamentoMunicipioId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynDepartamentoMunicipioId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_Zonas.htm");
         dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Values", (string)(dynDepartamentoMunicipioId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtZonasID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtZonasID_Internalname, context.GetMessage( "Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtZonasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A110ZonasID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "Seleccione su Zona", ""), edtZonasID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtZonasID_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Zonas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtZonasNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtZonasNombre_Internalname, context.GetMessage( "Nombre de la Zona", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtZonasNombre_Internalname, StringUtil.RTrim( A111ZonasNombre), StringUtil.RTrim( context.localUtil.Format( A111ZonasNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtZonasNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtZonasNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "NombreLargo", "start", true, "", "HLP_Zonas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbZonasEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbZonasEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbZonasEstado, cmbZonasEstado_Internalname, StringUtil.RTrim( A906ZonasEstado), 1, cmbZonasEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbZonasEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_Zonas.htm");
         cmbZonasEstado.CurrentValue = StringUtil.RTrim( A906ZonasEstado);
         AssignProp("", false, cmbZonasEstado_Internalname, "Values", (string)(cmbZonasEstado.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Zonas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Zonas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Zonas.htm");
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
         E110W2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z110ZonasID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z112DepartamentoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z114DepartamentoMunicipioId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z111ZonasNombre = cgiGet( "Z111ZonasNombre");
               Z906ZonasEstado = cgiGet( "Z906ZonasEstado");
               n906ZonasEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A906ZonasEstado)) ? true : false);
               Z965ZonasHabilitarEcommerce = StringUtil.StrToBool( cgiGet( "Z965ZonasHabilitarEcommerce"));
               n965ZonasHabilitarEcommerce = ((false==A965ZonasHabilitarEcommerce) ? true : false);
               A965ZonasHabilitarEcommerce = StringUtil.StrToBool( cgiGet( "Z965ZonasHabilitarEcommerce"));
               n965ZonasHabilitarEcommerce = false;
               n965ZonasHabilitarEcommerce = ((false==A965ZonasHabilitarEcommerce) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV11DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vDEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV12DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vDEPARTAMENTOMUNICIPIOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV10ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vZONASID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A965ZonasHabilitarEcommerce = StringUtil.StrToBool( cgiGet( "ZONASHABILITARECOMMERCE"));
               n965ZonasHabilitarEcommerce = ((false==A965ZonasHabilitarEcommerce) ? true : false);
               AV16Pgmname = cgiGet( "vPGMNAME");
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
               dynDepartamentoId.CurrentValue = cgiGet( dynDepartamentoId_Internalname);
               A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynDepartamentoId_Internalname), "."), 18, MidpointRounding.ToEven));
               n112DepartamentoId = false;
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               dynDepartamentoMunicipioId.CurrentValue = cgiGet( dynDepartamentoMunicipioId_Internalname);
               A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynDepartamentoMunicipioId_Internalname), "."), 18, MidpointRounding.ToEven));
               n114DepartamentoMunicipioId = false;
               AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ZONASID");
                  AnyError = 1;
                  GX_FocusControl = edtZonasID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A110ZonasID = 0;
                  n110ZonasID = false;
                  AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
               }
               else
               {
                  A110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n110ZonasID = false;
                  AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
               }
               A111ZonasNombre = cgiGet( edtZonasNombre_Internalname);
               AssignAttri("", false, "A111ZonasNombre", A111ZonasNombre);
               cmbZonasEstado.CurrentValue = cgiGet( cmbZonasEstado_Internalname);
               A906ZonasEstado = cgiGet( cmbZonasEstado_Internalname);
               n906ZonasEstado = false;
               AssignAttri("", false, "A906ZonasEstado", A906ZonasEstado);
               n906ZonasEstado = (String.IsNullOrEmpty(StringUtil.RTrim( A906ZonasEstado)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Zonas");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ZonasHabilitarEcommerce", StringUtil.BoolToStr( A965ZonasHabilitarEcommerce));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A110ZonasID != Z110ZonasID ) || ( A112DepartamentoId != Z112DepartamentoId ) || ( A114DepartamentoMunicipioId != Z114DepartamentoMunicipioId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("zonas:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A110ZonasID = (long)(Math.Round(NumberUtil.Val( GetPar( "ZonasID"), "."), 18, MidpointRounding.ToEven));
                  n110ZonasID = false;
                  AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
                  A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
                  n112DepartamentoId = false;
                  AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
                  A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
                  n114DepartamentoMunicipioId = false;
                  AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
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
                     sMode38 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode38;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound38 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0W0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ZONASID");
                        AnyError = 1;
                        GX_FocusControl = edtZonasID_Internalname;
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
                           E110W2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120W2 ();
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
            E120W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0W38( ) ;
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
            DisableAttributes0W38( ) ;
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

      protected void CONFIRM_0W0( )
      {
         BeforeValidate0W38( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0W38( ) ;
            }
            else
            {
               CheckExtendedTable0W38( ) ;
               CloseExtendedTableCursors0W38( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0W0( )
      {
      }

      protected void E110W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV13WWPContext) ;
         AV7IsAuthorized = true;
         AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWZonas_Insert", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWZonas_Update", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV7IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWZonas_Delete", out  GXt_boolean1) ;
            AV7IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV7IsAuthorized", AV7IsAuthorized);
         }
         if ( ! AV7IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV16Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV8TrnContext.FromXml(AV9WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV8TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("zonasww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0W38( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z111ZonasNombre = T000W3_A111ZonasNombre[0];
               Z906ZonasEstado = T000W3_A906ZonasEstado[0];
               Z965ZonasHabilitarEcommerce = T000W3_A965ZonasHabilitarEcommerce[0];
            }
            else
            {
               Z111ZonasNombre = A111ZonasNombre;
               Z906ZonasEstado = A906ZonasEstado;
               Z965ZonasHabilitarEcommerce = A965ZonasHabilitarEcommerce;
            }
         }
         if ( GX_JID == -12 )
         {
            Z110ZonasID = A110ZonasID;
            Z111ZonasNombre = A111ZonasNombre;
            Z906ZonasEstado = A906ZonasEstado;
            Z965ZonasHabilitarEcommerce = A965ZonasHabilitarEcommerce;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV11DepartamentoId) )
         {
            A112DepartamentoId = AV11DepartamentoId;
            n112DepartamentoId = false;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         if ( ! (0==AV11DepartamentoId) )
         {
            dynDepartamentoId.Enabled = 0;
            AssignProp("", false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), true);
         }
         else
         {
            dynDepartamentoId.Enabled = 1;
            AssignProp("", false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), true);
         }
         if ( ! (0==AV11DepartamentoId) )
         {
            dynDepartamentoId.Enabled = 0;
            AssignProp("", false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), true);
         }
         if ( ! (0==AV12DepartamentoMunicipioId) )
         {
            A114DepartamentoMunicipioId = AV12DepartamentoMunicipioId;
            n114DepartamentoMunicipioId = false;
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         if ( ! (0==AV12DepartamentoMunicipioId) )
         {
            dynDepartamentoMunicipioId.Enabled = 0;
            AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), true);
         }
         else
         {
            dynDepartamentoMunicipioId.Enabled = 1;
            AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), true);
         }
         if ( ! (0==AV12DepartamentoMunicipioId) )
         {
            dynDepartamentoMunicipioId.Enabled = 0;
            AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), true);
         }
         if ( ! (0==AV10ZonasID) )
         {
            A110ZonasID = AV10ZonasID;
            n110ZonasID = false;
            AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
         }
         if ( ! (0==AV10ZonasID) )
         {
            edtZonasID_Enabled = 0;
            AssignProp("", false, edtZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonasID_Enabled), 5, 0), true);
         }
         else
         {
            edtZonasID_Enabled = 1;
            AssignProp("", false, edtZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonasID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV10ZonasID) )
         {
            edtZonasID_Enabled = 0;
            AssignProp("", false, edtZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonasID_Enabled), 5, 0), true);
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A906ZonasEstado)) && ( Gx_BScreen == 0 ) )
         {
            A906ZonasEstado = context.GetMessage( context.GetMessage( "HAB", ""), "");
            n906ZonasEstado = false;
            AssignAttri("", false, "A906ZonasEstado", A906ZonasEstado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            GXADEPARTAMENTOMUNICIPIOID_html0W38( A112DepartamentoId) ;
            AV16Pgmname = "Zonas";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         }
      }

      protected void Load0W38( )
      {
         /* Using cursor T000W5 */
         pr_default.execute(3, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound38 = 1;
            A111ZonasNombre = T000W5_A111ZonasNombre[0];
            AssignAttri("", false, "A111ZonasNombre", A111ZonasNombre);
            A906ZonasEstado = T000W5_A906ZonasEstado[0];
            n906ZonasEstado = T000W5_n906ZonasEstado[0];
            AssignAttri("", false, "A906ZonasEstado", A906ZonasEstado);
            A965ZonasHabilitarEcommerce = T000W5_A965ZonasHabilitarEcommerce[0];
            n965ZonasHabilitarEcommerce = T000W5_n965ZonasHabilitarEcommerce[0];
            ZM0W38( -12) ;
         }
         pr_default.close(3);
         OnLoadActions0W38( ) ;
      }

      protected void OnLoadActions0W38( )
      {
         AV16Pgmname = "Zonas";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         GXADEPARTAMENTOMUNICIPIOID_html0W38( A112DepartamentoId) ;
      }

      protected void CheckExtendedTable0W38( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV16Pgmname = "Zonas";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         GXADEPARTAMENTOMUNICIPIOID_html0W38( A112DepartamentoId) ;
         /* Using cursor T000W4 */
         pr_default.execute(2, new Object[] {n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0W38( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( long A112DepartamentoId ,
                                long A114DepartamentoMunicipioId )
      {
         /* Using cursor T000W6 */
         pr_default.execute(4, new Object[] {n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
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

      protected void GetKey0W38( )
      {
         /* Using cursor T000W7 */
         pr_default.execute(5, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound38 = 1;
         }
         else
         {
            RcdFound38 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000W3 */
         pr_default.execute(1, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0W38( 12) ;
            RcdFound38 = 1;
            A110ZonasID = T000W3_A110ZonasID[0];
            n110ZonasID = T000W3_n110ZonasID[0];
            AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
            A111ZonasNombre = T000W3_A111ZonasNombre[0];
            AssignAttri("", false, "A111ZonasNombre", A111ZonasNombre);
            A906ZonasEstado = T000W3_A906ZonasEstado[0];
            n906ZonasEstado = T000W3_n906ZonasEstado[0];
            AssignAttri("", false, "A906ZonasEstado", A906ZonasEstado);
            A965ZonasHabilitarEcommerce = T000W3_A965ZonasHabilitarEcommerce[0];
            n965ZonasHabilitarEcommerce = T000W3_n965ZonasHabilitarEcommerce[0];
            A112DepartamentoId = T000W3_A112DepartamentoId[0];
            n112DepartamentoId = T000W3_n112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = T000W3_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = T000W3_n114DepartamentoMunicipioId[0];
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            Z110ZonasID = A110ZonasID;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0W38( ) ;
            if ( AnyError == 1 )
            {
               RcdFound38 = 0;
               InitializeNonKey0W38( ) ;
            }
            Gx_mode = sMode38;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound38 = 0;
            InitializeNonKey0W38( ) ;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode38;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0W38( ) ;
         if ( RcdFound38 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound38 = 0;
         /* Using cursor T000W8 */
         pr_default.execute(6, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000W8_A110ZonasID[0] < A110ZonasID ) || ( T000W8_A110ZonasID[0] == A110ZonasID ) && ( T000W8_A112DepartamentoId[0] < A112DepartamentoId ) || ( T000W8_A112DepartamentoId[0] == A112DepartamentoId ) && ( T000W8_A110ZonasID[0] == A110ZonasID ) && ( T000W8_A114DepartamentoMunicipioId[0] < A114DepartamentoMunicipioId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000W8_A110ZonasID[0] > A110ZonasID ) || ( T000W8_A110ZonasID[0] == A110ZonasID ) && ( T000W8_A112DepartamentoId[0] > A112DepartamentoId ) || ( T000W8_A112DepartamentoId[0] == A112DepartamentoId ) && ( T000W8_A110ZonasID[0] == A110ZonasID ) && ( T000W8_A114DepartamentoMunicipioId[0] > A114DepartamentoMunicipioId ) ) )
            {
               A110ZonasID = T000W8_A110ZonasID[0];
               n110ZonasID = T000W8_n110ZonasID[0];
               AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
               A112DepartamentoId = T000W8_A112DepartamentoId[0];
               n112DepartamentoId = T000W8_n112DepartamentoId[0];
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               A114DepartamentoMunicipioId = T000W8_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = T000W8_n114DepartamentoMunicipioId[0];
               AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
               RcdFound38 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound38 = 0;
         /* Using cursor T000W9 */
         pr_default.execute(7, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000W9_A110ZonasID[0] > A110ZonasID ) || ( T000W9_A110ZonasID[0] == A110ZonasID ) && ( T000W9_A112DepartamentoId[0] > A112DepartamentoId ) || ( T000W9_A112DepartamentoId[0] == A112DepartamentoId ) && ( T000W9_A110ZonasID[0] == A110ZonasID ) && ( T000W9_A114DepartamentoMunicipioId[0] > A114DepartamentoMunicipioId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000W9_A110ZonasID[0] < A110ZonasID ) || ( T000W9_A110ZonasID[0] == A110ZonasID ) && ( T000W9_A112DepartamentoId[0] < A112DepartamentoId ) || ( T000W9_A112DepartamentoId[0] == A112DepartamentoId ) && ( T000W9_A110ZonasID[0] == A110ZonasID ) && ( T000W9_A114DepartamentoMunicipioId[0] < A114DepartamentoMunicipioId ) ) )
            {
               A110ZonasID = T000W9_A110ZonasID[0];
               n110ZonasID = T000W9_n110ZonasID[0];
               AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
               A112DepartamentoId = T000W9_A112DepartamentoId[0];
               n112DepartamentoId = T000W9_n112DepartamentoId[0];
               AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
               A114DepartamentoMunicipioId = T000W9_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = T000W9_n114DepartamentoMunicipioId[0];
               AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
               RcdFound38 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0W38( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = dynDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0W38( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound38 == 1 )
            {
               if ( ( A110ZonasID != Z110ZonasID ) || ( A112DepartamentoId != Z112DepartamentoId ) || ( A114DepartamentoMunicipioId != Z114DepartamentoMunicipioId ) )
               {
                  A110ZonasID = Z110ZonasID;
                  n110ZonasID = false;
                  AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
                  A112DepartamentoId = Z112DepartamentoId;
                  n112DepartamentoId = false;
                  AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
                  A114DepartamentoMunicipioId = Z114DepartamentoMunicipioId;
                  n114DepartamentoMunicipioId = false;
                  AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ZONASID");
                  AnyError = 1;
                  GX_FocusControl = edtZonasID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = dynDepartamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0W38( ) ;
                  GX_FocusControl = dynDepartamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A110ZonasID != Z110ZonasID ) || ( A112DepartamentoId != Z112DepartamentoId ) || ( A114DepartamentoMunicipioId != Z114DepartamentoMunicipioId ) )
               {
                  /* Insert record */
                  GX_FocusControl = dynDepartamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0W38( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ZONASID");
                     AnyError = 1;
                     GX_FocusControl = edtZonasID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = dynDepartamentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0W38( ) ;
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
         if ( ( A110ZonasID != Z110ZonasID ) || ( A112DepartamentoId != Z112DepartamentoId ) || ( A114DepartamentoMunicipioId != Z114DepartamentoMunicipioId ) )
         {
            A110ZonasID = Z110ZonasID;
            n110ZonasID = false;
            AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
            A112DepartamentoId = Z112DepartamentoId;
            n112DepartamentoId = false;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = Z114DepartamentoMunicipioId;
            n114DepartamentoMunicipioId = false;
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ZONASID");
            AnyError = 1;
            GX_FocusControl = edtZonasID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = dynDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0W38( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000W2 */
            pr_default.execute(0, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Zonas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z111ZonasNombre, T000W2_A111ZonasNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z906ZonasEstado, T000W2_A906ZonasEstado[0]) != 0 ) || ( Z965ZonasHabilitarEcommerce != T000W2_A965ZonasHabilitarEcommerce[0] ) )
            {
               if ( StringUtil.StrCmp(Z111ZonasNombre, T000W2_A111ZonasNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("zonas:[seudo value changed for attri]"+"ZonasNombre");
                  GXUtil.WriteLogRaw("Old: ",Z111ZonasNombre);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A111ZonasNombre[0]);
               }
               if ( StringUtil.StrCmp(Z906ZonasEstado, T000W2_A906ZonasEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("zonas:[seudo value changed for attri]"+"ZonasEstado");
                  GXUtil.WriteLogRaw("Old: ",Z906ZonasEstado);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A906ZonasEstado[0]);
               }
               if ( Z965ZonasHabilitarEcommerce != T000W2_A965ZonasHabilitarEcommerce[0] )
               {
                  GXUtil.WriteLog("zonas:[seudo value changed for attri]"+"ZonasHabilitarEcommerce");
                  GXUtil.WriteLogRaw("Old: ",Z965ZonasHabilitarEcommerce);
                  GXUtil.WriteLogRaw("Current: ",T000W2_A965ZonasHabilitarEcommerce[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Zonas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W38( )
      {
         BeforeValidate0W38( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W38( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W38( 0) ;
            CheckOptimisticConcurrency0W38( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W38( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W38( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W10 */
                     pr_default.execute(8, new Object[] {n110ZonasID, A110ZonasID, A111ZonasNombre, n906ZonasEstado, A906ZonasEstado, n965ZonasHabilitarEcommerce, A965ZonasHabilitarEcommerce, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Zonas");
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
                           ResetCaption0W0( ) ;
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
               Load0W38( ) ;
            }
            EndLevel0W38( ) ;
         }
         CloseExtendedTableCursors0W38( ) ;
      }

      protected void Update0W38( )
      {
         BeforeValidate0W38( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W38( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W38( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W38( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W38( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000W11 */
                     pr_default.execute(9, new Object[] {A111ZonasNombre, n906ZonasEstado, A906ZonasEstado, n965ZonasHabilitarEcommerce, A965ZonasHabilitarEcommerce, n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Zonas");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Zonas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W38( ) ;
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
            EndLevel0W38( ) ;
         }
         CloseExtendedTableCursors0W38( ) ;
      }

      protected void DeferredUpdate0W38( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0W38( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W38( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W38( ) ;
            AfterConfirm0W38( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W38( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000W12 */
                  pr_default.execute(10, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Zonas");
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
         sMode38 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0W38( ) ;
         Gx_mode = sMode38;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0W38( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "Zonas";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            GXADEPARTAMENTOMUNICIPIOID_html0W38( A112DepartamentoId) ;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000W13 */
            pr_default.execute(11, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Seleccione la zona de trabajo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000W14 */
            pr_default.execute(12, new Object[] {n110ZonasID, A110ZonasID, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0W38( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0W38( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("zonas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("zonas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0W38( )
      {
         /* Scan By routine */
         /* Using cursor T000W15 */
         pr_default.execute(13);
         RcdFound38 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound38 = 1;
            A110ZonasID = T000W15_A110ZonasID[0];
            n110ZonasID = T000W15_n110ZonasID[0];
            AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
            A112DepartamentoId = T000W15_A112DepartamentoId[0];
            n112DepartamentoId = T000W15_n112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = T000W15_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = T000W15_n114DepartamentoMunicipioId[0];
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0W38( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound38 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound38 = 1;
            A110ZonasID = T000W15_A110ZonasID[0];
            n110ZonasID = T000W15_n110ZonasID[0];
            AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
            A112DepartamentoId = T000W15_A112DepartamentoId[0];
            n112DepartamentoId = T000W15_n112DepartamentoId[0];
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
            A114DepartamentoMunicipioId = T000W15_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = T000W15_n114DepartamentoMunicipioId[0];
            AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
      }

      protected void ScanEnd0W38( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0W38( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W38( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W38( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W38( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W38( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W38( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W38( )
      {
         dynDepartamentoId.Enabled = 0;
         AssignProp("", false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), true);
         dynDepartamentoMunicipioId.Enabled = 0;
         AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), true);
         edtZonasID_Enabled = 0;
         AssignProp("", false, edtZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonasID_Enabled), 5, 0), true);
         edtZonasNombre_Enabled = 0;
         AssignProp("", false, edtZonasNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtZonasNombre_Enabled), 5, 0), true);
         cmbZonasEstado.Enabled = 0;
         AssignProp("", false, cmbZonasEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbZonasEstado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0W38( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0W0( )
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
         GXEncryptionTmp = "zonas.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV11DepartamentoId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV12DepartamentoMunicipioId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10ZonasID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("zonas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Zonas");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ZonasHabilitarEcommerce", StringUtil.BoolToStr( A965ZonasHabilitarEcommerce));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("zonas:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z110ZonasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z112DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z111ZonasNombre", StringUtil.RTrim( Z111ZonasNombre));
         GxWebStd.gx_hidden_field( context, "Z906ZonasEstado", StringUtil.RTrim( Z906ZonasEstado));
         GxWebStd.gx_boolean_hidden_field( context, "Z965ZonasHabilitarEcommerce", Z965ZonasHabilitarEcommerce);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV8TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV8TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV8TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDEPARTAMENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11DepartamentoId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vDEPARTAMENTOMUNICIPIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDEPARTAMENTOMUNICIPIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vZONASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vZONASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10ZonasID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "ZONASHABILITARECOMMERCE", A965ZonasHabilitarEcommerce);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
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
         GXEncryptionTmp = "zonas.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV11DepartamentoId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV12DepartamentoMunicipioId,18,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10ZonasID,18,0));
         return formatLink("zonas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Zonas" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Zonas", "") ;
      }

      protected void InitializeNonKey0W38( )
      {
         A111ZonasNombre = "";
         AssignAttri("", false, "A111ZonasNombre", A111ZonasNombre);
         A965ZonasHabilitarEcommerce = false;
         n965ZonasHabilitarEcommerce = false;
         AssignAttri("", false, "A965ZonasHabilitarEcommerce", A965ZonasHabilitarEcommerce);
         A906ZonasEstado = context.GetMessage( "HAB", "");
         n906ZonasEstado = false;
         AssignAttri("", false, "A906ZonasEstado", A906ZonasEstado);
         Z111ZonasNombre = "";
         Z906ZonasEstado = "";
         Z965ZonasHabilitarEcommerce = false;
      }

      protected void InitAll0W38( )
      {
         A110ZonasID = 0;
         n110ZonasID = false;
         AssignAttri("", false, "A110ZonasID", StringUtil.LTrimStr( (decimal)(A110ZonasID), 18, 0));
         A112DepartamentoId = 0;
         n112DepartamentoId = false;
         AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         A114DepartamentoMunicipioId = 0;
         n114DepartamentoMunicipioId = false;
         AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         InitializeNonKey0W38( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A906ZonasEstado = i906ZonasEstado;
         n906ZonasEstado = false;
         AssignAttri("", false, "A906ZonasEstado", A906ZonasEstado);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021104878", true, true, false);
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
         context.AddJavascriptSource("zonas.js", "?202673021104878", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         dynDepartamentoId_Internalname = "DEPARTAMENTOID";
         dynDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID";
         edtZonasID_Internalname = "ZONASID";
         edtZonasNombre_Internalname = "ZONASNOMBRE";
         cmbZonasEstado_Internalname = "ZONASESTADO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Zonas", "");
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbZonasEstado_Jsonclick = "";
         cmbZonasEstado.Enabled = 1;
         edtZonasNombre_Jsonclick = "";
         edtZonasNombre_Enabled = 1;
         edtZonasID_Jsonclick = "";
         edtZonasID_Enabled = 1;
         dynDepartamentoMunicipioId_Jsonclick = "";
         dynDepartamentoMunicipioId.Enabled = 1;
         dynDepartamentoId_Jsonclick = "";
         dynDepartamentoId.Enabled = 1;
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
         GXADEPARTAMENTOMUNICIPIOID_html0W38( A112DepartamentoId) ;
         /* End function dynload_actions */
      }

      protected void GXDLADEPARTAMENTOID0W1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOID_data0W1( ) ;
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

      protected void GXADEPARTAMENTOID_html0W1( )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOID_data0W1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynDepartamentoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLADEPARTAMENTOID_data0W1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000W16 */
         pr_default.execute(14);
         while ( (pr_default.getStatus(14) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000W16_A112DepartamentoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000W16_A113DepartamentoDepartamento[0]));
            pr_default.readNext(14);
         }
         pr_default.close(14);
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOID0W38( long A112DepartamentoId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOMUNICIPIOID_data0W38( A112DepartamentoId) ;
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

      protected void GXADEPARTAMENTOMUNICIPIOID_html0W38( long A112DepartamentoId )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOMUNICIPIOID_data0W38( A112DepartamentoId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynDepartamentoMunicipioId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynDepartamentoMunicipioId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOID_data0W38( long A112DepartamentoId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000W17 */
         pr_default.execute(15, new Object[] {n112DepartamentoId, A112DepartamentoId});
         while ( (pr_default.getStatus(15) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000W17_A114DepartamentoMunicipioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000W17_A115DepartamentoMunicipioNombre[0]));
            pr_default.readNext(15);
         }
         pr_default.close(15);
      }

      protected void init_web_controls( )
      {
         dynDepartamentoId.Name = "DEPARTAMENTOID";
         dynDepartamentoId.WebTags = "";
         dynDepartamentoId.removeAllItems();
         /* Using cursor T000W18 */
         pr_default.execute(16);
         while ( (pr_default.getStatus(16) != 101) )
         {
            dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000W18_A112DepartamentoId[0]), 18, 0)), T000W18_A113DepartamentoDepartamento[0], 0);
            pr_default.readNext(16);
         }
         pr_default.close(16);
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
            AssignAttri("", false, "A112DepartamentoId", StringUtil.LTrimStr( (decimal)(A112DepartamentoId), 18, 0));
         }
         dynDepartamentoMunicipioId.Name = "DEPARTAMENTOMUNICIPIOID";
         dynDepartamentoMunicipioId.WebTags = "";
         cmbZonasEstado.Name = "ZONASESTADO";
         cmbZonasEstado.WebTags = "";
         cmbZonasEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbZonasEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         if ( cmbZonasEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A906ZonasEstado)) )
            {
               A906ZonasEstado = context.GetMessage( "HAB", "");
               n906ZonasEstado = false;
               AssignAttri("", false, "A906ZonasEstado", A906ZonasEstado);
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

      public void Valid_Departamentoid( )
      {
         n112DepartamentoId = false;
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n112DepartamentoId = false;
         n114DepartamentoMunicipioId = false;
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n114DepartamentoMunicipioId = false;
         GXADEPARTAMENTOMUNICIPIOID_html0W38( A112DepartamentoId) ;
         dynload_actions( ) ;
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
         }
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n114DepartamentoMunicipioId = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", "")));
         dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Values", dynDepartamentoMunicipioId.ToJavascriptSource(), true);
      }

      public void Valid_Departamentomunicipioid( )
      {
         n112DepartamentoId = false;
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n112DepartamentoId = false;
         n114DepartamentoMunicipioId = false;
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n114DepartamentoMunicipioId = false;
         /* Using cursor T000W19 */
         pr_default.execute(17, new Object[] {n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
         }
         pr_default.close(17);
         dynload_actions( ) ;
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n112DepartamentoId = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
         }
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n114DepartamentoMunicipioId = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV12DepartamentoMunicipioId',fld:'vDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV10ZonasID',fld:'vZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV11DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV12DepartamentoMunicipioId',fld:'vDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV10ZonasID',fld:'vZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A965ZonasHabilitarEcommerce',fld:'ZONASHABILITARECOMMERCE',pic:'',type:'boolean'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("AFTER TRN","{handler:'E120W2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID","{handler:'Valid_Departamentomunicipioid',iparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_ZONASID","{handler:'Valid_Zonasid',iparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("VALID_ZONASID",",oparms:[{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
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
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z111ZonasNombre = "";
         Z906ZonasEstado = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A906ZonasEstado = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A111ZonasNombre = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV16Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode38 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV13WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9WebSession = context.GetSession();
         T000W5_A110ZonasID = new long[1] ;
         T000W5_n110ZonasID = new bool[] {false} ;
         T000W5_A111ZonasNombre = new string[] {""} ;
         T000W5_A906ZonasEstado = new string[] {""} ;
         T000W5_n906ZonasEstado = new bool[] {false} ;
         T000W5_A965ZonasHabilitarEcommerce = new bool[] {false} ;
         T000W5_n965ZonasHabilitarEcommerce = new bool[] {false} ;
         T000W5_A112DepartamentoId = new long[1] ;
         T000W5_n112DepartamentoId = new bool[] {false} ;
         T000W5_A114DepartamentoMunicipioId = new long[1] ;
         T000W5_n114DepartamentoMunicipioId = new bool[] {false} ;
         T000W4_A112DepartamentoId = new long[1] ;
         T000W4_n112DepartamentoId = new bool[] {false} ;
         T000W6_A112DepartamentoId = new long[1] ;
         T000W6_n112DepartamentoId = new bool[] {false} ;
         T000W7_A110ZonasID = new long[1] ;
         T000W7_n110ZonasID = new bool[] {false} ;
         T000W7_A112DepartamentoId = new long[1] ;
         T000W7_n112DepartamentoId = new bool[] {false} ;
         T000W7_A114DepartamentoMunicipioId = new long[1] ;
         T000W7_n114DepartamentoMunicipioId = new bool[] {false} ;
         T000W3_A110ZonasID = new long[1] ;
         T000W3_n110ZonasID = new bool[] {false} ;
         T000W3_A111ZonasNombre = new string[] {""} ;
         T000W3_A906ZonasEstado = new string[] {""} ;
         T000W3_n906ZonasEstado = new bool[] {false} ;
         T000W3_A965ZonasHabilitarEcommerce = new bool[] {false} ;
         T000W3_n965ZonasHabilitarEcommerce = new bool[] {false} ;
         T000W3_A112DepartamentoId = new long[1] ;
         T000W3_n112DepartamentoId = new bool[] {false} ;
         T000W3_A114DepartamentoMunicipioId = new long[1] ;
         T000W3_n114DepartamentoMunicipioId = new bool[] {false} ;
         T000W8_A110ZonasID = new long[1] ;
         T000W8_n110ZonasID = new bool[] {false} ;
         T000W8_A112DepartamentoId = new long[1] ;
         T000W8_n112DepartamentoId = new bool[] {false} ;
         T000W8_A114DepartamentoMunicipioId = new long[1] ;
         T000W8_n114DepartamentoMunicipioId = new bool[] {false} ;
         T000W9_A110ZonasID = new long[1] ;
         T000W9_n110ZonasID = new bool[] {false} ;
         T000W9_A112DepartamentoId = new long[1] ;
         T000W9_n112DepartamentoId = new bool[] {false} ;
         T000W9_A114DepartamentoMunicipioId = new long[1] ;
         T000W9_n114DepartamentoMunicipioId = new bool[] {false} ;
         T000W2_A110ZonasID = new long[1] ;
         T000W2_n110ZonasID = new bool[] {false} ;
         T000W2_A111ZonasNombre = new string[] {""} ;
         T000W2_A906ZonasEstado = new string[] {""} ;
         T000W2_n906ZonasEstado = new bool[] {false} ;
         T000W2_A965ZonasHabilitarEcommerce = new bool[] {false} ;
         T000W2_n965ZonasHabilitarEcommerce = new bool[] {false} ;
         T000W2_A112DepartamentoId = new long[1] ;
         T000W2_n112DepartamentoId = new bool[] {false} ;
         T000W2_A114DepartamentoMunicipioId = new long[1] ;
         T000W2_n114DepartamentoMunicipioId = new bool[] {false} ;
         T000W13_A120ProfesionalesId = new string[] {""} ;
         T000W13_A126ProfesionalesZonasCorrelativo = new short[1] ;
         T000W14_A127SolicitudesID = new long[1] ;
         T000W15_A110ZonasID = new long[1] ;
         T000W15_n110ZonasID = new bool[] {false} ;
         T000W15_A112DepartamentoId = new long[1] ;
         T000W15_n112DepartamentoId = new bool[] {false} ;
         T000W15_A114DepartamentoMunicipioId = new long[1] ;
         T000W15_n114DepartamentoMunicipioId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i906ZonasEstado = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000W16_A112DepartamentoId = new long[1] ;
         T000W16_n112DepartamentoId = new bool[] {false} ;
         T000W16_A113DepartamentoDepartamento = new string[] {""} ;
         T000W17_A112DepartamentoId = new long[1] ;
         T000W17_n112DepartamentoId = new bool[] {false} ;
         T000W17_A114DepartamentoMunicipioId = new long[1] ;
         T000W17_n114DepartamentoMunicipioId = new bool[] {false} ;
         T000W17_A115DepartamentoMunicipioNombre = new string[] {""} ;
         T000W18_A112DepartamentoId = new long[1] ;
         T000W18_n112DepartamentoId = new bool[] {false} ;
         T000W18_A113DepartamentoDepartamento = new string[] {""} ;
         T000W19_A112DepartamentoId = new long[1] ;
         T000W19_n112DepartamentoId = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.zonas__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.zonas__default(),
            new Object[][] {
                new Object[] {
               T000W2_A110ZonasID, T000W2_A111ZonasNombre, T000W2_A906ZonasEstado, T000W2_n906ZonasEstado, T000W2_A965ZonasHabilitarEcommerce, T000W2_n965ZonasHabilitarEcommerce, T000W2_A112DepartamentoId, T000W2_A114DepartamentoMunicipioId
               }
               , new Object[] {
               T000W3_A110ZonasID, T000W3_A111ZonasNombre, T000W3_A906ZonasEstado, T000W3_n906ZonasEstado, T000W3_A965ZonasHabilitarEcommerce, T000W3_n965ZonasHabilitarEcommerce, T000W3_A112DepartamentoId, T000W3_A114DepartamentoMunicipioId
               }
               , new Object[] {
               T000W4_A112DepartamentoId
               }
               , new Object[] {
               T000W5_A110ZonasID, T000W5_A111ZonasNombre, T000W5_A906ZonasEstado, T000W5_n906ZonasEstado, T000W5_A965ZonasHabilitarEcommerce, T000W5_n965ZonasHabilitarEcommerce, T000W5_A112DepartamentoId, T000W5_A114DepartamentoMunicipioId
               }
               , new Object[] {
               T000W6_A112DepartamentoId
               }
               , new Object[] {
               T000W7_A110ZonasID, T000W7_A112DepartamentoId, T000W7_A114DepartamentoMunicipioId
               }
               , new Object[] {
               T000W8_A110ZonasID, T000W8_A112DepartamentoId, T000W8_A114DepartamentoMunicipioId
               }
               , new Object[] {
               T000W9_A110ZonasID, T000W9_A112DepartamentoId, T000W9_A114DepartamentoMunicipioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000W13_A120ProfesionalesId, T000W13_A126ProfesionalesZonasCorrelativo
               }
               , new Object[] {
               T000W14_A127SolicitudesID
               }
               , new Object[] {
               T000W15_A110ZonasID, T000W15_A112DepartamentoId, T000W15_A114DepartamentoMunicipioId
               }
               , new Object[] {
               T000W16_A112DepartamentoId, T000W16_A113DepartamentoDepartamento
               }
               , new Object[] {
               T000W17_A112DepartamentoId, T000W17_A114DepartamentoMunicipioId, T000W17_A115DepartamentoMunicipioNombre
               }
               , new Object[] {
               T000W18_A112DepartamentoId, T000W18_A113DepartamentoDepartamento
               }
               , new Object[] {
               T000W19_A112DepartamentoId
               }
            }
         );
         AV16Pgmname = "Zonas";
         Z906ZonasEstado = context.GetMessage( "HAB", "");
         n906ZonasEstado = false;
         A906ZonasEstado = context.GetMessage( "HAB", "");
         n906ZonasEstado = false;
         i906ZonasEstado = context.GetMessage( "HAB", "");
         n906ZonasEstado = false;
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound38 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtZonasID_Enabled ;
      private int edtZonasNombre_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private long wcpOAV11DepartamentoId ;
      private long wcpOAV12DepartamentoMunicipioId ;
      private long wcpOAV10ZonasID ;
      private long Z110ZonasID ;
      private long Z112DepartamentoId ;
      private long Z114DepartamentoMunicipioId ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long AV11DepartamentoId ;
      private long AV12DepartamentoMunicipioId ;
      private long AV10ZonasID ;
      private long A110ZonasID ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z111ZonasNombre ;
      private string Z906ZonasEstado ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string dynDepartamentoId_Internalname ;
      private string dynDepartamentoMunicipioId_Internalname ;
      private string A906ZonasEstado ;
      private string cmbZonasEstado_Internalname ;
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
      private string dynDepartamentoId_Jsonclick ;
      private string dynDepartamentoMunicipioId_Jsonclick ;
      private string edtZonasID_Internalname ;
      private string edtZonasID_Jsonclick ;
      private string edtZonasNombre_Internalname ;
      private string A111ZonasNombre ;
      private string edtZonasNombre_Jsonclick ;
      private string cmbZonasEstado_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string AV16Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode38 ;
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
      private string i906ZonasEstado ;
      private string gxwrpcisep ;
      private bool Z965ZonasHabilitarEcommerce ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool wbErr ;
      private bool n906ZonasEstado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n965ZonasHabilitarEcommerce ;
      private bool A965ZonasHabilitarEcommerce ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n110ZonasID ;
      private bool returnInSub ;
      private bool AV7IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool gxdyncontrolsrefreshing ;
      private IGxSession AV9WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynDepartamentoId ;
      private GXCombobox dynDepartamentoMunicipioId ;
      private GXCombobox cmbZonasEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV13WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private IDataStoreProvider pr_default ;
      private long[] T000W5_A110ZonasID ;
      private bool[] T000W5_n110ZonasID ;
      private string[] T000W5_A111ZonasNombre ;
      private string[] T000W5_A906ZonasEstado ;
      private bool[] T000W5_n906ZonasEstado ;
      private bool[] T000W5_A965ZonasHabilitarEcommerce ;
      private bool[] T000W5_n965ZonasHabilitarEcommerce ;
      private long[] T000W5_A112DepartamentoId ;
      private bool[] T000W5_n112DepartamentoId ;
      private long[] T000W5_A114DepartamentoMunicipioId ;
      private bool[] T000W5_n114DepartamentoMunicipioId ;
      private long[] T000W4_A112DepartamentoId ;
      private bool[] T000W4_n112DepartamentoId ;
      private long[] T000W6_A112DepartamentoId ;
      private bool[] T000W6_n112DepartamentoId ;
      private long[] T000W7_A110ZonasID ;
      private bool[] T000W7_n110ZonasID ;
      private long[] T000W7_A112DepartamentoId ;
      private bool[] T000W7_n112DepartamentoId ;
      private long[] T000W7_A114DepartamentoMunicipioId ;
      private bool[] T000W7_n114DepartamentoMunicipioId ;
      private long[] T000W3_A110ZonasID ;
      private bool[] T000W3_n110ZonasID ;
      private string[] T000W3_A111ZonasNombre ;
      private string[] T000W3_A906ZonasEstado ;
      private bool[] T000W3_n906ZonasEstado ;
      private bool[] T000W3_A965ZonasHabilitarEcommerce ;
      private bool[] T000W3_n965ZonasHabilitarEcommerce ;
      private long[] T000W3_A112DepartamentoId ;
      private bool[] T000W3_n112DepartamentoId ;
      private long[] T000W3_A114DepartamentoMunicipioId ;
      private bool[] T000W3_n114DepartamentoMunicipioId ;
      private long[] T000W8_A110ZonasID ;
      private bool[] T000W8_n110ZonasID ;
      private long[] T000W8_A112DepartamentoId ;
      private bool[] T000W8_n112DepartamentoId ;
      private long[] T000W8_A114DepartamentoMunicipioId ;
      private bool[] T000W8_n114DepartamentoMunicipioId ;
      private long[] T000W9_A110ZonasID ;
      private bool[] T000W9_n110ZonasID ;
      private long[] T000W9_A112DepartamentoId ;
      private bool[] T000W9_n112DepartamentoId ;
      private long[] T000W9_A114DepartamentoMunicipioId ;
      private bool[] T000W9_n114DepartamentoMunicipioId ;
      private long[] T000W2_A110ZonasID ;
      private bool[] T000W2_n110ZonasID ;
      private string[] T000W2_A111ZonasNombre ;
      private string[] T000W2_A906ZonasEstado ;
      private bool[] T000W2_n906ZonasEstado ;
      private bool[] T000W2_A965ZonasHabilitarEcommerce ;
      private bool[] T000W2_n965ZonasHabilitarEcommerce ;
      private long[] T000W2_A112DepartamentoId ;
      private bool[] T000W2_n112DepartamentoId ;
      private long[] T000W2_A114DepartamentoMunicipioId ;
      private bool[] T000W2_n114DepartamentoMunicipioId ;
      private string[] T000W13_A120ProfesionalesId ;
      private short[] T000W13_A126ProfesionalesZonasCorrelativo ;
      private long[] T000W14_A127SolicitudesID ;
      private long[] T000W15_A110ZonasID ;
      private bool[] T000W15_n110ZonasID ;
      private long[] T000W15_A112DepartamentoId ;
      private bool[] T000W15_n112DepartamentoId ;
      private long[] T000W15_A114DepartamentoMunicipioId ;
      private bool[] T000W15_n114DepartamentoMunicipioId ;
      private long[] T000W16_A112DepartamentoId ;
      private bool[] T000W16_n112DepartamentoId ;
      private string[] T000W16_A113DepartamentoDepartamento ;
      private long[] T000W17_A112DepartamentoId ;
      private bool[] T000W17_n112DepartamentoId ;
      private long[] T000W17_A114DepartamentoMunicipioId ;
      private bool[] T000W17_n114DepartamentoMunicipioId ;
      private string[] T000W17_A115DepartamentoMunicipioNombre ;
      private long[] T000W18_A112DepartamentoId ;
      private bool[] T000W18_n112DepartamentoId ;
      private string[] T000W18_A113DepartamentoDepartamento ;
      private long[] T000W19_A112DepartamentoId ;
      private bool[] T000W19_n112DepartamentoId ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class zonas__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class zonas__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000W2;
        prmT000W2 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W3;
        prmT000W3 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W4;
        prmT000W4 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W5;
        prmT000W5 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W6;
        prmT000W6 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W7;
        prmT000W7 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W8;
        prmT000W8 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W9;
        prmT000W9 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W10;
        prmT000W10 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ZonasNombre",GXType.NChar,120,0) ,
        new ParDef("@ZonasEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ZonasHabilitarEcommerce",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W11;
        prmT000W11 = new Object[] {
        new ParDef("@ZonasNombre",GXType.NChar,120,0) ,
        new ParDef("@ZonasEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ZonasHabilitarEcommerce",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W12;
        prmT000W12 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W13;
        prmT000W13 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W14;
        prmT000W14 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W15;
        prmT000W15 = new Object[] {
        };
        Object[] prmT000W16;
        prmT000W16 = new Object[] {
        };
        Object[] prmT000W17;
        prmT000W17 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000W18;
        prmT000W18 = new Object[] {
        };
        Object[] prmT000W19;
        prmT000W19 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T000W2", "SELECT [ZonasID], [ZonasNombre], [ZonasEstado], [ZonasHabilitarEcommerce], [DepartamentoId], [DepartamentoMunicipioId] FROM [Zonas] WITH (UPDLOCK) WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W3", "SELECT [ZonasID], [ZonasNombre], [ZonasEstado], [ZonasHabilitarEcommerce], [DepartamentoId], [DepartamentoMunicipioId] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W4", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W5", "SELECT TM1.[ZonasID], TM1.[ZonasNombre], TM1.[ZonasEstado], TM1.[ZonasHabilitarEcommerce], TM1.[DepartamentoId], TM1.[DepartamentoMunicipioId] FROM [Zonas] TM1 WHERE TM1.[ZonasID] = @ZonasID and TM1.[DepartamentoId] = @DepartamentoId and TM1.[DepartamentoMunicipioId] = @DepartamentoMunicipioId ORDER BY TM1.[ZonasID], TM1.[DepartamentoId], TM1.[DepartamentoMunicipioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W6", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W7", "SELECT [ZonasID], [DepartamentoId], [DepartamentoMunicipioId] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W8", "SELECT TOP 1 [ZonasID], [DepartamentoId], [DepartamentoMunicipioId] FROM [Zonas] WHERE ( [ZonasID] > @ZonasID or [ZonasID] = @ZonasID and [DepartamentoId] > @DepartamentoId or [DepartamentoId] = @DepartamentoId and [ZonasID] = @ZonasID and [DepartamentoMunicipioId] > @DepartamentoMunicipioId) ORDER BY [ZonasID], [DepartamentoId], [DepartamentoMunicipioId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W9", "SELECT TOP 1 [ZonasID], [DepartamentoId], [DepartamentoMunicipioId] FROM [Zonas] WHERE ( [ZonasID] < @ZonasID or [ZonasID] = @ZonasID and [DepartamentoId] < @DepartamentoId or [DepartamentoId] = @DepartamentoId and [ZonasID] = @ZonasID and [DepartamentoMunicipioId] < @DepartamentoMunicipioId) ORDER BY [ZonasID] DESC, [DepartamentoId] DESC, [DepartamentoMunicipioId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W10", "INSERT INTO [Zonas]([ZonasID], [ZonasNombre], [ZonasEstado], [ZonasHabilitarEcommerce], [DepartamentoId], [DepartamentoMunicipioId]) VALUES(@ZonasID, @ZonasNombre, @ZonasEstado, @ZonasHabilitarEcommerce, @DepartamentoId, @DepartamentoMunicipioId)", GxErrorMask.GX_NOMASK,prmT000W10)
           ,new CursorDef("T000W11", "UPDATE [Zonas] SET [ZonasNombre]=@ZonasNombre, [ZonasEstado]=@ZonasEstado, [ZonasHabilitarEcommerce]=@ZonasHabilitarEcommerce  WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId", GxErrorMask.GX_NOMASK,prmT000W11)
           ,new CursorDef("T000W12", "DELETE FROM [Zonas]  WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId", GxErrorMask.GX_NOMASK,prmT000W12)
           ,new CursorDef("T000W13", "SELECT TOP 1 [ProfesionalesId], [ProfesionalesZonasCorrelativo] FROM [ProfesionalesZonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W14", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000W15", "SELECT [ZonasID], [DepartamentoId], [DepartamentoMunicipioId] FROM [Zonas] ORDER BY [ZonasID], [DepartamentoId], [DepartamentoMunicipioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000W15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W16", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W16,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W17", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [DepartamentoMunicipioNombre] FROM [DepartamentoMunicipio] WHERE ([DepartamentoId] = @DepartamentoId) AND ([DepartamentoMunicipioId] < 9999) ORDER BY [DepartamentoMunicipioNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W17,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W18", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W18,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000W19", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000W19,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((long[]) buf[6])[0] = rslt.getLong(5);
              ((long[]) buf[7])[0] = rslt.getLong(6);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((long[]) buf[6])[0] = rslt.getLong(5);
              ((long[]) buf[7])[0] = rslt.getLong(6);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((long[]) buf[6])[0] = rslt.getLong(5);
              ((long[]) buf[7])[0] = rslt.getLong(6);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}

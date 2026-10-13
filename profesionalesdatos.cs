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
   public class profesionalesdatos : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"ESTADOSGENERICOSID") == 0 )
         {
            A107EstadosTipo = GetPar( "EstadosTipo");
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAESTADOSGENERICOSID1334( A107EstadosTipo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A107EstadosTipo = GetPar( "EstadosTipo");
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A107EstadosTipo, A108EstadosGenericosId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "profesionalesdatos.aspx")), "profesionalesdatos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "profesionalesdatos.aspx")))) ;
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
               AV7ProfesionalesId = gxfirstwebparm;
               AssignAttri("", false, "AV7ProfesionalesId", AV7ProfesionalesId);
               GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ProfesionalesId, "")), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Datos del Profesional", ""), 0) ;
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

      public profesionalesdatos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionalesdatos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           string aP1_Gx_mode )
      {
         this.AV7ProfesionalesId = aP0_ProfesionalesId;
         this.Gx_mode = aP1_Gx_mode;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynEstadosGenericosId = new GXCombobox();
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
         if ( dynEstadosGenericosId.ItemCount > 0 )
         {
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEstadosGenericosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
            AssignProp("", false, dynEstadosGenericosId_Internalname, "Values", dynEstadosGenericosId.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "|||", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesDatos.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, context.GetMessage( "Datos Personales", ""), "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ProfesionalesDatos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 FormCellAdvanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesId_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId), StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtProfesionalesId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProfesionalesId_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NoIdentidad", "start", true, "", "HLP_ProfesionalesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 TableCell", "end", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynEstadosGenericosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynEstadosGenericosId_Internalname, "||", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynEstadosGenericosId, dynEstadosGenericosId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0)), 1, dynEstadosGenericosId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynEstadosGenericosId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_ProfesionalesDatos.htm");
         dynEstadosGenericosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
         AssignProp("", false, dynEstadosGenericosId_Internalname, "Values", (string)(dynEstadosGenericosId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "top", "div");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesPrimerNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesPrimerNombre_Internalname, context.GetMessage( "Primer Nombre", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre), StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesPrimerNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProfesionalesPrimerNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesSegundoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesSegundoNombre_Internalname, context.GetMessage( "Segundo Nombre", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesSegundoNombre_Internalname, StringUtil.RTrim( A191ProfesionalesSegundoNombre), StringUtil.RTrim( context.localUtil.Format( A191ProfesionalesSegundoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesSegundoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProfesionalesSegundoNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesApellidoPrimero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesApellidoPrimero_Internalname, context.GetMessage( "Primer Apellido ", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero), StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesApellidoPrimero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProfesionalesApellidoPrimero_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesApellidoSegundo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesApellidoSegundo_Internalname, context.GetMessage( "Segundo Apellido ", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesApellidoSegundo_Internalname, StringUtil.RTrim( A192ProfesionalesApellidoSegundo), StringUtil.RTrim( context.localUtil.Format( A192ProfesionalesApellidoSegundo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesApellidoSegundo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProfesionalesApellidoSegundo_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ProfesionalesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "Center", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProfesionalesPhoto_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
         StyleString = "";
         A169ProfesionalesPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProfesionalesPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.PathToRelativeUrl( A169ProfesionalesPhoto));
         GxWebStd.gx_bitmap( context, imgProfesionalesPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProfesionalesPhoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", "", "", 0, A169ProfesionalesPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesDatos.htm");
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.PathToRelativeUrl( A169ProfesionalesPhoto)), true);
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A169ProfesionalesPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+Profesionalesfeedback_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucProfesionalesfeedback.SetProperty("Attribute", ProfesionalesFeedback);
         ucProfesionalesfeedback.SetProperty("CaptionClass", Profesionalesfeedback_Captionclass);
         ucProfesionalesfeedback.SetProperty("CaptionStyle", Profesionalesfeedback_Captionstyle);
         ucProfesionalesfeedback.SetProperty("CaptionPosition", Profesionalesfeedback_Captionposition);
         ucProfesionalesfeedback.Render(context, "rating", Profesionalesfeedback_Internalname, "PROFESIONALESFEEDBACKContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavProfesionalesfeedback_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtavProfesionalesfeedback_Internalname, context.GetMessage( "Reputación:", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavProfesionalesfeedback_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11ProfesionalesFeedback, 12, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavProfesionalesfeedback_Enabled!=0) ? context.localUtil.Format( AV11ProfesionalesFeedback, "ZZZZZZ9.99 %") : context.localUtil.Format( AV11ProfesionalesFeedback, "ZZZZZZ9.99 %"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProfesionalesfeedback_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProfesionalesfeedback_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesFeedBackCant_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesFeedBackCant_Internalname, context.GetMessage( "Calificadas:", ""), "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesFeedBackCant_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A268ProfesionalesFeedBackCant), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProfesionalesFeedBackCant_Enabled!=0) ? context.localUtil.Format( (decimal)(A268ProfesionalesFeedBackCant), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A268ProfesionalesFeedBackCant), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFeedBackCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProfesionalesFeedBackCant_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ProfesionalesDatos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs", "start", "top", "", "", "div");
         context.WriteHtmlText( "<hr/>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesTelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A170ProfesionalesTelefono);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesTelefono_Internalname, StringUtil.RTrim( A170ProfesionalesTelefono), StringUtil.RTrim( context.localUtil.Format( A170ProfesionalesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProfesionalesTelefono_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProfesionalesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_ProfesionalesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesEmail_Internalname, A193ProfesionalesEmail, StringUtil.RTrim( context.localUtil.Format( A193ProfesionalesEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A193ProfesionalesEmail, "", "", context.GetMessage( "email@correo.com", ""), edtProfesionalesEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProfesionalesEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_ProfesionalesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProfesionalesDireccion_Internalname, A198ProfesionalesDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A198ProfesionalesDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", 0, 1, edtProfesionalesDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_ProfesionalesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
         /* Static images/pictures */
         ClassString = "Image" + " " + ((StringUtil.StrCmp(imgImage1_gximage, "")==0) ? "GX_Image_ComboArrow_Class" : "GX_Image_"+imgImage1_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "5dcddcce-df89-424f-8cbe-19c24b6a0567", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage1_Visible, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_ProfesionalesDatos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProfesionalesDatos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z120ProfesionalesId = cgiGet( "Z120ProfesionalesId");
            Z199ProfesionalesFechaAlta = context.localUtil.CToT( cgiGet( "Z199ProfesionalesFechaAlta"), 0);
            Z200ProfesionalesFechaActualizado = context.localUtil.CToT( cgiGet( "Z200ProfesionalesFechaActualizado"), 0);
            Z166ProfesionalesPrimerNombre = cgiGet( "Z166ProfesionalesPrimerNombre");
            Z191ProfesionalesSegundoNombre = cgiGet( "Z191ProfesionalesSegundoNombre");
            Z167ProfesionalesApellidoPrimero = cgiGet( "Z167ProfesionalesApellidoPrimero");
            Z192ProfesionalesApellidoSegundo = cgiGet( "Z192ProfesionalesApellidoSegundo");
            Z170ProfesionalesTelefono = cgiGet( "Z170ProfesionalesTelefono");
            Z193ProfesionalesEmail = cgiGet( "Z193ProfesionalesEmail");
            n193ProfesionalesEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A193ProfesionalesEmail)) ? true : false);
            Z198ProfesionalesDireccion = cgiGet( "Z198ProfesionalesDireccion");
            Z196ProfesionalesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z196ProfesionalesAutoEnumerar"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z197ProfesionalesAutoEnuZona"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z267ProfesionalesVerDatPerSol = cgiGet( "Z267ProfesionalesVerDatPerSol");
            Z268ProfesionalesFeedBackCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z268ProfesionalesFeedBackCant"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z269ProfesionalesFeedBackProm = context.localUtil.CToN( cgiGet( "Z269ProfesionalesFeedBackProm"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            Z107EstadosTipo = cgiGet( "Z107EstadosTipo");
            Z108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z108EstadosGenericosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A199ProfesionalesFechaAlta = context.localUtil.CToT( cgiGet( "Z199ProfesionalesFechaAlta"), 0);
            A200ProfesionalesFechaActualizado = context.localUtil.CToT( cgiGet( "Z200ProfesionalesFechaActualizado"), 0);
            A196ProfesionalesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z196ProfesionalesAutoEnumerar"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z197ProfesionalesAutoEnuZona"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A267ProfesionalesVerDatPerSol = cgiGet( "Z267ProfesionalesVerDatPerSol");
            A269ProfesionalesFeedBackProm = context.localUtil.CToN( cgiGet( "Z269ProfesionalesFeedBackProm"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            A107EstadosTipo = cgiGet( "Z107EstadosTipo");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A269ProfesionalesFeedBackProm = context.localUtil.CToN( cgiGet( "PROFESIONALESFEEDBACKPROM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            A270ProfesionalesFeedback = context.localUtil.CToN( cgiGet( "PROFESIONALESFEEDBACK"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AV7ProfesionalesId = cgiGet( "vPROFESIONALESID");
            A107EstadosTipo = cgiGet( "ESTADOSTIPO");
            A199ProfesionalesFechaAlta = context.localUtil.CToT( cgiGet( "PROFESIONALESFECHAALTA"), 0);
            A200ProfesionalesFechaActualizado = context.localUtil.CToT( cgiGet( "PROFESIONALESFECHAACTUALIZADO"), 0);
            A40000ProfesionalesPhoto_GXI = cgiGet( "PROFESIONALESPHOTO_GXI");
            A196ProfesionalesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAUTOENUMERAR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAUTOENUZONA"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            A267ProfesionalesVerDatPerSol = cgiGet( "PROFESIONALESVERDATPERSOL");
            Profesionalesfeedback_Objectcall = cgiGet( "PROFESIONALESFEEDBACK_Objectcall");
            Profesionalesfeedback_Class = cgiGet( "PROFESIONALESFEEDBACK_Class");
            Profesionalesfeedback_Enabled = StringUtil.StrToBool( cgiGet( "PROFESIONALESFEEDBACK_Enabled"));
            Profesionalesfeedback_Maxvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESFEEDBACK_Maxvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Profesionalesfeedback_Step = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESFEEDBACK_Step"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Profesionalesfeedback_Ratingclass = cgiGet( "PROFESIONALESFEEDBACK_Ratingclass");
            Profesionalesfeedback_Captionvalue = cgiGet( "PROFESIONALESFEEDBACK_Captionvalue");
            Profesionalesfeedback_Captionclass = cgiGet( "PROFESIONALESFEEDBACK_Captionclass");
            Profesionalesfeedback_Captionstyle = cgiGet( "PROFESIONALESFEEDBACK_Captionstyle");
            Profesionalesfeedback_Captionposition = cgiGet( "PROFESIONALESFEEDBACK_Captionposition");
            Profesionalesfeedback_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "PROFESIONALESFEEDBACK_Isabstractlayoutcontrol"));
            Profesionalesfeedback_Coltitle = cgiGet( "PROFESIONALESFEEDBACK_Coltitle");
            Profesionalesfeedback_Coltitlefont = cgiGet( "PROFESIONALESFEEDBACK_Coltitlefont");
            Profesionalesfeedback_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESFEEDBACK_Coltitlecolor"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Profesionalesfeedback_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "PROFESIONALESFEEDBACK_Usercontroliscolumn"));
            Profesionalesfeedback_Visible = StringUtil.StrToBool( cgiGet( "PROFESIONALESFEEDBACK_Visible"));
            /* Read variables values. */
            A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
            dynEstadosGenericosId.CurrentValue = cgiGet( dynEstadosGenericosId_Internalname);
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynEstadosGenericosId_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            A166ProfesionalesPrimerNombre = cgiGet( edtProfesionalesPrimerNombre_Internalname);
            AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A191ProfesionalesSegundoNombre = cgiGet( edtProfesionalesSegundoNombre_Internalname);
            AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
            A167ProfesionalesApellidoPrimero = cgiGet( edtProfesionalesApellidoPrimero_Internalname);
            AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            A192ProfesionalesApellidoSegundo = cgiGet( edtProfesionalesApellidoSegundo_Internalname);
            AssignAttri("", false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
            A169ProfesionalesPhoto = cgiGet( imgProfesionalesPhoto_Internalname);
            AssignAttri("", false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
            AV11ProfesionalesFeedback = context.localUtil.CToN( cgiGet( edtavProfesionalesfeedback_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri("", false, "AV11ProfesionalesFeedback", StringUtil.LTrimStr( AV11ProfesionalesFeedback, 10, 2));
            A268ProfesionalesFeedBackCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
            A170ProfesionalesTelefono = cgiGet( edtProfesionalesTelefono_Internalname);
            AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
            A193ProfesionalesEmail = cgiGet( edtProfesionalesEmail_Internalname);
            n193ProfesionalesEmail = false;
            AssignAttri("", false, "A193ProfesionalesEmail", A193ProfesionalesEmail);
            n193ProfesionalesEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A193ProfesionalesEmail)) ? true : false);
            A198ProfesionalesDireccion = cgiGet( edtProfesionalesDireccion_Internalname);
            AssignAttri("", false, "A198ProfesionalesDireccion", A198ProfesionalesDireccion);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgProfesionalesPhoto_Internalname, ref  A169ProfesionalesPhoto, ref  A40000ProfesionalesPhoto_GXI);
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"ProfesionalesDatos");
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynEstadosGenericosId_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            forbiddenHiddens.Add("EstadosGenericosId", context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9"));
            A268ProfesionalesFeedBackCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
            forbiddenHiddens.Add("ProfesionalesFeedBackCant", context.localUtil.Format( (decimal)(A268ProfesionalesFeedBackCant), "ZZZZZZZZZZZZZZZZZ9"));
            forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
            forbiddenHiddens.Add("EstadosTipo", StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")));
            forbiddenHiddens.Add("ProfesionalesFechaAlta", context.localUtil.Format( A199ProfesionalesFechaAlta, "99/99/99 99:99"));
            forbiddenHiddens.Add("ProfesionalesFechaActualizado", context.localUtil.Format( A200ProfesionalesFechaActualizado, "99/99/99 99:99"));
            forbiddenHiddens.Add("ProfesionalesAutoEnumerar", context.localUtil.Format( (decimal)(A196ProfesionalesAutoEnumerar), "ZZZ9"));
            forbiddenHiddens.Add("ProfesionalesAutoEnuZona", context.localUtil.Format( (decimal)(A197ProfesionalesAutoEnuZona), "ZZZ9"));
            forbiddenHiddens.Add("ProfesionalesVerDatPerSol", StringUtil.RTrim( context.localUtil.Format( A267ProfesionalesVerDatPerSol, "")));
            forbiddenHiddens.Add("ProfesionalesFeedBackProm", context.localUtil.Format( A269ProfesionalesFeedBackProm, "ZZZZZZZZZZZZZZ9.99"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("profesionalesdatos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                        CONFIRM_130( ) ;
                        if ( AnyError == 0 )
                        {
                           GX_FocusControl = bttBtn_enter_Internalname;
                           AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROFESIONALESID");
                     AnyError = 1;
                     GX_FocusControl = edtProfesionalesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
               InitAll1334( ) ;
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
            DisableAttributes1334( ) ;
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

      protected void CONFIRM_130( )
      {
         BeforeValidate1334( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1334( ) ;
            }
            else
            {
               CheckExtendedTable1334( ) ;
               CloseExtendedTableCursors1334( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption130( )
      {
      }

      protected void ZM1334( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z199ProfesionalesFechaAlta = T00133_A199ProfesionalesFechaAlta[0];
               Z200ProfesionalesFechaActualizado = T00133_A200ProfesionalesFechaActualizado[0];
               Z166ProfesionalesPrimerNombre = T00133_A166ProfesionalesPrimerNombre[0];
               Z191ProfesionalesSegundoNombre = T00133_A191ProfesionalesSegundoNombre[0];
               Z167ProfesionalesApellidoPrimero = T00133_A167ProfesionalesApellidoPrimero[0];
               Z192ProfesionalesApellidoSegundo = T00133_A192ProfesionalesApellidoSegundo[0];
               Z170ProfesionalesTelefono = T00133_A170ProfesionalesTelefono[0];
               Z193ProfesionalesEmail = T00133_A193ProfesionalesEmail[0];
               Z198ProfesionalesDireccion = T00133_A198ProfesionalesDireccion[0];
               Z196ProfesionalesAutoEnumerar = T00133_A196ProfesionalesAutoEnumerar[0];
               Z197ProfesionalesAutoEnuZona = T00133_A197ProfesionalesAutoEnuZona[0];
               Z267ProfesionalesVerDatPerSol = T00133_A267ProfesionalesVerDatPerSol[0];
               Z268ProfesionalesFeedBackCant = T00133_A268ProfesionalesFeedBackCant[0];
               Z269ProfesionalesFeedBackProm = T00133_A269ProfesionalesFeedBackProm[0];
               Z107EstadosTipo = T00133_A107EstadosTipo[0];
               Z108EstadosGenericosId = T00133_A108EstadosGenericosId[0];
            }
            else
            {
               Z199ProfesionalesFechaAlta = A199ProfesionalesFechaAlta;
               Z200ProfesionalesFechaActualizado = A200ProfesionalesFechaActualizado;
               Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
               Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
               Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
               Z192ProfesionalesApellidoSegundo = A192ProfesionalesApellidoSegundo;
               Z170ProfesionalesTelefono = A170ProfesionalesTelefono;
               Z193ProfesionalesEmail = A193ProfesionalesEmail;
               Z198ProfesionalesDireccion = A198ProfesionalesDireccion;
               Z196ProfesionalesAutoEnumerar = A196ProfesionalesAutoEnumerar;
               Z197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
               Z267ProfesionalesVerDatPerSol = A267ProfesionalesVerDatPerSol;
               Z268ProfesionalesFeedBackCant = A268ProfesionalesFeedBackCant;
               Z269ProfesionalesFeedBackProm = A269ProfesionalesFeedBackProm;
               Z107EstadosTipo = A107EstadosTipo;
               Z108EstadosGenericosId = A108EstadosGenericosId;
            }
         }
         if ( GX_JID == -16 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
            Z199ProfesionalesFechaAlta = A199ProfesionalesFechaAlta;
            Z200ProfesionalesFechaActualizado = A200ProfesionalesFechaActualizado;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z192ProfesionalesApellidoSegundo = A192ProfesionalesApellidoSegundo;
            Z169ProfesionalesPhoto = A169ProfesionalesPhoto;
            Z40000ProfesionalesPhoto_GXI = A40000ProfesionalesPhoto_GXI;
            Z170ProfesionalesTelefono = A170ProfesionalesTelefono;
            Z193ProfesionalesEmail = A193ProfesionalesEmail;
            Z198ProfesionalesDireccion = A198ProfesionalesDireccion;
            Z196ProfesionalesAutoEnumerar = A196ProfesionalesAutoEnumerar;
            Z197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            Z267ProfesionalesVerDatPerSol = A267ProfesionalesVerDatPerSol;
            Z268ProfesionalesFeedBackCant = A268ProfesionalesFeedBackCant;
            Z269ProfesionalesFeedBackProm = A269ProfesionalesFeedBackProm;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
         }
      }

      protected void standaloneNotModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( context.GetMessage( "INS", ""), "")) != 0 )
         {
            edtProfesionalesId_Enabled = 0;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         }
         else
         {
            edtProfesionalesId_Enabled = 1;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         }
         dynEstadosGenericosId.Enabled = 0;
         AssignProp("", false, dynEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosGenericosId.Enabled), 5, 0), true);
         edtProfesionalesFeedBackCant_Enabled = 0;
         AssignProp("", false, edtProfesionalesFeedBackCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFeedBackCant_Enabled), 5, 0), true);
         Profesionalesfeedback_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Profesionalesfeedback_Internalname, "Enabled", StringUtil.BoolToStr( Profesionalesfeedback_Enabled), true);
         edtavProfesionalesfeedback_Enabled = 0;
         AssignProp("", false, edtavProfesionalesfeedback_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProfesionalesfeedback_Enabled), 5, 0), true);
         dynEstadosGenericosId.Enabled = 0;
         AssignProp("", false, dynEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosGenericosId.Enabled), 5, 0), true);
         edtProfesionalesFeedBackCant_Enabled = 0;
         AssignProp("", false, edtProfesionalesFeedBackCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFeedBackCant_Enabled), 5, 0), true);
         edtavProfesionalesfeedback_Enabled = 0;
         AssignProp("", false, edtavProfesionalesfeedback_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProfesionalesfeedback_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( context.GetMessage( "INS", ""), "")) != 0 )
         {
            A120ProfesionalesId = AV7ProfesionalesId;
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
         }
      }

      protected void standaloneModal( )
      {
         A107EstadosTipo = context.GetMessage( context.GetMessage( "STS", ""), "");
         AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         if ( IsIns( )  )
         {
            A108EstadosGenericosId = 2;
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         }
         if ( IsIns( )  )
         {
            A199ProfesionalesFechaAlta = DateTimeUtil.Now( context);
            AssignAttri("", false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( IsIns( )  || IsUpd( )  )
         {
            A200ProfesionalesFechaActualizado = DateTimeUtil.Now( context);
            AssignAttri("", false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( StringUtil.StrCmp(Gx_mode, context.GetMessage( "INS", "")) != 0 )
         {
            edtProfesionalesId_Enabled = 0;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            GXAESTADOSGENERICOSID_html1334( A107EstadosTipo) ;
         }
      }

      protected void Load1334( )
      {
         /* Using cursor T00135 */
         pr_default.execute(3, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound34 = 1;
            A199ProfesionalesFechaAlta = T00135_A199ProfesionalesFechaAlta[0];
            A200ProfesionalesFechaActualizado = T00135_A200ProfesionalesFechaActualizado[0];
            A166ProfesionalesPrimerNombre = T00135_A166ProfesionalesPrimerNombre[0];
            AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A191ProfesionalesSegundoNombre = T00135_A191ProfesionalesSegundoNombre[0];
            AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
            A167ProfesionalesApellidoPrimero = T00135_A167ProfesionalesApellidoPrimero[0];
            AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            A192ProfesionalesApellidoSegundo = T00135_A192ProfesionalesApellidoSegundo[0];
            AssignAttri("", false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
            A40000ProfesionalesPhoto_GXI = T00135_A40000ProfesionalesPhoto_GXI[0];
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A170ProfesionalesTelefono = T00135_A170ProfesionalesTelefono[0];
            AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
            A193ProfesionalesEmail = T00135_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = T00135_n193ProfesionalesEmail[0];
            AssignAttri("", false, "A193ProfesionalesEmail", A193ProfesionalesEmail);
            A198ProfesionalesDireccion = T00135_A198ProfesionalesDireccion[0];
            AssignAttri("", false, "A198ProfesionalesDireccion", A198ProfesionalesDireccion);
            A196ProfesionalesAutoEnumerar = T00135_A196ProfesionalesAutoEnumerar[0];
            A197ProfesionalesAutoEnuZona = T00135_A197ProfesionalesAutoEnuZona[0];
            A267ProfesionalesVerDatPerSol = T00135_A267ProfesionalesVerDatPerSol[0];
            A268ProfesionalesFeedBackCant = T00135_A268ProfesionalesFeedBackCant[0];
            AssignAttri("", false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
            A269ProfesionalesFeedBackProm = T00135_A269ProfesionalesFeedBackProm[0];
            A107EstadosTipo = T00135_A107EstadosTipo[0];
            A108EstadosGenericosId = T00135_A108EstadosGenericosId[0];
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            A169ProfesionalesPhoto = T00135_A169ProfesionalesPhoto[0];
            AssignAttri("", false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            ZM1334( -16) ;
         }
         pr_default.close(3);
         OnLoadActions1334( ) ;
      }

      protected void OnLoadActions1334( )
      {
         if ( A268ProfesionalesFeedBackCant > 0 )
         {
            A270ProfesionalesFeedback = (decimal)(A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant));
            AssignAttri("", false, "A270ProfesionalesFeedback", StringUtil.LTrimStr( A270ProfesionalesFeedback, 10, 2));
         }
         else
         {
            A270ProfesionalesFeedback = 0;
            AssignAttri("", false, "A270ProfesionalesFeedback", StringUtil.LTrimStr( A270ProfesionalesFeedback, 10, 2));
         }
         AV11ProfesionalesFeedback = A270ProfesionalesFeedback;
         AssignAttri("", false, "AV11ProfesionalesFeedback", StringUtil.LTrimStr( AV11ProfesionalesFeedback, 10, 2));
         GXAESTADOSGENERICOSID_html1334( A107EstadosTipo) ;
      }

      protected void CheckExtendedTable1334( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A193ProfesionalesEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A193ProfesionalesEmail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PROFESIONALESEMAIL");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( A268ProfesionalesFeedBackCant > 0 )
         {
            A270ProfesionalesFeedback = (decimal)(A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant));
            AssignAttri("", false, "A270ProfesionalesFeedback", StringUtil.LTrimStr( A270ProfesionalesFeedback, 10, 2));
         }
         else
         {
            A270ProfesionalesFeedback = 0;
            AssignAttri("", false, "A270ProfesionalesFeedback", StringUtil.LTrimStr( A270ProfesionalesFeedback, 10, 2));
         }
         AV11ProfesionalesFeedback = A270ProfesionalesFeedback;
         AssignAttri("", false, "AV11ProfesionalesFeedback", StringUtil.LTrimStr( AV11ProfesionalesFeedback, 10, 2));
         /* Using cursor T00134 */
         pr_default.execute(2, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
            AnyError = 1;
         }
         pr_default.close(2);
         GXAESTADOSGENERICOSID_html1334( A107EstadosTipo) ;
      }

      protected void CloseExtendedTableCursors1334( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( string A107EstadosTipo ,
                                int A108EstadosGenericosId )
      {
         /* Using cursor T00136 */
         pr_default.execute(4, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
            AnyError = 1;
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

      protected void GetKey1334( )
      {
         /* Using cursor T00137 */
         pr_default.execute(5, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00133 */
         pr_default.execute(1, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1334( 16) ;
            RcdFound34 = 1;
            A120ProfesionalesId = T00133_A120ProfesionalesId[0];
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
            A199ProfesionalesFechaAlta = T00133_A199ProfesionalesFechaAlta[0];
            A200ProfesionalesFechaActualizado = T00133_A200ProfesionalesFechaActualizado[0];
            A166ProfesionalesPrimerNombre = T00133_A166ProfesionalesPrimerNombre[0];
            AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A191ProfesionalesSegundoNombre = T00133_A191ProfesionalesSegundoNombre[0];
            AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
            A167ProfesionalesApellidoPrimero = T00133_A167ProfesionalesApellidoPrimero[0];
            AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            A192ProfesionalesApellidoSegundo = T00133_A192ProfesionalesApellidoSegundo[0];
            AssignAttri("", false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
            A40000ProfesionalesPhoto_GXI = T00133_A40000ProfesionalesPhoto_GXI[0];
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A170ProfesionalesTelefono = T00133_A170ProfesionalesTelefono[0];
            AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
            A193ProfesionalesEmail = T00133_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = T00133_n193ProfesionalesEmail[0];
            AssignAttri("", false, "A193ProfesionalesEmail", A193ProfesionalesEmail);
            A198ProfesionalesDireccion = T00133_A198ProfesionalesDireccion[0];
            AssignAttri("", false, "A198ProfesionalesDireccion", A198ProfesionalesDireccion);
            A196ProfesionalesAutoEnumerar = T00133_A196ProfesionalesAutoEnumerar[0];
            A197ProfesionalesAutoEnuZona = T00133_A197ProfesionalesAutoEnuZona[0];
            A267ProfesionalesVerDatPerSol = T00133_A267ProfesionalesVerDatPerSol[0];
            A268ProfesionalesFeedBackCant = T00133_A268ProfesionalesFeedBackCant[0];
            AssignAttri("", false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
            A269ProfesionalesFeedBackProm = T00133_A269ProfesionalesFeedBackProm[0];
            A107EstadosTipo = T00133_A107EstadosTipo[0];
            A108EstadosGenericosId = T00133_A108EstadosGenericosId[0];
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            A169ProfesionalesPhoto = T00133_A169ProfesionalesPhoto[0];
            AssignAttri("", false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            Z120ProfesionalesId = A120ProfesionalesId;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1334( ) ;
            if ( AnyError == 1 )
            {
               RcdFound34 = 0;
               InitializeNonKey1334( ) ;
            }
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey1334( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1334( ) ;
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
         /* Using cursor T00138 */
         pr_default.execute(6, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00138_A120ProfesionalesId[0], A120ProfesionalesId) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00138_A120ProfesionalesId[0], A120ProfesionalesId) > 0 ) ) )
            {
               A120ProfesionalesId = T00138_A120ProfesionalesId[0];
               AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
               RcdFound34 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound34 = 0;
         /* Using cursor T00139 */
         pr_default.execute(7, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00139_A120ProfesionalesId[0], A120ProfesionalesId) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00139_A120ProfesionalesId[0], A120ProfesionalesId) < 0 ) ) )
            {
               A120ProfesionalesId = T00139_A120ProfesionalesId[0];
               AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
               RcdFound34 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1334( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1334( ) ;
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
                  A120ProfesionalesId = Z120ProfesionalesId;
                  AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROFESIONALESID");
                  AnyError = 1;
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1334( ) ;
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1334( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROFESIONALESID");
                     AnyError = 1;
                     GX_FocusControl = edtProfesionalesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProfesionalesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1334( ) ;
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
         if ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 )
         {
            A120ProfesionalesId = Z120ProfesionalesId;
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROFESIONALESID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1334( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00132 */
            pr_default.execute(0, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Profesionales"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z199ProfesionalesFechaAlta != T00132_A199ProfesionalesFechaAlta[0] ) || ( Z200ProfesionalesFechaActualizado != T00132_A200ProfesionalesFechaActualizado[0] ) || ( StringUtil.StrCmp(Z166ProfesionalesPrimerNombre, T00132_A166ProfesionalesPrimerNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z191ProfesionalesSegundoNombre, T00132_A191ProfesionalesSegundoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z167ProfesionalesApellidoPrimero, T00132_A167ProfesionalesApellidoPrimero[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z192ProfesionalesApellidoSegundo, T00132_A192ProfesionalesApellidoSegundo[0]) != 0 ) || ( StringUtil.StrCmp(Z170ProfesionalesTelefono, T00132_A170ProfesionalesTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z193ProfesionalesEmail, T00132_A193ProfesionalesEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z198ProfesionalesDireccion, T00132_A198ProfesionalesDireccion[0]) != 0 ) || ( Z196ProfesionalesAutoEnumerar != T00132_A196ProfesionalesAutoEnumerar[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z197ProfesionalesAutoEnuZona != T00132_A197ProfesionalesAutoEnuZona[0] ) || ( StringUtil.StrCmp(Z267ProfesionalesVerDatPerSol, T00132_A267ProfesionalesVerDatPerSol[0]) != 0 ) || ( Z268ProfesionalesFeedBackCant != T00132_A268ProfesionalesFeedBackCant[0] ) || ( Z269ProfesionalesFeedBackProm != T00132_A269ProfesionalesFeedBackProm[0] ) || ( StringUtil.StrCmp(Z107EstadosTipo, T00132_A107EstadosTipo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z108EstadosGenericosId != T00132_A108EstadosGenericosId[0] ) )
            {
               if ( Z199ProfesionalesFechaAlta != T00132_A199ProfesionalesFechaAlta[0] )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z199ProfesionalesFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T00132_A199ProfesionalesFechaAlta[0]);
               }
               if ( Z200ProfesionalesFechaActualizado != T00132_A200ProfesionalesFechaActualizado[0] )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesFechaActualizado");
                  GXUtil.WriteLogRaw("Old: ",Z200ProfesionalesFechaActualizado);
                  GXUtil.WriteLogRaw("Current: ",T00132_A200ProfesionalesFechaActualizado[0]);
               }
               if ( StringUtil.StrCmp(Z166ProfesionalesPrimerNombre, T00132_A166ProfesionalesPrimerNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesPrimerNombre");
                  GXUtil.WriteLogRaw("Old: ",Z166ProfesionalesPrimerNombre);
                  GXUtil.WriteLogRaw("Current: ",T00132_A166ProfesionalesPrimerNombre[0]);
               }
               if ( StringUtil.StrCmp(Z191ProfesionalesSegundoNombre, T00132_A191ProfesionalesSegundoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesSegundoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z191ProfesionalesSegundoNombre);
                  GXUtil.WriteLogRaw("Current: ",T00132_A191ProfesionalesSegundoNombre[0]);
               }
               if ( StringUtil.StrCmp(Z167ProfesionalesApellidoPrimero, T00132_A167ProfesionalesApellidoPrimero[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesApellidoPrimero");
                  GXUtil.WriteLogRaw("Old: ",Z167ProfesionalesApellidoPrimero);
                  GXUtil.WriteLogRaw("Current: ",T00132_A167ProfesionalesApellidoPrimero[0]);
               }
               if ( StringUtil.StrCmp(Z192ProfesionalesApellidoSegundo, T00132_A192ProfesionalesApellidoSegundo[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesApellidoSegundo");
                  GXUtil.WriteLogRaw("Old: ",Z192ProfesionalesApellidoSegundo);
                  GXUtil.WriteLogRaw("Current: ",T00132_A192ProfesionalesApellidoSegundo[0]);
               }
               if ( StringUtil.StrCmp(Z170ProfesionalesTelefono, T00132_A170ProfesionalesTelefono[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z170ProfesionalesTelefono);
                  GXUtil.WriteLogRaw("Current: ",T00132_A170ProfesionalesTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z193ProfesionalesEmail, T00132_A193ProfesionalesEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesEmail");
                  GXUtil.WriteLogRaw("Old: ",Z193ProfesionalesEmail);
                  GXUtil.WriteLogRaw("Current: ",T00132_A193ProfesionalesEmail[0]);
               }
               if ( StringUtil.StrCmp(Z198ProfesionalesDireccion, T00132_A198ProfesionalesDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z198ProfesionalesDireccion);
                  GXUtil.WriteLogRaw("Current: ",T00132_A198ProfesionalesDireccion[0]);
               }
               if ( Z196ProfesionalesAutoEnumerar != T00132_A196ProfesionalesAutoEnumerar[0] )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesAutoEnumerar");
                  GXUtil.WriteLogRaw("Old: ",Z196ProfesionalesAutoEnumerar);
                  GXUtil.WriteLogRaw("Current: ",T00132_A196ProfesionalesAutoEnumerar[0]);
               }
               if ( Z197ProfesionalesAutoEnuZona != T00132_A197ProfesionalesAutoEnuZona[0] )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesAutoEnuZona");
                  GXUtil.WriteLogRaw("Old: ",Z197ProfesionalesAutoEnuZona);
                  GXUtil.WriteLogRaw("Current: ",T00132_A197ProfesionalesAutoEnuZona[0]);
               }
               if ( StringUtil.StrCmp(Z267ProfesionalesVerDatPerSol, T00132_A267ProfesionalesVerDatPerSol[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesVerDatPerSol");
                  GXUtil.WriteLogRaw("Old: ",Z267ProfesionalesVerDatPerSol);
                  GXUtil.WriteLogRaw("Current: ",T00132_A267ProfesionalesVerDatPerSol[0]);
               }
               if ( Z268ProfesionalesFeedBackCant != T00132_A268ProfesionalesFeedBackCant[0] )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesFeedBackCant");
                  GXUtil.WriteLogRaw("Old: ",Z268ProfesionalesFeedBackCant);
                  GXUtil.WriteLogRaw("Current: ",T00132_A268ProfesionalesFeedBackCant[0]);
               }
               if ( Z269ProfesionalesFeedBackProm != T00132_A269ProfesionalesFeedBackProm[0] )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"ProfesionalesFeedBackProm");
                  GXUtil.WriteLogRaw("Old: ",Z269ProfesionalesFeedBackProm);
                  GXUtil.WriteLogRaw("Current: ",T00132_A269ProfesionalesFeedBackProm[0]);
               }
               if ( StringUtil.StrCmp(Z107EstadosTipo, T00132_A107EstadosTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"EstadosTipo");
                  GXUtil.WriteLogRaw("Old: ",Z107EstadosTipo);
                  GXUtil.WriteLogRaw("Current: ",T00132_A107EstadosTipo[0]);
               }
               if ( Z108EstadosGenericosId != T00132_A108EstadosGenericosId[0] )
               {
                  GXUtil.WriteLog("profesionalesdatos:[seudo value changed for attri]"+"EstadosGenericosId");
                  GXUtil.WriteLogRaw("Old: ",Z108EstadosGenericosId);
                  GXUtil.WriteLogRaw("Current: ",T00132_A108EstadosGenericosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Profesionales"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1334( )
      {
         BeforeValidate1334( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1334( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1334( 0) ;
            CheckOptimisticConcurrency1334( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1334( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1334( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001310 */
                     pr_default.execute(8, new Object[] {A120ProfesionalesId, A199ProfesionalesFechaAlta, A200ProfesionalesFechaActualizado, A166ProfesionalesPrimerNombre, A191ProfesionalesSegundoNombre, A167ProfesionalesApellidoPrimero, A192ProfesionalesApellidoSegundo, A169ProfesionalesPhoto, A40000ProfesionalesPhoto_GXI, A170ProfesionalesTelefono, n193ProfesionalesEmail, A193ProfesionalesEmail, A198ProfesionalesDireccion, A196ProfesionalesAutoEnumerar, A197ProfesionalesAutoEnuZona, A267ProfesionalesVerDatPerSol, A268ProfesionalesFeedBackCant, A269ProfesionalesFeedBackProm, A107EstadosTipo, A108EstadosGenericosId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Profesionales");
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
                           ResetCaption130( ) ;
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
               Load1334( ) ;
            }
            EndLevel1334( ) ;
         }
         CloseExtendedTableCursors1334( ) ;
      }

      protected void Update1334( )
      {
         BeforeValidate1334( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1334( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1334( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1334( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1334( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001311 */
                     pr_default.execute(9, new Object[] {A199ProfesionalesFechaAlta, A200ProfesionalesFechaActualizado, A166ProfesionalesPrimerNombre, A191ProfesionalesSegundoNombre, A167ProfesionalesApellidoPrimero, A192ProfesionalesApellidoSegundo, A170ProfesionalesTelefono, n193ProfesionalesEmail, A193ProfesionalesEmail, A198ProfesionalesDireccion, A196ProfesionalesAutoEnumerar, A197ProfesionalesAutoEnuZona, A267ProfesionalesVerDatPerSol, A268ProfesionalesFeedBackCant, A269ProfesionalesFeedBackProm, A107EstadosTipo, A108EstadosGenericosId, A120ProfesionalesId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Profesionales");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Profesionales"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1334( ) ;
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
            EndLevel1334( ) ;
         }
         CloseExtendedTableCursors1334( ) ;
      }

      protected void DeferredUpdate1334( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001312 */
            pr_default.execute(10, new Object[] {A169ProfesionalesPhoto, A40000ProfesionalesPhoto_GXI, A120ProfesionalesId});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Profesionales");
         }
      }

      protected void delete( )
      {
         BeforeValidate1334( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1334( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1334( ) ;
            AfterConfirm1334( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1334( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001313 */
                  pr_default.execute(11, new Object[] {A120ProfesionalesId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Profesionales");
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
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1334( ) ;
         Gx_mode = sMode34;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1334( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( A268ProfesionalesFeedBackCant > 0 )
            {
               A270ProfesionalesFeedback = (decimal)(A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant));
               AssignAttri("", false, "A270ProfesionalesFeedback", StringUtil.LTrimStr( A270ProfesionalesFeedback, 10, 2));
            }
            else
            {
               A270ProfesionalesFeedback = 0;
               AssignAttri("", false, "A270ProfesionalesFeedback", StringUtil.LTrimStr( A270ProfesionalesFeedback, 10, 2));
            }
            AV11ProfesionalesFeedback = A270ProfesionalesFeedback;
            AssignAttri("", false, "AV11ProfesionalesFeedback", StringUtil.LTrimStr( AV11ProfesionalesFeedback, 10, 2));
            GXAESTADOSGENERICOSID_html1334( A107EstadosTipo) ;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001314 */
            pr_default.execute(12, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Detalles", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T001315 */
            pr_default.execute(13, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "ProfesionalesRestriccion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T001316 */
            pr_default.execute(14, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Prof Comisiones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T001317 */
            pr_default.execute(15, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T001318 */
            pr_default.execute(16, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "ProfesionalesServicios", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T001319 */
            pr_default.execute(17, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T001320 */
            pr_default.execute(18, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupacion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T001321 */
            pr_default.execute(19, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T001322 */
            pr_default.execute(20, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Seleccione la zona de trabajo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T001323 */
            pr_default.execute(21, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void EndLevel1334( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1334( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("profesionalesdatos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues130( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("profesionalesdatos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1334( )
      {
         /* Scan By routine */
         /* Using cursor T001324 */
         pr_default.execute(22);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound34 = 1;
            A120ProfesionalesId = T001324_A120ProfesionalesId[0];
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1334( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound34 = 1;
            A120ProfesionalesId = T001324_A120ProfesionalesId[0];
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
         }
      }

      protected void ScanEnd1334( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm1334( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1334( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1334( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1334( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1334( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1334( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1334( )
      {
         edtProfesionalesId_Enabled = 0;
         AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         dynEstadosGenericosId.Enabled = 0;
         AssignProp("", false, dynEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosGenericosId.Enabled), 5, 0), true);
         edtProfesionalesPrimerNombre_Enabled = 0;
         AssignProp("", false, edtProfesionalesPrimerNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPrimerNombre_Enabled), 5, 0), true);
         edtProfesionalesSegundoNombre_Enabled = 0;
         AssignProp("", false, edtProfesionalesSegundoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesSegundoNombre_Enabled), 5, 0), true);
         edtProfesionalesApellidoPrimero_Enabled = 0;
         AssignProp("", false, edtProfesionalesApellidoPrimero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoPrimero_Enabled), 5, 0), true);
         edtProfesionalesApellidoSegundo_Enabled = 0;
         AssignProp("", false, edtProfesionalesApellidoSegundo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesApellidoSegundo_Enabled), 5, 0), true);
         imgProfesionalesPhoto_Enabled = 0;
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProfesionalesPhoto_Enabled), 5, 0), true);
         edtavProfesionalesfeedback_Enabled = 0;
         AssignProp("", false, edtavProfesionalesfeedback_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProfesionalesfeedback_Enabled), 5, 0), true);
         edtProfesionalesFeedBackCant_Enabled = 0;
         AssignProp("", false, edtProfesionalesFeedBackCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFeedBackCant_Enabled), 5, 0), true);
         edtProfesionalesTelefono_Enabled = 0;
         AssignProp("", false, edtProfesionalesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesTelefono_Enabled), 5, 0), true);
         edtProfesionalesEmail_Enabled = 0;
         AssignProp("", false, edtProfesionalesEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesEmail_Enabled), 5, 0), true);
         edtProfesionalesDireccion_Enabled = 0;
         AssignProp("", false, edtProfesionalesDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesDireccion_Enabled), 5, 0), true);
         Profesionalesfeedback_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Profesionalesfeedback_Internalname, "Enabled", StringUtil.BoolToStr( Profesionalesfeedback_Enabled), true);
      }

      protected void send_integrity_lvl_hashes1334( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues130( )
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
         context.AddJavascriptSource("Rating/rating.min.js", "", false, true, false);
         context.AddJavascriptSource("Rating/RatingRender.js", "", false, true, false);
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
         GXEncryptionTmp = "profesionalesdatos.aspx"+UrlEncode(StringUtil.RTrim(AV7ProfesionalesId)) + "," + UrlEncode(StringUtil.RTrim(Gx_mode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profesionalesdatos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ProfesionalesDatos");
         forbiddenHiddens.Add("EstadosGenericosId", context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9"));
         forbiddenHiddens.Add("ProfesionalesFeedBackCant", context.localUtil.Format( (decimal)(A268ProfesionalesFeedBackCant), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("EstadosTipo", StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")));
         forbiddenHiddens.Add("ProfesionalesFechaAlta", context.localUtil.Format( A199ProfesionalesFechaAlta, "99/99/99 99:99"));
         forbiddenHiddens.Add("ProfesionalesFechaActualizado", context.localUtil.Format( A200ProfesionalesFechaActualizado, "99/99/99 99:99"));
         forbiddenHiddens.Add("ProfesionalesAutoEnumerar", context.localUtil.Format( (decimal)(A196ProfesionalesAutoEnumerar), "ZZZ9"));
         forbiddenHiddens.Add("ProfesionalesAutoEnuZona", context.localUtil.Format( (decimal)(A197ProfesionalesAutoEnuZona), "ZZZ9"));
         forbiddenHiddens.Add("ProfesionalesVerDatPerSol", StringUtil.RTrim( context.localUtil.Format( A267ProfesionalesVerDatPerSol, "")));
         forbiddenHiddens.Add("ProfesionalesFeedBackProm", context.localUtil.Format( A269ProfesionalesFeedBackProm, "ZZZZZZZZZZZZZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("profesionalesdatos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z120ProfesionalesId", StringUtil.RTrim( Z120ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "Z199ProfesionalesFechaAlta", context.localUtil.TToC( Z199ProfesionalesFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z200ProfesionalesFechaActualizado", context.localUtil.TToC( Z200ProfesionalesFechaActualizado, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z166ProfesionalesPrimerNombre", StringUtil.RTrim( Z166ProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, "Z191ProfesionalesSegundoNombre", StringUtil.RTrim( Z191ProfesionalesSegundoNombre));
         GxWebStd.gx_hidden_field( context, "Z167ProfesionalesApellidoPrimero", StringUtil.RTrim( Z167ProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, "Z192ProfesionalesApellidoSegundo", StringUtil.RTrim( Z192ProfesionalesApellidoSegundo));
         GxWebStd.gx_hidden_field( context, "Z170ProfesionalesTelefono", StringUtil.RTrim( Z170ProfesionalesTelefono));
         GxWebStd.gx_hidden_field( context, "Z193ProfesionalesEmail", Z193ProfesionalesEmail);
         GxWebStd.gx_hidden_field( context, "Z198ProfesionalesDireccion", Z198ProfesionalesDireccion);
         GxWebStd.gx_hidden_field( context, "Z196ProfesionalesAutoEnumerar", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z196ProfesionalesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z197ProfesionalesAutoEnuZona", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z197ProfesionalesAutoEnuZona), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z267ProfesionalesVerDatPerSol", StringUtil.RTrim( Z267ProfesionalesVerDatPerSol));
         GxWebStd.gx_hidden_field( context, "Z268ProfesionalesFeedBackCant", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z268ProfesionalesFeedBackCant), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z269ProfesionalesFeedBackProm", StringUtil.LTrim( StringUtil.NToC( Z269ProfesionalesFeedBackProm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z107EstadosTipo", StringUtil.RTrim( Z107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "Z108EstadosGenericosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACKPROM", StringUtil.LTrim( StringUtil.NToC( A269ProfesionalesFeedBackProm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACK", StringUtil.LTrim( StringUtil.NToC( A270ProfesionalesFeedback, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV7ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, "ESTADOSTIPO", StringUtil.RTrim( A107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFECHAALTA", context.localUtil.TToC( A199ProfesionalesFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFECHAACTUALIZADO", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESPHOTO_GXI", A40000ProfesionalesPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAUTOENUMERAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(A196ProfesionalesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAUTOENUZONA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESVERDATPERSOL", StringUtil.RTrim( A267ProfesionalesVerDatPerSol));
         GXCCtlgxBlob = "PROFESIONALESPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A169ProfesionalesPhoto);
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACK_Objectcall", StringUtil.RTrim( Profesionalesfeedback_Objectcall));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACK_Enabled", StringUtil.BoolToStr( Profesionalesfeedback_Enabled));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACK_Captionclass", StringUtil.RTrim( Profesionalesfeedback_Captionclass));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACK_Captionstyle", StringUtil.RTrim( Profesionalesfeedback_Captionstyle));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACK_Captionposition", StringUtil.RTrim( Profesionalesfeedback_Captionposition));
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
         GXEncryptionTmp = "profesionalesdatos.aspx"+UrlEncode(StringUtil.RTrim(AV7ProfesionalesId)) + "," + UrlEncode(StringUtil.RTrim(Gx_mode));
         return formatLink("profesionalesdatos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ProfesionalesDatos" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Datos del Profesional", "") ;
      }

      protected void InitializeNonKey1334( )
      {
         A107EstadosTipo = "";
         AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         A108EstadosGenericosId = 0;
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         A199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV11ProfesionalesFeedback = 0;
         AssignAttri("", false, "AV11ProfesionalesFeedback", StringUtil.LTrimStr( AV11ProfesionalesFeedback, 10, 2));
         A270ProfesionalesFeedback = 0;
         AssignAttri("", false, "A270ProfesionalesFeedback", StringUtil.LTrimStr( A270ProfesionalesFeedback, 10, 2));
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
         A193ProfesionalesEmail = "";
         n193ProfesionalesEmail = false;
         AssignAttri("", false, "A193ProfesionalesEmail", A193ProfesionalesEmail);
         n193ProfesionalesEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A193ProfesionalesEmail)) ? true : false);
         A198ProfesionalesDireccion = "";
         AssignAttri("", false, "A198ProfesionalesDireccion", A198ProfesionalesDireccion);
         A196ProfesionalesAutoEnumerar = 0;
         AssignAttri("", false, "A196ProfesionalesAutoEnumerar", StringUtil.LTrimStr( (decimal)(A196ProfesionalesAutoEnumerar), 4, 0));
         A197ProfesionalesAutoEnuZona = 0;
         AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         A267ProfesionalesVerDatPerSol = "";
         AssignAttri("", false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
         A268ProfesionalesFeedBackCant = 0;
         AssignAttri("", false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
         A269ProfesionalesFeedBackProm = 0;
         AssignAttri("", false, "A269ProfesionalesFeedBackProm", StringUtil.LTrimStr( A269ProfesionalesFeedBackProm, 18, 2));
         Z199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         Z200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         Z166ProfesionalesPrimerNombre = "";
         Z191ProfesionalesSegundoNombre = "";
         Z167ProfesionalesApellidoPrimero = "";
         Z192ProfesionalesApellidoSegundo = "";
         Z170ProfesionalesTelefono = "";
         Z193ProfesionalesEmail = "";
         Z198ProfesionalesDireccion = "";
         Z196ProfesionalesAutoEnumerar = 0;
         Z197ProfesionalesAutoEnuZona = 0;
         Z267ProfesionalesVerDatPerSol = "";
         Z268ProfesionalesFeedBackCant = 0;
         Z269ProfesionalesFeedBackProm = 0;
         Z107EstadosTipo = "";
         Z108EstadosGenericosId = 0;
      }

      protected void InitAll1334( )
      {
         A120ProfesionalesId = "";
         AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
         InitializeNonKey1334( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A107EstadosTipo = i107EstadosTipo;
         AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         A108EstadosGenericosId = i108EstadosGenericosId;
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         A199ProfesionalesFechaAlta = i199ProfesionalesFechaAlta;
         AssignAttri("", false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A200ProfesionalesFechaActualizado = i200ProfesionalesFechaActualizado;
         AssignAttri("", false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("Rating/rating.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932032229", true, true, false);
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
         context.AddJavascriptSource("profesionalesdatos.js", "?2026932032229", false, true, false);
         context.AddJavascriptSource("Rating/rating.min.js", "", false, true, false);
         context.AddJavascriptSource("Rating/RatingRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         dynEstadosGenericosId_Internalname = "ESTADOSGENERICOSID";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO";
         divTable2_Internalname = "TABLE2";
         imgProfesionalesPhoto_Internalname = "PROFESIONALESPHOTO";
         Profesionalesfeedback_Internalname = "PROFESIONALESFEEDBACK";
         edtavProfesionalesfeedback_Internalname = "vPROFESIONALESFEEDBACK";
         edtProfesionalesFeedBackCant_Internalname = "PROFESIONALESFEEDBACKCANT";
         divTable3_Internalname = "TABLE3";
         divTable1_Internalname = "TABLE1";
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO";
         edtProfesionalesEmail_Internalname = "PROFESIONALESEMAIL";
         edtProfesionalesDireccion_Internalname = "PROFESIONALESDIRECCION";
         imgImage1_Internalname = "IMAGE1";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
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
         Form.Caption = context.GetMessage( "Datos del Profesional", "");
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgImage1_Visible = 1;
         edtProfesionalesDireccion_Enabled = 1;
         edtProfesionalesEmail_Jsonclick = "";
         edtProfesionalesEmail_Enabled = 1;
         edtProfesionalesTelefono_Jsonclick = "";
         edtProfesionalesTelefono_Enabled = 1;
         edtProfesionalesFeedBackCant_Jsonclick = "";
         edtProfesionalesFeedBackCant_Enabled = 0;
         edtavProfesionalesfeedback_Jsonclick = "";
         edtavProfesionalesfeedback_Enabled = 0;
         Profesionalesfeedback_Captionposition = "Left";
         Profesionalesfeedback_Captionstyle = "";
         Profesionalesfeedback_Captionclass = "col-sm-3 AttributeLabel";
         Profesionalesfeedback_Enabled = Convert.ToBoolean( 0);
         imgProfesionalesPhoto_Enabled = 1;
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Enabled = 1;
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Enabled = 1;
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesSegundoNombre_Enabled = 1;
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Enabled = 1;
         dynEstadosGenericosId_Jsonclick = "";
         dynEstadosGenericosId.Enabled = 0;
         edtProfesionalesId_Jsonclick = "";
         edtProfesionalesId_Enabled = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         GXAESTADOSGENERICOSID_html1334( A107EstadosTipo) ;
         /* End function dynload_actions */
      }

      protected void GXDLAESTADOSGENERICOSID1334( string A107EstadosTipo )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAESTADOSGENERICOSID_data1334( A107EstadosTipo) ;
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

      protected void GXAESTADOSGENERICOSID_html1334( string A107EstadosTipo )
      {
         int gxdynajaxvalue;
         GXDLAESTADOSGENERICOSID_data1334( A107EstadosTipo) ;
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

      protected void GXDLAESTADOSGENERICOSID_data1334( string A107EstadosTipo )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T001325 */
         pr_default.execute(23, new Object[] {A107EstadosTipo});
         while ( (pr_default.getStatus(23) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T001325_A108EstadosGenericosId[0]), 5, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T001325_A109EstadosGenericosNombre[0]));
            pr_default.readNext(23);
         }
         pr_default.close(23);
      }

      protected void init_web_controls( )
      {
         dynEstadosGenericosId.Name = "ESTADOSGENERICOSID";
         dynEstadosGenericosId.WebTags = "";
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

      public void Valid_Profesionalesfeedbackcant( )
      {
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         if ( A268ProfesionalesFeedBackCant > 0 )
         {
            A270ProfesionalesFeedback = (decimal)(A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant));
         }
         else
         {
            A270ProfesionalesFeedback = 0;
         }
         AV11ProfesionalesFeedback = A270ProfesionalesFeedback;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A270ProfesionalesFeedback", StringUtil.LTrim( StringUtil.NToC( A270ProfesionalesFeedback, 10, 2, ".", "")));
         AssignAttri("", false, "AV11ProfesionalesFeedback", StringUtil.LTrim( StringUtil.NToC( AV11ProfesionalesFeedback, 10, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'AV7ProfesionalesId',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ProfesionalesId',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A268ProfesionalesFeedBackCant',fld:'PROFESIONALESFEEDBACKCANT',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A199ProfesionalesFechaAlta',fld:'PROFESIONALESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'A200ProfesionalesFechaActualizado',fld:'PROFESIONALESFECHAACTUALIZADO',pic:'99/99/99 99:99',type:'dtime'},{av:'A196ProfesionalesAutoEnumerar',fld:'PROFESIONALESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'A197ProfesionalesAutoEnuZona',fld:'PROFESIONALESAUTOENUZONA',pic:'ZZZ9',type:'int'},{av:'A267ProfesionalesVerDatPerSol',fld:'PROFESIONALESVERDATPERSOL',pic:'',type:'char'},{av:'A269ProfesionalesFeedBackProm',fld:'PROFESIONALESFEEDBACKPROM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_ESTADOSGENERICOSID","{handler:'Valid_Estadosgenericosid',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("VALID_ESTADOSGENERICOSID",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKCANT","{handler:'Valid_Profesionalesfeedbackcant',iparms:[{av:'A269ProfesionalesFeedBackProm',fld:'PROFESIONALESFEEDBACKPROM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A268ProfesionalesFeedBackCant',fld:'PROFESIONALESFEEDBACKCANT',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A270ProfesionalesFeedback',fld:'PROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV11ProfesionalesFeedback',fld:'vPROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99 %',type:'decimal'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKCANT",",oparms:[{av:'A270ProfesionalesFeedback',fld:'PROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV11ProfesionalesFeedback',fld:'vPROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99 %',type:'decimal'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PROFESIONALESEMAIL","{handler:'Valid_Profesionalesemail',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("VALID_PROFESIONALESEMAIL",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_PROFESIONALESFEEDBACK","{handler:'Valid_Profesionalesfeedback',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("VALID_PROFESIONALESFEEDBACK",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
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
         wcpOAV7ProfesionalesId = "";
         wcpOGx_mode = "";
         Z120ProfesionalesId = "";
         Z199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         Z200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         Z166ProfesionalesPrimerNombre = "";
         Z191ProfesionalesSegundoNombre = "";
         Z167ProfesionalesApellidoPrimero = "";
         Z192ProfesionalesApellidoSegundo = "";
         Z170ProfesionalesTelefono = "";
         Z193ProfesionalesEmail = "";
         Z198ProfesionalesDireccion = "";
         Z267ProfesionalesVerDatPerSol = "";
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
         lblTitle_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A169ProfesionalesPhoto = "";
         A40000ProfesionalesPhoto_GXI = "";
         sImgUrl = "";
         ucProfesionalesfeedback = new GXUserControl();
         gxphoneLink = "";
         A170ProfesionalesTelefono = "";
         A193ProfesionalesEmail = "";
         A198ProfesionalesDireccion = "";
         imgImage1_gximage = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         A199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         A200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         A267ProfesionalesVerDatPerSol = "";
         Profesionalesfeedback_Objectcall = "";
         Profesionalesfeedback_Class = "";
         Profesionalesfeedback_Ratingclass = "";
         Profesionalesfeedback_Captionvalue = "";
         Profesionalesfeedback_Coltitle = "";
         Profesionalesfeedback_Coltitlefont = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode34 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z169ProfesionalesPhoto = "";
         Z40000ProfesionalesPhoto_GXI = "";
         T00135_A120ProfesionalesId = new string[] {""} ;
         T00135_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00135_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         T00135_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T00135_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T00135_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T00135_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T00135_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         T00135_A170ProfesionalesTelefono = new string[] {""} ;
         T00135_A193ProfesionalesEmail = new string[] {""} ;
         T00135_n193ProfesionalesEmail = new bool[] {false} ;
         T00135_A198ProfesionalesDireccion = new string[] {""} ;
         T00135_A196ProfesionalesAutoEnumerar = new short[1] ;
         T00135_A197ProfesionalesAutoEnuZona = new short[1] ;
         T00135_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         T00135_A268ProfesionalesFeedBackCant = new long[1] ;
         T00135_A269ProfesionalesFeedBackProm = new decimal[1] ;
         T00135_A107EstadosTipo = new string[] {""} ;
         T00135_A108EstadosGenericosId = new int[1] ;
         T00135_A169ProfesionalesPhoto = new string[] {""} ;
         T00134_A107EstadosTipo = new string[] {""} ;
         T00136_A107EstadosTipo = new string[] {""} ;
         T00137_A120ProfesionalesId = new string[] {""} ;
         T00133_A120ProfesionalesId = new string[] {""} ;
         T00133_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00133_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         T00133_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T00133_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T00133_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T00133_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T00133_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         T00133_A170ProfesionalesTelefono = new string[] {""} ;
         T00133_A193ProfesionalesEmail = new string[] {""} ;
         T00133_n193ProfesionalesEmail = new bool[] {false} ;
         T00133_A198ProfesionalesDireccion = new string[] {""} ;
         T00133_A196ProfesionalesAutoEnumerar = new short[1] ;
         T00133_A197ProfesionalesAutoEnuZona = new short[1] ;
         T00133_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         T00133_A268ProfesionalesFeedBackCant = new long[1] ;
         T00133_A269ProfesionalesFeedBackProm = new decimal[1] ;
         T00133_A107EstadosTipo = new string[] {""} ;
         T00133_A108EstadosGenericosId = new int[1] ;
         T00133_A169ProfesionalesPhoto = new string[] {""} ;
         T00138_A120ProfesionalesId = new string[] {""} ;
         T00139_A120ProfesionalesId = new string[] {""} ;
         T00132_A120ProfesionalesId = new string[] {""} ;
         T00132_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T00132_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         T00132_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T00132_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T00132_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T00132_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T00132_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         T00132_A170ProfesionalesTelefono = new string[] {""} ;
         T00132_A193ProfesionalesEmail = new string[] {""} ;
         T00132_n193ProfesionalesEmail = new bool[] {false} ;
         T00132_A198ProfesionalesDireccion = new string[] {""} ;
         T00132_A196ProfesionalesAutoEnumerar = new short[1] ;
         T00132_A197ProfesionalesAutoEnuZona = new short[1] ;
         T00132_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         T00132_A268ProfesionalesFeedBackCant = new long[1] ;
         T00132_A269ProfesionalesFeedBackProm = new decimal[1] ;
         T00132_A107EstadosTipo = new string[] {""} ;
         T00132_A108EstadosGenericosId = new int[1] ;
         T00132_A169ProfesionalesPhoto = new string[] {""} ;
         T001314_A461CentroCostosId = new long[1] ;
         T001314_A466CentroCostosDetallesId = new long[1] ;
         T001315_A976ProfesionalesRestriccionId = new long[1] ;
         T001316_A450ProfComisionesID = new long[1] ;
         T001317_A127SolicitudesID = new long[1] ;
         T001317_A140RelacionesId = new long[1] ;
         T001318_A120ProfesionalesId = new string[] {""} ;
         T001318_A993ProfesionalServicioId = new long[1] ;
         T001319_A422PostulacionesId = new long[1] ;
         T001319_A120ProfesionalesId = new string[] {""} ;
         T001320_A590Listaid = new long[1] ;
         T001320_A133ProveedorID = new long[1] ;
         T001320_A120ProfesionalesId = new string[] {""} ;
         T001321_A503ComisionesID = new long[1] ;
         T001321_A120ProfesionalesId = new string[] {""} ;
         T001322_A120ProfesionalesId = new string[] {""} ;
         T001322_A126ProfesionalesZonasCorrelativo = new short[1] ;
         T001323_A120ProfesionalesId = new string[] {""} ;
         T001323_A121RubrosId = new short[1] ;
         T001324_A120ProfesionalesId = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         i107EstadosTipo = "";
         i199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         i200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T001325_A107EstadosTipo = new string[] {""} ;
         T001325_A108EstadosGenericosId = new int[1] ;
         T001325_A109EstadosGenericosNombre = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.profesionalesdatos__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalesdatos__default(),
            new Object[][] {
                new Object[] {
               T00132_A120ProfesionalesId, T00132_A199ProfesionalesFechaAlta, T00132_A200ProfesionalesFechaActualizado, T00132_A166ProfesionalesPrimerNombre, T00132_A191ProfesionalesSegundoNombre, T00132_A167ProfesionalesApellidoPrimero, T00132_A192ProfesionalesApellidoSegundo, T00132_A40000ProfesionalesPhoto_GXI, T00132_A170ProfesionalesTelefono, T00132_A193ProfesionalesEmail,
               T00132_n193ProfesionalesEmail, T00132_A198ProfesionalesDireccion, T00132_A196ProfesionalesAutoEnumerar, T00132_A197ProfesionalesAutoEnuZona, T00132_A267ProfesionalesVerDatPerSol, T00132_A268ProfesionalesFeedBackCant, T00132_A269ProfesionalesFeedBackProm, T00132_A107EstadosTipo, T00132_A108EstadosGenericosId, T00132_A169ProfesionalesPhoto
               }
               , new Object[] {
               T00133_A120ProfesionalesId, T00133_A199ProfesionalesFechaAlta, T00133_A200ProfesionalesFechaActualizado, T00133_A166ProfesionalesPrimerNombre, T00133_A191ProfesionalesSegundoNombre, T00133_A167ProfesionalesApellidoPrimero, T00133_A192ProfesionalesApellidoSegundo, T00133_A40000ProfesionalesPhoto_GXI, T00133_A170ProfesionalesTelefono, T00133_A193ProfesionalesEmail,
               T00133_n193ProfesionalesEmail, T00133_A198ProfesionalesDireccion, T00133_A196ProfesionalesAutoEnumerar, T00133_A197ProfesionalesAutoEnuZona, T00133_A267ProfesionalesVerDatPerSol, T00133_A268ProfesionalesFeedBackCant, T00133_A269ProfesionalesFeedBackProm, T00133_A107EstadosTipo, T00133_A108EstadosGenericosId, T00133_A169ProfesionalesPhoto
               }
               , new Object[] {
               T00134_A107EstadosTipo
               }
               , new Object[] {
               T00135_A120ProfesionalesId, T00135_A199ProfesionalesFechaAlta, T00135_A200ProfesionalesFechaActualizado, T00135_A166ProfesionalesPrimerNombre, T00135_A191ProfesionalesSegundoNombre, T00135_A167ProfesionalesApellidoPrimero, T00135_A192ProfesionalesApellidoSegundo, T00135_A40000ProfesionalesPhoto_GXI, T00135_A170ProfesionalesTelefono, T00135_A193ProfesionalesEmail,
               T00135_n193ProfesionalesEmail, T00135_A198ProfesionalesDireccion, T00135_A196ProfesionalesAutoEnumerar, T00135_A197ProfesionalesAutoEnuZona, T00135_A267ProfesionalesVerDatPerSol, T00135_A268ProfesionalesFeedBackCant, T00135_A269ProfesionalesFeedBackProm, T00135_A107EstadosTipo, T00135_A108EstadosGenericosId, T00135_A169ProfesionalesPhoto
               }
               , new Object[] {
               T00136_A107EstadosTipo
               }
               , new Object[] {
               T00137_A120ProfesionalesId
               }
               , new Object[] {
               T00138_A120ProfesionalesId
               }
               , new Object[] {
               T00139_A120ProfesionalesId
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
               T001314_A461CentroCostosId, T001314_A466CentroCostosDetallesId
               }
               , new Object[] {
               T001315_A976ProfesionalesRestriccionId
               }
               , new Object[] {
               T001316_A450ProfComisionesID
               }
               , new Object[] {
               T001317_A127SolicitudesID, T001317_A140RelacionesId
               }
               , new Object[] {
               T001318_A120ProfesionalesId, T001318_A993ProfesionalServicioId
               }
               , new Object[] {
               T001319_A422PostulacionesId, T001319_A120ProfesionalesId
               }
               , new Object[] {
               T001320_A590Listaid, T001320_A133ProveedorID, T001320_A120ProfesionalesId
               }
               , new Object[] {
               T001321_A503ComisionesID, T001321_A120ProfesionalesId
               }
               , new Object[] {
               T001322_A120ProfesionalesId, T001322_A126ProfesionalesZonasCorrelativo
               }
               , new Object[] {
               T001323_A120ProfesionalesId, T001323_A121RubrosId
               }
               , new Object[] {
               T001324_A120ProfesionalesId
               }
               , new Object[] {
               T001325_A107EstadosTipo, T001325_A108EstadosGenericosId, T001325_A109EstadosGenericosNombre
               }
            }
         );
      }

      private short Z196ProfesionalesAutoEnumerar ;
      private short Z197ProfesionalesAutoEnuZona ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A196ProfesionalesAutoEnumerar ;
      private short A197ProfesionalesAutoEnuZona ;
      private short RcdFound34 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z108EstadosGenericosId ;
      private int A108EstadosGenericosId ;
      private int trnEnded ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int imgProfesionalesPhoto_Enabled ;
      private int edtavProfesionalesfeedback_Enabled ;
      private int edtProfesionalesFeedBackCant_Enabled ;
      private int edtProfesionalesTelefono_Enabled ;
      private int edtProfesionalesEmail_Enabled ;
      private int edtProfesionalesDireccion_Enabled ;
      private int imgImage1_Visible ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int Profesionalesfeedback_Maxvalue ;
      private int Profesionalesfeedback_Step ;
      private int Profesionalesfeedback_Coltitlecolor ;
      private int i108EstadosGenericosId ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private long Z268ProfesionalesFeedBackCant ;
      private long A268ProfesionalesFeedBackCant ;
      private decimal Z269ProfesionalesFeedBackProm ;
      private decimal ProfesionalesFeedback ;
      private decimal AV11ProfesionalesFeedback ;
      private decimal A269ProfesionalesFeedBackProm ;
      private decimal A270ProfesionalesFeedback ;
      private decimal Z270ProfesionalesFeedback ;
      private decimal ZV11ProfesionalesFeedback ;
      private string sPrefix ;
      private string wcpOAV7ProfesionalesId ;
      private string wcpOGx_mode ;
      private string Z120ProfesionalesId ;
      private string Z166ProfesionalesPrimerNombre ;
      private string Z191ProfesionalesSegundoNombre ;
      private string Z167ProfesionalesApellidoPrimero ;
      private string Z192ProfesionalesApellidoSegundo ;
      private string Z170ProfesionalesTelefono ;
      private string Z267ProfesionalesVerDatPerSol ;
      private string Z107EstadosTipo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A107EstadosTipo ;
      private string GXKey ;
      private string GXDecQS ;
      private string AV7ProfesionalesId ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProfesionalesId_Internalname ;
      private string dynEstadosGenericosId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string divFormcontainer_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string TempTags ;
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Jsonclick ;
      private string dynEstadosGenericosId_Jsonclick ;
      private string divTable1_Internalname ;
      private string divTable2_Internalname ;
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
      private string divTable3_Internalname ;
      private string imgProfesionalesPhoto_Internalname ;
      private string sImgUrl ;
      private string Profesionalesfeedback_Internalname ;
      private string Profesionalesfeedback_Captionclass ;
      private string Profesionalesfeedback_Captionstyle ;
      private string Profesionalesfeedback_Captionposition ;
      private string edtavProfesionalesfeedback_Internalname ;
      private string edtavProfesionalesfeedback_Jsonclick ;
      private string edtProfesionalesFeedBackCant_Internalname ;
      private string edtProfesionalesFeedBackCant_Jsonclick ;
      private string edtProfesionalesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A170ProfesionalesTelefono ;
      private string edtProfesionalesTelefono_Jsonclick ;
      private string edtProfesionalesEmail_Internalname ;
      private string edtProfesionalesEmail_Jsonclick ;
      private string edtProfesionalesDireccion_Internalname ;
      private string imgImage1_gximage ;
      private string imgImage1_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string A267ProfesionalesVerDatPerSol ;
      private string Profesionalesfeedback_Objectcall ;
      private string Profesionalesfeedback_Class ;
      private string Profesionalesfeedback_Ratingclass ;
      private string Profesionalesfeedback_Captionvalue ;
      private string Profesionalesfeedback_Coltitle ;
      private string Profesionalesfeedback_Coltitlefont ;
      private string hsh ;
      private string sMode34 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXCCtlgxBlob ;
      private string i107EstadosTipo ;
      private string gxwrpcisep ;
      private DateTime Z199ProfesionalesFechaAlta ;
      private DateTime Z200ProfesionalesFechaActualizado ;
      private DateTime A199ProfesionalesFechaAlta ;
      private DateTime A200ProfesionalesFechaActualizado ;
      private DateTime i199ProfesionalesFechaAlta ;
      private DateTime i200ProfesionalesFechaActualizado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A169ProfesionalesPhoto_IsBlob ;
      private bool n193ProfesionalesEmail ;
      private bool Profesionalesfeedback_Enabled ;
      private bool Profesionalesfeedback_Isabstractlayoutcontrol ;
      private bool Profesionalesfeedback_Usercontroliscolumn ;
      private bool Profesionalesfeedback_Visible ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private string Z193ProfesionalesEmail ;
      private string Z198ProfesionalesDireccion ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string A193ProfesionalesEmail ;
      private string A198ProfesionalesDireccion ;
      private string Z40000ProfesionalesPhoto_GXI ;
      private string A169ProfesionalesPhoto ;
      private string Z169ProfesionalesPhoto ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucProfesionalesfeedback ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynEstadosGenericosId ;
      private IDataStoreProvider pr_default ;
      private string[] T00135_A120ProfesionalesId ;
      private DateTime[] T00135_A199ProfesionalesFechaAlta ;
      private DateTime[] T00135_A200ProfesionalesFechaActualizado ;
      private string[] T00135_A166ProfesionalesPrimerNombre ;
      private string[] T00135_A191ProfesionalesSegundoNombre ;
      private string[] T00135_A167ProfesionalesApellidoPrimero ;
      private string[] T00135_A192ProfesionalesApellidoSegundo ;
      private string[] T00135_A40000ProfesionalesPhoto_GXI ;
      private string[] T00135_A170ProfesionalesTelefono ;
      private string[] T00135_A193ProfesionalesEmail ;
      private bool[] T00135_n193ProfesionalesEmail ;
      private string[] T00135_A198ProfesionalesDireccion ;
      private short[] T00135_A196ProfesionalesAutoEnumerar ;
      private short[] T00135_A197ProfesionalesAutoEnuZona ;
      private string[] T00135_A267ProfesionalesVerDatPerSol ;
      private long[] T00135_A268ProfesionalesFeedBackCant ;
      private decimal[] T00135_A269ProfesionalesFeedBackProm ;
      private string[] T00135_A107EstadosTipo ;
      private int[] T00135_A108EstadosGenericosId ;
      private string[] T00135_A169ProfesionalesPhoto ;
      private string[] T00134_A107EstadosTipo ;
      private string[] T00136_A107EstadosTipo ;
      private string[] T00137_A120ProfesionalesId ;
      private string[] T00133_A120ProfesionalesId ;
      private DateTime[] T00133_A199ProfesionalesFechaAlta ;
      private DateTime[] T00133_A200ProfesionalesFechaActualizado ;
      private string[] T00133_A166ProfesionalesPrimerNombre ;
      private string[] T00133_A191ProfesionalesSegundoNombre ;
      private string[] T00133_A167ProfesionalesApellidoPrimero ;
      private string[] T00133_A192ProfesionalesApellidoSegundo ;
      private string[] T00133_A40000ProfesionalesPhoto_GXI ;
      private string[] T00133_A170ProfesionalesTelefono ;
      private string[] T00133_A193ProfesionalesEmail ;
      private bool[] T00133_n193ProfesionalesEmail ;
      private string[] T00133_A198ProfesionalesDireccion ;
      private short[] T00133_A196ProfesionalesAutoEnumerar ;
      private short[] T00133_A197ProfesionalesAutoEnuZona ;
      private string[] T00133_A267ProfesionalesVerDatPerSol ;
      private long[] T00133_A268ProfesionalesFeedBackCant ;
      private decimal[] T00133_A269ProfesionalesFeedBackProm ;
      private string[] T00133_A107EstadosTipo ;
      private int[] T00133_A108EstadosGenericosId ;
      private string[] T00133_A169ProfesionalesPhoto ;
      private string[] T00138_A120ProfesionalesId ;
      private string[] T00139_A120ProfesionalesId ;
      private string[] T00132_A120ProfesionalesId ;
      private DateTime[] T00132_A199ProfesionalesFechaAlta ;
      private DateTime[] T00132_A200ProfesionalesFechaActualizado ;
      private string[] T00132_A166ProfesionalesPrimerNombre ;
      private string[] T00132_A191ProfesionalesSegundoNombre ;
      private string[] T00132_A167ProfesionalesApellidoPrimero ;
      private string[] T00132_A192ProfesionalesApellidoSegundo ;
      private string[] T00132_A40000ProfesionalesPhoto_GXI ;
      private string[] T00132_A170ProfesionalesTelefono ;
      private string[] T00132_A193ProfesionalesEmail ;
      private bool[] T00132_n193ProfesionalesEmail ;
      private string[] T00132_A198ProfesionalesDireccion ;
      private short[] T00132_A196ProfesionalesAutoEnumerar ;
      private short[] T00132_A197ProfesionalesAutoEnuZona ;
      private string[] T00132_A267ProfesionalesVerDatPerSol ;
      private long[] T00132_A268ProfesionalesFeedBackCant ;
      private decimal[] T00132_A269ProfesionalesFeedBackProm ;
      private string[] T00132_A107EstadosTipo ;
      private int[] T00132_A108EstadosGenericosId ;
      private string[] T00132_A169ProfesionalesPhoto ;
      private long[] T001314_A461CentroCostosId ;
      private long[] T001314_A466CentroCostosDetallesId ;
      private long[] T001315_A976ProfesionalesRestriccionId ;
      private long[] T001316_A450ProfComisionesID ;
      private long[] T001317_A127SolicitudesID ;
      private long[] T001317_A140RelacionesId ;
      private string[] T001318_A120ProfesionalesId ;
      private long[] T001318_A993ProfesionalServicioId ;
      private long[] T001319_A422PostulacionesId ;
      private string[] T001319_A120ProfesionalesId ;
      private long[] T001320_A590Listaid ;
      private long[] T001320_A133ProveedorID ;
      private string[] T001320_A120ProfesionalesId ;
      private long[] T001321_A503ComisionesID ;
      private string[] T001321_A120ProfesionalesId ;
      private string[] T001322_A120ProfesionalesId ;
      private short[] T001322_A126ProfesionalesZonasCorrelativo ;
      private string[] T001323_A120ProfesionalesId ;
      private short[] T001323_A121RubrosId ;
      private string[] T001324_A120ProfesionalesId ;
      private string[] T001325_A107EstadosTipo ;
      private int[] T001325_A108EstadosGenericosId ;
      private string[] T001325_A109EstadosGenericosNombre ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class profesionalesdatos__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class profesionalesdatos__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00132;
        prmT00132 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT00133;
        prmT00133 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT00134;
        prmT00134 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT00135;
        prmT00135 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT00136;
        prmT00136 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT00137;
        prmT00137 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT00138;
        prmT00138 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT00139;
        prmT00139 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001310;
        prmT001310 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesFechaActualizado",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesPrimerNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesSegundoNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoPrimero",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoSegundo",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesPhoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ProfesionalesPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=7, Tbl="Profesionales", Fld="ProfesionalesPhoto"} ,
        new ParDef("@ProfesionalesTelefono",GXType.NChar,20,0) ,
        new ParDef("@ProfesionalesEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProfesionalesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@ProfesionalesAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesAutoEnuZona",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesVerDatPerSol",GXType.NChar,1,0) ,
        new ParDef("@ProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesFeedBackProm",GXType.Decimal,18,2) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT001311;
        prmT001311 = new Object[] {
        new ParDef("@ProfesionalesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesFechaActualizado",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesPrimerNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesSegundoNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoPrimero",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoSegundo",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesTelefono",GXType.NChar,20,0) ,
        new ParDef("@ProfesionalesEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProfesionalesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@ProfesionalesAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesAutoEnuZona",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesVerDatPerSol",GXType.NChar,1,0) ,
        new ParDef("@ProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesFeedBackProm",GXType.Decimal,18,2) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001312;
        prmT001312 = new Object[] {
        new ParDef("@ProfesionalesPhoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ProfesionalesPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Profesionales", Fld="ProfesionalesPhoto"} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001313;
        prmT001313 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001314;
        prmT001314 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001315;
        prmT001315 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001316;
        prmT001316 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001317;
        prmT001317 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001318;
        prmT001318 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001319;
        prmT001319 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001320;
        prmT001320 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001321;
        prmT001321 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001322;
        prmT001322 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001323;
        prmT001323 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT001324;
        prmT001324 = new Object[] {
        };
        Object[] prmT001325;
        prmT001325 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00132", "SELECT [ProfesionalesId], [ProfesionalesFechaAlta], [ProfesionalesFechaActualizado], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesEmail], [ProfesionalesDireccion], [ProfesionalesAutoEnumerar], [ProfesionalesAutoEnuZona], [ProfesionalesVerDatPerSol], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [EstadosTipo], [EstadosGenericosId], [ProfesionalesPhoto] FROM [Profesionales] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00132,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00133", "SELECT [ProfesionalesId], [ProfesionalesFechaAlta], [ProfesionalesFechaActualizado], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesEmail], [ProfesionalesDireccion], [ProfesionalesAutoEnumerar], [ProfesionalesAutoEnuZona], [ProfesionalesVerDatPerSol], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [EstadosTipo], [EstadosGenericosId], [ProfesionalesPhoto] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00133,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00134", "SELECT [EstadosTipo] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00134,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00135", "SELECT TM1.[ProfesionalesId], TM1.[ProfesionalesFechaAlta], TM1.[ProfesionalesFechaActualizado], TM1.[ProfesionalesPrimerNombre], TM1.[ProfesionalesSegundoNombre], TM1.[ProfesionalesApellidoPrimero], TM1.[ProfesionalesApellidoSegundo], TM1.[ProfesionalesPhoto_GXI], TM1.[ProfesionalesTelefono], TM1.[ProfesionalesEmail], TM1.[ProfesionalesDireccion], TM1.[ProfesionalesAutoEnumerar], TM1.[ProfesionalesAutoEnuZona], TM1.[ProfesionalesVerDatPerSol], TM1.[ProfesionalesFeedBackCant], TM1.[ProfesionalesFeedBackProm], TM1.[EstadosTipo], TM1.[EstadosGenericosId], TM1.[ProfesionalesPhoto] FROM [Profesionales] TM1 WHERE TM1.[ProfesionalesId] = @ProfesionalesId ORDER BY TM1.[ProfesionalesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00135,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00136", "SELECT [EstadosTipo] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00136,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00137", "SELECT [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00137,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00138", "SELECT TOP 1 [ProfesionalesId] FROM [Profesionales] WHERE ( [ProfesionalesId] > @ProfesionalesId) ORDER BY [ProfesionalesId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00138,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00139", "SELECT TOP 1 [ProfesionalesId] FROM [Profesionales] WHERE ( [ProfesionalesId] < @ProfesionalesId) ORDER BY [ProfesionalesId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00139,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001310", "INSERT INTO [Profesionales]([ProfesionalesId], [ProfesionalesFechaAlta], [ProfesionalesFechaActualizado], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesEmail], [ProfesionalesDireccion], [ProfesionalesAutoEnumerar], [ProfesionalesAutoEnuZona], [ProfesionalesVerDatPerSol], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [EstadosTipo], [EstadosGenericosId], [ProfesionalesPerAltShop], [ProfesionalesLimitOSF], [ProfesionalesEsRUT], [ProfesionalesExperiencia], [ProfesionalesAceptoTerminos], [ProfesionalesDeclaroDatosV], [ProfesionalesCuentaBancaria], [BancoId], [ProfesionalesCapacidadProducti], [ProfesionalesFechaNacimiento], [ProfesionalesRUT], [ProfesionalesTipoEmpresa]) VALUES(@ProfesionalesId, @ProfesionalesFechaAlta, @ProfesionalesFechaActualizado, @ProfesionalesPrimerNombre, @ProfesionalesSegundoNombre, @ProfesionalesApellidoPrimero, @ProfesionalesApellidoSegundo, @ProfesionalesPhoto, @ProfesionalesPhoto_GXI, @ProfesionalesTelefono, @ProfesionalesEmail, @ProfesionalesDireccion, @ProfesionalesAutoEnumerar, @ProfesionalesAutoEnuZona, @ProfesionalesVerDatPerSol, @ProfesionalesFeedBackCant, @ProfesionalesFeedBackProm, @EstadosTipo, @EstadosGenericosId, '', convert(int, 0), convert(bit, 0), '', convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', convert(int, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), '', convert(int, 0))", GxErrorMask.GX_NOMASK,prmT001310)
           ,new CursorDef("T001311", "UPDATE [Profesionales] SET [ProfesionalesFechaAlta]=@ProfesionalesFechaAlta, [ProfesionalesFechaActualizado]=@ProfesionalesFechaActualizado, [ProfesionalesPrimerNombre]=@ProfesionalesPrimerNombre, [ProfesionalesSegundoNombre]=@ProfesionalesSegundoNombre, [ProfesionalesApellidoPrimero]=@ProfesionalesApellidoPrimero, [ProfesionalesApellidoSegundo]=@ProfesionalesApellidoSegundo, [ProfesionalesTelefono]=@ProfesionalesTelefono, [ProfesionalesEmail]=@ProfesionalesEmail, [ProfesionalesDireccion]=@ProfesionalesDireccion, [ProfesionalesAutoEnumerar]=@ProfesionalesAutoEnumerar, [ProfesionalesAutoEnuZona]=@ProfesionalesAutoEnuZona, [ProfesionalesVerDatPerSol]=@ProfesionalesVerDatPerSol, [ProfesionalesFeedBackCant]=@ProfesionalesFeedBackCant, [ProfesionalesFeedBackProm]=@ProfesionalesFeedBackProm, [EstadosTipo]=@EstadosTipo, [EstadosGenericosId]=@EstadosGenericosId  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT001311)
           ,new CursorDef("T001312", "UPDATE [Profesionales] SET [ProfesionalesPhoto]=@ProfesionalesPhoto, [ProfesionalesPhoto_GXI]=@ProfesionalesPhoto_GXI  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT001312)
           ,new CursorDef("T001313", "DELETE FROM [Profesionales]  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT001313)
           ,new CursorDef("T001314", "SELECT TOP 1 [CentroCostosId], [CentroCostosDetallesId] FROM [CentroCostosDetalles] WHERE [CCDetallesProfId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001314,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001315", "SELECT TOP 1 [ProfesionalesRestriccionId] FROM [ProfesionalesRestriccion] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001315,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001316", "SELECT TOP 1 [ProfComisionesID] FROM [ProfComisiones] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001316,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001317", "SELECT TOP 1 [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001317,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001318", "SELECT TOP 1 [ProfesionalesId], [ProfesionalServicioId] FROM [ProfesionalesServicios] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001318,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001319", "SELECT TOP 1 [PostulacionesId], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001319,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001320", "SELECT TOP 1 [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001320,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001321", "SELECT TOP 1 [ComisionesID], [ProfesionalesId] FROM [ComisionesProfesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001321,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001322", "SELECT TOP 1 [ProfesionalesId], [ProfesionalesZonasCorrelativo] FROM [ProfesionalesZonas] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001322,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001323", "SELECT TOP 1 [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001323,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001324", "SELECT [ProfesionalesId] FROM [Profesionales] ORDER BY [ProfesionalesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001324,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001325", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo ORDER BY [EstadosGenericosNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001325,0, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getString(5, 30);
              ((string[]) buf[5])[0] = rslt.getString(6, 30);
              ((string[]) buf[6])[0] = rslt.getString(7, 30);
              ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((short[]) buf[12])[0] = rslt.getShort(12);
              ((short[]) buf[13])[0] = rslt.getShort(13);
              ((string[]) buf[14])[0] = rslt.getString(14, 1);
              ((long[]) buf[15])[0] = rslt.getLong(15);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
              ((string[]) buf[17])[0] = rslt.getString(17, 3);
              ((int[]) buf[18])[0] = rslt.getInt(18);
              ((string[]) buf[19])[0] = rslt.getMultimediaFile(19, rslt.getVarchar(8));
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getString(5, 30);
              ((string[]) buf[5])[0] = rslt.getString(6, 30);
              ((string[]) buf[6])[0] = rslt.getString(7, 30);
              ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((short[]) buf[12])[0] = rslt.getShort(12);
              ((short[]) buf[13])[0] = rslt.getShort(13);
              ((string[]) buf[14])[0] = rslt.getString(14, 1);
              ((long[]) buf[15])[0] = rslt.getLong(15);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
              ((string[]) buf[17])[0] = rslt.getString(17, 3);
              ((int[]) buf[18])[0] = rslt.getInt(18);
              ((string[]) buf[19])[0] = rslt.getMultimediaFile(19, rslt.getVarchar(8));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 30);
              ((string[]) buf[4])[0] = rslt.getString(5, 30);
              ((string[]) buf[5])[0] = rslt.getString(6, 30);
              ((string[]) buf[6])[0] = rslt.getString(7, 30);
              ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((short[]) buf[12])[0] = rslt.getShort(12);
              ((short[]) buf[13])[0] = rslt.getShort(13);
              ((string[]) buf[14])[0] = rslt.getString(14, 1);
              ((long[]) buf[15])[0] = rslt.getLong(15);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
              ((string[]) buf[17])[0] = rslt.getString(17, 3);
              ((int[]) buf[18])[0] = rslt.getInt(18);
              ((string[]) buf[19])[0] = rslt.getMultimediaFile(19, rslt.getVarchar(8));
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              return;
     }
  }

}

}

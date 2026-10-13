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
   public class comercioproductos : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"MEDIDASID") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAMEDIDASID2G116( A121RubrosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"INVENTARIOID") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAINVENTARIOID2G116( A121RubrosId, A137MedidasID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A121RubrosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A121RubrosId, A137MedidasID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
            A135InventarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "InventarioId"), "."), 18, MidpointRounding.ToEven));
            n135InventarioId = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A121RubrosId, A137MedidasID, A135InventarioId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "comercioproductos.aspx")), "comercioproductos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "comercioproductos.aspx")))) ;
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
                  AV7ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ProveedorID", StringUtil.LTrimStr( (decimal)(AV7ProveedorID), 18, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Rubros del Comercio", ""), 0) ;
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

      protected void gxnrGridlevel_rubros_newrow_invoke( )
      {
         nRC_GXsfl_39 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_39"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_39_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_39_idx = GetPar( "sGXsfl_39_idx");
         edtRubrosId_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtRubrosId_Internalname, "Horizontalalignment", edtRubrosId_Horizontalalignment, !bGXsfl_39_Refreshing);
         A712ComercioProductosREnum = (long)(Math.Round(NumberUtil.Val( GetPar( "ComercioProductosREnum"), "."), 18, MidpointRounding.ToEven));
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

      public comercioproductos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comercioproductos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_ProveedorID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProveedorID = aP1_ProveedorID;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbProveedorEstado = new GXCombobox();
         cmbComercioRubrosEstado = new GXCombobox();
         dynMedidasID = new GXCombobox();
         chkComercioItemsEstado = new GXCheckbox();
         dynInventarioId = new GXCombobox();
         chkComercioRubrosInventarioActiva = new GXCheckbox();
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
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
            AssignProp("", false, cmbProveedorEstado_Internalname, "Values", cmbProveedorEstado.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTb1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorID_Internalname, context.GetMessage( "Código del Proveedor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProveedorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,14);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ComercioProductos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorNombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_ComercioProductos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProveedorEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProveedorEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProveedorEstado, cmbProveedorEstado_Internalname, StringUtil.RTrim( A344ProveedorEstado), 1, cmbProveedorEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbProveedorEstado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, 0, "HLP_ComercioProductos.htm");
         cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
         AssignProp("", false, cmbProveedorEstado_Internalname, "Values", (string)(cmbProveedorEstado.ToJavascriptSource()), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 AttributeFLLabel", 0, true, "");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A432ProveedorImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen));
         GxWebStd.gx_bitmap( context, imgProveedorImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProveedorImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", "", "", 0, A432ProveedorImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_ComercioProductos.htm");
         AssignProp("", false, imgProveedorImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen)), true);
         AssignProp("", false, imgProveedorImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A432ProveedorImagen_IsBlob), true);
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
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ComercioProductos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ComercioProductos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ComercioProductos.htm");
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
         /* User Defined Control */
         ucCombo_rubrosid.SetProperty("Caption", Combo_rubrosid_Caption);
         ucCombo_rubrosid.SetProperty("Cls", Combo_rubrosid_Cls);
         ucCombo_rubrosid.SetProperty("IsGridItem", Combo_rubrosid_Isgriditem);
         ucCombo_rubrosid.SetProperty("DropDownOptionsData", AV13RubrosId_Data);
         ucCombo_rubrosid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_rubrosid_Internalname, "COMBO_RUBROSIDContainer");
         /* User Defined Control */
         ucGridlevel_rubros_titlescategories.Render(context, "dvelop.gridtitlescategories", Gridlevel_rubros_titlescategories_Internalname, "GRIDLEVEL_RUBROS_TITLESCATEGORIESContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_rubros( )
      {
         /*  Grid Control  */
         StartGridControl39( ) ;
         nGXsfl_39_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount116 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_116 = 1;
               ScanStart2G116( ) ;
               while ( RcdFound116 != 0 )
               {
                  init_level_properties116( ) ;
                  getByPrimaryKey2G116( ) ;
                  AddRow2G116( ) ;
                  ScanNext2G116( ) ;
               }
               ScanEnd2G116( ) ;
               nBlankRcdCount116 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B712ComercioProductosREnum = A712ComercioProductosREnum;
            AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
            standaloneNotModal2G116( ) ;
            standaloneModal2G116( ) ;
            sMode116 = Gx_mode;
            while ( nGXsfl_39_idx < nRC_GXsfl_39 )
            {
               bGXsfl_39_Refreshing = true;
               ReadRow2G116( ) ;
               edtComercioProductosRubrosID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMERCIOPRODUCTOSRUBROSID_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtComercioProductosRubrosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComercioProductosRubrosID_Enabled), 5, 0), !bGXsfl_39_Refreshing);
               edtRubrosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_39_Refreshing);
               edtRubrosId_Horizontalalignment = cgiGet( "RUBROSID_"+sGXsfl_39_idx+"Horizontalalignment");
               AssignProp("", false, edtRubrosId_Internalname, "Horizontalalignment", edtRubrosId_Horizontalalignment, !bGXsfl_39_Refreshing);
               cmbComercioRubrosEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMERCIORUBROSESTADO_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbComercioRubrosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComercioRubrosEstado.Enabled), 5, 0), !bGXsfl_39_Refreshing);
               dynMedidasID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASID_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_39_Refreshing);
               chkComercioItemsEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMERCIOITEMSESTADO_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, chkComercioItemsEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkComercioItemsEstado.Enabled), 5, 0), !bGXsfl_39_Refreshing);
               dynInventarioId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOID_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_39_Refreshing);
               chkComercioRubrosInventarioActiva.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMERCIORUBROSINVENTARIOACTIVA_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, chkComercioRubrosInventarioActiva_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkComercioRubrosInventarioActiva.Enabled), 5, 0), !bGXsfl_39_Refreshing);
               imgprompt_121_Link = cgiGet( "PROMPT_121_"+sGXsfl_39_idx+"Link");
               imgprompt_121_Link = cgiGet( "PROMPT_137_"+sGXsfl_39_idx+"Link");
               if ( ( nRcdExists_116 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal2G116( ) ;
               }
               SendRow2G116( ) ;
               bGXsfl_39_Refreshing = false;
            }
            Gx_mode = sMode116;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A712ComercioProductosREnum = B712ComercioProductosREnum;
            AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount116 = 5;
            nRcdExists_116 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart2G116( ) ;
               while ( RcdFound116 != 0 )
               {
                  sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_39116( ) ;
                  init_level_properties116( ) ;
                  standaloneNotModal2G116( ) ;
                  getByPrimaryKey2G116( ) ;
                  standaloneModal2G116( ) ;
                  AddRow2G116( ) ;
                  ScanNext2G116( ) ;
               }
               ScanEnd2G116( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode116 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx+1), 4, 0), 4, "0");
            SubsflControlProps_39116( ) ;
            InitAll2G116( ) ;
            init_level_properties116( ) ;
            B712ComercioProductosREnum = A712ComercioProductosREnum;
            AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
            nRcdExists_116 = 0;
            nIsMod_116 = 0;
            nRcdDeleted_116 = 0;
            nBlankRcdCount116 = (short)(nBlankRcdUsr116+nBlankRcdCount116);
            fRowAdded = 0;
            while ( nBlankRcdCount116 > 0 )
            {
               standaloneNotModal2G116( ) ;
               standaloneModal2G116( ) ;
               AddRow2G116( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount116 = (short)(nBlankRcdCount116-1);
            }
            Gx_mode = sMode116;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A712ComercioProductosREnum = B712ComercioProductosREnum;
            AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
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
         E112G2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vRUBROSID_DATA"), AV13RubrosId_Data);
               /* Read saved values. */
               Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z282ProveedorNombre = cgiGet( "Z282ProveedorNombre");
               Z344ProveedorEstado = cgiGet( "Z344ProveedorEstado");
               Z712ComercioProductosREnum = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z712ComercioProductosREnum"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z978ProveedorCIU = StringUtil.StrToBool( cgiGet( "Z978ProveedorCIU"));
               A712ComercioProductosREnum = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z712ComercioProductosREnum"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A978ProveedorCIU = StringUtil.StrToBool( cgiGet( "Z978ProveedorCIU"));
               O712ComercioProductosREnum = (long)(Math.Round(context.localUtil.CToN( cgiGet( "O712ComercioProductosREnum"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A978ProveedorCIU = StringUtil.StrToBool( cgiGet( "PROVEEDORCIU"));
               A40000ProveedorImagen_GXI = cgiGet( "PROVEEDORIMAGEN_GXI");
               n40000ProveedorImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
               A712ComercioProductosREnum = (long)(Math.Round(context.localUtil.CToN( cgiGet( "COMERCIOPRODUCTOSRENUM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV18Pgmname = cgiGet( "vPGMNAME");
               A122RubrosNombre = cgiGet( "RUBROSNOMBRE");
               A168RubrosImagen = cgiGet( "RUBROSIMAGEN");
               A40001RubrosImagen_GXI = cgiGet( "RUBROSIMAGEN_GXI");
               A123RubrosEstado = cgiGet( "RUBROSESTADO");
               n123RubrosEstado = false;
               A138MedidasNombre = cgiGet( "MEDIDASNOMBRE");
               A139MedidasEstado = cgiGet( "MEDIDASESTADO");
               n139MedidasEstado = false;
               A136InventarioNombre = cgiGet( "INVENTARIONOMBRE");
               A189InventarioImagen = cgiGet( "INVENTARIOIMAGEN");
               A40002InventarioImagen_GXI = cgiGet( "INVENTARIOIMAGEN_GXI");
               A107EstadosTipo = cgiGet( "ESTADOSTIPO");
               A108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_rubrosid_Objectcall = cgiGet( "COMBO_RUBROSID_Objectcall");
               Combo_rubrosid_Class = cgiGet( "COMBO_RUBROSID_Class");
               Combo_rubrosid_Icontype = cgiGet( "COMBO_RUBROSID_Icontype");
               Combo_rubrosid_Icon = cgiGet( "COMBO_RUBROSID_Icon");
               Combo_rubrosid_Caption = cgiGet( "COMBO_RUBROSID_Caption");
               Combo_rubrosid_Tooltip = cgiGet( "COMBO_RUBROSID_Tooltip");
               Combo_rubrosid_Cls = cgiGet( "COMBO_RUBROSID_Cls");
               Combo_rubrosid_Selectedvalue_set = cgiGet( "COMBO_RUBROSID_Selectedvalue_set");
               Combo_rubrosid_Selectedvalue_get = cgiGet( "COMBO_RUBROSID_Selectedvalue_get");
               Combo_rubrosid_Selectedtext_set = cgiGet( "COMBO_RUBROSID_Selectedtext_set");
               Combo_rubrosid_Selectedtext_get = cgiGet( "COMBO_RUBROSID_Selectedtext_get");
               Combo_rubrosid_Gamoauthtoken = cgiGet( "COMBO_RUBROSID_Gamoauthtoken");
               Combo_rubrosid_Ddointernalname = cgiGet( "COMBO_RUBROSID_Ddointernalname");
               Combo_rubrosid_Titlecontrolalign = cgiGet( "COMBO_RUBROSID_Titlecontrolalign");
               Combo_rubrosid_Dropdownoptionstype = cgiGet( "COMBO_RUBROSID_Dropdownoptionstype");
               Combo_rubrosid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_RUBROSID_Enabled"));
               Combo_rubrosid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_RUBROSID_Visible"));
               Combo_rubrosid_Titlecontrolidtoreplace = cgiGet( "COMBO_RUBROSID_Titlecontrolidtoreplace");
               Combo_rubrosid_Datalisttype = cgiGet( "COMBO_RUBROSID_Datalisttype");
               Combo_rubrosid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_RUBROSID_Allowmultipleselection"));
               Combo_rubrosid_Datalistfixedvalues = cgiGet( "COMBO_RUBROSID_Datalistfixedvalues");
               Combo_rubrosid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_RUBROSID_Isgriditem"));
               Combo_rubrosid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_RUBROSID_Hasdescription"));
               Combo_rubrosid_Datalistproc = cgiGet( "COMBO_RUBROSID_Datalistproc");
               Combo_rubrosid_Datalistprocparametersprefix = cgiGet( "COMBO_RUBROSID_Datalistprocparametersprefix");
               Combo_rubrosid_Remoteservicesparameters = cgiGet( "COMBO_RUBROSID_Remoteservicesparameters");
               Combo_rubrosid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RUBROSID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_rubrosid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_RUBROSID_Includeonlyselectedoption"));
               Combo_rubrosid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_RUBROSID_Includeselectalloption"));
               Combo_rubrosid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_RUBROSID_Emptyitem"));
               Combo_rubrosid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_RUBROSID_Includeaddnewoption"));
               Combo_rubrosid_Htmltemplate = cgiGet( "COMBO_RUBROSID_Htmltemplate");
               Combo_rubrosid_Multiplevaluestype = cgiGet( "COMBO_RUBROSID_Multiplevaluestype");
               Combo_rubrosid_Loadingdata = cgiGet( "COMBO_RUBROSID_Loadingdata");
               Combo_rubrosid_Noresultsfound = cgiGet( "COMBO_RUBROSID_Noresultsfound");
               Combo_rubrosid_Emptyitemtext = cgiGet( "COMBO_RUBROSID_Emptyitemtext");
               Combo_rubrosid_Onlyselectedvalues = cgiGet( "COMBO_RUBROSID_Onlyselectedvalues");
               Combo_rubrosid_Selectalltext = cgiGet( "COMBO_RUBROSID_Selectalltext");
               Combo_rubrosid_Multiplevaluesseparator = cgiGet( "COMBO_RUBROSID_Multiplevaluesseparator");
               Combo_rubrosid_Addnewoptiontext = cgiGet( "COMBO_RUBROSID_Addnewoptiontext");
               Combo_rubrosid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_RUBROSID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gridlevel_rubros_titlescategories_Objectcall = cgiGet( "GRIDLEVEL_RUBROS_TITLESCATEGORIES_Objectcall");
               Gridlevel_rubros_titlescategories_Class = cgiGet( "GRIDLEVEL_RUBROS_TITLESCATEGORIES_Class");
               Gridlevel_rubros_titlescategories_Enabled = StringUtil.StrToBool( cgiGet( "GRIDLEVEL_RUBROS_TITLESCATEGORIES_Enabled"));
               Gridlevel_rubros_titlescategories_Gridinternalname = cgiGet( "GRIDLEVEL_RUBROS_TITLESCATEGORIES_Gridinternalname");
               Gridlevel_rubros_titlescategories_Gridtitlescategories = cgiGet( "GRIDLEVEL_RUBROS_TITLESCATEGORIES_Gridtitlescategories");
               Gridlevel_rubros_titlescategories_Visible = StringUtil.StrToBool( cgiGet( "GRIDLEVEL_RUBROS_TITLESCATEGORIES_Visible"));
               /* Read variables values. */
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n133ProveedorID = false;
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
               AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
               cmbProveedorEstado.Name = cmbProveedorEstado_Internalname;
               cmbProveedorEstado.CurrentValue = cgiGet( cmbProveedorEstado_Internalname);
               A344ProveedorEstado = cgiGet( cmbProveedorEstado_Internalname);
               AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
               A432ProveedorImagen = cgiGet( imgProveedorImagen_Internalname);
               n432ProveedorImagen = false;
               AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProveedorImagen_Internalname, ref  A432ProveedorImagen, ref  A40000ProveedorImagen_GXI);
               n40000ProveedorImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
               n432ProveedorImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ComercioProductos");
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n133ProveedorID = false;
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               forbiddenHiddens.Add("ProveedorID", context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
               A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
               AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
               forbiddenHiddens.Add("ProveedorNombre", StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")));
               A344ProveedorEstado = cgiGet( cmbProveedorEstado_Internalname);
               AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
               forbiddenHiddens.Add("ProveedorEstado", StringUtil.RTrim( context.localUtil.Format( A344ProveedorEstado, "")));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ProveedorCIU", StringUtil.BoolToStr( A978ProveedorCIU));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A133ProveedorID != Z133ProveedorID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("comercioproductos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A133ProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedorID"), "."), 18, MidpointRounding.ToEven));
                  n133ProveedorID = false;
                  AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
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
                     sMode28 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode28;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound28 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2G0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROVEEDORID");
                        AnyError = 1;
                        GX_FocusControl = edtProveedorID_Internalname;
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
                           E112G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122G2 ();
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
            E122G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2G28( ) ;
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
            DisableAttributes2G28( ) ;
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

      protected void CONFIRM_2G0( )
      {
         BeforeValidate2G28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2G28( ) ;
            }
            else
            {
               CheckExtendedTable2G28( ) ;
               CloseExtendedTableCursors2G28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode28 = Gx_mode;
            CONFIRM_2G116( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode28;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_2G116( )
      {
         s712ComercioProductosREnum = O712ComercioProductosREnum;
         AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
         nGXsfl_39_idx = 0;
         while ( nGXsfl_39_idx < nRC_GXsfl_39 )
         {
            ReadRow2G116( ) ;
            if ( ( nRcdExists_116 != 0 ) || ( nIsMod_116 != 0 ) )
            {
               GetKey2G116( ) ;
               if ( ( nRcdExists_116 == 0 ) && ( nRcdDeleted_116 == 0 ) )
               {
                  if ( RcdFound116 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate2G116( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2G116( ) ;
                        CloseExtendedTableCursors2G116( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O712ComercioProductosREnum = A712ComercioProductosREnum;
                        AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
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
                  if ( RcdFound116 != 0 )
                  {
                     if ( nRcdDeleted_116 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey2G116( ) ;
                        Load2G116( ) ;
                        BeforeValidate2G116( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2G116( ) ;
                           O712ComercioProductosREnum = A712ComercioProductosREnum;
                           AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_116 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate2G116( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2G116( ) ;
                              CloseExtendedTableCursors2G116( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O712ComercioProductosREnum = A712ComercioProductosREnum;
                              AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_116 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtComercioProductosRubrosID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A713ComercioProductosRubrosID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbComercioRubrosEstado_Internalname, StringUtil.BoolToStr( A692ComercioRubrosEstado)) ;
            ChangePostValue( dynMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))) ;
            ChangePostValue( chkComercioItemsEstado_Internalname, StringUtil.BoolToStr( A695ComercioItemsEstado)) ;
            ChangePostValue( dynInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))) ;
            ChangePostValue( chkComercioRubrosInventarioActiva_Internalname, StringUtil.BoolToStr( A696ComercioRubrosInventarioActiva)) ;
            ChangePostValue( "ZT_"+"Z713ComercioProductosRubrosID_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z713ComercioProductosRubrosID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z692ComercioRubrosEstado_"+sGXsfl_39_idx, StringUtil.BoolToStr( Z692ComercioRubrosEstado)) ;
            ChangePostValue( "ZT_"+"Z695ComercioItemsEstado_"+sGXsfl_39_idx, StringUtil.BoolToStr( Z695ComercioItemsEstado)) ;
            ChangePostValue( "ZT_"+"Z696ComercioRubrosInventarioActiva_"+sGXsfl_39_idx, StringUtil.BoolToStr( Z696ComercioRubrosInventarioActiva)) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_116_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_116), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_116_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_116), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_116_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_116), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_116 != 0 )
            {
               ChangePostValue( "COMERCIOPRODUCTOSRUBROSID_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComercioProductosRubrosID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSID_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSID_"+sGXsfl_39_idx+"Horizontalalignment", StringUtil.RTrim( edtRubrosId_Horizontalalignment)) ;
               ChangePostValue( "COMERCIORUBROSESTADO_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbComercioRubrosEstado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASID_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COMERCIOITEMSESTADO_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkComercioItemsEstado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOID_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COMERCIORUBROSINVENTARIOACTIVA_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkComercioRubrosInventarioActiva.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O712ComercioProductosREnum = s712ComercioProductosREnum;
         AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption2G0( )
      {
      }

      protected void E112G2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_char1 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and image", out  GXt_char1) ;
         Combo_rubrosid_Htmltemplate = GXt_char1;
         ucCombo_rubrosid.SendProperty(context, "", false, Combo_rubrosid_Internalname, "HTMLTemplate", Combo_rubrosid_Htmltemplate);
         Combo_rubrosid_Titlecontrolidtoreplace = edtRubrosId_Internalname;
         ucCombo_rubrosid.SendProperty(context, "", false, Combo_rubrosid_Internalname, "TitleControlIdToReplace", Combo_rubrosid_Titlecontrolidtoreplace);
         edtRubrosId_Horizontalalignment = "Left";
         AssignProp("", false, edtRubrosId_Internalname, "Horizontalalignment", edtRubrosId_Horizontalalignment, !bGXsfl_39_Refreshing);
         /* Execute user subroutine: 'LOADCOMBORUBROSID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean2 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercioProductos_Insert", out  GXt_boolean2) ;
            AV9IsAuthorized = GXt_boolean2;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean2 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercioProductos_Update", out  GXt_boolean2) ;
            AV9IsAuthorized = GXt_boolean2;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean2 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComercioProductos_Delete", out  GXt_boolean2) ;
            AV9IsAuthorized = GXt_boolean2;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV18Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         Gridlevel_rubros_titlescategories_Gridinternalname = subGridlevel_rubros_Internalname;
         ucGridlevel_rubros_titlescategories.SendProperty(context, "", false, Gridlevel_rubros_titlescategories_Internalname, "GridInternalName", Gridlevel_rubros_titlescategories_Gridinternalname);
         Gridlevel_rubros_titlescategories_Gridtitlescategories = StringUtil.Format( ";;%1;%1;%2;%2;%3;%3", context.GetMessage( "Rubros del Comercio", ""), context.GetMessage( "Listado de Items", ""), context.GetMessage( "SERVICIO", ""), "", "", "", "", "", "");
         ucGridlevel_rubros_titlescategories.SendProperty(context, "", false, Gridlevel_rubros_titlescategories_Internalname, "GridTitlesCategories", Gridlevel_rubros_titlescategories_Gridtitlescategories);
      }

      protected void E122G2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBORUBROSID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item3 = AV13RubrosId_Data;
         new comercioproductosloaddvcombo(context ).execute(  "RubrosId",  Gx_mode,  AV7ProveedorID, out  AV14ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item3) ;
         AV13RubrosId_Data = GXt_objcol_SdtDVB_SDTComboData_Item3;
      }

      protected void ZM2G28( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z282ProveedorNombre = T002G8_A282ProveedorNombre[0];
               Z344ProveedorEstado = T002G8_A344ProveedorEstado[0];
               Z712ComercioProductosREnum = T002G8_A712ComercioProductosREnum[0];
               Z978ProveedorCIU = T002G8_A978ProveedorCIU[0];
            }
            else
            {
               Z282ProveedorNombre = A282ProveedorNombre;
               Z344ProveedorEstado = A344ProveedorEstado;
               Z712ComercioProductosREnum = A712ComercioProductosREnum;
               Z978ProveedorCIU = A978ProveedorCIU;
            }
         }
         if ( GX_JID == -15 )
         {
            Z133ProveedorID = A133ProveedorID;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z432ProveedorImagen = A432ProveedorImagen;
            Z40000ProveedorImagen_GXI = A40000ProveedorImagen_GXI;
            Z344ProveedorEstado = A344ProveedorEstado;
            Z712ComercioProductosREnum = A712ComercioProductosREnum;
            Z978ProveedorCIU = A978ProveedorCIU;
         }
      }

      protected void standaloneNotModal( )
      {
         imgProveedorImagen_Enabled = 0;
         AssignProp("", false, imgProveedorImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProveedorImagen_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         cmbProveedorEstado.Enabled = 0;
         AssignProp("", false, cmbProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Enabled), 5, 0), true);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgProveedorImagen_Enabled = 0;
         AssignProp("", false, imgProveedorImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProveedorImagen_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         cmbProveedorEstado.Enabled = 0;
         AssignProp("", false, cmbProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Enabled), 5, 0), true);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ProveedorID) )
         {
            A133ProveedorID = AV7ProveedorID;
            n133ProveedorID = false;
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
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
         if ( IsIns( )  && (false==A978ProveedorCIU) && ( Gx_BScreen == 0 ) )
         {
            A978ProveedorCIU = false;
            AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
         }
      }

      protected void Load2G28( )
      {
         /* Using cursor T002G9 */
         pr_default.execute(7, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound28 = 1;
            A282ProveedorNombre = T002G9_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A40000ProveedorImagen_GXI = T002G9_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = T002G9_n40000ProveedorImagen_GXI[0];
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A344ProveedorEstado = T002G9_A344ProveedorEstado[0];
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
            A712ComercioProductosREnum = T002G9_A712ComercioProductosREnum[0];
            A978ProveedorCIU = T002G9_A978ProveedorCIU[0];
            A432ProveedorImagen = T002G9_A432ProveedorImagen[0];
            n432ProveedorImagen = T002G9_n432ProveedorImagen[0];
            AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            ZM2G28( -15) ;
         }
         pr_default.close(7);
         OnLoadActions2G28( ) ;
      }

      protected void OnLoadActions2G28( )
      {
         AV18Pgmname = "ComercioProductos";
         AssignAttri("", false, "AV18Pgmname", AV18Pgmname);
      }

      protected void CheckExtendedTable2G28( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV18Pgmname = "ComercioProductos";
         AssignAttri("", false, "AV18Pgmname", AV18Pgmname);
      }

      protected void CloseExtendedTableCursors2G28( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2G28( )
      {
         /* Using cursor T002G10 */
         pr_default.execute(8, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002G8 */
         pr_default.execute(6, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM2G28( 15) ;
            RcdFound28 = 1;
            A133ProveedorID = T002G8_A133ProveedorID[0];
            n133ProveedorID = T002G8_n133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            A282ProveedorNombre = T002G8_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A40000ProveedorImagen_GXI = T002G8_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = T002G8_n40000ProveedorImagen_GXI[0];
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A344ProveedorEstado = T002G8_A344ProveedorEstado[0];
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
            A712ComercioProductosREnum = T002G8_A712ComercioProductosREnum[0];
            A978ProveedorCIU = T002G8_A978ProveedorCIU[0];
            A432ProveedorImagen = T002G8_A432ProveedorImagen[0];
            n432ProveedorImagen = T002G8_n432ProveedorImagen[0];
            AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            O712ComercioProductosREnum = A712ComercioProductosREnum;
            AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
            Z133ProveedorID = A133ProveedorID;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2G28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey2G28( ) ;
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey2G28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey2G28( ) ;
         if ( RcdFound28 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound28 = 0;
         /* Using cursor T002G11 */
         pr_default.execute(9, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002G11_A133ProveedorID[0] < A133ProveedorID ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002G11_A133ProveedorID[0] > A133ProveedorID ) ) )
            {
               A133ProveedorID = T002G11_A133ProveedorID[0];
               n133ProveedorID = T002G11_n133ProveedorID[0];
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound28 = 0;
         /* Using cursor T002G12 */
         pr_default.execute(10, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T002G12_A133ProveedorID[0] > A133ProveedorID ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T002G12_A133ProveedorID[0] < A133ProveedorID ) ) )
            {
               A133ProveedorID = T002G12_A133ProveedorID[0];
               n133ProveedorID = T002G12_n133ProveedorID[0];
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2G28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A712ComercioProductosREnum = O712ComercioProductosREnum;
            AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
            Insert2G28( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( A133ProveedorID != Z133ProveedorID )
               {
                  A133ProveedorID = Z133ProveedorID;
                  n133ProveedorID = false;
                  AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROVEEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtProveedorID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A712ComercioProductosREnum = O712ComercioProductosREnum;
                  AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  /* Update record */
                  A712ComercioProductosREnum = O712ComercioProductosREnum;
                  AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
                  Update2G28( ) ;
               }
            }
            else
            {
               if ( A133ProveedorID != Z133ProveedorID )
               {
                  /* Insert record */
                  A712ComercioProductosREnum = O712ComercioProductosREnum;
                  AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
                  Insert2G28( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROVEEDORID");
                     AnyError = 1;
                     GX_FocusControl = edtProveedorID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A712ComercioProductosREnum = O712ComercioProductosREnum;
                     AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
                     Insert2G28( ) ;
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
         if ( A133ProveedorID != Z133ProveedorID )
         {
            A133ProveedorID = Z133ProveedorID;
            n133ProveedorID = false;
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROVEEDORID");
            AnyError = 1;
            GX_FocusControl = edtProveedorID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A712ComercioProductosREnum = O712ComercioProductosREnum;
            AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
            delete( ) ;
            AfterTrn( ) ;
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2G28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002G7 */
            pr_default.execute(5, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(5) == 101) || ( StringUtil.StrCmp(Z282ProveedorNombre, T002G7_A282ProveedorNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z344ProveedorEstado, T002G7_A344ProveedorEstado[0]) != 0 ) || ( Z712ComercioProductosREnum != T002G7_A712ComercioProductosREnum[0] ) || ( Z978ProveedorCIU != T002G7_A978ProveedorCIU[0] ) )
            {
               if ( StringUtil.StrCmp(Z282ProveedorNombre, T002G7_A282ProveedorNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("comercioproductos:[seudo value changed for attri]"+"ProveedorNombre");
                  GXUtil.WriteLogRaw("Old: ",Z282ProveedorNombre);
                  GXUtil.WriteLogRaw("Current: ",T002G7_A282ProveedorNombre[0]);
               }
               if ( StringUtil.StrCmp(Z344ProveedorEstado, T002G7_A344ProveedorEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("comercioproductos:[seudo value changed for attri]"+"ProveedorEstado");
                  GXUtil.WriteLogRaw("Old: ",Z344ProveedorEstado);
                  GXUtil.WriteLogRaw("Current: ",T002G7_A344ProveedorEstado[0]);
               }
               if ( Z712ComercioProductosREnum != T002G7_A712ComercioProductosREnum[0] )
               {
                  GXUtil.WriteLog("comercioproductos:[seudo value changed for attri]"+"ComercioProductosREnum");
                  GXUtil.WriteLogRaw("Old: ",Z712ComercioProductosREnum);
                  GXUtil.WriteLogRaw("Current: ",T002G7_A712ComercioProductosREnum[0]);
               }
               if ( Z978ProveedorCIU != T002G7_A978ProveedorCIU[0] )
               {
                  GXUtil.WriteLog("comercioproductos:[seudo value changed for attri]"+"ProveedorCIU");
                  GXUtil.WriteLogRaw("Old: ",Z978ProveedorCIU);
                  GXUtil.WriteLogRaw("Current: ",T002G7_A978ProveedorCIU[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proveedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2G28( )
      {
         BeforeValidate2G28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2G28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2G28( 0) ;
            CheckOptimisticConcurrency2G28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2G28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2G28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002G13 */
                     pr_default.execute(11, new Object[] {A282ProveedorNombre, n432ProveedorImagen, A432ProveedorImagen, n40000ProveedorImagen_GXI, A40000ProveedorImagen_GXI, A344ProveedorEstado, A712ComercioProductosREnum, A978ProveedorCIU});
                     A133ProveedorID = T002G13_A133ProveedorID[0];
                     n133ProveedorID = T002G13_n133ProveedorID[0];
                     AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2G28( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption2G0( ) ;
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
               Load2G28( ) ;
            }
            EndLevel2G28( ) ;
         }
         CloseExtendedTableCursors2G28( ) ;
      }

      protected void Update2G28( )
      {
         BeforeValidate2G28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2G28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2G28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2G28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2G28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002G14 */
                     pr_default.execute(12, new Object[] {A282ProveedorNombre, A344ProveedorEstado, A712ComercioProductosREnum, A978ProveedorCIU, n133ProveedorID, A133ProveedorID});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2G28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2G28( ) ;
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
            EndLevel2G28( ) ;
         }
         CloseExtendedTableCursors2G28( ) ;
      }

      protected void DeferredUpdate2G28( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T002G15 */
            pr_default.execute(13, new Object[] {n432ProveedorImagen, A432ProveedorImagen, n40000ProveedorImagen_GXI, A40000ProveedorImagen_GXI, n133ProveedorID, A133ProveedorID});
            pr_default.close(13);
            pr_default.SmartCacheProvider.SetUpdated("Proveedor");
         }
      }

      protected void delete( )
      {
         BeforeValidate2G28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2G28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2G28( ) ;
            AfterConfirm2G28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2G28( ) ;
               if ( AnyError == 0 )
               {
                  A712ComercioProductosREnum = O712ComercioProductosREnum;
                  AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
                  ScanStart2G116( ) ;
                  while ( RcdFound116 != 0 )
                  {
                     getByPrimaryKey2G116( ) ;
                     Delete2G116( ) ;
                     ScanNext2G116( ) ;
                     O712ComercioProductosREnum = A712ComercioProductosREnum;
                     AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
                  }
                  ScanEnd2G116( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002G16 */
                     pr_default.execute(14, new Object[] {n133ProveedorID, A133ProveedorID});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2G28( ) ;
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2G28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV18Pgmname = "ComercioProductos";
            AssignAttri("", false, "AV18Pgmname", AV18Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002G17 */
            pr_default.execute(15, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Postulaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T002G18 */
            pr_default.execute(16, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")+" ("+context.GetMessage( "Comercios SubTipo", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T002G19 */
            pr_default.execute(17, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T002G20 */
            pr_default.execute(18, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Vincular Trn", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T002G21 */
            pr_default.execute(19, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T002G22 */
            pr_default.execute(20, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")+" ("+context.GetMessage( "Comercios SubTipo", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T002G23 */
            pr_default.execute(21, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T002G24 */
            pr_default.execute(22, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupacion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T002G25 */
            pr_default.execute(23, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T002G26 */
            pr_default.execute(24, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comercio | Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T002G27 */
            pr_default.execute(25, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T002G28 */
            pr_default.execute(26, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comisiones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
         }
      }

      protected void ProcessNestedLevel2G116( )
      {
         s712ComercioProductosREnum = O712ComercioProductosREnum;
         AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
         nGXsfl_39_idx = 0;
         while ( nGXsfl_39_idx < nRC_GXsfl_39 )
         {
            ReadRow2G116( ) ;
            if ( ( nRcdExists_116 != 0 ) || ( nIsMod_116 != 0 ) )
            {
               standaloneNotModal2G116( ) ;
               GetKey2G116( ) ;
               if ( ( nRcdExists_116 == 0 ) && ( nRcdDeleted_116 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert2G116( ) ;
               }
               else
               {
                  if ( RcdFound116 != 0 )
                  {
                     if ( ( nRcdDeleted_116 != 0 ) && ( nRcdExists_116 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete2G116( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_116 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update2G116( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_116 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O712ComercioProductosREnum = A712ComercioProductosREnum;
               AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
            }
            ChangePostValue( edtComercioProductosRubrosID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A713ComercioProductosRubrosID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbComercioRubrosEstado_Internalname, StringUtil.BoolToStr( A692ComercioRubrosEstado)) ;
            ChangePostValue( dynMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))) ;
            ChangePostValue( chkComercioItemsEstado_Internalname, StringUtil.BoolToStr( A695ComercioItemsEstado)) ;
            ChangePostValue( dynInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))) ;
            ChangePostValue( chkComercioRubrosInventarioActiva_Internalname, StringUtil.BoolToStr( A696ComercioRubrosInventarioActiva)) ;
            ChangePostValue( "ZT_"+"Z713ComercioProductosRubrosID_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z713ComercioProductosRubrosID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z692ComercioRubrosEstado_"+sGXsfl_39_idx, StringUtil.BoolToStr( Z692ComercioRubrosEstado)) ;
            ChangePostValue( "ZT_"+"Z695ComercioItemsEstado_"+sGXsfl_39_idx, StringUtil.BoolToStr( Z695ComercioItemsEstado)) ;
            ChangePostValue( "ZT_"+"Z696ComercioRubrosInventarioActiva_"+sGXsfl_39_idx, StringUtil.BoolToStr( Z696ComercioRubrosInventarioActiva)) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_116_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_116), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_116_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_116), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_116_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_116), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_116 != 0 )
            {
               ChangePostValue( "COMERCIOPRODUCTOSRUBROSID_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComercioProductosRubrosID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSID_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSID_"+sGXsfl_39_idx+"Horizontalalignment", StringUtil.RTrim( edtRubrosId_Horizontalalignment)) ;
               ChangePostValue( "COMERCIORUBROSESTADO_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbComercioRubrosEstado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASID_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COMERCIOITEMSESTADO_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkComercioItemsEstado.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOID_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "COMERCIORUBROSINVENTARIOACTIVA_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkComercioRubrosInventarioActiva.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2G116( ) ;
         if ( AnyError != 0 )
         {
            O712ComercioProductosREnum = s712ComercioProductosREnum;
            AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
         }
         nRcdExists_116 = 0;
         nIsMod_116 = 0;
         nRcdDeleted_116 = 0;
      }

      protected void ProcessLevel2G28( )
      {
         /* Save parent mode. */
         sMode28 = Gx_mode;
         ProcessNestedLevel2G116( ) ;
         if ( AnyError != 0 )
         {
            O712ComercioProductosREnum = s712ComercioProductosREnum;
            AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T002G29 */
         pr_default.execute(27, new Object[] {A712ComercioProductosREnum, n133ProveedorID, A133ProveedorID});
         pr_default.close(27);
         pr_default.SmartCacheProvider.SetUpdated("Proveedor");
      }

      protected void EndLevel2G28( )
      {
         pr_default.close(5);
         if ( AnyError == 0 )
         {
            BeforeComplete2G28( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(6);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            pr_default.close(3);
            pr_default.close(4);
            context.CommitDataStores("comercioproductos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2G0( ) ;
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
            context.RollbackDataStores("comercioproductos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2G28( )
      {
         /* Scan By routine */
         /* Using cursor T002G30 */
         pr_default.execute(28);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound28 = 1;
            A133ProveedorID = T002G30_A133ProveedorID[0];
            n133ProveedorID = T002G30_n133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2G28( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound28 = 1;
            A133ProveedorID = T002G30_A133ProveedorID[0];
            n133ProveedorID = T002G30_n133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
      }

      protected void ScanEnd2G28( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm2G28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2G28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2G28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2G28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2G28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2G28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2G28( )
      {
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         cmbProveedorEstado.Enabled = 0;
         AssignProp("", false, cmbProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Enabled), 5, 0), true);
         imgProveedorImagen_Enabled = 0;
         AssignProp("", false, imgProveedorImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProveedorImagen_Enabled), 5, 0), true);
      }

      protected void ZM2G116( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z692ComercioRubrosEstado = T002G3_A692ComercioRubrosEstado[0];
               Z695ComercioItemsEstado = T002G3_A695ComercioItemsEstado[0];
               Z696ComercioRubrosInventarioActiva = T002G3_A696ComercioRubrosInventarioActiva[0];
               Z121RubrosId = T002G3_A121RubrosId[0];
               Z137MedidasID = T002G3_A137MedidasID[0];
               Z135InventarioId = T002G3_A135InventarioId[0];
            }
            else
            {
               Z692ComercioRubrosEstado = A692ComercioRubrosEstado;
               Z695ComercioItemsEstado = A695ComercioItemsEstado;
               Z696ComercioRubrosInventarioActiva = A696ComercioRubrosInventarioActiva;
               Z121RubrosId = A121RubrosId;
               Z137MedidasID = A137MedidasID;
               Z135InventarioId = A135InventarioId;
            }
         }
         if ( GX_JID == -16 )
         {
            Z133ProveedorID = A133ProveedorID;
            Z713ComercioProductosRubrosID = A713ComercioProductosRubrosID;
            Z692ComercioRubrosEstado = A692ComercioRubrosEstado;
            Z695ComercioItemsEstado = A695ComercioItemsEstado;
            Z696ComercioRubrosInventarioActiva = A696ComercioRubrosInventarioActiva;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            Z122RubrosNombre = A122RubrosNombre;
            Z168RubrosImagen = A168RubrosImagen;
            Z40001RubrosImagen_GXI = A40001RubrosImagen_GXI;
            Z123RubrosEstado = A123RubrosEstado;
            Z138MedidasNombre = A138MedidasNombre;
            Z139MedidasEstado = A139MedidasEstado;
            Z136InventarioNombre = A136InventarioNombre;
            Z189InventarioImagen = A189InventarioImagen;
            Z40002InventarioImagen_GXI = A40002InventarioImagen_GXI;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
         }
      }

      protected void standaloneNotModal2G116( )
      {
         edtComercioProductosRubrosID_Enabled = 0;
         AssignProp("", false, edtComercioProductosRubrosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComercioProductosRubrosID_Enabled), 5, 0), !bGXsfl_39_Refreshing);
      }

      protected void standaloneModal2G116( )
      {
         if ( IsIns( )  )
         {
            A712ComercioProductosREnum = (long)(O712ComercioProductosREnum+1);
            AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A713ComercioProductosRubrosID = A712ComercioProductosREnum;
         }
         if ( IsIns( )  && (false==A692ComercioRubrosEstado) && ( Gx_BScreen == 0 ) )
         {
            A692ComercioRubrosEstado = true;
            n692ComercioRubrosEstado = false;
         }
         if ( IsIns( )  && (false==A695ComercioItemsEstado) && ( Gx_BScreen == 0 ) )
         {
            A695ComercioItemsEstado = true;
            n695ComercioItemsEstado = false;
         }
         if ( IsIns( )  && (false==A696ComercioRubrosInventarioActiva) && ( Gx_BScreen == 0 ) )
         {
            A696ComercioRubrosInventarioActiva = true;
            n696ComercioRubrosInventarioActiva = false;
         }
      }

      protected void Load2G116( )
      {
         /* Using cursor T002G31 */
         pr_default.execute(29, new Object[] {n133ProveedorID, A133ProveedorID, A713ComercioProductosRubrosID});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound116 = 1;
            A692ComercioRubrosEstado = T002G31_A692ComercioRubrosEstado[0];
            n692ComercioRubrosEstado = T002G31_n692ComercioRubrosEstado[0];
            A695ComercioItemsEstado = T002G31_A695ComercioItemsEstado[0];
            n695ComercioItemsEstado = T002G31_n695ComercioItemsEstado[0];
            A696ComercioRubrosInventarioActiva = T002G31_A696ComercioRubrosInventarioActiva[0];
            n696ComercioRubrosInventarioActiva = T002G31_n696ComercioRubrosInventarioActiva[0];
            A122RubrosNombre = T002G31_A122RubrosNombre[0];
            A40001RubrosImagen_GXI = T002G31_A40001RubrosImagen_GXI[0];
            A123RubrosEstado = T002G31_A123RubrosEstado[0];
            n123RubrosEstado = T002G31_n123RubrosEstado[0];
            A138MedidasNombre = T002G31_A138MedidasNombre[0];
            A139MedidasEstado = T002G31_A139MedidasEstado[0];
            n139MedidasEstado = T002G31_n139MedidasEstado[0];
            A136InventarioNombre = T002G31_A136InventarioNombre[0];
            A40002InventarioImagen_GXI = T002G31_A40002InventarioImagen_GXI[0];
            A121RubrosId = T002G31_A121RubrosId[0];
            A137MedidasID = T002G31_A137MedidasID[0];
            n137MedidasID = T002G31_n137MedidasID[0];
            A135InventarioId = T002G31_A135InventarioId[0];
            n135InventarioId = T002G31_n135InventarioId[0];
            A107EstadosTipo = T002G31_A107EstadosTipo[0];
            A108EstadosGenericosId = T002G31_A108EstadosGenericosId[0];
            A168RubrosImagen = T002G31_A168RubrosImagen[0];
            A189InventarioImagen = T002G31_A189InventarioImagen[0];
            ZM2G116( -16) ;
         }
         pr_default.close(29);
         OnLoadActions2G116( ) ;
      }

      protected void OnLoadActions2G116( )
      {
         GXAMEDIDASID_html2G116( A121RubrosId) ;
         GXAINVENTARIOID_html2G116( A121RubrosId, A137MedidasID) ;
      }

      protected void CheckExtendedTable2G116( )
      {
         nIsDirty_116 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal2G116( ) ;
         /* Using cursor T002G4 */
         pr_default.execute(2, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_39_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A122RubrosNombre = T002G4_A122RubrosNombre[0];
         A40001RubrosImagen_GXI = T002G4_A40001RubrosImagen_GXI[0];
         A123RubrosEstado = T002G4_A123RubrosEstado[0];
         n123RubrosEstado = T002G4_n123RubrosEstado[0];
         A168RubrosImagen = T002G4_A168RubrosImagen[0];
         pr_default.close(2);
         /* Using cursor T002G5 */
         pr_default.execute(3, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) ) )
            {
               GXCCtl = "MEDIDASID_" + sGXsfl_39_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A138MedidasNombre = T002G5_A138MedidasNombre[0];
         A139MedidasEstado = T002G5_A139MedidasEstado[0];
         n139MedidasEstado = T002G5_n139MedidasEstado[0];
         pr_default.close(3);
         /* Using cursor T002G6 */
         pr_default.execute(4, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) || (0==A135InventarioId) ) )
            {
               GXCCtl = "INVENTARIOID_" + sGXsfl_39_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A136InventarioNombre = T002G6_A136InventarioNombre[0];
         A40002InventarioImagen_GXI = T002G6_A40002InventarioImagen_GXI[0];
         A107EstadosTipo = T002G6_A107EstadosTipo[0];
         A108EstadosGenericosId = T002G6_A108EstadosGenericosId[0];
         A189InventarioImagen = T002G6_A189InventarioImagen[0];
         pr_default.close(4);
         GXAMEDIDASID_html2G116( A121RubrosId) ;
         GXAINVENTARIOID_html2G116( A121RubrosId, A137MedidasID) ;
      }

      protected void CloseExtendedTableCursors2G116( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable2G116( )
      {
      }

      protected void gxLoad_17( short A121RubrosId )
      {
         /* Using cursor T002G32 */
         pr_default.execute(30, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_39_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A122RubrosNombre = T002G32_A122RubrosNombre[0];
         A40001RubrosImagen_GXI = T002G32_A40001RubrosImagen_GXI[0];
         A123RubrosEstado = T002G32_A123RubrosEstado[0];
         n123RubrosEstado = T002G32_n123RubrosEstado[0];
         A168RubrosImagen = T002G32_A168RubrosImagen[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A122RubrosNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( A168RubrosImagen)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40001RubrosImagen_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A123RubrosEstado))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(30) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(30);
      }

      protected void gxLoad_18( short A121RubrosId ,
                                long A137MedidasID )
      {
         /* Using cursor T002G33 */
         pr_default.execute(31, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         if ( (pr_default.getStatus(31) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) ) )
            {
               GXCCtl = "MEDIDASID_" + sGXsfl_39_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A138MedidasNombre = T002G33_A138MedidasNombre[0];
         A139MedidasEstado = T002G33_A139MedidasEstado[0];
         n139MedidasEstado = T002G33_n139MedidasEstado[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A138MedidasNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A139MedidasEstado))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(31) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(31);
      }

      protected void gxLoad_19( short A121RubrosId ,
                                long A137MedidasID ,
                                long A135InventarioId )
      {
         /* Using cursor T002G34 */
         pr_default.execute(32, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) || (0==A135InventarioId) ) )
            {
               GXCCtl = "INVENTARIOID_" + sGXsfl_39_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A136InventarioNombre = T002G34_A136InventarioNombre[0];
         A40002InventarioImagen_GXI = T002G34_A40002InventarioImagen_GXI[0];
         A107EstadosTipo = T002G34_A107EstadosTipo[0];
         A108EstadosGenericosId = T002G34_A108EstadosGenericosId[0];
         A189InventarioImagen = T002G34_A189InventarioImagen[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A136InventarioNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( A189InventarioImagen)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40002InventarioImagen_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A107EstadosTipo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(32) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(32);
      }

      protected void GetKey2G116( )
      {
         /* Using cursor T002G35 */
         pr_default.execute(33, new Object[] {n133ProveedorID, A133ProveedorID, A713ComercioProductosRubrosID});
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound116 = 1;
         }
         else
         {
            RcdFound116 = 0;
         }
         pr_default.close(33);
      }

      protected void getByPrimaryKey2G116( )
      {
         /* Using cursor T002G3 */
         pr_default.execute(1, new Object[] {n133ProveedorID, A133ProveedorID, A713ComercioProductosRubrosID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2G116( 16) ;
            RcdFound116 = 1;
            InitializeNonKey2G116( ) ;
            A713ComercioProductosRubrosID = T002G3_A713ComercioProductosRubrosID[0];
            A692ComercioRubrosEstado = T002G3_A692ComercioRubrosEstado[0];
            n692ComercioRubrosEstado = T002G3_n692ComercioRubrosEstado[0];
            A695ComercioItemsEstado = T002G3_A695ComercioItemsEstado[0];
            n695ComercioItemsEstado = T002G3_n695ComercioItemsEstado[0];
            A696ComercioRubrosInventarioActiva = T002G3_A696ComercioRubrosInventarioActiva[0];
            n696ComercioRubrosInventarioActiva = T002G3_n696ComercioRubrosInventarioActiva[0];
            A121RubrosId = T002G3_A121RubrosId[0];
            A137MedidasID = T002G3_A137MedidasID[0];
            n137MedidasID = T002G3_n137MedidasID[0];
            A135InventarioId = T002G3_A135InventarioId[0];
            n135InventarioId = T002G3_n135InventarioId[0];
            Z133ProveedorID = A133ProveedorID;
            Z713ComercioProductosRubrosID = A713ComercioProductosRubrosID;
            sMode116 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2G116( ) ;
            Gx_mode = sMode116;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound116 = 0;
            InitializeNonKey2G116( ) ;
            sMode116 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2G116( ) ;
            Gx_mode = sMode116;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2G116( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2G116( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002G2 */
            pr_default.execute(0, new Object[] {n133ProveedorID, A133ProveedorID, A713ComercioProductosRubrosID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComercioProductosRubros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z692ComercioRubrosEstado != T002G2_A692ComercioRubrosEstado[0] ) || ( Z695ComercioItemsEstado != T002G2_A695ComercioItemsEstado[0] ) || ( Z696ComercioRubrosInventarioActiva != T002G2_A696ComercioRubrosInventarioActiva[0] ) || ( Z121RubrosId != T002G2_A121RubrosId[0] ) || ( Z137MedidasID != T002G2_A137MedidasID[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z135InventarioId != T002G2_A135InventarioId[0] ) )
            {
               if ( Z692ComercioRubrosEstado != T002G2_A692ComercioRubrosEstado[0] )
               {
                  GXUtil.WriteLog("comercioproductos:[seudo value changed for attri]"+"ComercioRubrosEstado");
                  GXUtil.WriteLogRaw("Old: ",Z692ComercioRubrosEstado);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A692ComercioRubrosEstado[0]);
               }
               if ( Z695ComercioItemsEstado != T002G2_A695ComercioItemsEstado[0] )
               {
                  GXUtil.WriteLog("comercioproductos:[seudo value changed for attri]"+"ComercioItemsEstado");
                  GXUtil.WriteLogRaw("Old: ",Z695ComercioItemsEstado);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A695ComercioItemsEstado[0]);
               }
               if ( Z696ComercioRubrosInventarioActiva != T002G2_A696ComercioRubrosInventarioActiva[0] )
               {
                  GXUtil.WriteLog("comercioproductos:[seudo value changed for attri]"+"ComercioRubrosInventarioActiva");
                  GXUtil.WriteLogRaw("Old: ",Z696ComercioRubrosInventarioActiva);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A696ComercioRubrosInventarioActiva[0]);
               }
               if ( Z121RubrosId != T002G2_A121RubrosId[0] )
               {
                  GXUtil.WriteLog("comercioproductos:[seudo value changed for attri]"+"RubrosId");
                  GXUtil.WriteLogRaw("Old: ",Z121RubrosId);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A121RubrosId[0]);
               }
               if ( Z137MedidasID != T002G2_A137MedidasID[0] )
               {
                  GXUtil.WriteLog("comercioproductos:[seudo value changed for attri]"+"MedidasID");
                  GXUtil.WriteLogRaw("Old: ",Z137MedidasID);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A137MedidasID[0]);
               }
               if ( Z135InventarioId != T002G2_A135InventarioId[0] )
               {
                  GXUtil.WriteLog("comercioproductos:[seudo value changed for attri]"+"InventarioId");
                  GXUtil.WriteLogRaw("Old: ",Z135InventarioId);
                  GXUtil.WriteLogRaw("Current: ",T002G2_A135InventarioId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ComercioProductosRubros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2G116( )
      {
         BeforeValidate2G116( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2G116( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2G116( 0) ;
            CheckOptimisticConcurrency2G116( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2G116( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2G116( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002G36 */
                     pr_default.execute(34, new Object[] {n133ProveedorID, A133ProveedorID, A713ComercioProductosRubrosID, n692ComercioRubrosEstado, A692ComercioRubrosEstado, n695ComercioItemsEstado, A695ComercioItemsEstado, n696ComercioRubrosInventarioActiva, A696ComercioRubrosInventarioActiva, A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
                     pr_default.close(34);
                     pr_default.SmartCacheProvider.SetUpdated("ComercioProductosRubros");
                     if ( (pr_default.getStatus(34) == 1) )
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
               Load2G116( ) ;
            }
            EndLevel2G116( ) ;
         }
         CloseExtendedTableCursors2G116( ) ;
      }

      protected void Update2G116( )
      {
         BeforeValidate2G116( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2G116( ) ;
         }
         if ( ( nIsMod_116 != 0 ) || ( nIsDirty_116 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency2G116( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm2G116( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate2G116( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T002G37 */
                        pr_default.execute(35, new Object[] {n692ComercioRubrosEstado, A692ComercioRubrosEstado, n695ComercioItemsEstado, A695ComercioItemsEstado, n696ComercioRubrosInventarioActiva, A696ComercioRubrosInventarioActiva, A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId, n133ProveedorID, A133ProveedorID, A713ComercioProductosRubrosID});
                        pr_default.close(35);
                        pr_default.SmartCacheProvider.SetUpdated("ComercioProductosRubros");
                        if ( (pr_default.getStatus(35) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ComercioProductosRubros"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate2G116( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey2G116( ) ;
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
               EndLevel2G116( ) ;
            }
         }
         CloseExtendedTableCursors2G116( ) ;
      }

      protected void DeferredUpdate2G116( )
      {
      }

      protected void Delete2G116( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2G116( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2G116( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2G116( ) ;
            AfterConfirm2G116( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2G116( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002G38 */
                  pr_default.execute(36, new Object[] {n133ProveedorID, A133ProveedorID, A713ComercioProductosRubrosID});
                  pr_default.close(36);
                  pr_default.SmartCacheProvider.SetUpdated("ComercioProductosRubros");
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
         sMode116 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2G116( ) ;
         Gx_mode = sMode116;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2G116( )
      {
         standaloneModal2G116( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002G39 */
            pr_default.execute(37, new Object[] {A121RubrosId});
            A122RubrosNombre = T002G39_A122RubrosNombre[0];
            A40001RubrosImagen_GXI = T002G39_A40001RubrosImagen_GXI[0];
            A123RubrosEstado = T002G39_A123RubrosEstado[0];
            n123RubrosEstado = T002G39_n123RubrosEstado[0];
            A168RubrosImagen = T002G39_A168RubrosImagen[0];
            pr_default.close(37);
            GXAMEDIDASID_html2G116( A121RubrosId) ;
            /* Using cursor T002G40 */
            pr_default.execute(38, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
            A138MedidasNombre = T002G40_A138MedidasNombre[0];
            A139MedidasEstado = T002G40_A139MedidasEstado[0];
            n139MedidasEstado = T002G40_n139MedidasEstado[0];
            pr_default.close(38);
            GXAINVENTARIOID_html2G116( A121RubrosId, A137MedidasID) ;
            /* Using cursor T002G41 */
            pr_default.execute(39, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
            A136InventarioNombre = T002G41_A136InventarioNombre[0];
            A40002InventarioImagen_GXI = T002G41_A40002InventarioImagen_GXI[0];
            A107EstadosTipo = T002G41_A107EstadosTipo[0];
            A108EstadosGenericosId = T002G41_A108EstadosGenericosId[0];
            A189InventarioImagen = T002G41_A189InventarioImagen[0];
            pr_default.close(39);
         }
      }

      protected void EndLevel2G116( )
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

      public void ScanStart2G116( )
      {
         /* Scan By routine */
         /* Using cursor T002G42 */
         pr_default.execute(40, new Object[] {n133ProveedorID, A133ProveedorID});
         RcdFound116 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound116 = 1;
            A713ComercioProductosRubrosID = T002G42_A713ComercioProductosRubrosID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2G116( )
      {
         /* Scan next routine */
         pr_default.readNext(40);
         RcdFound116 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound116 = 1;
            A713ComercioProductosRubrosID = T002G42_A713ComercioProductosRubrosID[0];
         }
      }

      protected void ScanEnd2G116( )
      {
         pr_default.close(40);
      }

      protected void AfterConfirm2G116( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2G116( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2G116( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2G116( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2G116( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2G116( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2G116( )
      {
         edtComercioProductosRubrosID_Enabled = 0;
         AssignProp("", false, edtComercioProductosRubrosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComercioProductosRubrosID_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtRubrosId_Enabled = 0;
         AssignProp("", false, edtRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosId_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         cmbComercioRubrosEstado.Enabled = 0;
         AssignProp("", false, cmbComercioRubrosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbComercioRubrosEstado.Enabled), 5, 0), !bGXsfl_39_Refreshing);
         dynMedidasID.Enabled = 0;
         AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_39_Refreshing);
         chkComercioItemsEstado.Enabled = 0;
         AssignProp("", false, chkComercioItemsEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkComercioItemsEstado.Enabled), 5, 0), !bGXsfl_39_Refreshing);
         dynInventarioId.Enabled = 0;
         AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_39_Refreshing);
         chkComercioRubrosInventarioActiva.Enabled = 0;
         AssignProp("", false, chkComercioRubrosInventarioActiva_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkComercioRubrosInventarioActiva.Enabled), 5, 0), !bGXsfl_39_Refreshing);
      }

      protected void send_integrity_lvl_hashes2G116( )
      {
      }

      protected void send_integrity_lvl_hashes2G28( )
      {
      }

      protected void SubsflControlProps_39116( )
      {
         edtComercioProductosRubrosID_Internalname = "COMERCIOPRODUCTOSRUBROSID_"+sGXsfl_39_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_39_idx;
         imgprompt_121_Internalname = "PROMPT_121_"+sGXsfl_39_idx;
         cmbComercioRubrosEstado_Internalname = "COMERCIORUBROSESTADO_"+sGXsfl_39_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_39_idx;
         imgprompt_137_Internalname = "PROMPT_137_"+sGXsfl_39_idx;
         chkComercioItemsEstado_Internalname = "COMERCIOITEMSESTADO_"+sGXsfl_39_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_39_idx;
         chkComercioRubrosInventarioActiva_Internalname = "COMERCIORUBROSINVENTARIOACTIVA_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_39116( )
      {
         edtComercioProductosRubrosID_Internalname = "COMERCIOPRODUCTOSRUBROSID_"+sGXsfl_39_fel_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_39_fel_idx;
         imgprompt_121_Internalname = "PROMPT_121_"+sGXsfl_39_fel_idx;
         cmbComercioRubrosEstado_Internalname = "COMERCIORUBROSESTADO_"+sGXsfl_39_fel_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_39_fel_idx;
         imgprompt_137_Internalname = "PROMPT_137_"+sGXsfl_39_fel_idx;
         chkComercioItemsEstado_Internalname = "COMERCIOITEMSESTADO_"+sGXsfl_39_fel_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_39_fel_idx;
         chkComercioRubrosInventarioActiva_Internalname = "COMERCIORUBROSINVENTARIOACTIVA_"+sGXsfl_39_fel_idx;
      }

      protected void AddRow2G116( )
      {
         nGXsfl_39_idx = (int)(nGXsfl_39_idx+1);
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_39116( ) ;
         SendRow2G116( ) ;
      }

      protected void SendRow2G116( )
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
            if ( ((int)((nGXsfl_39_idx) % (2))) == 0 )
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
         imgprompt_121_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0110.aspx"+"',["+"{Ctrl:gx.dom.el('"+"RUBROSID_"+sGXsfl_39_idx+"'), id:'"+"RUBROSID_"+sGXsfl_39_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_116_"+sGXsfl_39_idx+","+"'', false"+","+"false"+");");
         imgprompt_137_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00q1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"RUBROSID_"+sGXsfl_39_idx+"'), id:'"+"RUBROSID_"+sGXsfl_39_idx+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"MEDIDASID_"+sGXsfl_39_idx+"'), id:'"+"MEDIDASID_"+sGXsfl_39_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_116_"+sGXsfl_39_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_116_" + sGXsfl_39_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_39_idx + "',39)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtComercioProductosRubrosID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A713ComercioProductosRubrosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtComercioProductosRubrosID_Enabled!=0) ? context.localUtil.Format( (decimal)(A713ComercioProductosRubrosID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A713ComercioProductosRubrosID), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtComercioProductosRubrosID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtComercioProductosRubrosID_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_116_" + sGXsfl_39_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_39_idx + "',39)\"";
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtRubrosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9") : context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtRubrosId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)edtRubrosId_Horizontalalignment,(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_121_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_121_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_rubrosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_121_Internalname,(string)sImgUrl,(string)imgprompt_121_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_121_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_116_" + sGXsfl_39_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_39_idx + "',39)\"";
         GXCCtl = "COMERCIORUBROSESTADO_" + sGXsfl_39_idx;
         cmbComercioRubrosEstado.Name = GXCCtl;
         cmbComercioRubrosEstado.WebTags = "";
         cmbComercioRubrosEstado.addItem(StringUtil.BoolToStr( false), context.GetMessage( "Sin Acción", ""), 0);
         cmbComercioRubrosEstado.addItem(StringUtil.BoolToStr( true), context.GetMessage( "Si", ""), 0);
         cmbComercioRubrosEstado.addItem(StringUtil.BoolToStr( false), context.GetMessage( "No", ""), 0);
         if ( cmbComercioRubrosEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A692ComercioRubrosEstado) )
            {
               A692ComercioRubrosEstado = true;
               n692ComercioRubrosEstado = false;
            }
         }
         /* ComboBox */
         Gridlevel_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbComercioRubrosEstado,(string)cmbComercioRubrosEstado_Internalname,StringUtil.BoolToStr( A692ComercioRubrosEstado),(short)1,(string)cmbComercioRubrosEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,cmbComercioRubrosEstado.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"",(bool)true,(short)0});
         cmbComercioRubrosEstado.CurrentValue = StringUtil.BoolToStr( A692ComercioRubrosEstado);
         AssignProp("", false, cmbComercioRubrosEstado_Internalname, "Values", (string)(cmbComercioRubrosEstado.ToJavascriptSource()), !bGXsfl_39_Refreshing);
         GXAMEDIDASID_html2G116( A121RubrosId) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_116_" + sGXsfl_39_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_39_idx + "',39)\"";
         if ( ( dynMedidasID.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "MEDIDASID_" + sGXsfl_39_idx;
            dynMedidasID.Name = GXCCtl;
            dynMedidasID.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynMedidasID,(string)dynMedidasID_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)),(short)1,(string)dynMedidasID_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynMedidasID.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"",(bool)true,(short)0});
         dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         AssignProp("", false, dynMedidasID_Internalname, "Values", (string)(dynMedidasID.ToJavascriptSource()), !bGXsfl_39_Refreshing);
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_137_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_137_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_rubrosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_137_Internalname,(string)sImgUrl,(string)imgprompt_137_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_137_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_116_" + sGXsfl_39_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_39_idx + "',39)\"";
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "COMERCIOITEMSESTADO_" + sGXsfl_39_idx;
         chkComercioItemsEstado.Name = GXCCtl;
         chkComercioItemsEstado.WebTags = "";
         chkComercioItemsEstado.Caption = "";
         AssignProp("", false, chkComercioItemsEstado_Internalname, "TitleCaption", chkComercioItemsEstado.Caption, !bGXsfl_39_Refreshing);
         chkComercioItemsEstado.CheckedValue = "false";
         if ( IsIns( ) && (false==A695ComercioItemsEstado) )
         {
            A695ComercioItemsEstado = true;
            n695ComercioItemsEstado = false;
         }
         Gridlevel_rubrosRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkComercioItemsEstado_Internalname,StringUtil.BoolToStr( A695ComercioItemsEstado),(string)"",(string)"",(short)-1,chkComercioItemsEstado.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(44, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,44);\""});
         GXAINVENTARIOID_html2G116( A121RubrosId, A137MedidasID) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_116_" + sGXsfl_39_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_39_idx + "',39)\"";
         if ( ( dynInventarioId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "INVENTARIOID_" + sGXsfl_39_idx;
            dynInventarioId.Name = GXCCtl;
            dynInventarioId.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynInventarioId,(string)dynInventarioId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0)),(short)1,(string)dynInventarioId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynInventarioId.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"",(string)"",(bool)true,(short)0});
         dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         AssignProp("", false, dynInventarioId_Internalname, "Values", (string)(dynInventarioId.ToJavascriptSource()), !bGXsfl_39_Refreshing);
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_116_" + sGXsfl_39_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_39_idx + "',39)\"";
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "COMERCIORUBROSINVENTARIOACTIVA_" + sGXsfl_39_idx;
         chkComercioRubrosInventarioActiva.Name = GXCCtl;
         chkComercioRubrosInventarioActiva.WebTags = "";
         chkComercioRubrosInventarioActiva.Caption = "";
         AssignProp("", false, chkComercioRubrosInventarioActiva_Internalname, "TitleCaption", chkComercioRubrosInventarioActiva.Caption, !bGXsfl_39_Refreshing);
         chkComercioRubrosInventarioActiva.CheckedValue = "false";
         if ( IsIns( ) && (false==A696ComercioRubrosInventarioActiva) )
         {
            A696ComercioRubrosInventarioActiva = true;
            n696ComercioRubrosInventarioActiva = false;
         }
         Gridlevel_rubrosRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkComercioRubrosInventarioActiva_Internalname,StringUtil.BoolToStr( A696ComercioRubrosInventarioActiva),(string)"",(string)"",(short)-1,chkComercioRubrosInventarioActiva.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(46, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,46);\""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_rubrosRow);
         send_integrity_lvl_hashes2G116( ) ;
         GXCCtl = "Z713ComercioProductosRubrosID_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z713ComercioProductosRubrosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z692ComercioRubrosEstado_" + sGXsfl_39_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z692ComercioRubrosEstado);
         GXCCtl = "Z695ComercioItemsEstado_" + sGXsfl_39_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z695ComercioItemsEstado);
         GXCCtl = "Z696ComercioRubrosInventarioActiva_" + sGXsfl_39_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z696ComercioRubrosInventarioActiva);
         GXCCtl = "Z121RubrosId_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z137MedidasID_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z135InventarioId_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_116_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_116), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_116_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_116), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_116_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_116), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vPROVEEDORID_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "COMERCIOPRODUCTOSRUBROSID_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComercioProductosRubrosID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RUBROSID_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RUBROSID_"+sGXsfl_39_idx+"Horizontalalignment", StringUtil.RTrim( edtRubrosId_Horizontalalignment));
         GxWebStd.gx_hidden_field( context, "COMERCIORUBROSESTADO_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbComercioRubrosEstado.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MEDIDASID_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMERCIOITEMSESTADO_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkComercioItemsEstado.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOID_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMERCIORUBROSINVENTARIOACTIVA_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkComercioRubrosInventarioActiva.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_121_"+sGXsfl_39_idx+"Link", StringUtil.RTrim( imgprompt_121_Link));
         GxWebStd.gx_hidden_field( context, "PROMPT_137_"+sGXsfl_39_idx+"Link", StringUtil.RTrim( imgprompt_137_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_rubrosContainer.AddRow(Gridlevel_rubrosRow);
      }

      protected void ReadRow2G116( )
      {
         nGXsfl_39_idx = (int)(nGXsfl_39_idx+1);
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_39116( ) ;
         edtComercioProductosRubrosID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMERCIOPRODUCTOSRUBROSID_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtRubrosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtRubrosId_Horizontalalignment = cgiGet( "RUBROSID_"+sGXsfl_39_idx+"Horizontalalignment");
         cmbComercioRubrosEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMERCIORUBROSESTADO_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynMedidasID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASID_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         chkComercioItemsEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMERCIOITEMSESTADO_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynInventarioId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOID_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         chkComercioRubrosInventarioActiva.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMERCIORUBROSINVENTARIOACTIVA_"+sGXsfl_39_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_121_Link = cgiGet( "PROMPT_121_"+sGXsfl_39_idx+"Link");
         imgprompt_121_Link = cgiGet( "PROMPT_137_"+sGXsfl_39_idx+"Link");
         A713ComercioProductosRubrosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtComercioProductosRubrosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_39_idx;
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
         cmbComercioRubrosEstado.Name = cmbComercioRubrosEstado_Internalname;
         cmbComercioRubrosEstado.CurrentValue = cgiGet( cmbComercioRubrosEstado_Internalname);
         A692ComercioRubrosEstado = StringUtil.StrToBool( cgiGet( cmbComercioRubrosEstado_Internalname));
         n692ComercioRubrosEstado = false;
         n692ComercioRubrosEstado = ((false==A692ComercioRubrosEstado) ? true : false);
         dynMedidasID.Name = dynMedidasID_Internalname;
         dynMedidasID.CurrentValue = cgiGet( dynMedidasID_Internalname);
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynMedidasID_Internalname), "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         n137MedidasID = ((0==A137MedidasID) ? true : false);
         A695ComercioItemsEstado = StringUtil.StrToBool( cgiGet( chkComercioItemsEstado_Internalname));
         n695ComercioItemsEstado = false;
         n695ComercioItemsEstado = ((false==A695ComercioItemsEstado) ? true : false);
         dynInventarioId.Name = dynInventarioId_Internalname;
         dynInventarioId.CurrentValue = cgiGet( dynInventarioId_Internalname);
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynInventarioId_Internalname), "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         n135InventarioId = ((0==A135InventarioId) ? true : false);
         A696ComercioRubrosInventarioActiva = StringUtil.StrToBool( cgiGet( chkComercioRubrosInventarioActiva_Internalname));
         n696ComercioRubrosInventarioActiva = false;
         n696ComercioRubrosInventarioActiva = ((false==A696ComercioRubrosInventarioActiva) ? true : false);
         GXCCtl = "Z713ComercioProductosRubrosID_" + sGXsfl_39_idx;
         Z713ComercioProductosRubrosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z692ComercioRubrosEstado_" + sGXsfl_39_idx;
         Z692ComercioRubrosEstado = StringUtil.StrToBool( cgiGet( GXCCtl));
         n692ComercioRubrosEstado = ((false==A692ComercioRubrosEstado) ? true : false);
         GXCCtl = "Z695ComercioItemsEstado_" + sGXsfl_39_idx;
         Z695ComercioItemsEstado = StringUtil.StrToBool( cgiGet( GXCCtl));
         n695ComercioItemsEstado = ((false==A695ComercioItemsEstado) ? true : false);
         GXCCtl = "Z696ComercioRubrosInventarioActiva_" + sGXsfl_39_idx;
         Z696ComercioRubrosInventarioActiva = StringUtil.StrToBool( cgiGet( GXCCtl));
         n696ComercioRubrosInventarioActiva = ((false==A696ComercioRubrosInventarioActiva) ? true : false);
         GXCCtl = "Z121RubrosId_" + sGXsfl_39_idx;
         Z121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z137MedidasID_" + sGXsfl_39_idx;
         Z137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n137MedidasID = ((0==A137MedidasID) ? true : false);
         GXCCtl = "Z135InventarioId_" + sGXsfl_39_idx;
         Z135InventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n135InventarioId = ((0==A135InventarioId) ? true : false);
         GXCCtl = "nRcdDeleted_116_" + sGXsfl_39_idx;
         nRcdDeleted_116 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_116_" + sGXsfl_39_idx;
         nRcdExists_116 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_116_" + sGXsfl_39_idx;
         nIsMod_116 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtComercioProductosRubrosID_Enabled = edtComercioProductosRubrosID_Enabled;
      }

      protected void ConfirmValues2G0( )
      {
         nGXsfl_39_idx = 0;
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_39116( ) ;
         while ( nGXsfl_39_idx < nRC_GXsfl_39 )
         {
            nGXsfl_39_idx = (int)(nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_39116( ) ;
            ChangePostValue( "Z713ComercioProductosRubrosID_"+sGXsfl_39_idx, cgiGet( "ZT_"+"Z713ComercioProductosRubrosID_"+sGXsfl_39_idx)) ;
            DeletePostValue( "ZT_"+"Z713ComercioProductosRubrosID_"+sGXsfl_39_idx) ;
            ChangePostValue( "Z692ComercioRubrosEstado_"+sGXsfl_39_idx, cgiGet( "ZT_"+"Z692ComercioRubrosEstado_"+sGXsfl_39_idx)) ;
            DeletePostValue( "ZT_"+"Z692ComercioRubrosEstado_"+sGXsfl_39_idx) ;
            ChangePostValue( "Z695ComercioItemsEstado_"+sGXsfl_39_idx, cgiGet( "ZT_"+"Z695ComercioItemsEstado_"+sGXsfl_39_idx)) ;
            DeletePostValue( "ZT_"+"Z695ComercioItemsEstado_"+sGXsfl_39_idx) ;
            ChangePostValue( "Z696ComercioRubrosInventarioActiva_"+sGXsfl_39_idx, cgiGet( "ZT_"+"Z696ComercioRubrosInventarioActiva_"+sGXsfl_39_idx)) ;
            DeletePostValue( "ZT_"+"Z696ComercioRubrosInventarioActiva_"+sGXsfl_39_idx) ;
            ChangePostValue( "Z121RubrosId_"+sGXsfl_39_idx, cgiGet( "ZT_"+"Z121RubrosId_"+sGXsfl_39_idx)) ;
            DeletePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_39_idx) ;
            ChangePostValue( "Z137MedidasID_"+sGXsfl_39_idx, cgiGet( "ZT_"+"Z137MedidasID_"+sGXsfl_39_idx)) ;
            DeletePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_39_idx) ;
            ChangePostValue( "Z135InventarioId_"+sGXsfl_39_idx, cgiGet( "ZT_"+"Z135InventarioId_"+sGXsfl_39_idx)) ;
            DeletePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_39_idx) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true, false);
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
         GXEncryptionTmp = "comercioproductos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ProveedorID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("comercioproductos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ComercioProductos");
         forbiddenHiddens.Add("ProveedorID", context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("ProveedorNombre", StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")));
         forbiddenHiddens.Add("ProveedorEstado", StringUtil.RTrim( context.localUtil.Format( A344ProveedorEstado, "")));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ProveedorCIU", StringUtil.BoolToStr( A978ProveedorCIU));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("comercioproductos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z282ProveedorNombre", StringUtil.RTrim( Z282ProveedorNombre));
         GxWebStd.gx_hidden_field( context, "Z344ProveedorEstado", StringUtil.RTrim( Z344ProveedorEstado));
         GxWebStd.gx_hidden_field( context, "Z712ComercioProductosREnum", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z712ComercioProductosREnum), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z978ProveedorCIU", Z978ProveedorCIU);
         GxWebStd.gx_hidden_field( context, "O712ComercioProductosREnum", StringUtil.LTrim( StringUtil.NToC( (decimal)(O712ComercioProductosREnum), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_39_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vRUBROSID_DATA", AV13RubrosId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vRUBROSID_DATA", AV13RubrosId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "PROVEEDORCIU", A978ProveedorCIU);
         GxWebStd.gx_hidden_field( context, "PROVEEDORIMAGEN_GXI", A40000ProveedorImagen_GXI);
         GxWebStd.gx_hidden_field( context, "COMERCIOPRODUCTOSRENUM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A712ComercioProductosREnum), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV18Pgmname));
         GxWebStd.gx_hidden_field( context, "RUBROSNOMBRE", StringUtil.RTrim( A122RubrosNombre));
         GxWebStd.gx_hidden_field( context, "RUBROSIMAGEN", A168RubrosImagen);
         GxWebStd.gx_hidden_field( context, "RUBROSIMAGEN_GXI", A40001RubrosImagen_GXI);
         GxWebStd.gx_hidden_field( context, "RUBROSESTADO", StringUtil.RTrim( A123RubrosEstado));
         GxWebStd.gx_hidden_field( context, "MEDIDASNOMBRE", StringUtil.RTrim( A138MedidasNombre));
         GxWebStd.gx_hidden_field( context, "MEDIDASESTADO", StringUtil.RTrim( A139MedidasEstado));
         GxWebStd.gx_hidden_field( context, "INVENTARIONOMBRE", StringUtil.RTrim( A136InventarioNombre));
         GxWebStd.gx_hidden_field( context, "INVENTARIOIMAGEN", A189InventarioImagen);
         GxWebStd.gx_hidden_field( context, "INVENTARIOIMAGEN_GXI", A40002InventarioImagen_GXI);
         GxWebStd.gx_hidden_field( context, "ESTADOSTIPO", StringUtil.RTrim( A107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtlgxBlob = "PROVEEDORIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A432ProveedorImagen);
         GxWebStd.gx_hidden_field( context, "COMBO_RUBROSID_Objectcall", StringUtil.RTrim( Combo_rubrosid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_RUBROSID_Cls", StringUtil.RTrim( Combo_rubrosid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_RUBROSID_Enabled", StringUtil.BoolToStr( Combo_rubrosid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_RUBROSID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_rubrosid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_RUBROSID_Isgriditem", StringUtil.BoolToStr( Combo_rubrosid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_RUBROSID_Htmltemplate", StringUtil.RTrim( Combo_rubrosid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_RUBROS_TITLESCATEGORIES_Objectcall", StringUtil.RTrim( Gridlevel_rubros_titlescategories_Objectcall));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_RUBROS_TITLESCATEGORIES_Enabled", StringUtil.BoolToStr( Gridlevel_rubros_titlescategories_Enabled));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_RUBROS_TITLESCATEGORIES_Gridinternalname", StringUtil.RTrim( Gridlevel_rubros_titlescategories_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_RUBROS_TITLESCATEGORIES_Gridtitlescategories", StringUtil.RTrim( Gridlevel_rubros_titlescategories_Gridtitlescategories));
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
         GXEncryptionTmp = "comercioproductos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ProveedorID,18,0));
         return formatLink("comercioproductos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ComercioProductos" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Rubros del Comercio", "") ;
      }

      protected void InitializeNonKey2G28( )
      {
         A282ProveedorNombre = "";
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A432ProveedorImagen = "";
         n432ProveedorImagen = false;
         AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
         AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
         AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
         n432ProveedorImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
         A40000ProveedorImagen_GXI = "";
         n40000ProveedorImagen_GXI = false;
         AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
         AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
         A344ProveedorEstado = "";
         AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         A712ComercioProductosREnum = 0;
         AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
         A978ProveedorCIU = false;
         AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
         O712ComercioProductosREnum = A712ComercioProductosREnum;
         AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
         Z282ProveedorNombre = "";
         Z344ProveedorEstado = "";
         Z712ComercioProductosREnum = 0;
         Z978ProveedorCIU = false;
      }

      protected void InitAll2G28( )
      {
         A133ProveedorID = 0;
         n133ProveedorID = false;
         AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         InitializeNonKey2G28( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A978ProveedorCIU = i978ProveedorCIU;
         AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
      }

      protected void InitializeNonKey2G116( )
      {
         A121RubrosId = 0;
         A122RubrosNombre = "";
         AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
         A168RubrosImagen = "";
         AssignAttri("", false, "A168RubrosImagen", A168RubrosImagen);
         A40001RubrosImagen_GXI = "";
         AssignAttri("", false, "A40001RubrosImagen_GXI", A40001RubrosImagen_GXI);
         A123RubrosEstado = "";
         n123RubrosEstado = false;
         AssignAttri("", false, "A123RubrosEstado", A123RubrosEstado);
         A137MedidasID = 0;
         n137MedidasID = false;
         A138MedidasNombre = "";
         AssignAttri("", false, "A138MedidasNombre", A138MedidasNombre);
         A139MedidasEstado = "";
         n139MedidasEstado = false;
         AssignAttri("", false, "A139MedidasEstado", A139MedidasEstado);
         A135InventarioId = 0;
         n135InventarioId = false;
         A136InventarioNombre = "";
         AssignAttri("", false, "A136InventarioNombre", A136InventarioNombre);
         A189InventarioImagen = "";
         AssignAttri("", false, "A189InventarioImagen", A189InventarioImagen);
         A40002InventarioImagen_GXI = "";
         AssignAttri("", false, "A40002InventarioImagen_GXI", A40002InventarioImagen_GXI);
         A107EstadosTipo = "";
         AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         A108EstadosGenericosId = 0;
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         A692ComercioRubrosEstado = true;
         n692ComercioRubrosEstado = false;
         A695ComercioItemsEstado = true;
         n695ComercioItemsEstado = false;
         A696ComercioRubrosInventarioActiva = true;
         n696ComercioRubrosInventarioActiva = false;
         Z692ComercioRubrosEstado = false;
         Z695ComercioItemsEstado = false;
         Z696ComercioRubrosInventarioActiva = false;
         Z121RubrosId = 0;
         Z137MedidasID = 0;
         Z135InventarioId = 0;
      }

      protected void InitAll2G116( )
      {
         A713ComercioProductosRubrosID = 0;
         InitializeNonKey2G116( ) ;
      }

      protected void StandaloneModalInsert2G116( )
      {
         A712ComercioProductosREnum = i712ComercioProductosREnum;
         AssignAttri("", false, "A712ComercioProductosREnum", StringUtil.LTrimStr( (decimal)(A712ComercioProductosREnum), 10, 0));
         A692ComercioRubrosEstado = i692ComercioRubrosEstado;
         n692ComercioRubrosEstado = false;
         A695ComercioItemsEstado = i695ComercioItemsEstado;
         n695ComercioItemsEstado = false;
         A696ComercioRubrosInventarioActiva = i696ComercioRubrosInventarioActiva;
         n696ComercioRubrosInventarioActiva = false;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932093471", true, true, false);
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
         context.AddJavascriptSource("comercioproductos.js", "?2026932093472", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties116( )
      {
         edtComercioProductosRubrosID_Enabled = defedtComercioProductosRubrosID_Enabled;
         AssignProp("", false, edtComercioProductosRubrosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComercioProductosRubrosID_Enabled), 5, 0), !bGXsfl_39_Refreshing);
      }

      protected void StartGridControl39( )
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
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A713ComercioProductosRubrosID), 18, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtComercioProductosRubrosID_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosId_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosColumn.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtRubrosId_Horizontalalignment));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A692ComercioRubrosEstado)));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbComercioRubrosEstado.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A695ComercioItemsEstado)));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkComercioItemsEstado.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A696ComercioRubrosInventarioActiva)));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkComercioRubrosInventarioActiva.Enabled), 5, 0, ".", "")));
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
         edtProveedorID_Internalname = "PROVEEDORID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO";
         divTb1_Internalname = "TB1";
         imgProveedorImagen_Internalname = "PROVEEDORIMAGEN";
         divTb2_Internalname = "TB2";
         edtComercioProductosRubrosID_Internalname = "COMERCIOPRODUCTOSRUBROSID";
         edtRubrosId_Internalname = "RUBROSID";
         cmbComercioRubrosEstado_Internalname = "COMERCIORUBROSESTADO";
         dynMedidasID_Internalname = "MEDIDASID";
         chkComercioItemsEstado_Internalname = "COMERCIOITEMSESTADO";
         dynInventarioId_Internalname = "INVENTARIOID";
         chkComercioRubrosInventarioActiva_Internalname = "COMERCIORUBROSINVENTARIOACTIVA";
         divTableleaflevel_rubros_Internalname = "TABLELEAFLEVEL_RUBROS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Combo_rubrosid_Internalname = "COMBO_RUBROSID";
         Gridlevel_rubros_titlescategories_Internalname = "GRIDLEVEL_RUBROS_TITLESCATEGORIES";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_121_Internalname = "PROMPT_121";
         imgprompt_137_Internalname = "PROMPT_137";
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
         Combo_rubrosid_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Rubros del Comercio", "");
         chkComercioRubrosInventarioActiva.Caption = "";
         dynInventarioId_Jsonclick = "";
         chkComercioItemsEstado.Caption = "";
         imgprompt_137_Visible = 1;
         imgprompt_137_Link = "";
         dynMedidasID_Jsonclick = "";
         cmbComercioRubrosEstado_Jsonclick = "";
         imgprompt_121_Visible = 1;
         imgprompt_121_Link = "";
         imgprompt_121_Visible = 1;
         edtRubrosId_Jsonclick = "";
         edtComercioProductosRubrosID_Jsonclick = "";
         subGridlevel_rubros_Class = "WorkWith";
         subGridlevel_rubros_Backcolorstyle = 0;
         Gridlevel_rubros_titlescategories_Gridtitlescategories = "";
         Combo_rubrosid_Titlecontrolidtoreplace = "";
         Combo_rubrosid_Htmltemplate = "";
         chkComercioRubrosInventarioActiva.Enabled = 1;
         dynInventarioId.Enabled = 1;
         chkComercioItemsEstado.Enabled = 1;
         dynMedidasID.Enabled = 1;
         cmbComercioRubrosEstado.Enabled = 1;
         edtRubrosId_Enabled = 1;
         edtComercioProductosRubrosID_Enabled = 0;
         Combo_rubrosid_Isgriditem = Convert.ToBoolean( -1);
         Combo_rubrosid_Cls = "ExtendedCombo ExtendedComboWithImage";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         imgProveedorImagen_Enabled = 0;
         cmbProveedorEstado_Jsonclick = "";
         cmbProveedorEstado.Enabled = 0;
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Enabled = 0;
         edtProveedorID_Jsonclick = "";
         edtProveedorID_Enabled = 0;
         edtRubrosId_Horizontalalignment = "end";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         GXAMEDIDASID_html2G116( A121RubrosId) ;
         GXAINVENTARIOID_html2G116( A121RubrosId, A137MedidasID) ;
         /* End function dynload_actions */
      }

      protected void GXDLAMEDIDASID2G116( short A121RubrosId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMEDIDASID_data2G116( A121RubrosId) ;
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

      protected void GXAMEDIDASID_html2G116( short A121RubrosId )
      {
         long gxdynajaxvalue;
         GXDLAMEDIDASID_data2G116( A121RubrosId) ;
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

      protected void GXDLAMEDIDASID_data2G116( short A121RubrosId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T002G43 */
         pr_default.execute(41, new Object[] {A121RubrosId});
         while ( (pr_default.getStatus(41) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T002G43_A137MedidasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T002G43_A138MedidasNombre[0]));
            pr_default.readNext(41);
         }
         pr_default.close(41);
      }

      protected void GXDLAINVENTARIOID2G116( short A121RubrosId ,
                                             long A137MedidasID )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAINVENTARIOID_data2G116( A121RubrosId, A137MedidasID) ;
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

      protected void GXAINVENTARIOID_html2G116( short A121RubrosId ,
                                                long A137MedidasID )
      {
         long gxdynajaxvalue;
         GXDLAINVENTARIOID_data2G116( A121RubrosId, A137MedidasID) ;
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

      protected void GXDLAINVENTARIOID_data2G116( short A121RubrosId ,
                                                  long A137MedidasID )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T002G44 */
         pr_default.execute(42, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         while ( (pr_default.getStatus(42) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T002G44_A135InventarioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T002G44_A136InventarioNombre[0]));
            pr_default.readNext(42);
         }
         pr_default.close(42);
      }

      protected void gxnrGridlevel_rubros_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_39116( ) ;
         while ( nGXsfl_39_idx <= nRC_GXsfl_39 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal2G116( ) ;
            standaloneModal2G116( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow2G116( ) ;
            nGXsfl_39_idx = (int)(nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_39116( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_rubrosContainer)) ;
         /* End function gxnrGridlevel_rubros_newrow */
      }

      protected void init_web_controls( )
      {
         cmbProveedorEstado.Name = "PROVEEDORESTADO";
         cmbProveedorEstado.WebTags = "";
         cmbProveedorEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbProveedorEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbProveedorEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbProveedorEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbProveedorEstado.ItemCount > 0 )
         {
            A344ProveedorEstado = cmbProveedorEstado.getValidValue(A344ProveedorEstado);
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         }
         GXCCtl = "COMERCIORUBROSESTADO_" + sGXsfl_39_idx;
         cmbComercioRubrosEstado.Name = GXCCtl;
         cmbComercioRubrosEstado.WebTags = "";
         cmbComercioRubrosEstado.addItem(StringUtil.BoolToStr( false), context.GetMessage( "Sin Acción", ""), 0);
         cmbComercioRubrosEstado.addItem(StringUtil.BoolToStr( true), context.GetMessage( "Si", ""), 0);
         cmbComercioRubrosEstado.addItem(StringUtil.BoolToStr( false), context.GetMessage( "No", ""), 0);
         if ( cmbComercioRubrosEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A692ComercioRubrosEstado) )
            {
               A692ComercioRubrosEstado = true;
               n692ComercioRubrosEstado = false;
            }
         }
         GXCCtl = "MEDIDASID_" + sGXsfl_39_idx;
         dynMedidasID.Name = GXCCtl;
         dynMedidasID.WebTags = "";
         GXCCtl = "COMERCIOITEMSESTADO_" + sGXsfl_39_idx;
         chkComercioItemsEstado.Name = GXCCtl;
         chkComercioItemsEstado.WebTags = "";
         chkComercioItemsEstado.Caption = "";
         AssignProp("", false, chkComercioItemsEstado_Internalname, "TitleCaption", chkComercioItemsEstado.Caption, !bGXsfl_39_Refreshing);
         chkComercioItemsEstado.CheckedValue = "false";
         if ( IsIns( ) && (false==A695ComercioItemsEstado) )
         {
            A695ComercioItemsEstado = true;
            n695ComercioItemsEstado = false;
         }
         GXCCtl = "INVENTARIOID_" + sGXsfl_39_idx;
         dynInventarioId.Name = GXCCtl;
         dynInventarioId.WebTags = "";
         GXCCtl = "COMERCIORUBROSINVENTARIOACTIVA_" + sGXsfl_39_idx;
         chkComercioRubrosInventarioActiva.Name = GXCCtl;
         chkComercioRubrosInventarioActiva.WebTags = "";
         chkComercioRubrosInventarioActiva.Caption = "";
         AssignProp("", false, chkComercioRubrosInventarioActiva_Internalname, "TitleCaption", chkComercioRubrosInventarioActiva.Caption, !bGXsfl_39_Refreshing);
         chkComercioRubrosInventarioActiva.CheckedValue = "false";
         if ( IsIns( ) && (false==A696ComercioRubrosInventarioActiva) )
         {
            A696ComercioRubrosInventarioActiva = true;
            n696ComercioRubrosInventarioActiva = false;
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

      public void Valid_Rubrosid( )
      {
         n137MedidasID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         n135InventarioId = false;
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         n123RubrosEstado = false;
         /* Using cursor T002G45 */
         pr_default.execute(43, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(43) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = edtRubrosId_Internalname;
         }
         A122RubrosNombre = T002G45_A122RubrosNombre[0];
         A40001RubrosImagen_GXI = T002G45_A40001RubrosImagen_GXI[0];
         A123RubrosEstado = T002G45_A123RubrosEstado[0];
         n123RubrosEstado = T002G45_n123RubrosEstado[0];
         A168RubrosImagen = T002G45_A168RubrosImagen[0];
         pr_default.close(43);
         dynload_actions( ) ;
         if ( dynMedidasID.ItemCount > 0 )
         {
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n137MedidasID = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         }
         if ( dynInventarioId.ItemCount > 0 )
         {
            A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n135InventarioId = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A122RubrosNombre", StringUtil.RTrim( A122RubrosNombre));
         AssignAttri("", false, "A168RubrosImagen", context.PathToRelativeUrl( A168RubrosImagen));
         AssignAttri("", false, "A40001RubrosImagen_GXI", A40001RubrosImagen_GXI);
         AssignAttri("", false, "A123RubrosEstado", StringUtil.RTrim( A123RubrosEstado));
         AssignAttri("", false, "A137MedidasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", "")));
         dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         AssignProp("", false, dynMedidasID_Internalname, "Values", dynMedidasID.ToJavascriptSource(), true);
         AssignAttri("", false, "A135InventarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", "")));
         dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         AssignProp("", false, dynInventarioId_Internalname, "Values", dynInventarioId.ToJavascriptSource(), true);
      }

      public void Valid_Medidasid( )
      {
         n137MedidasID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         n135InventarioId = false;
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         n139MedidasEstado = false;
         /* Using cursor T002G46 */
         pr_default.execute(44, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID});
         if ( (pr_default.getStatus(44) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDIDASID");
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
            }
         }
         A138MedidasNombre = T002G46_A138MedidasNombre[0];
         A139MedidasEstado = T002G46_A139MedidasEstado[0];
         n139MedidasEstado = T002G46_n139MedidasEstado[0];
         pr_default.close(44);
         dynload_actions( ) ;
         if ( dynInventarioId.ItemCount > 0 )
         {
            A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n135InventarioId = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A138MedidasNombre", StringUtil.RTrim( A138MedidasNombre));
         AssignAttri("", false, "A139MedidasEstado", StringUtil.RTrim( A139MedidasEstado));
         AssignAttri("", false, "A135InventarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", "")));
         dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         AssignProp("", false, dynInventarioId_Internalname, "Values", dynInventarioId.ToJavascriptSource(), true);
      }

      public void Valid_Inventarioid( )
      {
         n137MedidasID = false;
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n137MedidasID = false;
         n135InventarioId = false;
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         /* Using cursor T002G47 */
         pr_default.execute(45, new Object[] {A121RubrosId, n137MedidasID, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(45) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) || (0==A135InventarioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "INVENTARIOID");
               AnyError = 1;
               GX_FocusControl = edtRubrosId_Internalname;
            }
         }
         A136InventarioNombre = T002G47_A136InventarioNombre[0];
         A40002InventarioImagen_GXI = T002G47_A40002InventarioImagen_GXI[0];
         A107EstadosTipo = T002G47_A107EstadosTipo[0];
         A108EstadosGenericosId = T002G47_A108EstadosGenericosId[0];
         A189InventarioImagen = T002G47_A189InventarioImagen[0];
         pr_default.close(45);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A136InventarioNombre", StringUtil.RTrim( A136InventarioNombre));
         AssignAttri("", false, "A189InventarioImagen", context.PathToRelativeUrl( A189InventarioImagen));
         AssignAttri("", false, "A40002InventarioImagen_GXI", A40002InventarioImagen_GXI);
         AssignAttri("", false, "A107EstadosTipo", StringUtil.RTrim( A107EstadosTipo));
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A282ProveedorNombre',fld:'PROVEEDORNOMBRE',pic:'',type:'char'},{av:'cmbProveedorEstado'},{av:'A344ProveedorEstado',fld:'PROVEEDORESTADO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E122G2',iparms:[]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[]}");
         setEventMetadata("VALID_COMERCIOPRODUCTOSRUBROSID","{handler:'Valid_Comercioproductosrubrosid',iparms:[]");
         setEventMetadata("VALID_COMERCIOPRODUCTOSRUBROSID",",oparms:[]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'A168RubrosImagen',fld:'RUBROSIMAGEN',pic:'',type:'bits'},{av:'A40001RubrosImagen_GXI',fld:'RUBROSIMAGEN_GXI',pic:'',type:'svchar'},{av:'A123RubrosEstado',fld:'RUBROSESTADO',pic:'',type:'char'}]");
         setEventMetadata("VALID_RUBROSID",",oparms:[{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'A168RubrosImagen',fld:'RUBROSIMAGEN',pic:'',type:'bits'},{av:'A40001RubrosImagen_GXI',fld:'RUBROSIMAGEN_GXI',pic:'',type:'svchar'},{av:'A123RubrosEstado',fld:'RUBROSESTADO',pic:'',type:'char'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A138MedidasNombre',fld:'MEDIDASNOMBRE',pic:'',type:'char'},{av:'A139MedidasEstado',fld:'MEDIDASESTADO',pic:'',type:'char'}]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[{av:'A138MedidasNombre',fld:'MEDIDASNOMBRE',pic:'',type:'char'},{av:'A139MedidasEstado',fld:'MEDIDASESTADO',pic:'',type:'char'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("VALID_INVENTARIOID","{handler:'Valid_Inventarioid',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A136InventarioNombre',fld:'INVENTARIONOMBRE',pic:'',type:'char'},{av:'A189InventarioImagen',fld:'INVENTARIOIMAGEN',pic:'',type:'bits'},{av:'A40002InventarioImagen_GXI',fld:'INVENTARIOIMAGEN_GXI',pic:'',type:'svchar'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("VALID_INVENTARIOID",",oparms:[{av:'A136InventarioNombre',fld:'INVENTARIONOMBRE',pic:'',type:'char'},{av:'A189InventarioImagen',fld:'INVENTARIOIMAGEN',pic:'',type:'bits'},{av:'A40002InventarioImagen_GXI',fld:'INVENTARIOIMAGEN_GXI',pic:'',type:'svchar'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("NULL","{handler:'Valid_Comerciorubrosinventarioactiva',iparms:[]");
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
         pr_default.close(44);
         pr_default.close(38);
         pr_default.close(45);
         pr_default.close(39);
         pr_default.close(43);
         pr_default.close(37);
         pr_default.close(6);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z282ProveedorNombre = "";
         Z344ProveedorEstado = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         A344ProveedorEstado = "";
         TempTags = "";
         A282ProveedorNombre = "";
         ClassString = "";
         StyleString = "";
         A432ProveedorImagen = "";
         A40000ProveedorImagen_GXI = "";
         sImgUrl = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucCombo_rubrosid = new GXUserControl();
         Combo_rubrosid_Caption = "";
         AV13RubrosId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         ucGridlevel_rubros_titlescategories = new GXUserControl();
         Gridlevel_rubrosContainer = new GXWebGrid( context);
         sMode116 = "";
         GX_FocusControl = "";
         sStyleString = "";
         AV18Pgmname = "";
         A122RubrosNombre = "";
         A168RubrosImagen = "";
         A40001RubrosImagen_GXI = "";
         A123RubrosEstado = "";
         A138MedidasNombre = "";
         A139MedidasEstado = "";
         A136InventarioNombre = "";
         A189InventarioImagen = "";
         A40002InventarioImagen_GXI = "";
         A107EstadosTipo = "";
         Combo_rubrosid_Objectcall = "";
         Combo_rubrosid_Class = "";
         Combo_rubrosid_Icontype = "";
         Combo_rubrosid_Icon = "";
         Combo_rubrosid_Tooltip = "";
         Combo_rubrosid_Selectedvalue_set = "";
         Combo_rubrosid_Selectedvalue_get = "";
         Combo_rubrosid_Selectedtext_set = "";
         Combo_rubrosid_Selectedtext_get = "";
         Combo_rubrosid_Gamoauthtoken = "";
         Combo_rubrosid_Ddointernalname = "";
         Combo_rubrosid_Titlecontrolalign = "";
         Combo_rubrosid_Dropdownoptionstype = "";
         Combo_rubrosid_Datalisttype = "";
         Combo_rubrosid_Datalistfixedvalues = "";
         Combo_rubrosid_Datalistproc = "";
         Combo_rubrosid_Datalistprocparametersprefix = "";
         Combo_rubrosid_Remoteservicesparameters = "";
         Combo_rubrosid_Multiplevaluestype = "";
         Combo_rubrosid_Loadingdata = "";
         Combo_rubrosid_Noresultsfound = "";
         Combo_rubrosid_Emptyitemtext = "";
         Combo_rubrosid_Onlyselectedvalues = "";
         Combo_rubrosid_Selectalltext = "";
         Combo_rubrosid_Multiplevaluesseparator = "";
         Combo_rubrosid_Addnewoptiontext = "";
         Gridlevel_rubros_titlescategories_Objectcall = "";
         Gridlevel_rubros_titlescategories_Class = "";
         Gridlevel_rubros_titlescategories_Gridinternalname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode28 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char1 = "";
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         GXt_objcol_SdtDVB_SDTComboData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV14ComboSelectedValue = "";
         Z432ProveedorImagen = "";
         Z40000ProveedorImagen_GXI = "";
         T002G9_A133ProveedorID = new long[1] ;
         T002G9_n133ProveedorID = new bool[] {false} ;
         T002G9_A282ProveedorNombre = new string[] {""} ;
         T002G9_A40000ProveedorImagen_GXI = new string[] {""} ;
         T002G9_n40000ProveedorImagen_GXI = new bool[] {false} ;
         T002G9_A344ProveedorEstado = new string[] {""} ;
         T002G9_A712ComercioProductosREnum = new long[1] ;
         T002G9_A978ProveedorCIU = new bool[] {false} ;
         T002G9_A432ProveedorImagen = new string[] {""} ;
         T002G9_n432ProveedorImagen = new bool[] {false} ;
         T002G10_A133ProveedorID = new long[1] ;
         T002G10_n133ProveedorID = new bool[] {false} ;
         T002G8_A133ProveedorID = new long[1] ;
         T002G8_n133ProveedorID = new bool[] {false} ;
         T002G8_A282ProveedorNombre = new string[] {""} ;
         T002G8_A40000ProveedorImagen_GXI = new string[] {""} ;
         T002G8_n40000ProveedorImagen_GXI = new bool[] {false} ;
         T002G8_A344ProveedorEstado = new string[] {""} ;
         T002G8_A712ComercioProductosREnum = new long[1] ;
         T002G8_A978ProveedorCIU = new bool[] {false} ;
         T002G8_A432ProveedorImagen = new string[] {""} ;
         T002G8_n432ProveedorImagen = new bool[] {false} ;
         T002G11_A133ProveedorID = new long[1] ;
         T002G11_n133ProveedorID = new bool[] {false} ;
         T002G12_A133ProveedorID = new long[1] ;
         T002G12_n133ProveedorID = new bool[] {false} ;
         T002G7_A133ProveedorID = new long[1] ;
         T002G7_n133ProveedorID = new bool[] {false} ;
         T002G7_A282ProveedorNombre = new string[] {""} ;
         T002G7_A40000ProveedorImagen_GXI = new string[] {""} ;
         T002G7_n40000ProveedorImagen_GXI = new bool[] {false} ;
         T002G7_A344ProveedorEstado = new string[] {""} ;
         T002G7_A712ComercioProductosREnum = new long[1] ;
         T002G7_A978ProveedorCIU = new bool[] {false} ;
         T002G7_A432ProveedorImagen = new string[] {""} ;
         T002G7_n432ProveedorImagen = new bool[] {false} ;
         T002G13_A133ProveedorID = new long[1] ;
         T002G13_n133ProveedorID = new bool[] {false} ;
         T002G17_A422PostulacionesId = new long[1] ;
         T002G18_A918MapeoID = new long[1] ;
         T002G19_A918MapeoID = new long[1] ;
         T002G20_A491VincularTrnId = new long[1] ;
         T002G21_A450ProfComisionesID = new long[1] ;
         T002G21_A452ProfComisionesRubrosId = new long[1] ;
         T002G22_A127SolicitudesID = new long[1] ;
         T002G23_A127SolicitudesID = new long[1] ;
         T002G24_A590Listaid = new long[1] ;
         T002G24_A133ProveedorID = new long[1] ;
         T002G24_n133ProveedorID = new bool[] {false} ;
         T002G24_A120ProfesionalesId = new string[] {""} ;
         T002G25_A590Listaid = new long[1] ;
         T002G25_A18SecUserId = new long[1] ;
         T002G25_A133ProveedorID = new long[1] ;
         T002G25_n133ProveedorID = new bool[] {false} ;
         T002G26_A503ComisionesID = new long[1] ;
         T002G26_A133ProveedorID = new long[1] ;
         T002G26_n133ProveedorID = new bool[] {false} ;
         T002G27_A133ProveedorID = new long[1] ;
         T002G27_n133ProveedorID = new bool[] {false} ;
         T002G27_A152ProveedorSolicitudesId = new long[1] ;
         T002G28_A133ProveedorID = new long[1] ;
         T002G28_n133ProveedorID = new bool[] {false} ;
         T002G28_A157ProveedorComisionID = new long[1] ;
         T002G30_A133ProveedorID = new long[1] ;
         T002G30_n133ProveedorID = new bool[] {false} ;
         Z122RubrosNombre = "";
         Z168RubrosImagen = "";
         Z40001RubrosImagen_GXI = "";
         Z123RubrosEstado = "";
         Z138MedidasNombre = "";
         Z139MedidasEstado = "";
         Z136InventarioNombre = "";
         Z189InventarioImagen = "";
         Z40002InventarioImagen_GXI = "";
         Z107EstadosTipo = "";
         T002G31_A133ProveedorID = new long[1] ;
         T002G31_n133ProveedorID = new bool[] {false} ;
         T002G31_A713ComercioProductosRubrosID = new long[1] ;
         T002G31_A692ComercioRubrosEstado = new bool[] {false} ;
         T002G31_n692ComercioRubrosEstado = new bool[] {false} ;
         T002G31_A695ComercioItemsEstado = new bool[] {false} ;
         T002G31_n695ComercioItemsEstado = new bool[] {false} ;
         T002G31_A696ComercioRubrosInventarioActiva = new bool[] {false} ;
         T002G31_n696ComercioRubrosInventarioActiva = new bool[] {false} ;
         T002G31_A122RubrosNombre = new string[] {""} ;
         T002G31_A40001RubrosImagen_GXI = new string[] {""} ;
         T002G31_A123RubrosEstado = new string[] {""} ;
         T002G31_n123RubrosEstado = new bool[] {false} ;
         T002G31_A138MedidasNombre = new string[] {""} ;
         T002G31_A139MedidasEstado = new string[] {""} ;
         T002G31_n139MedidasEstado = new bool[] {false} ;
         T002G31_A136InventarioNombre = new string[] {""} ;
         T002G31_A40002InventarioImagen_GXI = new string[] {""} ;
         T002G31_A121RubrosId = new short[1] ;
         T002G31_A137MedidasID = new long[1] ;
         T002G31_n137MedidasID = new bool[] {false} ;
         T002G31_A135InventarioId = new long[1] ;
         T002G31_n135InventarioId = new bool[] {false} ;
         T002G31_A107EstadosTipo = new string[] {""} ;
         T002G31_A108EstadosGenericosId = new int[1] ;
         T002G31_A168RubrosImagen = new string[] {""} ;
         T002G31_A189InventarioImagen = new string[] {""} ;
         T002G4_A122RubrosNombre = new string[] {""} ;
         T002G4_A40001RubrosImagen_GXI = new string[] {""} ;
         T002G4_A123RubrosEstado = new string[] {""} ;
         T002G4_n123RubrosEstado = new bool[] {false} ;
         T002G4_A168RubrosImagen = new string[] {""} ;
         GXCCtl = "";
         T002G5_A138MedidasNombre = new string[] {""} ;
         T002G5_A139MedidasEstado = new string[] {""} ;
         T002G5_n139MedidasEstado = new bool[] {false} ;
         T002G6_A136InventarioNombre = new string[] {""} ;
         T002G6_A40002InventarioImagen_GXI = new string[] {""} ;
         T002G6_A107EstadosTipo = new string[] {""} ;
         T002G6_A108EstadosGenericosId = new int[1] ;
         T002G6_A189InventarioImagen = new string[] {""} ;
         T002G32_A122RubrosNombre = new string[] {""} ;
         T002G32_A40001RubrosImagen_GXI = new string[] {""} ;
         T002G32_A123RubrosEstado = new string[] {""} ;
         T002G32_n123RubrosEstado = new bool[] {false} ;
         T002G32_A168RubrosImagen = new string[] {""} ;
         T002G33_A138MedidasNombre = new string[] {""} ;
         T002G33_A139MedidasEstado = new string[] {""} ;
         T002G33_n139MedidasEstado = new bool[] {false} ;
         T002G34_A136InventarioNombre = new string[] {""} ;
         T002G34_A40002InventarioImagen_GXI = new string[] {""} ;
         T002G34_A107EstadosTipo = new string[] {""} ;
         T002G34_A108EstadosGenericosId = new int[1] ;
         T002G34_A189InventarioImagen = new string[] {""} ;
         T002G35_A133ProveedorID = new long[1] ;
         T002G35_n133ProveedorID = new bool[] {false} ;
         T002G35_A713ComercioProductosRubrosID = new long[1] ;
         T002G3_A133ProveedorID = new long[1] ;
         T002G3_n133ProveedorID = new bool[] {false} ;
         T002G3_A713ComercioProductosRubrosID = new long[1] ;
         T002G3_A692ComercioRubrosEstado = new bool[] {false} ;
         T002G3_n692ComercioRubrosEstado = new bool[] {false} ;
         T002G3_A695ComercioItemsEstado = new bool[] {false} ;
         T002G3_n695ComercioItemsEstado = new bool[] {false} ;
         T002G3_A696ComercioRubrosInventarioActiva = new bool[] {false} ;
         T002G3_n696ComercioRubrosInventarioActiva = new bool[] {false} ;
         T002G3_A121RubrosId = new short[1] ;
         T002G3_A137MedidasID = new long[1] ;
         T002G3_n137MedidasID = new bool[] {false} ;
         T002G3_A135InventarioId = new long[1] ;
         T002G3_n135InventarioId = new bool[] {false} ;
         T002G2_A133ProveedorID = new long[1] ;
         T002G2_n133ProveedorID = new bool[] {false} ;
         T002G2_A713ComercioProductosRubrosID = new long[1] ;
         T002G2_A692ComercioRubrosEstado = new bool[] {false} ;
         T002G2_n692ComercioRubrosEstado = new bool[] {false} ;
         T002G2_A695ComercioItemsEstado = new bool[] {false} ;
         T002G2_n695ComercioItemsEstado = new bool[] {false} ;
         T002G2_A696ComercioRubrosInventarioActiva = new bool[] {false} ;
         T002G2_n696ComercioRubrosInventarioActiva = new bool[] {false} ;
         T002G2_A121RubrosId = new short[1] ;
         T002G2_A137MedidasID = new long[1] ;
         T002G2_n137MedidasID = new bool[] {false} ;
         T002G2_A135InventarioId = new long[1] ;
         T002G2_n135InventarioId = new bool[] {false} ;
         T002G39_A122RubrosNombre = new string[] {""} ;
         T002G39_A40001RubrosImagen_GXI = new string[] {""} ;
         T002G39_A123RubrosEstado = new string[] {""} ;
         T002G39_n123RubrosEstado = new bool[] {false} ;
         T002G39_A168RubrosImagen = new string[] {""} ;
         T002G40_A138MedidasNombre = new string[] {""} ;
         T002G40_A139MedidasEstado = new string[] {""} ;
         T002G40_n139MedidasEstado = new bool[] {false} ;
         T002G41_A136InventarioNombre = new string[] {""} ;
         T002G41_A40002InventarioImagen_GXI = new string[] {""} ;
         T002G41_A107EstadosTipo = new string[] {""} ;
         T002G41_A108EstadosGenericosId = new int[1] ;
         T002G41_A189InventarioImagen = new string[] {""} ;
         T002G42_A133ProveedorID = new long[1] ;
         T002G42_n133ProveedorID = new bool[] {false} ;
         T002G42_A713ComercioProductosRubrosID = new long[1] ;
         Gridlevel_rubrosRow = new GXWebRow();
         subGridlevel_rubros_Linesclass = "";
         ROClassString = "";
         imgprompt_121_gximage = "";
         imgprompt_137_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         Gridlevel_rubrosColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T002G43_A121RubrosId = new short[1] ;
         T002G43_A137MedidasID = new long[1] ;
         T002G43_n137MedidasID = new bool[] {false} ;
         T002G43_A138MedidasNombre = new string[] {""} ;
         T002G43_A139MedidasEstado = new string[] {""} ;
         T002G43_n139MedidasEstado = new bool[] {false} ;
         T002G44_A121RubrosId = new short[1] ;
         T002G44_A137MedidasID = new long[1] ;
         T002G44_n137MedidasID = new bool[] {false} ;
         T002G44_A135InventarioId = new long[1] ;
         T002G44_n135InventarioId = new bool[] {false} ;
         T002G44_A136InventarioNombre = new string[] {""} ;
         T002G44_A107EstadosTipo = new string[] {""} ;
         T002G44_A108EstadosGenericosId = new int[1] ;
         T002G45_A122RubrosNombre = new string[] {""} ;
         T002G45_A40001RubrosImagen_GXI = new string[] {""} ;
         T002G45_A123RubrosEstado = new string[] {""} ;
         T002G45_n123RubrosEstado = new bool[] {false} ;
         T002G45_A168RubrosImagen = new string[] {""} ;
         T002G46_A138MedidasNombre = new string[] {""} ;
         T002G46_A139MedidasEstado = new string[] {""} ;
         T002G46_n139MedidasEstado = new bool[] {false} ;
         T002G47_A136InventarioNombre = new string[] {""} ;
         T002G47_A40002InventarioImagen_GXI = new string[] {""} ;
         T002G47_A107EstadosTipo = new string[] {""} ;
         T002G47_A108EstadosGenericosId = new int[1] ;
         T002G47_A189InventarioImagen = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.comercioproductos__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comercioproductos__default(),
            new Object[][] {
                new Object[] {
               T002G2_A133ProveedorID, T002G2_A713ComercioProductosRubrosID, T002G2_A692ComercioRubrosEstado, T002G2_n692ComercioRubrosEstado, T002G2_A695ComercioItemsEstado, T002G2_n695ComercioItemsEstado, T002G2_A696ComercioRubrosInventarioActiva, T002G2_n696ComercioRubrosInventarioActiva, T002G2_A121RubrosId, T002G2_A137MedidasID,
               T002G2_n137MedidasID, T002G2_A135InventarioId, T002G2_n135InventarioId
               }
               , new Object[] {
               T002G3_A133ProveedorID, T002G3_A713ComercioProductosRubrosID, T002G3_A692ComercioRubrosEstado, T002G3_n692ComercioRubrosEstado, T002G3_A695ComercioItemsEstado, T002G3_n695ComercioItemsEstado, T002G3_A696ComercioRubrosInventarioActiva, T002G3_n696ComercioRubrosInventarioActiva, T002G3_A121RubrosId, T002G3_A137MedidasID,
               T002G3_n137MedidasID, T002G3_A135InventarioId, T002G3_n135InventarioId
               }
               , new Object[] {
               T002G4_A122RubrosNombre, T002G4_A40001RubrosImagen_GXI, T002G4_A123RubrosEstado, T002G4_n123RubrosEstado, T002G4_A168RubrosImagen
               }
               , new Object[] {
               T002G5_A138MedidasNombre, T002G5_A139MedidasEstado, T002G5_n139MedidasEstado
               }
               , new Object[] {
               T002G6_A136InventarioNombre, T002G6_A40002InventarioImagen_GXI, T002G6_A107EstadosTipo, T002G6_A108EstadosGenericosId, T002G6_A189InventarioImagen
               }
               , new Object[] {
               T002G7_A133ProveedorID, T002G7_A282ProveedorNombre, T002G7_A40000ProveedorImagen_GXI, T002G7_n40000ProveedorImagen_GXI, T002G7_A344ProveedorEstado, T002G7_A712ComercioProductosREnum, T002G7_A978ProveedorCIU, T002G7_A432ProveedorImagen, T002G7_n432ProveedorImagen
               }
               , new Object[] {
               T002G8_A133ProveedorID, T002G8_A282ProveedorNombre, T002G8_A40000ProveedorImagen_GXI, T002G8_n40000ProveedorImagen_GXI, T002G8_A344ProveedorEstado, T002G8_A712ComercioProductosREnum, T002G8_A978ProveedorCIU, T002G8_A432ProveedorImagen, T002G8_n432ProveedorImagen
               }
               , new Object[] {
               T002G9_A133ProveedorID, T002G9_A282ProveedorNombre, T002G9_A40000ProveedorImagen_GXI, T002G9_n40000ProveedorImagen_GXI, T002G9_A344ProveedorEstado, T002G9_A712ComercioProductosREnum, T002G9_A978ProveedorCIU, T002G9_A432ProveedorImagen, T002G9_n432ProveedorImagen
               }
               , new Object[] {
               T002G10_A133ProveedorID
               }
               , new Object[] {
               T002G11_A133ProveedorID
               }
               , new Object[] {
               T002G12_A133ProveedorID
               }
               , new Object[] {
               T002G13_A133ProveedorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002G17_A422PostulacionesId
               }
               , new Object[] {
               T002G18_A918MapeoID
               }
               , new Object[] {
               T002G19_A918MapeoID
               }
               , new Object[] {
               T002G20_A491VincularTrnId
               }
               , new Object[] {
               T002G21_A450ProfComisionesID, T002G21_A452ProfComisionesRubrosId
               }
               , new Object[] {
               T002G22_A127SolicitudesID
               }
               , new Object[] {
               T002G23_A127SolicitudesID
               }
               , new Object[] {
               T002G24_A590Listaid, T002G24_A133ProveedorID, T002G24_A120ProfesionalesId
               }
               , new Object[] {
               T002G25_A590Listaid, T002G25_A18SecUserId, T002G25_A133ProveedorID
               }
               , new Object[] {
               T002G26_A503ComisionesID, T002G26_A133ProveedorID
               }
               , new Object[] {
               T002G27_A133ProveedorID, T002G27_A152ProveedorSolicitudesId
               }
               , new Object[] {
               T002G28_A133ProveedorID, T002G28_A157ProveedorComisionID
               }
               , new Object[] {
               }
               , new Object[] {
               T002G30_A133ProveedorID
               }
               , new Object[] {
               T002G31_A133ProveedorID, T002G31_A713ComercioProductosRubrosID, T002G31_A692ComercioRubrosEstado, T002G31_n692ComercioRubrosEstado, T002G31_A695ComercioItemsEstado, T002G31_n695ComercioItemsEstado, T002G31_A696ComercioRubrosInventarioActiva, T002G31_n696ComercioRubrosInventarioActiva, T002G31_A122RubrosNombre, T002G31_A40001RubrosImagen_GXI,
               T002G31_A123RubrosEstado, T002G31_n123RubrosEstado, T002G31_A138MedidasNombre, T002G31_A139MedidasEstado, T002G31_n139MedidasEstado, T002G31_A136InventarioNombre, T002G31_A40002InventarioImagen_GXI, T002G31_A121RubrosId, T002G31_A137MedidasID, T002G31_n137MedidasID,
               T002G31_A135InventarioId, T002G31_n135InventarioId, T002G31_A107EstadosTipo, T002G31_A108EstadosGenericosId, T002G31_A168RubrosImagen, T002G31_A189InventarioImagen
               }
               , new Object[] {
               T002G32_A122RubrosNombre, T002G32_A40001RubrosImagen_GXI, T002G32_A123RubrosEstado, T002G32_n123RubrosEstado, T002G32_A168RubrosImagen
               }
               , new Object[] {
               T002G33_A138MedidasNombre, T002G33_A139MedidasEstado, T002G33_n139MedidasEstado
               }
               , new Object[] {
               T002G34_A136InventarioNombre, T002G34_A40002InventarioImagen_GXI, T002G34_A107EstadosTipo, T002G34_A108EstadosGenericosId, T002G34_A189InventarioImagen
               }
               , new Object[] {
               T002G35_A133ProveedorID, T002G35_A713ComercioProductosRubrosID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002G39_A122RubrosNombre, T002G39_A40001RubrosImagen_GXI, T002G39_A123RubrosEstado, T002G39_n123RubrosEstado, T002G39_A168RubrosImagen
               }
               , new Object[] {
               T002G40_A138MedidasNombre, T002G40_A139MedidasEstado, T002G40_n139MedidasEstado
               }
               , new Object[] {
               T002G41_A136InventarioNombre, T002G41_A40002InventarioImagen_GXI, T002G41_A107EstadosTipo, T002G41_A108EstadosGenericosId, T002G41_A189InventarioImagen
               }
               , new Object[] {
               T002G42_A133ProveedorID, T002G42_A713ComercioProductosRubrosID
               }
               , new Object[] {
               T002G43_A121RubrosId, T002G43_A137MedidasID, T002G43_A138MedidasNombre, T002G43_A139MedidasEstado, T002G43_n139MedidasEstado
               }
               , new Object[] {
               T002G44_A121RubrosId, T002G44_A137MedidasID, T002G44_A135InventarioId, T002G44_A136InventarioNombre, T002G44_A107EstadosTipo, T002G44_A108EstadosGenericosId
               }
               , new Object[] {
               T002G45_A122RubrosNombre, T002G45_A40001RubrosImagen_GXI, T002G45_A123RubrosEstado, T002G45_n123RubrosEstado, T002G45_A168RubrosImagen
               }
               , new Object[] {
               T002G46_A138MedidasNombre, T002G46_A139MedidasEstado, T002G46_n139MedidasEstado
               }
               , new Object[] {
               T002G47_A136InventarioNombre, T002G47_A40002InventarioImagen_GXI, T002G47_A107EstadosTipo, T002G47_A108EstadosGenericosId, T002G47_A189InventarioImagen
               }
            }
         );
         Z978ProveedorCIU = false;
         A978ProveedorCIU = false;
         i978ProveedorCIU = false;
         AV18Pgmname = "ComercioProductos";
         Z696ComercioRubrosInventarioActiva = true;
         n696ComercioRubrosInventarioActiva = false;
         A696ComercioRubrosInventarioActiva = true;
         n696ComercioRubrosInventarioActiva = false;
         i696ComercioRubrosInventarioActiva = true;
         n696ComercioRubrosInventarioActiva = false;
         Z695ComercioItemsEstado = true;
         n695ComercioItemsEstado = false;
         A695ComercioItemsEstado = true;
         n695ComercioItemsEstado = false;
         i695ComercioItemsEstado = true;
         n695ComercioItemsEstado = false;
         Z692ComercioRubrosEstado = true;
         n692ComercioRubrosEstado = false;
         A692ComercioRubrosEstado = true;
         n692ComercioRubrosEstado = false;
         i692ComercioRubrosEstado = true;
         n692ComercioRubrosEstado = false;
      }

      private short nIsMod_116 ;
      private short Z121RubrosId ;
      private short nRcdDeleted_116 ;
      private short nRcdExists_116 ;
      private short GxWebError ;
      private short A121RubrosId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount116 ;
      private short RcdFound116 ;
      private short nBlankRcdUsr116 ;
      private short RcdFound28 ;
      private short nIsDirty_116 ;
      private short subGridlevel_rubros_Backcolorstyle ;
      private short subGridlevel_rubros_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_rubros_Allowselection ;
      private short subGridlevel_rubros_Allowhovering ;
      private short subGridlevel_rubros_Allowcollapsing ;
      private short subGridlevel_rubros_Collapsed ;
      private int nRC_GXsfl_39 ;
      private int nGXsfl_39_idx=1 ;
      private int trnEnded ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int imgProveedorImagen_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtComercioProductosRubrosID_Enabled ;
      private int edtRubrosId_Enabled ;
      private int fRowAdded ;
      private int A108EstadosGenericosId ;
      private int Combo_rubrosid_Datalistupdateminimumcharacters ;
      private int Combo_rubrosid_Gxcontroltype ;
      private int Z108EstadosGenericosId ;
      private int subGridlevel_rubros_Backcolor ;
      private int subGridlevel_rubros_Allbackcolor ;
      private int imgprompt_121_Visible ;
      private int imgprompt_137_Visible ;
      private int defedtComercioProductosRubrosID_Enabled ;
      private int idxLst ;
      private int subGridlevel_rubros_Selectedindex ;
      private int subGridlevel_rubros_Selectioncolor ;
      private int subGridlevel_rubros_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long wcpOAV7ProveedorID ;
      private long Z133ProveedorID ;
      private long Z712ComercioProductosREnum ;
      private long O712ComercioProductosREnum ;
      private long Z713ComercioProductosRubrosID ;
      private long Z137MedidasID ;
      private long Z135InventarioId ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long AV7ProveedorID ;
      private long A712ComercioProductosREnum ;
      private long A133ProveedorID ;
      private long B712ComercioProductosREnum ;
      private long GRIDLEVEL_RUBROS_nFirstRecordOnPage ;
      private long s712ComercioProductosREnum ;
      private long A713ComercioProductosRubrosID ;
      private long i712ComercioProductosREnum ;
      private string sPrefix ;
      private string sGXsfl_39_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z282ProveedorNombre ;
      private string Z344ProveedorEstado ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string edtRubrosId_Horizontalalignment ;
      private string edtRubrosId_Internalname ;
      private string A344ProveedorEstado ;
      private string cmbProveedorEstado_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTb1_Internalname ;
      private string edtProveedorID_Internalname ;
      private string TempTags ;
      private string edtProveedorID_Jsonclick ;
      private string edtProveedorNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Jsonclick ;
      private string cmbProveedorEstado_Jsonclick ;
      private string divTb2_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgProveedorImagen_Internalname ;
      private string divTableleaflevel_rubros_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Combo_rubrosid_Caption ;
      private string Combo_rubrosid_Cls ;
      private string Combo_rubrosid_Internalname ;
      private string Gridlevel_rubros_titlescategories_Internalname ;
      private string sMode116 ;
      private string edtComercioProductosRubrosID_Internalname ;
      private string cmbComercioRubrosEstado_Internalname ;
      private string dynMedidasID_Internalname ;
      private string chkComercioItemsEstado_Internalname ;
      private string dynInventarioId_Internalname ;
      private string chkComercioRubrosInventarioActiva_Internalname ;
      private string imgprompt_121_Link ;
      private string GX_FocusControl ;
      private string sStyleString ;
      private string subGridlevel_rubros_Internalname ;
      private string AV18Pgmname ;
      private string A122RubrosNombre ;
      private string A123RubrosEstado ;
      private string A138MedidasNombre ;
      private string A139MedidasEstado ;
      private string A136InventarioNombre ;
      private string A107EstadosTipo ;
      private string Combo_rubrosid_Objectcall ;
      private string Combo_rubrosid_Class ;
      private string Combo_rubrosid_Icontype ;
      private string Combo_rubrosid_Icon ;
      private string Combo_rubrosid_Tooltip ;
      private string Combo_rubrosid_Selectedvalue_set ;
      private string Combo_rubrosid_Selectedvalue_get ;
      private string Combo_rubrosid_Selectedtext_set ;
      private string Combo_rubrosid_Selectedtext_get ;
      private string Combo_rubrosid_Gamoauthtoken ;
      private string Combo_rubrosid_Ddointernalname ;
      private string Combo_rubrosid_Titlecontrolalign ;
      private string Combo_rubrosid_Dropdownoptionstype ;
      private string Combo_rubrosid_Titlecontrolidtoreplace ;
      private string Combo_rubrosid_Datalisttype ;
      private string Combo_rubrosid_Datalistfixedvalues ;
      private string Combo_rubrosid_Datalistproc ;
      private string Combo_rubrosid_Datalistprocparametersprefix ;
      private string Combo_rubrosid_Remoteservicesparameters ;
      private string Combo_rubrosid_Htmltemplate ;
      private string Combo_rubrosid_Multiplevaluestype ;
      private string Combo_rubrosid_Loadingdata ;
      private string Combo_rubrosid_Noresultsfound ;
      private string Combo_rubrosid_Emptyitemtext ;
      private string Combo_rubrosid_Onlyselectedvalues ;
      private string Combo_rubrosid_Selectalltext ;
      private string Combo_rubrosid_Multiplevaluesseparator ;
      private string Combo_rubrosid_Addnewoptiontext ;
      private string Gridlevel_rubros_titlescategories_Objectcall ;
      private string Gridlevel_rubros_titlescategories_Class ;
      private string Gridlevel_rubros_titlescategories_Gridinternalname ;
      private string Gridlevel_rubros_titlescategories_Gridtitlescategories ;
      private string hsh ;
      private string sMode28 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char1 ;
      private string GXEncryptionTmp ;
      private string Z122RubrosNombre ;
      private string Z123RubrosEstado ;
      private string Z138MedidasNombre ;
      private string Z139MedidasEstado ;
      private string Z136InventarioNombre ;
      private string Z107EstadosTipo ;
      private string GXCCtl ;
      private string imgprompt_121_Internalname ;
      private string imgprompt_137_Internalname ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGridlevel_rubros_Class ;
      private string subGridlevel_rubros_Linesclass ;
      private string imgprompt_137_Link ;
      private string ROClassString ;
      private string edtComercioProductosRubrosID_Jsonclick ;
      private string edtRubrosId_Jsonclick ;
      private string imgprompt_121_gximage ;
      private string cmbComercioRubrosEstado_Jsonclick ;
      private string dynMedidasID_Jsonclick ;
      private string imgprompt_137_gximage ;
      private string dynInventarioId_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string subGridlevel_rubros_Header ;
      private string gxwrpcisep ;
      private bool Z978ProveedorCIU ;
      private bool Z692ComercioRubrosEstado ;
      private bool Z695ComercioItemsEstado ;
      private bool Z696ComercioRubrosInventarioActiva ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n137MedidasID ;
      private bool n135InventarioId ;
      private bool wbErr ;
      private bool bGXsfl_39_Refreshing=false ;
      private bool A432ProveedorImagen_IsBlob ;
      private bool Combo_rubrosid_Isgriditem ;
      private bool A978ProveedorCIU ;
      private bool n40000ProveedorImagen_GXI ;
      private bool n123RubrosEstado ;
      private bool n139MedidasEstado ;
      private bool Combo_rubrosid_Enabled ;
      private bool Combo_rubrosid_Visible ;
      private bool Combo_rubrosid_Allowmultipleselection ;
      private bool Combo_rubrosid_Hasdescription ;
      private bool Combo_rubrosid_Includeonlyselectedoption ;
      private bool Combo_rubrosid_Includeselectalloption ;
      private bool Combo_rubrosid_Emptyitem ;
      private bool Combo_rubrosid_Includeaddnewoption ;
      private bool Gridlevel_rubros_titlescategories_Enabled ;
      private bool Gridlevel_rubros_titlescategories_Visible ;
      private bool n133ProveedorID ;
      private bool n432ProveedorImagen ;
      private bool A692ComercioRubrosEstado ;
      private bool A695ComercioItemsEstado ;
      private bool A696ComercioRubrosInventarioActiva ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean2 ;
      private bool n692ComercioRubrosEstado ;
      private bool n695ComercioItemsEstado ;
      private bool n696ComercioRubrosInventarioActiva ;
      private bool Gx_longc ;
      private bool i978ProveedorCIU ;
      private bool i692ComercioRubrosEstado ;
      private bool i695ComercioItemsEstado ;
      private bool i696ComercioRubrosInventarioActiva ;
      private bool gxdyncontrolsrefreshing ;
      private string A40000ProveedorImagen_GXI ;
      private string A40001RubrosImagen_GXI ;
      private string A40002InventarioImagen_GXI ;
      private string AV14ComboSelectedValue ;
      private string Z40000ProveedorImagen_GXI ;
      private string Z40001RubrosImagen_GXI ;
      private string Z40002InventarioImagen_GXI ;
      private string A432ProveedorImagen ;
      private string A168RubrosImagen ;
      private string A189InventarioImagen ;
      private string Z432ProveedorImagen ;
      private string Z168RubrosImagen ;
      private string Z189InventarioImagen ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_rubrosContainer ;
      private GXWebRow Gridlevel_rubrosRow ;
      private GXWebColumn Gridlevel_rubrosColumn ;
      private GXUserControl ucCombo_rubrosid ;
      private GXUserControl ucGridlevel_rubros_titlescategories ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProveedorEstado ;
      private GXCombobox cmbComercioRubrosEstado ;
      private GXCombobox dynMedidasID ;
      private GXCheckbox chkComercioItemsEstado ;
      private GXCombobox dynInventarioId ;
      private GXCheckbox chkComercioRubrosInventarioActiva ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13RubrosId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item3 ;
      private IDataStoreProvider pr_default ;
      private long[] T002G9_A133ProveedorID ;
      private bool[] T002G9_n133ProveedorID ;
      private string[] T002G9_A282ProveedorNombre ;
      private string[] T002G9_A40000ProveedorImagen_GXI ;
      private bool[] T002G9_n40000ProveedorImagen_GXI ;
      private string[] T002G9_A344ProveedorEstado ;
      private long[] T002G9_A712ComercioProductosREnum ;
      private bool[] T002G9_A978ProveedorCIU ;
      private string[] T002G9_A432ProveedorImagen ;
      private bool[] T002G9_n432ProveedorImagen ;
      private long[] T002G10_A133ProveedorID ;
      private bool[] T002G10_n133ProveedorID ;
      private long[] T002G8_A133ProveedorID ;
      private bool[] T002G8_n133ProveedorID ;
      private string[] T002G8_A282ProveedorNombre ;
      private string[] T002G8_A40000ProveedorImagen_GXI ;
      private bool[] T002G8_n40000ProveedorImagen_GXI ;
      private string[] T002G8_A344ProveedorEstado ;
      private long[] T002G8_A712ComercioProductosREnum ;
      private bool[] T002G8_A978ProveedorCIU ;
      private string[] T002G8_A432ProveedorImagen ;
      private bool[] T002G8_n432ProveedorImagen ;
      private long[] T002G11_A133ProveedorID ;
      private bool[] T002G11_n133ProveedorID ;
      private long[] T002G12_A133ProveedorID ;
      private bool[] T002G12_n133ProveedorID ;
      private long[] T002G7_A133ProveedorID ;
      private bool[] T002G7_n133ProveedorID ;
      private string[] T002G7_A282ProveedorNombre ;
      private string[] T002G7_A40000ProveedorImagen_GXI ;
      private bool[] T002G7_n40000ProveedorImagen_GXI ;
      private string[] T002G7_A344ProveedorEstado ;
      private long[] T002G7_A712ComercioProductosREnum ;
      private bool[] T002G7_A978ProveedorCIU ;
      private string[] T002G7_A432ProveedorImagen ;
      private bool[] T002G7_n432ProveedorImagen ;
      private long[] T002G13_A133ProveedorID ;
      private bool[] T002G13_n133ProveedorID ;
      private long[] T002G17_A422PostulacionesId ;
      private long[] T002G18_A918MapeoID ;
      private long[] T002G19_A918MapeoID ;
      private long[] T002G20_A491VincularTrnId ;
      private long[] T002G21_A450ProfComisionesID ;
      private long[] T002G21_A452ProfComisionesRubrosId ;
      private long[] T002G22_A127SolicitudesID ;
      private long[] T002G23_A127SolicitudesID ;
      private long[] T002G24_A590Listaid ;
      private long[] T002G24_A133ProveedorID ;
      private bool[] T002G24_n133ProveedorID ;
      private string[] T002G24_A120ProfesionalesId ;
      private long[] T002G25_A590Listaid ;
      private long[] T002G25_A18SecUserId ;
      private long[] T002G25_A133ProveedorID ;
      private bool[] T002G25_n133ProveedorID ;
      private long[] T002G26_A503ComisionesID ;
      private long[] T002G26_A133ProveedorID ;
      private bool[] T002G26_n133ProveedorID ;
      private long[] T002G27_A133ProveedorID ;
      private bool[] T002G27_n133ProveedorID ;
      private long[] T002G27_A152ProveedorSolicitudesId ;
      private long[] T002G28_A133ProveedorID ;
      private bool[] T002G28_n133ProveedorID ;
      private long[] T002G28_A157ProveedorComisionID ;
      private long[] T002G30_A133ProveedorID ;
      private bool[] T002G30_n133ProveedorID ;
      private long[] T002G31_A133ProveedorID ;
      private bool[] T002G31_n133ProveedorID ;
      private long[] T002G31_A713ComercioProductosRubrosID ;
      private bool[] T002G31_A692ComercioRubrosEstado ;
      private bool[] T002G31_n692ComercioRubrosEstado ;
      private bool[] T002G31_A695ComercioItemsEstado ;
      private bool[] T002G31_n695ComercioItemsEstado ;
      private bool[] T002G31_A696ComercioRubrosInventarioActiva ;
      private bool[] T002G31_n696ComercioRubrosInventarioActiva ;
      private string[] T002G31_A122RubrosNombre ;
      private string[] T002G31_A40001RubrosImagen_GXI ;
      private string[] T002G31_A123RubrosEstado ;
      private bool[] T002G31_n123RubrosEstado ;
      private string[] T002G31_A138MedidasNombre ;
      private string[] T002G31_A139MedidasEstado ;
      private bool[] T002G31_n139MedidasEstado ;
      private string[] T002G31_A136InventarioNombre ;
      private string[] T002G31_A40002InventarioImagen_GXI ;
      private short[] T002G31_A121RubrosId ;
      private long[] T002G31_A137MedidasID ;
      private bool[] T002G31_n137MedidasID ;
      private long[] T002G31_A135InventarioId ;
      private bool[] T002G31_n135InventarioId ;
      private string[] T002G31_A107EstadosTipo ;
      private int[] T002G31_A108EstadosGenericosId ;
      private string[] T002G31_A168RubrosImagen ;
      private string[] T002G31_A189InventarioImagen ;
      private string[] T002G4_A122RubrosNombre ;
      private string[] T002G4_A40001RubrosImagen_GXI ;
      private string[] T002G4_A123RubrosEstado ;
      private bool[] T002G4_n123RubrosEstado ;
      private string[] T002G4_A168RubrosImagen ;
      private string[] T002G5_A138MedidasNombre ;
      private string[] T002G5_A139MedidasEstado ;
      private bool[] T002G5_n139MedidasEstado ;
      private string[] T002G6_A136InventarioNombre ;
      private string[] T002G6_A40002InventarioImagen_GXI ;
      private string[] T002G6_A107EstadosTipo ;
      private int[] T002G6_A108EstadosGenericosId ;
      private string[] T002G6_A189InventarioImagen ;
      private string[] T002G32_A122RubrosNombre ;
      private string[] T002G32_A40001RubrosImagen_GXI ;
      private string[] T002G32_A123RubrosEstado ;
      private bool[] T002G32_n123RubrosEstado ;
      private string[] T002G32_A168RubrosImagen ;
      private string[] T002G33_A138MedidasNombre ;
      private string[] T002G33_A139MedidasEstado ;
      private bool[] T002G33_n139MedidasEstado ;
      private string[] T002G34_A136InventarioNombre ;
      private string[] T002G34_A40002InventarioImagen_GXI ;
      private string[] T002G34_A107EstadosTipo ;
      private int[] T002G34_A108EstadosGenericosId ;
      private string[] T002G34_A189InventarioImagen ;
      private long[] T002G35_A133ProveedorID ;
      private bool[] T002G35_n133ProveedorID ;
      private long[] T002G35_A713ComercioProductosRubrosID ;
      private long[] T002G3_A133ProveedorID ;
      private bool[] T002G3_n133ProveedorID ;
      private long[] T002G3_A713ComercioProductosRubrosID ;
      private bool[] T002G3_A692ComercioRubrosEstado ;
      private bool[] T002G3_n692ComercioRubrosEstado ;
      private bool[] T002G3_A695ComercioItemsEstado ;
      private bool[] T002G3_n695ComercioItemsEstado ;
      private bool[] T002G3_A696ComercioRubrosInventarioActiva ;
      private bool[] T002G3_n696ComercioRubrosInventarioActiva ;
      private short[] T002G3_A121RubrosId ;
      private long[] T002G3_A137MedidasID ;
      private bool[] T002G3_n137MedidasID ;
      private long[] T002G3_A135InventarioId ;
      private bool[] T002G3_n135InventarioId ;
      private long[] T002G2_A133ProveedorID ;
      private bool[] T002G2_n133ProveedorID ;
      private long[] T002G2_A713ComercioProductosRubrosID ;
      private bool[] T002G2_A692ComercioRubrosEstado ;
      private bool[] T002G2_n692ComercioRubrosEstado ;
      private bool[] T002G2_A695ComercioItemsEstado ;
      private bool[] T002G2_n695ComercioItemsEstado ;
      private bool[] T002G2_A696ComercioRubrosInventarioActiva ;
      private bool[] T002G2_n696ComercioRubrosInventarioActiva ;
      private short[] T002G2_A121RubrosId ;
      private long[] T002G2_A137MedidasID ;
      private bool[] T002G2_n137MedidasID ;
      private long[] T002G2_A135InventarioId ;
      private bool[] T002G2_n135InventarioId ;
      private string[] T002G39_A122RubrosNombre ;
      private string[] T002G39_A40001RubrosImagen_GXI ;
      private string[] T002G39_A123RubrosEstado ;
      private bool[] T002G39_n123RubrosEstado ;
      private string[] T002G39_A168RubrosImagen ;
      private string[] T002G40_A138MedidasNombre ;
      private string[] T002G40_A139MedidasEstado ;
      private bool[] T002G40_n139MedidasEstado ;
      private string[] T002G41_A136InventarioNombre ;
      private string[] T002G41_A40002InventarioImagen_GXI ;
      private string[] T002G41_A107EstadosTipo ;
      private int[] T002G41_A108EstadosGenericosId ;
      private string[] T002G41_A189InventarioImagen ;
      private long[] T002G42_A133ProveedorID ;
      private bool[] T002G42_n133ProveedorID ;
      private long[] T002G42_A713ComercioProductosRubrosID ;
      private short[] T002G43_A121RubrosId ;
      private long[] T002G43_A137MedidasID ;
      private bool[] T002G43_n137MedidasID ;
      private string[] T002G43_A138MedidasNombre ;
      private string[] T002G43_A139MedidasEstado ;
      private bool[] T002G43_n139MedidasEstado ;
      private short[] T002G44_A121RubrosId ;
      private long[] T002G44_A137MedidasID ;
      private bool[] T002G44_n137MedidasID ;
      private long[] T002G44_A135InventarioId ;
      private bool[] T002G44_n135InventarioId ;
      private string[] T002G44_A136InventarioNombre ;
      private string[] T002G44_A107EstadosTipo ;
      private int[] T002G44_A108EstadosGenericosId ;
      private string[] T002G45_A122RubrosNombre ;
      private string[] T002G45_A40001RubrosImagen_GXI ;
      private string[] T002G45_A123RubrosEstado ;
      private bool[] T002G45_n123RubrosEstado ;
      private string[] T002G45_A168RubrosImagen ;
      private string[] T002G46_A138MedidasNombre ;
      private string[] T002G46_A139MedidasEstado ;
      private bool[] T002G46_n139MedidasEstado ;
      private string[] T002G47_A136InventarioNombre ;
      private string[] T002G47_A40002InventarioImagen_GXI ;
      private string[] T002G47_A107EstadosTipo ;
      private int[] T002G47_A108EstadosGenericosId ;
      private string[] T002G47_A189InventarioImagen ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class comercioproductos__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class comercioproductos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
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
       ,new ForEachCursor(def[26])
       ,new UpdateCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new UpdateCursor(def[34])
       ,new UpdateCursor(def[35])
       ,new UpdateCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new ForEachCursor(def[45])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002G2;
        prmT002G2 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ComercioProductosRubrosID",GXType.Decimal,18,0)
        };
        Object[] prmT002G3;
        prmT002G3 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ComercioProductosRubrosID",GXType.Decimal,18,0)
        };
        Object[] prmT002G4;
        prmT002G4 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT002G5;
        prmT002G5 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G6;
        prmT002G6 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G7;
        prmT002G7 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G8;
        prmT002G8 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G9;
        prmT002G9 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G10;
        prmT002G10 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G11;
        prmT002G11 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G12;
        prmT002G12 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G13;
        prmT002G13 = new Object[] {
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=1, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
        new ParDef("@ComercioProductosREnum",GXType.Decimal,10,0) ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0)
        };
        Object[] prmT002G14;
        prmT002G14 = new Object[] {
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
        new ParDef("@ComercioProductosREnum",GXType.Decimal,10,0) ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G15;
        prmT002G15 = new Object[] {
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G16;
        prmT002G16 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G17;
        prmT002G17 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G18;
        prmT002G18 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G19;
        prmT002G19 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G20;
        prmT002G20 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G21;
        prmT002G21 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G22;
        prmT002G22 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G23;
        prmT002G23 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G24;
        prmT002G24 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G25;
        prmT002G25 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G26;
        prmT002G26 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G27;
        prmT002G27 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G28;
        prmT002G28 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G29;
        prmT002G29 = new Object[] {
        new ParDef("@ComercioProductosREnum",GXType.Decimal,10,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G30;
        prmT002G30 = new Object[] {
        };
        Object[] prmT002G31;
        prmT002G31 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ComercioProductosRubrosID",GXType.Decimal,18,0)
        };
        Object[] prmT002G32;
        prmT002G32 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT002G33;
        prmT002G33 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G34;
        prmT002G34 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G35;
        prmT002G35 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ComercioProductosRubrosID",GXType.Decimal,18,0)
        };
        Object[] prmT002G36;
        prmT002G36 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ComercioProductosRubrosID",GXType.Decimal,18,0) ,
        new ParDef("@ComercioRubrosEstado",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ComercioItemsEstado",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ComercioRubrosInventarioActiva",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G37;
        prmT002G37 = new Object[] {
        new ParDef("@ComercioRubrosEstado",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ComercioItemsEstado",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ComercioRubrosInventarioActiva",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ComercioProductosRubrosID",GXType.Decimal,18,0)
        };
        Object[] prmT002G38;
        prmT002G38 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ComercioProductosRubrosID",GXType.Decimal,18,0)
        };
        Object[] prmT002G39;
        prmT002G39 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT002G40;
        prmT002G40 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G41;
        prmT002G41 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G42;
        prmT002G42 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G43;
        prmT002G43 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT002G44;
        prmT002G44 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G45;
        prmT002G45 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT002G46;
        prmT002G46 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002G47;
        prmT002G47 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T002G2", "SELECT [ProveedorID], [ComercioProductosRubrosID], [ComercioRubrosEstado], [ComercioItemsEstado], [ComercioRubrosInventarioActiva], [RubrosId], [MedidasID], [InventarioId] FROM [ComercioProductosRubros] WITH (UPDLOCK) WHERE [ProveedorID] = @ProveedorID AND [ComercioProductosRubrosID] = @ComercioProductosRubrosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G3", "SELECT [ProveedorID], [ComercioProductosRubrosID], [ComercioRubrosEstado], [ComercioItemsEstado], [ComercioRubrosInventarioActiva], [RubrosId], [MedidasID], [InventarioId] FROM [ComercioProductosRubros] WHERE [ProveedorID] = @ProveedorID AND [ComercioProductosRubrosID] = @ComercioProductosRubrosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G4", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G5", "SELECT [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G6", "SELECT [InventarioNombre], [InventarioImagen_GXI], [EstadosTipo], [EstadosGenericosId], [InventarioImagen] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G7", "SELECT [ProveedorID], [ProveedorNombre], [ProveedorImagen_GXI], [ProveedorEstado], [ComercioProductosREnum], [ProveedorCIU], [ProveedorImagen] FROM [Proveedor] WITH (UPDLOCK) WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G8", "SELECT [ProveedorID], [ProveedorNombre], [ProveedorImagen_GXI], [ProveedorEstado], [ComercioProductosREnum], [ProveedorCIU], [ProveedorImagen] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G9", "SELECT TM1.[ProveedorID], TM1.[ProveedorNombre], TM1.[ProveedorImagen_GXI], TM1.[ProveedorEstado], TM1.[ComercioProductosREnum], TM1.[ProveedorCIU], TM1.[ProveedorImagen] FROM [Proveedor] TM1 WHERE TM1.[ProveedorID] = @ProveedorID ORDER BY TM1.[ProveedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002G9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G10", "SELECT [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002G10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G11", "SELECT TOP 1 [ProveedorID] FROM [Proveedor] WHERE ( [ProveedorID] > @ProveedorID) ORDER BY [ProveedorID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002G11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G12", "SELECT TOP 1 [ProveedorID] FROM [Proveedor] WHERE ( [ProveedorID] < @ProveedorID) ORDER BY [ProveedorID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002G12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G13", "INSERT INTO [Proveedor]([ProveedorNombre], [ProveedorImagen], [ProveedorImagen_GXI], [ProveedorEstado], [ComercioProductosREnum], [ProveedorCIU], [ProveedoresTipoId], [ProveedorDocIdentidad], [ProveedorSerialComi], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorPerAltShop], [ProveedorPagoDefault], [ProveedorPideDoc], [DocumentacionId], [ProveedorUsrAlta], [ProveedorUsrActualizacion], [ProveedorFechaAlta], [ProveedorFechaActualizacion], [ProveedorUsoInterno], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorSitioWeb], [ProveedorAceptoTerminos], [ProveedorCuentaBancaria], [BancoId], [ProveedorFreezePrice]) VALUES(@ProveedorNombre, @ProveedorImagen, @ProveedorImagen_GXI, @ProveedorEstado, @ComercioProductosREnum, @ProveedorCIU, convert(int, 0), '', convert(int, 0), '', '', '', '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), '', '', '', '', '', convert( DATETIME, '17530101', 112 ), '', convert(int, 0), convert(bit, 0)); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT002G13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G14", "UPDATE [Proveedor] SET [ProveedorNombre]=@ProveedorNombre, [ProveedorEstado]=@ProveedorEstado, [ComercioProductosREnum]=@ComercioProductosREnum, [ProveedorCIU]=@ProveedorCIU  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT002G14)
           ,new CursorDef("T002G15", "UPDATE [Proveedor] SET [ProveedorImagen]=@ProveedorImagen, [ProveedorImagen_GXI]=@ProveedorImagen_GXI  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT002G15)
           ,new CursorDef("T002G16", "DELETE FROM [Proveedor]  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT002G16)
           ,new CursorDef("T002G17", "SELECT TOP 1 [PostulacionesId] FROM [Postulaciones] WHERE [PostulacionesProveedorId] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G18", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [STComerciosID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G19", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G20", "SELECT TOP 1 [VincularTrnId] FROM [VincularTrn] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G21", "SELECT TOP 1 [ProfComisionesID], [ProfComisionesRubrosId] FROM [ProfComisionesRubros] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G22", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [STComerciosID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G23", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G24", "SELECT TOP 1 [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G25", "SELECT TOP 1 [Listaid], [SecUserId], [ProveedorID] FROM [ListaAgrUserProveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G26", "SELECT TOP 1 [ComisionesID], [ProveedorID] FROM [ComisionesProveedores] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G27", "SELECT TOP 1 [ProveedorID], [ProveedorSolicitudesId] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G28", "SELECT TOP 1 [ProveedorID], [ProveedorComisionID] FROM [ProveedorComision] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002G29", "UPDATE [Proveedor] SET [ComercioProductosREnum]=@ComercioProductosREnum  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT002G29)
           ,new CursorDef("T002G30", "SELECT [ProveedorID] FROM [Proveedor] ORDER BY [ProveedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002G30,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G31", "SELECT T1.[ProveedorID], T1.[ComercioProductosRubrosID], T1.[ComercioRubrosEstado], T1.[ComercioItemsEstado], T1.[ComercioRubrosInventarioActiva], T2.[RubrosNombre], T2.[RubrosImagen_GXI], T2.[RubrosEstado], T3.[MedidasNombre], T3.[MedidasEstado], T4.[InventarioNombre], T4.[InventarioImagen_GXI], T1.[RubrosId], T1.[MedidasID], T1.[InventarioId], T4.[EstadosTipo], T4.[EstadosGenericosId], T2.[RubrosImagen], T4.[InventarioImagen] FROM ((([ComercioProductosRubros] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) LEFT JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Inventario] T4 ON T4.[RubrosId] = T1.[RubrosId] AND T4.[MedidasID] = T1.[MedidasID] AND T4.[InventarioId] = T1.[InventarioId]) WHERE T1.[ProveedorID] = @ProveedorID and T1.[ComercioProductosRubrosID] = @ComercioProductosRubrosID ORDER BY T1.[ProveedorID], T1.[ComercioProductosRubrosID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G31,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G32", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G33", "SELECT [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G34", "SELECT [InventarioNombre], [InventarioImagen_GXI], [EstadosTipo], [EstadosGenericosId], [InventarioImagen] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G35", "SELECT [ProveedorID], [ComercioProductosRubrosID] FROM [ComercioProductosRubros] WHERE [ProveedorID] = @ProveedorID AND [ComercioProductosRubrosID] = @ComercioProductosRubrosID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G36", "INSERT INTO [ComercioProductosRubros]([ProveedorID], [ComercioProductosRubrosID], [ComercioRubrosEstado], [ComercioItemsEstado], [ComercioRubrosInventarioActiva], [RubrosId], [MedidasID], [InventarioId]) VALUES(@ProveedorID, @ComercioProductosRubrosID, @ComercioRubrosEstado, @ComercioItemsEstado, @ComercioRubrosInventarioActiva, @RubrosId, @MedidasID, @InventarioId)", GxErrorMask.GX_NOMASK,prmT002G36)
           ,new CursorDef("T002G37", "UPDATE [ComercioProductosRubros] SET [ComercioRubrosEstado]=@ComercioRubrosEstado, [ComercioItemsEstado]=@ComercioItemsEstado, [ComercioRubrosInventarioActiva]=@ComercioRubrosInventarioActiva, [RubrosId]=@RubrosId, [MedidasID]=@MedidasID, [InventarioId]=@InventarioId  WHERE [ProveedorID] = @ProveedorID AND [ComercioProductosRubrosID] = @ComercioProductosRubrosID", GxErrorMask.GX_NOMASK,prmT002G37)
           ,new CursorDef("T002G38", "DELETE FROM [ComercioProductosRubros]  WHERE [ProveedorID] = @ProveedorID AND [ComercioProductosRubrosID] = @ComercioProductosRubrosID", GxErrorMask.GX_NOMASK,prmT002G38)
           ,new CursorDef("T002G39", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G39,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G40", "SELECT [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G40,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G41", "SELECT [InventarioNombre], [InventarioImagen_GXI], [EstadosTipo], [EstadosGenericosId], [InventarioImagen] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G41,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G42", "SELECT [ProveedorID], [ComercioProductosRubrosID] FROM [ComercioProductosRubros] WHERE [ProveedorID] = @ProveedorID ORDER BY [ProveedorID], [ComercioProductosRubrosID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G42,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G43", "SELECT [RubrosId], [MedidasID], [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE ([RubrosId] = @RubrosId) AND ([MedidasEstado] <> 'DES') ORDER BY [MedidasNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G43,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G44", "SELECT [RubrosId], [MedidasID], [InventarioId], [InventarioNombre], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE ([RubrosId] = @RubrosId and [MedidasID] = @MedidasID) AND ([EstadosGenericosId] = 1) ORDER BY [InventarioNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G44,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G45", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G45,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G46", "SELECT [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G46,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002G47", "SELECT [InventarioNombre], [InventarioImagen_GXI], [EstadosTipo], [EstadosGenericosId], [InventarioImagen] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002G47,1, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((bool[]) buf[6])[0] = rslt.getBool(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((short[]) buf[8])[0] = rslt.getShort(6);
              ((long[]) buf[9])[0] = rslt.getLong(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((long[]) buf[11])[0] = rslt.getLong(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((bool[]) buf[6])[0] = rslt.getBool(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((short[]) buf[8])[0] = rslt.getShort(6);
              ((long[]) buf[9])[0] = rslt.getLong(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((long[]) buf[11])[0] = rslt.getLong(8);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 50);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(2));
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 3);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((bool[]) buf[6])[0] = rslt.getBool(6);
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 3);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((bool[]) buf[6])[0] = rslt.getBool(6);
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getString(4, 3);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((bool[]) buf[6])[0] = rslt.getBool(6);
              ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
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
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 24 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((bool[]) buf[6])[0] = rslt.getBool(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((string[]) buf[8])[0] = rslt.getString(6, 100);
              ((string[]) buf[9])[0] = rslt.getMultimediaUri(7);
              ((string[]) buf[10])[0] = rslt.getString(8, 3);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getString(9, 50);
              ((string[]) buf[13])[0] = rslt.getString(10, 3);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getString(11, 100);
              ((string[]) buf[16])[0] = rslt.getMultimediaUri(12);
              ((short[]) buf[17])[0] = rslt.getShort(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              ((long[]) buf[20])[0] = rslt.getLong(15);
              ((bool[]) buf[21])[0] = rslt.wasNull(15);
              ((string[]) buf[22])[0] = rslt.getString(16, 3);
              ((int[]) buf[23])[0] = rslt.getInt(17);
              ((string[]) buf[24])[0] = rslt.getMultimediaFile(18, rslt.getVarchar(7));
              ((string[]) buf[25])[0] = rslt.getMultimediaFile(19, rslt.getVarchar(12));
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
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 50);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(2));
              return;
           case 33 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 37 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
              return;
           case 38 :
              ((string[]) buf[0])[0] = rslt.getString(1, 50);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(2));
              return;
           case 40 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 41 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 42 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 43 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
              return;
           case 44 :
              ((string[]) buf[0])[0] = rslt.getString(1, 50);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 45 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(2));
              return;
     }
  }

}

}

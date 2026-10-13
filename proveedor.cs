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
   public class proveedor : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"BANCOID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLABANCOID0N28( ) ;
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
            GXDLARUBROSID0N29( ) ;
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
            GXDLAMEDIDASID0N29( A121RubrosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"INVENTARIOID") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAINVENTARIOID0N29( A121RubrosId, A137MedidasID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_46") == 0 )
         {
            A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProveedoresTipoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_46( A151ProveedoresTipoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_47") == 0 )
         {
            A488DocumentacionId = (long)(Math.Round(NumberUtil.Val( GetPar( "DocumentacionId"), "."), 18, MidpointRounding.ToEven));
            n488DocumentacionId = false;
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_47( A488DocumentacionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_48") == 0 )
         {
            A673BancoId = (long)(Math.Round(NumberUtil.Val( GetPar( "BancoId"), "."), 18, MidpointRounding.ToEven));
            n673BancoId = false;
            AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_48( A673BancoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_50") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_50( A121RubrosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_51") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_51( A121RubrosId, A137MedidasID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_52") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "MedidasID"), "."), 18, MidpointRounding.ToEven));
            A135InventarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "InventarioId"), "."), 18, MidpointRounding.ToEven));
            n135InventarioId = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_52( A121RubrosId, A137MedidasID, A135InventarioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_53") == 0 )
         {
            A107EstadosTipo = GetPar( "EstadosTipo");
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_53( A107EstadosTipo, A108EstadosGenericosId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_comision") == 0 )
         {
            gxnrGridlevel_comision_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "proveedor.aspx")), "proveedor.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "proveedor.aspx")))) ;
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
         Form.Meta.addItem("description", context.GetMessage( "Comercio", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbProveedorEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_comision_newrow_invoke( )
      {
         nRC_GXsfl_176 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_176"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_176_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_176_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_176_idx = GetPar( "sGXsfl_176_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         A345ProveedorSerialComi = (short)(Math.Round(NumberUtil.Val( GetPar( "ProveedorSerialComi"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_comision_newrow( ) ;
         /* End function gxnrGridlevel_comision_newrow_invoke */
      }

      public proveedor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public proveedor( IGxContext context )
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
         chkProveedorFreezePrice = new GXCheckbox();
         dynProveedoresTipoId = new GXCombobox();
         chkProveedorUsoInterno = new GXCheckbox();
         chkProveedorCIU = new GXCheckbox();
         cmbProveedorPagoDefault = new GXCombobox();
         dynBancoId = new GXCombobox();
         dynProveedorUsrAlta = new GXCombobox();
         dynProveedorUsrActualizacion = new GXCombobox();
         dynRubrosId = new GXCombobox();
         dynMedidasID = new GXCombobox();
         dynInventarioId = new GXCombobox();
         chkProveedorComisionFP = new GXCheckbox();
         cmbProveedorComisionTipo = new GXCombobox();
         cmbProveedorComisionAccion = new GXCombobox();
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
         A999ProveedorFreezePrice = StringUtil.StrToBool( StringUtil.BoolToStr( A999ProveedorFreezePrice));
         n999ProveedorFreezePrice = false;
         AssignAttri("", false, "A999ProveedorFreezePrice", A999ProveedorFreezePrice);
         if ( dynProveedoresTipoId.ItemCount > 0 )
         {
            A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( dynProveedoresTipoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynProveedoresTipoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0));
            AssignProp("", false, dynProveedoresTipoId_Internalname, "Values", dynProveedoresTipoId.ToJavascriptSource(), true);
         }
         A601ProveedorUsoInterno = ((StringUtil.StrCmp(StringUtil.RTrim( A601ProveedorUsoInterno), "S")==0) ? "S" : "N");
         n601ProveedorUsoInterno = false;
         AssignAttri("", false, "A601ProveedorUsoInterno", A601ProveedorUsoInterno);
         A978ProveedorCIU = StringUtil.StrToBool( StringUtil.BoolToStr( A978ProveedorCIU));
         AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
         if ( cmbProveedorPagoDefault.ItemCount > 0 )
         {
            A440ProveedorPagoDefault = cmbProveedorPagoDefault.getValidValue(A440ProveedorPagoDefault);
            AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProveedorPagoDefault.CurrentValue = StringUtil.RTrim( A440ProveedorPagoDefault);
            AssignProp("", false, cmbProveedorPagoDefault_Internalname, "Values", cmbProveedorPagoDefault.ToJavascriptSource(), true);
         }
         if ( dynBancoId.ItemCount > 0 )
         {
            A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n673BancoId = false;
            AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynBancoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0));
            AssignProp("", false, dynBancoId_Internalname, "Values", dynBancoId.ToJavascriptSource(), true);
         }
         if ( dynProveedorUsrAlta.ItemCount > 0 )
         {
            A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrAlta.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n546ProveedorUsrAlta = false;
            AssignAttri("", false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynProveedorUsrAlta.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0));
            AssignProp("", false, dynProveedorUsrAlta_Internalname, "Values", dynProveedorUsrAlta.ToJavascriptSource(), true);
         }
         if ( dynProveedorUsrActualizacion.ItemCount > 0 )
         {
            A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrActualizacion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n547ProveedorUsrActualizacion = false;
            AssignAttri("", false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynProveedorUsrActualizacion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
            AssignProp("", false, dynProveedorUsrActualizacion_Internalname, "Values", dynProveedorUsrActualizacion.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
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
         /* User Defined Control */
         ucGxuitabspanel_tabs.SetProperty("PageCount", Gxuitabspanel_tabs_Pagecount);
         ucGxuitabspanel_tabs.SetProperty("Class", Gxuitabspanel_tabs_Class);
         ucGxuitabspanel_tabs.SetProperty("HistoryManagement", Gxuitabspanel_tabs_Historymanagement);
         ucGxuitabspanel_tabs.Render(context, "tab", Gxuitabspanel_tabs_Internalname, "GXUITABSPANEL_TABSContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTabgeneral_title_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), "", "", lblTabgeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Proveedor.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "tabGeneral") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorID_Internalname, context.GetMessage( "Código del Proveedor", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProveedorID_Enabled!=0) ? context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProveedorEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProveedorEstado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProveedorEstado, cmbProveedorEstado_Internalname, StringUtil.RTrim( A344ProveedorEstado), 1, cmbProveedorEstado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbProveedorEstado.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Proveedor.htm");
         cmbProveedorEstado.CurrentValue = StringUtil.RTrim( A344ProveedorEstado);
         AssignProp("", false, cmbProveedorEstado_Internalname, "Values", (string)(cmbProveedorEstado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedproveedorfreezeprice_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockproveedorfreezeprice_Internalname, "", "", "", lblTextblockproveedorfreezeprice_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedproveedorfreezeprice_Internalname, tblTablemergedproveedorfreezeprice_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='MergeDataCell'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkProveedorFreezePrice_Internalname, context.GetMessage( "Freezar Precio", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkProveedorFreezePrice_Internalname, StringUtil.BoolToStr( A999ProveedorFreezePrice), "", context.GetMessage( "Freezar Precio", ""), 1, chkProveedorFreezePrice.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(38, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,38);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblProveedorfreezeprice_righttext_Internalname, context.GetMessage( "Freezar Precios", ""), "", "", lblProveedorfreezeprice_righttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_Proveedor.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynProveedoresTipoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynProveedoresTipoId_Internalname, context.GetMessage( "TipoId", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynProveedoresTipoId, dynProveedoresTipoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0)), 1, dynProveedoresTipoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynProveedoresTipoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, 0, "HLP_Proveedor.htm");
         dynProveedoresTipoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0));
         AssignProp("", false, dynProveedoresTipoId_Internalname, "Values", (string)(dynProveedoresTipoId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorNombre_Internalname, StringUtil.RTrim( A282ProveedorNombre), StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorRazonSocial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorRazonSocial_Internalname, context.GetMessage( "Razón Social", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorRazonSocial_Internalname, StringUtil.RTrim( A682ProveedorRazonSocial), StringUtil.RTrim( context.localUtil.Format( A682ProveedorRazonSocial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorRazonSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorRazonSocial_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorTelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A430ProveedorTelefono);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorTelefono_Internalname, StringUtil.RTrim( A430ProveedorTelefono), StringUtil.RTrim( context.localUtil.Format( A430ProveedorTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProveedorTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorEmail_Internalname, A433ProveedorEmail, StringUtil.RTrim( context.localUtil.Format( A433ProveedorEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A433ProveedorEmail, "", "", "", edtProveedorEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProveedorDireccion_Internalname, A431ProveedorDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A431ProveedorDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", 0, 1, edtProveedorDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedproveedorusointerno_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockproveedorusointerno_Internalname, "", "", "", lblTextblockproveedorusointerno_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTablemergedproveedorusointerno_Internalname, tblTablemergedproveedorusointerno_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='MergeDataCell'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkProveedorUsoInterno_Internalname, context.GetMessage( "¿Es de Uso Interno?", ""), "gx-form-item AttributeCheckBoxLabel", 0, true, "width: 25%;");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkProveedorUsoInterno_Internalname, A601ProveedorUsoInterno, "", context.GetMessage( "¿Es de Uso Interno?", ""), 1, chkProveedorUsoInterno.Enabled, "S", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(85, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,85);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblProveedorusointerno_righttext_Internalname, context.GetMessage( "¿Es de uso Inter?", ""), "", "", lblProveedorusointerno_righttext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_Proveedor.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkProveedorCIU_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkProveedorCIU_Internalname, context.GetMessage( "¿Convenio CIU?", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkProveedorCIU_Internalname, StringUtil.BoolToStr( A978ProveedorCIU), "", context.GetMessage( "¿Convenio CIU?", ""), 1, chkProveedorCIU.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(92, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,92);\"");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProveedorImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A432ProveedorImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen));
         GxWebStd.gx_bitmap( context, imgProveedorImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProveedorImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "", "", "", 0, A432ProveedorImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Proveedor.htm");
         AssignProp("", false, imgProveedorImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.PathToRelativeUrl( A432ProveedorImagen)), true);
         AssignProp("", false, imgProveedorImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A432ProveedorImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProveedorPagoDefault_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProveedorPagoDefault_Internalname, context.GetMessage( "por Default", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProveedorPagoDefault, cmbProveedorPagoDefault_Internalname, StringUtil.RTrim( A440ProveedorPagoDefault), 1, cmbProveedorPagoDefault_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbProveedorPagoDefault.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "", true, 0, "HLP_Proveedor.htm");
         cmbProveedorPagoDefault.CurrentValue = StringUtil.RTrim( A440ProveedorPagoDefault);
         AssignProp("", false, cmbProveedorPagoDefault_Internalname, "Values", (string)(cmbProveedorPagoDefault.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorDocIdentidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorDocIdentidad_Internalname, context.GetMessage( "Documento de Identidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorDocIdentidad_Internalname, StringUtil.RTrim( A338ProveedorDocIdentidad), StringUtil.RTrim( context.localUtil.Format( A338ProveedorDocIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorDocIdentidad_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorDocIdentidad_Enabled, 0, "text", "", 25, "chr", 1, "row", 25, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorSitioWeb_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorSitioWeb_Internalname, context.GetMessage( "Web", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorSitioWeb_Internalname, StringUtil.RTrim( A685ProveedorSitioWeb), StringUtil.RTrim( context.localUtil.Format( A685ProveedorSitioWeb, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorSitioWeb_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorSitioWeb_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorAceptoTerminos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorAceptoTerminos_Internalname, context.GetMessage( "Aceptó Terminos y Condiciones", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProveedorAceptoTerminos_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProveedorAceptoTerminos_Internalname, context.localUtil.TToC( A686ProveedorAceptoTerminos, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A686ProveedorAceptoTerminos, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorAceptoTerminos_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorAceptoTerminos_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proveedor.htm");
         GxWebStd.gx_bitmap( context, edtProveedorAceptoTerminos_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProveedorAceptoTerminos_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Proveedor.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_unnamedtable3.SetProperty("Width", Dvpanel_unnamedtable3_Width);
         ucDvpanel_unnamedtable3.SetProperty("AutoWidth", Dvpanel_unnamedtable3_Autowidth);
         ucDvpanel_unnamedtable3.SetProperty("AutoHeight", Dvpanel_unnamedtable3_Autoheight);
         ucDvpanel_unnamedtable3.SetProperty("Cls", Dvpanel_unnamedtable3_Cls);
         ucDvpanel_unnamedtable3.SetProperty("Title", Dvpanel_unnamedtable3_Title);
         ucDvpanel_unnamedtable3.SetProperty("Collapsible", Dvpanel_unnamedtable3_Collapsible);
         ucDvpanel_unnamedtable3.SetProperty("Collapsed", Dvpanel_unnamedtable3_Collapsed);
         ucDvpanel_unnamedtable3.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable3_Showcollapseicon);
         ucDvpanel_unnamedtable3.SetProperty("IconPosition", Dvpanel_unnamedtable3_Iconposition);
         ucDvpanel_unnamedtable3.SetProperty("AutoScroll", Dvpanel_unnamedtable3_Autoscroll);
         ucDvpanel_unnamedtable3.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable3_Internalname, "DVPANEL_UNNAMEDTABLE3Container");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE3Container"+"UnnamedTable3"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorContacto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorContacto_Internalname, context.GetMessage( "Nombre del Contacto", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorContacto_Internalname, StringUtil.RTrim( A683ProveedorContacto), StringUtil.RTrim( context.localUtil.Format( A683ProveedorContacto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorContacto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorContacto_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorContactoCell_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorContactoCell_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A684ProveedorContactoCell);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorContactoCell_Internalname, StringUtil.RTrim( A684ProveedorContactoCell), StringUtil.RTrim( context.localUtil.Format( A684ProveedorContactoCell, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProveedorContactoCell_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorContactoCell_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Proveedor.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynBancoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynBancoId_Internalname, context.GetMessage( "Banco", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynBancoId, dynBancoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0)), 1, dynBancoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynBancoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "", true, 0, "HLP_Proveedor.htm");
         dynBancoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0));
         AssignProp("", false, dynBancoId_Internalname, "Values", (string)(dynBancoId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorCuentaBancaria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorCuentaBancaria_Internalname, context.GetMessage( "Cuenta Bancaria", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorCuentaBancaria_Internalname, StringUtil.RTrim( A687ProveedorCuentaBancaria), StringUtil.RTrim( context.localUtil.Format( A687ProveedorCuentaBancaria, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorCuentaBancaria_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorCuentaBancaria_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "CuentaBancari", "start", true, "", "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, context.GetMessage( "Auditoría", ""), 1, 0, "px", 0, "px", "Group", "", "HLP_Proveedor.htm");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblUnnamedtable1_Internalname, tblUnnamedtable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynProveedorUsrAlta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynProveedorUsrAlta_Internalname, context.GetMessage( "Alta", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynProveedorUsrAlta, dynProveedorUsrAlta_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0)), 1, dynProveedorUsrAlta_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynProveedorUsrAlta.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,152);\"", "", true, 0, "HLP_Proveedor.htm");
         dynProveedorUsrAlta.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0));
         AssignProp("", false, dynProveedorUsrAlta_Internalname, "Values", (string)(dynProveedorUsrAlta.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynProveedorUsrActualizacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynProveedorUsrActualizacion_Internalname, context.GetMessage( "Actualizacion", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynProveedorUsrActualizacion, dynProveedorUsrActualizacion_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0)), 1, dynProveedorUsrActualizacion_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynProveedorUsrActualizacion.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"", "", true, 0, "HLP_Proveedor.htm");
         dynProveedorUsrActualizacion.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
         AssignProp("", false, dynProveedorUsrActualizacion_Internalname, "Values", (string)(dynProveedorUsrActualizacion.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorFechaAlta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorFechaAlta_Internalname, context.GetMessage( "Alta", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProveedorFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProveedorFechaAlta_Internalname, context.localUtil.TToC( A548ProveedorFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A548ProveedorFechaAlta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorFechaAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorFechaAlta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proveedor.htm");
         GxWebStd.gx_bitmap( context, edtProveedorFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProveedorFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Proveedor.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='DataContentCellFL'>") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtProveedorFechaActualizacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProveedorFechaActualizacion_Internalname, context.GetMessage( "Actualizacion", ""), "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProveedorFechaActualizacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProveedorFechaActualizacion_Internalname, context.localUtil.TToC( A549ProveedorFechaActualizacion, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A549ProveedorFechaActualizacion, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,165);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorFechaActualizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProveedorFechaActualizacion_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proveedor.htm");
         GxWebStd.gx_bitmap( context, edtProveedorFechaActualizacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProveedorFechaActualizacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Proveedor.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_comision_title_Internalname, context.GetMessage( "Comisiones", ""), "", "", lblTablevel_comision_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Proveedor.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_Comision") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_comision_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_comision_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_comision( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proveedor.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proveedor.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorSerialComi_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A345ProveedorSerialComi), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProveedorSerialComi_Enabled!=0) ? context.localUtil.Format( (decimal)(A345ProveedorSerialComi), "ZZZ9") : context.localUtil.Format( (decimal)(A345ProveedorSerialComi), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,204);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorSerialComi_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedorSerialComi_Visible, edtProveedorSerialComi_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proveedor.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 205,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorPerAltShop_Internalname, StringUtil.RTrim( A437ProveedorPerAltShop), StringUtil.RTrim( context.localUtil.Format( A437ProveedorPerAltShop, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,205);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorPerAltShop_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedorPerAltShop_Visible, edtProveedorPerAltShop_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Proveedor.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProveedorPideDoc_Internalname, StringUtil.RTrim( A490ProveedorPideDoc), StringUtil.RTrim( context.localUtil.Format( A490ProveedorPideDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,206);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProveedorPideDoc_Jsonclick, 0, "Attribute", "", "", "", "", edtProveedorPideDoc_Visible, edtProveedorPideDoc_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Proveedor.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentacionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A488DocumentacionId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,207);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentacionId_Jsonclick, 0, "Attribute", "", "", "", "", edtDocumentacionId_Visible, edtDocumentacionId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Proveedor.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_488_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_488_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_488_Internalname, sImgUrl, imgprompt_488_Link, "", "", context.GetTheme( ), imgprompt_488_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "''", "HLP_Proveedor.htm");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 208,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A498DocumentacionIcono_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001DocumentacionIcono_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.PathToRelativeUrl( A498DocumentacionIcono));
         GxWebStd.gx_bitmap( context, imgDocumentacionIcono_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDocumentacionIcono_Visible, imgDocumentacionIcono_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,208);\"", "", "", "", 0, A498DocumentacionIcono_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Proveedor.htm");
         AssignProp("", false, imgDocumentacionIcono_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.PathToRelativeUrl( A498DocumentacionIcono)), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "IsBlob", StringUtil.BoolToStr( A498DocumentacionIcono_IsBlob), true);
         /* User Defined Control */
         ucGridlevel_comision_titlescategories.Render(context, "dvelop.gridtitlescategories", Gridlevel_comision_titlescategories_Internalname, "GRIDLEVEL_COMISION_TITLESCATEGORIESContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_comision( )
      {
         /*  Grid Control  */
         StartGridControl176( ) ;
         nGXsfl_176_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount29 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_29 = 1;
               ScanStart0N29( ) ;
               while ( RcdFound29 != 0 )
               {
                  init_level_properties29( ) ;
                  getByPrimaryKey0N29( ) ;
                  AddRow0N29( ) ;
                  ScanNext0N29( ) ;
               }
               ScanEnd0N29( ) ;
               nBlankRcdCount29 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B345ProveedorSerialComi = A345ProveedorSerialComi;
            AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
            standaloneNotModal0N29( ) ;
            standaloneModal0N29( ) ;
            sMode29 = Gx_mode;
            while ( nGXsfl_176_idx < nRC_GXsfl_176 )
            {
               bGXsfl_176_Refreshing = true;
               ReadRow0N29( ) ;
               edtProveedorComisionID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORCOMISIONID_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorComisionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorComisionID_Enabled), 5, 0), !bGXsfl_176_Refreshing);
               dynRubrosId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), !bGXsfl_176_Refreshing);
               edtRubrosImagen_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSIMAGEN_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtRubrosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosImagen_Enabled), 5, 0), !bGXsfl_176_Refreshing);
               dynMedidasID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASID_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_176_Refreshing);
               dynInventarioId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOID_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_176_Refreshing);
               edtMonedaId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MONEDAID_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaId_Enabled), 5, 0), !bGXsfl_176_Refreshing);
               edtEstadosTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSTIPO_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), !bGXsfl_176_Refreshing);
               edtEstadosGenericosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSID_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), !bGXsfl_176_Refreshing);
               edtEstadosGenericosNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSNOMBRE_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtEstadosGenericosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0), !bGXsfl_176_Refreshing);
               edtInventarioPrecioFinal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOPRECIOFINAL_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInventarioPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0), !bGXsfl_176_Refreshing);
               chkProveedorComisionFP.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORCOMISIONFP_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, chkProveedorComisionFP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProveedorComisionFP.Enabled), 5, 0), !bGXsfl_176_Refreshing);
               edtProveedorComisionFPF_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORCOMISIONFPF_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorComisionFPF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorComisionFPF_Enabled), 5, 0), !bGXsfl_176_Refreshing);
               cmbProveedorComisionTipo.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORCOMISIONTIPO_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbProveedorComisionTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorComisionTipo.Enabled), 5, 0), !bGXsfl_176_Refreshing);
               edtProveedorComision_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORCOMISION_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProveedorComision_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorComision_Enabled), 5, 0), !bGXsfl_176_Refreshing);
               cmbProveedorComisionAccion.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORCOMISIONACCION_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbProveedorComisionAccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorComisionAccion.Enabled), 5, 0), !bGXsfl_176_Refreshing);
               if ( ( nRcdExists_29 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0N29( ) ;
               }
               SendRow0N29( ) ;
               bGXsfl_176_Refreshing = false;
            }
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A345ProveedorSerialComi = B345ProveedorSerialComi;
            AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount29 = 5;
            nRcdExists_29 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0N29( ) ;
               while ( RcdFound29 != 0 )
               {
                  sGXsfl_176_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_176_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_17629( ) ;
                  init_level_properties29( ) ;
                  standaloneNotModal0N29( ) ;
                  getByPrimaryKey0N29( ) ;
                  standaloneModal0N29( ) ;
                  AddRow0N29( ) ;
                  ScanNext0N29( ) ;
               }
               ScanEnd0N29( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode29 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_176_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_176_idx+1), 4, 0), 4, "0");
            SubsflControlProps_17629( ) ;
            InitAll0N29( ) ;
            init_level_properties29( ) ;
            B345ProveedorSerialComi = A345ProveedorSerialComi;
            AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
            nRcdExists_29 = 0;
            nIsMod_29 = 0;
            nRcdDeleted_29 = 0;
            nBlankRcdCount29 = (short)(nBlankRcdUsr29+nBlankRcdCount29);
            fRowAdded = 0;
            while ( nBlankRcdCount29 > 0 )
            {
               standaloneNotModal0N29( ) ;
               standaloneModal0N29( ) ;
               AddRow0N29( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = dynRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount29 = (short)(nBlankRcdCount29-1);
            }
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A345ProveedorSerialComi = B345ProveedorSerialComi;
            AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_comisionContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_comision", Gridlevel_comisionContainer, subGridlevel_comision_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_comisionContainerData", Gridlevel_comisionContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_comisionContainerData"+"V", Gridlevel_comisionContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_comisionContainerData"+"V"+"\" value='"+Gridlevel_comisionContainer.GridValuesHidden()+"'/>") ;
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
         E110N2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z133ProveedorID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z546ProveedorUsrAlta = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z546ProveedorUsrAlta"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n546ProveedorUsrAlta = ((0==A546ProveedorUsrAlta) ? true : false);
               Z547ProveedorUsrActualizacion = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z547ProveedorUsrActualizacion"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n547ProveedorUsrActualizacion = ((0==A547ProveedorUsrActualizacion) ? true : false);
               Z548ProveedorFechaAlta = context.localUtil.CToT( cgiGet( "Z548ProveedorFechaAlta"), 0);
               n548ProveedorFechaAlta = ((DateTime.MinValue==A548ProveedorFechaAlta) ? true : false);
               Z549ProveedorFechaActualizacion = context.localUtil.CToT( cgiGet( "Z549ProveedorFechaActualizacion"), 0);
               n549ProveedorFechaActualizacion = ((DateTime.MinValue==A549ProveedorFechaActualizacion) ? true : false);
               Z282ProveedorNombre = cgiGet( "Z282ProveedorNombre");
               Z682ProveedorRazonSocial = cgiGet( "Z682ProveedorRazonSocial");
               n682ProveedorRazonSocial = (String.IsNullOrEmpty(StringUtil.RTrim( A682ProveedorRazonSocial)) ? true : false);
               Z683ProveedorContacto = cgiGet( "Z683ProveedorContacto");
               n683ProveedorContacto = (String.IsNullOrEmpty(StringUtil.RTrim( A683ProveedorContacto)) ? true : false);
               Z684ProveedorContactoCell = cgiGet( "Z684ProveedorContactoCell");
               n684ProveedorContactoCell = (String.IsNullOrEmpty(StringUtil.RTrim( A684ProveedorContactoCell)) ? true : false);
               Z338ProveedorDocIdentidad = cgiGet( "Z338ProveedorDocIdentidad");
               Z345ProveedorSerialComi = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z345ProveedorSerialComi"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z430ProveedorTelefono = cgiGet( "Z430ProveedorTelefono");
               n430ProveedorTelefono = (String.IsNullOrEmpty(StringUtil.RTrim( A430ProveedorTelefono)) ? true : false);
               Z431ProveedorDireccion = cgiGet( "Z431ProveedorDireccion");
               n431ProveedorDireccion = (String.IsNullOrEmpty(StringUtil.RTrim( A431ProveedorDireccion)) ? true : false);
               Z433ProveedorEmail = cgiGet( "Z433ProveedorEmail");
               n433ProveedorEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ? true : false);
               Z685ProveedorSitioWeb = cgiGet( "Z685ProveedorSitioWeb");
               n685ProveedorSitioWeb = (String.IsNullOrEmpty(StringUtil.RTrim( A685ProveedorSitioWeb)) ? true : false);
               Z686ProveedorAceptoTerminos = context.localUtil.CToT( cgiGet( "Z686ProveedorAceptoTerminos"), 0);
               n686ProveedorAceptoTerminos = ((DateTime.MinValue==A686ProveedorAceptoTerminos) ? true : false);
               Z437ProveedorPerAltShop = cgiGet( "Z437ProveedorPerAltShop");
               n437ProveedorPerAltShop = (String.IsNullOrEmpty(StringUtil.RTrim( A437ProveedorPerAltShop)) ? true : false);
               Z344ProveedorEstado = cgiGet( "Z344ProveedorEstado");
               Z440ProveedorPagoDefault = cgiGet( "Z440ProveedorPagoDefault");
               Z490ProveedorPideDoc = cgiGet( "Z490ProveedorPideDoc");
               n490ProveedorPideDoc = (String.IsNullOrEmpty(StringUtil.RTrim( A490ProveedorPideDoc)) ? true : false);
               Z601ProveedorUsoInterno = cgiGet( "Z601ProveedorUsoInterno");
               n601ProveedorUsoInterno = (String.IsNullOrEmpty(StringUtil.RTrim( A601ProveedorUsoInterno)) ? true : false);
               Z687ProveedorCuentaBancaria = cgiGet( "Z687ProveedorCuentaBancaria");
               n687ProveedorCuentaBancaria = (String.IsNullOrEmpty(StringUtil.RTrim( A687ProveedorCuentaBancaria)) ? true : false);
               Z978ProveedorCIU = StringUtil.StrToBool( cgiGet( "Z978ProveedorCIU"));
               Z999ProveedorFreezePrice = StringUtil.StrToBool( cgiGet( "Z999ProveedorFreezePrice"));
               n999ProveedorFreezePrice = ((false==A999ProveedorFreezePrice) ? true : false);
               Z151ProveedoresTipoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z151ProveedoresTipoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z488DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z488DocumentacionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n488DocumentacionId = ((0==A488DocumentacionId) ? true : false);
               Z673BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z673BancoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n673BancoId = ((0==A673BancoId) ? true : false);
               O345ProveedorSerialComi = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O345ProveedorSerialComi"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_176 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_176"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N151ProveedoresTipoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N151ProveedoresTipoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N488DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N488DocumentacionId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n488DocumentacionId = ((0==A488DocumentacionId) ? true : false);
               N673BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N673BancoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n673BancoId = ((0==A673BancoId) ? true : false);
               AV7ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vPROVEEDORID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_ProveedoresTipoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROVEEDORESTIPOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13Insert_ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(AV13Insert_ProveedoresTipoId), 18, 0));
               AV14Insert_DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_DOCUMENTACIONID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14Insert_DocumentacionId", StringUtil.LTrimStr( (decimal)(AV14Insert_DocumentacionId), 18, 0));
               AV36Insert_BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_BANCOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV36Insert_BancoId", StringUtil.LTrimStr( (decimal)(AV36Insert_BancoId), 18, 0));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A40000ProveedorImagen_GXI = cgiGet( "PROVEEDORIMAGEN_GXI");
               n40000ProveedorImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
               A278ProveedoresTipoNombre = cgiGet( "PROVEEDORESTIPONOMBRE");
               A40001DocumentacionIcono_GXI = cgiGet( "DOCUMENTACIONICONO_GXI");
               A674BancoNombre = cgiGet( "BANCONOMBRE");
               AV40Pgmname = cgiGet( "vPGMNAME");
               A40002RubrosImagen_GXI = cgiGet( "RUBROSIMAGEN_GXI");
               A136InventarioNombre = cgiGet( "INVENTARIONOMBRE");
               Dvpanel_unnamedtable3_Objectcall = cgiGet( "DVPANEL_UNNAMEDTABLE3_Objectcall");
               Dvpanel_unnamedtable3_Class = cgiGet( "DVPANEL_UNNAMEDTABLE3_Class");
               Dvpanel_unnamedtable3_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Enabled"));
               Dvpanel_unnamedtable3_Width = cgiGet( "DVPANEL_UNNAMEDTABLE3_Width");
               Dvpanel_unnamedtable3_Height = cgiGet( "DVPANEL_UNNAMEDTABLE3_Height");
               Dvpanel_unnamedtable3_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Autowidth"));
               Dvpanel_unnamedtable3_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Autoheight"));
               Dvpanel_unnamedtable3_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE3_Cls");
               Dvpanel_unnamedtable3_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Showheader"));
               Dvpanel_unnamedtable3_Title = cgiGet( "DVPANEL_UNNAMEDTABLE3_Title");
               Dvpanel_unnamedtable3_Titletype = cgiGet( "DVPANEL_UNNAMEDTABLE3_Titletype");
               Dvpanel_unnamedtable3_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Collapsible"));
               Dvpanel_unnamedtable3_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Collapsed"));
               Dvpanel_unnamedtable3_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Showcollapseicon"));
               Dvpanel_unnamedtable3_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE3_Iconposition");
               Dvpanel_unnamedtable3_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Autoscroll"));
               Dvpanel_unnamedtable3_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE3_Visible"));
               Dvpanel_unnamedtable3_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_UNNAMEDTABLE3_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Objectcall = cgiGet( "GXUITABSPANEL_TABS_Objectcall");
               Gxuitabspanel_tabs_Enabled = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Enabled"));
               Gxuitabspanel_tabs_Activepage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Activepage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Activepagecontrolname = cgiGet( "GXUITABSPANEL_TABS_Activepagecontrolname");
               Gxuitabspanel_tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
               Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
               Gxuitabspanel_tabs_Visible = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Visible"));
               Gridlevel_comision_titlescategories_Objectcall = cgiGet( "GRIDLEVEL_COMISION_TITLESCATEGORIES_Objectcall");
               Gridlevel_comision_titlescategories_Class = cgiGet( "GRIDLEVEL_COMISION_TITLESCATEGORIES_Class");
               Gridlevel_comision_titlescategories_Enabled = StringUtil.StrToBool( cgiGet( "GRIDLEVEL_COMISION_TITLESCATEGORIES_Enabled"));
               Gridlevel_comision_titlescategories_Gridinternalname = cgiGet( "GRIDLEVEL_COMISION_TITLESCATEGORIES_Gridinternalname");
               Gridlevel_comision_titlescategories_Gridtitlescategories = cgiGet( "GRIDLEVEL_COMISION_TITLESCATEGORIES_Gridtitlescategories");
               Gridlevel_comision_titlescategories_Visible = StringUtil.StrToBool( cgiGet( "GRIDLEVEL_COMISION_TITLESCATEGORIES_Visible"));
               /* Read variables values. */
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n133ProveedorID = false;
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               cmbProveedorEstado.Name = cmbProveedorEstado_Internalname;
               cmbProveedorEstado.CurrentValue = cgiGet( cmbProveedorEstado_Internalname);
               A344ProveedorEstado = cgiGet( cmbProveedorEstado_Internalname);
               AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
               A999ProveedorFreezePrice = StringUtil.StrToBool( cgiGet( chkProveedorFreezePrice_Internalname));
               n999ProveedorFreezePrice = false;
               AssignAttri("", false, "A999ProveedorFreezePrice", A999ProveedorFreezePrice);
               n999ProveedorFreezePrice = ((false==A999ProveedorFreezePrice) ? true : false);
               dynProveedoresTipoId.Name = dynProveedoresTipoId_Internalname;
               dynProveedoresTipoId.CurrentValue = cgiGet( dynProveedoresTipoId_Internalname);
               A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynProveedoresTipoId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
               A282ProveedorNombre = cgiGet( edtProveedorNombre_Internalname);
               AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
               A682ProveedorRazonSocial = cgiGet( edtProveedorRazonSocial_Internalname);
               n682ProveedorRazonSocial = false;
               AssignAttri("", false, "A682ProveedorRazonSocial", A682ProveedorRazonSocial);
               n682ProveedorRazonSocial = (String.IsNullOrEmpty(StringUtil.RTrim( A682ProveedorRazonSocial)) ? true : false);
               A430ProveedorTelefono = cgiGet( edtProveedorTelefono_Internalname);
               n430ProveedorTelefono = false;
               AssignAttri("", false, "A430ProveedorTelefono", A430ProveedorTelefono);
               n430ProveedorTelefono = (String.IsNullOrEmpty(StringUtil.RTrim( A430ProveedorTelefono)) ? true : false);
               A433ProveedorEmail = cgiGet( edtProveedorEmail_Internalname);
               n433ProveedorEmail = false;
               AssignAttri("", false, "A433ProveedorEmail", A433ProveedorEmail);
               n433ProveedorEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ? true : false);
               A431ProveedorDireccion = cgiGet( edtProveedorDireccion_Internalname);
               n431ProveedorDireccion = false;
               AssignAttri("", false, "A431ProveedorDireccion", A431ProveedorDireccion);
               n431ProveedorDireccion = (String.IsNullOrEmpty(StringUtil.RTrim( A431ProveedorDireccion)) ? true : false);
               A601ProveedorUsoInterno = ((StringUtil.StrCmp(cgiGet( chkProveedorUsoInterno_Internalname), "S")==0) ? "S" : "N");
               n601ProveedorUsoInterno = false;
               AssignAttri("", false, "A601ProveedorUsoInterno", A601ProveedorUsoInterno);
               n601ProveedorUsoInterno = (String.IsNullOrEmpty(StringUtil.RTrim( A601ProveedorUsoInterno)) ? true : false);
               A978ProveedorCIU = StringUtil.StrToBool( cgiGet( chkProveedorCIU_Internalname));
               AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
               A432ProveedorImagen = cgiGet( imgProveedorImagen_Internalname);
               n432ProveedorImagen = false;
               AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
               n432ProveedorImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
               cmbProveedorPagoDefault.Name = cmbProveedorPagoDefault_Internalname;
               cmbProveedorPagoDefault.CurrentValue = cgiGet( cmbProveedorPagoDefault_Internalname);
               A440ProveedorPagoDefault = cgiGet( cmbProveedorPagoDefault_Internalname);
               AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
               A338ProveedorDocIdentidad = cgiGet( edtProveedorDocIdentidad_Internalname);
               AssignAttri("", false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
               A685ProveedorSitioWeb = cgiGet( edtProveedorSitioWeb_Internalname);
               n685ProveedorSitioWeb = false;
               AssignAttri("", false, "A685ProveedorSitioWeb", A685ProveedorSitioWeb);
               n685ProveedorSitioWeb = (String.IsNullOrEmpty(StringUtil.RTrim( A685ProveedorSitioWeb)) ? true : false);
               A686ProveedorAceptoTerminos = context.localUtil.CToT( cgiGet( edtProveedorAceptoTerminos_Internalname));
               n686ProveedorAceptoTerminos = false;
               AssignAttri("", false, "A686ProveedorAceptoTerminos", context.localUtil.TToC( A686ProveedorAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A683ProveedorContacto = cgiGet( edtProveedorContacto_Internalname);
               n683ProveedorContacto = false;
               AssignAttri("", false, "A683ProveedorContacto", A683ProveedorContacto);
               n683ProveedorContacto = (String.IsNullOrEmpty(StringUtil.RTrim( A683ProveedorContacto)) ? true : false);
               A684ProveedorContactoCell = cgiGet( edtProveedorContactoCell_Internalname);
               n684ProveedorContactoCell = false;
               AssignAttri("", false, "A684ProveedorContactoCell", A684ProveedorContactoCell);
               n684ProveedorContactoCell = (String.IsNullOrEmpty(StringUtil.RTrim( A684ProveedorContactoCell)) ? true : false);
               dynBancoId.Name = dynBancoId_Internalname;
               dynBancoId.CurrentValue = cgiGet( dynBancoId_Internalname);
               A673BancoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynBancoId_Internalname), "."), 18, MidpointRounding.ToEven));
               n673BancoId = false;
               AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
               n673BancoId = ((0==A673BancoId) ? true : false);
               A687ProveedorCuentaBancaria = cgiGet( edtProveedorCuentaBancaria_Internalname);
               n687ProveedorCuentaBancaria = false;
               AssignAttri("", false, "A687ProveedorCuentaBancaria", A687ProveedorCuentaBancaria);
               n687ProveedorCuentaBancaria = (String.IsNullOrEmpty(StringUtil.RTrim( A687ProveedorCuentaBancaria)) ? true : false);
               dynProveedorUsrAlta.Name = dynProveedorUsrAlta_Internalname;
               dynProveedorUsrAlta.CurrentValue = cgiGet( dynProveedorUsrAlta_Internalname);
               A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( cgiGet( dynProveedorUsrAlta_Internalname), "."), 18, MidpointRounding.ToEven));
               n546ProveedorUsrAlta = false;
               AssignAttri("", false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
               dynProveedorUsrActualizacion.Name = dynProveedorUsrActualizacion_Internalname;
               dynProveedorUsrActualizacion.CurrentValue = cgiGet( dynProveedorUsrActualizacion_Internalname);
               A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( cgiGet( dynProveedorUsrActualizacion_Internalname), "."), 18, MidpointRounding.ToEven));
               n547ProveedorUsrActualizacion = false;
               AssignAttri("", false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
               A548ProveedorFechaAlta = context.localUtil.CToT( cgiGet( edtProveedorFechaAlta_Internalname));
               n548ProveedorFechaAlta = false;
               AssignAttri("", false, "A548ProveedorFechaAlta", context.localUtil.TToC( A548ProveedorFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A549ProveedorFechaActualizacion = context.localUtil.CToT( cgiGet( edtProveedorFechaActualizacion_Internalname));
               n549ProveedorFechaActualizacion = false;
               AssignAttri("", false, "A549ProveedorFechaActualizacion", context.localUtil.TToC( A549ProveedorFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A345ProveedorSerialComi = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorSerialComi_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
               A437ProveedorPerAltShop = cgiGet( edtProveedorPerAltShop_Internalname);
               n437ProveedorPerAltShop = false;
               AssignAttri("", false, "A437ProveedorPerAltShop", A437ProveedorPerAltShop);
               n437ProveedorPerAltShop = (String.IsNullOrEmpty(StringUtil.RTrim( A437ProveedorPerAltShop)) ? true : false);
               A490ProveedorPideDoc = cgiGet( edtProveedorPideDoc_Internalname);
               n490ProveedorPideDoc = false;
               AssignAttri("", false, "A490ProveedorPideDoc", A490ProveedorPideDoc);
               n490ProveedorPideDoc = (String.IsNullOrEmpty(StringUtil.RTrim( A490ProveedorPideDoc)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtDocumentacionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocumentacionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCUMENTACIONID");
                  AnyError = 1;
                  GX_FocusControl = edtDocumentacionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A488DocumentacionId = 0;
                  n488DocumentacionId = false;
                  AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
               }
               else
               {
                  A488DocumentacionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDocumentacionId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n488DocumentacionId = false;
                  AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
               }
               n488DocumentacionId = ((0==A488DocumentacionId) ? true : false);
               A498DocumentacionIcono = cgiGet( imgDocumentacionIcono_Internalname);
               AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProveedorImagen_Internalname, ref  A432ProveedorImagen, ref  A40000ProveedorImagen_GXI);
               n40000ProveedorImagen_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ProveedorImagen_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
               n432ProveedorImagen = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? true : false);
               getMultimediaValue(imgDocumentacionIcono_Internalname, ref  A498DocumentacionIcono, ref  A40001DocumentacionIcono_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Proveedor");
               A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n133ProveedorID = false;
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               forbiddenHiddens.Add("ProveedorID", context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
               A686ProveedorAceptoTerminos = context.localUtil.CToT( cgiGet( edtProveedorAceptoTerminos_Internalname));
               n686ProveedorAceptoTerminos = false;
               AssignAttri("", false, "A686ProveedorAceptoTerminos", context.localUtil.TToC( A686ProveedorAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               forbiddenHiddens.Add("ProveedorAceptoTerminos", context.localUtil.Format( A686ProveedorAceptoTerminos, "99/99/99 99:99"));
               A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( cgiGet( dynProveedorUsrAlta_Internalname), "."), 18, MidpointRounding.ToEven));
               n546ProveedorUsrAlta = false;
               AssignAttri("", false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
               forbiddenHiddens.Add("ProveedorUsrAlta", context.localUtil.Format( (decimal)(A546ProveedorUsrAlta), "ZZZZZZZZZ9"));
               A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( cgiGet( dynProveedorUsrActualizacion_Internalname), "."), 18, MidpointRounding.ToEven));
               n547ProveedorUsrActualizacion = false;
               AssignAttri("", false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
               forbiddenHiddens.Add("ProveedorUsrActualizacion", context.localUtil.Format( (decimal)(A547ProveedorUsrActualizacion), "ZZZZZZZZZ9"));
               A548ProveedorFechaAlta = context.localUtil.CToT( cgiGet( edtProveedorFechaAlta_Internalname));
               n548ProveedorFechaAlta = false;
               AssignAttri("", false, "A548ProveedorFechaAlta", context.localUtil.TToC( A548ProveedorFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               forbiddenHiddens.Add("ProveedorFechaAlta", context.localUtil.Format( A548ProveedorFechaAlta, "99/99/99 99:99"));
               A549ProveedorFechaActualizacion = context.localUtil.CToT( cgiGet( edtProveedorFechaActualizacion_Internalname));
               n549ProveedorFechaActualizacion = false;
               AssignAttri("", false, "A549ProveedorFechaActualizacion", context.localUtil.TToC( A549ProveedorFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               forbiddenHiddens.Add("ProveedorFechaActualizacion", context.localUtil.Format( A549ProveedorFechaActualizacion, "99/99/99 99:99"));
               forbiddenHiddens.Add("Insert_ProveedoresTipoId", context.localUtil.Format( (decimal)(AV13Insert_ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_DocumentacionId", context.localUtil.Format( (decimal)(AV14Insert_DocumentacionId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_BancoId", context.localUtil.Format( (decimal)(AV36Insert_BancoId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A133ProveedorID != Z133ProveedorID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("proveedor:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                           CONFIRM_0N0( ) ;
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
                           E110N2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120N2 ();
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
            E120N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0N28( ) ;
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
            DisableAttributes0N28( ) ;
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

      protected void CONFIRM_0N0( )
      {
         BeforeValidate0N28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0N28( ) ;
            }
            else
            {
               CheckExtendedTable0N28( ) ;
               CloseExtendedTableCursors0N28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode28 = Gx_mode;
            CONFIRM_0N29( ) ;
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

      protected void CONFIRM_0N29( )
      {
         s345ProveedorSerialComi = O345ProveedorSerialComi;
         AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
         nGXsfl_176_idx = 0;
         while ( nGXsfl_176_idx < nRC_GXsfl_176 )
         {
            ReadRow0N29( ) ;
            if ( ( nRcdExists_29 != 0 ) || ( nIsMod_29 != 0 ) )
            {
               GetKey0N29( ) ;
               if ( ( nRcdExists_29 == 0 ) && ( nRcdDeleted_29 == 0 ) )
               {
                  if ( RcdFound29 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0N29( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0N29( ) ;
                        CloseExtendedTableCursors0N29( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O345ProveedorSerialComi = A345ProveedorSerialComi;
                        AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
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
                  if ( RcdFound29 != 0 )
                  {
                     if ( nRcdDeleted_29 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0N29( ) ;
                        Load0N29( ) ;
                        BeforeValidate0N29( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0N29( ) ;
                           O345ProveedorSerialComi = A345ProveedorSerialComi;
                           AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_29 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0N29( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0N29( ) ;
                              CloseExtendedTableCursors0N29( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O345ProveedorSerialComi = A345ProveedorSerialComi;
                              AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_29 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtProveedorComisionID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A157ProveedorComisionID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( dynRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))) ;
            ChangePostValue( edtRubrosImagen_Internalname, A168RubrosImagen) ;
            ChangePostValue( dynMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))) ;
            ChangePostValue( dynInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))) ;
            ChangePostValue( edtMonedaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo)) ;
            ChangePostValue( edtEstadosGenericosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtEstadosGenericosNombre_Internalname, StringUtil.RTrim( A109EstadosGenericosNombre)) ;
            ChangePostValue( edtInventarioPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( chkProveedorComisionFP_Internalname, StringUtil.BoolToStr( A1001ProveedorComisionFP)) ;
            ChangePostValue( edtProveedorComisionFPF_Internalname, StringUtil.LTrim( StringUtil.NToC( A1000ProveedorComisionFPF, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbProveedorComisionTipo_Internalname, StringUtil.RTrim( A346ProveedorComisionTipo)) ;
            ChangePostValue( edtProveedorComision_Internalname, StringUtil.LTrim( StringUtil.NToC( A347ProveedorComision, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbProveedorComisionAccion_Internalname, StringUtil.RTrim( A348ProveedorComisionAccion)) ;
            ChangePostValue( "ZT_"+"Z157ProveedorComisionID_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z157ProveedorComisionID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z348ProveedorComisionAccion_"+sGXsfl_176_idx, StringUtil.RTrim( Z348ProveedorComisionAccion)) ;
            ChangePostValue( "ZT_"+"Z1001ProveedorComisionFP_"+sGXsfl_176_idx, StringUtil.BoolToStr( Z1001ProveedorComisionFP)) ;
            ChangePostValue( "ZT_"+"Z1000ProveedorComisionFPF_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( Z1000ProveedorComisionFPF, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z346ProveedorComisionTipo_"+sGXsfl_176_idx, StringUtil.RTrim( Z346ProveedorComisionTipo)) ;
            ChangePostValue( "ZT_"+"Z347ProveedorComision_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( Z347ProveedorComision, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_29_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_29), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_29_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_29), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_29_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_29), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_29 != 0 )
            {
               ChangePostValue( "PROVEEDORCOMISIONID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorComisionID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynRubrosId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSIMAGEN_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MONEDAID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSTIPO_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGENERICOSID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGENERICOSNOMBRE_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOPRECIOFINAL_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORCOMISIONFP_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkProveedorComisionFP.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORCOMISIONFPF_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorComisionFPF_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORCOMISIONTIPO_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorComisionTipo.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORCOMISION_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorComision_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORCOMISIONACCION_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorComisionAccion.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O345ProveedorSerialComi = s345ProveedorSerialComi;
         AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0N0( )
      {
      }

      protected void E110N2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor_Delete", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( ! AV9IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV40Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV40Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV41GXV1 = 1;
            AssignAttri("", false, "AV41GXV1", StringUtil.LTrimStr( (decimal)(AV41GXV1), 8, 0));
            while ( AV41GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV41GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ProveedoresTipoId") == 0 )
               {
                  AV13Insert_ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(AV13Insert_ProveedoresTipoId), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "DocumentacionId") == 0 )
               {
                  AV14Insert_DocumentacionId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_DocumentacionId", StringUtil.LTrimStr( (decimal)(AV14Insert_DocumentacionId), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "BancoId") == 0 )
               {
                  AV36Insert_BancoId = (long)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV36Insert_BancoId", StringUtil.LTrimStr( (decimal)(AV36Insert_BancoId), 18, 0));
               }
               AV41GXV1 = (int)(AV41GXV1+1);
               AssignAttri("", false, "AV41GXV1", StringUtil.LTrimStr( (decimal)(AV41GXV1), 8, 0));
            }
         }
         edtProveedorSerialComi_Visible = 0;
         AssignProp("", false, edtProveedorSerialComi_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorSerialComi_Visible), 5, 0), true);
         edtProveedorPerAltShop_Visible = 0;
         AssignProp("", false, edtProveedorPerAltShop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorPerAltShop_Visible), 5, 0), true);
         edtProveedorPideDoc_Visible = 0;
         AssignProp("", false, edtProveedorPideDoc_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProveedorPideDoc_Visible), 5, 0), true);
         edtDocumentacionId_Visible = 0;
         AssignProp("", false, edtDocumentacionId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocumentacionId_Visible), 5, 0), true);
         imgDocumentacionIcono_Visible = 0;
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDocumentacionIcono_Visible), 5, 0), true);
         Gridlevel_comision_titlescategories_Gridinternalname = subGridlevel_comision_Internalname;
         ucGridlevel_comision_titlescategories.SendProperty(context, "", false, Gridlevel_comision_titlescategories_Internalname, "GridInternalName", Gridlevel_comision_titlescategories_Gridinternalname);
         Gridlevel_comision_titlescategories_Gridtitlescategories = StringUtil.Format( ";;%1;%1;%1;%1;;;;;;;;;;", context.GetMessage( "SERVICIO", ""), "", "", "", "", "", "", "", "");
         ucGridlevel_comision_titlescategories.SendProperty(context, "", false, Gridlevel_comision_titlescategories_Internalname, "GridTitlesCategories", Gridlevel_comision_titlescategories_Gridtitlescategories);
         /* Execute user subroutine: 'OBTENGO ROL' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("proveedorww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'OBTENGO ROL' Routine */
         returnInSub = false;
         AV31Roles = AV8WWPContext.gxTpr_Roles;
         AV42GXV2 = 1;
         while ( AV42GXV2 <= AV31Roles.gxTpr_Roles.Count )
         {
            AV32RolesItem = ((SdtSDTRoles_Id)AV31Roles.gxTpr_Roles.Item(AV42GXV2));
            AV34SecRoleName = AV32RolesItem.gxTpr_Secrolename;
            AV42GXV2 = (int)(AV42GXV2+1);
         }
         if ( ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV34SecRoleName)), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( AV34SecRoleName)), context.GetMessage( "ADM GENERAL", "")) == 0 ) ) )
         {
         }
         else
         {
            new olisagruserprovid(context ).execute(  AV8WWPContext.gxTpr_Userid,  AV7ProveedorID,  "ADM", out  AV37Existe, out  AV33AgrProveedorEstado) ;
            if ( StringUtil.StrCmp(AV33AgrProveedorEstado, "VIN") != 0 )
            {
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void ZM0N28( short GX_JID )
      {
         if ( ( GX_JID == 45 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z546ProveedorUsrAlta = T000N9_A546ProveedorUsrAlta[0];
               Z547ProveedorUsrActualizacion = T000N9_A547ProveedorUsrActualizacion[0];
               Z548ProveedorFechaAlta = T000N9_A548ProveedorFechaAlta[0];
               Z549ProveedorFechaActualizacion = T000N9_A549ProveedorFechaActualizacion[0];
               Z282ProveedorNombre = T000N9_A282ProveedorNombre[0];
               Z682ProveedorRazonSocial = T000N9_A682ProveedorRazonSocial[0];
               Z683ProveedorContacto = T000N9_A683ProveedorContacto[0];
               Z684ProveedorContactoCell = T000N9_A684ProveedorContactoCell[0];
               Z338ProveedorDocIdentidad = T000N9_A338ProveedorDocIdentidad[0];
               Z345ProveedorSerialComi = T000N9_A345ProveedorSerialComi[0];
               Z430ProveedorTelefono = T000N9_A430ProveedorTelefono[0];
               Z431ProveedorDireccion = T000N9_A431ProveedorDireccion[0];
               Z433ProveedorEmail = T000N9_A433ProveedorEmail[0];
               Z685ProveedorSitioWeb = T000N9_A685ProveedorSitioWeb[0];
               Z686ProveedorAceptoTerminos = T000N9_A686ProveedorAceptoTerminos[0];
               Z437ProveedorPerAltShop = T000N9_A437ProveedorPerAltShop[0];
               Z344ProveedorEstado = T000N9_A344ProveedorEstado[0];
               Z440ProveedorPagoDefault = T000N9_A440ProveedorPagoDefault[0];
               Z490ProveedorPideDoc = T000N9_A490ProveedorPideDoc[0];
               Z601ProveedorUsoInterno = T000N9_A601ProveedorUsoInterno[0];
               Z687ProveedorCuentaBancaria = T000N9_A687ProveedorCuentaBancaria[0];
               Z978ProveedorCIU = T000N9_A978ProveedorCIU[0];
               Z999ProveedorFreezePrice = T000N9_A999ProveedorFreezePrice[0];
               Z151ProveedoresTipoId = T000N9_A151ProveedoresTipoId[0];
               Z488DocumentacionId = T000N9_A488DocumentacionId[0];
               Z673BancoId = T000N9_A673BancoId[0];
            }
            else
            {
               Z546ProveedorUsrAlta = A546ProveedorUsrAlta;
               Z547ProveedorUsrActualizacion = A547ProveedorUsrActualizacion;
               Z548ProveedorFechaAlta = A548ProveedorFechaAlta;
               Z549ProveedorFechaActualizacion = A549ProveedorFechaActualizacion;
               Z282ProveedorNombre = A282ProveedorNombre;
               Z682ProveedorRazonSocial = A682ProveedorRazonSocial;
               Z683ProveedorContacto = A683ProveedorContacto;
               Z684ProveedorContactoCell = A684ProveedorContactoCell;
               Z338ProveedorDocIdentidad = A338ProveedorDocIdentidad;
               Z345ProveedorSerialComi = A345ProveedorSerialComi;
               Z430ProveedorTelefono = A430ProveedorTelefono;
               Z431ProveedorDireccion = A431ProveedorDireccion;
               Z433ProveedorEmail = A433ProveedorEmail;
               Z685ProveedorSitioWeb = A685ProveedorSitioWeb;
               Z686ProveedorAceptoTerminos = A686ProveedorAceptoTerminos;
               Z437ProveedorPerAltShop = A437ProveedorPerAltShop;
               Z344ProveedorEstado = A344ProveedorEstado;
               Z440ProveedorPagoDefault = A440ProveedorPagoDefault;
               Z490ProveedorPideDoc = A490ProveedorPideDoc;
               Z601ProveedorUsoInterno = A601ProveedorUsoInterno;
               Z687ProveedorCuentaBancaria = A687ProveedorCuentaBancaria;
               Z978ProveedorCIU = A978ProveedorCIU;
               Z999ProveedorFreezePrice = A999ProveedorFreezePrice;
               Z151ProveedoresTipoId = A151ProveedoresTipoId;
               Z488DocumentacionId = A488DocumentacionId;
               Z673BancoId = A673BancoId;
            }
         }
         if ( GX_JID == -45 )
         {
            Z133ProveedorID = A133ProveedorID;
            Z546ProveedorUsrAlta = A546ProveedorUsrAlta;
            Z547ProveedorUsrActualizacion = A547ProveedorUsrActualizacion;
            Z548ProveedorFechaAlta = A548ProveedorFechaAlta;
            Z549ProveedorFechaActualizacion = A549ProveedorFechaActualizacion;
            Z282ProveedorNombre = A282ProveedorNombre;
            Z682ProveedorRazonSocial = A682ProveedorRazonSocial;
            Z683ProveedorContacto = A683ProveedorContacto;
            Z684ProveedorContactoCell = A684ProveedorContactoCell;
            Z432ProveedorImagen = A432ProveedorImagen;
            Z40000ProveedorImagen_GXI = A40000ProveedorImagen_GXI;
            Z338ProveedorDocIdentidad = A338ProveedorDocIdentidad;
            Z345ProveedorSerialComi = A345ProveedorSerialComi;
            Z430ProveedorTelefono = A430ProveedorTelefono;
            Z431ProveedorDireccion = A431ProveedorDireccion;
            Z433ProveedorEmail = A433ProveedorEmail;
            Z685ProveedorSitioWeb = A685ProveedorSitioWeb;
            Z686ProveedorAceptoTerminos = A686ProveedorAceptoTerminos;
            Z437ProveedorPerAltShop = A437ProveedorPerAltShop;
            Z344ProveedorEstado = A344ProveedorEstado;
            Z440ProveedorPagoDefault = A440ProveedorPagoDefault;
            Z490ProveedorPideDoc = A490ProveedorPideDoc;
            Z601ProveedorUsoInterno = A601ProveedorUsoInterno;
            Z687ProveedorCuentaBancaria = A687ProveedorCuentaBancaria;
            Z978ProveedorCIU = A978ProveedorCIU;
            Z999ProveedorFreezePrice = A999ProveedorFreezePrice;
            Z151ProveedoresTipoId = A151ProveedoresTipoId;
            Z488DocumentacionId = A488DocumentacionId;
            Z673BancoId = A673BancoId;
            Z278ProveedoresTipoNombre = A278ProveedoresTipoNombre;
            Z498DocumentacionIcono = A498DocumentacionIcono;
            Z40001DocumentacionIcono_GXI = A40001DocumentacionIcono_GXI;
            Z674BancoNombre = A674BancoNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         GXABANCOID_html0N28( ) ;
         dynProveedorUsrAlta.Enabled = 0;
         AssignProp("", false, dynProveedorUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorUsrAlta.Enabled), 5, 0), true);
         dynProveedorUsrActualizacion.Enabled = 0;
         AssignProp("", false, dynProveedorUsrActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorUsrActualizacion.Enabled), 5, 0), true);
         edtProveedorFechaAlta_Enabled = 0;
         AssignProp("", false, edtProveedorFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorFechaAlta_Enabled), 5, 0), true);
         edtProveedorFechaActualizacion_Enabled = 0;
         AssignProp("", false, edtProveedorFechaActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorFechaActualizacion_Enabled), 5, 0), true);
         edtProveedorAceptoTerminos_Enabled = 0;
         AssignProp("", false, edtProveedorAceptoTerminos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorAceptoTerminos_Enabled), 5, 0), true);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtProveedorSerialComi_Enabled = 0;
         AssignProp("", false, edtProveedorSerialComi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSerialComi_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_488_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0200.aspx"+"',["+"{Ctrl:gx.dom.el('"+"DOCUMENTACIONID"+"'), id:'"+"DOCUMENTACIONID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         dynProveedorUsrAlta.Enabled = 0;
         AssignProp("", false, dynProveedorUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorUsrAlta.Enabled), 5, 0), true);
         dynProveedorUsrActualizacion.Enabled = 0;
         AssignProp("", false, dynProveedorUsrActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorUsrActualizacion.Enabled), 5, 0), true);
         edtProveedorFechaAlta_Enabled = 0;
         AssignProp("", false, edtProveedorFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorFechaAlta_Enabled), 5, 0), true);
         edtProveedorFechaActualizacion_Enabled = 0;
         AssignProp("", false, edtProveedorFechaActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorFechaActualizacion_Enabled), 5, 0), true);
         edtProveedorAceptoTerminos_Enabled = 0;
         AssignProp("", false, edtProveedorAceptoTerminos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorAceptoTerminos_Enabled), 5, 0), true);
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         edtProveedorSerialComi_Enabled = 0;
         AssignProp("", false, edtProveedorSerialComi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSerialComi_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ProveedorID) )
         {
            A133ProveedorID = AV7ProveedorID;
            n133ProveedorID = false;
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ProveedoresTipoId) )
         {
            dynProveedoresTipoId.Enabled = 0;
            AssignProp("", false, dynProveedoresTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedoresTipoId.Enabled), 5, 0), true);
         }
         else
         {
            dynProveedoresTipoId.Enabled = 1;
            AssignProp("", false, dynProveedoresTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedoresTipoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_DocumentacionId) )
         {
            edtDocumentacionId_Enabled = 0;
            AssignProp("", false, edtDocumentacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentacionId_Enabled), 5, 0), true);
         }
         else
         {
            edtDocumentacionId_Enabled = 1;
            AssignProp("", false, edtDocumentacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentacionId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV36Insert_BancoId) )
         {
            dynBancoId.Enabled = 0;
            AssignProp("", false, dynBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBancoId.Enabled), 5, 0), true);
         }
         else
         {
            dynBancoId.Enabled = 1;
            AssignProp("", false, dynBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBancoId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A548ProveedorFechaAlta = DateTimeUtil.ServerNow( context, pr_default);
            n548ProveedorFechaAlta = false;
            AssignAttri("", false, "A548ProveedorFechaAlta", context.localUtil.TToC( A548ProveedorFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            A549ProveedorFechaActualizacion = DateTimeUtil.ServerNow( context, pr_default);
            n549ProveedorFechaActualizacion = false;
            AssignAttri("", false, "A549ProveedorFechaActualizacion", context.localUtil.TToC( A549ProveedorFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV36Insert_BancoId) )
         {
            A673BancoId = AV36Insert_BancoId;
            n673BancoId = false;
            AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_DocumentacionId) )
         {
            A488DocumentacionId = AV14Insert_DocumentacionId;
            n488DocumentacionId = false;
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_ProveedoresTipoId) )
         {
            A151ProveedoresTipoId = AV13Insert_ProveedoresTipoId;
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A546ProveedorUsrAlta = AV8WWPContext.gxTpr_Userid;
            n546ProveedorUsrAlta = false;
            AssignAttri("", false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            A547ProveedorUsrActualizacion = AV8WWPContext.gxTpr_Userid;
            n547ProveedorUsrActualizacion = false;
            AssignAttri("", false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
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
         if ( IsIns( )  && (false==A978ProveedorCIU) && ( Gx_BScreen == 0 ) )
         {
            A978ProveedorCIU = false;
            AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A344ProveedorEstado)) && ( Gx_BScreen == 0 ) )
         {
            A344ProveedorEstado = "PEN";
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A437ProveedorPerAltShop)) && ( Gx_BScreen == 0 ) )
         {
            A437ProveedorPerAltShop = context.GetMessage( context.GetMessage( "N", ""), "");
            n437ProveedorPerAltShop = false;
            AssignAttri("", false, "A437ProveedorPerAltShop", A437ProveedorPerAltShop);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A490ProveedorPideDoc)) && ( Gx_BScreen == 0 ) )
         {
            A490ProveedorPideDoc = context.GetMessage( context.GetMessage( "N", ""), "");
            n490ProveedorPideDoc = false;
            AssignAttri("", false, "A490ProveedorPideDoc", A490ProveedorPideDoc);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A440ProveedorPagoDefault)) && ( Gx_BScreen == 0 ) )
         {
            A440ProveedorPagoDefault = "T";
            AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
         }
         if ( IsIns( )  && (false==A999ProveedorFreezePrice) && ( Gx_BScreen == 0 ) )
         {
            A999ProveedorFreezePrice = false;
            n999ProveedorFreezePrice = false;
            AssignAttri("", false, "A999ProveedorFreezePrice", A999ProveedorFreezePrice);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000N12 */
            pr_default.execute(10, new Object[] {n673BancoId, A673BancoId});
            A674BancoNombre = T000N12_A674BancoNombre[0];
            pr_default.close(10);
            AV40Pgmname = "Proveedor";
            AssignAttri("", false, "AV40Pgmname", AV40Pgmname);
            /* Using cursor T000N11 */
            pr_default.execute(9, new Object[] {n488DocumentacionId, A488DocumentacionId});
            A40001DocumentacionIcono_GXI = T000N11_A40001DocumentacionIcono_GXI[0];
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A498DocumentacionIcono = T000N11_A498DocumentacionIcono[0];
            AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            pr_default.close(9);
            /* Using cursor T000N10 */
            pr_default.execute(8, new Object[] {A151ProveedoresTipoId});
            A278ProveedoresTipoNombre = T000N10_A278ProveedoresTipoNombre[0];
            pr_default.close(8);
         }
      }

      protected void Load0N28( )
      {
         /* Using cursor T000N13 */
         pr_default.execute(11, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound28 = 1;
            A546ProveedorUsrAlta = T000N13_A546ProveedorUsrAlta[0];
            n546ProveedorUsrAlta = T000N13_n546ProveedorUsrAlta[0];
            AssignAttri("", false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
            A547ProveedorUsrActualizacion = T000N13_A547ProveedorUsrActualizacion[0];
            n547ProveedorUsrActualizacion = T000N13_n547ProveedorUsrActualizacion[0];
            AssignAttri("", false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
            A548ProveedorFechaAlta = T000N13_A548ProveedorFechaAlta[0];
            n548ProveedorFechaAlta = T000N13_n548ProveedorFechaAlta[0];
            AssignAttri("", false, "A548ProveedorFechaAlta", context.localUtil.TToC( A548ProveedorFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A549ProveedorFechaActualizacion = T000N13_A549ProveedorFechaActualizacion[0];
            n549ProveedorFechaActualizacion = T000N13_n549ProveedorFechaActualizacion[0];
            AssignAttri("", false, "A549ProveedorFechaActualizacion", context.localUtil.TToC( A549ProveedorFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A278ProveedoresTipoNombre = T000N13_A278ProveedoresTipoNombre[0];
            A282ProveedorNombre = T000N13_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A682ProveedorRazonSocial = T000N13_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = T000N13_n682ProveedorRazonSocial[0];
            AssignAttri("", false, "A682ProveedorRazonSocial", A682ProveedorRazonSocial);
            A683ProveedorContacto = T000N13_A683ProveedorContacto[0];
            n683ProveedorContacto = T000N13_n683ProveedorContacto[0];
            AssignAttri("", false, "A683ProveedorContacto", A683ProveedorContacto);
            A684ProveedorContactoCell = T000N13_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = T000N13_n684ProveedorContactoCell[0];
            AssignAttri("", false, "A684ProveedorContactoCell", A684ProveedorContactoCell);
            A40000ProveedorImagen_GXI = T000N13_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = T000N13_n40000ProveedorImagen_GXI[0];
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A338ProveedorDocIdentidad = T000N13_A338ProveedorDocIdentidad[0];
            AssignAttri("", false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
            A345ProveedorSerialComi = T000N13_A345ProveedorSerialComi[0];
            AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
            A430ProveedorTelefono = T000N13_A430ProveedorTelefono[0];
            n430ProveedorTelefono = T000N13_n430ProveedorTelefono[0];
            AssignAttri("", false, "A430ProveedorTelefono", A430ProveedorTelefono);
            A431ProveedorDireccion = T000N13_A431ProveedorDireccion[0];
            n431ProveedorDireccion = T000N13_n431ProveedorDireccion[0];
            AssignAttri("", false, "A431ProveedorDireccion", A431ProveedorDireccion);
            A433ProveedorEmail = T000N13_A433ProveedorEmail[0];
            n433ProveedorEmail = T000N13_n433ProveedorEmail[0];
            AssignAttri("", false, "A433ProveedorEmail", A433ProveedorEmail);
            A685ProveedorSitioWeb = T000N13_A685ProveedorSitioWeb[0];
            n685ProveedorSitioWeb = T000N13_n685ProveedorSitioWeb[0];
            AssignAttri("", false, "A685ProveedorSitioWeb", A685ProveedorSitioWeb);
            A686ProveedorAceptoTerminos = T000N13_A686ProveedorAceptoTerminos[0];
            n686ProveedorAceptoTerminos = T000N13_n686ProveedorAceptoTerminos[0];
            AssignAttri("", false, "A686ProveedorAceptoTerminos", context.localUtil.TToC( A686ProveedorAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A437ProveedorPerAltShop = T000N13_A437ProveedorPerAltShop[0];
            n437ProveedorPerAltShop = T000N13_n437ProveedorPerAltShop[0];
            AssignAttri("", false, "A437ProveedorPerAltShop", A437ProveedorPerAltShop);
            A344ProveedorEstado = T000N13_A344ProveedorEstado[0];
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
            A440ProveedorPagoDefault = T000N13_A440ProveedorPagoDefault[0];
            AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
            A490ProveedorPideDoc = T000N13_A490ProveedorPideDoc[0];
            n490ProveedorPideDoc = T000N13_n490ProveedorPideDoc[0];
            AssignAttri("", false, "A490ProveedorPideDoc", A490ProveedorPideDoc);
            A40001DocumentacionIcono_GXI = T000N13_A40001DocumentacionIcono_GXI[0];
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A601ProveedorUsoInterno = T000N13_A601ProveedorUsoInterno[0];
            n601ProveedorUsoInterno = T000N13_n601ProveedorUsoInterno[0];
            AssignAttri("", false, "A601ProveedorUsoInterno", A601ProveedorUsoInterno);
            A687ProveedorCuentaBancaria = T000N13_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = T000N13_n687ProveedorCuentaBancaria[0];
            AssignAttri("", false, "A687ProveedorCuentaBancaria", A687ProveedorCuentaBancaria);
            A674BancoNombre = T000N13_A674BancoNombre[0];
            A978ProveedorCIU = T000N13_A978ProveedorCIU[0];
            AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
            A999ProveedorFreezePrice = T000N13_A999ProveedorFreezePrice[0];
            n999ProveedorFreezePrice = T000N13_n999ProveedorFreezePrice[0];
            AssignAttri("", false, "A999ProveedorFreezePrice", A999ProveedorFreezePrice);
            A151ProveedoresTipoId = T000N13_A151ProveedoresTipoId[0];
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            A488DocumentacionId = T000N13_A488DocumentacionId[0];
            n488DocumentacionId = T000N13_n488DocumentacionId[0];
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
            A673BancoId = T000N13_A673BancoId[0];
            n673BancoId = T000N13_n673BancoId[0];
            AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            A432ProveedorImagen = T000N13_A432ProveedorImagen[0];
            n432ProveedorImagen = T000N13_n432ProveedorImagen[0];
            AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A498DocumentacionIcono = T000N13_A498DocumentacionIcono[0];
            AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            ZM0N28( -45) ;
         }
         pr_default.close(11);
         OnLoadActions0N28( ) ;
      }

      protected void OnLoadActions0N28( )
      {
         AV40Pgmname = "Proveedor";
         AssignAttri("", false, "AV40Pgmname", AV40Pgmname);
      }

      protected void CheckExtendedTable0N28( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV40Pgmname = "Proveedor";
         AssignAttri("", false, "AV40Pgmname", AV40Pgmname);
         /* Using cursor T000N10 */
         pr_default.execute(8, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
            GX_FocusControl = dynProveedoresTipoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A278ProveedoresTipoNombre = T000N10_A278ProveedoresTipoNombre[0];
         pr_default.close(8);
         if ( ! ( GxRegex.IsMatch(A433ProveedorEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PROVEEDOREMAIL");
            AnyError = 1;
            GX_FocusControl = edtProveedorEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) || ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) || ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) || ( StringUtil.StrCmp(A344ProveedorEstado, "BLO") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Proveedor Estado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PROVEEDORESTADO");
            AnyError = 1;
            GX_FocusControl = cmbProveedorEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) || ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) || ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Pago por Default", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PROVEEDORPAGODEFAULT");
            AnyError = 1;
            GX_FocusControl = cmbProveedorPagoDefault_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000N11 */
         pr_default.execute(9, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A488DocumentacionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Documentacion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DOCUMENTACIONID");
               AnyError = 1;
               GX_FocusControl = edtDocumentacionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A40001DocumentacionIcono_GXI = T000N11_A40001DocumentacionIcono_GXI[0];
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         A498DocumentacionIcono = T000N11_A498DocumentacionIcono[0];
         AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         pr_default.close(9);
         /* Using cursor T000N12 */
         pr_default.execute(10, new Object[] {n673BancoId, A673BancoId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A673BancoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Banco", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
               GX_FocusControl = dynBancoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A674BancoNombre = T000N12_A674BancoNombre[0];
         pr_default.close(10);
      }

      protected void CloseExtendedTableCursors0N28( )
      {
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_46( long A151ProveedoresTipoId )
      {
         /* Using cursor T000N14 */
         pr_default.execute(12, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
            GX_FocusControl = dynProveedoresTipoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A278ProveedoresTipoNombre = T000N14_A278ProveedoresTipoNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A278ProveedoresTipoNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_47( long A488DocumentacionId )
      {
         /* Using cursor T000N15 */
         pr_default.execute(13, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A488DocumentacionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Documentacion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DOCUMENTACIONID");
               AnyError = 1;
               GX_FocusControl = edtDocumentacionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A40001DocumentacionIcono_GXI = T000N15_A40001DocumentacionIcono_GXI[0];
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         A498DocumentacionIcono = T000N15_A498DocumentacionIcono[0];
         AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A498DocumentacionIcono)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40001DocumentacionIcono_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_48( long A673BancoId )
      {
         /* Using cursor T000N16 */
         pr_default.execute(14, new Object[] {n673BancoId, A673BancoId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A673BancoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Banco", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
               GX_FocusControl = dynBancoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A674BancoNombre = T000N16_A674BancoNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A674BancoNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey0N28( )
      {
         /* Using cursor T000N17 */
         pr_default.execute(15, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000N9 */
         pr_default.execute(7, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM0N28( 45) ;
            RcdFound28 = 1;
            A133ProveedorID = T000N9_A133ProveedorID[0];
            n133ProveedorID = T000N9_n133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
            A546ProveedorUsrAlta = T000N9_A546ProveedorUsrAlta[0];
            n546ProveedorUsrAlta = T000N9_n546ProveedorUsrAlta[0];
            AssignAttri("", false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
            A547ProveedorUsrActualizacion = T000N9_A547ProveedorUsrActualizacion[0];
            n547ProveedorUsrActualizacion = T000N9_n547ProveedorUsrActualizacion[0];
            AssignAttri("", false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
            A548ProveedorFechaAlta = T000N9_A548ProveedorFechaAlta[0];
            n548ProveedorFechaAlta = T000N9_n548ProveedorFechaAlta[0];
            AssignAttri("", false, "A548ProveedorFechaAlta", context.localUtil.TToC( A548ProveedorFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A549ProveedorFechaActualizacion = T000N9_A549ProveedorFechaActualizacion[0];
            n549ProveedorFechaActualizacion = T000N9_n549ProveedorFechaActualizacion[0];
            AssignAttri("", false, "A549ProveedorFechaActualizacion", context.localUtil.TToC( A549ProveedorFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A282ProveedorNombre = T000N9_A282ProveedorNombre[0];
            AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
            A682ProveedorRazonSocial = T000N9_A682ProveedorRazonSocial[0];
            n682ProveedorRazonSocial = T000N9_n682ProveedorRazonSocial[0];
            AssignAttri("", false, "A682ProveedorRazonSocial", A682ProveedorRazonSocial);
            A683ProveedorContacto = T000N9_A683ProveedorContacto[0];
            n683ProveedorContacto = T000N9_n683ProveedorContacto[0];
            AssignAttri("", false, "A683ProveedorContacto", A683ProveedorContacto);
            A684ProveedorContactoCell = T000N9_A684ProveedorContactoCell[0];
            n684ProveedorContactoCell = T000N9_n684ProveedorContactoCell[0];
            AssignAttri("", false, "A684ProveedorContactoCell", A684ProveedorContactoCell);
            A40000ProveedorImagen_GXI = T000N9_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = T000N9_n40000ProveedorImagen_GXI[0];
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            A338ProveedorDocIdentidad = T000N9_A338ProveedorDocIdentidad[0];
            AssignAttri("", false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
            A345ProveedorSerialComi = T000N9_A345ProveedorSerialComi[0];
            AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
            A430ProveedorTelefono = T000N9_A430ProveedorTelefono[0];
            n430ProveedorTelefono = T000N9_n430ProveedorTelefono[0];
            AssignAttri("", false, "A430ProveedorTelefono", A430ProveedorTelefono);
            A431ProveedorDireccion = T000N9_A431ProveedorDireccion[0];
            n431ProveedorDireccion = T000N9_n431ProveedorDireccion[0];
            AssignAttri("", false, "A431ProveedorDireccion", A431ProveedorDireccion);
            A433ProveedorEmail = T000N9_A433ProveedorEmail[0];
            n433ProveedorEmail = T000N9_n433ProveedorEmail[0];
            AssignAttri("", false, "A433ProveedorEmail", A433ProveedorEmail);
            A685ProveedorSitioWeb = T000N9_A685ProveedorSitioWeb[0];
            n685ProveedorSitioWeb = T000N9_n685ProveedorSitioWeb[0];
            AssignAttri("", false, "A685ProveedorSitioWeb", A685ProveedorSitioWeb);
            A686ProveedorAceptoTerminos = T000N9_A686ProveedorAceptoTerminos[0];
            n686ProveedorAceptoTerminos = T000N9_n686ProveedorAceptoTerminos[0];
            AssignAttri("", false, "A686ProveedorAceptoTerminos", context.localUtil.TToC( A686ProveedorAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A437ProveedorPerAltShop = T000N9_A437ProveedorPerAltShop[0];
            n437ProveedorPerAltShop = T000N9_n437ProveedorPerAltShop[0];
            AssignAttri("", false, "A437ProveedorPerAltShop", A437ProveedorPerAltShop);
            A344ProveedorEstado = T000N9_A344ProveedorEstado[0];
            AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
            A440ProveedorPagoDefault = T000N9_A440ProveedorPagoDefault[0];
            AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
            A490ProveedorPideDoc = T000N9_A490ProveedorPideDoc[0];
            n490ProveedorPideDoc = T000N9_n490ProveedorPideDoc[0];
            AssignAttri("", false, "A490ProveedorPideDoc", A490ProveedorPideDoc);
            A601ProveedorUsoInterno = T000N9_A601ProveedorUsoInterno[0];
            n601ProveedorUsoInterno = T000N9_n601ProveedorUsoInterno[0];
            AssignAttri("", false, "A601ProveedorUsoInterno", A601ProveedorUsoInterno);
            A687ProveedorCuentaBancaria = T000N9_A687ProveedorCuentaBancaria[0];
            n687ProveedorCuentaBancaria = T000N9_n687ProveedorCuentaBancaria[0];
            AssignAttri("", false, "A687ProveedorCuentaBancaria", A687ProveedorCuentaBancaria);
            A978ProveedorCIU = T000N9_A978ProveedorCIU[0];
            AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
            A999ProveedorFreezePrice = T000N9_A999ProveedorFreezePrice[0];
            n999ProveedorFreezePrice = T000N9_n999ProveedorFreezePrice[0];
            AssignAttri("", false, "A999ProveedorFreezePrice", A999ProveedorFreezePrice);
            A151ProveedoresTipoId = T000N9_A151ProveedoresTipoId[0];
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
            A488DocumentacionId = T000N9_A488DocumentacionId[0];
            n488DocumentacionId = T000N9_n488DocumentacionId[0];
            AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
            A673BancoId = T000N9_A673BancoId[0];
            n673BancoId = T000N9_n673BancoId[0];
            AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            A432ProveedorImagen = T000N9_A432ProveedorImagen[0];
            n432ProveedorImagen = T000N9_n432ProveedorImagen[0];
            AssignAttri("", false, "A432ProveedorImagen", A432ProveedorImagen);
            AssignProp("", false, imgProveedorImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : context.convertURL( context.PathToRelativeUrl( A432ProveedorImagen))), true);
            AssignProp("", false, imgProveedorImagen_Internalname, "SrcSet", context.GetImageSrcSet( A432ProveedorImagen), true);
            O345ProveedorSerialComi = A345ProveedorSerialComi;
            AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
            Z133ProveedorID = A133ProveedorID;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0N28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0N28( ) ;
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0N28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N28( ) ;
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
         /* Using cursor T000N18 */
         pr_default.execute(16, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T000N18_A133ProveedorID[0] < A133ProveedorID ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T000N18_A133ProveedorID[0] > A133ProveedorID ) ) )
            {
               A133ProveedorID = T000N18_A133ProveedorID[0];
               n133ProveedorID = T000N18_n133ProveedorID[0];
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound28 = 0;
         /* Using cursor T000N19 */
         pr_default.execute(17, new Object[] {n133ProveedorID, A133ProveedorID});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T000N19_A133ProveedorID[0] > A133ProveedorID ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T000N19_A133ProveedorID[0] < A133ProveedorID ) ) )
            {
               A133ProveedorID = T000N19_A133ProveedorID[0];
               n133ProveedorID = T000N19_n133ProveedorID[0];
               AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0N28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A345ProveedorSerialComi = O345ProveedorSerialComi;
            AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
            GX_FocusControl = cmbProveedorEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0N28( ) ;
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
                  A345ProveedorSerialComi = O345ProveedorSerialComi;
                  AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbProveedorEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A345ProveedorSerialComi = O345ProveedorSerialComi;
                  AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
                  Update0N28( ) ;
                  GX_FocusControl = cmbProveedorEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A133ProveedorID != Z133ProveedorID )
               {
                  /* Insert record */
                  A345ProveedorSerialComi = O345ProveedorSerialComi;
                  AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
                  GX_FocusControl = cmbProveedorEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0N28( ) ;
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
                     A345ProveedorSerialComi = O345ProveedorSerialComi;
                     AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
                     GX_FocusControl = cmbProveedorEstado_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0N28( ) ;
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
            A345ProveedorSerialComi = O345ProveedorSerialComi;
            AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbProveedorEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0N28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000N8 */
            pr_default.execute(6, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(6) == 101) || ( Z546ProveedorUsrAlta != T000N8_A546ProveedorUsrAlta[0] ) || ( Z547ProveedorUsrActualizacion != T000N8_A547ProveedorUsrActualizacion[0] ) || ( Z548ProveedorFechaAlta != T000N8_A548ProveedorFechaAlta[0] ) || ( Z549ProveedorFechaActualizacion != T000N8_A549ProveedorFechaActualizacion[0] ) || ( StringUtil.StrCmp(Z282ProveedorNombre, T000N8_A282ProveedorNombre[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z682ProveedorRazonSocial, T000N8_A682ProveedorRazonSocial[0]) != 0 ) || ( StringUtil.StrCmp(Z683ProveedorContacto, T000N8_A683ProveedorContacto[0]) != 0 ) || ( StringUtil.StrCmp(Z684ProveedorContactoCell, T000N8_A684ProveedorContactoCell[0]) != 0 ) || ( StringUtil.StrCmp(Z338ProveedorDocIdentidad, T000N8_A338ProveedorDocIdentidad[0]) != 0 ) || ( Z345ProveedorSerialComi != T000N8_A345ProveedorSerialComi[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z430ProveedorTelefono, T000N8_A430ProveedorTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z431ProveedorDireccion, T000N8_A431ProveedorDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z433ProveedorEmail, T000N8_A433ProveedorEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z685ProveedorSitioWeb, T000N8_A685ProveedorSitioWeb[0]) != 0 ) || ( Z686ProveedorAceptoTerminos != T000N8_A686ProveedorAceptoTerminos[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z437ProveedorPerAltShop, T000N8_A437ProveedorPerAltShop[0]) != 0 ) || ( StringUtil.StrCmp(Z344ProveedorEstado, T000N8_A344ProveedorEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z440ProveedorPagoDefault, T000N8_A440ProveedorPagoDefault[0]) != 0 ) || ( StringUtil.StrCmp(Z490ProveedorPideDoc, T000N8_A490ProveedorPideDoc[0]) != 0 ) || ( StringUtil.StrCmp(Z601ProveedorUsoInterno, T000N8_A601ProveedorUsoInterno[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z687ProveedorCuentaBancaria, T000N8_A687ProveedorCuentaBancaria[0]) != 0 ) || ( Z978ProveedorCIU != T000N8_A978ProveedorCIU[0] ) || ( Z999ProveedorFreezePrice != T000N8_A999ProveedorFreezePrice[0] ) || ( Z151ProveedoresTipoId != T000N8_A151ProveedoresTipoId[0] ) || ( Z488DocumentacionId != T000N8_A488DocumentacionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z673BancoId != T000N8_A673BancoId[0] ) )
            {
               if ( Z546ProveedorUsrAlta != T000N8_A546ProveedorUsrAlta[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorUsrAlta");
                  GXUtil.WriteLogRaw("Old: ",Z546ProveedorUsrAlta);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A546ProveedorUsrAlta[0]);
               }
               if ( Z547ProveedorUsrActualizacion != T000N8_A547ProveedorUsrActualizacion[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorUsrActualizacion");
                  GXUtil.WriteLogRaw("Old: ",Z547ProveedorUsrActualizacion);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A547ProveedorUsrActualizacion[0]);
               }
               if ( Z548ProveedorFechaAlta != T000N8_A548ProveedorFechaAlta[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z548ProveedorFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A548ProveedorFechaAlta[0]);
               }
               if ( Z549ProveedorFechaActualizacion != T000N8_A549ProveedorFechaActualizacion[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorFechaActualizacion");
                  GXUtil.WriteLogRaw("Old: ",Z549ProveedorFechaActualizacion);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A549ProveedorFechaActualizacion[0]);
               }
               if ( StringUtil.StrCmp(Z282ProveedorNombre, T000N8_A282ProveedorNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorNombre");
                  GXUtil.WriteLogRaw("Old: ",Z282ProveedorNombre);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A282ProveedorNombre[0]);
               }
               if ( StringUtil.StrCmp(Z682ProveedorRazonSocial, T000N8_A682ProveedorRazonSocial[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorRazonSocial");
                  GXUtil.WriteLogRaw("Old: ",Z682ProveedorRazonSocial);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A682ProveedorRazonSocial[0]);
               }
               if ( StringUtil.StrCmp(Z683ProveedorContacto, T000N8_A683ProveedorContacto[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorContacto");
                  GXUtil.WriteLogRaw("Old: ",Z683ProveedorContacto);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A683ProveedorContacto[0]);
               }
               if ( StringUtil.StrCmp(Z684ProveedorContactoCell, T000N8_A684ProveedorContactoCell[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorContactoCell");
                  GXUtil.WriteLogRaw("Old: ",Z684ProveedorContactoCell);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A684ProveedorContactoCell[0]);
               }
               if ( StringUtil.StrCmp(Z338ProveedorDocIdentidad, T000N8_A338ProveedorDocIdentidad[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorDocIdentidad");
                  GXUtil.WriteLogRaw("Old: ",Z338ProveedorDocIdentidad);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A338ProveedorDocIdentidad[0]);
               }
               if ( Z345ProveedorSerialComi != T000N8_A345ProveedorSerialComi[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorSerialComi");
                  GXUtil.WriteLogRaw("Old: ",Z345ProveedorSerialComi);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A345ProveedorSerialComi[0]);
               }
               if ( StringUtil.StrCmp(Z430ProveedorTelefono, T000N8_A430ProveedorTelefono[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z430ProveedorTelefono);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A430ProveedorTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z431ProveedorDireccion, T000N8_A431ProveedorDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z431ProveedorDireccion);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A431ProveedorDireccion[0]);
               }
               if ( StringUtil.StrCmp(Z433ProveedorEmail, T000N8_A433ProveedorEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorEmail");
                  GXUtil.WriteLogRaw("Old: ",Z433ProveedorEmail);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A433ProveedorEmail[0]);
               }
               if ( StringUtil.StrCmp(Z685ProveedorSitioWeb, T000N8_A685ProveedorSitioWeb[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorSitioWeb");
                  GXUtil.WriteLogRaw("Old: ",Z685ProveedorSitioWeb);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A685ProveedorSitioWeb[0]);
               }
               if ( Z686ProveedorAceptoTerminos != T000N8_A686ProveedorAceptoTerminos[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorAceptoTerminos");
                  GXUtil.WriteLogRaw("Old: ",Z686ProveedorAceptoTerminos);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A686ProveedorAceptoTerminos[0]);
               }
               if ( StringUtil.StrCmp(Z437ProveedorPerAltShop, T000N8_A437ProveedorPerAltShop[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorPerAltShop");
                  GXUtil.WriteLogRaw("Old: ",Z437ProveedorPerAltShop);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A437ProveedorPerAltShop[0]);
               }
               if ( StringUtil.StrCmp(Z344ProveedorEstado, T000N8_A344ProveedorEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorEstado");
                  GXUtil.WriteLogRaw("Old: ",Z344ProveedorEstado);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A344ProveedorEstado[0]);
               }
               if ( StringUtil.StrCmp(Z440ProveedorPagoDefault, T000N8_A440ProveedorPagoDefault[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorPagoDefault");
                  GXUtil.WriteLogRaw("Old: ",Z440ProveedorPagoDefault);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A440ProveedorPagoDefault[0]);
               }
               if ( StringUtil.StrCmp(Z490ProveedorPideDoc, T000N8_A490ProveedorPideDoc[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorPideDoc");
                  GXUtil.WriteLogRaw("Old: ",Z490ProveedorPideDoc);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A490ProveedorPideDoc[0]);
               }
               if ( StringUtil.StrCmp(Z601ProveedorUsoInterno, T000N8_A601ProveedorUsoInterno[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorUsoInterno");
                  GXUtil.WriteLogRaw("Old: ",Z601ProveedorUsoInterno);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A601ProveedorUsoInterno[0]);
               }
               if ( StringUtil.StrCmp(Z687ProveedorCuentaBancaria, T000N8_A687ProveedorCuentaBancaria[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorCuentaBancaria");
                  GXUtil.WriteLogRaw("Old: ",Z687ProveedorCuentaBancaria);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A687ProveedorCuentaBancaria[0]);
               }
               if ( Z978ProveedorCIU != T000N8_A978ProveedorCIU[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorCIU");
                  GXUtil.WriteLogRaw("Old: ",Z978ProveedorCIU);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A978ProveedorCIU[0]);
               }
               if ( Z999ProveedorFreezePrice != T000N8_A999ProveedorFreezePrice[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorFreezePrice");
                  GXUtil.WriteLogRaw("Old: ",Z999ProveedorFreezePrice);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A999ProveedorFreezePrice[0]);
               }
               if ( Z151ProveedoresTipoId != T000N8_A151ProveedoresTipoId[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedoresTipoId");
                  GXUtil.WriteLogRaw("Old: ",Z151ProveedoresTipoId);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A151ProveedoresTipoId[0]);
               }
               if ( Z488DocumentacionId != T000N8_A488DocumentacionId[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"DocumentacionId");
                  GXUtil.WriteLogRaw("Old: ",Z488DocumentacionId);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A488DocumentacionId[0]);
               }
               if ( Z673BancoId != T000N8_A673BancoId[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"BancoId");
                  GXUtil.WriteLogRaw("Old: ",Z673BancoId);
                  GXUtil.WriteLogRaw("Current: ",T000N8_A673BancoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proveedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N28( )
      {
         BeforeValidate0N28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N28( 0) ;
            CheckOptimisticConcurrency0N28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N20 */
                     pr_default.execute(18, new Object[] {n546ProveedorUsrAlta, A546ProveedorUsrAlta, n547ProveedorUsrActualizacion, A547ProveedorUsrActualizacion, n548ProveedorFechaAlta, A548ProveedorFechaAlta, n549ProveedorFechaActualizacion, A549ProveedorFechaActualizacion, A282ProveedorNombre, n682ProveedorRazonSocial, A682ProveedorRazonSocial, n683ProveedorContacto, A683ProveedorContacto, n684ProveedorContactoCell, A684ProveedorContactoCell, n432ProveedorImagen, A432ProveedorImagen, n40000ProveedorImagen_GXI, A40000ProveedorImagen_GXI, A338ProveedorDocIdentidad, A345ProveedorSerialComi, n430ProveedorTelefono, A430ProveedorTelefono, n431ProveedorDireccion, A431ProveedorDireccion, n433ProveedorEmail, A433ProveedorEmail, n685ProveedorSitioWeb, A685ProveedorSitioWeb, n686ProveedorAceptoTerminos, A686ProveedorAceptoTerminos, n437ProveedorPerAltShop, A437ProveedorPerAltShop, A344ProveedorEstado, A440ProveedorPagoDefault, n490ProveedorPideDoc, A490ProveedorPideDoc, n601ProveedorUsoInterno, A601ProveedorUsoInterno, n687ProveedorCuentaBancaria, A687ProveedorCuentaBancaria, A978ProveedorCIU, n999ProveedorFreezePrice, A999ProveedorFreezePrice, A151ProveedoresTipoId, n488DocumentacionId, A488DocumentacionId, n673BancoId, A673BancoId});
                     A133ProveedorID = T000N20_A133ProveedorID[0];
                     n133ProveedorID = T000N20_n133ProveedorID[0];
                     AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0N28( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0N0( ) ;
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
               Load0N28( ) ;
            }
            EndLevel0N28( ) ;
         }
         CloseExtendedTableCursors0N28( ) ;
      }

      protected void Update0N28( )
      {
         BeforeValidate0N28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N21 */
                     pr_default.execute(19, new Object[] {n546ProveedorUsrAlta, A546ProveedorUsrAlta, n547ProveedorUsrActualizacion, A547ProveedorUsrActualizacion, n548ProveedorFechaAlta, A548ProveedorFechaAlta, n549ProveedorFechaActualizacion, A549ProveedorFechaActualizacion, A282ProveedorNombre, n682ProveedorRazonSocial, A682ProveedorRazonSocial, n683ProveedorContacto, A683ProveedorContacto, n684ProveedorContactoCell, A684ProveedorContactoCell, A338ProveedorDocIdentidad, A345ProveedorSerialComi, n430ProveedorTelefono, A430ProveedorTelefono, n431ProveedorDireccion, A431ProveedorDireccion, n433ProveedorEmail, A433ProveedorEmail, n685ProveedorSitioWeb, A685ProveedorSitioWeb, n686ProveedorAceptoTerminos, A686ProveedorAceptoTerminos, n437ProveedorPerAltShop, A437ProveedorPerAltShop, A344ProveedorEstado, A440ProveedorPagoDefault, n490ProveedorPideDoc, A490ProveedorPideDoc, n601ProveedorUsoInterno, A601ProveedorUsoInterno, n687ProveedorCuentaBancaria, A687ProveedorCuentaBancaria, A978ProveedorCIU, n999ProveedorFreezePrice, A999ProveedorFreezePrice, A151ProveedoresTipoId, n488DocumentacionId, A488DocumentacionId, n673BancoId, A673BancoId, n133ProveedorID, A133ProveedorID});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Proveedor");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proveedor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0N28( ) ;
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
            EndLevel0N28( ) ;
         }
         CloseExtendedTableCursors0N28( ) ;
      }

      protected void DeferredUpdate0N28( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000N22 */
            pr_default.execute(20, new Object[] {n432ProveedorImagen, A432ProveedorImagen, n40000ProveedorImagen_GXI, A40000ProveedorImagen_GXI, n133ProveedorID, A133ProveedorID});
            pr_default.close(20);
            pr_default.SmartCacheProvider.SetUpdated("Proveedor");
         }
      }

      protected void delete( )
      {
         BeforeValidate0N28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N28( ) ;
            AfterConfirm0N28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N28( ) ;
               if ( AnyError == 0 )
               {
                  A345ProveedorSerialComi = O345ProveedorSerialComi;
                  AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
                  ScanStart0N29( ) ;
                  while ( RcdFound29 != 0 )
                  {
                     getByPrimaryKey0N29( ) ;
                     Delete0N29( ) ;
                     ScanNext0N29( ) ;
                     O345ProveedorSerialComi = A345ProveedorSerialComi;
                     AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
                  }
                  ScanEnd0N29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N23 */
                     pr_default.execute(21, new Object[] {n133ProveedorID, A133ProveedorID});
                     pr_default.close(21);
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
         EndLevel0N28( ) ;
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0N28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV40Pgmname = "Proveedor";
            AssignAttri("", false, "AV40Pgmname", AV40Pgmname);
            /* Using cursor T000N24 */
            pr_default.execute(22, new Object[] {A151ProveedoresTipoId});
            A278ProveedoresTipoNombre = T000N24_A278ProveedoresTipoNombre[0];
            pr_default.close(22);
            /* Using cursor T000N25 */
            pr_default.execute(23, new Object[] {n488DocumentacionId, A488DocumentacionId});
            A40001DocumentacionIcono_GXI = T000N25_A40001DocumentacionIcono_GXI[0];
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            A498DocumentacionIcono = T000N25_A498DocumentacionIcono[0];
            AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
            AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
            pr_default.close(23);
            /* Using cursor T000N26 */
            pr_default.execute(24, new Object[] {n673BancoId, A673BancoId});
            A674BancoNombre = T000N26_A674BancoNombre[0];
            pr_default.close(24);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000N27 */
            pr_default.execute(25, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Postulaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T000N28 */
            pr_default.execute(26, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")+" ("+context.GetMessage( "Comercios SubTipo", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T000N29 */
            pr_default.execute(27, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Lista Mapeo", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T000N30 */
            pr_default.execute(28, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Vincular Trn", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T000N31 */
            pr_default.execute(29, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T000N32 */
            pr_default.execute(30, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")+" ("+context.GetMessage( "Comercios SubTipo", "")+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T000N33 */
            pr_default.execute(31, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Registro de Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T000N34 */
            pr_default.execute(32, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Rubros", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T000N35 */
            pr_default.execute(33, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupacion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T000N36 */
            pr_default.execute(34, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T000N37 */
            pr_default.execute(35, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Comercio | Proveedor", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T000N38 */
            pr_default.execute(36, new Object[] {n133ProveedorID, A133ProveedorID});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Solicitudes", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
         }
      }

      protected void ProcessNestedLevel0N29( )
      {
         s345ProveedorSerialComi = O345ProveedorSerialComi;
         AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
         nGXsfl_176_idx = 0;
         while ( nGXsfl_176_idx < nRC_GXsfl_176 )
         {
            ReadRow0N29( ) ;
            if ( ( nRcdExists_29 != 0 ) || ( nIsMod_29 != 0 ) )
            {
               standaloneNotModal0N29( ) ;
               GetKey0N29( ) ;
               if ( ( nRcdExists_29 == 0 ) && ( nRcdDeleted_29 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0N29( ) ;
               }
               else
               {
                  if ( RcdFound29 != 0 )
                  {
                     if ( ( nRcdDeleted_29 != 0 ) && ( nRcdExists_29 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0N29( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_29 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0N29( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_29 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O345ProveedorSerialComi = A345ProveedorSerialComi;
               AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
            }
            ChangePostValue( edtProveedorComisionID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A157ProveedorComisionID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( dynRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))) ;
            ChangePostValue( edtRubrosImagen_Internalname, A168RubrosImagen) ;
            ChangePostValue( dynMedidasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))) ;
            ChangePostValue( dynInventarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))) ;
            ChangePostValue( edtMonedaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo)) ;
            ChangePostValue( edtEstadosGenericosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtEstadosGenericosNombre_Internalname, StringUtil.RTrim( A109EstadosGenericosNombre)) ;
            ChangePostValue( edtInventarioPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( chkProveedorComisionFP_Internalname, StringUtil.BoolToStr( A1001ProveedorComisionFP)) ;
            ChangePostValue( edtProveedorComisionFPF_Internalname, StringUtil.LTrim( StringUtil.NToC( A1000ProveedorComisionFPF, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbProveedorComisionTipo_Internalname, StringUtil.RTrim( A346ProveedorComisionTipo)) ;
            ChangePostValue( edtProveedorComision_Internalname, StringUtil.LTrim( StringUtil.NToC( A347ProveedorComision, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( cmbProveedorComisionAccion_Internalname, StringUtil.RTrim( A348ProveedorComisionAccion)) ;
            ChangePostValue( "ZT_"+"Z157ProveedorComisionID_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z157ProveedorComisionID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z348ProveedorComisionAccion_"+sGXsfl_176_idx, StringUtil.RTrim( Z348ProveedorComisionAccion)) ;
            ChangePostValue( "ZT_"+"Z1001ProveedorComisionFP_"+sGXsfl_176_idx, StringUtil.BoolToStr( Z1001ProveedorComisionFP)) ;
            ChangePostValue( "ZT_"+"Z1000ProveedorComisionFPF_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( Z1000ProveedorComisionFPF, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z346ProveedorComisionTipo_"+sGXsfl_176_idx, StringUtil.RTrim( Z346ProveedorComisionTipo)) ;
            ChangePostValue( "ZT_"+"Z347ProveedorComision_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( Z347ProveedorComision, 18, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_29_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_29), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_29_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_29), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_29_"+sGXsfl_176_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_29), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_29 != 0 )
            {
               ChangePostValue( "PROVEEDORCOMISIONID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorComisionID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynRubrosId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSIMAGEN_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MEDIDASID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "MONEDAID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSTIPO_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGENERICOSID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSGENERICOSNOMBRE_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVENTARIOPRECIOFINAL_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORCOMISIONFP_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkProveedorComisionFP.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORCOMISIONFPF_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorComisionFPF_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORCOMISIONTIPO_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorComisionTipo.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORCOMISION_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorComision_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROVEEDORCOMISIONACCION_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorComisionAccion.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0N29( ) ;
         if ( AnyError != 0 )
         {
            O345ProveedorSerialComi = s345ProveedorSerialComi;
            AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
         }
         nRcdExists_29 = 0;
         nIsMod_29 = 0;
         nRcdDeleted_29 = 0;
      }

      protected void ProcessLevel0N28( )
      {
         /* Save parent mode. */
         sMode28 = Gx_mode;
         ProcessNestedLevel0N29( ) ;
         if ( AnyError != 0 )
         {
            O345ProveedorSerialComi = s345ProveedorSerialComi;
            AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000N39 */
         pr_default.execute(37, new Object[] {A345ProveedorSerialComi, n133ProveedorID, A133ProveedorID});
         pr_default.close(37);
         pr_default.SmartCacheProvider.SetUpdated("Proveedor");
      }

      protected void EndLevel0N28( )
      {
         pr_default.close(6);
         if ( AnyError == 0 )
         {
            BeforeComplete0N28( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(7);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(22);
            pr_default.close(23);
            pr_default.close(24);
            pr_default.close(2);
            pr_default.close(3);
            pr_default.close(4);
            pr_default.close(5);
            context.CommitDataStores("proveedor",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(7);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(22);
            pr_default.close(23);
            pr_default.close(24);
            pr_default.close(2);
            pr_default.close(3);
            pr_default.close(4);
            pr_default.close(5);
            context.RollbackDataStores("proveedor",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0N28( )
      {
         /* Scan By routine */
         /* Using cursor T000N40 */
         pr_default.execute(38);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(38) != 101) )
         {
            RcdFound28 = 1;
            A133ProveedorID = T000N40_A133ProveedorID[0];
            n133ProveedorID = T000N40_n133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0N28( )
      {
         /* Scan next routine */
         pr_default.readNext(38);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(38) != 101) )
         {
            RcdFound28 = 1;
            A133ProveedorID = T000N40_A133ProveedorID[0];
            n133ProveedorID = T000N40_n133ProveedorID[0];
            AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         }
      }

      protected void ScanEnd0N28( )
      {
         pr_default.close(38);
      }

      protected void AfterConfirm0N28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N28( )
      {
         edtProveedorID_Enabled = 0;
         AssignProp("", false, edtProveedorID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorID_Enabled), 5, 0), true);
         cmbProveedorEstado.Enabled = 0;
         AssignProp("", false, cmbProveedorEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorEstado.Enabled), 5, 0), true);
         chkProveedorFreezePrice.Enabled = 0;
         AssignProp("", false, chkProveedorFreezePrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProveedorFreezePrice.Enabled), 5, 0), true);
         dynProveedoresTipoId.Enabled = 0;
         AssignProp("", false, dynProveedoresTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedoresTipoId.Enabled), 5, 0), true);
         edtProveedorNombre_Enabled = 0;
         AssignProp("", false, edtProveedorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorNombre_Enabled), 5, 0), true);
         edtProveedorRazonSocial_Enabled = 0;
         AssignProp("", false, edtProveedorRazonSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorRazonSocial_Enabled), 5, 0), true);
         edtProveedorTelefono_Enabled = 0;
         AssignProp("", false, edtProveedorTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorTelefono_Enabled), 5, 0), true);
         edtProveedorEmail_Enabled = 0;
         AssignProp("", false, edtProveedorEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorEmail_Enabled), 5, 0), true);
         edtProveedorDireccion_Enabled = 0;
         AssignProp("", false, edtProveedorDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorDireccion_Enabled), 5, 0), true);
         chkProveedorUsoInterno.Enabled = 0;
         AssignProp("", false, chkProveedorUsoInterno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProveedorUsoInterno.Enabled), 5, 0), true);
         chkProveedorCIU.Enabled = 0;
         AssignProp("", false, chkProveedorCIU_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProveedorCIU.Enabled), 5, 0), true);
         imgProveedorImagen_Enabled = 0;
         AssignProp("", false, imgProveedorImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProveedorImagen_Enabled), 5, 0), true);
         cmbProveedorPagoDefault.Enabled = 0;
         AssignProp("", false, cmbProveedorPagoDefault_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorPagoDefault.Enabled), 5, 0), true);
         edtProveedorDocIdentidad_Enabled = 0;
         AssignProp("", false, edtProveedorDocIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorDocIdentidad_Enabled), 5, 0), true);
         edtProveedorSitioWeb_Enabled = 0;
         AssignProp("", false, edtProveedorSitioWeb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSitioWeb_Enabled), 5, 0), true);
         edtProveedorAceptoTerminos_Enabled = 0;
         AssignProp("", false, edtProveedorAceptoTerminos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorAceptoTerminos_Enabled), 5, 0), true);
         edtProveedorContacto_Enabled = 0;
         AssignProp("", false, edtProveedorContacto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorContacto_Enabled), 5, 0), true);
         edtProveedorContactoCell_Enabled = 0;
         AssignProp("", false, edtProveedorContactoCell_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorContactoCell_Enabled), 5, 0), true);
         dynBancoId.Enabled = 0;
         AssignProp("", false, dynBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBancoId.Enabled), 5, 0), true);
         edtProveedorCuentaBancaria_Enabled = 0;
         AssignProp("", false, edtProveedorCuentaBancaria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorCuentaBancaria_Enabled), 5, 0), true);
         dynProveedorUsrAlta.Enabled = 0;
         AssignProp("", false, dynProveedorUsrAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorUsrAlta.Enabled), 5, 0), true);
         dynProveedorUsrActualizacion.Enabled = 0;
         AssignProp("", false, dynProveedorUsrActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynProveedorUsrActualizacion.Enabled), 5, 0), true);
         edtProveedorFechaAlta_Enabled = 0;
         AssignProp("", false, edtProveedorFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorFechaAlta_Enabled), 5, 0), true);
         edtProveedorFechaActualizacion_Enabled = 0;
         AssignProp("", false, edtProveedorFechaActualizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorFechaActualizacion_Enabled), 5, 0), true);
         edtProveedorSerialComi_Enabled = 0;
         AssignProp("", false, edtProveedorSerialComi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSerialComi_Enabled), 5, 0), true);
         edtProveedorPerAltShop_Enabled = 0;
         AssignProp("", false, edtProveedorPerAltShop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorPerAltShop_Enabled), 5, 0), true);
         edtProveedorPideDoc_Enabled = 0;
         AssignProp("", false, edtProveedorPideDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorPideDoc_Enabled), 5, 0), true);
         edtDocumentacionId_Enabled = 0;
         AssignProp("", false, edtDocumentacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentacionId_Enabled), 5, 0), true);
         imgDocumentacionIcono_Enabled = 0;
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgDocumentacionIcono_Enabled), 5, 0), true);
      }

      protected void ZM0N29( short GX_JID )
      {
         if ( ( GX_JID == 49 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z348ProveedorComisionAccion = T000N3_A348ProveedorComisionAccion[0];
               Z1001ProveedorComisionFP = T000N3_A1001ProveedorComisionFP[0];
               Z1000ProveedorComisionFPF = T000N3_A1000ProveedorComisionFPF[0];
               Z346ProveedorComisionTipo = T000N3_A346ProveedorComisionTipo[0];
               Z347ProveedorComision = T000N3_A347ProveedorComision[0];
               Z121RubrosId = T000N3_A121RubrosId[0];
               Z137MedidasID = T000N3_A137MedidasID[0];
               Z135InventarioId = T000N3_A135InventarioId[0];
            }
            else
            {
               Z348ProveedorComisionAccion = A348ProveedorComisionAccion;
               Z1001ProveedorComisionFP = A1001ProveedorComisionFP;
               Z1000ProveedorComisionFPF = A1000ProveedorComisionFPF;
               Z346ProveedorComisionTipo = A346ProveedorComisionTipo;
               Z347ProveedorComision = A347ProveedorComision;
               Z121RubrosId = A121RubrosId;
               Z137MedidasID = A137MedidasID;
               Z135InventarioId = A135InventarioId;
            }
         }
         if ( GX_JID == -49 )
         {
            Z133ProveedorID = A133ProveedorID;
            Z157ProveedorComisionID = A157ProveedorComisionID;
            Z348ProveedorComisionAccion = A348ProveedorComisionAccion;
            Z1001ProveedorComisionFP = A1001ProveedorComisionFP;
            Z1000ProveedorComisionFPF = A1000ProveedorComisionFPF;
            Z346ProveedorComisionTipo = A346ProveedorComisionTipo;
            Z347ProveedorComision = A347ProveedorComision;
            Z121RubrosId = A121RubrosId;
            Z137MedidasID = A137MedidasID;
            Z135InventarioId = A135InventarioId;
            Z168RubrosImagen = A168RubrosImagen;
            Z40002RubrosImagen_GXI = A40002RubrosImagen_GXI;
            Z118MonedaId = A118MonedaId;
            Z136InventarioNombre = A136InventarioNombre;
            Z181InventarioPrecioFinal = A181InventarioPrecioFinal;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
            Z109EstadosGenericosNombre = A109EstadosGenericosNombre;
         }
      }

      protected void standaloneNotModal0N29( )
      {
         GXARUBROSID_html0N29( ) ;
         edtProveedorComisionID_Enabled = 0;
         AssignProp("", false, edtProveedorComisionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorComisionID_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtMonedaId_Enabled = 0;
         AssignProp("", false, edtMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaId_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtEstadosTipo_Enabled = 0;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtEstadosGenericosId_Enabled = 0;
         AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtProveedorSerialComi_Enabled = 0;
         AssignProp("", false, edtProveedorSerialComi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSerialComi_Enabled), 5, 0), true);
         edtProveedorSerialComi_Enabled = 0;
         AssignProp("", false, edtProveedorSerialComi_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorSerialComi_Enabled), 5, 0), true);
      }

      protected void standaloneModal0N29( )
      {
         if ( IsIns( )  )
         {
            A345ProveedorSerialComi = (short)(O345ProveedorSerialComi+1);
            AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A348ProveedorComisionAccion)) && ( Gx_BScreen == 0 ) )
         {
            A348ProveedorComisionAccion = "";
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A157ProveedorComisionID = A345ProveedorSerialComi;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000N4 */
            pr_default.execute(2, new Object[] {A121RubrosId});
            A40002RubrosImagen_GXI = T000N4_A40002RubrosImagen_GXI[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_176_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A168RubrosImagen = T000N4_A168RubrosImagen[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_176_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            pr_default.close(2);
            GXAMEDIDASID_html0N29( A121RubrosId) ;
            /* Using cursor T000N5 */
            pr_default.execute(3, new Object[] {A121RubrosId, A137MedidasID});
            A118MonedaId = T000N5_A118MonedaId[0];
            pr_default.close(3);
            GXAINVENTARIOID_html0N29( A121RubrosId, A137MedidasID) ;
            /* Using cursor T000N6 */
            pr_default.execute(4, new Object[] {A121RubrosId, A137MedidasID, n135InventarioId, A135InventarioId});
            A136InventarioNombre = T000N6_A136InventarioNombre[0];
            A181InventarioPrecioFinal = T000N6_A181InventarioPrecioFinal[0];
            A107EstadosTipo = T000N6_A107EstadosTipo[0];
            A108EstadosGenericosId = T000N6_A108EstadosGenericosId[0];
            pr_default.close(4);
            /* Using cursor T000N7 */
            pr_default.execute(5, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            A109EstadosGenericosNombre = T000N7_A109EstadosGenericosNombre[0];
            pr_default.close(5);
         }
      }

      protected void Load0N29( )
      {
         /* Using cursor T000N41 */
         pr_default.execute(39, new Object[] {n133ProveedorID, A133ProveedorID, A157ProveedorComisionID});
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound29 = 1;
            A348ProveedorComisionAccion = T000N41_A348ProveedorComisionAccion[0];
            A40002RubrosImagen_GXI = T000N41_A40002RubrosImagen_GXI[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_176_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A136InventarioNombre = T000N41_A136InventarioNombre[0];
            A109EstadosGenericosNombre = T000N41_A109EstadosGenericosNombre[0];
            A181InventarioPrecioFinal = T000N41_A181InventarioPrecioFinal[0];
            A1001ProveedorComisionFP = T000N41_A1001ProveedorComisionFP[0];
            n1001ProveedorComisionFP = T000N41_n1001ProveedorComisionFP[0];
            A1000ProveedorComisionFPF = T000N41_A1000ProveedorComisionFPF[0];
            n1000ProveedorComisionFPF = T000N41_n1000ProveedorComisionFPF[0];
            A346ProveedorComisionTipo = T000N41_A346ProveedorComisionTipo[0];
            A347ProveedorComision = T000N41_A347ProveedorComision[0];
            A121RubrosId = T000N41_A121RubrosId[0];
            A137MedidasID = T000N41_A137MedidasID[0];
            A135InventarioId = T000N41_A135InventarioId[0];
            n135InventarioId = T000N41_n135InventarioId[0];
            A118MonedaId = T000N41_A118MonedaId[0];
            A107EstadosTipo = T000N41_A107EstadosTipo[0];
            A108EstadosGenericosId = T000N41_A108EstadosGenericosId[0];
            A168RubrosImagen = T000N41_A168RubrosImagen[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_176_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            ZM0N29( -49) ;
         }
         pr_default.close(39);
         OnLoadActions0N29( ) ;
      }

      protected void OnLoadActions0N29( )
      {
         GXAMEDIDASID_html0N29( A121RubrosId) ;
         GXAINVENTARIOID_html0N29( A121RubrosId, A137MedidasID) ;
      }

      protected void CheckExtendedTable0N29( )
      {
         nIsDirty_29 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0N29( ) ;
         /* Using cursor T000N4 */
         pr_default.execute(2, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_176_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40002RubrosImagen_GXI = T000N4_A40002RubrosImagen_GXI[0];
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_176_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A168RubrosImagen = T000N4_A168RubrosImagen[0];
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_176_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         pr_default.close(2);
         /* Using cursor T000N5 */
         pr_default.execute(3, new Object[] {A121RubrosId, A137MedidasID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "MEDIDASID_" + sGXsfl_176_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A118MonedaId = T000N5_A118MonedaId[0];
         pr_default.close(3);
         /* Using cursor T000N6 */
         pr_default.execute(4, new Object[] {A121RubrosId, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) || (0==A135InventarioId) ) )
            {
               GXCCtl = "INVENTARIOID_" + sGXsfl_176_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = dynRubrosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A136InventarioNombre = T000N6_A136InventarioNombre[0];
         A181InventarioPrecioFinal = T000N6_A181InventarioPrecioFinal[0];
         A107EstadosTipo = T000N6_A107EstadosTipo[0];
         A108EstadosGenericosId = T000N6_A108EstadosGenericosId[0];
         pr_default.close(4);
         /* Using cursor T000N7 */
         pr_default.execute(5, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A107EstadosTipo)) || (0==A108EstadosGenericosId) ) )
            {
               GXCCtl = "ESTADOSGENERICOSID_" + sGXsfl_176_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
            }
         }
         A109EstadosGenericosNombre = T000N7_A109EstadosGenericosNombre[0];
         pr_default.close(5);
         GXAMEDIDASID_html0N29( A121RubrosId) ;
         GXAINVENTARIOID_html0N29( A121RubrosId, A137MedidasID) ;
      }

      protected void CloseExtendedTableCursors0N29( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable0N29( )
      {
      }

      protected void gxLoad_50( short A121RubrosId )
      {
         /* Using cursor T000N42 */
         pr_default.execute(40, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(40) == 101) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_176_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40002RubrosImagen_GXI = T000N42_A40002RubrosImagen_GXI[0];
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_176_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A168RubrosImagen = T000N42_A168RubrosImagen[0];
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_176_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A168RubrosImagen)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40002RubrosImagen_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(40) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(40);
      }

      protected void gxLoad_51( short A121RubrosId ,
                                long A137MedidasID )
      {
         /* Using cursor T000N43 */
         pr_default.execute(41, new Object[] {A121RubrosId, A137MedidasID});
         if ( (pr_default.getStatus(41) == 101) )
         {
            GXCCtl = "MEDIDASID_" + sGXsfl_176_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A118MonedaId = T000N43_A118MonedaId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(41) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(41);
      }

      protected void gxLoad_52( short A121RubrosId ,
                                long A137MedidasID ,
                                long A135InventarioId )
      {
         /* Using cursor T000N44 */
         pr_default.execute(42, new Object[] {A121RubrosId, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(42) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) || (0==A135InventarioId) ) )
            {
               GXCCtl = "INVENTARIOID_" + sGXsfl_176_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = dynRubrosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A136InventarioNombre = T000N44_A136InventarioNombre[0];
         A181InventarioPrecioFinal = T000N44_A181InventarioPrecioFinal[0];
         A107EstadosTipo = T000N44_A107EstadosTipo[0];
         A108EstadosGenericosId = T000N44_A108EstadosGenericosId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A136InventarioNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A107EstadosTipo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(42) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(42);
      }

      protected void gxLoad_53( string A107EstadosTipo ,
                                int A108EstadosGenericosId )
      {
         /* Using cursor T000N45 */
         pr_default.execute(43, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(43) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A107EstadosTipo)) || (0==A108EstadosGenericosId) ) )
            {
               GXCCtl = "ESTADOSGENERICOSID_" + sGXsfl_176_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
            }
         }
         A109EstadosGenericosNombre = T000N45_A109EstadosGenericosNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A109EstadosGenericosNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(43) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(43);
      }

      protected void GetKey0N29( )
      {
         /* Using cursor T000N46 */
         pr_default.execute(44, new Object[] {n133ProveedorID, A133ProveedorID, A157ProveedorComisionID});
         if ( (pr_default.getStatus(44) != 101) )
         {
            RcdFound29 = 1;
         }
         else
         {
            RcdFound29 = 0;
         }
         pr_default.close(44);
      }

      protected void getByPrimaryKey0N29( )
      {
         /* Using cursor T000N3 */
         pr_default.execute(1, new Object[] {n133ProveedorID, A133ProveedorID, A157ProveedorComisionID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N29( 49) ;
            RcdFound29 = 1;
            InitializeNonKey0N29( ) ;
            A157ProveedorComisionID = T000N3_A157ProveedorComisionID[0];
            A348ProveedorComisionAccion = T000N3_A348ProveedorComisionAccion[0];
            A1001ProveedorComisionFP = T000N3_A1001ProveedorComisionFP[0];
            n1001ProveedorComisionFP = T000N3_n1001ProveedorComisionFP[0];
            A1000ProveedorComisionFPF = T000N3_A1000ProveedorComisionFPF[0];
            n1000ProveedorComisionFPF = T000N3_n1000ProveedorComisionFPF[0];
            A346ProveedorComisionTipo = T000N3_A346ProveedorComisionTipo[0];
            A347ProveedorComision = T000N3_A347ProveedorComision[0];
            A121RubrosId = T000N3_A121RubrosId[0];
            A137MedidasID = T000N3_A137MedidasID[0];
            A135InventarioId = T000N3_A135InventarioId[0];
            n135InventarioId = T000N3_n135InventarioId[0];
            Z133ProveedorID = A133ProveedorID;
            Z157ProveedorComisionID = A157ProveedorComisionID;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0N29( ) ;
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound29 = 0;
            InitializeNonKey0N29( ) ;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0N29( ) ;
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0N29( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0N29( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000N2 */
            pr_default.execute(0, new Object[] {n133ProveedorID, A133ProveedorID, A157ProveedorComisionID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProveedorComision"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z348ProveedorComisionAccion, T000N2_A348ProveedorComisionAccion[0]) != 0 ) || ( Z1001ProveedorComisionFP != T000N2_A1001ProveedorComisionFP[0] ) || ( Z1000ProveedorComisionFPF != T000N2_A1000ProveedorComisionFPF[0] ) || ( StringUtil.StrCmp(Z346ProveedorComisionTipo, T000N2_A346ProveedorComisionTipo[0]) != 0 ) || ( Z347ProveedorComision != T000N2_A347ProveedorComision[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z121RubrosId != T000N2_A121RubrosId[0] ) || ( Z137MedidasID != T000N2_A137MedidasID[0] ) || ( Z135InventarioId != T000N2_A135InventarioId[0] ) )
            {
               if ( StringUtil.StrCmp(Z348ProveedorComisionAccion, T000N2_A348ProveedorComisionAccion[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorComisionAccion");
                  GXUtil.WriteLogRaw("Old: ",Z348ProveedorComisionAccion);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A348ProveedorComisionAccion[0]);
               }
               if ( Z1001ProveedorComisionFP != T000N2_A1001ProveedorComisionFP[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorComisionFP");
                  GXUtil.WriteLogRaw("Old: ",Z1001ProveedorComisionFP);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A1001ProveedorComisionFP[0]);
               }
               if ( Z1000ProveedorComisionFPF != T000N2_A1000ProveedorComisionFPF[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorComisionFPF");
                  GXUtil.WriteLogRaw("Old: ",Z1000ProveedorComisionFPF);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A1000ProveedorComisionFPF[0]);
               }
               if ( StringUtil.StrCmp(Z346ProveedorComisionTipo, T000N2_A346ProveedorComisionTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorComisionTipo");
                  GXUtil.WriteLogRaw("Old: ",Z346ProveedorComisionTipo);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A346ProveedorComisionTipo[0]);
               }
               if ( Z347ProveedorComision != T000N2_A347ProveedorComision[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"ProveedorComision");
                  GXUtil.WriteLogRaw("Old: ",Z347ProveedorComision);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A347ProveedorComision[0]);
               }
               if ( Z121RubrosId != T000N2_A121RubrosId[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"RubrosId");
                  GXUtil.WriteLogRaw("Old: ",Z121RubrosId);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A121RubrosId[0]);
               }
               if ( Z137MedidasID != T000N2_A137MedidasID[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"MedidasID");
                  GXUtil.WriteLogRaw("Old: ",Z137MedidasID);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A137MedidasID[0]);
               }
               if ( Z135InventarioId != T000N2_A135InventarioId[0] )
               {
                  GXUtil.WriteLog("proveedor:[seudo value changed for attri]"+"InventarioId");
                  GXUtil.WriteLogRaw("Old: ",Z135InventarioId);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A135InventarioId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProveedorComision"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N29( )
      {
         BeforeValidate0N29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N29( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N29( 0) ;
            CheckOptimisticConcurrency0N29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N47 */
                     pr_default.execute(45, new Object[] {n133ProveedorID, A133ProveedorID, A157ProveedorComisionID, A348ProveedorComisionAccion, n1001ProveedorComisionFP, A1001ProveedorComisionFP, n1000ProveedorComisionFPF, A1000ProveedorComisionFPF, A346ProveedorComisionTipo, A347ProveedorComision, A121RubrosId, A137MedidasID, n135InventarioId, A135InventarioId});
                     pr_default.close(45);
                     pr_default.SmartCacheProvider.SetUpdated("ProveedorComision");
                     if ( (pr_default.getStatus(45) == 1) )
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
               Load0N29( ) ;
            }
            EndLevel0N29( ) ;
         }
         CloseExtendedTableCursors0N29( ) ;
      }

      protected void Update0N29( )
      {
         BeforeValidate0N29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N29( ) ;
         }
         if ( ( nIsMod_29 != 0 ) || ( nIsDirty_29 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0N29( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0N29( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0N29( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000N48 */
                        pr_default.execute(46, new Object[] {A348ProveedorComisionAccion, n1001ProveedorComisionFP, A1001ProveedorComisionFP, n1000ProveedorComisionFPF, A1000ProveedorComisionFPF, A346ProveedorComisionTipo, A347ProveedorComision, A121RubrosId, A137MedidasID, n135InventarioId, A135InventarioId, n133ProveedorID, A133ProveedorID, A157ProveedorComisionID});
                        pr_default.close(46);
                        pr_default.SmartCacheProvider.SetUpdated("ProveedorComision");
                        if ( (pr_default.getStatus(46) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProveedorComision"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0N29( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0N29( ) ;
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
               EndLevel0N29( ) ;
            }
         }
         CloseExtendedTableCursors0N29( ) ;
      }

      protected void DeferredUpdate0N29( )
      {
      }

      protected void Delete0N29( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0N29( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N29( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N29( ) ;
            AfterConfirm0N29( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N29( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000N49 */
                  pr_default.execute(47, new Object[] {n133ProveedorID, A133ProveedorID, A157ProveedorComisionID});
                  pr_default.close(47);
                  pr_default.SmartCacheProvider.SetUpdated("ProveedorComision");
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
         sMode29 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0N29( ) ;
         Gx_mode = sMode29;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0N29( )
      {
         standaloneModal0N29( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000N50 */
            pr_default.execute(48, new Object[] {A121RubrosId});
            A40002RubrosImagen_GXI = T000N50_A40002RubrosImagen_GXI[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_176_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A168RubrosImagen = T000N50_A168RubrosImagen[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_176_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            pr_default.close(48);
            GXAMEDIDASID_html0N29( A121RubrosId) ;
            /* Using cursor T000N51 */
            pr_default.execute(49, new Object[] {A121RubrosId, A137MedidasID});
            A118MonedaId = T000N51_A118MonedaId[0];
            pr_default.close(49);
            GXAINVENTARIOID_html0N29( A121RubrosId, A137MedidasID) ;
            /* Using cursor T000N52 */
            pr_default.execute(50, new Object[] {A121RubrosId, A137MedidasID, n135InventarioId, A135InventarioId});
            A136InventarioNombre = T000N52_A136InventarioNombre[0];
            A181InventarioPrecioFinal = T000N52_A181InventarioPrecioFinal[0];
            A107EstadosTipo = T000N52_A107EstadosTipo[0];
            A108EstadosGenericosId = T000N52_A108EstadosGenericosId[0];
            pr_default.close(50);
            /* Using cursor T000N53 */
            pr_default.execute(51, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
            A109EstadosGenericosNombre = T000N53_A109EstadosGenericosNombre[0];
            pr_default.close(51);
         }
      }

      protected void EndLevel0N29( )
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

      public void ScanStart0N29( )
      {
         /* Scan By routine */
         /* Using cursor T000N54 */
         pr_default.execute(52, new Object[] {n133ProveedorID, A133ProveedorID});
         RcdFound29 = 0;
         if ( (pr_default.getStatus(52) != 101) )
         {
            RcdFound29 = 1;
            A157ProveedorComisionID = T000N54_A157ProveedorComisionID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0N29( )
      {
         /* Scan next routine */
         pr_default.readNext(52);
         RcdFound29 = 0;
         if ( (pr_default.getStatus(52) != 101) )
         {
            RcdFound29 = 1;
            A157ProveedorComisionID = T000N54_A157ProveedorComisionID[0];
         }
      }

      protected void ScanEnd0N29( )
      {
         pr_default.close(52);
      }

      protected void AfterConfirm0N29( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N29( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N29( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N29( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N29( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N29( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N29( )
      {
         edtProveedorComisionID_Enabled = 0;
         AssignProp("", false, edtProveedorComisionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorComisionID_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         dynRubrosId.Enabled = 0;
         AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtRubrosImagen_Enabled = 0;
         AssignProp("", false, edtRubrosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosImagen_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         dynMedidasID.Enabled = 0;
         AssignProp("", false, dynMedidasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynMedidasID.Enabled), 5, 0), !bGXsfl_176_Refreshing);
         dynInventarioId.Enabled = 0;
         AssignProp("", false, dynInventarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynInventarioId.Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtMonedaId_Enabled = 0;
         AssignProp("", false, edtMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaId_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtEstadosTipo_Enabled = 0;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtEstadosGenericosId_Enabled = 0;
         AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtEstadosGenericosNombre_Enabled = 0;
         AssignProp("", false, edtEstadosGenericosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtInventarioPrecioFinal_Enabled = 0;
         AssignProp("", false, edtInventarioPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         chkProveedorComisionFP.Enabled = 0;
         AssignProp("", false, chkProveedorComisionFP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProveedorComisionFP.Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtProveedorComisionFPF_Enabled = 0;
         AssignProp("", false, edtProveedorComisionFPF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorComisionFPF_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         cmbProveedorComisionTipo.Enabled = 0;
         AssignProp("", false, cmbProveedorComisionTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorComisionTipo.Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtProveedorComision_Enabled = 0;
         AssignProp("", false, edtProveedorComision_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorComision_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         cmbProveedorComisionAccion.Enabled = 0;
         AssignProp("", false, cmbProveedorComisionAccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProveedorComisionAccion.Enabled), 5, 0), !bGXsfl_176_Refreshing);
      }

      protected void send_integrity_lvl_hashes0N29( )
      {
      }

      protected void send_integrity_lvl_hashes0N28( )
      {
      }

      protected void SubsflControlProps_17629( )
      {
         edtProveedorComisionID_Internalname = "PROVEEDORCOMISIONID_"+sGXsfl_176_idx;
         dynRubrosId_Internalname = "RUBROSID_"+sGXsfl_176_idx;
         edtRubrosImagen_Internalname = "RUBROSIMAGEN_"+sGXsfl_176_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_176_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_176_idx;
         edtMonedaId_Internalname = "MONEDAID_"+sGXsfl_176_idx;
         edtEstadosTipo_Internalname = "ESTADOSTIPO_"+sGXsfl_176_idx;
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_176_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_176_idx;
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL_"+sGXsfl_176_idx;
         chkProveedorComisionFP_Internalname = "PROVEEDORCOMISIONFP_"+sGXsfl_176_idx;
         edtProveedorComisionFPF_Internalname = "PROVEEDORCOMISIONFPF_"+sGXsfl_176_idx;
         cmbProveedorComisionTipo_Internalname = "PROVEEDORCOMISIONTIPO_"+sGXsfl_176_idx;
         edtProveedorComision_Internalname = "PROVEEDORCOMISION_"+sGXsfl_176_idx;
         cmbProveedorComisionAccion_Internalname = "PROVEEDORCOMISIONACCION_"+sGXsfl_176_idx;
      }

      protected void SubsflControlProps_fel_17629( )
      {
         edtProveedorComisionID_Internalname = "PROVEEDORCOMISIONID_"+sGXsfl_176_fel_idx;
         dynRubrosId_Internalname = "RUBROSID_"+sGXsfl_176_fel_idx;
         edtRubrosImagen_Internalname = "RUBROSIMAGEN_"+sGXsfl_176_fel_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_176_fel_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_176_fel_idx;
         edtMonedaId_Internalname = "MONEDAID_"+sGXsfl_176_fel_idx;
         edtEstadosTipo_Internalname = "ESTADOSTIPO_"+sGXsfl_176_fel_idx;
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_176_fel_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_176_fel_idx;
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL_"+sGXsfl_176_fel_idx;
         chkProveedorComisionFP_Internalname = "PROVEEDORCOMISIONFP_"+sGXsfl_176_fel_idx;
         edtProveedorComisionFPF_Internalname = "PROVEEDORCOMISIONFPF_"+sGXsfl_176_fel_idx;
         cmbProveedorComisionTipo_Internalname = "PROVEEDORCOMISIONTIPO_"+sGXsfl_176_fel_idx;
         edtProveedorComision_Internalname = "PROVEEDORCOMISION_"+sGXsfl_176_fel_idx;
         cmbProveedorComisionAccion_Internalname = "PROVEEDORCOMISIONACCION_"+sGXsfl_176_fel_idx;
      }

      protected void AddRow0N29( )
      {
         nGXsfl_176_idx = (int)(nGXsfl_176_idx+1);
         sGXsfl_176_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_176_idx), 4, 0), 4, "0");
         SubsflControlProps_17629( ) ;
         SendRow0N29( ) ;
      }

      protected void SendRow0N29( )
      {
         Gridlevel_comisionRow = GXWebRow.GetNew(context);
         if ( subGridlevel_comision_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_comision_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_comision_Class, "") != 0 )
            {
               subGridlevel_comision_Linesclass = subGridlevel_comision_Class+"Odd";
            }
         }
         else if ( subGridlevel_comision_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_comision_Backstyle = 0;
            subGridlevel_comision_Backcolor = subGridlevel_comision_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_comision_Class, "") != 0 )
            {
               subGridlevel_comision_Linesclass = subGridlevel_comision_Class+"Uniform";
            }
         }
         else if ( subGridlevel_comision_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_comision_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_comision_Class, "") != 0 )
            {
               subGridlevel_comision_Linesclass = subGridlevel_comision_Class+"Odd";
            }
            subGridlevel_comision_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_comision_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_comision_Backstyle = 1;
            if ( ((int)((nGXsfl_176_idx) % (2))) == 0 )
            {
               subGridlevel_comision_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_comision_Class, "") != 0 )
               {
                  subGridlevel_comision_Linesclass = subGridlevel_comision_Class+"Even";
               }
            }
            else
            {
               subGridlevel_comision_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_comision_Class, "") != 0 )
               {
                  subGridlevel_comision_Linesclass = subGridlevel_comision_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_29_" + sGXsfl_176_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 177,'',false,'" + sGXsfl_176_idx + "',176)\"";
         ROClassString = "Attribute";
         Gridlevel_comisionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorComisionID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A157ProveedorComisionID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProveedorComisionID_Enabled!=0) ? context.localUtil.Format( (decimal)(A157ProveedorComisionID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A157ProveedorComisionID), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,177);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorComisionID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorComisionID_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)176,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         GXARUBROSID_html0N29( ) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_29_" + sGXsfl_176_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 178,'',false,'" + sGXsfl_176_idx + "',176)\"";
         if ( ( dynRubrosId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_176_idx;
            dynRubrosId.Name = GXCCtl;
            dynRubrosId.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_comisionRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynRubrosId,(string)dynRubrosId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0)),(short)1,(string)dynRubrosId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynRubrosId.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,178);\"",(string)"",(bool)true,(short)0});
         dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
         AssignProp("", false, dynRubrosId_Internalname, "Values", (string)(dynRubrosId.ToJavascriptSource()), !bGXsfl_176_Refreshing);
         /* Subfile cell */
         /* Static Bitmap Variable */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_29_" + sGXsfl_176_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 179,'',false,'" + sGXsfl_176_idx + "',176)\"";
         ClassString = "Attribute";
         StyleString = "";
         A168RubrosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40002RubrosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen));
         Gridlevel_comisionRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtRubrosImagen_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,179);\"",(string)"",(string)"",(string)"",(short)0,(bool)A168RubrosImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
         AssignProp("", false, edtRubrosImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen)), !bGXsfl_176_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A168RubrosImagen_IsBlob), !bGXsfl_176_Refreshing);
         GXAMEDIDASID_html0N29( A121RubrosId) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_29_" + sGXsfl_176_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 180,'',false,'" + sGXsfl_176_idx + "',176)\"";
         if ( ( dynMedidasID.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "MEDIDASID_" + sGXsfl_176_idx;
            dynMedidasID.Name = GXCCtl;
            dynMedidasID.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_comisionRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynMedidasID,(string)dynMedidasID_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)),(short)1,(string)dynMedidasID_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynMedidasID.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,180);\"",(string)"",(bool)true,(short)0});
         dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         AssignProp("", false, dynMedidasID_Internalname, "Values", (string)(dynMedidasID.ToJavascriptSource()), !bGXsfl_176_Refreshing);
         GXAINVENTARIOID_html0N29( A121RubrosId, A137MedidasID) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_29_" + sGXsfl_176_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 181,'',false,'" + sGXsfl_176_idx + "',176)\"";
         if ( ( dynInventarioId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "INVENTARIOID_" + sGXsfl_176_idx;
            dynInventarioId.Name = GXCCtl;
            dynInventarioId.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_comisionRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynInventarioId,(string)dynInventarioId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0)),(short)1,(string)dynInventarioId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynInventarioId.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,181);\"",(string)"",(bool)true,(short)0});
         dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         AssignProp("", false, dynInventarioId_Internalname, "Values", (string)(dynInventarioId.ToJavascriptSource()), !bGXsfl_176_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_comisionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMonedaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtMonedaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A118MonedaId), "ZZZ9") : context.localUtil.Format( (decimal)(A118MonedaId), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMonedaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtMonedaId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)176,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_comisionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosTipo_Internalname,StringUtil.RTrim( A107EstadosTipo),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtEstadosTipo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)176,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_comisionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtEstadosGenericosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9") : context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+""+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosGenericosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtEstadosGenericosId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)176,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_29_" + sGXsfl_176_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 185,'',false,'" + sGXsfl_176_idx + "',176)\"";
         ROClassString = "Attribute";
         Gridlevel_comisionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosNombre_Internalname,StringUtil.RTrim( A109EstadosGenericosNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,185);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosGenericosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtEstadosGenericosNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)176,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_29_" + sGXsfl_176_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 186,'',false,'" + sGXsfl_176_idx + "',176)\"";
         ROClassString = "Attribute";
         Gridlevel_comisionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtInventarioPrecioFinal_Enabled!=0) ? context.localUtil.Format( A181InventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A181InventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,186);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtInventarioPrecioFinal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)176,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_29_" + sGXsfl_176_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 187,'',false,'" + sGXsfl_176_idx + "',176)\"";
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "PROVEEDORCOMISIONFP_" + sGXsfl_176_idx;
         chkProveedorComisionFP.Name = GXCCtl;
         chkProveedorComisionFP.WebTags = "";
         chkProveedorComisionFP.Caption = "";
         AssignProp("", false, chkProveedorComisionFP_Internalname, "TitleCaption", chkProveedorComisionFP.Caption, !bGXsfl_176_Refreshing);
         chkProveedorComisionFP.CheckedValue = "false";
         A1001ProveedorComisionFP = StringUtil.StrToBool( StringUtil.BoolToStr( A1001ProveedorComisionFP));
         n1001ProveedorComisionFP = false;
         Gridlevel_comisionRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkProveedorComisionFP_Internalname,StringUtil.BoolToStr( A1001ProveedorComisionFP),context.GetMessage( "Desactivado omitirá el precio freezado", ""),(string)"",(short)-1,chkProveedorComisionFP.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(187, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,187);\""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_29_" + sGXsfl_176_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 188,'',false,'" + sGXsfl_176_idx + "',176)\"";
         ROClassString = "Attribute";
         Gridlevel_comisionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorComisionFPF_Internalname,StringUtil.LTrim( StringUtil.NToC( A1000ProveedorComisionFPF, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProveedorComisionFPF_Enabled!=0) ? context.localUtil.Format( A1000ProveedorComisionFPF, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A1000ProveedorComisionFPF, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,188);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorComisionFPF_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorComisionFPF_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)176,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_29_" + sGXsfl_176_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 189,'',false,'" + sGXsfl_176_idx + "',176)\"";
         if ( ( cmbProveedorComisionTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "PROVEEDORCOMISIONTIPO_" + sGXsfl_176_idx;
            cmbProveedorComisionTipo.Name = GXCCtl;
            cmbProveedorComisionTipo.WebTags = "";
            cmbProveedorComisionTipo.addItem("P", context.GetMessage( "Porcentaje", ""), 0);
            cmbProveedorComisionTipo.addItem("F", context.GetMessage( "Valor Fijo", ""), 0);
            cmbProveedorComisionTipo.addItem("N", context.GetMessage( "No Aplica", ""), 0);
            if ( cmbProveedorComisionTipo.ItemCount > 0 )
            {
               A346ProveedorComisionTipo = cmbProveedorComisionTipo.getValidValue(A346ProveedorComisionTipo);
            }
         }
         /* ComboBox */
         Gridlevel_comisionRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProveedorComisionTipo,(string)cmbProveedorComisionTipo_Internalname,StringUtil.RTrim( A346ProveedorComisionTipo),(short)1,(string)cmbProveedorComisionTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbProveedorComisionTipo.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,189);\"",(string)"",(bool)true,(short)0});
         cmbProveedorComisionTipo.CurrentValue = StringUtil.RTrim( A346ProveedorComisionTipo);
         AssignProp("", false, cmbProveedorComisionTipo_Internalname, "Values", (string)(cmbProveedorComisionTipo.ToJavascriptSource()), !bGXsfl_176_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_29_" + sGXsfl_176_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 190,'',false,'" + sGXsfl_176_idx + "',176)\"";
         ROClassString = "Attribute";
         Gridlevel_comisionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorComision_Internalname,StringUtil.LTrim( StringUtil.NToC( A347ProveedorComision, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProveedorComision_Enabled!=0) ? context.localUtil.Format( A347ProveedorComision, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A347ProveedorComision, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,190);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorComision_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProveedorComision_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)176,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_29_" + sGXsfl_176_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 191,'',false,'" + sGXsfl_176_idx + "',176)\"";
         GXCCtl = "PROVEEDORCOMISIONACCION_" + sGXsfl_176_idx;
         cmbProveedorComisionAccion.Name = GXCCtl;
         cmbProveedorComisionAccion.WebTags = "";
         cmbProveedorComisionAccion.addItem("", context.GetMessage( "Sin Accion", ""), 0);
         cmbProveedorComisionAccion.addItem("S", context.GetMessage( "Suma", ""), 0);
         cmbProveedorComisionAccion.addItem("R", context.GetMessage( "Resta", ""), 0);
         if ( cmbProveedorComisionAccion.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A348ProveedorComisionAccion)) )
            {
               A348ProveedorComisionAccion = "";
            }
         }
         /* ComboBox */
         Gridlevel_comisionRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbProveedorComisionAccion,(string)cmbProveedorComisionAccion_Internalname,StringUtil.RTrim( A348ProveedorComisionAccion),(short)1,(string)cmbProveedorComisionAccion_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbProveedorComisionAccion.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,191);\"",(string)"",(bool)true,(short)0});
         cmbProveedorComisionAccion.CurrentValue = StringUtil.RTrim( A348ProveedorComisionAccion);
         AssignProp("", false, cmbProveedorComisionAccion_Internalname, "Values", (string)(cmbProveedorComisionAccion.ToJavascriptSource()), !bGXsfl_176_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_comisionRow);
         send_integrity_lvl_hashes0N29( ) ;
         GXCCtl = "Z157ProveedorComisionID_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z157ProveedorComisionID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z348ProveedorComisionAccion_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z348ProveedorComisionAccion));
         GXCCtl = "Z1001ProveedorComisionFP_" + sGXsfl_176_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z1001ProveedorComisionFP);
         GXCCtl = "Z1000ProveedorComisionFPF_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z1000ProveedorComisionFPF, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z346ProveedorComisionTipo_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z346ProveedorComisionTipo));
         GXCCtl = "Z347ProveedorComision_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z347ProveedorComision, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z121RubrosId_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z137MedidasID_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z135InventarioId_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_29_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_29), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_29_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_29), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_29_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_29), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_176_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vPROVEEDORID_" + sGXsfl_176_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "RUBROSIMAGEN_" + sGXsfl_176_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A168RubrosImagen);
         GxWebStd.gx_hidden_field( context, "PROVEEDORCOMISIONID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorComisionID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RUBROSID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynRubrosId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RUBROSIMAGEN_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MEDIDASID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MONEDAID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSTIPO_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSID_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSNOMBRE_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVENTARIOPRECIOFINAL_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORCOMISIONFP_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkProveedorComisionFP.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORCOMISIONFPF_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorComisionFPF_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORCOMISIONTIPO_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorComisionTipo.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORCOMISION_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorComision_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORCOMISIONACCION_"+sGXsfl_176_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorComisionAccion.Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_comisionContainer.AddRow(Gridlevel_comisionRow);
      }

      protected void ReadRow0N29( )
      {
         nGXsfl_176_idx = (int)(nGXsfl_176_idx+1);
         sGXsfl_176_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_176_idx), 4, 0), 4, "0");
         SubsflControlProps_17629( ) ;
         edtProveedorComisionID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORCOMISIONID_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynRubrosId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtRubrosImagen_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSIMAGEN_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynMedidasID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MEDIDASID_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynInventarioId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOID_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtMonedaId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "MONEDAID_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtEstadosTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSTIPO_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtEstadosGenericosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSID_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtEstadosGenericosNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSGENERICOSNOMBRE_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtInventarioPrecioFinal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVENTARIOPRECIOFINAL_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         chkProveedorComisionFP.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORCOMISIONFP_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorComisionFPF_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORCOMISIONFPF_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbProveedorComisionTipo.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORCOMISIONTIPO_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProveedorComision_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORCOMISION_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbProveedorComisionAccion.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROVEEDORCOMISIONACCION_"+sGXsfl_176_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A157ProveedorComisionID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorComisionID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynRubrosId.Name = dynRubrosId_Internalname;
         dynRubrosId.CurrentValue = cgiGet( dynRubrosId_Internalname);
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynRubrosId_Internalname), "."), 18, MidpointRounding.ToEven));
         A168RubrosImagen = cgiGet( edtRubrosImagen_Internalname);
         dynMedidasID.Name = dynMedidasID_Internalname;
         dynMedidasID.CurrentValue = cgiGet( dynMedidasID_Internalname);
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynMedidasID_Internalname), "."), 18, MidpointRounding.ToEven));
         dynInventarioId.Name = dynInventarioId_Internalname;
         dynInventarioId.CurrentValue = cgiGet( dynInventarioId_Internalname);
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynInventarioId_Internalname), "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         n135InventarioId = ((0==A135InventarioId) ? true : false);
         A118MonedaId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMonedaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
         A108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosGenericosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A109EstadosGenericosNombre = cgiGet( edtEstadosGenericosNombre_Internalname);
         A181InventarioPrecioFinal = context.localUtil.CToN( cgiGet( edtInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         A1001ProveedorComisionFP = StringUtil.StrToBool( cgiGet( chkProveedorComisionFP_Internalname));
         n1001ProveedorComisionFP = false;
         n1001ProveedorComisionFP = ((false==A1001ProveedorComisionFP) ? true : false);
         if ( ( ( context.localUtil.CToN( cgiGet( edtProveedorComisionFPF_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProveedorComisionFPF_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
         {
            GXCCtl = "PROVEEDORCOMISIONFPF_" + sGXsfl_176_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProveedorComisionFPF_Internalname;
            wbErr = true;
            A1000ProveedorComisionFPF = 0;
            n1000ProveedorComisionFPF = false;
         }
         else
         {
            A1000ProveedorComisionFPF = context.localUtil.CToN( cgiGet( edtProveedorComisionFPF_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            n1000ProveedorComisionFPF = false;
         }
         n1000ProveedorComisionFPF = ((Convert.ToDecimal(0)==A1000ProveedorComisionFPF) ? true : false);
         cmbProveedorComisionTipo.Name = cmbProveedorComisionTipo_Internalname;
         cmbProveedorComisionTipo.CurrentValue = cgiGet( cmbProveedorComisionTipo_Internalname);
         A346ProveedorComisionTipo = cgiGet( cmbProveedorComisionTipo_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtProveedorComision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProveedorComision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
         {
            GXCCtl = "PROVEEDORCOMISION_" + sGXsfl_176_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProveedorComision_Internalname;
            wbErr = true;
            A347ProveedorComision = 0;
         }
         else
         {
            A347ProveedorComision = context.localUtil.CToN( cgiGet( edtProveedorComision_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         }
         cmbProveedorComisionAccion.Name = cmbProveedorComisionAccion_Internalname;
         cmbProveedorComisionAccion.CurrentValue = cgiGet( cmbProveedorComisionAccion_Internalname);
         A348ProveedorComisionAccion = cgiGet( cmbProveedorComisionAccion_Internalname);
         GXCCtl = "Z157ProveedorComisionID_" + sGXsfl_176_idx;
         Z157ProveedorComisionID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z348ProveedorComisionAccion_" + sGXsfl_176_idx;
         Z348ProveedorComisionAccion = cgiGet( GXCCtl);
         GXCCtl = "Z1001ProveedorComisionFP_" + sGXsfl_176_idx;
         Z1001ProveedorComisionFP = StringUtil.StrToBool( cgiGet( GXCCtl));
         n1001ProveedorComisionFP = ((false==A1001ProveedorComisionFP) ? true : false);
         GXCCtl = "Z1000ProveedorComisionFPF_" + sGXsfl_176_idx;
         Z1000ProveedorComisionFPF = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         n1000ProveedorComisionFPF = ((Convert.ToDecimal(0)==A1000ProveedorComisionFPF) ? true : false);
         GXCCtl = "Z346ProveedorComisionTipo_" + sGXsfl_176_idx;
         Z346ProveedorComisionTipo = cgiGet( GXCCtl);
         GXCCtl = "Z347ProveedorComision_" + sGXsfl_176_idx;
         Z347ProveedorComision = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z121RubrosId_" + sGXsfl_176_idx;
         Z121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z137MedidasID_" + sGXsfl_176_idx;
         Z137MedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z135InventarioId_" + sGXsfl_176_idx;
         Z135InventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n135InventarioId = ((0==A135InventarioId) ? true : false);
         GXCCtl = "nRcdDeleted_29_" + sGXsfl_176_idx;
         nRcdDeleted_29 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_29_" + sGXsfl_176_idx;
         nRcdExists_29 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_29_" + sGXsfl_176_idx;
         nIsMod_29 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         getMultimediaValue(edtRubrosImagen_Internalname, ref  A168RubrosImagen, ref  A40002RubrosImagen_GXI);
      }

      protected void assign_properties_default( )
      {
         defedtEstadosGenericosId_Enabled = edtEstadosGenericosId_Enabled;
         defedtEstadosTipo_Enabled = edtEstadosTipo_Enabled;
         defedtMonedaId_Enabled = edtMonedaId_Enabled;
         defedtProveedorComisionID_Enabled = edtProveedorComisionID_Enabled;
      }

      protected void ConfirmValues0N0( )
      {
         nGXsfl_176_idx = 0;
         sGXsfl_176_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_176_idx), 4, 0), 4, "0");
         SubsflControlProps_17629( ) ;
         while ( nGXsfl_176_idx < nRC_GXsfl_176 )
         {
            nGXsfl_176_idx = (int)(nGXsfl_176_idx+1);
            sGXsfl_176_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_176_idx), 4, 0), 4, "0");
            SubsflControlProps_17629( ) ;
            ChangePostValue( "Z157ProveedorComisionID_"+sGXsfl_176_idx, cgiGet( "ZT_"+"Z157ProveedorComisionID_"+sGXsfl_176_idx)) ;
            DeletePostValue( "ZT_"+"Z157ProveedorComisionID_"+sGXsfl_176_idx) ;
            ChangePostValue( "Z348ProveedorComisionAccion_"+sGXsfl_176_idx, cgiGet( "ZT_"+"Z348ProveedorComisionAccion_"+sGXsfl_176_idx)) ;
            DeletePostValue( "ZT_"+"Z348ProveedorComisionAccion_"+sGXsfl_176_idx) ;
            ChangePostValue( "Z1001ProveedorComisionFP_"+sGXsfl_176_idx, cgiGet( "ZT_"+"Z1001ProveedorComisionFP_"+sGXsfl_176_idx)) ;
            DeletePostValue( "ZT_"+"Z1001ProveedorComisionFP_"+sGXsfl_176_idx) ;
            ChangePostValue( "Z1000ProveedorComisionFPF_"+sGXsfl_176_idx, cgiGet( "ZT_"+"Z1000ProveedorComisionFPF_"+sGXsfl_176_idx)) ;
            DeletePostValue( "ZT_"+"Z1000ProveedorComisionFPF_"+sGXsfl_176_idx) ;
            ChangePostValue( "Z346ProveedorComisionTipo_"+sGXsfl_176_idx, cgiGet( "ZT_"+"Z346ProveedorComisionTipo_"+sGXsfl_176_idx)) ;
            DeletePostValue( "ZT_"+"Z346ProveedorComisionTipo_"+sGXsfl_176_idx) ;
            ChangePostValue( "Z347ProveedorComision_"+sGXsfl_176_idx, cgiGet( "ZT_"+"Z347ProveedorComision_"+sGXsfl_176_idx)) ;
            DeletePostValue( "ZT_"+"Z347ProveedorComision_"+sGXsfl_176_idx) ;
            ChangePostValue( "Z121RubrosId_"+sGXsfl_176_idx, cgiGet( "ZT_"+"Z121RubrosId_"+sGXsfl_176_idx)) ;
            DeletePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_176_idx) ;
            ChangePostValue( "Z137MedidasID_"+sGXsfl_176_idx, cgiGet( "ZT_"+"Z137MedidasID_"+sGXsfl_176_idx)) ;
            DeletePostValue( "ZT_"+"Z137MedidasID_"+sGXsfl_176_idx) ;
            ChangePostValue( "Z135InventarioId_"+sGXsfl_176_idx, cgiGet( "ZT_"+"Z135InventarioId_"+sGXsfl_176_idx)) ;
            DeletePostValue( "ZT_"+"Z135InventarioId_"+sGXsfl_176_idx) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 74760), false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
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
         GXEncryptionTmp = "proveedor.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ProveedorID,18,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("proveedor.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Proveedor");
         forbiddenHiddens.Add("ProveedorID", context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("ProveedorAceptoTerminos", context.localUtil.Format( A686ProveedorAceptoTerminos, "99/99/99 99:99"));
         forbiddenHiddens.Add("ProveedorUsrAlta", context.localUtil.Format( (decimal)(A546ProveedorUsrAlta), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("ProveedorUsrActualizacion", context.localUtil.Format( (decimal)(A547ProveedorUsrActualizacion), "ZZZZZZZZZ9"));
         forbiddenHiddens.Add("ProveedorFechaAlta", context.localUtil.Format( A548ProveedorFechaAlta, "99/99/99 99:99"));
         forbiddenHiddens.Add("ProveedorFechaActualizacion", context.localUtil.Format( A549ProveedorFechaActualizacion, "99/99/99 99:99"));
         forbiddenHiddens.Add("Insert_ProveedoresTipoId", context.localUtil.Format( (decimal)(AV13Insert_ProveedoresTipoId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_DocumentacionId", context.localUtil.Format( (decimal)(AV14Insert_DocumentacionId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_BancoId", context.localUtil.Format( (decimal)(AV36Insert_BancoId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("proveedor:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z133ProveedorID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z546ProveedorUsrAlta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z546ProveedorUsrAlta), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z547ProveedorUsrActualizacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z547ProveedorUsrActualizacion), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z548ProveedorFechaAlta", context.localUtil.TToC( Z548ProveedorFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z549ProveedorFechaActualizacion", context.localUtil.TToC( Z549ProveedorFechaActualizacion, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z282ProveedorNombre", StringUtil.RTrim( Z282ProveedorNombre));
         GxWebStd.gx_hidden_field( context, "Z682ProveedorRazonSocial", StringUtil.RTrim( Z682ProveedorRazonSocial));
         GxWebStd.gx_hidden_field( context, "Z683ProveedorContacto", StringUtil.RTrim( Z683ProveedorContacto));
         GxWebStd.gx_hidden_field( context, "Z684ProveedorContactoCell", StringUtil.RTrim( Z684ProveedorContactoCell));
         GxWebStd.gx_hidden_field( context, "Z338ProveedorDocIdentidad", StringUtil.RTrim( Z338ProveedorDocIdentidad));
         GxWebStd.gx_hidden_field( context, "Z345ProveedorSerialComi", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z345ProveedorSerialComi), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z430ProveedorTelefono", StringUtil.RTrim( Z430ProveedorTelefono));
         GxWebStd.gx_hidden_field( context, "Z431ProveedorDireccion", Z431ProveedorDireccion);
         GxWebStd.gx_hidden_field( context, "Z433ProveedorEmail", Z433ProveedorEmail);
         GxWebStd.gx_hidden_field( context, "Z685ProveedorSitioWeb", StringUtil.RTrim( Z685ProveedorSitioWeb));
         GxWebStd.gx_hidden_field( context, "Z686ProveedorAceptoTerminos", context.localUtil.TToC( Z686ProveedorAceptoTerminos, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z437ProveedorPerAltShop", StringUtil.RTrim( Z437ProveedorPerAltShop));
         GxWebStd.gx_hidden_field( context, "Z344ProveedorEstado", StringUtil.RTrim( Z344ProveedorEstado));
         GxWebStd.gx_hidden_field( context, "Z440ProveedorPagoDefault", StringUtil.RTrim( Z440ProveedorPagoDefault));
         GxWebStd.gx_hidden_field( context, "Z490ProveedorPideDoc", StringUtil.RTrim( Z490ProveedorPideDoc));
         GxWebStd.gx_hidden_field( context, "Z601ProveedorUsoInterno", StringUtil.RTrim( Z601ProveedorUsoInterno));
         GxWebStd.gx_hidden_field( context, "Z687ProveedorCuentaBancaria", StringUtil.RTrim( Z687ProveedorCuentaBancaria));
         GxWebStd.gx_boolean_hidden_field( context, "Z978ProveedorCIU", Z978ProveedorCIU);
         GxWebStd.gx_boolean_hidden_field( context, "Z999ProveedorFreezePrice", Z999ProveedorFreezePrice);
         GxWebStd.gx_hidden_field( context, "Z151ProveedoresTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z151ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z488DocumentacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z488DocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z673BancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z673BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O345ProveedorSerialComi", StringUtil.LTrim( StringUtil.NToC( (decimal)(O345ProveedorSerialComi), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_176", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_176_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N151ProveedoresTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A151ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N488DocumentacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A488DocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N673BancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A673BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "vPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROVEEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProveedorID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROVEEDORESTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_ProveedoresTipoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_DOCUMENTACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_DocumentacionId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_BANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36Insert_BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROVEEDORIMAGEN_GXI", A40000ProveedorImagen_GXI);
         GxWebStd.gx_hidden_field( context, "PROVEEDORESTIPONOMBRE", StringUtil.RTrim( A278ProveedoresTipoNombre));
         GxWebStd.gx_hidden_field( context, "DOCUMENTACIONICONO_GXI", A40001DocumentacionIcono_GXI);
         GxWebStd.gx_hidden_field( context, "BANCONOMBRE", StringUtil.RTrim( A674BancoNombre));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV40Pgmname));
         GxWebStd.gx_hidden_field( context, "RUBROSIMAGEN_GXI", A40002RubrosImagen_GXI);
         GxWebStd.gx_hidden_field( context, "INVENTARIONOMBRE", StringUtil.RTrim( A136InventarioNombre));
         GXCCtlgxBlob = "PROVEEDORIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A432ProveedorImagen);
         GXCCtlgxBlob = "DOCUMENTACIONICONO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A498DocumentacionIcono);
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Objectcall", StringUtil.RTrim( Dvpanel_unnamedtable3_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Enabled", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Width", StringUtil.RTrim( Dvpanel_unnamedtable3_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Cls", StringUtil.RTrim( Dvpanel_unnamedtable3_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Title", StringUtil.RTrim( Dvpanel_unnamedtable3_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable3_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE3_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable3_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Objectcall", StringUtil.RTrim( Gxuitabspanel_tabs_Objectcall));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Enabled", StringUtil.BoolToStr( Gxuitabspanel_tabs_Enabled));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_COMISION_TITLESCATEGORIES_Objectcall", StringUtil.RTrim( Gridlevel_comision_titlescategories_Objectcall));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_COMISION_TITLESCATEGORIES_Enabled", StringUtil.BoolToStr( Gridlevel_comision_titlescategories_Enabled));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_COMISION_TITLESCATEGORIES_Gridinternalname", StringUtil.RTrim( Gridlevel_comision_titlescategories_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDLEVEL_COMISION_TITLESCATEGORIES_Gridtitlescategories", StringUtil.RTrim( Gridlevel_comision_titlescategories_Gridtitlescategories));
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
         GXEncryptionTmp = "proveedor.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ProveedorID,18,0));
         return formatLink("proveedor.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Proveedor" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Comercio", "") ;
      }

      protected void InitializeNonKey0N28( )
      {
         A151ProveedoresTipoId = 0;
         AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
         A488DocumentacionId = 0;
         n488DocumentacionId = false;
         AssignAttri("", false, "A488DocumentacionId", StringUtil.LTrimStr( (decimal)(A488DocumentacionId), 18, 0));
         n488DocumentacionId = ((0==A488DocumentacionId) ? true : false);
         A673BancoId = 0;
         n673BancoId = false;
         AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
         n673BancoId = ((0==A673BancoId) ? true : false);
         A546ProveedorUsrAlta = 0;
         n546ProveedorUsrAlta = false;
         AssignAttri("", false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
         n546ProveedorUsrAlta = ((0==A546ProveedorUsrAlta) ? true : false);
         A547ProveedorUsrActualizacion = 0;
         n547ProveedorUsrActualizacion = false;
         AssignAttri("", false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
         n547ProveedorUsrActualizacion = ((0==A547ProveedorUsrActualizacion) ? true : false);
         A548ProveedorFechaAlta = (DateTime)(DateTime.MinValue);
         n548ProveedorFechaAlta = false;
         AssignAttri("", false, "A548ProveedorFechaAlta", context.localUtil.TToC( A548ProveedorFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n548ProveedorFechaAlta = ((DateTime.MinValue==A548ProveedorFechaAlta) ? true : false);
         A549ProveedorFechaActualizacion = (DateTime)(DateTime.MinValue);
         n549ProveedorFechaActualizacion = false;
         AssignAttri("", false, "A549ProveedorFechaActualizacion", context.localUtil.TToC( A549ProveedorFechaActualizacion, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n549ProveedorFechaActualizacion = ((DateTime.MinValue==A549ProveedorFechaActualizacion) ? true : false);
         A278ProveedoresTipoNombre = "";
         AssignAttri("", false, "A278ProveedoresTipoNombre", A278ProveedoresTipoNombre);
         A282ProveedorNombre = "";
         AssignAttri("", false, "A282ProveedorNombre", A282ProveedorNombre);
         A682ProveedorRazonSocial = "";
         n682ProveedorRazonSocial = false;
         AssignAttri("", false, "A682ProveedorRazonSocial", A682ProveedorRazonSocial);
         n682ProveedorRazonSocial = (String.IsNullOrEmpty(StringUtil.RTrim( A682ProveedorRazonSocial)) ? true : false);
         A683ProveedorContacto = "";
         n683ProveedorContacto = false;
         AssignAttri("", false, "A683ProveedorContacto", A683ProveedorContacto);
         n683ProveedorContacto = (String.IsNullOrEmpty(StringUtil.RTrim( A683ProveedorContacto)) ? true : false);
         A684ProveedorContactoCell = "";
         n684ProveedorContactoCell = false;
         AssignAttri("", false, "A684ProveedorContactoCell", A684ProveedorContactoCell);
         n684ProveedorContactoCell = (String.IsNullOrEmpty(StringUtil.RTrim( A684ProveedorContactoCell)) ? true : false);
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
         A338ProveedorDocIdentidad = "";
         AssignAttri("", false, "A338ProveedorDocIdentidad", A338ProveedorDocIdentidad);
         A345ProveedorSerialComi = 0;
         AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
         A430ProveedorTelefono = "";
         n430ProveedorTelefono = false;
         AssignAttri("", false, "A430ProveedorTelefono", A430ProveedorTelefono);
         n430ProveedorTelefono = (String.IsNullOrEmpty(StringUtil.RTrim( A430ProveedorTelefono)) ? true : false);
         A431ProveedorDireccion = "";
         n431ProveedorDireccion = false;
         AssignAttri("", false, "A431ProveedorDireccion", A431ProveedorDireccion);
         n431ProveedorDireccion = (String.IsNullOrEmpty(StringUtil.RTrim( A431ProveedorDireccion)) ? true : false);
         A433ProveedorEmail = "";
         n433ProveedorEmail = false;
         AssignAttri("", false, "A433ProveedorEmail", A433ProveedorEmail);
         n433ProveedorEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A433ProveedorEmail)) ? true : false);
         A685ProveedorSitioWeb = "";
         n685ProveedorSitioWeb = false;
         AssignAttri("", false, "A685ProveedorSitioWeb", A685ProveedorSitioWeb);
         n685ProveedorSitioWeb = (String.IsNullOrEmpty(StringUtil.RTrim( A685ProveedorSitioWeb)) ? true : false);
         A686ProveedorAceptoTerminos = (DateTime)(DateTime.MinValue);
         n686ProveedorAceptoTerminos = false;
         AssignAttri("", false, "A686ProveedorAceptoTerminos", context.localUtil.TToC( A686ProveedorAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n686ProveedorAceptoTerminos = ((DateTime.MinValue==A686ProveedorAceptoTerminos) ? true : false);
         A498DocumentacionIcono = "";
         AssignAttri("", false, "A498DocumentacionIcono", A498DocumentacionIcono);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         A40001DocumentacionIcono_GXI = "";
         AssignProp("", false, imgDocumentacionIcono_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40001DocumentacionIcono_GXI : context.convertURL( context.PathToRelativeUrl( A498DocumentacionIcono))), true);
         AssignProp("", false, imgDocumentacionIcono_Internalname, "SrcSet", context.GetImageSrcSet( A498DocumentacionIcono), true);
         A601ProveedorUsoInterno = "";
         n601ProveedorUsoInterno = false;
         AssignAttri("", false, "A601ProveedorUsoInterno", A601ProveedorUsoInterno);
         n601ProveedorUsoInterno = (String.IsNullOrEmpty(StringUtil.RTrim( A601ProveedorUsoInterno)) ? true : false);
         A687ProveedorCuentaBancaria = "";
         n687ProveedorCuentaBancaria = false;
         AssignAttri("", false, "A687ProveedorCuentaBancaria", A687ProveedorCuentaBancaria);
         n687ProveedorCuentaBancaria = (String.IsNullOrEmpty(StringUtil.RTrim( A687ProveedorCuentaBancaria)) ? true : false);
         A674BancoNombre = "";
         AssignAttri("", false, "A674BancoNombre", A674BancoNombre);
         A437ProveedorPerAltShop = context.GetMessage( "N", "");
         n437ProveedorPerAltShop = false;
         AssignAttri("", false, "A437ProveedorPerAltShop", A437ProveedorPerAltShop);
         A344ProveedorEstado = "PEN";
         AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         A440ProveedorPagoDefault = "T";
         AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
         A490ProveedorPideDoc = context.GetMessage( "N", "");
         n490ProveedorPideDoc = false;
         AssignAttri("", false, "A490ProveedorPideDoc", A490ProveedorPideDoc);
         A978ProveedorCIU = false;
         AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
         A999ProveedorFreezePrice = false;
         n999ProveedorFreezePrice = false;
         AssignAttri("", false, "A999ProveedorFreezePrice", A999ProveedorFreezePrice);
         O345ProveedorSerialComi = A345ProveedorSerialComi;
         AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
         Z546ProveedorUsrAlta = 0;
         Z547ProveedorUsrActualizacion = 0;
         Z548ProveedorFechaAlta = (DateTime)(DateTime.MinValue);
         Z549ProveedorFechaActualizacion = (DateTime)(DateTime.MinValue);
         Z282ProveedorNombre = "";
         Z682ProveedorRazonSocial = "";
         Z683ProveedorContacto = "";
         Z684ProveedorContactoCell = "";
         Z338ProveedorDocIdentidad = "";
         Z345ProveedorSerialComi = 0;
         Z430ProveedorTelefono = "";
         Z431ProveedorDireccion = "";
         Z433ProveedorEmail = "";
         Z685ProveedorSitioWeb = "";
         Z686ProveedorAceptoTerminos = (DateTime)(DateTime.MinValue);
         Z437ProveedorPerAltShop = "";
         Z344ProveedorEstado = "";
         Z440ProveedorPagoDefault = "";
         Z490ProveedorPideDoc = "";
         Z601ProveedorUsoInterno = "";
         Z687ProveedorCuentaBancaria = "";
         Z978ProveedorCIU = false;
         Z999ProveedorFreezePrice = false;
         Z151ProveedoresTipoId = 0;
         Z488DocumentacionId = 0;
         Z673BancoId = 0;
      }

      protected void InitAll0N28( )
      {
         A133ProveedorID = 0;
         n133ProveedorID = false;
         AssignAttri("", false, "A133ProveedorID", StringUtil.LTrimStr( (decimal)(A133ProveedorID), 18, 0));
         InitializeNonKey0N28( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A978ProveedorCIU = i978ProveedorCIU;
         AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
         A344ProveedorEstado = i344ProveedorEstado;
         AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
         A437ProveedorPerAltShop = i437ProveedorPerAltShop;
         n437ProveedorPerAltShop = false;
         AssignAttri("", false, "A437ProveedorPerAltShop", A437ProveedorPerAltShop);
         A490ProveedorPideDoc = i490ProveedorPideDoc;
         n490ProveedorPideDoc = false;
         AssignAttri("", false, "A490ProveedorPideDoc", A490ProveedorPideDoc);
         A440ProveedorPagoDefault = i440ProveedorPagoDefault;
         AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
         A999ProveedorFreezePrice = i999ProveedorFreezePrice;
         n999ProveedorFreezePrice = false;
         AssignAttri("", false, "A999ProveedorFreezePrice", A999ProveedorFreezePrice);
      }

      protected void InitializeNonKey0N29( )
      {
         A121RubrosId = 0;
         A168RubrosImagen = "";
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_176_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A40002RubrosImagen_GXI = "";
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40002RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_176_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A137MedidasID = 0;
         A135InventarioId = 0;
         n135InventarioId = false;
         A136InventarioNombre = "";
         AssignAttri("", false, "A136InventarioNombre", A136InventarioNombre);
         A118MonedaId = 0;
         A107EstadosTipo = "";
         A108EstadosGenericosId = 0;
         A109EstadosGenericosNombre = "";
         A181InventarioPrecioFinal = 0;
         A1001ProveedorComisionFP = false;
         n1001ProveedorComisionFP = false;
         A1000ProveedorComisionFPF = 0;
         n1000ProveedorComisionFPF = false;
         A346ProveedorComisionTipo = "";
         A347ProveedorComision = 0;
         A348ProveedorComisionAccion = "";
         Z348ProveedorComisionAccion = "";
         Z1001ProveedorComisionFP = false;
         Z1000ProveedorComisionFPF = 0;
         Z346ProveedorComisionTipo = "";
         Z347ProveedorComision = 0;
         Z121RubrosId = 0;
         Z137MedidasID = 0;
         Z135InventarioId = 0;
      }

      protected void InitAll0N29( )
      {
         A157ProveedorComisionID = 0;
         InitializeNonKey0N29( ) ;
      }

      protected void StandaloneModalInsert0N29( )
      {
         A345ProveedorSerialComi = i345ProveedorSerialComi;
         AssignAttri("", false, "A345ProveedorSerialComi", StringUtil.LTrimStr( (decimal)(A345ProveedorSerialComi), 4, 0));
         A348ProveedorComisionAccion = i348ProveedorComisionAccion;
      }

      protected void define_styles( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269319594388", true, true, false);
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
         context.AddJavascriptSource("proveedor.js", "?20269319594388", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties29( )
      {
         edtEstadosGenericosId_Enabled = defedtEstadosGenericosId_Enabled;
         AssignProp("", false, edtEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosGenericosId_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtEstadosTipo_Enabled = defedtEstadosTipo_Enabled;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtMonedaId_Enabled = defedtMonedaId_Enabled;
         AssignProp("", false, edtMonedaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonedaId_Enabled), 5, 0), !bGXsfl_176_Refreshing);
         edtProveedorComisionID_Enabled = defedtProveedorComisionID_Enabled;
         AssignProp("", false, edtProveedorComisionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProveedorComisionID_Enabled), 5, 0), !bGXsfl_176_Refreshing);
      }

      protected void StartGridControl176( )
      {
         Gridlevel_comisionContainer.AddObjectProperty("GridName", "Gridlevel_comision");
         Gridlevel_comisionContainer.AddObjectProperty("Header", subGridlevel_comision_Header);
         Gridlevel_comisionContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_comisionContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_comisionContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_comisionContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comision_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_comisionContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_comisionContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A157ProveedorComisionID), 18, 0, ".", ""))));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorComisionID_Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynRubrosId.Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", context.convertURL( A168RubrosImagen));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynMedidasID.Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynInventarioId.Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", ""))));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMonedaId_Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A107EstadosTipo)));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosTipo_Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", ""))));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosId_Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A109EstadosGenericosNombre)));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosGenericosNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", ""))));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInventarioPrecioFinal_Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A1001ProveedorComisionFP)));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkProveedorComisionFP.Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A1000ProveedorComisionFPF, 18, 2, ".", ""))));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorComisionFPF_Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A346ProveedorComisionTipo)));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorComisionTipo.Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A347ProveedorComision, 18, 2, ".", ""))));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProveedorComision_Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_comisionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A348ProveedorComisionAccion)));
         Gridlevel_comisionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbProveedorComisionAccion.Enabled), 5, 0, ".", "")));
         Gridlevel_comisionContainer.AddColumnProperties(Gridlevel_comisionColumn);
         Gridlevel_comisionContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comision_Selectedindex), 4, 0, ".", "")));
         Gridlevel_comisionContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comision_Allowselection), 1, 0, ".", "")));
         Gridlevel_comisionContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comision_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_comisionContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comision_Allowhovering), 1, 0, ".", "")));
         Gridlevel_comisionContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comision_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_comisionContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comision_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_comisionContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_comision_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTabgeneral_title_Internalname = "TABGENERAL_TITLE";
         edtProveedorID_Internalname = "PROVEEDORID";
         cmbProveedorEstado_Internalname = "PROVEEDORESTADO";
         lblTextblockproveedorfreezeprice_Internalname = "TEXTBLOCKPROVEEDORFREEZEPRICE";
         chkProveedorFreezePrice_Internalname = "PROVEEDORFREEZEPRICE";
         lblProveedorfreezeprice_righttext_Internalname = "PROVEEDORFREEZEPRICE_RIGHTTEXT";
         tblTablemergedproveedorfreezeprice_Internalname = "TABLEMERGEDPROVEEDORFREEZEPRICE";
         divTablesplittedproveedorfreezeprice_Internalname = "TABLESPLITTEDPROVEEDORFREEZEPRICE";
         dynProveedoresTipoId_Internalname = "PROVEEDORESTIPOID";
         edtProveedorNombre_Internalname = "PROVEEDORNOMBRE";
         edtProveedorRazonSocial_Internalname = "PROVEEDORRAZONSOCIAL";
         edtProveedorTelefono_Internalname = "PROVEEDORTELEFONO";
         edtProveedorEmail_Internalname = "PROVEEDOREMAIL";
         edtProveedorDireccion_Internalname = "PROVEEDORDIRECCION";
         lblTextblockproveedorusointerno_Internalname = "TEXTBLOCKPROVEEDORUSOINTERNO";
         chkProveedorUsoInterno_Internalname = "PROVEEDORUSOINTERNO";
         lblProveedorusointerno_righttext_Internalname = "PROVEEDORUSOINTERNO_RIGHTTEXT";
         tblTablemergedproveedorusointerno_Internalname = "TABLEMERGEDPROVEEDORUSOINTERNO";
         divTablesplittedproveedorusointerno_Internalname = "TABLESPLITTEDPROVEEDORUSOINTERNO";
         chkProveedorCIU_Internalname = "PROVEEDORCIU";
         divTb1_Internalname = "TB1";
         imgProveedorImagen_Internalname = "PROVEEDORIMAGEN";
         cmbProveedorPagoDefault_Internalname = "PROVEEDORPAGODEFAULT";
         edtProveedorDocIdentidad_Internalname = "PROVEEDORDOCIDENTIDAD";
         edtProveedorSitioWeb_Internalname = "PROVEEDORSITIOWEB";
         edtProveedorAceptoTerminos_Internalname = "PROVEEDORACEPTOTERMINOS";
         edtProveedorContacto_Internalname = "PROVEEDORCONTACTO";
         edtProveedorContactoCell_Internalname = "PROVEEDORCONTACTOCELL";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         Dvpanel_unnamedtable3_Internalname = "DVPANEL_UNNAMEDTABLE3";
         divTb2_Internalname = "TB2";
         dynBancoId_Internalname = "BANCOID";
         edtProveedorCuentaBancaria_Internalname = "PROVEEDORCUENTABANCARIA";
         dynProveedorUsrAlta_Internalname = "PROVEEDORUSRALTA";
         dynProveedorUsrActualizacion_Internalname = "PROVEEDORUSRACTUALIZACION";
         edtProveedorFechaAlta_Internalname = "PROVEEDORFECHAALTA";
         edtProveedorFechaActualizacion_Internalname = "PROVEEDORFECHAACTUALIZACION";
         tblUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         lblTablevel_comision_title_Internalname = "TABLEVEL_COMISION_TITLE";
         edtProveedorComisionID_Internalname = "PROVEEDORCOMISIONID";
         dynRubrosId_Internalname = "RUBROSID";
         edtRubrosImagen_Internalname = "RUBROSIMAGEN";
         dynMedidasID_Internalname = "MEDIDASID";
         dynInventarioId_Internalname = "INVENTARIOID";
         edtMonedaId_Internalname = "MONEDAID";
         edtEstadosTipo_Internalname = "ESTADOSTIPO";
         edtEstadosGenericosId_Internalname = "ESTADOSGENERICOSID";
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE";
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL";
         chkProveedorComisionFP_Internalname = "PROVEEDORCOMISIONFP";
         edtProveedorComisionFPF_Internalname = "PROVEEDORCOMISIONFPF";
         cmbProveedorComisionTipo_Internalname = "PROVEEDORCOMISIONTIPO";
         edtProveedorComision_Internalname = "PROVEEDORCOMISION";
         cmbProveedorComisionAccion_Internalname = "PROVEEDORCOMISIONACCION";
         divTableleaflevel_comision_Internalname = "TABLELEAFLEVEL_COMISION";
         divTabtablelevel_comision_Internalname = "TABTABLELEVEL_COMISION";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtProveedorSerialComi_Internalname = "PROVEEDORSERIALCOMI";
         edtProveedorPerAltShop_Internalname = "PROVEEDORPERALTSHOP";
         edtProveedorPideDoc_Internalname = "PROVEEDORPIDEDOC";
         edtDocumentacionId_Internalname = "DOCUMENTACIONID";
         imgDocumentacionIcono_Internalname = "DOCUMENTACIONICONO";
         Gridlevel_comision_titlescategories_Internalname = "GRIDLEVEL_COMISION_TITLESCATEGORIES";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_488_Internalname = "PROMPT_488";
         subGridlevel_comision_Internalname = "GRIDLEVEL_COMISION";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_comision_Allowcollapsing = 0;
         subGridlevel_comision_Allowselection = 0;
         subGridlevel_comision_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Comercio", "");
         cmbProveedorComisionAccion_Jsonclick = "";
         edtProveedorComision_Jsonclick = "";
         cmbProveedorComisionTipo_Jsonclick = "";
         edtProveedorComisionFPF_Jsonclick = "";
         chkProveedorComisionFP.Caption = "";
         edtInventarioPrecioFinal_Jsonclick = "";
         edtEstadosGenericosNombre_Jsonclick = "";
         edtEstadosGenericosId_Jsonclick = "";
         edtEstadosTipo_Jsonclick = "";
         edtMonedaId_Jsonclick = "";
         dynInventarioId_Jsonclick = "";
         dynMedidasID_Jsonclick = "";
         dynRubrosId_Jsonclick = "";
         edtProveedorComisionID_Jsonclick = "";
         subGridlevel_comision_Class = "WorkWith";
         subGridlevel_comision_Backcolorstyle = 0;
         Gridlevel_comision_titlescategories_Gridtitlescategories = "";
         cmbProveedorComisionAccion.Enabled = 1;
         edtProveedorComision_Enabled = 1;
         cmbProveedorComisionTipo.Enabled = 1;
         edtProveedorComisionFPF_Enabled = 1;
         chkProveedorComisionFP.Enabled = 1;
         edtInventarioPrecioFinal_Enabled = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         edtEstadosGenericosId_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         edtMonedaId_Enabled = 0;
         dynInventarioId.Enabled = 1;
         dynMedidasID.Enabled = 1;
         edtRubrosImagen_Enabled = 0;
         dynRubrosId.Enabled = 1;
         edtProveedorComisionID_Enabled = 0;
         imgDocumentacionIcono_Enabled = 0;
         imgDocumentacionIcono_Visible = 1;
         imgprompt_488_Visible = 1;
         imgprompt_488_Link = "";
         edtDocumentacionId_Jsonclick = "";
         edtDocumentacionId_Enabled = 1;
         edtDocumentacionId_Visible = 1;
         edtProveedorPideDoc_Jsonclick = "";
         edtProveedorPideDoc_Enabled = 1;
         edtProveedorPideDoc_Visible = 1;
         edtProveedorPerAltShop_Jsonclick = "";
         edtProveedorPerAltShop_Enabled = 1;
         edtProveedorPerAltShop_Visible = 1;
         edtProveedorSerialComi_Jsonclick = "";
         edtProveedorSerialComi_Enabled = 0;
         edtProveedorSerialComi_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtProveedorFechaActualizacion_Jsonclick = "";
         edtProveedorFechaActualizacion_Enabled = 0;
         edtProveedorFechaAlta_Jsonclick = "";
         edtProveedorFechaAlta_Enabled = 0;
         dynProveedorUsrActualizacion_Jsonclick = "";
         dynProveedorUsrActualizacion.Enabled = 0;
         dynProveedorUsrAlta_Jsonclick = "";
         dynProveedorUsrAlta.Enabled = 0;
         edtProveedorCuentaBancaria_Jsonclick = "";
         edtProveedorCuentaBancaria_Enabled = 1;
         dynBancoId_Jsonclick = "";
         dynBancoId.Enabled = 1;
         edtProveedorContactoCell_Jsonclick = "";
         edtProveedorContactoCell_Enabled = 1;
         edtProveedorContacto_Jsonclick = "";
         edtProveedorContacto_Enabled = 1;
         Dvpanel_unnamedtable3_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Iconposition = "Right";
         Dvpanel_unnamedtable3_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable3_Title = context.GetMessage( "CONTACTO", "");
         Dvpanel_unnamedtable3_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_unnamedtable3_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable3_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable3_Width = "100%";
         edtProveedorAceptoTerminos_Jsonclick = "";
         edtProveedorAceptoTerminos_Enabled = 0;
         edtProveedorSitioWeb_Jsonclick = "";
         edtProveedorSitioWeb_Enabled = 1;
         edtProveedorDocIdentidad_Jsonclick = "";
         edtProveedorDocIdentidad_Enabled = 1;
         cmbProveedorPagoDefault_Jsonclick = "";
         cmbProveedorPagoDefault.Enabled = 1;
         imgProveedorImagen_Enabled = 1;
         chkProveedorCIU.Enabled = 1;
         chkProveedorUsoInterno.Enabled = 1;
         edtProveedorDireccion_Enabled = 1;
         edtProveedorEmail_Jsonclick = "";
         edtProveedorEmail_Enabled = 1;
         edtProveedorTelefono_Jsonclick = "";
         edtProveedorTelefono_Enabled = 1;
         edtProveedorRazonSocial_Jsonclick = "";
         edtProveedorRazonSocial_Enabled = 1;
         edtProveedorNombre_Jsonclick = "";
         edtProveedorNombre_Enabled = 1;
         dynProveedoresTipoId_Jsonclick = "";
         dynProveedoresTipoId.Enabled = 1;
         chkProveedorFreezePrice.Enabled = 1;
         cmbProveedorEstado_Jsonclick = "";
         cmbProveedorEstado.Enabled = 1;
         edtProveedorID_Jsonclick = "";
         edtProveedorID_Enabled = 0;
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "Tab";
         Gxuitabspanel_tabs_Pagecount = 2;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         GXAMEDIDASID_html0N29( A121RubrosId) ;
         GXAINVENTARIOID_html0N29( A121RubrosId, A137MedidasID) ;
         /* End function dynload_actions */
      }

      protected void GXDLAPROVEEDORUSRACTUALIZACION0N1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAPROVEEDORUSRACTUALIZACION_data0N1( ) ;
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

      protected void GXAPROVEEDORUSRACTUALIZACION_html0N1( )
      {
         long gxdynajaxvalue;
         GXDLAPROVEEDORUSRACTUALIZACION_data0N1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynProveedorUsrActualizacion.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynProveedorUsrActualizacion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAPROVEEDORUSRACTUALIZACION_data0N1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000N55 */
         pr_default.execute(53);
         while ( (pr_default.getStatus(53) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000N55_A18SecUserId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000N55_A587SecUserFullName[0]);
            pr_default.readNext(53);
         }
         pr_default.close(53);
      }

      protected void GXDLAPROVEEDORUSRALTA0N1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAPROVEEDORUSRALTA_data0N1( ) ;
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

      protected void GXAPROVEEDORUSRALTA_html0N1( )
      {
         long gxdynajaxvalue;
         GXDLAPROVEEDORUSRALTA_data0N1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynProveedorUsrAlta.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynProveedorUsrAlta.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 10, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAPROVEEDORUSRALTA_data0N1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000N56 */
         pr_default.execute(54);
         while ( (pr_default.getStatus(54) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000N56_A18SecUserId[0]), 10, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000N56_A587SecUserFullName[0]);
            pr_default.readNext(54);
         }
         pr_default.close(54);
      }

      protected void GXDLAPROVEEDORESTIPOID0N1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAPROVEEDORESTIPOID_data0N1( ) ;
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

      protected void GXAPROVEEDORESTIPOID_html0N1( )
      {
         long gxdynajaxvalue;
         GXDLAPROVEEDORESTIPOID_data0N1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynProveedoresTipoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynProveedoresTipoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAPROVEEDORESTIPOID_data0N1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000N57 */
         pr_default.execute(55);
         while ( (pr_default.getStatus(55) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000N57_A151ProveedoresTipoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000N57_A278ProveedoresTipoNombre[0]));
            pr_default.readNext(55);
         }
         pr_default.close(55);
      }

      protected void GXDLABANCOID0N28( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLABANCOID_data0N28( ) ;
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

      protected void GXABANCOID_html0N28( )
      {
         long gxdynajaxvalue;
         GXDLABANCOID_data0N28( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynBancoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynBancoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLABANCOID_data0N28( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T000N58 */
         pr_default.execute(56);
         while ( (pr_default.getStatus(56) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000N58_A673BancoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000N58_A674BancoNombre[0]));
            pr_default.readNext(56);
         }
         pr_default.close(56);
      }

      protected void GXDLARUBROSID0N29( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLARUBROSID_data0N29( ) ;
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

      protected void GXARUBROSID_html0N29( )
      {
         short gxdynajaxvalue;
         GXDLARUBROSID_data0N29( ) ;
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

      protected void GXDLARUBROSID_data0N29( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T000N59 */
         pr_default.execute(57);
         while ( (pr_default.getStatus(57) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000N59_A121RubrosId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000N59_A122RubrosNombre[0]));
            pr_default.readNext(57);
         }
         pr_default.close(57);
      }

      protected void GXDLAMEDIDASID0N29( short A121RubrosId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMEDIDASID_data0N29( A121RubrosId) ;
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

      protected void GXAMEDIDASID_html0N29( short A121RubrosId )
      {
         long gxdynajaxvalue;
         GXDLAMEDIDASID_data0N29( A121RubrosId) ;
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

      protected void GXDLAMEDIDASID_data0N29( short A121RubrosId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T000N60 */
         pr_default.execute(58, new Object[] {A121RubrosId});
         while ( (pr_default.getStatus(58) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000N60_A137MedidasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000N60_A138MedidasNombre[0]));
            pr_default.readNext(58);
         }
         pr_default.close(58);
      }

      protected void GXDLAINVENTARIOID0N29( short A121RubrosId ,
                                            long A137MedidasID )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAINVENTARIOID_data0N29( A121RubrosId, A137MedidasID) ;
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

      protected void GXAINVENTARIOID_html0N29( short A121RubrosId ,
                                               long A137MedidasID )
      {
         long gxdynajaxvalue;
         GXDLAINVENTARIOID_data0N29( A121RubrosId, A137MedidasID) ;
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

      protected void GXDLAINVENTARIOID_data0N29( short A121RubrosId ,
                                                 long A137MedidasID )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T000N61 */
         pr_default.execute(59, new Object[] {A121RubrosId, A137MedidasID});
         while ( (pr_default.getStatus(59) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000N61_A135InventarioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000N61_A136InventarioNombre[0]));
            pr_default.readNext(59);
         }
         pr_default.close(59);
      }

      protected void gxnrGridlevel_comision_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_17629( ) ;
         while ( nGXsfl_176_idx <= nRC_GXsfl_176 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0N29( ) ;
            standaloneModal0N29( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0N29( ) ;
            nGXsfl_176_idx = (int)(nGXsfl_176_idx+1);
            sGXsfl_176_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_176_idx), 4, 0), 4, "0");
            SubsflControlProps_17629( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_comisionContainer)) ;
         /* End function gxnrGridlevel_comision_newrow */
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
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A344ProveedorEstado)) )
            {
               A344ProveedorEstado = "PEN";
               AssignAttri("", false, "A344ProveedorEstado", A344ProveedorEstado);
            }
         }
         chkProveedorFreezePrice.Name = "PROVEEDORFREEZEPRICE";
         chkProveedorFreezePrice.WebTags = "";
         chkProveedorFreezePrice.Caption = context.GetMessage( "Freezar Precio", "");
         AssignProp("", false, chkProveedorFreezePrice_Internalname, "TitleCaption", chkProveedorFreezePrice.Caption, true);
         chkProveedorFreezePrice.CheckedValue = "false";
         if ( IsIns( ) && (false==A999ProveedorFreezePrice) )
         {
            A999ProveedorFreezePrice = false;
            n999ProveedorFreezePrice = false;
            AssignAttri("", false, "A999ProveedorFreezePrice", A999ProveedorFreezePrice);
         }
         dynProveedoresTipoId.Name = "PROVEEDORESTIPOID";
         dynProveedoresTipoId.WebTags = "";
         dynProveedoresTipoId.removeAllItems();
         /* Using cursor T000N62 */
         pr_default.execute(60);
         while ( (pr_default.getStatus(60) != 101) )
         {
            dynProveedoresTipoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000N62_A151ProveedoresTipoId[0]), 18, 0)), T000N62_A278ProveedoresTipoNombre[0], 0);
            pr_default.readNext(60);
         }
         pr_default.close(60);
         if ( dynProveedoresTipoId.ItemCount > 0 )
         {
            A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( dynProveedoresTipoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A151ProveedoresTipoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A151ProveedoresTipoId", StringUtil.LTrimStr( (decimal)(A151ProveedoresTipoId), 18, 0));
         }
         chkProveedorUsoInterno.Name = "PROVEEDORUSOINTERNO";
         chkProveedorUsoInterno.WebTags = "";
         chkProveedorUsoInterno.Caption = context.GetMessage( "¿Es de Uso Interno?", "");
         AssignProp("", false, chkProveedorUsoInterno_Internalname, "TitleCaption", chkProveedorUsoInterno.Caption, true);
         chkProveedorUsoInterno.CheckedValue = "N";
         A601ProveedorUsoInterno = ((StringUtil.StrCmp(StringUtil.RTrim( A601ProveedorUsoInterno), "S")==0) ? "S" : "N");
         n601ProveedorUsoInterno = false;
         AssignAttri("", false, "A601ProveedorUsoInterno", A601ProveedorUsoInterno);
         chkProveedorCIU.Name = "PROVEEDORCIU";
         chkProveedorCIU.WebTags = "";
         chkProveedorCIU.Caption = context.GetMessage( "¿Convenio CIU?", "");
         AssignProp("", false, chkProveedorCIU_Internalname, "TitleCaption", chkProveedorCIU.Caption, true);
         chkProveedorCIU.CheckedValue = "false";
         if ( IsIns( ) && (false==A978ProveedorCIU) )
         {
            A978ProveedorCIU = false;
            AssignAttri("", false, "A978ProveedorCIU", A978ProveedorCIU);
         }
         cmbProveedorPagoDefault.Name = "PROVEEDORPAGODEFAULT";
         cmbProveedorPagoDefault.WebTags = "";
         cmbProveedorPagoDefault.addItem("F", context.GetMessage( "Cobro Directo", ""), 0);
         cmbProveedorPagoDefault.addItem("T", context.GetMessage( "Cobro Prepago Comercio", ""), 0);
         cmbProveedorPagoDefault.addItem("O", context.GetMessage( "Cobro Prepago Almango", ""), 0);
         if ( cmbProveedorPagoDefault.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A440ProveedorPagoDefault)) )
            {
               A440ProveedorPagoDefault = "T";
               AssignAttri("", false, "A440ProveedorPagoDefault", A440ProveedorPagoDefault);
            }
         }
         dynBancoId.Name = "BANCOID";
         dynBancoId.WebTags = "";
         dynProveedorUsrAlta.Name = "PROVEEDORUSRALTA";
         dynProveedorUsrAlta.WebTags = "";
         dynProveedorUsrAlta.removeAllItems();
         /* Using cursor T000N63 */
         pr_default.execute(61);
         while ( (pr_default.getStatus(61) != 101) )
         {
            dynProveedorUsrAlta.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000N63_A18SecUserId[0]), 10, 0)), T000N63_A587SecUserFullName[0], 0);
            pr_default.readNext(61);
         }
         pr_default.close(61);
         if ( dynProveedorUsrAlta.ItemCount > 0 )
         {
            A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrAlta.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A546ProveedorUsrAlta), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n546ProveedorUsrAlta = false;
            AssignAttri("", false, "A546ProveedorUsrAlta", StringUtil.LTrimStr( (decimal)(A546ProveedorUsrAlta), 10, 0));
         }
         dynProveedorUsrActualizacion.Name = "PROVEEDORUSRACTUALIZACION";
         dynProveedorUsrActualizacion.WebTags = "";
         dynProveedorUsrActualizacion.removeAllItems();
         /* Using cursor T000N64 */
         pr_default.execute(62);
         while ( (pr_default.getStatus(62) != 101) )
         {
            dynProveedorUsrActualizacion.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000N64_A18SecUserId[0]), 10, 0)), T000N64_A587SecUserFullName[0], 0);
            pr_default.readNext(62);
         }
         pr_default.close(62);
         if ( dynProveedorUsrActualizacion.ItemCount > 0 )
         {
            A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrActualizacion.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A547ProveedorUsrActualizacion), 10, 0))), "."), 18, MidpointRounding.ToEven));
            n547ProveedorUsrActualizacion = false;
            AssignAttri("", false, "A547ProveedorUsrActualizacion", StringUtil.LTrimStr( (decimal)(A547ProveedorUsrActualizacion), 10, 0));
         }
         GXCCtl = "RUBROSID_" + sGXsfl_176_idx;
         dynRubrosId.Name = GXCCtl;
         dynRubrosId.WebTags = "";
         GXCCtl = "MEDIDASID_" + sGXsfl_176_idx;
         dynMedidasID.Name = GXCCtl;
         dynMedidasID.WebTags = "";
         GXCCtl = "INVENTARIOID_" + sGXsfl_176_idx;
         dynInventarioId.Name = GXCCtl;
         dynInventarioId.WebTags = "";
         GXCCtl = "PROVEEDORCOMISIONFP_" + sGXsfl_176_idx;
         chkProveedorComisionFP.Name = GXCCtl;
         chkProveedorComisionFP.WebTags = "";
         chkProveedorComisionFP.Caption = "";
         AssignProp("", false, chkProveedorComisionFP_Internalname, "TitleCaption", chkProveedorComisionFP.Caption, !bGXsfl_176_Refreshing);
         chkProveedorComisionFP.CheckedValue = "false";
         A1001ProveedorComisionFP = StringUtil.StrToBool( StringUtil.BoolToStr( A1001ProveedorComisionFP));
         n1001ProveedorComisionFP = false;
         GXCCtl = "PROVEEDORCOMISIONTIPO_" + sGXsfl_176_idx;
         cmbProveedorComisionTipo.Name = GXCCtl;
         cmbProveedorComisionTipo.WebTags = "";
         cmbProveedorComisionTipo.addItem("P", context.GetMessage( "Porcentaje", ""), 0);
         cmbProveedorComisionTipo.addItem("F", context.GetMessage( "Valor Fijo", ""), 0);
         cmbProveedorComisionTipo.addItem("N", context.GetMessage( "No Aplica", ""), 0);
         if ( cmbProveedorComisionTipo.ItemCount > 0 )
         {
            A346ProveedorComisionTipo = cmbProveedorComisionTipo.getValidValue(A346ProveedorComisionTipo);
         }
         GXCCtl = "PROVEEDORCOMISIONACCION_" + sGXsfl_176_idx;
         cmbProveedorComisionAccion.Name = GXCCtl;
         cmbProveedorComisionAccion.WebTags = "";
         cmbProveedorComisionAccion.addItem("", context.GetMessage( "Sin Accion", ""), 0);
         cmbProveedorComisionAccion.addItem("S", context.GetMessage( "Suma", ""), 0);
         cmbProveedorComisionAccion.addItem("R", context.GetMessage( "Resta", ""), 0);
         if ( cmbProveedorComisionAccion.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A348ProveedorComisionAccion)) )
            {
               A348ProveedorComisionAccion = "";
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

      public void Valid_Proveedorestipoid( )
      {
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         n547ProveedorUsrActualizacion = false;
         A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrActualizacion.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n547ProveedorUsrActualizacion = false;
         n546ProveedorUsrAlta = false;
         A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrAlta.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n546ProveedorUsrAlta = false;
         A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( dynProveedoresTipoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000N24 */
         pr_default.execute(22, new Object[] {A151ProveedoresTipoId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Tipo de Proveedores", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROVEEDORESTIPOID");
            AnyError = 1;
            GX_FocusControl = dynProveedoresTipoId_Internalname;
         }
         A278ProveedoresTipoNombre = T000N24_A278ProveedoresTipoNombre[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A278ProveedoresTipoNombre", StringUtil.RTrim( A278ProveedoresTipoNombre));
      }

      public void Valid_Bancoid( )
      {
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         n547ProveedorUsrActualizacion = false;
         A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrActualizacion.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n547ProveedorUsrActualizacion = false;
         n546ProveedorUsrAlta = false;
         A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrAlta.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n546ProveedorUsrAlta = false;
         A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( dynProveedoresTipoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000N26 */
         pr_default.execute(24, new Object[] {n673BancoId, A673BancoId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A673BancoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Banco", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
               GX_FocusControl = dynBancoId_Internalname;
            }
         }
         A674BancoNombre = T000N26_A674BancoNombre[0];
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A674BancoNombre", StringUtil.RTrim( A674BancoNombre));
      }

      public void Valid_Documentacionid( )
      {
         n488DocumentacionId = false;
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         n547ProveedorUsrActualizacion = false;
         A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrActualizacion.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n547ProveedorUsrActualizacion = false;
         n546ProveedorUsrAlta = false;
         A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrAlta.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n546ProveedorUsrAlta = false;
         A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( dynProveedoresTipoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000N25 */
         pr_default.execute(23, new Object[] {n488DocumentacionId, A488DocumentacionId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A488DocumentacionId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Documentacion", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DOCUMENTACIONID");
               AnyError = 1;
               GX_FocusControl = edtDocumentacionId_Internalname;
            }
         }
         A40001DocumentacionIcono_GXI = T000N25_A40001DocumentacionIcono_GXI[0];
         A498DocumentacionIcono = T000N25_A498DocumentacionIcono[0];
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A498DocumentacionIcono", context.PathToRelativeUrl( A498DocumentacionIcono));
         GXCCtlgxBlob = "DOCUMENTACIONICONO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A498DocumentacionIcono));
         AssignAttri("", false, "A40001DocumentacionIcono_GXI", A40001DocumentacionIcono_GXI);
      }

      public void Valid_Rubrosid( )
      {
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         n547ProveedorUsrActualizacion = false;
         A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrActualizacion.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n547ProveedorUsrActualizacion = false;
         n546ProveedorUsrAlta = false;
         A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrAlta.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n546ProveedorUsrAlta = false;
         A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( dynProveedoresTipoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000N50 */
         pr_default.execute(48, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(48) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
         }
         A40002RubrosImagen_GXI = T000N50_A40002RubrosImagen_GXI[0];
         A168RubrosImagen = T000N50_A168RubrosImagen[0];
         pr_default.close(48);
         dynload_actions( ) ;
         if ( dynMedidasID.ItemCount > 0 )
         {
            A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
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
         AssignAttri("", false, "A168RubrosImagen", context.PathToRelativeUrl( A168RubrosImagen));
         GXCCtl = "RUBROSIMAGEN_" + sGXsfl_176_idx;
         AssignAttri("", false, "GXCCtl", GXCCtl);
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A168RubrosImagen));
         AssignAttri("", false, "A40002RubrosImagen_GXI", A40002RubrosImagen_GXI);
         AssignAttri("", false, "A137MedidasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", "")));
         dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
         AssignProp("", false, dynMedidasID_Internalname, "Values", dynMedidasID.ToJavascriptSource(), true);
         AssignAttri("", false, "A135InventarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", "")));
         dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         AssignProp("", false, dynInventarioId_Internalname, "Values", dynInventarioId.ToJavascriptSource(), true);
      }

      public void Valid_Medidasid( )
      {
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         n547ProveedorUsrActualizacion = false;
         A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrActualizacion.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n547ProveedorUsrActualizacion = false;
         n546ProveedorUsrAlta = false;
         A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrAlta.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n546ProveedorUsrAlta = false;
         A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( dynProveedoresTipoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000N51 */
         pr_default.execute(49, new Object[] {A121RubrosId, A137MedidasID});
         if ( (pr_default.getStatus(49) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros Medidas y Precios", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "MEDIDASID");
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
         }
         A118MonedaId = T000N51_A118MonedaId[0];
         pr_default.close(49);
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
         AssignAttri("", false, "A118MonedaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118MonedaId), 4, 0, ".", "")));
         AssignAttri("", false, "A135InventarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", "")));
         dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
         AssignProp("", false, dynInventarioId_Internalname, "Values", dynInventarioId.ToJavascriptSource(), true);
      }

      public void Valid_Inventarioid( )
      {
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A137MedidasID = (long)(Math.Round(NumberUtil.Val( dynMedidasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         A135InventarioId = (long)(Math.Round(NumberUtil.Val( dynInventarioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n135InventarioId = false;
         n547ProveedorUsrActualizacion = false;
         A547ProveedorUsrActualizacion = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrActualizacion.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n547ProveedorUsrActualizacion = false;
         n546ProveedorUsrAlta = false;
         A546ProveedorUsrAlta = (long)(Math.Round(NumberUtil.Val( dynProveedorUsrAlta.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n546ProveedorUsrAlta = false;
         A151ProveedoresTipoId = (long)(Math.Round(NumberUtil.Val( dynProveedoresTipoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000N52 */
         pr_default.execute(50, new Object[] {A121RubrosId, A137MedidasID, n135InventarioId, A135InventarioId});
         if ( (pr_default.getStatus(50) == 101) )
         {
            if ( ! ( (0==A121RubrosId) || (0==A137MedidasID) || (0==A135InventarioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "INVENTARIOID");
               AnyError = 1;
               GX_FocusControl = dynRubrosId_Internalname;
            }
         }
         A136InventarioNombre = T000N52_A136InventarioNombre[0];
         A181InventarioPrecioFinal = T000N52_A181InventarioPrecioFinal[0];
         A107EstadosTipo = T000N52_A107EstadosTipo[0];
         A108EstadosGenericosId = T000N52_A108EstadosGenericosId[0];
         pr_default.close(50);
         /* Using cursor T000N53 */
         pr_default.execute(51, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(51) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A107EstadosTipo)) || (0==A108EstadosGenericosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
               AnyError = 1;
            }
         }
         A109EstadosGenericosNombre = T000N53_A109EstadosGenericosNombre[0];
         pr_default.close(51);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A136InventarioNombre", StringUtil.RTrim( A136InventarioNombre));
         AssignAttri("", false, "A181InventarioPrecioFinal", StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", "")));
         AssignAttri("", false, "A107EstadosTipo", StringUtil.RTrim( A107EstadosTipo));
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", "")));
         AssignAttri("", false, "A109EstadosGenericosNombre", StringUtil.RTrim( A109EstadosGenericosNombre));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ProveedorID',fld:'vPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A133ProveedorID',fld:'PROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A686ProveedorAceptoTerminos',fld:'PROVEEDORACEPTOTERMINOS',pic:'99/99/99 99:99',type:'dtime'},{av:'A548ProveedorFechaAlta',fld:'PROVEEDORFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'A549ProveedorFechaActualizacion',fld:'PROVEEDORFECHAACTUALIZACION',pic:'99/99/99 99:99',type:'dtime'},{av:'AV13Insert_ProveedoresTipoId',fld:'vINSERT_PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14Insert_DocumentacionId',fld:'vINSERT_DOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV36Insert_BancoId',fld:'vINSERT_BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("AFTER TRN","{handler:'E120N2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROVEEDORID","{handler:'Valid_Proveedorid',iparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROVEEDORID",",oparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROVEEDORESTADO","{handler:'Valid_Proveedorestado',iparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROVEEDORESTADO",",oparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROVEEDORESTIPOID","{handler:'Valid_Proveedorestipoid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A278ProveedoresTipoNombre',fld:'PROVEEDORESTIPONOMBRE',pic:'',type:'char'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROVEEDORESTIPOID",",oparms:[{av:'A278ProveedoresTipoNombre',fld:'PROVEEDORESTIPONOMBRE',pic:'',type:'char'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROVEEDOREMAIL","{handler:'Valid_Proveedoremail',iparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROVEEDOREMAIL",",oparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROVEEDORPAGODEFAULT","{handler:'Valid_Proveedorpagodefault',iparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROVEEDORPAGODEFAULT",",oparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_BANCOID","{handler:'Valid_Bancoid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A674BancoNombre',fld:'BANCONOMBRE',pic:'',type:'char'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_BANCOID",",oparms:[{av:'A674BancoNombre',fld:'BANCONOMBRE',pic:'',type:'char'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROVEEDORSERIALCOMI","{handler:'Valid_Proveedorserialcomi',iparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROVEEDORSERIALCOMI",",oparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_DOCUMENTACIONID","{handler:'Valid_Documentacionid',iparms:[{av:'A488DocumentacionId',fld:'DOCUMENTACIONID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A498DocumentacionIcono',fld:'DOCUMENTACIONICONO',pic:'',type:'bits'},{av:'A40001DocumentacionIcono_GXI',fld:'DOCUMENTACIONICONO_GXI',pic:'',type:'svchar'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_DOCUMENTACIONID",",oparms:[{av:'A498DocumentacionIcono',fld:'DOCUMENTACIONICONO',pic:'',type:'bits'},{av:'A40001DocumentacionIcono_GXI',fld:'DOCUMENTACIONICONO_GXI',pic:'',type:'svchar'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROVEEDORCOMISIONID","{handler:'Valid_Proveedorcomisionid',iparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROVEEDORCOMISIONID",",oparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A168RubrosImagen',fld:'RUBROSIMAGEN',pic:'',type:'bits'},{av:'A40002RubrosImagen_GXI',fld:'RUBROSIMAGEN_GXI',pic:'',type:'svchar'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_RUBROSID",",oparms:[{av:'A168RubrosImagen',fld:'RUBROSIMAGEN',pic:'',type:'bits'},{av:'A40002RubrosImagen_GXI',fld:'RUBROSIMAGEN_GXI',pic:'',type:'svchar'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[{av:'A118MonedaId',fld:'MONEDAID',pic:'ZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_INVENTARIOID","{handler:'Valid_Inventarioid',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A136InventarioNombre',fld:'INVENTARIONOMBRE',pic:'',type:'char'},{av:'A181InventarioPrecioFinal',fld:'INVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A109EstadosGenericosNombre',fld:'ESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_INVENTARIOID",",oparms:[{av:'A136InventarioNombre',fld:'INVENTARIONOMBRE',pic:'',type:'char'},{av:'A181InventarioPrecioFinal',fld:'INVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'A109EstadosGenericosNombre',fld:'ESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ESTADOSTIPO","{handler:'Valid_Estadostipo',iparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ESTADOSTIPO",",oparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ESTADOSGENERICOSID","{handler:'Valid_Estadosgenericosid',iparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ESTADOSGENERICOSID",",oparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
         setEventMetadata("NULL","{handler:'Valid_Proveedorcomisionaccion',iparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]");
         setEventMetadata("NULL",",oparms:[{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrActualizacion'},{av:'A547ProveedorUsrActualizacion',fld:'PROVEEDORUSRACTUALIZACION',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedorUsrAlta'},{av:'A546ProveedorUsrAlta',fld:'PROVEEDORUSRALTA',pic:'ZZZZZZZZZ9',type:'int'},{av:'dynProveedoresTipoId'},{av:'A151ProveedoresTipoId',fld:'PROVEEDORESTIPOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A999ProveedorFreezePrice',fld:'PROVEEDORFREEZEPRICE',pic:'',type:'boolean'},{av:'A601ProveedorUsoInterno',fld:'PROVEEDORUSOINTERNO',pic:'',type:'char'},{av:'A978ProveedorCIU',fld:'PROVEEDORCIU',pic:'',type:'boolean'}]}");
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
         pr_default.close(49);
         pr_default.close(50);
         pr_default.close(48);
         pr_default.close(51);
         pr_default.close(7);
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(24);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z548ProveedorFechaAlta = (DateTime)(DateTime.MinValue);
         Z549ProveedorFechaActualizacion = (DateTime)(DateTime.MinValue);
         Z282ProveedorNombre = "";
         Z682ProveedorRazonSocial = "";
         Z683ProveedorContacto = "";
         Z684ProveedorContactoCell = "";
         Z338ProveedorDocIdentidad = "";
         Z430ProveedorTelefono = "";
         Z431ProveedorDireccion = "";
         Z433ProveedorEmail = "";
         Z685ProveedorSitioWeb = "";
         Z686ProveedorAceptoTerminos = (DateTime)(DateTime.MinValue);
         Z437ProveedorPerAltShop = "";
         Z344ProveedorEstado = "";
         Z440ProveedorPagoDefault = "";
         Z490ProveedorPideDoc = "";
         Z601ProveedorUsoInterno = "";
         Z687ProveedorCuentaBancaria = "";
         Z348ProveedorComisionAccion = "";
         Z346ProveedorComisionTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A107EstadosTipo = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A344ProveedorEstado = "";
         A601ProveedorUsoInterno = "";
         A440ProveedorPagoDefault = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblTabgeneral_title_Jsonclick = "";
         TempTags = "";
         lblTextblockproveedorfreezeprice_Jsonclick = "";
         sStyleString = "";
         lblProveedorfreezeprice_righttext_Jsonclick = "";
         A282ProveedorNombre = "";
         A682ProveedorRazonSocial = "";
         gxphoneLink = "";
         A430ProveedorTelefono = "";
         A433ProveedorEmail = "";
         A431ProveedorDireccion = "";
         lblTextblockproveedorusointerno_Jsonclick = "";
         lblProveedorusointerno_righttext_Jsonclick = "";
         A432ProveedorImagen = "";
         A40000ProveedorImagen_GXI = "";
         sImgUrl = "";
         A338ProveedorDocIdentidad = "";
         A685ProveedorSitioWeb = "";
         A686ProveedorAceptoTerminos = (DateTime)(DateTime.MinValue);
         ucDvpanel_unnamedtable3 = new GXUserControl();
         A683ProveedorContacto = "";
         A684ProveedorContactoCell = "";
         A687ProveedorCuentaBancaria = "";
         A548ProveedorFechaAlta = (DateTime)(DateTime.MinValue);
         A549ProveedorFechaActualizacion = (DateTime)(DateTime.MinValue);
         lblTablevel_comision_title_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A437ProveedorPerAltShop = "";
         A490ProveedorPideDoc = "";
         imgprompt_488_gximage = "";
         A498DocumentacionIcono = "";
         A40001DocumentacionIcono_GXI = "";
         ucGridlevel_comision_titlescategories = new GXUserControl();
         Gridlevel_comisionContainer = new GXWebGrid( context);
         sMode29 = "";
         A278ProveedoresTipoNombre = "";
         A674BancoNombre = "";
         AV40Pgmname = "";
         A40002RubrosImagen_GXI = "";
         A136InventarioNombre = "";
         Dvpanel_unnamedtable3_Objectcall = "";
         Dvpanel_unnamedtable3_Class = "";
         Dvpanel_unnamedtable3_Height = "";
         Dvpanel_unnamedtable3_Titletype = "";
         Gxuitabspanel_tabs_Objectcall = "";
         Gxuitabspanel_tabs_Activepagecontrolname = "";
         Gridlevel_comision_titlescategories_Objectcall = "";
         Gridlevel_comision_titlescategories_Class = "";
         Gridlevel_comision_titlescategories_Gridinternalname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode28 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A168RubrosImagen = "";
         A109EstadosGenericosNombre = "";
         A346ProveedorComisionTipo = "";
         A348ProveedorComisionAccion = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV31Roles = new SdtSDTRoles(context);
         AV32RolesItem = new SdtSDTRoles_Id(context);
         AV34SecRoleName = "";
         AV33AgrProveedorEstado = "";
         Z432ProveedorImagen = "";
         Z40000ProveedorImagen_GXI = "";
         Z278ProveedoresTipoNombre = "";
         Z498DocumentacionIcono = "";
         Z40001DocumentacionIcono_GXI = "";
         Z674BancoNombre = "";
         T000N12_A674BancoNombre = new string[] {""} ;
         T000N11_A40001DocumentacionIcono_GXI = new string[] {""} ;
         T000N11_A498DocumentacionIcono = new string[] {""} ;
         T000N10_A278ProveedoresTipoNombre = new string[] {""} ;
         T000N13_A133ProveedorID = new long[1] ;
         T000N13_n133ProveedorID = new bool[] {false} ;
         T000N13_A546ProveedorUsrAlta = new long[1] ;
         T000N13_n546ProveedorUsrAlta = new bool[] {false} ;
         T000N13_A547ProveedorUsrActualizacion = new long[1] ;
         T000N13_n547ProveedorUsrActualizacion = new bool[] {false} ;
         T000N13_A548ProveedorFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T000N13_n548ProveedorFechaAlta = new bool[] {false} ;
         T000N13_A549ProveedorFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         T000N13_n549ProveedorFechaActualizacion = new bool[] {false} ;
         T000N13_A278ProveedoresTipoNombre = new string[] {""} ;
         T000N13_A282ProveedorNombre = new string[] {""} ;
         T000N13_A682ProveedorRazonSocial = new string[] {""} ;
         T000N13_n682ProveedorRazonSocial = new bool[] {false} ;
         T000N13_A683ProveedorContacto = new string[] {""} ;
         T000N13_n683ProveedorContacto = new bool[] {false} ;
         T000N13_A684ProveedorContactoCell = new string[] {""} ;
         T000N13_n684ProveedorContactoCell = new bool[] {false} ;
         T000N13_A40000ProveedorImagen_GXI = new string[] {""} ;
         T000N13_n40000ProveedorImagen_GXI = new bool[] {false} ;
         T000N13_A338ProveedorDocIdentidad = new string[] {""} ;
         T000N13_A345ProveedorSerialComi = new short[1] ;
         T000N13_A430ProveedorTelefono = new string[] {""} ;
         T000N13_n430ProveedorTelefono = new bool[] {false} ;
         T000N13_A431ProveedorDireccion = new string[] {""} ;
         T000N13_n431ProveedorDireccion = new bool[] {false} ;
         T000N13_A433ProveedorEmail = new string[] {""} ;
         T000N13_n433ProveedorEmail = new bool[] {false} ;
         T000N13_A685ProveedorSitioWeb = new string[] {""} ;
         T000N13_n685ProveedorSitioWeb = new bool[] {false} ;
         T000N13_A686ProveedorAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         T000N13_n686ProveedorAceptoTerminos = new bool[] {false} ;
         T000N13_A437ProveedorPerAltShop = new string[] {""} ;
         T000N13_n437ProveedorPerAltShop = new bool[] {false} ;
         T000N13_A344ProveedorEstado = new string[] {""} ;
         T000N13_A440ProveedorPagoDefault = new string[] {""} ;
         T000N13_A490ProveedorPideDoc = new string[] {""} ;
         T000N13_n490ProveedorPideDoc = new bool[] {false} ;
         T000N13_A40001DocumentacionIcono_GXI = new string[] {""} ;
         T000N13_A601ProveedorUsoInterno = new string[] {""} ;
         T000N13_n601ProveedorUsoInterno = new bool[] {false} ;
         T000N13_A687ProveedorCuentaBancaria = new string[] {""} ;
         T000N13_n687ProveedorCuentaBancaria = new bool[] {false} ;
         T000N13_A674BancoNombre = new string[] {""} ;
         T000N13_A978ProveedorCIU = new bool[] {false} ;
         T000N13_A999ProveedorFreezePrice = new bool[] {false} ;
         T000N13_n999ProveedorFreezePrice = new bool[] {false} ;
         T000N13_A151ProveedoresTipoId = new long[1] ;
         T000N13_A488DocumentacionId = new long[1] ;
         T000N13_n488DocumentacionId = new bool[] {false} ;
         T000N13_A673BancoId = new long[1] ;
         T000N13_n673BancoId = new bool[] {false} ;
         T000N13_A432ProveedorImagen = new string[] {""} ;
         T000N13_n432ProveedorImagen = new bool[] {false} ;
         T000N13_A498DocumentacionIcono = new string[] {""} ;
         T000N14_A278ProveedoresTipoNombre = new string[] {""} ;
         T000N15_A40001DocumentacionIcono_GXI = new string[] {""} ;
         T000N15_A498DocumentacionIcono = new string[] {""} ;
         T000N16_A674BancoNombre = new string[] {""} ;
         T000N17_A133ProveedorID = new long[1] ;
         T000N17_n133ProveedorID = new bool[] {false} ;
         T000N9_A133ProveedorID = new long[1] ;
         T000N9_n133ProveedorID = new bool[] {false} ;
         T000N9_A546ProveedorUsrAlta = new long[1] ;
         T000N9_n546ProveedorUsrAlta = new bool[] {false} ;
         T000N9_A547ProveedorUsrActualizacion = new long[1] ;
         T000N9_n547ProveedorUsrActualizacion = new bool[] {false} ;
         T000N9_A548ProveedorFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T000N9_n548ProveedorFechaAlta = new bool[] {false} ;
         T000N9_A549ProveedorFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         T000N9_n549ProveedorFechaActualizacion = new bool[] {false} ;
         T000N9_A282ProveedorNombre = new string[] {""} ;
         T000N9_A682ProveedorRazonSocial = new string[] {""} ;
         T000N9_n682ProveedorRazonSocial = new bool[] {false} ;
         T000N9_A683ProveedorContacto = new string[] {""} ;
         T000N9_n683ProveedorContacto = new bool[] {false} ;
         T000N9_A684ProveedorContactoCell = new string[] {""} ;
         T000N9_n684ProveedorContactoCell = new bool[] {false} ;
         T000N9_A40000ProveedorImagen_GXI = new string[] {""} ;
         T000N9_n40000ProveedorImagen_GXI = new bool[] {false} ;
         T000N9_A338ProveedorDocIdentidad = new string[] {""} ;
         T000N9_A345ProveedorSerialComi = new short[1] ;
         T000N9_A430ProveedorTelefono = new string[] {""} ;
         T000N9_n430ProveedorTelefono = new bool[] {false} ;
         T000N9_A431ProveedorDireccion = new string[] {""} ;
         T000N9_n431ProveedorDireccion = new bool[] {false} ;
         T000N9_A433ProveedorEmail = new string[] {""} ;
         T000N9_n433ProveedorEmail = new bool[] {false} ;
         T000N9_A685ProveedorSitioWeb = new string[] {""} ;
         T000N9_n685ProveedorSitioWeb = new bool[] {false} ;
         T000N9_A686ProveedorAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         T000N9_n686ProveedorAceptoTerminos = new bool[] {false} ;
         T000N9_A437ProveedorPerAltShop = new string[] {""} ;
         T000N9_n437ProveedorPerAltShop = new bool[] {false} ;
         T000N9_A344ProveedorEstado = new string[] {""} ;
         T000N9_A440ProveedorPagoDefault = new string[] {""} ;
         T000N9_A490ProveedorPideDoc = new string[] {""} ;
         T000N9_n490ProveedorPideDoc = new bool[] {false} ;
         T000N9_A601ProveedorUsoInterno = new string[] {""} ;
         T000N9_n601ProveedorUsoInterno = new bool[] {false} ;
         T000N9_A687ProveedorCuentaBancaria = new string[] {""} ;
         T000N9_n687ProveedorCuentaBancaria = new bool[] {false} ;
         T000N9_A978ProveedorCIU = new bool[] {false} ;
         T000N9_A999ProveedorFreezePrice = new bool[] {false} ;
         T000N9_n999ProveedorFreezePrice = new bool[] {false} ;
         T000N9_A151ProveedoresTipoId = new long[1] ;
         T000N9_A488DocumentacionId = new long[1] ;
         T000N9_n488DocumentacionId = new bool[] {false} ;
         T000N9_A673BancoId = new long[1] ;
         T000N9_n673BancoId = new bool[] {false} ;
         T000N9_A432ProveedorImagen = new string[] {""} ;
         T000N9_n432ProveedorImagen = new bool[] {false} ;
         T000N18_A133ProveedorID = new long[1] ;
         T000N18_n133ProveedorID = new bool[] {false} ;
         T000N19_A133ProveedorID = new long[1] ;
         T000N19_n133ProveedorID = new bool[] {false} ;
         T000N8_A133ProveedorID = new long[1] ;
         T000N8_n133ProveedorID = new bool[] {false} ;
         T000N8_A546ProveedorUsrAlta = new long[1] ;
         T000N8_n546ProveedorUsrAlta = new bool[] {false} ;
         T000N8_A547ProveedorUsrActualizacion = new long[1] ;
         T000N8_n547ProveedorUsrActualizacion = new bool[] {false} ;
         T000N8_A548ProveedorFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T000N8_n548ProveedorFechaAlta = new bool[] {false} ;
         T000N8_A549ProveedorFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         T000N8_n549ProveedorFechaActualizacion = new bool[] {false} ;
         T000N8_A282ProveedorNombre = new string[] {""} ;
         T000N8_A682ProveedorRazonSocial = new string[] {""} ;
         T000N8_n682ProveedorRazonSocial = new bool[] {false} ;
         T000N8_A683ProveedorContacto = new string[] {""} ;
         T000N8_n683ProveedorContacto = new bool[] {false} ;
         T000N8_A684ProveedorContactoCell = new string[] {""} ;
         T000N8_n684ProveedorContactoCell = new bool[] {false} ;
         T000N8_A40000ProveedorImagen_GXI = new string[] {""} ;
         T000N8_n40000ProveedorImagen_GXI = new bool[] {false} ;
         T000N8_A338ProveedorDocIdentidad = new string[] {""} ;
         T000N8_A345ProveedorSerialComi = new short[1] ;
         T000N8_A430ProveedorTelefono = new string[] {""} ;
         T000N8_n430ProveedorTelefono = new bool[] {false} ;
         T000N8_A431ProveedorDireccion = new string[] {""} ;
         T000N8_n431ProveedorDireccion = new bool[] {false} ;
         T000N8_A433ProveedorEmail = new string[] {""} ;
         T000N8_n433ProveedorEmail = new bool[] {false} ;
         T000N8_A685ProveedorSitioWeb = new string[] {""} ;
         T000N8_n685ProveedorSitioWeb = new bool[] {false} ;
         T000N8_A686ProveedorAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         T000N8_n686ProveedorAceptoTerminos = new bool[] {false} ;
         T000N8_A437ProveedorPerAltShop = new string[] {""} ;
         T000N8_n437ProveedorPerAltShop = new bool[] {false} ;
         T000N8_A344ProveedorEstado = new string[] {""} ;
         T000N8_A440ProveedorPagoDefault = new string[] {""} ;
         T000N8_A490ProveedorPideDoc = new string[] {""} ;
         T000N8_n490ProveedorPideDoc = new bool[] {false} ;
         T000N8_A601ProveedorUsoInterno = new string[] {""} ;
         T000N8_n601ProveedorUsoInterno = new bool[] {false} ;
         T000N8_A687ProveedorCuentaBancaria = new string[] {""} ;
         T000N8_n687ProveedorCuentaBancaria = new bool[] {false} ;
         T000N8_A978ProveedorCIU = new bool[] {false} ;
         T000N8_A999ProveedorFreezePrice = new bool[] {false} ;
         T000N8_n999ProveedorFreezePrice = new bool[] {false} ;
         T000N8_A151ProveedoresTipoId = new long[1] ;
         T000N8_A488DocumentacionId = new long[1] ;
         T000N8_n488DocumentacionId = new bool[] {false} ;
         T000N8_A673BancoId = new long[1] ;
         T000N8_n673BancoId = new bool[] {false} ;
         T000N8_A432ProveedorImagen = new string[] {""} ;
         T000N8_n432ProveedorImagen = new bool[] {false} ;
         T000N20_A133ProveedorID = new long[1] ;
         T000N20_n133ProveedorID = new bool[] {false} ;
         T000N24_A278ProveedoresTipoNombre = new string[] {""} ;
         T000N25_A40001DocumentacionIcono_GXI = new string[] {""} ;
         T000N25_A498DocumentacionIcono = new string[] {""} ;
         T000N26_A674BancoNombre = new string[] {""} ;
         T000N27_A422PostulacionesId = new long[1] ;
         T000N28_A918MapeoID = new long[1] ;
         T000N29_A918MapeoID = new long[1] ;
         T000N30_A491VincularTrnId = new long[1] ;
         T000N31_A450ProfComisionesID = new long[1] ;
         T000N31_A452ProfComisionesRubrosId = new long[1] ;
         T000N32_A127SolicitudesID = new long[1] ;
         T000N33_A127SolicitudesID = new long[1] ;
         T000N34_A133ProveedorID = new long[1] ;
         T000N34_n133ProveedorID = new bool[] {false} ;
         T000N34_A713ComercioProductosRubrosID = new long[1] ;
         T000N35_A590Listaid = new long[1] ;
         T000N35_A133ProveedorID = new long[1] ;
         T000N35_n133ProveedorID = new bool[] {false} ;
         T000N35_A120ProfesionalesId = new string[] {""} ;
         T000N36_A590Listaid = new long[1] ;
         T000N36_A18SecUserId = new long[1] ;
         T000N36_A133ProveedorID = new long[1] ;
         T000N36_n133ProveedorID = new bool[] {false} ;
         T000N37_A503ComisionesID = new long[1] ;
         T000N37_A133ProveedorID = new long[1] ;
         T000N37_n133ProveedorID = new bool[] {false} ;
         T000N38_A133ProveedorID = new long[1] ;
         T000N38_n133ProveedorID = new bool[] {false} ;
         T000N38_A152ProveedorSolicitudesId = new long[1] ;
         T000N40_A133ProveedorID = new long[1] ;
         T000N40_n133ProveedorID = new bool[] {false} ;
         Z168RubrosImagen = "";
         Z40002RubrosImagen_GXI = "";
         Z136InventarioNombre = "";
         Z107EstadosTipo = "";
         Z109EstadosGenericosNombre = "";
         T000N4_A40002RubrosImagen_GXI = new string[] {""} ;
         T000N4_A168RubrosImagen = new string[] {""} ;
         T000N5_A118MonedaId = new short[1] ;
         T000N6_A136InventarioNombre = new string[] {""} ;
         T000N6_A181InventarioPrecioFinal = new decimal[1] ;
         T000N6_A107EstadosTipo = new string[] {""} ;
         T000N6_A108EstadosGenericosId = new int[1] ;
         T000N7_A109EstadosGenericosNombre = new string[] {""} ;
         T000N41_A133ProveedorID = new long[1] ;
         T000N41_n133ProveedorID = new bool[] {false} ;
         T000N41_A157ProveedorComisionID = new long[1] ;
         T000N41_A348ProveedorComisionAccion = new string[] {""} ;
         T000N41_A40002RubrosImagen_GXI = new string[] {""} ;
         T000N41_A136InventarioNombre = new string[] {""} ;
         T000N41_A109EstadosGenericosNombre = new string[] {""} ;
         T000N41_A181InventarioPrecioFinal = new decimal[1] ;
         T000N41_A1001ProveedorComisionFP = new bool[] {false} ;
         T000N41_n1001ProveedorComisionFP = new bool[] {false} ;
         T000N41_A1000ProveedorComisionFPF = new decimal[1] ;
         T000N41_n1000ProveedorComisionFPF = new bool[] {false} ;
         T000N41_A346ProveedorComisionTipo = new string[] {""} ;
         T000N41_A347ProveedorComision = new decimal[1] ;
         T000N41_A121RubrosId = new short[1] ;
         T000N41_A137MedidasID = new long[1] ;
         T000N41_A135InventarioId = new long[1] ;
         T000N41_n135InventarioId = new bool[] {false} ;
         T000N41_A118MonedaId = new short[1] ;
         T000N41_A107EstadosTipo = new string[] {""} ;
         T000N41_A108EstadosGenericosId = new int[1] ;
         T000N41_A168RubrosImagen = new string[] {""} ;
         GXCCtl = "";
         T000N42_A40002RubrosImagen_GXI = new string[] {""} ;
         T000N42_A168RubrosImagen = new string[] {""} ;
         T000N43_A118MonedaId = new short[1] ;
         T000N44_A136InventarioNombre = new string[] {""} ;
         T000N44_A181InventarioPrecioFinal = new decimal[1] ;
         T000N44_A107EstadosTipo = new string[] {""} ;
         T000N44_A108EstadosGenericosId = new int[1] ;
         T000N45_A109EstadosGenericosNombre = new string[] {""} ;
         T000N46_A133ProveedorID = new long[1] ;
         T000N46_n133ProveedorID = new bool[] {false} ;
         T000N46_A157ProveedorComisionID = new long[1] ;
         T000N3_A133ProveedorID = new long[1] ;
         T000N3_n133ProveedorID = new bool[] {false} ;
         T000N3_A157ProveedorComisionID = new long[1] ;
         T000N3_A348ProveedorComisionAccion = new string[] {""} ;
         T000N3_A1001ProveedorComisionFP = new bool[] {false} ;
         T000N3_n1001ProveedorComisionFP = new bool[] {false} ;
         T000N3_A1000ProveedorComisionFPF = new decimal[1] ;
         T000N3_n1000ProveedorComisionFPF = new bool[] {false} ;
         T000N3_A346ProveedorComisionTipo = new string[] {""} ;
         T000N3_A347ProveedorComision = new decimal[1] ;
         T000N3_A121RubrosId = new short[1] ;
         T000N3_A137MedidasID = new long[1] ;
         T000N3_A135InventarioId = new long[1] ;
         T000N3_n135InventarioId = new bool[] {false} ;
         T000N2_A133ProveedorID = new long[1] ;
         T000N2_n133ProveedorID = new bool[] {false} ;
         T000N2_A157ProveedorComisionID = new long[1] ;
         T000N2_A348ProveedorComisionAccion = new string[] {""} ;
         T000N2_A1001ProveedorComisionFP = new bool[] {false} ;
         T000N2_n1001ProveedorComisionFP = new bool[] {false} ;
         T000N2_A1000ProveedorComisionFPF = new decimal[1] ;
         T000N2_n1000ProveedorComisionFPF = new bool[] {false} ;
         T000N2_A346ProveedorComisionTipo = new string[] {""} ;
         T000N2_A347ProveedorComision = new decimal[1] ;
         T000N2_A121RubrosId = new short[1] ;
         T000N2_A137MedidasID = new long[1] ;
         T000N2_A135InventarioId = new long[1] ;
         T000N2_n135InventarioId = new bool[] {false} ;
         T000N50_A40002RubrosImagen_GXI = new string[] {""} ;
         T000N50_A168RubrosImagen = new string[] {""} ;
         T000N51_A118MonedaId = new short[1] ;
         T000N52_A136InventarioNombre = new string[] {""} ;
         T000N52_A181InventarioPrecioFinal = new decimal[1] ;
         T000N52_A107EstadosTipo = new string[] {""} ;
         T000N52_A108EstadosGenericosId = new int[1] ;
         T000N53_A109EstadosGenericosNombre = new string[] {""} ;
         T000N54_A133ProveedorID = new long[1] ;
         T000N54_n133ProveedorID = new bool[] {false} ;
         T000N54_A157ProveedorComisionID = new long[1] ;
         Gridlevel_comisionRow = new GXWebRow();
         subGridlevel_comision_Linesclass = "";
         ROClassString = "";
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i344ProveedorEstado = "";
         i437ProveedorPerAltShop = "";
         i490ProveedorPideDoc = "";
         i440ProveedorPagoDefault = "";
         i348ProveedorComisionAccion = "";
         Gridlevel_comisionColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000N55_A18SecUserId = new long[1] ;
         T000N55_A587SecUserFullName = new string[] {""} ;
         T000N56_A18SecUserId = new long[1] ;
         T000N56_A587SecUserFullName = new string[] {""} ;
         T000N57_A151ProveedoresTipoId = new long[1] ;
         T000N57_A278ProveedoresTipoNombre = new string[] {""} ;
         T000N58_A673BancoId = new long[1] ;
         T000N58_n673BancoId = new bool[] {false} ;
         T000N58_A674BancoNombre = new string[] {""} ;
         T000N58_A675BancoEstado = new string[] {""} ;
         T000N59_A121RubrosId = new short[1] ;
         T000N59_A122RubrosNombre = new string[] {""} ;
         T000N59_A123RubrosEstado = new string[] {""} ;
         T000N59_n123RubrosEstado = new bool[] {false} ;
         T000N60_A121RubrosId = new short[1] ;
         T000N60_A137MedidasID = new long[1] ;
         T000N60_A138MedidasNombre = new string[] {""} ;
         T000N60_A139MedidasEstado = new string[] {""} ;
         T000N60_n139MedidasEstado = new bool[] {false} ;
         T000N61_A121RubrosId = new short[1] ;
         T000N61_A137MedidasID = new long[1] ;
         T000N61_A135InventarioId = new long[1] ;
         T000N61_n135InventarioId = new bool[] {false} ;
         T000N61_A136InventarioNombre = new string[] {""} ;
         T000N61_A107EstadosTipo = new string[] {""} ;
         T000N61_A108EstadosGenericosId = new int[1] ;
         T000N62_A151ProveedoresTipoId = new long[1] ;
         T000N62_A278ProveedoresTipoNombre = new string[] {""} ;
         T000N63_A18SecUserId = new long[1] ;
         T000N63_A587SecUserFullName = new string[] {""} ;
         T000N64_A18SecUserId = new long[1] ;
         T000N64_A587SecUserFullName = new string[] {""} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.proveedor__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedor__default(),
            new Object[][] {
                new Object[] {
               T000N2_A133ProveedorID, T000N2_A157ProveedorComisionID, T000N2_A348ProveedorComisionAccion, T000N2_A1001ProveedorComisionFP, T000N2_n1001ProveedorComisionFP, T000N2_A1000ProveedorComisionFPF, T000N2_n1000ProveedorComisionFPF, T000N2_A346ProveedorComisionTipo, T000N2_A347ProveedorComision, T000N2_A121RubrosId,
               T000N2_A137MedidasID, T000N2_A135InventarioId, T000N2_n135InventarioId
               }
               , new Object[] {
               T000N3_A133ProveedorID, T000N3_A157ProveedorComisionID, T000N3_A348ProveedorComisionAccion, T000N3_A1001ProveedorComisionFP, T000N3_n1001ProveedorComisionFP, T000N3_A1000ProveedorComisionFPF, T000N3_n1000ProveedorComisionFPF, T000N3_A346ProveedorComisionTipo, T000N3_A347ProveedorComision, T000N3_A121RubrosId,
               T000N3_A137MedidasID, T000N3_A135InventarioId, T000N3_n135InventarioId
               }
               , new Object[] {
               T000N4_A40002RubrosImagen_GXI, T000N4_A168RubrosImagen
               }
               , new Object[] {
               T000N5_A118MonedaId
               }
               , new Object[] {
               T000N6_A136InventarioNombre, T000N6_A181InventarioPrecioFinal, T000N6_A107EstadosTipo, T000N6_A108EstadosGenericosId
               }
               , new Object[] {
               T000N7_A109EstadosGenericosNombre
               }
               , new Object[] {
               T000N8_A133ProveedorID, T000N8_A546ProveedorUsrAlta, T000N8_n546ProveedorUsrAlta, T000N8_A547ProveedorUsrActualizacion, T000N8_n547ProveedorUsrActualizacion, T000N8_A548ProveedorFechaAlta, T000N8_n548ProveedorFechaAlta, T000N8_A549ProveedorFechaActualizacion, T000N8_n549ProveedorFechaActualizacion, T000N8_A282ProveedorNombre,
               T000N8_A682ProveedorRazonSocial, T000N8_n682ProveedorRazonSocial, T000N8_A683ProveedorContacto, T000N8_n683ProveedorContacto, T000N8_A684ProveedorContactoCell, T000N8_n684ProveedorContactoCell, T000N8_A40000ProveedorImagen_GXI, T000N8_n40000ProveedorImagen_GXI, T000N8_A338ProveedorDocIdentidad, T000N8_A345ProveedorSerialComi,
               T000N8_A430ProveedorTelefono, T000N8_n430ProveedorTelefono, T000N8_A431ProveedorDireccion, T000N8_n431ProveedorDireccion, T000N8_A433ProveedorEmail, T000N8_n433ProveedorEmail, T000N8_A685ProveedorSitioWeb, T000N8_n685ProveedorSitioWeb, T000N8_A686ProveedorAceptoTerminos, T000N8_n686ProveedorAceptoTerminos,
               T000N8_A437ProveedorPerAltShop, T000N8_n437ProveedorPerAltShop, T000N8_A344ProveedorEstado, T000N8_A440ProveedorPagoDefault, T000N8_A490ProveedorPideDoc, T000N8_n490ProveedorPideDoc, T000N8_A601ProveedorUsoInterno, T000N8_n601ProveedorUsoInterno, T000N8_A687ProveedorCuentaBancaria, T000N8_n687ProveedorCuentaBancaria,
               T000N8_A978ProveedorCIU, T000N8_A999ProveedorFreezePrice, T000N8_n999ProveedorFreezePrice, T000N8_A151ProveedoresTipoId, T000N8_A488DocumentacionId, T000N8_n488DocumentacionId, T000N8_A673BancoId, T000N8_n673BancoId, T000N8_A432ProveedorImagen, T000N8_n432ProveedorImagen
               }
               , new Object[] {
               T000N9_A133ProveedorID, T000N9_A546ProveedorUsrAlta, T000N9_n546ProveedorUsrAlta, T000N9_A547ProveedorUsrActualizacion, T000N9_n547ProveedorUsrActualizacion, T000N9_A548ProveedorFechaAlta, T000N9_n548ProveedorFechaAlta, T000N9_A549ProveedorFechaActualizacion, T000N9_n549ProveedorFechaActualizacion, T000N9_A282ProveedorNombre,
               T000N9_A682ProveedorRazonSocial, T000N9_n682ProveedorRazonSocial, T000N9_A683ProveedorContacto, T000N9_n683ProveedorContacto, T000N9_A684ProveedorContactoCell, T000N9_n684ProveedorContactoCell, T000N9_A40000ProveedorImagen_GXI, T000N9_n40000ProveedorImagen_GXI, T000N9_A338ProveedorDocIdentidad, T000N9_A345ProveedorSerialComi,
               T000N9_A430ProveedorTelefono, T000N9_n430ProveedorTelefono, T000N9_A431ProveedorDireccion, T000N9_n431ProveedorDireccion, T000N9_A433ProveedorEmail, T000N9_n433ProveedorEmail, T000N9_A685ProveedorSitioWeb, T000N9_n685ProveedorSitioWeb, T000N9_A686ProveedorAceptoTerminos, T000N9_n686ProveedorAceptoTerminos,
               T000N9_A437ProveedorPerAltShop, T000N9_n437ProveedorPerAltShop, T000N9_A344ProveedorEstado, T000N9_A440ProveedorPagoDefault, T000N9_A490ProveedorPideDoc, T000N9_n490ProveedorPideDoc, T000N9_A601ProveedorUsoInterno, T000N9_n601ProveedorUsoInterno, T000N9_A687ProveedorCuentaBancaria, T000N9_n687ProveedorCuentaBancaria,
               T000N9_A978ProveedorCIU, T000N9_A999ProveedorFreezePrice, T000N9_n999ProveedorFreezePrice, T000N9_A151ProveedoresTipoId, T000N9_A488DocumentacionId, T000N9_n488DocumentacionId, T000N9_A673BancoId, T000N9_n673BancoId, T000N9_A432ProveedorImagen, T000N9_n432ProveedorImagen
               }
               , new Object[] {
               T000N10_A278ProveedoresTipoNombre
               }
               , new Object[] {
               T000N11_A40001DocumentacionIcono_GXI, T000N11_A498DocumentacionIcono
               }
               , new Object[] {
               T000N12_A674BancoNombre
               }
               , new Object[] {
               T000N13_A133ProveedorID, T000N13_A546ProveedorUsrAlta, T000N13_n546ProveedorUsrAlta, T000N13_A547ProveedorUsrActualizacion, T000N13_n547ProveedorUsrActualizacion, T000N13_A548ProveedorFechaAlta, T000N13_n548ProveedorFechaAlta, T000N13_A549ProveedorFechaActualizacion, T000N13_n549ProveedorFechaActualizacion, T000N13_A278ProveedoresTipoNombre,
               T000N13_A282ProveedorNombre, T000N13_A682ProveedorRazonSocial, T000N13_n682ProveedorRazonSocial, T000N13_A683ProveedorContacto, T000N13_n683ProveedorContacto, T000N13_A684ProveedorContactoCell, T000N13_n684ProveedorContactoCell, T000N13_A40000ProveedorImagen_GXI, T000N13_n40000ProveedorImagen_GXI, T000N13_A338ProveedorDocIdentidad,
               T000N13_A345ProveedorSerialComi, T000N13_A430ProveedorTelefono, T000N13_n430ProveedorTelefono, T000N13_A431ProveedorDireccion, T000N13_n431ProveedorDireccion, T000N13_A433ProveedorEmail, T000N13_n433ProveedorEmail, T000N13_A685ProveedorSitioWeb, T000N13_n685ProveedorSitioWeb, T000N13_A686ProveedorAceptoTerminos,
               T000N13_n686ProveedorAceptoTerminos, T000N13_A437ProveedorPerAltShop, T000N13_n437ProveedorPerAltShop, T000N13_A344ProveedorEstado, T000N13_A440ProveedorPagoDefault, T000N13_A490ProveedorPideDoc, T000N13_n490ProveedorPideDoc, T000N13_A40001DocumentacionIcono_GXI, T000N13_A601ProveedorUsoInterno, T000N13_n601ProveedorUsoInterno,
               T000N13_A687ProveedorCuentaBancaria, T000N13_n687ProveedorCuentaBancaria, T000N13_A674BancoNombre, T000N13_A978ProveedorCIU, T000N13_A999ProveedorFreezePrice, T000N13_n999ProveedorFreezePrice, T000N13_A151ProveedoresTipoId, T000N13_A488DocumentacionId, T000N13_n488DocumentacionId, T000N13_A673BancoId,
               T000N13_n673BancoId, T000N13_A432ProveedorImagen, T000N13_n432ProveedorImagen, T000N13_A498DocumentacionIcono
               }
               , new Object[] {
               T000N14_A278ProveedoresTipoNombre
               }
               , new Object[] {
               T000N15_A40001DocumentacionIcono_GXI, T000N15_A498DocumentacionIcono
               }
               , new Object[] {
               T000N16_A674BancoNombre
               }
               , new Object[] {
               T000N17_A133ProveedorID
               }
               , new Object[] {
               T000N18_A133ProveedorID
               }
               , new Object[] {
               T000N19_A133ProveedorID
               }
               , new Object[] {
               T000N20_A133ProveedorID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000N24_A278ProveedoresTipoNombre
               }
               , new Object[] {
               T000N25_A40001DocumentacionIcono_GXI, T000N25_A498DocumentacionIcono
               }
               , new Object[] {
               T000N26_A674BancoNombre
               }
               , new Object[] {
               T000N27_A422PostulacionesId
               }
               , new Object[] {
               T000N28_A918MapeoID
               }
               , new Object[] {
               T000N29_A918MapeoID
               }
               , new Object[] {
               T000N30_A491VincularTrnId
               }
               , new Object[] {
               T000N31_A450ProfComisionesID, T000N31_A452ProfComisionesRubrosId
               }
               , new Object[] {
               T000N32_A127SolicitudesID
               }
               , new Object[] {
               T000N33_A127SolicitudesID
               }
               , new Object[] {
               T000N34_A133ProveedorID, T000N34_A713ComercioProductosRubrosID
               }
               , new Object[] {
               T000N35_A590Listaid, T000N35_A133ProveedorID, T000N35_A120ProfesionalesId
               }
               , new Object[] {
               T000N36_A590Listaid, T000N36_A18SecUserId, T000N36_A133ProveedorID
               }
               , new Object[] {
               T000N37_A503ComisionesID, T000N37_A133ProveedorID
               }
               , new Object[] {
               T000N38_A133ProveedorID, T000N38_A152ProveedorSolicitudesId
               }
               , new Object[] {
               }
               , new Object[] {
               T000N40_A133ProveedorID
               }
               , new Object[] {
               T000N41_A133ProveedorID, T000N41_A157ProveedorComisionID, T000N41_A348ProveedorComisionAccion, T000N41_A40002RubrosImagen_GXI, T000N41_A136InventarioNombre, T000N41_A109EstadosGenericosNombre, T000N41_A181InventarioPrecioFinal, T000N41_A1001ProveedorComisionFP, T000N41_n1001ProveedorComisionFP, T000N41_A1000ProveedorComisionFPF,
               T000N41_n1000ProveedorComisionFPF, T000N41_A346ProveedorComisionTipo, T000N41_A347ProveedorComision, T000N41_A121RubrosId, T000N41_A137MedidasID, T000N41_A135InventarioId, T000N41_n135InventarioId, T000N41_A118MonedaId, T000N41_A107EstadosTipo, T000N41_A108EstadosGenericosId,
               T000N41_A168RubrosImagen
               }
               , new Object[] {
               T000N42_A40002RubrosImagen_GXI, T000N42_A168RubrosImagen
               }
               , new Object[] {
               T000N43_A118MonedaId
               }
               , new Object[] {
               T000N44_A136InventarioNombre, T000N44_A181InventarioPrecioFinal, T000N44_A107EstadosTipo, T000N44_A108EstadosGenericosId
               }
               , new Object[] {
               T000N45_A109EstadosGenericosNombre
               }
               , new Object[] {
               T000N46_A133ProveedorID, T000N46_A157ProveedorComisionID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000N50_A40002RubrosImagen_GXI, T000N50_A168RubrosImagen
               }
               , new Object[] {
               T000N51_A118MonedaId
               }
               , new Object[] {
               T000N52_A136InventarioNombre, T000N52_A181InventarioPrecioFinal, T000N52_A107EstadosTipo, T000N52_A108EstadosGenericosId
               }
               , new Object[] {
               T000N53_A109EstadosGenericosNombre
               }
               , new Object[] {
               T000N54_A133ProveedorID, T000N54_A157ProveedorComisionID
               }
               , new Object[] {
               T000N55_A18SecUserId, T000N55_A587SecUserFullName
               }
               , new Object[] {
               T000N56_A18SecUserId, T000N56_A587SecUserFullName
               }
               , new Object[] {
               T000N57_A151ProveedoresTipoId, T000N57_A278ProveedoresTipoNombre
               }
               , new Object[] {
               T000N58_A673BancoId, T000N58_A674BancoNombre, T000N58_A675BancoEstado
               }
               , new Object[] {
               T000N59_A121RubrosId, T000N59_A122RubrosNombre, T000N59_A123RubrosEstado, T000N59_n123RubrosEstado
               }
               , new Object[] {
               T000N60_A121RubrosId, T000N60_A137MedidasID, T000N60_A138MedidasNombre, T000N60_A139MedidasEstado, T000N60_n139MedidasEstado
               }
               , new Object[] {
               T000N61_A121RubrosId, T000N61_A137MedidasID, T000N61_A135InventarioId, T000N61_A136InventarioNombre, T000N61_A107EstadosTipo, T000N61_A108EstadosGenericosId
               }
               , new Object[] {
               T000N62_A151ProveedoresTipoId, T000N62_A278ProveedoresTipoNombre
               }
               , new Object[] {
               T000N63_A18SecUserId, T000N63_A587SecUserFullName
               }
               , new Object[] {
               T000N64_A18SecUserId, T000N64_A587SecUserFullName
               }
            }
         );
         Z978ProveedorCIU = false;
         A978ProveedorCIU = false;
         i978ProveedorCIU = false;
         AV40Pgmname = "Proveedor";
         Z999ProveedorFreezePrice = false;
         n999ProveedorFreezePrice = false;
         A999ProveedorFreezePrice = false;
         n999ProveedorFreezePrice = false;
         i999ProveedorFreezePrice = false;
         n999ProveedorFreezePrice = false;
         Z440ProveedorPagoDefault = "T";
         A440ProveedorPagoDefault = "T";
         i440ProveedorPagoDefault = "T";
         Z490ProveedorPideDoc = context.GetMessage( "N", "");
         n490ProveedorPideDoc = false;
         A490ProveedorPideDoc = context.GetMessage( "N", "");
         n490ProveedorPideDoc = false;
         i490ProveedorPideDoc = context.GetMessage( "N", "");
         n490ProveedorPideDoc = false;
         Z348ProveedorComisionAccion = "";
         A348ProveedorComisionAccion = "";
         i348ProveedorComisionAccion = "";
         Z437ProveedorPerAltShop = context.GetMessage( "N", "");
         n437ProveedorPerAltShop = false;
         A437ProveedorPerAltShop = context.GetMessage( "N", "");
         n437ProveedorPerAltShop = false;
         i437ProveedorPerAltShop = context.GetMessage( "N", "");
         n437ProveedorPerAltShop = false;
         Z344ProveedorEstado = "PEN";
         A344ProveedorEstado = "PEN";
         i344ProveedorEstado = "PEN";
      }

      private short Z345ProveedorSerialComi ;
      private short O345ProveedorSerialComi ;
      private short Z121RubrosId ;
      private short nRcdDeleted_29 ;
      private short nRcdExists_29 ;
      private short nIsMod_29 ;
      private short GxWebError ;
      private short A121RubrosId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short A345ProveedorSerialComi ;
      private short nBlankRcdCount29 ;
      private short RcdFound29 ;
      private short B345ProveedorSerialComi ;
      private short nBlankRcdUsr29 ;
      private short RcdFound28 ;
      private short s345ProveedorSerialComi ;
      private short A118MonedaId ;
      private short Z118MonedaId ;
      private short nIsDirty_29 ;
      private short subGridlevel_comision_Backcolorstyle ;
      private short subGridlevel_comision_Backstyle ;
      private short gxajaxcallmode ;
      private short i345ProveedorSerialComi ;
      private short subGridlevel_comision_Allowselection ;
      private short subGridlevel_comision_Allowhovering ;
      private short subGridlevel_comision_Allowcollapsing ;
      private short subGridlevel_comision_Collapsed ;
      private int nRC_GXsfl_176 ;
      private int nGXsfl_176_idx=1 ;
      private int A108EstadosGenericosId ;
      private int trnEnded ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtProveedorID_Enabled ;
      private int edtProveedorNombre_Enabled ;
      private int edtProveedorRazonSocial_Enabled ;
      private int edtProveedorTelefono_Enabled ;
      private int edtProveedorEmail_Enabled ;
      private int edtProveedorDireccion_Enabled ;
      private int imgProveedorImagen_Enabled ;
      private int edtProveedorDocIdentidad_Enabled ;
      private int edtProveedorSitioWeb_Enabled ;
      private int edtProveedorAceptoTerminos_Enabled ;
      private int edtProveedorContacto_Enabled ;
      private int edtProveedorContactoCell_Enabled ;
      private int edtProveedorCuentaBancaria_Enabled ;
      private int edtProveedorFechaAlta_Enabled ;
      private int edtProveedorFechaActualizacion_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtProveedorSerialComi_Enabled ;
      private int edtProveedorSerialComi_Visible ;
      private int edtProveedorPerAltShop_Visible ;
      private int edtProveedorPerAltShop_Enabled ;
      private int edtProveedorPideDoc_Visible ;
      private int edtProveedorPideDoc_Enabled ;
      private int edtDocumentacionId_Visible ;
      private int edtDocumentacionId_Enabled ;
      private int imgprompt_488_Visible ;
      private int imgDocumentacionIcono_Visible ;
      private int imgDocumentacionIcono_Enabled ;
      private int edtProveedorComisionID_Enabled ;
      private int edtRubrosImagen_Enabled ;
      private int edtMonedaId_Enabled ;
      private int edtEstadosTipo_Enabled ;
      private int edtEstadosGenericosId_Enabled ;
      private int edtEstadosGenericosNombre_Enabled ;
      private int edtInventarioPrecioFinal_Enabled ;
      private int edtProveedorComisionFPF_Enabled ;
      private int edtProveedorComision_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_unnamedtable3_Gxcontroltype ;
      private int Gxuitabspanel_tabs_Activepage ;
      private int AV41GXV1 ;
      private int AV42GXV2 ;
      private int Z108EstadosGenericosId ;
      private int subGridlevel_comision_Backcolor ;
      private int subGridlevel_comision_Allbackcolor ;
      private int defedtEstadosGenericosId_Enabled ;
      private int defedtEstadosTipo_Enabled ;
      private int defedtMonedaId_Enabled ;
      private int defedtProveedorComisionID_Enabled ;
      private int idxLst ;
      private int subGridlevel_comision_Selectedindex ;
      private int subGridlevel_comision_Selectioncolor ;
      private int subGridlevel_comision_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long wcpOAV7ProveedorID ;
      private long Z133ProveedorID ;
      private long Z546ProveedorUsrAlta ;
      private long Z547ProveedorUsrActualizacion ;
      private long Z151ProveedoresTipoId ;
      private long Z488DocumentacionId ;
      private long Z673BancoId ;
      private long N151ProveedoresTipoId ;
      private long N488DocumentacionId ;
      private long N673BancoId ;
      private long Z157ProveedorComisionID ;
      private long Z137MedidasID ;
      private long Z135InventarioId ;
      private long A137MedidasID ;
      private long A151ProveedoresTipoId ;
      private long A488DocumentacionId ;
      private long A673BancoId ;
      private long A135InventarioId ;
      private long AV7ProveedorID ;
      private long A546ProveedorUsrAlta ;
      private long A547ProveedorUsrActualizacion ;
      private long A133ProveedorID ;
      private long AV13Insert_ProveedoresTipoId ;
      private long AV14Insert_DocumentacionId ;
      private long AV36Insert_BancoId ;
      private long GRIDLEVEL_COMISION_nFirstRecordOnPage ;
      private long A157ProveedorComisionID ;
      private decimal Z1000ProveedorComisionFPF ;
      private decimal Z347ProveedorComision ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A1000ProveedorComisionFPF ;
      private decimal A347ProveedorComision ;
      private decimal Z181InventarioPrecioFinal ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z282ProveedorNombre ;
      private string Z682ProveedorRazonSocial ;
      private string Z683ProveedorContacto ;
      private string Z684ProveedorContactoCell ;
      private string Z338ProveedorDocIdentidad ;
      private string Z430ProveedorTelefono ;
      private string Z685ProveedorSitioWeb ;
      private string Z437ProveedorPerAltShop ;
      private string Z344ProveedorEstado ;
      private string Z440ProveedorPagoDefault ;
      private string Z490ProveedorPideDoc ;
      private string Z601ProveedorUsoInterno ;
      private string Z687ProveedorCuentaBancaria ;
      private string Z348ProveedorComisionAccion ;
      private string Z346ProveedorComisionTipo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A107EstadosTipo ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbProveedorEstado_Internalname ;
      private string sGXsfl_176_idx="0001" ;
      private string A344ProveedorEstado ;
      private string dynProveedoresTipoId_Internalname ;
      private string A601ProveedorUsoInterno ;
      private string A440ProveedorPagoDefault ;
      private string cmbProveedorPagoDefault_Internalname ;
      private string dynBancoId_Internalname ;
      private string dynProveedorUsrAlta_Internalname ;
      private string dynProveedorUsrActualizacion_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Gxuitabspanel_tabs_Class ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblTabgeneral_title_Internalname ;
      private string lblTabgeneral_title_Jsonclick ;
      private string divTableattributes_Internalname ;
      private string edtProveedorID_Internalname ;
      private string TempTags ;
      private string edtProveedorID_Jsonclick ;
      private string cmbProveedorEstado_Jsonclick ;
      private string divTablesplittedproveedorfreezeprice_Internalname ;
      private string lblTextblockproveedorfreezeprice_Internalname ;
      private string lblTextblockproveedorfreezeprice_Jsonclick ;
      private string sStyleString ;
      private string tblTablemergedproveedorfreezeprice_Internalname ;
      private string chkProveedorFreezePrice_Internalname ;
      private string lblProveedorfreezeprice_righttext_Internalname ;
      private string lblProveedorfreezeprice_righttext_Jsonclick ;
      private string divTb1_Internalname ;
      private string dynProveedoresTipoId_Jsonclick ;
      private string edtProveedorNombre_Internalname ;
      private string A282ProveedorNombre ;
      private string edtProveedorNombre_Jsonclick ;
      private string edtProveedorRazonSocial_Internalname ;
      private string A682ProveedorRazonSocial ;
      private string edtProveedorRazonSocial_Jsonclick ;
      private string edtProveedorTelefono_Internalname ;
      private string gxphoneLink ;
      private string A430ProveedorTelefono ;
      private string edtProveedorTelefono_Jsonclick ;
      private string edtProveedorEmail_Internalname ;
      private string edtProveedorEmail_Jsonclick ;
      private string edtProveedorDireccion_Internalname ;
      private string divTablesplittedproveedorusointerno_Internalname ;
      private string lblTextblockproveedorusointerno_Internalname ;
      private string lblTextblockproveedorusointerno_Jsonclick ;
      private string tblTablemergedproveedorusointerno_Internalname ;
      private string chkProveedorUsoInterno_Internalname ;
      private string lblProveedorusointerno_righttext_Internalname ;
      private string lblProveedorusointerno_righttext_Jsonclick ;
      private string chkProveedorCIU_Internalname ;
      private string divTb2_Internalname ;
      private string imgProveedorImagen_Internalname ;
      private string sImgUrl ;
      private string cmbProveedorPagoDefault_Jsonclick ;
      private string edtProveedorDocIdentidad_Internalname ;
      private string A338ProveedorDocIdentidad ;
      private string edtProveedorDocIdentidad_Jsonclick ;
      private string edtProveedorSitioWeb_Internalname ;
      private string A685ProveedorSitioWeb ;
      private string edtProveedorSitioWeb_Jsonclick ;
      private string edtProveedorAceptoTerminos_Internalname ;
      private string edtProveedorAceptoTerminos_Jsonclick ;
      private string Dvpanel_unnamedtable3_Width ;
      private string Dvpanel_unnamedtable3_Cls ;
      private string Dvpanel_unnamedtable3_Title ;
      private string Dvpanel_unnamedtable3_Iconposition ;
      private string Dvpanel_unnamedtable3_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string edtProveedorContacto_Internalname ;
      private string A683ProveedorContacto ;
      private string edtProveedorContacto_Jsonclick ;
      private string edtProveedorContactoCell_Internalname ;
      private string A684ProveedorContactoCell ;
      private string edtProveedorContactoCell_Jsonclick ;
      private string dynBancoId_Jsonclick ;
      private string edtProveedorCuentaBancaria_Internalname ;
      private string A687ProveedorCuentaBancaria ;
      private string edtProveedorCuentaBancaria_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string tblUnnamedtable1_Internalname ;
      private string dynProveedorUsrAlta_Jsonclick ;
      private string dynProveedorUsrActualizacion_Jsonclick ;
      private string edtProveedorFechaAlta_Internalname ;
      private string edtProveedorFechaAlta_Jsonclick ;
      private string edtProveedorFechaActualizacion_Internalname ;
      private string edtProveedorFechaActualizacion_Jsonclick ;
      private string lblTablevel_comision_title_Internalname ;
      private string lblTablevel_comision_title_Jsonclick ;
      private string divTabtablelevel_comision_Internalname ;
      private string divTableleaflevel_comision_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtProveedorSerialComi_Internalname ;
      private string edtProveedorSerialComi_Jsonclick ;
      private string edtProveedorPerAltShop_Internalname ;
      private string A437ProveedorPerAltShop ;
      private string edtProveedorPerAltShop_Jsonclick ;
      private string edtProveedorPideDoc_Internalname ;
      private string A490ProveedorPideDoc ;
      private string edtProveedorPideDoc_Jsonclick ;
      private string edtDocumentacionId_Internalname ;
      private string edtDocumentacionId_Jsonclick ;
      private string imgprompt_488_gximage ;
      private string imgprompt_488_Internalname ;
      private string imgprompt_488_Link ;
      private string imgDocumentacionIcono_Internalname ;
      private string Gridlevel_comision_titlescategories_Internalname ;
      private string sMode29 ;
      private string edtProveedorComisionID_Internalname ;
      private string dynRubrosId_Internalname ;
      private string edtRubrosImagen_Internalname ;
      private string dynMedidasID_Internalname ;
      private string dynInventarioId_Internalname ;
      private string edtMonedaId_Internalname ;
      private string edtEstadosTipo_Internalname ;
      private string edtEstadosGenericosId_Internalname ;
      private string edtEstadosGenericosNombre_Internalname ;
      private string edtInventarioPrecioFinal_Internalname ;
      private string chkProveedorComisionFP_Internalname ;
      private string edtProveedorComisionFPF_Internalname ;
      private string cmbProveedorComisionTipo_Internalname ;
      private string edtProveedorComision_Internalname ;
      private string cmbProveedorComisionAccion_Internalname ;
      private string subGridlevel_comision_Internalname ;
      private string A278ProveedoresTipoNombre ;
      private string A674BancoNombre ;
      private string AV40Pgmname ;
      private string A136InventarioNombre ;
      private string Dvpanel_unnamedtable3_Objectcall ;
      private string Dvpanel_unnamedtable3_Class ;
      private string Dvpanel_unnamedtable3_Height ;
      private string Dvpanel_unnamedtable3_Titletype ;
      private string Gxuitabspanel_tabs_Objectcall ;
      private string Gxuitabspanel_tabs_Activepagecontrolname ;
      private string Gridlevel_comision_titlescategories_Objectcall ;
      private string Gridlevel_comision_titlescategories_Class ;
      private string Gridlevel_comision_titlescategories_Gridinternalname ;
      private string Gridlevel_comision_titlescategories_Gridtitlescategories ;
      private string hsh ;
      private string sMode28 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A109EstadosGenericosNombre ;
      private string A346ProveedorComisionTipo ;
      private string A348ProveedorComisionAccion ;
      private string GXEncryptionTmp ;
      private string AV33AgrProveedorEstado ;
      private string Z278ProveedoresTipoNombre ;
      private string Z674BancoNombre ;
      private string Z136InventarioNombre ;
      private string Z107EstadosTipo ;
      private string Z109EstadosGenericosNombre ;
      private string GXCCtl ;
      private string sGXsfl_176_fel_idx="0001" ;
      private string subGridlevel_comision_Class ;
      private string subGridlevel_comision_Linesclass ;
      private string ROClassString ;
      private string edtProveedorComisionID_Jsonclick ;
      private string dynRubrosId_Jsonclick ;
      private string dynMedidasID_Jsonclick ;
      private string dynInventarioId_Jsonclick ;
      private string edtMonedaId_Jsonclick ;
      private string edtEstadosTipo_Jsonclick ;
      private string edtEstadosGenericosId_Jsonclick ;
      private string edtEstadosGenericosNombre_Jsonclick ;
      private string edtInventarioPrecioFinal_Jsonclick ;
      private string edtProveedorComisionFPF_Jsonclick ;
      private string cmbProveedorComisionTipo_Jsonclick ;
      private string edtProveedorComision_Jsonclick ;
      private string cmbProveedorComisionAccion_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i344ProveedorEstado ;
      private string i437ProveedorPerAltShop ;
      private string i490ProveedorPideDoc ;
      private string i440ProveedorPagoDefault ;
      private string i348ProveedorComisionAccion ;
      private string subGridlevel_comision_Header ;
      private string gxwrpcisep ;
      private DateTime Z548ProveedorFechaAlta ;
      private DateTime Z549ProveedorFechaActualizacion ;
      private DateTime Z686ProveedorAceptoTerminos ;
      private DateTime A686ProveedorAceptoTerminos ;
      private DateTime A548ProveedorFechaAlta ;
      private DateTime A549ProveedorFechaActualizacion ;
      private bool Z978ProveedorCIU ;
      private bool Z999ProveedorFreezePrice ;
      private bool Z1001ProveedorComisionFP ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n488DocumentacionId ;
      private bool n673BancoId ;
      private bool n135InventarioId ;
      private bool wbErr ;
      private bool A999ProveedorFreezePrice ;
      private bool n999ProveedorFreezePrice ;
      private bool n601ProveedorUsoInterno ;
      private bool A978ProveedorCIU ;
      private bool n546ProveedorUsrAlta ;
      private bool n547ProveedorUsrActualizacion ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool A432ProveedorImagen_IsBlob ;
      private bool Dvpanel_unnamedtable3_Autowidth ;
      private bool Dvpanel_unnamedtable3_Autoheight ;
      private bool Dvpanel_unnamedtable3_Collapsible ;
      private bool Dvpanel_unnamedtable3_Collapsed ;
      private bool Dvpanel_unnamedtable3_Showcollapseicon ;
      private bool Dvpanel_unnamedtable3_Autoscroll ;
      private bool A498DocumentacionIcono_IsBlob ;
      private bool bGXsfl_176_Refreshing=false ;
      private bool n548ProveedorFechaAlta ;
      private bool n549ProveedorFechaActualizacion ;
      private bool n682ProveedorRazonSocial ;
      private bool n683ProveedorContacto ;
      private bool n684ProveedorContactoCell ;
      private bool n430ProveedorTelefono ;
      private bool n431ProveedorDireccion ;
      private bool n433ProveedorEmail ;
      private bool n685ProveedorSitioWeb ;
      private bool n686ProveedorAceptoTerminos ;
      private bool n437ProveedorPerAltShop ;
      private bool n490ProveedorPideDoc ;
      private bool n687ProveedorCuentaBancaria ;
      private bool n40000ProveedorImagen_GXI ;
      private bool Dvpanel_unnamedtable3_Enabled ;
      private bool Dvpanel_unnamedtable3_Showheader ;
      private bool Dvpanel_unnamedtable3_Visible ;
      private bool Gxuitabspanel_tabs_Enabled ;
      private bool Gxuitabspanel_tabs_Visible ;
      private bool Gridlevel_comision_titlescategories_Enabled ;
      private bool Gridlevel_comision_titlescategories_Visible ;
      private bool n133ProveedorID ;
      private bool n432ProveedorImagen ;
      private bool A1001ProveedorComisionFP ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool AV37Existe ;
      private bool Gx_longc ;
      private bool n1001ProveedorComisionFP ;
      private bool n1000ProveedorComisionFPF ;
      private bool A168RubrosImagen_IsBlob ;
      private bool i978ProveedorCIU ;
      private bool i999ProveedorFreezePrice ;
      private bool gxdyncontrolsrefreshing ;
      private string Z431ProveedorDireccion ;
      private string Z433ProveedorEmail ;
      private string A433ProveedorEmail ;
      private string A431ProveedorDireccion ;
      private string A40000ProveedorImagen_GXI ;
      private string A40001DocumentacionIcono_GXI ;
      private string A40002RubrosImagen_GXI ;
      private string AV34SecRoleName ;
      private string Z40000ProveedorImagen_GXI ;
      private string Z40001DocumentacionIcono_GXI ;
      private string Z40002RubrosImagen_GXI ;
      private string A432ProveedorImagen ;
      private string A498DocumentacionIcono ;
      private string A168RubrosImagen ;
      private string Z432ProveedorImagen ;
      private string Z498DocumentacionIcono ;
      private string Z168RubrosImagen ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_comisionContainer ;
      private GXWebRow Gridlevel_comisionRow ;
      private GXWebColumn Gridlevel_comisionColumn ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXUserControl ucDvpanel_unnamedtable3 ;
      private GXUserControl ucGridlevel_comision_titlescategories ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbProveedorEstado ;
      private GXCheckbox chkProveedorFreezePrice ;
      private GXCombobox dynProveedoresTipoId ;
      private GXCheckbox chkProveedorUsoInterno ;
      private GXCheckbox chkProveedorCIU ;
      private GXCombobox cmbProveedorPagoDefault ;
      private GXCombobox dynBancoId ;
      private GXCombobox dynProveedorUsrAlta ;
      private GXCombobox dynProveedorUsrActualizacion ;
      private GXCombobox dynRubrosId ;
      private GXCombobox dynMedidasID ;
      private GXCombobox dynInventarioId ;
      private GXCheckbox chkProveedorComisionFP ;
      private GXCombobox cmbProveedorComisionTipo ;
      private GXCombobox cmbProveedorComisionAccion ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private SdtSDTRoles AV31Roles ;
      private SdtSDTRoles_Id AV32RolesItem ;
      private IDataStoreProvider pr_default ;
      private string[] T000N12_A674BancoNombre ;
      private string[] T000N11_A40001DocumentacionIcono_GXI ;
      private string[] T000N11_A498DocumentacionIcono ;
      private string[] T000N10_A278ProveedoresTipoNombre ;
      private long[] T000N13_A133ProveedorID ;
      private bool[] T000N13_n133ProveedorID ;
      private long[] T000N13_A546ProveedorUsrAlta ;
      private bool[] T000N13_n546ProveedorUsrAlta ;
      private long[] T000N13_A547ProveedorUsrActualizacion ;
      private bool[] T000N13_n547ProveedorUsrActualizacion ;
      private DateTime[] T000N13_A548ProveedorFechaAlta ;
      private bool[] T000N13_n548ProveedorFechaAlta ;
      private DateTime[] T000N13_A549ProveedorFechaActualizacion ;
      private bool[] T000N13_n549ProveedorFechaActualizacion ;
      private string[] T000N13_A278ProveedoresTipoNombre ;
      private string[] T000N13_A282ProveedorNombre ;
      private string[] T000N13_A682ProveedorRazonSocial ;
      private bool[] T000N13_n682ProveedorRazonSocial ;
      private string[] T000N13_A683ProveedorContacto ;
      private bool[] T000N13_n683ProveedorContacto ;
      private string[] T000N13_A684ProveedorContactoCell ;
      private bool[] T000N13_n684ProveedorContactoCell ;
      private string[] T000N13_A40000ProveedorImagen_GXI ;
      private bool[] T000N13_n40000ProveedorImagen_GXI ;
      private string[] T000N13_A338ProveedorDocIdentidad ;
      private short[] T000N13_A345ProveedorSerialComi ;
      private string[] T000N13_A430ProveedorTelefono ;
      private bool[] T000N13_n430ProveedorTelefono ;
      private string[] T000N13_A431ProveedorDireccion ;
      private bool[] T000N13_n431ProveedorDireccion ;
      private string[] T000N13_A433ProveedorEmail ;
      private bool[] T000N13_n433ProveedorEmail ;
      private string[] T000N13_A685ProveedorSitioWeb ;
      private bool[] T000N13_n685ProveedorSitioWeb ;
      private DateTime[] T000N13_A686ProveedorAceptoTerminos ;
      private bool[] T000N13_n686ProveedorAceptoTerminos ;
      private string[] T000N13_A437ProveedorPerAltShop ;
      private bool[] T000N13_n437ProveedorPerAltShop ;
      private string[] T000N13_A344ProveedorEstado ;
      private string[] T000N13_A440ProveedorPagoDefault ;
      private string[] T000N13_A490ProveedorPideDoc ;
      private bool[] T000N13_n490ProveedorPideDoc ;
      private string[] T000N13_A40001DocumentacionIcono_GXI ;
      private string[] T000N13_A601ProveedorUsoInterno ;
      private bool[] T000N13_n601ProveedorUsoInterno ;
      private string[] T000N13_A687ProveedorCuentaBancaria ;
      private bool[] T000N13_n687ProveedorCuentaBancaria ;
      private string[] T000N13_A674BancoNombre ;
      private bool[] T000N13_A978ProveedorCIU ;
      private bool[] T000N13_A999ProveedorFreezePrice ;
      private bool[] T000N13_n999ProveedorFreezePrice ;
      private long[] T000N13_A151ProveedoresTipoId ;
      private long[] T000N13_A488DocumentacionId ;
      private bool[] T000N13_n488DocumentacionId ;
      private long[] T000N13_A673BancoId ;
      private bool[] T000N13_n673BancoId ;
      private string[] T000N13_A432ProveedorImagen ;
      private bool[] T000N13_n432ProveedorImagen ;
      private string[] T000N13_A498DocumentacionIcono ;
      private string[] T000N14_A278ProveedoresTipoNombre ;
      private string[] T000N15_A40001DocumentacionIcono_GXI ;
      private string[] T000N15_A498DocumentacionIcono ;
      private string[] T000N16_A674BancoNombre ;
      private long[] T000N17_A133ProveedorID ;
      private bool[] T000N17_n133ProveedorID ;
      private long[] T000N9_A133ProveedorID ;
      private bool[] T000N9_n133ProveedorID ;
      private long[] T000N9_A546ProveedorUsrAlta ;
      private bool[] T000N9_n546ProveedorUsrAlta ;
      private long[] T000N9_A547ProveedorUsrActualizacion ;
      private bool[] T000N9_n547ProveedorUsrActualizacion ;
      private DateTime[] T000N9_A548ProveedorFechaAlta ;
      private bool[] T000N9_n548ProveedorFechaAlta ;
      private DateTime[] T000N9_A549ProveedorFechaActualizacion ;
      private bool[] T000N9_n549ProveedorFechaActualizacion ;
      private string[] T000N9_A282ProveedorNombre ;
      private string[] T000N9_A682ProveedorRazonSocial ;
      private bool[] T000N9_n682ProveedorRazonSocial ;
      private string[] T000N9_A683ProveedorContacto ;
      private bool[] T000N9_n683ProveedorContacto ;
      private string[] T000N9_A684ProveedorContactoCell ;
      private bool[] T000N9_n684ProveedorContactoCell ;
      private string[] T000N9_A40000ProveedorImagen_GXI ;
      private bool[] T000N9_n40000ProveedorImagen_GXI ;
      private string[] T000N9_A338ProveedorDocIdentidad ;
      private short[] T000N9_A345ProveedorSerialComi ;
      private string[] T000N9_A430ProveedorTelefono ;
      private bool[] T000N9_n430ProveedorTelefono ;
      private string[] T000N9_A431ProveedorDireccion ;
      private bool[] T000N9_n431ProveedorDireccion ;
      private string[] T000N9_A433ProveedorEmail ;
      private bool[] T000N9_n433ProveedorEmail ;
      private string[] T000N9_A685ProveedorSitioWeb ;
      private bool[] T000N9_n685ProveedorSitioWeb ;
      private DateTime[] T000N9_A686ProveedorAceptoTerminos ;
      private bool[] T000N9_n686ProveedorAceptoTerminos ;
      private string[] T000N9_A437ProveedorPerAltShop ;
      private bool[] T000N9_n437ProveedorPerAltShop ;
      private string[] T000N9_A344ProveedorEstado ;
      private string[] T000N9_A440ProveedorPagoDefault ;
      private string[] T000N9_A490ProveedorPideDoc ;
      private bool[] T000N9_n490ProveedorPideDoc ;
      private string[] T000N9_A601ProveedorUsoInterno ;
      private bool[] T000N9_n601ProveedorUsoInterno ;
      private string[] T000N9_A687ProveedorCuentaBancaria ;
      private bool[] T000N9_n687ProveedorCuentaBancaria ;
      private bool[] T000N9_A978ProveedorCIU ;
      private bool[] T000N9_A999ProveedorFreezePrice ;
      private bool[] T000N9_n999ProveedorFreezePrice ;
      private long[] T000N9_A151ProveedoresTipoId ;
      private long[] T000N9_A488DocumentacionId ;
      private bool[] T000N9_n488DocumentacionId ;
      private long[] T000N9_A673BancoId ;
      private bool[] T000N9_n673BancoId ;
      private string[] T000N9_A432ProveedorImagen ;
      private bool[] T000N9_n432ProveedorImagen ;
      private long[] T000N18_A133ProveedorID ;
      private bool[] T000N18_n133ProveedorID ;
      private long[] T000N19_A133ProveedorID ;
      private bool[] T000N19_n133ProveedorID ;
      private long[] T000N8_A133ProveedorID ;
      private bool[] T000N8_n133ProveedorID ;
      private long[] T000N8_A546ProveedorUsrAlta ;
      private bool[] T000N8_n546ProveedorUsrAlta ;
      private long[] T000N8_A547ProveedorUsrActualizacion ;
      private bool[] T000N8_n547ProveedorUsrActualizacion ;
      private DateTime[] T000N8_A548ProveedorFechaAlta ;
      private bool[] T000N8_n548ProveedorFechaAlta ;
      private DateTime[] T000N8_A549ProveedorFechaActualizacion ;
      private bool[] T000N8_n549ProveedorFechaActualizacion ;
      private string[] T000N8_A282ProveedorNombre ;
      private string[] T000N8_A682ProveedorRazonSocial ;
      private bool[] T000N8_n682ProveedorRazonSocial ;
      private string[] T000N8_A683ProveedorContacto ;
      private bool[] T000N8_n683ProveedorContacto ;
      private string[] T000N8_A684ProveedorContactoCell ;
      private bool[] T000N8_n684ProveedorContactoCell ;
      private string[] T000N8_A40000ProveedorImagen_GXI ;
      private bool[] T000N8_n40000ProveedorImagen_GXI ;
      private string[] T000N8_A338ProveedorDocIdentidad ;
      private short[] T000N8_A345ProveedorSerialComi ;
      private string[] T000N8_A430ProveedorTelefono ;
      private bool[] T000N8_n430ProveedorTelefono ;
      private string[] T000N8_A431ProveedorDireccion ;
      private bool[] T000N8_n431ProveedorDireccion ;
      private string[] T000N8_A433ProveedorEmail ;
      private bool[] T000N8_n433ProveedorEmail ;
      private string[] T000N8_A685ProveedorSitioWeb ;
      private bool[] T000N8_n685ProveedorSitioWeb ;
      private DateTime[] T000N8_A686ProveedorAceptoTerminos ;
      private bool[] T000N8_n686ProveedorAceptoTerminos ;
      private string[] T000N8_A437ProveedorPerAltShop ;
      private bool[] T000N8_n437ProveedorPerAltShop ;
      private string[] T000N8_A344ProveedorEstado ;
      private string[] T000N8_A440ProveedorPagoDefault ;
      private string[] T000N8_A490ProveedorPideDoc ;
      private bool[] T000N8_n490ProveedorPideDoc ;
      private string[] T000N8_A601ProveedorUsoInterno ;
      private bool[] T000N8_n601ProveedorUsoInterno ;
      private string[] T000N8_A687ProveedorCuentaBancaria ;
      private bool[] T000N8_n687ProveedorCuentaBancaria ;
      private bool[] T000N8_A978ProveedorCIU ;
      private bool[] T000N8_A999ProveedorFreezePrice ;
      private bool[] T000N8_n999ProveedorFreezePrice ;
      private long[] T000N8_A151ProveedoresTipoId ;
      private long[] T000N8_A488DocumentacionId ;
      private bool[] T000N8_n488DocumentacionId ;
      private long[] T000N8_A673BancoId ;
      private bool[] T000N8_n673BancoId ;
      private string[] T000N8_A432ProveedorImagen ;
      private bool[] T000N8_n432ProveedorImagen ;
      private long[] T000N20_A133ProveedorID ;
      private bool[] T000N20_n133ProveedorID ;
      private string[] T000N24_A278ProveedoresTipoNombre ;
      private string[] T000N25_A40001DocumentacionIcono_GXI ;
      private string[] T000N25_A498DocumentacionIcono ;
      private string[] T000N26_A674BancoNombre ;
      private long[] T000N27_A422PostulacionesId ;
      private long[] T000N28_A918MapeoID ;
      private long[] T000N29_A918MapeoID ;
      private long[] T000N30_A491VincularTrnId ;
      private long[] T000N31_A450ProfComisionesID ;
      private long[] T000N31_A452ProfComisionesRubrosId ;
      private long[] T000N32_A127SolicitudesID ;
      private long[] T000N33_A127SolicitudesID ;
      private long[] T000N34_A133ProveedorID ;
      private bool[] T000N34_n133ProveedorID ;
      private long[] T000N34_A713ComercioProductosRubrosID ;
      private long[] T000N35_A590Listaid ;
      private long[] T000N35_A133ProveedorID ;
      private bool[] T000N35_n133ProveedorID ;
      private string[] T000N35_A120ProfesionalesId ;
      private long[] T000N36_A590Listaid ;
      private long[] T000N36_A18SecUserId ;
      private long[] T000N36_A133ProveedorID ;
      private bool[] T000N36_n133ProveedorID ;
      private long[] T000N37_A503ComisionesID ;
      private long[] T000N37_A133ProveedorID ;
      private bool[] T000N37_n133ProveedorID ;
      private long[] T000N38_A133ProveedorID ;
      private bool[] T000N38_n133ProveedorID ;
      private long[] T000N38_A152ProveedorSolicitudesId ;
      private long[] T000N40_A133ProveedorID ;
      private bool[] T000N40_n133ProveedorID ;
      private string[] T000N4_A40002RubrosImagen_GXI ;
      private string[] T000N4_A168RubrosImagen ;
      private short[] T000N5_A118MonedaId ;
      private string[] T000N6_A136InventarioNombre ;
      private decimal[] T000N6_A181InventarioPrecioFinal ;
      private string[] T000N6_A107EstadosTipo ;
      private int[] T000N6_A108EstadosGenericosId ;
      private string[] T000N7_A109EstadosGenericosNombre ;
      private long[] T000N41_A133ProveedorID ;
      private bool[] T000N41_n133ProveedorID ;
      private long[] T000N41_A157ProveedorComisionID ;
      private string[] T000N41_A348ProveedorComisionAccion ;
      private string[] T000N41_A40002RubrosImagen_GXI ;
      private string[] T000N41_A136InventarioNombre ;
      private string[] T000N41_A109EstadosGenericosNombre ;
      private decimal[] T000N41_A181InventarioPrecioFinal ;
      private bool[] T000N41_A1001ProveedorComisionFP ;
      private bool[] T000N41_n1001ProveedorComisionFP ;
      private decimal[] T000N41_A1000ProveedorComisionFPF ;
      private bool[] T000N41_n1000ProveedorComisionFPF ;
      private string[] T000N41_A346ProveedorComisionTipo ;
      private decimal[] T000N41_A347ProveedorComision ;
      private short[] T000N41_A121RubrosId ;
      private long[] T000N41_A137MedidasID ;
      private long[] T000N41_A135InventarioId ;
      private bool[] T000N41_n135InventarioId ;
      private short[] T000N41_A118MonedaId ;
      private string[] T000N41_A107EstadosTipo ;
      private int[] T000N41_A108EstadosGenericosId ;
      private string[] T000N41_A168RubrosImagen ;
      private string[] T000N42_A40002RubrosImagen_GXI ;
      private string[] T000N42_A168RubrosImagen ;
      private short[] T000N43_A118MonedaId ;
      private string[] T000N44_A136InventarioNombre ;
      private decimal[] T000N44_A181InventarioPrecioFinal ;
      private string[] T000N44_A107EstadosTipo ;
      private int[] T000N44_A108EstadosGenericosId ;
      private string[] T000N45_A109EstadosGenericosNombre ;
      private long[] T000N46_A133ProveedorID ;
      private bool[] T000N46_n133ProveedorID ;
      private long[] T000N46_A157ProveedorComisionID ;
      private long[] T000N3_A133ProveedorID ;
      private bool[] T000N3_n133ProveedorID ;
      private long[] T000N3_A157ProveedorComisionID ;
      private string[] T000N3_A348ProveedorComisionAccion ;
      private bool[] T000N3_A1001ProveedorComisionFP ;
      private bool[] T000N3_n1001ProveedorComisionFP ;
      private decimal[] T000N3_A1000ProveedorComisionFPF ;
      private bool[] T000N3_n1000ProveedorComisionFPF ;
      private string[] T000N3_A346ProveedorComisionTipo ;
      private decimal[] T000N3_A347ProveedorComision ;
      private short[] T000N3_A121RubrosId ;
      private long[] T000N3_A137MedidasID ;
      private long[] T000N3_A135InventarioId ;
      private bool[] T000N3_n135InventarioId ;
      private long[] T000N2_A133ProveedorID ;
      private bool[] T000N2_n133ProveedorID ;
      private long[] T000N2_A157ProveedorComisionID ;
      private string[] T000N2_A348ProveedorComisionAccion ;
      private bool[] T000N2_A1001ProveedorComisionFP ;
      private bool[] T000N2_n1001ProveedorComisionFP ;
      private decimal[] T000N2_A1000ProveedorComisionFPF ;
      private bool[] T000N2_n1000ProveedorComisionFPF ;
      private string[] T000N2_A346ProveedorComisionTipo ;
      private decimal[] T000N2_A347ProveedorComision ;
      private short[] T000N2_A121RubrosId ;
      private long[] T000N2_A137MedidasID ;
      private long[] T000N2_A135InventarioId ;
      private bool[] T000N2_n135InventarioId ;
      private string[] T000N50_A40002RubrosImagen_GXI ;
      private string[] T000N50_A168RubrosImagen ;
      private short[] T000N51_A118MonedaId ;
      private string[] T000N52_A136InventarioNombre ;
      private decimal[] T000N52_A181InventarioPrecioFinal ;
      private string[] T000N52_A107EstadosTipo ;
      private int[] T000N52_A108EstadosGenericosId ;
      private string[] T000N53_A109EstadosGenericosNombre ;
      private long[] T000N54_A133ProveedorID ;
      private bool[] T000N54_n133ProveedorID ;
      private long[] T000N54_A157ProveedorComisionID ;
      private long[] T000N55_A18SecUserId ;
      private string[] T000N55_A587SecUserFullName ;
      private long[] T000N56_A18SecUserId ;
      private string[] T000N56_A587SecUserFullName ;
      private long[] T000N57_A151ProveedoresTipoId ;
      private string[] T000N57_A278ProveedoresTipoNombre ;
      private long[] T000N58_A673BancoId ;
      private bool[] T000N58_n673BancoId ;
      private string[] T000N58_A674BancoNombre ;
      private string[] T000N58_A675BancoEstado ;
      private short[] T000N59_A121RubrosId ;
      private string[] T000N59_A122RubrosNombre ;
      private string[] T000N59_A123RubrosEstado ;
      private bool[] T000N59_n123RubrosEstado ;
      private short[] T000N60_A121RubrosId ;
      private long[] T000N60_A137MedidasID ;
      private string[] T000N60_A138MedidasNombre ;
      private string[] T000N60_A139MedidasEstado ;
      private bool[] T000N60_n139MedidasEstado ;
      private short[] T000N61_A121RubrosId ;
      private long[] T000N61_A137MedidasID ;
      private long[] T000N61_A135InventarioId ;
      private bool[] T000N61_n135InventarioId ;
      private string[] T000N61_A136InventarioNombre ;
      private string[] T000N61_A107EstadosTipo ;
      private int[] T000N61_A108EstadosGenericosId ;
      private long[] T000N62_A151ProveedoresTipoId ;
      private string[] T000N62_A278ProveedoresTipoNombre ;
      private long[] T000N63_A18SecUserId ;
      private string[] T000N63_A587SecUserFullName ;
      private long[] T000N64_A18SecUserId ;
      private string[] T000N64_A587SecUserFullName ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class proveedor__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class proveedor__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new UpdateCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new UpdateCursor(def[45])
       ,new UpdateCursor(def[46])
       ,new UpdateCursor(def[47])
       ,new ForEachCursor(def[48])
       ,new ForEachCursor(def[49])
       ,new ForEachCursor(def[50])
       ,new ForEachCursor(def[51])
       ,new ForEachCursor(def[52])
       ,new ForEachCursor(def[53])
       ,new ForEachCursor(def[54])
       ,new ForEachCursor(def[55])
       ,new ForEachCursor(def[56])
       ,new ForEachCursor(def[57])
       ,new ForEachCursor(def[58])
       ,new ForEachCursor(def[59])
       ,new ForEachCursor(def[60])
       ,new ForEachCursor(def[61])
       ,new ForEachCursor(def[62])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000N2;
        prmT000N2 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
        };
        Object[] prmT000N3;
        prmT000N3 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
        };
        Object[] prmT000N4;
        prmT000N4 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000N5;
        prmT000N5 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT000N6;
        prmT000N6 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N7;
        prmT000N7 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000N8;
        prmT000N8 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N9;
        prmT000N9 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N10;
        prmT000N10 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT000N11;
        prmT000N11 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N12;
        prmT000N12 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N13;
        prmT000N13 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N14;
        prmT000N14 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT000N15;
        prmT000N15 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N16;
        prmT000N16 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N17;
        prmT000N17 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N18;
        prmT000N18 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N19;
        prmT000N19 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N20;
        prmT000N20 = new Object[] {
        new ParDef("@ProveedorUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@ProveedorUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@ProveedorFechaAlta",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorRazonSocial",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@ProveedorContacto",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorContactoCell",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=8, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorDocIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ProveedorSerialComi",GXType.Int16,4,0) ,
        new ParDef("@ProveedorTelefono",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorDireccion",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProveedorEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProveedorSitioWeb",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorAceptoTerminos",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorPerAltShop",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
        new ParDef("@ProveedorPagoDefault",GXType.NChar,1,0) ,
        new ParDef("@ProveedorPideDoc",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProveedorUsoInterno",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProveedorCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0) ,
        new ParDef("@ProveedorFreezePrice",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0) ,
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N21;
        prmT000N21 = new Object[] {
        new ParDef("@ProveedorUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@ProveedorUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@ProveedorFechaAlta",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorNombre",GXType.NChar,80,0) ,
        new ParDef("@ProveedorRazonSocial",GXType.NChar,25,0){Nullable=true} ,
        new ParDef("@ProveedorContacto",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorContactoCell",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorDocIdentidad",GXType.NChar,25,0) ,
        new ParDef("@ProveedorSerialComi",GXType.Int16,4,0) ,
        new ParDef("@ProveedorTelefono",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProveedorDireccion",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProveedorEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProveedorSitioWeb",GXType.NChar,128,0){Nullable=true} ,
        new ParDef("@ProveedorAceptoTerminos",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProveedorPerAltShop",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProveedorEstado",GXType.NChar,3,0) ,
        new ParDef("@ProveedorPagoDefault",GXType.NChar,1,0) ,
        new ParDef("@ProveedorPideDoc",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProveedorUsoInterno",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProveedorCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@ProveedorCIU",GXType.Boolean,4,0) ,
        new ParDef("@ProveedorFreezePrice",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0) ,
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N22;
        prmT000N22 = new Object[] {
        new ParDef("@ProveedorImagen",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
        new ParDef("@ProveedorImagen_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Proveedor", Fld="ProveedorImagen"} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N23;
        prmT000N23 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N24;
        prmT000N24 = new Object[] {
        new ParDef("@ProveedoresTipoId",GXType.Decimal,18,0)
        };
        Object[] prmT000N25;
        prmT000N25 = new Object[] {
        new ParDef("@DocumentacionId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N26;
        prmT000N26 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N27;
        prmT000N27 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N28;
        prmT000N28 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N29;
        prmT000N29 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N30;
        prmT000N30 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N31;
        prmT000N31 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N32;
        prmT000N32 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N33;
        prmT000N33 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N34;
        prmT000N34 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N35;
        prmT000N35 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N36;
        prmT000N36 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N37;
        prmT000N37 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N38;
        prmT000N38 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N39;
        prmT000N39 = new Object[] {
        new ParDef("@ProveedorSerialComi",GXType.Int16,4,0) ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N40;
        prmT000N40 = new Object[] {
        };
        Object[] prmT000N41;
        prmT000N41 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
        };
        Object[] prmT000N42;
        prmT000N42 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000N43;
        prmT000N43 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT000N44;
        prmT000N44 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N45;
        prmT000N45 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000N46;
        prmT000N46 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
        };
        Object[] prmT000N47;
        prmT000N47 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0) ,
        new ParDef("@ProveedorComisionAccion",GXType.NChar,1,0) ,
        new ParDef("@ProveedorComisionFP",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProveedorComisionFPF",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@ProveedorComisionTipo",GXType.NChar,1,0) ,
        new ParDef("@ProveedorComision",GXType.Decimal,18,2) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N48;
        prmT000N48 = new Object[] {
        new ParDef("@ProveedorComisionAccion",GXType.NChar,1,0) ,
        new ParDef("@ProveedorComisionFP",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProveedorComisionFPF",GXType.Decimal,18,2){Nullable=true} ,
        new ParDef("@ProveedorComisionTipo",GXType.NChar,1,0) ,
        new ParDef("@ProveedorComision",GXType.Decimal,18,2) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
        };
        Object[] prmT000N49;
        prmT000N49 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
        };
        Object[] prmT000N50;
        prmT000N50 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000N51;
        prmT000N51 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT000N52;
        prmT000N52 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0) ,
        new ParDef("@InventarioId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N53;
        prmT000N53 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000N54;
        prmT000N54 = new Object[] {
        new ParDef("@ProveedorID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000N55;
        prmT000N55 = new Object[] {
        };
        Object[] prmT000N56;
        prmT000N56 = new Object[] {
        };
        Object[] prmT000N57;
        prmT000N57 = new Object[] {
        };
        Object[] prmT000N58;
        prmT000N58 = new Object[] {
        };
        Object[] prmT000N59;
        prmT000N59 = new Object[] {
        };
        Object[] prmT000N60;
        prmT000N60 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000N61;
        prmT000N61 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@MedidasID",GXType.Decimal,18,0)
        };
        Object[] prmT000N62;
        prmT000N62 = new Object[] {
        };
        Object[] prmT000N63;
        prmT000N63 = new Object[] {
        };
        Object[] prmT000N64;
        prmT000N64 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000N2", "SELECT [ProveedorID], [ProveedorComisionID], [ProveedorComisionAccion], [ProveedorComisionFP], [ProveedorComisionFPF], [ProveedorComisionTipo], [ProveedorComision], [RubrosId], [MedidasID], [InventarioId] FROM [ProveedorComision] WITH (UPDLOCK) WHERE [ProveedorID] = @ProveedorID AND [ProveedorComisionID] = @ProveedorComisionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N3", "SELECT [ProveedorID], [ProveedorComisionID], [ProveedorComisionAccion], [ProveedorComisionFP], [ProveedorComisionFPF], [ProveedorComisionTipo], [ProveedorComision], [RubrosId], [MedidasID], [InventarioId] FROM [ProveedorComision] WHERE [ProveedorID] = @ProveedorID AND [ProveedorComisionID] = @ProveedorComisionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N4", "SELECT [RubrosImagen_GXI], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N5", "SELECT [MonedaId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N6", "SELECT [InventarioNombre], [InventarioPrecioFinal], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N7", "SELECT [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N8", "SELECT [ProveedorID], [ProveedorUsrAlta], [ProveedorUsrActualizacion], [ProveedorFechaAlta], [ProveedorFechaActualizacion], [ProveedorNombre], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorImagen_GXI], [ProveedorDocIdentidad], [ProveedorSerialComi], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorSitioWeb], [ProveedorAceptoTerminos], [ProveedorPerAltShop], [ProveedorEstado], [ProveedorPagoDefault], [ProveedorPideDoc], [ProveedorUsoInterno], [ProveedorCuentaBancaria], [ProveedorCIU], [ProveedorFreezePrice], [ProveedoresTipoId], [DocumentacionId], [BancoId], [ProveedorImagen] FROM [Proveedor] WITH (UPDLOCK) WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N9", "SELECT [ProveedorID], [ProveedorUsrAlta], [ProveedorUsrActualizacion], [ProveedorFechaAlta], [ProveedorFechaActualizacion], [ProveedorNombre], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorImagen_GXI], [ProveedorDocIdentidad], [ProveedorSerialComi], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorSitioWeb], [ProveedorAceptoTerminos], [ProveedorPerAltShop], [ProveedorEstado], [ProveedorPagoDefault], [ProveedorPideDoc], [ProveedorUsoInterno], [ProveedorCuentaBancaria], [ProveedorCIU], [ProveedorFreezePrice], [ProveedoresTipoId], [DocumentacionId], [BancoId], [ProveedorImagen] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N10", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N11", "SELECT [DocumentacionIcono_GXI], [DocumentacionIcono] FROM [Documentacion] WHERE [DocumentacionId] = @DocumentacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N12", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N13", "SELECT TM1.[ProveedorID], TM1.[ProveedorUsrAlta], TM1.[ProveedorUsrActualizacion], TM1.[ProveedorFechaAlta], TM1.[ProveedorFechaActualizacion], T2.[ProveedoresTipoNombre], TM1.[ProveedorNombre], TM1.[ProveedorRazonSocial], TM1.[ProveedorContacto], TM1.[ProveedorContactoCell], TM1.[ProveedorImagen_GXI], TM1.[ProveedorDocIdentidad], TM1.[ProveedorSerialComi], TM1.[ProveedorTelefono], TM1.[ProveedorDireccion], TM1.[ProveedorEmail], TM1.[ProveedorSitioWeb], TM1.[ProveedorAceptoTerminos], TM1.[ProveedorPerAltShop], TM1.[ProveedorEstado], TM1.[ProveedorPagoDefault], TM1.[ProveedorPideDoc], T3.[DocumentacionIcono_GXI], TM1.[ProveedorUsoInterno], TM1.[ProveedorCuentaBancaria], T4.[BancoNombre], TM1.[ProveedorCIU], TM1.[ProveedorFreezePrice], TM1.[ProveedoresTipoId], TM1.[DocumentacionId], TM1.[BancoId], TM1.[ProveedorImagen], T3.[DocumentacionIcono] FROM ((([Proveedor] TM1 INNER JOIN [ProveedoresTipo] T2 ON T2.[ProveedoresTipoId] = TM1.[ProveedoresTipoId]) LEFT JOIN [Documentacion] T3 ON T3.[DocumentacionId] = TM1.[DocumentacionId]) LEFT JOIN [Banco] T4 ON T4.[BancoId] = TM1.[BancoId]) WHERE TM1.[ProveedorID] = @ProveedorID ORDER BY TM1.[ProveedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N14", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N15", "SELECT [DocumentacionIcono_GXI], [DocumentacionIcono] FROM [Documentacion] WHERE [DocumentacionId] = @DocumentacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N16", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N17", "SELECT [ProveedorID] FROM [Proveedor] WHERE [ProveedorID] = @ProveedorID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N18", "SELECT TOP 1 [ProveedorID] FROM [Proveedor] WHERE ( [ProveedorID] > @ProveedorID) ORDER BY [ProveedorID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N19", "SELECT TOP 1 [ProveedorID] FROM [Proveedor] WHERE ( [ProveedorID] < @ProveedorID) ORDER BY [ProveedorID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N20", "INSERT INTO [Proveedor]([ProveedorUsrAlta], [ProveedorUsrActualizacion], [ProveedorFechaAlta], [ProveedorFechaActualizacion], [ProveedorNombre], [ProveedorRazonSocial], [ProveedorContacto], [ProveedorContactoCell], [ProveedorImagen], [ProveedorImagen_GXI], [ProveedorDocIdentidad], [ProveedorSerialComi], [ProveedorTelefono], [ProveedorDireccion], [ProveedorEmail], [ProveedorSitioWeb], [ProveedorAceptoTerminos], [ProveedorPerAltShop], [ProveedorEstado], [ProveedorPagoDefault], [ProveedorPideDoc], [ProveedorUsoInterno], [ProveedorCuentaBancaria], [ProveedorCIU], [ProveedorFreezePrice], [ProveedoresTipoId], [DocumentacionId], [BancoId], [ComercioProductosREnum]) VALUES(@ProveedorUsrAlta, @ProveedorUsrActualizacion, @ProveedorFechaAlta, @ProveedorFechaActualizacion, @ProveedorNombre, @ProveedorRazonSocial, @ProveedorContacto, @ProveedorContactoCell, @ProveedorImagen, @ProveedorImagen_GXI, @ProveedorDocIdentidad, @ProveedorSerialComi, @ProveedorTelefono, @ProveedorDireccion, @ProveedorEmail, @ProveedorSitioWeb, @ProveedorAceptoTerminos, @ProveedorPerAltShop, @ProveedorEstado, @ProveedorPagoDefault, @ProveedorPideDoc, @ProveedorUsoInterno, @ProveedorCuentaBancaria, @ProveedorCIU, @ProveedorFreezePrice, @ProveedoresTipoId, @DocumentacionId, @BancoId, convert(int, 0)); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000N20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N21", "UPDATE [Proveedor] SET [ProveedorUsrAlta]=@ProveedorUsrAlta, [ProveedorUsrActualizacion]=@ProveedorUsrActualizacion, [ProveedorFechaAlta]=@ProveedorFechaAlta, [ProveedorFechaActualizacion]=@ProveedorFechaActualizacion, [ProveedorNombre]=@ProveedorNombre, [ProveedorRazonSocial]=@ProveedorRazonSocial, [ProveedorContacto]=@ProveedorContacto, [ProveedorContactoCell]=@ProveedorContactoCell, [ProveedorDocIdentidad]=@ProveedorDocIdentidad, [ProveedorSerialComi]=@ProveedorSerialComi, [ProveedorTelefono]=@ProveedorTelefono, [ProveedorDireccion]=@ProveedorDireccion, [ProveedorEmail]=@ProveedorEmail, [ProveedorSitioWeb]=@ProveedorSitioWeb, [ProveedorAceptoTerminos]=@ProveedorAceptoTerminos, [ProveedorPerAltShop]=@ProveedorPerAltShop, [ProveedorEstado]=@ProveedorEstado, [ProveedorPagoDefault]=@ProveedorPagoDefault, [ProveedorPideDoc]=@ProveedorPideDoc, [ProveedorUsoInterno]=@ProveedorUsoInterno, [ProveedorCuentaBancaria]=@ProveedorCuentaBancaria, [ProveedorCIU]=@ProveedorCIU, [ProveedorFreezePrice]=@ProveedorFreezePrice, [ProveedoresTipoId]=@ProveedoresTipoId, [DocumentacionId]=@DocumentacionId, [BancoId]=@BancoId  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT000N21)
           ,new CursorDef("T000N22", "UPDATE [Proveedor] SET [ProveedorImagen]=@ProveedorImagen, [ProveedorImagen_GXI]=@ProveedorImagen_GXI  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT000N22)
           ,new CursorDef("T000N23", "DELETE FROM [Proveedor]  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT000N23)
           ,new CursorDef("T000N24", "SELECT [ProveedoresTipoNombre] FROM [ProveedoresTipo] WHERE [ProveedoresTipoId] = @ProveedoresTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N25", "SELECT [DocumentacionIcono_GXI], [DocumentacionIcono] FROM [Documentacion] WHERE [DocumentacionId] = @DocumentacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N26", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N27", "SELECT TOP 1 [PostulacionesId] FROM [Postulaciones] WHERE [PostulacionesProveedorId] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N28", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [STComerciosID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N29", "SELECT TOP 1 [MapeoID] FROM [ListaMapeo] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N30", "SELECT TOP 1 [VincularTrnId] FROM [VincularTrn] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N31", "SELECT TOP 1 [ProfComisionesID], [ProfComisionesRubrosId] FROM [ProfComisionesRubros] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N32", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [STComerciosID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N32,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N33", "SELECT TOP 1 [SolicitudesID] FROM [Solicitudes] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N34", "SELECT TOP 1 [ProveedorID], [ComercioProductosRubrosID] FROM [ComercioProductosRubros] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N34,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N35", "SELECT TOP 1 [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N35,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N36", "SELECT TOP 1 [Listaid], [SecUserId], [ProveedorID] FROM [ListaAgrUserProveedor] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N36,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N37", "SELECT TOP 1 [ComisionesID], [ProveedorID] FROM [ComisionesProveedores] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N37,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N38", "SELECT TOP 1 [ProveedorID], [ProveedorSolicitudesId] FROM [ProveedorSolicitudes] WHERE [ProveedorID] = @ProveedorID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N38,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N39", "UPDATE [Proveedor] SET [ProveedorSerialComi]=@ProveedorSerialComi  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK,prmT000N39)
           ,new CursorDef("T000N40", "SELECT [ProveedorID] FROM [Proveedor] ORDER BY [ProveedorID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000N40,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N41", "SELECT T1.[ProveedorID], T1.[ProveedorComisionID], T1.[ProveedorComisionAccion], T2.[RubrosImagen_GXI], T4.[InventarioNombre], T5.[EstadosGenericosNombre], T4.[InventarioPrecioFinal], T1.[ProveedorComisionFP], T1.[ProveedorComisionFPF], T1.[ProveedorComisionTipo], T1.[ProveedorComision], T1.[RubrosId], T1.[MedidasID], T1.[InventarioId], T3.[MonedaId], T4.[EstadosTipo], T4.[EstadosGenericosId], T2.[RubrosImagen] FROM (((([ProveedorComision] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Inventario] T4 ON T4.[RubrosId] = T1.[RubrosId] AND T4.[MedidasID] = T1.[MedidasID] AND T4.[InventarioId] = T1.[InventarioId]) LEFT JOIN [EstadosGenericos] T5 ON T5.[EstadosTipo] = T4.[EstadosTipo] AND T5.[EstadosGenericosId] = T4.[EstadosGenericosId]) WHERE T1.[ProveedorID] = @ProveedorID and T1.[ProveedorComisionID] = @ProveedorComisionID ORDER BY T1.[ProveedorID], T1.[ProveedorComisionID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N41,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N42", "SELECT [RubrosImagen_GXI], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N42,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N43", "SELECT [MonedaId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N43,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N44", "SELECT [InventarioNombre], [InventarioPrecioFinal], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N44,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N45", "SELECT [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N45,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N46", "SELECT [ProveedorID], [ProveedorComisionID] FROM [ProveedorComision] WHERE [ProveedorID] = @ProveedorID AND [ProveedorComisionID] = @ProveedorComisionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N46,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N47", "INSERT INTO [ProveedorComision]([ProveedorID], [ProveedorComisionID], [ProveedorComisionAccion], [ProveedorComisionFP], [ProveedorComisionFPF], [ProveedorComisionTipo], [ProveedorComision], [RubrosId], [MedidasID], [InventarioId]) VALUES(@ProveedorID, @ProveedorComisionID, @ProveedorComisionAccion, @ProveedorComisionFP, @ProveedorComisionFPF, @ProveedorComisionTipo, @ProveedorComision, @RubrosId, @MedidasID, @InventarioId)", GxErrorMask.GX_NOMASK,prmT000N47)
           ,new CursorDef("T000N48", "UPDATE [ProveedorComision] SET [ProveedorComisionAccion]=@ProveedorComisionAccion, [ProveedorComisionFP]=@ProveedorComisionFP, [ProveedorComisionFPF]=@ProveedorComisionFPF, [ProveedorComisionTipo]=@ProveedorComisionTipo, [ProveedorComision]=@ProveedorComision, [RubrosId]=@RubrosId, [MedidasID]=@MedidasID, [InventarioId]=@InventarioId  WHERE [ProveedorID] = @ProveedorID AND [ProveedorComisionID] = @ProveedorComisionID", GxErrorMask.GX_NOMASK,prmT000N48)
           ,new CursorDef("T000N49", "DELETE FROM [ProveedorComision]  WHERE [ProveedorID] = @ProveedorID AND [ProveedorComisionID] = @ProveedorComisionID", GxErrorMask.GX_NOMASK,prmT000N49)
           ,new CursorDef("T000N50", "SELECT [RubrosImagen_GXI], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N50,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N51", "SELECT [MonedaId] FROM [RubrosMedidas] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N51,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N52", "SELECT [InventarioNombre], [InventarioPrecioFinal], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE [RubrosId] = @RubrosId AND [MedidasID] = @MedidasID AND [InventarioId] = @InventarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N52,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N53", "SELECT [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N53,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N54", "SELECT [ProveedorID], [ProveedorComisionID] FROM [ProveedorComision] WHERE [ProveedorID] = @ProveedorID ORDER BY [ProveedorID], [ProveedorComisionID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N54,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N55", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N55,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N56", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N56,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N57", "SELECT [ProveedoresTipoId], [ProveedoresTipoNombre] FROM [ProveedoresTipo] ORDER BY [ProveedoresTipoNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N57,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N58", "SELECT [BancoId], [BancoNombre], [BancoEstado] FROM [Banco] WHERE [BancoEstado] = 'HAB' ORDER BY [BancoNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N58,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N59", "SELECT [RubrosId], [RubrosNombre], [RubrosEstado] FROM [Rubros] WHERE [RubrosEstado] <> 'DES' ORDER BY [RubrosNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N59,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N60", "SELECT [RubrosId], [MedidasID], [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE ([RubrosId] = @RubrosId) AND ([MedidasEstado] <> 'DES') ORDER BY [MedidasNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N60,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N61", "SELECT [RubrosId], [MedidasID], [InventarioId], [InventarioNombre], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE ([RubrosId] = @RubrosId and [MedidasID] = @MedidasID) AND ([EstadosGenericosId] = 1) ORDER BY [InventarioNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N61,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N62", "SELECT [ProveedoresTipoId], [ProveedoresTipoNombre] FROM [ProveedoresTipo] ORDER BY [ProveedoresTipoNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N62,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N63", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N63,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N64", "SELECT [SecUserId], [SecUserFullName] FROM [SecUser] ORDER BY [SecUserFullName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N64,0, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getString(6, 1);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
              ((short[]) buf[9])[0] = rslt.getShort(8);
              ((long[]) buf[10])[0] = rslt.getLong(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getString(6, 1);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
              ((short[]) buf[9])[0] = rslt.getShort(8);
              ((long[]) buf[10])[0] = rslt.getLong(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 80);
              ((string[]) buf[10])[0] = rslt.getString(7, 25);
              ((bool[]) buf[11])[0] = rslt.wasNull(7);
              ((string[]) buf[12])[0] = rslt.getString(8, 128);
              ((bool[]) buf[13])[0] = rslt.wasNull(8);
              ((string[]) buf[14])[0] = rslt.getString(9, 20);
              ((bool[]) buf[15])[0] = rslt.wasNull(9);
              ((string[]) buf[16])[0] = rslt.getMultimediaUri(10);
              ((bool[]) buf[17])[0] = rslt.wasNull(10);
              ((string[]) buf[18])[0] = rslt.getString(11, 25);
              ((short[]) buf[19])[0] = rslt.getShort(12);
              ((string[]) buf[20])[0] = rslt.getString(13, 20);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((string[]) buf[22])[0] = rslt.getVarchar(14);
              ((bool[]) buf[23])[0] = rslt.wasNull(14);
              ((string[]) buf[24])[0] = rslt.getVarchar(15);
              ((bool[]) buf[25])[0] = rslt.wasNull(15);
              ((string[]) buf[26])[0] = rslt.getString(16, 128);
              ((bool[]) buf[27])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(17);
              ((bool[]) buf[29])[0] = rslt.wasNull(17);
              ((string[]) buf[30])[0] = rslt.getString(18, 1);
              ((bool[]) buf[31])[0] = rslt.wasNull(18);
              ((string[]) buf[32])[0] = rslt.getString(19, 3);
              ((string[]) buf[33])[0] = rslt.getString(20, 1);
              ((string[]) buf[34])[0] = rslt.getString(21, 1);
              ((bool[]) buf[35])[0] = rslt.wasNull(21);
              ((string[]) buf[36])[0] = rslt.getString(22, 1);
              ((bool[]) buf[37])[0] = rslt.wasNull(22);
              ((string[]) buf[38])[0] = rslt.getString(23, 50);
              ((bool[]) buf[39])[0] = rslt.wasNull(23);
              ((bool[]) buf[40])[0] = rslt.getBool(24);
              ((bool[]) buf[41])[0] = rslt.getBool(25);
              ((bool[]) buf[42])[0] = rslt.wasNull(25);
              ((long[]) buf[43])[0] = rslt.getLong(26);
              ((long[]) buf[44])[0] = rslt.getLong(27);
              ((bool[]) buf[45])[0] = rslt.wasNull(27);
              ((long[]) buf[46])[0] = rslt.getLong(28);
              ((bool[]) buf[47])[0] = rslt.wasNull(28);
              ((string[]) buf[48])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(10));
              ((bool[]) buf[49])[0] = rslt.wasNull(29);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 80);
              ((string[]) buf[10])[0] = rslt.getString(7, 25);
              ((bool[]) buf[11])[0] = rslt.wasNull(7);
              ((string[]) buf[12])[0] = rslt.getString(8, 128);
              ((bool[]) buf[13])[0] = rslt.wasNull(8);
              ((string[]) buf[14])[0] = rslt.getString(9, 20);
              ((bool[]) buf[15])[0] = rslt.wasNull(9);
              ((string[]) buf[16])[0] = rslt.getMultimediaUri(10);
              ((bool[]) buf[17])[0] = rslt.wasNull(10);
              ((string[]) buf[18])[0] = rslt.getString(11, 25);
              ((short[]) buf[19])[0] = rslt.getShort(12);
              ((string[]) buf[20])[0] = rslt.getString(13, 20);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((string[]) buf[22])[0] = rslt.getVarchar(14);
              ((bool[]) buf[23])[0] = rslt.wasNull(14);
              ((string[]) buf[24])[0] = rslt.getVarchar(15);
              ((bool[]) buf[25])[0] = rslt.wasNull(15);
              ((string[]) buf[26])[0] = rslt.getString(16, 128);
              ((bool[]) buf[27])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(17);
              ((bool[]) buf[29])[0] = rslt.wasNull(17);
              ((string[]) buf[30])[0] = rslt.getString(18, 1);
              ((bool[]) buf[31])[0] = rslt.wasNull(18);
              ((string[]) buf[32])[0] = rslt.getString(19, 3);
              ((string[]) buf[33])[0] = rslt.getString(20, 1);
              ((string[]) buf[34])[0] = rslt.getString(21, 1);
              ((bool[]) buf[35])[0] = rslt.wasNull(21);
              ((string[]) buf[36])[0] = rslt.getString(22, 1);
              ((bool[]) buf[37])[0] = rslt.wasNull(22);
              ((string[]) buf[38])[0] = rslt.getString(23, 50);
              ((bool[]) buf[39])[0] = rslt.wasNull(23);
              ((bool[]) buf[40])[0] = rslt.getBool(24);
              ((bool[]) buf[41])[0] = rslt.getBool(25);
              ((bool[]) buf[42])[0] = rslt.wasNull(25);
              ((long[]) buf[43])[0] = rslt.getLong(26);
              ((long[]) buf[44])[0] = rslt.getLong(27);
              ((bool[]) buf[45])[0] = rslt.wasNull(27);
              ((long[]) buf[46])[0] = rslt.getLong(28);
              ((bool[]) buf[47])[0] = rslt.wasNull(28);
              ((string[]) buf[48])[0] = rslt.getMultimediaFile(29, rslt.getVarchar(10));
              ((bool[]) buf[49])[0] = rslt.wasNull(29);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 120);
              ((string[]) buf[10])[0] = rslt.getString(7, 80);
              ((string[]) buf[11])[0] = rslt.getString(8, 25);
              ((bool[]) buf[12])[0] = rslt.wasNull(8);
              ((string[]) buf[13])[0] = rslt.getString(9, 128);
              ((bool[]) buf[14])[0] = rslt.wasNull(9);
              ((string[]) buf[15])[0] = rslt.getString(10, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(10);
              ((string[]) buf[17])[0] = rslt.getMultimediaUri(11);
              ((bool[]) buf[18])[0] = rslt.wasNull(11);
              ((string[]) buf[19])[0] = rslt.getString(12, 25);
              ((short[]) buf[20])[0] = rslt.getShort(13);
              ((string[]) buf[21])[0] = rslt.getString(14, 20);
              ((bool[]) buf[22])[0] = rslt.wasNull(14);
              ((string[]) buf[23])[0] = rslt.getVarchar(15);
              ((bool[]) buf[24])[0] = rslt.wasNull(15);
              ((string[]) buf[25])[0] = rslt.getVarchar(16);
              ((bool[]) buf[26])[0] = rslt.wasNull(16);
              ((string[]) buf[27])[0] = rslt.getString(17, 128);
              ((bool[]) buf[28])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(18);
              ((bool[]) buf[30])[0] = rslt.wasNull(18);
              ((string[]) buf[31])[0] = rslt.getString(19, 1);
              ((bool[]) buf[32])[0] = rslt.wasNull(19);
              ((string[]) buf[33])[0] = rslt.getString(20, 3);
              ((string[]) buf[34])[0] = rslt.getString(21, 1);
              ((string[]) buf[35])[0] = rslt.getString(22, 1);
              ((bool[]) buf[36])[0] = rslt.wasNull(22);
              ((string[]) buf[37])[0] = rslt.getMultimediaUri(23);
              ((string[]) buf[38])[0] = rslt.getString(24, 1);
              ((bool[]) buf[39])[0] = rslt.wasNull(24);
              ((string[]) buf[40])[0] = rslt.getString(25, 50);
              ((bool[]) buf[41])[0] = rslt.wasNull(25);
              ((string[]) buf[42])[0] = rslt.getString(26, 80);
              ((bool[]) buf[43])[0] = rslt.getBool(27);
              ((bool[]) buf[44])[0] = rslt.getBool(28);
              ((bool[]) buf[45])[0] = rslt.wasNull(28);
              ((long[]) buf[46])[0] = rslt.getLong(29);
              ((long[]) buf[47])[0] = rslt.getLong(30);
              ((bool[]) buf[48])[0] = rslt.wasNull(30);
              ((long[]) buf[49])[0] = rslt.getLong(31);
              ((bool[]) buf[50])[0] = rslt.wasNull(31);
              ((string[]) buf[51])[0] = rslt.getMultimediaFile(32, rslt.getVarchar(11));
              ((bool[]) buf[52])[0] = rslt.wasNull(32);
              ((string[]) buf[53])[0] = rslt.getMultimediaFile(33, rslt.getVarchar(23));
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
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
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 120);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 26 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 31 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 32 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 33 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 34 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 35 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 36 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 38 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 39 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 80);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getString(10, 1);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
              ((short[]) buf[13])[0] = rslt.getShort(12);
              ((long[]) buf[14])[0] = rslt.getLong(13);
              ((long[]) buf[15])[0] = rslt.getLong(14);
              ((bool[]) buf[16])[0] = rslt.wasNull(14);
              ((short[]) buf[17])[0] = rslt.getShort(15);
              ((string[]) buf[18])[0] = rslt.getString(16, 3);
              ((int[]) buf[19])[0] = rslt.getInt(17);
              ((string[]) buf[20])[0] = rslt.getMultimediaFile(18, rslt.getVarchar(4));
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 41 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 42 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 43 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 44 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 48 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getMultimediaFile(2, rslt.getVarchar(1));
              return;
           case 49 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 50 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 51 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 52 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 53 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 54 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 55 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              return;
           case 56 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 57 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 58 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              return;
           case 59 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
     }
     getresults60( cursor, rslt, buf) ;
  }

  public void getresults60( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 60 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 120);
              return;
           case 61 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 62 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
     }
  }

}

}

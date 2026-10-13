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
   public class costoservicios : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action15") == 0 )
         {
            AV8CentroCostosRef = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosRef"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8CentroCostosRef", StringUtil.LTrimStr( (decimal)(AV8CentroCostosRef), 18, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vCENTROCOSTOSREF", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"), context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_15_0P69( AV8CentroCostosRef) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action16") == 0 )
         {
            AV8CentroCostosRef = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosRef"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8CentroCostosRef", StringUtil.LTrimStr( (decimal)(AV8CentroCostosRef), 18, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vCENTROCOSTOSREF", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"), context));
            AV14CentroCostosPrecioFinal = NumberUtil.Val( GetPar( "CentroCostosPrecioFinal"), ".");
            AssignAttri("", false, "AV14CentroCostosPrecioFinal", StringUtil.LTrimStr( AV14CentroCostosPrecioFinal, 18, 2));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_16_0P69( AV8CentroCostosRef, AV14CentroCostosPrecioFinal) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action19") == 0 )
         {
            A461CentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_19_0P69( A461CentroCostosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action48") == 0 )
         {
            A461CentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
            A466CentroCostosDetallesId = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosDetallesId"), "."), 18, MidpointRounding.ToEven));
            A892CentroCostosDetallesFecha = context.localUtil.ParseDateParm( GetPar( "CentroCostosDetallesFecha"));
            A893CentroCostosDetallesEstado = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosDetallesEstado"), "."), 18, MidpointRounding.ToEven));
            A473CentroCostosDetallesNombre = GetPar( "CentroCostosDetallesNombre");
            A468CentroCostosDetallesValor = NumberUtil.Val( GetPar( "CentroCostosDetallesValor"), ".");
            A890CCDetallesProfId = GetPar( "CCDetallesProfId");
            AV8CentroCostosRef = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosRef"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8CentroCostosRef", StringUtil.LTrimStr( (decimal)(AV8CentroCostosRef), 18, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vCENTROCOSTOSREF", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"), context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_48_0P70( A461CentroCostosId, A466CentroCostosDetallesId, A892CentroCostosDetallesFecha, A893CentroCostosDetallesEstado, A473CentroCostosDetallesNombre, A468CentroCostosDetallesValor, A890CCDetallesProfId, AV8CentroCostosRef) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel5"+"_"+"vFECHACIERRESOLICITUD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX5ASAFECHACIERRESOLICITUD0P69( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel13"+"_"+"vSOLICITUDESIDCOLLECTION") == 0 )
         {
            AV8CentroCostosRef = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosRef"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8CentroCostosRef", StringUtil.LTrimStr( (decimal)(AV8CentroCostosRef), 18, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vCENTROCOSTOSREF", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"), context));
            AV31FechaCierreSolicitud = context.localUtil.ParseDateParm( GetPar( "FechaCierreSolicitud"));
            AssignAttri("", false, "AV31FechaCierreSolicitud", context.localUtil.Format(AV31FechaCierreSolicitud, "99/99/99"));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX13ASASOLICITUDESIDCOLLECTION0P69( AV8CentroCostosRef, AV31FechaCierreSolicitud) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_50") == 0 )
         {
            A461CentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_50( A461CentroCostosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_52") == 0 )
         {
            A459ListaCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "ListaCostosId"), "."), 18, MidpointRounding.ToEven));
            n459ListaCostosId = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_52( A459ListaCostosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_53") == 0 )
         {
            A890CCDetallesProfId = GetPar( "CCDetallesProfId");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_53( A890CCDetallesProfId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_detalles") == 0 )
         {
            gxnrGridlevel_detalles_newrow_invoke( ) ;
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
               AV7CentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7CentroCostosId", StringUtil.LTrimStr( (decimal)(AV7CentroCostosId), 18, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCENTROCOSTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
               AV8CentroCostosRef = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosRef"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8CentroCostosRef", StringUtil.LTrimStr( (decimal)(AV8CentroCostosRef), 18, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCENTROCOSTOSREF", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Costo Servicios", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCentroCostosNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_detalles_newrow_invoke( )
      {
         nRC_GXsfl_65 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_65"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_65_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_65_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_65_idx = GetPar( "sGXsfl_65_idx");
         A465CentroCostosSerial = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosSerial"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         AV31FechaCierreSolicitud = context.localUtil.ParseDateParm( GetPar( "FechaCierreSolicitud"));
         AV32RoleName = GetPar( "RoleName");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_detalles_newrow( ) ;
         /* End function gxnrGridlevel_detalles_newrow_invoke */
      }

      public costoservicios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public costoservicios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_CentroCostosId ,
                           long aP2_CentroCostosRef )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CentroCostosId = aP1_CentroCostosId;
         this.AV8CentroCostosRef = aP2_CentroCostosRef;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCentroCostosTipoRef = new GXCombobox();
         cmbCentroCostosDetallesEstado = new GXCombobox();
         chkavError = new GXCheckbox();
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
         if ( cmbCentroCostosTipoRef.ItemCount > 0 )
         {
            A487CentroCostosTipoRef = cmbCentroCostosTipoRef.getValidValue(A487CentroCostosTipoRef);
            AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCentroCostosTipoRef.CurrentValue = StringUtil.RTrim( A487CentroCostosTipoRef);
            AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Values", cmbCentroCostosTipoRef.ToJavascriptSource(), true);
         }
         AV35Error = StringUtil.StrToBool( StringUtil.BoolToStr( AV35Error));
         AssignAttri("", false, "AV35Error", AV35Error);
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosId_Internalname, context.GetMessage( "Código CC:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CostoServicios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 hidden-xs hidden-sm hidden-md hidden-lg DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbCentroCostosTipoRef_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCentroCostosTipoRef_Internalname, context.GetMessage( "Tipo Referencia:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCentroCostosTipoRef, cmbCentroCostosTipoRef_Internalname, StringUtil.RTrim( A487CentroCostosTipoRef), 1, cmbCentroCostosTipoRef_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbCentroCostosTipoRef.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "", true, 0, "HLP_CostoServicios.htm");
         cmbCentroCostosTipoRef.CurrentValue = StringUtil.RTrim( A487CentroCostosTipoRef);
         AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Values", (string)(cmbCentroCostosTipoRef.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosRef_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosRef_Internalname, context.GetMessage( "Referencia Nro:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosRef_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A462CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosRef_Enabled!=0) ? context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosRef_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosRef_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_CostoServicios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCentrocostosnombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtavCentrocostosnombre_Internalname, context.GetMessage( "NOMBRE", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCentrocostosnombre_Internalname, AV13CentroCostosNombre, StringUtil.RTrim( context.localUtil.Format( AV13CentroCostosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCentrocostosnombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCentrocostosnombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_CostoServicios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCentrocostospreciofinal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtavCentrocostospreciofinal_Internalname, context.GetMessage( "Precio Final", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCentrocostospreciofinal_Internalname, StringUtil.LTrim( StringUtil.NToC( AV14CentroCostosPrecioFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCentrocostospreciofinal_Enabled!=0) ? context.localUtil.Format( AV14CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( AV14CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCentrocostospreciofinal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavCentrocostospreciofinal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_CostoServicios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosSubTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosSubTotal_Internalname, context.GetMessage( "Sub Total", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosSubTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A469CentroCostosSubTotal, 22, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosSubTotal_Enabled!=0) ? context.localUtil.Format( A469CentroCostosSubTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A469CentroCostosSubTotal, "ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosSubTotal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosSubTotal_Enabled, 0, "text", "", 22, "chr", 1, "row", 22, 0, 0, 0, 0, -1, 0, true, "Total", "end", false, "", "HLP_CostoServicios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-6 hidden-sm hidden-md hidden-lg DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosNombre_Internalname, context.GetMessage( "Nombre:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosNombre_Internalname, StringUtil.RTrim( A463CentroCostosNombre), StringUtil.RTrim( context.localUtil.Format( A463CentroCostosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosNombre_Enabled, 1, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_CostoServicios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-6 hidden-sm hidden-md hidden-lg DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCentroCostosPrecioFinal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentroCostosPrecioFinal_Internalname, context.GetMessage( "Precio Final:", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentroCostosPrecioFinal_Internalname, StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtCentroCostosPrecioFinal_Enabled!=0) ? context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentroCostosPrecioFinal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCentroCostosPrecioFinal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_CostoServicios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavFechacierresolicitud_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtavFechacierresolicitud_Internalname, context.GetMessage( "Cierre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtavFechacierresolicitud_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtavFechacierresolicitud_Internalname, context.localUtil.Format(AV31FechaCierreSolicitud, "99/99/99"), context.localUtil.Format( AV31FechaCierreSolicitud, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFechacierresolicitud_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavFechacierresolicitud_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_CostoServicios.htm");
         GxWebStd.gx_bitmap( context, edtavFechacierresolicitud_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFechacierresolicitud_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_CostoServicios.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, lblTextblock2_Caption, "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_CostoServicios.htm");
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
         GxWebStd.gx_div_start( context, divTableleaflevel_detalles_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_detalles( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, " ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CostoServicios.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CostoServicios.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CostoServicios.htm");
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
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkavError_Internalname, StringUtil.BoolToStr( AV35Error), "", "", chkavError.Visible, chkavError.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(88, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,88);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_detalles( )
      {
         /*  Grid Control  */
         StartGridControl65( ) ;
         nGXsfl_65_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount70 = 3;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_70 = 1;
               ScanStart0P70( ) ;
               while ( RcdFound70 != 0 )
               {
                  init_level_properties70( ) ;
                  getByPrimaryKey0P70( ) ;
                  AddRow0P70( ) ;
                  ScanNext0P70( ) ;
               }
               ScanEnd0P70( ) ;
               nBlankRcdCount70 = 3;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B465CentroCostosSerial = A465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            B469CentroCostosSubTotal = A469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            standaloneNotModal0P70( ) ;
            standaloneModal0P70( ) ;
            sMode70 = Gx_mode;
            while ( nGXsfl_65_idx < nRC_GXsfl_65 )
            {
               bGXsfl_65_Refreshing = true;
               ReadRow0P70( ) ;
               edtCentroCostosDetallesFecha_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESFECHA_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCentroCostosDetallesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtCentroCostosDetallesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESID_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtListaCostosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "LISTACOSTOSID_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtCentroCostosDetallesNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCentroCostosDetallesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtCentroCostosDetallesValor_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCentroCostosDetallesValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtCentroCostosDetallesSolId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESSOLID_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCentroCostosDetallesSolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesSolId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtCCDetallesProfId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CCDETALLESPROFID_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCCDetallesProfId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCDetallesProfId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               edtCCDetallesProfNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CCDETALLESPROFNOMBRE_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtCCDetallesProfNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCDetallesProfNombre_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               cmbCentroCostosDetallesEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESESTADO_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbCentroCostosDetallesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0), !bGXsfl_65_Refreshing);
               imgprompt_459_Link = cgiGet( "PROMPT_459_"+sGXsfl_65_idx+"Link");
               imgprompt_459_Link = cgiGet( "PROMPT_890_"+sGXsfl_65_idx+"Link");
               if ( ( nRcdExists_70 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0P70( ) ;
               }
               SendRow0P70( ) ;
               bGXsfl_65_Refreshing = false;
            }
            Gx_mode = sMode70;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A465CentroCostosSerial = B465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            A469CentroCostosSubTotal = B469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount70 = 3;
            nRcdExists_70 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0P70( ) ;
               while ( RcdFound70 != 0 )
               {
                  sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_6570( ) ;
                  init_level_properties70( ) ;
                  standaloneNotModal0P70( ) ;
                  getByPrimaryKey0P70( ) ;
                  standaloneModal0P70( ) ;
                  AddRow0P70( ) ;
                  ScanNext0P70( ) ;
               }
               ScanEnd0P70( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode70 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx+1), 4, 0), 4, "0");
            SubsflControlProps_6570( ) ;
            InitAll0P70( ) ;
            init_level_properties70( ) ;
            B465CentroCostosSerial = A465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            B469CentroCostosSubTotal = A469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            nRcdExists_70 = 0;
            nIsMod_70 = 0;
            nRcdDeleted_70 = 0;
            nBlankRcdCount70 = (short)(nBlankRcdUsr70+nBlankRcdCount70);
            fRowAdded = 0;
            while ( nBlankRcdCount70 > 0 )
            {
               standaloneNotModal0P70( ) ;
               standaloneModal0P70( ) ;
               AddRow0P70( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtCentroCostosDetallesFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount70 = (short)(nBlankRcdCount70-1);
            }
            Gx_mode = sMode70;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A465CentroCostosSerial = B465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            A469CentroCostosSubTotal = B469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_detallesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_detalles", Gridlevel_detallesContainer, subGridlevel_detalles_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_detallesContainerData", Gridlevel_detallesContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_detallesContainerData"+"V", Gridlevel_detallesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_detallesContainerData"+"V"+"\" value='"+Gridlevel_detallesContainer.GridValuesHidden()+"'/>") ;
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
         E110P2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z461CentroCostosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z487CentroCostosTipoRef = cgiGet( "Z487CentroCostosTipoRef");
               Z462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z462CentroCostosRef"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z475CentroCostosCosto = context.localUtil.CToN( cgiGet( "Z475CentroCostosCosto"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z463CentroCostosNombre = cgiGet( "Z463CentroCostosNombre");
               Z464CentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( "Z464CentroCostosPrecioFinal"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z465CentroCostosSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z465CentroCostosSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z478CentroCostosUsrAlta = cgiGet( "Z478CentroCostosUsrAlta");
               Z479CentroCostosUsrMod = cgiGet( "Z479CentroCostosUsrMod");
               Z480CentroCostosHoraAlt = context.localUtil.CToD( cgiGet( "Z480CentroCostosHoraAlt"), 0);
               Z481CentroCostosHoraMod = context.localUtil.CToD( cgiGet( "Z481CentroCostosHoraMod"), 0);
               Z482CentroCostosEstado = cgiGet( "Z482CentroCostosEstado");
               A475CentroCostosCosto = context.localUtil.CToN( cgiGet( "Z475CentroCostosCosto"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A465CentroCostosSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z465CentroCostosSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A478CentroCostosUsrAlta = cgiGet( "Z478CentroCostosUsrAlta");
               A479CentroCostosUsrMod = cgiGet( "Z479CentroCostosUsrMod");
               A480CentroCostosHoraAlt = context.localUtil.CToD( cgiGet( "Z480CentroCostosHoraAlt"), 0);
               A481CentroCostosHoraMod = context.localUtil.CToD( cgiGet( "Z481CentroCostosHoraMod"), 0);
               A482CentroCostosEstado = cgiGet( "Z482CentroCostosEstado");
               O465CentroCostosSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( "O465CentroCostosSerial"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O469CentroCostosSubTotal = context.localUtil.CToN( cgiGet( "O469CentroCostosSubTotal"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_65 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_65"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A475CentroCostosCosto = context.localUtil.CToN( cgiGet( "CENTROCOSTOSCOSTO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A474CentroCostosGam = context.localUtil.CToN( cgiGet( "CENTROCOSTOSGAM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AV7CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCENTROCOSTOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV32RoleName = cgiGet( "vROLENAME");
               AV8CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vCENTROCOSTOSREF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               ajax_req_read_hidden_sdt(cgiGet( "vSOLICITUDESIDCOLLECTION"), AV36SolicitudesIdCollection);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A482CentroCostosEstado = cgiGet( "CENTROCOSTOSESTADO");
               A465CentroCostosSerial = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSSERIAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A889CentroCostosJson = cgiGet( "CENTROCOSTOSJSON");
               A478CentroCostosUsrAlta = cgiGet( "CENTROCOSTOSUSRALTA");
               A479CentroCostosUsrMod = cgiGet( "CENTROCOSTOSUSRMOD");
               A480CentroCostosHoraAlt = context.localUtil.CToD( cgiGet( "CENTROCOSTOSHORAALT"), 0);
               A481CentroCostosHoraMod = context.localUtil.CToD( cgiGet( "CENTROCOSTOSHORAMOD"), 0);
               AV40Pgmname = cgiGet( "vPGMNAME");
               A167ProfesionalesApellidoPrimero = cgiGet( "PROFESIONALESAPELLIDOPRIMERO");
               n167ProfesionalesApellidoPrimero = false;
               A166ProfesionalesPrimerNombre = cgiGet( "PROFESIONALESPRIMERNOMBRE");
               n166ProfesionalesPrimerNombre = false;
               A191ProfesionalesSegundoNombre = cgiGet( "PROFESIONALESSEGUNDONOMBRE");
               n191ProfesionalesSegundoNombre = false;
               AV23NewSolicitudId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vNEWSOLICITUDID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV24IsOk = StringUtil.StrToBool( cgiGet( "vISOK"));
               AV25TxtMsg = cgiGet( "vTXTMSG");
               A460ListaCostosNombre = cgiGet( "LISTACOSTOSNOMBRE");
               A471ListaCostosValor = context.localUtil.CToN( cgiGet( "LISTACOSTOSVALOR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               /* Read variables values. */
               A461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
               cmbCentroCostosTipoRef.Name = cmbCentroCostosTipoRef_Internalname;
               cmbCentroCostosTipoRef.CurrentValue = cgiGet( cmbCentroCostosTipoRef_Internalname);
               A487CentroCostosTipoRef = cgiGet( cmbCentroCostosTipoRef_Internalname);
               AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
               A462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosRef_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
               AV13CentroCostosNombre = cgiGet( edtavCentrocostosnombre_Internalname);
               AssignAttri("", false, "AV13CentroCostosNombre", AV13CentroCostosNombre);
               AV14CentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( edtavCentrocostospreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV14CentroCostosPrecioFinal", StringUtil.LTrimStr( AV14CentroCostosPrecioFinal, 18, 2));
               A469CentroCostosSubTotal = context.localUtil.CToN( cgiGet( edtCentroCostosSubTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               A463CentroCostosNombre = cgiGet( edtCentroCostosNombre_Internalname);
               AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
               A464CentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( edtCentroCostosPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
               AV31FechaCierreSolicitud = context.localUtil.CToD( cgiGet( edtavFechacierresolicitud_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV31FechaCierreSolicitud", context.localUtil.Format(AV31FechaCierreSolicitud, "99/99/99"));
               AV35Error = StringUtil.StrToBool( cgiGet( chkavError_Internalname));
               AssignAttri("", false, "AV35Error", AV35Error);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CostoServicios");
               A461CentroCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
               forbiddenHiddens.Add("CentroCostosId", context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"));
               A487CentroCostosTipoRef = cgiGet( cmbCentroCostosTipoRef_Internalname);
               AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
               forbiddenHiddens.Add("CentroCostosTipoRef", StringUtil.RTrim( context.localUtil.Format( A487CentroCostosTipoRef, "")));
               A462CentroCostosRef = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosRef_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
               forbiddenHiddens.Add("CentroCostosRef", context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"));
               A464CentroCostosPrecioFinal = context.localUtil.CToN( cgiGet( edtCentroCostosPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
               forbiddenHiddens.Add("CentroCostosPrecioFinal", context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               AV31FechaCierreSolicitud = context.localUtil.CToD( cgiGet( edtavFechacierresolicitud_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV31FechaCierreSolicitud", context.localUtil.Format(AV31FechaCierreSolicitud, "99/99/99"));
               forbiddenHiddens.Add("FechaCierreSolicitud", context.localUtil.Format(AV31FechaCierreSolicitud, "99/99/99"));
               forbiddenHiddens.Add("RoleName", StringUtil.RTrim( context.localUtil.Format( AV32RoleName, "")));
               forbiddenHiddens.Add("CentroCostosUsrAlta", StringUtil.RTrim( context.localUtil.Format( A478CentroCostosUsrAlta, "")));
               forbiddenHiddens.Add("CentroCostosUsrMod", StringUtil.RTrim( context.localUtil.Format( A479CentroCostosUsrMod, "")));
               forbiddenHiddens.Add("CentroCostosHoraAlt", context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"));
               forbiddenHiddens.Add("CentroCostosHoraMod", context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"));
               forbiddenHiddens.Add("CentroCostosEstado", StringUtil.RTrim( context.localUtil.Format( A482CentroCostosEstado, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A461CentroCostosId != Z461CentroCostosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("costoservicios:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A461CentroCostosId = (long)(Math.Round(NumberUtil.Val( GetPar( "CentroCostosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
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
                     sMode69 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode69;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound69 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0P0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CENTROCOSTOSID");
                        AnyError = 1;
                        GX_FocusControl = edtCentroCostosId_Internalname;
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
                           E110P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'NUEVO ITEM'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'Nuevo Item' */
                           E130P2 ();
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
                        if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 31), "CENTROCOSTOSDETALLESFECHA.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 31), "CENTROCOSTOSDETALLESFECHA.CLICK") == 0 ) )
                        {
                           nGXsfl_65_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
                           SubsflControlProps_6570( ) ;
                           if ( context.localUtil.VCDate( cgiGet( edtCentroCostosDetallesFecha_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
                           {
                              GXCCtl = "CENTROCOSTOSDETALLESFECHA_" + sGXsfl_65_idx;
                              GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Costo Servicios Detalles Fecha", "")}), 1, GXCCtl);
                              AnyError = 1;
                              GX_FocusControl = edtCentroCostosDetallesFecha_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                              wbErr = true;
                              A892CentroCostosDetallesFecha = DateTime.MinValue;
                           }
                           else
                           {
                              A892CentroCostosDetallesFecha = context.localUtil.CToD( cgiGet( edtCentroCostosDetallesFecha_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                           }
                           A466CentroCostosDetallesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosDetallesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           if ( ( ( context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
                           {
                              GXCCtl = "LISTACOSTOSID_" + sGXsfl_65_idx;
                              GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
                              AnyError = 1;
                              GX_FocusControl = edtListaCostosId_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                              wbErr = true;
                              A459ListaCostosId = 0;
                              n459ListaCostosId = false;
                           }
                           else
                           {
                              A459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n459ListaCostosId = false;
                           }
                           n459ListaCostosId = ((0==A459ListaCostosId) ? true : false);
                           A473CentroCostosDetallesNombre = cgiGet( edtCentroCostosDetallesNombre_Internalname);
                           if ( ( ( context.localUtil.CToN( cgiGet( edtCentroCostosDetallesValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCentroCostosDetallesValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
                           {
                              GXCCtl = "CENTROCOSTOSDETALLESVALOR_" + sGXsfl_65_idx;
                              GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
                              AnyError = 1;
                              GX_FocusControl = edtCentroCostosDetallesValor_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                              wbErr = true;
                              A468CentroCostosDetallesValor = 0;
                           }
                           else
                           {
                              A468CentroCostosDetallesValor = context.localUtil.CToN( cgiGet( edtCentroCostosDetallesValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                           }
                           A888CentroCostosDetallesSolId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosDetallesSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           A890CCDetallesProfId = cgiGet( edtCCDetallesProfId_Internalname);
                           A891CCDetallesProfNombre = cgiGet( edtCCDetallesProfNombre_Internalname);
                           cmbCentroCostosDetallesEstado.Name = cmbCentroCostosDetallesEstado_Internalname;
                           cmbCentroCostosDetallesEstado.CurrentValue = cgiGet( cmbCentroCostosDetallesEstado_Internalname);
                           A893CentroCostosDetallesEstado = (long)(Math.Round(NumberUtil.Val( cgiGet( cmbCentroCostosDetallesEstado_Internalname), "."), 18, MidpointRounding.ToEven));
                           GXCCtl = "Z466CentroCostosDetallesId_" + sGXsfl_65_idx;
                           Z466CentroCostosDetallesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "Z893CentroCostosDetallesEstado_" + sGXsfl_65_idx;
                           Z893CentroCostosDetallesEstado = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "Z473CentroCostosDetallesNombre_" + sGXsfl_65_idx;
                           Z473CentroCostosDetallesNombre = cgiGet( GXCCtl);
                           GXCCtl = "Z468CentroCostosDetallesValor_" + sGXsfl_65_idx;
                           Z468CentroCostosDetallesValor = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                           GXCCtl = "Z892CentroCostosDetallesFecha_" + sGXsfl_65_idx;
                           Z892CentroCostosDetallesFecha = context.localUtil.CToD( cgiGet( GXCCtl), 0);
                           GXCCtl = "Z888CentroCostosDetallesSolId_" + sGXsfl_65_idx;
                           Z888CentroCostosDetallesSolId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "Z459ListaCostosId_" + sGXsfl_65_idx;
                           Z459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           n459ListaCostosId = ((0==A459ListaCostosId) ? true : false);
                           GXCCtl = "Z890CCDetallesProfId_" + sGXsfl_65_idx;
                           Z890CCDetallesProfId = cgiGet( GXCCtl);
                           GXCCtl = "O468CentroCostosDetallesValor_" + sGXsfl_65_idx;
                           O468CentroCostosDetallesValor = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                           GXCCtl = "nRcdDeleted_70_" + sGXsfl_65_idx;
                           nRcdDeleted_70 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "nRcdExists_70_" + sGXsfl_65_idx;
                           nRcdExists_70 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "nIsMod_70_" + sGXsfl_65_idx;
                           nIsMod_70 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "N466CentroCostosDetallesId_" + sGXsfl_65_idx;
                           N466CentroCostosDetallesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           GXCCtl = "N892CentroCostosDetallesFecha_" + sGXsfl_65_idx;
                           N892CentroCostosDetallesFecha = context.localUtil.CToD( cgiGet( GXCCtl), 0);
                           GXCCtl = "N459ListaCostosId_" + sGXsfl_65_idx;
                           N459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           n459ListaCostosId = ((0==A459ListaCostosId) ? true : false);
                           GXCCtl = "N473CentroCostosDetallesNombre_" + sGXsfl_65_idx;
                           N473CentroCostosDetallesNombre = cgiGet( GXCCtl);
                           GXCCtl = "N468CentroCostosDetallesValor_" + sGXsfl_65_idx;
                           N468CentroCostosDetallesValor = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                           GXCCtl = "N890CCDetallesProfId_" + sGXsfl_65_idx;
                           N890CCDetallesProfId = cgiGet( GXCCtl);
                           GXCCtl = "N893CentroCostosDetallesEstado_" + sGXsfl_65_idx;
                           N893CentroCostosDetallesEstado = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                           sEvtType = StringUtil.Right( sEvt, 1);
                           if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                           {
                              sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                              if ( StringUtil.StrCmp(sEvt, "CENTROCOSTOSDETALLESFECHA.CLICK") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 E140P2 ();
                              }
                           }
                           else
                           {
                           }
                        }
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
            E120P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0P69( ) ;
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
         if ( IsDsp( ) || IsDlt( ) )
         {
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0P69( ) ;
         }
         AssignProp("", false, edtavCentrocostosnombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCentrocostosnombre_Enabled), 5, 0), true);
         AssignProp("", false, edtavCentrocostospreciofinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCentrocostospreciofinal_Enabled), 5, 0), true);
         AssignProp("", false, edtavFechacierresolicitud_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFechacierresolicitud_Enabled), 5, 0), true);
         AssignProp("", false, chkavError_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavError.Enabled), 5, 0), true);
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

      protected void CONFIRM_0P0( )
      {
         BeforeValidate0P69( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0P69( ) ;
            }
            else
            {
               CheckExtendedTable0P69( ) ;
               CloseExtendedTableCursors0P69( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode69 = Gx_mode;
            CONFIRM_0P70( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode69;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode69;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0P70( )
      {
         s465CentroCostosSerial = O465CentroCostosSerial;
         AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         s469CentroCostosSubTotal = O469CentroCostosSubTotal;
         n469CentroCostosSubTotal = false;
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         s475CentroCostosCosto = O475CentroCostosCosto;
         AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         nGXsfl_65_idx = 0;
         while ( nGXsfl_65_idx < nRC_GXsfl_65 )
         {
            ReadRow0P70( ) ;
            if ( ( nRcdExists_70 != 0 ) || ( nIsMod_70 != 0 ) )
            {
               GetKey0P70( ) ;
               if ( ( nRcdExists_70 == 0 ) && ( nRcdDeleted_70 == 0 ) )
               {
                  if ( RcdFound70 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0P70( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0P70( ) ;
                        CloseExtendedTableCursors0P70( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O465CentroCostosSerial = A465CentroCostosSerial;
                        AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                        O469CentroCostosSubTotal = A469CentroCostosSubTotal;
                        n469CentroCostosSubTotal = false;
                        AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                        O475CentroCostosCosto = A475CentroCostosCosto;
                        AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
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
                  if ( RcdFound70 != 0 )
                  {
                     if ( nRcdDeleted_70 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0P70( ) ;
                        Load0P70( ) ;
                        BeforeValidate0P70( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0P70( ) ;
                           O465CentroCostosSerial = A465CentroCostosSerial;
                           AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                           O469CentroCostosSubTotal = A469CentroCostosSubTotal;
                           n469CentroCostosSubTotal = false;
                           AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                           O475CentroCostosCosto = A475CentroCostosCosto;
                           AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
                        }
                     }
                     else
                     {
                        if ( nIsMod_70 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0P70( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0P70( ) ;
                              CloseExtendedTableCursors0P70( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O465CentroCostosSerial = A465CentroCostosSerial;
                              AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                              O469CentroCostosSubTotal = A469CentroCostosSubTotal;
                              n469CentroCostosSubTotal = false;
                              AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                              O475CentroCostosCosto = A475CentroCostosCosto;
                              AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_70 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtCentroCostosDetallesFecha_Internalname, context.localUtil.Format(A892CentroCostosDetallesFecha, "99/99/99")) ;
            ChangePostValue( edtCentroCostosDetallesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtListaCostosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCentroCostosDetallesNombre_Internalname, StringUtil.RTrim( A473CentroCostosDetallesNombre)) ;
            ChangePostValue( edtCentroCostosDetallesValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCentroCostosDetallesSolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A888CentroCostosDetallesSolId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCCDetallesProfId_Internalname, StringUtil.RTrim( A890CCDetallesProfId)) ;
            ChangePostValue( edtCCDetallesProfNombre_Internalname, A891CCDetallesProfNombre) ;
            ChangePostValue( cmbCentroCostosDetallesEstado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A893CentroCostosDetallesEstado), 18, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z466CentroCostosDetallesId_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z893CentroCostosDetallesEstado_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z893CentroCostosDetallesEstado), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z473CentroCostosDetallesNombre_"+sGXsfl_65_idx, StringUtil.RTrim( Z473CentroCostosDetallesNombre)) ;
            ChangePostValue( "ZT_"+"Z468CentroCostosDetallesValor_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( Z468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z892CentroCostosDetallesFecha_"+sGXsfl_65_idx, context.localUtil.DToC( Z892CentroCostosDetallesFecha, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z888CentroCostosDetallesSolId_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z888CentroCostosDetallesSolId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z459ListaCostosId_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z890CCDetallesProfId_"+sGXsfl_65_idx, StringUtil.RTrim( Z890CCDetallesProfId)) ;
            ChangePostValue( "T468CentroCostosDetallesValor_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( O468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_70_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_70), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_70_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_70), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_70_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_70), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "N466CentroCostosDetallesId_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "N892CentroCostosDetallesFecha_"+sGXsfl_65_idx, context.localUtil.DToC( A892CentroCostosDetallesFecha, 0, "/")) ;
            ChangePostValue( "N459ListaCostosId_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "N473CentroCostosDetallesNombre_"+sGXsfl_65_idx, StringUtil.RTrim( A473CentroCostosDetallesNombre)) ;
            ChangePostValue( "N468CentroCostosDetallesValor_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "N890CCDetallesProfId_"+sGXsfl_65_idx, StringUtil.RTrim( A890CCDetallesProfId)) ;
            ChangePostValue( "N893CentroCostosDetallesEstado_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(A893CentroCostosDetallesEstado), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_70 != 0 )
            {
               ChangePostValue( "CENTROCOSTOSDETALLESFECHA_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESID_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LISTACOSTOSID_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaCostosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESSOLID_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesSolId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CCDETALLESPROFID_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCCDetallesProfId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CCDETALLESPROFNOMBRE_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCCDetallesProfNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESESTADO_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O465CentroCostosSerial = s465CentroCostosSerial;
         AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         O469CentroCostosSubTotal = s469CentroCostosSubTotal;
         n469CentroCostosSubTotal = false;
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         O475CentroCostosCosto = s475CentroCostosCosto;
         AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0P0( )
      {
      }

      protected void E110P2( )
      {
         /* Start Routine */
         returnInSub = false;
         imgNuevoitem_gximage = "ActionNewDynamicFilter";
         AssignProp("", false, imgNuevoitem_Internalname, "gximage", imgNuevoitem_gximage, true);
         AV15NuevoItem = context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( ));
         AssignAttri("", false, "AV15NuevoItem", AV15NuevoItem);
         AV39Nuevoitem_GXI = GXDbFile.PathToUrl( context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )), context);
         lblTextblock2_Caption = context.GetMessage( "<script>document.getElementById('TABLEMAIN').style.minWidth='900px';</script>", "");
         AssignProp("", false, lblTextblock2_Internalname, "Caption", lblTextblock2_Caption, true);
         if ( ! AV35Error )
         {
            AV11WebSession.Set(context.GetMessage( "Error", ""), context.GetMessage( "NO", ""));
         }
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV16WWPContext) ;
         AV9IsAuthorized = true;
         AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Insert", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Update", out  GXt_boolean1) ;
            AV9IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV9IsAuthorized", AV9IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV9IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos_Delete", out  GXt_boolean1) ;
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
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
         chkavError.Visible = 0;
         AssignProp("", false, chkavError_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavError.Visible), 5, 0), true);
      }

      protected void E120P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV11WebSession.Set(context.GetMessage( "Error", ""), context.GetMessage( "NO", ""));
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E130P2( )
      {
         /* 'Nuevo Item' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "listacostos.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("listacostos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E140P2( )
      {
         /* CentroCostosDetallesFecha_Click Routine */
         returnInSub = false;
         if ( ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) && ! (DateTime.MinValue==A892CentroCostosDetallesFecha) && ! AV35Error )
         {
            if ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) )
            {
               AV11WebSession.Set(context.GetMessage( "Error", ""), context.GetMessage( "SI", ""));
               AV35Error = true;
               AssignAttri("", false, "AV35Error", AV35Error);
               this.executeExternalObjectMethod("", false, "GlobalEvents", "FechaAnteriorCierre", new Object[] {}, true);
            }
         }
         /*  Sending Event outputs  */
      }

      protected void ZM0P69( short GX_JID )
      {
         if ( ( GX_JID == 49 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z487CentroCostosTipoRef = T000P7_A487CentroCostosTipoRef[0];
               Z462CentroCostosRef = T000P7_A462CentroCostosRef[0];
               Z475CentroCostosCosto = T000P7_A475CentroCostosCosto[0];
               Z463CentroCostosNombre = T000P7_A463CentroCostosNombre[0];
               Z464CentroCostosPrecioFinal = T000P7_A464CentroCostosPrecioFinal[0];
               Z465CentroCostosSerial = T000P7_A465CentroCostosSerial[0];
               Z478CentroCostosUsrAlta = T000P7_A478CentroCostosUsrAlta[0];
               Z479CentroCostosUsrMod = T000P7_A479CentroCostosUsrMod[0];
               Z480CentroCostosHoraAlt = T000P7_A480CentroCostosHoraAlt[0];
               Z481CentroCostosHoraMod = T000P7_A481CentroCostosHoraMod[0];
               Z482CentroCostosEstado = T000P7_A482CentroCostosEstado[0];
            }
            else
            {
               Z487CentroCostosTipoRef = A487CentroCostosTipoRef;
               Z462CentroCostosRef = A462CentroCostosRef;
               Z475CentroCostosCosto = A475CentroCostosCosto;
               Z463CentroCostosNombre = A463CentroCostosNombre;
               Z464CentroCostosPrecioFinal = A464CentroCostosPrecioFinal;
               Z465CentroCostosSerial = A465CentroCostosSerial;
               Z478CentroCostosUsrAlta = A478CentroCostosUsrAlta;
               Z479CentroCostosUsrMod = A479CentroCostosUsrMod;
               Z480CentroCostosHoraAlt = A480CentroCostosHoraAlt;
               Z481CentroCostosHoraMod = A481CentroCostosHoraMod;
               Z482CentroCostosEstado = A482CentroCostosEstado;
            }
         }
         if ( GX_JID == -49 )
         {
            Z461CentroCostosId = A461CentroCostosId;
            Z487CentroCostosTipoRef = A487CentroCostosTipoRef;
            Z462CentroCostosRef = A462CentroCostosRef;
            Z475CentroCostosCosto = A475CentroCostosCosto;
            Z463CentroCostosNombre = A463CentroCostosNombre;
            Z464CentroCostosPrecioFinal = A464CentroCostosPrecioFinal;
            Z465CentroCostosSerial = A465CentroCostosSerial;
            Z889CentroCostosJson = A889CentroCostosJson;
            Z478CentroCostosUsrAlta = A478CentroCostosUsrAlta;
            Z479CentroCostosUsrMod = A479CentroCostosUsrMod;
            Z480CentroCostosHoraAlt = A480CentroCostosHoraAlt;
            Z481CentroCostosHoraMod = A481CentroCostosHoraMod;
            Z482CentroCostosEstado = A482CentroCostosEstado;
            Z469CentroCostosSubTotal = A469CentroCostosSubTotal;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCentroCostosRef_Enabled = 0;
         AssignProp("", false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
         edtCentroCostosId_Enabled = 0;
         AssignProp("", false, edtCentroCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosId_Enabled), 5, 0), true);
         GXt_date2 = AV31FechaCierreSolicitud;
         new obtenercierres(context ).execute(  context.GetMessage( context.GetMessage( "FechaCierreSolicitud", ""), ""), out  GXt_date2) ;
         AV31FechaCierreSolicitud = GXt_date2;
         AssignAttri("", false, "AV31FechaCierreSolicitud", context.localUtil.Format(AV31FechaCierreSolicitud, "99/99/99"));
         cmbCentroCostosTipoRef.Enabled = 0;
         AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosTipoRef.Enabled), 5, 0), true);
         edtCentroCostosPrecioFinal_Enabled = 0;
         AssignProp("", false, edtCentroCostosPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosPrecioFinal_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCentroCostosRef_Enabled = 0;
         AssignProp("", false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
         edtCentroCostosId_Enabled = 0;
         AssignProp("", false, edtCentroCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosId_Enabled), 5, 0), true);
         cmbCentroCostosTipoRef.Enabled = 0;
         AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosTipoRef.Enabled), 5, 0), true);
         edtCentroCostosPrecioFinal_Enabled = 0;
         AssignProp("", false, edtCentroCostosPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosPrecioFinal_Enabled), 5, 0), true);
         if ( ! (0==AV7CentroCostosId) )
         {
            A461CentroCostosId = AV7CentroCostosId;
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8CentroCostosRef > 0 ) )
         {
            edtCentroCostosNombre_Enabled = 0;
            AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
         }
         else
         {
            edtCentroCostosNombre_Enabled = 1;
            AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
         }
         GXt_objcol_int3 = AV36SolicitudesIdCollection;
         new solicitudesfechavigente(context ).execute(  AV8CentroCostosRef,  AV31FechaCierreSolicitud, out  GXt_objcol_int3) ;
         AV36SolicitudesIdCollection = GXt_objcol_int3;
         new osoldat(context ).execute(  AV8CentroCostosRef, out  AV13CentroCostosNombre, out  AV14CentroCostosPrecioFinal) ;
         AssignAttri("", false, "AV13CentroCostosNombre", AV13CentroCostosNombre);
         AssignAttri("", false, "AV14CentroCostosPrecioFinal", StringUtil.LTrimStr( AV14CentroCostosPrecioFinal, 18, 2));
         if ( ( AV14CentroCostosPrecioFinal > Convert.ToDecimal( 0 )) )
         {
            new osoldat(context ).execute(  AV8CentroCostosRef, out  A463CentroCostosNombre, out  A464CentroCostosPrecioFinal) ;
            AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
            AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
         }
         AV32RoleName = AV11WebSession.Get(context.GetMessage( context.GetMessage( "Rol", ""), ""));
         AssignAttri("", false, "AV32RoleName", AV32RoleName);
      }

      protected void standaloneModal( )
      {
         A487CentroCostosTipoRef = context.GetMessage( context.GetMessage( "S", ""), "");
         AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
         A462CentroCostosRef = AV8CentroCostosRef;
         AssignAttri("", false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8CentroCostosRef > 0 ) )
         {
            edtCentroCostosNombre_Enabled = 0;
            AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A482CentroCostosEstado)) && ( Gx_BScreen == 0 ) )
         {
            A482CentroCostosEstado = context.GetMessage( context.GetMessage( "PND", ""), "");
            AssignAttri("", false, "A482CentroCostosEstado", A482CentroCostosEstado);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000P9 */
            pr_default.execute(6, new Object[] {A461CentroCostosId});
            if ( (pr_default.getStatus(6) != 101) )
            {
               A469CentroCostosSubTotal = T000P9_A469CentroCostosSubTotal[0];
               n469CentroCostosSubTotal = T000P9_n469CentroCostosSubTotal[0];
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            else
            {
               A469CentroCostosSubTotal = 0;
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            O469CentroCostosSubTotal = A469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            pr_default.close(6);
            AV40Pgmname = "CostoServicios";
            AssignAttri("", false, "AV40Pgmname", AV40Pgmname);
         }
      }

      protected void Load0P69( )
      {
         /* Using cursor T000P11 */
         pr_default.execute(7, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound69 = 1;
            A487CentroCostosTipoRef = T000P11_A487CentroCostosTipoRef[0];
            AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
            A462CentroCostosRef = T000P11_A462CentroCostosRef[0];
            AssignAttri("", false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
            A475CentroCostosCosto = T000P11_A475CentroCostosCosto[0];
            A463CentroCostosNombre = T000P11_A463CentroCostosNombre[0];
            AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
            A464CentroCostosPrecioFinal = T000P11_A464CentroCostosPrecioFinal[0];
            AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
            A465CentroCostosSerial = T000P11_A465CentroCostosSerial[0];
            A889CentroCostosJson = T000P11_A889CentroCostosJson[0];
            A478CentroCostosUsrAlta = T000P11_A478CentroCostosUsrAlta[0];
            A479CentroCostosUsrMod = T000P11_A479CentroCostosUsrMod[0];
            A480CentroCostosHoraAlt = T000P11_A480CentroCostosHoraAlt[0];
            A481CentroCostosHoraMod = T000P11_A481CentroCostosHoraMod[0];
            A482CentroCostosEstado = T000P11_A482CentroCostosEstado[0];
            A469CentroCostosSubTotal = T000P11_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = T000P11_n469CentroCostosSubTotal[0];
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            ZM0P69( -49) ;
         }
         pr_default.close(7);
         OnLoadActions0P69( ) ;
      }

      protected void OnLoadActions0P69( )
      {
         O469CentroCostosSubTotal = A469CentroCostosSubTotal;
         n469CentroCostosSubTotal = false;
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         AV40Pgmname = "CostoServicios";
         AssignAttri("", false, "AV40Pgmname", AV40Pgmname);
         if ( true /* After */ && ( A469CentroCostosSubTotal > Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            A475CentroCostosCosto = A469CentroCostosSubTotal;
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         }
         A474CentroCostosGam = (decimal)(A464CentroCostosPrecioFinal-A475CentroCostosCosto);
         AssignAttri("", false, "A474CentroCostosGam", StringUtil.LTrimStr( A474CentroCostosGam, 18, 2));
      }

      protected void CheckExtendedTable0P69( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV40Pgmname = "CostoServicios";
         AssignAttri("", false, "AV40Pgmname", AV40Pgmname);
         /* Using cursor T000P9 */
         pr_default.execute(6, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A469CentroCostosSubTotal = T000P9_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = T000P9_n469CentroCostosSubTotal[0];
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         else
         {
            A469CentroCostosSubTotal = 0;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         pr_default.close(6);
         if ( true /* After */ && ( A469CentroCostosSubTotal > Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            A475CentroCostosCosto = A469CentroCostosSubTotal;
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         }
         A474CentroCostosGam = (decimal)(A464CentroCostosPrecioFinal-A475CentroCostosCosto);
         AssignAttri("", false, "A474CentroCostosGam", StringUtil.LTrimStr( A474CentroCostosGam, 18, 2));
         if ( ( AV14CentroCostosPrecioFinal > Convert.ToDecimal( 0 )) && ( ( AV14CentroCostosPrecioFinal != A464CentroCostosPrecioFinal ) && ( A464CentroCostosPrecioFinal > Convert.ToDecimal( 0 )) ) )
         {
            GX_msglist.addItem(context.GetMessage( "Atención: Ha cambiado el precio final de la solicitud, favor guardar los cambios antes de salir.", ""), 0, "");
         }
      }

      protected void CloseExtendedTableCursors0P69( )
      {
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_50( long A461CentroCostosId )
      {
         /* Using cursor T000P13 */
         pr_default.execute(8, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A469CentroCostosSubTotal = T000P13_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = T000P13_n469CentroCostosSubTotal[0];
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         else
         {
            A469CentroCostosSubTotal = 0;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A469CentroCostosSubTotal, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0P69( )
      {
         /* Using cursor T000P14 */
         pr_default.execute(9, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound69 = 1;
         }
         else
         {
            RcdFound69 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000P7 */
         pr_default.execute(5, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0P69( 49) ;
            RcdFound69 = 1;
            A461CentroCostosId = T000P7_A461CentroCostosId[0];
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
            A487CentroCostosTipoRef = T000P7_A487CentroCostosTipoRef[0];
            AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
            A462CentroCostosRef = T000P7_A462CentroCostosRef[0];
            AssignAttri("", false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
            A475CentroCostosCosto = T000P7_A475CentroCostosCosto[0];
            A463CentroCostosNombre = T000P7_A463CentroCostosNombre[0];
            AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
            A464CentroCostosPrecioFinal = T000P7_A464CentroCostosPrecioFinal[0];
            AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
            A465CentroCostosSerial = T000P7_A465CentroCostosSerial[0];
            A889CentroCostosJson = T000P7_A889CentroCostosJson[0];
            A478CentroCostosUsrAlta = T000P7_A478CentroCostosUsrAlta[0];
            A479CentroCostosUsrMod = T000P7_A479CentroCostosUsrMod[0];
            A480CentroCostosHoraAlt = T000P7_A480CentroCostosHoraAlt[0];
            A481CentroCostosHoraMod = T000P7_A481CentroCostosHoraMod[0];
            A482CentroCostosEstado = T000P7_A482CentroCostosEstado[0];
            O465CentroCostosSerial = A465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            Z461CentroCostosId = A461CentroCostosId;
            sMode69 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0P69( ) ;
            if ( AnyError == 1 )
            {
               RcdFound69 = 0;
               InitializeNonKey0P69( ) ;
            }
            Gx_mode = sMode69;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound69 = 0;
            InitializeNonKey0P69( ) ;
            sMode69 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode69;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0P69( ) ;
         if ( RcdFound69 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound69 = 0;
         /* Using cursor T000P15 */
         pr_default.execute(10, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000P15_A461CentroCostosId[0] < A461CentroCostosId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000P15_A461CentroCostosId[0] > A461CentroCostosId ) ) )
            {
               A461CentroCostosId = T000P15_A461CentroCostosId[0];
               AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
               RcdFound69 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound69 = 0;
         /* Using cursor T000P16 */
         pr_default.execute(11, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000P16_A461CentroCostosId[0] > A461CentroCostosId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000P16_A461CentroCostosId[0] < A461CentroCostosId ) ) )
            {
               A461CentroCostosId = T000P16_A461CentroCostosId[0];
               AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
               RcdFound69 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0P69( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A465CentroCostosSerial = O465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            A469CentroCostosSubTotal = O469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            A475CentroCostosCosto = O475CentroCostosCosto;
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
            GX_FocusControl = edtCentroCostosNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0P69( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound69 == 1 )
            {
               if ( A461CentroCostosId != Z461CentroCostosId )
               {
                  A461CentroCostosId = Z461CentroCostosId;
                  AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CENTROCOSTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtCentroCostosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A465CentroCostosSerial = O465CentroCostosSerial;
                  AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                  A469CentroCostosSubTotal = O469CentroCostosSubTotal;
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                  A475CentroCostosCosto = O475CentroCostosCosto;
                  AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCentroCostosNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A465CentroCostosSerial = O465CentroCostosSerial;
                  AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                  A469CentroCostosSubTotal = O469CentroCostosSubTotal;
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                  A475CentroCostosCosto = O475CentroCostosCosto;
                  AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
                  Update0P69( ) ;
                  GX_FocusControl = edtCentroCostosNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A461CentroCostosId != Z461CentroCostosId )
               {
                  /* Insert record */
                  A465CentroCostosSerial = O465CentroCostosSerial;
                  AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                  A469CentroCostosSubTotal = O469CentroCostosSubTotal;
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                  A475CentroCostosCosto = O475CentroCostosCosto;
                  AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
                  GX_FocusControl = edtCentroCostosNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0P69( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CENTROCOSTOSID");
                     AnyError = 1;
                     GX_FocusControl = edtCentroCostosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A465CentroCostosSerial = O465CentroCostosSerial;
                     AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                     A469CentroCostosSubTotal = O469CentroCostosSubTotal;
                     n469CentroCostosSubTotal = false;
                     AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                     A475CentroCostosCosto = O475CentroCostosCosto;
                     AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
                     GX_FocusControl = edtCentroCostosNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0P69( ) ;
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
         if ( A461CentroCostosId != Z461CentroCostosId )
         {
            A461CentroCostosId = Z461CentroCostosId;
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CENTROCOSTOSID");
            AnyError = 1;
            GX_FocusControl = edtCentroCostosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A465CentroCostosSerial = O465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            A469CentroCostosSubTotal = O469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            A475CentroCostosCosto = O475CentroCostosCosto;
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCentroCostosNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0P69( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000P6 */
            pr_default.execute(4, new Object[] {A461CentroCostosId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CentroCostos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z487CentroCostosTipoRef, T000P6_A487CentroCostosTipoRef[0]) != 0 ) || ( Z462CentroCostosRef != T000P6_A462CentroCostosRef[0] ) || ( Z475CentroCostosCosto != T000P6_A475CentroCostosCosto[0] ) || ( StringUtil.StrCmp(Z463CentroCostosNombre, T000P6_A463CentroCostosNombre[0]) != 0 ) || ( Z464CentroCostosPrecioFinal != T000P6_A464CentroCostosPrecioFinal[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z465CentroCostosSerial != T000P6_A465CentroCostosSerial[0] ) || ( StringUtil.StrCmp(Z478CentroCostosUsrAlta, T000P6_A478CentroCostosUsrAlta[0]) != 0 ) || ( StringUtil.StrCmp(Z479CentroCostosUsrMod, T000P6_A479CentroCostosUsrMod[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z480CentroCostosHoraAlt ) != DateTimeUtil.ResetTime ( T000P6_A480CentroCostosHoraAlt[0] ) ) || ( DateTimeUtil.ResetTime ( Z481CentroCostosHoraMod ) != DateTimeUtil.ResetTime ( T000P6_A481CentroCostosHoraMod[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z482CentroCostosEstado, T000P6_A482CentroCostosEstado[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z487CentroCostosTipoRef, T000P6_A487CentroCostosTipoRef[0]) != 0 )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosTipoRef");
                  GXUtil.WriteLogRaw("Old: ",Z487CentroCostosTipoRef);
                  GXUtil.WriteLogRaw("Current: ",T000P6_A487CentroCostosTipoRef[0]);
               }
               if ( Z462CentroCostosRef != T000P6_A462CentroCostosRef[0] )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosRef");
                  GXUtil.WriteLogRaw("Old: ",Z462CentroCostosRef);
                  GXUtil.WriteLogRaw("Current: ",T000P6_A462CentroCostosRef[0]);
               }
               if ( Z475CentroCostosCosto != T000P6_A475CentroCostosCosto[0] )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosCosto");
                  GXUtil.WriteLogRaw("Old: ",Z475CentroCostosCosto);
                  GXUtil.WriteLogRaw("Current: ",T000P6_A475CentroCostosCosto[0]);
               }
               if ( StringUtil.StrCmp(Z463CentroCostosNombre, T000P6_A463CentroCostosNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosNombre");
                  GXUtil.WriteLogRaw("Old: ",Z463CentroCostosNombre);
                  GXUtil.WriteLogRaw("Current: ",T000P6_A463CentroCostosNombre[0]);
               }
               if ( Z464CentroCostosPrecioFinal != T000P6_A464CentroCostosPrecioFinal[0] )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosPrecioFinal");
                  GXUtil.WriteLogRaw("Old: ",Z464CentroCostosPrecioFinal);
                  GXUtil.WriteLogRaw("Current: ",T000P6_A464CentroCostosPrecioFinal[0]);
               }
               if ( Z465CentroCostosSerial != T000P6_A465CentroCostosSerial[0] )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosSerial");
                  GXUtil.WriteLogRaw("Old: ",Z465CentroCostosSerial);
                  GXUtil.WriteLogRaw("Current: ",T000P6_A465CentroCostosSerial[0]);
               }
               if ( StringUtil.StrCmp(Z478CentroCostosUsrAlta, T000P6_A478CentroCostosUsrAlta[0]) != 0 )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosUsrAlta");
                  GXUtil.WriteLogRaw("Old: ",Z478CentroCostosUsrAlta);
                  GXUtil.WriteLogRaw("Current: ",T000P6_A478CentroCostosUsrAlta[0]);
               }
               if ( StringUtil.StrCmp(Z479CentroCostosUsrMod, T000P6_A479CentroCostosUsrMod[0]) != 0 )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosUsrMod");
                  GXUtil.WriteLogRaw("Old: ",Z479CentroCostosUsrMod);
                  GXUtil.WriteLogRaw("Current: ",T000P6_A479CentroCostosUsrMod[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z480CentroCostosHoraAlt ) != DateTimeUtil.ResetTime ( T000P6_A480CentroCostosHoraAlt[0] ) )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosHoraAlt");
                  GXUtil.WriteLogRaw("Old: ",Z480CentroCostosHoraAlt);
                  GXUtil.WriteLogRaw("Current: ",T000P6_A480CentroCostosHoraAlt[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z481CentroCostosHoraMod ) != DateTimeUtil.ResetTime ( T000P6_A481CentroCostosHoraMod[0] ) )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosHoraMod");
                  GXUtil.WriteLogRaw("Old: ",Z481CentroCostosHoraMod);
                  GXUtil.WriteLogRaw("Current: ",T000P6_A481CentroCostosHoraMod[0]);
               }
               if ( StringUtil.StrCmp(Z482CentroCostosEstado, T000P6_A482CentroCostosEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosEstado");
                  GXUtil.WriteLogRaw("Old: ",Z482CentroCostosEstado);
                  GXUtil.WriteLogRaw("Current: ",T000P6_A482CentroCostosEstado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CentroCostos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0P69( )
      {
         BeforeValidate0P69( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P69( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0P69( 0) ;
            CheckOptimisticConcurrency0P69( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P69( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0P69( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P17 */
                     pr_default.execute(12, new Object[] {A487CentroCostosTipoRef, A462CentroCostosRef, A475CentroCostosCosto, A463CentroCostosNombre, A464CentroCostosPrecioFinal, A465CentroCostosSerial, A889CentroCostosJson, A478CentroCostosUsrAlta, A479CentroCostosUsrMod, A480CentroCostosHoraAlt, A481CentroCostosHoraMod, A482CentroCostosEstado});
                     A461CentroCostosId = T000P17_A461CentroCostosId[0];
                     AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("CentroCostos");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0P69( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0P0( ) ;
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
               Load0P69( ) ;
            }
            EndLevel0P69( ) ;
         }
         CloseExtendedTableCursors0P69( ) ;
      }

      protected void Update0P69( )
      {
         BeforeValidate0P69( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P69( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P69( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P69( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0P69( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P18 */
                     pr_default.execute(13, new Object[] {A487CentroCostosTipoRef, A462CentroCostosRef, A475CentroCostosCosto, A463CentroCostosNombre, A464CentroCostosPrecioFinal, A465CentroCostosSerial, A889CentroCostosJson, A478CentroCostosUsrAlta, A479CentroCostosUsrMod, A480CentroCostosHoraAlt, A481CentroCostosHoraMod, A482CentroCostosEstado, A461CentroCostosId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("CentroCostos");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CentroCostos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0P69( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0P69( ) ;
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
            EndLevel0P69( ) ;
         }
         CloseExtendedTableCursors0P69( ) ;
      }

      protected void DeferredUpdate0P69( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0P69( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P69( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0P69( ) ;
            AfterConfirm0P69( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0P69( ) ;
               if ( AnyError == 0 )
               {
                  A465CentroCostosSerial = O465CentroCostosSerial;
                  AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                  A469CentroCostosSubTotal = O469CentroCostosSubTotal;
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                  A475CentroCostosCosto = O475CentroCostosCosto;
                  AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
                  ScanStart0P70( ) ;
                  while ( RcdFound70 != 0 )
                  {
                     getByPrimaryKey0P70( ) ;
                     Delete0P70( ) ;
                     ScanNext0P70( ) ;
                     O465CentroCostosSerial = A465CentroCostosSerial;
                     AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
                     O469CentroCostosSubTotal = A469CentroCostosSubTotal;
                     n469CentroCostosSubTotal = false;
                     AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                     O475CentroCostosCosto = A475CentroCostosCosto;
                     AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
                  }
                  ScanEnd0P70( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P19 */
                     pr_default.execute(14, new Object[] {A461CentroCostosId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("CentroCostos");
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
         sMode69 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0P69( ) ;
         Gx_mode = sMode69;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0P69( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV40Pgmname = "CostoServicios";
            AssignAttri("", false, "AV40Pgmname", AV40Pgmname);
            /* Using cursor T000P21 */
            pr_default.execute(15, new Object[] {A461CentroCostosId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               A469CentroCostosSubTotal = T000P21_A469CentroCostosSubTotal[0];
               n469CentroCostosSubTotal = T000P21_n469CentroCostosSubTotal[0];
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            else
            {
               A469CentroCostosSubTotal = 0;
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            pr_default.close(15);
            A474CentroCostosGam = (decimal)(A464CentroCostosPrecioFinal-A475CentroCostosCosto);
            AssignAttri("", false, "A474CentroCostosGam", StringUtil.LTrimStr( A474CentroCostosGam, 18, 2));
         }
      }

      protected void ProcessNestedLevel0P70( )
      {
         s465CentroCostosSerial = O465CentroCostosSerial;
         AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         s469CentroCostosSubTotal = O469CentroCostosSubTotal;
         n469CentroCostosSubTotal = false;
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         s475CentroCostosCosto = O475CentroCostosCosto;
         AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         nGXsfl_65_idx = 0;
         while ( nGXsfl_65_idx < nRC_GXsfl_65 )
         {
            ReadRow0P70( ) ;
            if ( ( nRcdExists_70 != 0 ) || ( nIsMod_70 != 0 ) )
            {
               standaloneNotModal0P70( ) ;
               GetKey0P70( ) ;
               if ( ( nRcdExists_70 == 0 ) && ( nRcdDeleted_70 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0P70( ) ;
               }
               else
               {
                  if ( RcdFound70 != 0 )
                  {
                     if ( ( nRcdDeleted_70 != 0 ) && ( nRcdExists_70 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0P70( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_70 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0P70( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_70 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O465CentroCostosSerial = A465CentroCostosSerial;
               AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
               O469CentroCostosSubTotal = A469CentroCostosSubTotal;
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               O475CentroCostosCosto = A475CentroCostosCosto;
               AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
            }
            ChangePostValue( edtCentroCostosDetallesFecha_Internalname, context.localUtil.Format(A892CentroCostosDetallesFecha, "99/99/99")) ;
            ChangePostValue( edtCentroCostosDetallesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtListaCostosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCentroCostosDetallesNombre_Internalname, StringUtil.RTrim( A473CentroCostosDetallesNombre)) ;
            ChangePostValue( edtCentroCostosDetallesValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCentroCostosDetallesSolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A888CentroCostosDetallesSolId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtCCDetallesProfId_Internalname, StringUtil.RTrim( A890CCDetallesProfId)) ;
            ChangePostValue( edtCCDetallesProfNombre_Internalname, A891CCDetallesProfNombre) ;
            ChangePostValue( cmbCentroCostosDetallesEstado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A893CentroCostosDetallesEstado), 18, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z466CentroCostosDetallesId_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z893CentroCostosDetallesEstado_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z893CentroCostosDetallesEstado), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z473CentroCostosDetallesNombre_"+sGXsfl_65_idx, StringUtil.RTrim( Z473CentroCostosDetallesNombre)) ;
            ChangePostValue( "ZT_"+"Z468CentroCostosDetallesValor_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( Z468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z892CentroCostosDetallesFecha_"+sGXsfl_65_idx, context.localUtil.DToC( Z892CentroCostosDetallesFecha, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z888CentroCostosDetallesSolId_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z888CentroCostosDetallesSolId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z459ListaCostosId_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z890CCDetallesProfId_"+sGXsfl_65_idx, StringUtil.RTrim( Z890CCDetallesProfId)) ;
            ChangePostValue( "T468CentroCostosDetallesValor_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( O468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_70_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_70), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_70_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_70), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_70_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_70), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "N466CentroCostosDetallesId_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "N892CentroCostosDetallesFecha_"+sGXsfl_65_idx, context.localUtil.DToC( A892CentroCostosDetallesFecha, 0, "/")) ;
            ChangePostValue( "N459ListaCostosId_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "N473CentroCostosDetallesNombre_"+sGXsfl_65_idx, StringUtil.RTrim( A473CentroCostosDetallesNombre)) ;
            ChangePostValue( "N468CentroCostosDetallesValor_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "N890CCDetallesProfId_"+sGXsfl_65_idx, StringUtil.RTrim( A890CCDetallesProfId)) ;
            ChangePostValue( "N893CentroCostosDetallesEstado_"+sGXsfl_65_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(A893CentroCostosDetallesEstado), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_70 != 0 )
            {
               ChangePostValue( "CENTROCOSTOSDETALLESFECHA_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESID_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LISTACOSTOSID_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaCostosId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESSOLID_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesSolId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CCDETALLESPROFID_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCCDetallesProfId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CCDETALLESPROFNOMBRE_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCCDetallesProfNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CENTROCOSTOSDETALLESESTADO_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0P70( ) ;
         if ( AnyError != 0 )
         {
            O465CentroCostosSerial = s465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            O469CentroCostosSubTotal = s469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            O475CentroCostosCosto = s475CentroCostosCosto;
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         }
         nRcdExists_70 = 0;
         nIsMod_70 = 0;
         nRcdDeleted_70 = 0;
      }

      protected void ProcessLevel0P69( )
      {
         /* Save parent mode. */
         sMode69 = Gx_mode;
         ProcessNestedLevel0P70( ) ;
         if ( AnyError != 0 )
         {
            O465CentroCostosSerial = s465CentroCostosSerial;
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
            O469CentroCostosSubTotal = s469CentroCostosSubTotal;
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            O475CentroCostosCosto = s475CentroCostosCosto;
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         }
         /* Restore parent mode. */
         Gx_mode = sMode69;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000P22 */
         pr_default.execute(16, new Object[] {A465CentroCostosSerial, A475CentroCostosCosto, A461CentroCostosId});
         pr_default.close(16);
         pr_default.SmartCacheProvider.SetUpdated("CentroCostos");
      }

      protected void EndLevel0P69( )
      {
         pr_default.close(4);
         if ( AnyError == 0 )
         {
            BeforeComplete0P69( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(15);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("costoservicios",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0P0( ) ;
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
            pr_default.close(15);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("costoservicios",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0P69( )
      {
         /* Scan By routine */
         /* Using cursor T000P23 */
         pr_default.execute(17);
         RcdFound69 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound69 = 1;
            A461CentroCostosId = T000P23_A461CentroCostosId[0];
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0P69( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound69 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound69 = 1;
            A461CentroCostosId = T000P23_A461CentroCostosId[0];
            AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
         }
      }

      protected void ScanEnd0P69( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0P69( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0P69( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0P69( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0P69( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0P69( )
      {
         /* Before Complete Rules */
         new controlsubsolicitud(context ).execute(  A461CentroCostosId) ;
      }

      protected void BeforeValidate0P69( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0P69( )
      {
         edtCentroCostosId_Enabled = 0;
         AssignProp("", false, edtCentroCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosId_Enabled), 5, 0), true);
         cmbCentroCostosTipoRef.Enabled = 0;
         AssignProp("", false, cmbCentroCostosTipoRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosTipoRef.Enabled), 5, 0), true);
         edtCentroCostosRef_Enabled = 0;
         AssignProp("", false, edtCentroCostosRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosRef_Enabled), 5, 0), true);
         edtavCentrocostosnombre_Enabled = 0;
         AssignProp("", false, edtavCentrocostosnombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCentrocostosnombre_Enabled), 5, 0), true);
         edtavCentrocostospreciofinal_Enabled = 0;
         AssignProp("", false, edtavCentrocostospreciofinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCentrocostospreciofinal_Enabled), 5, 0), true);
         edtCentroCostosSubTotal_Enabled = 0;
         AssignProp("", false, edtCentroCostosSubTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosSubTotal_Enabled), 5, 0), true);
         edtCentroCostosNombre_Enabled = 0;
         AssignProp("", false, edtCentroCostosNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosNombre_Enabled), 5, 0), true);
         edtCentroCostosPrecioFinal_Enabled = 0;
         AssignProp("", false, edtCentroCostosPrecioFinal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosPrecioFinal_Enabled), 5, 0), true);
         edtavFechacierresolicitud_Enabled = 0;
         AssignProp("", false, edtavFechacierresolicitud_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFechacierresolicitud_Enabled), 5, 0), true);
      }

      protected void ZM0P70( short GX_JID )
      {
         if ( ( GX_JID == 51 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z893CentroCostosDetallesEstado = T000P3_A893CentroCostosDetallesEstado[0];
               Z473CentroCostosDetallesNombre = T000P3_A473CentroCostosDetallesNombre[0];
               Z468CentroCostosDetallesValor = T000P3_A468CentroCostosDetallesValor[0];
               Z892CentroCostosDetallesFecha = T000P3_A892CentroCostosDetallesFecha[0];
               Z888CentroCostosDetallesSolId = T000P3_A888CentroCostosDetallesSolId[0];
               Z459ListaCostosId = T000P3_A459ListaCostosId[0];
               Z890CCDetallesProfId = T000P3_A890CCDetallesProfId[0];
            }
            else
            {
               Z893CentroCostosDetallesEstado = A893CentroCostosDetallesEstado;
               Z473CentroCostosDetallesNombre = A473CentroCostosDetallesNombre;
               Z468CentroCostosDetallesValor = A468CentroCostosDetallesValor;
               Z892CentroCostosDetallesFecha = A892CentroCostosDetallesFecha;
               Z888CentroCostosDetallesSolId = A888CentroCostosDetallesSolId;
               Z459ListaCostosId = A459ListaCostosId;
               Z890CCDetallesProfId = A890CCDetallesProfId;
            }
         }
         if ( GX_JID == -51 )
         {
            Z461CentroCostosId = A461CentroCostosId;
            Z466CentroCostosDetallesId = A466CentroCostosDetallesId;
            Z893CentroCostosDetallesEstado = A893CentroCostosDetallesEstado;
            Z473CentroCostosDetallesNombre = A473CentroCostosDetallesNombre;
            Z468CentroCostosDetallesValor = A468CentroCostosDetallesValor;
            Z892CentroCostosDetallesFecha = A892CentroCostosDetallesFecha;
            Z888CentroCostosDetallesSolId = A888CentroCostosDetallesSolId;
            Z459ListaCostosId = A459ListaCostosId;
            Z890CCDetallesProfId = A890CCDetallesProfId;
            Z460ListaCostosNombre = A460ListaCostosNombre;
            Z471ListaCostosValor = A471ListaCostosValor;
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
         }
      }

      protected void standaloneNotModal0P70( )
      {
         edtCentroCostosDetallesSolId_Enabled = 0;
         AssignProp("", false, edtCentroCostosDetallesSolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesSolId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
      }

      protected void standaloneModal0P70( )
      {
         if ( IsIns( )  )
         {
            A465CentroCostosSerial = (long)(O465CentroCostosSerial+1);
            AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A466CentroCostosDetallesId = A465CentroCostosSerial;
         }
         if ( IsIns( )  && (0==A893CentroCostosDetallesEstado) && ( Gx_BScreen == 0 ) )
         {
            A893CentroCostosDetallesEstado = 1;
         }
      }

      protected void Load0P70( )
      {
         /* Using cursor T000P24 */
         pr_default.execute(18, new Object[] {A461CentroCostosId, A466CentroCostosDetallesId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound70 = 1;
            A893CentroCostosDetallesEstado = T000P24_A893CentroCostosDetallesEstado[0];
            A473CentroCostosDetallesNombre = T000P24_A473CentroCostosDetallesNombre[0];
            A468CentroCostosDetallesValor = T000P24_A468CentroCostosDetallesValor[0];
            A892CentroCostosDetallesFecha = T000P24_A892CentroCostosDetallesFecha[0];
            A460ListaCostosNombre = T000P24_A460ListaCostosNombre[0];
            A471ListaCostosValor = T000P24_A471ListaCostosValor[0];
            A888CentroCostosDetallesSolId = T000P24_A888CentroCostosDetallesSolId[0];
            A167ProfesionalesApellidoPrimero = T000P24_A167ProfesionalesApellidoPrimero[0];
            n167ProfesionalesApellidoPrimero = T000P24_n167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = T000P24_A166ProfesionalesPrimerNombre[0];
            n166ProfesionalesPrimerNombre = T000P24_n166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = T000P24_A191ProfesionalesSegundoNombre[0];
            n191ProfesionalesSegundoNombre = T000P24_n191ProfesionalesSegundoNombre[0];
            A459ListaCostosId = T000P24_A459ListaCostosId[0];
            n459ListaCostosId = T000P24_n459ListaCostosId[0];
            A890CCDetallesProfId = T000P24_A890CCDetallesProfId[0];
            ZM0P70( -51) ;
         }
         pr_default.close(18);
         OnLoadActions0P70( ) ;
      }

      protected void OnLoadActions0P70( )
      {
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            edtCentroCostosDetallesFecha_Enabled = 0;
            AssignProp("", false, edtCentroCostosDetallesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            edtCentroCostosDetallesFecha_Enabled = 1;
            AssignProp("", false, edtCentroCostosDetallesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            edtCentroCostosDetallesId_Enabled = 0;
            AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            if ( true )
            {
               edtCentroCostosDetallesId_Enabled = 1;
               AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            else
            {
               edtCentroCostosDetallesId_Enabled = 0;
               AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
         }
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            edtListaCostosId_Enabled = 0;
            AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            edtListaCostosId_Enabled = 1;
            AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            edtCentroCostosDetallesNombre_Enabled = 0;
            AssignProp("", false, edtCentroCostosDetallesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            edtCentroCostosDetallesNombre_Enabled = 1;
            AssignProp("", false, edtCentroCostosDetallesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            edtCentroCostosDetallesValor_Enabled = 0;
            AssignProp("", false, edtCentroCostosDetallesValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            edtCentroCostosDetallesValor_Enabled = 1;
            AssignProp("", false, edtCentroCostosDetallesValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            edtCCDetallesProfId_Enabled = 0;
            AssignProp("", false, edtCCDetallesProfId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCDetallesProfId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            edtCCDetallesProfId_Enabled = 1;
            AssignProp("", false, edtCCDetallesProfId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCDetallesProfId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            cmbCentroCostosDetallesEstado.Enabled = 0;
            AssignProp("", false, cmbCentroCostosDetallesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            cmbCentroCostosDetallesEstado.Enabled = 1;
            AssignProp("", false, cmbCentroCostosDetallesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         if ( true /* After */ && IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A473CentroCostosDetallesNombre)) )
         {
            A473CentroCostosDetallesNombre = A460ListaCostosNombre;
         }
         if ( true /* After */ && IsIns( )  && ( A468CentroCostosDetallesValor == Convert.ToDecimal( 0 )) )
         {
            A468CentroCostosDetallesValor = A471ListaCostosValor;
         }
         if ( IsIns( )  )
         {
            A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal+A468CentroCostosDetallesValor);
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal+A468CentroCostosDetallesValor-O468CentroCostosDetallesValor);
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal-O468CentroCostosDetallesValor);
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               }
            }
         }
         if ( true /* After */ && ( A469CentroCostosSubTotal > Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            A475CentroCostosCosto = A469CentroCostosSubTotal;
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         }
         A891CCDetallesProfNombre = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
      }

      protected void CheckExtendedTable0P70( )
      {
         nIsDirty_70 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0P70( ) ;
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            edtCentroCostosDetallesFecha_Enabled = 0;
            AssignProp("", false, edtCentroCostosDetallesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            edtCentroCostosDetallesFecha_Enabled = 1;
            AssignProp("", false, edtCentroCostosDetallesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            edtCentroCostosDetallesId_Enabled = 0;
            AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            if ( true )
            {
               edtCentroCostosDetallesId_Enabled = 1;
               AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            else
            {
               edtCentroCostosDetallesId_Enabled = 0;
               AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
         }
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            edtListaCostosId_Enabled = 0;
            AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            edtListaCostosId_Enabled = 1;
            AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            edtCentroCostosDetallesNombre_Enabled = 0;
            AssignProp("", false, edtCentroCostosDetallesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            edtCentroCostosDetallesNombre_Enabled = 1;
            AssignProp("", false, edtCentroCostosDetallesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            edtCentroCostosDetallesValor_Enabled = 0;
            AssignProp("", false, edtCentroCostosDetallesValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            edtCentroCostosDetallesValor_Enabled = 1;
            AssignProp("", false, edtCentroCostosDetallesValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            edtCCDetallesProfId_Enabled = 0;
            AssignProp("", false, edtCCDetallesProfId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCDetallesProfId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            edtCCDetallesProfId_Enabled = 1;
            AssignProp("", false, edtCCDetallesProfId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCDetallesProfId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
         {
            cmbCentroCostosDetallesEstado.Enabled = 0;
            AssignProp("", false, cmbCentroCostosDetallesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         else
         {
            cmbCentroCostosDetallesEstado.Enabled = 1;
            AssignProp("", false, cmbCentroCostosDetallesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0), !bGXsfl_65_Refreshing);
         }
         if ( ! ( (DateTime.MinValue==A892CentroCostosDetallesFecha) || ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GXCCtl = "CENTROCOSTOSDETALLESFECHA_" + sGXsfl_65_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Costo Servicios Detalles Fecha", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCentroCostosDetallesFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000P4 */
         pr_default.execute(2, new Object[] {n459ListaCostosId, A459ListaCostosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A459ListaCostosId) ) )
            {
               GXCCtl = "LISTACOSTOSID_" + sGXsfl_65_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Lista de Costos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtListaCostosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A460ListaCostosNombre = T000P4_A460ListaCostosNombre[0];
         A471ListaCostosValor = T000P4_A471ListaCostosValor[0];
         pr_default.close(2);
         if ( true /* After */ && IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A473CentroCostosDetallesNombre)) )
         {
            nIsDirty_70 = 1;
            A473CentroCostosDetallesNombre = A460ListaCostosNombre;
         }
         if ( true /* After */ && IsIns( )  && ( A468CentroCostosDetallesValor == Convert.ToDecimal( 0 )) )
         {
            nIsDirty_70 = 1;
            A468CentroCostosDetallesValor = A471ListaCostosValor;
         }
         if ( IsIns( )  )
         {
            nIsDirty_70 = 1;
            A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal+A468CentroCostosDetallesValor);
            n469CentroCostosSubTotal = false;
            AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_70 = 1;
               A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal+A468CentroCostosDetallesValor-O468CentroCostosDetallesValor);
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_70 = 1;
                  A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal-O468CentroCostosDetallesValor);
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               }
            }
         }
         if ( true /* After */ && ( A469CentroCostosSubTotal > Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            nIsDirty_70 = 1;
            A475CentroCostosCosto = A469CentroCostosSubTotal;
            AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         }
         /* Using cursor T000P5 */
         pr_default.execute(3, new Object[] {A890CCDetallesProfId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "CCDETALLESPROFID_" + sGXsfl_65_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "CCDetalles Prof", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCCDetallesProfId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A167ProfesionalesApellidoPrimero = T000P5_A167ProfesionalesApellidoPrimero[0];
         n167ProfesionalesApellidoPrimero = T000P5_n167ProfesionalesApellidoPrimero[0];
         A166ProfesionalesPrimerNombre = T000P5_A166ProfesionalesPrimerNombre[0];
         n166ProfesionalesPrimerNombre = T000P5_n166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T000P5_A191ProfesionalesSegundoNombre[0];
         n191ProfesionalesSegundoNombre = T000P5_n191ProfesionalesSegundoNombre[0];
         pr_default.close(3);
         nIsDirty_70 = 1;
         A891CCDetallesProfNombre = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
      }

      protected void CloseExtendedTableCursors0P70( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0P70( )
      {
      }

      protected void gxLoad_52( long A459ListaCostosId )
      {
         /* Using cursor T000P25 */
         pr_default.execute(19, new Object[] {n459ListaCostosId, A459ListaCostosId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A459ListaCostosId) ) )
            {
               GXCCtl = "LISTACOSTOSID_" + sGXsfl_65_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Lista de Costos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtListaCostosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A460ListaCostosNombre = T000P25_A460ListaCostosNombre[0];
         A471ListaCostosValor = T000P25_A471ListaCostosValor[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A460ListaCostosNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A471ListaCostosValor, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_53( string A890CCDetallesProfId )
      {
         /* Using cursor T000P26 */
         pr_default.execute(20, new Object[] {A890CCDetallesProfId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GXCCtl = "CCDETALLESPROFID_" + sGXsfl_65_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "CCDetalles Prof", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCCDetallesProfId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A167ProfesionalesApellidoPrimero = T000P26_A167ProfesionalesApellidoPrimero[0];
         n167ProfesionalesApellidoPrimero = T000P26_n167ProfesionalesApellidoPrimero[0];
         A166ProfesionalesPrimerNombre = T000P26_A166ProfesionalesPrimerNombre[0];
         n166ProfesionalesPrimerNombre = T000P26_n166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T000P26_A191ProfesionalesSegundoNombre[0];
         n191ProfesionalesSegundoNombre = T000P26_n191ProfesionalesSegundoNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A167ProfesionalesApellidoPrimero))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A166ProfesionalesPrimerNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A191ProfesionalesSegundoNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey0P70( )
      {
         /* Using cursor T000P27 */
         pr_default.execute(21, new Object[] {A461CentroCostosId, A466CentroCostosDetallesId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound70 = 1;
         }
         else
         {
            RcdFound70 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey0P70( )
      {
         /* Using cursor T000P3 */
         pr_default.execute(1, new Object[] {A461CentroCostosId, A466CentroCostosDetallesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0P70( 51) ;
            RcdFound70 = 1;
            InitializeNonKey0P70( ) ;
            A466CentroCostosDetallesId = T000P3_A466CentroCostosDetallesId[0];
            A893CentroCostosDetallesEstado = T000P3_A893CentroCostosDetallesEstado[0];
            A473CentroCostosDetallesNombre = T000P3_A473CentroCostosDetallesNombre[0];
            A468CentroCostosDetallesValor = T000P3_A468CentroCostosDetallesValor[0];
            A892CentroCostosDetallesFecha = T000P3_A892CentroCostosDetallesFecha[0];
            A888CentroCostosDetallesSolId = T000P3_A888CentroCostosDetallesSolId[0];
            A459ListaCostosId = T000P3_A459ListaCostosId[0];
            n459ListaCostosId = T000P3_n459ListaCostosId[0];
            A890CCDetallesProfId = T000P3_A890CCDetallesProfId[0];
            O468CentroCostosDetallesValor = A468CentroCostosDetallesValor;
            Z461CentroCostosId = A461CentroCostosId;
            Z466CentroCostosDetallesId = A466CentroCostosDetallesId;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0P70( ) ;
            Gx_mode = sMode70;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound70 = 0;
            InitializeNonKey0P70( ) ;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0P70( ) ;
            Gx_mode = sMode70;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0P70( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0P70( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000P2 */
            pr_default.execute(0, new Object[] {A461CentroCostosId, A466CentroCostosDetallesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CentroCostosDetalles"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z893CentroCostosDetallesEstado != T000P2_A893CentroCostosDetallesEstado[0] ) || ( StringUtil.StrCmp(Z473CentroCostosDetallesNombre, T000P2_A473CentroCostosDetallesNombre[0]) != 0 ) || ( Z468CentroCostosDetallesValor != T000P2_A468CentroCostosDetallesValor[0] ) || ( DateTimeUtil.ResetTime ( Z892CentroCostosDetallesFecha ) != DateTimeUtil.ResetTime ( T000P2_A892CentroCostosDetallesFecha[0] ) ) || ( Z888CentroCostosDetallesSolId != T000P2_A888CentroCostosDetallesSolId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z459ListaCostosId != T000P2_A459ListaCostosId[0] ) || ( StringUtil.StrCmp(Z890CCDetallesProfId, T000P2_A890CCDetallesProfId[0]) != 0 ) )
            {
               if ( Z893CentroCostosDetallesEstado != T000P2_A893CentroCostosDetallesEstado[0] )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosDetallesEstado");
                  GXUtil.WriteLogRaw("Old: ",Z893CentroCostosDetallesEstado);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A893CentroCostosDetallesEstado[0]);
               }
               if ( StringUtil.StrCmp(Z473CentroCostosDetallesNombre, T000P2_A473CentroCostosDetallesNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosDetallesNombre");
                  GXUtil.WriteLogRaw("Old: ",Z473CentroCostosDetallesNombre);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A473CentroCostosDetallesNombre[0]);
               }
               if ( Z468CentroCostosDetallesValor != T000P2_A468CentroCostosDetallesValor[0] )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosDetallesValor");
                  GXUtil.WriteLogRaw("Old: ",Z468CentroCostosDetallesValor);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A468CentroCostosDetallesValor[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z892CentroCostosDetallesFecha ) != DateTimeUtil.ResetTime ( T000P2_A892CentroCostosDetallesFecha[0] ) )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosDetallesFecha");
                  GXUtil.WriteLogRaw("Old: ",Z892CentroCostosDetallesFecha);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A892CentroCostosDetallesFecha[0]);
               }
               if ( Z888CentroCostosDetallesSolId != T000P2_A888CentroCostosDetallesSolId[0] )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CentroCostosDetallesSolId");
                  GXUtil.WriteLogRaw("Old: ",Z888CentroCostosDetallesSolId);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A888CentroCostosDetallesSolId[0]);
               }
               if ( Z459ListaCostosId != T000P2_A459ListaCostosId[0] )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"ListaCostosId");
                  GXUtil.WriteLogRaw("Old: ",Z459ListaCostosId);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A459ListaCostosId[0]);
               }
               if ( StringUtil.StrCmp(Z890CCDetallesProfId, T000P2_A890CCDetallesProfId[0]) != 0 )
               {
                  GXUtil.WriteLog("costoservicios:[seudo value changed for attri]"+"CCDetallesProfId");
                  GXUtil.WriteLogRaw("Old: ",Z890CCDetallesProfId);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A890CCDetallesProfId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CentroCostosDetalles"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0P70( )
      {
         BeforeValidate0P70( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P70( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0P70( 0) ;
            CheckOptimisticConcurrency0P70( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P70( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0P70( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P28 */
                     pr_default.execute(22, new Object[] {A461CentroCostosId, A466CentroCostosDetallesId, A893CentroCostosDetallesEstado, A473CentroCostosDetallesNombre, A468CentroCostosDetallesValor, A892CentroCostosDetallesFecha, A888CentroCostosDetallesSolId, n459ListaCostosId, A459ListaCostosId, A890CCDetallesProfId});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("CentroCostosDetalles");
                     if ( (pr_default.getStatus(22) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) )
                        {
                           GXCCtl = "CENTROCOSTOSDETALLESFECHA_" + sGXsfl_65_idx;
                           GX_msglist.addItem(context.GetMessage( "Fecha anterior a cierre.", ""), 1, GXCCtl);
                           AnyError = 1;
                           GX_FocusControl = edtCentroCostosDetallesFecha_Internalname;
                           AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                        }
                        new altasubsolicitud(context ).execute(  A461CentroCostosId,  A466CentroCostosDetallesId,  A892CentroCostosDetallesFecha,  A893CentroCostosDetallesEstado,  A473CentroCostosDetallesNombre,  A468CentroCostosDetallesValor,  A890CCDetallesProfId,  AV8CentroCostosRef, out  AV23NewSolicitudId, out  AV24IsOk, out  AV25TxtMsg) ;
                        AssignAttri("", false, "AV23NewSolicitudId", StringUtil.LTrimStr( (decimal)(AV23NewSolicitudId), 18, 0));
                        AssignAttri("", false, "AV24IsOk", AV24IsOk);
                        AssignAttri("", false, "AV25TxtMsg", AV25TxtMsg);
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
               Load0P70( ) ;
            }
            EndLevel0P70( ) ;
         }
         CloseExtendedTableCursors0P70( ) ;
      }

      protected void Update0P70( )
      {
         BeforeValidate0P70( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P70( ) ;
         }
         if ( ( nIsMod_70 != 0 ) || ( nIsDirty_70 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0P70( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0P70( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0P70( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000P29 */
                        pr_default.execute(23, new Object[] {A893CentroCostosDetallesEstado, A473CentroCostosDetallesNombre, A468CentroCostosDetallesValor, A892CentroCostosDetallesFecha, A888CentroCostosDetallesSolId, n459ListaCostosId, A459ListaCostosId, A890CCDetallesProfId, A461CentroCostosId, A466CentroCostosDetallesId});
                        pr_default.close(23);
                        pr_default.SmartCacheProvider.SetUpdated("CentroCostosDetalles");
                        if ( (pr_default.getStatus(23) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CentroCostosDetalles"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0P70( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ( A888CentroCostosDetallesSolId != 0 ) && (AV36SolicitudesIdCollection.IndexOf(A888CentroCostosDetallesSolId)>0) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) )
                           {
                              GXCCtl = "CENTROCOSTOSDETALLESFECHA_" + sGXsfl_65_idx;
                              GX_msglist.addItem(context.GetMessage( "Fecha anterior a cierre. Los datos no serán guardados.", ""), 1, GXCCtl);
                              AnyError = 1;
                              GX_FocusControl = edtCentroCostosDetallesFecha_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0P70( ) ;
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
               EndLevel0P70( ) ;
            }
         }
         CloseExtendedTableCursors0P70( ) ;
      }

      protected void DeferredUpdate0P70( )
      {
      }

      protected void Delete0P70( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0P70( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P70( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0P70( ) ;
            AfterConfirm0P70( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0P70( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000P30 */
                  pr_default.execute(24, new Object[] {A461CentroCostosId, A466CentroCostosDetallesId});
                  pr_default.close(24);
                  pr_default.SmartCacheProvider.SetUpdated("CentroCostosDetalles");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( "ADMINISTRATOR", "")) == 0 ) )
                     {
                        GXCCtl = "CENTROCOSTOSDETALLESFECHA_" + sGXsfl_65_idx;
                        GX_msglist.addItem(context.GetMessage( "Fecha anterior a cierre.", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCentroCostosDetallesFecha_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
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
         sMode70 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0P70( ) ;
         Gx_mode = sMode70;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0P70( )
      {
         standaloneModal0P70( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
            {
               edtCentroCostosDetallesFecha_Enabled = 0;
               AssignProp("", false, edtCentroCostosDetallesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            else
            {
               edtCentroCostosDetallesFecha_Enabled = 1;
               AssignProp("", false, edtCentroCostosDetallesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
            {
               edtCentroCostosDetallesId_Enabled = 0;
               AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            else
            {
               if ( true )
               {
                  edtCentroCostosDetallesId_Enabled = 1;
                  AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               }
               else
               {
                  edtCentroCostosDetallesId_Enabled = 0;
                  AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
               }
            }
            if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
            {
               edtListaCostosId_Enabled = 0;
               AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            else
            {
               edtListaCostosId_Enabled = 1;
               AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
            {
               edtCentroCostosDetallesNombre_Enabled = 0;
               AssignProp("", false, edtCentroCostosDetallesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            else
            {
               edtCentroCostosDetallesNombre_Enabled = 1;
               AssignProp("", false, edtCentroCostosDetallesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
            {
               edtCentroCostosDetallesValor_Enabled = 0;
               AssignProp("", false, edtCentroCostosDetallesValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            else
            {
               edtCentroCostosDetallesValor_Enabled = 1;
               AssignProp("", false, edtCentroCostosDetallesValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
            {
               edtCCDetallesProfId_Enabled = 0;
               AssignProp("", false, edtCCDetallesProfId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCDetallesProfId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            else
            {
               edtCCDetallesProfId_Enabled = 1;
               AssignProp("", false, edtCCDetallesProfId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCDetallesProfId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            if ( ( DateTimeUtil.ResetTime ( A892CentroCostosDetallesFecha ) < DateTimeUtil.ResetTime ( AV31FechaCierreSolicitud ) ) && ! ( StringUtil.StrCmp(StringUtil.Trim( AV32RoleName), context.GetMessage( context.GetMessage( "ADMINISTRATOR", ""), "")) == 0 ) )
            {
               cmbCentroCostosDetallesEstado.Enabled = 0;
               AssignProp("", false, cmbCentroCostosDetallesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            else
            {
               cmbCentroCostosDetallesEstado.Enabled = 1;
               AssignProp("", false, cmbCentroCostosDetallesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0), !bGXsfl_65_Refreshing);
            }
            /* Using cursor T000P31 */
            pr_default.execute(25, new Object[] {n459ListaCostosId, A459ListaCostosId});
            A460ListaCostosNombre = T000P31_A460ListaCostosNombre[0];
            A471ListaCostosValor = T000P31_A471ListaCostosValor[0];
            pr_default.close(25);
            if ( IsIns( )  )
            {
               A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal+A468CentroCostosDetallesValor);
               n469CentroCostosSubTotal = false;
               AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal+A468CentroCostosDetallesValor-O468CentroCostosDetallesValor);
                  n469CentroCostosSubTotal = false;
                  AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A469CentroCostosSubTotal = (decimal)(O469CentroCostosSubTotal-O468CentroCostosDetallesValor);
                     n469CentroCostosSubTotal = false;
                     AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
                  }
               }
            }
            if ( true /* After */ && ( A469CentroCostosSubTotal > Convert.ToDecimal( 0 )) && IsIns( )  )
            {
               A475CentroCostosCosto = A469CentroCostosSubTotal;
               AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
            }
            /* Using cursor T000P32 */
            pr_default.execute(26, new Object[] {A890CCDetallesProfId});
            A167ProfesionalesApellidoPrimero = T000P32_A167ProfesionalesApellidoPrimero[0];
            n167ProfesionalesApellidoPrimero = T000P32_n167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = T000P32_A166ProfesionalesPrimerNombre[0];
            n166ProfesionalesPrimerNombre = T000P32_n166ProfesionalesPrimerNombre[0];
            A191ProfesionalesSegundoNombre = T000P32_A191ProfesionalesSegundoNombre[0];
            n191ProfesionalesSegundoNombre = T000P32_n191ProfesionalesSegundoNombre[0];
            pr_default.close(26);
            A891CCDetallesProfNombre = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
         }
      }

      protected void EndLevel0P70( )
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

      public void ScanStart0P70( )
      {
         /* Scan By routine */
         /* Using cursor T000P33 */
         pr_default.execute(27, new Object[] {A461CentroCostosId});
         RcdFound70 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound70 = 1;
            A466CentroCostosDetallesId = T000P33_A466CentroCostosDetallesId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0P70( )
      {
         /* Scan next routine */
         pr_default.readNext(27);
         RcdFound70 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound70 = 1;
            A466CentroCostosDetallesId = T000P33_A466CentroCostosDetallesId[0];
         }
      }

      protected void ScanEnd0P70( )
      {
         pr_default.close(27);
      }

      protected void AfterConfirm0P70( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0P70( )
      {
         /* Before Insert Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A890CCDetallesProfId)) && ! ((A459ListaCostosId==5)||(A459ListaCostosId==6)) )
         {
            GXCCtl = "LISTACOSTOSID_" + sGXsfl_65_idx;
            GX_msglist.addItem(context.GetMessage( "Debe asignar un Profesional", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtListaCostosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void BeforeUpdate0P70( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0P70( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0P70( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0P70( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0P70( )
      {
         edtCentroCostosDetallesFecha_Enabled = 0;
         AssignProp("", false, edtCentroCostosDetallesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtCentroCostosDetallesId_Enabled = 0;
         AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtListaCostosId_Enabled = 0;
         AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtCentroCostosDetallesNombre_Enabled = 0;
         AssignProp("", false, edtCentroCostosDetallesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtCentroCostosDetallesValor_Enabled = 0;
         AssignProp("", false, edtCentroCostosDetallesValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtCentroCostosDetallesSolId_Enabled = 0;
         AssignProp("", false, edtCentroCostosDetallesSolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesSolId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtCCDetallesProfId_Enabled = 0;
         AssignProp("", false, edtCCDetallesProfId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCDetallesProfId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtCCDetallesProfNombre_Enabled = 0;
         AssignProp("", false, edtCCDetallesProfNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCDetallesProfNombre_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         cmbCentroCostosDetallesEstado.Enabled = 0;
         AssignProp("", false, cmbCentroCostosDetallesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0), !bGXsfl_65_Refreshing);
      }

      protected void send_integrity_lvl_hashes0P70( )
      {
      }

      protected void send_integrity_lvl_hashes0P69( )
      {
      }

      protected void SubsflControlProps_6570( )
      {
         edtCentroCostosDetallesFecha_Internalname = "CENTROCOSTOSDETALLESFECHA_"+sGXsfl_65_idx;
         edtCentroCostosDetallesId_Internalname = "CENTROCOSTOSDETALLESID_"+sGXsfl_65_idx;
         edtListaCostosId_Internalname = "LISTACOSTOSID_"+sGXsfl_65_idx;
         imgprompt_459_Internalname = "PROMPT_459_"+sGXsfl_65_idx;
         edtCentroCostosDetallesNombre_Internalname = "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_65_idx;
         edtCentroCostosDetallesValor_Internalname = "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_65_idx;
         edtCentroCostosDetallesSolId_Internalname = "CENTROCOSTOSDETALLESSOLID_"+sGXsfl_65_idx;
         edtCCDetallesProfId_Internalname = "CCDETALLESPROFID_"+sGXsfl_65_idx;
         imgprompt_890_Internalname = "PROMPT_890_"+sGXsfl_65_idx;
         edtCCDetallesProfNombre_Internalname = "CCDETALLESPROFNOMBRE_"+sGXsfl_65_idx;
         cmbCentroCostosDetallesEstado_Internalname = "CENTROCOSTOSDETALLESESTADO_"+sGXsfl_65_idx;
      }

      protected void SubsflControlProps_fel_6570( )
      {
         edtCentroCostosDetallesFecha_Internalname = "CENTROCOSTOSDETALLESFECHA_"+sGXsfl_65_fel_idx;
         edtCentroCostosDetallesId_Internalname = "CENTROCOSTOSDETALLESID_"+sGXsfl_65_fel_idx;
         edtListaCostosId_Internalname = "LISTACOSTOSID_"+sGXsfl_65_fel_idx;
         imgprompt_459_Internalname = "PROMPT_459_"+sGXsfl_65_fel_idx;
         edtCentroCostosDetallesNombre_Internalname = "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_65_fel_idx;
         edtCentroCostosDetallesValor_Internalname = "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_65_fel_idx;
         edtCentroCostosDetallesSolId_Internalname = "CENTROCOSTOSDETALLESSOLID_"+sGXsfl_65_fel_idx;
         edtCCDetallesProfId_Internalname = "CCDETALLESPROFID_"+sGXsfl_65_fel_idx;
         imgprompt_890_Internalname = "PROMPT_890_"+sGXsfl_65_fel_idx;
         edtCCDetallesProfNombre_Internalname = "CCDETALLESPROFNOMBRE_"+sGXsfl_65_fel_idx;
         cmbCentroCostosDetallesEstado_Internalname = "CENTROCOSTOSDETALLESESTADO_"+sGXsfl_65_fel_idx;
      }

      protected void AddRow0P70( )
      {
         nGXsfl_65_idx = (int)(nGXsfl_65_idx+1);
         sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
         SubsflControlProps_6570( ) ;
         SendRow0P70( ) ;
      }

      protected void SendRow0P70( )
      {
         Gridlevel_detallesRow = GXWebRow.GetNew(context);
         if ( subGridlevel_detalles_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_detalles_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_detalles_Class, "") != 0 )
            {
               subGridlevel_detalles_Linesclass = subGridlevel_detalles_Class+"Odd";
            }
         }
         else if ( subGridlevel_detalles_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_detalles_Backstyle = 0;
            subGridlevel_detalles_Backcolor = subGridlevel_detalles_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_detalles_Class, "") != 0 )
            {
               subGridlevel_detalles_Linesclass = subGridlevel_detalles_Class+"Uniform";
            }
         }
         else if ( subGridlevel_detalles_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_detalles_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_detalles_Class, "") != 0 )
            {
               subGridlevel_detalles_Linesclass = subGridlevel_detalles_Class+"Odd";
            }
            subGridlevel_detalles_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_detalles_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_detalles_Backstyle = 1;
            if ( ((int)((nGXsfl_65_idx) % (2))) == 0 )
            {
               subGridlevel_detalles_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_detalles_Class, "") != 0 )
               {
                  subGridlevel_detalles_Linesclass = subGridlevel_detalles_Class+"Even";
               }
            }
            else
            {
               subGridlevel_detalles_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_detalles_Class, "") != 0 )
               {
                  subGridlevel_detalles_Linesclass = subGridlevel_detalles_Class+"Odd";
               }
            }
         }
         imgprompt_890_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"profesionalesfullnameprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CCDETALLESPROFID_"+sGXsfl_65_idx+"'), id:'"+"CCDETALLESPROFID_"+sGXsfl_65_idx+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"vFULLNAME"+"'), id:'"+"vFULLNAME"+"'"+",IOType:'inout'}"+"],"+"gx.dom.form()."+"nIsMod_70_"+sGXsfl_65_idx+","+"'', false"+","+"false"+");");
         imgprompt_459_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx01w0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"LISTACOSTOSID_"+sGXsfl_65_idx+"'), id:'"+"LISTACOSTOSID_"+sGXsfl_65_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_70_"+sGXsfl_65_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_65_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_65_idx + "',65)\"";
         ROClassString = "Attribute";
         Gridlevel_detallesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosDetallesFecha_Internalname,context.localUtil.Format(A892CentroCostosDetallesFecha, "99/99/99"),context.localUtil.Format( A892CentroCostosDetallesFecha, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,66);\"","'"+""+"'"+",false,"+"'"+"ECENTROCOSTOSDETALLESFECHA.CLICK."+sGXsfl_65_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosDetallesFecha_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCentroCostosDetallesFecha_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_65_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_65_idx + "',65)\"";
         ROClassString = "Attribute";
         Gridlevel_detallesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosDetallesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A466CentroCostosDetallesId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,67);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosDetallesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn hidden-xs hidden-sm hidden-md hidden-lg",(string)"",(short)-1,(int)edtCentroCostosDetallesId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_65_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_65_idx + "',65)\"";
         ROClassString = "Attribute";
         Gridlevel_detallesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtListaCostosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A459ListaCostosId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,68);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtListaCostosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtListaCostosId_Enabled,(short)1,(string)"text",(string)"1",(short)50,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_459_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_459_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_detallesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_459_Internalname,(string)sImgUrl,(string)imgprompt_459_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_459_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_65_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_65_idx + "',65)\"";
         ROClassString = "Attribute";
         Gridlevel_detallesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosDetallesNombre_Internalname,StringUtil.RTrim( A473CentroCostosDetallesNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosDetallesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCentroCostosDetallesNombre_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_65_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_65_idx + "',65)\"";
         ROClassString = "Attribute";
         Gridlevel_detallesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosDetallesValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A468CentroCostosDetallesValor, "ZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,70);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosDetallesValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn ColumnAlignLeft ColumnAlignLeft",(string)"",(short)-1,(int)edtCentroCostosDetallesValor_Enabled,(short)1,(string)"text",(string)"",(short)80,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_65_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_65_idx + "',65)\"";
         ROClassString = "Attribute";
         Gridlevel_detallesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCentroCostosDetallesSolId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A888CentroCostosDetallesSolId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtCentroCostosDetallesSolId_Enabled!=0) ? context.localUtil.Format( (decimal)(A888CentroCostosDetallesSolId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A888CentroCostosDetallesSolId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,71);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCentroCostosDetallesSolId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn ColumnAlignCenter ColumnAlignCenter",(string)"",(short)-1,(int)edtCentroCostosDetallesSolId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_65_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_65_idx + "',65)\"";
         ROClassString = "Attribute";
         Gridlevel_detallesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCCDetallesProfId_Internalname,StringUtil.RTrim( A890CCDetallesProfId),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtCCDetallesProfId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCCDetallesProfId_Enabled,(short)1,(string)"text",(string)"",(short)100,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_890_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_890_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_detallesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_890_Internalname,(string)sImgUrl,(string)imgprompt_890_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_890_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_65_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_65_idx + "',65)\"";
         ROClassString = "Attribute";
         Gridlevel_detallesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCCDetallesProfNombre_Internalname,(string)A891CCDetallesProfNombre,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCCDetallesProfNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtCCDetallesProfNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)65,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_70_" + sGXsfl_65_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_65_idx + "',65)\"";
         GXCCtl = "CENTROCOSTOSDETALLESESTADO_" + sGXsfl_65_idx;
         cmbCentroCostosDetallesEstado.Name = GXCCtl;
         cmbCentroCostosDetallesEstado.WebTags = "";
         cmbCentroCostosDetallesEstado.addItem("1", context.GetMessage( "Ingresada", ""), 0);
         cmbCentroCostosDetallesEstado.addItem("2", context.GetMessage( "Asignada", ""), 0);
         cmbCentroCostosDetallesEstado.addItem("3", context.GetMessage( "Cancelada", ""), 0);
         cmbCentroCostosDetallesEstado.addItem("5", context.GetMessage( "Aceptada", ""), 0);
         cmbCentroCostosDetallesEstado.addItem("6", context.GetMessage( "Finalizada", ""), 0);
         if ( cmbCentroCostosDetallesEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A893CentroCostosDetallesEstado) )
            {
               A893CentroCostosDetallesEstado = 1;
            }
         }
         /* ComboBox */
         Gridlevel_detallesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbCentroCostosDetallesEstado,(string)cmbCentroCostosDetallesEstado_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A893CentroCostosDetallesEstado), 18, 0)),(short)1,(string)cmbCentroCostosDetallesEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbCentroCostosDetallesEstado.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"",(string)"",(bool)true,(short)0});
         cmbCentroCostosDetallesEstado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A893CentroCostosDetallesEstado), 18, 0));
         AssignProp("", false, cmbCentroCostosDetallesEstado_Internalname, "Values", (string)(cmbCentroCostosDetallesEstado.ToJavascriptSource()), !bGXsfl_65_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_detallesRow);
         send_integrity_lvl_hashes0P70( ) ;
         GXCCtl = "Z466CentroCostosDetallesId_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z893CentroCostosDetallesEstado_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z893CentroCostosDetallesEstado), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z473CentroCostosDetallesNombre_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z473CentroCostosDetallesNombre));
         GXCCtl = "Z468CentroCostosDetallesValor_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z892CentroCostosDetallesFecha_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z892CentroCostosDetallesFecha, 0, "/"));
         GXCCtl = "Z888CentroCostosDetallesSolId_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z888CentroCostosDetallesSolId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z459ListaCostosId_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z890CCDetallesProfId_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z890CCDetallesProfId));
         GXCCtl = "O468CentroCostosDetallesValor_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( O468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_70_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_70), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_70_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_70), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_70_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_70), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "N466CentroCostosDetallesId_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "N892CentroCostosDetallesFecha_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( A892CentroCostosDetallesFecha, 0, "/"));
         GXCCtl = "N459ListaCostosId_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "N473CentroCostosDetallesNombre_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( A473CentroCostosDetallesNombre));
         GXCCtl = "N468CentroCostosDetallesValor_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "N890CCDetallesProfId_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( A890CCDetallesProfId));
         GXCCtl = "N893CentroCostosDetallesEstado_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(A893CentroCostosDetallesEstado), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vROLENAME_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV32RoleName));
         GXCCtl = "vMODE_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vCENTROCOSTOSID_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vCENTROCOSTOSREF_" + sGXsfl_65_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESFECHA_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESID_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LISTACOSTOSID_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaCostosId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESSOLID_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesSolId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CCDETALLESPROFID_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCCDetallesProfId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CCDETALLESPROFNOMBRE_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCCDetallesProfNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSDETALLESESTADO_"+sGXsfl_65_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_459_"+sGXsfl_65_idx+"Link", StringUtil.RTrim( imgprompt_459_Link));
         GxWebStd.gx_hidden_field( context, "PROMPT_890_"+sGXsfl_65_idx+"Link", StringUtil.RTrim( imgprompt_890_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_detallesContainer.AddRow(Gridlevel_detallesRow);
      }

      protected void ReadRow0P70( )
      {
         nGXsfl_65_idx = (int)(nGXsfl_65_idx+1);
         sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
         SubsflControlProps_6570( ) ;
         edtCentroCostosDetallesFecha_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESFECHA_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCentroCostosDetallesId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESID_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtListaCostosId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "LISTACOSTOSID_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCentroCostosDetallesNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESNOMBRE_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCentroCostosDetallesValor_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESVALOR_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCentroCostosDetallesSolId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESSOLID_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCCDetallesProfId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CCDETALLESPROFID_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtCCDetallesProfNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CCDETALLESPROFNOMBRE_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbCentroCostosDetallesEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CENTROCOSTOSDETALLESESTADO_"+sGXsfl_65_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_459_Link = cgiGet( "PROMPT_459_"+sGXsfl_65_idx+"Link");
         imgprompt_459_Link = cgiGet( "PROMPT_890_"+sGXsfl_65_idx+"Link");
         if ( context.localUtil.VCDate( cgiGet( edtCentroCostosDetallesFecha_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
         {
            GXCCtl = "CENTROCOSTOSDETALLESFECHA_" + sGXsfl_65_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Costo Servicios Detalles Fecha", "")}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCentroCostosDetallesFecha_Internalname;
            wbErr = true;
            A892CentroCostosDetallesFecha = DateTime.MinValue;
         }
         else
         {
            A892CentroCostosDetallesFecha = context.localUtil.CToD( cgiGet( edtCentroCostosDetallesFecha_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
         }
         A466CentroCostosDetallesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosDetallesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "LISTACOSTOSID_" + sGXsfl_65_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtListaCostosId_Internalname;
            wbErr = true;
            A459ListaCostosId = 0;
            n459ListaCostosId = false;
         }
         else
         {
            A459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtListaCostosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n459ListaCostosId = false;
         }
         n459ListaCostosId = ((0==A459ListaCostosId) ? true : false);
         A473CentroCostosDetallesNombre = cgiGet( edtCentroCostosDetallesNombre_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtCentroCostosDetallesValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCentroCostosDetallesValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
         {
            GXCCtl = "CENTROCOSTOSDETALLESVALOR_" + sGXsfl_65_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCentroCostosDetallesValor_Internalname;
            wbErr = true;
            A468CentroCostosDetallesValor = 0;
         }
         else
         {
            A468CentroCostosDetallesValor = context.localUtil.CToN( cgiGet( edtCentroCostosDetallesValor_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         }
         A888CentroCostosDetallesSolId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCentroCostosDetallesSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A890CCDetallesProfId = cgiGet( edtCCDetallesProfId_Internalname);
         A891CCDetallesProfNombre = cgiGet( edtCCDetallesProfNombre_Internalname);
         cmbCentroCostosDetallesEstado.Name = cmbCentroCostosDetallesEstado_Internalname;
         cmbCentroCostosDetallesEstado.CurrentValue = cgiGet( cmbCentroCostosDetallesEstado_Internalname);
         A893CentroCostosDetallesEstado = (long)(Math.Round(NumberUtil.Val( cgiGet( cmbCentroCostosDetallesEstado_Internalname), "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z466CentroCostosDetallesId_" + sGXsfl_65_idx;
         Z466CentroCostosDetallesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z893CentroCostosDetallesEstado_" + sGXsfl_65_idx;
         Z893CentroCostosDetallesEstado = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z473CentroCostosDetallesNombre_" + sGXsfl_65_idx;
         Z473CentroCostosDetallesNombre = cgiGet( GXCCtl);
         GXCCtl = "Z468CentroCostosDetallesValor_" + sGXsfl_65_idx;
         Z468CentroCostosDetallesValor = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "Z892CentroCostosDetallesFecha_" + sGXsfl_65_idx;
         Z892CentroCostosDetallesFecha = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         GXCCtl = "Z888CentroCostosDetallesSolId_" + sGXsfl_65_idx;
         Z888CentroCostosDetallesSolId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z459ListaCostosId_" + sGXsfl_65_idx;
         Z459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n459ListaCostosId = ((0==A459ListaCostosId) ? true : false);
         GXCCtl = "Z890CCDetallesProfId_" + sGXsfl_65_idx;
         Z890CCDetallesProfId = cgiGet( GXCCtl);
         GXCCtl = "O468CentroCostosDetallesValor_" + sGXsfl_65_idx;
         O468CentroCostosDetallesValor = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "nRcdDeleted_70_" + sGXsfl_65_idx;
         nRcdDeleted_70 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_70_" + sGXsfl_65_idx;
         nRcdExists_70 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_70_" + sGXsfl_65_idx;
         nIsMod_70 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "N466CentroCostosDetallesId_" + sGXsfl_65_idx;
         N466CentroCostosDetallesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "N892CentroCostosDetallesFecha_" + sGXsfl_65_idx;
         N892CentroCostosDetallesFecha = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         GXCCtl = "N459ListaCostosId_" + sGXsfl_65_idx;
         N459ListaCostosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n459ListaCostosId = ((0==A459ListaCostosId) ? true : false);
         GXCCtl = "N473CentroCostosDetallesNombre_" + sGXsfl_65_idx;
         N473CentroCostosDetallesNombre = cgiGet( GXCCtl);
         GXCCtl = "N468CentroCostosDetallesValor_" + sGXsfl_65_idx;
         N468CentroCostosDetallesValor = context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
         GXCCtl = "N890CCDetallesProfId_" + sGXsfl_65_idx;
         N890CCDetallesProfId = cgiGet( GXCCtl);
         GXCCtl = "N893CentroCostosDetallesEstado_" + sGXsfl_65_idx;
         N893CentroCostosDetallesEstado = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defcmbCentroCostosDetallesEstado_Enabled = cmbCentroCostosDetallesEstado.Enabled;
         defedtCCDetallesProfId_Enabled = edtCCDetallesProfId_Enabled;
         defedtCentroCostosDetallesSolId_Enabled = edtCentroCostosDetallesSolId_Enabled;
         defedtCentroCostosDetallesValor_Enabled = edtCentroCostosDetallesValor_Enabled;
         defedtCentroCostosDetallesNombre_Enabled = edtCentroCostosDetallesNombre_Enabled;
         defedtListaCostosId_Enabled = edtListaCostosId_Enabled;
         defedtCentroCostosDetallesId_Enabled = edtCentroCostosDetallesId_Enabled;
         defedtCentroCostosDetallesFecha_Enabled = edtCentroCostosDetallesFecha_Enabled;
      }

      protected void ConfirmValues0P0( )
      {
         nGXsfl_65_idx = 0;
         sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
         SubsflControlProps_6570( ) ;
         while ( nGXsfl_65_idx < nRC_GXsfl_65 )
         {
            nGXsfl_65_idx = (int)(nGXsfl_65_idx+1);
            sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
            SubsflControlProps_6570( ) ;
            ChangePostValue( "Z466CentroCostosDetallesId_"+sGXsfl_65_idx, cgiGet( "ZT_"+"Z466CentroCostosDetallesId_"+sGXsfl_65_idx)) ;
            DeletePostValue( "ZT_"+"Z466CentroCostosDetallesId_"+sGXsfl_65_idx) ;
            ChangePostValue( "Z893CentroCostosDetallesEstado_"+sGXsfl_65_idx, cgiGet( "ZT_"+"Z893CentroCostosDetallesEstado_"+sGXsfl_65_idx)) ;
            DeletePostValue( "ZT_"+"Z893CentroCostosDetallesEstado_"+sGXsfl_65_idx) ;
            ChangePostValue( "Z473CentroCostosDetallesNombre_"+sGXsfl_65_idx, cgiGet( "ZT_"+"Z473CentroCostosDetallesNombre_"+sGXsfl_65_idx)) ;
            DeletePostValue( "ZT_"+"Z473CentroCostosDetallesNombre_"+sGXsfl_65_idx) ;
            ChangePostValue( "Z468CentroCostosDetallesValor_"+sGXsfl_65_idx, cgiGet( "ZT_"+"Z468CentroCostosDetallesValor_"+sGXsfl_65_idx)) ;
            DeletePostValue( "ZT_"+"Z468CentroCostosDetallesValor_"+sGXsfl_65_idx) ;
            ChangePostValue( "Z892CentroCostosDetallesFecha_"+sGXsfl_65_idx, cgiGet( "ZT_"+"Z892CentroCostosDetallesFecha_"+sGXsfl_65_idx)) ;
            DeletePostValue( "ZT_"+"Z892CentroCostosDetallesFecha_"+sGXsfl_65_idx) ;
            ChangePostValue( "Z888CentroCostosDetallesSolId_"+sGXsfl_65_idx, cgiGet( "ZT_"+"Z888CentroCostosDetallesSolId_"+sGXsfl_65_idx)) ;
            DeletePostValue( "ZT_"+"Z888CentroCostosDetallesSolId_"+sGXsfl_65_idx) ;
            ChangePostValue( "Z459ListaCostosId_"+sGXsfl_65_idx, cgiGet( "ZT_"+"Z459ListaCostosId_"+sGXsfl_65_idx)) ;
            DeletePostValue( "ZT_"+"Z459ListaCostosId_"+sGXsfl_65_idx) ;
            ChangePostValue( "Z890CCDetallesProfId_"+sGXsfl_65_idx, cgiGet( "ZT_"+"Z890CCDetallesProfId_"+sGXsfl_65_idx)) ;
            DeletePostValue( "ZT_"+"Z890CCDetallesProfId_"+sGXsfl_65_idx) ;
         }
         ChangePostValue( "O468CentroCostosDetallesValor", cgiGet( "T468CentroCostosDetallesValor")) ;
         DeletePostValue( "T468CentroCostosDetallesValor") ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("costoservicios.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CentroCostosId,18,0)),UrlEncode(StringUtil.LTrimStr(AV8CentroCostosRef,18,0))}, new string[] {"Gx_mode","CentroCostosId","CentroCostosRef"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CostoServicios");
         forbiddenHiddens.Add("CentroCostosId", context.localUtil.Format( (decimal)(A461CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("CentroCostosTipoRef", StringUtil.RTrim( context.localUtil.Format( A487CentroCostosTipoRef, "")));
         forbiddenHiddens.Add("CentroCostosRef", context.localUtil.Format( (decimal)(A462CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("CentroCostosPrecioFinal", context.localUtil.Format( A464CentroCostosPrecioFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("FechaCierreSolicitud", context.localUtil.Format(AV31FechaCierreSolicitud, "99/99/99"));
         forbiddenHiddens.Add("RoleName", StringUtil.RTrim( context.localUtil.Format( AV32RoleName, "")));
         forbiddenHiddens.Add("CentroCostosUsrAlta", StringUtil.RTrim( context.localUtil.Format( A478CentroCostosUsrAlta, "")));
         forbiddenHiddens.Add("CentroCostosUsrMod", StringUtil.RTrim( context.localUtil.Format( A479CentroCostosUsrMod, "")));
         forbiddenHiddens.Add("CentroCostosHoraAlt", context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"));
         forbiddenHiddens.Add("CentroCostosHoraMod", context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"));
         forbiddenHiddens.Add("CentroCostosEstado", StringUtil.RTrim( context.localUtil.Format( A482CentroCostosEstado, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("costoservicios:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z461CentroCostosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z461CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z487CentroCostosTipoRef", StringUtil.RTrim( Z487CentroCostosTipoRef));
         GxWebStd.gx_hidden_field( context, "Z462CentroCostosRef", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z462CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z475CentroCostosCosto", StringUtil.LTrim( StringUtil.NToC( Z475CentroCostosCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z463CentroCostosNombre", StringUtil.RTrim( Z463CentroCostosNombre));
         GxWebStd.gx_hidden_field( context, "Z464CentroCostosPrecioFinal", StringUtil.LTrim( StringUtil.NToC( Z464CentroCostosPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z465CentroCostosSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z465CentroCostosSerial), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z478CentroCostosUsrAlta", StringUtil.RTrim( Z478CentroCostosUsrAlta));
         GxWebStd.gx_hidden_field( context, "Z479CentroCostosUsrMod", StringUtil.RTrim( Z479CentroCostosUsrMod));
         GxWebStd.gx_hidden_field( context, "Z480CentroCostosHoraAlt", context.localUtil.DToC( Z480CentroCostosHoraAlt, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z481CentroCostosHoraMod", context.localUtil.DToC( Z481CentroCostosHoraMod, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z482CentroCostosEstado", StringUtil.RTrim( Z482CentroCostosEstado));
         GxWebStd.gx_hidden_field( context, "O465CentroCostosSerial", StringUtil.LTrim( StringUtil.NToC( (decimal)(O465CentroCostosSerial), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O469CentroCostosSubTotal", StringUtil.LTrim( StringUtil.NToC( O469CentroCostosSubTotal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_65", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_65_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSCOSTO", StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSGAM", StringUtil.LTrim( StringUtil.NToC( A474CentroCostosGam, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vCENTROCOSTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CentroCostosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCENTROCOSTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CentroCostosId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vROLENAME", StringUtil.RTrim( AV32RoleName));
         GxWebStd.gx_hidden_field( context, "vCENTROCOSTOSREF", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CentroCostosRef), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCENTROCOSTOSREF", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8CentroCostosRef), "ZZZZZZZZZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSOLICITUDESIDCOLLECTION", AV36SolicitudesIdCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSOLICITUDESIDCOLLECTION", AV36SolicitudesIdCollection);
         }
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSESTADO", StringUtil.RTrim( A482CentroCostosEstado));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSSERIAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(A465CentroCostosSerial), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSJSON", A889CentroCostosJson);
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSUSRALTA", StringUtil.RTrim( A478CentroCostosUsrAlta));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSUSRMOD", StringUtil.RTrim( A479CentroCostosUsrMod));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSHORAALT", context.localUtil.DToC( A480CentroCostosHoraAlt, 0, "/"));
         GxWebStd.gx_hidden_field( context, "CENTROCOSTOSHORAMOD", context.localUtil.DToC( A481CentroCostosHoraMod, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV40Pgmname));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAPELLIDOPRIMERO", StringUtil.RTrim( A167ProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESPRIMERNOMBRE", StringUtil.RTrim( A166ProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESSEGUNDONOMBRE", StringUtil.RTrim( A191ProfesionalesSegundoNombre));
         GxWebStd.gx_hidden_field( context, "vNEWSOLICITUDID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23NewSolicitudId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISOK", AV24IsOk);
         GxWebStd.gx_hidden_field( context, "vTXTMSG", AV25TxtMsg);
         GxWebStd.gx_hidden_field( context, "LISTACOSTOSNOMBRE", StringUtil.RTrim( A460ListaCostosNombre));
         GxWebStd.gx_hidden_field( context, "LISTACOSTOSVALOR", StringUtil.LTrim( StringUtil.NToC( A471ListaCostosValor, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
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
         return formatLink("costoservicios.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CentroCostosId,18,0)),UrlEncode(StringUtil.LTrimStr(AV8CentroCostosRef,18,0))}, new string[] {"Gx_mode","CentroCostosId","CentroCostosRef"})  ;
      }

      public override string GetPgmname( )
      {
         return "CostoServicios" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Costo Servicios", "") ;
      }

      protected void InitializeNonKey0P69( )
      {
         A487CentroCostosTipoRef = "";
         AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
         A462CentroCostosRef = 0;
         AssignAttri("", false, "A462CentroCostosRef", StringUtil.LTrimStr( (decimal)(A462CentroCostosRef), 18, 0));
         A475CentroCostosCosto = 0;
         AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrimStr( A475CentroCostosCosto, 18, 2));
         A474CentroCostosGam = 0;
         AssignAttri("", false, "A474CentroCostosGam", StringUtil.LTrimStr( A474CentroCostosGam, 18, 2));
         A463CentroCostosNombre = "";
         AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
         A464CentroCostosPrecioFinal = 0;
         AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
         A465CentroCostosSerial = 0;
         AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         A889CentroCostosJson = "";
         AssignAttri("", false, "A889CentroCostosJson", A889CentroCostosJson);
         A469CentroCostosSubTotal = 0;
         n469CentroCostosSubTotal = false;
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         A478CentroCostosUsrAlta = "";
         AssignAttri("", false, "A478CentroCostosUsrAlta", A478CentroCostosUsrAlta);
         A479CentroCostosUsrMod = "";
         AssignAttri("", false, "A479CentroCostosUsrMod", A479CentroCostosUsrMod);
         A480CentroCostosHoraAlt = DateTime.MinValue;
         AssignAttri("", false, "A480CentroCostosHoraAlt", context.localUtil.Format(A480CentroCostosHoraAlt, "99/99/99"));
         A481CentroCostosHoraMod = DateTime.MinValue;
         AssignAttri("", false, "A481CentroCostosHoraMod", context.localUtil.Format(A481CentroCostosHoraMod, "99/99/99"));
         A482CentroCostosEstado = context.GetMessage( "PND", "");
         AssignAttri("", false, "A482CentroCostosEstado", A482CentroCostosEstado);
         O465CentroCostosSerial = A465CentroCostosSerial;
         AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         O469CentroCostosSubTotal = A469CentroCostosSubTotal;
         n469CentroCostosSubTotal = false;
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrimStr( A469CentroCostosSubTotal, 18, 2));
         Z487CentroCostosTipoRef = "";
         Z462CentroCostosRef = 0;
         Z475CentroCostosCosto = 0;
         Z463CentroCostosNombre = "";
         Z464CentroCostosPrecioFinal = 0;
         Z465CentroCostosSerial = 0;
         Z478CentroCostosUsrAlta = "";
         Z479CentroCostosUsrMod = "";
         Z480CentroCostosHoraAlt = DateTime.MinValue;
         Z481CentroCostosHoraMod = DateTime.MinValue;
         Z482CentroCostosEstado = "";
      }

      protected void InitAll0P69( )
      {
         A461CentroCostosId = 0;
         AssignAttri("", false, "A461CentroCostosId", StringUtil.LTrimStr( (decimal)(A461CentroCostosId), 18, 0));
         InitializeNonKey0P69( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A487CentroCostosTipoRef = i487CentroCostosTipoRef;
         AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
         A482CentroCostosEstado = i482CentroCostosEstado;
         AssignAttri("", false, "A482CentroCostosEstado", A482CentroCostosEstado);
      }

      protected void InitializeNonKey0P70( )
      {
         A473CentroCostosDetallesNombre = "";
         A468CentroCostosDetallesValor = 0;
         AV23NewSolicitudId = 0;
         AssignAttri("", false, "AV23NewSolicitudId", StringUtil.LTrimStr( (decimal)(AV23NewSolicitudId), 18, 0));
         AV24IsOk = false;
         AssignAttri("", false, "AV24IsOk", AV24IsOk);
         AV25TxtMsg = "";
         AssignAttri("", false, "AV25TxtMsg", AV25TxtMsg);
         A892CentroCostosDetallesFecha = DateTime.MinValue;
         A459ListaCostosId = 0;
         n459ListaCostosId = false;
         A460ListaCostosNombre = "";
         AssignAttri("", false, "A460ListaCostosNombre", A460ListaCostosNombre);
         A471ListaCostosValor = 0;
         AssignAttri("", false, "A471ListaCostosValor", StringUtil.LTrimStr( A471ListaCostosValor, 18, 2));
         A890CCDetallesProfId = "";
         A891CCDetallesProfNombre = "";
         A888CentroCostosDetallesSolId = 0;
         A167ProfesionalesApellidoPrimero = "";
         n167ProfesionalesApellidoPrimero = false;
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
         A166ProfesionalesPrimerNombre = "";
         n166ProfesionalesPrimerNombre = false;
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
         A191ProfesionalesSegundoNombre = "";
         n191ProfesionalesSegundoNombre = false;
         AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
         A893CentroCostosDetallesEstado = 1;
         O468CentroCostosDetallesValor = A468CentroCostosDetallesValor;
         Z893CentroCostosDetallesEstado = 0;
         Z473CentroCostosDetallesNombre = "";
         Z468CentroCostosDetallesValor = 0;
         Z892CentroCostosDetallesFecha = DateTime.MinValue;
         Z888CentroCostosDetallesSolId = 0;
         Z459ListaCostosId = 0;
         Z890CCDetallesProfId = "";
      }

      protected void InitAll0P70( )
      {
         A466CentroCostosDetallesId = 0;
         InitializeNonKey0P70( ) ;
      }

      protected void StandaloneModalInsert0P70( )
      {
         A465CentroCostosSerial = i465CentroCostosSerial;
         AssignAttri("", false, "A465CentroCostosSerial", StringUtil.LTrimStr( (decimal)(A465CentroCostosSerial), 10, 0));
         A893CentroCostosDetallesEstado = i893CentroCostosDetallesEstado;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269212213652", true, true, false);
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
         context.AddJavascriptSource("costoservicios.js", "?20269212213652", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties70( )
      {
         cmbCentroCostosDetallesEstado.Enabled = defcmbCentroCostosDetallesEstado_Enabled;
         AssignProp("", false, cmbCentroCostosDetallesEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtCCDetallesProfId_Enabled = defedtCCDetallesProfId_Enabled;
         AssignProp("", false, edtCCDetallesProfId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCCDetallesProfId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtCentroCostosDetallesSolId_Enabled = defedtCentroCostosDetallesSolId_Enabled;
         AssignProp("", false, edtCentroCostosDetallesSolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesSolId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtCentroCostosDetallesValor_Enabled = defedtCentroCostosDetallesValor_Enabled;
         AssignProp("", false, edtCentroCostosDetallesValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtCentroCostosDetallesNombre_Enabled = defedtCentroCostosDetallesNombre_Enabled;
         AssignProp("", false, edtCentroCostosDetallesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtListaCostosId_Enabled = defedtListaCostosId_Enabled;
         AssignProp("", false, edtListaCostosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaCostosId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtCentroCostosDetallesId_Enabled = defedtCentroCostosDetallesId_Enabled;
         AssignProp("", false, edtCentroCostosDetallesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0), !bGXsfl_65_Refreshing);
         edtCentroCostosDetallesFecha_Enabled = defedtCentroCostosDetallesFecha_Enabled;
         AssignProp("", false, edtCentroCostosDetallesFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0), !bGXsfl_65_Refreshing);
      }

      protected void StartGridControl65( )
      {
         Gridlevel_detallesContainer.AddObjectProperty("GridName", "Gridlevel_detalles");
         Gridlevel_detallesContainer.AddObjectProperty("Header", subGridlevel_detalles_Header);
         Gridlevel_detallesContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_detallesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_detallesContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A892CentroCostosDetallesFecha, "99/99/99")));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesFecha_Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A466CentroCostosDetallesId), 18, 0, ".", ""))));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesId_Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A459ListaCostosId), 18, 0, ".", ""))));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtListaCostosId_Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A473CentroCostosDetallesNombre)));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, ".", ""))));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesValor_Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A888CentroCostosDetallesSolId), 18, 0, ".", ""))));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCentroCostosDetallesSolId_Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A890CCDetallesProfId)));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCCDetallesProfId_Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A891CCDetallesProfNombre));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCCDetallesProfNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_detallesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A893CentroCostosDetallesEstado), 18, 0, ".", ""))));
         Gridlevel_detallesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbCentroCostosDetallesEstado.Enabled), 5, 0, ".", "")));
         Gridlevel_detallesContainer.AddColumnProperties(Gridlevel_detallesColumn);
         Gridlevel_detallesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Selectedindex), 4, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Allowselection), 1, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Allowhovering), 1, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_detallesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_detalles_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtCentroCostosId_Internalname = "CENTROCOSTOSID";
         cmbCentroCostosTipoRef_Internalname = "CENTROCOSTOSTIPOREF";
         edtCentroCostosRef_Internalname = "CENTROCOSTOSREF";
         edtavCentrocostosnombre_Internalname = "vCENTROCOSTOSNOMBRE";
         edtavCentrocostospreciofinal_Internalname = "vCENTROCOSTOSPRECIOFINAL";
         edtCentroCostosSubTotal_Internalname = "CENTROCOSTOSSUBTOTAL";
         edtCentroCostosNombre_Internalname = "CENTROCOSTOSNOMBRE";
         edtCentroCostosPrecioFinal_Internalname = "CENTROCOSTOSPRECIOFINAL";
         edtavFechacierresolicitud_Internalname = "vFECHACIERRESOLICITUD";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         divTablecontent_Internalname = "TABLECONTENT";
         edtCentroCostosDetallesFecha_Internalname = "CENTROCOSTOSDETALLESFECHA";
         edtCentroCostosDetallesId_Internalname = "CENTROCOSTOSDETALLESID";
         edtListaCostosId_Internalname = "LISTACOSTOSID";
         edtCentroCostosDetallesNombre_Internalname = "CENTROCOSTOSDETALLESNOMBRE";
         edtCentroCostosDetallesValor_Internalname = "CENTROCOSTOSDETALLESVALOR";
         edtCentroCostosDetallesSolId_Internalname = "CENTROCOSTOSDETALLESSOLID";
         edtCCDetallesProfId_Internalname = "CCDETALLESPROFID";
         edtCCDetallesProfNombre_Internalname = "CCDETALLESPROFNOMBRE";
         cmbCentroCostosDetallesEstado_Internalname = "CENTROCOSTOSDETALLESESTADO";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divTableleaflevel_detalles_Internalname = "TABLELEAFLEVEL_DETALLES";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         chkavError_Internalname = "vERROR";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_459_Internalname = "PROMPT_459";
         imgprompt_890_Internalname = "PROMPT_890";
         subGridlevel_detalles_Internalname = "GRIDLEVEL_DETALLES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_detalles_Allowcollapsing = 0;
         subGridlevel_detalles_Allowselection = 0;
         subGridlevel_detalles_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Costo Servicios", "");
         cmbCentroCostosDetallesEstado_Jsonclick = "";
         edtCCDetallesProfNombre_Jsonclick = "";
         imgprompt_890_Visible = 1;
         imgprompt_890_Link = "";
         edtCCDetallesProfId_Jsonclick = "";
         edtCentroCostosDetallesSolId_Jsonclick = "";
         edtCentroCostosDetallesValor_Jsonclick = "";
         edtCentroCostosDetallesNombre_Jsonclick = "";
         imgprompt_459_Visible = 1;
         imgprompt_459_Link = "";
         imgprompt_459_Visible = 1;
         edtListaCostosId_Jsonclick = "";
         edtCentroCostosDetallesId_Jsonclick = "";
         edtCentroCostosDetallesFecha_Jsonclick = "";
         subGridlevel_detalles_Class = "WorkWith";
         subGridlevel_detalles_Backcolorstyle = 0;
         cmbCentroCostosDetallesEstado.Enabled = 1;
         edtCCDetallesProfNombre_Enabled = 0;
         edtCCDetallesProfId_Enabled = 1;
         edtCentroCostosDetallesSolId_Enabled = 0;
         edtCentroCostosDetallesValor_Enabled = 1;
         edtCentroCostosDetallesNombre_Enabled = 1;
         edtListaCostosId_Enabled = 1;
         edtCentroCostosDetallesId_Enabled = 0;
         edtCentroCostosDetallesFecha_Enabled = 1;
         chkavError.Enabled = 0;
         chkavError.Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         lblTextblock2_Caption = "";
         edtavFechacierresolicitud_Jsonclick = "";
         edtavFechacierresolicitud_Enabled = 0;
         edtCentroCostosPrecioFinal_Jsonclick = "";
         edtCentroCostosPrecioFinal_Enabled = 0;
         edtCentroCostosNombre_Jsonclick = "";
         edtCentroCostosNombre_Enabled = 1;
         edtCentroCostosSubTotal_Jsonclick = "";
         edtCentroCostosSubTotal_Enabled = 0;
         edtavCentrocostospreciofinal_Jsonclick = "";
         edtavCentrocostospreciofinal_Enabled = 0;
         edtavCentrocostosnombre_Jsonclick = "";
         edtavCentrocostosnombre_Enabled = 0;
         edtCentroCostosRef_Jsonclick = "";
         edtCentroCostosRef_Enabled = 0;
         cmbCentroCostosTipoRef_Jsonclick = "";
         cmbCentroCostosTipoRef.Enabled = 0;
         edtCentroCostosId_Jsonclick = "";
         edtCentroCostosId_Enabled = 0;
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

      protected void GX5ASAFECHACIERRESOLICITUD0P69( )
      {
         GXt_date2 = AV31FechaCierreSolicitud;
         new obtenercierres(context ).execute(  context.GetMessage( context.GetMessage( "FechaCierreSolicitud", ""), ""), out  GXt_date2) ;
         AV31FechaCierreSolicitud = GXt_date2;
         AssignAttri("", false, "AV31FechaCierreSolicitud", context.localUtil.Format(AV31FechaCierreSolicitud, "99/99/99"));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.Format(AV31FechaCierreSolicitud, "99/99/99"))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX13ASASOLICITUDESIDCOLLECTION0P69( long AV8CentroCostosRef ,
                                                         DateTime AV31FechaCierreSolicitud )
      {
         GXt_objcol_int3 = AV36SolicitudesIdCollection;
         new solicitudesfechavigente(context ).execute(  AV8CentroCostosRef,  AV31FechaCierreSolicitud, out  GXt_objcol_int3) ;
         AV36SolicitudesIdCollection = GXt_objcol_int3;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV36SolicitudesIdCollection.ToXml(false, true, "Collection", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_15_0P69( long AV8CentroCostosRef )
      {
         new osoldat(context ).execute(  AV8CentroCostosRef, out  AV13CentroCostosNombre, out  AV14CentroCostosPrecioFinal) ;
         AssignAttri("", false, "AV13CentroCostosNombre", AV13CentroCostosNombre);
         AssignAttri("", false, "AV14CentroCostosPrecioFinal", StringUtil.LTrimStr( AV14CentroCostosPrecioFinal, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( AV13CentroCostosNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( AV14CentroCostosPrecioFinal, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_16_0P69( long AV8CentroCostosRef ,
                                 decimal AV14CentroCostosPrecioFinal )
      {
         if ( ( AV14CentroCostosPrecioFinal > Convert.ToDecimal( 0 )) )
         {
            new osoldat(context ).execute(  AV8CentroCostosRef, out  A463CentroCostosNombre, out  A464CentroCostosPrecioFinal) ;
            AssignAttri("", false, "A463CentroCostosNombre", A463CentroCostosNombre);
            AssignAttri("", false, "A464CentroCostosPrecioFinal", StringUtil.LTrimStr( A464CentroCostosPrecioFinal, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A463CentroCostosNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A464CentroCostosPrecioFinal, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_19_0P69( long A461CentroCostosId )
      {
         new controlsubsolicitud(context ).execute(  A461CentroCostosId) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_48_0P70( long A461CentroCostosId ,
                                 long A466CentroCostosDetallesId ,
                                 DateTime A892CentroCostosDetallesFecha ,
                                 long A893CentroCostosDetallesEstado ,
                                 string A473CentroCostosDetallesNombre ,
                                 decimal A468CentroCostosDetallesValor ,
                                 string A890CCDetallesProfId ,
                                 long AV8CentroCostosRef )
      {
         new altasubsolicitud(context ).execute(  A461CentroCostosId,  A466CentroCostosDetallesId,  A892CentroCostosDetallesFecha,  A893CentroCostosDetallesEstado,  A473CentroCostosDetallesNombre,  A468CentroCostosDetallesValor,  A890CCDetallesProfId,  AV8CentroCostosRef, out  AV23NewSolicitudId, out  AV24IsOk, out  AV25TxtMsg) ;
         AssignAttri("", false, "AV23NewSolicitudId", StringUtil.LTrimStr( (decimal)(AV23NewSolicitudId), 18, 0));
         AssignAttri("", false, "AV24IsOk", AV24IsOk);
         AssignAttri("", false, "AV25TxtMsg", AV25TxtMsg);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23NewSolicitudId), 18, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( AV24IsOk))+"\""+","+"\""+GXUtil.EncodeJSConstant( AV25TxtMsg)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_detalles_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_6570( ) ;
         while ( nGXsfl_65_idx <= nRC_GXsfl_65 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0P70( ) ;
            standaloneModal0P70( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0P70( ) ;
            nGXsfl_65_idx = (int)(nGXsfl_65_idx+1);
            sGXsfl_65_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_65_idx), 4, 0), 4, "0");
            SubsflControlProps_6570( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_detallesContainer)) ;
         /* End function gxnrGridlevel_detalles_newrow */
      }

      protected void init_web_controls( )
      {
         cmbCentroCostosTipoRef.Name = "CENTROCOSTOSTIPOREF";
         cmbCentroCostosTipoRef.WebTags = "";
         cmbCentroCostosTipoRef.addItem("S", context.GetMessage( "Servicios", ""), 0);
         cmbCentroCostosTipoRef.addItem("O", context.GetMessage( "Otros", ""), 0);
         if ( cmbCentroCostosTipoRef.ItemCount > 0 )
         {
            A487CentroCostosTipoRef = cmbCentroCostosTipoRef.getValidValue(A487CentroCostosTipoRef);
            AssignAttri("", false, "A487CentroCostosTipoRef", A487CentroCostosTipoRef);
         }
         GXCCtl = "CENTROCOSTOSDETALLESESTADO_" + sGXsfl_65_idx;
         cmbCentroCostosDetallesEstado.Name = GXCCtl;
         cmbCentroCostosDetallesEstado.WebTags = "";
         cmbCentroCostosDetallesEstado.addItem("1", context.GetMessage( "Ingresada", ""), 0);
         cmbCentroCostosDetallesEstado.addItem("2", context.GetMessage( "Asignada", ""), 0);
         cmbCentroCostosDetallesEstado.addItem("3", context.GetMessage( "Cancelada", ""), 0);
         cmbCentroCostosDetallesEstado.addItem("5", context.GetMessage( "Aceptada", ""), 0);
         cmbCentroCostosDetallesEstado.addItem("6", context.GetMessage( "Finalizada", ""), 0);
         if ( cmbCentroCostosDetallesEstado.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A893CentroCostosDetallesEstado) )
            {
               A893CentroCostosDetallesEstado = 1;
            }
         }
         chkavError.Name = "vERROR";
         chkavError.WebTags = "";
         chkavError.Caption = "";
         AssignProp("", false, chkavError_Internalname, "TitleCaption", chkavError.Caption, true);
         chkavError.CheckedValue = "false";
         AV35Error = StringUtil.StrToBool( StringUtil.BoolToStr( AV35Error));
         AssignAttri("", false, "AV35Error", AV35Error);
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

      public void Valid_Centrocostosid( )
      {
         n469CentroCostosSubTotal = false;
         /* Using cursor T000P21 */
         pr_default.execute(15, new Object[] {A461CentroCostosId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            A469CentroCostosSubTotal = T000P21_A469CentroCostosSubTotal[0];
            n469CentroCostosSubTotal = T000P21_n469CentroCostosSubTotal[0];
         }
         else
         {
            A469CentroCostosSubTotal = 0;
            n469CentroCostosSubTotal = false;
         }
         pr_default.close(15);
         if ( true /* After */ && ( A469CentroCostosSubTotal > Convert.ToDecimal( 0 )) && IsIns( )  )
         {
            A475CentroCostosCosto = A469CentroCostosSubTotal;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A469CentroCostosSubTotal", StringUtil.LTrim( StringUtil.NToC( A469CentroCostosSubTotal, 18, 2, ".", "")));
         AssignAttri("", false, "A475CentroCostosCosto", StringUtil.LTrim( StringUtil.NToC( A475CentroCostosCosto, 18, 2, ".", "")));
      }

      public void Valid_Listacostosid( )
      {
         n459ListaCostosId = false;
         /* Using cursor T000P31 */
         pr_default.execute(25, new Object[] {n459ListaCostosId, A459ListaCostosId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (0==A459ListaCostosId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Lista de Costos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "LISTACOSTOSID");
               AnyError = 1;
               GX_FocusControl = edtListaCostosId_Internalname;
            }
         }
         A460ListaCostosNombre = T000P31_A460ListaCostosNombre[0];
         A471ListaCostosValor = T000P31_A471ListaCostosValor[0];
         pr_default.close(25);
         if ( true /* After */ && IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A473CentroCostosDetallesNombre)) )
         {
            A473CentroCostosDetallesNombre = A460ListaCostosNombre;
         }
         if ( true /* After */ && IsIns( )  && ( A468CentroCostosDetallesValor == Convert.ToDecimal( 0 )) )
         {
            A468CentroCostosDetallesValor = A471ListaCostosValor;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A460ListaCostosNombre", StringUtil.RTrim( A460ListaCostosNombre));
         AssignAttri("", false, "A471ListaCostosValor", StringUtil.LTrim( StringUtil.NToC( A471ListaCostosValor, 18, 2, ".", "")));
         AssignAttri("", false, "A473CentroCostosDetallesNombre", StringUtil.RTrim( A473CentroCostosDetallesNombre));
         AssignAttri("", false, "A468CentroCostosDetallesValor", StringUtil.LTrim( StringUtil.NToC( A468CentroCostosDetallesValor, 10, 2, ".", "")));
      }

      public void Valid_Ccdetallesprofid( )
      {
         n167ProfesionalesApellidoPrimero = false;
         n166ProfesionalesPrimerNombre = false;
         n191ProfesionalesSegundoNombre = false;
         /* Using cursor T000P32 */
         pr_default.execute(26, new Object[] {A890CCDetallesProfId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "CCDetalles Prof", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "CCDETALLESPROFID");
            AnyError = 1;
            GX_FocusControl = edtCCDetallesProfId_Internalname;
         }
         A167ProfesionalesApellidoPrimero = T000P32_A167ProfesionalesApellidoPrimero[0];
         n167ProfesionalesApellidoPrimero = T000P32_n167ProfesionalesApellidoPrimero[0];
         A166ProfesionalesPrimerNombre = T000P32_A166ProfesionalesPrimerNombre[0];
         n166ProfesionalesPrimerNombre = T000P32_n166ProfesionalesPrimerNombre[0];
         A191ProfesionalesSegundoNombre = T000P32_A191ProfesionalesSegundoNombre[0];
         n191ProfesionalesSegundoNombre = T000P32_n191ProfesionalesSegundoNombre[0];
         pr_default.close(26);
         A891CCDetallesProfNombre = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A167ProfesionalesApellidoPrimero", StringUtil.RTrim( A167ProfesionalesApellidoPrimero));
         AssignAttri("", false, "A166ProfesionalesPrimerNombre", StringUtil.RTrim( A166ProfesionalesPrimerNombre));
         AssignAttri("", false, "A191ProfesionalesSegundoNombre", StringUtil.RTrim( A191ProfesionalesSegundoNombre));
         AssignAttri("", false, "A891CCDetallesProfNombre", A891CCDetallesProfNombre);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7CentroCostosId',fld:'vCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV8CentroCostosRef',fld:'vCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7CentroCostosId',fld:'vCENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV8CentroCostosRef',fld:'vCENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'cmbCentroCostosTipoRef'},{av:'A487CentroCostosTipoRef',fld:'CENTROCOSTOSTIPOREF',pic:'',type:'char'},{av:'A462CentroCostosRef',fld:'CENTROCOSTOSREF',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A464CentroCostosPrecioFinal',fld:'CENTROCOSTOSPRECIOFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV31FechaCierreSolicitud',fld:'vFECHACIERRESOLICITUD',pic:'',type:'date'},{av:'AV32RoleName',fld:'vROLENAME',pic:'',type:'char'},{av:'A478CentroCostosUsrAlta',fld:'CENTROCOSTOSUSRALTA',pic:'',type:'char'},{av:'A479CentroCostosUsrMod',fld:'CENTROCOSTOSUSRMOD',pic:'',type:'char'},{av:'A480CentroCostosHoraAlt',fld:'CENTROCOSTOSHORAALT',pic:'',type:'date'},{av:'A481CentroCostosHoraMod',fld:'CENTROCOSTOSHORAMOD',pic:'',type:'date'},{av:'A482CentroCostosEstado',fld:'CENTROCOSTOSESTADO',pic:'',type:'char'},{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("AFTER TRN","{handler:'E120P2',iparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("'NUEVO ITEM'","{handler:'E130P2',iparms:[{av:'A459ListaCostosId',fld:'LISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("'NUEVO ITEM'",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("CENTROCOSTOSDETALLESFECHA.CLICK","{handler:'E140P2',iparms:[{av:'AV32RoleName',fld:'vROLENAME',pic:'',type:'char'},{av:'A892CentroCostosDetallesFecha',fld:'CENTROCOSTOSDETALLESFECHA',pic:'',type:'date'},{av:'AV31FechaCierreSolicitud',fld:'vFECHACIERRESOLICITUD',pic:'',type:'date'},{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("CENTROCOSTOSDETALLESFECHA.CLICK",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_CENTROCOSTOSID","{handler:'Valid_Centrocostosid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'A461CentroCostosId',fld:'CENTROCOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A469CentroCostosSubTotal',fld:'CENTROCOSTOSSUBTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A475CentroCostosCosto',fld:'CENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_CENTROCOSTOSID",",oparms:[{av:'A469CentroCostosSubTotal',fld:'CENTROCOSTOSSUBTOTAL',pic:'ZZZ,ZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'A475CentroCostosCosto',fld:'CENTROCOSTOSCOSTO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALIDV_CENTROCOSTOSPRECIOFINAL","{handler:'Validv_Centrocostospreciofinal',iparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALIDV_CENTROCOSTOSPRECIOFINAL",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_CENTROCOSTOSSUBTOTAL","{handler:'Valid_Centrocostossubtotal',iparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_CENTROCOSTOSSUBTOTAL",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_CENTROCOSTOSPRECIOFINAL","{handler:'Valid_Centrocostospreciofinal',iparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_CENTROCOSTOSPRECIOFINAL",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALIDV_FECHACIERRESOLICITUD","{handler:'Validv_Fechacierresolicitud',iparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALIDV_FECHACIERRESOLICITUD",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESFECHA","{handler:'Valid_Centrocostosdetallesfecha',iparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESFECHA",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESID","{handler:'Valid_Centrocostosdetallesid',iparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESID",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_LISTACOSTOSID","{handler:'Valid_Listacostosid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',type:'char'},{av:'A459ListaCostosId',fld:'LISTACOSTOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A460ListaCostosNombre',fld:'LISTACOSTOSNOMBRE',pic:'',type:'char'},{av:'A471ListaCostosValor',fld:'LISTACOSTOSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A473CentroCostosDetallesNombre',fld:'CENTROCOSTOSDETALLESNOMBRE',pic:'',type:'char'},{av:'A468CentroCostosDetallesValor',fld:'CENTROCOSTOSDETALLESVALOR',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_LISTACOSTOSID",",oparms:[{av:'A460ListaCostosNombre',fld:'LISTACOSTOSNOMBRE',pic:'',type:'char'},{av:'A471ListaCostosValor',fld:'LISTACOSTOSVALOR',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A473CentroCostosDetallesNombre',fld:'CENTROCOSTOSDETALLESNOMBRE',pic:'',type:'char'},{av:'A468CentroCostosDetallesValor',fld:'CENTROCOSTOSDETALLESVALOR',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESNOMBRE","{handler:'Valid_Centrocostosdetallesnombre',iparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESNOMBRE",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESVALOR","{handler:'Valid_Centrocostosdetallesvalor',iparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESVALOR",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESSOLID","{handler:'Valid_Centrocostosdetallessolid',iparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESSOLID",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_CCDETALLESPROFID","{handler:'Valid_Ccdetallesprofid',iparms:[{av:'A890CCDetallesProfId',fld:'CCDETALLESPROFID',pic:'',type:'char'},{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A191ProfesionalesSegundoNombre',fld:'PROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'A891CCDetallesProfNombre',fld:'CCDETALLESPROFNOMBRE',pic:'',type:'svchar'},{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_CCDETALLESPROFID",",oparms:[{av:'A167ProfesionalesApellidoPrimero',fld:'PROFESIONALESAPELLIDOPRIMERO',pic:'',type:'char'},{av:'A166ProfesionalesPrimerNombre',fld:'PROFESIONALESPRIMERNOMBRE',pic:'',type:'char'},{av:'A191ProfesionalesSegundoNombre',fld:'PROFESIONALESSEGUNDONOMBRE',pic:'',type:'char'},{av:'A891CCDetallesProfNombre',fld:'CCDETALLESPROFNOMBRE',pic:'',type:'svchar'},{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESESTADO","{handler:'Valid_Centrocostosdetallesestado',iparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_CENTROCOSTOSDETALLESESTADO",",oparms:[{av:'AV35Error',fld:'vERROR',pic:'',type:'boolean'}]}");
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
         pr_default.close(25);
         pr_default.close(26);
         pr_default.close(5);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z487CentroCostosTipoRef = "";
         Z463CentroCostosNombre = "";
         Z478CentroCostosUsrAlta = "";
         Z479CentroCostosUsrMod = "";
         Z480CentroCostosHoraAlt = DateTime.MinValue;
         Z481CentroCostosHoraMod = DateTime.MinValue;
         Z482CentroCostosEstado = "";
         Z473CentroCostosDetallesNombre = "";
         Z892CentroCostosDetallesFecha = DateTime.MinValue;
         Z890CCDetallesProfId = "";
         N892CentroCostosDetallesFecha = DateTime.MinValue;
         N473CentroCostosDetallesNombre = "";
         N890CCDetallesProfId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A892CentroCostosDetallesFecha = DateTime.MinValue;
         A473CentroCostosDetallesNombre = "";
         A890CCDetallesProfId = "";
         AV31FechaCierreSolicitud = DateTime.MinValue;
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         AV32RoleName = "";
         A487CentroCostosTipoRef = "";
         TempTags = "";
         AV13CentroCostosNombre = "";
         A463CentroCostosNombre = "";
         lblTextblock2_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTextblock1_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         Gridlevel_detallesContainer = new GXWebGrid( context);
         sMode70 = "";
         sStyleString = "";
         A478CentroCostosUsrAlta = "";
         A479CentroCostosUsrMod = "";
         A480CentroCostosHoraAlt = DateTime.MinValue;
         A481CentroCostosHoraMod = DateTime.MinValue;
         A482CentroCostosEstado = "";
         AV36SolicitudesIdCollection = new GxSimpleCollection<long>();
         A889CentroCostosJson = "";
         AV40Pgmname = "";
         A167ProfesionalesApellidoPrimero = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         AV25TxtMsg = "";
         A460ListaCostosNombre = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode69 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         A891CCDetallesProfNombre = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV15NuevoItem = "";
         imgNuevoitem_gximage = "";
         imgNuevoitem_Internalname = "";
         AV39Nuevoitem_GXI = "";
         AV11WebSession = context.GetSession();
         AV16WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         Z889CentroCostosJson = "";
         T000P9_A469CentroCostosSubTotal = new decimal[1] ;
         T000P9_n469CentroCostosSubTotal = new bool[] {false} ;
         T000P11_A461CentroCostosId = new long[1] ;
         T000P11_A487CentroCostosTipoRef = new string[] {""} ;
         T000P11_A462CentroCostosRef = new long[1] ;
         T000P11_A475CentroCostosCosto = new decimal[1] ;
         T000P11_A463CentroCostosNombre = new string[] {""} ;
         T000P11_A464CentroCostosPrecioFinal = new decimal[1] ;
         T000P11_A465CentroCostosSerial = new long[1] ;
         T000P11_A889CentroCostosJson = new string[] {""} ;
         T000P11_A478CentroCostosUsrAlta = new string[] {""} ;
         T000P11_A479CentroCostosUsrMod = new string[] {""} ;
         T000P11_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         T000P11_A481CentroCostosHoraMod = new DateTime[] {DateTime.MinValue} ;
         T000P11_A482CentroCostosEstado = new string[] {""} ;
         T000P11_A469CentroCostosSubTotal = new decimal[1] ;
         T000P11_n469CentroCostosSubTotal = new bool[] {false} ;
         T000P13_A469CentroCostosSubTotal = new decimal[1] ;
         T000P13_n469CentroCostosSubTotal = new bool[] {false} ;
         T000P14_A461CentroCostosId = new long[1] ;
         T000P7_A461CentroCostosId = new long[1] ;
         T000P7_A487CentroCostosTipoRef = new string[] {""} ;
         T000P7_A462CentroCostosRef = new long[1] ;
         T000P7_A475CentroCostosCosto = new decimal[1] ;
         T000P7_A463CentroCostosNombre = new string[] {""} ;
         T000P7_A464CentroCostosPrecioFinal = new decimal[1] ;
         T000P7_A465CentroCostosSerial = new long[1] ;
         T000P7_A889CentroCostosJson = new string[] {""} ;
         T000P7_A478CentroCostosUsrAlta = new string[] {""} ;
         T000P7_A479CentroCostosUsrMod = new string[] {""} ;
         T000P7_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         T000P7_A481CentroCostosHoraMod = new DateTime[] {DateTime.MinValue} ;
         T000P7_A482CentroCostosEstado = new string[] {""} ;
         T000P15_A461CentroCostosId = new long[1] ;
         T000P16_A461CentroCostosId = new long[1] ;
         T000P6_A461CentroCostosId = new long[1] ;
         T000P6_A487CentroCostosTipoRef = new string[] {""} ;
         T000P6_A462CentroCostosRef = new long[1] ;
         T000P6_A475CentroCostosCosto = new decimal[1] ;
         T000P6_A463CentroCostosNombre = new string[] {""} ;
         T000P6_A464CentroCostosPrecioFinal = new decimal[1] ;
         T000P6_A465CentroCostosSerial = new long[1] ;
         T000P6_A889CentroCostosJson = new string[] {""} ;
         T000P6_A478CentroCostosUsrAlta = new string[] {""} ;
         T000P6_A479CentroCostosUsrMod = new string[] {""} ;
         T000P6_A480CentroCostosHoraAlt = new DateTime[] {DateTime.MinValue} ;
         T000P6_A481CentroCostosHoraMod = new DateTime[] {DateTime.MinValue} ;
         T000P6_A482CentroCostosEstado = new string[] {""} ;
         T000P17_A461CentroCostosId = new long[1] ;
         T000P21_A469CentroCostosSubTotal = new decimal[1] ;
         T000P21_n469CentroCostosSubTotal = new bool[] {false} ;
         T000P23_A461CentroCostosId = new long[1] ;
         Z460ListaCostosNombre = "";
         Z167ProfesionalesApellidoPrimero = "";
         Z166ProfesionalesPrimerNombre = "";
         Z191ProfesionalesSegundoNombre = "";
         T000P24_A461CentroCostosId = new long[1] ;
         T000P24_A466CentroCostosDetallesId = new long[1] ;
         T000P24_A893CentroCostosDetallesEstado = new long[1] ;
         T000P24_A473CentroCostosDetallesNombre = new string[] {""} ;
         T000P24_A468CentroCostosDetallesValor = new decimal[1] ;
         T000P24_A892CentroCostosDetallesFecha = new DateTime[] {DateTime.MinValue} ;
         T000P24_A460ListaCostosNombre = new string[] {""} ;
         T000P24_A471ListaCostosValor = new decimal[1] ;
         T000P24_A888CentroCostosDetallesSolId = new long[1] ;
         T000P24_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T000P24_n167ProfesionalesApellidoPrimero = new bool[] {false} ;
         T000P24_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T000P24_n166ProfesionalesPrimerNombre = new bool[] {false} ;
         T000P24_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T000P24_n191ProfesionalesSegundoNombre = new bool[] {false} ;
         T000P24_A459ListaCostosId = new long[1] ;
         T000P24_n459ListaCostosId = new bool[] {false} ;
         T000P24_A890CCDetallesProfId = new string[] {""} ;
         T000P4_A460ListaCostosNombre = new string[] {""} ;
         T000P4_A471ListaCostosValor = new decimal[1] ;
         T000P5_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T000P5_n167ProfesionalesApellidoPrimero = new bool[] {false} ;
         T000P5_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T000P5_n166ProfesionalesPrimerNombre = new bool[] {false} ;
         T000P5_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T000P5_n191ProfesionalesSegundoNombre = new bool[] {false} ;
         T000P25_A460ListaCostosNombre = new string[] {""} ;
         T000P25_A471ListaCostosValor = new decimal[1] ;
         T000P26_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T000P26_n167ProfesionalesApellidoPrimero = new bool[] {false} ;
         T000P26_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T000P26_n166ProfesionalesPrimerNombre = new bool[] {false} ;
         T000P26_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T000P26_n191ProfesionalesSegundoNombre = new bool[] {false} ;
         T000P27_A461CentroCostosId = new long[1] ;
         T000P27_A466CentroCostosDetallesId = new long[1] ;
         T000P3_A461CentroCostosId = new long[1] ;
         T000P3_A466CentroCostosDetallesId = new long[1] ;
         T000P3_A893CentroCostosDetallesEstado = new long[1] ;
         T000P3_A473CentroCostosDetallesNombre = new string[] {""} ;
         T000P3_A468CentroCostosDetallesValor = new decimal[1] ;
         T000P3_A892CentroCostosDetallesFecha = new DateTime[] {DateTime.MinValue} ;
         T000P3_A888CentroCostosDetallesSolId = new long[1] ;
         T000P3_A459ListaCostosId = new long[1] ;
         T000P3_n459ListaCostosId = new bool[] {false} ;
         T000P3_A890CCDetallesProfId = new string[] {""} ;
         T000P2_A461CentroCostosId = new long[1] ;
         T000P2_A466CentroCostosDetallesId = new long[1] ;
         T000P2_A893CentroCostosDetallesEstado = new long[1] ;
         T000P2_A473CentroCostosDetallesNombre = new string[] {""} ;
         T000P2_A468CentroCostosDetallesValor = new decimal[1] ;
         T000P2_A892CentroCostosDetallesFecha = new DateTime[] {DateTime.MinValue} ;
         T000P2_A888CentroCostosDetallesSolId = new long[1] ;
         T000P2_A459ListaCostosId = new long[1] ;
         T000P2_n459ListaCostosId = new bool[] {false} ;
         T000P2_A890CCDetallesProfId = new string[] {""} ;
         T000P31_A460ListaCostosNombre = new string[] {""} ;
         T000P31_A471ListaCostosValor = new decimal[1] ;
         T000P32_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T000P32_n167ProfesionalesApellidoPrimero = new bool[] {false} ;
         T000P32_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T000P32_n166ProfesionalesPrimerNombre = new bool[] {false} ;
         T000P32_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T000P32_n191ProfesionalesSegundoNombre = new bool[] {false} ;
         T000P33_A461CentroCostosId = new long[1] ;
         T000P33_A466CentroCostosDetallesId = new long[1] ;
         Gridlevel_detallesRow = new GXWebRow();
         subGridlevel_detalles_Linesclass = "";
         ROClassString = "";
         imgprompt_459_gximage = "";
         sImgUrl = "";
         imgprompt_890_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i487CentroCostosTipoRef = "";
         i482CentroCostosEstado = "";
         Gridlevel_detallesColumn = new GXWebColumn();
         GXt_date2 = DateTime.MinValue;
         GXt_objcol_int3 = new GxSimpleCollection<long>();
         Z891CCDetallesProfNombre = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.costoservicios__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costoservicios__default(),
            new Object[][] {
                new Object[] {
               T000P2_A461CentroCostosId, T000P2_A466CentroCostosDetallesId, T000P2_A893CentroCostosDetallesEstado, T000P2_A473CentroCostosDetallesNombre, T000P2_A468CentroCostosDetallesValor, T000P2_A892CentroCostosDetallesFecha, T000P2_A888CentroCostosDetallesSolId, T000P2_A459ListaCostosId, T000P2_n459ListaCostosId, T000P2_A890CCDetallesProfId
               }
               , new Object[] {
               T000P3_A461CentroCostosId, T000P3_A466CentroCostosDetallesId, T000P3_A893CentroCostosDetallesEstado, T000P3_A473CentroCostosDetallesNombre, T000P3_A468CentroCostosDetallesValor, T000P3_A892CentroCostosDetallesFecha, T000P3_A888CentroCostosDetallesSolId, T000P3_A459ListaCostosId, T000P3_n459ListaCostosId, T000P3_A890CCDetallesProfId
               }
               , new Object[] {
               T000P4_A460ListaCostosNombre, T000P4_A471ListaCostosValor
               }
               , new Object[] {
               T000P5_A167ProfesionalesApellidoPrimero, T000P5_n167ProfesionalesApellidoPrimero, T000P5_A166ProfesionalesPrimerNombre, T000P5_n166ProfesionalesPrimerNombre, T000P5_A191ProfesionalesSegundoNombre, T000P5_n191ProfesionalesSegundoNombre
               }
               , new Object[] {
               T000P6_A461CentroCostosId, T000P6_A487CentroCostosTipoRef, T000P6_A462CentroCostosRef, T000P6_A475CentroCostosCosto, T000P6_A463CentroCostosNombre, T000P6_A464CentroCostosPrecioFinal, T000P6_A465CentroCostosSerial, T000P6_A889CentroCostosJson, T000P6_A478CentroCostosUsrAlta, T000P6_A479CentroCostosUsrMod,
               T000P6_A480CentroCostosHoraAlt, T000P6_A481CentroCostosHoraMod, T000P6_A482CentroCostosEstado
               }
               , new Object[] {
               T000P7_A461CentroCostosId, T000P7_A487CentroCostosTipoRef, T000P7_A462CentroCostosRef, T000P7_A475CentroCostosCosto, T000P7_A463CentroCostosNombre, T000P7_A464CentroCostosPrecioFinal, T000P7_A465CentroCostosSerial, T000P7_A889CentroCostosJson, T000P7_A478CentroCostosUsrAlta, T000P7_A479CentroCostosUsrMod,
               T000P7_A480CentroCostosHoraAlt, T000P7_A481CentroCostosHoraMod, T000P7_A482CentroCostosEstado
               }
               , new Object[] {
               T000P9_A469CentroCostosSubTotal, T000P9_n469CentroCostosSubTotal
               }
               , new Object[] {
               T000P11_A461CentroCostosId, T000P11_A487CentroCostosTipoRef, T000P11_A462CentroCostosRef, T000P11_A475CentroCostosCosto, T000P11_A463CentroCostosNombre, T000P11_A464CentroCostosPrecioFinal, T000P11_A465CentroCostosSerial, T000P11_A889CentroCostosJson, T000P11_A478CentroCostosUsrAlta, T000P11_A479CentroCostosUsrMod,
               T000P11_A480CentroCostosHoraAlt, T000P11_A481CentroCostosHoraMod, T000P11_A482CentroCostosEstado, T000P11_A469CentroCostosSubTotal, T000P11_n469CentroCostosSubTotal
               }
               , new Object[] {
               T000P13_A469CentroCostosSubTotal, T000P13_n469CentroCostosSubTotal
               }
               , new Object[] {
               T000P14_A461CentroCostosId
               }
               , new Object[] {
               T000P15_A461CentroCostosId
               }
               , new Object[] {
               T000P16_A461CentroCostosId
               }
               , new Object[] {
               T000P17_A461CentroCostosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000P21_A469CentroCostosSubTotal, T000P21_n469CentroCostosSubTotal
               }
               , new Object[] {
               }
               , new Object[] {
               T000P23_A461CentroCostosId
               }
               , new Object[] {
               T000P24_A461CentroCostosId, T000P24_A466CentroCostosDetallesId, T000P24_A893CentroCostosDetallesEstado, T000P24_A473CentroCostosDetallesNombre, T000P24_A468CentroCostosDetallesValor, T000P24_A892CentroCostosDetallesFecha, T000P24_A460ListaCostosNombre, T000P24_A471ListaCostosValor, T000P24_A888CentroCostosDetallesSolId, T000P24_A167ProfesionalesApellidoPrimero,
               T000P24_n167ProfesionalesApellidoPrimero, T000P24_A166ProfesionalesPrimerNombre, T000P24_n166ProfesionalesPrimerNombre, T000P24_A191ProfesionalesSegundoNombre, T000P24_n191ProfesionalesSegundoNombre, T000P24_A459ListaCostosId, T000P24_n459ListaCostosId, T000P24_A890CCDetallesProfId
               }
               , new Object[] {
               T000P25_A460ListaCostosNombre, T000P25_A471ListaCostosValor
               }
               , new Object[] {
               T000P26_A167ProfesionalesApellidoPrimero, T000P26_n167ProfesionalesApellidoPrimero, T000P26_A166ProfesionalesPrimerNombre, T000P26_n166ProfesionalesPrimerNombre, T000P26_A191ProfesionalesSegundoNombre, T000P26_n191ProfesionalesSegundoNombre
               }
               , new Object[] {
               T000P27_A461CentroCostosId, T000P27_A466CentroCostosDetallesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000P31_A460ListaCostosNombre, T000P31_A471ListaCostosValor
               }
               , new Object[] {
               T000P32_A167ProfesionalesApellidoPrimero, T000P32_n167ProfesionalesApellidoPrimero, T000P32_A166ProfesionalesPrimerNombre, T000P32_n166ProfesionalesPrimerNombre, T000P32_A191ProfesionalesSegundoNombre, T000P32_n191ProfesionalesSegundoNombre
               }
               , new Object[] {
               T000P33_A461CentroCostosId, T000P33_A466CentroCostosDetallesId
               }
            }
         );
         AV40Pgmname = "CostoServicios";
         Z893CentroCostosDetallesEstado = 1;
         N893CentroCostosDetallesEstado = 1;
         i893CentroCostosDetallesEstado = 1;
         A893CentroCostosDetallesEstado = 1;
         Z482CentroCostosEstado = context.GetMessage( "PND", "");
         A482CentroCostosEstado = context.GetMessage( "PND", "");
         i482CentroCostosEstado = context.GetMessage( "PND", "");
      }

      private short nIsMod_70 ;
      private short nRcdDeleted_70 ;
      private short nRcdExists_70 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short nBlankRcdCount70 ;
      private short RcdFound70 ;
      private short nBlankRcdUsr70 ;
      private short RcdFound69 ;
      private short nIsDirty_70 ;
      private short subGridlevel_detalles_Backcolorstyle ;
      private short subGridlevel_detalles_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_detalles_Allowselection ;
      private short subGridlevel_detalles_Allowhovering ;
      private short subGridlevel_detalles_Allowcollapsing ;
      private short subGridlevel_detalles_Collapsed ;
      private int nRC_GXsfl_65 ;
      private int nGXsfl_65_idx=1 ;
      private int trnEnded ;
      private int edtCentroCostosId_Enabled ;
      private int edtCentroCostosRef_Enabled ;
      private int edtavCentrocostosnombre_Enabled ;
      private int edtavCentrocostospreciofinal_Enabled ;
      private int edtCentroCostosSubTotal_Enabled ;
      private int edtCentroCostosNombre_Enabled ;
      private int edtCentroCostosPrecioFinal_Enabled ;
      private int edtavFechacierresolicitud_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int edtCentroCostosDetallesFecha_Enabled ;
      private int edtCentroCostosDetallesId_Enabled ;
      private int edtListaCostosId_Enabled ;
      private int edtCentroCostosDetallesNombre_Enabled ;
      private int edtCentroCostosDetallesValor_Enabled ;
      private int edtCentroCostosDetallesSolId_Enabled ;
      private int edtCCDetallesProfId_Enabled ;
      private int edtCCDetallesProfNombre_Enabled ;
      private int fRowAdded ;
      private int subGridlevel_detalles_Backcolor ;
      private int subGridlevel_detalles_Allbackcolor ;
      private int imgprompt_459_Visible ;
      private int imgprompt_890_Visible ;
      private int defcmbCentroCostosDetallesEstado_Enabled ;
      private int defedtCCDetallesProfId_Enabled ;
      private int defedtCentroCostosDetallesSolId_Enabled ;
      private int defedtCentroCostosDetallesValor_Enabled ;
      private int defedtCentroCostosDetallesNombre_Enabled ;
      private int defedtListaCostosId_Enabled ;
      private int defedtCentroCostosDetallesId_Enabled ;
      private int defedtCentroCostosDetallesFecha_Enabled ;
      private int idxLst ;
      private int subGridlevel_detalles_Selectedindex ;
      private int subGridlevel_detalles_Selectioncolor ;
      private int subGridlevel_detalles_Hoveringcolor ;
      private long wcpOAV7CentroCostosId ;
      private long wcpOAV8CentroCostosRef ;
      private long Z461CentroCostosId ;
      private long Z462CentroCostosRef ;
      private long Z465CentroCostosSerial ;
      private long O465CentroCostosSerial ;
      private long Z466CentroCostosDetallesId ;
      private long Z893CentroCostosDetallesEstado ;
      private long Z888CentroCostosDetallesSolId ;
      private long Z459ListaCostosId ;
      private long N466CentroCostosDetallesId ;
      private long N459ListaCostosId ;
      private long N893CentroCostosDetallesEstado ;
      private long AV8CentroCostosRef ;
      private long A461CentroCostosId ;
      private long A466CentroCostosDetallesId ;
      private long A893CentroCostosDetallesEstado ;
      private long A459ListaCostosId ;
      private long AV7CentroCostosId ;
      private long A465CentroCostosSerial ;
      private long A462CentroCostosRef ;
      private long B465CentroCostosSerial ;
      private long AV23NewSolicitudId ;
      private long GRIDLEVEL_DETALLES_nFirstRecordOnPage ;
      private long A888CentroCostosDetallesSolId ;
      private long s465CentroCostosSerial ;
      private long i465CentroCostosSerial ;
      private long i893CentroCostosDetallesEstado ;
      private decimal Z475CentroCostosCosto ;
      private decimal Z464CentroCostosPrecioFinal ;
      private decimal O469CentroCostosSubTotal ;
      private decimal Z468CentroCostosDetallesValor ;
      private decimal O468CentroCostosDetallesValor ;
      private decimal N468CentroCostosDetallesValor ;
      private decimal AV14CentroCostosPrecioFinal ;
      private decimal A468CentroCostosDetallesValor ;
      private decimal A469CentroCostosSubTotal ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal B469CentroCostosSubTotal ;
      private decimal A475CentroCostosCosto ;
      private decimal A474CentroCostosGam ;
      private decimal A471ListaCostosValor ;
      private decimal s469CentroCostosSubTotal ;
      private decimal s475CentroCostosCosto ;
      private decimal O475CentroCostosCosto ;
      private decimal T468CentroCostosDetallesValor ;
      private decimal Z469CentroCostosSubTotal ;
      private decimal Z471ListaCostosValor ;
      private string sPrefix ;
      private string sGXsfl_65_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z487CentroCostosTipoRef ;
      private string Z463CentroCostosNombre ;
      private string Z478CentroCostosUsrAlta ;
      private string Z479CentroCostosUsrMod ;
      private string Z482CentroCostosEstado ;
      private string Z473CentroCostosDetallesNombre ;
      private string Z890CCDetallesProfId ;
      private string N473CentroCostosDetallesNombre ;
      private string N890CCDetallesProfId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A473CentroCostosDetallesNombre ;
      private string A890CCDetallesProfId ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCentroCostosNombre_Internalname ;
      private string AV32RoleName ;
      private string A487CentroCostosTipoRef ;
      private string cmbCentroCostosTipoRef_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtCentroCostosId_Internalname ;
      private string TempTags ;
      private string edtCentroCostosId_Jsonclick ;
      private string cmbCentroCostosTipoRef_Jsonclick ;
      private string edtCentroCostosRef_Internalname ;
      private string edtCentroCostosRef_Jsonclick ;
      private string edtavCentrocostosnombre_Internalname ;
      private string edtavCentrocostosnombre_Jsonclick ;
      private string edtavCentrocostospreciofinal_Internalname ;
      private string edtavCentrocostospreciofinal_Jsonclick ;
      private string edtCentroCostosSubTotal_Internalname ;
      private string edtCentroCostosSubTotal_Jsonclick ;
      private string A463CentroCostosNombre ;
      private string edtCentroCostosNombre_Jsonclick ;
      private string edtCentroCostosPrecioFinal_Internalname ;
      private string edtCentroCostosPrecioFinal_Jsonclick ;
      private string edtavFechacierresolicitud_Internalname ;
      private string edtavFechacierresolicitud_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Caption ;
      private string lblTextblock2_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divTableleaflevel_detalles_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string chkavError_Internalname ;
      private string sMode70 ;
      private string edtCentroCostosDetallesFecha_Internalname ;
      private string edtCentroCostosDetallesId_Internalname ;
      private string edtListaCostosId_Internalname ;
      private string edtCentroCostosDetallesNombre_Internalname ;
      private string edtCentroCostosDetallesValor_Internalname ;
      private string edtCentroCostosDetallesSolId_Internalname ;
      private string edtCCDetallesProfId_Internalname ;
      private string edtCCDetallesProfNombre_Internalname ;
      private string cmbCentroCostosDetallesEstado_Internalname ;
      private string imgprompt_459_Link ;
      private string sStyleString ;
      private string subGridlevel_detalles_Internalname ;
      private string A478CentroCostosUsrAlta ;
      private string A479CentroCostosUsrMod ;
      private string A482CentroCostosEstado ;
      private string AV40Pgmname ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A460ListaCostosNombre ;
      private string hsh ;
      private string sMode69 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXCCtl ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string imgNuevoitem_gximage ;
      private string imgNuevoitem_Internalname ;
      private string GXEncryptionTmp ;
      private string Z460ListaCostosNombre ;
      private string Z167ProfesionalesApellidoPrimero ;
      private string Z166ProfesionalesPrimerNombre ;
      private string Z191ProfesionalesSegundoNombre ;
      private string imgprompt_459_Internalname ;
      private string imgprompt_890_Internalname ;
      private string sGXsfl_65_fel_idx="0001" ;
      private string subGridlevel_detalles_Class ;
      private string subGridlevel_detalles_Linesclass ;
      private string imgprompt_890_Link ;
      private string ROClassString ;
      private string edtCentroCostosDetallesFecha_Jsonclick ;
      private string edtCentroCostosDetallesId_Jsonclick ;
      private string edtListaCostosId_Jsonclick ;
      private string imgprompt_459_gximage ;
      private string sImgUrl ;
      private string edtCentroCostosDetallesNombre_Jsonclick ;
      private string edtCentroCostosDetallesValor_Jsonclick ;
      private string edtCentroCostosDetallesSolId_Jsonclick ;
      private string edtCCDetallesProfId_Jsonclick ;
      private string imgprompt_890_gximage ;
      private string edtCCDetallesProfNombre_Jsonclick ;
      private string cmbCentroCostosDetallesEstado_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i487CentroCostosTipoRef ;
      private string i482CentroCostosEstado ;
      private string subGridlevel_detalles_Header ;
      private DateTime Z480CentroCostosHoraAlt ;
      private DateTime Z481CentroCostosHoraMod ;
      private DateTime Z892CentroCostosDetallesFecha ;
      private DateTime N892CentroCostosDetallesFecha ;
      private DateTime A892CentroCostosDetallesFecha ;
      private DateTime AV31FechaCierreSolicitud ;
      private DateTime A480CentroCostosHoraAlt ;
      private DateTime A481CentroCostosHoraMod ;
      private DateTime GXt_date2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n459ListaCostosId ;
      private bool wbErr ;
      private bool AV35Error ;
      private bool n469CentroCostosSubTotal ;
      private bool bGXsfl_65_Refreshing=false ;
      private bool n167ProfesionalesApellidoPrimero ;
      private bool n166ProfesionalesPrimerNombre ;
      private bool n191ProfesionalesSegundoNombre ;
      private bool AV24IsOk ;
      private bool returnInSub ;
      private bool AV9IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private string A889CentroCostosJson ;
      private string Z889CentroCostosJson ;
      private string AV13CentroCostosNombre ;
      private string AV25TxtMsg ;
      private string A891CCDetallesProfNombre ;
      private string AV39Nuevoitem_GXI ;
      private string Z891CCDetallesProfNombre ;
      private string AV15NuevoItem ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_detallesContainer ;
      private GXWebRow Gridlevel_detallesRow ;
      private GXWebColumn Gridlevel_detallesColumn ;
      private IGxSession AV11WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCentroCostosTipoRef ;
      private GXCombobox cmbCentroCostosDetallesEstado ;
      private GXCheckbox chkavError ;
      private GxSimpleCollection<long> AV36SolicitudesIdCollection ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV16WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_default ;
      private decimal[] T000P9_A469CentroCostosSubTotal ;
      private bool[] T000P9_n469CentroCostosSubTotal ;
      private long[] T000P11_A461CentroCostosId ;
      private string[] T000P11_A487CentroCostosTipoRef ;
      private long[] T000P11_A462CentroCostosRef ;
      private decimal[] T000P11_A475CentroCostosCosto ;
      private string[] T000P11_A463CentroCostosNombre ;
      private decimal[] T000P11_A464CentroCostosPrecioFinal ;
      private long[] T000P11_A465CentroCostosSerial ;
      private string[] T000P11_A889CentroCostosJson ;
      private string[] T000P11_A478CentroCostosUsrAlta ;
      private string[] T000P11_A479CentroCostosUsrMod ;
      private DateTime[] T000P11_A480CentroCostosHoraAlt ;
      private DateTime[] T000P11_A481CentroCostosHoraMod ;
      private string[] T000P11_A482CentroCostosEstado ;
      private decimal[] T000P11_A469CentroCostosSubTotal ;
      private bool[] T000P11_n469CentroCostosSubTotal ;
      private decimal[] T000P13_A469CentroCostosSubTotal ;
      private bool[] T000P13_n469CentroCostosSubTotal ;
      private long[] T000P14_A461CentroCostosId ;
      private long[] T000P7_A461CentroCostosId ;
      private string[] T000P7_A487CentroCostosTipoRef ;
      private long[] T000P7_A462CentroCostosRef ;
      private decimal[] T000P7_A475CentroCostosCosto ;
      private string[] T000P7_A463CentroCostosNombre ;
      private decimal[] T000P7_A464CentroCostosPrecioFinal ;
      private long[] T000P7_A465CentroCostosSerial ;
      private string[] T000P7_A889CentroCostosJson ;
      private string[] T000P7_A478CentroCostosUsrAlta ;
      private string[] T000P7_A479CentroCostosUsrMod ;
      private DateTime[] T000P7_A480CentroCostosHoraAlt ;
      private DateTime[] T000P7_A481CentroCostosHoraMod ;
      private string[] T000P7_A482CentroCostosEstado ;
      private long[] T000P15_A461CentroCostosId ;
      private long[] T000P16_A461CentroCostosId ;
      private long[] T000P6_A461CentroCostosId ;
      private string[] T000P6_A487CentroCostosTipoRef ;
      private long[] T000P6_A462CentroCostosRef ;
      private decimal[] T000P6_A475CentroCostosCosto ;
      private string[] T000P6_A463CentroCostosNombre ;
      private decimal[] T000P6_A464CentroCostosPrecioFinal ;
      private long[] T000P6_A465CentroCostosSerial ;
      private string[] T000P6_A889CentroCostosJson ;
      private string[] T000P6_A478CentroCostosUsrAlta ;
      private string[] T000P6_A479CentroCostosUsrMod ;
      private DateTime[] T000P6_A480CentroCostosHoraAlt ;
      private DateTime[] T000P6_A481CentroCostosHoraMod ;
      private string[] T000P6_A482CentroCostosEstado ;
      private long[] T000P17_A461CentroCostosId ;
      private decimal[] T000P21_A469CentroCostosSubTotal ;
      private bool[] T000P21_n469CentroCostosSubTotal ;
      private long[] T000P23_A461CentroCostosId ;
      private long[] T000P24_A461CentroCostosId ;
      private long[] T000P24_A466CentroCostosDetallesId ;
      private long[] T000P24_A893CentroCostosDetallesEstado ;
      private string[] T000P24_A473CentroCostosDetallesNombre ;
      private decimal[] T000P24_A468CentroCostosDetallesValor ;
      private DateTime[] T000P24_A892CentroCostosDetallesFecha ;
      private string[] T000P24_A460ListaCostosNombre ;
      private decimal[] T000P24_A471ListaCostosValor ;
      private long[] T000P24_A888CentroCostosDetallesSolId ;
      private string[] T000P24_A167ProfesionalesApellidoPrimero ;
      private bool[] T000P24_n167ProfesionalesApellidoPrimero ;
      private string[] T000P24_A166ProfesionalesPrimerNombre ;
      private bool[] T000P24_n166ProfesionalesPrimerNombre ;
      private string[] T000P24_A191ProfesionalesSegundoNombre ;
      private bool[] T000P24_n191ProfesionalesSegundoNombre ;
      private long[] T000P24_A459ListaCostosId ;
      private bool[] T000P24_n459ListaCostosId ;
      private string[] T000P24_A890CCDetallesProfId ;
      private string[] T000P4_A460ListaCostosNombre ;
      private decimal[] T000P4_A471ListaCostosValor ;
      private string[] T000P5_A167ProfesionalesApellidoPrimero ;
      private bool[] T000P5_n167ProfesionalesApellidoPrimero ;
      private string[] T000P5_A166ProfesionalesPrimerNombre ;
      private bool[] T000P5_n166ProfesionalesPrimerNombre ;
      private string[] T000P5_A191ProfesionalesSegundoNombre ;
      private bool[] T000P5_n191ProfesionalesSegundoNombre ;
      private string[] T000P25_A460ListaCostosNombre ;
      private decimal[] T000P25_A471ListaCostosValor ;
      private string[] T000P26_A167ProfesionalesApellidoPrimero ;
      private bool[] T000P26_n167ProfesionalesApellidoPrimero ;
      private string[] T000P26_A166ProfesionalesPrimerNombre ;
      private bool[] T000P26_n166ProfesionalesPrimerNombre ;
      private string[] T000P26_A191ProfesionalesSegundoNombre ;
      private bool[] T000P26_n191ProfesionalesSegundoNombre ;
      private long[] T000P27_A461CentroCostosId ;
      private long[] T000P27_A466CentroCostosDetallesId ;
      private long[] T000P3_A461CentroCostosId ;
      private long[] T000P3_A466CentroCostosDetallesId ;
      private long[] T000P3_A893CentroCostosDetallesEstado ;
      private string[] T000P3_A473CentroCostosDetallesNombre ;
      private decimal[] T000P3_A468CentroCostosDetallesValor ;
      private DateTime[] T000P3_A892CentroCostosDetallesFecha ;
      private long[] T000P3_A888CentroCostosDetallesSolId ;
      private long[] T000P3_A459ListaCostosId ;
      private bool[] T000P3_n459ListaCostosId ;
      private string[] T000P3_A890CCDetallesProfId ;
      private long[] T000P2_A461CentroCostosId ;
      private long[] T000P2_A466CentroCostosDetallesId ;
      private long[] T000P2_A893CentroCostosDetallesEstado ;
      private string[] T000P2_A473CentroCostosDetallesNombre ;
      private decimal[] T000P2_A468CentroCostosDetallesValor ;
      private DateTime[] T000P2_A892CentroCostosDetallesFecha ;
      private long[] T000P2_A888CentroCostosDetallesSolId ;
      private long[] T000P2_A459ListaCostosId ;
      private bool[] T000P2_n459ListaCostosId ;
      private string[] T000P2_A890CCDetallesProfId ;
      private string[] T000P31_A460ListaCostosNombre ;
      private decimal[] T000P31_A471ListaCostosValor ;
      private string[] T000P32_A167ProfesionalesApellidoPrimero ;
      private bool[] T000P32_n167ProfesionalesApellidoPrimero ;
      private string[] T000P32_A166ProfesionalesPrimerNombre ;
      private bool[] T000P32_n166ProfesionalesPrimerNombre ;
      private string[] T000P32_A191ProfesionalesSegundoNombre ;
      private bool[] T000P32_n191ProfesionalesSegundoNombre ;
      private long[] T000P33_A461CentroCostosId ;
      private long[] T000P33_A466CentroCostosDetallesId ;
      private GxSimpleCollection<long> GXt_objcol_int3 ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class costoservicios__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class costoservicios__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000P2;
        prmT000P2 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmT000P3;
        prmT000P3 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmT000P4;
        prmT000P4 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000P5;
        prmT000P5 = new Object[] {
        new ParDef("@CCDetallesProfId",GXType.Char,20,0)
        };
        Object[] prmT000P6;
        prmT000P6 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT000P7;
        prmT000P7 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT000P9;
        prmT000P9 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT000P11;
        prmT000P11 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT000P13;
        prmT000P13 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT000P14;
        prmT000P14 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT000P15;
        prmT000P15 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT000P16;
        prmT000P16 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT000P17;
        prmT000P17 = new Object[] {
        new ParDef("@CentroCostosTipoRef",GXType.NChar,1,0) ,
        new ParDef("@CentroCostosRef",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosCosto",GXType.Decimal,18,2) ,
        new ParDef("@CentroCostosNombre",GXType.NChar,80,0) ,
        new ParDef("@CentroCostosPrecioFinal",GXType.Decimal,18,2) ,
        new ParDef("@CentroCostosSerial",GXType.Decimal,10,0) ,
        new ParDef("@CentroCostosJson",GXType.NVarChar,2097152,0) ,
        new ParDef("@CentroCostosUsrAlta",GXType.NChar,30,0) ,
        new ParDef("@CentroCostosUsrMod",GXType.NChar,30,0) ,
        new ParDef("@CentroCostosHoraAlt",GXType.Date,8,0) ,
        new ParDef("@CentroCostosHoraMod",GXType.Date,8,0) ,
        new ParDef("@CentroCostosEstado",GXType.NChar,3,0)
        };
        Object[] prmT000P18;
        prmT000P18 = new Object[] {
        new ParDef("@CentroCostosTipoRef",GXType.NChar,1,0) ,
        new ParDef("@CentroCostosRef",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosCosto",GXType.Decimal,18,2) ,
        new ParDef("@CentroCostosNombre",GXType.NChar,80,0) ,
        new ParDef("@CentroCostosPrecioFinal",GXType.Decimal,18,2) ,
        new ParDef("@CentroCostosSerial",GXType.Decimal,10,0) ,
        new ParDef("@CentroCostosJson",GXType.NVarChar,2097152,0) ,
        new ParDef("@CentroCostosUsrAlta",GXType.NChar,30,0) ,
        new ParDef("@CentroCostosUsrMod",GXType.NChar,30,0) ,
        new ParDef("@CentroCostosHoraAlt",GXType.Date,8,0) ,
        new ParDef("@CentroCostosHoraMod",GXType.Date,8,0) ,
        new ParDef("@CentroCostosEstado",GXType.NChar,3,0) ,
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT000P19;
        prmT000P19 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT000P21;
        prmT000P21 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT000P22;
        prmT000P22 = new Object[] {
        new ParDef("@CentroCostosSerial",GXType.Decimal,10,0) ,
        new ParDef("@CentroCostosCosto",GXType.Decimal,18,2) ,
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        Object[] prmT000P23;
        prmT000P23 = new Object[] {
        };
        Object[] prmT000P24;
        prmT000P24 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmT000P25;
        prmT000P25 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000P26;
        prmT000P26 = new Object[] {
        new ParDef("@CCDetallesProfId",GXType.Char,20,0)
        };
        Object[] prmT000P27;
        prmT000P27 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmT000P28;
        prmT000P28 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesEstado",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesNombre",GXType.NChar,80,0) ,
        new ParDef("@CentroCostosDetallesValor",GXType.Decimal,10,2) ,
        new ParDef("@CentroCostosDetallesFecha",GXType.Date,8,0) ,
        new ParDef("@CentroCostosDetallesSolId",GXType.Decimal,18,0) ,
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CCDetallesProfId",GXType.Char,20,0)
        };
        Object[] prmT000P29;
        prmT000P29 = new Object[] {
        new ParDef("@CentroCostosDetallesEstado",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesNombre",GXType.NChar,80,0) ,
        new ParDef("@CentroCostosDetallesValor",GXType.Decimal,10,2) ,
        new ParDef("@CentroCostosDetallesFecha",GXType.Date,8,0) ,
        new ParDef("@CentroCostosDetallesSolId",GXType.Decimal,18,0) ,
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@CCDetallesProfId",GXType.Char,20,0) ,
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmT000P30;
        prmT000P30 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0) ,
        new ParDef("@CentroCostosDetallesId",GXType.Decimal,18,0)
        };
        Object[] prmT000P31;
        prmT000P31 = new Object[] {
        new ParDef("@ListaCostosId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000P32;
        prmT000P32 = new Object[] {
        new ParDef("@CCDetallesProfId",GXType.Char,20,0)
        };
        Object[] prmT000P33;
        prmT000P33 = new Object[] {
        new ParDef("@CentroCostosId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000P2", "SELECT [CentroCostosId], [CentroCostosDetallesId], [CentroCostosDetallesEstado], [CentroCostosDetallesNombre], [CentroCostosDetallesValor], [CentroCostosDetallesFecha], [CentroCostosDetallesSolId], [ListaCostosId], [CCDetallesProfId] AS CCDetallesProfId FROM [CentroCostosDetalles] WITH (UPDLOCK) WHERE [CentroCostosId] = @CentroCostosId AND [CentroCostosDetallesId] = @CentroCostosDetallesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P3", "SELECT [CentroCostosId], [CentroCostosDetallesId], [CentroCostosDetallesEstado], [CentroCostosDetallesNombre], [CentroCostosDetallesValor], [CentroCostosDetallesFecha], [CentroCostosDetallesSolId], [ListaCostosId], [CCDetallesProfId] AS CCDetallesProfId FROM [CentroCostosDetalles] WHERE [CentroCostosId] = @CentroCostosId AND [CentroCostosDetallesId] = @CentroCostosDetallesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P4", "SELECT [ListaCostosNombre], [ListaCostosValor] FROM [ListaCostos] WHERE [ListaCostosId] = @ListaCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P5", "SELECT [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre] FROM [Profesionales] WHERE [ProfesionalesId] = @CCDetallesProfId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P6", "SELECT [CentroCostosId], [CentroCostosTipoRef], [CentroCostosRef], [CentroCostosCosto], [CentroCostosNombre], [CentroCostosPrecioFinal], [CentroCostosSerial], [CentroCostosJson], [CentroCostosUsrAlta], [CentroCostosUsrMod], [CentroCostosHoraAlt], [CentroCostosHoraMod], [CentroCostosEstado] FROM [CentroCostos] WITH (UPDLOCK) WHERE [CentroCostosId] = @CentroCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P7", "SELECT [CentroCostosId], [CentroCostosTipoRef], [CentroCostosRef], [CentroCostosCosto], [CentroCostosNombre], [CentroCostosPrecioFinal], [CentroCostosSerial], [CentroCostosJson], [CentroCostosUsrAlta], [CentroCostosUsrMod], [CentroCostosHoraAlt], [CentroCostosHoraMod], [CentroCostosEstado] FROM [CentroCostos] WHERE [CentroCostosId] = @CentroCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P9", "SELECT COALESCE( T1.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T1 WHERE T1.[CentroCostosId] = @CentroCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P11", "SELECT TM1.[CentroCostosId], TM1.[CentroCostosTipoRef], TM1.[CentroCostosRef], TM1.[CentroCostosCosto], TM1.[CentroCostosNombre], TM1.[CentroCostosPrecioFinal], TM1.[CentroCostosSerial], TM1.[CentroCostosJson], TM1.[CentroCostosUsrAlta], TM1.[CentroCostosUsrMod], TM1.[CentroCostosHoraAlt], TM1.[CentroCostosHoraMod], TM1.[CentroCostosEstado], COALESCE( T2.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM ([CentroCostos] TM1 LEFT JOIN (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T2 ON T2.[CentroCostosId] = TM1.[CentroCostosId]) WHERE TM1.[CentroCostosId] = @CentroCostosId ORDER BY TM1.[CentroCostosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P11,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P13", "SELECT COALESCE( T1.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T1 WHERE T1.[CentroCostosId] = @CentroCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P14", "SELECT [CentroCostosId] FROM [CentroCostos] WHERE [CentroCostosId] = @CentroCostosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P15", "SELECT TOP 1 [CentroCostosId] FROM [CentroCostos] WHERE ( [CentroCostosId] > @CentroCostosId) ORDER BY [CentroCostosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P16", "SELECT TOP 1 [CentroCostosId] FROM [CentroCostos] WHERE ( [CentroCostosId] < @CentroCostosId) ORDER BY [CentroCostosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P17", "INSERT INTO [CentroCostos]([CentroCostosTipoRef], [CentroCostosRef], [CentroCostosCosto], [CentroCostosNombre], [CentroCostosPrecioFinal], [CentroCostosSerial], [CentroCostosJson], [CentroCostosUsrAlta], [CentroCostosUsrMod], [CentroCostosHoraAlt], [CentroCostosHoraMod], [CentroCostosEstado]) VALUES(@CentroCostosTipoRef, @CentroCostosRef, @CentroCostosCosto, @CentroCostosNombre, @CentroCostosPrecioFinal, @CentroCostosSerial, @CentroCostosJson, @CentroCostosUsrAlta, @CentroCostosUsrMod, @CentroCostosHoraAlt, @CentroCostosHoraMod, @CentroCostosEstado); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000P17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P18", "UPDATE [CentroCostos] SET [CentroCostosTipoRef]=@CentroCostosTipoRef, [CentroCostosRef]=@CentroCostosRef, [CentroCostosCosto]=@CentroCostosCosto, [CentroCostosNombre]=@CentroCostosNombre, [CentroCostosPrecioFinal]=@CentroCostosPrecioFinal, [CentroCostosSerial]=@CentroCostosSerial, [CentroCostosJson]=@CentroCostosJson, [CentroCostosUsrAlta]=@CentroCostosUsrAlta, [CentroCostosUsrMod]=@CentroCostosUsrMod, [CentroCostosHoraAlt]=@CentroCostosHoraAlt, [CentroCostosHoraMod]=@CentroCostosHoraMod, [CentroCostosEstado]=@CentroCostosEstado  WHERE [CentroCostosId] = @CentroCostosId", GxErrorMask.GX_NOMASK,prmT000P18)
           ,new CursorDef("T000P19", "DELETE FROM [CentroCostos]  WHERE [CentroCostosId] = @CentroCostosId", GxErrorMask.GX_NOMASK,prmT000P19)
           ,new CursorDef("T000P21", "SELECT COALESCE( T1.[CentroCostosSubTotal], 0) AS CentroCostosSubTotal FROM (SELECT SUM([CentroCostosDetallesValor]) AS CentroCostosSubTotal, [CentroCostosId] FROM [CentroCostosDetalles] GROUP BY [CentroCostosId] ) T1 WHERE T1.[CentroCostosId] = @CentroCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P22", "UPDATE [CentroCostos] SET [CentroCostosSerial]=@CentroCostosSerial, [CentroCostosCosto]=@CentroCostosCosto  WHERE [CentroCostosId] = @CentroCostosId", GxErrorMask.GX_NOMASK,prmT000P22)
           ,new CursorDef("T000P23", "SELECT [CentroCostosId] FROM [CentroCostos] ORDER BY [CentroCostosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P23,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P24", "SELECT T1.[CentroCostosId], T1.[CentroCostosDetallesId], T1.[CentroCostosDetallesEstado], T1.[CentroCostosDetallesNombre], T1.[CentroCostosDetallesValor], T1.[CentroCostosDetallesFecha], T2.[ListaCostosNombre], T2.[ListaCostosValor], T1.[CentroCostosDetallesSolId], T3.[ProfesionalesApellidoPrimero], T3.[ProfesionalesPrimerNombre], T3.[ProfesionalesSegundoNombre], T1.[ListaCostosId], T1.[CCDetallesProfId] AS CCDetallesProfId FROM (([CentroCostosDetalles] T1 LEFT JOIN [ListaCostos] T2 ON T2.[ListaCostosId] = T1.[ListaCostosId]) INNER JOIN [Profesionales] T3 ON T3.[ProfesionalesId] = T1.[CCDetallesProfId]) WHERE T1.[CentroCostosId] = @CentroCostosId and T1.[CentroCostosDetallesId] = @CentroCostosDetallesId ORDER BY T1.[CentroCostosId], T1.[CentroCostosDetallesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P24,4, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P25", "SELECT [ListaCostosNombre], [ListaCostosValor] FROM [ListaCostos] WHERE [ListaCostosId] = @ListaCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P26", "SELECT [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre] FROM [Profesionales] WHERE [ProfesionalesId] = @CCDetallesProfId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P27", "SELECT [CentroCostosId], [CentroCostosDetallesId] FROM [CentroCostosDetalles] WHERE [CentroCostosId] = @CentroCostosId AND [CentroCostosDetallesId] = @CentroCostosDetallesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P28", "INSERT INTO [CentroCostosDetalles]([CentroCostosId], [CentroCostosDetallesId], [CentroCostosDetallesEstado], [CentroCostosDetallesNombre], [CentroCostosDetallesValor], [CentroCostosDetallesFecha], [CentroCostosDetallesSolId], [ListaCostosId], [CCDetallesProfId]) VALUES(@CentroCostosId, @CentroCostosDetallesId, @CentroCostosDetallesEstado, @CentroCostosDetallesNombre, @CentroCostosDetallesValor, @CentroCostosDetallesFecha, @CentroCostosDetallesSolId, @ListaCostosId, @CCDetallesProfId)", GxErrorMask.GX_NOMASK,prmT000P28)
           ,new CursorDef("T000P29", "UPDATE [CentroCostosDetalles] SET [CentroCostosDetallesEstado]=@CentroCostosDetallesEstado, [CentroCostosDetallesNombre]=@CentroCostosDetallesNombre, [CentroCostosDetallesValor]=@CentroCostosDetallesValor, [CentroCostosDetallesFecha]=@CentroCostosDetallesFecha, [CentroCostosDetallesSolId]=@CentroCostosDetallesSolId, [ListaCostosId]=@ListaCostosId, [CCDetallesProfId]=@CCDetallesProfId  WHERE [CentroCostosId] = @CentroCostosId AND [CentroCostosDetallesId] = @CentroCostosDetallesId", GxErrorMask.GX_NOMASK,prmT000P29)
           ,new CursorDef("T000P30", "DELETE FROM [CentroCostosDetalles]  WHERE [CentroCostosId] = @CentroCostosId AND [CentroCostosDetallesId] = @CentroCostosDetallesId", GxErrorMask.GX_NOMASK,prmT000P30)
           ,new CursorDef("T000P31", "SELECT [ListaCostosNombre], [ListaCostosValor] FROM [ListaCostos] WHERE [ListaCostosId] = @ListaCostosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P32", "SELECT [ProfesionalesApellidoPrimero], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre] FROM [Profesionales] WHERE [ProfesionalesId] = @CCDetallesProfId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P33", "SELECT [CentroCostosId], [CentroCostosDetallesId] FROM [CentroCostosDetalles] WHERE [CentroCostosId] = @CentroCostosId ORDER BY [CentroCostosId], [CentroCostosDetallesId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P33,4, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 30);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getString(3, 30);
              ((bool[]) buf[5])[0] = rslt.wasNull(3);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 30);
              ((string[]) buf[9])[0] = rslt.getString(10, 30);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 3);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 30);
              ((string[]) buf[9])[0] = rslt.getString(10, 30);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 3);
              return;
           case 6 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 80);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 30);
              ((string[]) buf[9])[0] = rslt.getString(10, 30);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 3);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((bool[]) buf[14])[0] = rslt.wasNull(14);
              return;
           case 8 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 80);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 80);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 30);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 30);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 30);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              ((string[]) buf[17])[0] = rslt.getString(14, 20);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 30);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getString(3, 30);
              ((bool[]) buf[5])[0] = rslt.wasNull(3);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 30);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 30);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getString(3, 30);
              ((bool[]) buf[5])[0] = rslt.wasNull(3);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}

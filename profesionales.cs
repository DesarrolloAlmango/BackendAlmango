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
   public class profesionales : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            GXDLAESTADOSGENERICOSID0S34( A107EstadosTipo) ;
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
            GXDLABANCOID0S34( ) ;
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
            GXDLARUBROSID0S35( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"DEPARTAMENTOMUNICIPIOID") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLADEPARTAMENTOMUNICIPIOID0S36( A112DepartamentoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"ZONASID") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLAZONASID0S36( A112DepartamentoId, A114DepartamentoMunicipioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_46") == 0 )
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
            gxLoad_46( A673BancoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_45") == 0 )
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
            gxLoad_45( A107EstadosTipo, A108EstadosGenericosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_48") == 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "RubrosId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_48( A121RubrosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_49") == 0 )
         {
            A124EstadosProfRubTipo = GetPar( "EstadosProfRubTipo");
            A125EstadosProfRubId = (int)(Math.Round(NumberUtil.Val( GetPar( "EstadosProfRubId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_49( A124EstadosProfRubTipo, A125EstadosProfRubId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_51") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_51( A112DepartamentoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_52") == 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_52( A112DepartamentoId, A114DepartamentoMunicipioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_53") == 0 )
         {
            A110ZonasID = (long)(Math.Round(NumberUtil.Val( GetPar( "ZonasID"), "."), 18, MidpointRounding.ToEven));
            n110ZonasID = false;
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoId"), "."), 18, MidpointRounding.ToEven));
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "DepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_53( A110ZonasID, A112DepartamentoId, A114DepartamentoMunicipioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_55") == 0 )
         {
            A993ProfesionalServicioId = (long)(Math.Round(NumberUtil.Val( GetPar( "ProfesionalServicioId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_55( A993ProfesionalServicioId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_servicios") == 0 )
         {
            gxnrGridlevel_servicios_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_zonas") == 0 )
         {
            gxnrGridlevel_zonas_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "profesionales.aspx")), "profesionales.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "profesionales.aspx")))) ;
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
                  AV7ProfesionalesId = GetPar( "ProfesionalesId");
                  AssignAttri("", false, "AV7ProfesionalesId", AV7ProfesionalesId);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ProfesionalesId, "")), context));
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
         Form.Meta.addItem("description", context.GetMessage( "Profesionales", ""), 0) ;
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

      protected void gxnrGridlevel_rubros_newrow_invoke( )
      {
         nRC_GXsfl_122 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_122"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_122_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_122_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_122_idx = GetPar( "sGXsfl_122_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_rubros_newrow( ) ;
         /* End function gxnrGridlevel_rubros_newrow_invoke */
      }

      protected void gxnrGridlevel_servicios_newrow_invoke( )
      {
         nRC_GXsfl_143 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_143"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_143_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_143_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_143_idx = GetPar( "sGXsfl_143_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_servicios_newrow( ) ;
         /* End function gxnrGridlevel_servicios_newrow_invoke */
      }

      protected void gxnrGridlevel_zonas_newrow_invoke( )
      {
         nRC_GXsfl_157 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_157"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_157_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_157_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_157_idx = GetPar( "sGXsfl_157_idx");
         A197ProfesionalesAutoEnuZona = (short)(Math.Round(NumberUtil.Val( GetPar( "ProfesionalesAutoEnuZona"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_zonas_newrow( ) ;
         /* End function gxnrGridlevel_zonas_newrow_invoke */
      }

      public profesionales( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionales( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_ProfesionalesId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProfesionalesId = aP1_ProfesionalesId;
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
         chkProfesionalesEsRUT = new GXCheckbox();
         cmbProfesionalesVerDatPerSol = new GXCombobox();
         dynBancoId = new GXCombobox();
         dynRubrosId = new GXCombobox();
         cmbEstadosProfRubId = new GXCombobox();
         cmbRubrosEstado = new GXCombobox();
         cmbEstadoServProf = new GXCombobox();
         dynDepartamentoId = new GXCombobox();
         dynDepartamentoMunicipioId = new GXCombobox();
         dynZonasID = new GXCombobox();
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
         A676ProfesionalesEsRUT = StringUtil.StrToBool( StringUtil.BoolToStr( A676ProfesionalesEsRUT));
         n676ProfesionalesEsRUT = false;
         AssignAttri("", false, "A676ProfesionalesEsRUT", A676ProfesionalesEsRUT);
         if ( cmbProfesionalesVerDatPerSol.ItemCount > 0 )
         {
            A267ProfesionalesVerDatPerSol = cmbProfesionalesVerDatPerSol.getValidValue(A267ProfesionalesVerDatPerSol);
            AssignAttri("", false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProfesionalesVerDatPerSol.CurrentValue = StringUtil.RTrim( A267ProfesionalesVerDatPerSol);
            AssignProp("", false, cmbProfesionalesVerDatPerSol_Internalname, "Values", cmbProfesionalesVerDatPerSol.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTabgeneral_title_Internalname, context.GetMessage( "WWP_TemplateDataPanelTitle", ""), "", "", lblTabgeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Profesionales.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesId_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesId_Internalname, StringUtil.RTrim( A120ProfesionalesId), StringUtil.RTrim( context.localUtil.Format( A120ProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtProfesionalesId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesId_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "NoIdentidad", "start", true, "", "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynEstadosGenericosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynEstadosGenericosId_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynEstadosGenericosId, dynEstadosGenericosId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0)), 1, dynEstadosGenericosId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynEstadosGenericosId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Profesionales.htm");
         dynEstadosGenericosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
         AssignProp("", false, dynEstadosGenericosId_Internalname, "Values", (string)(dynEstadosGenericosId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkProfesionalesEsRUT_Internalname, context.GetMessage( "El Documento es RUT", ""), "col-sm-3 AttributeCheckBoxLabel", 0, true, "");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkProfesionalesEsRUT_Internalname, StringUtil.BoolToStr( A676ProfesionalesEsRUT), "", context.GetMessage( "El Documento es RUT", ""), 1, chkProfesionalesEsRUT.Enabled, "true", context.GetMessage( "EL DOCUMENTO ES RUT?", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(30, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,30);\"");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesPrimerNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesPrimerNombre_Internalname, context.GetMessage( "Primer Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesPrimerNombre_Internalname, StringUtil.RTrim( A166ProfesionalesPrimerNombre), StringUtil.RTrim( context.localUtil.Format( A166ProfesionalesPrimerNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesPrimerNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesPrimerNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesSegundoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesSegundoNombre_Internalname, context.GetMessage( "Segundo Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesSegundoNombre_Internalname, StringUtil.RTrim( A191ProfesionalesSegundoNombre), StringUtil.RTrim( context.localUtil.Format( A191ProfesionalesSegundoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesSegundoNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesSegundoNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesApellidoPrimero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesApellidoPrimero_Internalname, context.GetMessage( "Primer Apellido ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesApellidoPrimero_Internalname, StringUtil.RTrim( A167ProfesionalesApellidoPrimero), StringUtil.RTrim( context.localUtil.Format( A167ProfesionalesApellidoPrimero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesApellidoPrimero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesApellidoPrimero_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesApellidoSegundo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesApellidoSegundo_Internalname, context.GetMessage( "Segundo Apellido ", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesApellidoSegundo_Internalname, StringUtil.RTrim( A192ProfesionalesApellidoSegundo), StringUtil.RTrim( context.localUtil.Format( A192ProfesionalesApellidoSegundo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesApellidoSegundo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesApellidoSegundo_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Profesionales.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProfesionalesPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", context.GetMessage( "Imagen", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         A169ProfesionalesPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProfesionalesPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.PathToRelativeUrl( A169ProfesionalesPhoto));
         GxWebStd.gx_bitmap( context, imgProfesionalesPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProfesionalesPhoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "", "", "", 0, A169ProfesionalesPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "none", "HLP_Profesionales.htm");
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.PathToRelativeUrl( A169ProfesionalesPhoto)), true);
         AssignProp("", false, imgProfesionalesPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A169ProfesionalesPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesFeedBackCant_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesFeedBackCant_Internalname, context.GetMessage( "FeedBack", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesFeedBackCant_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A268ProfesionalesFeedBackCant), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProfesionalesFeedBackCant_Enabled!=0) ? context.localUtil.Format( (decimal)(A268ProfesionalesFeedBackCant), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A268ProfesionalesFeedBackCant), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFeedBackCant_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesFeedBackCant_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesTelefono_Internalname, context.GetMessage( "Teléfono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         gxphoneLink = "tel:" + StringUtil.RTrim( A170ProfesionalesTelefono);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesTelefono_Internalname, StringUtil.RTrim( A170ProfesionalesTelefono), StringUtil.RTrim( context.localUtil.Format( A170ProfesionalesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtProfesionalesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesEmail_Internalname, A193ProfesionalesEmail, StringUtil.RTrim( context.localUtil.Format( A193ProfesionalesEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A193ProfesionalesEmail, "", "", context.GetMessage( "email@correo.com", ""), edtProfesionalesEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesDireccion_Internalname, context.GetMessage( "Dirección", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProfesionalesDireccion_Internalname, A198ProfesionalesDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A198ProfesionalesDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", 0, 1, edtProfesionalesDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbProfesionalesVerDatPerSol_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbProfesionalesVerDatPerSol_Internalname, context.GetMessage( "Ver datos personales de solicitudes", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProfesionalesVerDatPerSol, cmbProfesionalesVerDatPerSol_Internalname, StringUtil.RTrim( A267ProfesionalesVerDatPerSol), 1, cmbProfesionalesVerDatPerSol_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbProfesionalesVerDatPerSol.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "", true, 0, "HLP_Profesionales.htm");
         cmbProfesionalesVerDatPerSol.CurrentValue = StringUtil.RTrim( A267ProfesionalesVerDatPerSol);
         AssignProp("", false, cmbProfesionalesVerDatPerSol_Internalname, "Values", (string)(cmbProfesionalesVerDatPerSol.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesLimitOSF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesLimitOSF_Internalname, context.GetMessage( "Limite ordenes sin finalizar", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesLimitOSF_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A617ProfesionalesLimitOSF), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProfesionalesLimitOSF_Enabled!=0) ? context.localUtil.Format( (decimal)(A617ProfesionalesLimitOSF), "ZZZ9") : context.localUtil.Format( (decimal)(A617ProfesionalesLimitOSF), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesLimitOSF_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesLimitOSF_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesAceptoTerminos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesAceptoTerminos_Internalname, context.GetMessage( "Aceptó Terminos y Condiciones", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProfesionalesAceptoTerminos_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProfesionalesAceptoTerminos_Internalname, context.localUtil.TToC( A678ProfesionalesAceptoTerminos, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A678ProfesionalesAceptoTerminos, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesAceptoTerminos_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesAceptoTerminos_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Profesionales.htm");
         GxWebStd.gx_bitmap( context, edtProfesionalesAceptoTerminos_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProfesionalesAceptoTerminos_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Profesionales.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesDeclaroDatosV_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesDeclaroDatosV_Internalname, context.GetMessage( "Declaró que los Datos Registrados son Verdaderos", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProfesionalesDeclaroDatosV_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProfesionalesDeclaroDatosV_Internalname, context.localUtil.TToC( A679ProfesionalesDeclaroDatosV, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A679ProfesionalesDeclaroDatosV, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesDeclaroDatosV_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesDeclaroDatosV_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Profesionales.htm");
         GxWebStd.gx_bitmap( context, edtProfesionalesDeclaroDatosV_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProfesionalesDeclaroDatosV_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Profesionales.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynBancoId, dynBancoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0)), 1, dynBancoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynBancoId.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "", true, 0, "HLP_Profesionales.htm");
         dynBancoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A673BancoId), 18, 0));
         AssignProp("", false, dynBancoId_Internalname, "Values", (string)(dynBancoId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesCuentaBancaria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesCuentaBancaria_Internalname, context.GetMessage( "Cuenta Bancaria", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesCuentaBancaria_Internalname, StringUtil.RTrim( A680ProfesionalesCuentaBancaria), StringUtil.RTrim( context.localUtil.Format( A680ProfesionalesCuentaBancaria, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesCuentaBancaria_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtProfesionalesCuentaBancaria_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "CuentaBancari", "start", true, "", "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_rubros_title_Internalname, context.GetMessage( "Rubros de Trabajo", ""), "", "", lblTablevel_rubros_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Profesionales.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_Rubros") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_rubros_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL DscTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProfesionalesExperiencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProfesionalesExperiencia_Internalname, context.GetMessage( "Experiencia", ""), " ActionGroupHeaderLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
         ClassString = "ActionGroupHeader";
         StyleString = "";
         ClassString = "ActionGroupHeader";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProfesionalesExperiencia_Internalname, A677ProfesionalesExperiencia, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"", 0, 1, edtProfesionalesExperiencia_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title3"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_servicios_title_Internalname, context.GetMessage( "Servicios de trabajo", ""), "", "", lblTablevel_servicios_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Profesionales.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_Servicios") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel3"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_servicios_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_servicios_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridlevel_servicios( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title4"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTablevel_zonas_title_Internalname, context.GetMessage( "Zona de trabajo", ""), "", "", lblTablevel_zonas_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Profesionales.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "TabLevel_Zonas") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel4"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabtablelevel_zonas_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_zonas_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders", "start", "top", "", "", "div");
         gxdraw_Gridlevel_zonas( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Profesionales.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadosTipo_Internalname, StringUtil.RTrim( A107EstadosTipo), StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,175);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosTipo_Jsonclick, 0, "Attribute", "", "", "", "", edtEstadosTipo_Visible, edtEstadosTipo_Enabled, 1, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Profesionales.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesCapacidadProducti_Internalname, StringUtil.LTrim( StringUtil.NToC( A800ProfesionalesCapacidadProducti, 10, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProfesionalesCapacidadProducti_Enabled!=0) ? context.localUtil.Format( A800ProfesionalesCapacidadProducti, "ZZZZZZ9.99") : context.localUtil.Format( A800ProfesionalesCapacidadProducti, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesCapacidadProducti_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesCapacidadProducti_Visible, edtProfesionalesCapacidadProducti_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "HoraCapacidadProductiva", "end", false, "", "HLP_Profesionales.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesPerAltShop_Internalname, StringUtil.RTrim( A436ProfesionalesPerAltShop), StringUtil.RTrim( context.localUtil.Format( A436ProfesionalesPerAltShop, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,177);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesPerAltShop_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesPerAltShop_Visible, edtProfesionalesPerAltShop_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Profesionales.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProfesionalesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProfesionalesFechaAlta_Internalname, context.localUtil.TToC( A199ProfesionalesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A199ProfesionalesFechaAlta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,178);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFechaAlta_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesFechaAlta_Visible, edtProfesionalesFechaAlta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Profesionales.htm");
         GxWebStd.gx_bitmap( context, edtProfesionalesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtProfesionalesFechaAlta_Visible==0)||(edtProfesionalesFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Profesionales.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProfesionalesFechaActualizado_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProfesionalesFechaActualizado_Internalname, context.localUtil.TToC( A200ProfesionalesFechaActualizado, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A200ProfesionalesFechaActualizado, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,179);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFechaActualizado_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesFechaActualizado_Visible, edtProfesionalesFechaActualizado_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Profesionales.htm");
         GxWebStd.gx_bitmap( context, edtProfesionalesFechaActualizado_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtProfesionalesFechaActualizado_Visible==0)||(edtProfesionalesFechaActualizado_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_Profesionales.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProfesionalesFeedBackProm_Internalname, StringUtil.LTrim( StringUtil.NToC( A269ProfesionalesFeedBackProm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtProfesionalesFeedBackProm_Enabled!=0) ? context.localUtil.Format( A269ProfesionalesFeedBackProm, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A269ProfesionalesFeedBackProm, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,180);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProfesionalesFeedBackProm_Jsonclick, 0, "Attribute", "", "", "", "", edtProfesionalesFeedBackProm_Visible, edtProfesionalesFeedBackProm_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Profesionales.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_rubros( )
      {
         /*  Grid Control  */
         StartGridControl122( ) ;
         nGXsfl_122_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount35 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_35 = 1;
               ScanStart0S35( ) ;
               while ( RcdFound35 != 0 )
               {
                  init_level_properties35( ) ;
                  getByPrimaryKey0S35( ) ;
                  AddRow0S35( ) ;
                  ScanNext0S35( ) ;
               }
               ScanEnd0S35( ) ;
               nBlankRcdCount35 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            standaloneNotModal0S35( ) ;
            standaloneModal0S35( ) ;
            sMode35 = Gx_mode;
            while ( nGXsfl_122_idx < nRC_GXsfl_122 )
            {
               bGXsfl_122_Refreshing = true;
               ReadRow0S35( ) ;
               dynRubrosId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_122_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), !bGXsfl_122_Refreshing);
               edtRubrosImagen_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSIMAGEN_"+sGXsfl_122_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtRubrosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosImagen_Enabled), 5, 0), !bGXsfl_122_Refreshing);
               edtEstadosProfRubTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSPROFRUBTIPO_"+sGXsfl_122_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtEstadosProfRubTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosProfRubTipo_Enabled), 5, 0), !bGXsfl_122_Refreshing);
               cmbEstadosProfRubId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSPROFRUBID_"+sGXsfl_122_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbEstadosProfRubId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEstadosProfRubId.Enabled), 5, 0), !bGXsfl_122_Refreshing);
               cmbRubrosEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSESTADO_"+sGXsfl_122_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbRubrosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRubrosEstado.Enabled), 5, 0), !bGXsfl_122_Refreshing);
               imgprompt_125_Link = cgiGet( "PROMPT_125_"+sGXsfl_122_idx+"Link");
               if ( ( nRcdExists_35 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0S35( ) ;
               }
               SendRow0S35( ) ;
               bGXsfl_122_Refreshing = false;
            }
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A197ProfesionalesAutoEnuZona = B197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount35 = 5;
            nRcdExists_35 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0S35( ) ;
               while ( RcdFound35 != 0 )
               {
                  sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_12235( ) ;
                  init_level_properties35( ) ;
                  standaloneNotModal0S35( ) ;
                  getByPrimaryKey0S35( ) ;
                  standaloneModal0S35( ) ;
                  AddRow0S35( ) ;
                  ScanNext0S35( ) ;
               }
               ScanEnd0S35( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode35 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx+1), 4, 0), 4, "0");
            SubsflControlProps_12235( ) ;
            InitAll0S35( ) ;
            init_level_properties35( ) ;
            B197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            nRcdExists_35 = 0;
            nIsMod_35 = 0;
            nRcdDeleted_35 = 0;
            nBlankRcdCount35 = (short)(nBlankRcdUsr35+nBlankRcdCount35);
            fRowAdded = 0;
            while ( nBlankRcdCount35 > 0 )
            {
               standaloneNotModal0S35( ) ;
               standaloneModal0S35( ) ;
               AddRow0S35( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = dynRubrosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount35 = (short)(nBlankRcdCount35-1);
            }
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A197ProfesionalesAutoEnuZona = B197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
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

      protected void gxdraw_Gridlevel_servicios( )
      {
         /*  Grid Control  */
         StartGridControl143( ) ;
         nGXsfl_143_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount145 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_145 = 1;
               ScanStart0S145( ) ;
               while ( RcdFound145 != 0 )
               {
                  init_level_properties145( ) ;
                  getByPrimaryKey0S145( ) ;
                  AddRow0S145( ) ;
                  ScanNext0S145( ) ;
               }
               ScanEnd0S145( ) ;
               nBlankRcdCount145 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            standaloneNotModal0S145( ) ;
            standaloneModal0S145( ) ;
            sMode145 = Gx_mode;
            while ( nGXsfl_143_idx < nRC_GXsfl_143 )
            {
               bGXsfl_143_Refreshing = true;
               ReadRow0S145( ) ;
               edtProfesionalServicioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALSERVICIOID_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalServicioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalServicioId_Enabled), 5, 0), !bGXsfl_143_Refreshing);
               edtProfesionalServicioNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALSERVICIONOMBRE_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalServicioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalServicioNombre_Enabled), 5, 0), !bGXsfl_143_Refreshing);
               cmbEstadoServProf.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSERVPROF_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbEstadoServProf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEstadoServProf.Enabled), 5, 0), !bGXsfl_143_Refreshing);
               imgprompt_125_Link = cgiGet( "PROMPT_993_"+sGXsfl_143_idx+"Link");
               if ( ( nRcdExists_145 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0S145( ) ;
               }
               SendRow0S145( ) ;
               bGXsfl_143_Refreshing = false;
            }
            Gx_mode = sMode145;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A197ProfesionalesAutoEnuZona = B197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount145 = 5;
            nRcdExists_145 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0S145( ) ;
               while ( RcdFound145 != 0 )
               {
                  sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_143145( ) ;
                  init_level_properties145( ) ;
                  standaloneNotModal0S145( ) ;
                  getByPrimaryKey0S145( ) ;
                  standaloneModal0S145( ) ;
                  AddRow0S145( ) ;
                  ScanNext0S145( ) ;
               }
               ScanEnd0S145( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode145 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx+1), 4, 0), 4, "0");
            SubsflControlProps_143145( ) ;
            InitAll0S145( ) ;
            init_level_properties145( ) ;
            B197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            nRcdExists_145 = 0;
            nIsMod_145 = 0;
            nRcdDeleted_145 = 0;
            nBlankRcdCount145 = (short)(nBlankRcdUsr145+nBlankRcdCount145);
            fRowAdded = 0;
            while ( nBlankRcdCount145 > 0 )
            {
               standaloneNotModal0S145( ) ;
               standaloneModal0S145( ) ;
               AddRow0S145( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProfesionalServicioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount145 = (short)(nBlankRcdCount145-1);
            }
            Gx_mode = sMode145;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A197ProfesionalesAutoEnuZona = B197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_serviciosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_servicios", Gridlevel_serviciosContainer, subGridlevel_servicios_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_serviciosContainerData", Gridlevel_serviciosContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_serviciosContainerData"+"V", Gridlevel_serviciosContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_serviciosContainerData"+"V"+"\" value='"+Gridlevel_serviciosContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridlevel_zonas( )
      {
         /*  Grid Control  */
         StartGridControl157( ) ;
         nGXsfl_157_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount36 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_36 = 1;
               ScanStart0S36( ) ;
               while ( RcdFound36 != 0 )
               {
                  init_level_properties36( ) ;
                  getByPrimaryKey0S36( ) ;
                  AddRow0S36( ) ;
                  ScanNext0S36( ) ;
               }
               ScanEnd0S36( ) ;
               nBlankRcdCount36 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            standaloneNotModal0S36( ) ;
            standaloneModal0S36( ) ;
            sMode36 = Gx_mode;
            while ( nGXsfl_157_idx < nRC_GXsfl_157 )
            {
               bGXsfl_157_Refreshing = true;
               ReadRow0S36( ) ;
               edtProfesionalesZonasCorrelativo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_157_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProfesionalesZonasCorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0), !bGXsfl_157_Refreshing);
               edtPaisID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAISID_"+sGXsfl_157_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), !bGXsfl_157_Refreshing);
               dynDepartamentoId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOID_"+sGXsfl_157_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), !bGXsfl_157_Refreshing);
               dynDepartamentoMunicipioId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_157_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), !bGXsfl_157_Refreshing);
               dynZonasID.Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ZONASID_"+sGXsfl_157_idx+"Visible"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynZonasID.Visible), 5, 0), !bGXsfl_157_Refreshing);
               dynZonasID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ZONASID_"+sGXsfl_157_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynZonasID.Enabled), 5, 0), !bGXsfl_157_Refreshing);
               if ( ( nRcdExists_36 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0S36( ) ;
               }
               SendRow0S36( ) ;
               bGXsfl_157_Refreshing = false;
            }
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A197ProfesionalesAutoEnuZona = B197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount36 = 5;
            nRcdExists_36 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0S36( ) ;
               while ( RcdFound36 != 0 )
               {
                  sGXsfl_157_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_157_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_15736( ) ;
                  init_level_properties36( ) ;
                  standaloneNotModal0S36( ) ;
                  getByPrimaryKey0S36( ) ;
                  standaloneModal0S36( ) ;
                  AddRow0S36( ) ;
                  ScanNext0S36( ) ;
               }
               ScanEnd0S36( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode36 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_157_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_157_idx+1), 4, 0), 4, "0");
            SubsflControlProps_15736( ) ;
            InitAll0S36( ) ;
            init_level_properties36( ) ;
            B197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            nRcdExists_36 = 0;
            nIsMod_36 = 0;
            nRcdDeleted_36 = 0;
            nBlankRcdCount36 = (short)(nBlankRcdUsr36+nBlankRcdCount36);
            fRowAdded = 0;
            while ( nBlankRcdCount36 > 0 )
            {
               standaloneNotModal0S36( ) ;
               standaloneModal0S36( ) ;
               AddRow0S36( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = dynDepartamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount36 = (short)(nBlankRcdCount36-1);
            }
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A197ProfesionalesAutoEnuZona = B197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_zonasContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_zonas", Gridlevel_zonasContainer, subGridlevel_zonas_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_zonasContainerData", Gridlevel_zonasContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_zonasContainerData"+"V", Gridlevel_zonasContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_zonasContainerData"+"V"+"\" value='"+Gridlevel_zonasContainer.GridValuesHidden()+"'/>") ;
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
         E110S2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z120ProfesionalesId = cgiGet( "Z120ProfesionalesId");
               Z199ProfesionalesFechaAlta = context.localUtil.CToT( cgiGet( "Z199ProfesionalesFechaAlta"), 0);
               Z200ProfesionalesFechaActualizado = context.localUtil.CToT( cgiGet( "Z200ProfesionalesFechaActualizado"), 0);
               Z900ProfesionalesFechaNacimiento = context.localUtil.CToD( cgiGet( "Z900ProfesionalesFechaNacimiento"), 0);
               n900ProfesionalesFechaNacimiento = ((DateTime.MinValue==A900ProfesionalesFechaNacimiento) ? true : false);
               Z901ProfesionalesRUT = cgiGet( "Z901ProfesionalesRUT");
               n901ProfesionalesRUT = (String.IsNullOrEmpty(StringUtil.RTrim( A901ProfesionalesRUT)) ? true : false);
               Z902ProfesionalesTipoEmpresa = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z902ProfesionalesTipoEmpresa"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n902ProfesionalesTipoEmpresa = ((0==A902ProfesionalesTipoEmpresa) ? true : false);
               Z676ProfesionalesEsRUT = StringUtil.StrToBool( cgiGet( "Z676ProfesionalesEsRUT"));
               n676ProfesionalesEsRUT = ((false==A676ProfesionalesEsRUT) ? true : false);
               Z166ProfesionalesPrimerNombre = cgiGet( "Z166ProfesionalesPrimerNombre");
               Z191ProfesionalesSegundoNombre = cgiGet( "Z191ProfesionalesSegundoNombre");
               Z167ProfesionalesApellidoPrimero = cgiGet( "Z167ProfesionalesApellidoPrimero");
               Z192ProfesionalesApellidoSegundo = cgiGet( "Z192ProfesionalesApellidoSegundo");
               Z170ProfesionalesTelefono = cgiGet( "Z170ProfesionalesTelefono");
               Z193ProfesionalesEmail = cgiGet( "Z193ProfesionalesEmail");
               n193ProfesionalesEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A193ProfesionalesEmail)) ? true : false);
               Z198ProfesionalesDireccion = cgiGet( "Z198ProfesionalesDireccion");
               Z267ProfesionalesVerDatPerSol = cgiGet( "Z267ProfesionalesVerDatPerSol");
               Z436ProfesionalesPerAltShop = cgiGet( "Z436ProfesionalesPerAltShop");
               n436ProfesionalesPerAltShop = (String.IsNullOrEmpty(StringUtil.RTrim( A436ProfesionalesPerAltShop)) ? true : false);
               Z196ProfesionalesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z196ProfesionalesAutoEnumerar"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z197ProfesionalesAutoEnuZona"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z677ProfesionalesExperiencia = cgiGet( "Z677ProfesionalesExperiencia");
               n677ProfesionalesExperiencia = (String.IsNullOrEmpty(StringUtil.RTrim( A677ProfesionalesExperiencia)) ? true : false);
               Z678ProfesionalesAceptoTerminos = context.localUtil.CToT( cgiGet( "Z678ProfesionalesAceptoTerminos"), 0);
               n678ProfesionalesAceptoTerminos = ((DateTime.MinValue==A678ProfesionalesAceptoTerminos) ? true : false);
               Z679ProfesionalesDeclaroDatosV = context.localUtil.CToT( cgiGet( "Z679ProfesionalesDeclaroDatosV"), 0);
               n679ProfesionalesDeclaroDatosV = ((DateTime.MinValue==A679ProfesionalesDeclaroDatosV) ? true : false);
               Z680ProfesionalesCuentaBancaria = cgiGet( "Z680ProfesionalesCuentaBancaria");
               n680ProfesionalesCuentaBancaria = (String.IsNullOrEmpty(StringUtil.RTrim( A680ProfesionalesCuentaBancaria)) ? true : false);
               Z800ProfesionalesCapacidadProducti = context.localUtil.CToN( cgiGet( "Z800ProfesionalesCapacidadProducti"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z617ProfesionalesLimitOSF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z617ProfesionalesLimitOSF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n617ProfesionalesLimitOSF = ((0==A617ProfesionalesLimitOSF) ? true : false);
               Z268ProfesionalesFeedBackCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z268ProfesionalesFeedBackCant"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z269ProfesionalesFeedBackProm = context.localUtil.CToN( cgiGet( "Z269ProfesionalesFeedBackProm"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Z107EstadosTipo = cgiGet( "Z107EstadosTipo");
               Z108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z108EstadosGenericosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z673BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z673BancoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n673BancoId = ((0==A673BancoId) ? true : false);
               A900ProfesionalesFechaNacimiento = context.localUtil.CToD( cgiGet( "Z900ProfesionalesFechaNacimiento"), 0);
               n900ProfesionalesFechaNacimiento = false;
               n900ProfesionalesFechaNacimiento = ((DateTime.MinValue==A900ProfesionalesFechaNacimiento) ? true : false);
               A901ProfesionalesRUT = cgiGet( "Z901ProfesionalesRUT");
               n901ProfesionalesRUT = false;
               n901ProfesionalesRUT = (String.IsNullOrEmpty(StringUtil.RTrim( A901ProfesionalesRUT)) ? true : false);
               A902ProfesionalesTipoEmpresa = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z902ProfesionalesTipoEmpresa"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n902ProfesionalesTipoEmpresa = false;
               n902ProfesionalesTipoEmpresa = ((0==A902ProfesionalesTipoEmpresa) ? true : false);
               A196ProfesionalesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z196ProfesionalesAutoEnumerar"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z197ProfesionalesAutoEnuZona"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O197ProfesionalesAutoEnuZona"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_122 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_122"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_157 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_157"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               nRC_GXsfl_143 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_143"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N673BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N673BancoId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n673BancoId = ((0==A673BancoId) ? true : false);
               N107EstadosTipo = cgiGet( "N107EstadosTipo");
               N108EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N108EstadosGenericosId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A886ProfesionalesNombreCompleto = cgiGet( "PROFESIONALESNOMBRECOMPLETO");
               A803ProfesionalesTiempoDisponible = context.localUtil.CToN( cgiGet( "PROFESIONALESTIEMPODISPONIBLE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               A270ProfesionalesFeedback = context.localUtil.CToN( cgiGet( "PROFESIONALESFEEDBACK"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AV7ProfesionalesId = cgiGet( "vPROFESIONALESID");
               AV32Insert_BancoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_BANCOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV32Insert_BancoId", StringUtil.LTrimStr( (decimal)(AV32Insert_BancoId), 18, 0));
               AV11Insert_EstadosTipo = cgiGet( "vINSERT_ESTADOSTIPO");
               AssignAttri("", false, "AV11Insert_EstadosTipo", AV11Insert_EstadosTipo);
               AV12Insert_EstadosGenericosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ESTADOSGENERICOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_EstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV12Insert_EstadosGenericosId), 5, 0));
               AV14ProfesionalesFeedback = context.localUtil.CToN( cgiGet( "vPROFESIONALESFEEDBACK"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A900ProfesionalesFechaNacimiento = context.localUtil.CToD( cgiGet( "PROFESIONALESFECHANACIMIENTO"), 0);
               n900ProfesionalesFechaNacimiento = ((DateTime.MinValue==A900ProfesionalesFechaNacimiento) ? true : false);
               A901ProfesionalesRUT = cgiGet( "PROFESIONALESRUT");
               n901ProfesionalesRUT = (String.IsNullOrEmpty(StringUtil.RTrim( A901ProfesionalesRUT)) ? true : false);
               A902ProfesionalesTipoEmpresa = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESTIPOEMPRESA"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               n902ProfesionalesTipoEmpresa = ((0==A902ProfesionalesTipoEmpresa) ? true : false);
               A40000ProfesionalesPhoto_GXI = cgiGet( "PROFESIONALESPHOTO_GXI");
               A196ProfesionalesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAUTOENUMERAR"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A197ProfesionalesAutoEnuZona = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESAUTOENUZONA"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               A674BancoNombre = cgiGet( "BANCONOMBRE");
               AV34Pgmname = cgiGet( "vPGMNAME");
               A122RubrosNombre = cgiGet( "RUBROSNOMBRE");
               A40001RubrosImagen_GXI = cgiGet( "RUBROSIMAGEN_GXI");
               A221EstadosProfRubNomb = cgiGet( "ESTADOSPROFRUBNOMB");
               A113DepartamentoDepartamento = cgiGet( "DEPARTAMENTODEPARTAMENTO");
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
               Gxuitabspanel_tabs_Objectcall = cgiGet( "GXUITABSPANEL_TABS_Objectcall");
               Gxuitabspanel_tabs_Enabled = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Enabled"));
               Gxuitabspanel_tabs_Activepage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Activepage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Activepagecontrolname = cgiGet( "GXUITABSPANEL_TABS_Activepagecontrolname");
               Gxuitabspanel_tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
               Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
               Gxuitabspanel_tabs_Visible = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Visible"));
               /* Read variables values. */
               A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
               AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
               dynEstadosGenericosId.Name = dynEstadosGenericosId_Internalname;
               dynEstadosGenericosId.CurrentValue = cgiGet( dynEstadosGenericosId_Internalname);
               A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynEstadosGenericosId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
               A676ProfesionalesEsRUT = StringUtil.StrToBool( cgiGet( chkProfesionalesEsRUT_Internalname));
               n676ProfesionalesEsRUT = false;
               AssignAttri("", false, "A676ProfesionalesEsRUT", A676ProfesionalesEsRUT);
               n676ProfesionalesEsRUT = ((false==A676ProfesionalesEsRUT) ? true : false);
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROFESIONALESFEEDBACKCANT");
                  AnyError = 1;
                  GX_FocusControl = edtProfesionalesFeedBackCant_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A268ProfesionalesFeedBackCant = 0;
                  AssignAttri("", false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
               }
               else
               {
                  A268ProfesionalesFeedBackCant = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackCant_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
               }
               A170ProfesionalesTelefono = cgiGet( edtProfesionalesTelefono_Internalname);
               AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
               A193ProfesionalesEmail = cgiGet( edtProfesionalesEmail_Internalname);
               n193ProfesionalesEmail = false;
               AssignAttri("", false, "A193ProfesionalesEmail", A193ProfesionalesEmail);
               n193ProfesionalesEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A193ProfesionalesEmail)) ? true : false);
               A198ProfesionalesDireccion = cgiGet( edtProfesionalesDireccion_Internalname);
               AssignAttri("", false, "A198ProfesionalesDireccion", A198ProfesionalesDireccion);
               cmbProfesionalesVerDatPerSol.Name = cmbProfesionalesVerDatPerSol_Internalname;
               cmbProfesionalesVerDatPerSol.CurrentValue = cgiGet( cmbProfesionalesVerDatPerSol_Internalname);
               A267ProfesionalesVerDatPerSol = cgiGet( cmbProfesionalesVerDatPerSol_Internalname);
               AssignAttri("", false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProfesionalesLimitOSF_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProfesionalesLimitOSF_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROFESIONALESLIMITOSF");
                  AnyError = 1;
                  GX_FocusControl = edtProfesionalesLimitOSF_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A617ProfesionalesLimitOSF = 0;
                  n617ProfesionalesLimitOSF = false;
                  AssignAttri("", false, "A617ProfesionalesLimitOSF", StringUtil.LTrimStr( (decimal)(A617ProfesionalesLimitOSF), 4, 0));
               }
               else
               {
                  A617ProfesionalesLimitOSF = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesLimitOSF_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  n617ProfesionalesLimitOSF = false;
                  AssignAttri("", false, "A617ProfesionalesLimitOSF", StringUtil.LTrimStr( (decimal)(A617ProfesionalesLimitOSF), 4, 0));
               }
               n617ProfesionalesLimitOSF = ((0==A617ProfesionalesLimitOSF) ? true : false);
               A678ProfesionalesAceptoTerminos = context.localUtil.CToT( cgiGet( edtProfesionalesAceptoTerminos_Internalname));
               n678ProfesionalesAceptoTerminos = false;
               AssignAttri("", false, "A678ProfesionalesAceptoTerminos", context.localUtil.TToC( A678ProfesionalesAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A679ProfesionalesDeclaroDatosV = context.localUtil.CToT( cgiGet( edtProfesionalesDeclaroDatosV_Internalname));
               n679ProfesionalesDeclaroDatosV = false;
               AssignAttri("", false, "A679ProfesionalesDeclaroDatosV", context.localUtil.TToC( A679ProfesionalesDeclaroDatosV, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               dynBancoId.Name = dynBancoId_Internalname;
               dynBancoId.CurrentValue = cgiGet( dynBancoId_Internalname);
               A673BancoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynBancoId_Internalname), "."), 18, MidpointRounding.ToEven));
               n673BancoId = false;
               AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
               n673BancoId = ((0==A673BancoId) ? true : false);
               A680ProfesionalesCuentaBancaria = cgiGet( edtProfesionalesCuentaBancaria_Internalname);
               n680ProfesionalesCuentaBancaria = false;
               AssignAttri("", false, "A680ProfesionalesCuentaBancaria", A680ProfesionalesCuentaBancaria);
               n680ProfesionalesCuentaBancaria = (String.IsNullOrEmpty(StringUtil.RTrim( A680ProfesionalesCuentaBancaria)) ? true : false);
               A677ProfesionalesExperiencia = cgiGet( edtProfesionalesExperiencia_Internalname);
               n677ProfesionalesExperiencia = false;
               AssignAttri("", false, "A677ProfesionalesExperiencia", A677ProfesionalesExperiencia);
               n677ProfesionalesExperiencia = (String.IsNullOrEmpty(StringUtil.RTrim( A677ProfesionalesExperiencia)) ? true : false);
               A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
               AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProfesionalesCapacidadProducti_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProfesionalesCapacidadProducti_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 9999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROFESIONALESCAPACIDADPRODUCTI");
                  AnyError = 1;
                  GX_FocusControl = edtProfesionalesCapacidadProducti_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A800ProfesionalesCapacidadProducti = 0;
                  AssignAttri("", false, "A800ProfesionalesCapacidadProducti", StringUtil.LTrimStr( A800ProfesionalesCapacidadProducti, 10, 2));
               }
               else
               {
                  A800ProfesionalesCapacidadProducti = context.localUtil.CToN( cgiGet( edtProfesionalesCapacidadProducti_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A800ProfesionalesCapacidadProducti", StringUtil.LTrimStr( A800ProfesionalesCapacidadProducti, 10, 2));
               }
               A436ProfesionalesPerAltShop = cgiGet( edtProfesionalesPerAltShop_Internalname);
               n436ProfesionalesPerAltShop = false;
               AssignAttri("", false, "A436ProfesionalesPerAltShop", A436ProfesionalesPerAltShop);
               n436ProfesionalesPerAltShop = (String.IsNullOrEmpty(StringUtil.RTrim( A436ProfesionalesPerAltShop)) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtProfesionalesFechaAlta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha de Alta", "")}), 1, "PROFESIONALESFECHAALTA");
                  AnyError = 1;
                  GX_FocusControl = edtProfesionalesFechaAlta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A199ProfesionalesFechaAlta = context.localUtil.CToT( cgiGet( edtProfesionalesFechaAlta_Internalname));
                  AssignAttri("", false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtProfesionalesFechaActualizado_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha Actualizado", "")}), 1, "PROFESIONALESFECHAACTUALIZADO");
                  AnyError = 1;
                  GX_FocusControl = edtProfesionalesFechaActualizado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               else
               {
                  A200ProfesionalesFechaActualizado = context.localUtil.CToT( cgiGet( edtProfesionalesFechaActualizado_Internalname));
                  AssignAttri("", false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackProm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackProm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROFESIONALESFEEDBACKPROM");
                  AnyError = 1;
                  GX_FocusControl = edtProfesionalesFeedBackProm_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A269ProfesionalesFeedBackProm = 0;
                  AssignAttri("", false, "A269ProfesionalesFeedBackProm", StringUtil.LTrimStr( A269ProfesionalesFeedBackProm, 18, 2));
               }
               else
               {
                  A269ProfesionalesFeedBackProm = context.localUtil.CToN( cgiGet( edtProfesionalesFeedBackProm_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                  AssignAttri("", false, "A269ProfesionalesFeedBackProm", StringUtil.LTrimStr( A269ProfesionalesFeedBackProm, 18, 2));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProfesionalesPhoto_Internalname, ref  A169ProfesionalesPhoto, ref  A40000ProfesionalesPhoto_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Profesionales");
               A678ProfesionalesAceptoTerminos = context.localUtil.CToT( cgiGet( edtProfesionalesAceptoTerminos_Internalname));
               n678ProfesionalesAceptoTerminos = false;
               AssignAttri("", false, "A678ProfesionalesAceptoTerminos", context.localUtil.TToC( A678ProfesionalesAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               forbiddenHiddens.Add("ProfesionalesAceptoTerminos", context.localUtil.Format( A678ProfesionalesAceptoTerminos, "99/99/99 99:99"));
               A679ProfesionalesDeclaroDatosV = context.localUtil.CToT( cgiGet( edtProfesionalesDeclaroDatosV_Internalname));
               n679ProfesionalesDeclaroDatosV = false;
               AssignAttri("", false, "A679ProfesionalesDeclaroDatosV", context.localUtil.TToC( A679ProfesionalesDeclaroDatosV, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               forbiddenHiddens.Add("ProfesionalesDeclaroDatosV", context.localUtil.Format( A679ProfesionalesDeclaroDatosV, "99/99/99 99:99"));
               forbiddenHiddens.Add("Insert_BancoId", context.localUtil.Format( (decimal)(AV32Insert_BancoId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_EstadosTipo", StringUtil.RTrim( context.localUtil.Format( AV11Insert_EstadosTipo, "")));
               forbiddenHiddens.Add("Insert_EstadosGenericosId", context.localUtil.Format( (decimal)(AV12Insert_EstadosGenericosId), "ZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ProfesionalesFechaNacimiento", context.localUtil.Format(A900ProfesionalesFechaNacimiento, "99/99/99"));
               forbiddenHiddens.Add("ProfesionalesRUT", StringUtil.RTrim( context.localUtil.Format( A901ProfesionalesRUT, "")));
               forbiddenHiddens.Add("ProfesionalesTipoEmpresa", context.localUtil.Format( (decimal)(A902ProfesionalesTipoEmpresa), "ZZZ9"));
               forbiddenHiddens.Add("ProfesionalesAutoEnumerar", context.localUtil.Format( (decimal)(A196ProfesionalesAutoEnumerar), "ZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("profesionales:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               /* Check if conditions changed and reset current page numbers */
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
                           CONFIRM_0S0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
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
                           E110S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120S2 ();
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
            E120S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0S34( ) ;
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
            DisableAttributes0S34( ) ;
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

      protected void CONFIRM_0S0( )
      {
         BeforeValidate0S34( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0S34( ) ;
            }
            else
            {
               CheckExtendedTable0S34( ) ;
               CloseExtendedTableCursors0S34( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode34 = Gx_mode;
            CONFIRM_0S35( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0S36( ) ;
               if ( AnyError == 0 )
               {
                  CONFIRM_0S145( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Restore parent mode. */
                     Gx_mode = sMode34;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     IsConfirmed = 1;
                     AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                  }
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0S145( )
      {
         nGXsfl_143_idx = 0;
         while ( nGXsfl_143_idx < nRC_GXsfl_143 )
         {
            ReadRow0S145( ) ;
            if ( ( nRcdExists_145 != 0 ) || ( nIsMod_145 != 0 ) )
            {
               GetKey0S145( ) ;
               if ( ( nRcdExists_145 == 0 ) && ( nRcdDeleted_145 == 0 ) )
               {
                  if ( RcdFound145 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0S145( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0S145( ) ;
                        CloseExtendedTableCursors0S145( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PROFESIONALSERVICIOID_" + sGXsfl_143_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProfesionalServicioId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound145 != 0 )
                  {
                     if ( nRcdDeleted_145 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0S145( ) ;
                        Load0S145( ) ;
                        BeforeValidate0S145( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0S145( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_145 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0S145( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0S145( ) ;
                              CloseExtendedTableCursors0S145( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_145 == 0 )
                     {
                        GXCCtl = "PROFESIONALSERVICIOID_" + sGXsfl_143_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProfesionalServicioId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProfesionalServicioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A993ProfesionalServicioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProfesionalServicioNombre_Internalname, StringUtil.RTrim( A994ProfesionalServicioNombre)) ;
            ChangePostValue( cmbEstadoServProf_Internalname, StringUtil.RTrim( A995EstadoServProf)) ;
            ChangePostValue( "ZT_"+"Z993ProfesionalServicioId_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z993ProfesionalServicioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z995EstadoServProf_"+sGXsfl_143_idx, StringUtil.RTrim( Z995EstadoServProf)) ;
            ChangePostValue( "nRcdDeleted_145_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_145), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_145_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_145), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_145_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_145), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_145 != 0 )
            {
               ChangePostValue( "PROFESIONALSERVICIOID_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalServicioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALSERVICIONOMBRE_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalServicioNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSERVPROF_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbEstadoServProf.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0S36( )
      {
         s197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
         AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         nGXsfl_157_idx = 0;
         while ( nGXsfl_157_idx < nRC_GXsfl_157 )
         {
            ReadRow0S36( ) ;
            if ( ( nRcdExists_36 != 0 ) || ( nIsMod_36 != 0 ) )
            {
               GetKey0S36( ) ;
               if ( ( nRcdExists_36 == 0 ) && ( nRcdDeleted_36 == 0 ) )
               {
                  if ( RcdFound36 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0S36( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0S36( ) ;
                        CloseExtendedTableCursors0S36( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
                        AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PROFESIONALESID");
                     AnyError = 1;
                     GX_FocusControl = edtProfesionalesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound36 != 0 )
                  {
                     if ( nRcdDeleted_36 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0S36( ) ;
                        Load0S36( ) ;
                        BeforeValidate0S36( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0S36( ) ;
                           O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
                           AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_36 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0S36( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0S36( ) ;
                              CloseExtendedTableCursors0S36( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
                              AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_36 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROFESIONALESID");
                        AnyError = 1;
                        GX_FocusControl = edtProfesionalesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProfesionalesZonasCorrelativo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A126ProfesionalesZonasCorrelativo), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtPaisID_Internalname, StringUtil.RTrim( A116PaisID)) ;
            ChangePostValue( dynDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", ""))) ;
            ChangePostValue( dynDepartamentoMunicipioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", ""))) ;
            ChangePostValue( dynZonasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z126ProfesionalesZonasCorrelativo_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126ProfesionalesZonasCorrelativo), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z112DepartamentoId_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z114DepartamentoMunicipioId_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z110ZonasID_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_36_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_36), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_36_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_36), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_36_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_36), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_36 != 0 )
            {
               ChangePostValue( "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAISID_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaisID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOID_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynDepartamentoId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ZONASID_"+sGXsfl_157_idx+"Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynZonasID.Visible), 5, 0, ".", ""))) ;
               ChangePostValue( "ZONASID_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynZonasID.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O197ProfesionalesAutoEnuZona = s197ProfesionalesAutoEnuZona;
         AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0S35( )
      {
         nGXsfl_122_idx = 0;
         while ( nGXsfl_122_idx < nRC_GXsfl_122 )
         {
            ReadRow0S35( ) ;
            if ( ( nRcdExists_35 != 0 ) || ( nIsMod_35 != 0 ) )
            {
               GetKey0S35( ) ;
               if ( ( nRcdExists_35 == 0 ) && ( nRcdDeleted_35 == 0 ) )
               {
                  if ( RcdFound35 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0S35( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0S35( ) ;
                        CloseExtendedTableCursors0S35( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "RUBROSID_" + sGXsfl_122_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = dynRubrosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound35 != 0 )
                  {
                     if ( nRcdDeleted_35 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0S35( ) ;
                        Load0S35( ) ;
                        BeforeValidate0S35( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0S35( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_35 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0S35( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0S35( ) ;
                              CloseExtendedTableCursors0S35( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_35 == 0 )
                     {
                        GXCCtl = "RUBROSID_" + sGXsfl_122_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = dynRubrosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( dynRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))) ;
            ChangePostValue( edtRubrosImagen_Internalname, A168RubrosImagen) ;
            ChangePostValue( edtEstadosProfRubTipo_Internalname, StringUtil.RTrim( A124EstadosProfRubTipo)) ;
            ChangePostValue( cmbEstadosProfRubId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A125EstadosProfRubId), 5, 0, ".", ""))) ;
            ChangePostValue( cmbRubrosEstado_Internalname, StringUtil.RTrim( A123RubrosEstado)) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_122_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z124EstadosProfRubTipo_"+sGXsfl_122_idx, StringUtil.RTrim( Z124EstadosProfRubTipo)) ;
            ChangePostValue( "ZT_"+"Z125EstadosProfRubId_"+sGXsfl_122_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125EstadosProfRubId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_35_"+sGXsfl_122_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_35), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_35_"+sGXsfl_122_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_35), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_35_"+sGXsfl_122_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_35), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_35 != 0 )
            {
               ChangePostValue( "RUBROSID_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynRubrosId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSIMAGEN_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSPROFRUBTIPO_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosProfRubTipo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSPROFRUBID_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbEstadosProfRubId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSESTADO_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbRubrosEstado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0S0( )
      {
      }

      protected void E110S2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV15WWPContext) ;
         AV8IsAuthorized = true;
         AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Insert", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Update", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales_Delete", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            AssignAttri("", false, "AV8IsAuthorized", AV8IsAuthorized);
         }
         if ( ! AV8IsAuthorized )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV34Pgmname));
            CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV34Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV35GXV1 = 1;
            AssignAttri("", false, "AV35GXV1", StringUtil.LTrimStr( (decimal)(AV35GXV1), 8, 0));
            while ( AV35GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV35GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "BancoId") == 0 )
               {
                  AV32Insert_BancoId = (long)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV32Insert_BancoId", StringUtil.LTrimStr( (decimal)(AV32Insert_BancoId), 18, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "EstadosTipo") == 0 )
               {
                  AV11Insert_EstadosTipo = AV13TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV11Insert_EstadosTipo", AV11Insert_EstadosTipo);
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "EstadosGenericosId") == 0 )
               {
                  AV12Insert_EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_EstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV12Insert_EstadosGenericosId), 5, 0));
               }
               AV35GXV1 = (int)(AV35GXV1+1);
               AssignAttri("", false, "AV35GXV1", StringUtil.LTrimStr( (decimal)(AV35GXV1), 8, 0));
            }
         }
         edtEstadosTipo_Visible = 0;
         AssignProp("", false, edtEstadosTipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Visible), 5, 0), true);
         edtProfesionalesCapacidadProducti_Visible = 0;
         AssignProp("", false, edtProfesionalesCapacidadProducti_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesCapacidadProducti_Visible), 5, 0), true);
         edtProfesionalesPerAltShop_Visible = 0;
         AssignProp("", false, edtProfesionalesPerAltShop_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesPerAltShop_Visible), 5, 0), true);
         edtProfesionalesFechaAlta_Visible = 0;
         AssignProp("", false, edtProfesionalesFechaAlta_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesFechaAlta_Visible), 5, 0), true);
         edtProfesionalesFechaActualizado_Visible = 0;
         AssignProp("", false, edtProfesionalesFechaActualizado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesFechaActualizado_Visible), 5, 0), true);
         edtProfesionalesFeedBackProm_Visible = 0;
         AssignProp("", false, edtProfesionalesFeedBackProm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProfesionalesFeedBackProm_Visible), 5, 0), true);
      }

      protected void E120S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("profesionalesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0S34( short GX_JID )
      {
         if ( ( GX_JID == 44 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z199ProfesionalesFechaAlta = T000S15_A199ProfesionalesFechaAlta[0];
               Z200ProfesionalesFechaActualizado = T000S15_A200ProfesionalesFechaActualizado[0];
               Z900ProfesionalesFechaNacimiento = T000S15_A900ProfesionalesFechaNacimiento[0];
               Z901ProfesionalesRUT = T000S15_A901ProfesionalesRUT[0];
               Z902ProfesionalesTipoEmpresa = T000S15_A902ProfesionalesTipoEmpresa[0];
               Z676ProfesionalesEsRUT = T000S15_A676ProfesionalesEsRUT[0];
               Z166ProfesionalesPrimerNombre = T000S15_A166ProfesionalesPrimerNombre[0];
               Z191ProfesionalesSegundoNombre = T000S15_A191ProfesionalesSegundoNombre[0];
               Z167ProfesionalesApellidoPrimero = T000S15_A167ProfesionalesApellidoPrimero[0];
               Z192ProfesionalesApellidoSegundo = T000S15_A192ProfesionalesApellidoSegundo[0];
               Z170ProfesionalesTelefono = T000S15_A170ProfesionalesTelefono[0];
               Z193ProfesionalesEmail = T000S15_A193ProfesionalesEmail[0];
               Z198ProfesionalesDireccion = T000S15_A198ProfesionalesDireccion[0];
               Z267ProfesionalesVerDatPerSol = T000S15_A267ProfesionalesVerDatPerSol[0];
               Z436ProfesionalesPerAltShop = T000S15_A436ProfesionalesPerAltShop[0];
               Z196ProfesionalesAutoEnumerar = T000S15_A196ProfesionalesAutoEnumerar[0];
               Z197ProfesionalesAutoEnuZona = T000S15_A197ProfesionalesAutoEnuZona[0];
               Z677ProfesionalesExperiencia = T000S15_A677ProfesionalesExperiencia[0];
               Z678ProfesionalesAceptoTerminos = T000S15_A678ProfesionalesAceptoTerminos[0];
               Z679ProfesionalesDeclaroDatosV = T000S15_A679ProfesionalesDeclaroDatosV[0];
               Z680ProfesionalesCuentaBancaria = T000S15_A680ProfesionalesCuentaBancaria[0];
               Z800ProfesionalesCapacidadProducti = T000S15_A800ProfesionalesCapacidadProducti[0];
               Z617ProfesionalesLimitOSF = T000S15_A617ProfesionalesLimitOSF[0];
               Z268ProfesionalesFeedBackCant = T000S15_A268ProfesionalesFeedBackCant[0];
               Z269ProfesionalesFeedBackProm = T000S15_A269ProfesionalesFeedBackProm[0];
               Z107EstadosTipo = T000S15_A107EstadosTipo[0];
               Z108EstadosGenericosId = T000S15_A108EstadosGenericosId[0];
               Z673BancoId = T000S15_A673BancoId[0];
            }
            else
            {
               Z199ProfesionalesFechaAlta = A199ProfesionalesFechaAlta;
               Z200ProfesionalesFechaActualizado = A200ProfesionalesFechaActualizado;
               Z900ProfesionalesFechaNacimiento = A900ProfesionalesFechaNacimiento;
               Z901ProfesionalesRUT = A901ProfesionalesRUT;
               Z902ProfesionalesTipoEmpresa = A902ProfesionalesTipoEmpresa;
               Z676ProfesionalesEsRUT = A676ProfesionalesEsRUT;
               Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
               Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
               Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
               Z192ProfesionalesApellidoSegundo = A192ProfesionalesApellidoSegundo;
               Z170ProfesionalesTelefono = A170ProfesionalesTelefono;
               Z193ProfesionalesEmail = A193ProfesionalesEmail;
               Z198ProfesionalesDireccion = A198ProfesionalesDireccion;
               Z267ProfesionalesVerDatPerSol = A267ProfesionalesVerDatPerSol;
               Z436ProfesionalesPerAltShop = A436ProfesionalesPerAltShop;
               Z196ProfesionalesAutoEnumerar = A196ProfesionalesAutoEnumerar;
               Z197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
               Z677ProfesionalesExperiencia = A677ProfesionalesExperiencia;
               Z678ProfesionalesAceptoTerminos = A678ProfesionalesAceptoTerminos;
               Z679ProfesionalesDeclaroDatosV = A679ProfesionalesDeclaroDatosV;
               Z680ProfesionalesCuentaBancaria = A680ProfesionalesCuentaBancaria;
               Z800ProfesionalesCapacidadProducti = A800ProfesionalesCapacidadProducti;
               Z617ProfesionalesLimitOSF = A617ProfesionalesLimitOSF;
               Z268ProfesionalesFeedBackCant = A268ProfesionalesFeedBackCant;
               Z269ProfesionalesFeedBackProm = A269ProfesionalesFeedBackProm;
               Z107EstadosTipo = A107EstadosTipo;
               Z108EstadosGenericosId = A108EstadosGenericosId;
               Z673BancoId = A673BancoId;
            }
         }
         if ( GX_JID == -44 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
            Z199ProfesionalesFechaAlta = A199ProfesionalesFechaAlta;
            Z200ProfesionalesFechaActualizado = A200ProfesionalesFechaActualizado;
            Z900ProfesionalesFechaNacimiento = A900ProfesionalesFechaNacimiento;
            Z901ProfesionalesRUT = A901ProfesionalesRUT;
            Z902ProfesionalesTipoEmpresa = A902ProfesionalesTipoEmpresa;
            Z676ProfesionalesEsRUT = A676ProfesionalesEsRUT;
            Z166ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            Z191ProfesionalesSegundoNombre = A191ProfesionalesSegundoNombre;
            Z167ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            Z192ProfesionalesApellidoSegundo = A192ProfesionalesApellidoSegundo;
            Z169ProfesionalesPhoto = A169ProfesionalesPhoto;
            Z40000ProfesionalesPhoto_GXI = A40000ProfesionalesPhoto_GXI;
            Z170ProfesionalesTelefono = A170ProfesionalesTelefono;
            Z193ProfesionalesEmail = A193ProfesionalesEmail;
            Z198ProfesionalesDireccion = A198ProfesionalesDireccion;
            Z267ProfesionalesVerDatPerSol = A267ProfesionalesVerDatPerSol;
            Z436ProfesionalesPerAltShop = A436ProfesionalesPerAltShop;
            Z196ProfesionalesAutoEnumerar = A196ProfesionalesAutoEnumerar;
            Z197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            Z677ProfesionalesExperiencia = A677ProfesionalesExperiencia;
            Z678ProfesionalesAceptoTerminos = A678ProfesionalesAceptoTerminos;
            Z679ProfesionalesDeclaroDatosV = A679ProfesionalesDeclaroDatosV;
            Z680ProfesionalesCuentaBancaria = A680ProfesionalesCuentaBancaria;
            Z800ProfesionalesCapacidadProducti = A800ProfesionalesCapacidadProducti;
            Z617ProfesionalesLimitOSF = A617ProfesionalesLimitOSF;
            Z268ProfesionalesFeedBackCant = A268ProfesionalesFeedBackCant;
            Z269ProfesionalesFeedBackProm = A269ProfesionalesFeedBackProm;
            Z107EstadosTipo = A107EstadosTipo;
            Z108EstadosGenericosId = A108EstadosGenericosId;
            Z673BancoId = A673BancoId;
            Z674BancoNombre = A674BancoNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         GXABANCOID_html0S34( ) ;
         edtProfesionalesAceptoTerminos_Enabled = 0;
         AssignProp("", false, edtProfesionalesAceptoTerminos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesAceptoTerminos_Enabled), 5, 0), true);
         edtProfesionalesDeclaroDatosV_Enabled = 0;
         AssignProp("", false, edtProfesionalesDeclaroDatosV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesDeclaroDatosV_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtProfesionalesAceptoTerminos_Enabled = 0;
         AssignProp("", false, edtProfesionalesAceptoTerminos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesAceptoTerminos_Enabled), 5, 0), true);
         edtProfesionalesDeclaroDatosV_Enabled = 0;
         AssignProp("", false, edtProfesionalesDeclaroDatosV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesDeclaroDatosV_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ProfesionalesId)) )
         {
            A120ProfesionalesId = AV7ProfesionalesId;
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ProfesionalesId)) )
         {
            edtProfesionalesId_Enabled = 0;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         }
         else
         {
            edtProfesionalesId_Enabled = 1;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ProfesionalesId)) )
         {
            edtProfesionalesId_Enabled = 0;
            AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV32Insert_BancoId) )
         {
            dynBancoId.Enabled = 0;
            AssignProp("", false, dynBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBancoId.Enabled), 5, 0), true);
         }
         else
         {
            dynBancoId.Enabled = 1;
            AssignProp("", false, dynBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBancoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_EstadosTipo)) )
         {
            edtEstadosTipo_Enabled = 0;
            AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         }
         else
         {
            edtEstadosTipo_Enabled = 1;
            AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_EstadosGenericosId) )
         {
            dynEstadosGenericosId.Enabled = 0;
            AssignProp("", false, dynEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosGenericosId.Enabled), 5, 0), true);
         }
         else
         {
            dynEstadosGenericosId.Enabled = 1;
            AssignProp("", false, dynEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosGenericosId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_EstadosGenericosId) )
         {
            A108EstadosGenericosId = AV12Insert_EstadosGenericosId;
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         }
         else
         {
            if ( IsIns( )  )
            {
               A108EstadosGenericosId = 3;
               AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Insert_EstadosTipo)) )
         {
            A107EstadosTipo = AV11Insert_EstadosTipo;
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         }
         else
         {
            A107EstadosTipo = context.GetMessage( context.GetMessage( "STS", ""), "");
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV32Insert_BancoId) )
         {
            A673BancoId = AV32Insert_BancoId;
            n673BancoId = false;
            AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A267ProfesionalesVerDatPerSol)) && ( Gx_BScreen == 0 ) )
         {
            A267ProfesionalesVerDatPerSol = context.GetMessage( context.GetMessage( "N", ""), "");
            AssignAttri("", false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A436ProfesionalesPerAltShop)) && ( Gx_BScreen == 0 ) )
         {
            A436ProfesionalesPerAltShop = context.GetMessage( context.GetMessage( "N", ""), "");
            n436ProfesionalesPerAltShop = false;
            AssignAttri("", false, "A436ProfesionalesPerAltShop", A436ProfesionalesPerAltShop);
         }
         if ( IsIns( )  && (Convert.ToDecimal(0)==A800ProfesionalesCapacidadProducti) && ( Gx_BScreen == 0 ) )
         {
            A800ProfesionalesCapacidadProducti = (decimal)(8);
            AssignAttri("", false, "A800ProfesionalesCapacidadProducti", StringUtil.LTrimStr( A800ProfesionalesCapacidadProducti, 10, 2));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000S17 */
            pr_default.execute(15, new Object[] {n673BancoId, A673BancoId});
            A674BancoNombre = T000S17_A674BancoNombre[0];
            pr_default.close(15);
            AV34Pgmname = "Profesionales";
            AssignAttri("", false, "AV34Pgmname", AV34Pgmname);
            GXAESTADOSGENERICOSID_html0S34( A107EstadosTipo) ;
            A803ProfesionalesTiempoDisponible = A800ProfesionalesCapacidadProducti;
            AssignAttri("", false, "A803ProfesionalesTiempoDisponible", StringUtil.LTrimStr( A803ProfesionalesTiempoDisponible, 10, 2));
         }
      }

      protected void Load0S34( )
      {
         /* Using cursor T000S18 */
         pr_default.execute(16, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound34 = 1;
            A199ProfesionalesFechaAlta = T000S18_A199ProfesionalesFechaAlta[0];
            AssignAttri("", false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A200ProfesionalesFechaActualizado = T000S18_A200ProfesionalesFechaActualizado[0];
            AssignAttri("", false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A900ProfesionalesFechaNacimiento = T000S18_A900ProfesionalesFechaNacimiento[0];
            n900ProfesionalesFechaNacimiento = T000S18_n900ProfesionalesFechaNacimiento[0];
            A901ProfesionalesRUT = T000S18_A901ProfesionalesRUT[0];
            n901ProfesionalesRUT = T000S18_n901ProfesionalesRUT[0];
            A902ProfesionalesTipoEmpresa = T000S18_A902ProfesionalesTipoEmpresa[0];
            n902ProfesionalesTipoEmpresa = T000S18_n902ProfesionalesTipoEmpresa[0];
            A676ProfesionalesEsRUT = T000S18_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = T000S18_n676ProfesionalesEsRUT[0];
            AssignAttri("", false, "A676ProfesionalesEsRUT", A676ProfesionalesEsRUT);
            A166ProfesionalesPrimerNombre = T000S18_A166ProfesionalesPrimerNombre[0];
            AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A191ProfesionalesSegundoNombre = T000S18_A191ProfesionalesSegundoNombre[0];
            AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
            A167ProfesionalesApellidoPrimero = T000S18_A167ProfesionalesApellidoPrimero[0];
            AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            A192ProfesionalesApellidoSegundo = T000S18_A192ProfesionalesApellidoSegundo[0];
            AssignAttri("", false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
            A40000ProfesionalesPhoto_GXI = T000S18_A40000ProfesionalesPhoto_GXI[0];
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A170ProfesionalesTelefono = T000S18_A170ProfesionalesTelefono[0];
            AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
            A193ProfesionalesEmail = T000S18_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = T000S18_n193ProfesionalesEmail[0];
            AssignAttri("", false, "A193ProfesionalesEmail", A193ProfesionalesEmail);
            A198ProfesionalesDireccion = T000S18_A198ProfesionalesDireccion[0];
            AssignAttri("", false, "A198ProfesionalesDireccion", A198ProfesionalesDireccion);
            A267ProfesionalesVerDatPerSol = T000S18_A267ProfesionalesVerDatPerSol[0];
            AssignAttri("", false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
            A436ProfesionalesPerAltShop = T000S18_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = T000S18_n436ProfesionalesPerAltShop[0];
            AssignAttri("", false, "A436ProfesionalesPerAltShop", A436ProfesionalesPerAltShop);
            A196ProfesionalesAutoEnumerar = T000S18_A196ProfesionalesAutoEnumerar[0];
            A197ProfesionalesAutoEnuZona = T000S18_A197ProfesionalesAutoEnuZona[0];
            A677ProfesionalesExperiencia = T000S18_A677ProfesionalesExperiencia[0];
            n677ProfesionalesExperiencia = T000S18_n677ProfesionalesExperiencia[0];
            AssignAttri("", false, "A677ProfesionalesExperiencia", A677ProfesionalesExperiencia);
            A678ProfesionalesAceptoTerminos = T000S18_A678ProfesionalesAceptoTerminos[0];
            n678ProfesionalesAceptoTerminos = T000S18_n678ProfesionalesAceptoTerminos[0];
            AssignAttri("", false, "A678ProfesionalesAceptoTerminos", context.localUtil.TToC( A678ProfesionalesAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A679ProfesionalesDeclaroDatosV = T000S18_A679ProfesionalesDeclaroDatosV[0];
            n679ProfesionalesDeclaroDatosV = T000S18_n679ProfesionalesDeclaroDatosV[0];
            AssignAttri("", false, "A679ProfesionalesDeclaroDatosV", context.localUtil.TToC( A679ProfesionalesDeclaroDatosV, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A680ProfesionalesCuentaBancaria = T000S18_A680ProfesionalesCuentaBancaria[0];
            n680ProfesionalesCuentaBancaria = T000S18_n680ProfesionalesCuentaBancaria[0];
            AssignAttri("", false, "A680ProfesionalesCuentaBancaria", A680ProfesionalesCuentaBancaria);
            A800ProfesionalesCapacidadProducti = T000S18_A800ProfesionalesCapacidadProducti[0];
            AssignAttri("", false, "A800ProfesionalesCapacidadProducti", StringUtil.LTrimStr( A800ProfesionalesCapacidadProducti, 10, 2));
            A674BancoNombre = T000S18_A674BancoNombre[0];
            A617ProfesionalesLimitOSF = T000S18_A617ProfesionalesLimitOSF[0];
            n617ProfesionalesLimitOSF = T000S18_n617ProfesionalesLimitOSF[0];
            AssignAttri("", false, "A617ProfesionalesLimitOSF", StringUtil.LTrimStr( (decimal)(A617ProfesionalesLimitOSF), 4, 0));
            A268ProfesionalesFeedBackCant = T000S18_A268ProfesionalesFeedBackCant[0];
            AssignAttri("", false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
            A269ProfesionalesFeedBackProm = T000S18_A269ProfesionalesFeedBackProm[0];
            AssignAttri("", false, "A269ProfesionalesFeedBackProm", StringUtil.LTrimStr( A269ProfesionalesFeedBackProm, 18, 2));
            A107EstadosTipo = T000S18_A107EstadosTipo[0];
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            A108EstadosGenericosId = T000S18_A108EstadosGenericosId[0];
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            A673BancoId = T000S18_A673BancoId[0];
            n673BancoId = T000S18_n673BancoId[0];
            AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            A169ProfesionalesPhoto = T000S18_A169ProfesionalesPhoto[0];
            AssignAttri("", false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            ZM0S34( -44) ;
         }
         pr_default.close(16);
         OnLoadActions0S34( ) ;
      }

      protected void OnLoadActions0S34( )
      {
         AV34Pgmname = "Profesionales";
         AssignAttri("", false, "AV34Pgmname", AV34Pgmname);
         A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
         AssignAttri("", false, "A886ProfesionalesNombreCompleto", A886ProfesionalesNombreCompleto);
         A803ProfesionalesTiempoDisponible = A800ProfesionalesCapacidadProducti;
         AssignAttri("", false, "A803ProfesionalesTiempoDisponible", StringUtil.LTrimStr( A803ProfesionalesTiempoDisponible, 10, 2));
         GXAESTADOSGENERICOSID_html0S34( A107EstadosTipo) ;
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
         AV14ProfesionalesFeedback = A270ProfesionalesFeedback;
         AssignAttri("", false, "AV14ProfesionalesFeedback", StringUtil.LTrimStr( AV14ProfesionalesFeedback, 10, 2));
      }

      protected void CheckExtendedTable0S34( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV34Pgmname = "Profesionales";
         AssignAttri("", false, "AV34Pgmname", AV34Pgmname);
         A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
         AssignAttri("", false, "A886ProfesionalesNombreCompleto", A886ProfesionalesNombreCompleto);
         if ( ! ( GxRegex.IsMatch(A193ProfesionalesEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A193ProfesionalesEmail)) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PROFESIONALESEMAIL");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A803ProfesionalesTiempoDisponible = A800ProfesionalesCapacidadProducti;
         AssignAttri("", false, "A803ProfesionalesTiempoDisponible", StringUtil.LTrimStr( A803ProfesionalesTiempoDisponible, 10, 2));
         /* Using cursor T000S17 */
         pr_default.execute(15, new Object[] {n673BancoId, A673BancoId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A673BancoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Banco", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
               GX_FocusControl = dynBancoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A674BancoNombre = T000S17_A674BancoNombre[0];
         pr_default.close(15);
         /* Using cursor T000S16 */
         pr_default.execute(14, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
            AnyError = 1;
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         GXAESTADOSGENERICOSID_html0S34( A107EstadosTipo) ;
         if ( ! ( (DateTime.MinValue==A199ProfesionalesFechaAlta) || ( A199ProfesionalesFechaAlta >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha de Alta", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PROFESIONALESFECHAALTA");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesFechaAlta_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A200ProfesionalesFechaActualizado) || ( A200ProfesionalesFechaActualizado >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Fecha Actualizado", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "PROFESIONALESFECHAACTUALIZADO");
            AnyError = 1;
            GX_FocusControl = edtProfesionalesFechaActualizado_Internalname;
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
         AV14ProfesionalesFeedback = A270ProfesionalesFeedback;
         AssignAttri("", false, "AV14ProfesionalesFeedback", StringUtil.LTrimStr( AV14ProfesionalesFeedback, 10, 2));
      }

      protected void CloseExtendedTableCursors0S34( )
      {
         pr_default.close(15);
         pr_default.close(14);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_46( long A673BancoId )
      {
         /* Using cursor T000S19 */
         pr_default.execute(17, new Object[] {n673BancoId, A673BancoId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A673BancoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Banco", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
               GX_FocusControl = dynBancoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A674BancoNombre = T000S19_A674BancoNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A674BancoNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_45( string A107EstadosTipo ,
                                int A108EstadosGenericosId )
      {
         /* Using cursor T000S20 */
         pr_default.execute(18, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
            AnyError = 1;
            GX_FocusControl = edtEstadosTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void GetKey0S34( )
      {
         /* Using cursor T000S21 */
         pr_default.execute(19, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000S15 */
         pr_default.execute(13, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            ZM0S34( 44) ;
            RcdFound34 = 1;
            A120ProfesionalesId = T000S15_A120ProfesionalesId[0];
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
            A199ProfesionalesFechaAlta = T000S15_A199ProfesionalesFechaAlta[0];
            AssignAttri("", false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A200ProfesionalesFechaActualizado = T000S15_A200ProfesionalesFechaActualizado[0];
            AssignAttri("", false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A900ProfesionalesFechaNacimiento = T000S15_A900ProfesionalesFechaNacimiento[0];
            n900ProfesionalesFechaNacimiento = T000S15_n900ProfesionalesFechaNacimiento[0];
            A901ProfesionalesRUT = T000S15_A901ProfesionalesRUT[0];
            n901ProfesionalesRUT = T000S15_n901ProfesionalesRUT[0];
            A902ProfesionalesTipoEmpresa = T000S15_A902ProfesionalesTipoEmpresa[0];
            n902ProfesionalesTipoEmpresa = T000S15_n902ProfesionalesTipoEmpresa[0];
            A676ProfesionalesEsRUT = T000S15_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = T000S15_n676ProfesionalesEsRUT[0];
            AssignAttri("", false, "A676ProfesionalesEsRUT", A676ProfesionalesEsRUT);
            A166ProfesionalesPrimerNombre = T000S15_A166ProfesionalesPrimerNombre[0];
            AssignAttri("", false, "A166ProfesionalesPrimerNombre", A166ProfesionalesPrimerNombre);
            A191ProfesionalesSegundoNombre = T000S15_A191ProfesionalesSegundoNombre[0];
            AssignAttri("", false, "A191ProfesionalesSegundoNombre", A191ProfesionalesSegundoNombre);
            A167ProfesionalesApellidoPrimero = T000S15_A167ProfesionalesApellidoPrimero[0];
            AssignAttri("", false, "A167ProfesionalesApellidoPrimero", A167ProfesionalesApellidoPrimero);
            A192ProfesionalesApellidoSegundo = T000S15_A192ProfesionalesApellidoSegundo[0];
            AssignAttri("", false, "A192ProfesionalesApellidoSegundo", A192ProfesionalesApellidoSegundo);
            A40000ProfesionalesPhoto_GXI = T000S15_A40000ProfesionalesPhoto_GXI[0];
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            A170ProfesionalesTelefono = T000S15_A170ProfesionalesTelefono[0];
            AssignAttri("", false, "A170ProfesionalesTelefono", A170ProfesionalesTelefono);
            A193ProfesionalesEmail = T000S15_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = T000S15_n193ProfesionalesEmail[0];
            AssignAttri("", false, "A193ProfesionalesEmail", A193ProfesionalesEmail);
            A198ProfesionalesDireccion = T000S15_A198ProfesionalesDireccion[0];
            AssignAttri("", false, "A198ProfesionalesDireccion", A198ProfesionalesDireccion);
            A267ProfesionalesVerDatPerSol = T000S15_A267ProfesionalesVerDatPerSol[0];
            AssignAttri("", false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
            A436ProfesionalesPerAltShop = T000S15_A436ProfesionalesPerAltShop[0];
            n436ProfesionalesPerAltShop = T000S15_n436ProfesionalesPerAltShop[0];
            AssignAttri("", false, "A436ProfesionalesPerAltShop", A436ProfesionalesPerAltShop);
            A196ProfesionalesAutoEnumerar = T000S15_A196ProfesionalesAutoEnumerar[0];
            A197ProfesionalesAutoEnuZona = T000S15_A197ProfesionalesAutoEnuZona[0];
            A677ProfesionalesExperiencia = T000S15_A677ProfesionalesExperiencia[0];
            n677ProfesionalesExperiencia = T000S15_n677ProfesionalesExperiencia[0];
            AssignAttri("", false, "A677ProfesionalesExperiencia", A677ProfesionalesExperiencia);
            A678ProfesionalesAceptoTerminos = T000S15_A678ProfesionalesAceptoTerminos[0];
            n678ProfesionalesAceptoTerminos = T000S15_n678ProfesionalesAceptoTerminos[0];
            AssignAttri("", false, "A678ProfesionalesAceptoTerminos", context.localUtil.TToC( A678ProfesionalesAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A679ProfesionalesDeclaroDatosV = T000S15_A679ProfesionalesDeclaroDatosV[0];
            n679ProfesionalesDeclaroDatosV = T000S15_n679ProfesionalesDeclaroDatosV[0];
            AssignAttri("", false, "A679ProfesionalesDeclaroDatosV", context.localUtil.TToC( A679ProfesionalesDeclaroDatosV, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A680ProfesionalesCuentaBancaria = T000S15_A680ProfesionalesCuentaBancaria[0];
            n680ProfesionalesCuentaBancaria = T000S15_n680ProfesionalesCuentaBancaria[0];
            AssignAttri("", false, "A680ProfesionalesCuentaBancaria", A680ProfesionalesCuentaBancaria);
            A800ProfesionalesCapacidadProducti = T000S15_A800ProfesionalesCapacidadProducti[0];
            AssignAttri("", false, "A800ProfesionalesCapacidadProducti", StringUtil.LTrimStr( A800ProfesionalesCapacidadProducti, 10, 2));
            A617ProfesionalesLimitOSF = T000S15_A617ProfesionalesLimitOSF[0];
            n617ProfesionalesLimitOSF = T000S15_n617ProfesionalesLimitOSF[0];
            AssignAttri("", false, "A617ProfesionalesLimitOSF", StringUtil.LTrimStr( (decimal)(A617ProfesionalesLimitOSF), 4, 0));
            A268ProfesionalesFeedBackCant = T000S15_A268ProfesionalesFeedBackCant[0];
            AssignAttri("", false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
            A269ProfesionalesFeedBackProm = T000S15_A269ProfesionalesFeedBackProm[0];
            AssignAttri("", false, "A269ProfesionalesFeedBackProm", StringUtil.LTrimStr( A269ProfesionalesFeedBackProm, 18, 2));
            A107EstadosTipo = T000S15_A107EstadosTipo[0];
            AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
            A108EstadosGenericosId = T000S15_A108EstadosGenericosId[0];
            AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
            A673BancoId = T000S15_A673BancoId[0];
            n673BancoId = T000S15_n673BancoId[0];
            AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
            A169ProfesionalesPhoto = T000S15_A169ProfesionalesPhoto[0];
            AssignAttri("", false, "A169ProfesionalesPhoto", A169ProfesionalesPhoto);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A169ProfesionalesPhoto)) ? A40000ProfesionalesPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A169ProfesionalesPhoto))), true);
            AssignProp("", false, imgProfesionalesPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A169ProfesionalesPhoto), true);
            O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            Z120ProfesionalesId = A120ProfesionalesId;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0S34( ) ;
            if ( AnyError == 1 )
            {
               RcdFound34 = 0;
               InitializeNonKey0S34( ) ;
            }
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey0S34( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(13);
      }

      protected void getEqualNoModal( )
      {
         GetKey0S34( ) ;
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
         /* Using cursor T000S22 */
         pr_default.execute(20, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            while ( (pr_default.getStatus(20) != 101) && ( ( StringUtil.StrCmp(T000S22_A120ProfesionalesId[0], A120ProfesionalesId) < 0 ) ) )
            {
               pr_default.readNext(20);
            }
            if ( (pr_default.getStatus(20) != 101) && ( ( StringUtil.StrCmp(T000S22_A120ProfesionalesId[0], A120ProfesionalesId) > 0 ) ) )
            {
               A120ProfesionalesId = T000S22_A120ProfesionalesId[0];
               AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
               RcdFound34 = 1;
            }
         }
         pr_default.close(20);
      }

      protected void move_previous( )
      {
         RcdFound34 = 0;
         /* Using cursor T000S23 */
         pr_default.execute(21, new Object[] {A120ProfesionalesId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            while ( (pr_default.getStatus(21) != 101) && ( ( StringUtil.StrCmp(T000S23_A120ProfesionalesId[0], A120ProfesionalesId) > 0 ) ) )
            {
               pr_default.readNext(21);
            }
            if ( (pr_default.getStatus(21) != 101) && ( ( StringUtil.StrCmp(T000S23_A120ProfesionalesId[0], A120ProfesionalesId) < 0 ) ) )
            {
               A120ProfesionalesId = T000S23_A120ProfesionalesId[0];
               AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
               RcdFound34 = 1;
            }
         }
         pr_default.close(21);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0S34( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0S34( ) ;
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
                  A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                  AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                  AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                  Update0S34( ) ;
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A120ProfesionalesId, Z120ProfesionalesId) != 0 )
               {
                  /* Insert record */
                  A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                  AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                  GX_FocusControl = edtProfesionalesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0S34( ) ;
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
                     A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                     AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                     GX_FocusControl = edtProfesionalesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0S34( ) ;
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
            A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProfesionalesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0S34( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000S14 */
            pr_default.execute(12, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(12) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Profesionales"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(12) == 101) || ( Z199ProfesionalesFechaAlta != T000S14_A199ProfesionalesFechaAlta[0] ) || ( Z200ProfesionalesFechaActualizado != T000S14_A200ProfesionalesFechaActualizado[0] ) || ( DateTimeUtil.ResetTime ( Z900ProfesionalesFechaNacimiento ) != DateTimeUtil.ResetTime ( T000S14_A900ProfesionalesFechaNacimiento[0] ) ) || ( StringUtil.StrCmp(Z901ProfesionalesRUT, T000S14_A901ProfesionalesRUT[0]) != 0 ) || ( Z902ProfesionalesTipoEmpresa != T000S14_A902ProfesionalesTipoEmpresa[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z676ProfesionalesEsRUT != T000S14_A676ProfesionalesEsRUT[0] ) || ( StringUtil.StrCmp(Z166ProfesionalesPrimerNombre, T000S14_A166ProfesionalesPrimerNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z191ProfesionalesSegundoNombre, T000S14_A191ProfesionalesSegundoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z167ProfesionalesApellidoPrimero, T000S14_A167ProfesionalesApellidoPrimero[0]) != 0 ) || ( StringUtil.StrCmp(Z192ProfesionalesApellidoSegundo, T000S14_A192ProfesionalesApellidoSegundo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z170ProfesionalesTelefono, T000S14_A170ProfesionalesTelefono[0]) != 0 ) || ( StringUtil.StrCmp(Z193ProfesionalesEmail, T000S14_A193ProfesionalesEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z198ProfesionalesDireccion, T000S14_A198ProfesionalesDireccion[0]) != 0 ) || ( StringUtil.StrCmp(Z267ProfesionalesVerDatPerSol, T000S14_A267ProfesionalesVerDatPerSol[0]) != 0 ) || ( StringUtil.StrCmp(Z436ProfesionalesPerAltShop, T000S14_A436ProfesionalesPerAltShop[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z196ProfesionalesAutoEnumerar != T000S14_A196ProfesionalesAutoEnumerar[0] ) || ( Z197ProfesionalesAutoEnuZona != T000S14_A197ProfesionalesAutoEnuZona[0] ) || ( StringUtil.StrCmp(Z677ProfesionalesExperiencia, T000S14_A677ProfesionalesExperiencia[0]) != 0 ) || ( Z678ProfesionalesAceptoTerminos != T000S14_A678ProfesionalesAceptoTerminos[0] ) || ( Z679ProfesionalesDeclaroDatosV != T000S14_A679ProfesionalesDeclaroDatosV[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z680ProfesionalesCuentaBancaria, T000S14_A680ProfesionalesCuentaBancaria[0]) != 0 ) || ( Z800ProfesionalesCapacidadProducti != T000S14_A800ProfesionalesCapacidadProducti[0] ) || ( Z617ProfesionalesLimitOSF != T000S14_A617ProfesionalesLimitOSF[0] ) || ( Z268ProfesionalesFeedBackCant != T000S14_A268ProfesionalesFeedBackCant[0] ) || ( Z269ProfesionalesFeedBackProm != T000S14_A269ProfesionalesFeedBackProm[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z107EstadosTipo, T000S14_A107EstadosTipo[0]) != 0 ) || ( Z108EstadosGenericosId != T000S14_A108EstadosGenericosId[0] ) || ( Z673BancoId != T000S14_A673BancoId[0] ) )
            {
               if ( Z199ProfesionalesFechaAlta != T000S14_A199ProfesionalesFechaAlta[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesFechaAlta");
                  GXUtil.WriteLogRaw("Old: ",Z199ProfesionalesFechaAlta);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A199ProfesionalesFechaAlta[0]);
               }
               if ( Z200ProfesionalesFechaActualizado != T000S14_A200ProfesionalesFechaActualizado[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesFechaActualizado");
                  GXUtil.WriteLogRaw("Old: ",Z200ProfesionalesFechaActualizado);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A200ProfesionalesFechaActualizado[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z900ProfesionalesFechaNacimiento ) != DateTimeUtil.ResetTime ( T000S14_A900ProfesionalesFechaNacimiento[0] ) )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesFechaNacimiento");
                  GXUtil.WriteLogRaw("Old: ",Z900ProfesionalesFechaNacimiento);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A900ProfesionalesFechaNacimiento[0]);
               }
               if ( StringUtil.StrCmp(Z901ProfesionalesRUT, T000S14_A901ProfesionalesRUT[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesRUT");
                  GXUtil.WriteLogRaw("Old: ",Z901ProfesionalesRUT);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A901ProfesionalesRUT[0]);
               }
               if ( Z902ProfesionalesTipoEmpresa != T000S14_A902ProfesionalesTipoEmpresa[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesTipoEmpresa");
                  GXUtil.WriteLogRaw("Old: ",Z902ProfesionalesTipoEmpresa);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A902ProfesionalesTipoEmpresa[0]);
               }
               if ( Z676ProfesionalesEsRUT != T000S14_A676ProfesionalesEsRUT[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesEsRUT");
                  GXUtil.WriteLogRaw("Old: ",Z676ProfesionalesEsRUT);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A676ProfesionalesEsRUT[0]);
               }
               if ( StringUtil.StrCmp(Z166ProfesionalesPrimerNombre, T000S14_A166ProfesionalesPrimerNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesPrimerNombre");
                  GXUtil.WriteLogRaw("Old: ",Z166ProfesionalesPrimerNombre);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A166ProfesionalesPrimerNombre[0]);
               }
               if ( StringUtil.StrCmp(Z191ProfesionalesSegundoNombre, T000S14_A191ProfesionalesSegundoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesSegundoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z191ProfesionalesSegundoNombre);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A191ProfesionalesSegundoNombre[0]);
               }
               if ( StringUtil.StrCmp(Z167ProfesionalesApellidoPrimero, T000S14_A167ProfesionalesApellidoPrimero[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesApellidoPrimero");
                  GXUtil.WriteLogRaw("Old: ",Z167ProfesionalesApellidoPrimero);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A167ProfesionalesApellidoPrimero[0]);
               }
               if ( StringUtil.StrCmp(Z192ProfesionalesApellidoSegundo, T000S14_A192ProfesionalesApellidoSegundo[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesApellidoSegundo");
                  GXUtil.WriteLogRaw("Old: ",Z192ProfesionalesApellidoSegundo);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A192ProfesionalesApellidoSegundo[0]);
               }
               if ( StringUtil.StrCmp(Z170ProfesionalesTelefono, T000S14_A170ProfesionalesTelefono[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z170ProfesionalesTelefono);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A170ProfesionalesTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z193ProfesionalesEmail, T000S14_A193ProfesionalesEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesEmail");
                  GXUtil.WriteLogRaw("Old: ",Z193ProfesionalesEmail);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A193ProfesionalesEmail[0]);
               }
               if ( StringUtil.StrCmp(Z198ProfesionalesDireccion, T000S14_A198ProfesionalesDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z198ProfesionalesDireccion);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A198ProfesionalesDireccion[0]);
               }
               if ( StringUtil.StrCmp(Z267ProfesionalesVerDatPerSol, T000S14_A267ProfesionalesVerDatPerSol[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesVerDatPerSol");
                  GXUtil.WriteLogRaw("Old: ",Z267ProfesionalesVerDatPerSol);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A267ProfesionalesVerDatPerSol[0]);
               }
               if ( StringUtil.StrCmp(Z436ProfesionalesPerAltShop, T000S14_A436ProfesionalesPerAltShop[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesPerAltShop");
                  GXUtil.WriteLogRaw("Old: ",Z436ProfesionalesPerAltShop);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A436ProfesionalesPerAltShop[0]);
               }
               if ( Z196ProfesionalesAutoEnumerar != T000S14_A196ProfesionalesAutoEnumerar[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesAutoEnumerar");
                  GXUtil.WriteLogRaw("Old: ",Z196ProfesionalesAutoEnumerar);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A196ProfesionalesAutoEnumerar[0]);
               }
               if ( Z197ProfesionalesAutoEnuZona != T000S14_A197ProfesionalesAutoEnuZona[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesAutoEnuZona");
                  GXUtil.WriteLogRaw("Old: ",Z197ProfesionalesAutoEnuZona);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A197ProfesionalesAutoEnuZona[0]);
               }
               if ( StringUtil.StrCmp(Z677ProfesionalesExperiencia, T000S14_A677ProfesionalesExperiencia[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesExperiencia");
                  GXUtil.WriteLogRaw("Old: ",Z677ProfesionalesExperiencia);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A677ProfesionalesExperiencia[0]);
               }
               if ( Z678ProfesionalesAceptoTerminos != T000S14_A678ProfesionalesAceptoTerminos[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesAceptoTerminos");
                  GXUtil.WriteLogRaw("Old: ",Z678ProfesionalesAceptoTerminos);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A678ProfesionalesAceptoTerminos[0]);
               }
               if ( Z679ProfesionalesDeclaroDatosV != T000S14_A679ProfesionalesDeclaroDatosV[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesDeclaroDatosV");
                  GXUtil.WriteLogRaw("Old: ",Z679ProfesionalesDeclaroDatosV);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A679ProfesionalesDeclaroDatosV[0]);
               }
               if ( StringUtil.StrCmp(Z680ProfesionalesCuentaBancaria, T000S14_A680ProfesionalesCuentaBancaria[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesCuentaBancaria");
                  GXUtil.WriteLogRaw("Old: ",Z680ProfesionalesCuentaBancaria);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A680ProfesionalesCuentaBancaria[0]);
               }
               if ( Z800ProfesionalesCapacidadProducti != T000S14_A800ProfesionalesCapacidadProducti[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesCapacidadProducti");
                  GXUtil.WriteLogRaw("Old: ",Z800ProfesionalesCapacidadProducti);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A800ProfesionalesCapacidadProducti[0]);
               }
               if ( Z617ProfesionalesLimitOSF != T000S14_A617ProfesionalesLimitOSF[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesLimitOSF");
                  GXUtil.WriteLogRaw("Old: ",Z617ProfesionalesLimitOSF);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A617ProfesionalesLimitOSF[0]);
               }
               if ( Z268ProfesionalesFeedBackCant != T000S14_A268ProfesionalesFeedBackCant[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesFeedBackCant");
                  GXUtil.WriteLogRaw("Old: ",Z268ProfesionalesFeedBackCant);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A268ProfesionalesFeedBackCant[0]);
               }
               if ( Z269ProfesionalesFeedBackProm != T000S14_A269ProfesionalesFeedBackProm[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ProfesionalesFeedBackProm");
                  GXUtil.WriteLogRaw("Old: ",Z269ProfesionalesFeedBackProm);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A269ProfesionalesFeedBackProm[0]);
               }
               if ( StringUtil.StrCmp(Z107EstadosTipo, T000S14_A107EstadosTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"EstadosTipo");
                  GXUtil.WriteLogRaw("Old: ",Z107EstadosTipo);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A107EstadosTipo[0]);
               }
               if ( Z108EstadosGenericosId != T000S14_A108EstadosGenericosId[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"EstadosGenericosId");
                  GXUtil.WriteLogRaw("Old: ",Z108EstadosGenericosId);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A108EstadosGenericosId[0]);
               }
               if ( Z673BancoId != T000S14_A673BancoId[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"BancoId");
                  GXUtil.WriteLogRaw("Old: ",Z673BancoId);
                  GXUtil.WriteLogRaw("Current: ",T000S14_A673BancoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Profesionales"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S34( )
      {
         BeforeValidate0S34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S34( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S34( 0) ;
            CheckOptimisticConcurrency0S34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S24 */
                     pr_default.execute(22, new Object[] {A120ProfesionalesId, A199ProfesionalesFechaAlta, A200ProfesionalesFechaActualizado, n900ProfesionalesFechaNacimiento, A900ProfesionalesFechaNacimiento, n901ProfesionalesRUT, A901ProfesionalesRUT, n902ProfesionalesTipoEmpresa, A902ProfesionalesTipoEmpresa, n676ProfesionalesEsRUT, A676ProfesionalesEsRUT, A166ProfesionalesPrimerNombre, A191ProfesionalesSegundoNombre, A167ProfesionalesApellidoPrimero, A192ProfesionalesApellidoSegundo, A169ProfesionalesPhoto, A40000ProfesionalesPhoto_GXI, A170ProfesionalesTelefono, n193ProfesionalesEmail, A193ProfesionalesEmail, A198ProfesionalesDireccion, A267ProfesionalesVerDatPerSol, n436ProfesionalesPerAltShop, A436ProfesionalesPerAltShop, A196ProfesionalesAutoEnumerar, A197ProfesionalesAutoEnuZona, n677ProfesionalesExperiencia, A677ProfesionalesExperiencia, n678ProfesionalesAceptoTerminos, A678ProfesionalesAceptoTerminos, n679ProfesionalesDeclaroDatosV, A679ProfesionalesDeclaroDatosV, n680ProfesionalesCuentaBancaria, A680ProfesionalesCuentaBancaria, A800ProfesionalesCapacidadProducti, n617ProfesionalesLimitOSF, A617ProfesionalesLimitOSF, A268ProfesionalesFeedBackCant, A269ProfesionalesFeedBackProm, A107EstadosTipo, A108EstadosGenericosId, n673BancoId, A673BancoId});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("Profesionales");
                     if ( (pr_default.getStatus(22) == 1) )
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
                           ProcessLevel0S34( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0S0( ) ;
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
               Load0S34( ) ;
            }
            EndLevel0S34( ) ;
         }
         CloseExtendedTableCursors0S34( ) ;
      }

      protected void Update0S34( )
      {
         BeforeValidate0S34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S34( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S25 */
                     pr_default.execute(23, new Object[] {A199ProfesionalesFechaAlta, A200ProfesionalesFechaActualizado, n900ProfesionalesFechaNacimiento, A900ProfesionalesFechaNacimiento, n901ProfesionalesRUT, A901ProfesionalesRUT, n902ProfesionalesTipoEmpresa, A902ProfesionalesTipoEmpresa, n676ProfesionalesEsRUT, A676ProfesionalesEsRUT, A166ProfesionalesPrimerNombre, A191ProfesionalesSegundoNombre, A167ProfesionalesApellidoPrimero, A192ProfesionalesApellidoSegundo, A170ProfesionalesTelefono, n193ProfesionalesEmail, A193ProfesionalesEmail, A198ProfesionalesDireccion, A267ProfesionalesVerDatPerSol, n436ProfesionalesPerAltShop, A436ProfesionalesPerAltShop, A196ProfesionalesAutoEnumerar, A197ProfesionalesAutoEnuZona, n677ProfesionalesExperiencia, A677ProfesionalesExperiencia, n678ProfesionalesAceptoTerminos, A678ProfesionalesAceptoTerminos, n679ProfesionalesDeclaroDatosV, A679ProfesionalesDeclaroDatosV, n680ProfesionalesCuentaBancaria, A680ProfesionalesCuentaBancaria, A800ProfesionalesCapacidadProducti, n617ProfesionalesLimitOSF, A617ProfesionalesLimitOSF, A268ProfesionalesFeedBackCant, A269ProfesionalesFeedBackProm, A107EstadosTipo, A108EstadosGenericosId, n673BancoId, A673BancoId, A120ProfesionalesId});
                     pr_default.close(23);
                     pr_default.SmartCacheProvider.SetUpdated("Profesionales");
                     if ( (pr_default.getStatus(23) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Profesionales"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0S34( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0S34( ) ;
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
            EndLevel0S34( ) ;
         }
         CloseExtendedTableCursors0S34( ) ;
      }

      protected void DeferredUpdate0S34( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000S26 */
            pr_default.execute(24, new Object[] {A169ProfesionalesPhoto, A40000ProfesionalesPhoto_GXI, A120ProfesionalesId});
            pr_default.close(24);
            pr_default.SmartCacheProvider.SetUpdated("Profesionales");
         }
      }

      protected void delete( )
      {
         BeforeValidate0S34( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S34( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S34( ) ;
            AfterConfirm0S34( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S34( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0S145( ) ;
                  while ( RcdFound145 != 0 )
                  {
                     getByPrimaryKey0S145( ) ;
                     Delete0S145( ) ;
                     ScanNext0S145( ) ;
                  }
                  ScanEnd0S145( ) ;
                  A197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
                  AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                  ScanStart0S36( ) ;
                  while ( RcdFound36 != 0 )
                  {
                     getByPrimaryKey0S36( ) ;
                     Delete0S36( ) ;
                     ScanNext0S36( ) ;
                     O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
                     AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
                  }
                  ScanEnd0S36( ) ;
                  ScanStart0S35( ) ;
                  while ( RcdFound35 != 0 )
                  {
                     getByPrimaryKey0S35( ) ;
                     Delete0S35( ) ;
                     ScanNext0S35( ) ;
                  }
                  ScanEnd0S35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S27 */
                     pr_default.execute(25, new Object[] {A120ProfesionalesId});
                     pr_default.close(25);
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
         }
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0S34( ) ;
         Gx_mode = sMode34;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0S34( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV34Pgmname = "Profesionales";
            AssignAttri("", false, "AV34Pgmname", AV34Pgmname);
            A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
            AssignAttri("", false, "A886ProfesionalesNombreCompleto", A886ProfesionalesNombreCompleto);
            A803ProfesionalesTiempoDisponible = A800ProfesionalesCapacidadProducti;
            AssignAttri("", false, "A803ProfesionalesTiempoDisponible", StringUtil.LTrimStr( A803ProfesionalesTiempoDisponible, 10, 2));
            /* Using cursor T000S28 */
            pr_default.execute(26, new Object[] {n673BancoId, A673BancoId});
            A674BancoNombre = T000S28_A674BancoNombre[0];
            pr_default.close(26);
            GXAESTADOSGENERICOSID_html0S34( A107EstadosTipo) ;
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
            AV14ProfesionalesFeedback = A270ProfesionalesFeedback;
            AssignAttri("", false, "AV14ProfesionalesFeedback", StringUtil.LTrimStr( AV14ProfesionalesFeedback, 10, 2));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000S29 */
            pr_default.execute(27, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Detalles", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T000S30 */
            pr_default.execute(28, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "ProfesionalesRestriccion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T000S31 */
            pr_default.execute(29, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Prof Comisiones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T000S32 */
            pr_default.execute(30, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Relaciones", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T000S33 */
            pr_default.execute(31, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T000S34 */
            pr_default.execute(32, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Agrupacion", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T000S35 */
            pr_default.execute(33, new Object[] {A120ProfesionalesId});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Profesionales", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
         }
      }

      protected void ProcessNestedLevel0S35( )
      {
         nGXsfl_122_idx = 0;
         while ( nGXsfl_122_idx < nRC_GXsfl_122 )
         {
            ReadRow0S35( ) ;
            if ( ( nRcdExists_35 != 0 ) || ( nIsMod_35 != 0 ) )
            {
               standaloneNotModal0S35( ) ;
               GetKey0S35( ) ;
               if ( ( nRcdExists_35 == 0 ) && ( nRcdDeleted_35 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0S35( ) ;
               }
               else
               {
                  if ( RcdFound35 != 0 )
                  {
                     if ( ( nRcdDeleted_35 != 0 ) && ( nRcdExists_35 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0S35( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_35 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0S35( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_35 == 0 )
                     {
                        GXCCtl = "RUBROSID_" + sGXsfl_122_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = dynRubrosId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( dynRubrosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))) ;
            ChangePostValue( edtRubrosImagen_Internalname, A168RubrosImagen) ;
            ChangePostValue( edtEstadosProfRubTipo_Internalname, StringUtil.RTrim( A124EstadosProfRubTipo)) ;
            ChangePostValue( cmbEstadosProfRubId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A125EstadosProfRubId), 5, 0, ".", ""))) ;
            ChangePostValue( cmbRubrosEstado_Internalname, StringUtil.RTrim( A123RubrosEstado)) ;
            ChangePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_122_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z124EstadosProfRubTipo_"+sGXsfl_122_idx, StringUtil.RTrim( Z124EstadosProfRubTipo)) ;
            ChangePostValue( "ZT_"+"Z125EstadosProfRubId_"+sGXsfl_122_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125EstadosProfRubId), 5, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_35_"+sGXsfl_122_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_35), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_35_"+sGXsfl_122_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_35), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_35_"+sGXsfl_122_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_35), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_35 != 0 )
            {
               ChangePostValue( "RUBROSID_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynRubrosId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSIMAGEN_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSPROFRUBTIPO_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosProfRubTipo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSPROFRUBID_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbEstadosProfRubId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "RUBROSESTADO_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbRubrosEstado.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0S35( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_35 = 0;
         nIsMod_35 = 0;
         nRcdDeleted_35 = 0;
      }

      protected void ProcessNestedLevel0S36( )
      {
         s197ProfesionalesAutoEnuZona = O197ProfesionalesAutoEnuZona;
         AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         nGXsfl_157_idx = 0;
         while ( nGXsfl_157_idx < nRC_GXsfl_157 )
         {
            ReadRow0S36( ) ;
            if ( ( nRcdExists_36 != 0 ) || ( nIsMod_36 != 0 ) )
            {
               standaloneNotModal0S36( ) ;
               GetKey0S36( ) ;
               if ( ( nRcdExists_36 == 0 ) && ( nRcdDeleted_36 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0S36( ) ;
               }
               else
               {
                  if ( RcdFound36 != 0 )
                  {
                     if ( ( nRcdDeleted_36 != 0 ) && ( nRcdExists_36 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0S36( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_36 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0S36( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_36 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROFESIONALESID");
                        AnyError = 1;
                        GX_FocusControl = edtProfesionalesId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
               AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
            }
            ChangePostValue( edtProfesionalesZonasCorrelativo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A126ProfesionalesZonasCorrelativo), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtPaisID_Internalname, StringUtil.RTrim( A116PaisID)) ;
            ChangePostValue( dynDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", ""))) ;
            ChangePostValue( dynDepartamentoMunicipioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", ""))) ;
            ChangePostValue( dynZonasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z126ProfesionalesZonasCorrelativo_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126ProfesionalesZonasCorrelativo), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z112DepartamentoId_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z114DepartamentoMunicipioId_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z110ZonasID_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_36_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_36), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_36_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_36), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_36_"+sGXsfl_157_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_36), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_36 != 0 )
            {
               ChangePostValue( "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAISID_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaisID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOID_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynDepartamentoId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ZONASID_"+sGXsfl_157_idx+"Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynZonasID.Visible), 5, 0, ".", ""))) ;
               ChangePostValue( "ZONASID_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynZonasID.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0S36( ) ;
         if ( AnyError != 0 )
         {
            O197ProfesionalesAutoEnuZona = s197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         nRcdExists_36 = 0;
         nIsMod_36 = 0;
         nRcdDeleted_36 = 0;
      }

      protected void ProcessNestedLevel0S145( )
      {
         nGXsfl_143_idx = 0;
         while ( nGXsfl_143_idx < nRC_GXsfl_143 )
         {
            ReadRow0S145( ) ;
            if ( ( nRcdExists_145 != 0 ) || ( nIsMod_145 != 0 ) )
            {
               standaloneNotModal0S145( ) ;
               GetKey0S145( ) ;
               if ( ( nRcdExists_145 == 0 ) && ( nRcdDeleted_145 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0S145( ) ;
               }
               else
               {
                  if ( RcdFound145 != 0 )
                  {
                     if ( ( nRcdDeleted_145 != 0 ) && ( nRcdExists_145 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0S145( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_145 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0S145( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_145 == 0 )
                     {
                        GXCCtl = "PROFESIONALSERVICIOID_" + sGXsfl_143_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProfesionalServicioId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProfesionalServicioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A993ProfesionalServicioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtProfesionalServicioNombre_Internalname, StringUtil.RTrim( A994ProfesionalServicioNombre)) ;
            ChangePostValue( cmbEstadoServProf_Internalname, StringUtil.RTrim( A995EstadoServProf)) ;
            ChangePostValue( "ZT_"+"Z993ProfesionalServicioId_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z993ProfesionalServicioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z995EstadoServProf_"+sGXsfl_143_idx, StringUtil.RTrim( Z995EstadoServProf)) ;
            ChangePostValue( "nRcdDeleted_145_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_145), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_145_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_145), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_145_"+sGXsfl_143_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_145), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_145 != 0 )
            {
               ChangePostValue( "PROFESIONALSERVICIOID_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalServicioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PROFESIONALSERVICIONOMBRE_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalServicioNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESTADOSERVPROF_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbEstadoServProf.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0S145( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_145 = 0;
         nIsMod_145 = 0;
         nRcdDeleted_145 = 0;
      }

      protected void ProcessLevel0S34( )
      {
         /* Save parent mode. */
         sMode34 = Gx_mode;
         ProcessNestedLevel0S35( ) ;
         ProcessNestedLevel0S36( ) ;
         ProcessNestedLevel0S145( ) ;
         if ( AnyError != 0 )
         {
            O197ProfesionalesAutoEnuZona = s197ProfesionalesAutoEnuZona;
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode34;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000S36 */
         pr_default.execute(34, new Object[] {A197ProfesionalesAutoEnuZona, A120ProfesionalesId});
         pr_default.close(34);
         pr_default.SmartCacheProvider.SetUpdated("Profesionales");
      }

      protected void EndLevel0S34( )
      {
         pr_default.close(12);
         if ( AnyError == 0 )
         {
            BeforeComplete0S34( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(13);
            pr_default.close(9);
            pr_default.close(8);
            pr_default.close(4);
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(26);
            pr_default.close(10);
            pr_default.close(11);
            pr_default.close(5);
            pr_default.close(6);
            pr_default.close(7);
            pr_default.close(2);
            context.CommitDataStores("profesionales",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(13);
            pr_default.close(9);
            pr_default.close(8);
            pr_default.close(4);
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(26);
            pr_default.close(10);
            pr_default.close(11);
            pr_default.close(5);
            pr_default.close(6);
            pr_default.close(7);
            pr_default.close(2);
            context.RollbackDataStores("profesionales",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0S34( )
      {
         /* Scan By routine */
         /* Using cursor T000S37 */
         pr_default.execute(35);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound34 = 1;
            A120ProfesionalesId = T000S37_A120ProfesionalesId[0];
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0S34( )
      {
         /* Scan next routine */
         pr_default.readNext(35);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound34 = 1;
            A120ProfesionalesId = T000S37_A120ProfesionalesId[0];
            AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
         }
      }

      protected void ScanEnd0S34( )
      {
         pr_default.close(35);
      }

      protected void AfterConfirm0S34( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S34( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S34( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S34( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S34( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S34( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S34( )
      {
         edtProfesionalesId_Enabled = 0;
         AssignProp("", false, edtProfesionalesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesId_Enabled), 5, 0), true);
         dynEstadosGenericosId.Enabled = 0;
         AssignProp("", false, dynEstadosGenericosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEstadosGenericosId.Enabled), 5, 0), true);
         chkProfesionalesEsRUT.Enabled = 0;
         AssignProp("", false, chkProfesionalesEsRUT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProfesionalesEsRUT.Enabled), 5, 0), true);
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
         edtProfesionalesFeedBackCant_Enabled = 0;
         AssignProp("", false, edtProfesionalesFeedBackCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFeedBackCant_Enabled), 5, 0), true);
         edtProfesionalesTelefono_Enabled = 0;
         AssignProp("", false, edtProfesionalesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesTelefono_Enabled), 5, 0), true);
         edtProfesionalesEmail_Enabled = 0;
         AssignProp("", false, edtProfesionalesEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesEmail_Enabled), 5, 0), true);
         edtProfesionalesDireccion_Enabled = 0;
         AssignProp("", false, edtProfesionalesDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesDireccion_Enabled), 5, 0), true);
         cmbProfesionalesVerDatPerSol.Enabled = 0;
         AssignProp("", false, cmbProfesionalesVerDatPerSol_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProfesionalesVerDatPerSol.Enabled), 5, 0), true);
         edtProfesionalesLimitOSF_Enabled = 0;
         AssignProp("", false, edtProfesionalesLimitOSF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesLimitOSF_Enabled), 5, 0), true);
         edtProfesionalesAceptoTerminos_Enabled = 0;
         AssignProp("", false, edtProfesionalesAceptoTerminos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesAceptoTerminos_Enabled), 5, 0), true);
         edtProfesionalesDeclaroDatosV_Enabled = 0;
         AssignProp("", false, edtProfesionalesDeclaroDatosV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesDeclaroDatosV_Enabled), 5, 0), true);
         dynBancoId.Enabled = 0;
         AssignProp("", false, dynBancoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBancoId.Enabled), 5, 0), true);
         edtProfesionalesCuentaBancaria_Enabled = 0;
         AssignProp("", false, edtProfesionalesCuentaBancaria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesCuentaBancaria_Enabled), 5, 0), true);
         edtProfesionalesExperiencia_Enabled = 0;
         AssignProp("", false, edtProfesionalesExperiencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesExperiencia_Enabled), 5, 0), true);
         edtEstadosTipo_Enabled = 0;
         AssignProp("", false, edtEstadosTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosTipo_Enabled), 5, 0), true);
         edtProfesionalesCapacidadProducti_Enabled = 0;
         AssignProp("", false, edtProfesionalesCapacidadProducti_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesCapacidadProducti_Enabled), 5, 0), true);
         edtProfesionalesPerAltShop_Enabled = 0;
         AssignProp("", false, edtProfesionalesPerAltShop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesPerAltShop_Enabled), 5, 0), true);
         edtProfesionalesFechaAlta_Enabled = 0;
         AssignProp("", false, edtProfesionalesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFechaAlta_Enabled), 5, 0), true);
         edtProfesionalesFechaActualizado_Enabled = 0;
         AssignProp("", false, edtProfesionalesFechaActualizado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFechaActualizado_Enabled), 5, 0), true);
         edtProfesionalesFeedBackProm_Enabled = 0;
         AssignProp("", false, edtProfesionalesFeedBackProm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesFeedBackProm_Enabled), 5, 0), true);
         Profesionalesfeedback_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Profesionalesfeedback_Internalname, "Enabled", StringUtil.BoolToStr( Profesionalesfeedback_Enabled), true);
      }

      protected void ZM0S35( short GX_JID )
      {
         if ( ( GX_JID == 47 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z124EstadosProfRubTipo = T000S11_A124EstadosProfRubTipo[0];
               Z125EstadosProfRubId = T000S11_A125EstadosProfRubId[0];
            }
            else
            {
               Z124EstadosProfRubTipo = A124EstadosProfRubTipo;
               Z125EstadosProfRubId = A125EstadosProfRubId;
            }
         }
         if ( GX_JID == -47 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
            Z121RubrosId = A121RubrosId;
            Z124EstadosProfRubTipo = A124EstadosProfRubTipo;
            Z125EstadosProfRubId = A125EstadosProfRubId;
            Z122RubrosNombre = A122RubrosNombre;
            Z168RubrosImagen = A168RubrosImagen;
            Z40001RubrosImagen_GXI = A40001RubrosImagen_GXI;
            Z123RubrosEstado = A123RubrosEstado;
            Z221EstadosProfRubNomb = A221EstadosProfRubNomb;
         }
      }

      protected void standaloneNotModal0S35( )
      {
         GXARUBROSID_html0S35( ) ;
         edtEstadosProfRubTipo_Enabled = 0;
         AssignProp("", false, edtEstadosProfRubTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosProfRubTipo_Enabled), 5, 0), !bGXsfl_122_Refreshing);
      }

      protected void standaloneModal0S35( )
      {
         A124EstadosProfRubTipo = context.GetMessage( context.GetMessage( "STS", ""), "");
         if ( IsIns( )  )
         {
            A125EstadosProfRubId = 1;
         }
         if ( IsIns( )  && (0==A121RubrosId) && ( Gx_BScreen == 0 ) )
         {
            A121RubrosId = 0;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            dynRubrosId.Enabled = 0;
            AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), !bGXsfl_122_Refreshing);
         }
         else
         {
            dynRubrosId.Enabled = 1;
            AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), !bGXsfl_122_Refreshing);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000S12 */
            pr_default.execute(10, new Object[] {A121RubrosId});
            A122RubrosNombre = T000S12_A122RubrosNombre[0];
            A40001RubrosImagen_GXI = T000S12_A40001RubrosImagen_GXI[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_122_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A123RubrosEstado = T000S12_A123RubrosEstado[0];
            n123RubrosEstado = T000S12_n123RubrosEstado[0];
            A168RubrosImagen = T000S12_A168RubrosImagen[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_122_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            pr_default.close(10);
            /* Using cursor T000S13 */
            pr_default.execute(11, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
            A221EstadosProfRubNomb = T000S13_A221EstadosProfRubNomb[0];
            pr_default.close(11);
         }
      }

      protected void Load0S35( )
      {
         /* Using cursor T000S38 */
         pr_default.execute(36, new Object[] {A120ProfesionalesId, A121RubrosId});
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound35 = 1;
            A122RubrosNombre = T000S38_A122RubrosNombre[0];
            A40001RubrosImagen_GXI = T000S38_A40001RubrosImagen_GXI[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_122_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A123RubrosEstado = T000S38_A123RubrosEstado[0];
            n123RubrosEstado = T000S38_n123RubrosEstado[0];
            A221EstadosProfRubNomb = T000S38_A221EstadosProfRubNomb[0];
            A124EstadosProfRubTipo = T000S38_A124EstadosProfRubTipo[0];
            A125EstadosProfRubId = T000S38_A125EstadosProfRubId[0];
            A168RubrosImagen = T000S38_A168RubrosImagen[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_122_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            ZM0S35( -47) ;
         }
         pr_default.close(36);
         OnLoadActions0S35( ) ;
      }

      protected void OnLoadActions0S35( )
      {
      }

      protected void CheckExtendedTable0S35( )
      {
         nIsDirty_35 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0S35( ) ;
         /* Using cursor T000S12 */
         pr_default.execute(10, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_122_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A122RubrosNombre = T000S12_A122RubrosNombre[0];
         A40001RubrosImagen_GXI = T000S12_A40001RubrosImagen_GXI[0];
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A123RubrosEstado = T000S12_A123RubrosEstado[0];
         n123RubrosEstado = T000S12_n123RubrosEstado[0];
         A168RubrosImagen = T000S12_A168RubrosImagen[0];
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         pr_default.close(10);
         /* Using cursor T000S13 */
         pr_default.execute(11, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GXCCtl = "ESTADOSPROFRUBID_" + sGXsfl_122_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Prof Rub", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbEstadosProfRubId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A221EstadosProfRubNomb = T000S13_A221EstadosProfRubNomb[0];
         pr_default.close(11);
      }

      protected void CloseExtendedTableCursors0S35( )
      {
         pr_default.close(10);
         pr_default.close(11);
      }

      protected void enableDisable0S35( )
      {
      }

      protected void gxLoad_48( short A121RubrosId )
      {
         /* Using cursor T000S39 */
         pr_default.execute(37, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(37) == 101) )
         {
            GXCCtl = "RUBROSID_" + sGXsfl_122_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A122RubrosNombre = T000S39_A122RubrosNombre[0];
         A40001RubrosImagen_GXI = T000S39_A40001RubrosImagen_GXI[0];
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A123RubrosEstado = T000S39_A123RubrosEstado[0];
         n123RubrosEstado = T000S39_n123RubrosEstado[0];
         A168RubrosImagen = T000S39_A168RubrosImagen[0];
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A122RubrosNombre))+"\""+","+"\""+GXUtil.EncodeJSConstant( A168RubrosImagen)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40001RubrosImagen_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A123RubrosEstado))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(37) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(37);
      }

      protected void gxLoad_49( string A124EstadosProfRubTipo ,
                                int A125EstadosProfRubId )
      {
         /* Using cursor T000S40 */
         pr_default.execute(38, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
         if ( (pr_default.getStatus(38) == 101) )
         {
            GXCCtl = "ESTADOSPROFRUBID_" + sGXsfl_122_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Prof Rub", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbEstadosProfRubId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A221EstadosProfRubNomb = T000S40_A221EstadosProfRubNomb[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A221EstadosProfRubNomb))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(38) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(38);
      }

      protected void GetKey0S35( )
      {
         /* Using cursor T000S41 */
         pr_default.execute(39, new Object[] {A120ProfesionalesId, A121RubrosId});
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound35 = 1;
         }
         else
         {
            RcdFound35 = 0;
         }
         pr_default.close(39);
      }

      protected void getByPrimaryKey0S35( )
      {
         /* Using cursor T000S11 */
         pr_default.execute(9, new Object[] {A120ProfesionalesId, A121RubrosId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            ZM0S35( 47) ;
            RcdFound35 = 1;
            InitializeNonKey0S35( ) ;
            A121RubrosId = T000S11_A121RubrosId[0];
            A124EstadosProfRubTipo = T000S11_A124EstadosProfRubTipo[0];
            A125EstadosProfRubId = T000S11_A125EstadosProfRubId[0];
            Z120ProfesionalesId = A120ProfesionalesId;
            Z121RubrosId = A121RubrosId;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0S35( ) ;
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound35 = 0;
            InitializeNonKey0S35( ) ;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0S35( ) ;
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0S35( ) ;
         }
         pr_default.close(9);
      }

      protected void CheckOptimisticConcurrency0S35( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000S10 */
            pr_default.execute(8, new Object[] {A120ProfesionalesId, A121RubrosId});
            if ( (pr_default.getStatus(8) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesRubros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(8) == 101) || ( StringUtil.StrCmp(Z124EstadosProfRubTipo, T000S10_A124EstadosProfRubTipo[0]) != 0 ) || ( Z125EstadosProfRubId != T000S10_A125EstadosProfRubId[0] ) )
            {
               if ( StringUtil.StrCmp(Z124EstadosProfRubTipo, T000S10_A124EstadosProfRubTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"EstadosProfRubTipo");
                  GXUtil.WriteLogRaw("Old: ",Z124EstadosProfRubTipo);
                  GXUtil.WriteLogRaw("Current: ",T000S10_A124EstadosProfRubTipo[0]);
               }
               if ( Z125EstadosProfRubId != T000S10_A125EstadosProfRubId[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"EstadosProfRubId");
                  GXUtil.WriteLogRaw("Old: ",Z125EstadosProfRubId);
                  GXUtil.WriteLogRaw("Current: ",T000S10_A125EstadosProfRubId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProfesionalesRubros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S35( )
      {
         BeforeValidate0S35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S35( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S35( 0) ;
            CheckOptimisticConcurrency0S35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S42 */
                     pr_default.execute(40, new Object[] {A120ProfesionalesId, A121RubrosId, A124EstadosProfRubTipo, A125EstadosProfRubId});
                     pr_default.close(40);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRubros");
                     if ( (pr_default.getStatus(40) == 1) )
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
               Load0S35( ) ;
            }
            EndLevel0S35( ) ;
         }
         CloseExtendedTableCursors0S35( ) ;
      }

      protected void Update0S35( )
      {
         BeforeValidate0S35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S35( ) ;
         }
         if ( ( nIsMod_35 != 0 ) || ( nIsDirty_35 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0S35( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0S35( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0S35( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000S43 */
                        pr_default.execute(41, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId, A120ProfesionalesId, A121RubrosId});
                        pr_default.close(41);
                        pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRubros");
                        if ( (pr_default.getStatus(41) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesRubros"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0S35( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0S35( ) ;
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
               EndLevel0S35( ) ;
            }
         }
         CloseExtendedTableCursors0S35( ) ;
      }

      protected void DeferredUpdate0S35( )
      {
      }

      protected void Delete0S35( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0S35( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S35( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S35( ) ;
            AfterConfirm0S35( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S35( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000S44 */
                  pr_default.execute(42, new Object[] {A120ProfesionalesId, A121RubrosId});
                  pr_default.close(42);
                  pr_default.SmartCacheProvider.SetUpdated("ProfesionalesRubros");
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
         sMode35 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0S35( ) ;
         Gx_mode = sMode35;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0S35( )
      {
         standaloneModal0S35( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000S45 */
            pr_default.execute(43, new Object[] {A121RubrosId});
            A122RubrosNombre = T000S45_A122RubrosNombre[0];
            A40001RubrosImagen_GXI = T000S45_A40001RubrosImagen_GXI[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_122_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            A123RubrosEstado = T000S45_A123RubrosEstado[0];
            n123RubrosEstado = T000S45_n123RubrosEstado[0];
            A168RubrosImagen = T000S45_A168RubrosImagen[0];
            AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_122_Refreshing);
            AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
            pr_default.close(43);
            /* Using cursor T000S46 */
            pr_default.execute(44, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
            A221EstadosProfRubNomb = T000S46_A221EstadosProfRubNomb[0];
            pr_default.close(44);
         }
      }

      protected void EndLevel0S35( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(8);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0S35( )
      {
         /* Scan By routine */
         /* Using cursor T000S47 */
         pr_default.execute(45, new Object[] {A120ProfesionalesId});
         RcdFound35 = 0;
         if ( (pr_default.getStatus(45) != 101) )
         {
            RcdFound35 = 1;
            A121RubrosId = T000S47_A121RubrosId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0S35( )
      {
         /* Scan next routine */
         pr_default.readNext(45);
         RcdFound35 = 0;
         if ( (pr_default.getStatus(45) != 101) )
         {
            RcdFound35 = 1;
            A121RubrosId = T000S47_A121RubrosId[0];
         }
      }

      protected void ScanEnd0S35( )
      {
         pr_default.close(45);
      }

      protected void AfterConfirm0S35( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S35( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S35( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S35( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S35( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S35( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S35( )
      {
         dynRubrosId.Enabled = 0;
         AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), !bGXsfl_122_Refreshing);
         edtRubrosImagen_Enabled = 0;
         AssignProp("", false, edtRubrosImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRubrosImagen_Enabled), 5, 0), !bGXsfl_122_Refreshing);
         edtEstadosProfRubTipo_Enabled = 0;
         AssignProp("", false, edtEstadosProfRubTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosProfRubTipo_Enabled), 5, 0), !bGXsfl_122_Refreshing);
         cmbEstadosProfRubId.Enabled = 0;
         AssignProp("", false, cmbEstadosProfRubId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEstadosProfRubId.Enabled), 5, 0), !bGXsfl_122_Refreshing);
         cmbRubrosEstado.Enabled = 0;
         AssignProp("", false, cmbRubrosEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRubrosEstado.Enabled), 5, 0), !bGXsfl_122_Refreshing);
      }

      protected void send_integrity_lvl_hashes0S35( )
      {
      }

      protected void ZM0S36( short GX_JID )
      {
         if ( ( GX_JID == 50 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z112DepartamentoId = T000S6_A112DepartamentoId[0];
               Z114DepartamentoMunicipioId = T000S6_A114DepartamentoMunicipioId[0];
               Z110ZonasID = T000S6_A110ZonasID[0];
            }
            else
            {
               Z112DepartamentoId = A112DepartamentoId;
               Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
               Z110ZonasID = A110ZonasID;
            }
         }
         if ( GX_JID == -50 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
            Z126ProfesionalesZonasCorrelativo = A126ProfesionalesZonasCorrelativo;
            Z112DepartamentoId = A112DepartamentoId;
            Z114DepartamentoMunicipioId = A114DepartamentoMunicipioId;
            Z110ZonasID = A110ZonasID;
            Z113DepartamentoDepartamento = A113DepartamentoDepartamento;
            Z116PaisID = A116PaisID;
         }
      }

      protected void standaloneNotModal0S36( )
      {
         edtProfesionalesZonasCorrelativo_Enabled = 0;
         AssignProp("", false, edtProfesionalesZonasCorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0), !bGXsfl_157_Refreshing);
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), !bGXsfl_157_Refreshing);
      }

      protected void standaloneModal0S36( )
      {
         if ( IsIns( )  )
         {
            A197ProfesionalesAutoEnuZona = (short)(O197ProfesionalesAutoEnuZona+1);
            AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A126ProfesionalesZonasCorrelativo = A197ProfesionalesAutoEnuZona;
         }
         else
         {
            if ( IsIns( )  && (0==A126ProfesionalesZonasCorrelativo) && ( Gx_BScreen == 0 ) )
            {
               A126ProfesionalesZonasCorrelativo = 0;
            }
         }
      }

      protected void Load0S36( )
      {
         /* Using cursor T000S48 */
         pr_default.execute(46, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
         if ( (pr_default.getStatus(46) != 101) )
         {
            RcdFound36 = 1;
            A113DepartamentoDepartamento = T000S48_A113DepartamentoDepartamento[0];
            A112DepartamentoId = T000S48_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = T000S48_A114DepartamentoMunicipioId[0];
            A110ZonasID = T000S48_A110ZonasID[0];
            n110ZonasID = T000S48_n110ZonasID[0];
            A116PaisID = T000S48_A116PaisID[0];
            ZM0S36( -50) ;
         }
         pr_default.close(46);
         OnLoadActions0S36( ) ;
      }

      protected void OnLoadActions0S36( )
      {
         GXADEPARTAMENTOMUNICIPIOID_html0S36( A112DepartamentoId) ;
         GXAZONASID_html0S36( A112DepartamentoId, A114DepartamentoMunicipioId) ;
         if ( ( A112DepartamentoId == 1 ) && true /* After */ )
         {
            dynZonasID.Visible = 0;
            AssignProp("", false, dynZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynZonasID.Visible), 5, 0), !bGXsfl_157_Refreshing);
         }
         else
         {
            if ( ( A112DepartamentoId >= 2 ) && true /* After */ )
            {
               dynZonasID.Visible = 1;
               AssignProp("", false, dynZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynZonasID.Visible), 5, 0), !bGXsfl_157_Refreshing);
            }
         }
      }

      protected void CheckExtendedTable0S36( )
      {
         nIsDirty_36 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0S36( ) ;
         /* Using cursor T000S7 */
         pr_default.execute(5, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GXCCtl = "DEPARTAMENTOID_" + sGXsfl_157_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A113DepartamentoDepartamento = T000S7_A113DepartamentoDepartamento[0];
         A116PaisID = T000S7_A116PaisID[0];
         pr_default.close(5);
         /* Using cursor T000S8 */
         pr_default.execute(6, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GXCCtl = "DEPARTAMENTOMUNICIPIOID_" + sGXsfl_157_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
         /* Using cursor T000S9 */
         pr_default.execute(7, new Object[] {n110ZonasID, A110ZonasID, A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A110ZonasID) || (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GXCCtl = "DEPARTAMENTOMUNICIPIOID_" + sGXsfl_157_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Zonas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = dynZonasID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(7);
         GXADEPARTAMENTOMUNICIPIOID_html0S36( A112DepartamentoId) ;
         GXAZONASID_html0S36( A112DepartamentoId, A114DepartamentoMunicipioId) ;
         if ( ( A112DepartamentoId == 1 ) && true /* After */ )
         {
            dynZonasID.Visible = 0;
            AssignProp("", false, dynZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynZonasID.Visible), 5, 0), !bGXsfl_157_Refreshing);
         }
         else
         {
            if ( ( A112DepartamentoId >= 2 ) && true /* After */ )
            {
               dynZonasID.Visible = 1;
               AssignProp("", false, dynZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynZonasID.Visible), 5, 0), !bGXsfl_157_Refreshing);
            }
         }
      }

      protected void CloseExtendedTableCursors0S36( )
      {
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable0S36( )
      {
      }

      protected void gxLoad_51( long A112DepartamentoId )
      {
         /* Using cursor T000S49 */
         pr_default.execute(47, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(47) == 101) )
         {
            GXCCtl = "DEPARTAMENTOID_" + sGXsfl_157_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A113DepartamentoDepartamento = T000S49_A113DepartamentoDepartamento[0];
         A116PaisID = T000S49_A116PaisID[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A113DepartamentoDepartamento))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A116PaisID))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(47) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(47);
      }

      protected void gxLoad_52( long A112DepartamentoId ,
                                long A114DepartamentoMunicipioId )
      {
         /* Using cursor T000S50 */
         pr_default.execute(48, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(48) == 101) )
         {
            GXCCtl = "DEPARTAMENTOMUNICIPIOID_" + sGXsfl_157_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(48) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(48);
      }

      protected void gxLoad_53( long A110ZonasID ,
                                long A112DepartamentoId ,
                                long A114DepartamentoMunicipioId )
      {
         /* Using cursor T000S51 */
         pr_default.execute(49, new Object[] {n110ZonasID, A110ZonasID, A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(49) == 101) )
         {
            if ( ! ( (0==A110ZonasID) || (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GXCCtl = "DEPARTAMENTOMUNICIPIOID_" + sGXsfl_157_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Zonas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = dynZonasID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(49) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(49);
      }

      protected void GetKey0S36( )
      {
         /* Using cursor T000S52 */
         pr_default.execute(50, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
         if ( (pr_default.getStatus(50) != 101) )
         {
            RcdFound36 = 1;
         }
         else
         {
            RcdFound36 = 0;
         }
         pr_default.close(50);
      }

      protected void getByPrimaryKey0S36( )
      {
         /* Using cursor T000S6 */
         pr_default.execute(4, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0S36( 50) ;
            RcdFound36 = 1;
            InitializeNonKey0S36( ) ;
            A126ProfesionalesZonasCorrelativo = T000S6_A126ProfesionalesZonasCorrelativo[0];
            A112DepartamentoId = T000S6_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = T000S6_A114DepartamentoMunicipioId[0];
            A110ZonasID = T000S6_A110ZonasID[0];
            n110ZonasID = T000S6_n110ZonasID[0];
            Z120ProfesionalesId = A120ProfesionalesId;
            Z126ProfesionalesZonasCorrelativo = A126ProfesionalesZonasCorrelativo;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0S36( ) ;
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound36 = 0;
            InitializeNonKey0S36( ) ;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0S36( ) ;
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0S36( ) ;
         }
         pr_default.close(4);
      }

      protected void CheckOptimisticConcurrency0S36( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000S5 */
            pr_default.execute(3, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesZonas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( Z112DepartamentoId != T000S5_A112DepartamentoId[0] ) || ( Z114DepartamentoMunicipioId != T000S5_A114DepartamentoMunicipioId[0] ) || ( Z110ZonasID != T000S5_A110ZonasID[0] ) )
            {
               if ( Z112DepartamentoId != T000S5_A112DepartamentoId[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"DepartamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z112DepartamentoId);
                  GXUtil.WriteLogRaw("Current: ",T000S5_A112DepartamentoId[0]);
               }
               if ( Z114DepartamentoMunicipioId != T000S5_A114DepartamentoMunicipioId[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"DepartamentoMunicipioId");
                  GXUtil.WriteLogRaw("Old: ",Z114DepartamentoMunicipioId);
                  GXUtil.WriteLogRaw("Current: ",T000S5_A114DepartamentoMunicipioId[0]);
               }
               if ( Z110ZonasID != T000S5_A110ZonasID[0] )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"ZonasID");
                  GXUtil.WriteLogRaw("Old: ",Z110ZonasID);
                  GXUtil.WriteLogRaw("Current: ",T000S5_A110ZonasID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProfesionalesZonas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S36( )
      {
         BeforeValidate0S36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S36( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S36( 0) ;
            CheckOptimisticConcurrency0S36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S53 */
                     pr_default.execute(51, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo, A112DepartamentoId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID});
                     pr_default.close(51);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesZonas");
                     if ( (pr_default.getStatus(51) == 1) )
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
               Load0S36( ) ;
            }
            EndLevel0S36( ) ;
         }
         CloseExtendedTableCursors0S36( ) ;
      }

      protected void Update0S36( )
      {
         BeforeValidate0S36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S36( ) ;
         }
         if ( ( nIsMod_36 != 0 ) || ( nIsDirty_36 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0S36( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0S36( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0S36( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000S54 */
                        pr_default.execute(52, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID, A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
                        pr_default.close(52);
                        pr_default.SmartCacheProvider.SetUpdated("ProfesionalesZonas");
                        if ( (pr_default.getStatus(52) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesZonas"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0S36( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0S36( ) ;
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
               EndLevel0S36( ) ;
            }
         }
         CloseExtendedTableCursors0S36( ) ;
      }

      protected void DeferredUpdate0S36( )
      {
      }

      protected void Delete0S36( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0S36( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S36( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S36( ) ;
            AfterConfirm0S36( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S36( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000S55 */
                  pr_default.execute(53, new Object[] {A120ProfesionalesId, A126ProfesionalesZonasCorrelativo});
                  pr_default.close(53);
                  pr_default.SmartCacheProvider.SetUpdated("ProfesionalesZonas");
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
         sMode36 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0S36( ) ;
         Gx_mode = sMode36;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0S36( )
      {
         standaloneModal0S36( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000S56 */
            pr_default.execute(54, new Object[] {A112DepartamentoId});
            A113DepartamentoDepartamento = T000S56_A113DepartamentoDepartamento[0];
            A116PaisID = T000S56_A116PaisID[0];
            pr_default.close(54);
            GXADEPARTAMENTOMUNICIPIOID_html0S36( A112DepartamentoId) ;
            if ( ( A112DepartamentoId == 1 ) && true /* After */ )
            {
               dynZonasID.Visible = 0;
               AssignProp("", false, dynZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynZonasID.Visible), 5, 0), !bGXsfl_157_Refreshing);
            }
            else
            {
               if ( ( A112DepartamentoId >= 2 ) && true /* After */ )
               {
                  dynZonasID.Visible = 1;
                  AssignProp("", false, dynZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynZonasID.Visible), 5, 0), !bGXsfl_157_Refreshing);
               }
            }
            GXAZONASID_html0S36( A112DepartamentoId, A114DepartamentoMunicipioId) ;
         }
      }

      protected void EndLevel0S36( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0S36( )
      {
         /* Scan By routine */
         /* Using cursor T000S57 */
         pr_default.execute(55, new Object[] {A120ProfesionalesId});
         RcdFound36 = 0;
         if ( (pr_default.getStatus(55) != 101) )
         {
            RcdFound36 = 1;
            A126ProfesionalesZonasCorrelativo = T000S57_A126ProfesionalesZonasCorrelativo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0S36( )
      {
         /* Scan next routine */
         pr_default.readNext(55);
         RcdFound36 = 0;
         if ( (pr_default.getStatus(55) != 101) )
         {
            RcdFound36 = 1;
            A126ProfesionalesZonasCorrelativo = T000S57_A126ProfesionalesZonasCorrelativo[0];
         }
      }

      protected void ScanEnd0S36( )
      {
         pr_default.close(55);
      }

      protected void AfterConfirm0S36( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S36( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S36( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S36( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S36( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S36( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S36( )
      {
         edtProfesionalesZonasCorrelativo_Enabled = 0;
         AssignProp("", false, edtProfesionalesZonasCorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0), !bGXsfl_157_Refreshing);
         edtPaisID_Enabled = 0;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), !bGXsfl_157_Refreshing);
         dynDepartamentoId.Enabled = 0;
         AssignProp("", false, dynDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoId.Enabled), 5, 0), !bGXsfl_157_Refreshing);
         dynDepartamentoMunicipioId.Enabled = 0;
         AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0), !bGXsfl_157_Refreshing);
         dynZonasID.Enabled = 0;
         AssignProp("", false, dynZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynZonasID.Enabled), 5, 0), !bGXsfl_157_Refreshing);
      }

      protected void send_integrity_lvl_hashes0S36( )
      {
      }

      protected void ZM0S145( short GX_JID )
      {
         if ( ( GX_JID == 54 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z995EstadoServProf = T000S3_A995EstadoServProf[0];
            }
            else
            {
               Z995EstadoServProf = A995EstadoServProf;
            }
         }
         if ( GX_JID == -54 )
         {
            Z120ProfesionalesId = A120ProfesionalesId;
            Z995EstadoServProf = A995EstadoServProf;
            Z993ProfesionalServicioId = A993ProfesionalServicioId;
            Z994ProfesionalServicioNombre = A994ProfesionalServicioNombre;
         }
      }

      protected void standaloneNotModal0S145( )
      {
      }

      protected void standaloneModal0S145( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProfesionalServicioId_Enabled = 0;
            AssignProp("", false, edtProfesionalServicioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalServicioId_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         }
         else
         {
            edtProfesionalServicioId_Enabled = 1;
            AssignProp("", false, edtProfesionalServicioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalServicioId_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         }
      }

      protected void Load0S145( )
      {
         /* Using cursor T000S58 */
         pr_default.execute(56, new Object[] {A120ProfesionalesId, A993ProfesionalServicioId});
         if ( (pr_default.getStatus(56) != 101) )
         {
            RcdFound145 = 1;
            A994ProfesionalServicioNombre = T000S58_A994ProfesionalServicioNombre[0];
            A995EstadoServProf = T000S58_A995EstadoServProf[0];
            n995EstadoServProf = T000S58_n995EstadoServProf[0];
            ZM0S145( -54) ;
         }
         pr_default.close(56);
         OnLoadActions0S145( ) ;
      }

      protected void OnLoadActions0S145( )
      {
      }

      protected void CheckExtendedTable0S145( )
      {
         nIsDirty_145 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0S145( ) ;
         /* Using cursor T000S4 */
         pr_default.execute(2, new Object[] {A993ProfesionalServicioId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PROFESIONALSERVICIOID_" + sGXsfl_143_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesional Servicios Brindados", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalServicioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A994ProfesionalServicioNombre = T000S4_A994ProfesionalServicioNombre[0];
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A995EstadoServProf, "HAB") == 0 ) || ( StringUtil.StrCmp(A995EstadoServProf, "DES") == 0 ) || ( StringUtil.StrCmp(A995EstadoServProf, "PEN") == 0 ) || ( StringUtil.StrCmp(A995EstadoServProf, "BLO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A995EstadoServProf)) ) )
         {
            GXCCtl = "ESTADOSERVPROF_" + sGXsfl_143_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Estado vinculo servicio profesional", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbEstadoServProf_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0S145( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0S145( )
      {
      }

      protected void gxLoad_55( long A993ProfesionalServicioId )
      {
         /* Using cursor T000S59 */
         pr_default.execute(57, new Object[] {A993ProfesionalServicioId});
         if ( (pr_default.getStatus(57) == 101) )
         {
            GXCCtl = "PROFESIONALSERVICIOID_" + sGXsfl_143_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesional Servicios Brindados", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalServicioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A994ProfesionalServicioNombre = T000S59_A994ProfesionalServicioNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A994ProfesionalServicioNombre))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(57) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(57);
      }

      protected void GetKey0S145( )
      {
         /* Using cursor T000S60 */
         pr_default.execute(58, new Object[] {A120ProfesionalesId, A993ProfesionalServicioId});
         if ( (pr_default.getStatus(58) != 101) )
         {
            RcdFound145 = 1;
         }
         else
         {
            RcdFound145 = 0;
         }
         pr_default.close(58);
      }

      protected void getByPrimaryKey0S145( )
      {
         /* Using cursor T000S3 */
         pr_default.execute(1, new Object[] {A120ProfesionalesId, A993ProfesionalServicioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0S145( 54) ;
            RcdFound145 = 1;
            InitializeNonKey0S145( ) ;
            A995EstadoServProf = T000S3_A995EstadoServProf[0];
            n995EstadoServProf = T000S3_n995EstadoServProf[0];
            A993ProfesionalServicioId = T000S3_A993ProfesionalServicioId[0];
            Z120ProfesionalesId = A120ProfesionalesId;
            Z993ProfesionalServicioId = A993ProfesionalServicioId;
            sMode145 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0S145( ) ;
            Gx_mode = sMode145;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound145 = 0;
            InitializeNonKey0S145( ) ;
            sMode145 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0S145( ) ;
            Gx_mode = sMode145;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0S145( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0S145( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000S2 */
            pr_default.execute(0, new Object[] {A120ProfesionalesId, A993ProfesionalServicioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesServicios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z995EstadoServProf, T000S2_A995EstadoServProf[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z995EstadoServProf, T000S2_A995EstadoServProf[0]) != 0 )
               {
                  GXUtil.WriteLog("profesionales:[seudo value changed for attri]"+"EstadoServProf");
                  GXUtil.WriteLogRaw("Old: ",Z995EstadoServProf);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A995EstadoServProf[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProfesionalesServicios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S145( )
      {
         BeforeValidate0S145( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S145( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S145( 0) ;
            CheckOptimisticConcurrency0S145( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S145( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S145( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S61 */
                     pr_default.execute(59, new Object[] {A120ProfesionalesId, n995EstadoServProf, A995EstadoServProf, A993ProfesionalServicioId});
                     pr_default.close(59);
                     pr_default.SmartCacheProvider.SetUpdated("ProfesionalesServicios");
                     if ( (pr_default.getStatus(59) == 1) )
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
               Load0S145( ) ;
            }
            EndLevel0S145( ) ;
         }
         CloseExtendedTableCursors0S145( ) ;
      }

      protected void Update0S145( )
      {
         BeforeValidate0S145( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S145( ) ;
         }
         if ( ( nIsMod_145 != 0 ) || ( nIsDirty_145 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0S145( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0S145( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0S145( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000S62 */
                        pr_default.execute(60, new Object[] {n995EstadoServProf, A995EstadoServProf, A120ProfesionalesId, A993ProfesionalServicioId});
                        pr_default.close(60);
                        pr_default.SmartCacheProvider.SetUpdated("ProfesionalesServicios");
                        if ( (pr_default.getStatus(60) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProfesionalesServicios"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0S145( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0S145( ) ;
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
               EndLevel0S145( ) ;
            }
         }
         CloseExtendedTableCursors0S145( ) ;
      }

      protected void DeferredUpdate0S145( )
      {
      }

      protected void Delete0S145( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0S145( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S145( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S145( ) ;
            AfterConfirm0S145( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S145( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000S63 */
                  pr_default.execute(61, new Object[] {A120ProfesionalesId, A993ProfesionalServicioId});
                  pr_default.close(61);
                  pr_default.SmartCacheProvider.SetUpdated("ProfesionalesServicios");
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
         sMode145 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0S145( ) ;
         Gx_mode = sMode145;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0S145( )
      {
         standaloneModal0S145( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000S64 */
            pr_default.execute(62, new Object[] {A993ProfesionalServicioId});
            A994ProfesionalServicioNombre = T000S64_A994ProfesionalServicioNombre[0];
            pr_default.close(62);
         }
      }

      protected void EndLevel0S145( )
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

      public void ScanStart0S145( )
      {
         /* Scan By routine */
         /* Using cursor T000S65 */
         pr_default.execute(63, new Object[] {A120ProfesionalesId});
         RcdFound145 = 0;
         if ( (pr_default.getStatus(63) != 101) )
         {
            RcdFound145 = 1;
            A993ProfesionalServicioId = T000S65_A993ProfesionalServicioId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0S145( )
      {
         /* Scan next routine */
         pr_default.readNext(63);
         RcdFound145 = 0;
         if ( (pr_default.getStatus(63) != 101) )
         {
            RcdFound145 = 1;
            A993ProfesionalServicioId = T000S65_A993ProfesionalServicioId[0];
         }
      }

      protected void ScanEnd0S145( )
      {
         pr_default.close(63);
      }

      protected void AfterConfirm0S145( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S145( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S145( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S145( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S145( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S145( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S145( )
      {
         edtProfesionalServicioId_Enabled = 0;
         AssignProp("", false, edtProfesionalServicioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalServicioId_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         edtProfesionalServicioNombre_Enabled = 0;
         AssignProp("", false, edtProfesionalServicioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalServicioNombre_Enabled), 5, 0), !bGXsfl_143_Refreshing);
         cmbEstadoServProf.Enabled = 0;
         AssignProp("", false, cmbEstadoServProf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEstadoServProf.Enabled), 5, 0), !bGXsfl_143_Refreshing);
      }

      protected void send_integrity_lvl_hashes0S145( )
      {
      }

      protected void send_integrity_lvl_hashes0S34( )
      {
      }

      protected void SubsflControlProps_12235( )
      {
         dynRubrosId_Internalname = "RUBROSID_"+sGXsfl_122_idx;
         edtRubrosImagen_Internalname = "RUBROSIMAGEN_"+sGXsfl_122_idx;
         edtEstadosProfRubTipo_Internalname = "ESTADOSPROFRUBTIPO_"+sGXsfl_122_idx;
         cmbEstadosProfRubId_Internalname = "ESTADOSPROFRUBID_"+sGXsfl_122_idx;
         imgprompt_125_Internalname = "PROMPT_125_"+sGXsfl_122_idx;
         cmbRubrosEstado_Internalname = "RUBROSESTADO_"+sGXsfl_122_idx;
      }

      protected void SubsflControlProps_fel_12235( )
      {
         dynRubrosId_Internalname = "RUBROSID_"+sGXsfl_122_fel_idx;
         edtRubrosImagen_Internalname = "RUBROSIMAGEN_"+sGXsfl_122_fel_idx;
         edtEstadosProfRubTipo_Internalname = "ESTADOSPROFRUBTIPO_"+sGXsfl_122_fel_idx;
         cmbEstadosProfRubId_Internalname = "ESTADOSPROFRUBID_"+sGXsfl_122_fel_idx;
         imgprompt_125_Internalname = "PROMPT_125_"+sGXsfl_122_fel_idx;
         cmbRubrosEstado_Internalname = "RUBROSESTADO_"+sGXsfl_122_fel_idx;
      }

      protected void AddRow0S35( )
      {
         nGXsfl_122_idx = (int)(nGXsfl_122_idx+1);
         sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx), 4, 0), 4, "0");
         SubsflControlProps_12235( ) ;
         SendRow0S35( ) ;
      }

      protected void SendRow0S35( )
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
            if ( ((int)((nGXsfl_122_idx) % (2))) == 0 )
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
         imgprompt_125_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00o1.aspx"+"',["+"'"+GXUtil.ValueEncode( StringUtil.StringReplace( StringUtil.RTrim( A124EstadosProfRubTipo), "'", "\\'"))+"'"+","+"{Ctrl:gx.dom.el('"+"ESTADOSPROFRUBID_"+sGXsfl_122_idx+"'), id:'"+"ESTADOSPROFRUBID_"+sGXsfl_122_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_35_"+sGXsfl_122_idx+","+"'', false"+","+"false"+");");
         GXARUBROSID_html0S35( ) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_35_" + sGXsfl_122_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_122_idx + "',122)\"";
         GXCCtl = "RUBROSID_" + sGXsfl_122_idx;
         dynRubrosId.Name = GXCCtl;
         dynRubrosId.WebTags = "";
         /* ComboBox */
         Gridlevel_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynRubrosId,(string)dynRubrosId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0)),(short)1,(string)dynRubrosId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynRubrosId.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"",(string)"",(bool)true,(short)0});
         dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
         AssignProp("", false, dynRubrosId_Internalname, "Values", (string)(dynRubrosId.ToJavascriptSource()), !bGXsfl_122_Refreshing);
         /* Subfile cell */
         /* Static Bitmap Variable */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_35_" + sGXsfl_122_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 124,'',false,'" + sGXsfl_122_idx + "',122)\"";
         ClassString = "Attribute";
         StyleString = "";
         A168RubrosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001RubrosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen));
         Gridlevel_rubrosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtRubrosImagen_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"",(string)"",(string)"",(string)"",(short)0,(bool)A168RubrosImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
         AssignProp("", false, edtRubrosImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.PathToRelativeUrl( A168RubrosImagen)), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A168RubrosImagen_IsBlob), !bGXsfl_122_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_rubrosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosProfRubTipo_Internalname,StringUtil.RTrim( A124EstadosProfRubTipo),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosProfRubTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtEstadosProfRubTipo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)122,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_35_" + sGXsfl_122_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 126,'',false,'" + sGXsfl_122_idx + "',122)\"";
         GXCCtl = "ESTADOSPROFRUBID_" + sGXsfl_122_idx;
         cmbEstadosProfRubId.Name = GXCCtl;
         cmbEstadosProfRubId.WebTags = "";
         cmbEstadosProfRubId.addItem("1", context.GetMessage( "Habilitado", ""), 0);
         cmbEstadosProfRubId.addItem("2", context.GetMessage( "Deshabilitado", ""), 0);
         cmbEstadosProfRubId.addItem("3", context.GetMessage( "Pendiente", ""), 0);
         if ( cmbEstadosProfRubId.ItemCount > 0 )
         {
            A125EstadosProfRubId = (int)(Math.Round(NumberUtil.Val( cmbEstadosProfRubId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A125EstadosProfRubId), 5, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* ComboBox */
         Gridlevel_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbEstadosProfRubId,(string)cmbEstadosProfRubId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A125EstadosProfRubId), 5, 0)),(short)1,(string)cmbEstadosProfRubId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbEstadosProfRubId.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"",(string)"",(bool)true,(short)0});
         cmbEstadosProfRubId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A125EstadosProfRubId), 5, 0));
         AssignProp("", false, cmbEstadosProfRubId_Internalname, "Values", (string)(cmbEstadosProfRubId.ToJavascriptSource()), !bGXsfl_122_Refreshing);
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_125_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_125_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_rubrosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_125_Internalname,(string)sImgUrl,(string)imgprompt_125_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_125_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_35_" + sGXsfl_122_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_122_idx + "',122)\"";
         GXCCtl = "RUBROSESTADO_" + sGXsfl_122_idx;
         cmbRubrosEstado.Name = GXCCtl;
         cmbRubrosEstado.WebTags = "";
         cmbRubrosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbRubrosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbRubrosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbRubrosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbRubrosEstado.ItemCount > 0 )
         {
            A123RubrosEstado = cmbRubrosEstado.getValidValue(A123RubrosEstado);
            n123RubrosEstado = false;
         }
         /* ComboBox */
         Gridlevel_rubrosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbRubrosEstado,(string)cmbRubrosEstado_Internalname,StringUtil.RTrim( A123RubrosEstado),(short)1,(string)cmbRubrosEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbRubrosEstado.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"",(string)"",(bool)true,(short)0});
         cmbRubrosEstado.CurrentValue = StringUtil.RTrim( A123RubrosEstado);
         AssignProp("", false, cmbRubrosEstado_Internalname, "Values", (string)(cmbRubrosEstado.ToJavascriptSource()), !bGXsfl_122_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_rubrosRow);
         send_integrity_lvl_hashes0S35( ) ;
         GXCCtl = "Z121RubrosId_" + sGXsfl_122_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z124EstadosProfRubTipo_" + sGXsfl_122_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z124EstadosProfRubTipo));
         GXCCtl = "Z125EstadosProfRubId_" + sGXsfl_122_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125EstadosProfRubId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_35_" + sGXsfl_122_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_35), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_35_" + sGXsfl_122_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_35), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_35_" + sGXsfl_122_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_35), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_122_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_122_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPROFESIONALESID_" + sGXsfl_122_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV7ProfesionalesId));
         GXCCtl = "RUBROSIMAGEN_" + sGXsfl_122_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A168RubrosImagen);
         GxWebStd.gx_hidden_field( context, "RUBROSID_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynRubrosId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RUBROSIMAGEN_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSPROFRUBTIPO_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosProfRubTipo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSPROFRUBID_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbEstadosProfRubId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "RUBROSESTADO_"+sGXsfl_122_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbRubrosEstado.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_125_"+sGXsfl_122_idx+"Link", StringUtil.RTrim( imgprompt_125_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_rubrosContainer.AddRow(Gridlevel_rubrosRow);
      }

      protected void ReadRow0S35( )
      {
         nGXsfl_122_idx = (int)(nGXsfl_122_idx+1);
         sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx), 4, 0), 4, "0");
         SubsflControlProps_12235( ) ;
         dynRubrosId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSID_"+sGXsfl_122_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtRubrosImagen_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSIMAGEN_"+sGXsfl_122_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtEstadosProfRubTipo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSPROFRUBTIPO_"+sGXsfl_122_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbEstadosProfRubId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSPROFRUBID_"+sGXsfl_122_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbRubrosEstado.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RUBROSESTADO_"+sGXsfl_122_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_125_Link = cgiGet( "PROMPT_125_"+sGXsfl_122_idx+"Link");
         dynRubrosId.Name = dynRubrosId_Internalname;
         dynRubrosId.CurrentValue = cgiGet( dynRubrosId_Internalname);
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynRubrosId_Internalname), "."), 18, MidpointRounding.ToEven));
         A168RubrosImagen = cgiGet( edtRubrosImagen_Internalname);
         A124EstadosProfRubTipo = cgiGet( edtEstadosProfRubTipo_Internalname);
         cmbEstadosProfRubId.Name = cmbEstadosProfRubId_Internalname;
         cmbEstadosProfRubId.CurrentValue = cgiGet( cmbEstadosProfRubId_Internalname);
         A125EstadosProfRubId = (int)(Math.Round(NumberUtil.Val( cgiGet( cmbEstadosProfRubId_Internalname), "."), 18, MidpointRounding.ToEven));
         cmbRubrosEstado.Name = cmbRubrosEstado_Internalname;
         cmbRubrosEstado.CurrentValue = cgiGet( cmbRubrosEstado_Internalname);
         A123RubrosEstado = cgiGet( cmbRubrosEstado_Internalname);
         n123RubrosEstado = false;
         GXCCtl = "Z121RubrosId_" + sGXsfl_122_idx;
         Z121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z124EstadosProfRubTipo_" + sGXsfl_122_idx;
         Z124EstadosProfRubTipo = cgiGet( GXCCtl);
         GXCCtl = "Z125EstadosProfRubId_" + sGXsfl_122_idx;
         Z125EstadosProfRubId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_35_" + sGXsfl_122_idx;
         nRcdDeleted_35 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_35_" + sGXsfl_122_idx;
         nRcdExists_35 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_35_" + sGXsfl_122_idx;
         nIsMod_35 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         getMultimediaValue(edtRubrosImagen_Internalname, ref  A168RubrosImagen, ref  A40001RubrosImagen_GXI);
      }

      protected void SubsflControlProps_15736( )
      {
         edtProfesionalesZonasCorrelativo_Internalname = "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_157_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_157_idx;
         dynDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_157_idx;
         dynDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_157_idx;
         dynZonasID_Internalname = "ZONASID_"+sGXsfl_157_idx;
      }

      protected void SubsflControlProps_fel_15736( )
      {
         edtProfesionalesZonasCorrelativo_Internalname = "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_157_fel_idx;
         edtPaisID_Internalname = "PAISID_"+sGXsfl_157_fel_idx;
         dynDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_157_fel_idx;
         dynDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_157_fel_idx;
         dynZonasID_Internalname = "ZONASID_"+sGXsfl_157_fel_idx;
      }

      protected void AddRow0S36( )
      {
         nGXsfl_157_idx = (int)(nGXsfl_157_idx+1);
         sGXsfl_157_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_157_idx), 4, 0), 4, "0");
         SubsflControlProps_15736( ) ;
         SendRow0S36( ) ;
      }

      protected void SendRow0S36( )
      {
         Gridlevel_zonasRow = GXWebRow.GetNew(context);
         if ( subGridlevel_zonas_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_zonas_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_zonas_Class, "") != 0 )
            {
               subGridlevel_zonas_Linesclass = subGridlevel_zonas_Class+"Odd";
            }
         }
         else if ( subGridlevel_zonas_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_zonas_Backstyle = 0;
            subGridlevel_zonas_Backcolor = subGridlevel_zonas_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_zonas_Class, "") != 0 )
            {
               subGridlevel_zonas_Linesclass = subGridlevel_zonas_Class+"Uniform";
            }
         }
         else if ( subGridlevel_zonas_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_zonas_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_zonas_Class, "") != 0 )
            {
               subGridlevel_zonas_Linesclass = subGridlevel_zonas_Class+"Odd";
            }
            subGridlevel_zonas_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_zonas_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_zonas_Backstyle = 1;
            if ( ((int)((nGXsfl_157_idx) % (2))) == 0 )
            {
               subGridlevel_zonas_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_zonas_Class, "") != 0 )
               {
                  subGridlevel_zonas_Linesclass = subGridlevel_zonas_Class+"Even";
               }
            }
            else
            {
               subGridlevel_zonas_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_zonas_Class, "") != 0 )
               {
                  subGridlevel_zonas_Linesclass = subGridlevel_zonas_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_36_" + sGXsfl_157_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 158,'',false,'" + sGXsfl_157_idx + "',157)\"";
         ROClassString = "Attribute";
         Gridlevel_zonasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesZonasCorrelativo_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A126ProfesionalesZonasCorrelativo), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtProfesionalesZonasCorrelativo_Enabled!=0) ? context.localUtil.Format( (decimal)(A126ProfesionalesZonasCorrelativo), "ZZZ9") : context.localUtil.Format( (decimal)(A126ProfesionalesZonasCorrelativo), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,158);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesZonasCorrelativo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalesZonasCorrelativo_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)157,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_zonasRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaisID_Internalname,StringUtil.RTrim( A116PaisID),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaisID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtPaisID_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2,(short)0,(short)0,(short)157,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_36_" + sGXsfl_157_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 160,'',false,'" + sGXsfl_157_idx + "',157)\"";
         if ( ( dynDepartamentoId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "DEPARTAMENTOID_" + sGXsfl_157_idx;
            dynDepartamentoId.Name = GXCCtl;
            dynDepartamentoId.WebTags = "";
            dynDepartamentoId.removeAllItems();
            /* Using cursor T000S66 */
            pr_default.execute(64);
            while ( (pr_default.getStatus(64) != 101) )
            {
               dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000S66_A112DepartamentoId[0]), 18, 0)), T000S66_A113DepartamentoDepartamento[0], 0);
               pr_default.readNext(64);
            }
            pr_default.close(64);
            if ( dynDepartamentoId.ItemCount > 0 )
            {
               A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
            }
         }
         /* ComboBox */
         Gridlevel_zonasRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynDepartamentoId,(string)dynDepartamentoId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0)),(short)1,(string)dynDepartamentoId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynDepartamentoId.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,160);\"",(string)"",(bool)true,(short)0});
         dynDepartamentoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0));
         AssignProp("", false, dynDepartamentoId_Internalname, "Values", (string)(dynDepartamentoId.ToJavascriptSource()), !bGXsfl_157_Refreshing);
         GXADEPARTAMENTOMUNICIPIOID_html0S36( A112DepartamentoId) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_36_" + sGXsfl_157_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 161,'',false,'" + sGXsfl_157_idx + "',157)\"";
         if ( ( dynDepartamentoMunicipioId.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "DEPARTAMENTOMUNICIPIOID_" + sGXsfl_157_idx;
            dynDepartamentoMunicipioId.Name = GXCCtl;
            dynDepartamentoMunicipioId.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_zonasRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynDepartamentoMunicipioId,(string)dynDepartamentoMunicipioId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0)),(short)1,(string)dynDepartamentoMunicipioId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynDepartamentoMunicipioId.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"",(string)"",(bool)true,(short)0});
         dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Values", (string)(dynDepartamentoMunicipioId.ToJavascriptSource()), !bGXsfl_157_Refreshing);
         GXAZONASID_html0S36( A112DepartamentoId, A114DepartamentoMunicipioId) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_36_" + sGXsfl_157_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 162,'',false,'" + sGXsfl_157_idx + "',157)\"";
         if ( ( dynZonasID.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "ZONASID_" + sGXsfl_157_idx;
            dynZonasID.Name = GXCCtl;
            dynZonasID.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_zonasRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynZonasID,(string)dynZonasID_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0)),(short)1,(string)dynZonasID_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",dynZonasID.Visible,dynZonasID.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,162);\"",(string)"",(bool)true,(short)0});
         dynZonasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0));
         AssignProp("", false, dynZonasID_Internalname, "Values", (string)(dynZonasID.ToJavascriptSource()), !bGXsfl_157_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_zonasRow);
         send_integrity_lvl_hashes0S36( ) ;
         GXCCtl = "Z126ProfesionalesZonasCorrelativo_" + sGXsfl_157_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126ProfesionalesZonasCorrelativo), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z112DepartamentoId_" + sGXsfl_157_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z114DepartamentoMunicipioId_" + sGXsfl_157_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z110ZonasID_" + sGXsfl_157_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_36_" + sGXsfl_157_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_36), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_36_" + sGXsfl_157_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_36), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_36_" + sGXsfl_157_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_36), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_157_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_157_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPROFESIONALESID_" + sGXsfl_157_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV7ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAISID_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaisID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOID_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynDepartamentoId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ZONASID_"+sGXsfl_157_idx+"Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynZonasID.Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ZONASID_"+sGXsfl_157_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynZonasID.Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_zonasContainer.AddRow(Gridlevel_zonasRow);
      }

      protected void ReadRow0S36( )
      {
         nGXsfl_157_idx = (int)(nGXsfl_157_idx+1);
         sGXsfl_157_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_157_idx), 4, 0), 4, "0");
         SubsflControlProps_15736( ) ;
         edtProfesionalesZonasCorrelativo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALESZONASCORRELATIVO_"+sGXsfl_157_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtPaisID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAISID_"+sGXsfl_157_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynDepartamentoId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOID_"+sGXsfl_157_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynDepartamentoMunicipioId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DEPARTAMENTOMUNICIPIOID_"+sGXsfl_157_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynZonasID.Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ZONASID_"+sGXsfl_157_idx+"Visible"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         dynZonasID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ZONASID_"+sGXsfl_157_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A126ProfesionalesZonasCorrelativo = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalesZonasCorrelativo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A116PaisID = cgiGet( edtPaisID_Internalname);
         dynDepartamentoId.Name = dynDepartamentoId_Internalname;
         dynDepartamentoId.CurrentValue = cgiGet( dynDepartamentoId_Internalname);
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynDepartamentoId_Internalname), "."), 18, MidpointRounding.ToEven));
         dynDepartamentoMunicipioId.Name = dynDepartamentoMunicipioId_Internalname;
         dynDepartamentoMunicipioId.CurrentValue = cgiGet( dynDepartamentoMunicipioId_Internalname);
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynDepartamentoMunicipioId_Internalname), "."), 18, MidpointRounding.ToEven));
         dynZonasID.Name = dynZonasID_Internalname;
         dynZonasID.CurrentValue = cgiGet( dynZonasID_Internalname);
         A110ZonasID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynZonasID_Internalname), "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         n110ZonasID = ((0==A110ZonasID) ? true : false);
         GXCCtl = "Z126ProfesionalesZonasCorrelativo_" + sGXsfl_157_idx;
         Z126ProfesionalesZonasCorrelativo = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z112DepartamentoId_" + sGXsfl_157_idx;
         Z112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z114DepartamentoMunicipioId_" + sGXsfl_157_idx;
         Z114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z110ZonasID_" + sGXsfl_157_idx;
         Z110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n110ZonasID = ((0==A110ZonasID) ? true : false);
         GXCCtl = "nRcdDeleted_36_" + sGXsfl_157_idx;
         nRcdDeleted_36 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_36_" + sGXsfl_157_idx;
         nRcdExists_36 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_36_" + sGXsfl_157_idx;
         nIsMod_36 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_143145( )
      {
         edtProfesionalServicioId_Internalname = "PROFESIONALSERVICIOID_"+sGXsfl_143_idx;
         imgprompt_993_Internalname = "PROMPT_993_"+sGXsfl_143_idx;
         edtProfesionalServicioNombre_Internalname = "PROFESIONALSERVICIONOMBRE_"+sGXsfl_143_idx;
         cmbEstadoServProf_Internalname = "ESTADOSERVPROF_"+sGXsfl_143_idx;
      }

      protected void SubsflControlProps_fel_143145( )
      {
         edtProfesionalServicioId_Internalname = "PROFESIONALSERVICIOID_"+sGXsfl_143_fel_idx;
         imgprompt_993_Internalname = "PROMPT_993_"+sGXsfl_143_fel_idx;
         edtProfesionalServicioNombre_Internalname = "PROFESIONALSERVICIONOMBRE_"+sGXsfl_143_fel_idx;
         cmbEstadoServProf_Internalname = "ESTADOSERVPROF_"+sGXsfl_143_fel_idx;
      }

      protected void AddRow0S145( )
      {
         nGXsfl_143_idx = (int)(nGXsfl_143_idx+1);
         sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0");
         SubsflControlProps_143145( ) ;
         SendRow0S145( ) ;
      }

      protected void SendRow0S145( )
      {
         Gridlevel_serviciosRow = GXWebRow.GetNew(context);
         if ( subGridlevel_servicios_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_servicios_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_servicios_Class, "") != 0 )
            {
               subGridlevel_servicios_Linesclass = subGridlevel_servicios_Class+"Odd";
            }
         }
         else if ( subGridlevel_servicios_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_servicios_Backstyle = 0;
            subGridlevel_servicios_Backcolor = subGridlevel_servicios_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_servicios_Class, "") != 0 )
            {
               subGridlevel_servicios_Linesclass = subGridlevel_servicios_Class+"Uniform";
            }
         }
         else if ( subGridlevel_servicios_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_servicios_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_servicios_Class, "") != 0 )
            {
               subGridlevel_servicios_Linesclass = subGridlevel_servicios_Class+"Odd";
            }
            subGridlevel_servicios_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_servicios_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_servicios_Backstyle = 1;
            if ( ((int)((nGXsfl_143_idx) % (2))) == 0 )
            {
               subGridlevel_servicios_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_servicios_Class, "") != 0 )
               {
                  subGridlevel_servicios_Linesclass = subGridlevel_servicios_Class+"Even";
               }
            }
            else
            {
               subGridlevel_servicios_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_servicios_Class, "") != 0 )
               {
                  subGridlevel_servicios_Linesclass = subGridlevel_servicios_Class+"Odd";
               }
            }
         }
         imgprompt_993_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"serviciosprompt.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PROFESIONALSERVICIOID_"+sGXsfl_143_idx+"'), id:'"+"PROFESIONALSERVICIOID_"+sGXsfl_143_idx+"'"+",IOType:'inout'}"+","+"{Ctrl:gx.dom.el('"+"PROFESIONALSERVICIONOMBRE_"+sGXsfl_143_idx+"'), id:'"+"PROFESIONALSERVICIONOMBRE_"+sGXsfl_143_idx+"'"+",IOType:'inout'}"+"],"+"gx.dom.form()."+"nIsMod_145_"+sGXsfl_143_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_145_" + sGXsfl_143_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 144,'',false,'" + sGXsfl_143_idx + "',143)\"";
         ROClassString = "Attribute";
         Gridlevel_serviciosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalServicioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A993ProfesionalServicioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A993ProfesionalServicioId), "ZZZZZZZZZZZZZZZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,144);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalServicioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalServicioId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_993_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_993_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         Gridlevel_serviciosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_993_Internalname,(string)sImgUrl,(string)imgprompt_993_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_993_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"''"});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_145_" + sGXsfl_143_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 145,'',false,'" + sGXsfl_143_idx + "',143)\"";
         ROClassString = "Attribute";
         Gridlevel_serviciosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalServicioNombre_Internalname,StringUtil.RTrim( A994ProfesionalServicioNombre),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,145);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalServicioNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtProfesionalServicioNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)143,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_145_" + sGXsfl_143_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 146,'',false,'" + sGXsfl_143_idx + "',143)\"";
         if ( ( cmbEstadoServProf.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "ESTADOSERVPROF_" + sGXsfl_143_idx;
            cmbEstadoServProf.Name = GXCCtl;
            cmbEstadoServProf.WebTags = "";
            cmbEstadoServProf.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
            cmbEstadoServProf.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
            cmbEstadoServProf.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
            cmbEstadoServProf.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
            if ( cmbEstadoServProf.ItemCount > 0 )
            {
               A995EstadoServProf = cmbEstadoServProf.getValidValue(A995EstadoServProf);
               n995EstadoServProf = false;
            }
         }
         /* ComboBox */
         Gridlevel_serviciosRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbEstadoServProf,(string)cmbEstadoServProf_Internalname,StringUtil.RTrim( A995EstadoServProf),(short)1,(string)cmbEstadoServProf_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbEstadoServProf.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"",(string)"",(bool)true,(short)0});
         cmbEstadoServProf.CurrentValue = StringUtil.RTrim( A995EstadoServProf);
         AssignProp("", false, cmbEstadoServProf_Internalname, "Values", (string)(cmbEstadoServProf.ToJavascriptSource()), !bGXsfl_143_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_serviciosRow);
         send_integrity_lvl_hashes0S145( ) ;
         GXCCtl = "Z993ProfesionalServicioId_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z993ProfesionalServicioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z995EstadoServProf_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z995EstadoServProf));
         GXCCtl = "nRcdDeleted_145_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_145), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_145_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_145), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_145_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_145), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_143_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPROFESIONALESID_" + sGXsfl_143_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV7ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "PROFESIONALSERVICIOID_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalServicioId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALSERVICIONOMBRE_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalServicioNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESTADOSERVPROF_"+sGXsfl_143_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbEstadoServProf.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_993_"+sGXsfl_143_idx+"Link", StringUtil.RTrim( imgprompt_993_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_serviciosContainer.AddRow(Gridlevel_serviciosRow);
      }

      protected void ReadRow0S145( )
      {
         nGXsfl_143_idx = (int)(nGXsfl_143_idx+1);
         sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0");
         SubsflControlProps_143145( ) ;
         edtProfesionalServicioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALSERVICIOID_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtProfesionalServicioNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROFESIONALSERVICIONOMBRE_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbEstadoServProf.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESTADOSERVPROF_"+sGXsfl_143_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         imgprompt_125_Link = cgiGet( "PROMPT_993_"+sGXsfl_143_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProfesionalServicioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProfesionalServicioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "PROFESIONALSERVICIOID_" + sGXsfl_143_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProfesionalServicioId_Internalname;
            wbErr = true;
            A993ProfesionalServicioId = 0;
         }
         else
         {
            A993ProfesionalServicioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProfesionalServicioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A994ProfesionalServicioNombre = cgiGet( edtProfesionalServicioNombre_Internalname);
         cmbEstadoServProf.Name = cmbEstadoServProf_Internalname;
         cmbEstadoServProf.CurrentValue = cgiGet( cmbEstadoServProf_Internalname);
         A995EstadoServProf = cgiGet( cmbEstadoServProf_Internalname);
         n995EstadoServProf = false;
         n995EstadoServProf = (String.IsNullOrEmpty(StringUtil.RTrim( A995EstadoServProf)) ? true : false);
         GXCCtl = "Z993ProfesionalServicioId_" + sGXsfl_143_idx;
         Z993ProfesionalServicioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z995EstadoServProf_" + sGXsfl_143_idx;
         Z995EstadoServProf = cgiGet( GXCCtl);
         n995EstadoServProf = (String.IsNullOrEmpty(StringUtil.RTrim( A995EstadoServProf)) ? true : false);
         GXCCtl = "nRcdDeleted_145_" + sGXsfl_143_idx;
         nRcdDeleted_145 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_145_" + sGXsfl_143_idx;
         nRcdExists_145 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_145_" + sGXsfl_143_idx;
         nIsMod_145 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defdynZonasID_Visible = dynZonasID.Visible;
         defedtPaisID_Enabled = edtPaisID_Enabled;
         defedtProfesionalesZonasCorrelativo_Enabled = edtProfesionalesZonasCorrelativo_Enabled;
         defedtProfesionalServicioId_Enabled = edtProfesionalServicioId_Enabled;
         defedtEstadosProfRubTipo_Enabled = edtEstadosProfRubTipo_Enabled;
         defdynRubrosId_Enabled = dynRubrosId.Enabled;
      }

      protected void ConfirmValues0S0( )
      {
         nGXsfl_122_idx = 0;
         sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx), 4, 0), 4, "0");
         SubsflControlProps_12235( ) ;
         while ( nGXsfl_122_idx < nRC_GXsfl_122 )
         {
            nGXsfl_122_idx = (int)(nGXsfl_122_idx+1);
            sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx), 4, 0), 4, "0");
            SubsflControlProps_12235( ) ;
            ChangePostValue( "Z121RubrosId_"+sGXsfl_122_idx, cgiGet( "ZT_"+"Z121RubrosId_"+sGXsfl_122_idx)) ;
            DeletePostValue( "ZT_"+"Z121RubrosId_"+sGXsfl_122_idx) ;
            ChangePostValue( "Z124EstadosProfRubTipo_"+sGXsfl_122_idx, cgiGet( "ZT_"+"Z124EstadosProfRubTipo_"+sGXsfl_122_idx)) ;
            DeletePostValue( "ZT_"+"Z124EstadosProfRubTipo_"+sGXsfl_122_idx) ;
            ChangePostValue( "Z125EstadosProfRubId_"+sGXsfl_122_idx, cgiGet( "ZT_"+"Z125EstadosProfRubId_"+sGXsfl_122_idx)) ;
            DeletePostValue( "ZT_"+"Z125EstadosProfRubId_"+sGXsfl_122_idx) ;
         }
         nGXsfl_143_idx = 0;
         sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0");
         SubsflControlProps_143145( ) ;
         while ( nGXsfl_143_idx < nRC_GXsfl_143 )
         {
            nGXsfl_143_idx = (int)(nGXsfl_143_idx+1);
            sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0");
            SubsflControlProps_143145( ) ;
            ChangePostValue( "Z993ProfesionalServicioId_"+sGXsfl_143_idx, cgiGet( "ZT_"+"Z993ProfesionalServicioId_"+sGXsfl_143_idx)) ;
            DeletePostValue( "ZT_"+"Z993ProfesionalServicioId_"+sGXsfl_143_idx) ;
            ChangePostValue( "Z995EstadoServProf_"+sGXsfl_143_idx, cgiGet( "ZT_"+"Z995EstadoServProf_"+sGXsfl_143_idx)) ;
            DeletePostValue( "ZT_"+"Z995EstadoServProf_"+sGXsfl_143_idx) ;
         }
         nGXsfl_157_idx = 0;
         sGXsfl_157_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_157_idx), 4, 0), 4, "0");
         SubsflControlProps_15736( ) ;
         while ( nGXsfl_157_idx < nRC_GXsfl_157 )
         {
            nGXsfl_157_idx = (int)(nGXsfl_157_idx+1);
            sGXsfl_157_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_157_idx), 4, 0), 4, "0");
            SubsflControlProps_15736( ) ;
            ChangePostValue( "Z126ProfesionalesZonasCorrelativo_"+sGXsfl_157_idx, cgiGet( "ZT_"+"Z126ProfesionalesZonasCorrelativo_"+sGXsfl_157_idx)) ;
            DeletePostValue( "ZT_"+"Z126ProfesionalesZonasCorrelativo_"+sGXsfl_157_idx) ;
            ChangePostValue( "Z112DepartamentoId_"+sGXsfl_157_idx, cgiGet( "ZT_"+"Z112DepartamentoId_"+sGXsfl_157_idx)) ;
            DeletePostValue( "ZT_"+"Z112DepartamentoId_"+sGXsfl_157_idx) ;
            ChangePostValue( "Z114DepartamentoMunicipioId_"+sGXsfl_157_idx, cgiGet( "ZT_"+"Z114DepartamentoMunicipioId_"+sGXsfl_157_idx)) ;
            DeletePostValue( "ZT_"+"Z114DepartamentoMunicipioId_"+sGXsfl_157_idx) ;
            ChangePostValue( "Z110ZonasID_"+sGXsfl_157_idx, cgiGet( "ZT_"+"Z110ZonasID_"+sGXsfl_157_idx)) ;
            DeletePostValue( "ZT_"+"Z110ZonasID_"+sGXsfl_157_idx) ;
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
         GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7ProfesionalesId));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Profesionales");
         forbiddenHiddens.Add("ProfesionalesAceptoTerminos", context.localUtil.Format( A678ProfesionalesAceptoTerminos, "99/99/99 99:99"));
         forbiddenHiddens.Add("ProfesionalesDeclaroDatosV", context.localUtil.Format( A679ProfesionalesDeclaroDatosV, "99/99/99 99:99"));
         forbiddenHiddens.Add("Insert_BancoId", context.localUtil.Format( (decimal)(AV32Insert_BancoId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_EstadosTipo", StringUtil.RTrim( context.localUtil.Format( AV11Insert_EstadosTipo, "")));
         forbiddenHiddens.Add("Insert_EstadosGenericosId", context.localUtil.Format( (decimal)(AV12Insert_EstadosGenericosId), "ZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ProfesionalesFechaNacimiento", context.localUtil.Format(A900ProfesionalesFechaNacimiento, "99/99/99"));
         forbiddenHiddens.Add("ProfesionalesRUT", StringUtil.RTrim( context.localUtil.Format( A901ProfesionalesRUT, "")));
         forbiddenHiddens.Add("ProfesionalesTipoEmpresa", context.localUtil.Format( (decimal)(A902ProfesionalesTipoEmpresa), "ZZZ9"));
         forbiddenHiddens.Add("ProfesionalesAutoEnumerar", context.localUtil.Format( (decimal)(A196ProfesionalesAutoEnumerar), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("profesionales:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z120ProfesionalesId", StringUtil.RTrim( Z120ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "Z199ProfesionalesFechaAlta", context.localUtil.TToC( Z199ProfesionalesFechaAlta, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z200ProfesionalesFechaActualizado", context.localUtil.TToC( Z200ProfesionalesFechaActualizado, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z900ProfesionalesFechaNacimiento", context.localUtil.DToC( Z900ProfesionalesFechaNacimiento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z901ProfesionalesRUT", StringUtil.RTrim( Z901ProfesionalesRUT));
         GxWebStd.gx_hidden_field( context, "Z902ProfesionalesTipoEmpresa", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z902ProfesionalesTipoEmpresa), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z676ProfesionalesEsRUT", Z676ProfesionalesEsRUT);
         GxWebStd.gx_hidden_field( context, "Z166ProfesionalesPrimerNombre", StringUtil.RTrim( Z166ProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, "Z191ProfesionalesSegundoNombre", StringUtil.RTrim( Z191ProfesionalesSegundoNombre));
         GxWebStd.gx_hidden_field( context, "Z167ProfesionalesApellidoPrimero", StringUtil.RTrim( Z167ProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, "Z192ProfesionalesApellidoSegundo", StringUtil.RTrim( Z192ProfesionalesApellidoSegundo));
         GxWebStd.gx_hidden_field( context, "Z170ProfesionalesTelefono", StringUtil.RTrim( Z170ProfesionalesTelefono));
         GxWebStd.gx_hidden_field( context, "Z193ProfesionalesEmail", Z193ProfesionalesEmail);
         GxWebStd.gx_hidden_field( context, "Z198ProfesionalesDireccion", Z198ProfesionalesDireccion);
         GxWebStd.gx_hidden_field( context, "Z267ProfesionalesVerDatPerSol", StringUtil.RTrim( Z267ProfesionalesVerDatPerSol));
         GxWebStd.gx_hidden_field( context, "Z436ProfesionalesPerAltShop", StringUtil.RTrim( Z436ProfesionalesPerAltShop));
         GxWebStd.gx_hidden_field( context, "Z196ProfesionalesAutoEnumerar", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z196ProfesionalesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z197ProfesionalesAutoEnuZona", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z197ProfesionalesAutoEnuZona), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z677ProfesionalesExperiencia", Z677ProfesionalesExperiencia);
         GxWebStd.gx_hidden_field( context, "Z678ProfesionalesAceptoTerminos", context.localUtil.TToC( Z678ProfesionalesAceptoTerminos, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z679ProfesionalesDeclaroDatosV", context.localUtil.TToC( Z679ProfesionalesDeclaroDatosV, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z680ProfesionalesCuentaBancaria", StringUtil.RTrim( Z680ProfesionalesCuentaBancaria));
         GxWebStd.gx_hidden_field( context, "Z800ProfesionalesCapacidadProducti", StringUtil.LTrim( StringUtil.NToC( Z800ProfesionalesCapacidadProducti, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z617ProfesionalesLimitOSF", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z617ProfesionalesLimitOSF), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z268ProfesionalesFeedBackCant", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z268ProfesionalesFeedBackCant), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z269ProfesionalesFeedBackProm", StringUtil.LTrim( StringUtil.NToC( Z269ProfesionalesFeedBackProm, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z107EstadosTipo", StringUtil.RTrim( Z107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "Z108EstadosGenericosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z673BancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z673BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O197ProfesionalesAutoEnuZona", StringUtil.LTrim( StringUtil.NToC( (decimal)(O197ProfesionalesAutoEnuZona), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_122", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_122_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_157", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_157_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_143", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_143_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N673BancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A673BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N107EstadosTipo", StringUtil.RTrim( A107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "N108EstadosGenericosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
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
         GxWebStd.gx_hidden_field( context, "PROFESIONALESNOMBRECOMPLETO", A886ProfesionalesNombreCompleto);
         GxWebStd.gx_hidden_field( context, "PROFESIONALESTIEMPODISPONIBLE", StringUtil.LTrim( StringUtil.NToC( A803ProfesionalesTiempoDisponible, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACK", StringUtil.LTrim( StringUtil.NToC( A270ProfesionalesFeedback, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESID", StringUtil.RTrim( AV7ProfesionalesId));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROFESIONALESID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ProfesionalesId, "")), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_BANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32Insert_BancoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESTADOSTIPO", StringUtil.RTrim( AV11Insert_EstadosTipo));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPROFESIONALESFEEDBACK", StringUtil.LTrim( StringUtil.NToC( AV14ProfesionalesFeedback, 10, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFECHANACIMIENTO", context.localUtil.DToC( A900ProfesionalesFechaNacimiento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESRUT", StringUtil.RTrim( A901ProfesionalesRUT));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESTIPOEMPRESA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A902ProfesionalesTipoEmpresa), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESPHOTO_GXI", A40000ProfesionalesPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAUTOENUMERAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(A196ProfesionalesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESAUTOENUZONA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "BANCONOMBRE", StringUtil.RTrim( A674BancoNombre));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV34Pgmname));
         GxWebStd.gx_hidden_field( context, "RUBROSNOMBRE", StringUtil.RTrim( A122RubrosNombre));
         GxWebStd.gx_hidden_field( context, "RUBROSIMAGEN_GXI", A40001RubrosImagen_GXI);
         GxWebStd.gx_hidden_field( context, "ESTADOSPROFRUBNOMB", StringUtil.RTrim( A221EstadosProfRubNomb));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTODEPARTAMENTO", StringUtil.RTrim( A113DepartamentoDepartamento));
         GXCCtlgxBlob = "PROFESIONALESPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A169ProfesionalesPhoto);
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACK_Objectcall", StringUtil.RTrim( Profesionalesfeedback_Objectcall));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACK_Enabled", StringUtil.BoolToStr( Profesionalesfeedback_Enabled));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACK_Captionclass", StringUtil.RTrim( Profesionalesfeedback_Captionclass));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACK_Captionstyle", StringUtil.RTrim( Profesionalesfeedback_Captionstyle));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESFEEDBACK_Captionposition", StringUtil.RTrim( Profesionalesfeedback_Captionposition));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Objectcall", StringUtil.RTrim( Gxuitabspanel_tabs_Objectcall));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Enabled", StringUtil.BoolToStr( Gxuitabspanel_tabs_Enabled));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
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
         GXEncryptionTmp = "profesionales.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7ProfesionalesId));
         return formatLink("profesionales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Profesionales" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Profesionales", "") ;
      }

      protected void InitializeNonKey0S34( )
      {
         A673BancoId = 0;
         n673BancoId = false;
         AssignAttri("", false, "A673BancoId", StringUtil.LTrimStr( (decimal)(A673BancoId), 18, 0));
         n673BancoId = ((0==A673BancoId) ? true : false);
         A107EstadosTipo = "";
         AssignAttri("", false, "A107EstadosTipo", A107EstadosTipo);
         A108EstadosGenericosId = 0;
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         A199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AV14ProfesionalesFeedback = 0;
         AssignAttri("", false, "AV14ProfesionalesFeedback", StringUtil.LTrimStr( AV14ProfesionalesFeedback, 10, 2));
         A270ProfesionalesFeedback = 0;
         AssignAttri("", false, "A270ProfesionalesFeedback", StringUtil.LTrimStr( A270ProfesionalesFeedback, 10, 2));
         A803ProfesionalesTiempoDisponible = 0;
         AssignAttri("", false, "A803ProfesionalesTiempoDisponible", StringUtil.LTrimStr( A803ProfesionalesTiempoDisponible, 10, 2));
         A886ProfesionalesNombreCompleto = "";
         AssignAttri("", false, "A886ProfesionalesNombreCompleto", A886ProfesionalesNombreCompleto);
         A900ProfesionalesFechaNacimiento = DateTime.MinValue;
         n900ProfesionalesFechaNacimiento = false;
         AssignAttri("", false, "A900ProfesionalesFechaNacimiento", context.localUtil.Format(A900ProfesionalesFechaNacimiento, "99/99/99"));
         A901ProfesionalesRUT = "";
         n901ProfesionalesRUT = false;
         AssignAttri("", false, "A901ProfesionalesRUT", A901ProfesionalesRUT);
         A902ProfesionalesTipoEmpresa = 0;
         n902ProfesionalesTipoEmpresa = false;
         AssignAttri("", false, "A902ProfesionalesTipoEmpresa", StringUtil.LTrimStr( (decimal)(A902ProfesionalesTipoEmpresa), 4, 0));
         A676ProfesionalesEsRUT = false;
         n676ProfesionalesEsRUT = false;
         AssignAttri("", false, "A676ProfesionalesEsRUT", A676ProfesionalesEsRUT);
         n676ProfesionalesEsRUT = ((false==A676ProfesionalesEsRUT) ? true : false);
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
         A677ProfesionalesExperiencia = "";
         n677ProfesionalesExperiencia = false;
         AssignAttri("", false, "A677ProfesionalesExperiencia", A677ProfesionalesExperiencia);
         n677ProfesionalesExperiencia = (String.IsNullOrEmpty(StringUtil.RTrim( A677ProfesionalesExperiencia)) ? true : false);
         A678ProfesionalesAceptoTerminos = (DateTime)(DateTime.MinValue);
         n678ProfesionalesAceptoTerminos = false;
         AssignAttri("", false, "A678ProfesionalesAceptoTerminos", context.localUtil.TToC( A678ProfesionalesAceptoTerminos, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n678ProfesionalesAceptoTerminos = ((DateTime.MinValue==A678ProfesionalesAceptoTerminos) ? true : false);
         A679ProfesionalesDeclaroDatosV = (DateTime)(DateTime.MinValue);
         n679ProfesionalesDeclaroDatosV = false;
         AssignAttri("", false, "A679ProfesionalesDeclaroDatosV", context.localUtil.TToC( A679ProfesionalesDeclaroDatosV, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         n679ProfesionalesDeclaroDatosV = ((DateTime.MinValue==A679ProfesionalesDeclaroDatosV) ? true : false);
         A680ProfesionalesCuentaBancaria = "";
         n680ProfesionalesCuentaBancaria = false;
         AssignAttri("", false, "A680ProfesionalesCuentaBancaria", A680ProfesionalesCuentaBancaria);
         n680ProfesionalesCuentaBancaria = (String.IsNullOrEmpty(StringUtil.RTrim( A680ProfesionalesCuentaBancaria)) ? true : false);
         A674BancoNombre = "";
         AssignAttri("", false, "A674BancoNombre", A674BancoNombre);
         A617ProfesionalesLimitOSF = 0;
         n617ProfesionalesLimitOSF = false;
         AssignAttri("", false, "A617ProfesionalesLimitOSF", StringUtil.LTrimStr( (decimal)(A617ProfesionalesLimitOSF), 4, 0));
         n617ProfesionalesLimitOSF = ((0==A617ProfesionalesLimitOSF) ? true : false);
         A268ProfesionalesFeedBackCant = 0;
         AssignAttri("", false, "A268ProfesionalesFeedBackCant", StringUtil.LTrimStr( (decimal)(A268ProfesionalesFeedBackCant), 18, 0));
         A269ProfesionalesFeedBackProm = 0;
         AssignAttri("", false, "A269ProfesionalesFeedBackProm", StringUtil.LTrimStr( A269ProfesionalesFeedBackProm, 18, 2));
         A267ProfesionalesVerDatPerSol = context.GetMessage( "N", "");
         AssignAttri("", false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
         A436ProfesionalesPerAltShop = context.GetMessage( "N", "");
         n436ProfesionalesPerAltShop = false;
         AssignAttri("", false, "A436ProfesionalesPerAltShop", A436ProfesionalesPerAltShop);
         A800ProfesionalesCapacidadProducti = (decimal)(8);
         AssignAttri("", false, "A800ProfesionalesCapacidadProducti", StringUtil.LTrimStr( A800ProfesionalesCapacidadProducti, 10, 2));
         O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
         AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
         Z199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         Z200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         Z900ProfesionalesFechaNacimiento = DateTime.MinValue;
         Z901ProfesionalesRUT = "";
         Z902ProfesionalesTipoEmpresa = 0;
         Z676ProfesionalesEsRUT = false;
         Z166ProfesionalesPrimerNombre = "";
         Z191ProfesionalesSegundoNombre = "";
         Z167ProfesionalesApellidoPrimero = "";
         Z192ProfesionalesApellidoSegundo = "";
         Z170ProfesionalesTelefono = "";
         Z193ProfesionalesEmail = "";
         Z198ProfesionalesDireccion = "";
         Z267ProfesionalesVerDatPerSol = "";
         Z436ProfesionalesPerAltShop = "";
         Z196ProfesionalesAutoEnumerar = 0;
         Z197ProfesionalesAutoEnuZona = 0;
         Z677ProfesionalesExperiencia = "";
         Z678ProfesionalesAceptoTerminos = (DateTime)(DateTime.MinValue);
         Z679ProfesionalesDeclaroDatosV = (DateTime)(DateTime.MinValue);
         Z680ProfesionalesCuentaBancaria = "";
         Z800ProfesionalesCapacidadProducti = 0;
         Z617ProfesionalesLimitOSF = 0;
         Z268ProfesionalesFeedBackCant = 0;
         Z269ProfesionalesFeedBackProm = 0;
         Z107EstadosTipo = "";
         Z108EstadosGenericosId = 0;
         Z673BancoId = 0;
      }

      protected void InitAll0S34( )
      {
         A120ProfesionalesId = "";
         AssignAttri("", false, "A120ProfesionalesId", A120ProfesionalesId);
         InitializeNonKey0S34( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A199ProfesionalesFechaAlta = i199ProfesionalesFechaAlta;
         AssignAttri("", false, "A199ProfesionalesFechaAlta", context.localUtil.TToC( A199ProfesionalesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A200ProfesionalesFechaActualizado = i200ProfesionalesFechaActualizado;
         AssignAttri("", false, "A200ProfesionalesFechaActualizado", context.localUtil.TToC( A200ProfesionalesFechaActualizado, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         A108EstadosGenericosId = i108EstadosGenericosId;
         AssignAttri("", false, "A108EstadosGenericosId", StringUtil.LTrimStr( (decimal)(A108EstadosGenericosId), 5, 0));
         A267ProfesionalesVerDatPerSol = i267ProfesionalesVerDatPerSol;
         AssignAttri("", false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
         A436ProfesionalesPerAltShop = i436ProfesionalesPerAltShop;
         n436ProfesionalesPerAltShop = false;
         AssignAttri("", false, "A436ProfesionalesPerAltShop", A436ProfesionalesPerAltShop);
         A800ProfesionalesCapacidadProducti = i800ProfesionalesCapacidadProducti;
         AssignAttri("", false, "A800ProfesionalesCapacidadProducti", StringUtil.LTrimStr( A800ProfesionalesCapacidadProducti, 10, 2));
      }

      protected void InitializeNonKey0S35( )
      {
         A124EstadosProfRubTipo = "";
         A125EstadosProfRubId = 0;
         A122RubrosNombre = "";
         AssignAttri("", false, "A122RubrosNombre", A122RubrosNombre);
         A168RubrosImagen = "";
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A40001RubrosImagen_GXI = "";
         AssignProp("", false, edtRubrosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40001RubrosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A168RubrosImagen))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtRubrosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A168RubrosImagen), true);
         A123RubrosEstado = "";
         n123RubrosEstado = false;
         A221EstadosProfRubNomb = "";
         AssignAttri("", false, "A221EstadosProfRubNomb", A221EstadosProfRubNomb);
         Z124EstadosProfRubTipo = "";
         Z125EstadosProfRubId = 0;
      }

      protected void InitAll0S35( )
      {
         A121RubrosId = 0;
         InitializeNonKey0S35( ) ;
      }

      protected void StandaloneModalInsert0S35( )
      {
         A124EstadosProfRubTipo = i124EstadosProfRubTipo;
         A125EstadosProfRubId = i125EstadosProfRubId;
      }

      protected void InitializeNonKey0S36( )
      {
         A116PaisID = "";
         A112DepartamentoId = 0;
         A113DepartamentoDepartamento = "";
         AssignAttri("", false, "A113DepartamentoDepartamento", A113DepartamentoDepartamento);
         A114DepartamentoMunicipioId = 0;
         A110ZonasID = 0;
         n110ZonasID = false;
         Z112DepartamentoId = 0;
         Z114DepartamentoMunicipioId = 0;
         Z110ZonasID = 0;
      }

      protected void InitAll0S36( )
      {
         A126ProfesionalesZonasCorrelativo = 0;
         InitializeNonKey0S36( ) ;
      }

      protected void StandaloneModalInsert0S36( )
      {
         A197ProfesionalesAutoEnuZona = i197ProfesionalesAutoEnuZona;
         AssignAttri("", false, "A197ProfesionalesAutoEnuZona", StringUtil.LTrimStr( (decimal)(A197ProfesionalesAutoEnuZona), 4, 0));
      }

      protected void InitializeNonKey0S145( )
      {
         A994ProfesionalServicioNombre = "";
         A995EstadoServProf = "";
         n995EstadoServProf = false;
         Z995EstadoServProf = "";
      }

      protected void InitAll0S145( )
      {
         A993ProfesionalServicioId = 0;
         InitializeNonKey0S145( ) ;
      }

      protected void StandaloneModalInsert0S145( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("Rating/rating.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932014686", true, true, false);
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
         context.AddJavascriptSource("profesionales.js", "?2026932014686", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true, false);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true, false);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true, false);
         context.AddJavascriptSource("Rating/rating.min.js", "", false, true, false);
         context.AddJavascriptSource("Rating/RatingRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_level_properties35( )
      {
         edtEstadosProfRubTipo_Enabled = defedtEstadosProfRubTipo_Enabled;
         AssignProp("", false, edtEstadosProfRubTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosProfRubTipo_Enabled), 5, 0), !bGXsfl_122_Refreshing);
         dynRubrosId.Enabled = defdynRubrosId_Enabled;
         AssignProp("", false, dynRubrosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRubrosId.Enabled), 5, 0), !bGXsfl_122_Refreshing);
      }

      protected void init_level_properties36( )
      {
         dynZonasID.Visible = defdynZonasID_Visible;
         AssignProp("", false, dynZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynZonasID.Visible), 5, 0), !bGXsfl_157_Refreshing);
         edtPaisID_Enabled = defedtPaisID_Enabled;
         AssignProp("", false, edtPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisID_Enabled), 5, 0), !bGXsfl_157_Refreshing);
         edtProfesionalesZonasCorrelativo_Enabled = defedtProfesionalesZonasCorrelativo_Enabled;
         AssignProp("", false, edtProfesionalesZonasCorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0), !bGXsfl_157_Refreshing);
      }

      protected void init_level_properties145( )
      {
         edtProfesionalServicioId_Enabled = defedtProfesionalServicioId_Enabled;
         AssignProp("", false, edtProfesionalServicioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProfesionalServicioId_Enabled), 5, 0), !bGXsfl_143_Refreshing);
      }

      protected void StartGridControl122( )
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
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynRubrosId.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", context.convertURL( A168RubrosImagen));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRubrosImagen_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A124EstadosProfRubTipo)));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadosProfRubTipo_Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A125EstadosProfRubId), 5, 0, ".", ""))));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbEstadosProfRubId.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_rubrosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A123RubrosEstado)));
         Gridlevel_rubrosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbRubrosEstado.Enabled), 5, 0, ".", "")));
         Gridlevel_rubrosContainer.AddColumnProperties(Gridlevel_rubrosColumn);
         Gridlevel_rubrosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Selectedindex), 4, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Allowselection), 1, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Allowhovering), 1, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_rubrosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_rubros_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl143( )
      {
         Gridlevel_serviciosContainer.AddObjectProperty("GridName", "Gridlevel_servicios");
         Gridlevel_serviciosContainer.AddObjectProperty("Header", subGridlevel_servicios_Header);
         Gridlevel_serviciosContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_serviciosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_serviciosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_serviciosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_servicios_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_serviciosContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_serviciosContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_serviciosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_serviciosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A993ProfesionalServicioId), 18, 0, ".", ""))));
         Gridlevel_serviciosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalServicioId_Enabled), 5, 0, ".", "")));
         Gridlevel_serviciosContainer.AddColumnProperties(Gridlevel_serviciosColumn);
         Gridlevel_serviciosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_serviciosContainer.AddColumnProperties(Gridlevel_serviciosColumn);
         Gridlevel_serviciosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_serviciosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A994ProfesionalServicioNombre)));
         Gridlevel_serviciosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalServicioNombre_Enabled), 5, 0, ".", "")));
         Gridlevel_serviciosContainer.AddColumnProperties(Gridlevel_serviciosColumn);
         Gridlevel_serviciosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_serviciosColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A995EstadoServProf)));
         Gridlevel_serviciosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbEstadoServProf.Enabled), 5, 0, ".", "")));
         Gridlevel_serviciosContainer.AddColumnProperties(Gridlevel_serviciosColumn);
         Gridlevel_serviciosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_servicios_Selectedindex), 4, 0, ".", "")));
         Gridlevel_serviciosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_servicios_Allowselection), 1, 0, ".", "")));
         Gridlevel_serviciosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_servicios_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_serviciosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_servicios_Allowhovering), 1, 0, ".", "")));
         Gridlevel_serviciosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_servicios_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_serviciosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_servicios_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_serviciosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_servicios_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl157( )
      {
         Gridlevel_zonasContainer.AddObjectProperty("GridName", "Gridlevel_zonas");
         Gridlevel_zonasContainer.AddObjectProperty("Header", subGridlevel_zonas_Header);
         Gridlevel_zonasContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_zonasContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_zonasContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_zonasContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_zonas_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_zonasContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_zonasContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_zonasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_zonasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A126ProfesionalesZonasCorrelativo), 4, 0, ".", ""))));
         Gridlevel_zonasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProfesionalesZonasCorrelativo_Enabled), 5, 0, ".", "")));
         Gridlevel_zonasContainer.AddColumnProperties(Gridlevel_zonasColumn);
         Gridlevel_zonasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_zonasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A116PaisID)));
         Gridlevel_zonasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaisID_Enabled), 5, 0, ".", "")));
         Gridlevel_zonasContainer.AddColumnProperties(Gridlevel_zonasColumn);
         Gridlevel_zonasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_zonasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", ""))));
         Gridlevel_zonasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynDepartamentoId.Enabled), 5, 0, ".", "")));
         Gridlevel_zonasContainer.AddColumnProperties(Gridlevel_zonasColumn);
         Gridlevel_zonasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_zonasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", ""))));
         Gridlevel_zonasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynDepartamentoMunicipioId.Enabled), 5, 0, ".", "")));
         Gridlevel_zonasContainer.AddColumnProperties(Gridlevel_zonasColumn);
         Gridlevel_zonasColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_zonasColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, ".", ""))));
         Gridlevel_zonasColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynZonasID.Visible), 5, 0, ".", "")));
         Gridlevel_zonasColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynZonasID.Enabled), 5, 0, ".", "")));
         Gridlevel_zonasContainer.AddColumnProperties(Gridlevel_zonasColumn);
         Gridlevel_zonasContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_zonas_Selectedindex), 4, 0, ".", "")));
         Gridlevel_zonasContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_zonas_Allowselection), 1, 0, ".", "")));
         Gridlevel_zonasContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_zonas_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_zonasContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_zonas_Allowhovering), 1, 0, ".", "")));
         Gridlevel_zonasContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_zonas_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_zonasContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_zonas_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_zonasContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_zonas_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTabgeneral_title_Internalname = "TABGENERAL_TITLE";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         dynEstadosGenericosId_Internalname = "ESTADOSGENERICOSID";
         chkProfesionalesEsRUT_Internalname = "PROFESIONALESESRUT";
         edtProfesionalesPrimerNombre_Internalname = "PROFESIONALESPRIMERNOMBRE";
         edtProfesionalesSegundoNombre_Internalname = "PROFESIONALESSEGUNDONOMBRE";
         edtProfesionalesApellidoPrimero_Internalname = "PROFESIONALESAPELLIDOPRIMERO";
         edtProfesionalesApellidoSegundo_Internalname = "PROFESIONALESAPELLIDOSEGUNDO";
         divTb1_Internalname = "TB1";
         imgProfesionalesPhoto_Internalname = "PROFESIONALESPHOTO";
         edtProfesionalesFeedBackCant_Internalname = "PROFESIONALESFEEDBACKCANT";
         Profesionalesfeedback_Internalname = "PROFESIONALESFEEDBACK";
         divTb2_Internalname = "TB2";
         edtProfesionalesTelefono_Internalname = "PROFESIONALESTELEFONO";
         edtProfesionalesEmail_Internalname = "PROFESIONALESEMAIL";
         edtProfesionalesDireccion_Internalname = "PROFESIONALESDIRECCION";
         cmbProfesionalesVerDatPerSol_Internalname = "PROFESIONALESVERDATPERSOL";
         edtProfesionalesLimitOSF_Internalname = "PROFESIONALESLIMITOSF";
         edtProfesionalesAceptoTerminos_Internalname = "PROFESIONALESACEPTOTERMINOS";
         edtProfesionalesDeclaroDatosV_Internalname = "PROFESIONALESDECLARODATOSV";
         dynBancoId_Internalname = "BANCOID";
         edtProfesionalesCuentaBancaria_Internalname = "PROFESIONALESCUENTABANCARIA";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         lblTablevel_rubros_title_Internalname = "TABLEVEL_RUBROS_TITLE";
         dynRubrosId_Internalname = "RUBROSID";
         edtRubrosImagen_Internalname = "RUBROSIMAGEN";
         edtEstadosProfRubTipo_Internalname = "ESTADOSPROFRUBTIPO";
         cmbEstadosProfRubId_Internalname = "ESTADOSPROFRUBID";
         cmbRubrosEstado_Internalname = "RUBROSESTADO";
         edtProfesionalesExperiencia_Internalname = "PROFESIONALESEXPERIENCIA";
         divTableleaflevel_rubros_Internalname = "TABLELEAFLEVEL_RUBROS";
         divTabtablelevel_rubros_Internalname = "TABTABLELEVEL_RUBROS";
         lblTablevel_servicios_title_Internalname = "TABLEVEL_SERVICIOS_TITLE";
         edtProfesionalServicioId_Internalname = "PROFESIONALSERVICIOID";
         edtProfesionalServicioNombre_Internalname = "PROFESIONALSERVICIONOMBRE";
         cmbEstadoServProf_Internalname = "ESTADOSERVPROF";
         divTableleaflevel_servicios_Internalname = "TABLELEAFLEVEL_SERVICIOS";
         divTabtablelevel_servicios_Internalname = "TABTABLELEVEL_SERVICIOS";
         lblTablevel_zonas_title_Internalname = "TABLEVEL_ZONAS_TITLE";
         edtProfesionalesZonasCorrelativo_Internalname = "PROFESIONALESZONASCORRELATIVO";
         edtPaisID_Internalname = "PAISID";
         dynDepartamentoId_Internalname = "DEPARTAMENTOID";
         dynDepartamentoMunicipioId_Internalname = "DEPARTAMENTOMUNICIPIOID";
         dynZonasID_Internalname = "ZONASID";
         divTableleaflevel_zonas_Internalname = "TABLELEAFLEVEL_ZONAS";
         divTabtablelevel_zonas_Internalname = "TABTABLELEVEL_ZONAS";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtEstadosTipo_Internalname = "ESTADOSTIPO";
         edtProfesionalesCapacidadProducti_Internalname = "PROFESIONALESCAPACIDADPRODUCTI";
         edtProfesionalesPerAltShop_Internalname = "PROFESIONALESPERALTSHOP";
         edtProfesionalesFechaAlta_Internalname = "PROFESIONALESFECHAALTA";
         edtProfesionalesFechaActualizado_Internalname = "PROFESIONALESFECHAACTUALIZADO";
         edtProfesionalesFeedBackProm_Internalname = "PROFESIONALESFEEDBACKPROM";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_125_Internalname = "PROMPT_125";
         imgprompt_993_Internalname = "PROMPT_993";
         subGridlevel_rubros_Internalname = "GRIDLEVEL_RUBROS";
         subGridlevel_servicios_Internalname = "GRIDLEVEL_SERVICIOS";
         subGridlevel_zonas_Internalname = "GRIDLEVEL_ZONAS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_zonas_Allowcollapsing = 0;
         subGridlevel_zonas_Allowselection = 0;
         subGridlevel_zonas_Header = "";
         subGridlevel_servicios_Allowcollapsing = 0;
         subGridlevel_servicios_Allowselection = 0;
         subGridlevel_servicios_Header = "";
         subGridlevel_rubros_Allowcollapsing = 0;
         subGridlevel_rubros_Allowselection = 0;
         subGridlevel_rubros_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Profesionales", "");
         cmbEstadoServProf_Jsonclick = "";
         edtProfesionalServicioNombre_Jsonclick = "";
         imgprompt_993_Visible = 1;
         imgprompt_993_Link = "";
         edtProfesionalServicioId_Jsonclick = "";
         subGridlevel_servicios_Class = "WorkWith";
         subGridlevel_servicios_Backcolorstyle = 0;
         dynZonasID_Jsonclick = "";
         dynDepartamentoMunicipioId_Jsonclick = "";
         dynDepartamentoId_Jsonclick = "";
         edtPaisID_Jsonclick = "";
         edtProfesionalesZonasCorrelativo_Jsonclick = "";
         subGridlevel_zonas_Class = "WorkWith";
         subGridlevel_zonas_Backcolorstyle = 0;
         cmbRubrosEstado_Jsonclick = "";
         imgprompt_125_Visible = 1;
         imgprompt_125_Link = "";
         imgprompt_125_Visible = 1;
         cmbEstadosProfRubId_Jsonclick = "";
         edtEstadosProfRubTipo_Jsonclick = "";
         dynRubrosId_Jsonclick = "";
         subGridlevel_rubros_Class = "WorkWith";
         subGridlevel_rubros_Backcolorstyle = 0;
         dynZonasID.Enabled = 1;
         dynZonasID.Visible = -1;
         dynDepartamentoMunicipioId.Enabled = 1;
         dynDepartamentoId.Enabled = 1;
         edtPaisID_Enabled = 0;
         edtProfesionalesZonasCorrelativo_Enabled = 0;
         cmbEstadoServProf.Enabled = 1;
         edtProfesionalServicioNombre_Enabled = 0;
         edtProfesionalServicioId_Enabled = 1;
         cmbRubrosEstado.Enabled = 0;
         cmbEstadosProfRubId.Enabled = 1;
         edtEstadosProfRubTipo_Enabled = 0;
         edtRubrosImagen_Enabled = 0;
         dynRubrosId.Enabled = 1;
         edtProfesionalesFeedBackProm_Jsonclick = "";
         edtProfesionalesFeedBackProm_Enabled = 1;
         edtProfesionalesFeedBackProm_Visible = 1;
         edtProfesionalesFechaActualizado_Jsonclick = "";
         edtProfesionalesFechaActualizado_Enabled = 1;
         edtProfesionalesFechaActualizado_Visible = 1;
         edtProfesionalesFechaAlta_Jsonclick = "";
         edtProfesionalesFechaAlta_Enabled = 1;
         edtProfesionalesFechaAlta_Visible = 1;
         edtProfesionalesPerAltShop_Jsonclick = "";
         edtProfesionalesPerAltShop_Enabled = 1;
         edtProfesionalesPerAltShop_Visible = 1;
         edtProfesionalesCapacidadProducti_Jsonclick = "";
         edtProfesionalesCapacidadProducti_Enabled = 1;
         edtProfesionalesCapacidadProducti_Visible = 1;
         edtEstadosTipo_Jsonclick = "";
         edtEstadosTipo_Enabled = 1;
         edtEstadosTipo_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtProfesionalesExperiencia_Enabled = 1;
         edtProfesionalesCuentaBancaria_Jsonclick = "";
         edtProfesionalesCuentaBancaria_Enabled = 1;
         dynBancoId_Jsonclick = "";
         dynBancoId.Enabled = 1;
         edtProfesionalesDeclaroDatosV_Jsonclick = "";
         edtProfesionalesDeclaroDatosV_Enabled = 0;
         edtProfesionalesAceptoTerminos_Jsonclick = "";
         edtProfesionalesAceptoTerminos_Enabled = 0;
         edtProfesionalesLimitOSF_Jsonclick = "";
         edtProfesionalesLimitOSF_Enabled = 1;
         cmbProfesionalesVerDatPerSol_Jsonclick = "";
         cmbProfesionalesVerDatPerSol.Enabled = 1;
         edtProfesionalesDireccion_Enabled = 1;
         edtProfesionalesEmail_Jsonclick = "";
         edtProfesionalesEmail_Enabled = 1;
         edtProfesionalesTelefono_Jsonclick = "";
         edtProfesionalesTelefono_Enabled = 1;
         Profesionalesfeedback_Captionposition = "Left";
         Profesionalesfeedback_Captionstyle = "";
         Profesionalesfeedback_Captionclass = "col-sm-3 AttributeFLLabel";
         Profesionalesfeedback_Enabled = Convert.ToBoolean( 0);
         edtProfesionalesFeedBackCant_Jsonclick = "";
         edtProfesionalesFeedBackCant_Enabled = 1;
         imgProfesionalesPhoto_Enabled = 1;
         edtProfesionalesApellidoSegundo_Jsonclick = "";
         edtProfesionalesApellidoSegundo_Enabled = 1;
         edtProfesionalesApellidoPrimero_Jsonclick = "";
         edtProfesionalesApellidoPrimero_Enabled = 1;
         edtProfesionalesSegundoNombre_Jsonclick = "";
         edtProfesionalesSegundoNombre_Enabled = 1;
         edtProfesionalesPrimerNombre_Jsonclick = "";
         edtProfesionalesPrimerNombre_Enabled = 1;
         chkProfesionalesEsRUT.Enabled = 1;
         dynEstadosGenericosId_Jsonclick = "";
         dynEstadosGenericosId.Enabled = 1;
         edtProfesionalesId_Jsonclick = "";
         edtProfesionalesId_Enabled = 1;
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "Tab";
         Gxuitabspanel_tabs_Pagecount = 4;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         GXAESTADOSGENERICOSID_html0S34( A107EstadosTipo) ;
         GXADEPARTAMENTOMUNICIPIOID_html0S36( A112DepartamentoId) ;
         GXAZONASID_html0S36( A112DepartamentoId, A114DepartamentoMunicipioId) ;
         /* End function dynload_actions */
      }

      protected void GXDLAESTADOSGENERICOSID0S34( string A107EstadosTipo )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAESTADOSGENERICOSID_data0S34( A107EstadosTipo) ;
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

      protected void GXAESTADOSGENERICOSID_html0S34( string A107EstadosTipo )
      {
         int gxdynajaxvalue;
         GXDLAESTADOSGENERICOSID_data0S34( A107EstadosTipo) ;
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

      protected void GXDLAESTADOSGENERICOSID_data0S34( string A107EstadosTipo )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000S67 */
         pr_default.execute(65, new Object[] {A107EstadosTipo});
         while ( (pr_default.getStatus(65) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000S67_A108EstadosGenericosId[0]), 5, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000S67_A109EstadosGenericosNombre[0]));
            pr_default.readNext(65);
         }
         pr_default.close(65);
      }

      protected void GXDLABANCOID0S34( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLABANCOID_data0S34( ) ;
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

      protected void GXABANCOID_html0S34( )
      {
         long gxdynajaxvalue;
         GXDLABANCOID_data0S34( ) ;
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

      protected void GXDLABANCOID_data0S34( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T000S68 */
         pr_default.execute(66);
         while ( (pr_default.getStatus(66) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000S68_A673BancoId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000S68_A674BancoNombre[0]));
            pr_default.readNext(66);
         }
         pr_default.close(66);
      }

      protected void GXDLARUBROSID0S35( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLARUBROSID_data0S35( ) ;
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

      protected void GXARUBROSID_html0S35( )
      {
         short gxdynajaxvalue;
         GXDLARUBROSID_data0S35( ) ;
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

      protected void GXDLARUBROSID_data0S35( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T000S69 */
         pr_default.execute(67);
         while ( (pr_default.getStatus(67) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000S69_A121RubrosId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000S69_A122RubrosNombre[0]));
            pr_default.readNext(67);
         }
         pr_default.close(67);
      }

      protected void GXDLADEPARTAMENTOMUNICIPIOID0S36( long A112DepartamentoId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLADEPARTAMENTOMUNICIPIOID_data0S36( A112DepartamentoId) ;
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

      protected void GXADEPARTAMENTOMUNICIPIOID_html0S36( long A112DepartamentoId )
      {
         long gxdynajaxvalue;
         GXDLADEPARTAMENTOMUNICIPIOID_data0S36( A112DepartamentoId) ;
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

      protected void GXDLADEPARTAMENTOMUNICIPIOID_data0S36( long A112DepartamentoId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000S70 */
         pr_default.execute(68, new Object[] {A112DepartamentoId});
         while ( (pr_default.getStatus(68) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000S70_A114DepartamentoMunicipioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000S70_A115DepartamentoMunicipioNombre[0]));
            pr_default.readNext(68);
         }
         pr_default.close(68);
      }

      protected void GXDLAZONASID0S36( long A112DepartamentoId ,
                                       long A114DepartamentoMunicipioId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAZONASID_data0S36( A112DepartamentoId, A114DepartamentoMunicipioId) ;
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

      protected void GXAZONASID_html0S36( long A112DepartamentoId ,
                                          long A114DepartamentoMunicipioId )
      {
         long gxdynajaxvalue;
         GXDLAZONASID_data0S36( A112DepartamentoId, A114DepartamentoMunicipioId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynZonasID.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (long)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynZonasID.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 18, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAZONASID_data0S36( long A112DepartamentoId ,
                                            long A114DepartamentoMunicipioId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor T000S71 */
         pr_default.execute(69, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         while ( (pr_default.getStatus(69) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000S71_A110ZonasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000S71_A111ZonasNombre[0]));
            pr_default.readNext(69);
         }
         pr_default.close(69);
      }

      protected void gxnrGridlevel_rubros_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_12235( ) ;
         while ( nGXsfl_122_idx <= nRC_GXsfl_122 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0S35( ) ;
            standaloneModal0S35( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0S35( ) ;
            nGXsfl_122_idx = (int)(nGXsfl_122_idx+1);
            sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx), 4, 0), 4, "0");
            SubsflControlProps_12235( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_rubrosContainer)) ;
         /* End function gxnrGridlevel_rubros_newrow */
      }

      protected void gxnrGridlevel_zonas_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_15736( ) ;
         while ( nGXsfl_157_idx <= nRC_GXsfl_157 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0S36( ) ;
            standaloneModal0S36( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0S36( ) ;
            nGXsfl_157_idx = (int)(nGXsfl_157_idx+1);
            sGXsfl_157_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_157_idx), 4, 0), 4, "0");
            SubsflControlProps_15736( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_zonasContainer)) ;
         /* End function gxnrGridlevel_zonas_newrow */
      }

      protected void gxnrGridlevel_servicios_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_143145( ) ;
         while ( nGXsfl_143_idx <= nRC_GXsfl_143 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0S145( ) ;
            standaloneModal0S145( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0S145( ) ;
            nGXsfl_143_idx = (int)(nGXsfl_143_idx+1);
            sGXsfl_143_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_143_idx), 4, 0), 4, "0");
            SubsflControlProps_143145( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_serviciosContainer)) ;
         /* End function gxnrGridlevel_servicios_newrow */
      }

      protected void init_web_controls( )
      {
         dynEstadosGenericosId.Name = "ESTADOSGENERICOSID";
         dynEstadosGenericosId.WebTags = "";
         chkProfesionalesEsRUT.Name = "PROFESIONALESESRUT";
         chkProfesionalesEsRUT.WebTags = "";
         chkProfesionalesEsRUT.Caption = context.GetMessage( "El Documento es RUT", "");
         AssignProp("", false, chkProfesionalesEsRUT_Internalname, "TitleCaption", chkProfesionalesEsRUT.Caption, true);
         chkProfesionalesEsRUT.CheckedValue = "false";
         A676ProfesionalesEsRUT = StringUtil.StrToBool( StringUtil.BoolToStr( A676ProfesionalesEsRUT));
         n676ProfesionalesEsRUT = false;
         AssignAttri("", false, "A676ProfesionalesEsRUT", A676ProfesionalesEsRUT);
         cmbProfesionalesVerDatPerSol.Name = "PROFESIONALESVERDATPERSOL";
         cmbProfesionalesVerDatPerSol.WebTags = "";
         cmbProfesionalesVerDatPerSol.addItem("S", context.GetMessage( "SI", ""), 0);
         cmbProfesionalesVerDatPerSol.addItem("N", context.GetMessage( "NO", ""), 0);
         if ( cmbProfesionalesVerDatPerSol.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A267ProfesionalesVerDatPerSol)) )
            {
               A267ProfesionalesVerDatPerSol = context.GetMessage( "N", "");
               AssignAttri("", false, "A267ProfesionalesVerDatPerSol", A267ProfesionalesVerDatPerSol);
            }
         }
         dynBancoId.Name = "BANCOID";
         dynBancoId.WebTags = "";
         GXCCtl = "RUBROSID_" + sGXsfl_122_idx;
         dynRubrosId.Name = GXCCtl;
         dynRubrosId.WebTags = "";
         GXCCtl = "ESTADOSPROFRUBID_" + sGXsfl_122_idx;
         cmbEstadosProfRubId.Name = GXCCtl;
         cmbEstadosProfRubId.WebTags = "";
         cmbEstadosProfRubId.addItem("1", context.GetMessage( "Habilitado", ""), 0);
         cmbEstadosProfRubId.addItem("2", context.GetMessage( "Deshabilitado", ""), 0);
         cmbEstadosProfRubId.addItem("3", context.GetMessage( "Pendiente", ""), 0);
         if ( cmbEstadosProfRubId.ItemCount > 0 )
         {
            A125EstadosProfRubId = (int)(Math.Round(NumberUtil.Val( cmbEstadosProfRubId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A125EstadosProfRubId), 5, 0))), "."), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "RUBROSESTADO_" + sGXsfl_122_idx;
         cmbRubrosEstado.Name = GXCCtl;
         cmbRubrosEstado.WebTags = "";
         cmbRubrosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbRubrosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbRubrosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbRubrosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbRubrosEstado.ItemCount > 0 )
         {
            A123RubrosEstado = cmbRubrosEstado.getValidValue(A123RubrosEstado);
            n123RubrosEstado = false;
         }
         GXCCtl = "ESTADOSERVPROF_" + sGXsfl_143_idx;
         cmbEstadoServProf.Name = GXCCtl;
         cmbEstadoServProf.WebTags = "";
         cmbEstadoServProf.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbEstadoServProf.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbEstadoServProf.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbEstadoServProf.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbEstadoServProf.ItemCount > 0 )
         {
            A995EstadoServProf = cmbEstadoServProf.getValidValue(A995EstadoServProf);
            n995EstadoServProf = false;
         }
         GXCCtl = "DEPARTAMENTOID_" + sGXsfl_157_idx;
         dynDepartamentoId.Name = GXCCtl;
         dynDepartamentoId.WebTags = "";
         dynDepartamentoId.removeAllItems();
         /* Using cursor T000S72 */
         pr_default.execute(70);
         while ( (pr_default.getStatus(70) != 101) )
         {
            dynDepartamentoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000S72_A112DepartamentoId[0]), 18, 0)), T000S72_A113DepartamentoDepartamento[0], 0);
            pr_default.readNext(70);
         }
         pr_default.close(70);
         if ( dynDepartamentoId.ItemCount > 0 )
         {
            A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "DEPARTAMENTOMUNICIPIOID_" + sGXsfl_157_idx;
         dynDepartamentoMunicipioId.Name = GXCCtl;
         dynDepartamentoMunicipioId.WebTags = "";
         GXCCtl = "ZONASID_" + sGXsfl_157_idx;
         dynZonasID.Name = GXCCtl;
         dynZonasID.WebTags = "";
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

      public void Valid_Bancoid( )
      {
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         /* Using cursor T000S28 */
         pr_default.execute(26, new Object[] {n673BancoId, A673BancoId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            if ( ! ( (0==A673BancoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Banco", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
               GX_FocusControl = dynBancoId_Internalname;
            }
         }
         A674BancoNombre = T000S28_A674BancoNombre[0];
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A674BancoNombre", StringUtil.RTrim( A674BancoNombre));
      }

      public void Valid_Estadostipo( )
      {
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         /* Using cursor T000S73 */
         pr_default.execute(71, new Object[] {A107EstadosTipo, A108EstadosGenericosId});
         if ( (pr_default.getStatus(71) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSGENERICOSID");
            AnyError = 1;
            GX_FocusControl = edtEstadosTipo_Internalname;
         }
         pr_default.close(71);
         GXAESTADOSGENERICOSID_html0S34( A107EstadosTipo) ;
         dynload_actions( ) ;
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

      public void Valid_Profesionalesfeedbackprom( )
      {
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         if ( A268ProfesionalesFeedBackCant > 0 )
         {
            A270ProfesionalesFeedback = (decimal)(A269ProfesionalesFeedBackProm/ (decimal)(A268ProfesionalesFeedBackCant));
         }
         else
         {
            A270ProfesionalesFeedback = 0;
         }
         AV14ProfesionalesFeedback = A270ProfesionalesFeedback;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A270ProfesionalesFeedback", StringUtil.LTrim( StringUtil.NToC( A270ProfesionalesFeedback, 10, 2, ".", "")));
         AssignAttri("", false, "AV14ProfesionalesFeedback", StringUtil.LTrim( StringUtil.NToC( AV14ProfesionalesFeedback, 10, 2, ".", "")));
      }

      public void Valid_Rubrosid( )
      {
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         n123RubrosEstado = false;
         A123RubrosEstado = cmbRubrosEstado.CurrentValue;
         n123RubrosEstado = false;
         cmbRubrosEstado.CurrentValue = A123RubrosEstado;
         /* Using cursor T000S45 */
         pr_default.execute(43, new Object[] {A121RubrosId});
         if ( (pr_default.getStatus(43) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "RUBROSID");
            AnyError = 1;
            GX_FocusControl = dynRubrosId_Internalname;
         }
         A122RubrosNombre = T000S45_A122RubrosNombre[0];
         A40001RubrosImagen_GXI = T000S45_A40001RubrosImagen_GXI[0];
         A123RubrosEstado = T000S45_A123RubrosEstado[0];
         n123RubrosEstado = T000S45_n123RubrosEstado[0];
         cmbRubrosEstado.CurrentValue = A123RubrosEstado;
         A168RubrosImagen = T000S45_A168RubrosImagen[0];
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
         if ( cmbRubrosEstado.ItemCount > 0 )
         {
            A123RubrosEstado = cmbRubrosEstado.getValidValue(A123RubrosEstado);
            n123RubrosEstado = false;
            cmbRubrosEstado.CurrentValue = A123RubrosEstado;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRubrosEstado.CurrentValue = StringUtil.RTrim( A123RubrosEstado);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A122RubrosNombre", StringUtil.RTrim( A122RubrosNombre));
         AssignAttri("", false, "A168RubrosImagen", context.PathToRelativeUrl( A168RubrosImagen));
         GXCCtl = "RUBROSIMAGEN_" + sGXsfl_122_idx;
         AssignAttri("", false, "GXCCtl", GXCCtl);
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A168RubrosImagen));
         AssignAttri("", false, "A40001RubrosImagen_GXI", A40001RubrosImagen_GXI);
         AssignAttri("", false, "A123RubrosEstado", StringUtil.RTrim( A123RubrosEstado));
         cmbRubrosEstado.CurrentValue = StringUtil.RTrim( A123RubrosEstado);
         AssignProp("", false, cmbRubrosEstado_Internalname, "Values", cmbRubrosEstado.ToJavascriptSource(), true);
      }

      public void Valid_Estadosprofrubid( )
      {
         A125EstadosProfRubId = (int)(Math.Round(NumberUtil.Val( cmbEstadosProfRubId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         /* Using cursor T000S46 */
         pr_default.execute(44, new Object[] {A124EstadosProfRubTipo, A125EstadosProfRubId});
         if ( (pr_default.getStatus(44) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Estados Prof Rub", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ESTADOSPROFRUBID");
            AnyError = 1;
            GX_FocusControl = cmbEstadosProfRubId_Internalname;
         }
         A221EstadosProfRubNomb = T000S46_A221EstadosProfRubNomb[0];
         pr_default.close(44);
         dynload_actions( ) ;
         if ( dynRubrosId.ItemCount > 0 )
         {
            A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynRubrosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A121RubrosId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A221EstadosProfRubNomb", StringUtil.RTrim( A221EstadosProfRubNomb));
      }

      public void Valid_Departamentoid( )
      {
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         /* Using cursor T000S56 */
         pr_default.execute(54, new Object[] {A112DepartamentoId});
         if ( (pr_default.getStatus(54) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Departamento", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
         }
         A113DepartamentoDepartamento = T000S56_A113DepartamentoDepartamento[0];
         A116PaisID = T000S56_A116PaisID[0];
         pr_default.close(54);
         if ( ( A112DepartamentoId == 1 ) && true /* After */ )
         {
            dynZonasID.Visible = 0;
         }
         else
         {
            if ( ( A112DepartamentoId >= 2 ) && true /* After */ )
            {
               dynZonasID.Visible = 1;
            }
         }
         dynload_actions( ) ;
         if ( dynDepartamentoMunicipioId.ItemCount > 0 )
         {
            A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         }
         if ( dynZonasID.ItemCount > 0 )
         {
            A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n110ZonasID = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynZonasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A113DepartamentoDepartamento", StringUtil.RTrim( A113DepartamentoDepartamento));
         AssignAttri("", false, "A116PaisID", StringUtil.RTrim( A116PaisID));
         AssignProp("", false, dynZonasID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynZonasID.Visible), 5, 0), !bGXsfl_157_Refreshing);
         AssignAttri("", false, "A114DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", "")));
         dynDepartamentoMunicipioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0));
         AssignProp("", false, dynDepartamentoMunicipioId_Internalname, "Values", dynDepartamentoMunicipioId.ToJavascriptSource(), true);
         AssignAttri("", false, "A110ZonasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, ".", "")));
         dynZonasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0));
         AssignProp("", false, dynZonasID_Internalname, "Values", dynZonasID.ToJavascriptSource(), true);
      }

      public void Valid_Departamentomunicipioid( )
      {
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         /* Using cursor T000S74 */
         pr_default.execute(72, new Object[] {A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(72) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Municipio", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = dynDepartamentoId_Internalname;
         }
         pr_default.close(72);
         dynload_actions( ) ;
         if ( dynZonasID.ItemCount > 0 )
         {
            A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0))), "."), 18, MidpointRounding.ToEven));
            n110ZonasID = false;
         }
         if ( context.isAjaxRequest( ) )
         {
            dynZonasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A110ZonasID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, ".", "")));
         dynZonasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A110ZonasID), 18, 0));
         AssignProp("", false, dynZonasID_Internalname, "Values", dynZonasID.ToJavascriptSource(), true);
      }

      public void Valid_Zonasid( )
      {
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         /* Using cursor T000S75 */
         pr_default.execute(73, new Object[] {n110ZonasID, A110ZonasID, A112DepartamentoId, A114DepartamentoMunicipioId});
         if ( (pr_default.getStatus(73) == 101) )
         {
            if ( ! ( (0==A110ZonasID) || (0==A112DepartamentoId) || (0==A114DepartamentoMunicipioId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Zonas", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "DEPARTAMENTOMUNICIPIOID");
               AnyError = 1;
               GX_FocusControl = dynZonasID_Internalname;
            }
         }
         pr_default.close(73);
         O197ProfesionalesAutoEnuZona = A197ProfesionalesAutoEnuZona;
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Profesionalservicioid( )
      {
         A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A673BancoId = (long)(Math.Round(NumberUtil.Val( dynBancoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n673BancoId = false;
         A121RubrosId = (short)(Math.Round(NumberUtil.Val( dynRubrosId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A112DepartamentoId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A114DepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( dynDepartamentoMunicipioId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         A110ZonasID = (long)(Math.Round(NumberUtil.Val( dynZonasID.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n110ZonasID = false;
         /* Using cursor T000S64 */
         pr_default.execute(62, new Object[] {A993ProfesionalServicioId});
         if ( (pr_default.getStatus(62) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Profesional Servicios Brindados", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "PROFESIONALSERVICIOID");
            AnyError = 1;
            GX_FocusControl = edtProfesionalServicioId_Internalname;
         }
         A994ProfesionalServicioNombre = T000S64_A994ProfesionalServicioNombre[0];
         pr_default.close(62);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A994ProfesionalServicioNombre", StringUtil.RTrim( A994ProfesionalServicioNombre));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV7ProfesionalesId',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ProfesionalesId',fld:'vPROFESIONALESID',pic:'',hsh:true,type:'char'},{av:'A678ProfesionalesAceptoTerminos',fld:'PROFESIONALESACEPTOTERMINOS',pic:'99/99/99 99:99',type:'dtime'},{av:'A679ProfesionalesDeclaroDatosV',fld:'PROFESIONALESDECLARODATOSV',pic:'99/99/99 99:99',type:'dtime'},{av:'AV32Insert_BancoId',fld:'vINSERT_BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11Insert_EstadosTipo',fld:'vINSERT_ESTADOSTIPO',pic:'',type:'char'},{av:'AV12Insert_EstadosGenericosId',fld:'vINSERT_ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'A900ProfesionalesFechaNacimiento',fld:'PROFESIONALESFECHANACIMIENTO',pic:'',type:'date'},{av:'A901ProfesionalesRUT',fld:'PROFESIONALESRUT',pic:'',type:'char'},{av:'A902ProfesionalesTipoEmpresa',fld:'PROFESIONALESTIPOEMPRESA',pic:'ZZZ9',type:'int'},{av:'A196ProfesionalesAutoEnumerar',fld:'PROFESIONALESAUTOENUMERAR',pic:'ZZZ9',type:'int'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("AFTER TRN","{handler:'E120S2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true,type:'char'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ESTADOSGENERICOSID","{handler:'Valid_Estadosgenericosid',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ESTADOSGENERICOSID",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESPRIMERNOMBRE","{handler:'Valid_Profesionalesprimernombre',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESPRIMERNOMBRE",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESSEGUNDONOMBRE","{handler:'Valid_Profesionalessegundonombre',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESSEGUNDONOMBRE",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESAPELLIDOPRIMERO","{handler:'Valid_Profesionalesapellidoprimero',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESAPELLIDOPRIMERO",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKCANT","{handler:'Valid_Profesionalesfeedbackcant',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKCANT",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESEMAIL","{handler:'Valid_Profesionalesemail',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESEMAIL",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_BANCOID","{handler:'Valid_Bancoid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A674BancoNombre',fld:'BANCONOMBRE',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_BANCOID",",oparms:[{av:'A674BancoNombre',fld:'BANCONOMBRE',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ESTADOSTIPO","{handler:'Valid_Estadostipo',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ESTADOSTIPO",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESCAPACIDADPRODUCTI","{handler:'Valid_Profesionalescapacidadproducti',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESCAPACIDADPRODUCTI",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESFECHAALTA","{handler:'Valid_Profesionalesfechaalta',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESFECHAALTA",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESFECHAACTUALIZADO","{handler:'Valid_Profesionalesfechaactualizado',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESFECHAACTUALIZADO",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKPROM","{handler:'Valid_Profesionalesfeedbackprom',iparms:[{av:'A269ProfesionalesFeedBackProm',fld:'PROFESIONALESFEEDBACKPROM',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'A268ProfesionalesFeedBackCant',fld:'PROFESIONALESFEEDBACKCANT',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A270ProfesionalesFeedback',fld:'PROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99',type:'decimal'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14ProfesionalesFeedback',fld:'vPROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99 %',type:'decimal'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESFEEDBACKPROM",",oparms:[{av:'A270ProfesionalesFeedback',fld:'PROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99',type:'decimal'},{av:'AV14ProfesionalesFeedback',fld:'vPROFESIONALESFEEDBACK',pic:'ZZZZZZ9.99 %',type:'decimal'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESFEEDBACK","{handler:'Valid_Profesionalesfeedback',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESFEEDBACK",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'A168RubrosImagen',fld:'RUBROSIMAGEN',pic:'',type:'bits'},{av:'A40001RubrosImagen_GXI',fld:'RUBROSIMAGEN_GXI',pic:'',type:'svchar'},{av:'cmbRubrosEstado'},{av:'A123RubrosEstado',fld:'RUBROSESTADO',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_RUBROSID",",oparms:[{av:'A122RubrosNombre',fld:'RUBROSNOMBRE',pic:'',type:'char'},{av:'A168RubrosImagen',fld:'RUBROSIMAGEN',pic:'',type:'bits'},{av:'A40001RubrosImagen_GXI',fld:'RUBROSIMAGEN_GXI',pic:'',type:'svchar'},{av:'cmbRubrosEstado'},{av:'A123RubrosEstado',fld:'RUBROSESTADO',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ESTADOSPROFRUBTIPO","{handler:'Valid_Estadosprofrubtipo',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ESTADOSPROFRUBTIPO",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ESTADOSPROFRUBID","{handler:'Valid_Estadosprofrubid',iparms:[{av:'A124EstadosProfRubTipo',fld:'ESTADOSPROFRUBTIPO',pic:'',type:'char'},{av:'cmbEstadosProfRubId'},{av:'A125EstadosProfRubId',fld:'ESTADOSPROFRUBID',pic:'ZZZZ9',type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A221EstadosProfRubNomb',fld:'ESTADOSPROFRUBNOMB',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ESTADOSPROFRUBID",",oparms:[{av:'A221EstadosProfRubNomb',fld:'ESTADOSPROFRUBNOMB',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("NULL","{handler:'Valid_Rubrosestado',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("NULL",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALSERVICIOID","{handler:'Valid_Profesionalservicioid',iparms:[{av:'A993ProfesionalServicioId',fld:'PROFESIONALSERVICIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A994ProfesionalServicioNombre',fld:'PROFESIONALSERVICIONOMBRE',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALSERVICIOID",",oparms:[{av:'A994ProfesionalServicioNombre',fld:'PROFESIONALSERVICIONOMBRE',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ESTADOSERVPROF","{handler:'Valid_Estadoservprof',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ESTADOSERVPROF",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_PROFESIONALESZONASCORRELATIVO","{handler:'Valid_Profesionaleszonascorrelativo',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_PROFESIONALESZONASCORRELATIVO",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A113DepartamentoDepartamento',fld:'DEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[{av:'A113DepartamentoDepartamento',fld:'DEPARTAMENTODEPARTAMENTO',pic:'',type:'char'},{av:'A116PaisID',fld:'PAISID',pic:'',type:'char'},{av:'dynZonasID'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID","{handler:'Valid_Departamentomunicipioid',iparms:[{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID",",oparms:[{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
         setEventMetadata("VALID_ZONASID","{handler:'Valid_Zonasid',iparms:[{av:'A197ProfesionalesAutoEnuZona',fld:'PROFESIONALESAUTOENUZONA',pic:'ZZZ9',type:'int'},{av:'dynRubrosId'},{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',type:'int'},{av:'dynDepartamentoId'},{av:'A112DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynDepartamentoMunicipioId'},{av:'A114DepartamentoMunicipioId',fld:'DEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'dynZonasID'},{av:'A110ZonasID',fld:'ZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]");
         setEventMetadata("VALID_ZONASID",",oparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'},{av:'dynBancoId'},{av:'A673BancoId',fld:'BANCOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'A676ProfesionalesEsRUT',fld:'PROFESIONALESESRUT',pic:'',type:'boolean'}]}");
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
         pr_default.close(62);
         pr_default.close(4);
         pr_default.close(54);
         pr_default.close(72);
         pr_default.close(73);
         pr_default.close(9);
         pr_default.close(43);
         pr_default.close(44);
         pr_default.close(13);
         pr_default.close(71);
         pr_default.close(26);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7ProfesionalesId = "";
         Z120ProfesionalesId = "";
         Z199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         Z200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         Z900ProfesionalesFechaNacimiento = DateTime.MinValue;
         Z901ProfesionalesRUT = "";
         Z166ProfesionalesPrimerNombre = "";
         Z191ProfesionalesSegundoNombre = "";
         Z167ProfesionalesApellidoPrimero = "";
         Z192ProfesionalesApellidoSegundo = "";
         Z170ProfesionalesTelefono = "";
         Z193ProfesionalesEmail = "";
         Z198ProfesionalesDireccion = "";
         Z267ProfesionalesVerDatPerSol = "";
         Z436ProfesionalesPerAltShop = "";
         Z677ProfesionalesExperiencia = "";
         Z678ProfesionalesAceptoTerminos = (DateTime)(DateTime.MinValue);
         Z679ProfesionalesDeclaroDatosV = (DateTime)(DateTime.MinValue);
         Z680ProfesionalesCuentaBancaria = "";
         Z107EstadosTipo = "";
         N107EstadosTipo = "";
         Z124EstadosProfRubTipo = "";
         Z995EstadoServProf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A107EstadosTipo = "";
         A124EstadosProfRubTipo = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A267ProfesionalesVerDatPerSol = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblTabgeneral_title_Jsonclick = "";
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
         A678ProfesionalesAceptoTerminos = (DateTime)(DateTime.MinValue);
         A679ProfesionalesDeclaroDatosV = (DateTime)(DateTime.MinValue);
         A680ProfesionalesCuentaBancaria = "";
         lblTablevel_rubros_title_Jsonclick = "";
         A677ProfesionalesExperiencia = "";
         lblTablevel_servicios_title_Jsonclick = "";
         lblTablevel_zonas_title_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A436ProfesionalesPerAltShop = "";
         A199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         A200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         Gridlevel_rubrosContainer = new GXWebGrid( context);
         sMode35 = "";
         sStyleString = "";
         Gridlevel_serviciosContainer = new GXWebGrid( context);
         sMode145 = "";
         Gridlevel_zonasContainer = new GXWebGrid( context);
         sMode36 = "";
         A900ProfesionalesFechaNacimiento = DateTime.MinValue;
         A901ProfesionalesRUT = "";
         A886ProfesionalesNombreCompleto = "";
         AV11Insert_EstadosTipo = "";
         A674BancoNombre = "";
         AV34Pgmname = "";
         A122RubrosNombre = "";
         A40001RubrosImagen_GXI = "";
         A221EstadosProfRubNomb = "";
         A113DepartamentoDepartamento = "";
         Profesionalesfeedback_Objectcall = "";
         Profesionalesfeedback_Class = "";
         Profesionalesfeedback_Ratingclass = "";
         Profesionalesfeedback_Captionvalue = "";
         Profesionalesfeedback_Coltitle = "";
         Profesionalesfeedback_Coltitlefont = "";
         Gxuitabspanel_tabs_Objectcall = "";
         Gxuitabspanel_tabs_Activepagecontrolname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode34 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A994ProfesionalServicioNombre = "";
         A995EstadoServProf = "";
         A116PaisID = "";
         A168RubrosImagen = "";
         A123RubrosEstado = "";
         AV15WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXEncryptionTmp = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z169ProfesionalesPhoto = "";
         Z40000ProfesionalesPhoto_GXI = "";
         Z674BancoNombre = "";
         T000S17_A674BancoNombre = new string[] {""} ;
         T000S18_A120ProfesionalesId = new string[] {""} ;
         T000S18_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T000S18_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         T000S18_A900ProfesionalesFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000S18_n900ProfesionalesFechaNacimiento = new bool[] {false} ;
         T000S18_A901ProfesionalesRUT = new string[] {""} ;
         T000S18_n901ProfesionalesRUT = new bool[] {false} ;
         T000S18_A902ProfesionalesTipoEmpresa = new short[1] ;
         T000S18_n902ProfesionalesTipoEmpresa = new bool[] {false} ;
         T000S18_A676ProfesionalesEsRUT = new bool[] {false} ;
         T000S18_n676ProfesionalesEsRUT = new bool[] {false} ;
         T000S18_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T000S18_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T000S18_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T000S18_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T000S18_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         T000S18_A170ProfesionalesTelefono = new string[] {""} ;
         T000S18_A193ProfesionalesEmail = new string[] {""} ;
         T000S18_n193ProfesionalesEmail = new bool[] {false} ;
         T000S18_A198ProfesionalesDireccion = new string[] {""} ;
         T000S18_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         T000S18_A436ProfesionalesPerAltShop = new string[] {""} ;
         T000S18_n436ProfesionalesPerAltShop = new bool[] {false} ;
         T000S18_A196ProfesionalesAutoEnumerar = new short[1] ;
         T000S18_A197ProfesionalesAutoEnuZona = new short[1] ;
         T000S18_A677ProfesionalesExperiencia = new string[] {""} ;
         T000S18_n677ProfesionalesExperiencia = new bool[] {false} ;
         T000S18_A678ProfesionalesAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         T000S18_n678ProfesionalesAceptoTerminos = new bool[] {false} ;
         T000S18_A679ProfesionalesDeclaroDatosV = new DateTime[] {DateTime.MinValue} ;
         T000S18_n679ProfesionalesDeclaroDatosV = new bool[] {false} ;
         T000S18_A680ProfesionalesCuentaBancaria = new string[] {""} ;
         T000S18_n680ProfesionalesCuentaBancaria = new bool[] {false} ;
         T000S18_A800ProfesionalesCapacidadProducti = new decimal[1] ;
         T000S18_A674BancoNombre = new string[] {""} ;
         T000S18_A617ProfesionalesLimitOSF = new short[1] ;
         T000S18_n617ProfesionalesLimitOSF = new bool[] {false} ;
         T000S18_A268ProfesionalesFeedBackCant = new long[1] ;
         T000S18_A269ProfesionalesFeedBackProm = new decimal[1] ;
         T000S18_A107EstadosTipo = new string[] {""} ;
         T000S18_A108EstadosGenericosId = new int[1] ;
         T000S18_A673BancoId = new long[1] ;
         T000S18_n673BancoId = new bool[] {false} ;
         T000S18_A169ProfesionalesPhoto = new string[] {""} ;
         T000S16_A107EstadosTipo = new string[] {""} ;
         T000S19_A674BancoNombre = new string[] {""} ;
         T000S20_A107EstadosTipo = new string[] {""} ;
         T000S21_A120ProfesionalesId = new string[] {""} ;
         T000S15_A120ProfesionalesId = new string[] {""} ;
         T000S15_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T000S15_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         T000S15_A900ProfesionalesFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000S15_n900ProfesionalesFechaNacimiento = new bool[] {false} ;
         T000S15_A901ProfesionalesRUT = new string[] {""} ;
         T000S15_n901ProfesionalesRUT = new bool[] {false} ;
         T000S15_A902ProfesionalesTipoEmpresa = new short[1] ;
         T000S15_n902ProfesionalesTipoEmpresa = new bool[] {false} ;
         T000S15_A676ProfesionalesEsRUT = new bool[] {false} ;
         T000S15_n676ProfesionalesEsRUT = new bool[] {false} ;
         T000S15_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T000S15_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T000S15_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T000S15_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T000S15_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         T000S15_A170ProfesionalesTelefono = new string[] {""} ;
         T000S15_A193ProfesionalesEmail = new string[] {""} ;
         T000S15_n193ProfesionalesEmail = new bool[] {false} ;
         T000S15_A198ProfesionalesDireccion = new string[] {""} ;
         T000S15_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         T000S15_A436ProfesionalesPerAltShop = new string[] {""} ;
         T000S15_n436ProfesionalesPerAltShop = new bool[] {false} ;
         T000S15_A196ProfesionalesAutoEnumerar = new short[1] ;
         T000S15_A197ProfesionalesAutoEnuZona = new short[1] ;
         T000S15_A677ProfesionalesExperiencia = new string[] {""} ;
         T000S15_n677ProfesionalesExperiencia = new bool[] {false} ;
         T000S15_A678ProfesionalesAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         T000S15_n678ProfesionalesAceptoTerminos = new bool[] {false} ;
         T000S15_A679ProfesionalesDeclaroDatosV = new DateTime[] {DateTime.MinValue} ;
         T000S15_n679ProfesionalesDeclaroDatosV = new bool[] {false} ;
         T000S15_A680ProfesionalesCuentaBancaria = new string[] {""} ;
         T000S15_n680ProfesionalesCuentaBancaria = new bool[] {false} ;
         T000S15_A800ProfesionalesCapacidadProducti = new decimal[1] ;
         T000S15_A617ProfesionalesLimitOSF = new short[1] ;
         T000S15_n617ProfesionalesLimitOSF = new bool[] {false} ;
         T000S15_A268ProfesionalesFeedBackCant = new long[1] ;
         T000S15_A269ProfesionalesFeedBackProm = new decimal[1] ;
         T000S15_A107EstadosTipo = new string[] {""} ;
         T000S15_A108EstadosGenericosId = new int[1] ;
         T000S15_A673BancoId = new long[1] ;
         T000S15_n673BancoId = new bool[] {false} ;
         T000S15_A169ProfesionalesPhoto = new string[] {""} ;
         T000S22_A120ProfesionalesId = new string[] {""} ;
         T000S23_A120ProfesionalesId = new string[] {""} ;
         T000S14_A120ProfesionalesId = new string[] {""} ;
         T000S14_A199ProfesionalesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         T000S14_A200ProfesionalesFechaActualizado = new DateTime[] {DateTime.MinValue} ;
         T000S14_A900ProfesionalesFechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         T000S14_n900ProfesionalesFechaNacimiento = new bool[] {false} ;
         T000S14_A901ProfesionalesRUT = new string[] {""} ;
         T000S14_n901ProfesionalesRUT = new bool[] {false} ;
         T000S14_A902ProfesionalesTipoEmpresa = new short[1] ;
         T000S14_n902ProfesionalesTipoEmpresa = new bool[] {false} ;
         T000S14_A676ProfesionalesEsRUT = new bool[] {false} ;
         T000S14_n676ProfesionalesEsRUT = new bool[] {false} ;
         T000S14_A166ProfesionalesPrimerNombre = new string[] {""} ;
         T000S14_A191ProfesionalesSegundoNombre = new string[] {""} ;
         T000S14_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         T000S14_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         T000S14_A40000ProfesionalesPhoto_GXI = new string[] {""} ;
         T000S14_A170ProfesionalesTelefono = new string[] {""} ;
         T000S14_A193ProfesionalesEmail = new string[] {""} ;
         T000S14_n193ProfesionalesEmail = new bool[] {false} ;
         T000S14_A198ProfesionalesDireccion = new string[] {""} ;
         T000S14_A267ProfesionalesVerDatPerSol = new string[] {""} ;
         T000S14_A436ProfesionalesPerAltShop = new string[] {""} ;
         T000S14_n436ProfesionalesPerAltShop = new bool[] {false} ;
         T000S14_A196ProfesionalesAutoEnumerar = new short[1] ;
         T000S14_A197ProfesionalesAutoEnuZona = new short[1] ;
         T000S14_A677ProfesionalesExperiencia = new string[] {""} ;
         T000S14_n677ProfesionalesExperiencia = new bool[] {false} ;
         T000S14_A678ProfesionalesAceptoTerminos = new DateTime[] {DateTime.MinValue} ;
         T000S14_n678ProfesionalesAceptoTerminos = new bool[] {false} ;
         T000S14_A679ProfesionalesDeclaroDatosV = new DateTime[] {DateTime.MinValue} ;
         T000S14_n679ProfesionalesDeclaroDatosV = new bool[] {false} ;
         T000S14_A680ProfesionalesCuentaBancaria = new string[] {""} ;
         T000S14_n680ProfesionalesCuentaBancaria = new bool[] {false} ;
         T000S14_A800ProfesionalesCapacidadProducti = new decimal[1] ;
         T000S14_A617ProfesionalesLimitOSF = new short[1] ;
         T000S14_n617ProfesionalesLimitOSF = new bool[] {false} ;
         T000S14_A268ProfesionalesFeedBackCant = new long[1] ;
         T000S14_A269ProfesionalesFeedBackProm = new decimal[1] ;
         T000S14_A107EstadosTipo = new string[] {""} ;
         T000S14_A108EstadosGenericosId = new int[1] ;
         T000S14_A673BancoId = new long[1] ;
         T000S14_n673BancoId = new bool[] {false} ;
         T000S14_A169ProfesionalesPhoto = new string[] {""} ;
         T000S28_A674BancoNombre = new string[] {""} ;
         T000S29_A461CentroCostosId = new long[1] ;
         T000S29_A466CentroCostosDetallesId = new long[1] ;
         T000S30_A976ProfesionalesRestriccionId = new long[1] ;
         T000S31_A450ProfComisionesID = new long[1] ;
         T000S32_A127SolicitudesID = new long[1] ;
         T000S32_A140RelacionesId = new long[1] ;
         T000S33_A422PostulacionesId = new long[1] ;
         T000S33_A120ProfesionalesId = new string[] {""} ;
         T000S34_A590Listaid = new long[1] ;
         T000S34_A133ProveedorID = new long[1] ;
         T000S34_A120ProfesionalesId = new string[] {""} ;
         T000S35_A503ComisionesID = new long[1] ;
         T000S35_A120ProfesionalesId = new string[] {""} ;
         T000S37_A120ProfesionalesId = new string[] {""} ;
         Z122RubrosNombre = "";
         Z168RubrosImagen = "";
         Z40001RubrosImagen_GXI = "";
         Z123RubrosEstado = "";
         Z221EstadosProfRubNomb = "";
         T000S12_A122RubrosNombre = new string[] {""} ;
         T000S12_A40001RubrosImagen_GXI = new string[] {""} ;
         T000S12_A123RubrosEstado = new string[] {""} ;
         T000S12_n123RubrosEstado = new bool[] {false} ;
         T000S12_A168RubrosImagen = new string[] {""} ;
         T000S13_A221EstadosProfRubNomb = new string[] {""} ;
         T000S38_A120ProfesionalesId = new string[] {""} ;
         T000S38_A122RubrosNombre = new string[] {""} ;
         T000S38_A40001RubrosImagen_GXI = new string[] {""} ;
         T000S38_A123RubrosEstado = new string[] {""} ;
         T000S38_n123RubrosEstado = new bool[] {false} ;
         T000S38_A221EstadosProfRubNomb = new string[] {""} ;
         T000S38_A121RubrosId = new short[1] ;
         T000S38_A124EstadosProfRubTipo = new string[] {""} ;
         T000S38_A125EstadosProfRubId = new int[1] ;
         T000S38_A168RubrosImagen = new string[] {""} ;
         T000S39_A122RubrosNombre = new string[] {""} ;
         T000S39_A40001RubrosImagen_GXI = new string[] {""} ;
         T000S39_A123RubrosEstado = new string[] {""} ;
         T000S39_n123RubrosEstado = new bool[] {false} ;
         T000S39_A168RubrosImagen = new string[] {""} ;
         T000S40_A221EstadosProfRubNomb = new string[] {""} ;
         T000S41_A120ProfesionalesId = new string[] {""} ;
         T000S41_A121RubrosId = new short[1] ;
         T000S11_A120ProfesionalesId = new string[] {""} ;
         T000S11_A121RubrosId = new short[1] ;
         T000S11_A124EstadosProfRubTipo = new string[] {""} ;
         T000S11_A125EstadosProfRubId = new int[1] ;
         T000S10_A120ProfesionalesId = new string[] {""} ;
         T000S10_A121RubrosId = new short[1] ;
         T000S10_A124EstadosProfRubTipo = new string[] {""} ;
         T000S10_A125EstadosProfRubId = new int[1] ;
         T000S45_A122RubrosNombre = new string[] {""} ;
         T000S45_A40001RubrosImagen_GXI = new string[] {""} ;
         T000S45_A123RubrosEstado = new string[] {""} ;
         T000S45_n123RubrosEstado = new bool[] {false} ;
         T000S45_A168RubrosImagen = new string[] {""} ;
         T000S46_A221EstadosProfRubNomb = new string[] {""} ;
         T000S47_A120ProfesionalesId = new string[] {""} ;
         T000S47_A121RubrosId = new short[1] ;
         Z113DepartamentoDepartamento = "";
         Z116PaisID = "";
         T000S48_A120ProfesionalesId = new string[] {""} ;
         T000S48_A126ProfesionalesZonasCorrelativo = new short[1] ;
         T000S48_A113DepartamentoDepartamento = new string[] {""} ;
         T000S48_A112DepartamentoId = new long[1] ;
         T000S48_A114DepartamentoMunicipioId = new long[1] ;
         T000S48_A110ZonasID = new long[1] ;
         T000S48_n110ZonasID = new bool[] {false} ;
         T000S48_A116PaisID = new string[] {""} ;
         T000S7_A113DepartamentoDepartamento = new string[] {""} ;
         T000S7_A116PaisID = new string[] {""} ;
         T000S8_A112DepartamentoId = new long[1] ;
         T000S9_A110ZonasID = new long[1] ;
         T000S9_n110ZonasID = new bool[] {false} ;
         T000S49_A113DepartamentoDepartamento = new string[] {""} ;
         T000S49_A116PaisID = new string[] {""} ;
         T000S50_A112DepartamentoId = new long[1] ;
         T000S51_A110ZonasID = new long[1] ;
         T000S51_n110ZonasID = new bool[] {false} ;
         T000S52_A120ProfesionalesId = new string[] {""} ;
         T000S52_A126ProfesionalesZonasCorrelativo = new short[1] ;
         T000S6_A120ProfesionalesId = new string[] {""} ;
         T000S6_A126ProfesionalesZonasCorrelativo = new short[1] ;
         T000S6_A112DepartamentoId = new long[1] ;
         T000S6_A114DepartamentoMunicipioId = new long[1] ;
         T000S6_A110ZonasID = new long[1] ;
         T000S6_n110ZonasID = new bool[] {false} ;
         T000S5_A120ProfesionalesId = new string[] {""} ;
         T000S5_A126ProfesionalesZonasCorrelativo = new short[1] ;
         T000S5_A112DepartamentoId = new long[1] ;
         T000S5_A114DepartamentoMunicipioId = new long[1] ;
         T000S5_A110ZonasID = new long[1] ;
         T000S5_n110ZonasID = new bool[] {false} ;
         T000S56_A113DepartamentoDepartamento = new string[] {""} ;
         T000S56_A116PaisID = new string[] {""} ;
         T000S57_A120ProfesionalesId = new string[] {""} ;
         T000S57_A126ProfesionalesZonasCorrelativo = new short[1] ;
         Z994ProfesionalServicioNombre = "";
         T000S58_A120ProfesionalesId = new string[] {""} ;
         T000S58_A994ProfesionalServicioNombre = new string[] {""} ;
         T000S58_A995EstadoServProf = new string[] {""} ;
         T000S58_n995EstadoServProf = new bool[] {false} ;
         T000S58_A993ProfesionalServicioId = new long[1] ;
         T000S4_A994ProfesionalServicioNombre = new string[] {""} ;
         T000S59_A994ProfesionalServicioNombre = new string[] {""} ;
         T000S60_A120ProfesionalesId = new string[] {""} ;
         T000S60_A993ProfesionalServicioId = new long[1] ;
         T000S3_A120ProfesionalesId = new string[] {""} ;
         T000S3_A995EstadoServProf = new string[] {""} ;
         T000S3_n995EstadoServProf = new bool[] {false} ;
         T000S3_A993ProfesionalServicioId = new long[1] ;
         T000S2_A120ProfesionalesId = new string[] {""} ;
         T000S2_A995EstadoServProf = new string[] {""} ;
         T000S2_n995EstadoServProf = new bool[] {false} ;
         T000S2_A993ProfesionalServicioId = new long[1] ;
         T000S64_A994ProfesionalServicioNombre = new string[] {""} ;
         T000S65_A120ProfesionalesId = new string[] {""} ;
         T000S65_A993ProfesionalServicioId = new long[1] ;
         Gridlevel_rubrosRow = new GXWebRow();
         subGridlevel_rubros_Linesclass = "";
         ROClassString = "";
         imgprompt_125_gximage = "";
         GXCCtlgxBlob = "";
         Gridlevel_zonasRow = new GXWebRow();
         subGridlevel_zonas_Linesclass = "";
         T000S66_A112DepartamentoId = new long[1] ;
         T000S66_A113DepartamentoDepartamento = new string[] {""} ;
         Gridlevel_serviciosRow = new GXWebRow();
         subGridlevel_servicios_Linesclass = "";
         imgprompt_993_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i199ProfesionalesFechaAlta = (DateTime)(DateTime.MinValue);
         i200ProfesionalesFechaActualizado = (DateTime)(DateTime.MinValue);
         i267ProfesionalesVerDatPerSol = "";
         i436ProfesionalesPerAltShop = "";
         i124EstadosProfRubTipo = "";
         Gridlevel_rubrosColumn = new GXWebColumn();
         Gridlevel_serviciosColumn = new GXWebColumn();
         Gridlevel_zonasColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000S67_A107EstadosTipo = new string[] {""} ;
         T000S67_A108EstadosGenericosId = new int[1] ;
         T000S67_A109EstadosGenericosNombre = new string[] {""} ;
         T000S68_A673BancoId = new long[1] ;
         T000S68_n673BancoId = new bool[] {false} ;
         T000S68_A674BancoNombre = new string[] {""} ;
         T000S68_A675BancoEstado = new string[] {""} ;
         T000S69_A121RubrosId = new short[1] ;
         T000S69_A122RubrosNombre = new string[] {""} ;
         T000S69_A123RubrosEstado = new string[] {""} ;
         T000S69_n123RubrosEstado = new bool[] {false} ;
         T000S70_A112DepartamentoId = new long[1] ;
         T000S70_A114DepartamentoMunicipioId = new long[1] ;
         T000S70_A115DepartamentoMunicipioNombre = new string[] {""} ;
         T000S71_A112DepartamentoId = new long[1] ;
         T000S71_A114DepartamentoMunicipioId = new long[1] ;
         T000S71_A110ZonasID = new long[1] ;
         T000S71_n110ZonasID = new bool[] {false} ;
         T000S71_A111ZonasNombre = new string[] {""} ;
         T000S72_A112DepartamentoId = new long[1] ;
         T000S72_A113DepartamentoDepartamento = new string[] {""} ;
         T000S73_A107EstadosTipo = new string[] {""} ;
         T000S74_A112DepartamentoId = new long[1] ;
         T000S75_A110ZonasID = new long[1] ;
         T000S75_n110ZonasID = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.profesionales__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionales__default(),
            new Object[][] {
                new Object[] {
               T000S2_A120ProfesionalesId, T000S2_A995EstadoServProf, T000S2_n995EstadoServProf, T000S2_A993ProfesionalServicioId
               }
               , new Object[] {
               T000S3_A120ProfesionalesId, T000S3_A995EstadoServProf, T000S3_n995EstadoServProf, T000S3_A993ProfesionalServicioId
               }
               , new Object[] {
               T000S4_A994ProfesionalServicioNombre
               }
               , new Object[] {
               T000S5_A120ProfesionalesId, T000S5_A126ProfesionalesZonasCorrelativo, T000S5_A112DepartamentoId, T000S5_A114DepartamentoMunicipioId, T000S5_A110ZonasID, T000S5_n110ZonasID
               }
               , new Object[] {
               T000S6_A120ProfesionalesId, T000S6_A126ProfesionalesZonasCorrelativo, T000S6_A112DepartamentoId, T000S6_A114DepartamentoMunicipioId, T000S6_A110ZonasID, T000S6_n110ZonasID
               }
               , new Object[] {
               T000S7_A113DepartamentoDepartamento, T000S7_A116PaisID
               }
               , new Object[] {
               T000S8_A112DepartamentoId
               }
               , new Object[] {
               T000S9_A110ZonasID
               }
               , new Object[] {
               T000S10_A120ProfesionalesId, T000S10_A121RubrosId, T000S10_A124EstadosProfRubTipo, T000S10_A125EstadosProfRubId
               }
               , new Object[] {
               T000S11_A120ProfesionalesId, T000S11_A121RubrosId, T000S11_A124EstadosProfRubTipo, T000S11_A125EstadosProfRubId
               }
               , new Object[] {
               T000S12_A122RubrosNombre, T000S12_A40001RubrosImagen_GXI, T000S12_A123RubrosEstado, T000S12_n123RubrosEstado, T000S12_A168RubrosImagen
               }
               , new Object[] {
               T000S13_A221EstadosProfRubNomb
               }
               , new Object[] {
               T000S14_A120ProfesionalesId, T000S14_A199ProfesionalesFechaAlta, T000S14_A200ProfesionalesFechaActualizado, T000S14_A900ProfesionalesFechaNacimiento, T000S14_n900ProfesionalesFechaNacimiento, T000S14_A901ProfesionalesRUT, T000S14_n901ProfesionalesRUT, T000S14_A902ProfesionalesTipoEmpresa, T000S14_n902ProfesionalesTipoEmpresa, T000S14_A676ProfesionalesEsRUT,
               T000S14_n676ProfesionalesEsRUT, T000S14_A166ProfesionalesPrimerNombre, T000S14_A191ProfesionalesSegundoNombre, T000S14_A167ProfesionalesApellidoPrimero, T000S14_A192ProfesionalesApellidoSegundo, T000S14_A40000ProfesionalesPhoto_GXI, T000S14_A170ProfesionalesTelefono, T000S14_A193ProfesionalesEmail, T000S14_n193ProfesionalesEmail, T000S14_A198ProfesionalesDireccion,
               T000S14_A267ProfesionalesVerDatPerSol, T000S14_A436ProfesionalesPerAltShop, T000S14_n436ProfesionalesPerAltShop, T000S14_A196ProfesionalesAutoEnumerar, T000S14_A197ProfesionalesAutoEnuZona, T000S14_A677ProfesionalesExperiencia, T000S14_n677ProfesionalesExperiencia, T000S14_A678ProfesionalesAceptoTerminos, T000S14_n678ProfesionalesAceptoTerminos, T000S14_A679ProfesionalesDeclaroDatosV,
               T000S14_n679ProfesionalesDeclaroDatosV, T000S14_A680ProfesionalesCuentaBancaria, T000S14_n680ProfesionalesCuentaBancaria, T000S14_A800ProfesionalesCapacidadProducti, T000S14_A617ProfesionalesLimitOSF, T000S14_n617ProfesionalesLimitOSF, T000S14_A268ProfesionalesFeedBackCant, T000S14_A269ProfesionalesFeedBackProm, T000S14_A107EstadosTipo, T000S14_A108EstadosGenericosId,
               T000S14_A673BancoId, T000S14_n673BancoId, T000S14_A169ProfesionalesPhoto
               }
               , new Object[] {
               T000S15_A120ProfesionalesId, T000S15_A199ProfesionalesFechaAlta, T000S15_A200ProfesionalesFechaActualizado, T000S15_A900ProfesionalesFechaNacimiento, T000S15_n900ProfesionalesFechaNacimiento, T000S15_A901ProfesionalesRUT, T000S15_n901ProfesionalesRUT, T000S15_A902ProfesionalesTipoEmpresa, T000S15_n902ProfesionalesTipoEmpresa, T000S15_A676ProfesionalesEsRUT,
               T000S15_n676ProfesionalesEsRUT, T000S15_A166ProfesionalesPrimerNombre, T000S15_A191ProfesionalesSegundoNombre, T000S15_A167ProfesionalesApellidoPrimero, T000S15_A192ProfesionalesApellidoSegundo, T000S15_A40000ProfesionalesPhoto_GXI, T000S15_A170ProfesionalesTelefono, T000S15_A193ProfesionalesEmail, T000S15_n193ProfesionalesEmail, T000S15_A198ProfesionalesDireccion,
               T000S15_A267ProfesionalesVerDatPerSol, T000S15_A436ProfesionalesPerAltShop, T000S15_n436ProfesionalesPerAltShop, T000S15_A196ProfesionalesAutoEnumerar, T000S15_A197ProfesionalesAutoEnuZona, T000S15_A677ProfesionalesExperiencia, T000S15_n677ProfesionalesExperiencia, T000S15_A678ProfesionalesAceptoTerminos, T000S15_n678ProfesionalesAceptoTerminos, T000S15_A679ProfesionalesDeclaroDatosV,
               T000S15_n679ProfesionalesDeclaroDatosV, T000S15_A680ProfesionalesCuentaBancaria, T000S15_n680ProfesionalesCuentaBancaria, T000S15_A800ProfesionalesCapacidadProducti, T000S15_A617ProfesionalesLimitOSF, T000S15_n617ProfesionalesLimitOSF, T000S15_A268ProfesionalesFeedBackCant, T000S15_A269ProfesionalesFeedBackProm, T000S15_A107EstadosTipo, T000S15_A108EstadosGenericosId,
               T000S15_A673BancoId, T000S15_n673BancoId, T000S15_A169ProfesionalesPhoto
               }
               , new Object[] {
               T000S16_A107EstadosTipo
               }
               , new Object[] {
               T000S17_A674BancoNombre
               }
               , new Object[] {
               T000S18_A120ProfesionalesId, T000S18_A199ProfesionalesFechaAlta, T000S18_A200ProfesionalesFechaActualizado, T000S18_A900ProfesionalesFechaNacimiento, T000S18_n900ProfesionalesFechaNacimiento, T000S18_A901ProfesionalesRUT, T000S18_n901ProfesionalesRUT, T000S18_A902ProfesionalesTipoEmpresa, T000S18_n902ProfesionalesTipoEmpresa, T000S18_A676ProfesionalesEsRUT,
               T000S18_n676ProfesionalesEsRUT, T000S18_A166ProfesionalesPrimerNombre, T000S18_A191ProfesionalesSegundoNombre, T000S18_A167ProfesionalesApellidoPrimero, T000S18_A192ProfesionalesApellidoSegundo, T000S18_A40000ProfesionalesPhoto_GXI, T000S18_A170ProfesionalesTelefono, T000S18_A193ProfesionalesEmail, T000S18_n193ProfesionalesEmail, T000S18_A198ProfesionalesDireccion,
               T000S18_A267ProfesionalesVerDatPerSol, T000S18_A436ProfesionalesPerAltShop, T000S18_n436ProfesionalesPerAltShop, T000S18_A196ProfesionalesAutoEnumerar, T000S18_A197ProfesionalesAutoEnuZona, T000S18_A677ProfesionalesExperiencia, T000S18_n677ProfesionalesExperiencia, T000S18_A678ProfesionalesAceptoTerminos, T000S18_n678ProfesionalesAceptoTerminos, T000S18_A679ProfesionalesDeclaroDatosV,
               T000S18_n679ProfesionalesDeclaroDatosV, T000S18_A680ProfesionalesCuentaBancaria, T000S18_n680ProfesionalesCuentaBancaria, T000S18_A800ProfesionalesCapacidadProducti, T000S18_A674BancoNombre, T000S18_A617ProfesionalesLimitOSF, T000S18_n617ProfesionalesLimitOSF, T000S18_A268ProfesionalesFeedBackCant, T000S18_A269ProfesionalesFeedBackProm, T000S18_A107EstadosTipo,
               T000S18_A108EstadosGenericosId, T000S18_A673BancoId, T000S18_n673BancoId, T000S18_A169ProfesionalesPhoto
               }
               , new Object[] {
               T000S19_A674BancoNombre
               }
               , new Object[] {
               T000S20_A107EstadosTipo
               }
               , new Object[] {
               T000S21_A120ProfesionalesId
               }
               , new Object[] {
               T000S22_A120ProfesionalesId
               }
               , new Object[] {
               T000S23_A120ProfesionalesId
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
               T000S28_A674BancoNombre
               }
               , new Object[] {
               T000S29_A461CentroCostosId, T000S29_A466CentroCostosDetallesId
               }
               , new Object[] {
               T000S30_A976ProfesionalesRestriccionId
               }
               , new Object[] {
               T000S31_A450ProfComisionesID
               }
               , new Object[] {
               T000S32_A127SolicitudesID, T000S32_A140RelacionesId
               }
               , new Object[] {
               T000S33_A422PostulacionesId, T000S33_A120ProfesionalesId
               }
               , new Object[] {
               T000S34_A590Listaid, T000S34_A133ProveedorID, T000S34_A120ProfesionalesId
               }
               , new Object[] {
               T000S35_A503ComisionesID, T000S35_A120ProfesionalesId
               }
               , new Object[] {
               }
               , new Object[] {
               T000S37_A120ProfesionalesId
               }
               , new Object[] {
               T000S38_A120ProfesionalesId, T000S38_A122RubrosNombre, T000S38_A40001RubrosImagen_GXI, T000S38_A123RubrosEstado, T000S38_n123RubrosEstado, T000S38_A221EstadosProfRubNomb, T000S38_A121RubrosId, T000S38_A124EstadosProfRubTipo, T000S38_A125EstadosProfRubId, T000S38_A168RubrosImagen
               }
               , new Object[] {
               T000S39_A122RubrosNombre, T000S39_A40001RubrosImagen_GXI, T000S39_A123RubrosEstado, T000S39_n123RubrosEstado, T000S39_A168RubrosImagen
               }
               , new Object[] {
               T000S40_A221EstadosProfRubNomb
               }
               , new Object[] {
               T000S41_A120ProfesionalesId, T000S41_A121RubrosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000S45_A122RubrosNombre, T000S45_A40001RubrosImagen_GXI, T000S45_A123RubrosEstado, T000S45_n123RubrosEstado, T000S45_A168RubrosImagen
               }
               , new Object[] {
               T000S46_A221EstadosProfRubNomb
               }
               , new Object[] {
               T000S47_A120ProfesionalesId, T000S47_A121RubrosId
               }
               , new Object[] {
               T000S48_A120ProfesionalesId, T000S48_A126ProfesionalesZonasCorrelativo, T000S48_A113DepartamentoDepartamento, T000S48_A112DepartamentoId, T000S48_A114DepartamentoMunicipioId, T000S48_A110ZonasID, T000S48_n110ZonasID, T000S48_A116PaisID
               }
               , new Object[] {
               T000S49_A113DepartamentoDepartamento, T000S49_A116PaisID
               }
               , new Object[] {
               T000S50_A112DepartamentoId
               }
               , new Object[] {
               T000S51_A110ZonasID
               }
               , new Object[] {
               T000S52_A120ProfesionalesId, T000S52_A126ProfesionalesZonasCorrelativo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000S56_A113DepartamentoDepartamento, T000S56_A116PaisID
               }
               , new Object[] {
               T000S57_A120ProfesionalesId, T000S57_A126ProfesionalesZonasCorrelativo
               }
               , new Object[] {
               T000S58_A120ProfesionalesId, T000S58_A994ProfesionalServicioNombre, T000S58_A995EstadoServProf, T000S58_n995EstadoServProf, T000S58_A993ProfesionalServicioId
               }
               , new Object[] {
               T000S59_A994ProfesionalServicioNombre
               }
               , new Object[] {
               T000S60_A120ProfesionalesId, T000S60_A993ProfesionalServicioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000S64_A994ProfesionalServicioNombre
               }
               , new Object[] {
               T000S65_A120ProfesionalesId, T000S65_A993ProfesionalServicioId
               }
               , new Object[] {
               T000S66_A112DepartamentoId, T000S66_A113DepartamentoDepartamento
               }
               , new Object[] {
               T000S67_A107EstadosTipo, T000S67_A108EstadosGenericosId, T000S67_A109EstadosGenericosNombre
               }
               , new Object[] {
               T000S68_A673BancoId, T000S68_A674BancoNombre, T000S68_A675BancoEstado
               }
               , new Object[] {
               T000S69_A121RubrosId, T000S69_A122RubrosNombre, T000S69_A123RubrosEstado, T000S69_n123RubrosEstado
               }
               , new Object[] {
               T000S70_A112DepartamentoId, T000S70_A114DepartamentoMunicipioId, T000S70_A115DepartamentoMunicipioNombre
               }
               , new Object[] {
               T000S71_A112DepartamentoId, T000S71_A114DepartamentoMunicipioId, T000S71_A110ZonasID, T000S71_A111ZonasNombre
               }
               , new Object[] {
               T000S72_A112DepartamentoId, T000S72_A113DepartamentoDepartamento
               }
               , new Object[] {
               T000S73_A107EstadosTipo
               }
               , new Object[] {
               T000S74_A112DepartamentoId
               }
               , new Object[] {
               T000S75_A110ZonasID
               }
            }
         );
         AV34Pgmname = "Profesionales";
         Z800ProfesionalesCapacidadProducti = (decimal)(8);
         A800ProfesionalesCapacidadProducti = (decimal)(8);
         i800ProfesionalesCapacidadProducti = (decimal)(8);
         Z436ProfesionalesPerAltShop = context.GetMessage( "N", "");
         n436ProfesionalesPerAltShop = false;
         A436ProfesionalesPerAltShop = context.GetMessage( "N", "");
         n436ProfesionalesPerAltShop = false;
         i436ProfesionalesPerAltShop = context.GetMessage( "N", "");
         n436ProfesionalesPerAltShop = false;
         Z267ProfesionalesVerDatPerSol = context.GetMessage( "N", "");
         A267ProfesionalesVerDatPerSol = context.GetMessage( "N", "");
         i267ProfesionalesVerDatPerSol = context.GetMessage( "N", "");
         Z121RubrosId = 0;
         A121RubrosId = 0;
         Z126ProfesionalesZonasCorrelativo = 0;
         A126ProfesionalesZonasCorrelativo = 0;
      }

      private short nIsMod_35 ;
      private short nIsMod_145 ;
      private short Z902ProfesionalesTipoEmpresa ;
      private short Z196ProfesionalesAutoEnumerar ;
      private short Z197ProfesionalesAutoEnuZona ;
      private short Z617ProfesionalesLimitOSF ;
      private short O197ProfesionalesAutoEnuZona ;
      private short Z121RubrosId ;
      private short nRcdDeleted_35 ;
      private short nRcdExists_35 ;
      private short Z126ProfesionalesZonasCorrelativo ;
      private short nRcdDeleted_36 ;
      private short nRcdExists_36 ;
      private short nIsMod_36 ;
      private short nRcdDeleted_145 ;
      private short nRcdExists_145 ;
      private short GxWebError ;
      private short A121RubrosId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short A197ProfesionalesAutoEnuZona ;
      private short A617ProfesionalesLimitOSF ;
      private short nBlankRcdCount35 ;
      private short RcdFound35 ;
      private short B197ProfesionalesAutoEnuZona ;
      private short nBlankRcdUsr35 ;
      private short nBlankRcdCount145 ;
      private short RcdFound145 ;
      private short nBlankRcdUsr145 ;
      private short nBlankRcdCount36 ;
      private short RcdFound36 ;
      private short nBlankRcdUsr36 ;
      private short A902ProfesionalesTipoEmpresa ;
      private short A196ProfesionalesAutoEnumerar ;
      private short RcdFound34 ;
      private short s197ProfesionalesAutoEnuZona ;
      private short A126ProfesionalesZonasCorrelativo ;
      private short nIsDirty_35 ;
      private short nIsDirty_36 ;
      private short nIsDirty_145 ;
      private short subGridlevel_rubros_Backcolorstyle ;
      private short subGridlevel_rubros_Backstyle ;
      private short subGridlevel_zonas_Backcolorstyle ;
      private short subGridlevel_zonas_Backstyle ;
      private short subGridlevel_servicios_Backcolorstyle ;
      private short subGridlevel_servicios_Backstyle ;
      private short gxajaxcallmode ;
      private short i197ProfesionalesAutoEnuZona ;
      private short subGridlevel_rubros_Allowselection ;
      private short subGridlevel_rubros_Allowhovering ;
      private short subGridlevel_rubros_Allowcollapsing ;
      private short subGridlevel_rubros_Collapsed ;
      private short subGridlevel_servicios_Allowselection ;
      private short subGridlevel_servicios_Allowhovering ;
      private short subGridlevel_servicios_Allowcollapsing ;
      private short subGridlevel_servicios_Collapsed ;
      private short subGridlevel_zonas_Allowselection ;
      private short subGridlevel_zonas_Allowhovering ;
      private short subGridlevel_zonas_Allowcollapsing ;
      private short subGridlevel_zonas_Collapsed ;
      private int Z108EstadosGenericosId ;
      private int nRC_GXsfl_122 ;
      private int nGXsfl_122_idx=1 ;
      private int nRC_GXsfl_157 ;
      private int nGXsfl_157_idx=1 ;
      private int nRC_GXsfl_143 ;
      private int nGXsfl_143_idx=1 ;
      private int N108EstadosGenericosId ;
      private int Z125EstadosProfRubId ;
      private int A108EstadosGenericosId ;
      private int A125EstadosProfRubId ;
      private int trnEnded ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesPrimerNombre_Enabled ;
      private int edtProfesionalesSegundoNombre_Enabled ;
      private int edtProfesionalesApellidoPrimero_Enabled ;
      private int edtProfesionalesApellidoSegundo_Enabled ;
      private int imgProfesionalesPhoto_Enabled ;
      private int edtProfesionalesFeedBackCant_Enabled ;
      private int edtProfesionalesTelefono_Enabled ;
      private int edtProfesionalesEmail_Enabled ;
      private int edtProfesionalesDireccion_Enabled ;
      private int edtProfesionalesLimitOSF_Enabled ;
      private int edtProfesionalesAceptoTerminos_Enabled ;
      private int edtProfesionalesDeclaroDatosV_Enabled ;
      private int edtProfesionalesCuentaBancaria_Enabled ;
      private int edtProfesionalesExperiencia_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtEstadosTipo_Visible ;
      private int edtEstadosTipo_Enabled ;
      private int edtProfesionalesCapacidadProducti_Enabled ;
      private int edtProfesionalesCapacidadProducti_Visible ;
      private int edtProfesionalesPerAltShop_Visible ;
      private int edtProfesionalesPerAltShop_Enabled ;
      private int edtProfesionalesFechaAlta_Visible ;
      private int edtProfesionalesFechaAlta_Enabled ;
      private int edtProfesionalesFechaActualizado_Visible ;
      private int edtProfesionalesFechaActualizado_Enabled ;
      private int edtProfesionalesFeedBackProm_Enabled ;
      private int edtProfesionalesFeedBackProm_Visible ;
      private int edtRubrosImagen_Enabled ;
      private int edtEstadosProfRubTipo_Enabled ;
      private int fRowAdded ;
      private int edtProfesionalServicioId_Enabled ;
      private int edtProfesionalServicioNombre_Enabled ;
      private int edtProfesionalesZonasCorrelativo_Enabled ;
      private int edtPaisID_Enabled ;
      private int AV12Insert_EstadosGenericosId ;
      private int Profesionalesfeedback_Maxvalue ;
      private int Profesionalesfeedback_Step ;
      private int Profesionalesfeedback_Coltitlecolor ;
      private int Gxuitabspanel_tabs_Activepage ;
      private int AV35GXV1 ;
      private int subGridlevel_rubros_Backcolor ;
      private int subGridlevel_rubros_Allbackcolor ;
      private int imgprompt_125_Visible ;
      private int subGridlevel_zonas_Backcolor ;
      private int subGridlevel_zonas_Allbackcolor ;
      private int subGridlevel_servicios_Backcolor ;
      private int subGridlevel_servicios_Allbackcolor ;
      private int imgprompt_993_Visible ;
      private int defdynZonasID_Visible ;
      private int defedtPaisID_Enabled ;
      private int defedtProfesionalesZonasCorrelativo_Enabled ;
      private int defedtProfesionalServicioId_Enabled ;
      private int defedtEstadosProfRubTipo_Enabled ;
      private int defdynRubrosId_Enabled ;
      private int i108EstadosGenericosId ;
      private int i125EstadosProfRubId ;
      private int idxLst ;
      private int subGridlevel_rubros_Selectedindex ;
      private int subGridlevel_rubros_Selectioncolor ;
      private int subGridlevel_rubros_Hoveringcolor ;
      private int subGridlevel_servicios_Selectedindex ;
      private int subGridlevel_servicios_Selectioncolor ;
      private int subGridlevel_servicios_Hoveringcolor ;
      private int subGridlevel_zonas_Selectedindex ;
      private int subGridlevel_zonas_Selectioncolor ;
      private int subGridlevel_zonas_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long Z268ProfesionalesFeedBackCant ;
      private long Z673BancoId ;
      private long N673BancoId ;
      private long Z112DepartamentoId ;
      private long Z114DepartamentoMunicipioId ;
      private long Z110ZonasID ;
      private long Z993ProfesionalServicioId ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A673BancoId ;
      private long A110ZonasID ;
      private long A993ProfesionalServicioId ;
      private long A268ProfesionalesFeedBackCant ;
      private long AV32Insert_BancoId ;
      private long GRIDLEVEL_RUBROS_nFirstRecordOnPage ;
      private long GRIDLEVEL_ZONAS_nFirstRecordOnPage ;
      private long GRIDLEVEL_SERVICIOS_nFirstRecordOnPage ;
      private decimal Z800ProfesionalesCapacidadProducti ;
      private decimal Z269ProfesionalesFeedBackProm ;
      private decimal ProfesionalesFeedback ;
      private decimal A800ProfesionalesCapacidadProducti ;
      private decimal A269ProfesionalesFeedBackProm ;
      private decimal A803ProfesionalesTiempoDisponible ;
      private decimal A270ProfesionalesFeedback ;
      private decimal AV14ProfesionalesFeedback ;
      private decimal i800ProfesionalesCapacidadProducti ;
      private decimal Z270ProfesionalesFeedback ;
      private decimal ZV14ProfesionalesFeedback ;
      private string sPrefix ;
      private string sGXsfl_122_idx="0001" ;
      private string sGXsfl_143_idx="0001" ;
      private string wcpOGx_mode ;
      private string wcpOAV7ProfesionalesId ;
      private string Z120ProfesionalesId ;
      private string Z901ProfesionalesRUT ;
      private string Z166ProfesionalesPrimerNombre ;
      private string Z191ProfesionalesSegundoNombre ;
      private string Z167ProfesionalesApellidoPrimero ;
      private string Z192ProfesionalesApellidoSegundo ;
      private string Z170ProfesionalesTelefono ;
      private string Z267ProfesionalesVerDatPerSol ;
      private string Z436ProfesionalesPerAltShop ;
      private string Z680ProfesionalesCuentaBancaria ;
      private string Z107EstadosTipo ;
      private string N107EstadosTipo ;
      private string Z124EstadosProfRubTipo ;
      private string Z995EstadoServProf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A107EstadosTipo ;
      private string A124EstadosProfRubTipo ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7ProfesionalesId ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProfesionalesId_Internalname ;
      private string sGXsfl_157_idx="0001" ;
      private string dynEstadosGenericosId_Internalname ;
      private string A267ProfesionalesVerDatPerSol ;
      private string cmbProfesionalesVerDatPerSol_Internalname ;
      private string dynBancoId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Gxuitabspanel_tabs_Class ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblTabgeneral_title_Internalname ;
      private string lblTabgeneral_title_Jsonclick ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Jsonclick ;
      private string dynEstadosGenericosId_Jsonclick ;
      private string chkProfesionalesEsRUT_Internalname ;
      private string divTb1_Internalname ;
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
      private string divTb2_Internalname ;
      private string imgProfesionalesPhoto_Internalname ;
      private string sImgUrl ;
      private string edtProfesionalesFeedBackCant_Internalname ;
      private string edtProfesionalesFeedBackCant_Jsonclick ;
      private string Profesionalesfeedback_Internalname ;
      private string Profesionalesfeedback_Captionclass ;
      private string Profesionalesfeedback_Captionstyle ;
      private string Profesionalesfeedback_Captionposition ;
      private string edtProfesionalesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A170ProfesionalesTelefono ;
      private string edtProfesionalesTelefono_Jsonclick ;
      private string edtProfesionalesEmail_Internalname ;
      private string edtProfesionalesEmail_Jsonclick ;
      private string edtProfesionalesDireccion_Internalname ;
      private string cmbProfesionalesVerDatPerSol_Jsonclick ;
      private string edtProfesionalesLimitOSF_Internalname ;
      private string edtProfesionalesLimitOSF_Jsonclick ;
      private string edtProfesionalesAceptoTerminos_Internalname ;
      private string edtProfesionalesAceptoTerminos_Jsonclick ;
      private string edtProfesionalesDeclaroDatosV_Internalname ;
      private string edtProfesionalesDeclaroDatosV_Jsonclick ;
      private string dynBancoId_Jsonclick ;
      private string edtProfesionalesCuentaBancaria_Internalname ;
      private string A680ProfesionalesCuentaBancaria ;
      private string edtProfesionalesCuentaBancaria_Jsonclick ;
      private string lblTablevel_rubros_title_Internalname ;
      private string lblTablevel_rubros_title_Jsonclick ;
      private string divTabtablelevel_rubros_Internalname ;
      private string divTableleaflevel_rubros_Internalname ;
      private string edtProfesionalesExperiencia_Internalname ;
      private string lblTablevel_servicios_title_Internalname ;
      private string lblTablevel_servicios_title_Jsonclick ;
      private string divTabtablelevel_servicios_Internalname ;
      private string divTableleaflevel_servicios_Internalname ;
      private string lblTablevel_zonas_title_Internalname ;
      private string lblTablevel_zonas_title_Jsonclick ;
      private string divTabtablelevel_zonas_Internalname ;
      private string divTableleaflevel_zonas_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtEstadosTipo_Internalname ;
      private string edtEstadosTipo_Jsonclick ;
      private string edtProfesionalesCapacidadProducti_Internalname ;
      private string edtProfesionalesCapacidadProducti_Jsonclick ;
      private string edtProfesionalesPerAltShop_Internalname ;
      private string A436ProfesionalesPerAltShop ;
      private string edtProfesionalesPerAltShop_Jsonclick ;
      private string edtProfesionalesFechaAlta_Internalname ;
      private string edtProfesionalesFechaAlta_Jsonclick ;
      private string edtProfesionalesFechaActualizado_Internalname ;
      private string edtProfesionalesFechaActualizado_Jsonclick ;
      private string edtProfesionalesFeedBackProm_Internalname ;
      private string edtProfesionalesFeedBackProm_Jsonclick ;
      private string sMode35 ;
      private string dynRubrosId_Internalname ;
      private string edtRubrosImagen_Internalname ;
      private string edtEstadosProfRubTipo_Internalname ;
      private string cmbEstadosProfRubId_Internalname ;
      private string cmbRubrosEstado_Internalname ;
      private string imgprompt_125_Link ;
      private string sStyleString ;
      private string subGridlevel_rubros_Internalname ;
      private string sMode145 ;
      private string edtProfesionalServicioId_Internalname ;
      private string edtProfesionalServicioNombre_Internalname ;
      private string cmbEstadoServProf_Internalname ;
      private string subGridlevel_servicios_Internalname ;
      private string sMode36 ;
      private string edtProfesionalesZonasCorrelativo_Internalname ;
      private string edtPaisID_Internalname ;
      private string dynDepartamentoId_Internalname ;
      private string dynDepartamentoMunicipioId_Internalname ;
      private string dynZonasID_Internalname ;
      private string subGridlevel_zonas_Internalname ;
      private string A901ProfesionalesRUT ;
      private string AV11Insert_EstadosTipo ;
      private string A674BancoNombre ;
      private string AV34Pgmname ;
      private string A122RubrosNombre ;
      private string A221EstadosProfRubNomb ;
      private string A113DepartamentoDepartamento ;
      private string Profesionalesfeedback_Objectcall ;
      private string Profesionalesfeedback_Class ;
      private string Profesionalesfeedback_Ratingclass ;
      private string Profesionalesfeedback_Captionvalue ;
      private string Profesionalesfeedback_Coltitle ;
      private string Profesionalesfeedback_Coltitlefont ;
      private string Gxuitabspanel_tabs_Objectcall ;
      private string Gxuitabspanel_tabs_Activepagecontrolname ;
      private string hsh ;
      private string sMode34 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A994ProfesionalServicioNombre ;
      private string A995EstadoServProf ;
      private string A116PaisID ;
      private string A123RubrosEstado ;
      private string GXEncryptionTmp ;
      private string Z674BancoNombre ;
      private string Z122RubrosNombre ;
      private string Z123RubrosEstado ;
      private string Z221EstadosProfRubNomb ;
      private string Z113DepartamentoDepartamento ;
      private string Z116PaisID ;
      private string Z994ProfesionalServicioNombre ;
      private string imgprompt_125_Internalname ;
      private string sGXsfl_122_fel_idx="0001" ;
      private string subGridlevel_rubros_Class ;
      private string subGridlevel_rubros_Linesclass ;
      private string dynRubrosId_Jsonclick ;
      private string ROClassString ;
      private string edtEstadosProfRubTipo_Jsonclick ;
      private string cmbEstadosProfRubId_Jsonclick ;
      private string imgprompt_125_gximage ;
      private string cmbRubrosEstado_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sGXsfl_157_fel_idx="0001" ;
      private string subGridlevel_zonas_Class ;
      private string subGridlevel_zonas_Linesclass ;
      private string edtProfesionalesZonasCorrelativo_Jsonclick ;
      private string edtPaisID_Jsonclick ;
      private string dynDepartamentoId_Jsonclick ;
      private string dynDepartamentoMunicipioId_Jsonclick ;
      private string dynZonasID_Jsonclick ;
      private string imgprompt_993_Internalname ;
      private string sGXsfl_143_fel_idx="0001" ;
      private string subGridlevel_servicios_Class ;
      private string subGridlevel_servicios_Linesclass ;
      private string imgprompt_993_Link ;
      private string edtProfesionalServicioId_Jsonclick ;
      private string imgprompt_993_gximage ;
      private string edtProfesionalServicioNombre_Jsonclick ;
      private string cmbEstadoServProf_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string i267ProfesionalesVerDatPerSol ;
      private string i436ProfesionalesPerAltShop ;
      private string i124EstadosProfRubTipo ;
      private string subGridlevel_rubros_Header ;
      private string subGridlevel_servicios_Header ;
      private string subGridlevel_zonas_Header ;
      private string gxwrpcisep ;
      private DateTime Z199ProfesionalesFechaAlta ;
      private DateTime Z200ProfesionalesFechaActualizado ;
      private DateTime Z678ProfesionalesAceptoTerminos ;
      private DateTime Z679ProfesionalesDeclaroDatosV ;
      private DateTime A678ProfesionalesAceptoTerminos ;
      private DateTime A679ProfesionalesDeclaroDatosV ;
      private DateTime A199ProfesionalesFechaAlta ;
      private DateTime A200ProfesionalesFechaActualizado ;
      private DateTime i199ProfesionalesFechaAlta ;
      private DateTime i200ProfesionalesFechaActualizado ;
      private DateTime Z900ProfesionalesFechaNacimiento ;
      private DateTime A900ProfesionalesFechaNacimiento ;
      private bool Z676ProfesionalesEsRUT ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n673BancoId ;
      private bool n110ZonasID ;
      private bool wbErr ;
      private bool A676ProfesionalesEsRUT ;
      private bool n676ProfesionalesEsRUT ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool A169ProfesionalesPhoto_IsBlob ;
      private bool bGXsfl_122_Refreshing=false ;
      private bool bGXsfl_143_Refreshing=false ;
      private bool bGXsfl_157_Refreshing=false ;
      private bool n900ProfesionalesFechaNacimiento ;
      private bool n901ProfesionalesRUT ;
      private bool n902ProfesionalesTipoEmpresa ;
      private bool n193ProfesionalesEmail ;
      private bool n436ProfesionalesPerAltShop ;
      private bool n677ProfesionalesExperiencia ;
      private bool n678ProfesionalesAceptoTerminos ;
      private bool n679ProfesionalesDeclaroDatosV ;
      private bool n680ProfesionalesCuentaBancaria ;
      private bool n617ProfesionalesLimitOSF ;
      private bool Profesionalesfeedback_Enabled ;
      private bool Profesionalesfeedback_Isabstractlayoutcontrol ;
      private bool Profesionalesfeedback_Usercontroliscolumn ;
      private bool Profesionalesfeedback_Visible ;
      private bool Gxuitabspanel_tabs_Enabled ;
      private bool Gxuitabspanel_tabs_Visible ;
      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool Gx_longc ;
      private bool n123RubrosEstado ;
      private bool n995EstadoServProf ;
      private bool A168RubrosImagen_IsBlob ;
      private bool gxdyncontrolsrefreshing ;
      private string Z193ProfesionalesEmail ;
      private string Z198ProfesionalesDireccion ;
      private string Z677ProfesionalesExperiencia ;
      private string A40000ProfesionalesPhoto_GXI ;
      private string A193ProfesionalesEmail ;
      private string A198ProfesionalesDireccion ;
      private string A677ProfesionalesExperiencia ;
      private string A886ProfesionalesNombreCompleto ;
      private string A40001RubrosImagen_GXI ;
      private string Z40000ProfesionalesPhoto_GXI ;
      private string Z40001RubrosImagen_GXI ;
      private string A169ProfesionalesPhoto ;
      private string A168RubrosImagen ;
      private string Z169ProfesionalesPhoto ;
      private string Z168RubrosImagen ;
      private IGxSession AV10WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_rubrosContainer ;
      private GXWebGrid Gridlevel_serviciosContainer ;
      private GXWebGrid Gridlevel_zonasContainer ;
      private GXWebRow Gridlevel_rubrosRow ;
      private GXWebRow Gridlevel_zonasRow ;
      private GXWebRow Gridlevel_serviciosRow ;
      private GXWebColumn Gridlevel_rubrosColumn ;
      private GXWebColumn Gridlevel_serviciosColumn ;
      private GXWebColumn Gridlevel_zonasColumn ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private GXUserControl ucProfesionalesfeedback ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynEstadosGenericosId ;
      private GXCheckbox chkProfesionalesEsRUT ;
      private GXCombobox cmbProfesionalesVerDatPerSol ;
      private GXCombobox dynBancoId ;
      private GXCombobox dynRubrosId ;
      private GXCombobox cmbEstadosProfRubId ;
      private GXCombobox cmbRubrosEstado ;
      private GXCombobox cmbEstadoServProf ;
      private GXCombobox dynDepartamentoId ;
      private GXCombobox dynDepartamentoMunicipioId ;
      private GXCombobox dynZonasID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV15WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T000S17_A674BancoNombre ;
      private string[] T000S18_A120ProfesionalesId ;
      private DateTime[] T000S18_A199ProfesionalesFechaAlta ;
      private DateTime[] T000S18_A200ProfesionalesFechaActualizado ;
      private DateTime[] T000S18_A900ProfesionalesFechaNacimiento ;
      private bool[] T000S18_n900ProfesionalesFechaNacimiento ;
      private string[] T000S18_A901ProfesionalesRUT ;
      private bool[] T000S18_n901ProfesionalesRUT ;
      private short[] T000S18_A902ProfesionalesTipoEmpresa ;
      private bool[] T000S18_n902ProfesionalesTipoEmpresa ;
      private bool[] T000S18_A676ProfesionalesEsRUT ;
      private bool[] T000S18_n676ProfesionalesEsRUT ;
      private string[] T000S18_A166ProfesionalesPrimerNombre ;
      private string[] T000S18_A191ProfesionalesSegundoNombre ;
      private string[] T000S18_A167ProfesionalesApellidoPrimero ;
      private string[] T000S18_A192ProfesionalesApellidoSegundo ;
      private string[] T000S18_A40000ProfesionalesPhoto_GXI ;
      private string[] T000S18_A170ProfesionalesTelefono ;
      private string[] T000S18_A193ProfesionalesEmail ;
      private bool[] T000S18_n193ProfesionalesEmail ;
      private string[] T000S18_A198ProfesionalesDireccion ;
      private string[] T000S18_A267ProfesionalesVerDatPerSol ;
      private string[] T000S18_A436ProfesionalesPerAltShop ;
      private bool[] T000S18_n436ProfesionalesPerAltShop ;
      private short[] T000S18_A196ProfesionalesAutoEnumerar ;
      private short[] T000S18_A197ProfesionalesAutoEnuZona ;
      private string[] T000S18_A677ProfesionalesExperiencia ;
      private bool[] T000S18_n677ProfesionalesExperiencia ;
      private DateTime[] T000S18_A678ProfesionalesAceptoTerminos ;
      private bool[] T000S18_n678ProfesionalesAceptoTerminos ;
      private DateTime[] T000S18_A679ProfesionalesDeclaroDatosV ;
      private bool[] T000S18_n679ProfesionalesDeclaroDatosV ;
      private string[] T000S18_A680ProfesionalesCuentaBancaria ;
      private bool[] T000S18_n680ProfesionalesCuentaBancaria ;
      private decimal[] T000S18_A800ProfesionalesCapacidadProducti ;
      private string[] T000S18_A674BancoNombre ;
      private short[] T000S18_A617ProfesionalesLimitOSF ;
      private bool[] T000S18_n617ProfesionalesLimitOSF ;
      private long[] T000S18_A268ProfesionalesFeedBackCant ;
      private decimal[] T000S18_A269ProfesionalesFeedBackProm ;
      private string[] T000S18_A107EstadosTipo ;
      private int[] T000S18_A108EstadosGenericosId ;
      private long[] T000S18_A673BancoId ;
      private bool[] T000S18_n673BancoId ;
      private string[] T000S18_A169ProfesionalesPhoto ;
      private string[] T000S16_A107EstadosTipo ;
      private string[] T000S19_A674BancoNombre ;
      private string[] T000S20_A107EstadosTipo ;
      private string[] T000S21_A120ProfesionalesId ;
      private string[] T000S15_A120ProfesionalesId ;
      private DateTime[] T000S15_A199ProfesionalesFechaAlta ;
      private DateTime[] T000S15_A200ProfesionalesFechaActualizado ;
      private DateTime[] T000S15_A900ProfesionalesFechaNacimiento ;
      private bool[] T000S15_n900ProfesionalesFechaNacimiento ;
      private string[] T000S15_A901ProfesionalesRUT ;
      private bool[] T000S15_n901ProfesionalesRUT ;
      private short[] T000S15_A902ProfesionalesTipoEmpresa ;
      private bool[] T000S15_n902ProfesionalesTipoEmpresa ;
      private bool[] T000S15_A676ProfesionalesEsRUT ;
      private bool[] T000S15_n676ProfesionalesEsRUT ;
      private string[] T000S15_A166ProfesionalesPrimerNombre ;
      private string[] T000S15_A191ProfesionalesSegundoNombre ;
      private string[] T000S15_A167ProfesionalesApellidoPrimero ;
      private string[] T000S15_A192ProfesionalesApellidoSegundo ;
      private string[] T000S15_A40000ProfesionalesPhoto_GXI ;
      private string[] T000S15_A170ProfesionalesTelefono ;
      private string[] T000S15_A193ProfesionalesEmail ;
      private bool[] T000S15_n193ProfesionalesEmail ;
      private string[] T000S15_A198ProfesionalesDireccion ;
      private string[] T000S15_A267ProfesionalesVerDatPerSol ;
      private string[] T000S15_A436ProfesionalesPerAltShop ;
      private bool[] T000S15_n436ProfesionalesPerAltShop ;
      private short[] T000S15_A196ProfesionalesAutoEnumerar ;
      private short[] T000S15_A197ProfesionalesAutoEnuZona ;
      private string[] T000S15_A677ProfesionalesExperiencia ;
      private bool[] T000S15_n677ProfesionalesExperiencia ;
      private DateTime[] T000S15_A678ProfesionalesAceptoTerminos ;
      private bool[] T000S15_n678ProfesionalesAceptoTerminos ;
      private DateTime[] T000S15_A679ProfesionalesDeclaroDatosV ;
      private bool[] T000S15_n679ProfesionalesDeclaroDatosV ;
      private string[] T000S15_A680ProfesionalesCuentaBancaria ;
      private bool[] T000S15_n680ProfesionalesCuentaBancaria ;
      private decimal[] T000S15_A800ProfesionalesCapacidadProducti ;
      private short[] T000S15_A617ProfesionalesLimitOSF ;
      private bool[] T000S15_n617ProfesionalesLimitOSF ;
      private long[] T000S15_A268ProfesionalesFeedBackCant ;
      private decimal[] T000S15_A269ProfesionalesFeedBackProm ;
      private string[] T000S15_A107EstadosTipo ;
      private int[] T000S15_A108EstadosGenericosId ;
      private long[] T000S15_A673BancoId ;
      private bool[] T000S15_n673BancoId ;
      private string[] T000S15_A169ProfesionalesPhoto ;
      private string[] T000S22_A120ProfesionalesId ;
      private string[] T000S23_A120ProfesionalesId ;
      private string[] T000S14_A120ProfesionalesId ;
      private DateTime[] T000S14_A199ProfesionalesFechaAlta ;
      private DateTime[] T000S14_A200ProfesionalesFechaActualizado ;
      private DateTime[] T000S14_A900ProfesionalesFechaNacimiento ;
      private bool[] T000S14_n900ProfesionalesFechaNacimiento ;
      private string[] T000S14_A901ProfesionalesRUT ;
      private bool[] T000S14_n901ProfesionalesRUT ;
      private short[] T000S14_A902ProfesionalesTipoEmpresa ;
      private bool[] T000S14_n902ProfesionalesTipoEmpresa ;
      private bool[] T000S14_A676ProfesionalesEsRUT ;
      private bool[] T000S14_n676ProfesionalesEsRUT ;
      private string[] T000S14_A166ProfesionalesPrimerNombre ;
      private string[] T000S14_A191ProfesionalesSegundoNombre ;
      private string[] T000S14_A167ProfesionalesApellidoPrimero ;
      private string[] T000S14_A192ProfesionalesApellidoSegundo ;
      private string[] T000S14_A40000ProfesionalesPhoto_GXI ;
      private string[] T000S14_A170ProfesionalesTelefono ;
      private string[] T000S14_A193ProfesionalesEmail ;
      private bool[] T000S14_n193ProfesionalesEmail ;
      private string[] T000S14_A198ProfesionalesDireccion ;
      private string[] T000S14_A267ProfesionalesVerDatPerSol ;
      private string[] T000S14_A436ProfesionalesPerAltShop ;
      private bool[] T000S14_n436ProfesionalesPerAltShop ;
      private short[] T000S14_A196ProfesionalesAutoEnumerar ;
      private short[] T000S14_A197ProfesionalesAutoEnuZona ;
      private string[] T000S14_A677ProfesionalesExperiencia ;
      private bool[] T000S14_n677ProfesionalesExperiencia ;
      private DateTime[] T000S14_A678ProfesionalesAceptoTerminos ;
      private bool[] T000S14_n678ProfesionalesAceptoTerminos ;
      private DateTime[] T000S14_A679ProfesionalesDeclaroDatosV ;
      private bool[] T000S14_n679ProfesionalesDeclaroDatosV ;
      private string[] T000S14_A680ProfesionalesCuentaBancaria ;
      private bool[] T000S14_n680ProfesionalesCuentaBancaria ;
      private decimal[] T000S14_A800ProfesionalesCapacidadProducti ;
      private short[] T000S14_A617ProfesionalesLimitOSF ;
      private bool[] T000S14_n617ProfesionalesLimitOSF ;
      private long[] T000S14_A268ProfesionalesFeedBackCant ;
      private decimal[] T000S14_A269ProfesionalesFeedBackProm ;
      private string[] T000S14_A107EstadosTipo ;
      private int[] T000S14_A108EstadosGenericosId ;
      private long[] T000S14_A673BancoId ;
      private bool[] T000S14_n673BancoId ;
      private string[] T000S14_A169ProfesionalesPhoto ;
      private string[] T000S28_A674BancoNombre ;
      private long[] T000S29_A461CentroCostosId ;
      private long[] T000S29_A466CentroCostosDetallesId ;
      private long[] T000S30_A976ProfesionalesRestriccionId ;
      private long[] T000S31_A450ProfComisionesID ;
      private long[] T000S32_A127SolicitudesID ;
      private long[] T000S32_A140RelacionesId ;
      private long[] T000S33_A422PostulacionesId ;
      private string[] T000S33_A120ProfesionalesId ;
      private long[] T000S34_A590Listaid ;
      private long[] T000S34_A133ProveedorID ;
      private string[] T000S34_A120ProfesionalesId ;
      private long[] T000S35_A503ComisionesID ;
      private string[] T000S35_A120ProfesionalesId ;
      private string[] T000S37_A120ProfesionalesId ;
      private string[] T000S12_A122RubrosNombre ;
      private string[] T000S12_A40001RubrosImagen_GXI ;
      private string[] T000S12_A123RubrosEstado ;
      private bool[] T000S12_n123RubrosEstado ;
      private string[] T000S12_A168RubrosImagen ;
      private string[] T000S13_A221EstadosProfRubNomb ;
      private string[] T000S38_A120ProfesionalesId ;
      private string[] T000S38_A122RubrosNombre ;
      private string[] T000S38_A40001RubrosImagen_GXI ;
      private string[] T000S38_A123RubrosEstado ;
      private bool[] T000S38_n123RubrosEstado ;
      private string[] T000S38_A221EstadosProfRubNomb ;
      private short[] T000S38_A121RubrosId ;
      private string[] T000S38_A124EstadosProfRubTipo ;
      private int[] T000S38_A125EstadosProfRubId ;
      private string[] T000S38_A168RubrosImagen ;
      private string[] T000S39_A122RubrosNombre ;
      private string[] T000S39_A40001RubrosImagen_GXI ;
      private string[] T000S39_A123RubrosEstado ;
      private bool[] T000S39_n123RubrosEstado ;
      private string[] T000S39_A168RubrosImagen ;
      private string[] T000S40_A221EstadosProfRubNomb ;
      private string[] T000S41_A120ProfesionalesId ;
      private short[] T000S41_A121RubrosId ;
      private string[] T000S11_A120ProfesionalesId ;
      private short[] T000S11_A121RubrosId ;
      private string[] T000S11_A124EstadosProfRubTipo ;
      private int[] T000S11_A125EstadosProfRubId ;
      private string[] T000S10_A120ProfesionalesId ;
      private short[] T000S10_A121RubrosId ;
      private string[] T000S10_A124EstadosProfRubTipo ;
      private int[] T000S10_A125EstadosProfRubId ;
      private string[] T000S45_A122RubrosNombre ;
      private string[] T000S45_A40001RubrosImagen_GXI ;
      private string[] T000S45_A123RubrosEstado ;
      private bool[] T000S45_n123RubrosEstado ;
      private string[] T000S45_A168RubrosImagen ;
      private string[] T000S46_A221EstadosProfRubNomb ;
      private string[] T000S47_A120ProfesionalesId ;
      private short[] T000S47_A121RubrosId ;
      private string[] T000S48_A120ProfesionalesId ;
      private short[] T000S48_A126ProfesionalesZonasCorrelativo ;
      private string[] T000S48_A113DepartamentoDepartamento ;
      private long[] T000S48_A112DepartamentoId ;
      private long[] T000S48_A114DepartamentoMunicipioId ;
      private long[] T000S48_A110ZonasID ;
      private bool[] T000S48_n110ZonasID ;
      private string[] T000S48_A116PaisID ;
      private string[] T000S7_A113DepartamentoDepartamento ;
      private string[] T000S7_A116PaisID ;
      private long[] T000S8_A112DepartamentoId ;
      private long[] T000S9_A110ZonasID ;
      private bool[] T000S9_n110ZonasID ;
      private string[] T000S49_A113DepartamentoDepartamento ;
      private string[] T000S49_A116PaisID ;
      private long[] T000S50_A112DepartamentoId ;
      private long[] T000S51_A110ZonasID ;
      private bool[] T000S51_n110ZonasID ;
      private string[] T000S52_A120ProfesionalesId ;
      private short[] T000S52_A126ProfesionalesZonasCorrelativo ;
      private string[] T000S6_A120ProfesionalesId ;
      private short[] T000S6_A126ProfesionalesZonasCorrelativo ;
      private long[] T000S6_A112DepartamentoId ;
      private long[] T000S6_A114DepartamentoMunicipioId ;
      private long[] T000S6_A110ZonasID ;
      private bool[] T000S6_n110ZonasID ;
      private string[] T000S5_A120ProfesionalesId ;
      private short[] T000S5_A126ProfesionalesZonasCorrelativo ;
      private long[] T000S5_A112DepartamentoId ;
      private long[] T000S5_A114DepartamentoMunicipioId ;
      private long[] T000S5_A110ZonasID ;
      private bool[] T000S5_n110ZonasID ;
      private string[] T000S56_A113DepartamentoDepartamento ;
      private string[] T000S56_A116PaisID ;
      private string[] T000S57_A120ProfesionalesId ;
      private short[] T000S57_A126ProfesionalesZonasCorrelativo ;
      private string[] T000S58_A120ProfesionalesId ;
      private string[] T000S58_A994ProfesionalServicioNombre ;
      private string[] T000S58_A995EstadoServProf ;
      private bool[] T000S58_n995EstadoServProf ;
      private long[] T000S58_A993ProfesionalServicioId ;
      private string[] T000S4_A994ProfesionalServicioNombre ;
      private string[] T000S59_A994ProfesionalServicioNombre ;
      private string[] T000S60_A120ProfesionalesId ;
      private long[] T000S60_A993ProfesionalServicioId ;
      private string[] T000S3_A120ProfesionalesId ;
      private string[] T000S3_A995EstadoServProf ;
      private bool[] T000S3_n995EstadoServProf ;
      private long[] T000S3_A993ProfesionalServicioId ;
      private string[] T000S2_A120ProfesionalesId ;
      private string[] T000S2_A995EstadoServProf ;
      private bool[] T000S2_n995EstadoServProf ;
      private long[] T000S2_A993ProfesionalServicioId ;
      private string[] T000S64_A994ProfesionalServicioNombre ;
      private string[] T000S65_A120ProfesionalesId ;
      private long[] T000S65_A993ProfesionalServicioId ;
      private long[] T000S66_A112DepartamentoId ;
      private string[] T000S66_A113DepartamentoDepartamento ;
      private string[] T000S67_A107EstadosTipo ;
      private int[] T000S67_A108EstadosGenericosId ;
      private string[] T000S67_A109EstadosGenericosNombre ;
      private long[] T000S68_A673BancoId ;
      private bool[] T000S68_n673BancoId ;
      private string[] T000S68_A674BancoNombre ;
      private string[] T000S68_A675BancoEstado ;
      private short[] T000S69_A121RubrosId ;
      private string[] T000S69_A122RubrosNombre ;
      private string[] T000S69_A123RubrosEstado ;
      private bool[] T000S69_n123RubrosEstado ;
      private long[] T000S70_A112DepartamentoId ;
      private long[] T000S70_A114DepartamentoMunicipioId ;
      private string[] T000S70_A115DepartamentoMunicipioNombre ;
      private long[] T000S71_A112DepartamentoId ;
      private long[] T000S71_A114DepartamentoMunicipioId ;
      private long[] T000S71_A110ZonasID ;
      private bool[] T000S71_n110ZonasID ;
      private string[] T000S71_A111ZonasNombre ;
      private long[] T000S72_A112DepartamentoId ;
      private string[] T000S72_A113DepartamentoDepartamento ;
      private string[] T000S73_A107EstadosTipo ;
      private long[] T000S74_A112DepartamentoId ;
      private long[] T000S75_A110ZonasID ;
      private bool[] T000S75_n110ZonasID ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class profesionales__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class profesionales__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new UpdateCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new UpdateCursor(def[40])
       ,new UpdateCursor(def[41])
       ,new UpdateCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new ForEachCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new ForEachCursor(def[47])
       ,new ForEachCursor(def[48])
       ,new ForEachCursor(def[49])
       ,new ForEachCursor(def[50])
       ,new UpdateCursor(def[51])
       ,new UpdateCursor(def[52])
       ,new UpdateCursor(def[53])
       ,new ForEachCursor(def[54])
       ,new ForEachCursor(def[55])
       ,new ForEachCursor(def[56])
       ,new ForEachCursor(def[57])
       ,new ForEachCursor(def[58])
       ,new UpdateCursor(def[59])
       ,new UpdateCursor(def[60])
       ,new UpdateCursor(def[61])
       ,new ForEachCursor(def[62])
       ,new ForEachCursor(def[63])
       ,new ForEachCursor(def[64])
       ,new ForEachCursor(def[65])
       ,new ForEachCursor(def[66])
       ,new ForEachCursor(def[67])
       ,new ForEachCursor(def[68])
       ,new ForEachCursor(def[69])
       ,new ForEachCursor(def[70])
       ,new ForEachCursor(def[71])
       ,new ForEachCursor(def[72])
       ,new ForEachCursor(def[73])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000S2;
        prmT000S2 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S3;
        prmT000S3 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S4;
        prmT000S4 = new Object[] {
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S5;
        prmT000S5 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmT000S6;
        prmT000S6 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmT000S7;
        prmT000S7 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000S8;
        prmT000S8 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S9;
        prmT000S9 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S10;
        prmT000S10 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000S11;
        prmT000S11 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000S12;
        prmT000S12 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000S13;
        prmT000S13 = new Object[] {
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
        };
        Object[] prmT000S14;
        prmT000S14 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S15;
        prmT000S15 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S16;
        prmT000S16 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000S17;
        prmT000S17 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000S18;
        prmT000S18 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S19;
        prmT000S19 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000S20;
        prmT000S20 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000S21;
        prmT000S21 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S22;
        prmT000S22 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S23;
        prmT000S23 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S24;
        prmT000S24 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesFechaActualizado",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesFechaNacimiento",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@ProfesionalesRUT",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProfesionalesTipoEmpresa",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesEsRUT",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesPrimerNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesSegundoNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoPrimero",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoSegundo",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesPhoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ProfesionalesPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=11, Tbl="Profesionales", Fld="ProfesionalesPhoto"} ,
        new ParDef("@ProfesionalesTelefono",GXType.NChar,20,0) ,
        new ParDef("@ProfesionalesEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProfesionalesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@ProfesionalesVerDatPerSol",GXType.NChar,1,0) ,
        new ParDef("@ProfesionalesPerAltShop",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProfesionalesAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesAutoEnuZona",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesExperiencia",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProfesionalesAceptoTerminos",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProfesionalesDeclaroDatosV",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProfesionalesCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@ProfesionalesCapacidadProducti",GXType.Decimal,10,2) ,
        new ParDef("@ProfesionalesLimitOSF",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesFeedBackProm",GXType.Decimal,18,2) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000S25;
        prmT000S25 = new Object[] {
        new ParDef("@ProfesionalesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesFechaActualizado",GXType.DateTime,8,5) ,
        new ParDef("@ProfesionalesFechaNacimiento",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@ProfesionalesRUT",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@ProfesionalesTipoEmpresa",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesEsRUT",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesPrimerNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesSegundoNombre",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoPrimero",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesApellidoSegundo",GXType.NChar,30,0) ,
        new ParDef("@ProfesionalesTelefono",GXType.NChar,20,0) ,
        new ParDef("@ProfesionalesEmail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@ProfesionalesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@ProfesionalesVerDatPerSol",GXType.NChar,1,0) ,
        new ParDef("@ProfesionalesPerAltShop",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@ProfesionalesAutoEnumerar",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesAutoEnuZona",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesExperiencia",GXType.NVarChar,1024,0){Nullable=true} ,
        new ParDef("@ProfesionalesAceptoTerminos",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProfesionalesDeclaroDatosV",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ProfesionalesCuentaBancaria",GXType.NChar,50,0){Nullable=true} ,
        new ParDef("@ProfesionalesCapacidadProducti",GXType.Decimal,10,2) ,
        new ParDef("@ProfesionalesLimitOSF",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@ProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesFeedBackProm",GXType.Decimal,18,2) ,
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0) ,
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S26;
        prmT000S26 = new Object[] {
        new ParDef("@ProfesionalesPhoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@ProfesionalesPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Profesionales", Fld="ProfesionalesPhoto"} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S27;
        prmT000S27 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S28;
        prmT000S28 = new Object[] {
        new ParDef("@BancoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000S29;
        prmT000S29 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S30;
        prmT000S30 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S31;
        prmT000S31 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S32;
        prmT000S32 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S33;
        prmT000S33 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S34;
        prmT000S34 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S35;
        prmT000S35 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S36;
        prmT000S36 = new Object[] {
        new ParDef("@ProfesionalesAutoEnuZona",GXType.Int16,4,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S37;
        prmT000S37 = new Object[] {
        };
        Object[] prmT000S38;
        prmT000S38 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000S39;
        prmT000S39 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000S40;
        prmT000S40 = new Object[] {
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
        };
        Object[] prmT000S41;
        prmT000S41 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000S42;
        prmT000S42 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0) ,
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
        };
        Object[] prmT000S43;
        prmT000S43 = new Object[] {
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000S44;
        prmT000S44 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000S45;
        prmT000S45 = new Object[] {
        new ParDef("@RubrosId",GXType.Int16,4,0)
        };
        Object[] prmT000S46;
        prmT000S46 = new Object[] {
        new ParDef("@EstadosProfRubTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosProfRubId",GXType.Int32,5,0)
        };
        Object[] prmT000S47;
        prmT000S47 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S48;
        prmT000S48 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmT000S49;
        prmT000S49 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000S50;
        prmT000S50 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S51;
        prmT000S51 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S52;
        prmT000S52 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmT000S53;
        prmT000S53 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0) ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT000S54;
        prmT000S54 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0) ,
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmT000S55;
        prmT000S55 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalesZonasCorrelativo",GXType.Int16,4,0)
        };
        Object[] prmT000S56;
        prmT000S56 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000S57;
        prmT000S57 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S58;
        prmT000S58 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S59;
        prmT000S59 = new Object[] {
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S60;
        prmT000S60 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S61;
        prmT000S61 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@EstadoServProf",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S62;
        prmT000S62 = new Object[] {
        new ParDef("@EstadoServProf",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S63;
        prmT000S63 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S64;
        prmT000S64 = new Object[] {
        new ParDef("@ProfesionalServicioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S65;
        prmT000S65 = new Object[] {
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmT000S66;
        prmT000S66 = new Object[] {
        };
        Object[] prmT000S67;
        prmT000S67 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0)
        };
        Object[] prmT000S68;
        prmT000S68 = new Object[] {
        };
        Object[] prmT000S69;
        prmT000S69 = new Object[] {
        };
        Object[] prmT000S70;
        prmT000S70 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0)
        };
        Object[] prmT000S71;
        prmT000S71 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S72;
        prmT000S72 = new Object[] {
        };
        Object[] prmT000S73;
        prmT000S73 = new Object[] {
        new ParDef("@EstadosTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosGenericosId",GXType.Int32,5,0)
        };
        Object[] prmT000S74;
        prmT000S74 = new Object[] {
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        Object[] prmT000S75;
        prmT000S75 = new Object[] {
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0) ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000S2", "SELECT [ProfesionalesId], [EstadoServProf], [ProfesionalServicioId] AS ProfesionalServicioId FROM [ProfesionalesServicios] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalServicioId] = @ProfesionalServicioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S3", "SELECT [ProfesionalesId], [EstadoServProf], [ProfesionalServicioId] AS ProfesionalServicioId FROM [ProfesionalesServicios] WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalServicioId] = @ProfesionalServicioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S4", "SELECT [ServiciosNombre] AS ProfesionalServicioNombre FROM [Servicios] WHERE [ServiciosId] = @ProfesionalServicioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S5", "SELECT [ProfesionalesId], [ProfesionalesZonasCorrelativo], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID] FROM [ProfesionalesZonas] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S6", "SELECT [ProfesionalesId], [ProfesionalesZonasCorrelativo], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID] FROM [ProfesionalesZonas] WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S7", "SELECT [DepartamentoDepartamento], [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S8", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S9", "SELECT [ZonasID] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S10", "SELECT [ProfesionalesId], [RubrosId], [EstadosProfRubTipo] AS EstadosProfRubTipo, [EstadosProfRubId] AS EstadosProfRubId FROM [ProfesionalesRubros] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S11", "SELECT [ProfesionalesId], [RubrosId], [EstadosProfRubTipo] AS EstadosProfRubTipo, [EstadosProfRubId] AS EstadosProfRubId FROM [ProfesionalesRubros] WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S12", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S13", "SELECT [EstadosGenericosNombre] AS EstadosProfRubNomb FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosProfRubTipo AND [EstadosGenericosId] = @EstadosProfRubId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S14", "SELECT [ProfesionalesId], [ProfesionalesFechaAlta], [ProfesionalesFechaActualizado], [ProfesionalesFechaNacimiento], [ProfesionalesRUT], [ProfesionalesTipoEmpresa], [ProfesionalesEsRUT], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesEmail], [ProfesionalesDireccion], [ProfesionalesVerDatPerSol], [ProfesionalesPerAltShop], [ProfesionalesAutoEnumerar], [ProfesionalesAutoEnuZona], [ProfesionalesExperiencia], [ProfesionalesAceptoTerminos], [ProfesionalesDeclaroDatosV], [ProfesionalesCuentaBancaria], [ProfesionalesCapacidadProducti], [ProfesionalesLimitOSF], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [EstadosTipo], [EstadosGenericosId], [BancoId], [ProfesionalesPhoto] FROM [Profesionales] WITH (UPDLOCK) WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S15", "SELECT [ProfesionalesId], [ProfesionalesFechaAlta], [ProfesionalesFechaActualizado], [ProfesionalesFechaNacimiento], [ProfesionalesRUT], [ProfesionalesTipoEmpresa], [ProfesionalesEsRUT], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesEmail], [ProfesionalesDireccion], [ProfesionalesVerDatPerSol], [ProfesionalesPerAltShop], [ProfesionalesAutoEnumerar], [ProfesionalesAutoEnuZona], [ProfesionalesExperiencia], [ProfesionalesAceptoTerminos], [ProfesionalesDeclaroDatosV], [ProfesionalesCuentaBancaria], [ProfesionalesCapacidadProducti], [ProfesionalesLimitOSF], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [EstadosTipo], [EstadosGenericosId], [BancoId], [ProfesionalesPhoto] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S16", "SELECT [EstadosTipo] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S17", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S18", "SELECT TM1.[ProfesionalesId], TM1.[ProfesionalesFechaAlta], TM1.[ProfesionalesFechaActualizado], TM1.[ProfesionalesFechaNacimiento], TM1.[ProfesionalesRUT], TM1.[ProfesionalesTipoEmpresa], TM1.[ProfesionalesEsRUT], TM1.[ProfesionalesPrimerNombre], TM1.[ProfesionalesSegundoNombre], TM1.[ProfesionalesApellidoPrimero], TM1.[ProfesionalesApellidoSegundo], TM1.[ProfesionalesPhoto_GXI], TM1.[ProfesionalesTelefono], TM1.[ProfesionalesEmail], TM1.[ProfesionalesDireccion], TM1.[ProfesionalesVerDatPerSol], TM1.[ProfesionalesPerAltShop], TM1.[ProfesionalesAutoEnumerar], TM1.[ProfesionalesAutoEnuZona], TM1.[ProfesionalesExperiencia], TM1.[ProfesionalesAceptoTerminos], TM1.[ProfesionalesDeclaroDatosV], TM1.[ProfesionalesCuentaBancaria], TM1.[ProfesionalesCapacidadProducti], T2.[BancoNombre], TM1.[ProfesionalesLimitOSF], TM1.[ProfesionalesFeedBackCant], TM1.[ProfesionalesFeedBackProm], TM1.[EstadosTipo], TM1.[EstadosGenericosId], TM1.[BancoId], TM1.[ProfesionalesPhoto] FROM ([Profesionales] TM1 LEFT JOIN [Banco] T2 ON T2.[BancoId] = TM1.[BancoId]) WHERE TM1.[ProfesionalesId] = @ProfesionalesId ORDER BY TM1.[ProfesionalesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S18,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S19", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S20", "SELECT [EstadosTipo] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S21", "SELECT [ProfesionalesId] FROM [Profesionales] WHERE [ProfesionalesId] = @ProfesionalesId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S22", "SELECT TOP 1 [ProfesionalesId] FROM [Profesionales] WHERE ( [ProfesionalesId] > @ProfesionalesId) ORDER BY [ProfesionalesId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S23", "SELECT TOP 1 [ProfesionalesId] FROM [Profesionales] WHERE ( [ProfesionalesId] < @ProfesionalesId) ORDER BY [ProfesionalesId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S24", "INSERT INTO [Profesionales]([ProfesionalesId], [ProfesionalesFechaAlta], [ProfesionalesFechaActualizado], [ProfesionalesFechaNacimiento], [ProfesionalesRUT], [ProfesionalesTipoEmpresa], [ProfesionalesEsRUT], [ProfesionalesPrimerNombre], [ProfesionalesSegundoNombre], [ProfesionalesApellidoPrimero], [ProfesionalesApellidoSegundo], [ProfesionalesPhoto], [ProfesionalesPhoto_GXI], [ProfesionalesTelefono], [ProfesionalesEmail], [ProfesionalesDireccion], [ProfesionalesVerDatPerSol], [ProfesionalesPerAltShop], [ProfesionalesAutoEnumerar], [ProfesionalesAutoEnuZona], [ProfesionalesExperiencia], [ProfesionalesAceptoTerminos], [ProfesionalesDeclaroDatosV], [ProfesionalesCuentaBancaria], [ProfesionalesCapacidadProducti], [ProfesionalesLimitOSF], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm], [EstadosTipo], [EstadosGenericosId], [BancoId]) VALUES(@ProfesionalesId, @ProfesionalesFechaAlta, @ProfesionalesFechaActualizado, @ProfesionalesFechaNacimiento, @ProfesionalesRUT, @ProfesionalesTipoEmpresa, @ProfesionalesEsRUT, @ProfesionalesPrimerNombre, @ProfesionalesSegundoNombre, @ProfesionalesApellidoPrimero, @ProfesionalesApellidoSegundo, @ProfesionalesPhoto, @ProfesionalesPhoto_GXI, @ProfesionalesTelefono, @ProfesionalesEmail, @ProfesionalesDireccion, @ProfesionalesVerDatPerSol, @ProfesionalesPerAltShop, @ProfesionalesAutoEnumerar, @ProfesionalesAutoEnuZona, @ProfesionalesExperiencia, @ProfesionalesAceptoTerminos, @ProfesionalesDeclaroDatosV, @ProfesionalesCuentaBancaria, @ProfesionalesCapacidadProducti, @ProfesionalesLimitOSF, @ProfesionalesFeedBackCant, @ProfesionalesFeedBackProm, @EstadosTipo, @EstadosGenericosId, @BancoId)", GxErrorMask.GX_NOMASK,prmT000S24)
           ,new CursorDef("T000S25", "UPDATE [Profesionales] SET [ProfesionalesFechaAlta]=@ProfesionalesFechaAlta, [ProfesionalesFechaActualizado]=@ProfesionalesFechaActualizado, [ProfesionalesFechaNacimiento]=@ProfesionalesFechaNacimiento, [ProfesionalesRUT]=@ProfesionalesRUT, [ProfesionalesTipoEmpresa]=@ProfesionalesTipoEmpresa, [ProfesionalesEsRUT]=@ProfesionalesEsRUT, [ProfesionalesPrimerNombre]=@ProfesionalesPrimerNombre, [ProfesionalesSegundoNombre]=@ProfesionalesSegundoNombre, [ProfesionalesApellidoPrimero]=@ProfesionalesApellidoPrimero, [ProfesionalesApellidoSegundo]=@ProfesionalesApellidoSegundo, [ProfesionalesTelefono]=@ProfesionalesTelefono, [ProfesionalesEmail]=@ProfesionalesEmail, [ProfesionalesDireccion]=@ProfesionalesDireccion, [ProfesionalesVerDatPerSol]=@ProfesionalesVerDatPerSol, [ProfesionalesPerAltShop]=@ProfesionalesPerAltShop, [ProfesionalesAutoEnumerar]=@ProfesionalesAutoEnumerar, [ProfesionalesAutoEnuZona]=@ProfesionalesAutoEnuZona, [ProfesionalesExperiencia]=@ProfesionalesExperiencia, [ProfesionalesAceptoTerminos]=@ProfesionalesAceptoTerminos, [ProfesionalesDeclaroDatosV]=@ProfesionalesDeclaroDatosV, [ProfesionalesCuentaBancaria]=@ProfesionalesCuentaBancaria, [ProfesionalesCapacidadProducti]=@ProfesionalesCapacidadProducti, [ProfesionalesLimitOSF]=@ProfesionalesLimitOSF, [ProfesionalesFeedBackCant]=@ProfesionalesFeedBackCant, [ProfesionalesFeedBackProm]=@ProfesionalesFeedBackProm, [EstadosTipo]=@EstadosTipo, [EstadosGenericosId]=@EstadosGenericosId, [BancoId]=@BancoId  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT000S25)
           ,new CursorDef("T000S26", "UPDATE [Profesionales] SET [ProfesionalesPhoto]=@ProfesionalesPhoto, [ProfesionalesPhoto_GXI]=@ProfesionalesPhoto_GXI  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT000S26)
           ,new CursorDef("T000S27", "DELETE FROM [Profesionales]  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT000S27)
           ,new CursorDef("T000S28", "SELECT [BancoNombre] FROM [Banco] WHERE [BancoId] = @BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S29", "SELECT TOP 1 [CentroCostosId], [CentroCostosDetallesId] FROM [CentroCostosDetalles] WHERE [CCDetallesProfId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S30", "SELECT TOP 1 [ProfesionalesRestriccionId] FROM [ProfesionalesRestriccion] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S31", "SELECT TOP 1 [ProfComisionesID] FROM [ProfComisiones] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S32", "SELECT TOP 1 [SolicitudesID], [RelacionesId] FROM [Relaciones] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S32,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S33", "SELECT TOP 1 [PostulacionesId], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S34", "SELECT TOP 1 [Listaid], [ProveedorID], [ProfesionalesId] FROM [ListaAgrupacion] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S34,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S35", "SELECT TOP 1 [ComisionesID], [ProfesionalesId] FROM [ComisionesProfesionales] WHERE [ProfesionalesId] = @ProfesionalesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S35,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S36", "UPDATE [Profesionales] SET [ProfesionalesAutoEnuZona]=@ProfesionalesAutoEnuZona  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK,prmT000S36)
           ,new CursorDef("T000S37", "SELECT [ProfesionalesId] FROM [Profesionales] ORDER BY [ProfesionalesId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000S37,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S38", "SELECT T1.[ProfesionalesId], T2.[RubrosNombre], T2.[RubrosImagen_GXI], T2.[RubrosEstado], T3.[EstadosGenericosNombre] AS EstadosProfRubNomb, T1.[RubrosId], T1.[EstadosProfRubTipo] AS EstadosProfRubTipo, T1.[EstadosProfRubId] AS EstadosProfRubId, T2.[RubrosImagen] FROM (([ProfesionalesRubros] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [EstadosGenericos] T3 ON T3.[EstadosTipo] = T1.[EstadosProfRubTipo] AND T3.[EstadosGenericosId] = T1.[EstadosProfRubId]) WHERE T1.[ProfesionalesId] = @ProfesionalesId and T1.[RubrosId] = @RubrosId ORDER BY T1.[ProfesionalesId], T1.[RubrosId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S38,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S39", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S39,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S40", "SELECT [EstadosGenericosNombre] AS EstadosProfRubNomb FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosProfRubTipo AND [EstadosGenericosId] = @EstadosProfRubId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S40,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S41", "SELECT [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S41,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S42", "INSERT INTO [ProfesionalesRubros]([ProfesionalesId], [RubrosId], [EstadosProfRubTipo], [EstadosProfRubId]) VALUES(@ProfesionalesId, @RubrosId, @EstadosProfRubTipo, @EstadosProfRubId)", GxErrorMask.GX_NOMASK,prmT000S42)
           ,new CursorDef("T000S43", "UPDATE [ProfesionalesRubros] SET [EstadosProfRubTipo]=@EstadosProfRubTipo, [EstadosProfRubId]=@EstadosProfRubId  WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmT000S43)
           ,new CursorDef("T000S44", "DELETE FROM [ProfesionalesRubros]  WHERE [ProfesionalesId] = @ProfesionalesId AND [RubrosId] = @RubrosId", GxErrorMask.GX_NOMASK,prmT000S44)
           ,new CursorDef("T000S45", "SELECT [RubrosNombre], [RubrosImagen_GXI], [RubrosEstado], [RubrosImagen] FROM [Rubros] WHERE [RubrosId] = @RubrosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S45,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S46", "SELECT [EstadosGenericosNombre] AS EstadosProfRubNomb FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosProfRubTipo AND [EstadosGenericosId] = @EstadosProfRubId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S46,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S47", "SELECT [ProfesionalesId], [RubrosId] FROM [ProfesionalesRubros] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId], [RubrosId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S47,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S48", "SELECT T1.[ProfesionalesId], T1.[ProfesionalesZonasCorrelativo], T2.[DepartamentoDepartamento], T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasID], T2.[PaisID] FROM ([ProfesionalesZonas] T1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) WHERE T1.[ProfesionalesId] = @ProfesionalesId and T1.[ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo ORDER BY T1.[ProfesionalesId], T1.[ProfesionalesZonasCorrelativo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S48,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S49", "SELECT [DepartamentoDepartamento], [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S49,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S50", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S50,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S51", "SELECT [ZonasID] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S51,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S52", "SELECT [ProfesionalesId], [ProfesionalesZonasCorrelativo] FROM [ProfesionalesZonas] WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S52,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S53", "INSERT INTO [ProfesionalesZonas]([ProfesionalesId], [ProfesionalesZonasCorrelativo], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID]) VALUES(@ProfesionalesId, @ProfesionalesZonasCorrelativo, @DepartamentoId, @DepartamentoMunicipioId, @ZonasID)", GxErrorMask.GX_NOMASK,prmT000S53)
           ,new CursorDef("T000S54", "UPDATE [ProfesionalesZonas] SET [DepartamentoId]=@DepartamentoId, [DepartamentoMunicipioId]=@DepartamentoMunicipioId, [ZonasID]=@ZonasID  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo", GxErrorMask.GX_NOMASK,prmT000S54)
           ,new CursorDef("T000S55", "DELETE FROM [ProfesionalesZonas]  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalesZonasCorrelativo] = @ProfesionalesZonasCorrelativo", GxErrorMask.GX_NOMASK,prmT000S55)
           ,new CursorDef("T000S56", "SELECT [DepartamentoDepartamento], [PaisID] FROM [Departamento] WHERE [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S56,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S57", "SELECT [ProfesionalesId], [ProfesionalesZonasCorrelativo] FROM [ProfesionalesZonas] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId], [ProfesionalesZonasCorrelativo] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S57,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S58", "SELECT T1.[ProfesionalesId], T2.[ServiciosNombre] AS ProfesionalServicioNombre, T1.[EstadoServProf], T1.[ProfesionalServicioId] AS ProfesionalServicioId FROM ([ProfesionalesServicios] T1 INNER JOIN [Servicios] T2 ON T2.[ServiciosId] = T1.[ProfesionalServicioId]) WHERE T1.[ProfesionalesId] = @ProfesionalesId and T1.[ProfesionalServicioId] = @ProfesionalServicioId ORDER BY T1.[ProfesionalesId], T1.[ProfesionalServicioId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S58,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S59", "SELECT [ServiciosNombre] AS ProfesionalServicioNombre FROM [Servicios] WHERE [ServiciosId] = @ProfesionalServicioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S59,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S60", "SELECT [ProfesionalesId], [ProfesionalServicioId] AS ProfesionalServicioId FROM [ProfesionalesServicios] WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalServicioId] = @ProfesionalServicioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S60,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S61", "INSERT INTO [ProfesionalesServicios]([ProfesionalesId], [EstadoServProf], [ProfesionalServicioId]) VALUES(@ProfesionalesId, @EstadoServProf, @ProfesionalServicioId)", GxErrorMask.GX_NOMASK,prmT000S61)
           ,new CursorDef("T000S62", "UPDATE [ProfesionalesServicios] SET [EstadoServProf]=@EstadoServProf  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalServicioId] = @ProfesionalServicioId", GxErrorMask.GX_NOMASK,prmT000S62)
           ,new CursorDef("T000S63", "DELETE FROM [ProfesionalesServicios]  WHERE [ProfesionalesId] = @ProfesionalesId AND [ProfesionalServicioId] = @ProfesionalServicioId", GxErrorMask.GX_NOMASK,prmT000S63)
           ,new CursorDef("T000S64", "SELECT [ServiciosNombre] AS ProfesionalServicioNombre FROM [Servicios] WHERE [ServiciosId] = @ProfesionalServicioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S64,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S65", "SELECT [ProfesionalesId], [ProfesionalServicioId] AS ProfesionalServicioId FROM [ProfesionalesServicios] WHERE [ProfesionalesId] = @ProfesionalesId ORDER BY [ProfesionalesId], [ProfesionalServicioId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S65,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S66", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S66,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S67", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo ORDER BY [EstadosGenericosNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S67,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S68", "SELECT [BancoId], [BancoNombre], [BancoEstado] FROM [Banco] WHERE [BancoEstado] = 'HAB' ORDER BY [BancoNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S68,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S69", "SELECT [RubrosId], [RubrosNombre], [RubrosEstado] FROM [Rubros] WHERE [RubrosEstado] <> 'DES' ORDER BY [RubrosNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S69,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S70", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [DepartamentoMunicipioNombre] FROM [DepartamentoMunicipio] WHERE ([DepartamentoId] = @DepartamentoId) AND ([DepartamentoMunicipioId] < 9999) ORDER BY [DepartamentoMunicipioNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S70,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S71", "SELECT [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [ZonasNombre] FROM [Zonas] WHERE ([DepartamentoId] = @DepartamentoId and [DepartamentoMunicipioId] = @DepartamentoMunicipioId) AND ([ZonasID] < 9999) ORDER BY [ZonasNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S71,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S72", "SELECT [DepartamentoId], [DepartamentoDepartamento] FROM [Departamento] ORDER BY [DepartamentoDepartamento] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S72,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S73", "SELECT [EstadosTipo] FROM [EstadosGenericos] WHERE [EstadosTipo] = @EstadosTipo AND [EstadosGenericosId] = @EstadosGenericosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S73,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S74", "SELECT [DepartamentoId] FROM [DepartamentoMunicipio] WHERE [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S74,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S75", "SELECT [ZonasID] FROM [Zonas] WHERE [ZonasID] = @ZonasID AND [DepartamentoId] = @DepartamentoId AND [DepartamentoMunicipioId] = @DepartamentoMunicipioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S75,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((long[]) buf[3])[0] = rslt.getLong(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((short[]) buf[7])[0] = rslt.getShort(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((bool[]) buf[9])[0] = rslt.getBool(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getString(8, 30);
              ((string[]) buf[12])[0] = rslt.getString(9, 30);
              ((string[]) buf[13])[0] = rslt.getString(10, 30);
              ((string[]) buf[14])[0] = rslt.getString(11, 30);
              ((string[]) buf[15])[0] = rslt.getMultimediaUri(12);
              ((string[]) buf[16])[0] = rslt.getString(13, 20);
              ((string[]) buf[17])[0] = rslt.getVarchar(14);
              ((bool[]) buf[18])[0] = rslt.wasNull(14);
              ((string[]) buf[19])[0] = rslt.getVarchar(15);
              ((string[]) buf[20])[0] = rslt.getString(16, 1);
              ((string[]) buf[21])[0] = rslt.getString(17, 1);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((short[]) buf[23])[0] = rslt.getShort(18);
              ((short[]) buf[24])[0] = rslt.getShort(19);
              ((string[]) buf[25])[0] = rslt.getVarchar(20);
              ((bool[]) buf[26])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[28])[0] = rslt.wasNull(21);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[30])[0] = rslt.wasNull(22);
              ((string[]) buf[31])[0] = rslt.getString(23, 50);
              ((bool[]) buf[32])[0] = rslt.wasNull(23);
              ((decimal[]) buf[33])[0] = rslt.getDecimal(24);
              ((short[]) buf[34])[0] = rslt.getShort(25);
              ((bool[]) buf[35])[0] = rslt.wasNull(25);
              ((long[]) buf[36])[0] = rslt.getLong(26);
              ((decimal[]) buf[37])[0] = rslt.getDecimal(27);
              ((string[]) buf[38])[0] = rslt.getString(28, 3);
              ((int[]) buf[39])[0] = rslt.getInt(29);
              ((long[]) buf[40])[0] = rslt.getLong(30);
              ((bool[]) buf[41])[0] = rslt.wasNull(30);
              ((string[]) buf[42])[0] = rslt.getMultimediaFile(31, rslt.getVarchar(12));
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((short[]) buf[7])[0] = rslt.getShort(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((bool[]) buf[9])[0] = rslt.getBool(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getString(8, 30);
              ((string[]) buf[12])[0] = rslt.getString(9, 30);
              ((string[]) buf[13])[0] = rslt.getString(10, 30);
              ((string[]) buf[14])[0] = rslt.getString(11, 30);
              ((string[]) buf[15])[0] = rslt.getMultimediaUri(12);
              ((string[]) buf[16])[0] = rslt.getString(13, 20);
              ((string[]) buf[17])[0] = rslt.getVarchar(14);
              ((bool[]) buf[18])[0] = rslt.wasNull(14);
              ((string[]) buf[19])[0] = rslt.getVarchar(15);
              ((string[]) buf[20])[0] = rslt.getString(16, 1);
              ((string[]) buf[21])[0] = rslt.getString(17, 1);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((short[]) buf[23])[0] = rslt.getShort(18);
              ((short[]) buf[24])[0] = rslt.getShort(19);
              ((string[]) buf[25])[0] = rslt.getVarchar(20);
              ((bool[]) buf[26])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[28])[0] = rslt.wasNull(21);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[30])[0] = rslt.wasNull(22);
              ((string[]) buf[31])[0] = rslt.getString(23, 50);
              ((bool[]) buf[32])[0] = rslt.wasNull(23);
              ((decimal[]) buf[33])[0] = rslt.getDecimal(24);
              ((short[]) buf[34])[0] = rslt.getShort(25);
              ((bool[]) buf[35])[0] = rslt.wasNull(25);
              ((long[]) buf[36])[0] = rslt.getLong(26);
              ((decimal[]) buf[37])[0] = rslt.getDecimal(27);
              ((string[]) buf[38])[0] = rslt.getString(28, 3);
              ((int[]) buf[39])[0] = rslt.getInt(29);
              ((long[]) buf[40])[0] = rslt.getLong(30);
              ((bool[]) buf[41])[0] = rslt.wasNull(30);
              ((string[]) buf[42])[0] = rslt.getMultimediaFile(31, rslt.getVarchar(12));
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 20);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((short[]) buf[7])[0] = rslt.getShort(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((bool[]) buf[9])[0] = rslt.getBool(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getString(8, 30);
              ((string[]) buf[12])[0] = rslt.getString(9, 30);
              ((string[]) buf[13])[0] = rslt.getString(10, 30);
              ((string[]) buf[14])[0] = rslt.getString(11, 30);
              ((string[]) buf[15])[0] = rslt.getMultimediaUri(12);
              ((string[]) buf[16])[0] = rslt.getString(13, 20);
              ((string[]) buf[17])[0] = rslt.getVarchar(14);
              ((bool[]) buf[18])[0] = rslt.wasNull(14);
              ((string[]) buf[19])[0] = rslt.getVarchar(15);
              ((string[]) buf[20])[0] = rslt.getString(16, 1);
              ((string[]) buf[21])[0] = rslt.getString(17, 1);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((short[]) buf[23])[0] = rslt.getShort(18);
              ((short[]) buf[24])[0] = rslt.getShort(19);
              ((string[]) buf[25])[0] = rslt.getVarchar(20);
              ((bool[]) buf[26])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[28])[0] = rslt.wasNull(21);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[30])[0] = rslt.wasNull(22);
              ((string[]) buf[31])[0] = rslt.getString(23, 50);
              ((bool[]) buf[32])[0] = rslt.wasNull(23);
              ((decimal[]) buf[33])[0] = rslt.getDecimal(24);
              ((string[]) buf[34])[0] = rslt.getString(25, 80);
              ((short[]) buf[35])[0] = rslt.getShort(26);
              ((bool[]) buf[36])[0] = rslt.wasNull(26);
              ((long[]) buf[37])[0] = rslt.getLong(27);
              ((decimal[]) buf[38])[0] = rslt.getDecimal(28);
              ((string[]) buf[39])[0] = rslt.getString(29, 3);
              ((int[]) buf[40])[0] = rslt.getInt(30);
              ((long[]) buf[41])[0] = rslt.getLong(31);
              ((bool[]) buf[42])[0] = rslt.wasNull(31);
              ((string[]) buf[43])[0] = rslt.getMultimediaFile(32, rslt.getVarchar(12));
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 29 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 31 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 32 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 33 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 36 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 80);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 3);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(3));
              return;
           case 37 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
              return;
           case 38 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 43 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
              return;
           case 44 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 45 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 46 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 2);
              return;
           case 47 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 48 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 49 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 50 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 54 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              ((string[]) buf[1])[0] = rslt.getString(2, 2);
              return;
           case 55 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 56 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              return;
           case 57 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 58 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 62 :
              ((string[]) buf[0])[0] = rslt.getString(1, 80);
              return;
           case 63 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 64 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 65 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 80);
              return;
           case 66 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 67 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 68 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 120);
              return;
           case 69 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 120);
              return;
           case 70 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              return;
           case 71 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 72 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 73 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}

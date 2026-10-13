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
namespace GeneXus.Programs {
   public class postulacionesprofesionaleswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public postulacionesprofesionaleswc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public postulacionesprofesionaleswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_PostulacionesId )
      {
         this.AV8PostulacionesId = aP0_PostulacionesId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbPostulacionProfesionalEstado = new GXCombobox();
         cmbPostulacionProfesionalUniE = new GXCombobox();
         cmbPostulacionProfesionalUniG = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "PostulacionesId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV8PostulacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "PostulacionesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8PostulacionesId", StringUtil.LTrimStr( (decimal)(AV8PostulacionesId), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV8PostulacionesId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "PostulacionesId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "PostulacionesId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  gxnrGrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  gxgrGrid_refresh_invoke( ) ;
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
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_15 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_15"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_15_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_15_idx = GetPar( "sGXsfl_15_idx");
         sPrefix = GetPar( "sPrefix");
         AV37VerMas = GetPar( "VerMas");
         edtavVermas_Tooltiptext = GetNextPar( );
         AssignProp(sPrefix, false, edtavVermas_Internalname, "Tooltiptext", edtavVermas_Tooltiptext, !bGXsfl_15_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV8PostulacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "PostulacionesId"), "."), 18, MidpointRounding.ToEven));
         AV39Pgmname = GetPar( "Pgmname");
         AV23TFProfesionalesNombreCompleto = GetPar( "TFProfesionalesNombreCompleto");
         AV24TFProfesionalesNombreCompleto_Sel = GetPar( "TFProfesionalesNombreCompleto_Sel");
         AV25TFPostulacionProfesionalPrecio = NumberUtil.Val( GetPar( "TFPostulacionProfesionalPrecio"), ".");
         AV26TFPostulacionProfesionalPrecio_To = NumberUtil.Val( GetPar( "TFPostulacionProfesionalPrecio_To"), ".");
         AV27TFPostulacionProfesionalPlazoE = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionProfesionalPlazoE"), "."), 18, MidpointRounding.ToEven));
         AV28TFPostulacionProfesionalPlazoE_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionProfesionalPlazoE_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV30TFPostulacionProfesionalUniE_Sels);
         AV33TFPostulacionProfesionalGar = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionProfesionalGar"), "."), 18, MidpointRounding.ToEven));
         AV34TFPostulacionProfesionalGar_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFPostulacionProfesionalGar_To"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV32TFPostulacionProfesionalUniG_Sels);
         AV35TFPostulacionProfesionalA = GetPar( "TFPostulacionProfesionalA");
         AV36TFPostulacionProfesionalA_Sel = GetPar( "TFPostulacionProfesionalA_Sel");
         AV37VerMas = GetPar( "VerMas");
         edtavVermas_Tooltiptext = GetNextPar( );
         AssignProp(sPrefix, false, edtavVermas_Internalname, "Tooltiptext", edtavVermas_Tooltiptext, !bGXsfl_15_Refreshing);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8PostulacionesId, AV39Pgmname, AV23TFProfesionalesNombreCompleto, AV24TFProfesionalesNombreCompleto_Sel, AV25TFPostulacionProfesionalPrecio, AV26TFPostulacionProfesionalPrecio_To, AV27TFPostulacionProfesionalPlazoE, AV28TFPostulacionProfesionalPlazoE_To, AV30TFPostulacionProfesionalUniE_Sels, AV33TFPostulacionProfesionalGar, AV34TFPostulacionProfesionalGar_To, AV32TFPostulacionProfesionalUniG_Sels, AV35TFPostulacionProfesionalA, AV36TFPostulacionProfesionalA_Sel, AV37VerMas, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PAKQ2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV39Pgmname = "PostulacionesProfesionalesWC";
               WSKQ2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( context.GetMessage( "Postulaciones Profesionales WC", "")) ;
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
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
            {
               context.WriteHtmlText( " dir=\"rtl\" ") ;
            }
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "postulacionesprofesionaleswc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8PostulacionesId,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("postulacionesprofesionaleswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV39Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV39Pgmname, "")), context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_15", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_15), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV22GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8PostulacionesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV39Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV39Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESNOMBRECOMPLETO", AV23TFProfesionalesNombreCompleto);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPROFESIONALESNOMBRECOMPLETO_SEL", AV24TFProfesionalesNombreCompleto_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPOSTULACIONPROFESIONALPRECIO", StringUtil.LTrim( StringUtil.NToC( AV25TFPostulacionProfesionalPrecio, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPOSTULACIONPROFESIONALPRECIO_TO", StringUtil.LTrim( StringUtil.NToC( AV26TFPostulacionProfesionalPrecio_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPOSTULACIONPROFESIONALPLAZOE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27TFPostulacionProfesionalPlazoE), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPOSTULACIONPROFESIONALPLAZOE_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28TFPostulacionProfesionalPlazoE_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFPOSTULACIONPROFESIONALUNIE_SELS", AV30TFPostulacionProfesionalUniE_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFPOSTULACIONPROFESIONALUNIE_SELS", AV30TFPostulacionProfesionalUniE_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPOSTULACIONPROFESIONALGAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TFPostulacionProfesionalGar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPOSTULACIONPROFESIONALGAR_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34TFPostulacionProfesionalGar_To), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTFPOSTULACIONPROFESIONALUNIG_SELS", AV32TFPostulacionProfesionalUniG_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTFPOSTULACIONPROFESIONALUNIG_SELS", AV32TFPostulacionProfesionalUniG_Sels);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPOSTULACIONPROFESIONALA", AV35TFPostulacionProfesionalA);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFPOSTULACIONPROFESIONALA_SEL", AV36TFPostulacionProfesionalA_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPOSTULACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFESIONALESAPELLIDOPRIMERO", StringUtil.RTrim( A167ProfesionalesApellidoPrimero));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFESIONALESPRIMERNOMBRE", StringUtil.RTrim( A166ProfesionalesPrimerNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROFESIONALESSEGUNDONOMBRE", StringUtil.RTrim( A191ProfesionalesSegundoNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"vVERMAS_Tooltiptext", StringUtil.RTrim( edtavVermas_Tooltiptext));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
      }

      protected void RenderHtmlCloseFormKQ2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "PostulacionesProfesionalesWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Postulaciones Profesionales WC", "") ;
      }

      protected void WBKQ0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "postulacionesprofesionaleswc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegridheader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl15( ) ;
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            nRC_GXsfl_15 = (int)(nGXsfl_15_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV20GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV21GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV22GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, sPrefix+"GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPostulacionesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A422PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A422PostulacionesId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPostulacionesId_Jsonclick, 0, "Attribute", "", "", "", "", edtPostulacionesId_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PostulacionesProfesionalesWC.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 15 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void STARTKQ2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
               }
            }
            Form.Meta.addItem("description", context.GetMessage( "Postulaciones Profesionales WC", ""), 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUPKQ0( ) ;
            }
         }
      }

      protected void WSKQ2( )
      {
         STARTKQ2( ) ;
         EVTKQ2( ) ;
      }

      protected void EVTKQ2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKQ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKQ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E11KQ2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKQ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E12KQ2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKQ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E13KQ2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKQ0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VVERMAS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VVERMAS.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUPKQ0( ) ;
                              }
                              nGXsfl_15_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
                              SubsflControlProps_152( ) ;
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A886ProfesionalesNombreCompleto = cgiGet( edtProfesionalesNombreCompleto_Internalname);
                              cmbPostulacionProfesionalEstado.Name = cmbPostulacionProfesionalEstado_Internalname;
                              cmbPostulacionProfesionalEstado.CurrentValue = cgiGet( cmbPostulacionProfesionalEstado_Internalname);
                              A956PostulacionProfesionalEstado = cgiGet( cmbPostulacionProfesionalEstado_Internalname);
                              A957PostulacionProfesionalFechaA = context.localUtil.CToT( cgiGet( edtPostulacionProfesionalFechaA_Internalname), 0);
                              A958PostulacionProfesionalFechaT = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPostulacionProfesionalFechaT_Internalname), 0));
                              A959PostulacionProfesionalTurnoT = cgiGet( edtPostulacionProfesionalTurnoT_Internalname);
                              A982PostulacionProfesionalPrecio = context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPrecio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              n982PostulacionProfesionalPrecio = false;
                              A983PostulacionProfesionalPlazoE = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionProfesionalPlazoE_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n983PostulacionProfesionalPlazoE = false;
                              cmbPostulacionProfesionalUniE.Name = cmbPostulacionProfesionalUniE_Internalname;
                              cmbPostulacionProfesionalUniE.CurrentValue = cgiGet( cmbPostulacionProfesionalUniE_Internalname);
                              A986PostulacionProfesionalUniE = cgiGet( cmbPostulacionProfesionalUniE_Internalname);
                              n986PostulacionProfesionalUniE = false;
                              A985PostulacionProfesionalGar = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionProfesionalGar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n985PostulacionProfesionalGar = false;
                              cmbPostulacionProfesionalUniG.Name = cmbPostulacionProfesionalUniG_Internalname;
                              cmbPostulacionProfesionalUniG.CurrentValue = cgiGet( cmbPostulacionProfesionalUniG_Internalname);
                              A987PostulacionProfesionalUniG = cgiGet( cmbPostulacionProfesionalUniG_Internalname);
                              n987PostulacionProfesionalUniG = false;
                              A984PostulacionProfesionalA = cgiGet( edtPostulacionProfesionalA_Internalname);
                              n984PostulacionProfesionalA = false;
                              AV37VerMas = cgiGet( edtavVermas_Internalname);
                              AssignProp(sPrefix, false, edtavVermas_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37VerMas)) ? AV38Vermas_GXI : context.convertURL( context.PathToRelativeUrl( AV37VerMas))), !bGXsfl_15_Refreshing);
                              AssignProp(sPrefix, false, edtavVermas_Internalname, "SrcSet", context.GetImageSrcSet( AV37VerMas), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E14KQ2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Refresh */
                                          E15KQ2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Grid.Load */
                                          E16KQ2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VVERMAS.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E17KQ2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUPKQ0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                       }
                                    }
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
      }

      protected void WEKQ2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseFormKQ2( ) ;
            }
         }
      }

      protected void PAKQ2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "postulacionesprofesionaleswc.aspx")), "postulacionesprofesionaleswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "postulacionesprofesionaleswc.aspx")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "PostulacionesId");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( toggleJsOutput )
                     {
                        if ( context.isSpaRequest( ) )
                        {
                           enableJsOutput();
                        }
                     }
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_152( ) ;
         while ( nGXsfl_15_idx <= nRC_GXsfl_15 )
         {
            sendrow_152( ) ;
            nGXsfl_15_idx = ((subGrid_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       long AV8PostulacionesId ,
                                       string AV39Pgmname ,
                                       string AV23TFProfesionalesNombreCompleto ,
                                       string AV24TFProfesionalesNombreCompleto_Sel ,
                                       decimal AV25TFPostulacionProfesionalPrecio ,
                                       decimal AV26TFPostulacionProfesionalPrecio_To ,
                                       short AV27TFPostulacionProfesionalPlazoE ,
                                       short AV28TFPostulacionProfesionalPlazoE_To ,
                                       GxSimpleCollection<string> AV30TFPostulacionProfesionalUniE_Sels ,
                                       short AV33TFPostulacionProfesionalGar ,
                                       short AV34TFPostulacionProfesionalGar_To ,
                                       GxSimpleCollection<string> AV32TFPostulacionProfesionalUniG_Sels ,
                                       string AV35TFPostulacionProfesionalA ,
                                       string AV36TFPostulacionProfesionalA_Sel ,
                                       string AV37VerMas ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RFKQ2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_POSTULACIONPROFESIONALA", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( A984PostulacionProfesionalA, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"POSTULACIONPROFESIONALA", A984PostulacionProfesionalA);
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
         RFKQ2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV39Pgmname = "PostulacionesProfesionalesWC";
      }

      protected void RFKQ2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 15;
         /* Execute user event: Refresh */
         E15KQ2 ();
         nGXsfl_15_idx = 1;
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         bGXsfl_15_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_152( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A986PostulacionProfesionalUniE ,
                                                 AV30TFPostulacionProfesionalUniE_Sels ,
                                                 A987PostulacionProfesionalUniG ,
                                                 AV32TFPostulacionProfesionalUniG_Sels ,
                                                 AV24TFProfesionalesNombreCompleto_Sel ,
                                                 AV23TFProfesionalesNombreCompleto ,
                                                 AV25TFPostulacionProfesionalPrecio ,
                                                 AV26TFPostulacionProfesionalPrecio_To ,
                                                 AV27TFPostulacionProfesionalPlazoE ,
                                                 AV28TFPostulacionProfesionalPlazoE_To ,
                                                 AV30TFPostulacionProfesionalUniE_Sels.Count ,
                                                 AV33TFPostulacionProfesionalGar ,
                                                 AV34TFPostulacionProfesionalGar_To ,
                                                 AV32TFPostulacionProfesionalUniG_Sels.Count ,
                                                 AV36TFPostulacionProfesionalA_Sel ,
                                                 AV35TFPostulacionProfesionalA ,
                                                 A167ProfesionalesApellidoPrimero ,
                                                 A166ProfesionalesPrimerNombre ,
                                                 A191ProfesionalesSegundoNombre ,
                                                 A982PostulacionProfesionalPrecio ,
                                                 A983PostulacionProfesionalPlazoE ,
                                                 A985PostulacionProfesionalGar ,
                                                 A984PostulacionProfesionalA ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV8PostulacionesId ,
                                                 A422PostulacionesId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                                 TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                                 TypeConstants.LONG
                                                 }
            });
            lV23TFProfesionalesNombreCompleto = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesNombreCompleto), "%", "");
            lV35TFPostulacionProfesionalA = StringUtil.Concat( StringUtil.RTrim( AV35TFPostulacionProfesionalA), "%", "");
            /* Using cursor H00KQ2 */
            pr_default.execute(0, new Object[] {AV8PostulacionesId, lV23TFProfesionalesNombreCompleto, AV24TFProfesionalesNombreCompleto_Sel, AV25TFPostulacionProfesionalPrecio, AV26TFPostulacionProfesionalPrecio_To, AV27TFPostulacionProfesionalPlazoE, AV28TFPostulacionProfesionalPlazoE_To, AV33TFPostulacionProfesionalGar, AV34TFPostulacionProfesionalGar_To, lV35TFPostulacionProfesionalA, AV36TFPostulacionProfesionalA_Sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_15_idx = 1;
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A422PostulacionesId = H00KQ2_A422PostulacionesId[0];
               AssignAttri(sPrefix, false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
               A984PostulacionProfesionalA = H00KQ2_A984PostulacionProfesionalA[0];
               n984PostulacionProfesionalA = H00KQ2_n984PostulacionProfesionalA[0];
               A987PostulacionProfesionalUniG = H00KQ2_A987PostulacionProfesionalUniG[0];
               n987PostulacionProfesionalUniG = H00KQ2_n987PostulacionProfesionalUniG[0];
               A985PostulacionProfesionalGar = H00KQ2_A985PostulacionProfesionalGar[0];
               n985PostulacionProfesionalGar = H00KQ2_n985PostulacionProfesionalGar[0];
               A986PostulacionProfesionalUniE = H00KQ2_A986PostulacionProfesionalUniE[0];
               n986PostulacionProfesionalUniE = H00KQ2_n986PostulacionProfesionalUniE[0];
               A983PostulacionProfesionalPlazoE = H00KQ2_A983PostulacionProfesionalPlazoE[0];
               n983PostulacionProfesionalPlazoE = H00KQ2_n983PostulacionProfesionalPlazoE[0];
               A982PostulacionProfesionalPrecio = H00KQ2_A982PostulacionProfesionalPrecio[0];
               n982PostulacionProfesionalPrecio = H00KQ2_n982PostulacionProfesionalPrecio[0];
               A959PostulacionProfesionalTurnoT = H00KQ2_A959PostulacionProfesionalTurnoT[0];
               A958PostulacionProfesionalFechaT = H00KQ2_A958PostulacionProfesionalFechaT[0];
               A957PostulacionProfesionalFechaA = H00KQ2_A957PostulacionProfesionalFechaA[0];
               A956PostulacionProfesionalEstado = H00KQ2_A956PostulacionProfesionalEstado[0];
               A120ProfesionalesId = H00KQ2_A120ProfesionalesId[0];
               A191ProfesionalesSegundoNombre = H00KQ2_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H00KQ2_A166ProfesionalesPrimerNombre[0];
               A167ProfesionalesApellidoPrimero = H00KQ2_A167ProfesionalesApellidoPrimero[0];
               A191ProfesionalesSegundoNombre = H00KQ2_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = H00KQ2_A166ProfesionalesPrimerNombre[0];
               A167ProfesionalesApellidoPrimero = H00KQ2_A167ProfesionalesApellidoPrimero[0];
               A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
               /* Execute user event: Grid.Load */
               E16KQ2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 15;
            WBKQ0( ) ;
         }
         bGXsfl_15_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesKQ2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV39Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV39Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_POSTULACIONPROFESIONALA"+"_"+sGXsfl_15_idx, GetSecureSignedToken( sPrefix+sGXsfl_15_idx, StringUtil.RTrim( context.localUtil.Format( A984PostulacionProfesionalA, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A986PostulacionProfesionalUniE ,
                                              AV30TFPostulacionProfesionalUniE_Sels ,
                                              A987PostulacionProfesionalUniG ,
                                              AV32TFPostulacionProfesionalUniG_Sels ,
                                              AV24TFProfesionalesNombreCompleto_Sel ,
                                              AV23TFProfesionalesNombreCompleto ,
                                              AV25TFPostulacionProfesionalPrecio ,
                                              AV26TFPostulacionProfesionalPrecio_To ,
                                              AV27TFPostulacionProfesionalPlazoE ,
                                              AV28TFPostulacionProfesionalPlazoE_To ,
                                              AV30TFPostulacionProfesionalUniE_Sels.Count ,
                                              AV33TFPostulacionProfesionalGar ,
                                              AV34TFPostulacionProfesionalGar_To ,
                                              AV32TFPostulacionProfesionalUniG_Sels.Count ,
                                              AV36TFPostulacionProfesionalA_Sel ,
                                              AV35TFPostulacionProfesionalA ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A982PostulacionProfesionalPrecio ,
                                              A983PostulacionProfesionalPlazoE ,
                                              A985PostulacionProfesionalGar ,
                                              A984PostulacionProfesionalA ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV8PostulacionesId ,
                                              A422PostulacionesId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV23TFProfesionalesNombreCompleto = StringUtil.Concat( StringUtil.RTrim( AV23TFProfesionalesNombreCompleto), "%", "");
         lV35TFPostulacionProfesionalA = StringUtil.Concat( StringUtil.RTrim( AV35TFPostulacionProfesionalA), "%", "");
         /* Using cursor H00KQ3 */
         pr_default.execute(1, new Object[] {AV8PostulacionesId, lV23TFProfesionalesNombreCompleto, AV24TFProfesionalesNombreCompleto_Sel, AV25TFPostulacionProfesionalPrecio, AV26TFPostulacionProfesionalPrecio_To, AV27TFPostulacionProfesionalPlazoE, AV28TFPostulacionProfesionalPlazoE_To, AV33TFPostulacionProfesionalGar, AV34TFPostulacionProfesionalGar_To, lV35TFPostulacionProfesionalA, AV36TFPostulacionProfesionalA_Sel});
         GRID_nRecordCount = H00KQ3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8PostulacionesId, AV39Pgmname, AV23TFProfesionalesNombreCompleto, AV24TFProfesionalesNombreCompleto_Sel, AV25TFPostulacionProfesionalPrecio, AV26TFPostulacionProfesionalPrecio_To, AV27TFPostulacionProfesionalPlazoE, AV28TFPostulacionProfesionalPlazoE_To, AV30TFPostulacionProfesionalUniE_Sels, AV33TFPostulacionProfesionalGar, AV34TFPostulacionProfesionalGar_To, AV32TFPostulacionProfesionalUniG_Sels, AV35TFPostulacionProfesionalA, AV36TFPostulacionProfesionalA_Sel, AV37VerMas, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8PostulacionesId, AV39Pgmname, AV23TFProfesionalesNombreCompleto, AV24TFProfesionalesNombreCompleto_Sel, AV25TFPostulacionProfesionalPrecio, AV26TFPostulacionProfesionalPrecio_To, AV27TFPostulacionProfesionalPlazoE, AV28TFPostulacionProfesionalPlazoE_To, AV30TFPostulacionProfesionalUniE_Sels, AV33TFPostulacionProfesionalGar, AV34TFPostulacionProfesionalGar_To, AV32TFPostulacionProfesionalUniG_Sels, AV35TFPostulacionProfesionalA, AV36TFPostulacionProfesionalA_Sel, AV37VerMas, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8PostulacionesId, AV39Pgmname, AV23TFProfesionalesNombreCompleto, AV24TFProfesionalesNombreCompleto_Sel, AV25TFPostulacionProfesionalPrecio, AV26TFPostulacionProfesionalPrecio_To, AV27TFPostulacionProfesionalPlazoE, AV28TFPostulacionProfesionalPlazoE_To, AV30TFPostulacionProfesionalUniE_Sels, AV33TFPostulacionProfesionalGar, AV34TFPostulacionProfesionalGar_To, AV32TFPostulacionProfesionalUniG_Sels, AV35TFPostulacionProfesionalA, AV36TFPostulacionProfesionalA_Sel, AV37VerMas, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((long)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8PostulacionesId, AV39Pgmname, AV23TFProfesionalesNombreCompleto, AV24TFProfesionalesNombreCompleto_Sel, AV25TFPostulacionProfesionalPrecio, AV26TFPostulacionProfesionalPrecio_To, AV27TFPostulacionProfesionalPlazoE, AV28TFPostulacionProfesionalPlazoE_To, AV30TFPostulacionProfesionalUniE_Sels, AV33TFPostulacionProfesionalGar, AV34TFPostulacionProfesionalGar_To, AV32TFPostulacionProfesionalUniG_Sels, AV35TFPostulacionProfesionalA, AV36TFPostulacionProfesionalA_Sel, AV37VerMas, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV8PostulacionesId, AV39Pgmname, AV23TFProfesionalesNombreCompleto, AV24TFProfesionalesNombreCompleto_Sel, AV25TFPostulacionProfesionalPrecio, AV26TFPostulacionProfesionalPrecio_To, AV27TFPostulacionProfesionalPlazoE, AV28TFPostulacionProfesionalPlazoE_To, AV30TFPostulacionProfesionalUniE_Sels, AV33TFPostulacionProfesionalGar, AV34TFPostulacionProfesionalGar_To, AV32TFPostulacionProfesionalUniG_Sels, AV35TFPostulacionProfesionalA, AV36TFPostulacionProfesionalA_Sel, AV37VerMas, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV39Pgmname = "PostulacionesProfesionalesWC";
         edtProfesionalesId_Enabled = 0;
         edtProfesionalesNombreCompleto_Enabled = 0;
         cmbPostulacionProfesionalEstado.Enabled = 0;
         edtPostulacionProfesionalFechaA_Enabled = 0;
         edtPostulacionProfesionalFechaT_Enabled = 0;
         edtPostulacionProfesionalTurnoT_Enabled = 0;
         edtPostulacionProfesionalPrecio_Enabled = 0;
         edtPostulacionProfesionalPlazoE_Enabled = 0;
         cmbPostulacionProfesionalUniE.Enabled = 0;
         edtPostulacionProfesionalGar_Enabled = 0;
         cmbPostulacionProfesionalUniG.Enabled = 0;
         edtPostulacionProfesionalA_Enabled = 0;
         edtPostulacionesId_Enabled = 0;
         AssignProp(sPrefix, false, edtPostulacionesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPostulacionesId_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUPKQ0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14KQ2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV17DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_15 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_15"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV20GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV21GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV22GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV8PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8PostulacionesId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Class = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( sPrefix+"DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( sPrefix+"DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( sPrefix+"DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            /* Read variables values. */
            A422PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPostulacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A422PostulacionesId", StringUtil.LTrimStr( (decimal)(A422PostulacionesId), 18, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV14OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV15OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E14KQ2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E14KQ2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtPostulacionesId_Visible = 0;
         AssignProp(sPrefix, false, edtPostulacionesId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPostulacionesId_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV14OrderedBy < 1 )
         {
            AV14OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV17DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV17DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         edtavVermas_gximage = "prompt";
         AssignProp(sPrefix, false, edtavVermas_Internalname, "gximage", edtavVermas_gximage, !bGXsfl_15_Refreshing);
         AV37VerMas = context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( ));
         AssignProp(sPrefix, false, edtavVermas_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37VerMas)) ? AV38Vermas_GXI : context.convertURL( context.PathToRelativeUrl( AV37VerMas))), !bGXsfl_15_Refreshing);
         AssignProp(sPrefix, false, edtavVermas_Internalname, "SrcSet", context.GetImageSrcSet( AV37VerMas), true);
         AV38Vermas_GXI = GXDbFile.PathToUrl( context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )), context);
         AssignProp(sPrefix, false, edtavVermas_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV37VerMas)) ? AV38Vermas_GXI : context.convertURL( context.PathToRelativeUrl( AV37VerMas))), !bGXsfl_15_Refreshing);
         AssignProp(sPrefix, false, edtavVermas_Internalname, "SrcSet", context.GetImageSrcSet( AV37VerMas), true);
         edtavVermas_Tooltiptext = context.GetMessage( "Ver aclaración", "");
         AssignProp(sPrefix, false, edtavVermas_Internalname, "Tooltiptext", edtavVermas_Tooltiptext, !bGXsfl_15_Refreshing);
      }

      protected void E15KQ2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV20GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV20GridCurrentPage), 10, 0));
         AV21GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV21GridPageCount", StringUtil.LTrimStr( (decimal)(AV21GridPageCount), 10, 0));
         GXt_char2 = AV22GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV39Pgmname, out  GXt_char2) ;
         AV22GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV22GridAppliedFilters", AV22GridAppliedFilters);
         /*  Sending Event outputs  */
      }

      protected void E11KQ2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV19PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV19PageToGo) ;
         }
         /*  Sending Event outputs  */
      }

      protected void E12KQ2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E13KQ2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ProfesionalesNombreCompleto") == 0 )
            {
               AV23TFProfesionalesNombreCompleto = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV23TFProfesionalesNombreCompleto", AV23TFProfesionalesNombreCompleto);
               AV24TFProfesionalesNombreCompleto_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV24TFProfesionalesNombreCompleto_Sel", AV24TFProfesionalesNombreCompleto_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionProfesionalPrecio") == 0 )
            {
               AV25TFPostulacionProfesionalPrecio = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV25TFPostulacionProfesionalPrecio", StringUtil.LTrimStr( AV25TFPostulacionProfesionalPrecio, 18, 2));
               AV26TFPostulacionProfesionalPrecio_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV26TFPostulacionProfesionalPrecio_To", StringUtil.LTrimStr( AV26TFPostulacionProfesionalPrecio_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionProfesionalPlazoE") == 0 )
            {
               AV27TFPostulacionProfesionalPlazoE = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV27TFPostulacionProfesionalPlazoE", StringUtil.LTrimStr( (decimal)(AV27TFPostulacionProfesionalPlazoE), 4, 0));
               AV28TFPostulacionProfesionalPlazoE_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV28TFPostulacionProfesionalPlazoE_To", StringUtil.LTrimStr( (decimal)(AV28TFPostulacionProfesionalPlazoE_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionProfesionalUniE") == 0 )
            {
               AV29TFPostulacionProfesionalUniE_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV29TFPostulacionProfesionalUniE_SelsJson", AV29TFPostulacionProfesionalUniE_SelsJson);
               AV30TFPostulacionProfesionalUniE_Sels.FromJSonString(AV29TFPostulacionProfesionalUniE_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionProfesionalGar") == 0 )
            {
               AV33TFPostulacionProfesionalGar = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV33TFPostulacionProfesionalGar", StringUtil.LTrimStr( (decimal)(AV33TFPostulacionProfesionalGar), 4, 0));
               AV34TFPostulacionProfesionalGar_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV34TFPostulacionProfesionalGar_To", StringUtil.LTrimStr( (decimal)(AV34TFPostulacionProfesionalGar_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionProfesionalUniG") == 0 )
            {
               AV31TFPostulacionProfesionalUniG_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV31TFPostulacionProfesionalUniG_SelsJson", AV31TFPostulacionProfesionalUniG_SelsJson);
               AV32TFPostulacionProfesionalUniG_Sels.FromJSonString(AV31TFPostulacionProfesionalUniG_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "PostulacionProfesionalA") == 0 )
            {
               AV35TFPostulacionProfesionalA = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV35TFPostulacionProfesionalA", AV35TFPostulacionProfesionalA);
               AV36TFPostulacionProfesionalA_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV36TFPostulacionProfesionalA_Sel", AV36TFPostulacionProfesionalA_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32TFPostulacionProfesionalUniG_Sels", AV32TFPostulacionProfesionalUniG_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV30TFPostulacionProfesionalUniE_Sels", AV30TFPostulacionProfesionalUniE_Sels);
      }

      private void E16KQ2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 15;
         }
         sendrow_152( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_15_Refreshing )
         {
            context.DoAjaxLoad(15, GridRow);
         }
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV39Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV39Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV16Session.Get(AV39Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV40GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESNOMBRECOMPLETO") == 0 )
            {
               AV23TFProfesionalesNombreCompleto = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFProfesionalesNombreCompleto", AV23TFProfesionalesNombreCompleto);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESNOMBRECOMPLETO_SEL") == 0 )
            {
               AV24TFProfesionalesNombreCompleto_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFProfesionalesNombreCompleto_Sel", AV24TFProfesionalesNombreCompleto_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALPRECIO") == 0 )
            {
               AV25TFPostulacionProfesionalPrecio = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV25TFPostulacionProfesionalPrecio", StringUtil.LTrimStr( AV25TFPostulacionProfesionalPrecio, 18, 2));
               AV26TFPostulacionProfesionalPrecio_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV26TFPostulacionProfesionalPrecio_To", StringUtil.LTrimStr( AV26TFPostulacionProfesionalPrecio_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALPLAZOE") == 0 )
            {
               AV27TFPostulacionProfesionalPlazoE = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV27TFPostulacionProfesionalPlazoE", StringUtil.LTrimStr( (decimal)(AV27TFPostulacionProfesionalPlazoE), 4, 0));
               AV28TFPostulacionProfesionalPlazoE_To = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV28TFPostulacionProfesionalPlazoE_To", StringUtil.LTrimStr( (decimal)(AV28TFPostulacionProfesionalPlazoE_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALUNIE_SEL") == 0 )
            {
               AV29TFPostulacionProfesionalUniE_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV29TFPostulacionProfesionalUniE_SelsJson", AV29TFPostulacionProfesionalUniE_SelsJson);
               AV30TFPostulacionProfesionalUniE_Sels.FromJSonString(AV29TFPostulacionProfesionalUniE_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALGAR") == 0 )
            {
               AV33TFPostulacionProfesionalGar = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV33TFPostulacionProfesionalGar", StringUtil.LTrimStr( (decimal)(AV33TFPostulacionProfesionalGar), 4, 0));
               AV34TFPostulacionProfesionalGar_To = (short)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV34TFPostulacionProfesionalGar_To", StringUtil.LTrimStr( (decimal)(AV34TFPostulacionProfesionalGar_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALUNIG_SEL") == 0 )
            {
               AV31TFPostulacionProfesionalUniG_SelsJson = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV31TFPostulacionProfesionalUniG_SelsJson", AV31TFPostulacionProfesionalUniG_SelsJson);
               AV32TFPostulacionProfesionalUniG_Sels.FromJSonString(AV31TFPostulacionProfesionalUniG_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALA") == 0 )
            {
               AV35TFPostulacionProfesionalA = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFPostulacionProfesionalA", AV35TFPostulacionProfesionalA);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONPROFESIONALA_SEL") == 0 )
            {
               AV36TFPostulacionProfesionalA_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV36TFPostulacionProfesionalA_Sel", AV36TFPostulacionProfesionalA_Sel);
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesNombreCompleto_Sel)),  AV24TFProfesionalesNombreCompleto_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV30TFPostulacionProfesionalUniE_Sels.Count==0),  AV29TFPostulacionProfesionalUniE_SelsJson, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV32TFPostulacionProfesionalUniG_Sels.Count==0),  AV31TFPostulacionProfesionalUniG_SelsJson, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPostulacionProfesionalA_Sel)),  AV36TFPostulacionProfesionalA_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"||||||"+GXt_char3+"||"+GXt_char4+"|"+GXt_char5;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesNombreCompleto)),  AV23TFProfesionalesNombreCompleto, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPostulacionProfesionalA)),  AV35TFPostulacionProfesionalA, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = "|"+GXt_char5+"||||"+((Convert.ToDecimal(0)==AV25TFPostulacionProfesionalPrecio) ? "" : StringUtil.Str( AV25TFPostulacionProfesionalPrecio, 18, 2))+"|"+((0==AV27TFPostulacionProfesionalPlazoE) ? "" : StringUtil.Str( (decimal)(AV27TFPostulacionProfesionalPlazoE), 4, 0))+"||"+((0==AV33TFPostulacionProfesionalGar) ? "" : StringUtil.Str( (decimal)(AV33TFPostulacionProfesionalGar), 4, 0))+"||"+GXt_char4;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||||"+((Convert.ToDecimal(0)==AV26TFPostulacionProfesionalPrecio_To) ? "" : StringUtil.Str( AV26TFPostulacionProfesionalPrecio_To, 18, 2))+"|"+((0==AV28TFPostulacionProfesionalPlazoE_To) ? "" : StringUtil.Str( (decimal)(AV28TFPostulacionProfesionalPlazoE_To), 4, 0))+"||"+((0==AV34TFPostulacionProfesionalGar_To) ? "" : StringUtil.Str( (decimal)(AV34TFPostulacionProfesionalGar_To), 4, 0))+"||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV16Session.Get(AV39Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPROFESIONALESNOMBRECOMPLETO",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesNombreCompleto)),  0,  AV23TFProfesionalesNombreCompleto,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesNombreCompleto_Sel)),  AV24TFProfesionalesNombreCompleto_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPOSTULACIONPROFESIONALPRECIO",  context.GetMessage( "Precio propuesto", ""),  !((Convert.ToDecimal(0)==AV25TFPostulacionProfesionalPrecio)&&(Convert.ToDecimal(0)==AV26TFPostulacionProfesionalPrecio_To)),  0,  StringUtil.Trim( StringUtil.Str( AV25TFPostulacionProfesionalPrecio, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV26TFPostulacionProfesionalPrecio_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPOSTULACIONPROFESIONALPLAZOE",  context.GetMessage( "Plazo Ejecucion", ""),  !((0==AV27TFPostulacionProfesionalPlazoE)&&(0==AV28TFPostulacionProfesionalPlazoE_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV27TFPostulacionProfesionalPlazoE), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV28TFPostulacionProfesionalPlazoE_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPOSTULACIONPROFESIONALUNIE_SEL",  context.GetMessage( "Plazo Ejecucion (U)", ""),  !(AV30TFPostulacionProfesionalUniE_Sels.Count==0),  0,  AV30TFPostulacionProfesionalUniE_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPOSTULACIONPROFESIONALGAR",  context.GetMessage( "Plazo Garantia", ""),  !((0==AV33TFPostulacionProfesionalGar)&&(0==AV34TFPostulacionProfesionalGar_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV33TFPostulacionProfesionalGar), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV34TFPostulacionProfesionalGar_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFPOSTULACIONPROFESIONALUNIG_SEL",  context.GetMessage( "Plazo Garantia (U)", ""),  !(AV32TFPostulacionProfesionalUniG_Sels.Count==0),  0,  AV32TFPostulacionProfesionalUniG_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFPOSTULACIONPROFESIONALA",  context.GetMessage( "Aclaraciones", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPostulacionProfesionalA)),  0,  AV35TFPostulacionProfesionalA,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPostulacionProfesionalA_Sel)),  AV36TFPostulacionProfesionalA_Sel,  "") ;
         if ( ! (0==AV8PostulacionesId) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&POSTULACIONESID";
            AV13GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8PostulacionesId), 18, 0);
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV39Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV39Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "Postulaciones";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "PostulacionesId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8PostulacionesId), 18, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV16Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void E17KQ2( )
      {
         /* Vermas_Click Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wcpopovertexto.aspx"+UrlEncode(StringUtil.RTrim(context.GetMessage( "Detalle del Profesional", ""))) + "," + UrlEncode(StringUtil.RTrim(A984PostulacionProfesionalA));
         context.PopUp(formatLink("wcpopovertexto.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8PostulacionesId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8PostulacionesId", StringUtil.LTrimStr( (decimal)(AV8PostulacionesId), 18, 0));
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
         PAKQ2( ) ;
         WSKQ2( ) ;
         WEKQ2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SITE ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV8PostulacionesId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PAKQ2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "postulacionesprofesionaleswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PAKQ2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8PostulacionesId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8PostulacionesId", StringUtil.LTrimStr( (decimal)(AV8PostulacionesId), 18, 0));
         }
         wcpOAV8PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8PostulacionesId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8PostulacionesId != wcpOAV8PostulacionesId ) ) )
         {
            setjustcreated();
         }
         wcpOAV8PostulacionesId = AV8PostulacionesId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8PostulacionesId = cgiGet( sPrefix+"AV8PostulacionesId_CTRL");
         if ( StringUtil.Len( sCtrlAV8PostulacionesId) > 0 )
         {
            AV8PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8PostulacionesId), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8PostulacionesId", StringUtil.LTrimStr( (decimal)(AV8PostulacionesId), 18, 0));
         }
         else
         {
            AV8PostulacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8PostulacionesId_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PAKQ2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WSKQ2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WSKQ2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8PostulacionesId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8PostulacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8PostulacionesId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8PostulacionesId_CTRL", StringUtil.RTrim( sCtrlAV8PostulacionesId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WEKQ2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202693204738", true, true, false);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("postulacionesprofesionaleswc.js", "?202693204739", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_152( )
      {
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID_"+sGXsfl_15_idx;
         edtProfesionalesNombreCompleto_Internalname = sPrefix+"PROFESIONALESNOMBRECOMPLETO_"+sGXsfl_15_idx;
         cmbPostulacionProfesionalEstado_Internalname = sPrefix+"POSTULACIONPROFESIONALESTADO_"+sGXsfl_15_idx;
         edtPostulacionProfesionalFechaA_Internalname = sPrefix+"POSTULACIONPROFESIONALFECHAA_"+sGXsfl_15_idx;
         edtPostulacionProfesionalFechaT_Internalname = sPrefix+"POSTULACIONPROFESIONALFECHAT_"+sGXsfl_15_idx;
         edtPostulacionProfesionalTurnoT_Internalname = sPrefix+"POSTULACIONPROFESIONALTURNOT_"+sGXsfl_15_idx;
         edtPostulacionProfesionalPrecio_Internalname = sPrefix+"POSTULACIONPROFESIONALPRECIO_"+sGXsfl_15_idx;
         edtPostulacionProfesionalPlazoE_Internalname = sPrefix+"POSTULACIONPROFESIONALPLAZOE_"+sGXsfl_15_idx;
         cmbPostulacionProfesionalUniE_Internalname = sPrefix+"POSTULACIONPROFESIONALUNIE_"+sGXsfl_15_idx;
         edtPostulacionProfesionalGar_Internalname = sPrefix+"POSTULACIONPROFESIONALGAR_"+sGXsfl_15_idx;
         cmbPostulacionProfesionalUniG_Internalname = sPrefix+"POSTULACIONPROFESIONALUNIG_"+sGXsfl_15_idx;
         edtPostulacionProfesionalA_Internalname = sPrefix+"POSTULACIONPROFESIONALA_"+sGXsfl_15_idx;
         edtavVermas_Internalname = sPrefix+"vVERMAS_"+sGXsfl_15_idx;
      }

      protected void SubsflControlProps_fel_152( )
      {
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID_"+sGXsfl_15_fel_idx;
         edtProfesionalesNombreCompleto_Internalname = sPrefix+"PROFESIONALESNOMBRECOMPLETO_"+sGXsfl_15_fel_idx;
         cmbPostulacionProfesionalEstado_Internalname = sPrefix+"POSTULACIONPROFESIONALESTADO_"+sGXsfl_15_fel_idx;
         edtPostulacionProfesionalFechaA_Internalname = sPrefix+"POSTULACIONPROFESIONALFECHAA_"+sGXsfl_15_fel_idx;
         edtPostulacionProfesionalFechaT_Internalname = sPrefix+"POSTULACIONPROFESIONALFECHAT_"+sGXsfl_15_fel_idx;
         edtPostulacionProfesionalTurnoT_Internalname = sPrefix+"POSTULACIONPROFESIONALTURNOT_"+sGXsfl_15_fel_idx;
         edtPostulacionProfesionalPrecio_Internalname = sPrefix+"POSTULACIONPROFESIONALPRECIO_"+sGXsfl_15_fel_idx;
         edtPostulacionProfesionalPlazoE_Internalname = sPrefix+"POSTULACIONPROFESIONALPLAZOE_"+sGXsfl_15_fel_idx;
         cmbPostulacionProfesionalUniE_Internalname = sPrefix+"POSTULACIONPROFESIONALUNIE_"+sGXsfl_15_fel_idx;
         edtPostulacionProfesionalGar_Internalname = sPrefix+"POSTULACIONPROFESIONALGAR_"+sGXsfl_15_fel_idx;
         cmbPostulacionProfesionalUniG_Internalname = sPrefix+"POSTULACIONPROFESIONALUNIG_"+sGXsfl_15_fel_idx;
         edtPostulacionProfesionalA_Internalname = sPrefix+"POSTULACIONPROFESIONALA_"+sGXsfl_15_fel_idx;
         edtavVermas_Internalname = sPrefix+"vVERMAS_"+sGXsfl_15_fel_idx;
      }

      protected void sendrow_152( )
      {
         sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
         SubsflControlProps_152( ) ;
         WBKQ0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_15_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_15_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_15_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesNombreCompleto_Internalname,(string)A886ProfesionalesNombreCompleto,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProfesionalesNombreCompleto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbPostulacionProfesionalEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "POSTULACIONPROFESIONALESTADO_" + sGXsfl_15_idx;
               cmbPostulacionProfesionalEstado.Name = GXCCtl;
               cmbPostulacionProfesionalEstado.WebTags = "";
               cmbPostulacionProfesionalEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbPostulacionProfesionalEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbPostulacionProfesionalEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
               cmbPostulacionProfesionalEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
               if ( cmbPostulacionProfesionalEstado.ItemCount > 0 )
               {
                  A956PostulacionProfesionalEstado = cmbPostulacionProfesionalEstado.getValidValue(A956PostulacionProfesionalEstado);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPostulacionProfesionalEstado,(string)cmbPostulacionProfesionalEstado_Internalname,StringUtil.RTrim( A956PostulacionProfesionalEstado),(short)1,(string)cmbPostulacionProfesionalEstado_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbPostulacionProfesionalEstado.CurrentValue = StringUtil.RTrim( A956PostulacionProfesionalEstado);
            AssignProp(sPrefix, false, cmbPostulacionProfesionalEstado_Internalname, "Values", (string)(cmbPostulacionProfesionalEstado.ToJavascriptSource()), !bGXsfl_15_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalFechaA_Internalname,context.localUtil.TToC( A957PostulacionProfesionalFechaA, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A957PostulacionProfesionalFechaA, "99/99/99 99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalFechaA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalFechaT_Internalname,context.localUtil.Format(A958PostulacionProfesionalFechaT, "99/99/99"),context.localUtil.Format( A958PostulacionProfesionalFechaT, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalFechaT_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalTurnoT_Internalname,StringUtil.RTrim( A959PostulacionProfesionalTurnoT),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalTurnoT_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( A982PostulacionProfesionalPrecio, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A982PostulacionProfesionalPrecio, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalPlazoE_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A983PostulacionProfesionalPlazoE), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A983PostulacionProfesionalPlazoE), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalPlazoE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbPostulacionProfesionalUniE.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "POSTULACIONPROFESIONALUNIE_" + sGXsfl_15_idx;
               cmbPostulacionProfesionalUniE.Name = GXCCtl;
               cmbPostulacionProfesionalUniE.WebTags = "";
               cmbPostulacionProfesionalUniE.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
               cmbPostulacionProfesionalUniE.addItem("D", context.GetMessage( "Días", ""), 0);
               cmbPostulacionProfesionalUniE.addItem("M", context.GetMessage( "Meses", ""), 0);
               if ( cmbPostulacionProfesionalUniE.ItemCount > 0 )
               {
                  A986PostulacionProfesionalUniE = cmbPostulacionProfesionalUniE.getValidValue(A986PostulacionProfesionalUniE);
                  n986PostulacionProfesionalUniE = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPostulacionProfesionalUniE,(string)cmbPostulacionProfesionalUniE_Internalname,StringUtil.RTrim( A986PostulacionProfesionalUniE),(short)1,(string)cmbPostulacionProfesionalUniE_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbPostulacionProfesionalUniE.CurrentValue = StringUtil.RTrim( A986PostulacionProfesionalUniE);
            AssignProp(sPrefix, false, cmbPostulacionProfesionalUniE_Internalname, "Values", (string)(cmbPostulacionProfesionalUniE.ToJavascriptSource()), !bGXsfl_15_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalGar_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A985PostulacionProfesionalGar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A985PostulacionProfesionalGar), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalGar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbPostulacionProfesionalUniG.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "POSTULACIONPROFESIONALUNIG_" + sGXsfl_15_idx;
               cmbPostulacionProfesionalUniG.Name = GXCCtl;
               cmbPostulacionProfesionalUniG.WebTags = "";
               cmbPostulacionProfesionalUniG.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
               cmbPostulacionProfesionalUniG.addItem("D", context.GetMessage( "Días", ""), 0);
               cmbPostulacionProfesionalUniG.addItem("M", context.GetMessage( "Meses", ""), 0);
               if ( cmbPostulacionProfesionalUniG.ItemCount > 0 )
               {
                  A987PostulacionProfesionalUniG = cmbPostulacionProfesionalUniG.getValidValue(A987PostulacionProfesionalUniG);
                  n987PostulacionProfesionalUniG = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbPostulacionProfesionalUniG,(string)cmbPostulacionProfesionalUniG_Internalname,StringUtil.RTrim( A987PostulacionProfesionalUniG),(short)1,(string)cmbPostulacionProfesionalUniG_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbPostulacionProfesionalUniG.CurrentValue = StringUtil.RTrim( A987PostulacionProfesionalUniG);
            AssignProp(sPrefix, false, cmbPostulacionProfesionalUniG_Internalname, "Values", (string)(cmbPostulacionProfesionalUniG.ToJavascriptSource()), !bGXsfl_15_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPostulacionProfesionalA_Internalname,(string)A984PostulacionProfesionalA,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPostulacionProfesionalA_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)500,(short)0,(short)0,(short)15,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',15)\"";
            ClassString = "Attribute" + " " + ((StringUtil.StrCmp(edtavVermas_gximage, "")==0) ? "" : "GX_Image_"+edtavVermas_gximage+"_Class");
            StyleString = "";
            AV37VerMas_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV37VerMas))&&String.IsNullOrEmpty(StringUtil.RTrim( AV38Vermas_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV37VerMas)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV37VerMas)) ? AV38Vermas_GXI : context.PathToRelativeUrl( AV37VerMas));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavVermas_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)edtavVermas_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavVermas_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVVERMAS.CLICK."+sGXsfl_15_idx+"'",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV37VerMas_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            send_integrity_lvl_hashesKQ2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_15_idx = ((subGrid_Islastpage==1)&&(nGXsfl_15_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_15_idx+1);
            sGXsfl_15_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_15_idx), 4, 0), 4, "0");
            SubsflControlProps_152( ) ;
         }
         /* End function sendrow_152 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "POSTULACIONPROFESIONALESTADO_" + sGXsfl_15_idx;
         cmbPostulacionProfesionalEstado.Name = GXCCtl;
         cmbPostulacionProfesionalEstado.WebTags = "";
         cmbPostulacionProfesionalEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbPostulacionProfesionalEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbPostulacionProfesionalEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbPostulacionProfesionalEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbPostulacionProfesionalEstado.ItemCount > 0 )
         {
         }
         GXCCtl = "POSTULACIONPROFESIONALUNIE_" + sGXsfl_15_idx;
         cmbPostulacionProfesionalUniE.Name = GXCCtl;
         cmbPostulacionProfesionalUniE.WebTags = "";
         cmbPostulacionProfesionalUniE.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbPostulacionProfesionalUniE.addItem("D", context.GetMessage( "Días", ""), 0);
         cmbPostulacionProfesionalUniE.addItem("M", context.GetMessage( "Meses", ""), 0);
         if ( cmbPostulacionProfesionalUniE.ItemCount > 0 )
         {
         }
         GXCCtl = "POSTULACIONPROFESIONALUNIG_" + sGXsfl_15_idx;
         cmbPostulacionProfesionalUniG.Name = GXCCtl;
         cmbPostulacionProfesionalUniG.WebTags = "";
         cmbPostulacionProfesionalUniG.addItem("", context.GetMessage( "GX_EmptyItemText", ""), 0);
         cmbPostulacionProfesionalUniG.addItem("D", context.GetMessage( "Días", ""), 0);
         cmbPostulacionProfesionalUniG.addItem("M", context.GetMessage( "Meses", ""), 0);
         if ( cmbPostulacionProfesionalUniG.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl15( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"15\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Postulacion Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha alta postulacion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Fecha propuesta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Turno propuesto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio propuesto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Plazo Ejecucion", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Plazo Ejecucion (U)", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Plazo Garantia", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Plazo Garantia (U)", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Aclaraciones", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+" "+((StringUtil.StrCmp(edtavVermas_gximage, "")==0) ? "" : "GX_Image_"+edtavVermas_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A886ProfesionalesNombreCompleto));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A956PostulacionProfesionalEstado)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A957PostulacionProfesionalFechaA, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A958PostulacionProfesionalFechaT, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A959PostulacionProfesionalTurnoT)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A982PostulacionProfesionalPrecio, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A983PostulacionProfesionalPlazoE), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A986PostulacionProfesionalUniE)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A985PostulacionProfesionalGar), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A987PostulacionProfesionalUniG)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A984PostulacionProfesionalA));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV37VerMas));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavVermas_Tooltiptext));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtProfesionalesId_Internalname = sPrefix+"PROFESIONALESID";
         edtProfesionalesNombreCompleto_Internalname = sPrefix+"PROFESIONALESNOMBRECOMPLETO";
         cmbPostulacionProfesionalEstado_Internalname = sPrefix+"POSTULACIONPROFESIONALESTADO";
         edtPostulacionProfesionalFechaA_Internalname = sPrefix+"POSTULACIONPROFESIONALFECHAA";
         edtPostulacionProfesionalFechaT_Internalname = sPrefix+"POSTULACIONPROFESIONALFECHAT";
         edtPostulacionProfesionalTurnoT_Internalname = sPrefix+"POSTULACIONPROFESIONALTURNOT";
         edtPostulacionProfesionalPrecio_Internalname = sPrefix+"POSTULACIONPROFESIONALPRECIO";
         edtPostulacionProfesionalPlazoE_Internalname = sPrefix+"POSTULACIONPROFESIONALPLAZOE";
         cmbPostulacionProfesionalUniE_Internalname = sPrefix+"POSTULACIONPROFESIONALUNIE";
         edtPostulacionProfesionalGar_Internalname = sPrefix+"POSTULACIONPROFESIONALGAR";
         cmbPostulacionProfesionalUniG_Internalname = sPrefix+"POSTULACIONPROFESIONALUNIG";
         edtPostulacionProfesionalA_Internalname = sPrefix+"POSTULACIONPROFESIONALA";
         edtavVermas_Internalname = sPrefix+"vVERMAS";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtPostulacionesId_Internalname = sPrefix+"POSTULACIONESID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavVermas_Jsonclick = "";
         edtPostulacionProfesionalA_Jsonclick = "";
         cmbPostulacionProfesionalUniG_Jsonclick = "";
         edtPostulacionProfesionalGar_Jsonclick = "";
         cmbPostulacionProfesionalUniE_Jsonclick = "";
         edtPostulacionProfesionalPlazoE_Jsonclick = "";
         edtPostulacionProfesionalPrecio_Jsonclick = "";
         edtPostulacionProfesionalTurnoT_Jsonclick = "";
         edtPostulacionProfesionalFechaT_Jsonclick = "";
         edtPostulacionProfesionalFechaA_Jsonclick = "";
         cmbPostulacionProfesionalEstado_Jsonclick = "";
         edtProfesionalesNombreCompleto_Jsonclick = "";
         edtProfesionalesId_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavVermas_gximage = "";
         edtPostulacionesId_Enabled = 0;
         edtPostulacionProfesionalA_Enabled = 0;
         cmbPostulacionProfesionalUniG.Enabled = 0;
         edtPostulacionProfesionalGar_Enabled = 0;
         cmbPostulacionProfesionalUniE.Enabled = 0;
         edtPostulacionProfesionalPlazoE_Enabled = 0;
         edtPostulacionProfesionalPrecio_Enabled = 0;
         edtPostulacionProfesionalTurnoT_Enabled = 0;
         edtPostulacionProfesionalFechaT_Enabled = 0;
         edtPostulacionProfesionalFechaA_Enabled = 0;
         cmbPostulacionProfesionalEstado.Enabled = 0;
         edtProfesionalesNombreCompleto_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         subGrid_Sortable = 0;
         edtPostulacionesId_Jsonclick = "";
         edtPostulacionesId_Visible = 1;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "|||||-18.2|4.0||4.0||";
         Ddo_grid_Datalistproc = "PostulacionesProfesionalesWCGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||||D:Días,M:Meses||D:Días,M:Meses|";
         Ddo_grid_Allowmultipleselection = "|||||||T||T|";
         Ddo_grid_Datalisttype = "|Dynamic||||||FixedValues||FixedValues|Dynamic";
         Ddo_grid_Includedatalist = "|T||||||T||T|T";
         Ddo_grid_Filterisrange = "|||||T|T||T||";
         Ddo_grid_Filtertype = "|Character||||Numeric|Numeric||Numeric||Character";
         Ddo_grid_Includefilter = "|T||||T|T||T||T";
         Ddo_grid_Includesortasc = "T||T|T|T|T|T|T|T|T|T";
         Ddo_grid_Columnssortvalues = "1||2|3|4|5|6|7|8|9|10";
         Ddo_grid_Columnids = "0:ProfesionalesId|1:ProfesionalesNombreCompleto|2:PostulacionProfesionalEstado|4:PostulacionProfesionalFechaT|5:PostulacionProfesionalTurnoT|6:PostulacionProfesionalPrecio|7:PostulacionProfesionalPlazoE|8:PostulacionProfesionalUniE|9:PostulacionProfesionalGar|10:PostulacionProfesionalUniG|11:PostulacionProfesionalA";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = context.GetMessage( "WWP_PagingCaption", "");
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Right";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( 0);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( 0);
         Gridpaginationbar_Class = "PaginationBar";
         edtavVermas_Tooltiptext = "";
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'AV37VerMas',fld:'vVERMAS',pic:'',type:'bits'},{av:'edtavVermas_Tooltiptext',ctrl:'vVERMAS',prop:'Tooltiptext'},{av:'sPrefix',type:'char'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8PostulacionesId',fld:'vPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV23TFProfesionalesNombreCompleto',fld:'vTFPROFESIONALESNOMBRECOMPLETO',pic:'',type:'svchar'},{av:'AV24TFProfesionalesNombreCompleto_Sel',fld:'vTFPROFESIONALESNOMBRECOMPLETO_SEL',pic:'',type:'svchar'},{av:'AV25TFPostulacionProfesionalPrecio',fld:'vTFPOSTULACIONPROFESIONALPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26TFPostulacionProfesionalPrecio_To',fld:'vTFPOSTULACIONPROFESIONALPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV27TFPostulacionProfesionalPlazoE',fld:'vTFPOSTULACIONPROFESIONALPLAZOE',pic:'ZZZ9',type:'int'},{av:'AV28TFPostulacionProfesionalPlazoE_To',fld:'vTFPOSTULACIONPROFESIONALPLAZOE_TO',pic:'ZZZ9',type:'int'},{av:'AV30TFPostulacionProfesionalUniE_Sels',fld:'vTFPOSTULACIONPROFESIONALUNIE_SELS',pic:''},{av:'AV33TFPostulacionProfesionalGar',fld:'vTFPOSTULACIONPROFESIONALGAR',pic:'ZZZ9',type:'int'},{av:'AV34TFPostulacionProfesionalGar_To',fld:'vTFPOSTULACIONPROFESIONALGAR_TO',pic:'ZZZ9',type:'int'},{av:'AV32TFPostulacionProfesionalUniG_Sels',fld:'vTFPOSTULACIONPROFESIONALUNIG_SELS',pic:''},{av:'AV35TFPostulacionProfesionalA',fld:'vTFPOSTULACIONPROFESIONALA',pic:'',type:'svchar'},{av:'AV36TFPostulacionProfesionalA_Sel',fld:'vTFPOSTULACIONPROFESIONALA_SEL',pic:'',type:'svchar'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV20GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV21GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV22GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11KQ2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8PostulacionesId',fld:'vPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV23TFProfesionalesNombreCompleto',fld:'vTFPROFESIONALESNOMBRECOMPLETO',pic:'',type:'svchar'},{av:'AV24TFProfesionalesNombreCompleto_Sel',fld:'vTFPROFESIONALESNOMBRECOMPLETO_SEL',pic:'',type:'svchar'},{av:'AV25TFPostulacionProfesionalPrecio',fld:'vTFPOSTULACIONPROFESIONALPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26TFPostulacionProfesionalPrecio_To',fld:'vTFPOSTULACIONPROFESIONALPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV27TFPostulacionProfesionalPlazoE',fld:'vTFPOSTULACIONPROFESIONALPLAZOE',pic:'ZZZ9',type:'int'},{av:'AV28TFPostulacionProfesionalPlazoE_To',fld:'vTFPOSTULACIONPROFESIONALPLAZOE_TO',pic:'ZZZ9',type:'int'},{av:'AV30TFPostulacionProfesionalUniE_Sels',fld:'vTFPOSTULACIONPROFESIONALUNIE_SELS',pic:''},{av:'AV33TFPostulacionProfesionalGar',fld:'vTFPOSTULACIONPROFESIONALGAR',pic:'ZZZ9',type:'int'},{av:'AV34TFPostulacionProfesionalGar_To',fld:'vTFPOSTULACIONPROFESIONALGAR_TO',pic:'ZZZ9',type:'int'},{av:'AV32TFPostulacionProfesionalUniG_Sels',fld:'vTFPOSTULACIONPROFESIONALUNIG_SELS',pic:''},{av:'AV35TFPostulacionProfesionalA',fld:'vTFPOSTULACIONPROFESIONALA',pic:'',type:'svchar'},{av:'AV36TFPostulacionProfesionalA_Sel',fld:'vTFPOSTULACIONPROFESIONALA_SEL',pic:'',type:'svchar'},{av:'AV37VerMas',fld:'vVERMAS',pic:'',type:'bits'},{av:'edtavVermas_Tooltiptext',ctrl:'vVERMAS',prop:'Tooltiptext'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV20GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV21GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV22GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12KQ2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8PostulacionesId',fld:'vPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV23TFProfesionalesNombreCompleto',fld:'vTFPROFESIONALESNOMBRECOMPLETO',pic:'',type:'svchar'},{av:'AV24TFProfesionalesNombreCompleto_Sel',fld:'vTFPROFESIONALESNOMBRECOMPLETO_SEL',pic:'',type:'svchar'},{av:'AV25TFPostulacionProfesionalPrecio',fld:'vTFPOSTULACIONPROFESIONALPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26TFPostulacionProfesionalPrecio_To',fld:'vTFPOSTULACIONPROFESIONALPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV27TFPostulacionProfesionalPlazoE',fld:'vTFPOSTULACIONPROFESIONALPLAZOE',pic:'ZZZ9',type:'int'},{av:'AV28TFPostulacionProfesionalPlazoE_To',fld:'vTFPOSTULACIONPROFESIONALPLAZOE_TO',pic:'ZZZ9',type:'int'},{av:'AV30TFPostulacionProfesionalUniE_Sels',fld:'vTFPOSTULACIONPROFESIONALUNIE_SELS',pic:''},{av:'AV33TFPostulacionProfesionalGar',fld:'vTFPOSTULACIONPROFESIONALGAR',pic:'ZZZ9',type:'int'},{av:'AV34TFPostulacionProfesionalGar_To',fld:'vTFPOSTULACIONPROFESIONALGAR_TO',pic:'ZZZ9',type:'int'},{av:'AV32TFPostulacionProfesionalUniG_Sels',fld:'vTFPOSTULACIONPROFESIONALUNIG_SELS',pic:''},{av:'AV35TFPostulacionProfesionalA',fld:'vTFPOSTULACIONPROFESIONALA',pic:'',type:'svchar'},{av:'AV36TFPostulacionProfesionalA_Sel',fld:'vTFPOSTULACIONPROFESIONALA_SEL',pic:'',type:'svchar'},{av:'AV37VerMas',fld:'vVERMAS',pic:'',type:'bits'},{av:'edtavVermas_Tooltiptext',ctrl:'vVERMAS',prop:'Tooltiptext'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E13KQ2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV8PostulacionesId',fld:'vPOSTULACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV39Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV23TFProfesionalesNombreCompleto',fld:'vTFPROFESIONALESNOMBRECOMPLETO',pic:'',type:'svchar'},{av:'AV24TFProfesionalesNombreCompleto_Sel',fld:'vTFPROFESIONALESNOMBRECOMPLETO_SEL',pic:'',type:'svchar'},{av:'AV25TFPostulacionProfesionalPrecio',fld:'vTFPOSTULACIONPROFESIONALPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26TFPostulacionProfesionalPrecio_To',fld:'vTFPOSTULACIONPROFESIONALPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV27TFPostulacionProfesionalPlazoE',fld:'vTFPOSTULACIONPROFESIONALPLAZOE',pic:'ZZZ9',type:'int'},{av:'AV28TFPostulacionProfesionalPlazoE_To',fld:'vTFPOSTULACIONPROFESIONALPLAZOE_TO',pic:'ZZZ9',type:'int'},{av:'AV30TFPostulacionProfesionalUniE_Sels',fld:'vTFPOSTULACIONPROFESIONALUNIE_SELS',pic:''},{av:'AV33TFPostulacionProfesionalGar',fld:'vTFPOSTULACIONPROFESIONALGAR',pic:'ZZZ9',type:'int'},{av:'AV34TFPostulacionProfesionalGar_To',fld:'vTFPOSTULACIONPROFESIONALGAR_TO',pic:'ZZZ9',type:'int'},{av:'AV32TFPostulacionProfesionalUniG_Sels',fld:'vTFPOSTULACIONPROFESIONALUNIG_SELS',pic:''},{av:'AV35TFPostulacionProfesionalA',fld:'vTFPOSTULACIONPROFESIONALA',pic:'',type:'svchar'},{av:'AV36TFPostulacionProfesionalA_Sel',fld:'vTFPOSTULACIONPROFESIONALA_SEL',pic:'',type:'svchar'},{av:'AV37VerMas',fld:'vVERMAS',pic:'',type:'bits'},{av:'edtavVermas_Tooltiptext',ctrl:'vVERMAS',prop:'Tooltiptext'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV35TFPostulacionProfesionalA',fld:'vTFPOSTULACIONPROFESIONALA',pic:'',type:'svchar'},{av:'AV36TFPostulacionProfesionalA_Sel',fld:'vTFPOSTULACIONPROFESIONALA_SEL',pic:'',type:'svchar'},{av:'AV31TFPostulacionProfesionalUniG_SelsJson',fld:'vTFPOSTULACIONPROFESIONALUNIG_SELSJSON',pic:'',type:'vchar'},{av:'AV32TFPostulacionProfesionalUniG_Sels',fld:'vTFPOSTULACIONPROFESIONALUNIG_SELS',pic:''},{av:'AV33TFPostulacionProfesionalGar',fld:'vTFPOSTULACIONPROFESIONALGAR',pic:'ZZZ9',type:'int'},{av:'AV34TFPostulacionProfesionalGar_To',fld:'vTFPOSTULACIONPROFESIONALGAR_TO',pic:'ZZZ9',type:'int'},{av:'AV29TFPostulacionProfesionalUniE_SelsJson',fld:'vTFPOSTULACIONPROFESIONALUNIE_SELSJSON',pic:'',type:'vchar'},{av:'AV30TFPostulacionProfesionalUniE_Sels',fld:'vTFPOSTULACIONPROFESIONALUNIE_SELS',pic:''},{av:'AV27TFPostulacionProfesionalPlazoE',fld:'vTFPOSTULACIONPROFESIONALPLAZOE',pic:'ZZZ9',type:'int'},{av:'AV28TFPostulacionProfesionalPlazoE_To',fld:'vTFPOSTULACIONPROFESIONALPLAZOE_TO',pic:'ZZZ9',type:'int'},{av:'AV25TFPostulacionProfesionalPrecio',fld:'vTFPOSTULACIONPROFESIONALPRECIO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV26TFPostulacionProfesionalPrecio_To',fld:'vTFPOSTULACIONPROFESIONALPRECIO_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV23TFProfesionalesNombreCompleto',fld:'vTFPROFESIONALESNOMBRECOMPLETO',pic:'',type:'svchar'},{av:'AV24TFProfesionalesNombreCompleto_Sel',fld:'vTFPROFESIONALESNOMBRECOMPLETO_SEL',pic:'',type:'svchar'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E16KQ2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[]}");
         setEventMetadata("VVERMAS.CLICK","{handler:'E17KQ2',iparms:[{av:'A984PostulacionProfesionalA',fld:'POSTULACIONPROFESIONALA',pic:'',hsh:true,type:'svchar'}]");
         setEventMetadata("VVERMAS.CLICK",",oparms:[]}");
         setEventMetadata("VALID_PROFESIONALESID","{handler:'Valid_Profesionalesid',iparms:[]");
         setEventMetadata("VALID_PROFESIONALESID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Vermas',iparms:[]");
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

      public override void initialize( )
      {
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV37VerMas = "";
         AV39Pgmname = "";
         AV23TFProfesionalesNombreCompleto = "";
         AV24TFProfesionalesNombreCompleto_Sel = "";
         AV30TFPostulacionProfesionalUniE_Sels = new GxSimpleCollection<string>();
         AV32TFPostulacionProfesionalUniG_Sels = new GxSimpleCollection<string>();
         AV35TFPostulacionProfesionalA = "";
         AV36TFPostulacionProfesionalA_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV22GridAppliedFilters = "";
         AV17DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         A167ProfesionalesApellidoPrimero = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A120ProfesionalesId = "";
         A886ProfesionalesNombreCompleto = "";
         A956PostulacionProfesionalEstado = "";
         A957PostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
         A958PostulacionProfesionalFechaT = DateTime.MinValue;
         A959PostulacionProfesionalTurnoT = "";
         A986PostulacionProfesionalUniE = "";
         A987PostulacionProfesionalUniG = "";
         A984PostulacionProfesionalA = "";
         AV38Vermas_GXI = "";
         GXDecQS = "";
         lV23TFProfesionalesNombreCompleto = "";
         lV35TFPostulacionProfesionalA = "";
         H00KQ2_A422PostulacionesId = new long[1] ;
         H00KQ2_A984PostulacionProfesionalA = new string[] {""} ;
         H00KQ2_n984PostulacionProfesionalA = new bool[] {false} ;
         H00KQ2_A987PostulacionProfesionalUniG = new string[] {""} ;
         H00KQ2_n987PostulacionProfesionalUniG = new bool[] {false} ;
         H00KQ2_A985PostulacionProfesionalGar = new short[1] ;
         H00KQ2_n985PostulacionProfesionalGar = new bool[] {false} ;
         H00KQ2_A986PostulacionProfesionalUniE = new string[] {""} ;
         H00KQ2_n986PostulacionProfesionalUniE = new bool[] {false} ;
         H00KQ2_A983PostulacionProfesionalPlazoE = new short[1] ;
         H00KQ2_n983PostulacionProfesionalPlazoE = new bool[] {false} ;
         H00KQ2_A982PostulacionProfesionalPrecio = new decimal[1] ;
         H00KQ2_n982PostulacionProfesionalPrecio = new bool[] {false} ;
         H00KQ2_A959PostulacionProfesionalTurnoT = new string[] {""} ;
         H00KQ2_A958PostulacionProfesionalFechaT = new DateTime[] {DateTime.MinValue} ;
         H00KQ2_A957PostulacionProfesionalFechaA = new DateTime[] {DateTime.MinValue} ;
         H00KQ2_A956PostulacionProfesionalEstado = new string[] {""} ;
         H00KQ2_A120ProfesionalesId = new string[] {""} ;
         H00KQ2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         H00KQ2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         H00KQ2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         H00KQ3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29TFPostulacionProfesionalUniE_SelsJson = "";
         AV31TFPostulacionProfesionalUniG_SelsJson = "";
         GridRow = new GXWebRow();
         AV16Session = context.GetSession();
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char3 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8PostulacionesId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         TempTags = "";
         sImgUrl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.postulacionesprofesionaleswc__default(),
            new Object[][] {
                new Object[] {
               H00KQ2_A422PostulacionesId, H00KQ2_A984PostulacionProfesionalA, H00KQ2_n984PostulacionProfesionalA, H00KQ2_A987PostulacionProfesionalUniG, H00KQ2_n987PostulacionProfesionalUniG, H00KQ2_A985PostulacionProfesionalGar, H00KQ2_n985PostulacionProfesionalGar, H00KQ2_A986PostulacionProfesionalUniE, H00KQ2_n986PostulacionProfesionalUniE, H00KQ2_A983PostulacionProfesionalPlazoE,
               H00KQ2_n983PostulacionProfesionalPlazoE, H00KQ2_A982PostulacionProfesionalPrecio, H00KQ2_n982PostulacionProfesionalPrecio, H00KQ2_A959PostulacionProfesionalTurnoT, H00KQ2_A958PostulacionProfesionalFechaT, H00KQ2_A957PostulacionProfesionalFechaA, H00KQ2_A956PostulacionProfesionalEstado, H00KQ2_A120ProfesionalesId, H00KQ2_A191ProfesionalesSegundoNombre, H00KQ2_A166ProfesionalesPrimerNombre,
               H00KQ2_A167ProfesionalesApellidoPrimero
               }
               , new Object[] {
               H00KQ3_AGRID_nRecordCount
               }
            }
         );
         AV39Pgmname = "PostulacionesProfesionalesWC";
         /* GeneXus formulas. */
         AV39Pgmname = "PostulacionesProfesionalesWC";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV27TFPostulacionProfesionalPlazoE ;
      private short AV28TFPostulacionProfesionalPlazoE_To ;
      private short AV33TFPostulacionProfesionalGar ;
      private short AV34TFPostulacionProfesionalGar_To ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A983PostulacionProfesionalPlazoE ;
      private short A985PostulacionProfesionalGar ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_15 ;
      private int nGXsfl_15_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtPostulacionesId_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV30TFPostulacionProfesionalUniE_Sels_Count ;
      private int AV32TFPostulacionProfesionalUniG_Sels_Count ;
      private int edtProfesionalesId_Enabled ;
      private int edtProfesionalesNombreCompleto_Enabled ;
      private int edtPostulacionProfesionalFechaA_Enabled ;
      private int edtPostulacionProfesionalFechaT_Enabled ;
      private int edtPostulacionProfesionalTurnoT_Enabled ;
      private int edtPostulacionProfesionalPrecio_Enabled ;
      private int edtPostulacionProfesionalPlazoE_Enabled ;
      private int edtPostulacionProfesionalGar_Enabled ;
      private int edtPostulacionProfesionalA_Enabled ;
      private int edtPostulacionesId_Enabled ;
      private int AV19PageToGo ;
      private int AV40GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8PostulacionesId ;
      private long wcpOAV8PostulacionesId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV20GridCurrentPage ;
      private long AV21GridPageCount ;
      private long A422PostulacionesId ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV25TFPostulacionProfesionalPrecio ;
      private decimal AV26TFPostulacionProfesionalPrecio_To ;
      private decimal A982PostulacionProfesionalPrecio ;
      private string edtavVermas_Tooltiptext ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_15_idx="0001" ;
      private string edtavVermas_Internalname ;
      private string AV39Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablegridheader_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string edtPostulacionesId_Internalname ;
      private string edtPostulacionesId_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Internalname ;
      private string edtProfesionalesNombreCompleto_Internalname ;
      private string cmbPostulacionProfesionalEstado_Internalname ;
      private string A956PostulacionProfesionalEstado ;
      private string edtPostulacionProfesionalFechaA_Internalname ;
      private string edtPostulacionProfesionalFechaT_Internalname ;
      private string A959PostulacionProfesionalTurnoT ;
      private string edtPostulacionProfesionalTurnoT_Internalname ;
      private string edtPostulacionProfesionalPrecio_Internalname ;
      private string edtPostulacionProfesionalPlazoE_Internalname ;
      private string cmbPostulacionProfesionalUniE_Internalname ;
      private string A986PostulacionProfesionalUniE ;
      private string edtPostulacionProfesionalGar_Internalname ;
      private string cmbPostulacionProfesionalUniG_Internalname ;
      private string A987PostulacionProfesionalUniG ;
      private string edtPostulacionProfesionalA_Internalname ;
      private string GXDecQS ;
      private string edtavVermas_gximage ;
      private string GXt_char2 ;
      private string GXt_char3 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string sCtrlAV8PostulacionesId ;
      private string sGXsfl_15_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtProfesionalesNombreCompleto_Jsonclick ;
      private string GXCCtl ;
      private string cmbPostulacionProfesionalEstado_Jsonclick ;
      private string edtPostulacionProfesionalFechaA_Jsonclick ;
      private string edtPostulacionProfesionalFechaT_Jsonclick ;
      private string edtPostulacionProfesionalTurnoT_Jsonclick ;
      private string edtPostulacionProfesionalPrecio_Jsonclick ;
      private string edtPostulacionProfesionalPlazoE_Jsonclick ;
      private string cmbPostulacionProfesionalUniE_Jsonclick ;
      private string edtPostulacionProfesionalGar_Jsonclick ;
      private string cmbPostulacionProfesionalUniG_Jsonclick ;
      private string edtPostulacionProfesionalA_Jsonclick ;
      private string TempTags ;
      private string sImgUrl ;
      private string edtavVermas_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A957PostulacionProfesionalFechaA ;
      private DateTime A958PostulacionProfesionalFechaT ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_15_Refreshing=false ;
      private bool AV15OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n982PostulacionProfesionalPrecio ;
      private bool n983PostulacionProfesionalPlazoE ;
      private bool n986PostulacionProfesionalUniE ;
      private bool n985PostulacionProfesionalGar ;
      private bool n987PostulacionProfesionalUniG ;
      private bool n984PostulacionProfesionalA ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV37VerMas_IsBlob ;
      private string AV29TFPostulacionProfesionalUniE_SelsJson ;
      private string AV31TFPostulacionProfesionalUniG_SelsJson ;
      private string AV23TFProfesionalesNombreCompleto ;
      private string AV24TFProfesionalesNombreCompleto_Sel ;
      private string AV35TFPostulacionProfesionalA ;
      private string AV36TFPostulacionProfesionalA_Sel ;
      private string AV22GridAppliedFilters ;
      private string A886ProfesionalesNombreCompleto ;
      private string A984PostulacionProfesionalA ;
      private string AV38Vermas_GXI ;
      private string lV23TFProfesionalesNombreCompleto ;
      private string lV35TFPostulacionProfesionalA ;
      private string AV37VerMas ;
      private IGxSession AV16Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPostulacionProfesionalEstado ;
      private GXCombobox cmbPostulacionProfesionalUniE ;
      private GXCombobox cmbPostulacionProfesionalUniG ;
      private GxSimpleCollection<string> AV30TFPostulacionProfesionalUniE_Sels ;
      private GxSimpleCollection<string> AV32TFPostulacionProfesionalUniG_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV17DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private long[] H00KQ2_A422PostulacionesId ;
      private string[] H00KQ2_A984PostulacionProfesionalA ;
      private bool[] H00KQ2_n984PostulacionProfesionalA ;
      private string[] H00KQ2_A987PostulacionProfesionalUniG ;
      private bool[] H00KQ2_n987PostulacionProfesionalUniG ;
      private short[] H00KQ2_A985PostulacionProfesionalGar ;
      private bool[] H00KQ2_n985PostulacionProfesionalGar ;
      private string[] H00KQ2_A986PostulacionProfesionalUniE ;
      private bool[] H00KQ2_n986PostulacionProfesionalUniE ;
      private short[] H00KQ2_A983PostulacionProfesionalPlazoE ;
      private bool[] H00KQ2_n983PostulacionProfesionalPlazoE ;
      private decimal[] H00KQ2_A982PostulacionProfesionalPrecio ;
      private bool[] H00KQ2_n982PostulacionProfesionalPrecio ;
      private string[] H00KQ2_A959PostulacionProfesionalTurnoT ;
      private DateTime[] H00KQ2_A958PostulacionProfesionalFechaT ;
      private DateTime[] H00KQ2_A957PostulacionProfesionalFechaA ;
      private string[] H00KQ2_A956PostulacionProfesionalEstado ;
      private string[] H00KQ2_A120ProfesionalesId ;
      private string[] H00KQ2_A191ProfesionalesSegundoNombre ;
      private string[] H00KQ2_A166ProfesionalesPrimerNombre ;
      private string[] H00KQ2_A167ProfesionalesApellidoPrimero ;
      private long[] H00KQ3_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class postulacionesprofesionaleswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00KQ2( IGxContext context ,
                                             string A986PostulacionProfesionalUniE ,
                                             GxSimpleCollection<string> AV30TFPostulacionProfesionalUniE_Sels ,
                                             string A987PostulacionProfesionalUniG ,
                                             GxSimpleCollection<string> AV32TFPostulacionProfesionalUniG_Sels ,
                                             string AV24TFProfesionalesNombreCompleto_Sel ,
                                             string AV23TFProfesionalesNombreCompleto ,
                                             decimal AV25TFPostulacionProfesionalPrecio ,
                                             decimal AV26TFPostulacionProfesionalPrecio_To ,
                                             short AV27TFPostulacionProfesionalPlazoE ,
                                             short AV28TFPostulacionProfesionalPlazoE_To ,
                                             int AV30TFPostulacionProfesionalUniE_Sels_Count ,
                                             short AV33TFPostulacionProfesionalGar ,
                                             short AV34TFPostulacionProfesionalGar_To ,
                                             int AV32TFPostulacionProfesionalUniG_Sels_Count ,
                                             string AV36TFPostulacionProfesionalA_Sel ,
                                             string AV35TFPostulacionProfesionalA ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             decimal A982PostulacionProfesionalPrecio ,
                                             short A983PostulacionProfesionalPlazoE ,
                                             short A985PostulacionProfesionalGar ,
                                             string A984PostulacionProfesionalA ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             long AV8PostulacionesId ,
                                             long A422PostulacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[14];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[PostulacionesId], T1.[PostulacionProfesionalA], T1.[PostulacionProfesionalUniG], T1.[PostulacionProfesionalGar], T1.[PostulacionProfesionalUniE], T1.[PostulacionProfesionalPlazoE], T1.[PostulacionProfesionalPrecio], T1.[PostulacionProfesionalTurnoT], T1.[PostulacionProfesionalFechaT], T1.[PostulacionProfesionalFechaA], T1.[PostulacionProfesionalEstado], T1.[ProfesionalesId], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesApellidoPrimero]";
         sFromString = " FROM ([PostulacionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[PostulacionesId] = @AV8PostulacionesId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesNombreCompleto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesNombreCompleto)) ) )
         {
            AddWhere(sWhereString, "(UPPER(RTRIM(LTRIM(T2.[ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM(T2.[ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM(T2.[ProfesionalesSegundoNombre]))) like UPPER(@lV23TFProfesionalesNombreCompleto))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesNombreCompleto_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesNombreCompleto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM(T2.[ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM(T2.[ProfesionalesSegundoNombre])) = @AV24TFProfesionalesNombreCompleto_Sel)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesNombreCompleto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((RTRIM(LTRIM(T2.[ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM(T2.[ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM(T2.[ProfesionalesSegundoNombre])) = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV25TFPostulacionProfesionalPrecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPrecio] >= @AV25TFPostulacionProfesionalPrecio)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV26TFPostulacionProfesionalPrecio_To) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPrecio] <= @AV26TFPostulacionProfesionalPrecio_To)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (0==AV27TFPostulacionProfesionalPlazoE) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPlazoE] >= @AV27TFPostulacionProfesionalPlazoE)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV28TFPostulacionProfesionalPlazoE_To) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPlazoE] <= @AV28TFPostulacionProfesionalPlazoE_To)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV30TFPostulacionProfesionalUniE_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFPostulacionProfesionalUniE_Sels, "T1.[PostulacionProfesionalUniE] IN (", ")")+")");
         }
         if ( ! (0==AV33TFPostulacionProfesionalGar) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalGar] >= @AV33TFPostulacionProfesionalGar)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! (0==AV34TFPostulacionProfesionalGar_To) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalGar] <= @AV34TFPostulacionProfesionalGar_To)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV32TFPostulacionProfesionalUniG_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV32TFPostulacionProfesionalUniG_Sels, "T1.[PostulacionProfesionalUniG] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPostulacionProfesionalA_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPostulacionProfesionalA)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionProfesionalA]) like UPPER(@lV35TFPostulacionProfesionalA))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPostulacionProfesionalA_Sel)) && ! ( StringUtil.StrCmp(AV36TFPostulacionProfesionalA_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalA] = @AV36TFPostulacionProfesionalA_Sel)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( StringUtil.StrCmp(AV36TFPostulacionProfesionalA_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalA] IS NULL or (T1.[PostulacionProfesionalA] = ''))");
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId], T1.[ProfesionalesId]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId] DESC, T1.[ProfesionalesId] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId], T1.[PostulacionProfesionalEstado]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId] DESC, T1.[PostulacionProfesionalEstado] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId], T1.[PostulacionProfesionalFechaT]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId] DESC, T1.[PostulacionProfesionalFechaT] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId], T1.[PostulacionProfesionalTurnoT]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId] DESC, T1.[PostulacionProfesionalTurnoT] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId], T1.[PostulacionProfesionalPrecio]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId] DESC, T1.[PostulacionProfesionalPrecio] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId], T1.[PostulacionProfesionalPlazoE]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId] DESC, T1.[PostulacionProfesionalPlazoE] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId], T1.[PostulacionProfesionalUniE]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId] DESC, T1.[PostulacionProfesionalUniE] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId], T1.[PostulacionProfesionalGar]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId] DESC, T1.[PostulacionProfesionalGar] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId], T1.[PostulacionProfesionalUniG]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId] DESC, T1.[PostulacionProfesionalUniG] DESC";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId], T1.[PostulacionProfesionalA]";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId] DESC, T1.[PostulacionProfesionalA] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[PostulacionesId], T1.[ProfesionalesId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H00KQ3( IGxContext context ,
                                             string A986PostulacionProfesionalUniE ,
                                             GxSimpleCollection<string> AV30TFPostulacionProfesionalUniE_Sels ,
                                             string A987PostulacionProfesionalUniG ,
                                             GxSimpleCollection<string> AV32TFPostulacionProfesionalUniG_Sels ,
                                             string AV24TFProfesionalesNombreCompleto_Sel ,
                                             string AV23TFProfesionalesNombreCompleto ,
                                             decimal AV25TFPostulacionProfesionalPrecio ,
                                             decimal AV26TFPostulacionProfesionalPrecio_To ,
                                             short AV27TFPostulacionProfesionalPlazoE ,
                                             short AV28TFPostulacionProfesionalPlazoE_To ,
                                             int AV30TFPostulacionProfesionalUniE_Sels_Count ,
                                             short AV33TFPostulacionProfesionalGar ,
                                             short AV34TFPostulacionProfesionalGar_To ,
                                             int AV32TFPostulacionProfesionalUniG_Sels_Count ,
                                             string AV36TFPostulacionProfesionalA_Sel ,
                                             string AV35TFPostulacionProfesionalA ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             decimal A982PostulacionProfesionalPrecio ,
                                             short A983PostulacionProfesionalPlazoE ,
                                             short A985PostulacionProfesionalGar ,
                                             string A984PostulacionProfesionalA ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             long AV8PostulacionesId ,
                                             long A422PostulacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[11];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([PostulacionesProfesionales] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         AddWhere(sWhereString, "(T1.[PostulacionesId] = @AV8PostulacionesId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesNombreCompleto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFProfesionalesNombreCompleto)) ) )
         {
            AddWhere(sWhereString, "(UPPER(RTRIM(LTRIM(T2.[ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM(T2.[ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM(T2.[ProfesionalesSegundoNombre]))) like UPPER(@lV23TFProfesionalesNombreCompleto))");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFProfesionalesNombreCompleto_Sel)) && ! ( StringUtil.StrCmp(AV24TFProfesionalesNombreCompleto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM(T2.[ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM(T2.[ProfesionalesSegundoNombre])) = @AV24TFProfesionalesNombreCompleto_Sel)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFProfesionalesNombreCompleto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((RTRIM(LTRIM(T2.[ProfesionalesApellidoPrimero])) + ', ' + RTRIM(LTRIM(T2.[ProfesionalesPrimerNombre])) + ' ' + RTRIM(LTRIM(T2.[ProfesionalesSegundoNombre])) = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV25TFPostulacionProfesionalPrecio) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPrecio] >= @AV25TFPostulacionProfesionalPrecio)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV26TFPostulacionProfesionalPrecio_To) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPrecio] <= @AV26TFPostulacionProfesionalPrecio_To)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! (0==AV27TFPostulacionProfesionalPlazoE) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPlazoE] >= @AV27TFPostulacionProfesionalPlazoE)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (0==AV28TFPostulacionProfesionalPlazoE_To) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalPlazoE] <= @AV28TFPostulacionProfesionalPlazoE_To)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV30TFPostulacionProfesionalUniE_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV30TFPostulacionProfesionalUniE_Sels, "T1.[PostulacionProfesionalUniE] IN (", ")")+")");
         }
         if ( ! (0==AV33TFPostulacionProfesionalGar) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalGar] >= @AV33TFPostulacionProfesionalGar)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! (0==AV34TFPostulacionProfesionalGar_To) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalGar] <= @AV34TFPostulacionProfesionalGar_To)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV32TFPostulacionProfesionalUniG_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV32TFPostulacionProfesionalUniG_Sels, "T1.[PostulacionProfesionalUniG] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPostulacionProfesionalA_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPostulacionProfesionalA)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PostulacionProfesionalA]) like UPPER(@lV35TFPostulacionProfesionalA))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPostulacionProfesionalA_Sel)) && ! ( StringUtil.StrCmp(AV36TFPostulacionProfesionalA_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalA] = @AV36TFPostulacionProfesionalA_Sel)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV36TFPostulacionProfesionalA_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[PostulacionProfesionalA] IS NULL or (T1.[PostulacionProfesionalA] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00KQ2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (decimal)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] );
               case 1 :
                     return conditional_H00KQ3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (decimal)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH00KQ2;
          prmH00KQ2 = new Object[] {
          new ParDef("@AV8PostulacionesId",GXType.Decimal,18,0) ,
          new ParDef("@lV23TFProfesionalesNombreCompleto",GXType.VarChar,100,0) ,
          new ParDef("@AV24TFProfesionalesNombreCompleto_Sel",GXType.VarChar,100,0) ,
          new ParDef("@AV25TFPostulacionProfesionalPrecio",GXType.Decimal,18,2) ,
          new ParDef("@AV26TFPostulacionProfesionalPrecio_To",GXType.Decimal,18,2) ,
          new ParDef("@AV27TFPostulacionProfesionalPlazoE",GXType.Int16,4,0) ,
          new ParDef("@AV28TFPostulacionProfesionalPlazoE_To",GXType.Int16,4,0) ,
          new ParDef("@AV33TFPostulacionProfesionalGar",GXType.Int16,4,0) ,
          new ParDef("@AV34TFPostulacionProfesionalGar_To",GXType.Int16,4,0) ,
          new ParDef("@lV35TFPostulacionProfesionalA",GXType.VarChar,500,0) ,
          new ParDef("@AV36TFPostulacionProfesionalA_Sel",GXType.NVarChar,500,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00KQ3;
          prmH00KQ3 = new Object[] {
          new ParDef("@AV8PostulacionesId",GXType.Decimal,18,0) ,
          new ParDef("@lV23TFProfesionalesNombreCompleto",GXType.VarChar,100,0) ,
          new ParDef("@AV24TFProfesionalesNombreCompleto_Sel",GXType.VarChar,100,0) ,
          new ParDef("@AV25TFPostulacionProfesionalPrecio",GXType.Decimal,18,2) ,
          new ParDef("@AV26TFPostulacionProfesionalPrecio_To",GXType.Decimal,18,2) ,
          new ParDef("@AV27TFPostulacionProfesionalPlazoE",GXType.Int16,4,0) ,
          new ParDef("@AV28TFPostulacionProfesionalPlazoE_To",GXType.Int16,4,0) ,
          new ParDef("@AV33TFPostulacionProfesionalGar",GXType.Int16,4,0) ,
          new ParDef("@AV34TFPostulacionProfesionalGar_To",GXType.Int16,4,0) ,
          new ParDef("@lV35TFPostulacionProfesionalA",GXType.VarChar,500,0) ,
          new ParDef("@AV36TFPostulacionProfesionalA_Sel",GXType.NVarChar,500,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00KQ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KQ2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00KQ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00KQ3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 1);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getString(8, 1);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(10);
                ((string[]) buf[16])[0] = rslt.getString(11, 3);
                ((string[]) buf[17])[0] = rslt.getString(12, 20);
                ((string[]) buf[18])[0] = rslt.getString(13, 30);
                ((string[]) buf[19])[0] = rslt.getString(14, 30);
                ((string[]) buf[20])[0] = rslt.getString(15, 30);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

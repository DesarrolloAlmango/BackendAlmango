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
   public class secuserww : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public secuserww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserww( IGxContext context )
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
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbusuariosEstado = new GXCombobox();
         cmbSecUserEstado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_118 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_118"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_118_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_118_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_118_idx = GetPar( "sGXsfl_118_idx");
         edtavUaassociateroles_Title = GetNextPar( );
         AssignProp("", false, edtavUaassociateroles_Internalname, "Title", edtavUaassociateroles_Title, !bGXsfl_118_Refreshing);
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
         AV23OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV24OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV27SecUserName1 = GetPar( "SecUserName1");
         AV86usuariosId1 = GetPar( "usuariosId1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV30DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV31SecUserName2 = GetPar( "SecUserName2");
         AV87usuariosId2 = GetPar( "usuariosId2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV33DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV34DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV35SecUserName3 = GetPar( "SecUserName3");
         AV88usuariosId3 = GetPar( "usuariosId3");
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV28DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV32DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV70ColumnsSelector);
         AV104Pgmname = GetPar( "Pgmname");
         AV83FilterFullText = GetPar( "FilterFullText");
         AV47TFSecUserId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFSecUserId"), "."), 18, MidpointRounding.ToEven));
         AV48TFSecUserId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFSecUserId_To"), "."), 18, MidpointRounding.ToEven));
         AV51TFSecUserName = GetPar( "TFSecUserName");
         AV52TFSecUserName_Sel = GetPar( "TFSecUserName_Sel");
         AV89TFSecUserFullName = GetPar( "TFSecUserFullName");
         AV90TFSecUserFullName_Sel = GetPar( "TFSecUserFullName_Sel");
         AV91TFusuariosId = GetPar( "TFusuariosId");
         AV92TFusuariosId_Sel = GetPar( "TFusuariosId_Sel");
         AV93TFusuariosNombre = GetPar( "TFusuariosNombre");
         AV94TFusuariosNombre_Sel = GetPar( "TFusuariosNombre_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV96TFusuariosEstado_Sels);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV98TFSecUserEstado_Sels);
         AV101TFSecUserPassword = GetPar( "TFSecUserPassword");
         AV102TFSecUserPassword_Sel = GetPar( "TFSecUserPassword_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV20GridState);
         AV37DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV36DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         edtavUaassociateroles_Title = GetNextPar( );
         AssignProp("", false, edtavUaassociateroles_Internalname, "Title", edtavUaassociateroles_Title, !bGXsfl_118_Refreshing);
         AV17IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV18IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV103IsAuthorized_Desencriptar = StringUtil.StrToBool( GetPar( "IsAuthorized_Desencriptar"));
         AV16IsAuthorized_UAAssociateRoles = StringUtil.StrToBool( GetPar( "IsAuthorized_UAAssociateRoles"));
         AV100IsAuthorized_usuariosId = StringUtil.StrToBool( GetPar( "IsAuthorized_usuariosId"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV86usuariosId1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV87usuariosId2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV88usuariosId3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV70ColumnsSelector, AV104Pgmname, AV83FilterFullText, AV47TFSecUserId, AV48TFSecUserId_To, AV51TFSecUserName, AV52TFSecUserName_Sel, AV89TFSecUserFullName, AV90TFSecUserFullName_Sel, AV91TFusuariosId, AV92TFusuariosId_Sel, AV93TFusuariosNombre, AV94TFusuariosNombre_Sel, AV96TFusuariosEstado_Sels, AV98TFSecUserEstado_Sels, AV101TFSecUserPassword, AV102TFSecUserPassword_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV17IsAuthorized_Update, AV18IsAuthorized_Delete, AV103IsAuthorized_Desencriptar, AV16IsAuthorized_UAAssociateRoles, AV100IsAuthorized_usuariosId) ;
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

      public override short ExecuteStartEvent( )
      {
         PA0U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0U2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secuserww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV104Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV104Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV17IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV17IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV18IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV18IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DESENCRIPTAR", AV103IsAuthorized_Desencriptar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DESENCRIPTAR", GetSecureSignedToken( "", AV103IsAuthorized_Desencriptar, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UAASSOCIATEROLES", AV16IsAuthorized_UAAssociateRoles);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UAASSOCIATEROLES", GetSecureSignedToken( "", AV16IsAuthorized_UAAssociateRoles, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USUARIOSID", AV100IsAuthorized_usuariosId);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USUARIOSID", GetSecureSignedToken( "", AV100IsAuthorized_usuariosId, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDDSC", StringUtil.BoolToStr( AV24OrderedDsc));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV25DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26DynamicFiltersOperator1), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME1", AV27SecUserName1);
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIOSID1", StringUtil.RTrim( AV86usuariosId1));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV29DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30DynamicFiltersOperator2), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME2", AV31SecUserName2);
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIOSID2", StringUtil.RTrim( AV87usuariosId2));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV33DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34DynamicFiltersOperator3), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECUSERNAME3", AV35SecUserName3);
         GxWebStd.gx_hidden_field( context, "GXH_vUSUARIOSID3", StringUtil.RTrim( AV88usuariosId3));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_118", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_118), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV44ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV44ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV79GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV80GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV82GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV84AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV84AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV54DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV54DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV70ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV70ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV28DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV32DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV104Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV104Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFSECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47TFSecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSECUSERID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48TFSecUserId_To), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vTFSECUSERNAME", AV51TFSecUserName);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERNAME_SEL", AV52TFSecUserName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERFULLNAME", AV89TFSecUserFullName);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERFULLNAME_SEL", AV90TFSecUserFullName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSID", StringUtil.RTrim( AV91TFusuariosId));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSID_SEL", StringUtil.RTrim( AV92TFusuariosId_Sel));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSNOMBRE", StringUtil.RTrim( AV93TFusuariosNombre));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSNOMBRE_SEL", StringUtil.RTrim( AV94TFusuariosNombre_Sel));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFUSUARIOSESTADO_SELS", AV96TFusuariosEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFUSUARIOSESTADO_SELS", AV96TFusuariosEstado_Sels);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFSECUSERESTADO_SELS", AV98TFSecUserEstado_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFSECUSERESTADO_SELS", AV98TFSecUserEstado_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFSECUSERPASSWORD", AV101TFSecUserPassword);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERPASSWORD_SEL", AV102TFSecUserPassword_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV24OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV20GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV20GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV37DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV36DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV17IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV17IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV18IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV18IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DESENCRIPTAR", AV103IsAuthorized_Desencriptar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DESENCRIPTAR", GetSecureSignedToken( "", AV103IsAuthorized_Desencriptar, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UAASSOCIATEROLES", AV16IsAuthorized_UAAssociateRoles);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UAASSOCIATEROLES", GetSecureSignedToken( "", AV16IsAuthorized_UAAssociateRoles, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USUARIOSID", AV100IsAuthorized_usuariosId);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USUARIOSID", GetSecureSignedToken( "", AV100IsAuthorized_usuariosId, context));
         GxWebStd.gx_hidden_field( context, "vTFUSUARIOSESTADO_SELSJSON", AV95TFusuariosEstado_SelsJson);
         GxWebStd.gx_hidden_field( context, "vTFSECUSERESTADO_SELSJSON", AV97TFSecUserEstado_SelsJson);
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DESENCRIPTAR_MODAL_Width", StringUtil.RTrim( Desencriptar_modal_Width));
         GxWebStd.gx_hidden_field( context, "DESENCRIPTAR_MODAL_Title", StringUtil.RTrim( Desencriptar_modal_Title));
         GxWebStd.gx_hidden_field( context, "DESENCRIPTAR_MODAL_Confirmtype", StringUtil.RTrim( Desencriptar_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "DESENCRIPTAR_MODAL_Bodytype", StringUtil.RTrim( Desencriptar_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "vUAASSOCIATEROLES_Title", StringUtil.RTrim( edtavUaassociateroles_Title));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0U2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwpbaseobjects.secuserww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecUserWW" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( " User", "") ;
      }

      protected void WB0U0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColoredActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(118), 3, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(118), 3, 0)+","+"null"+");", context.GetMessage( "WWP_ExportData", ""), bttBtnagexport_Jsonclick, 0, context.GetMessage( "WWP_ExportData", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(118), 3, 0)+","+"null"+");", context.GetMessage( "WWP_EditColumnsCaption", ""), bttBtneditcolumns_Jsonclick, 0, context.GetMessage( "WWP_EditColumnsTooltip", ""), "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_23_0U2( true) ;
         }
         else
         {
            wb_table1_23_0U2( false) ;
         }
         return  ;
      }

      protected void wb_table1_23_0U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellAdvancedFiltersHidden", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedfilterscontainer_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfilters_Internalname, 1, 0, "px", 0, "px", "TableDynamicFiltersFlex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, context.GetMessage( "Dynamic Filters Selector1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV25DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_WWPBaseObjects/SecUserWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_47_0U2( true) ;
         }
         else
         {
            wb_table2_47_0U2( false) ;
         }
         return  ;
      }

      protected void wb_table2_47_0U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, context.GetMessage( "Dynamic Filters Selector2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV29DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 0, "HLP_WWPBaseObjects/SecUserWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_72_0U2( true) ;
         }
         else
         {
            wb_table3_72_0U2( false) ;
         }
         return  ;
      }

      protected void wb_table3_72_0U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, context.GetMessage( "WWP_DynFilterPrefix", ""), "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, context.GetMessage( "Dynamic Filters Selector3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV33DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_WWPBaseObjects/SecUserWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, context.GetMessage( "WWP_DynFilterMiddle", ""), "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_97_0U2( true) ;
         }
         else
         {
            wb_table4_97_0U2( false) ;
         }
         return  ;
      }

      protected void wb_table4_97_0U2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell GridFixedColumnBorders HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl118( ) ;
         }
         if ( wbEnd == 118 )
         {
            wbEnd = 0;
            nRC_GXsfl_118 = (int)(nGXsfl_118_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV79GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV80GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV82GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV84AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects/SecUserWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV54DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV54DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV70ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table5_141_0U2( true) ;
         }
         else
         {
            wb_table5_141_0U2( false) ;
         }
         return  ;
      }

      protected void wb_table5_141_0U2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0148"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0148"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_118_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0148"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 118 )
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
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0U2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_15-188745", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( " User", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0U0( ) ;
      }

      protected void WS0U2( )
      {
         START0U2( ) ;
         EVT0U2( ) ;
      }

      protected void EVT0U2( )
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
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_managefilters.Onoptionclicked */
                              E110U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changepage */
                              E120U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Gridpaginationbar.Changerowsperpage */
                              E130U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_agexport.Onoptionclicked */
                              E140U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_grid.Onoptionclicked */
                              E150U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Ddo_gridcolumnsselector.Oncolumnschanged */
                              E160U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DESENCRIPTAR_MODAL.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Desencriptar_modal.Close */
                              E170U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DESENCRIPTAR_MODAL.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Desencriptar_modal.Onloadcomponent */
                              E180U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E190U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E200U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E210U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E220U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E230U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E240U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E250U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E260U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E270U2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_118_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
                              SubsflControlProps_1182( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV99GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV99GridActions), 4, 0));
                              AV15UAAssociateRoles = cgiGet( edtavUaassociateroles_Internalname);
                              AssignProp("", false, edtavUaassociateroles_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV15UAAssociateRoles)) ? AV134Uaassociateroles_GXI : context.convertURL( context.PathToRelativeUrl( AV15UAAssociateRoles))), !bGXsfl_118_Refreshing);
                              AssignProp("", false, edtavUaassociateroles_Internalname, "SrcSet", context.GetImageSrcSet( AV15UAAssociateRoles), true);
                              A18SecUserId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A26SecUserName = cgiGet( edtSecUserName_Internalname);
                              A587SecUserFullName = cgiGet( edtSecUserFullName_Internalname);
                              A145usuariosId = cgiGet( edtusuariosId_Internalname);
                              n145usuariosId = false;
                              A222usuariosNombre = cgiGet( edtusuariosNombre_Internalname);
                              cmbusuariosEstado.Name = cmbusuariosEstado_Internalname;
                              cmbusuariosEstado.CurrentValue = cgiGet( cmbusuariosEstado_Internalname);
                              A226usuariosEstado = cgiGet( cmbusuariosEstado_Internalname);
                              A266usuariosImagen = cgiGet( edtusuariosImagen_Internalname);
                              AssignProp("", false, edtusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), !bGXsfl_118_Refreshing);
                              AssignProp("", false, edtusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
                              cmbSecUserEstado.Name = cmbSecUserEstado_Internalname;
                              cmbSecUserEstado.CurrentValue = cgiGet( cmbSecUserEstado_Internalname);
                              A550SecUserEstado = cgiGet( cmbSecUserEstado_Internalname);
                              n550SecUserEstado = false;
                              A27SecUserPassword = cgiGet( edtSecUserPassword_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E280U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E290U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E300U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E310U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV23OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ordereddsc Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV24OrderedDsc )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV25DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV26DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME1"), AV27SecUserName1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuariosid1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIOSID1"), AV86usuariosId1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV29DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV30DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME2"), AV31SecUserName2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuariosid2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIOSID2"), AV87usuariosId2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV33DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV34DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Secusername3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME3"), AV35SecUserName3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Usuariosid3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIOSID3"), AV88usuariosId3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 148 )
                        {
                           OldWwpaux_wc = cgiGet( "W0148");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0148", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0U2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0U2( )
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_1182( ) ;
         while ( nGXsfl_118_idx <= nRC_GXsfl_118 )
         {
            sendrow_1182( ) ;
            nGXsfl_118_idx = ((subGrid_Islastpage==1)&&(nGXsfl_118_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_118_idx+1);
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1182( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV23OrderedBy ,
                                       bool AV24OrderedDsc ,
                                       string AV25DynamicFiltersSelector1 ,
                                       short AV26DynamicFiltersOperator1 ,
                                       string AV27SecUserName1 ,
                                       string AV86usuariosId1 ,
                                       string AV29DynamicFiltersSelector2 ,
                                       short AV30DynamicFiltersOperator2 ,
                                       string AV31SecUserName2 ,
                                       string AV87usuariosId2 ,
                                       string AV33DynamicFiltersSelector3 ,
                                       short AV34DynamicFiltersOperator3 ,
                                       string AV35SecUserName3 ,
                                       string AV88usuariosId3 ,
                                       short AV40ManageFiltersExecutionStep ,
                                       bool AV28DynamicFiltersEnabled2 ,
                                       bool AV32DynamicFiltersEnabled3 ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV70ColumnsSelector ,
                                       string AV104Pgmname ,
                                       string AV83FilterFullText ,
                                       long AV47TFSecUserId ,
                                       long AV48TFSecUserId_To ,
                                       string AV51TFSecUserName ,
                                       string AV52TFSecUserName_Sel ,
                                       string AV89TFSecUserFullName ,
                                       string AV90TFSecUserFullName_Sel ,
                                       string AV91TFusuariosId ,
                                       string AV92TFusuariosId_Sel ,
                                       string AV93TFusuariosNombre ,
                                       string AV94TFusuariosNombre_Sel ,
                                       GxSimpleCollection<string> AV96TFusuariosEstado_Sels ,
                                       GxSimpleCollection<string> AV98TFSecUserEstado_Sels ,
                                       string AV101TFSecUserPassword ,
                                       string AV102TFSecUserPassword_Sel ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV20GridState ,
                                       bool AV37DynamicFiltersIgnoreFirst ,
                                       bool AV36DynamicFiltersRemoving ,
                                       bool AV17IsAuthorized_Update ,
                                       bool AV18IsAuthorized_Delete ,
                                       bool AV103IsAuthorized_Desencriptar ,
                                       bool AV16IsAuthorized_UAAssociateRoles ,
                                       bool AV100IsAuthorized_usuariosId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0U2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SECUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18SecUserId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_SECUSERPASSWORD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A27SecUserPassword, "")), context));
         GxWebStd.gx_hidden_field( context, "SECUSERPASSWORD", A27SecUserPassword);
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
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV25DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV25DynamicFiltersSelector1);
            AssignAttri("", false, "AV25DynamicFiltersSelector1", AV25DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV29DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV29DynamicFiltersSelector2);
            AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV30DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV33DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV33DynamicFiltersSelector3);
            AssignAttri("", false, "AV33DynamicFiltersSelector3", AV33DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV34DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0U2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV104Pgmname = "WWPBaseObjects.SecUserWW";
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV105Wwpbaseobjects_secuserwwds_1_filterfulltext = AV83FilterFullText;
         AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV25DynamicFiltersSelector1;
         AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV26DynamicFiltersOperator1;
         AV108Wwpbaseobjects_secuserwwds_4_secusername1 = AV27SecUserName1;
         AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV86usuariosId1;
         AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV113Wwpbaseobjects_secuserwwds_9_secusername2 = AV31SecUserName2;
         AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV87usuariosId2;
         AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV32DynamicFiltersEnabled3;
         AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV33DynamicFiltersSelector3;
         AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV34DynamicFiltersOperator3;
         AV118Wwpbaseobjects_secuserwwds_14_secusername3 = AV35SecUserName3;
         AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV88usuariosId3;
         AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV47TFSecUserId;
         AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV48TFSecUserId_To;
         AV122Wwpbaseobjects_secuserwwds_18_tfsecusername = AV51TFSecUserName;
         AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV52TFSecUserName_Sel;
         AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV89TFSecUserFullName;
         AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV90TFSecUserFullName_Sel;
         AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV91TFusuariosId;
         AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV92TFusuariosId_Sel;
         AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV93TFusuariosNombre;
         AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV94TFusuariosNombre_Sel;
         AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV96TFusuariosEstado_Sels;
         AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV98TFSecUserEstado_Sels;
         AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV101TFSecUserPassword;
         AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV102TFSecUserPassword_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A226usuariosEstado ,
                                              AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                              A550SecUserEstado ,
                                              AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                              AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                              AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                              AV108Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                              AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                              AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                              AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                              AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                              AV113Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                              AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                              AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                              AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                              AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                              AV118Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                              AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                              AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                              AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                              AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                              AV122Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                              AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                              AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                              AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                              AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                              AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                              AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                              AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels.Count ,
                                              AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels.Count ,
                                              AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                              AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                              A26SecUserName ,
                                              A145usuariosId ,
                                              A18SecUserId ,
                                              A587SecUserFullName ,
                                              A222usuariosNombre ,
                                              A27SecUserPassword ,
                                              AV23OrderedBy ,
                                              AV24OrderedDsc ,
                                              AV105Wwpbaseobjects_secuserwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV108Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV108Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV108Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV108Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV109Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV109Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV113Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV113Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV113Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV113Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV114Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV114Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV118Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV118Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV118Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV118Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV119Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV119Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV122Wwpbaseobjects_secuserwwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV122Wwpbaseobjects_secuserwwds_18_tfsecusername), "%", "");
         lV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname), "%", "");
         lV126Wwpbaseobjects_secuserwwds_22_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid), 20, "%");
         lV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre), 80, "%");
         lV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = StringUtil.Concat( StringUtil.RTrim( AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword), "%", "");
         /* Using cursor H000U2 */
         pr_default.execute(0, new Object[] {lV108Wwpbaseobjects_secuserwwds_4_secusername1, lV108Wwpbaseobjects_secuserwwds_4_secusername1, lV109Wwpbaseobjects_secuserwwds_5_usuariosid1, lV109Wwpbaseobjects_secuserwwds_5_usuariosid1, lV113Wwpbaseobjects_secuserwwds_9_secusername2, lV113Wwpbaseobjects_secuserwwds_9_secusername2, lV114Wwpbaseobjects_secuserwwds_10_usuariosid2, lV114Wwpbaseobjects_secuserwwds_10_usuariosid2, lV118Wwpbaseobjects_secuserwwds_14_secusername3, lV118Wwpbaseobjects_secuserwwds_14_secusername3, lV119Wwpbaseobjects_secuserwwds_15_usuariosid3, lV119Wwpbaseobjects_secuserwwds_15_usuariosid3, AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid, AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to, lV122Wwpbaseobjects_secuserwwds_18_tfsecusername, AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, lV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname, AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, lV126Wwpbaseobjects_secuserwwds_22_tfusuariosid, AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, lV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre, AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, lV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword, AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A27SecUserPassword = H000U2_A27SecUserPassword[0];
            A550SecUserEstado = H000U2_A550SecUserEstado[0];
            n550SecUserEstado = H000U2_n550SecUserEstado[0];
            A40000usuariosImagen_GXI = H000U2_A40000usuariosImagen_GXI[0];
            AssignProp("", false, edtusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), !bGXsfl_118_Refreshing);
            AssignProp("", false, edtusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            A226usuariosEstado = H000U2_A226usuariosEstado[0];
            A222usuariosNombre = H000U2_A222usuariosNombre[0];
            A145usuariosId = H000U2_A145usuariosId[0];
            n145usuariosId = H000U2_n145usuariosId[0];
            A587SecUserFullName = H000U2_A587SecUserFullName[0];
            A26SecUserName = H000U2_A26SecUserName[0];
            A18SecUserId = H000U2_A18SecUserId[0];
            A266usuariosImagen = H000U2_A266usuariosImagen[0];
            AssignProp("", false, edtusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), !bGXsfl_118_Refreshing);
            AssignProp("", false, edtusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            A40000usuariosImagen_GXI = H000U2_A40000usuariosImagen_GXI[0];
            AssignProp("", false, edtusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), !bGXsfl_118_Refreshing);
            AssignProp("", false, edtusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            A226usuariosEstado = H000U2_A226usuariosEstado[0];
            A222usuariosNombre = H000U2_A222usuariosNombre[0];
            A266usuariosImagen = H000U2_A266usuariosImagen[0];
            AssignProp("", false, edtusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), !bGXsfl_118_Refreshing);
            AssignProp("", false, edtusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A18SecUserId), 10, 0) , StringUtil.PadR( "%" + AV105Wwpbaseobjects_secuserwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A26SecUserName) , StringUtil.PadR( "%" + StringUtil.Upper( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A587SecUserFullName) , StringUtil.PadR( "%" + StringUtil.Upper( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A27SecUserPassword) , StringUtil.PadR( "%" + StringUtil.Upper( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF0U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 118;
         /* Execute user event: Refresh */
         E290U2 ();
         nGXsfl_118_idx = 1;
         sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
         SubsflControlProps_1182( ) ;
         bGXsfl_118_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1182( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 A226usuariosEstado ,
                                                 AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                                 A550SecUserEstado ,
                                                 AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                                 AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                                 AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                                 AV108Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                                 AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                                 AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                                 AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                                 AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                                 AV113Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                                 AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                                 AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                                 AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                                 AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                                 AV118Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                                 AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                                 AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                                 AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                                 AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                                 AV122Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                                 AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                                 AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                                 AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                                 AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                                 AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                                 AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                                 AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels.Count ,
                                                 AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels.Count ,
                                                 AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                                 AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                                 A26SecUserName ,
                                                 A145usuariosId ,
                                                 A18SecUserId ,
                                                 A587SecUserFullName ,
                                                 A222usuariosNombre ,
                                                 A27SecUserPassword ,
                                                 AV23OrderedBy ,
                                                 AV24OrderedDsc ,
                                                 AV105Wwpbaseobjects_secuserwwds_1_filterfulltext } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV108Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV108Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
            lV108Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV108Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
            lV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV109Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
            lV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV109Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
            lV113Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV113Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
            lV113Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV113Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
            lV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV114Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
            lV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV114Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
            lV118Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV118Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
            lV118Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV118Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
            lV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV119Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
            lV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV119Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
            lV122Wwpbaseobjects_secuserwwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV122Wwpbaseobjects_secuserwwds_18_tfsecusername), "%", "");
            lV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname), "%", "");
            lV126Wwpbaseobjects_secuserwwds_22_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid), 20, "%");
            lV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre), 80, "%");
            lV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = StringUtil.Concat( StringUtil.RTrim( AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword), "%", "");
            /* Using cursor H000U3 */
            pr_default.execute(1, new Object[] {lV108Wwpbaseobjects_secuserwwds_4_secusername1, lV108Wwpbaseobjects_secuserwwds_4_secusername1, lV109Wwpbaseobjects_secuserwwds_5_usuariosid1, lV109Wwpbaseobjects_secuserwwds_5_usuariosid1, lV113Wwpbaseobjects_secuserwwds_9_secusername2, lV113Wwpbaseobjects_secuserwwds_9_secusername2, lV114Wwpbaseobjects_secuserwwds_10_usuariosid2, lV114Wwpbaseobjects_secuserwwds_10_usuariosid2, lV118Wwpbaseobjects_secuserwwds_14_secusername3, lV118Wwpbaseobjects_secuserwwds_14_secusername3, lV119Wwpbaseobjects_secuserwwds_15_usuariosid3, lV119Wwpbaseobjects_secuserwwds_15_usuariosid3, AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid, AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to, lV122Wwpbaseobjects_secuserwwds_18_tfsecusername, AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, lV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname, AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, lV126Wwpbaseobjects_secuserwwds_22_tfusuariosid, AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, lV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre, AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, lV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword, AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel});
            nGXsfl_118_idx = 1;
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1182( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A27SecUserPassword = H000U3_A27SecUserPassword[0];
               A550SecUserEstado = H000U3_A550SecUserEstado[0];
               n550SecUserEstado = H000U3_n550SecUserEstado[0];
               A40000usuariosImagen_GXI = H000U3_A40000usuariosImagen_GXI[0];
               AssignProp("", false, edtusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), !bGXsfl_118_Refreshing);
               AssignProp("", false, edtusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
               A226usuariosEstado = H000U3_A226usuariosEstado[0];
               A222usuariosNombre = H000U3_A222usuariosNombre[0];
               A145usuariosId = H000U3_A145usuariosId[0];
               n145usuariosId = H000U3_n145usuariosId[0];
               A587SecUserFullName = H000U3_A587SecUserFullName[0];
               A26SecUserName = H000U3_A26SecUserName[0];
               A18SecUserId = H000U3_A18SecUserId[0];
               A266usuariosImagen = H000U3_A266usuariosImagen[0];
               AssignProp("", false, edtusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), !bGXsfl_118_Refreshing);
               AssignProp("", false, edtusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
               A40000usuariosImagen_GXI = H000U3_A40000usuariosImagen_GXI[0];
               AssignProp("", false, edtusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), !bGXsfl_118_Refreshing);
               AssignProp("", false, edtusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
               A226usuariosEstado = H000U3_A226usuariosEstado[0];
               A222usuariosNombre = H000U3_A222usuariosNombre[0];
               A266usuariosImagen = H000U3_A266usuariosImagen[0];
               AssignProp("", false, edtusuariosImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.convertURL( context.PathToRelativeUrl( A266usuariosImagen))), !bGXsfl_118_Refreshing);
               AssignProp("", false, edtusuariosImagen_Internalname, "SrcSet", context.GetImageSrcSet( A266usuariosImagen), true);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A18SecUserId), 10, 0) , StringUtil.PadR( "%" + AV105Wwpbaseobjects_secuserwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A26SecUserName) , StringUtil.PadR( "%" + StringUtil.Upper( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A587SecUserFullName) , StringUtil.PadR( "%" + StringUtil.Upper( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
               ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "HAB") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 ) ) ||
               ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A27SecUserPassword) , StringUtil.PadR( "%" + StringUtil.Upper( AV105Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
               )
               {
                  /* Execute user event: Grid.Load */
                  E300U2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 118;
            WB0U0( ) ;
         }
         bGXsfl_118_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0U2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV104Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV104Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV17IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV17IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV18IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV18IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DESENCRIPTAR", AV103IsAuthorized_Desencriptar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DESENCRIPTAR", GetSecureSignedToken( "", AV103IsAuthorized_Desencriptar, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UAASSOCIATEROLES", AV16IsAuthorized_UAAssociateRoles);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UAASSOCIATEROLES", GetSecureSignedToken( "", AV16IsAuthorized_UAAssociateRoles, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_USUARIOSID", AV100IsAuthorized_usuariosId);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USUARIOSID", GetSecureSignedToken( "", AV100IsAuthorized_usuariosId, context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECUSERID"+"_"+sGXsfl_118_idx, GetSecureSignedToken( sGXsfl_118_idx, context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_SECUSERPASSWORD"+"_"+sGXsfl_118_idx, GetSecureSignedToken( sGXsfl_118_idx, StringUtil.RTrim( context.localUtil.Format( A27SecUserPassword, "")), context));
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
         return (int)(subGridclient_rec_count_fnc()) ;
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
         AV105Wwpbaseobjects_secuserwwds_1_filterfulltext = AV83FilterFullText;
         AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV25DynamicFiltersSelector1;
         AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV26DynamicFiltersOperator1;
         AV108Wwpbaseobjects_secuserwwds_4_secusername1 = AV27SecUserName1;
         AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV86usuariosId1;
         AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV113Wwpbaseobjects_secuserwwds_9_secusername2 = AV31SecUserName2;
         AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV87usuariosId2;
         AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV32DynamicFiltersEnabled3;
         AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV33DynamicFiltersSelector3;
         AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV34DynamicFiltersOperator3;
         AV118Wwpbaseobjects_secuserwwds_14_secusername3 = AV35SecUserName3;
         AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV88usuariosId3;
         AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV47TFSecUserId;
         AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV48TFSecUserId_To;
         AV122Wwpbaseobjects_secuserwwds_18_tfsecusername = AV51TFSecUserName;
         AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV52TFSecUserName_Sel;
         AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV89TFSecUserFullName;
         AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV90TFSecUserFullName_Sel;
         AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV91TFusuariosId;
         AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV92TFusuariosId_Sel;
         AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV93TFusuariosNombre;
         AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV94TFusuariosNombre_Sel;
         AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV96TFusuariosEstado_Sels;
         AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV98TFSecUserEstado_Sels;
         AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV101TFSecUserPassword;
         AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV102TFSecUserPassword_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV86usuariosId1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV87usuariosId2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV88usuariosId3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV70ColumnsSelector, AV104Pgmname, AV83FilterFullText, AV47TFSecUserId, AV48TFSecUserId_To, AV51TFSecUserName, AV52TFSecUserName_Sel, AV89TFSecUserFullName, AV90TFSecUserFullName_Sel, AV91TFusuariosId, AV92TFusuariosId_Sel, AV93TFusuariosNombre, AV94TFusuariosNombre_Sel, AV96TFusuariosEstado_Sels, AV98TFSecUserEstado_Sels, AV101TFSecUserPassword, AV102TFSecUserPassword_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV17IsAuthorized_Update, AV18IsAuthorized_Delete, AV103IsAuthorized_Desencriptar, AV16IsAuthorized_UAAssociateRoles, AV100IsAuthorized_usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV105Wwpbaseobjects_secuserwwds_1_filterfulltext = AV83FilterFullText;
         AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV25DynamicFiltersSelector1;
         AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV26DynamicFiltersOperator1;
         AV108Wwpbaseobjects_secuserwwds_4_secusername1 = AV27SecUserName1;
         AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV86usuariosId1;
         AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV113Wwpbaseobjects_secuserwwds_9_secusername2 = AV31SecUserName2;
         AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV87usuariosId2;
         AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV32DynamicFiltersEnabled3;
         AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV33DynamicFiltersSelector3;
         AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV34DynamicFiltersOperator3;
         AV118Wwpbaseobjects_secuserwwds_14_secusername3 = AV35SecUserName3;
         AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV88usuariosId3;
         AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV47TFSecUserId;
         AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV48TFSecUserId_To;
         AV122Wwpbaseobjects_secuserwwds_18_tfsecusername = AV51TFSecUserName;
         AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV52TFSecUserName_Sel;
         AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV89TFSecUserFullName;
         AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV90TFSecUserFullName_Sel;
         AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV91TFusuariosId;
         AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV92TFusuariosId_Sel;
         AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV93TFusuariosNombre;
         AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV94TFusuariosNombre_Sel;
         AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV96TFusuariosEstado_Sels;
         AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV98TFSecUserEstado_Sels;
         AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV101TFSecUserPassword;
         AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV102TFSecUserPassword_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV86usuariosId1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV87usuariosId2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV88usuariosId3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV70ColumnsSelector, AV104Pgmname, AV83FilterFullText, AV47TFSecUserId, AV48TFSecUserId_To, AV51TFSecUserName, AV52TFSecUserName_Sel, AV89TFSecUserFullName, AV90TFSecUserFullName_Sel, AV91TFusuariosId, AV92TFusuariosId_Sel, AV93TFusuariosNombre, AV94TFusuariosNombre_Sel, AV96TFusuariosEstado_Sels, AV98TFSecUserEstado_Sels, AV101TFSecUserPassword, AV102TFSecUserPassword_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV17IsAuthorized_Update, AV18IsAuthorized_Delete, AV103IsAuthorized_Desencriptar, AV16IsAuthorized_UAAssociateRoles, AV100IsAuthorized_usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV105Wwpbaseobjects_secuserwwds_1_filterfulltext = AV83FilterFullText;
         AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV25DynamicFiltersSelector1;
         AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV26DynamicFiltersOperator1;
         AV108Wwpbaseobjects_secuserwwds_4_secusername1 = AV27SecUserName1;
         AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV86usuariosId1;
         AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV113Wwpbaseobjects_secuserwwds_9_secusername2 = AV31SecUserName2;
         AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV87usuariosId2;
         AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV32DynamicFiltersEnabled3;
         AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV33DynamicFiltersSelector3;
         AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV34DynamicFiltersOperator3;
         AV118Wwpbaseobjects_secuserwwds_14_secusername3 = AV35SecUserName3;
         AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV88usuariosId3;
         AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV47TFSecUserId;
         AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV48TFSecUserId_To;
         AV122Wwpbaseobjects_secuserwwds_18_tfsecusername = AV51TFSecUserName;
         AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV52TFSecUserName_Sel;
         AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV89TFSecUserFullName;
         AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV90TFSecUserFullName_Sel;
         AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV91TFusuariosId;
         AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV92TFusuariosId_Sel;
         AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV93TFusuariosNombre;
         AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV94TFusuariosNombre_Sel;
         AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV96TFusuariosEstado_Sels;
         AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV98TFSecUserEstado_Sels;
         AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV101TFSecUserPassword;
         AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV102TFSecUserPassword_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV86usuariosId1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV87usuariosId2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV88usuariosId3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV70ColumnsSelector, AV104Pgmname, AV83FilterFullText, AV47TFSecUserId, AV48TFSecUserId_To, AV51TFSecUserName, AV52TFSecUserName_Sel, AV89TFSecUserFullName, AV90TFSecUserFullName_Sel, AV91TFusuariosId, AV92TFusuariosId_Sel, AV93TFusuariosNombre, AV94TFusuariosNombre_Sel, AV96TFusuariosEstado_Sels, AV98TFSecUserEstado_Sels, AV101TFSecUserPassword, AV102TFSecUserPassword_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV17IsAuthorized_Update, AV18IsAuthorized_Delete, AV103IsAuthorized_Desencriptar, AV16IsAuthorized_UAAssociateRoles, AV100IsAuthorized_usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV105Wwpbaseobjects_secuserwwds_1_filterfulltext = AV83FilterFullText;
         AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV25DynamicFiltersSelector1;
         AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV26DynamicFiltersOperator1;
         AV108Wwpbaseobjects_secuserwwds_4_secusername1 = AV27SecUserName1;
         AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV86usuariosId1;
         AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV113Wwpbaseobjects_secuserwwds_9_secusername2 = AV31SecUserName2;
         AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV87usuariosId2;
         AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV32DynamicFiltersEnabled3;
         AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV33DynamicFiltersSelector3;
         AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV34DynamicFiltersOperator3;
         AV118Wwpbaseobjects_secuserwwds_14_secusername3 = AV35SecUserName3;
         AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV88usuariosId3;
         AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV47TFSecUserId;
         AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV48TFSecUserId_To;
         AV122Wwpbaseobjects_secuserwwds_18_tfsecusername = AV51TFSecUserName;
         AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV52TFSecUserName_Sel;
         AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV89TFSecUserFullName;
         AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV90TFSecUserFullName_Sel;
         AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV91TFusuariosId;
         AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV92TFusuariosId_Sel;
         AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV93TFusuariosNombre;
         AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV94TFusuariosNombre_Sel;
         AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV96TFusuariosEstado_Sels;
         AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV98TFSecUserEstado_Sels;
         AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV101TFSecUserPassword;
         AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV102TFSecUserPassword_Sel;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV86usuariosId1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV87usuariosId2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV88usuariosId3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV70ColumnsSelector, AV104Pgmname, AV83FilterFullText, AV47TFSecUserId, AV48TFSecUserId_To, AV51TFSecUserName, AV52TFSecUserName_Sel, AV89TFSecUserFullName, AV90TFSecUserFullName_Sel, AV91TFusuariosId, AV92TFusuariosId_Sel, AV93TFusuariosNombre, AV94TFusuariosNombre_Sel, AV96TFusuariosEstado_Sels, AV98TFSecUserEstado_Sels, AV101TFSecUserPassword, AV102TFSecUserPassword_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV17IsAuthorized_Update, AV18IsAuthorized_Delete, AV103IsAuthorized_Desencriptar, AV16IsAuthorized_UAAssociateRoles, AV100IsAuthorized_usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV105Wwpbaseobjects_secuserwwds_1_filterfulltext = AV83FilterFullText;
         AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV25DynamicFiltersSelector1;
         AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV26DynamicFiltersOperator1;
         AV108Wwpbaseobjects_secuserwwds_4_secusername1 = AV27SecUserName1;
         AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV86usuariosId1;
         AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV113Wwpbaseobjects_secuserwwds_9_secusername2 = AV31SecUserName2;
         AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV87usuariosId2;
         AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV32DynamicFiltersEnabled3;
         AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV33DynamicFiltersSelector3;
         AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV34DynamicFiltersOperator3;
         AV118Wwpbaseobjects_secuserwwds_14_secusername3 = AV35SecUserName3;
         AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV88usuariosId3;
         AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV47TFSecUserId;
         AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV48TFSecUserId_To;
         AV122Wwpbaseobjects_secuserwwds_18_tfsecusername = AV51TFSecUserName;
         AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV52TFSecUserName_Sel;
         AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV89TFSecUserFullName;
         AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV90TFSecUserFullName_Sel;
         AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV91TFusuariosId;
         AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV92TFusuariosId_Sel;
         AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV93TFusuariosNombre;
         AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV94TFusuariosNombre_Sel;
         AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV96TFusuariosEstado_Sels;
         AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV98TFSecUserEstado_Sels;
         AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV101TFSecUserPassword;
         AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV102TFSecUserPassword_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV86usuariosId1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV87usuariosId2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV88usuariosId3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV70ColumnsSelector, AV104Pgmname, AV83FilterFullText, AV47TFSecUserId, AV48TFSecUserId_To, AV51TFSecUserName, AV52TFSecUserName_Sel, AV89TFSecUserFullName, AV90TFSecUserFullName_Sel, AV91TFusuariosId, AV92TFusuariosId_Sel, AV93TFusuariosNombre, AV94TFusuariosNombre_Sel, AV96TFusuariosEstado_Sels, AV98TFSecUserEstado_Sels, AV101TFSecUserPassword, AV102TFSecUserPassword_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV17IsAuthorized_Update, AV18IsAuthorized_Delete, AV103IsAuthorized_Desencriptar, AV16IsAuthorized_UAAssociateRoles, AV100IsAuthorized_usuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV104Pgmname = "WWPBaseObjects.SecUserWW";
         edtSecUserId_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtSecUserFullName_Enabled = 0;
         edtusuariosId_Enabled = 0;
         edtusuariosNombre_Enabled = 0;
         cmbusuariosEstado.Enabled = 0;
         edtusuariosImagen_Enabled = 0;
         cmbSecUserEstado.Enabled = 0;
         edtSecUserPassword_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E280U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV44ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV84AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV54DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV70ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_118 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_118"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV79GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV80GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV82GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Desencriptar_modal_Width = cgiGet( "DESENCRIPTAR_MODAL_Width");
            Desencriptar_modal_Title = cgiGet( "DESENCRIPTAR_MODAL_Title");
            Desencriptar_modal_Confirmtype = cgiGet( "DESENCRIPTAR_MODAL_Confirmtype");
            Desencriptar_modal_Bodytype = cgiGet( "DESENCRIPTAR_MODAL_Bodytype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV83FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV83FilterFullText", AV83FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV25DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV25DynamicFiltersSelector1", AV25DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV26DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
            AV27SecUserName1 = cgiGet( edtavSecusername1_Internalname);
            AssignAttri("", false, "AV27SecUserName1", AV27SecUserName1);
            AV86usuariosId1 = cgiGet( edtavUsuariosid1_Internalname);
            AssignAttri("", false, "AV86usuariosId1", AV86usuariosId1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV29DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV30DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
            AV31SecUserName2 = cgiGet( edtavSecusername2_Internalname);
            AssignAttri("", false, "AV31SecUserName2", AV31SecUserName2);
            AV87usuariosId2 = cgiGet( edtavUsuariosid2_Internalname);
            AssignAttri("", false, "AV87usuariosId2", AV87usuariosId2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV33DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV33DynamicFiltersSelector3", AV33DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV34DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
            AV35SecUserName3 = cgiGet( edtavSecusername3_Internalname);
            AssignAttri("", false, "AV35SecUserName3", AV35SecUserName3);
            AV88usuariosId3 = cgiGet( edtavUsuariosid3_Internalname);
            AssignAttri("", false, "AV88usuariosId3", AV88usuariosId3);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV23OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vORDEREDDSC")) != AV24OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV25DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV26DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME1"), AV27SecUserName1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIOSID1"), AV86usuariosId1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV29DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV30DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME2"), AV31SecUserName2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIOSID2"), AV87usuariosId2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV33DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV34DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vSECUSERNAME3"), AV35SecUserName3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSUARIOSID3"), AV88usuariosId3) != 0 )
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
         E280U2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E280U2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV25DynamicFiltersSelector1 = "SECUSERNAME";
         AssignAttri("", false, "AV25DynamicFiltersSelector1", AV25DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV29DynamicFiltersSelector2 = "SECUSERNAME";
         AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV33DynamicFiltersSelector3 = "SECUSERNAME";
         AssignAttri("", false, "AV33DynamicFiltersSelector3", AV33DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV84AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV85AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV85AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportCaption", "");
         AV85AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV85AGExportDataItem.gxTpr_Eventkey = "Export";
         AV85AGExportDataItem.gxTpr_Isdivider = false;
         AV84AGExportData.Add(AV85AGExportDataItem, 0);
         AV85AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV85AGExportDataItem.gxTpr_Title = context.GetMessage( "WWP_ExportReportCaption", "");
         AV85AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV85AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV85AGExportDataItem.gxTpr_Isdivider = false;
         AV84AGExportData.Add(AV85AGExportDataItem, 0);
         GXt_boolean1 = AV100IsAuthorized_usuariosId;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWusuarios", out  GXt_boolean1) ;
         AV100IsAuthorized_usuariosId = GXt_boolean1;
         AssignAttri("", false, "AV100IsAuthorized_usuariosId", AV100IsAuthorized_usuariosId);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_USUARIOSID", GetSecureSignedToken( "", AV100IsAuthorized_usuariosId, context));
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = context.GetMessage( " User", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV23OrderedBy < 1 )
         {
            AV23OrderedBy = 1;
            AssignAttri("", false, "AV23OrderedBy", StringUtil.LTrimStr( (decimal)(AV23OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV54DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV54DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         edtavUaassociateroles_Title = context.GetMessage( "Roles", "");
         AssignProp("", false, edtavUaassociateroles_Internalname, "Title", edtavUaassociateroles_Title, !bGXsfl_118_Refreshing);
      }

      protected void E290U2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV77WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV40ManageFiltersExecutionStep == 1 )
         {
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV40ManageFiltersExecutionStep == 2 )
         {
            AV40ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERNAME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "USUARIOSID") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
            cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         }
         if ( AV28DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERNAME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "USUARIOSID") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
               cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
            }
            if ( AV32DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERNAME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
                  cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
               }
               else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "USUARIOSID") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
                  cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
               }
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV14Session.Get("WWPBaseObjects.SecUserWWColumnsSelector"), "") != 0 )
         {
            AV58ColumnsSelectorXML = AV14Session.Get("WWPBaseObjects.SecUserWWColumnsSelector");
            AV70ColumnsSelector.FromXml(AV58ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtSecUserId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSecUserId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserId_Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtSecUserName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSecUserName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserName_Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtSecUserFullName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSecUserFullName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserFullName_Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtusuariosId_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtusuariosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtusuariosId_Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtusuariosNombre_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtusuariosNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtusuariosNombre_Visible), 5, 0), !bGXsfl_118_Refreshing);
         cmbusuariosEstado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbusuariosEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbusuariosEstado.Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtusuariosImagen_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtusuariosImagen_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtusuariosImagen_Visible), 5, 0), !bGXsfl_118_Refreshing);
         cmbSecUserEstado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbSecUserEstado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbSecUserEstado.Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtSecUserPassword_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV70ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtSecUserPassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSecUserPassword_Visible), 5, 0), !bGXsfl_118_Refreshing);
         AV79GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV79GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV79GridCurrentPage), 10, 0));
         AV80GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV80GridPageCount", StringUtil.LTrimStr( (decimal)(AV80GridPageCount), 10, 0));
         GXt_char3 = AV82GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV104Pgmname, out  GXt_char3) ;
         AV82GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV82GridAppliedFilters", AV82GridAppliedFilters);
         cmbavGridactions_Columnheaderclass = "WWActionGroupColumn";
         AssignProp("", false, cmbavGridactions_Internalname, "Columnheaderclass", cmbavGridactions_Columnheaderclass, !bGXsfl_118_Refreshing);
         edtavUaassociateroles_Columnheaderclass = "WWActionColumn";
         AssignProp("", false, edtavUaassociateroles_Internalname, "Columnheaderclass", edtavUaassociateroles_Columnheaderclass, !bGXsfl_118_Refreshing);
         edtSecUserId_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, edtSecUserId_Internalname, "Columnheaderclass", edtSecUserId_Columnheaderclass, !bGXsfl_118_Refreshing);
         edtSecUserName_Columnheaderclass = "WWColumn";
         AssignProp("", false, edtSecUserName_Internalname, "Columnheaderclass", edtSecUserName_Columnheaderclass, !bGXsfl_118_Refreshing);
         edtSecUserFullName_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, edtSecUserFullName_Internalname, "Columnheaderclass", edtSecUserFullName_Columnheaderclass, !bGXsfl_118_Refreshing);
         edtusuariosId_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, edtusuariosId_Internalname, "Columnheaderclass", edtusuariosId_Columnheaderclass, !bGXsfl_118_Refreshing);
         edtusuariosNombre_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, edtusuariosNombre_Internalname, "Columnheaderclass", edtusuariosNombre_Columnheaderclass, !bGXsfl_118_Refreshing);
         cmbusuariosEstado_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, cmbusuariosEstado_Internalname, "Columnheaderclass", cmbusuariosEstado_Columnheaderclass, !bGXsfl_118_Refreshing);
         edtusuariosImagen_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, edtusuariosImagen_Internalname, "Columnheaderclass", edtusuariosImagen_Columnheaderclass, !bGXsfl_118_Refreshing);
         cmbSecUserEstado_Columnheaderclass = "WWColumn hidden-xs";
         AssignProp("", false, cmbSecUserEstado_Internalname, "Columnheaderclass", cmbSecUserEstado_Columnheaderclass, !bGXsfl_118_Refreshing);
         edtSecUserPassword_Columnheaderclass = "WWColumn hidden-xs hidden-sm hidden-md hidden-lg";
         AssignProp("", false, edtSecUserPassword_Internalname, "Columnheaderclass", edtSecUserPassword_Columnheaderclass, !bGXsfl_118_Refreshing);
         AV105Wwpbaseobjects_secuserwwds_1_filterfulltext = AV83FilterFullText;
         AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV25DynamicFiltersSelector1;
         AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV26DynamicFiltersOperator1;
         AV108Wwpbaseobjects_secuserwwds_4_secusername1 = AV27SecUserName1;
         AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV86usuariosId1;
         AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV113Wwpbaseobjects_secuserwwds_9_secusername2 = AV31SecUserName2;
         AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV87usuariosId2;
         AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV32DynamicFiltersEnabled3;
         AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV33DynamicFiltersSelector3;
         AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV34DynamicFiltersOperator3;
         AV118Wwpbaseobjects_secuserwwds_14_secusername3 = AV35SecUserName3;
         AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV88usuariosId3;
         AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV47TFSecUserId;
         AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV48TFSecUserId_To;
         AV122Wwpbaseobjects_secuserwwds_18_tfsecusername = AV51TFSecUserName;
         AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV52TFSecUserName_Sel;
         AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV89TFSecUserFullName;
         AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV90TFSecUserFullName_Sel;
         AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV91TFusuariosId;
         AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV92TFusuariosId_Sel;
         AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV93TFusuariosNombre;
         AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV94TFusuariosNombre_Sel;
         AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV96TFusuariosEstado_Sels;
         AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV98TFSecUserEstado_Sels;
         AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV101TFSecUserPassword;
         AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV102TFSecUserPassword_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E120U2( )
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
            AV78PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV78PageToGo) ;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E130U2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E150U2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV23OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23OrderedBy", StringUtil.LTrimStr( (decimal)(AV23OrderedBy), 4, 0));
            AV24OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV24OrderedDsc", AV24OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserId") == 0 )
            {
               AV47TFSecUserId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFSecUserId", StringUtil.LTrimStr( (decimal)(AV47TFSecUserId), 10, 0));
               AV48TFSecUserId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFSecUserId_To", StringUtil.LTrimStr( (decimal)(AV48TFSecUserId_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserName") == 0 )
            {
               AV51TFSecUserName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV51TFSecUserName", AV51TFSecUserName);
               AV52TFSecUserName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV52TFSecUserName_Sel", AV52TFSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserFullName") == 0 )
            {
               AV89TFSecUserFullName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV89TFSecUserFullName", AV89TFSecUserFullName);
               AV90TFSecUserFullName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV90TFSecUserFullName_Sel", AV90TFSecUserFullName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "usuariosId") == 0 )
            {
               AV91TFusuariosId = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV91TFusuariosId", AV91TFusuariosId);
               AV92TFusuariosId_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV92TFusuariosId_Sel", AV92TFusuariosId_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "usuariosNombre") == 0 )
            {
               AV93TFusuariosNombre = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV93TFusuariosNombre", AV93TFusuariosNombre);
               AV94TFusuariosNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV94TFusuariosNombre_Sel", AV94TFusuariosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "usuariosEstado") == 0 )
            {
               AV95TFusuariosEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV95TFusuariosEstado_SelsJson", AV95TFusuariosEstado_SelsJson);
               AV96TFusuariosEstado_Sels.FromJSonString(AV95TFusuariosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserEstado") == 0 )
            {
               AV97TFSecUserEstado_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV97TFSecUserEstado_SelsJson", AV97TFSecUserEstado_SelsJson);
               AV98TFSecUserEstado_Sels.FromJSonString(AV97TFSecUserEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SecUserPassword") == 0 )
            {
               AV101TFSecUserPassword = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV101TFSecUserPassword", AV101TFSecUserPassword);
               AV102TFSecUserPassword_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV102TFSecUserPassword_Sel", AV102TFSecUserPassword_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV98TFSecUserEstado_Sels", AV98TFSecUserEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV96TFusuariosEstado_Sels", AV96TFusuariosEstado_Sels);
      }

      private void E300U2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            cmbavGridactions.removeAllItems();
            cmbavGridactions.addItem("0", ";fa fa-bars", 0);
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_display", ""), "fa fa-search", "", "", "", "", "", "", ""), 0);
            if ( AV17IsAuthorized_Update )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", context.GetMessage( "GXM_update", ""), "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
            if ( AV18IsAuthorized_Delete )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", context.GetMessage( "GX_BtnDelete", ""), "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
            if ( AV103IsAuthorized_Desencriptar )
            {
               cmbavGridactions.addItem("4", StringUtil.Format( "%1;%2", context.GetMessage( "Ver Pass", ""), "fas fa-unlock-keyhole", "", "", "", "", "", "", ""), 0);
            }
            edtavUaassociateroles_gximage = "Roles";
            AV15UAAssociateRoles = context.GetImagePath( "cc488df4-dfce-487a-a445-6fdd39fec85e", "", context.GetTheme( ));
            AssignAttri("", false, edtavUaassociateroles_Internalname, AV15UAAssociateRoles);
            AV134Uaassociateroles_GXI = GXDbFile.PathToUrl( context.GetImagePath( "cc488df4-dfce-487a-a445-6fdd39fec85e", "", context.GetTheme( )), context);
            edtavUaassociateroles_Tooltiptext = "";
            if ( AV16IsAuthorized_UAAssociateRoles )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.secusersecuserroleassociation.aspx"+UrlEncode(StringUtil.LTrimStr(A18SecUserId,10,0));
               edtavUaassociateroles_Link = formatLink("wwpbaseobjects.secusersecuserroleassociation.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.secuserview.aspx"+UrlEncode(StringUtil.LTrimStr(A18SecUserId,10,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtSecUserName_Link = formatLink("wwpbaseobjects.secuserview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            if ( AV100IsAuthorized_usuariosId )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "usuariosview.aspx"+UrlEncode(StringUtil.RTrim(A145usuariosId)) + "," + UrlEncode(StringUtil.RTrim(""));
               edtusuariosId_Link = formatLink("usuariosview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            if ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 )
            {
               cmbavGridactions_Columnclass = "WWActionGroupColumn WWColumnWarning WWColumnWarningFirstColumn";
               edtavUaassociateroles_Columnclass = "WWActionColumn WWColumnWarning";
               edtSecUserId_Columnclass = "WWColumn WWColumnWarning hidden-xs";
               edtSecUserName_Columnclass = "WWColumn WWColumnWarning";
               edtSecUserFullName_Columnclass = "WWColumn WWColumnWarning hidden-xs";
               edtusuariosId_Columnclass = "WWColumn WWColumnWarning hidden-xs";
               edtusuariosNombre_Columnclass = "WWColumn WWColumnWarning hidden-xs";
               cmbusuariosEstado_Columnclass = "WWColumn WWColumnWarning hidden-xs";
               edtusuariosImagen_Columnclass = "WWColumn WWColumnWarning hidden-xs";
               cmbSecUserEstado_Columnclass = "WWColumn WWColumnWarning hidden-xs";
               edtSecUserPassword_Columnclass = "WWColumn WWColumnWarning hidden-xs hidden-sm hidden-md hidden-lg";
            }
            else if ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 )
            {
               cmbavGridactions_Columnclass = "WWActionGroupColumn WWColumnDanger WWColumnDangerFirstColumn";
               edtavUaassociateroles_Columnclass = "WWActionColumn WWColumnDanger";
               edtSecUserId_Columnclass = "WWColumn WWColumnDanger hidden-xs";
               edtSecUserName_Columnclass = "WWColumn WWColumnDanger";
               edtSecUserFullName_Columnclass = "WWColumn WWColumnDanger hidden-xs";
               edtusuariosId_Columnclass = "WWColumn WWColumnDanger hidden-xs";
               edtusuariosNombre_Columnclass = "WWColumn WWColumnDanger hidden-xs";
               cmbusuariosEstado_Columnclass = "WWColumn WWColumnDanger hidden-xs";
               edtusuariosImagen_Columnclass = "WWColumn WWColumnDanger hidden-xs";
               cmbSecUserEstado_Columnclass = "WWColumn WWColumnDanger hidden-xs";
               edtSecUserPassword_Columnclass = "WWColumn WWColumnDanger hidden-xs hidden-sm hidden-md hidden-lg";
            }
            else
            {
               cmbavGridactions_Columnclass = "WWActionGroupColumn";
               edtavUaassociateroles_Columnclass = "WWActionColumn";
               edtSecUserId_Columnclass = "WWColumn hidden-xs";
               edtSecUserName_Columnclass = "WWColumn";
               edtSecUserFullName_Columnclass = "WWColumn hidden-xs";
               edtusuariosId_Columnclass = "WWColumn hidden-xs";
               edtusuariosNombre_Columnclass = "WWColumn hidden-xs";
               cmbusuariosEstado_Columnclass = "WWColumn hidden-xs";
               edtusuariosImagen_Columnclass = "WWColumn hidden-xs";
               cmbSecUserEstado_Columnclass = "WWColumn hidden-xs";
               edtSecUserPassword_Columnclass = "WWColumn hidden-xs hidden-sm hidden-md hidden-lg";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 118;
            }
            sendrow_1182( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_118_Refreshing )
         {
            context.DoAjaxLoad(118, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV99GridActions), 4, 0));
      }

      protected void E160U2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV58ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV70ColumnsSelector.FromJSonString(AV58ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "WWPBaseObjects.SecUserWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV58ColumnsSelectorXML)) ? "" : AV70ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E230U2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV28DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV86usuariosId1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV87usuariosId2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV88usuariosId3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV70ColumnsSelector, AV104Pgmname, AV83FilterFullText, AV47TFSecUserId, AV48TFSecUserId_To, AV51TFSecUserName, AV52TFSecUserName_Sel, AV89TFSecUserFullName, AV90TFSecUserFullName_Sel, AV91TFusuariosId, AV92TFusuariosId_Sel, AV93TFusuariosNombre, AV94TFusuariosNombre_Sel, AV96TFusuariosEstado_Sels, AV98TFSecUserEstado_Sels, AV101TFSecUserPassword, AV102TFSecUserPassword_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV17IsAuthorized_Update, AV18IsAuthorized_Delete, AV103IsAuthorized_Desencriptar, AV16IsAuthorized_UAAssociateRoles, AV100IsAuthorized_usuariosId) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E190U2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV36DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV37DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV37DynamicFiltersIgnoreFirst", AV37DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV36DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV37DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV37DynamicFiltersIgnoreFirst", AV37DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV86usuariosId1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV87usuariosId2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV88usuariosId3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV70ColumnsSelector, AV104Pgmname, AV83FilterFullText, AV47TFSecUserId, AV48TFSecUserId_To, AV51TFSecUserName, AV52TFSecUserName_Sel, AV89TFSecUserFullName, AV90TFSecUserFullName_Sel, AV91TFusuariosId, AV92TFusuariosId_Sel, AV93TFusuariosNombre, AV94TFusuariosNombre_Sel, AV96TFusuariosEstado_Sels, AV98TFSecUserEstado_Sels, AV101TFSecUserPassword, AV102TFSecUserPassword_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV17IsAuthorized_Update, AV18IsAuthorized_Delete, AV103IsAuthorized_Desencriptar, AV16IsAuthorized_UAAssociateRoles, AV100IsAuthorized_usuariosId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E240U2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV26DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E250U2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV32DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV32DynamicFiltersEnabled3", AV32DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV86usuariosId1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV87usuariosId2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV88usuariosId3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV70ColumnsSelector, AV104Pgmname, AV83FilterFullText, AV47TFSecUserId, AV48TFSecUserId_To, AV51TFSecUserName, AV52TFSecUserName_Sel, AV89TFSecUserFullName, AV90TFSecUserFullName_Sel, AV91TFusuariosId, AV92TFusuariosId_Sel, AV93TFusuariosNombre, AV94TFusuariosNombre_Sel, AV96TFusuariosEstado_Sels, AV98TFSecUserEstado_Sels, AV101TFSecUserPassword, AV102TFSecUserPassword_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV17IsAuthorized_Update, AV18IsAuthorized_Delete, AV103IsAuthorized_Desencriptar, AV16IsAuthorized_UAAssociateRoles, AV100IsAuthorized_usuariosId) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E200U2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV36DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV28DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV36DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV86usuariosId1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV87usuariosId2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV88usuariosId3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV70ColumnsSelector, AV104Pgmname, AV83FilterFullText, AV47TFSecUserId, AV48TFSecUserId_To, AV51TFSecUserName, AV52TFSecUserName_Sel, AV89TFSecUserFullName, AV90TFSecUserFullName_Sel, AV91TFusuariosId, AV92TFusuariosId_Sel, AV93TFusuariosNombre, AV94TFusuariosNombre_Sel, AV96TFusuariosEstado_Sels, AV98TFSecUserEstado_Sels, AV101TFSecUserPassword, AV102TFSecUserPassword_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV17IsAuthorized_Update, AV18IsAuthorized_Delete, AV103IsAuthorized_Desencriptar, AV16IsAuthorized_UAAssociateRoles, AV100IsAuthorized_usuariosId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E260U2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV30DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E210U2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV36DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         AV32DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV32DynamicFiltersEnabled3", AV32DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV36DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV36DynamicFiltersRemoving", AV36DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV23OrderedBy, AV24OrderedDsc, AV25DynamicFiltersSelector1, AV26DynamicFiltersOperator1, AV27SecUserName1, AV86usuariosId1, AV29DynamicFiltersSelector2, AV30DynamicFiltersOperator2, AV31SecUserName2, AV87usuariosId2, AV33DynamicFiltersSelector3, AV34DynamicFiltersOperator3, AV35SecUserName3, AV88usuariosId3, AV40ManageFiltersExecutionStep, AV28DynamicFiltersEnabled2, AV32DynamicFiltersEnabled3, AV70ColumnsSelector, AV104Pgmname, AV83FilterFullText, AV47TFSecUserId, AV48TFSecUserId_To, AV51TFSecUserName, AV52TFSecUserName_Sel, AV89TFSecUserFullName, AV90TFSecUserFullName_Sel, AV91TFusuariosId, AV92TFusuariosId_Sel, AV93TFusuariosNombre, AV94TFusuariosNombre_Sel, AV96TFusuariosEstado_Sels, AV98TFSecUserEstado_Sels, AV101TFSecUserPassword, AV102TFSecUserPassword_Sel, AV20GridState, AV37DynamicFiltersIgnoreFirst, AV36DynamicFiltersRemoving, AV17IsAuthorized_Update, AV18IsAuthorized_Delete, AV103IsAuthorized_Desencriptar, AV16IsAuthorized_UAAssociateRoles, AV100IsAuthorized_usuariosId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E270U2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV34DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E110U2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("WWPBaseObjects.SecUserWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV104Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("WWPBaseObjects.SecUserWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV41ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "WWPBaseObjects.SecUserWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV41ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S242 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV104Pgmname+"GridState",  AV41ManageFiltersXml) ;
               AV20GridState.FromXml(AV41ManageFiltersXml, null, "", "");
               AV23OrderedBy = AV20GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV23OrderedBy", StringUtil.LTrimStr( (decimal)(AV23OrderedBy), 4, 0));
               AV24OrderedDsc = AV20GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV24OrderedDsc", AV24OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S252 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S232 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV96TFusuariosEstado_Sels", AV96TFusuariosEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV98TFSecUserEstado_Sels", AV98TFSecUserEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void E310U2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV99GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DISPLAY' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV99GridActions == 2 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV99GridActions == 3 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV99GridActions == 4 )
         {
            /* Execute user subroutine: 'DO DESENCRIPTAR' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV99GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV99GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV99GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E180U2( )
      {
         /* Desencriptar_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "DesencriptarPass")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "desencriptarpass", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "DesencriptarPass";
            WebComp_Wwpaux_wc_Component = "DesencriptarPass";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0148",(string)"",(string)A27SecUserPassword});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0148"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E170U2( )
      {
         /* Desencriptar_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
      }

      protected void E220U2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.secuser.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("wwpbaseobjects.secuser.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E140U2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S312 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20GridState", AV20GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV98TFSecUserEstado_Sels", AV98TFSecUserEstado_Sels);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV96TFusuariosEstado_Sels", AV96TFusuariosEstado_Sels);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV29DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV33DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ColumnsSelector", AV70ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ManageFiltersData", AV44ManageFiltersData);
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV23OrderedBy), 4, 0))+":"+(AV24OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S202( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV70ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "SecUserId",  "",  "Usuario Nro.",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "SecUserName",  "",  "NickName",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "SecUserFullName",  "",  "Nombre Completo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "usuariosId",  "",  "NickName",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "usuariosNombre",  "",  "Nombre",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "usuariosEstado",  "",  "usuarios Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "usuariosImagen",  "",  "Imagen",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "SecUserEstado",  "",  "Estado",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV70ColumnsSelector,  "SecUserPassword",  "",  "Password",  true,  "") ;
         GXt_char3 = AV65UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "WWPBaseObjects.SecUserWWColumnsSelector", out  GXt_char3) ;
         AV65UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65UserCustomValue)) ) )
         {
            AV81ColumnsSelectorAux.FromXml(AV65UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV81ColumnsSelectorAux, ref  AV70ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV17IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser_Update", out  GXt_boolean1) ;
         AV17IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV17IsAuthorized_Update", AV17IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV17IsAuthorized_Update, context));
         GXt_boolean1 = AV18IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser_Delete", out  GXt_boolean1) ;
         AV18IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV18IsAuthorized_Delete", AV18IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV18IsAuthorized_Delete, context));
         GXt_boolean1 = AV103IsAuthorized_Desencriptar;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WebComponent1", out  GXt_boolean1) ;
         AV103IsAuthorized_Desencriptar = GXt_boolean1;
         AssignAttri("", false, "AV103IsAuthorized_Desencriptar", AV103IsAuthorized_Desencriptar);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DESENCRIPTAR", GetSecureSignedToken( "", AV103IsAuthorized_Desencriptar, context));
         GXt_boolean1 = AV16IsAuthorized_UAAssociateRoles;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "UserAssignRoles", out  GXt_boolean1) ;
         AV16IsAuthorized_UAAssociateRoles = GXt_boolean1;
         AssignAttri("", false, "AV16IsAuthorized_UAAssociateRoles", AV16IsAuthorized_UAAssociateRoles);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UAASSOCIATEROLES", GetSecureSignedToken( "", AV16IsAuthorized_UAAssociateRoles, context));
         if ( ! ( AV16IsAuthorized_UAAssociateRoles ) )
         {
            edtavUaassociateroles_Visible = 0;
            AssignProp("", false, edtavUaassociateroles_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUaassociateroles_Visible), 5, 0), !bGXsfl_118_Refreshing);
         }
         GXt_boolean1 = AV19TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser_Insert", out  GXt_boolean1) ;
         AV19TempBoolean = GXt_boolean1;
         if ( ! ( AV19TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavSecusername1_Visible = 0;
         AssignProp("", false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
         edtavUsuariosid1_Visible = 0;
         AssignProp("", false, edtavUsuariosid1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariosid1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERNAME") == 0 )
         {
            edtavSecusername1_Visible = 1;
            AssignProp("", false, edtavSecusername1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "USUARIOSID") == 0 )
         {
            edtavUsuariosid1_Visible = 1;
            AssignProp("", false, edtavUsuariosid1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariosid1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavSecusername2_Visible = 0;
         AssignProp("", false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
         edtavUsuariosid2_Visible = 0;
         AssignProp("", false, edtavUsuariosid2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariosid2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERNAME") == 0 )
         {
            edtavSecusername2_Visible = 1;
            AssignProp("", false, edtavSecusername2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "USUARIOSID") == 0 )
         {
            edtavUsuariosid2_Visible = 1;
            AssignProp("", false, edtavUsuariosid2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariosid2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavSecusername3_Visible = 0;
         AssignProp("", false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
         edtavUsuariosid3_Visible = 0;
         AssignProp("", false, edtavUsuariosid3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariosid3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERNAME") == 0 )
         {
            edtavSecusername3_Visible = 1;
            AssignProp("", false, edtavSecusername3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSecusername3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "USUARIOSID") == 0 )
         {
            edtavUsuariosid3_Visible = 1;
            AssignProp("", false, edtavUsuariosid3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsuariosid3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV28DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
         AV29DynamicFiltersSelector2 = "SECUSERNAME";
         AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
         AV30DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         AV31SecUserName2 = "";
         AssignAttri("", false, "AV31SecUserName2", AV31SecUserName2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV32DynamicFiltersEnabled3", AV32DynamicFiltersEnabled3);
         AV33DynamicFiltersSelector3 = "SECUSERNAME";
         AssignAttri("", false, "AV33DynamicFiltersSelector3", AV33DynamicFiltersSelector3);
         AV34DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         AV35SecUserName3 = "";
         AssignAttri("", false, "AV35SecUserName3", AV35SecUserName3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV44ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "WWPBaseObjects.SecUserWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV44ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV83FilterFullText = "";
         AssignAttri("", false, "AV83FilterFullText", AV83FilterFullText);
         AV47TFSecUserId = 0;
         AssignAttri("", false, "AV47TFSecUserId", StringUtil.LTrimStr( (decimal)(AV47TFSecUserId), 10, 0));
         AV48TFSecUserId_To = 0;
         AssignAttri("", false, "AV48TFSecUserId_To", StringUtil.LTrimStr( (decimal)(AV48TFSecUserId_To), 10, 0));
         AV51TFSecUserName = "";
         AssignAttri("", false, "AV51TFSecUserName", AV51TFSecUserName);
         AV52TFSecUserName_Sel = "";
         AssignAttri("", false, "AV52TFSecUserName_Sel", AV52TFSecUserName_Sel);
         AV89TFSecUserFullName = "";
         AssignAttri("", false, "AV89TFSecUserFullName", AV89TFSecUserFullName);
         AV90TFSecUserFullName_Sel = "";
         AssignAttri("", false, "AV90TFSecUserFullName_Sel", AV90TFSecUserFullName_Sel);
         AV91TFusuariosId = "";
         AssignAttri("", false, "AV91TFusuariosId", AV91TFusuariosId);
         AV92TFusuariosId_Sel = "";
         AssignAttri("", false, "AV92TFusuariosId_Sel", AV92TFusuariosId_Sel);
         AV93TFusuariosNombre = "";
         AssignAttri("", false, "AV93TFusuariosNombre", AV93TFusuariosNombre);
         AV94TFusuariosNombre_Sel = "";
         AssignAttri("", false, "AV94TFusuariosNombre_Sel", AV94TFusuariosNombre_Sel);
         AV96TFusuariosEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV98TFSecUserEstado_Sels = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV101TFSecUserPassword = "";
         AssignAttri("", false, "AV101TFSecUserPassword", AV101TFSecUserPassword);
         AV102TFSecUserPassword_Sel = "";
         AssignAttri("", false, "AV102TFSecUserPassword_Sel", AV102TFSecUserPassword_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV25DynamicFiltersSelector1 = "SECUSERNAME";
         AssignAttri("", false, "AV25DynamicFiltersSelector1", AV25DynamicFiltersSelector1);
         AV26DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         AV27SecUserName1 = "";
         AssignAttri("", false, "AV27SecUserName1", AV27SecUserName1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S262( )
      {
         /* 'DO DISPLAY' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.secuserview.aspx"+UrlEncode(StringUtil.LTrimStr(A18SecUserId,10,0)) + "," + UrlEncode(StringUtil.RTrim(""));
         CallWebObject(formatLink("wwpbaseobjects.secuserview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S272( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.secuser.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A18SecUserId,10,0));
         CallWebObject(formatLink("wwpbaseobjects.secuser.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S282( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.secuser.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A18SecUserId,10,0));
         CallWebObject(formatLink("wwpbaseobjects.secuser.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S292( )
      {
         /* 'DO DESENCRIPTAR' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "DESENCRIPTAR_MODALContainer", "Confirm", "", new Object[] {});
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get(AV104Pgmname+"GridState"), "") == 0 )
         {
            AV20GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV104Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV20GridState.FromXml(AV14Session.Get(AV104Pgmname+"GridState"), null, "", "");
         }
         AV23OrderedBy = AV20GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV23OrderedBy", StringUtil.LTrimStr( (decimal)(AV23OrderedBy), 4, 0));
         AV24OrderedDsc = AV20GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV24OrderedDsc", AV24OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV20GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV20GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV20GridState.gxTpr_Currentpage) ;
      }

      protected void S252( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV135GXV1 = 1;
         while ( AV135GXV1 <= AV20GridState.gxTpr_Filtervalues.Count )
         {
            AV21GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV20GridState.gxTpr_Filtervalues.Item(AV135GXV1));
            if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV83FilterFullText = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV83FilterFullText", AV83FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERID") == 0 )
            {
               AV47TFSecUserId = (long)(Math.Round(NumberUtil.Val( AV21GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFSecUserId", StringUtil.LTrimStr( (decimal)(AV47TFSecUserId), 10, 0));
               AV48TFSecUserId_To = (long)(Math.Round(NumberUtil.Val( AV21GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV48TFSecUserId_To", StringUtil.LTrimStr( (decimal)(AV48TFSecUserId_To), 10, 0));
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV51TFSecUserName = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFSecUserName", AV51TFSecUserName);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV52TFSecUserName_Sel = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFSecUserName_Sel", AV52TFSecUserName_Sel);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV89TFSecUserFullName = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV89TFSecUserFullName", AV89TFSecUserFullName);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV90TFSecUserFullName_Sel = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV90TFSecUserFullName_Sel", AV90TFSecUserFullName_Sel);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFUSUARIOSID") == 0 )
            {
               AV91TFusuariosId = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV91TFusuariosId", AV91TFusuariosId);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFUSUARIOSID_SEL") == 0 )
            {
               AV92TFusuariosId_Sel = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV92TFusuariosId_Sel", AV92TFusuariosId_Sel);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFUSUARIOSNOMBRE") == 0 )
            {
               AV93TFusuariosNombre = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV93TFusuariosNombre", AV93TFusuariosNombre);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFUSUARIOSNOMBRE_SEL") == 0 )
            {
               AV94TFusuariosNombre_Sel = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV94TFusuariosNombre_Sel", AV94TFusuariosNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFUSUARIOSESTADO_SEL") == 0 )
            {
               AV95TFusuariosEstado_SelsJson = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV95TFusuariosEstado_SelsJson", AV95TFusuariosEstado_SelsJson);
               AV96TFusuariosEstado_Sels.FromJSonString(AV95TFusuariosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERESTADO_SEL") == 0 )
            {
               AV97TFSecUserEstado_SelsJson = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV97TFSecUserEstado_SelsJson", AV97TFSecUserEstado_SelsJson);
               AV98TFSecUserEstado_Sels.FromJSonString(AV97TFSecUserEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERPASSWORD") == 0 )
            {
               AV101TFSecUserPassword = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV101TFSecUserPassword", AV101TFSecUserPassword);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Name, "TFSECUSERPASSWORD_SEL") == 0 )
            {
               AV102TFSecUserPassword_Sel = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV102TFSecUserPassword_Sel", AV102TFSecUserPassword_Sel);
            }
            AV135GXV1 = (int)(AV135GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserName_Sel)),  AV52TFSecUserName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV90TFSecUserFullName_Sel)),  AV90TFSecUserFullName_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV92TFusuariosId_Sel)),  AV92TFusuariosId_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV94TFusuariosNombre_Sel)),  AV94TFusuariosNombre_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV96TFusuariosEstado_Sels.Count==0),  AV95TFusuariosEstado_SelsJson, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV98TFSecUserEstado_Sels.Count==0),  AV97TFSecUserEstado_SelsJson, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV102TFSecUserPassword_Sel)),  AV102TFSecUserPassword_Sel, out  GXt_char10) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"||"+GXt_char9+"|"+GXt_char10;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserName)),  AV51TFSecUserName, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV89TFSecUserFullName)),  AV89TFSecUserFullName, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV91TFusuariosId)),  AV91TFusuariosId, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV93TFusuariosNombre)),  AV93TFusuariosNombre, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV101TFSecUserPassword)),  AV101TFSecUserPassword, out  GXt_char6) ;
         Ddo_grid_Filteredtext_set = ((0==AV47TFSecUserId) ? "" : StringUtil.Str( (decimal)(AV47TFSecUserId), 10, 0))+"|"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"||||"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV48TFSecUserId_To) ? "" : StringUtil.Str( (decimal)(AV48TFSecUserId_To), 10, 0))+"||||||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S232( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV20GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV22GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV20GridState.gxTpr_Dynamicfilters.Item(1));
            AV25DynamicFiltersSelector1 = AV22GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV25DynamicFiltersSelector1", AV25DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV26DynamicFiltersOperator1 = AV22GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
               AV27SecUserName1 = AV22GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV27SecUserName1", AV27SecUserName1);
            }
            else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "USUARIOSID") == 0 )
            {
               AV26DynamicFiltersOperator1 = AV22GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
               AV86usuariosId1 = AV22GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV86usuariosId1", AV86usuariosId1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV20GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV28DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV28DynamicFiltersEnabled2", AV28DynamicFiltersEnabled2);
               AV22GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV20GridState.gxTpr_Dynamicfilters.Item(2));
               AV29DynamicFiltersSelector2 = AV22GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV22GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV31SecUserName2 = AV22GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV31SecUserName2", AV31SecUserName2);
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "USUARIOSID") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV22GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
                  AV87usuariosId2 = AV22GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV87usuariosId2", AV87usuariosId2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV20GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV32DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV32DynamicFiltersEnabled3", AV32DynamicFiltersEnabled3);
                  AV22GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV20GridState.gxTpr_Dynamicfilters.Item(3));
                  AV33DynamicFiltersSelector3 = AV22GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV33DynamicFiltersSelector3", AV33DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV22GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
                     AV35SecUserName3 = AV22GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV35SecUserName3", AV35SecUserName3);
                  }
                  else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "USUARIOSID") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV22GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
                     AV88usuariosId3 = AV22GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV88usuariosId3", AV88usuariosId3);
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S142 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+"});</script>";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV36DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV20GridState.FromXml(AV14Session.Get(AV104Pgmname+"GridState"), null, "", "");
         AV20GridState.gxTpr_Orderedby = AV23OrderedBy;
         AV20GridState.gxTpr_Ordereddsc = AV24OrderedDsc;
         AV20GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV83FilterFullText)),  0,  AV83FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "TFSECUSERID",  context.GetMessage( "Usuario Nro.", ""),  !((0==AV47TFSecUserId)&&(0==AV48TFSecUserId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV47TFSecUserId), 10, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV48TFSecUserId_To), 10, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFSECUSERNAME",  context.GetMessage( "NickName", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserName)),  0,  AV51TFSecUserName,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserName_Sel)),  AV52TFSecUserName_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFSECUSERFULLNAME",  context.GetMessage( "Nombre Completo", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV89TFSecUserFullName)),  0,  AV89TFSecUserFullName,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV90TFSecUserFullName_Sel)),  AV90TFSecUserFullName_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFUSUARIOSID",  context.GetMessage( "NickName", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV91TFusuariosId)),  0,  AV91TFusuariosId,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV92TFusuariosId_Sel)),  AV92TFusuariosId_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFUSUARIOSNOMBRE",  context.GetMessage( "Nombre", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV93TFusuariosNombre)),  0,  AV93TFusuariosNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV94TFusuariosNombre_Sel)),  AV94TFusuariosNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "TFUSUARIOSESTADO_SEL",  context.GetMessage( "usuarios Estado", ""),  !(AV96TFusuariosEstado_Sels.Count==0),  0,  AV96TFusuariosEstado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV20GridState,  "TFSECUSERESTADO_SEL",  context.GetMessage( "Estado", ""),  !(AV98TFSecUserEstado_Sels.Count==0),  0,  AV98TFSecUserEstado_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV20GridState,  "TFSECUSERPASSWORD",  context.GetMessage( "Password", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV101TFSecUserPassword)),  0,  AV101TFSecUserPassword,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV102TFSecUserPassword_Sel)),  AV102TFSecUserPassword_Sel,  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV20GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV20GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV104Pgmname+"GridState",  AV20GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV20GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV37DynamicFiltersIgnoreFirst )
         {
            AV22GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV22GridStateDynamicFilter.gxTpr_Selected = AV25DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SecUserName1)) )
            {
               AV22GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "NickName", "");
               AV22GridStateDynamicFilter.gxTpr_Value = AV27SecUserName1;
               AV22GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector1, "USUARIOSID") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV86usuariosId1)) )
            {
               AV22GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "NickName", "");
               AV22GridStateDynamicFilter.gxTpr_Value = AV86usuariosId1;
               AV22GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator1;
            }
            if ( AV36DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV22GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV20GridState.gxTpr_Dynamicfilters.Add(AV22GridStateDynamicFilter, 0);
            }
         }
         if ( AV28DynamicFiltersEnabled2 )
         {
            AV22GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV22GridStateDynamicFilter.gxTpr_Selected = AV29DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31SecUserName2)) )
            {
               AV22GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "NickName", "");
               AV22GridStateDynamicFilter.gxTpr_Value = AV31SecUserName2;
               AV22GridStateDynamicFilter.gxTpr_Operator = AV30DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "USUARIOSID") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV87usuariosId2)) )
            {
               AV22GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "NickName", "");
               AV22GridStateDynamicFilter.gxTpr_Value = AV87usuariosId2;
               AV22GridStateDynamicFilter.gxTpr_Operator = AV30DynamicFiltersOperator2;
            }
            if ( AV36DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV22GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV20GridState.gxTpr_Dynamicfilters.Add(AV22GridStateDynamicFilter, 0);
            }
         }
         if ( AV32DynamicFiltersEnabled3 )
         {
            AV22GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV22GridStateDynamicFilter.gxTpr_Selected = AV33DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV35SecUserName3)) )
            {
               AV22GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "NickName", "");
               AV22GridStateDynamicFilter.gxTpr_Value = AV35SecUserName3;
               AV22GridStateDynamicFilter.gxTpr_Operator = AV34DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "USUARIOSID") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV88usuariosId3)) )
            {
               AV22GridStateDynamicFilter.gxTpr_Dsc = context.GetMessage( "NickName", "");
               AV22GridStateDynamicFilter.gxTpr_Value = AV88usuariosId3;
               AV22GridStateDynamicFilter.gxTpr_Operator = AV34DynamicFiltersOperator3;
            }
            if ( AV36DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV22GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV20GridState.gxTpr_Dynamicfilters.Add(AV22GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV104Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "WWPBaseObjects.SecUser";
         AV14Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S302( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.wwpbaseobjects.secuserwwexport(context ).execute( out  AV38ExcelFilename, out  AV39ErrorMessage) ;
         if ( StringUtil.StrCmp(AV38ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV38ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV39ErrorMessage);
         }
      }

      protected void S312( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("wwpbaseobjects.asecuserwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table5_141_0U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledesencriptar_modal_Internalname, tblTabledesencriptar_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDesencriptar_modal.SetProperty("Width", Desencriptar_modal_Width);
            ucDesencriptar_modal.SetProperty("Title", Desencriptar_modal_Title);
            ucDesencriptar_modal.SetProperty("ConfirmType", Desencriptar_modal_Confirmtype);
            ucDesencriptar_modal.SetProperty("BodyType", Desencriptar_modal_Bodytype);
            ucDesencriptar_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Desencriptar_modal_Internalname, "DESENCRIPTAR_MODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DESENCRIPTAR_MODALContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_141_0U2e( true) ;
         }
         else
         {
            wb_table5_141_0U2e( false) ;
         }
      }

      protected void wb_table4_97_0U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters3_Internalname, tblTablemergeddynamicfilters3_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator3_Internalname, context.GetMessage( "Dynamic Filters Operator3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 0, "HLP_WWPBaseObjects/SecUserWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername3_Internalname, context.GetMessage( "Sec User Name3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername3_Internalname, AV35SecUserName3, StringUtil.RTrim( context.localUtil.Format( AV35SecUserName3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername3_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername3_Visible, edtavSecusername3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_usuariosid3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariosid3_Internalname, context.GetMessage( "usuarios Id3", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuariosid3_Internalname, StringUtil.RTrim( AV88usuariosId3), StringUtil.RTrim( context.localUtil.Format( AV88usuariosId3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariosid3_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuariosid3_Visible, edtavUsuariosid3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_WWPBaseObjects/SecUserWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_97_0U2e( true) ;
         }
         else
         {
            wb_table4_97_0U2e( false) ;
         }
      }

      protected void wb_table3_72_0U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters2_Internalname, tblTablemergeddynamicfilters2_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator2_Internalname, context.GetMessage( "Dynamic Filters Operator2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "", true, 0, "HLP_WWPBaseObjects/SecUserWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername2_Internalname, context.GetMessage( "Sec User Name2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername2_Internalname, AV31SecUserName2, StringUtil.RTrim( context.localUtil.Format( AV31SecUserName2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername2_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername2_Visible, edtavSecusername2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_usuariosid2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariosid2_Internalname, context.GetMessage( "usuarios Id2", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuariosid2_Internalname, StringUtil.RTrim( AV87usuariosId2), StringUtil.RTrim( context.localUtil.Format( AV87usuariosId2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariosid2_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuariosid2_Visible, edtavUsuariosid2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_WWPBaseObjects/SecUserWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_WWPBaseObjects/SecUserWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_72_0U2e( true) ;
         }
         else
         {
            wb_table3_72_0U2e( false) ;
         }
      }

      protected void wb_table2_47_0U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters1_Internalname, tblTablemergeddynamicfilters1_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator1_Internalname, context.GetMessage( "Dynamic Filters Operator1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_WWPBaseObjects/SecUserWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_secusername1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSecusername1_Internalname, context.GetMessage( "Sec User Name1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSecusername1_Internalname, AV27SecUserName1, StringUtil.RTrim( context.localUtil.Format( AV27SecUserName1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSecusername1_Jsonclick, 0, "Attribute", "", "", "", "", edtavSecusername1_Visible, edtavSecusername1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_usuariosid1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariosid1_Internalname, context.GetMessage( "usuarios Id1", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuariosid1_Internalname, StringUtil.RTrim( AV86usuariosId1), StringUtil.RTrim( context.localUtil.Format( AV86usuariosId1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariosid1_Jsonclick, 0, "Attribute", "", "", "", "", edtavUsuariosid1_Visible, edtavUsuariosid1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterAddTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_WWPBaseObjects/SecUserWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", context.GetMessage( "WWP_DynFilterRemoveTooltip", ""), 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "none", "HLP_WWPBaseObjects/SecUserWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_47_0U2e( true) ;
         }
         else
         {
            wb_table2_47_0U2e( false) ;
         }
      }

      protected void wb_table1_23_0U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV44ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table6_28_0U2( true) ;
         }
         else
         {
            wb_table6_28_0U2( false) ;
         }
         return  ;
      }

      protected void wb_table6_28_0U2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_23_0U2e( true) ;
         }
         else
         {
            wb_table1_23_0U2e( false) ;
         }
      }

      protected void wb_table6_28_0U2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, context.GetMessage( "Filter Full Text", ""), "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV83FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV83FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_WWPBaseObjects/SecUserWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_28_0U2e( true) ;
         }
         else
         {
            wb_table6_28_0U2e( false) ;
         }
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
         PA0U2( ) ;
         WS0U2( ) ;
         WE0U2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269320123941", true, true, false);
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
         context.AddJavascriptSource("wwpbaseobjects/secuserww.js", "?20269320123942", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1182( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_118_idx;
         edtavUaassociateroles_Internalname = "vUAASSOCIATEROLES_"+sGXsfl_118_idx;
         edtSecUserId_Internalname = "SECUSERID_"+sGXsfl_118_idx;
         edtSecUserName_Internalname = "SECUSERNAME_"+sGXsfl_118_idx;
         edtSecUserFullName_Internalname = "SECUSERFULLNAME_"+sGXsfl_118_idx;
         edtusuariosId_Internalname = "USUARIOSID_"+sGXsfl_118_idx;
         edtusuariosNombre_Internalname = "USUARIOSNOMBRE_"+sGXsfl_118_idx;
         cmbusuariosEstado_Internalname = "USUARIOSESTADO_"+sGXsfl_118_idx;
         edtusuariosImagen_Internalname = "USUARIOSIMAGEN_"+sGXsfl_118_idx;
         cmbSecUserEstado_Internalname = "SECUSERESTADO_"+sGXsfl_118_idx;
         edtSecUserPassword_Internalname = "SECUSERPASSWORD_"+sGXsfl_118_idx;
      }

      protected void SubsflControlProps_fel_1182( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_118_fel_idx;
         edtavUaassociateroles_Internalname = "vUAASSOCIATEROLES_"+sGXsfl_118_fel_idx;
         edtSecUserId_Internalname = "SECUSERID_"+sGXsfl_118_fel_idx;
         edtSecUserName_Internalname = "SECUSERNAME_"+sGXsfl_118_fel_idx;
         edtSecUserFullName_Internalname = "SECUSERFULLNAME_"+sGXsfl_118_fel_idx;
         edtusuariosId_Internalname = "USUARIOSID_"+sGXsfl_118_fel_idx;
         edtusuariosNombre_Internalname = "USUARIOSNOMBRE_"+sGXsfl_118_fel_idx;
         cmbusuariosEstado_Internalname = "USUARIOSESTADO_"+sGXsfl_118_fel_idx;
         edtusuariosImagen_Internalname = "USUARIOSIMAGEN_"+sGXsfl_118_fel_idx;
         cmbSecUserEstado_Internalname = "SECUSERESTADO_"+sGXsfl_118_fel_idx;
         edtSecUserPassword_Internalname = "SECUSERPASSWORD_"+sGXsfl_118_fel_idx;
      }

      protected void sendrow_1182( )
      {
         sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
         SubsflControlProps_1182( ) ;
         WB0U0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_118_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_118_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_118_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'" + sGXsfl_118_idx + "',118)\"";
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_118_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV99GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV99GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV99GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV99GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_118_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)cmbavGridactions_Columnclass,(string)cmbavGridactions_Columnheaderclass,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"",(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV99GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_118_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUaassociateroles_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ActionBaseColorAttribute" + " " + ((StringUtil.StrCmp(edtavUaassociateroles_gximage, "")==0) ? "" : "GX_Image_"+edtavUaassociateroles_gximage+"_Class");
            StyleString = "";
            AV15UAAssociateRoles_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV15UAAssociateRoles))&&String.IsNullOrEmpty(StringUtil.RTrim( AV134Uaassociateroles_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV15UAAssociateRoles)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV15UAAssociateRoles)) ? AV134Uaassociateroles_GXI : context.PathToRelativeUrl( AV15UAAssociateRoles));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUaassociateroles_Internalname,(string)sImgUrl,(string)edtavUaassociateroles_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUaassociateroles_Visible,(short)1,(string)"",(string)edtavUaassociateroles_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)edtavUaassociateroles_Columnclass,(string)edtavUaassociateroles_Columnheaderclass,(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV15UAAssociateRoles_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtSecUserId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A18SecUserId), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A18SecUserId), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtSecUserId_Columnclass,(string)edtSecUserId_Columnheaderclass,(int)edtSecUserId_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSecUserName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserName_Internalname,(string)A26SecUserName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSecUserName_Link,(string)"",(string)"",(string)"",(string)edtSecUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtSecUserName_Columnclass,(string)edtSecUserName_Columnheaderclass,(int)edtSecUserName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSecUserFullName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserFullName_Internalname,(string)A587SecUserFullName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserFullName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtSecUserFullName_Columnclass,(string)edtSecUserFullName_Columnheaderclass,(int)edtSecUserFullName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtusuariosId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosId_Internalname,StringUtil.RTrim( A145usuariosId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtusuariosId_Link,(string)"",(string)"",(string)"",(string)edtusuariosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtusuariosId_Columnclass,(string)edtusuariosId_Columnheaderclass,(int)edtusuariosId_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"NickName",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtusuariosNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosNombre_Internalname,StringUtil.RTrim( A222usuariosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtusuariosNombre_Columnclass,(string)edtusuariosNombre_Columnheaderclass,(int)edtusuariosNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbusuariosEstado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            GXCCtl = "USUARIOSESTADO_" + sGXsfl_118_idx;
            cmbusuariosEstado.Name = GXCCtl;
            cmbusuariosEstado.WebTags = "";
            cmbusuariosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
            cmbusuariosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
            cmbusuariosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
            cmbusuariosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
            if ( cmbusuariosEstado.ItemCount > 0 )
            {
               A226usuariosEstado = cmbusuariosEstado.getValidValue(A226usuariosEstado);
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbusuariosEstado,(string)cmbusuariosEstado_Internalname,StringUtil.RTrim( A226usuariosEstado),(short)1,(string)cmbusuariosEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbusuariosEstado.Visible,(short)0,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbusuariosEstado_Columnclass,(string)cmbusuariosEstado_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbusuariosEstado.CurrentValue = StringUtil.RTrim( A226usuariosEstado);
            AssignProp("", false, cmbusuariosEstado_Internalname, "Values", (string)(cmbusuariosEstado.ToJavascriptSource()), !bGXsfl_118_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtusuariosImagen_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Attribute";
            StyleString = "";
            A266usuariosImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000usuariosImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A266usuariosImagen)) ? A40000usuariosImagen_GXI : context.PathToRelativeUrl( A266usuariosImagen));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(int)edtusuariosImagen_Visible,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)edtusuariosImagen_Columnclass,(string)edtusuariosImagen_Columnheaderclass,(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A266usuariosImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbSecUserEstado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbSecUserEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "SECUSERESTADO_" + sGXsfl_118_idx;
               cmbSecUserEstado.Name = GXCCtl;
               cmbSecUserEstado.WebTags = "";
               cmbSecUserEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
               cmbSecUserEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
               cmbSecUserEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
               cmbSecUserEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
               if ( cmbSecUserEstado.ItemCount > 0 )
               {
                  A550SecUserEstado = cmbSecUserEstado.getValidValue(A550SecUserEstado);
                  n550SecUserEstado = false;
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbSecUserEstado,(string)cmbSecUserEstado_Internalname,StringUtil.RTrim( A550SecUserEstado),(short)1,(string)cmbSecUserEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbSecUserEstado.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbSecUserEstado_Columnclass,(string)cmbSecUserEstado_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbSecUserEstado.CurrentValue = StringUtil.RTrim( A550SecUserEstado);
            AssignProp("", false, cmbSecUserEstado_Internalname, "Values", (string)(cmbSecUserEstado.ToJavascriptSource()), !bGXsfl_118_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtSecUserPassword_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSecUserPassword_Internalname,(string)A27SecUserPassword,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSecUserPassword_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)edtSecUserPassword_Columnclass,(string)edtSecUserPassword_Columnheaderclass,(int)edtSecUserPassword_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)-1,(short)0,(short)118,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes0U2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_118_idx = ((subGrid_Islastpage==1)&&(nGXsfl_118_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_118_idx+1);
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1182( ) ;
         }
         /* End function sendrow_1182 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("SECUSERNAME", context.GetMessage( "NickName", ""), 0);
         cmbavDynamicfiltersselector1.addItem("USUARIOSID", context.GetMessage( "NickName", ""), 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV25DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV25DynamicFiltersSelector1);
            AssignAttri("", false, "AV25DynamicFiltersSelector1", AV25DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator1.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("SECUSERNAME", context.GetMessage( "NickName", ""), 0);
         cmbavDynamicfiltersselector2.addItem("USUARIOSID", context.GetMessage( "NickName", ""), 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV29DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV29DynamicFiltersSelector2);
            AssignAttri("", false, "AV29DynamicFiltersSelector2", AV29DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator2.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV30DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV30DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("SECUSERNAME", context.GetMessage( "NickName", ""), 0);
         cmbavDynamicfiltersselector3.addItem("USUARIOSID", context.GetMessage( "NickName", ""), 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV33DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV33DynamicFiltersSelector3);
            AssignAttri("", false, "AV33DynamicFiltersSelector3", AV33DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", context.GetMessage( "WWP_FilterLike", ""), 0);
         cmbavDynamicfiltersoperator3.addItem("1", context.GetMessage( "WWP_FilterContains", ""), 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV34DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV34DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV34DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV34DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_118_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV99GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV99GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV99GridActions), 4, 0));
         }
         GXCCtl = "USUARIOSESTADO_" + sGXsfl_118_idx;
         cmbusuariosEstado.Name = GXCCtl;
         cmbusuariosEstado.WebTags = "";
         cmbusuariosEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbusuariosEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbusuariosEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbusuariosEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbusuariosEstado.ItemCount > 0 )
         {
            A226usuariosEstado = cmbusuariosEstado.getValidValue(A226usuariosEstado);
         }
         GXCCtl = "SECUSERESTADO_" + sGXsfl_118_idx;
         cmbSecUserEstado.Name = GXCCtl;
         cmbSecUserEstado.WebTags = "";
         cmbSecUserEstado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbSecUserEstado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbSecUserEstado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbSecUserEstado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbSecUserEstado.ItemCount > 0 )
         {
            A550SecUserEstado = cmbSecUserEstado.getValidValue(A550SecUserEstado);
            n550SecUserEstado = false;
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl118( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"118\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ActionBaseColorAttribute"+" "+((StringUtil.StrCmp(edtavUaassociateroles_gximage, "")==0) ? "" : "GX_Image_"+edtavUaassociateroles_gximage+"_Class")+"\" "+" style=\""+((edtavUaassociateroles_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( edtavUaassociateroles_Title) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSecUserId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Usuario Nro.", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSecUserName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "NickName", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSecUserFullName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre Completo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtusuariosId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "NickName", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtusuariosNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbusuariosEstado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "usuarios Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtusuariosImagen_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Imagen", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbSecUserEstado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtSecUserPassword_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Password", "")) ;
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
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV99GridActions), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbavGridactions_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbavGridactions_Columnheaderclass));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( AV15UAAssociateRoles));
            GridColumn.AddObjectProperty("Title", StringUtil.RTrim( edtavUaassociateroles_Title));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtavUaassociateroles_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtavUaassociateroles_Columnheaderclass));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUaassociateroles_Link));
            GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUaassociateroles_Tooltiptext));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUaassociateroles_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A18SecUserId), 10, 0, ".", ""))));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtSecUserId_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtSecUserId_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecUserId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A26SecUserName));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtSecUserName_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtSecUserName_Columnheaderclass));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSecUserName_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecUserName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A587SecUserFullName));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtSecUserFullName_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtSecUserFullName_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecUserFullName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A145usuariosId)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtusuariosId_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtusuariosId_Columnheaderclass));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtusuariosId_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosId_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A222usuariosNombre)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtusuariosNombre_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtusuariosNombre_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosNombre_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A226usuariosEstado)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbusuariosEstado_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbusuariosEstado_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbusuariosEstado.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.convertURL( A266usuariosImagen));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtusuariosImagen_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtusuariosImagen_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtusuariosImagen_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A550SecUserEstado)));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbSecUserEstado_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbSecUserEstado_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbSecUserEstado.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A27SecUserPassword));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( edtSecUserPassword_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( edtSecUserPassword_Columnheaderclass));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSecUserPassword_Visible), 5, 0, ".", "")));
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
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavSecusername1_Internalname = "vSECUSERNAME1";
         cellFilter_secusername1_cell_Internalname = "FILTER_SECUSERNAME1_CELL";
         edtavUsuariosid1_Internalname = "vUSUARIOSID1";
         cellFilter_usuariosid1_cell_Internalname = "FILTER_USUARIOSID1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = "TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = "vDYNAMICFILTERSOPERATOR2";
         edtavSecusername2_Internalname = "vSECUSERNAME2";
         cellFilter_secusername2_cell_Internalname = "FILTER_SECUSERNAME2_CELL";
         edtavUsuariosid2_Internalname = "vUSUARIOSID2";
         cellFilter_usuariosid2_cell_Internalname = "FILTER_USUARIOSID2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = "TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = "vDYNAMICFILTERSOPERATOR3";
         edtavSecusername3_Internalname = "vSECUSERNAME3";
         cellFilter_secusername3_cell_Internalname = "FILTER_SECUSERNAME3_CELL";
         edtavUsuariosid3_Internalname = "vUSUARIOSID3";
         cellFilter_usuariosid3_cell_Internalname = "FILTER_USUARIOSID3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtavUaassociateroles_Internalname = "vUAASSOCIATEROLES";
         edtSecUserId_Internalname = "SECUSERID";
         edtSecUserName_Internalname = "SECUSERNAME";
         edtSecUserFullName_Internalname = "SECUSERFULLNAME";
         edtusuariosId_Internalname = "USUARIOSID";
         edtusuariosNombre_Internalname = "USUARIOSNOMBRE";
         cmbusuariosEstado_Internalname = "USUARIOSESTADO";
         edtusuariosImagen_Internalname = "USUARIOSIMAGEN";
         cmbSecUserEstado_Internalname = "SECUSERESTADO";
         edtSecUserPassword_Internalname = "SECUSERPASSWORD";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Desencriptar_modal_Internalname = "DESENCRIPTAR_MODAL";
         tblTabledesencriptar_modal_Internalname = "TABLEDESENCRIPTAR_MODAL";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtSecUserPassword_Jsonclick = "";
         edtSecUserPassword_Columnclass = "WWColumn hidden-xs hidden-sm hidden-md hidden-lg";
         cmbSecUserEstado_Jsonclick = "";
         cmbSecUserEstado_Columnclass = "WWColumn hidden-xs";
         edtusuariosImagen_Columnclass = "WWColumn hidden-xs";
         cmbusuariosEstado_Jsonclick = "";
         cmbusuariosEstado_Columnclass = "WWColumn hidden-xs";
         edtusuariosNombre_Jsonclick = "";
         edtusuariosNombre_Columnclass = "WWColumn hidden-xs";
         edtusuariosId_Jsonclick = "";
         edtusuariosId_Columnclass = "WWColumn hidden-xs";
         edtusuariosId_Link = "";
         edtSecUserFullName_Jsonclick = "";
         edtSecUserFullName_Columnclass = "WWColumn hidden-xs";
         edtSecUserName_Jsonclick = "";
         edtSecUserName_Columnclass = "WWColumn";
         edtSecUserName_Link = "";
         edtSecUserId_Jsonclick = "";
         edtSecUserId_Columnclass = "WWColumn hidden-xs";
         edtavUaassociateroles_Columnclass = "WWActionColumn";
         edtavUaassociateroles_gximage = "";
         edtavUaassociateroles_Link = "";
         edtavUaassociateroles_Tooltiptext = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions_Columnclass = "WWActionGroupColumn";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavUsuariosid1_Jsonclick = "";
         edtavUsuariosid1_Enabled = 1;
         edtavSecusername1_Jsonclick = "";
         edtavSecusername1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavUsuariosid2_Jsonclick = "";
         edtavUsuariosid2_Enabled = 1;
         edtavSecusername2_Jsonclick = "";
         edtavSecusername2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavUsuariosid3_Jsonclick = "";
         edtavUsuariosid3_Enabled = 1;
         edtavSecusername3_Jsonclick = "";
         edtavSecusername3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavUsuariosid3_Visible = 1;
         edtavSecusername3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavUsuariosid2_Visible = 1;
         edtavSecusername2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavUsuariosid1_Visible = 1;
         edtavSecusername1_Visible = 1;
         edtavUaassociateroles_Visible = -1;
         edtSecUserPassword_Columnheaderclass = "";
         cmbSecUserEstado_Columnheaderclass = "";
         edtusuariosImagen_Columnheaderclass = "";
         cmbusuariosEstado_Columnheaderclass = "";
         edtusuariosNombre_Columnheaderclass = "";
         edtusuariosId_Columnheaderclass = "";
         edtSecUserFullName_Columnheaderclass = "";
         edtSecUserName_Columnheaderclass = "";
         edtSecUserId_Columnheaderclass = "";
         edtavUaassociateroles_Columnheaderclass = "";
         cmbavGridactions_Columnheaderclass = "";
         edtSecUserPassword_Visible = -1;
         cmbSecUserEstado.Visible = -1;
         edtusuariosImagen_Visible = -1;
         cmbusuariosEstado.Visible = -1;
         edtusuariosNombre_Visible = -1;
         edtusuariosId_Visible = -1;
         edtSecUserFullName_Visible = -1;
         edtSecUserName_Visible = -1;
         edtSecUserId_Visible = -1;
         edtSecUserPassword_Enabled = 0;
         cmbSecUserEstado.Enabled = 0;
         edtusuariosImagen_Enabled = 0;
         cmbusuariosEstado.Enabled = 0;
         edtusuariosNombre_Enabled = 0;
         edtusuariosId_Enabled = 0;
         edtSecUserFullName_Enabled = 0;
         edtSecUserName_Enabled = 0;
         edtSecUserId_Enabled = 0;
         subGrid_Sortable = 0;
         lblJsdynamicfilters_Caption = context.GetMessage( "JSDynamicFilters", "");
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Desencriptar_modal_Bodytype = "WebComponent";
         Desencriptar_modal_Confirmtype = "";
         Desencriptar_modal_Title = context.GetMessage( "Contraseña", "");
         Desencriptar_modal_Width = "400";
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = context.GetMessage( "WWP_EditColumnsCaption", "");
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Format = "10.0||||||||";
         Ddo_grid_Datalistproc = "WWPBaseObjects.SecUserWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||HAB:Habilitado,DES:Deshabilitado,PEN:Pendiente||HAB:Habilitado,DES:Deshabilitado,PEN:Pendiente|";
         Ddo_grid_Allowmultipleselection = "|||||T||T|";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic|Dynamic|FixedValues||FixedValues|Dynamic";
         Ddo_grid_Includedatalist = "|T|T|T|T|T||T|T";
         Ddo_grid_Filterisrange = "T||||||||";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|Character||||Character";
         Ddo_grid_Includefilter = "T|T|T|T|T||||T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|T||T|T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6||7|8";
         Ddo_grid_Columnids = "2:SecUserId|3:SecUserName|4:SecUserFullName|5:usuariosId|6:usuariosNombre|7:usuariosEstado|8:usuariosImagen|9:SecUserEstado|10:SecUserPassword";
         Ddo_grid_Gridinternalname = "";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
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
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( " User", "");
         edtavUaassociateroles_Title = "";
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtSecUserId_Visible',ctrl:'SECUSERID',prop:'Visible'},{av:'edtSecUserName_Visible',ctrl:'SECUSERNAME',prop:'Visible'},{av:'edtSecUserFullName_Visible',ctrl:'SECUSERFULLNAME',prop:'Visible'},{av:'edtusuariosId_Visible',ctrl:'USUARIOSID',prop:'Visible'},{av:'edtusuariosNombre_Visible',ctrl:'USUARIOSNOMBRE',prop:'Visible'},{av:'cmbusuariosEstado'},{av:'edtusuariosImagen_Visible',ctrl:'USUARIOSIMAGEN',prop:'Visible'},{av:'cmbSecUserEstado'},{av:'edtSecUserPassword_Visible',ctrl:'SECUSERPASSWORD',prop:'Visible'},{av:'AV79GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV80GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtavUaassociateroles_Columnheaderclass',ctrl:'vUAASSOCIATEROLES',prop:'Columnheaderclass'},{av:'edtSecUserId_Columnheaderclass',ctrl:'SECUSERID',prop:'Columnheaderclass'},{av:'edtSecUserName_Columnheaderclass',ctrl:'SECUSERNAME',prop:'Columnheaderclass'},{av:'edtSecUserFullName_Columnheaderclass',ctrl:'SECUSERFULLNAME',prop:'Columnheaderclass'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtusuariosImagen_Columnheaderclass',ctrl:'USUARIOSIMAGEN',prop:'Columnheaderclass'},{av:'edtSecUserPassword_Columnheaderclass',ctrl:'SECUSERPASSWORD',prop:'Columnheaderclass'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'edtavUaassociateroles_Visible',ctrl:'vUAASSOCIATEROLES',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E120U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtSecUserId_Visible',ctrl:'SECUSERID',prop:'Visible'},{av:'edtSecUserName_Visible',ctrl:'SECUSERNAME',prop:'Visible'},{av:'edtSecUserFullName_Visible',ctrl:'SECUSERFULLNAME',prop:'Visible'},{av:'edtusuariosId_Visible',ctrl:'USUARIOSID',prop:'Visible'},{av:'edtusuariosNombre_Visible',ctrl:'USUARIOSNOMBRE',prop:'Visible'},{av:'cmbusuariosEstado'},{av:'edtusuariosImagen_Visible',ctrl:'USUARIOSIMAGEN',prop:'Visible'},{av:'cmbSecUserEstado'},{av:'edtSecUserPassword_Visible',ctrl:'SECUSERPASSWORD',prop:'Visible'},{av:'AV79GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV80GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtavUaassociateroles_Columnheaderclass',ctrl:'vUAASSOCIATEROLES',prop:'Columnheaderclass'},{av:'edtSecUserId_Columnheaderclass',ctrl:'SECUSERID',prop:'Columnheaderclass'},{av:'edtSecUserName_Columnheaderclass',ctrl:'SECUSERNAME',prop:'Columnheaderclass'},{av:'edtSecUserFullName_Columnheaderclass',ctrl:'SECUSERFULLNAME',prop:'Columnheaderclass'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtusuariosImagen_Columnheaderclass',ctrl:'USUARIOSIMAGEN',prop:'Columnheaderclass'},{av:'edtSecUserPassword_Columnheaderclass',ctrl:'SECUSERPASSWORD',prop:'Columnheaderclass'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'edtavUaassociateroles_Visible',ctrl:'vUAASSOCIATEROLES',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E130U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E150U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV97TFSecUserEstado_SelsJson',fld:'vTFSECUSERESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV95TFusuariosEstado_SelsJson',fld:'vTFUSUARIOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E300U2',iparms:[{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'A145usuariosId',fld:'USUARIOSID',pic:'',type:'char'},{av:'cmbSecUserEstado'},{av:'A550SecUserEstado',fld:'SECUSERESTADO',pic:'',type:'char'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV99GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'AV15UAAssociateRoles',fld:'vUAASSOCIATEROLES',pic:'',type:'bits'},{av:'edtavUaassociateroles_Tooltiptext',ctrl:'vUAASSOCIATEROLES',prop:'Tooltiptext'},{av:'edtavUaassociateroles_Link',ctrl:'vUAASSOCIATEROLES',prop:'Link'},{av:'edtSecUserName_Link',ctrl:'SECUSERNAME',prop:'Link'},{av:'edtusuariosId_Link',ctrl:'USUARIOSID',prop:'Link'},{av:'edtavUaassociateroles_Columnclass',ctrl:'vUAASSOCIATEROLES',prop:'Columnclass'},{av:'edtSecUserId_Columnclass',ctrl:'SECUSERID',prop:'Columnclass'},{av:'edtSecUserName_Columnclass',ctrl:'SECUSERNAME',prop:'Columnclass'},{av:'edtSecUserFullName_Columnclass',ctrl:'SECUSERFULLNAME',prop:'Columnclass'},{av:'edtusuariosId_Columnclass',ctrl:'USUARIOSID',prop:'Columnclass'},{av:'edtusuariosNombre_Columnclass',ctrl:'USUARIOSNOMBRE',prop:'Columnclass'},{av:'cmbusuariosEstado'},{av:'edtusuariosImagen_Columnclass',ctrl:'USUARIOSIMAGEN',prop:'Columnclass'},{av:'cmbSecUserEstado'},{av:'edtSecUserPassword_Columnclass',ctrl:'SECUSERPASSWORD',prop:'Columnclass'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E160U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtSecUserId_Visible',ctrl:'SECUSERID',prop:'Visible'},{av:'edtSecUserName_Visible',ctrl:'SECUSERNAME',prop:'Visible'},{av:'edtSecUserFullName_Visible',ctrl:'SECUSERFULLNAME',prop:'Visible'},{av:'edtusuariosId_Visible',ctrl:'USUARIOSID',prop:'Visible'},{av:'edtusuariosNombre_Visible',ctrl:'USUARIOSNOMBRE',prop:'Visible'},{av:'cmbusuariosEstado'},{av:'edtusuariosImagen_Visible',ctrl:'USUARIOSIMAGEN',prop:'Visible'},{av:'cmbSecUserEstado'},{av:'edtSecUserPassword_Visible',ctrl:'SECUSERPASSWORD',prop:'Visible'},{av:'AV79GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV80GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtavUaassociateroles_Columnheaderclass',ctrl:'vUAASSOCIATEROLES',prop:'Columnheaderclass'},{av:'edtSecUserId_Columnheaderclass',ctrl:'SECUSERID',prop:'Columnheaderclass'},{av:'edtSecUserName_Columnheaderclass',ctrl:'SECUSERNAME',prop:'Columnheaderclass'},{av:'edtSecUserFullName_Columnheaderclass',ctrl:'SECUSERFULLNAME',prop:'Columnheaderclass'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtusuariosImagen_Columnheaderclass',ctrl:'USUARIOSIMAGEN',prop:'Columnheaderclass'},{av:'edtSecUserPassword_Columnheaderclass',ctrl:'SECUSERPASSWORD',prop:'Columnheaderclass'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'edtavUaassociateroles_Visible',ctrl:'vUAASSOCIATEROLES',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E230U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtSecUserId_Visible',ctrl:'SECUSERID',prop:'Visible'},{av:'edtSecUserName_Visible',ctrl:'SECUSERNAME',prop:'Visible'},{av:'edtSecUserFullName_Visible',ctrl:'SECUSERFULLNAME',prop:'Visible'},{av:'edtusuariosId_Visible',ctrl:'USUARIOSID',prop:'Visible'},{av:'edtusuariosNombre_Visible',ctrl:'USUARIOSNOMBRE',prop:'Visible'},{av:'cmbusuariosEstado'},{av:'edtusuariosImagen_Visible',ctrl:'USUARIOSIMAGEN',prop:'Visible'},{av:'cmbSecUserEstado'},{av:'edtSecUserPassword_Visible',ctrl:'SECUSERPASSWORD',prop:'Visible'},{av:'AV79GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV80GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtavUaassociateroles_Columnheaderclass',ctrl:'vUAASSOCIATEROLES',prop:'Columnheaderclass'},{av:'edtSecUserId_Columnheaderclass',ctrl:'SECUSERID',prop:'Columnheaderclass'},{av:'edtSecUserName_Columnheaderclass',ctrl:'SECUSERNAME',prop:'Columnheaderclass'},{av:'edtSecUserFullName_Columnheaderclass',ctrl:'SECUSERFULLNAME',prop:'Columnheaderclass'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtusuariosImagen_Columnheaderclass',ctrl:'USUARIOSIMAGEN',prop:'Columnheaderclass'},{av:'edtSecUserPassword_Columnheaderclass',ctrl:'SECUSERPASSWORD',prop:'Columnheaderclass'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'edtavUaassociateroles_Visible',ctrl:'vUAASSOCIATEROLES',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E190U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'edtavSecusername2_Visible',ctrl:'vSECUSERNAME2',prop:'Visible'},{av:'edtavUsuariosid2_Visible',ctrl:'vUSUARIOSID2',prop:'Visible'},{av:'edtavSecusername3_Visible',ctrl:'vSECUSERNAME3',prop:'Visible'},{av:'edtavUsuariosid3_Visible',ctrl:'vUSUARIOSID3',prop:'Visible'},{av:'edtavSecusername1_Visible',ctrl:'vSECUSERNAME1',prop:'Visible'},{av:'edtavUsuariosid1_Visible',ctrl:'vUSUARIOSID1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtSecUserId_Visible',ctrl:'SECUSERID',prop:'Visible'},{av:'edtSecUserName_Visible',ctrl:'SECUSERNAME',prop:'Visible'},{av:'edtSecUserFullName_Visible',ctrl:'SECUSERFULLNAME',prop:'Visible'},{av:'edtusuariosId_Visible',ctrl:'USUARIOSID',prop:'Visible'},{av:'edtusuariosNombre_Visible',ctrl:'USUARIOSNOMBRE',prop:'Visible'},{av:'cmbusuariosEstado'},{av:'edtusuariosImagen_Visible',ctrl:'USUARIOSIMAGEN',prop:'Visible'},{av:'cmbSecUserEstado'},{av:'edtSecUserPassword_Visible',ctrl:'SECUSERPASSWORD',prop:'Visible'},{av:'AV79GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV80GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtavUaassociateroles_Columnheaderclass',ctrl:'vUAASSOCIATEROLES',prop:'Columnheaderclass'},{av:'edtSecUserId_Columnheaderclass',ctrl:'SECUSERID',prop:'Columnheaderclass'},{av:'edtSecUserName_Columnheaderclass',ctrl:'SECUSERNAME',prop:'Columnheaderclass'},{av:'edtSecUserFullName_Columnheaderclass',ctrl:'SECUSERFULLNAME',prop:'Columnheaderclass'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtusuariosImagen_Columnheaderclass',ctrl:'USUARIOSIMAGEN',prop:'Columnheaderclass'},{av:'edtSecUserPassword_Columnheaderclass',ctrl:'SECUSERPASSWORD',prop:'Columnheaderclass'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'edtavUaassociateroles_Visible',ctrl:'vUAASSOCIATEROLES',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E240U2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'edtavSecusername1_Visible',ctrl:'vSECUSERNAME1',prop:'Visible'},{av:'edtavUsuariosid1_Visible',ctrl:'vUSUARIOSID1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E250U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtSecUserId_Visible',ctrl:'SECUSERID',prop:'Visible'},{av:'edtSecUserName_Visible',ctrl:'SECUSERNAME',prop:'Visible'},{av:'edtSecUserFullName_Visible',ctrl:'SECUSERFULLNAME',prop:'Visible'},{av:'edtusuariosId_Visible',ctrl:'USUARIOSID',prop:'Visible'},{av:'edtusuariosNombre_Visible',ctrl:'USUARIOSNOMBRE',prop:'Visible'},{av:'cmbusuariosEstado'},{av:'edtusuariosImagen_Visible',ctrl:'USUARIOSIMAGEN',prop:'Visible'},{av:'cmbSecUserEstado'},{av:'edtSecUserPassword_Visible',ctrl:'SECUSERPASSWORD',prop:'Visible'},{av:'AV79GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV80GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtavUaassociateroles_Columnheaderclass',ctrl:'vUAASSOCIATEROLES',prop:'Columnheaderclass'},{av:'edtSecUserId_Columnheaderclass',ctrl:'SECUSERID',prop:'Columnheaderclass'},{av:'edtSecUserName_Columnheaderclass',ctrl:'SECUSERNAME',prop:'Columnheaderclass'},{av:'edtSecUserFullName_Columnheaderclass',ctrl:'SECUSERFULLNAME',prop:'Columnheaderclass'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtusuariosImagen_Columnheaderclass',ctrl:'USUARIOSIMAGEN',prop:'Columnheaderclass'},{av:'edtSecUserPassword_Columnheaderclass',ctrl:'SECUSERPASSWORD',prop:'Columnheaderclass'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'edtavUaassociateroles_Visible',ctrl:'vUAASSOCIATEROLES',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E200U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'edtavSecusername2_Visible',ctrl:'vSECUSERNAME2',prop:'Visible'},{av:'edtavUsuariosid2_Visible',ctrl:'vUSUARIOSID2',prop:'Visible'},{av:'edtavSecusername3_Visible',ctrl:'vSECUSERNAME3',prop:'Visible'},{av:'edtavUsuariosid3_Visible',ctrl:'vUSUARIOSID3',prop:'Visible'},{av:'edtavSecusername1_Visible',ctrl:'vSECUSERNAME1',prop:'Visible'},{av:'edtavUsuariosid1_Visible',ctrl:'vUSUARIOSID1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtSecUserId_Visible',ctrl:'SECUSERID',prop:'Visible'},{av:'edtSecUserName_Visible',ctrl:'SECUSERNAME',prop:'Visible'},{av:'edtSecUserFullName_Visible',ctrl:'SECUSERFULLNAME',prop:'Visible'},{av:'edtusuariosId_Visible',ctrl:'USUARIOSID',prop:'Visible'},{av:'edtusuariosNombre_Visible',ctrl:'USUARIOSNOMBRE',prop:'Visible'},{av:'cmbusuariosEstado'},{av:'edtusuariosImagen_Visible',ctrl:'USUARIOSIMAGEN',prop:'Visible'},{av:'cmbSecUserEstado'},{av:'edtSecUserPassword_Visible',ctrl:'SECUSERPASSWORD',prop:'Visible'},{av:'AV79GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV80GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtavUaassociateroles_Columnheaderclass',ctrl:'vUAASSOCIATEROLES',prop:'Columnheaderclass'},{av:'edtSecUserId_Columnheaderclass',ctrl:'SECUSERID',prop:'Columnheaderclass'},{av:'edtSecUserName_Columnheaderclass',ctrl:'SECUSERNAME',prop:'Columnheaderclass'},{av:'edtSecUserFullName_Columnheaderclass',ctrl:'SECUSERFULLNAME',prop:'Columnheaderclass'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtusuariosImagen_Columnheaderclass',ctrl:'USUARIOSIMAGEN',prop:'Columnheaderclass'},{av:'edtSecUserPassword_Columnheaderclass',ctrl:'SECUSERPASSWORD',prop:'Columnheaderclass'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'edtavUaassociateroles_Visible',ctrl:'vUAASSOCIATEROLES',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E260U2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'edtavSecusername2_Visible',ctrl:'vSECUSERNAME2',prop:'Visible'},{av:'edtavUsuariosid2_Visible',ctrl:'vUSUARIOSID2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E210U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'edtavSecusername2_Visible',ctrl:'vSECUSERNAME2',prop:'Visible'},{av:'edtavUsuariosid2_Visible',ctrl:'vUSUARIOSID2',prop:'Visible'},{av:'edtavSecusername3_Visible',ctrl:'vSECUSERNAME3',prop:'Visible'},{av:'edtavUsuariosid3_Visible',ctrl:'vUSUARIOSID3',prop:'Visible'},{av:'edtavSecusername1_Visible',ctrl:'vSECUSERNAME1',prop:'Visible'},{av:'edtavUsuariosid1_Visible',ctrl:'vUSUARIOSID1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtSecUserId_Visible',ctrl:'SECUSERID',prop:'Visible'},{av:'edtSecUserName_Visible',ctrl:'SECUSERNAME',prop:'Visible'},{av:'edtSecUserFullName_Visible',ctrl:'SECUSERFULLNAME',prop:'Visible'},{av:'edtusuariosId_Visible',ctrl:'USUARIOSID',prop:'Visible'},{av:'edtusuariosNombre_Visible',ctrl:'USUARIOSNOMBRE',prop:'Visible'},{av:'cmbusuariosEstado'},{av:'edtusuariosImagen_Visible',ctrl:'USUARIOSIMAGEN',prop:'Visible'},{av:'cmbSecUserEstado'},{av:'edtSecUserPassword_Visible',ctrl:'SECUSERPASSWORD',prop:'Visible'},{av:'AV79GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV80GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtavUaassociateroles_Columnheaderclass',ctrl:'vUAASSOCIATEROLES',prop:'Columnheaderclass'},{av:'edtSecUserId_Columnheaderclass',ctrl:'SECUSERID',prop:'Columnheaderclass'},{av:'edtSecUserName_Columnheaderclass',ctrl:'SECUSERNAME',prop:'Columnheaderclass'},{av:'edtSecUserFullName_Columnheaderclass',ctrl:'SECUSERFULLNAME',prop:'Columnheaderclass'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtusuariosImagen_Columnheaderclass',ctrl:'USUARIOSIMAGEN',prop:'Columnheaderclass'},{av:'edtSecUserPassword_Columnheaderclass',ctrl:'SECUSERPASSWORD',prop:'Columnheaderclass'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'edtavUaassociateroles_Visible',ctrl:'vUAASSOCIATEROLES',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E270U2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'edtavSecusername3_Visible',ctrl:'vSECUSERNAME3',prop:'Visible'},{av:'edtavUsuariosid3_Visible',ctrl:'vUSUARIOSID3',prop:'Visible'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E110U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV95TFusuariosEstado_SelsJson',fld:'vTFUSUARIOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV97TFSecUserEstado_SelsJson',fld:'vTFSECUSERESTADO_SELSJSON',pic:'',type:'vchar'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV97TFSecUserEstado_SelsJson',fld:'vTFSECUSERESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV95TFusuariosEstado_SelsJson',fld:'vTFUSUARIOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'edtavSecusername1_Visible',ctrl:'vSECUSERNAME1',prop:'Visible'},{av:'edtavUsuariosid1_Visible',ctrl:'vUSUARIOSID1',prop:'Visible'},{av:'edtavSecusername2_Visible',ctrl:'vSECUSERNAME2',prop:'Visible'},{av:'edtavUsuariosid2_Visible',ctrl:'vUSUARIOSID2',prop:'Visible'},{av:'edtavSecusername3_Visible',ctrl:'vSECUSERNAME3',prop:'Visible'},{av:'edtavUsuariosid3_Visible',ctrl:'vUSUARIOSID3',prop:'Visible'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtSecUserId_Visible',ctrl:'SECUSERID',prop:'Visible'},{av:'edtSecUserName_Visible',ctrl:'SECUSERNAME',prop:'Visible'},{av:'edtSecUserFullName_Visible',ctrl:'SECUSERFULLNAME',prop:'Visible'},{av:'edtusuariosId_Visible',ctrl:'USUARIOSID',prop:'Visible'},{av:'edtusuariosNombre_Visible',ctrl:'USUARIOSNOMBRE',prop:'Visible'},{av:'cmbusuariosEstado'},{av:'edtusuariosImagen_Visible',ctrl:'USUARIOSIMAGEN',prop:'Visible'},{av:'cmbSecUserEstado'},{av:'edtSecUserPassword_Visible',ctrl:'SECUSERPASSWORD',prop:'Visible'},{av:'AV79GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV80GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtavUaassociateroles_Columnheaderclass',ctrl:'vUAASSOCIATEROLES',prop:'Columnheaderclass'},{av:'edtSecUserId_Columnheaderclass',ctrl:'SECUSERID',prop:'Columnheaderclass'},{av:'edtSecUserName_Columnheaderclass',ctrl:'SECUSERNAME',prop:'Columnheaderclass'},{av:'edtSecUserFullName_Columnheaderclass',ctrl:'SECUSERFULLNAME',prop:'Columnheaderclass'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtusuariosImagen_Columnheaderclass',ctrl:'USUARIOSIMAGEN',prop:'Columnheaderclass'},{av:'edtSecUserPassword_Columnheaderclass',ctrl:'SECUSERPASSWORD',prop:'Columnheaderclass'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'edtavUaassociateroles_Visible',ctrl:'vUAASSOCIATEROLES',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E310U2',iparms:[{av:'cmbavGridactions'},{av:'AV99GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'},{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV99GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("DESENCRIPTAR_MODAL.ONLOADCOMPONENT","{handler:'E180U2',iparms:[{av:'A27SecUserPassword',fld:'SECUSERPASSWORD',pic:'',hsh:true,type:'svchar'}]");
         setEventMetadata("DESENCRIPTAR_MODAL.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("DESENCRIPTAR_MODAL.CLOSE","{handler:'E170U2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DESENCRIPTAR_MODAL.CLOSE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtSecUserId_Visible',ctrl:'SECUSERID',prop:'Visible'},{av:'edtSecUserName_Visible',ctrl:'SECUSERNAME',prop:'Visible'},{av:'edtSecUserFullName_Visible',ctrl:'SECUSERFULLNAME',prop:'Visible'},{av:'edtusuariosId_Visible',ctrl:'USUARIOSID',prop:'Visible'},{av:'edtusuariosNombre_Visible',ctrl:'USUARIOSNOMBRE',prop:'Visible'},{av:'cmbusuariosEstado'},{av:'edtusuariosImagen_Visible',ctrl:'USUARIOSIMAGEN',prop:'Visible'},{av:'cmbSecUserEstado'},{av:'edtSecUserPassword_Visible',ctrl:'SECUSERPASSWORD',prop:'Visible'},{av:'AV79GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV80GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtavUaassociateroles_Columnheaderclass',ctrl:'vUAASSOCIATEROLES',prop:'Columnheaderclass'},{av:'edtSecUserId_Columnheaderclass',ctrl:'SECUSERID',prop:'Columnheaderclass'},{av:'edtSecUserName_Columnheaderclass',ctrl:'SECUSERNAME',prop:'Columnheaderclass'},{av:'edtSecUserFullName_Columnheaderclass',ctrl:'SECUSERFULLNAME',prop:'Columnheaderclass'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtusuariosImagen_Columnheaderclass',ctrl:'USUARIOSIMAGEN',prop:'Columnheaderclass'},{av:'edtSecUserPassword_Columnheaderclass',ctrl:'SECUSERPASSWORD',prop:'Columnheaderclass'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'edtavUaassociateroles_Visible',ctrl:'vUAASSOCIATEROLES',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E220U2',iparms:[{av:'A18SecUserId',fld:'SECUSERID',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E140U2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV95TFusuariosEstado_SelsJson',fld:'vTFUSUARIOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV97TFSecUserEstado_SelsJson',fld:'vTFSECUSERESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV20GridState',fld:'vGRIDSTATE',pic:''},{av:'AV23OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV24OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'cmbavDynamicfiltersselector1'},{av:'AV25DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV26DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9',type:'int'},{av:'AV27SecUserName1',fld:'vSECUSERNAME1',pic:'',type:'svchar'},{av:'AV86usuariosId1',fld:'vUSUARIOSID1',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector2'},{av:'AV29DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV30DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9',type:'int'},{av:'AV31SecUserName2',fld:'vSECUSERNAME2',pic:'',type:'svchar'},{av:'AV87usuariosId2',fld:'vUSUARIOSID2',pic:'',type:'char'},{av:'cmbavDynamicfiltersselector3'},{av:'AV33DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:'',type:'svchar'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV34DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9',type:'int'},{av:'AV35SecUserName3',fld:'vSECUSERNAME3',pic:'',type:'svchar'},{av:'AV88usuariosId3',fld:'vUSUARIOSID3',pic:'',type:'char'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV28DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:'',type:'boolean'},{av:'AV32DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:'',type:'boolean'},{av:'AV70ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV104Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV83FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV47TFSecUserId',fld:'vTFSECUSERID',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV48TFSecUserId_To',fld:'vTFSECUSERID_TO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV51TFSecUserName',fld:'vTFSECUSERNAME',pic:'',type:'svchar'},{av:'AV52TFSecUserName_Sel',fld:'vTFSECUSERNAME_SEL',pic:'',type:'svchar'},{av:'AV89TFSecUserFullName',fld:'vTFSECUSERFULLNAME',pic:'',type:'svchar'},{av:'AV90TFSecUserFullName_Sel',fld:'vTFSECUSERFULLNAME_SEL',pic:'',type:'svchar'},{av:'AV91TFusuariosId',fld:'vTFUSUARIOSID',pic:'',type:'char'},{av:'AV92TFusuariosId_Sel',fld:'vTFUSUARIOSID_SEL',pic:'',type:'char'},{av:'AV93TFusuariosNombre',fld:'vTFUSUARIOSNOMBRE',pic:'',type:'char'},{av:'AV94TFusuariosNombre_Sel',fld:'vTFUSUARIOSNOMBRE_SEL',pic:'',type:'char'},{av:'AV96TFusuariosEstado_Sels',fld:'vTFUSUARIOSESTADO_SELS',pic:''},{av:'AV98TFSecUserEstado_Sels',fld:'vTFSECUSERESTADO_SELS',pic:''},{av:'AV101TFSecUserPassword',fld:'vTFSECUSERPASSWORD',pic:'',type:'svchar'},{av:'AV102TFSecUserPassword_Sel',fld:'vTFSECUSERPASSWORD_SEL',pic:'',type:'svchar'},{av:'AV37DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',type:'boolean'},{av:'AV36DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',type:'boolean'},{av:'edtavUaassociateroles_Title',ctrl:'vUAASSOCIATEROLES',prop:'Title'},{av:'AV17IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV18IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'AV103IsAuthorized_Desencriptar',fld:'vISAUTHORIZED_DESENCRIPTAR',pic:'',hsh:true,type:'boolean'},{av:'AV16IsAuthorized_UAAssociateRoles',fld:'vISAUTHORIZED_UAASSOCIATEROLES',pic:'',hsh:true,type:'boolean'},{av:'AV100IsAuthorized_usuariosId',fld:'vISAUTHORIZED_USUARIOSID',pic:'',hsh:true,type:'boolean'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV97TFSecUserEstado_SelsJson',fld:'vTFSECUSERESTADO_SELSJSON',pic:'',type:'vchar'},{av:'AV95TFusuariosEstado_SelsJson',fld:'vTFUSUARIOSESTADO_SELSJSON',pic:'',type:'vchar'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavSecusername1_Visible',ctrl:'vSECUSERNAME1',prop:'Visible'},{av:'edtavUsuariosid1_Visible',ctrl:'vUSUARIOSID1',prop:'Visible'},{av:'edtavSecusername2_Visible',ctrl:'vSECUSERNAME2',prop:'Visible'},{av:'edtavUsuariosid2_Visible',ctrl:'vUSUARIOSID2',prop:'Visible'},{av:'edtavSecusername3_Visible',ctrl:'vSECUSERNAME3',prop:'Visible'},{av:'edtavUsuariosid3_Visible',ctrl:'vUSUARIOSID3',prop:'Visible'},{av:'edtSecUserId_Visible',ctrl:'SECUSERID',prop:'Visible'},{av:'edtSecUserName_Visible',ctrl:'SECUSERNAME',prop:'Visible'},{av:'edtSecUserFullName_Visible',ctrl:'SECUSERFULLNAME',prop:'Visible'},{av:'edtusuariosId_Visible',ctrl:'USUARIOSID',prop:'Visible'},{av:'edtusuariosNombre_Visible',ctrl:'USUARIOSNOMBRE',prop:'Visible'},{av:'cmbusuariosEstado'},{av:'edtusuariosImagen_Visible',ctrl:'USUARIOSIMAGEN',prop:'Visible'},{av:'cmbSecUserEstado'},{av:'edtSecUserPassword_Visible',ctrl:'SECUSERPASSWORD',prop:'Visible'},{av:'AV79GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV80GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV82GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'cmbavGridactions'},{av:'edtavUaassociateroles_Columnheaderclass',ctrl:'vUAASSOCIATEROLES',prop:'Columnheaderclass'},{av:'edtSecUserId_Columnheaderclass',ctrl:'SECUSERID',prop:'Columnheaderclass'},{av:'edtSecUserName_Columnheaderclass',ctrl:'SECUSERNAME',prop:'Columnheaderclass'},{av:'edtSecUserFullName_Columnheaderclass',ctrl:'SECUSERFULLNAME',prop:'Columnheaderclass'},{av:'edtusuariosId_Columnheaderclass',ctrl:'USUARIOSID',prop:'Columnheaderclass'},{av:'edtusuariosNombre_Columnheaderclass',ctrl:'USUARIOSNOMBRE',prop:'Columnheaderclass'},{av:'edtusuariosImagen_Columnheaderclass',ctrl:'USUARIOSIMAGEN',prop:'Columnheaderclass'},{av:'edtSecUserPassword_Columnheaderclass',ctrl:'SECUSERPASSWORD',prop:'Columnheaderclass'},{av:'edtavUaassociateroles_Visible',ctrl:'vUAASSOCIATEROLES',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV44ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VALID_SECUSERID","{handler:'Valid_Secuserid',iparms:[]");
         setEventMetadata("VALID_SECUSERID",",oparms:[]}");
         setEventMetadata("VALID_SECUSERNAME","{handler:'Valid_Secusername',iparms:[]");
         setEventMetadata("VALID_SECUSERNAME",",oparms:[]}");
         setEventMetadata("VALID_SECUSERFULLNAME","{handler:'Valid_Secuserfullname',iparms:[]");
         setEventMetadata("VALID_SECUSERFULLNAME",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSID","{handler:'Valid_Usuariosid',iparms:[]");
         setEventMetadata("VALID_USUARIOSID",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSNOMBRE","{handler:'Valid_Usuariosnombre',iparms:[]");
         setEventMetadata("VALID_USUARIOSNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSESTADO","{handler:'Valid_Usuariosestado',iparms:[]");
         setEventMetadata("VALID_USUARIOSESTADO",",oparms:[]}");
         setEventMetadata("VALID_SECUSERESTADO","{handler:'Valid_Secuserestado',iparms:[]");
         setEventMetadata("VALID_SECUSERESTADO",",oparms:[]}");
         setEventMetadata("VALID_SECUSERPASSWORD","{handler:'Valid_Secuserpassword',iparms:[]");
         setEventMetadata("VALID_SECUSERPASSWORD",",oparms:[]}");
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
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV25DynamicFiltersSelector1 = "";
         AV27SecUserName1 = "";
         AV86usuariosId1 = "";
         AV29DynamicFiltersSelector2 = "";
         AV31SecUserName2 = "";
         AV87usuariosId2 = "";
         AV33DynamicFiltersSelector3 = "";
         AV35SecUserName3 = "";
         AV88usuariosId3 = "";
         AV70ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV104Pgmname = "";
         AV83FilterFullText = "";
         AV51TFSecUserName = "";
         AV52TFSecUserName_Sel = "";
         AV89TFSecUserFullName = "";
         AV90TFSecUserFullName_Sel = "";
         AV91TFusuariosId = "";
         AV92TFusuariosId_Sel = "";
         AV93TFusuariosNombre = "";
         AV94TFusuariosNombre_Sel = "";
         AV96TFusuariosEstado_Sels = new GxSimpleCollection<string>();
         AV98TFSecUserEstado_Sels = new GxSimpleCollection<string>();
         AV101TFSecUserPassword = "";
         AV102TFSecUserPassword_Sel = "";
         AV20GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV44ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV82GridAppliedFilters = "";
         AV84AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV54DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV95TFusuariosEstado_SelsJson = "";
         AV97TFSecUserEstado_SelsJson = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV15UAAssociateRoles = "";
         AV134Uaassociateroles_GXI = "";
         A26SecUserName = "";
         A587SecUserFullName = "";
         A145usuariosId = "";
         A222usuariosNombre = "";
         A226usuariosEstado = "";
         A266usuariosImagen = "";
         A40000usuariosImagen_GXI = "";
         A550SecUserEstado = "";
         A27SecUserPassword = "";
         AV105Wwpbaseobjects_secuserwwds_1_filterfulltext = "";
         AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = "";
         AV108Wwpbaseobjects_secuserwwds_4_secusername1 = "";
         AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = "";
         AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = "";
         AV113Wwpbaseobjects_secuserwwds_9_secusername2 = "";
         AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = "";
         AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = "";
         AV118Wwpbaseobjects_secuserwwds_14_secusername3 = "";
         AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = "";
         AV122Wwpbaseobjects_secuserwwds_18_tfsecusername = "";
         AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = "";
         AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = "";
         AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = "";
         AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid = "";
         AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = "";
         AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = "";
         AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = "";
         AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = new GxSimpleCollection<string>();
         AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = new GxSimpleCollection<string>();
         AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = "";
         AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = "";
         lV105Wwpbaseobjects_secuserwwds_1_filterfulltext = "";
         lV108Wwpbaseobjects_secuserwwds_4_secusername1 = "";
         lV109Wwpbaseobjects_secuserwwds_5_usuariosid1 = "";
         lV113Wwpbaseobjects_secuserwwds_9_secusername2 = "";
         lV114Wwpbaseobjects_secuserwwds_10_usuariosid2 = "";
         lV118Wwpbaseobjects_secuserwwds_14_secusername3 = "";
         lV119Wwpbaseobjects_secuserwwds_15_usuariosid3 = "";
         lV122Wwpbaseobjects_secuserwwds_18_tfsecusername = "";
         lV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = "";
         lV126Wwpbaseobjects_secuserwwds_22_tfusuariosid = "";
         lV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = "";
         lV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = "";
         H000U2_A27SecUserPassword = new string[] {""} ;
         H000U2_A550SecUserEstado = new string[] {""} ;
         H000U2_n550SecUserEstado = new bool[] {false} ;
         H000U2_A40000usuariosImagen_GXI = new string[] {""} ;
         H000U2_A226usuariosEstado = new string[] {""} ;
         H000U2_A222usuariosNombre = new string[] {""} ;
         H000U2_A145usuariosId = new string[] {""} ;
         H000U2_n145usuariosId = new bool[] {false} ;
         H000U2_A587SecUserFullName = new string[] {""} ;
         H000U2_A26SecUserName = new string[] {""} ;
         H000U2_A18SecUserId = new long[1] ;
         H000U2_A266usuariosImagen = new string[] {""} ;
         H000U3_A27SecUserPassword = new string[] {""} ;
         H000U3_A550SecUserEstado = new string[] {""} ;
         H000U3_n550SecUserEstado = new bool[] {false} ;
         H000U3_A40000usuariosImagen_GXI = new string[] {""} ;
         H000U3_A226usuariosEstado = new string[] {""} ;
         H000U3_A222usuariosNombre = new string[] {""} ;
         H000U3_A145usuariosId = new string[] {""} ;
         H000U3_n145usuariosId = new bool[] {false} ;
         H000U3_A587SecUserFullName = new string[] {""} ;
         H000U3_A26SecUserName = new string[] {""} ;
         H000U3_A18SecUserId = new long[1] ;
         H000U3_A266usuariosImagen = new string[] {""} ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV85AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV77WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14Session = context.GetSession();
         AV58ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV41ManageFiltersXml = "";
         AV65UserCustomValue = "";
         AV81ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV21GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char3 = "";
         GXt_char5 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         AV22GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV38ExcelFilename = "";
         AV39ErrorMessage = "";
         ucDesencriptar_modal = new GXUserControl();
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuserww__default(),
            new Object[][] {
                new Object[] {
               H000U2_A27SecUserPassword, H000U2_A550SecUserEstado, H000U2_n550SecUserEstado, H000U2_A40000usuariosImagen_GXI, H000U2_A226usuariosEstado, H000U2_A222usuariosNombre, H000U2_A145usuariosId, H000U2_n145usuariosId, H000U2_A587SecUserFullName, H000U2_A26SecUserName,
               H000U2_A18SecUserId, H000U2_A266usuariosImagen
               }
               , new Object[] {
               H000U3_A27SecUserPassword, H000U3_A550SecUserEstado, H000U3_n550SecUserEstado, H000U3_A40000usuariosImagen_GXI, H000U3_A226usuariosEstado, H000U3_A222usuariosNombre, H000U3_A145usuariosId, H000U3_n145usuariosId, H000U3_A587SecUserFullName, H000U3_A26SecUserName,
               H000U3_A18SecUserId, H000U3_A266usuariosImagen
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV104Pgmname = "WWPBaseObjects.SecUserWW";
         /* GeneXus formulas. */
         AV104Pgmname = "WWPBaseObjects.SecUserWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV23OrderedBy ;
      private short AV26DynamicFiltersOperator1 ;
      private short AV30DynamicFiltersOperator2 ;
      private short AV34DynamicFiltersOperator3 ;
      private short AV40ManageFiltersExecutionStep ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV99GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ;
      private short AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ;
      private short AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ;
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
      private int nRC_GXsfl_118 ;
      private int nGXsfl_118_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int subGrid_Islastpage ;
      private int AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ;
      private int AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ;
      private int edtSecUserId_Enabled ;
      private int edtSecUserName_Enabled ;
      private int edtSecUserFullName_Enabled ;
      private int edtusuariosId_Enabled ;
      private int edtusuariosNombre_Enabled ;
      private int edtusuariosImagen_Enabled ;
      private int edtSecUserPassword_Enabled ;
      private int edtSecUserId_Visible ;
      private int edtSecUserName_Visible ;
      private int edtSecUserFullName_Visible ;
      private int edtusuariosId_Visible ;
      private int edtusuariosNombre_Visible ;
      private int edtusuariosImagen_Visible ;
      private int edtSecUserPassword_Visible ;
      private int AV78PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavUaassociateroles_Visible ;
      private int edtavSecusername1_Visible ;
      private int edtavUsuariosid1_Visible ;
      private int edtavSecusername2_Visible ;
      private int edtavUsuariosid2_Visible ;
      private int edtavSecusername3_Visible ;
      private int edtavUsuariosid3_Visible ;
      private int AV135GXV1 ;
      private int edtavSecusername3_Enabled ;
      private int edtavUsuariosid3_Enabled ;
      private int edtavSecusername2_Enabled ;
      private int edtavUsuariosid2_Enabled ;
      private int edtavSecusername1_Enabled ;
      private int edtavUsuariosid1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV47TFSecUserId ;
      private long AV48TFSecUserId_To ;
      private long AV79GridCurrentPage ;
      private long AV80GridPageCount ;
      private long A18SecUserId ;
      private long GRID_nCurrentRecord ;
      private long AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid ;
      private long AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ;
      private long GRID_nRecordCount ;
      private string edtavUaassociateroles_Title ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_118_idx="0001" ;
      private string edtavUaassociateroles_Internalname ;
      private string AV86usuariosId1 ;
      private string AV87usuariosId2 ;
      private string AV88usuariosId3 ;
      private string AV104Pgmname ;
      private string AV91TFusuariosId ;
      private string AV92TFusuariosId_Sel ;
      private string AV93TFusuariosNombre ;
      private string AV94TFusuariosNombre_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
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
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
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
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Desencriptar_modal_Width ;
      private string Desencriptar_modal_Title ;
      private string Desencriptar_modal_Confirmtype ;
      private string Desencriptar_modal_Bodytype ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string divAdvancedfilterscontainer_Internalname ;
      private string divTabledynamicfilters_Internalname ;
      private string divTabledynamicfiltersrow1_Internalname ;
      private string lblDynamicfiltersprefix1_Internalname ;
      private string lblDynamicfiltersprefix1_Jsonclick ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersselector1_Jsonclick ;
      private string lblDynamicfiltersmiddle1_Internalname ;
      private string lblDynamicfiltersmiddle1_Jsonclick ;
      private string divTabledynamicfiltersrow2_Internalname ;
      private string lblDynamicfiltersprefix2_Internalname ;
      private string lblDynamicfiltersprefix2_Jsonclick ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersselector2_Jsonclick ;
      private string lblDynamicfiltersmiddle2_Internalname ;
      private string lblDynamicfiltersmiddle2_Jsonclick ;
      private string divTabledynamicfiltersrow3_Internalname ;
      private string lblDynamicfiltersprefix3_Internalname ;
      private string lblDynamicfiltersprefix3_Jsonclick ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersselector3_Jsonclick ;
      private string lblDynamicfiltersmiddle3_Internalname ;
      private string lblDynamicfiltersmiddle3_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtSecUserId_Internalname ;
      private string edtSecUserName_Internalname ;
      private string edtSecUserFullName_Internalname ;
      private string A145usuariosId ;
      private string edtusuariosId_Internalname ;
      private string A222usuariosNombre ;
      private string edtusuariosNombre_Internalname ;
      private string cmbusuariosEstado_Internalname ;
      private string A226usuariosEstado ;
      private string edtusuariosImagen_Internalname ;
      private string cmbSecUserEstado_Internalname ;
      private string A550SecUserEstado ;
      private string edtSecUserPassword_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 ;
      private string AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 ;
      private string AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 ;
      private string AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid ;
      private string AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ;
      private string AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ;
      private string AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ;
      private string lV109Wwpbaseobjects_secuserwwds_5_usuariosid1 ;
      private string lV114Wwpbaseobjects_secuserwwds_10_usuariosid2 ;
      private string lV119Wwpbaseobjects_secuserwwds_15_usuariosid3 ;
      private string lV126Wwpbaseobjects_secuserwwds_22_tfusuariosid ;
      private string lV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ;
      private string edtavSecusername1_Internalname ;
      private string edtavUsuariosid1_Internalname ;
      private string edtavSecusername2_Internalname ;
      private string edtavUsuariosid2_Internalname ;
      private string edtavSecusername3_Internalname ;
      private string edtavUsuariosid3_Internalname ;
      private string imgAdddynamicfilters1_Jsonclick ;
      private string imgAdddynamicfilters1_Internalname ;
      private string imgRemovedynamicfilters1_Jsonclick ;
      private string imgRemovedynamicfilters1_Internalname ;
      private string imgAdddynamicfilters2_Jsonclick ;
      private string imgAdddynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters2_Jsonclick ;
      private string imgRemovedynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters3_Jsonclick ;
      private string imgRemovedynamicfilters3_Internalname ;
      private string cmbavGridactions_Columnheaderclass ;
      private string edtavUaassociateroles_Columnheaderclass ;
      private string edtSecUserId_Columnheaderclass ;
      private string edtSecUserName_Columnheaderclass ;
      private string edtSecUserFullName_Columnheaderclass ;
      private string edtusuariosId_Columnheaderclass ;
      private string edtusuariosNombre_Columnheaderclass ;
      private string cmbusuariosEstado_Columnheaderclass ;
      private string edtusuariosImagen_Columnheaderclass ;
      private string cmbSecUserEstado_Columnheaderclass ;
      private string edtSecUserPassword_Columnheaderclass ;
      private string edtavUaassociateroles_gximage ;
      private string edtavUaassociateroles_Tooltiptext ;
      private string edtavUaassociateroles_Link ;
      private string GXEncryptionTmp ;
      private string edtSecUserName_Link ;
      private string edtusuariosId_Link ;
      private string cmbavGridactions_Columnclass ;
      private string edtavUaassociateroles_Columnclass ;
      private string edtSecUserId_Columnclass ;
      private string edtSecUserName_Columnclass ;
      private string edtSecUserFullName_Columnclass ;
      private string edtusuariosId_Columnclass ;
      private string edtusuariosNombre_Columnclass ;
      private string cmbusuariosEstado_Columnclass ;
      private string edtusuariosImagen_Columnclass ;
      private string cmbSecUserEstado_Columnclass ;
      private string edtSecUserPassword_Columnclass ;
      private string GXt_char3 ;
      private string GXt_char5 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string tblTabledesencriptar_modal_Internalname ;
      private string Desencriptar_modal_Internalname ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_secusername3_cell_Internalname ;
      private string edtavSecusername3_Jsonclick ;
      private string cellFilter_usuariosid3_cell_Internalname ;
      private string edtavUsuariosid3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_secusername2_cell_Internalname ;
      private string edtavSecusername2_Jsonclick ;
      private string cellFilter_usuariosid2_cell_Internalname ;
      private string edtavUsuariosid2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_secusername1_cell_Internalname ;
      private string edtavSecusername1_Jsonclick ;
      private string cellFilter_usuariosid1_cell_Internalname ;
      private string edtavUsuariosid1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_118_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtSecUserId_Jsonclick ;
      private string edtSecUserName_Jsonclick ;
      private string edtSecUserFullName_Jsonclick ;
      private string edtusuariosId_Jsonclick ;
      private string edtusuariosNombre_Jsonclick ;
      private string cmbusuariosEstado_Jsonclick ;
      private string cmbSecUserEstado_Jsonclick ;
      private string edtSecUserPassword_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_118_Refreshing=false ;
      private bool AV24OrderedDsc ;
      private bool AV28DynamicFiltersEnabled2 ;
      private bool AV32DynamicFiltersEnabled3 ;
      private bool AV37DynamicFiltersIgnoreFirst ;
      private bool AV36DynamicFiltersRemoving ;
      private bool AV17IsAuthorized_Update ;
      private bool AV18IsAuthorized_Delete ;
      private bool AV103IsAuthorized_Desencriptar ;
      private bool AV16IsAuthorized_UAAssociateRoles ;
      private bool AV100IsAuthorized_usuariosId ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n145usuariosId ;
      private bool n550SecUserEstado ;
      private bool AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ;
      private bool AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool AV19TempBoolean ;
      private bool GXt_boolean1 ;
      private bool AV15UAAssociateRoles_IsBlob ;
      private bool A266usuariosImagen_IsBlob ;
      private string AV95TFusuariosEstado_SelsJson ;
      private string AV97TFSecUserEstado_SelsJson ;
      private string AV58ColumnsSelectorXML ;
      private string AV41ManageFiltersXml ;
      private string AV65UserCustomValue ;
      private string AV25DynamicFiltersSelector1 ;
      private string AV27SecUserName1 ;
      private string AV29DynamicFiltersSelector2 ;
      private string AV31SecUserName2 ;
      private string AV33DynamicFiltersSelector3 ;
      private string AV35SecUserName3 ;
      private string AV83FilterFullText ;
      private string AV51TFSecUserName ;
      private string AV52TFSecUserName_Sel ;
      private string AV89TFSecUserFullName ;
      private string AV90TFSecUserFullName_Sel ;
      private string AV101TFSecUserPassword ;
      private string AV102TFSecUserPassword_Sel ;
      private string AV82GridAppliedFilters ;
      private string AV134Uaassociateroles_GXI ;
      private string A26SecUserName ;
      private string A587SecUserFullName ;
      private string A40000usuariosImagen_GXI ;
      private string A27SecUserPassword ;
      private string AV105Wwpbaseobjects_secuserwwds_1_filterfulltext ;
      private string AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ;
      private string AV108Wwpbaseobjects_secuserwwds_4_secusername1 ;
      private string AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ;
      private string AV113Wwpbaseobjects_secuserwwds_9_secusername2 ;
      private string AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ;
      private string AV118Wwpbaseobjects_secuserwwds_14_secusername3 ;
      private string AV122Wwpbaseobjects_secuserwwds_18_tfsecusername ;
      private string AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ;
      private string AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ;
      private string AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ;
      private string AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ;
      private string AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ;
      private string lV105Wwpbaseobjects_secuserwwds_1_filterfulltext ;
      private string lV108Wwpbaseobjects_secuserwwds_4_secusername1 ;
      private string lV113Wwpbaseobjects_secuserwwds_9_secusername2 ;
      private string lV118Wwpbaseobjects_secuserwwds_14_secusername3 ;
      private string lV122Wwpbaseobjects_secuserwwds_18_tfsecusername ;
      private string lV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ;
      private string lV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ;
      private string AV38ExcelFilename ;
      private string AV39ErrorMessage ;
      private string AV15UAAssociateRoles ;
      private string A266usuariosImagen ;
      private IGxSession AV14Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDesencriptar_modal ;
      private GXUserControl ucDdo_managefilters ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbusuariosEstado ;
      private GXCombobox cmbSecUserEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV70ColumnsSelector ;
      private GxSimpleCollection<string> AV96TFusuariosEstado_Sels ;
      private GxSimpleCollection<string> AV98TFSecUserEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV20GridState ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV44ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV84AGExportData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV54DDO_TitleSettingsIcons ;
      private GxSimpleCollection<string> AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ;
      private GxSimpleCollection<string> AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] H000U2_A27SecUserPassword ;
      private string[] H000U2_A550SecUserEstado ;
      private bool[] H000U2_n550SecUserEstado ;
      private string[] H000U2_A40000usuariosImagen_GXI ;
      private string[] H000U2_A226usuariosEstado ;
      private string[] H000U2_A222usuariosNombre ;
      private string[] H000U2_A145usuariosId ;
      private bool[] H000U2_n145usuariosId ;
      private string[] H000U2_A587SecUserFullName ;
      private string[] H000U2_A26SecUserName ;
      private long[] H000U2_A18SecUserId ;
      private string[] H000U2_A266usuariosImagen ;
      private string[] H000U3_A27SecUserPassword ;
      private string[] H000U3_A550SecUserEstado ;
      private bool[] H000U3_n550SecUserEstado ;
      private string[] H000U3_A40000usuariosImagen_GXI ;
      private string[] H000U3_A226usuariosEstado ;
      private string[] H000U3_A222usuariosNombre ;
      private string[] H000U3_A145usuariosId ;
      private bool[] H000U3_n145usuariosId ;
      private string[] H000U3_A587SecUserFullName ;
      private string[] H000U3_A26SecUserName ;
      private long[] H000U3_A18SecUserId ;
      private string[] H000U3_A266usuariosImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV85AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV77WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV81ColumnsSelectorAux ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV21GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV22GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secuserww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000U2( IGxContext context ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                             string A550SecUserEstado ,
                                             GxSimpleCollection<string> AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                             string AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                             short AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                             string AV108Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                             string AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                             bool AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                             string AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                             short AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                             string AV113Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                             string AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                             bool AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                             string AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                             short AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                             string AV118Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                             string AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                             long AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                             long AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                             string AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                             string AV122Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                             string AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                             string AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                             string AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                             string AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                             string AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                             string AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                             int AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ,
                                             int AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ,
                                             string AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                             string AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                             string A26SecUserName ,
                                             string A145usuariosId ,
                                             long A18SecUserId ,
                                             string A587SecUserFullName ,
                                             string A222usuariosNombre ,
                                             string A27SecUserPassword ,
                                             short AV23OrderedBy ,
                                             bool AV24OrderedDsc ,
                                             string AV105Wwpbaseobjects_secuserwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[24];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.[SecUserPassword], T1.[SecUserEstado], T2.[usuariosImagen_GXI], T2.[usuariosEstado], T2.[usuariosNombre], T1.[usuariosId], T1.[SecUserFullName], T1.[SecUserName], T1.[SecUserId], T2.[usuariosImagen] FROM ([SecUser] T1 LEFT JOIN [usuarios] T2 ON T2.[usuariosId] = T1.[usuariosId])";
         if ( ( StringUtil.StrCmp(AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV108Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV108Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV109Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV109Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV113Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV113Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV114Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV114Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV118Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV118Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV119Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV119Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! (0==AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] >= @AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! (0==AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] <= @AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wwpbaseobjects_secuserwwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV122Wwpbaseobjects_secuserwwds_18_tfsecusername))");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserName] = @AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( StringUtil.StrCmp(AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserFullName]) like UPPER(@lV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname))");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserFullName] = @AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( StringUtil.StrCmp(AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserFullName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV126Wwpbaseobjects_secuserwwds_22_tfusuariosid))");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] = @AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( StringUtil.StrCmp(AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] IS NULL or (T1.[usuariosId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[usuariosNombre]) like UPPER(@lV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre))");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] = @AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( StringUtil.StrCmp(AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] IS NULL or (T2.[usuariosNombre] = ''))");
         }
         if ( AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels, "T2.[usuariosEstado] IN (", ")")+")");
         }
         if ( AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels, "T1.[SecUserEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserPassword]) like UPPER(@lV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword))");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ! ( StringUtil.StrCmp(AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserPassword] = @AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( StringUtil.StrCmp(AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserPassword] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV23OrderedBy == 1 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserName]";
         }
         else if ( ( AV23OrderedBy == 1 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserName] DESC";
         }
         else if ( ( AV23OrderedBy == 2 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserId]";
         }
         else if ( ( AV23OrderedBy == 2 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserId] DESC";
         }
         else if ( ( AV23OrderedBy == 3 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserFullName]";
         }
         else if ( ( AV23OrderedBy == 3 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserFullName] DESC";
         }
         else if ( ( AV23OrderedBy == 4 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[usuariosId]";
         }
         else if ( ( AV23OrderedBy == 4 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[usuariosId] DESC";
         }
         else if ( ( AV23OrderedBy == 5 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[usuariosNombre]";
         }
         else if ( ( AV23OrderedBy == 5 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[usuariosNombre] DESC";
         }
         else if ( ( AV23OrderedBy == 6 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[usuariosEstado]";
         }
         else if ( ( AV23OrderedBy == 6 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[usuariosEstado] DESC";
         }
         else if ( ( AV23OrderedBy == 7 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserEstado]";
         }
         else if ( ( AV23OrderedBy == 7 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserEstado] DESC";
         }
         else if ( ( AV23OrderedBy == 8 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserPassword]";
         }
         else if ( ( AV23OrderedBy == 8 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserPassword] DESC";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_H000U3( IGxContext context ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                             string A550SecUserEstado ,
                                             GxSimpleCollection<string> AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                             string AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                             short AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                             string AV108Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                             string AV109Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                             bool AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                             string AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                             short AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                             string AV113Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                             string AV114Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                             bool AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                             string AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                             short AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                             string AV118Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                             string AV119Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                             long AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                             long AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                             string AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                             string AV122Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                             string AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                             string AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                             string AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                             string AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                             string AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                             string AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                             int AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ,
                                             int AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ,
                                             string AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                             string AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                             string A26SecUserName ,
                                             string A145usuariosId ,
                                             long A18SecUserId ,
                                             string A587SecUserFullName ,
                                             string A222usuariosNombre ,
                                             string A27SecUserPassword ,
                                             short AV23OrderedBy ,
                                             bool AV24OrderedDsc ,
                                             string AV105Wwpbaseobjects_secuserwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[24];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T1.[SecUserPassword], T1.[SecUserEstado], T2.[usuariosImagen_GXI], T2.[usuariosEstado], T2.[usuariosNombre], T1.[usuariosId], T1.[SecUserFullName], T1.[SecUserName], T1.[SecUserId], T2.[usuariosImagen] FROM ([SecUser] T1 LEFT JOIN [usuarios] T2 ON T2.[usuariosId] = T1.[usuariosId])";
         if ( ( StringUtil.StrCmp(AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV108Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int13[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV108Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int13[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV109Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int13[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV106Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV107Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV109Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int13[3] = 1;
         }
         if ( AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV113Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int13[4] = 1;
         }
         if ( AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV113Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int13[5] = 1;
         }
         if ( AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV114Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int13[6] = 1;
         }
         if ( AV110Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV112Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV114Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int13[7] = 1;
         }
         if ( AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV118Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV118Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV119Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( AV115Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV116Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV117Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV119Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( ! (0==AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] >= @AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid)");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( ! (0==AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] <= @AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to)");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wwpbaseobjects_secuserwwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV122Wwpbaseobjects_secuserwwds_18_tfsecusername))");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserName] = @AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( StringUtil.StrCmp(AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserFullName]) like UPPER(@lV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname))");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserFullName] = @AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( StringUtil.StrCmp(AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserFullName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wwpbaseobjects_secuserwwds_22_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV126Wwpbaseobjects_secuserwwds_22_tfusuariosid))");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] = @AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( StringUtil.StrCmp(AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] IS NULL or (T1.[usuariosId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[usuariosNombre]) like UPPER(@lV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre))");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] = @AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( StringUtil.StrCmp(AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] IS NULL or (T2.[usuariosNombre] = ''))");
         }
         if ( AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV130Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels, "T2.[usuariosEstado] IN (", ")")+")");
         }
         if ( AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV131Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels, "T1.[SecUserEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserPassword]) like UPPER(@lV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword))");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ! ( StringUtil.StrCmp(AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserPassword] = @AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)");
         }
         else
         {
            GXv_int13[23] = 1;
         }
         if ( StringUtil.StrCmp(AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserPassword] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV23OrderedBy == 1 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserName]";
         }
         else if ( ( AV23OrderedBy == 1 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserName] DESC";
         }
         else if ( ( AV23OrderedBy == 2 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserId]";
         }
         else if ( ( AV23OrderedBy == 2 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserId] DESC";
         }
         else if ( ( AV23OrderedBy == 3 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserFullName]";
         }
         else if ( ( AV23OrderedBy == 3 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserFullName] DESC";
         }
         else if ( ( AV23OrderedBy == 4 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[usuariosId]";
         }
         else if ( ( AV23OrderedBy == 4 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[usuariosId] DESC";
         }
         else if ( ( AV23OrderedBy == 5 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[usuariosNombre]";
         }
         else if ( ( AV23OrderedBy == 5 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[usuariosNombre] DESC";
         }
         else if ( ( AV23OrderedBy == 6 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[usuariosEstado]";
         }
         else if ( ( AV23OrderedBy == 6 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[usuariosEstado] DESC";
         }
         else if ( ( AV23OrderedBy == 7 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserEstado]";
         }
         else if ( ( AV23OrderedBy == 7 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserEstado] DESC";
         }
         else if ( ( AV23OrderedBy == 8 ) && ! AV24OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SecUserPassword]";
         }
         else if ( ( AV23OrderedBy == 8 ) && ( AV24OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SecUserPassword] DESC";
         }
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000U2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] , (string)dynConstraints[40] );
               case 1 :
                     return conditional_H000U3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] , (string)dynConstraints[40] );
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
          Object[] prmH000U2;
          prmH000U2 = new Object[] {
          new ParDef("@lV108Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV108Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV109Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV109Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV113Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV113Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV114Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV114Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV118Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV118Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV119Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@lV119Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid",GXType.Decimal,10,0) ,
          new ParDef("@AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV122Wwpbaseobjects_secuserwwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("@AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname",GXType.VarChar,120,0) ,
          new ParDef("@AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel",GXType.NVarChar,120,0) ,
          new ParDef("@lV126Wwpbaseobjects_secuserwwds_22_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword",GXType.VarChar,100,0) ,
          new ParDef("@AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel",GXType.NVarChar,100,0)
          };
          Object[] prmH000U3;
          prmH000U3 = new Object[] {
          new ParDef("@lV108Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV108Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV109Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV109Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV113Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV113Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV114Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV114Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV118Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV118Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV119Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@lV119Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@AV120Wwpbaseobjects_secuserwwds_16_tfsecuserid",GXType.Decimal,10,0) ,
          new ParDef("@AV121Wwpbaseobjects_secuserwwds_17_tfsecuserid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV122Wwpbaseobjects_secuserwwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("@AV123Wwpbaseobjects_secuserwwds_19_tfsecusername_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV124Wwpbaseobjects_secuserwwds_20_tfsecuserfullname",GXType.VarChar,120,0) ,
          new ParDef("@AV125Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel",GXType.NVarChar,120,0) ,
          new ParDef("@lV126Wwpbaseobjects_secuserwwds_22_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV127Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV128Wwpbaseobjects_secuserwwds_24_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV129Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV132Wwpbaseobjects_secuserwwds_28_tfsecuserpassword",GXType.VarChar,100,0) ,
          new ParDef("@AV133Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000U2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000U3,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(3));
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(3));
                return;
       }
    }

 }

}

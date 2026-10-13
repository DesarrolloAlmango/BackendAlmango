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
   public class metodopagossolicitudeswc : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public metodopagossolicitudeswc( )
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

      public metodopagossolicitudeswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_MetodoPagosID )
      {
         this.AV8MetodoPagosID = aP0_MetodoPagosID;
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
         chkSolicitudServicioSolCoti = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "MetodoPagosID");
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
                  AV8MetodoPagosID = (long)(Math.Round(NumberUtil.Val( GetPar( "MetodoPagosID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV8MetodoPagosID", StringUtil.LTrimStr( (decimal)(AV8MetodoPagosID), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV8MetodoPagosID});
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
                  gxfirstwebparm = GetFirstPar( "MetodoPagosID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "MetodoPagosID");
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
         nRC_GXsfl_37 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_37"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_37_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_37_idx = GetPar( "sGXsfl_37_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV16FilterFullText = GetPar( "FilterFullText");
         AV8MetodoPagosID = (long)(Math.Round(NumberUtil.Val( GetPar( "MetodoPagosID"), "."), 18, MidpointRounding.ToEven));
         AV20ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV55Pgmname = GetPar( "Pgmname");
         AV21TFSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFSolicitudesID"), "."), 18, MidpointRounding.ToEven));
         AV22TFSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFSolicitudesID_To"), "."), 18, MidpointRounding.ToEven));
         AV23TFSolicitudesNombre = GetPar( "TFSolicitudesNombre");
         AV24TFSolicitudesNombre_Sel = GetPar( "TFSolicitudesNombre_Sel");
         AV25TFSolicitudesTelefono = GetPar( "TFSolicitudesTelefono");
         AV26TFSolicitudesTelefono_Sel = GetPar( "TFSolicitudesTelefono_Sel");
         AV27TFSolicitudesMail = GetPar( "TFSolicitudesMail");
         AV28TFSolicitudesMail_Sel = GetPar( "TFSolicitudesMail_Sel");
         AV29TFDepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFDepartamentoId"), "."), 18, MidpointRounding.ToEven));
         AV30TFDepartamentoId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFDepartamentoId_To"), "."), 18, MidpointRounding.ToEven));
         AV31TFDepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "TFDepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
         AV32TFDepartamentoMunicipioId_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFDepartamentoMunicipioId_To"), "."), 18, MidpointRounding.ToEven));
         AV33TFZonasID = (long)(Math.Round(NumberUtil.Val( GetPar( "TFZonasID"), "."), 18, MidpointRounding.ToEven));
         AV34TFZonasID_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFZonasID_To"), "."), 18, MidpointRounding.ToEven));
         AV35TFSolicitudesDireccion = GetPar( "TFSolicitudesDireccion");
         AV36TFSolicitudesDireccion_Sel = GetPar( "TFSolicitudesDireccion_Sel");
         AV37TFSolicitudesTotal = NumberUtil.Val( GetPar( "TFSolicitudesTotal"), ".");
         AV38TFSolicitudesTotal_To = NumberUtil.Val( GetPar( "TFSolicitudesTotal_To"), ".");
         AV39TFSolicitudServicioSolCoti_Sel = GetPar( "TFSolicitudServicioSolCoti_Sel");
         AV40TFSolicitudServicioPFinal = NumberUtil.Val( GetPar( "TFSolicitudServicioPFinal"), ".");
         AV41TFSolicitudServicioPFinal_To = NumberUtil.Val( GetPar( "TFSolicitudServicioPFinal_To"), ".");
         AV49IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV50IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8MetodoPagosID, AV20ManageFiltersExecutionStep, AV55Pgmname, AV21TFSolicitudesID, AV22TFSolicitudesID_To, AV23TFSolicitudesNombre, AV24TFSolicitudesNombre_Sel, AV25TFSolicitudesTelefono, AV26TFSolicitudesTelefono_Sel, AV27TFSolicitudesMail, AV28TFSolicitudesMail_Sel, AV29TFDepartamentoId, AV30TFDepartamentoId_To, AV31TFDepartamentoMunicipioId, AV32TFDepartamentoMunicipioId_To, AV33TFZonasID, AV34TFZonasID_To, AV35TFSolicitudesDireccion, AV36TFSolicitudesDireccion_Sel, AV37TFSolicitudesTotal, AV38TFSolicitudesTotal_To, AV39TFSolicitudServicioSolCoti_Sel, AV40TFSolicitudServicioPFinal, AV41TFSolicitudServicioPFinal_To, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, sPrefix) ;
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
            PA2F2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV55Pgmname = "MetodoPagosSolicitudesWC";
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               edtavDelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_37_Refreshing);
               WS2F2( ) ;
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

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor H002F2 */
         pr_default.execute(0, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) && ( H002F2_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( H002F2_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(H002F2_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((H002F2_A176SolicitudesItemsPrecioFinal[0]*H002F2_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(H002F2_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(H002F2_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((H002F2_A176SolicitudesItemsPrecioFinal[0]*H002F2_A177SolicitudesItemsCantidad[0])-(H002F2_A180SolicitudItemsComision[0]*H002F2_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(H002F2_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(H002F2_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((H002F2_A176SolicitudesItemsPrecioFinal[0]*H002F2_A177SolicitudesItemsCantidad[0])+(H002F2_A180SolicitudItemsComision[0]*H002F2_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(H002F2_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(H002F2_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((H002F2_A176SolicitudesItemsPrecioFinal[0]*H002F2_A177SolicitudesItemsCantidad[0])-((H002F2_A176SolicitudesItemsPrecioFinal[0]*H002F2_A177SolicitudesItemsCantidad[0])*(H002F2_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(H002F2_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(H002F2_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((H002F2_A176SolicitudesItemsPrecioFinal[0]*H002F2_A177SolicitudesItemsCantidad[0])+((H002F2_A176SolicitudesItemsPrecioFinal[0]*H002F2_A177SolicitudesItemsCantidad[0])*(H002F2_A180SolicitudItemsComision[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A175SolicitudesItemsPrecioInstalac = 0;
                        }
                     }
                  }
               }
            }
            A174SolicitudesTotal = (decimal)(A174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
            context.SendWebValue( context.GetMessage( "Metodo Pagos Solicitudes WC", "")) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
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
            GXEncryptionTmp = "metodopagossolicitudeswc.aspx"+UrlEncode(StringUtil.LTrimStr(AV8MetodoPagosID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("metodopagossolicitudeswc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV49IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV50IsAuthorized_Delete, context));
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV15OrderedDsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_37", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_37), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV18ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45GridCurrentPage), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46GridPageCount), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRIDAPPLIEDFILTERS", AV47GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV42DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8MetodoPagosID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ManageFiltersExecutionStep), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21TFSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDESID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22TFSolicitudesID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDESNOMBRE", StringUtil.RTrim( AV23TFSolicitudesNombre));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDESNOMBRE_SEL", StringUtil.RTrim( AV24TFSolicitudesNombre_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDESTELEFONO", StringUtil.RTrim( AV25TFSolicitudesTelefono));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDESTELEFONO_SEL", StringUtil.RTrim( AV26TFSolicitudesTelefono_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDESMAIL", AV27TFSolicitudesMail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDESMAIL_SEL", AV28TFSolicitudesMail_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29TFDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFDEPARTAMENTOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TFDepartamentoId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFDEPARTAMENTOMUNICIPIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31TFDepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFDEPARTAMENTOMUNICIPIOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32TFDepartamentoMunicipioId_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFZONASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33TFZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFZONASID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34TFZonasID_To), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDESDIRECCION", AV35TFSolicitudesDireccion);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDESDIRECCION_SEL", AV36TFSolicitudesDireccion_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDESTOTAL", StringUtil.LTrim( StringUtil.NToC( AV37TFSolicitudesTotal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDESTOTAL_TO", StringUtil.LTrim( StringUtil.NToC( AV38TFSolicitudesTotal_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDSERVICIOSOLCOTI_SEL", StringUtil.RTrim( AV39TFSolicitudServicioSolCoti_Sel));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDSERVICIOPFINAL", StringUtil.LTrim( StringUtil.NToC( AV40TFSolicitudServicioPFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSOLICITUDSERVICIOPFINAL_TO", StringUtil.LTrim( StringUtil.NToC( AV41TFSolicitudServicioPFinal_To, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMETODOPAGOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV49IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV50IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SOLICITUDESCOSTOXZONA", StringUtil.LTrim( StringUtil.NToC( A864SolicitudesCostoXZona, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SOLICITUDESDESCUENTO", StringUtil.LTrim( StringUtil.NToC( A897SolicitudesDescuento, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SOLICITUDESDESCUENTOCUPON", StringUtil.LTrim( StringUtil.NToC( A1016SolicitudesDescuentoCupon, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SOLICITUDESCOTIZACION", StringUtil.LTrim( StringUtil.NToC( A212SolicitudesCotizacion, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SOLICITUDESCOMISIONMETODOPAGO", StringUtil.LTrim( StringUtil.NToC( A796SolicitudesComisionMetodoPago, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm2F2( )
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
         return "MetodoPagosSolicitudesWC" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Metodo Pagos Solicitudes WC", "") ;
      }

      protected void WB2F0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "metodopagossolicitudeswc.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button ButtonColor";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(37), 2, 0)+","+"null"+");", context.GetMessage( "GXM_insert", ""), bttBtninsert_Jsonclick, 5, context.GetMessage( "GXM_insert", ""), "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_MetodoPagosSolicitudesWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_22_2F2( true) ;
         }
         else
         {
            wb_table1_22_2F2( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_2F2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            StartGridControl37( ) ;
         }
         if ( wbEnd == 37 )
         {
            wbEnd = 0;
            nRC_GXsfl_37 = (int)(nGXsfl_37_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV45GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV46GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV47GridAppliedFilters);
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
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV42DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMetodoPagosID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A128MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetodoPagosID_Jsonclick, 0, "Attribute", "", "", "", "", edtMetodoPagosID_Visible, 0, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_MetodoPagosSolicitudesWC.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 37 )
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

      protected void START2F2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Metodo Pagos Solicitudes WC", ""), 0) ;
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
               STRUP2F0( ) ;
            }
         }
      }

      protected void WS2F2( )
      {
         START2F2( ) ;
         EVT2F2( ) ;
      }

      protected void EVT2F2( )
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
                                 STRUP2F0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_managefilters.Onoptionclicked */
                                    E112F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changepage */
                                    E122F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Gridpaginationbar.Changerowsperpage */
                                    E132F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E142F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E152F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavFilterfulltext_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2F0( ) ;
                              }
                              nGXsfl_37_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
                              SubsflControlProps_372( ) ;
                              AV53Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV53Update);
                              AV54Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri(sPrefix, false, edtavDelete_Internalname, AV54Delete);
                              A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A171SolicitudesNombre = cgiGet( edtSolicitudesNombre_Internalname);
                              A172SolicitudesTelefono = cgiGet( edtSolicitudesTelefono_Internalname);
                              A206SolicitudesMail = cgiGet( edtSolicitudesMail_Internalname);
                              n206SolicitudesMail = false;
                              A116PaisID = cgiGet( edtPaisID_Internalname);
                              A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n112DepartamentoId = false;
                              A114DepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoMunicipioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n114DepartamentoMunicipioId = false;
                              A110ZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              n110ZonasID = false;
                              A173SolicitudesDireccion = cgiGet( edtSolicitudesDireccion_Internalname);
                              A194SolicitudesAutoEnumerar = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesAutoEnumerar_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A174SolicitudesTotal = context.localUtil.CToN( cgiGet( edtSolicitudesTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A210SolicitudServicioSolCoti = ((StringUtil.StrCmp(cgiGet( chkSolicitudServicioSolCoti_Internalname), "S")==0) ? "S" : "N");
                              A211SolicitudServicioPFinal = context.localUtil.CToN( cgiGet( edtSolicitudServicioPFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E162F2 ();
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E172F2 ();
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
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Grid.Load */
                                          E182F2 ();
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
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
                                       STRUP2F0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavFilterfulltext_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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

      protected void WE2F2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2F2( ) ;
            }
         }
      }

      protected void PA2F2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "metodopagossolicitudeswc.aspx")), "metodopagossolicitudeswc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "metodopagossolicitudeswc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "MetodoPagosID");
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
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_372( ) ;
         while ( nGXsfl_37_idx <= nRC_GXsfl_37 )
         {
            sendrow_372( ) ;
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       string AV16FilterFullText ,
                                       long AV8MetodoPagosID ,
                                       short AV20ManageFiltersExecutionStep ,
                                       string AV55Pgmname ,
                                       long AV21TFSolicitudesID ,
                                       long AV22TFSolicitudesID_To ,
                                       string AV23TFSolicitudesNombre ,
                                       string AV24TFSolicitudesNombre_Sel ,
                                       string AV25TFSolicitudesTelefono ,
                                       string AV26TFSolicitudesTelefono_Sel ,
                                       string AV27TFSolicitudesMail ,
                                       string AV28TFSolicitudesMail_Sel ,
                                       long AV29TFDepartamentoId ,
                                       long AV30TFDepartamentoId_To ,
                                       long AV31TFDepartamentoMunicipioId ,
                                       long AV32TFDepartamentoMunicipioId_To ,
                                       long AV33TFZonasID ,
                                       long AV34TFZonasID_To ,
                                       string AV35TFSolicitudesDireccion ,
                                       string AV36TFSolicitudesDireccion_Sel ,
                                       decimal AV37TFSolicitudesTotal ,
                                       decimal AV38TFSolicitudesTotal_To ,
                                       string AV39TFSolicitudServicioSolCoti_Sel ,
                                       decimal AV40TFSolicitudServicioPFinal ,
                                       decimal AV41TFSolicitudServicioPFinal_To ,
                                       bool AV49IsAuthorized_Update ,
                                       bool AV50IsAuthorized_Delete ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF2F2( ) ;
         GXKey = Crypto.GetSiteKey( );
         send_integrity_footer_hashes( ) ;
         GXKey = Crypto.GetSiteKey( );
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SOLICITUDESID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"SOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, ".", "")));
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
         RF2F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV55Pgmname = "MetodoPagosSolicitudesWC";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV21TFSolicitudesID ,
                                              AV22TFSolicitudesID_To ,
                                              AV24TFSolicitudesNombre_Sel ,
                                              AV23TFSolicitudesNombre ,
                                              AV26TFSolicitudesTelefono_Sel ,
                                              AV25TFSolicitudesTelefono ,
                                              AV28TFSolicitudesMail_Sel ,
                                              AV27TFSolicitudesMail ,
                                              AV29TFDepartamentoId ,
                                              AV30TFDepartamentoId_To ,
                                              AV31TFDepartamentoMunicipioId ,
                                              AV32TFDepartamentoMunicipioId_To ,
                                              AV33TFZonasID ,
                                              AV34TFZonasID_To ,
                                              AV36TFSolicitudesDireccion_Sel ,
                                              AV35TFSolicitudesDireccion ,
                                              AV37TFSolicitudesTotal ,
                                              AV38TFSolicitudesTotal_To ,
                                              AV39TFSolicitudServicioSolCoti_Sel ,
                                              A127SolicitudesID ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A206SolicitudesMail ,
                                              A112DepartamentoId ,
                                              A114DepartamentoMunicipioId ,
                                              A110ZonasID ,
                                              A173SolicitudesDireccion ,
                                              A174SolicitudesTotal ,
                                              A210SolicitudServicioSolCoti ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV16FilterFullText ,
                                              A211SolicitudServicioPFinal ,
                                              AV40TFSolicitudServicioPFinal ,
                                              AV41TFSolicitudServicioPFinal_To ,
                                              AV8MetodoPagosID ,
                                              A128MetodoPagosID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV23TFSolicitudesNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFSolicitudesNombre), 100, "%");
         lV25TFSolicitudesTelefono = StringUtil.PadR( StringUtil.RTrim( AV25TFSolicitudesTelefono), 20, "%");
         lV27TFSolicitudesMail = StringUtil.Concat( StringUtil.RTrim( AV27TFSolicitudesMail), "%", "");
         lV35TFSolicitudesDireccion = StringUtil.Concat( StringUtil.RTrim( AV35TFSolicitudesDireccion), "%", "");
         /* Using cursor H002F3 */
         pr_default.execute(1, new Object[] {AV8MetodoPagosID, AV21TFSolicitudesID, AV22TFSolicitudesID_To, lV23TFSolicitudesNombre, AV24TFSolicitudesNombre_Sel, lV25TFSolicitudesTelefono, AV26TFSolicitudesTelefono_Sel, lV27TFSolicitudesMail, AV28TFSolicitudesMail_Sel, AV29TFDepartamentoId, AV30TFDepartamentoId_To, AV31TFDepartamentoMunicipioId, AV32TFDepartamentoMunicipioId_To, AV33TFZonasID, AV34TFZonasID_To, lV35TFSolicitudesDireccion, AV36TFSolicitudesDireccion_Sel, AV39TFSolicitudServicioSolCoti_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A128MetodoPagosID = H002F3_A128MetodoPagosID[0];
            AssignAttri(sPrefix, false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
            A210SolicitudServicioSolCoti = H002F3_A210SolicitudServicioSolCoti[0];
            A194SolicitudesAutoEnumerar = H002F3_A194SolicitudesAutoEnumerar[0];
            A173SolicitudesDireccion = H002F3_A173SolicitudesDireccion[0];
            A110ZonasID = H002F3_A110ZonasID[0];
            n110ZonasID = H002F3_n110ZonasID[0];
            A114DepartamentoMunicipioId = H002F3_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = H002F3_n114DepartamentoMunicipioId[0];
            A112DepartamentoId = H002F3_A112DepartamentoId[0];
            n112DepartamentoId = H002F3_n112DepartamentoId[0];
            A116PaisID = H002F3_A116PaisID[0];
            A206SolicitudesMail = H002F3_A206SolicitudesMail[0];
            n206SolicitudesMail = H002F3_n206SolicitudesMail[0];
            A172SolicitudesTelefono = H002F3_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = H002F3_A171SolicitudesNombre[0];
            A127SolicitudesID = H002F3_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = H002F3_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = H002F3_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = H002F3_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = H002F3_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = H002F3_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = H002F3_A864SolicitudesCostoXZona[0];
            A116PaisID = H002F3_A116PaisID[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A171SolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A172SolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A206SolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A110ZonasID), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A173SolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A174SolicitudesTotal, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A211SolicitudServicioPFinal, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV40TFSolicitudServicioPFinal) || ( ( A211SolicitudServicioPFinal >= AV40TFSolicitudServicioPFinal ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV41TFSolicitudServicioPFinal_To) || ( ( A211SolicitudServicioPFinal <= AV41TFSolicitudServicioPFinal_To ) ) )
                  {
                     GRID_nRecordCount = (long)(GRID_nRecordCount+1);
                  }
               }
            }
            pr_default.readNext(1);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF2F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 37;
         /* Execute user event: Refresh */
         E172F2 ();
         nGXsfl_37_idx = 1;
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         bGXsfl_37_Refreshing = true;
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
            SubsflControlProps_372( ) ;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV21TFSolicitudesID ,
                                                 AV22TFSolicitudesID_To ,
                                                 AV24TFSolicitudesNombre_Sel ,
                                                 AV23TFSolicitudesNombre ,
                                                 AV26TFSolicitudesTelefono_Sel ,
                                                 AV25TFSolicitudesTelefono ,
                                                 AV28TFSolicitudesMail_Sel ,
                                                 AV27TFSolicitudesMail ,
                                                 AV29TFDepartamentoId ,
                                                 AV30TFDepartamentoId_To ,
                                                 AV31TFDepartamentoMunicipioId ,
                                                 AV32TFDepartamentoMunicipioId_To ,
                                                 AV33TFZonasID ,
                                                 AV34TFZonasID_To ,
                                                 AV36TFSolicitudesDireccion_Sel ,
                                                 AV35TFSolicitudesDireccion ,
                                                 AV37TFSolicitudesTotal ,
                                                 AV38TFSolicitudesTotal_To ,
                                                 AV39TFSolicitudServicioSolCoti_Sel ,
                                                 A127SolicitudesID ,
                                                 A171SolicitudesNombre ,
                                                 A172SolicitudesTelefono ,
                                                 A206SolicitudesMail ,
                                                 A112DepartamentoId ,
                                                 A114DepartamentoMunicipioId ,
                                                 A110ZonasID ,
                                                 A173SolicitudesDireccion ,
                                                 A174SolicitudesTotal ,
                                                 A210SolicitudServicioSolCoti ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV16FilterFullText ,
                                                 A211SolicitudServicioPFinal ,
                                                 AV40TFSolicitudServicioPFinal ,
                                                 AV41TFSolicitudServicioPFinal_To ,
                                                 AV8MetodoPagosID ,
                                                 A128MetodoPagosID } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV23TFSolicitudesNombre = StringUtil.PadR( StringUtil.RTrim( AV23TFSolicitudesNombre), 100, "%");
            lV25TFSolicitudesTelefono = StringUtil.PadR( StringUtil.RTrim( AV25TFSolicitudesTelefono), 20, "%");
            lV27TFSolicitudesMail = StringUtil.Concat( StringUtil.RTrim( AV27TFSolicitudesMail), "%", "");
            lV35TFSolicitudesDireccion = StringUtil.Concat( StringUtil.RTrim( AV35TFSolicitudesDireccion), "%", "");
            /* Using cursor H002F4 */
            pr_default.execute(2, new Object[] {AV8MetodoPagosID, AV21TFSolicitudesID, AV22TFSolicitudesID_To, lV23TFSolicitudesNombre, AV24TFSolicitudesNombre_Sel, lV25TFSolicitudesTelefono, AV26TFSolicitudesTelefono_Sel, lV27TFSolicitudesMail, AV28TFSolicitudesMail_Sel, AV29TFDepartamentoId, AV30TFDepartamentoId_To, AV31TFDepartamentoMunicipioId, AV32TFDepartamentoMunicipioId_To, AV33TFZonasID, AV34TFZonasID_To, lV35TFSolicitudesDireccion, AV36TFSolicitudesDireccion_Sel, AV39TFSolicitudServicioSolCoti_Sel});
            nGXsfl_37_idx = 1;
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(2) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A128MetodoPagosID = H002F4_A128MetodoPagosID[0];
               AssignAttri(sPrefix, false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
               A210SolicitudServicioSolCoti = H002F4_A210SolicitudServicioSolCoti[0];
               A194SolicitudesAutoEnumerar = H002F4_A194SolicitudesAutoEnumerar[0];
               A173SolicitudesDireccion = H002F4_A173SolicitudesDireccion[0];
               A110ZonasID = H002F4_A110ZonasID[0];
               n110ZonasID = H002F4_n110ZonasID[0];
               A114DepartamentoMunicipioId = H002F4_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = H002F4_n114DepartamentoMunicipioId[0];
               A112DepartamentoId = H002F4_A112DepartamentoId[0];
               n112DepartamentoId = H002F4_n112DepartamentoId[0];
               A116PaisID = H002F4_A116PaisID[0];
               A206SolicitudesMail = H002F4_A206SolicitudesMail[0];
               n206SolicitudesMail = H002F4_n206SolicitudesMail[0];
               A172SolicitudesTelefono = H002F4_A172SolicitudesTelefono[0];
               A171SolicitudesNombre = H002F4_A171SolicitudesNombre[0];
               A127SolicitudesID = H002F4_A127SolicitudesID[0];
               A796SolicitudesComisionMetodoPago = H002F4_A796SolicitudesComisionMetodoPago[0];
               A212SolicitudesCotizacion = H002F4_A212SolicitudesCotizacion[0];
               A1016SolicitudesDescuentoCupon = H002F4_A1016SolicitudesDescuentoCupon[0];
               A897SolicitudesDescuento = H002F4_A897SolicitudesDescuento[0];
               n897SolicitudesDescuento = H002F4_n897SolicitudesDescuento[0];
               A864SolicitudesCostoXZona = H002F4_A864SolicitudesCostoXZona[0];
               A116PaisID = H002F4_A116PaisID[0];
               GetSolicitudesTotal( A127SolicitudesID) ;
               if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                     }
                     else
                     {
                        if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                        {
                           A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                        }
                        else
                        {
                           A211SolicitudServicioPFinal = 0;
                        }
                     }
                  }
               }
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A127SolicitudesID), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A171SolicitudesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A172SolicitudesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A206SolicitudesMail) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A114DepartamentoMunicipioId), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A110ZonasID), 18, 0) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A173SolicitudesDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV16FilterFullText) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A174SolicitudesTotal, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A211SolicitudServicioPFinal, 18, 2) , StringUtil.PadR( "%" + AV16FilterFullText , 254 , "%"),  ' ' ) ) ) )
               {
                  if ( (Convert.ToDecimal(0)==AV40TFSolicitudServicioPFinal) || ( ( A211SolicitudServicioPFinal >= AV40TFSolicitudServicioPFinal ) ) )
                  {
                     if ( (Convert.ToDecimal(0)==AV41TFSolicitudServicioPFinal_To) || ( ( A211SolicitudServicioPFinal <= AV41TFSolicitudServicioPFinal_To ) ) )
                     {
                        /* Execute user event: Grid.Load */
                        E182F2 ();
                     }
                  }
               }
               pr_default.readNext(2);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(2);
            wbEnd = 37;
            WB2F0( ) ;
         }
         bGXsfl_37_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2F2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV55Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV55Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV49IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV50IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_SOLICITUDESID"+"_"+sGXsfl_37_idx, GetSecureSignedToken( sPrefix+sGXsfl_37_idx, context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8MetodoPagosID, AV20ManageFiltersExecutionStep, AV55Pgmname, AV21TFSolicitudesID, AV22TFSolicitudesID_To, AV23TFSolicitudesNombre, AV24TFSolicitudesNombre_Sel, AV25TFSolicitudesTelefono, AV26TFSolicitudesTelefono_Sel, AV27TFSolicitudesMail, AV28TFSolicitudesMail_Sel, AV29TFDepartamentoId, AV30TFDepartamentoId_To, AV31TFDepartamentoMunicipioId, AV32TFDepartamentoMunicipioId_To, AV33TFZonasID, AV34TFZonasID_To, AV35TFSolicitudesDireccion, AV36TFSolicitudesDireccion_Sel, AV37TFSolicitudesTotal, AV38TFSolicitudesTotal_To, AV39TFSolicitudServicioSolCoti_Sel, AV40TFSolicitudServicioPFinal, AV41TFSolicitudServicioPFinal_To, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8MetodoPagosID, AV20ManageFiltersExecutionStep, AV55Pgmname, AV21TFSolicitudesID, AV22TFSolicitudesID_To, AV23TFSolicitudesNombre, AV24TFSolicitudesNombre_Sel, AV25TFSolicitudesTelefono, AV26TFSolicitudesTelefono_Sel, AV27TFSolicitudesMail, AV28TFSolicitudesMail_Sel, AV29TFDepartamentoId, AV30TFDepartamentoId_To, AV31TFDepartamentoMunicipioId, AV32TFDepartamentoMunicipioId_To, AV33TFZonasID, AV34TFZonasID_To, AV35TFSolicitudesDireccion, AV36TFSolicitudesDireccion_Sel, AV37TFSolicitudesTotal, AV38TFSolicitudesTotal_To, AV39TFSolicitudServicioSolCoti_Sel, AV40TFSolicitudServicioPFinal, AV41TFSolicitudServicioPFinal_To, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8MetodoPagosID, AV20ManageFiltersExecutionStep, AV55Pgmname, AV21TFSolicitudesID, AV22TFSolicitudesID_To, AV23TFSolicitudesNombre, AV24TFSolicitudesNombre_Sel, AV25TFSolicitudesTelefono, AV26TFSolicitudesTelefono_Sel, AV27TFSolicitudesMail, AV28TFSolicitudesMail_Sel, AV29TFDepartamentoId, AV30TFDepartamentoId_To, AV31TFDepartamentoMunicipioId, AV32TFDepartamentoMunicipioId_To, AV33TFZonasID, AV34TFZonasID_To, AV35TFSolicitudesDireccion, AV36TFSolicitudesDireccion_Sel, AV37TFSolicitudesTotal, AV38TFSolicitudesTotal_To, AV39TFSolicitudServicioSolCoti_Sel, AV40TFSolicitudServicioPFinal, AV41TFSolicitudServicioPFinal_To, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8MetodoPagosID, AV20ManageFiltersExecutionStep, AV55Pgmname, AV21TFSolicitudesID, AV22TFSolicitudesID_To, AV23TFSolicitudesNombre, AV24TFSolicitudesNombre_Sel, AV25TFSolicitudesTelefono, AV26TFSolicitudesTelefono_Sel, AV27TFSolicitudesMail, AV28TFSolicitudesMail_Sel, AV29TFDepartamentoId, AV30TFDepartamentoId_To, AV31TFDepartamentoMunicipioId, AV32TFDepartamentoMunicipioId_To, AV33TFZonasID, AV34TFZonasID_To, AV35TFSolicitudesDireccion, AV36TFSolicitudesDireccion_Sel, AV37TFSolicitudesTotal, AV38TFSolicitudesTotal_To, AV39TFSolicitudServicioSolCoti_Sel, AV40TFSolicitudServicioPFinal, AV41TFSolicitudServicioPFinal_To, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, sPrefix) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14OrderedBy, AV15OrderedDsc, AV16FilterFullText, AV8MetodoPagosID, AV20ManageFiltersExecutionStep, AV55Pgmname, AV21TFSolicitudesID, AV22TFSolicitudesID_To, AV23TFSolicitudesNombre, AV24TFSolicitudesNombre_Sel, AV25TFSolicitudesTelefono, AV26TFSolicitudesTelefono_Sel, AV27TFSolicitudesMail, AV28TFSolicitudesMail_Sel, AV29TFDepartamentoId, AV30TFDepartamentoId_To, AV31TFDepartamentoMunicipioId, AV32TFDepartamentoMunicipioId_To, AV33TFZonasID, AV34TFZonasID_To, AV35TFSolicitudesDireccion, AV36TFSolicitudesDireccion_Sel, AV37TFSolicitudesTotal, AV38TFSolicitudesTotal_To, AV39TFSolicitudServicioSolCoti_Sel, AV40TFSolicitudServicioPFinal, AV41TFSolicitudServicioPFinal_To, AV49IsAuthorized_Update, AV50IsAuthorized_Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV55Pgmname = "MetodoPagosSolicitudesWC";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtSolicitudesID_Enabled = 0;
         edtSolicitudesNombre_Enabled = 0;
         edtSolicitudesTelefono_Enabled = 0;
         edtSolicitudesMail_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         edtDepartamentoMunicipioId_Enabled = 0;
         edtZonasID_Enabled = 0;
         edtSolicitudesDireccion_Enabled = 0;
         edtSolicitudesAutoEnumerar_Enabled = 0;
         edtSolicitudesTotal_Enabled = 0;
         chkSolicitudServicioSolCoti.Enabled = 0;
         edtSolicitudServicioPFinal_Enabled = 0;
         edtMetodoPagosID_Enabled = 0;
         AssignProp(sPrefix, false, edtMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E162F2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV18ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV42DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_37 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_37"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV45GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDCURRENTPAGE"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV46GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vGRIDPAGECOUNT"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AV47GridAppliedFilters = cgiGet( sPrefix+"vGRIDAPPLIEDFILTERS");
            wcpOAV8MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8MetodoPagosID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
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
            Ddo_grid_Datalistfixedvalues = cgiGet( sPrefix+"DDO_GRID_Datalistfixedvalues");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( sPrefix+"DDO_GRID_Format");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( sPrefix+"GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( sPrefix+"GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            A128MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMetodoPagosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
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
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
         E162F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E162F2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 50;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         edtMetodoPagosID_Visible = 0;
         AssignProp(sPrefix, false, edtMetodoPagosID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
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
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV42DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV42DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, sPrefix, false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E172F2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV20ManageFiltersExecutionStep == 1 )
         {
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV20ManageFiltersExecutionStep == 2 )
         {
            AV20ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV45GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri(sPrefix, false, "AV45GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV45GridCurrentPage), 10, 0));
         AV46GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri(sPrefix, false, "AV46GridPageCount", StringUtil.LTrimStr( (decimal)(AV46GridPageCount), 10, 0));
         GXt_char2 = AV47GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV55Pgmname, out  GXt_char2) ;
         AV47GridAppliedFilters = GXt_char2;
         AssignAttri(sPrefix, false, "AV47GridAppliedFilters", AV47GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E122F2( )
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
            AV44PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV44PageToGo) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E132F2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E142F2( )
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
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesID") == 0 )
            {
               AV21TFSolicitudesID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21TFSolicitudesID", StringUtil.LTrimStr( (decimal)(AV21TFSolicitudesID), 18, 0));
               AV22TFSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22TFSolicitudesID_To", StringUtil.LTrimStr( (decimal)(AV22TFSolicitudesID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesNombre") == 0 )
            {
               AV23TFSolicitudesNombre = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV23TFSolicitudesNombre", AV23TFSolicitudesNombre);
               AV24TFSolicitudesNombre_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV24TFSolicitudesNombre_Sel", AV24TFSolicitudesNombre_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesTelefono") == 0 )
            {
               AV25TFSolicitudesTelefono = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV25TFSolicitudesTelefono", AV25TFSolicitudesTelefono);
               AV26TFSolicitudesTelefono_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV26TFSolicitudesTelefono_Sel", AV26TFSolicitudesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesMail") == 0 )
            {
               AV27TFSolicitudesMail = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV27TFSolicitudesMail", AV27TFSolicitudesMail);
               AV28TFSolicitudesMail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV28TFSolicitudesMail_Sel", AV28TFSolicitudesMail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DepartamentoId") == 0 )
            {
               AV29TFDepartamentoId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV29TFDepartamentoId", StringUtil.LTrimStr( (decimal)(AV29TFDepartamentoId), 18, 0));
               AV30TFDepartamentoId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV30TFDepartamentoId_To", StringUtil.LTrimStr( (decimal)(AV30TFDepartamentoId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DepartamentoMunicipioId") == 0 )
            {
               AV31TFDepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV31TFDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV31TFDepartamentoMunicipioId), 18, 0));
               AV32TFDepartamentoMunicipioId_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV32TFDepartamentoMunicipioId_To", StringUtil.LTrimStr( (decimal)(AV32TFDepartamentoMunicipioId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ZonasID") == 0 )
            {
               AV33TFZonasID = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV33TFZonasID", StringUtil.LTrimStr( (decimal)(AV33TFZonasID), 18, 0));
               AV34TFZonasID_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV34TFZonasID_To", StringUtil.LTrimStr( (decimal)(AV34TFZonasID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesDireccion") == 0 )
            {
               AV35TFSolicitudesDireccion = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV35TFSolicitudesDireccion", AV35TFSolicitudesDireccion);
               AV36TFSolicitudesDireccion_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV36TFSolicitudesDireccion_Sel", AV36TFSolicitudesDireccion_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudesTotal") == 0 )
            {
               AV37TFSolicitudesTotal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV37TFSolicitudesTotal", StringUtil.LTrimStr( AV37TFSolicitudesTotal, 18, 2));
               AV38TFSolicitudesTotal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV38TFSolicitudesTotal_To", StringUtil.LTrimStr( AV38TFSolicitudesTotal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudServicioSolCoti") == 0 )
            {
               AV39TFSolicitudServicioSolCoti_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV39TFSolicitudServicioSolCoti_Sel", AV39TFSolicitudServicioSolCoti_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SolicitudServicioPFinal") == 0 )
            {
               AV40TFSolicitudServicioPFinal = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri(sPrefix, false, "AV40TFSolicitudServicioPFinal", StringUtil.LTrimStr( AV40TFSolicitudServicioPFinal, 18, 2));
               AV41TFSolicitudServicioPFinal_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri(sPrefix, false, "AV41TFSolicitudServicioPFinal_To", StringUtil.LTrimStr( AV41TFSolicitudServicioPFinal_To, 18, 2));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E182F2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            AV53Update = "<i class=\"fa fa-pen\"></i>";
            AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV53Update);
            if ( AV49IsAuthorized_Update )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "solicitudes.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0));
               edtavUpdate_Link = formatLink("solicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            AV54Delete = "<i class=\"fa fa-times\"></i>";
            AssignAttri(sPrefix, false, edtavDelete_Internalname, AV54Delete);
            if ( AV50IsAuthorized_Delete )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "solicitudes.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0));
               edtavDelete_Link = formatLink("solicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "solicitudesview.aspx"+UrlEncode(StringUtil.LTrimStr(A127SolicitudesID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtSolicitudesNombre_Link = formatLink("solicitudesview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 37;
            }
            sendrow_372( ) ;
         }
         GRID_nEOF = (short)(((subGrid_Rows==0)||(GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_37_Refreshing )
         {
            context.DoAjaxLoad(37, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E112F2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S172 ();
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
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("MetodoPagosSolicitudesWCFilters")) + "," + UrlEncode(StringUtil.RTrim(AV55Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("MetodoPagosSolicitudesWCFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV20ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV20ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV20ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV19ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "MetodoPagosSolicitudesWCFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV19ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19ManageFiltersXml)) )
            {
               GX_msglist.addItem(context.GetMessage( "WWP_FilterNotExist", ""));
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV55Pgmname+"GridState",  AV19ManageFiltersXml) ;
               AV12GridState.FromXml(AV19ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV18ManageFiltersData", AV18ManageFiltersData);
      }

      protected void E152F2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "solicitudes.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
         CallWebObject(formatLink("solicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV49IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes_Update", out  GXt_boolean3) ;
         AV49IsAuthorized_Update = GXt_boolean3;
         AssignAttri(sPrefix, false, "AV49IsAuthorized_Update", AV49IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV49IsAuthorized_Update, context));
         if ( ! ( AV49IsAuthorized_Update ) )
         {
            edtavUpdate_Visible = 0;
            AssignProp(sPrefix, false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean3 = AV50IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes_Delete", out  GXt_boolean3) ;
         AV50IsAuthorized_Delete = GXt_boolean3;
         AssignAttri(sPrefix, false, "AV50IsAuthorized_Delete", AV50IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV50IsAuthorized_Delete, context));
         if ( ! ( AV50IsAuthorized_Delete ) )
         {
            edtavDelete_Visible = 0;
            AssignProp(sPrefix, false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_37_Refreshing);
         }
         GXt_boolean3 = AV51TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes_Insert", out  GXt_boolean3) ;
         AV51TempBoolean = GXt_boolean3;
         if ( ! ( AV51TempBoolean ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp(sPrefix, false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV18ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "MetodoPagosSolicitudesWCFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV18ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
         AV21TFSolicitudesID = 0;
         AssignAttri(sPrefix, false, "AV21TFSolicitudesID", StringUtil.LTrimStr( (decimal)(AV21TFSolicitudesID), 18, 0));
         AV22TFSolicitudesID_To = 0;
         AssignAttri(sPrefix, false, "AV22TFSolicitudesID_To", StringUtil.LTrimStr( (decimal)(AV22TFSolicitudesID_To), 18, 0));
         AV23TFSolicitudesNombre = "";
         AssignAttri(sPrefix, false, "AV23TFSolicitudesNombre", AV23TFSolicitudesNombre);
         AV24TFSolicitudesNombre_Sel = "";
         AssignAttri(sPrefix, false, "AV24TFSolicitudesNombre_Sel", AV24TFSolicitudesNombre_Sel);
         AV25TFSolicitudesTelefono = "";
         AssignAttri(sPrefix, false, "AV25TFSolicitudesTelefono", AV25TFSolicitudesTelefono);
         AV26TFSolicitudesTelefono_Sel = "";
         AssignAttri(sPrefix, false, "AV26TFSolicitudesTelefono_Sel", AV26TFSolicitudesTelefono_Sel);
         AV27TFSolicitudesMail = "";
         AssignAttri(sPrefix, false, "AV27TFSolicitudesMail", AV27TFSolicitudesMail);
         AV28TFSolicitudesMail_Sel = "";
         AssignAttri(sPrefix, false, "AV28TFSolicitudesMail_Sel", AV28TFSolicitudesMail_Sel);
         AV29TFDepartamentoId = 0;
         AssignAttri(sPrefix, false, "AV29TFDepartamentoId", StringUtil.LTrimStr( (decimal)(AV29TFDepartamentoId), 18, 0));
         AV30TFDepartamentoId_To = 0;
         AssignAttri(sPrefix, false, "AV30TFDepartamentoId_To", StringUtil.LTrimStr( (decimal)(AV30TFDepartamentoId_To), 18, 0));
         AV31TFDepartamentoMunicipioId = 0;
         AssignAttri(sPrefix, false, "AV31TFDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV31TFDepartamentoMunicipioId), 18, 0));
         AV32TFDepartamentoMunicipioId_To = 0;
         AssignAttri(sPrefix, false, "AV32TFDepartamentoMunicipioId_To", StringUtil.LTrimStr( (decimal)(AV32TFDepartamentoMunicipioId_To), 18, 0));
         AV33TFZonasID = 0;
         AssignAttri(sPrefix, false, "AV33TFZonasID", StringUtil.LTrimStr( (decimal)(AV33TFZonasID), 18, 0));
         AV34TFZonasID_To = 0;
         AssignAttri(sPrefix, false, "AV34TFZonasID_To", StringUtil.LTrimStr( (decimal)(AV34TFZonasID_To), 18, 0));
         AV35TFSolicitudesDireccion = "";
         AssignAttri(sPrefix, false, "AV35TFSolicitudesDireccion", AV35TFSolicitudesDireccion);
         AV36TFSolicitudesDireccion_Sel = "";
         AssignAttri(sPrefix, false, "AV36TFSolicitudesDireccion_Sel", AV36TFSolicitudesDireccion_Sel);
         AV37TFSolicitudesTotal = 0;
         AssignAttri(sPrefix, false, "AV37TFSolicitudesTotal", StringUtil.LTrimStr( AV37TFSolicitudesTotal, 18, 2));
         AV38TFSolicitudesTotal_To = 0;
         AssignAttri(sPrefix, false, "AV38TFSolicitudesTotal_To", StringUtil.LTrimStr( AV38TFSolicitudesTotal_To, 18, 2));
         AV39TFSolicitudServicioSolCoti_Sel = "";
         AssignAttri(sPrefix, false, "AV39TFSolicitudServicioSolCoti_Sel", AV39TFSolicitudServicioSolCoti_Sel);
         AV40TFSolicitudServicioPFinal = 0;
         AssignAttri(sPrefix, false, "AV40TFSolicitudServicioPFinal", StringUtil.LTrimStr( AV40TFSolicitudServicioPFinal, 18, 2));
         AV41TFSolicitudServicioPFinal_To = 0;
         AssignAttri(sPrefix, false, "AV41TFSolicitudServicioPFinal_To", StringUtil.LTrimStr( AV41TFSolicitudServicioPFinal_To, 18, 2));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV17Session.Get(AV55Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV55Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV17Session.Get(AV55Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESID") == 0 )
            {
               AV21TFSolicitudesID = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV21TFSolicitudesID", StringUtil.LTrimStr( (decimal)(AV21TFSolicitudesID), 18, 0));
               AV22TFSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV22TFSolicitudesID_To", StringUtil.LTrimStr( (decimal)(AV22TFSolicitudesID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOMBRE") == 0 )
            {
               AV23TFSolicitudesNombre = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFSolicitudesNombre", AV23TFSolicitudesNombre);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESNOMBRE_SEL") == 0 )
            {
               AV24TFSolicitudesNombre_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFSolicitudesNombre_Sel", AV24TFSolicitudesNombre_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESTELEFONO") == 0 )
            {
               AV25TFSolicitudesTelefono = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25TFSolicitudesTelefono", AV25TFSolicitudesTelefono);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESTELEFONO_SEL") == 0 )
            {
               AV26TFSolicitudesTelefono_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV26TFSolicitudesTelefono_Sel", AV26TFSolicitudesTelefono_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESMAIL") == 0 )
            {
               AV27TFSolicitudesMail = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV27TFSolicitudesMail", AV27TFSolicitudesMail);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESMAIL_SEL") == 0 )
            {
               AV28TFSolicitudesMail_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28TFSolicitudesMail_Sel", AV28TFSolicitudesMail_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOID") == 0 )
            {
               AV29TFDepartamentoId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV29TFDepartamentoId", StringUtil.LTrimStr( (decimal)(AV29TFDepartamentoId), 18, 0));
               AV30TFDepartamentoId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV30TFDepartamentoId_To", StringUtil.LTrimStr( (decimal)(AV30TFDepartamentoId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIOID") == 0 )
            {
               AV31TFDepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV31TFDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV31TFDepartamentoMunicipioId), 18, 0));
               AV32TFDepartamentoMunicipioId_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV32TFDepartamentoMunicipioId_To", StringUtil.LTrimStr( (decimal)(AV32TFDepartamentoMunicipioId_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFZONASID") == 0 )
            {
               AV33TFZonasID = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV33TFZonasID", StringUtil.LTrimStr( (decimal)(AV33TFZonasID), 18, 0));
               AV34TFZonasID_To = (long)(Math.Round(NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV34TFZonasID_To", StringUtil.LTrimStr( (decimal)(AV34TFZonasID_To), 18, 0));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDIRECCION") == 0 )
            {
               AV35TFSolicitudesDireccion = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV35TFSolicitudesDireccion", AV35TFSolicitudesDireccion);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDIRECCION_SEL") == 0 )
            {
               AV36TFSolicitudesDireccion_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV36TFSolicitudesDireccion_Sel", AV36TFSolicitudesDireccion_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESTOTAL") == 0 )
            {
               AV37TFSolicitudesTotal = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV37TFSolicitudesTotal", StringUtil.LTrimStr( AV37TFSolicitudesTotal, 18, 2));
               AV38TFSolicitudesTotal_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV38TFSolicitudesTotal_To", StringUtil.LTrimStr( AV38TFSolicitudesTotal_To, 18, 2));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOSOLCOTI_SEL") == 0 )
            {
               AV39TFSolicitudServicioSolCoti_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV39TFSolicitudServicioSolCoti_Sel", AV39TFSolicitudServicioSolCoti_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOPFINAL") == 0 )
            {
               AV40TFSolicitudServicioPFinal = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri(sPrefix, false, "AV40TFSolicitudServicioPFinal", StringUtil.LTrimStr( AV40TFSolicitudServicioPFinal, 18, 2));
               AV41TFSolicitudServicioPFinal_To = NumberUtil.Val( AV13GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri(sPrefix, false, "AV41TFSolicitudServicioPFinal_To", StringUtil.LTrimStr( AV41TFSolicitudServicioPFinal_To, 18, 2));
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSolicitudesNombre_Sel)),  AV24TFSolicitudesNombre_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesTelefono_Sel)),  AV26TFSolicitudesTelefono_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSolicitudesMail_Sel)),  AV28TFSolicitudesMail_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSolicitudesDireccion_Sel)),  AV36TFSolicitudesDireccion_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSolicitudServicioSolCoti_Sel)),  AV39TFSolicitudServicioSolCoti_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|"+GXt_char5+"|"+GXt_char6+"||||"+GXt_char7+"||"+GXt_char8+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSolicitudesNombre)),  AV23TFSolicitudesNombre, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSolicitudesTelefono)),  AV25TFSolicitudesTelefono, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSolicitudesMail)),  AV27TFSolicitudesMail, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSolicitudesDireccion)),  AV35TFSolicitudesDireccion, out  GXt_char5) ;
         Ddo_grid_Filteredtext_set = ((0==AV21TFSolicitudesID) ? "" : StringUtil.Str( (decimal)(AV21TFSolicitudesID), 18, 0))+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+((0==AV29TFDepartamentoId) ? "" : StringUtil.Str( (decimal)(AV29TFDepartamentoId), 18, 0))+"|"+((0==AV31TFDepartamentoMunicipioId) ? "" : StringUtil.Str( (decimal)(AV31TFDepartamentoMunicipioId), 18, 0))+"|"+((0==AV33TFZonasID) ? "" : StringUtil.Str( (decimal)(AV33TFZonasID), 18, 0))+"|"+GXt_char5+"|"+((Convert.ToDecimal(0)==AV37TFSolicitudesTotal) ? "" : StringUtil.Str( AV37TFSolicitudesTotal, 18, 2))+"||"+((Convert.ToDecimal(0)==AV40TFSolicitudServicioPFinal) ? "" : StringUtil.Str( AV40TFSolicitudServicioPFinal, 18, 2));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV22TFSolicitudesID_To) ? "" : StringUtil.Str( (decimal)(AV22TFSolicitudesID_To), 18, 0))+"||||"+((0==AV30TFDepartamentoId_To) ? "" : StringUtil.Str( (decimal)(AV30TFDepartamentoId_To), 18, 0))+"|"+((0==AV32TFDepartamentoMunicipioId_To) ? "" : StringUtil.Str( (decimal)(AV32TFDepartamentoMunicipioId_To), 18, 0))+"|"+((0==AV34TFZonasID_To) ? "" : StringUtil.Str( (decimal)(AV34TFZonasID_To), 18, 0))+"||"+((Convert.ToDecimal(0)==AV38TFSolicitudesTotal_To) ? "" : StringUtil.Str( AV38TFSolicitudesTotal_To, 18, 2))+"||"+((Convert.ToDecimal(0)==AV41TFSolicitudServicioPFinal_To) ? "" : StringUtil.Str( AV41TFSolicitudServicioPFinal_To, 18, 2));
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV17Session.Get(AV55Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  context.GetMessage( "WWP_FullTextFilterDescription", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFSOLICITUDESID",  context.GetMessage( "Solicitud No:", ""),  !((0==AV21TFSolicitudesID)&&(0==AV22TFSolicitudesID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV21TFSolicitudesID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV22TFSolicitudesID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFSOLICITUDESNOMBRE",  context.GetMessage( "Nombre de la Persona/Contacto", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSolicitudesNombre)),  0,  AV23TFSolicitudesNombre,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSolicitudesNombre_Sel)),  AV24TFSolicitudesNombre_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFSOLICITUDESTELEFONO",  context.GetMessage( "Teléfono", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSolicitudesTelefono)),  0,  AV25TFSolicitudesTelefono,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesTelefono_Sel)),  AV26TFSolicitudesTelefono_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFSOLICITUDESMAIL",  context.GetMessage( "Mail", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSolicitudesMail)),  0,  AV27TFSolicitudesMail,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSolicitudesMail_Sel)),  AV28TFSolicitudesMail_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFDEPARTAMENTOID",  context.GetMessage( "Departamento", ""),  !((0==AV29TFDepartamentoId)&&(0==AV30TFDepartamentoId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV29TFDepartamentoId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV30TFDepartamentoId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFDEPARTAMENTOMUNICIPIOID",  context.GetMessage( "Identificador", ""),  !((0==AV31TFDepartamentoMunicipioId)&&(0==AV32TFDepartamentoMunicipioId_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV31TFDepartamentoMunicipioId), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV32TFDepartamentoMunicipioId_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFZONASID",  context.GetMessage( "Zona", ""),  !((0==AV33TFZonasID)&&(0==AV34TFZonasID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV33TFZonasID), 18, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV34TFZonasID_To), 18, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFSOLICITUDESDIRECCION",  context.GetMessage( "Dirección", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSolicitudesDireccion)),  0,  AV35TFSolicitudesDireccion,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSolicitudesDireccion_Sel)),  AV36TFSolicitudesDireccion_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFSOLICITUDESTOTAL",  context.GetMessage( "Total Instalación", ""),  !((Convert.ToDecimal(0)==AV37TFSolicitudesTotal)&&(Convert.ToDecimal(0)==AV38TFSolicitudesTotal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV37TFSolicitudesTotal, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV38TFSolicitudesTotal_To, 18, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFSOLICITUDSERVICIOSOLCOTI_SEL",  context.GetMessage( "Solicitar cotización ", ""),  !String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSolicitudServicioSolCoti_Sel)),  0,  AV39TFSolicitudServicioSolCoti_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFSOLICITUDSERVICIOPFINAL",  context.GetMessage( "Precio Final", ""),  !((Convert.ToDecimal(0)==AV40TFSolicitudServicioPFinal)&&(Convert.ToDecimal(0)==AV41TFSolicitudServicioPFinal_To)),  0,  StringUtil.Trim( StringUtil.Str( AV40TFSolicitudServicioPFinal, 18, 2)),  StringUtil.Trim( StringUtil.Str( AV41TFSolicitudServicioPFinal_To, 18, 2))) ;
         if ( ! (0==AV8MetodoPagosID) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&METODOPAGOSID";
            AV13GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV8MetodoPagosID), 18, 0);
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV55Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV55Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "Solicitudes";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "MetodoPagosID";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV8MetodoPagosID), 18, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV17Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void wb_table1_22_2F2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV18ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_27_2F2( true) ;
         }
         else
         {
            wb_table2_27_2F2( false) ;
         }
         return  ;
      }

      protected void wb_table2_27_2F2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_2F2e( true) ;
         }
         else
         {
            wb_table1_22_2F2e( false) ;
         }
      }

      protected void wb_table2_27_2F2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", context.GetMessage( "WWP_Search", ""), edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_MetodoPagosSolicitudesWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_27_2F2e( true) ;
         }
         else
         {
            wb_table2_27_2F2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8MetodoPagosID = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV8MetodoPagosID", StringUtil.LTrimStr( (decimal)(AV8MetodoPagosID), 18, 0));
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
         PA2F2( ) ;
         WS2F2( ) ;
         WE2F2( ) ;
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
         sCtrlAV8MetodoPagosID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2F2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "metodopagossolicitudeswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2F2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8MetodoPagosID = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV8MetodoPagosID", StringUtil.LTrimStr( (decimal)(AV8MetodoPagosID), 18, 0));
         }
         wcpOAV8MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8MetodoPagosID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV8MetodoPagosID != wcpOAV8MetodoPagosID ) ) )
         {
            setjustcreated();
         }
         wcpOAV8MetodoPagosID = AV8MetodoPagosID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8MetodoPagosID = cgiGet( sPrefix+"AV8MetodoPagosID_CTRL");
         if ( StringUtil.Len( sCtrlAV8MetodoPagosID) > 0 )
         {
            AV8MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV8MetodoPagosID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV8MetodoPagosID", StringUtil.LTrimStr( (decimal)(AV8MetodoPagosID), 18, 0));
         }
         else
         {
            AV8MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV8MetodoPagosID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA2F2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2F2( ) ;
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
         WS2F2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8MetodoPagosID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8MetodoPagosID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8MetodoPagosID_CTRL", StringUtil.RTrim( sCtrlAV8MetodoPagosID));
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
         WE2F2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026980392481", true, true, false);
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
         context.AddJavascriptSource("metodopagossolicitudeswc.js", "?2026980392482", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true, false);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true, false);
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

      protected void SubsflControlProps_372( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_37_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_37_idx;
         edtSolicitudesID_Internalname = sPrefix+"SOLICITUDESID_"+sGXsfl_37_idx;
         edtSolicitudesNombre_Internalname = sPrefix+"SOLICITUDESNOMBRE_"+sGXsfl_37_idx;
         edtSolicitudesTelefono_Internalname = sPrefix+"SOLICITUDESTELEFONO_"+sGXsfl_37_idx;
         edtSolicitudesMail_Internalname = sPrefix+"SOLICITUDESMAIL_"+sGXsfl_37_idx;
         edtPaisID_Internalname = sPrefix+"PAISID_"+sGXsfl_37_idx;
         edtDepartamentoId_Internalname = sPrefix+"DEPARTAMENTOID_"+sGXsfl_37_idx;
         edtDepartamentoMunicipioId_Internalname = sPrefix+"DEPARTAMENTOMUNICIPIOID_"+sGXsfl_37_idx;
         edtZonasID_Internalname = sPrefix+"ZONASID_"+sGXsfl_37_idx;
         edtSolicitudesDireccion_Internalname = sPrefix+"SOLICITUDESDIRECCION_"+sGXsfl_37_idx;
         edtSolicitudesAutoEnumerar_Internalname = sPrefix+"SOLICITUDESAUTOENUMERAR_"+sGXsfl_37_idx;
         edtSolicitudesTotal_Internalname = sPrefix+"SOLICITUDESTOTAL_"+sGXsfl_37_idx;
         chkSolicitudServicioSolCoti_Internalname = sPrefix+"SOLICITUDSERVICIOSOLCOTI_"+sGXsfl_37_idx;
         edtSolicitudServicioPFinal_Internalname = sPrefix+"SOLICITUDSERVICIOPFINAL_"+sGXsfl_37_idx;
      }

      protected void SubsflControlProps_fel_372( )
      {
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_37_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_37_fel_idx;
         edtSolicitudesID_Internalname = sPrefix+"SOLICITUDESID_"+sGXsfl_37_fel_idx;
         edtSolicitudesNombre_Internalname = sPrefix+"SOLICITUDESNOMBRE_"+sGXsfl_37_fel_idx;
         edtSolicitudesTelefono_Internalname = sPrefix+"SOLICITUDESTELEFONO_"+sGXsfl_37_fel_idx;
         edtSolicitudesMail_Internalname = sPrefix+"SOLICITUDESMAIL_"+sGXsfl_37_fel_idx;
         edtPaisID_Internalname = sPrefix+"PAISID_"+sGXsfl_37_fel_idx;
         edtDepartamentoId_Internalname = sPrefix+"DEPARTAMENTOID_"+sGXsfl_37_fel_idx;
         edtDepartamentoMunicipioId_Internalname = sPrefix+"DEPARTAMENTOMUNICIPIOID_"+sGXsfl_37_fel_idx;
         edtZonasID_Internalname = sPrefix+"ZONASID_"+sGXsfl_37_fel_idx;
         edtSolicitudesDireccion_Internalname = sPrefix+"SOLICITUDESDIRECCION_"+sGXsfl_37_fel_idx;
         edtSolicitudesAutoEnumerar_Internalname = sPrefix+"SOLICITUDESAUTOENUMERAR_"+sGXsfl_37_fel_idx;
         edtSolicitudesTotal_Internalname = sPrefix+"SOLICITUDESTOTAL_"+sGXsfl_37_fel_idx;
         chkSolicitudServicioSolCoti_Internalname = sPrefix+"SOLICITUDSERVICIOSOLCOTI_"+sGXsfl_37_fel_idx;
         edtSolicitudServicioPFinal_Internalname = sPrefix+"SOLICITUDSERVICIOPFINAL_"+sGXsfl_37_fel_idx;
      }

      protected void sendrow_372( )
      {
         sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
         SubsflControlProps_372( ) ;
         WB2F0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_37_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_37_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_37_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV53Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",context.GetMessage( "GXM_update", ""),(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'" + sGXsfl_37_idx + "',37)\"";
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV54Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",context.GetMessage( "GX_BtnDelete", ""),(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesNombre_Internalname,StringUtil.RTrim( A171SolicitudesNombre),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSolicitudesNombre_Link,(string)"",(string)"",(string)"",(string)edtSolicitudesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A172SolicitudesTelefono);
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesTelefono_Internalname,StringUtil.RTrim( A172SolicitudesTelefono),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"598 099 999999",(string)edtSolicitudesTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesMail_Internalname,(string)A206SolicitudesMail,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A206SolicitudesMail,(string)"",(string)"",(string)"",(string)edtSolicitudesMail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaisID_Internalname,StringUtil.RTrim( A116PaisID),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaisID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoMunicipioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A114DepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoMunicipioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtZonasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A110ZonasID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",context.GetMessage( "Seleccione su Zona", ""),(string)edtZonasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesDireccion_Internalname,(string)A173SolicitudesDireccion,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",context.GetMessage( "Calle, casa numero 1234...", ""),(string)edtSolicitudesDireccion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesAutoEnumerar_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A194SolicitudesAutoEnumerar), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A194SolicitudesAutoEnumerar), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesAutoEnumerar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A174SolicitudesTotal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A174SolicitudesTotal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "SOLICITUDSERVICIOSOLCOTI_" + sGXsfl_37_idx;
            chkSolicitudServicioSolCoti.Name = GXCCtl;
            chkSolicitudServicioSolCoti.WebTags = "";
            chkSolicitudServicioSolCoti.Caption = "";
            AssignProp(sPrefix, false, chkSolicitudServicioSolCoti_Internalname, "TitleCaption", chkSolicitudServicioSolCoti.Caption, !bGXsfl_37_Refreshing);
            chkSolicitudServicioSolCoti.CheckedValue = "N";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkSolicitudServicioSolCoti_Internalname,(string)A210SolicitudServicioSolCoti,(string)"",(string)"",(short)-1,(short)0,(string)"S",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudServicioPFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A211SolicitudServicioPFinal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A211SolicitudServicioPFinal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudServicioPFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)21,(short)0,(short)0,(short)37,(short)0,(short)-1,(short)0,(bool)true,(string)"Precio",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes2F2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_37_idx = ((subGrid_Islastpage==1)&&(nGXsfl_37_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_37_idx+1);
            sGXsfl_37_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_37_idx), 4, 0), 4, "0");
            SubsflControlProps_372( ) ;
         }
         /* End function sendrow_372 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "SOLICITUDSERVICIOSOLCOTI_" + sGXsfl_37_idx;
         chkSolicitudServicioSolCoti.Name = GXCCtl;
         chkSolicitudServicioSolCoti.WebTags = "";
         chkSolicitudServicioSolCoti.Caption = "";
         AssignProp(sPrefix, false, chkSolicitudServicioSolCoti_Internalname, "TitleCaption", chkSolicitudServicioSolCoti.Caption, !bGXsfl_37_Refreshing);
         chkSolicitudServicioSolCoti.CheckedValue = "N";
         /* End function init_web_controls */
      }

      protected void StartGridControl37( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"37\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitud No:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre de la Persona/Contacto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Teléfono", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mail", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "PaisId", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Departamento", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Zona", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Dirección", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Auto Enumerar", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Total Instalación", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Solicitar cotización ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Final", "")) ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV53Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV54Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A171SolicitudesNombre)));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSolicitudesNombre_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A172SolicitudesTelefono)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A206SolicitudesMail));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A116PaisID)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A114DepartamentoMunicipioId), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A110ZonasID), 18, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A173SolicitudesDireccion));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A194SolicitudesAutoEnumerar), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A174SolicitudesTotal, 21, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A210SolicitudServicioSolCoti)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A211SolicitudServicioPFinal, 21, 2, ".", ""))));
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
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         tblTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         tblTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         edtSolicitudesID_Internalname = sPrefix+"SOLICITUDESID";
         edtSolicitudesNombre_Internalname = sPrefix+"SOLICITUDESNOMBRE";
         edtSolicitudesTelefono_Internalname = sPrefix+"SOLICITUDESTELEFONO";
         edtSolicitudesMail_Internalname = sPrefix+"SOLICITUDESMAIL";
         edtPaisID_Internalname = sPrefix+"PAISID";
         edtDepartamentoId_Internalname = sPrefix+"DEPARTAMENTOID";
         edtDepartamentoMunicipioId_Internalname = sPrefix+"DEPARTAMENTOMUNICIPIOID";
         edtZonasID_Internalname = sPrefix+"ZONASID";
         edtSolicitudesDireccion_Internalname = sPrefix+"SOLICITUDESDIRECCION";
         edtSolicitudesAutoEnumerar_Internalname = sPrefix+"SOLICITUDESAUTOENUMERAR";
         edtSolicitudesTotal_Internalname = sPrefix+"SOLICITUDESTOTAL";
         chkSolicitudServicioSolCoti_Internalname = sPrefix+"SOLICITUDSERVICIOSOLCOTI";
         edtSolicitudServicioPFinal_Internalname = sPrefix+"SOLICITUDSERVICIOPFINAL";
         Gridpaginationbar_Internalname = sPrefix+"GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = sPrefix+"GRIDTABLEWITHPAGINATIONBAR";
         divTablegridheader_Internalname = sPrefix+"TABLEGRIDHEADER";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         edtMetodoPagosID_Internalname = sPrefix+"METODOPAGOSID";
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
         edtSolicitudServicioPFinal_Jsonclick = "";
         chkSolicitudServicioSolCoti.Caption = "";
         edtSolicitudesTotal_Jsonclick = "";
         edtSolicitudesAutoEnumerar_Jsonclick = "";
         edtSolicitudesDireccion_Jsonclick = "";
         edtZonasID_Jsonclick = "";
         edtDepartamentoMunicipioId_Jsonclick = "";
         edtDepartamentoId_Jsonclick = "";
         edtPaisID_Jsonclick = "";
         edtSolicitudesMail_Jsonclick = "";
         edtSolicitudesTelefono_Jsonclick = "";
         edtSolicitudesNombre_Jsonclick = "";
         edtSolicitudesNombre_Link = "";
         edtSolicitudesID_Jsonclick = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtMetodoPagosID_Enabled = 0;
         edtSolicitudServicioPFinal_Enabled = 0;
         chkSolicitudServicioSolCoti.Enabled = 0;
         edtSolicitudesTotal_Enabled = 0;
         edtSolicitudesAutoEnumerar_Enabled = 0;
         edtSolicitudesDireccion_Enabled = 0;
         edtZonasID_Enabled = 0;
         edtDepartamentoMunicipioId_Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         edtPaisID_Enabled = 0;
         edtSolicitudesMail_Enabled = 0;
         edtSolicitudesTelefono_Enabled = 0;
         edtSolicitudesNombre_Enabled = 0;
         edtSolicitudesID_Enabled = 0;
         subGrid_Sortable = 0;
         edtMetodoPagosID_Jsonclick = "";
         edtMetodoPagosID_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;L;;;;;;;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Format = "18.0||||18.0|18.0|18.0||-18.2||-18.2";
         Ddo_grid_Datalistproc = "MetodoPagosSolicitudesWCGetFilterData";
         Ddo_grid_Datalistfixedvalues = "|||||||||S:WWP_TSChecked,N:WWP_TSUnChecked|";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic||||Dynamic||FixedValues|";
         Ddo_grid_Includedatalist = "|T|T|T||||T||T|";
         Ddo_grid_Filterisrange = "T||||T|T|T||T||T";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|Numeric|Numeric|Numeric|Character|Numeric||Numeric";
         Ddo_grid_Includefilter = "T|T|T|T|T|T|T|T|T||T";
         Ddo_grid_Includesortasc = "T|T|T|T|T|T|T|T||T|";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8||9|";
         Ddo_grid_Columnids = "2:SolicitudesID|3:SolicitudesNombre|4:SolicitudesTelefono|5:SolicitudesMail|7:DepartamentoId|8:DepartamentoMunicipioId|9:ZonasID|10:SolicitudesDireccion|12:SolicitudesTotal|13:SolicitudServicioSolCoti|14:SolicitudServicioPFinal";
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
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'sPrefix',type:'char'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8MetodoPagosID',fld:'vMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV24TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV26TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV27TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV28TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV29TFDepartamentoId',fld:'vTFDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFDepartamentoId_To',fld:'vTFDEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFDepartamentoMunicipioId',fld:'vTFDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFDepartamentoMunicipioId_To',fld:'vTFDEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFZonasID',fld:'vTFZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFZonasID_To',fld:'vTFZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV37TFSolicitudesTotal',fld:'vTFSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV38TFSolicitudesTotal_To',fld:'vTFSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV39TFSolicitudServicioSolCoti_Sel',fld:'vTFSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV40TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV46GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV47GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E122F2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8MetodoPagosID',fld:'vMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV24TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV26TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV27TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV28TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV29TFDepartamentoId',fld:'vTFDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFDepartamentoId_To',fld:'vTFDEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFDepartamentoMunicipioId',fld:'vTFDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFDepartamentoMunicipioId_To',fld:'vTFDEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFZonasID',fld:'vTFZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFZonasID_To',fld:'vTFZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV37TFSolicitudesTotal',fld:'vTFSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV38TFSolicitudesTotal_To',fld:'vTFSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV39TFSolicitudServicioSolCoti_Sel',fld:'vTFSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV40TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV46GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV47GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E132F2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8MetodoPagosID',fld:'vMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV24TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV26TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV27TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV28TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV29TFDepartamentoId',fld:'vTFDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFDepartamentoId_To',fld:'vTFDEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFDepartamentoMunicipioId',fld:'vTFDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFDepartamentoMunicipioId_To',fld:'vTFDEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFZonasID',fld:'vTFZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFZonasID_To',fld:'vTFZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV37TFSolicitudesTotal',fld:'vTFSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV38TFSolicitudesTotal_To',fld:'vTFSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV39TFSolicitudServicioSolCoti_Sel',fld:'vTFSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV40TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E142F2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8MetodoPagosID',fld:'vMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV24TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV26TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV27TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV28TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV29TFDepartamentoId',fld:'vTFDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFDepartamentoId_To',fld:'vTFDEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFDepartamentoMunicipioId',fld:'vTFDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFDepartamentoMunicipioId_To',fld:'vTFDEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFZonasID',fld:'vTFZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFZonasID_To',fld:'vTFZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV37TFSolicitudesTotal',fld:'vTFSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV38TFSolicitudesTotal_To',fld:'vTFSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV39TFSolicitudServicioSolCoti_Sel',fld:'vTFSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV40TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV40TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV39TFSolicitudServicioSolCoti_Sel',fld:'vTFSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV37TFSolicitudesTotal',fld:'vTFSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV38TFSolicitudesTotal_To',fld:'vTFSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV35TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV33TFZonasID',fld:'vTFZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFZonasID_To',fld:'vTFZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFDepartamentoMunicipioId',fld:'vTFDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFDepartamentoMunicipioId_To',fld:'vTFDEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV29TFDepartamentoId',fld:'vTFDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFDepartamentoId_To',fld:'vTFDEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV27TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV28TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV25TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV26TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV23TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV24TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV21TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E182F2',iparms:[{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV53Update',fld:'vUPDATE',pic:'',type:'char'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV54Delete',fld:'vDELETE',pic:'',type:'char'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtSolicitudesNombre_Link',ctrl:'SOLICITUDESNOMBRE',prop:'Link'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E112F2',iparms:[{av:'GRID_nFirstRecordOnPage',type:'int'},{av:'GRID_nEOF',type:'int'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV8MetodoPagosID',fld:'vMETODOPAGOSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV55Pgmname',fld:'vPGMNAME',pic:'',hsh:true,type:'char'},{av:'AV21TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV24TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV26TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV27TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV28TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV29TFDepartamentoId',fld:'vTFDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFDepartamentoId_To',fld:'vTFDEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFDepartamentoMunicipioId',fld:'vTFDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFDepartamentoMunicipioId_To',fld:'vTFDEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFZonasID',fld:'vTFZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFZonasID_To',fld:'vTFZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV37TFSolicitudesTotal',fld:'vTFSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV38TFSolicitudesTotal_To',fld:'vTFSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV39TFSolicitudServicioSolCoti_Sel',fld:'vTFSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV40TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'sPrefix',type:'char'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV20ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9',type:'int'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9',type:'int'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:'',type:'boolean'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:'',type:'svchar'},{av:'AV21TFSolicitudesID',fld:'vTFSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV22TFSolicitudesID_To',fld:'vTFSOLICITUDESID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV23TFSolicitudesNombre',fld:'vTFSOLICITUDESNOMBRE',pic:'',type:'char'},{av:'AV24TFSolicitudesNombre_Sel',fld:'vTFSOLICITUDESNOMBRE_SEL',pic:'',type:'char'},{av:'AV25TFSolicitudesTelefono',fld:'vTFSOLICITUDESTELEFONO',pic:'',type:'char'},{av:'AV26TFSolicitudesTelefono_Sel',fld:'vTFSOLICITUDESTELEFONO_SEL',pic:'',type:'char'},{av:'AV27TFSolicitudesMail',fld:'vTFSOLICITUDESMAIL',pic:'',type:'svchar'},{av:'AV28TFSolicitudesMail_Sel',fld:'vTFSOLICITUDESMAIL_SEL',pic:'',type:'svchar'},{av:'AV29TFDepartamentoId',fld:'vTFDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV30TFDepartamentoId_To',fld:'vTFDEPARTAMENTOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV31TFDepartamentoMunicipioId',fld:'vTFDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV32TFDepartamentoMunicipioId_To',fld:'vTFDEPARTAMENTOMUNICIPIOID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV33TFZonasID',fld:'vTFZONASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV34TFZonasID_To',fld:'vTFZONASID_TO',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV35TFSolicitudesDireccion',fld:'vTFSOLICITUDESDIRECCION',pic:'',type:'svchar'},{av:'AV36TFSolicitudesDireccion_Sel',fld:'vTFSOLICITUDESDIRECCION_SEL',pic:'',type:'svchar'},{av:'AV37TFSolicitudesTotal',fld:'vTFSOLICITUDESTOTAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV38TFSolicitudesTotal_To',fld:'vTFSOLICITUDESTOTAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV39TFSolicitudServicioSolCoti_Sel',fld:'vTFSOLICITUDSERVICIOSOLCOTI_SEL',pic:'',type:'char'},{av:'AV40TFSolicitudServicioPFinal',fld:'vTFSOLICITUDSERVICIOPFINAL',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'AV41TFSolicitudServicioPFinal_To',fld:'vTFSOLICITUDSERVICIOPFINAL_TO',pic:'ZZZZZZ,ZZZ,ZZZ,ZZ9.99',type:'decimal'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV45GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV46GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV47GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:'',type:'svchar'},{av:'AV49IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true,type:'boolean'},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'AV50IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true,type:'boolean'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV18ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E152F2',iparms:[{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESID","{handler:'Valid_Solicitudesid',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESID",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESNOMBRE","{handler:'Valid_Solicitudesnombre',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESNOMBRE",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESTELEFONO","{handler:'Valid_Solicitudestelefono',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESTELEFONO",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESMAIL","{handler:'Valid_Solicitudesmail',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESMAIL",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID","{handler:'Valid_Departamentomunicipioid',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTOMUNICIPIOID",",oparms:[]}");
         setEventMetadata("VALID_ZONASID","{handler:'Valid_Zonasid',iparms:[]");
         setEventMetadata("VALID_ZONASID",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESDIRECCION","{handler:'Valid_Solicitudesdireccion',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESDIRECCION",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDESTOTAL","{handler:'Valid_Solicitudestotal',iparms:[]");
         setEventMetadata("VALID_SOLICITUDESTOTAL",",oparms:[]}");
         setEventMetadata("VALID_SOLICITUDSERVICIOPFINAL","{handler:'Valid_Solicitudserviciopfinal',iparms:[]");
         setEventMetadata("VALID_SOLICITUDSERVICIOPFINAL",",oparms:[]}");
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
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV16FilterFullText = "";
         AV55Pgmname = "";
         AV23TFSolicitudesNombre = "";
         AV24TFSolicitudesNombre_Sel = "";
         AV25TFSolicitudesTelefono = "";
         AV26TFSolicitudesTelefono_Sel = "";
         AV27TFSolicitudesMail = "";
         AV28TFSolicitudesMail_Sel = "";
         AV35TFSolicitudesDireccion = "";
         AV36TFSolicitudesDireccion_Sel = "";
         AV39TFSolicitudServicioSolCoti_Sel = "";
         H002F2_A127SolicitudesID = new long[1] ;
         H002F2_A134SolicitudesItemsID = new short[1] ;
         H002F2_A180SolicitudItemsComision = new decimal[1] ;
         H002F2_A179SolicitudItemsComisionTipo = new string[] {""} ;
         H002F2_A178SolicitudItemsSR = new string[] {""} ;
         H002F2_A177SolicitudesItemsCantidad = new short[1] ;
         H002F2_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         H002F2_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV18ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV47GridAppliedFilters = "";
         AV42DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtninsert_Jsonclick = "";
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
         AV53Update = "";
         AV54Delete = "";
         A171SolicitudesNombre = "";
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         A116PaisID = "";
         A173SolicitudesDireccion = "";
         A210SolicitudServicioSolCoti = "";
         GXDecQS = "";
         lV23TFSolicitudesNombre = "";
         lV25TFSolicitudesTelefono = "";
         lV27TFSolicitudesMail = "";
         lV35TFSolicitudesDireccion = "";
         H002F3_A128MetodoPagosID = new long[1] ;
         H002F3_A210SolicitudServicioSolCoti = new string[] {""} ;
         H002F3_A194SolicitudesAutoEnumerar = new short[1] ;
         H002F3_A173SolicitudesDireccion = new string[] {""} ;
         H002F3_A110ZonasID = new long[1] ;
         H002F3_n110ZonasID = new bool[] {false} ;
         H002F3_A114DepartamentoMunicipioId = new long[1] ;
         H002F3_n114DepartamentoMunicipioId = new bool[] {false} ;
         H002F3_A112DepartamentoId = new long[1] ;
         H002F3_n112DepartamentoId = new bool[] {false} ;
         H002F3_A116PaisID = new string[] {""} ;
         H002F3_A206SolicitudesMail = new string[] {""} ;
         H002F3_n206SolicitudesMail = new bool[] {false} ;
         H002F3_A172SolicitudesTelefono = new string[] {""} ;
         H002F3_A171SolicitudesNombre = new string[] {""} ;
         H002F3_A127SolicitudesID = new long[1] ;
         H002F3_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         H002F3_A212SolicitudesCotizacion = new decimal[1] ;
         H002F3_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         H002F3_A897SolicitudesDescuento = new decimal[1] ;
         H002F3_n897SolicitudesDescuento = new bool[] {false} ;
         H002F3_A864SolicitudesCostoXZona = new decimal[1] ;
         H002F4_A128MetodoPagosID = new long[1] ;
         H002F4_A210SolicitudServicioSolCoti = new string[] {""} ;
         H002F4_A194SolicitudesAutoEnumerar = new short[1] ;
         H002F4_A173SolicitudesDireccion = new string[] {""} ;
         H002F4_A110ZonasID = new long[1] ;
         H002F4_n110ZonasID = new bool[] {false} ;
         H002F4_A114DepartamentoMunicipioId = new long[1] ;
         H002F4_n114DepartamentoMunicipioId = new bool[] {false} ;
         H002F4_A112DepartamentoId = new long[1] ;
         H002F4_n112DepartamentoId = new bool[] {false} ;
         H002F4_A116PaisID = new string[] {""} ;
         H002F4_A206SolicitudesMail = new string[] {""} ;
         H002F4_n206SolicitudesMail = new bool[] {false} ;
         H002F4_A172SolicitudesTelefono = new string[] {""} ;
         H002F4_A171SolicitudesNombre = new string[] {""} ;
         H002F4_A127SolicitudesID = new long[1] ;
         H002F4_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         H002F4_A212SolicitudesCotizacion = new decimal[1] ;
         H002F4_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         H002F4_A897SolicitudesDescuento = new decimal[1] ;
         H002F4_n897SolicitudesDescuento = new bool[] {false} ;
         H002F4_A864SolicitudesCostoXZona = new decimal[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV19ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV17Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8MetodoPagosID = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         gxphoneLink = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.metodopagossolicitudeswc__default(),
            new Object[][] {
                new Object[] {
               H002F2_A127SolicitudesID, H002F2_A134SolicitudesItemsID, H002F2_A180SolicitudItemsComision, H002F2_A179SolicitudItemsComisionTipo, H002F2_A178SolicitudItemsSR, H002F2_A177SolicitudesItemsCantidad, H002F2_A176SolicitudesItemsPrecioFinal, H002F2_n176SolicitudesItemsPrecioFinal
               }
               , new Object[] {
               H002F3_A128MetodoPagosID, H002F3_A210SolicitudServicioSolCoti, H002F3_A194SolicitudesAutoEnumerar, H002F3_A173SolicitudesDireccion, H002F3_A110ZonasID, H002F3_n110ZonasID, H002F3_A114DepartamentoMunicipioId, H002F3_n114DepartamentoMunicipioId, H002F3_A112DepartamentoId, H002F3_n112DepartamentoId,
               H002F3_A116PaisID, H002F3_A206SolicitudesMail, H002F3_n206SolicitudesMail, H002F3_A172SolicitudesTelefono, H002F3_A171SolicitudesNombre, H002F3_A127SolicitudesID, H002F3_A796SolicitudesComisionMetodoPago, H002F3_A212SolicitudesCotizacion, H002F3_A1016SolicitudesDescuentoCupon, H002F3_A897SolicitudesDescuento,
               H002F3_n897SolicitudesDescuento, H002F3_A864SolicitudesCostoXZona
               }
               , new Object[] {
               H002F4_A128MetodoPagosID, H002F4_A210SolicitudServicioSolCoti, H002F4_A194SolicitudesAutoEnumerar, H002F4_A173SolicitudesDireccion, H002F4_A110ZonasID, H002F4_n110ZonasID, H002F4_A114DepartamentoMunicipioId, H002F4_n114DepartamentoMunicipioId, H002F4_A112DepartamentoId, H002F4_n112DepartamentoId,
               H002F4_A116PaisID, H002F4_A206SolicitudesMail, H002F4_n206SolicitudesMail, H002F4_A172SolicitudesTelefono, H002F4_A171SolicitudesNombre, H002F4_A127SolicitudesID, H002F4_A796SolicitudesComisionMetodoPago, H002F4_A212SolicitudesCotizacion, H002F4_A1016SolicitudesDescuentoCupon, H002F4_A897SolicitudesDescuento,
               H002F4_n897SolicitudesDescuento, H002F4_A864SolicitudesCostoXZona
               }
            }
         );
         AV55Pgmname = "MetodoPagosSolicitudesWC";
         /* GeneXus formulas. */
         AV55Pgmname = "MetodoPagosSolicitudesWC";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV14OrderedBy ;
      private short AV20ManageFiltersExecutionStep ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A194SolicitudesAutoEnumerar ;
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
      private int nRC_GXsfl_37 ;
      private int nGXsfl_37_idx=1 ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int edtMetodoPagosID_Visible ;
      private int subGrid_Islastpage ;
      private int edtSolicitudesID_Enabled ;
      private int edtSolicitudesNombre_Enabled ;
      private int edtSolicitudesTelefono_Enabled ;
      private int edtSolicitudesMail_Enabled ;
      private int edtPaisID_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int edtDepartamentoMunicipioId_Enabled ;
      private int edtZonasID_Enabled ;
      private int edtSolicitudesDireccion_Enabled ;
      private int edtSolicitudesAutoEnumerar_Enabled ;
      private int edtSolicitudesTotal_Enabled ;
      private int edtSolicitudServicioPFinal_Enabled ;
      private int edtMetodoPagosID_Enabled ;
      private int AV44PageToGo ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
      private int AV56GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV8MetodoPagosID ;
      private long wcpOAV8MetodoPagosID ;
      private long GRID_nFirstRecordOnPage ;
      private long AV21TFSolicitudesID ;
      private long AV22TFSolicitudesID_To ;
      private long AV29TFDepartamentoId ;
      private long AV30TFDepartamentoId_To ;
      private long AV31TFDepartamentoMunicipioId ;
      private long AV32TFDepartamentoMunicipioId_To ;
      private long AV33TFZonasID ;
      private long AV34TFZonasID_To ;
      private long A127SolicitudesID ;
      private long AV45GridCurrentPage ;
      private long AV46GridPageCount ;
      private long A128MetodoPagosID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal AV37TFSolicitudesTotal ;
      private decimal AV38TFSolicitudesTotal_To ;
      private decimal AV40TFSolicitudServicioPFinal ;
      private decimal AV41TFSolicitudServicioPFinal_To ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A897SolicitudesDescuento ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A211SolicitudServicioPFinal ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_37_idx="0001" ;
      private string AV55Pgmname ;
      private string AV23TFSolicitudesNombre ;
      private string AV24TFSolicitudesNombre_Sel ;
      private string AV25TFSolicitudesTelefono ;
      private string AV26TFSolicitudesTelefono_Sel ;
      private string AV39TFSolicitudServicioSolCoti_Sel ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Datalistfixedvalues ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablegridheader_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string edtMetodoPagosID_Internalname ;
      private string edtMetodoPagosID_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavFilterfulltext_Internalname ;
      private string AV53Update ;
      private string AV54Delete ;
      private string edtSolicitudesID_Internalname ;
      private string A171SolicitudesNombre ;
      private string edtSolicitudesNombre_Internalname ;
      private string A172SolicitudesTelefono ;
      private string edtSolicitudesTelefono_Internalname ;
      private string edtSolicitudesMail_Internalname ;
      private string A116PaisID ;
      private string edtPaisID_Internalname ;
      private string edtDepartamentoId_Internalname ;
      private string edtDepartamentoMunicipioId_Internalname ;
      private string edtZonasID_Internalname ;
      private string edtSolicitudesDireccion_Internalname ;
      private string edtSolicitudesAutoEnumerar_Internalname ;
      private string edtSolicitudesTotal_Internalname ;
      private string A210SolicitudServicioSolCoti ;
      private string chkSolicitudServicioSolCoti_Internalname ;
      private string edtSolicitudServicioPFinal_Internalname ;
      private string GXDecQS ;
      private string lV23TFSolicitudesNombre ;
      private string lV25TFSolicitudesTelefono ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtSolicitudesNombre_Link ;
      private string GXt_char2 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sCtrlAV8MetodoPagosID ;
      private string sGXsfl_37_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtSolicitudesID_Jsonclick ;
      private string edtSolicitudesNombre_Jsonclick ;
      private string gxphoneLink ;
      private string edtSolicitudesTelefono_Jsonclick ;
      private string edtSolicitudesMail_Jsonclick ;
      private string edtPaisID_Jsonclick ;
      private string edtDepartamentoId_Jsonclick ;
      private string edtDepartamentoMunicipioId_Jsonclick ;
      private string edtZonasID_Jsonclick ;
      private string edtSolicitudesDireccion_Jsonclick ;
      private string edtSolicitudesAutoEnumerar_Jsonclick ;
      private string edtSolicitudesTotal_Jsonclick ;
      private string GXCCtl ;
      private string edtSolicitudServicioPFinal_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV49IsAuthorized_Update ;
      private bool AV50IsAuthorized_Delete ;
      private bool bGXsfl_37_Refreshing=false ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n206SolicitudesMail ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n110ZonasID ;
      private bool n897SolicitudesDescuento ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV51TempBoolean ;
      private bool GXt_boolean3 ;
      private string AV19ManageFiltersXml ;
      private string AV16FilterFullText ;
      private string AV27TFSolicitudesMail ;
      private string AV28TFSolicitudesMail_Sel ;
      private string AV35TFSolicitudesDireccion ;
      private string AV36TFSolicitudesDireccion_Sel ;
      private string AV47GridAppliedFilters ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private string lV27TFSolicitudesMail ;
      private string lV35TFSolicitudesDireccion ;
      private IGxSession AV17Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private GXWebForm Form ;
      private GxHttpRequest AV9HTTPRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkSolicitudServicioSolCoti ;
      private IDataStoreProvider pr_default ;
      private long[] H002F2_A127SolicitudesID ;
      private short[] H002F2_A134SolicitudesItemsID ;
      private decimal[] H002F2_A180SolicitudItemsComision ;
      private string[] H002F2_A179SolicitudItemsComisionTipo ;
      private string[] H002F2_A178SolicitudItemsSR ;
      private short[] H002F2_A177SolicitudesItemsCantidad ;
      private decimal[] H002F2_A176SolicitudesItemsPrecioFinal ;
      private bool[] H002F2_n176SolicitudesItemsPrecioFinal ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV18ManageFiltersData ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV42DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private long[] H002F3_A128MetodoPagosID ;
      private string[] H002F3_A210SolicitudServicioSolCoti ;
      private short[] H002F3_A194SolicitudesAutoEnumerar ;
      private string[] H002F3_A173SolicitudesDireccion ;
      private long[] H002F3_A110ZonasID ;
      private bool[] H002F3_n110ZonasID ;
      private long[] H002F3_A114DepartamentoMunicipioId ;
      private bool[] H002F3_n114DepartamentoMunicipioId ;
      private long[] H002F3_A112DepartamentoId ;
      private bool[] H002F3_n112DepartamentoId ;
      private string[] H002F3_A116PaisID ;
      private string[] H002F3_A206SolicitudesMail ;
      private bool[] H002F3_n206SolicitudesMail ;
      private string[] H002F3_A172SolicitudesTelefono ;
      private string[] H002F3_A171SolicitudesNombre ;
      private long[] H002F3_A127SolicitudesID ;
      private decimal[] H002F3_A796SolicitudesComisionMetodoPago ;
      private decimal[] H002F3_A212SolicitudesCotizacion ;
      private decimal[] H002F3_A1016SolicitudesDescuentoCupon ;
      private decimal[] H002F3_A897SolicitudesDescuento ;
      private bool[] H002F3_n897SolicitudesDescuento ;
      private decimal[] H002F3_A864SolicitudesCostoXZona ;
      private long[] H002F4_A128MetodoPagosID ;
      private string[] H002F4_A210SolicitudServicioSolCoti ;
      private short[] H002F4_A194SolicitudesAutoEnumerar ;
      private string[] H002F4_A173SolicitudesDireccion ;
      private long[] H002F4_A110ZonasID ;
      private bool[] H002F4_n110ZonasID ;
      private long[] H002F4_A114DepartamentoMunicipioId ;
      private bool[] H002F4_n114DepartamentoMunicipioId ;
      private long[] H002F4_A112DepartamentoId ;
      private bool[] H002F4_n112DepartamentoId ;
      private string[] H002F4_A116PaisID ;
      private string[] H002F4_A206SolicitudesMail ;
      private bool[] H002F4_n206SolicitudesMail ;
      private string[] H002F4_A172SolicitudesTelefono ;
      private string[] H002F4_A171SolicitudesNombre ;
      private long[] H002F4_A127SolicitudesID ;
      private decimal[] H002F4_A796SolicitudesComisionMetodoPago ;
      private decimal[] H002F4_A212SolicitudesCotizacion ;
      private decimal[] H002F4_A1016SolicitudesDescuentoCupon ;
      private decimal[] H002F4_A897SolicitudesDescuento ;
      private bool[] H002F4_n897SolicitudesDescuento ;
      private decimal[] H002F4_A864SolicitudesCostoXZona ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class metodopagossolicitudeswc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002F3( IGxContext context ,
                                             long AV21TFSolicitudesID ,
                                             long AV22TFSolicitudesID_To ,
                                             string AV24TFSolicitudesNombre_Sel ,
                                             string AV23TFSolicitudesNombre ,
                                             string AV26TFSolicitudesTelefono_Sel ,
                                             string AV25TFSolicitudesTelefono ,
                                             string AV28TFSolicitudesMail_Sel ,
                                             string AV27TFSolicitudesMail ,
                                             long AV29TFDepartamentoId ,
                                             long AV30TFDepartamentoId_To ,
                                             long AV31TFDepartamentoMunicipioId ,
                                             long AV32TFDepartamentoMunicipioId_To ,
                                             long AV33TFZonasID ,
                                             long AV34TFZonasID_To ,
                                             string AV36TFSolicitudesDireccion_Sel ,
                                             string AV35TFSolicitudesDireccion ,
                                             decimal AV37TFSolicitudesTotal ,
                                             decimal AV38TFSolicitudesTotal_To ,
                                             string AV39TFSolicitudServicioSolCoti_Sel ,
                                             long A127SolicitudesID ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A206SolicitudesMail ,
                                             long A112DepartamentoId ,
                                             long A114DepartamentoMunicipioId ,
                                             long A110ZonasID ,
                                             string A173SolicitudesDireccion ,
                                             decimal A174SolicitudesTotal ,
                                             string A210SolicitudServicioSolCoti ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV40TFSolicitudServicioPFinal ,
                                             decimal AV41TFSolicitudServicioPFinal_To ,
                                             long AV8MetodoPagosID ,
                                             long A128MetodoPagosID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[18];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[MetodoPagosID], T1.[SolicitudServicioSolCoti], T1.[SolicitudesAutoEnumerar], T1.[SolicitudesDireccion], T1.[ZonasID], T1.[DepartamentoMunicipioId], T1.[DepartamentoId], T2.[PaisID], T1.[SolicitudesMail], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T1.[SolicitudesID], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId])";
         AddWhere(sWhereString, "(T1.[MetodoPagosID] = @AV8MetodoPagosID)");
         if ( ! (0==AV21TFSolicitudesID) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV21TFSolicitudesID)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! (0==AV22TFSolicitudesID_To) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV22TFSolicitudesID_To)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSolicitudesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSolicitudesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesNombre]) like UPPER(@lV23TFSolicitudesNombre))");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSolicitudesNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFSolicitudesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesNombre] = @AV24TFSolicitudesNombre_Sel)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFSolicitudesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSolicitudesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesTelefono]) like UPPER(@lV25TFSolicitudesTelefono))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV26TFSolicitudesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesTelefono] = @AV26TFSolicitudesTelefono_Sel)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFSolicitudesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSolicitudesMail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSolicitudesMail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesMail]) like UPPER(@lV27TFSolicitudesMail))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSolicitudesMail_Sel)) && ! ( StringUtil.StrCmp(AV28TFSolicitudesMail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesMail] = @AV28TFSolicitudesMail_Sel)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFSolicitudesMail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesMail] IS NULL or (T1.[SolicitudesMail] = ''))");
         }
         if ( ! (0==AV29TFDepartamentoId) )
         {
            AddWhere(sWhereString, "(T1.[DepartamentoId] >= @AV29TFDepartamentoId)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! (0==AV30TFDepartamentoId_To) )
         {
            AddWhere(sWhereString, "(T1.[DepartamentoId] <= @AV30TFDepartamentoId_To)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! (0==AV31TFDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "(T1.[DepartamentoMunicipioId] >= @AV31TFDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! (0==AV32TFDepartamentoMunicipioId_To) )
         {
            AddWhere(sWhereString, "(T1.[DepartamentoMunicipioId] <= @AV32TFDepartamentoMunicipioId_To)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! (0==AV33TFZonasID) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] >= @AV33TFZonasID)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! (0==AV34TFZonasID_To) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] <= @AV34TFZonasID_To)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSolicitudesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSolicitudesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesDireccion]) like UPPER(@lV35TFSolicitudesDireccion))");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSolicitudesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV36TFSolicitudesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDireccion] = @AV36TFSolicitudesDireccion_Sel)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV36TFSolicitudesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesDireccion] = ''))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSolicitudServicioSolCoti_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioSolCoti] = @AV39TFSolicitudServicioSolCoti_Sel)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[SolicitudesID]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[SolicitudesID] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[SolicitudesNombre]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[SolicitudesNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[SolicitudesTelefono]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[SolicitudesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[SolicitudesMail]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[SolicitudesMail] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[DepartamentoId]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[DepartamentoId] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[DepartamentoMunicipioId]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[DepartamentoMunicipioId] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[ZonasID]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[ZonasID] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[SolicitudesDireccion]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[SolicitudesDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[SolicitudServicioSolCoti]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[SolicitudServicioSolCoti] DESC";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H002F4( IGxContext context ,
                                             long AV21TFSolicitudesID ,
                                             long AV22TFSolicitudesID_To ,
                                             string AV24TFSolicitudesNombre_Sel ,
                                             string AV23TFSolicitudesNombre ,
                                             string AV26TFSolicitudesTelefono_Sel ,
                                             string AV25TFSolicitudesTelefono ,
                                             string AV28TFSolicitudesMail_Sel ,
                                             string AV27TFSolicitudesMail ,
                                             long AV29TFDepartamentoId ,
                                             long AV30TFDepartamentoId_To ,
                                             long AV31TFDepartamentoMunicipioId ,
                                             long AV32TFDepartamentoMunicipioId_To ,
                                             long AV33TFZonasID ,
                                             long AV34TFZonasID_To ,
                                             string AV36TFSolicitudesDireccion_Sel ,
                                             string AV35TFSolicitudesDireccion ,
                                             decimal AV37TFSolicitudesTotal ,
                                             decimal AV38TFSolicitudesTotal_To ,
                                             string AV39TFSolicitudServicioSolCoti_Sel ,
                                             long A127SolicitudesID ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A206SolicitudesMail ,
                                             long A112DepartamentoId ,
                                             long A114DepartamentoMunicipioId ,
                                             long A110ZonasID ,
                                             string A173SolicitudesDireccion ,
                                             decimal A174SolicitudesTotal ,
                                             string A210SolicitudServicioSolCoti ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string AV16FilterFullText ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV40TFSolicitudServicioPFinal ,
                                             decimal AV41TFSolicitudServicioPFinal_To ,
                                             long AV8MetodoPagosID ,
                                             long A128MetodoPagosID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[18];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.[MetodoPagosID], T1.[SolicitudServicioSolCoti], T1.[SolicitudesAutoEnumerar], T1.[SolicitudesDireccion], T1.[ZonasID], T1.[DepartamentoMunicipioId], T1.[DepartamentoId], T2.[PaisID], T1.[SolicitudesMail], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T1.[SolicitudesID], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM ([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId])";
         AddWhere(sWhereString, "(T1.[MetodoPagosID] = @AV8MetodoPagosID)");
         if ( ! (0==AV21TFSolicitudesID) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV21TFSolicitudesID)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! (0==AV22TFSolicitudesID_To) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV22TFSolicitudesID_To)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSolicitudesNombre_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSolicitudesNombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesNombre]) like UPPER(@lV23TFSolicitudesNombre))");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSolicitudesNombre_Sel)) && ! ( StringUtil.StrCmp(AV24TFSolicitudesNombre_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesNombre] = @AV24TFSolicitudesNombre_Sel)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFSolicitudesNombre_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesTelefono_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSolicitudesTelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesTelefono]) like UPPER(@lV25TFSolicitudesTelefono))");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSolicitudesTelefono_Sel)) && ! ( StringUtil.StrCmp(AV26TFSolicitudesTelefono_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesTelefono] = @AV26TFSolicitudesTelefono_Sel)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( StringUtil.StrCmp(AV26TFSolicitudesTelefono_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSolicitudesMail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSolicitudesMail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesMail]) like UPPER(@lV27TFSolicitudesMail))");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSolicitudesMail_Sel)) && ! ( StringUtil.StrCmp(AV28TFSolicitudesMail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesMail] = @AV28TFSolicitudesMail_Sel)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFSolicitudesMail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesMail] IS NULL or (T1.[SolicitudesMail] = ''))");
         }
         if ( ! (0==AV29TFDepartamentoId) )
         {
            AddWhere(sWhereString, "(T1.[DepartamentoId] >= @AV29TFDepartamentoId)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! (0==AV30TFDepartamentoId_To) )
         {
            AddWhere(sWhereString, "(T1.[DepartamentoId] <= @AV30TFDepartamentoId_To)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! (0==AV31TFDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "(T1.[DepartamentoMunicipioId] >= @AV31TFDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! (0==AV32TFDepartamentoMunicipioId_To) )
         {
            AddWhere(sWhereString, "(T1.[DepartamentoMunicipioId] <= @AV32TFDepartamentoMunicipioId_To)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! (0==AV33TFZonasID) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] >= @AV33TFZonasID)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! (0==AV34TFZonasID_To) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] <= @AV34TFZonasID_To)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSolicitudesDireccion_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSolicitudesDireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesDireccion]) like UPPER(@lV35TFSolicitudesDireccion))");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSolicitudesDireccion_Sel)) && ! ( StringUtil.StrCmp(AV36TFSolicitudesDireccion_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDireccion] = @AV36TFSolicitudesDireccion_Sel)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( StringUtil.StrCmp(AV36TFSolicitudesDireccion_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SolicitudesDireccion] = ''))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSolicitudServicioSolCoti_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudServicioSolCoti] = @AV39TFSolicitudServicioSolCoti_Sel)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[SolicitudesID]";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[SolicitudesID] DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[SolicitudesNombre]";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[SolicitudesNombre] DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[SolicitudesTelefono]";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[SolicitudesTelefono] DESC";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[SolicitudesMail]";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[SolicitudesMail] DESC";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[DepartamentoId]";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[DepartamentoId] DESC";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[DepartamentoMunicipioId]";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[DepartamentoMunicipioId] DESC";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[ZonasID]";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[ZonasID] DESC";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[SolicitudesDireccion]";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[SolicitudesDireccion] DESC";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID], T1.[SolicitudServicioSolCoti]";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[MetodoPagosID] DESC, T1.[SolicitudServicioSolCoti] DESC";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H002F3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (decimal)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] , (string)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (long)dynConstraints[35] , (long)dynConstraints[36] );
               case 2 :
                     return conditional_H002F4(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (long)dynConstraints[25] , (string)dynConstraints[26] , (decimal)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] , (string)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (decimal)dynConstraints[34] , (long)dynConstraints[35] , (long)dynConstraints[36] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002F2;
          prmH002F2 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH002F3;
          prmH002F3 = new Object[] {
          new ParDef("@AV8MetodoPagosID",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFSolicitudesID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV23TFSolicitudesNombre",GXType.Char,100,0) ,
          new ParDef("@AV24TFSolicitudesNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV25TFSolicitudesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV26TFSolicitudesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV27TFSolicitudesMail",GXType.VarChar,100,0) ,
          new ParDef("@AV28TFSolicitudesMail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV29TFDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV30TFDepartamentoId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV31TFDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFDepartamentoMunicipioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV33TFZonasID",GXType.Decimal,18,0) ,
          new ParDef("@AV34TFZonasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV35TFSolicitudesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV36TFSolicitudesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV39TFSolicitudServicioSolCoti_Sel",GXType.NChar,1,0)
          };
          Object[] prmH002F4;
          prmH002F4 = new Object[] {
          new ParDef("@AV8MetodoPagosID",GXType.Decimal,18,0) ,
          new ParDef("@AV21TFSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV22TFSolicitudesID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV23TFSolicitudesNombre",GXType.Char,100,0) ,
          new ParDef("@AV24TFSolicitudesNombre_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV25TFSolicitudesTelefono",GXType.Char,20,0) ,
          new ParDef("@AV26TFSolicitudesTelefono_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV27TFSolicitudesMail",GXType.VarChar,100,0) ,
          new ParDef("@AV28TFSolicitudesMail_Sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV29TFDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV30TFDepartamentoId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV31TFDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV32TFDepartamentoMunicipioId_To",GXType.Decimal,18,0) ,
          new ParDef("@AV33TFZonasID",GXType.Decimal,18,0) ,
          new ParDef("@AV34TFZonasID_To",GXType.Decimal,18,0) ,
          new ParDef("@lV35TFSolicitudesDireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV36TFSolicitudesDireccion_Sel",GXType.NVarChar,1024,0) ,
          new ParDef("@AV39TFSolicitudServicioSolCoti_Sel",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002F2", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002F2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002F3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002F4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002F4,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 2);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 20);
                ((string[]) buf[14])[0] = rslt.getString(11, 100);
                ((long[]) buf[15])[0] = rslt.getLong(12);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(16);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((long[]) buf[8])[0] = rslt.getLong(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 2);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 20);
                ((string[]) buf[14])[0] = rslt.getString(11, 100);
                ((long[]) buf[15])[0] = rslt.getLong(12);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(16);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
                return;
       }
    }

 }

}

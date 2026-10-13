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
   public class historicosolicitudesgeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public historicosolicitudesgeneral( )
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

      public historicosolicitudesgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_HistoricoSolicitudesID )
      {
         this.A153HistoricoSolicitudesID = aP0_HistoricoSolicitudesID;
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
         cmbHistoricoSolicitudesPagado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "HistoricoSolicitudesID");
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
                  A153HistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "HistoricoSolicitudesID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)A153HistoricoSolicitudesID});
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
                  gxfirstwebparm = GetFirstPar( "HistoricoSolicitudesID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "HistoricoSolicitudesID");
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
            PA2J2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "HistoricoSolicitudesGeneral";
               GetHistoricoSolicitudesTotal( A153HistoricoSolicitudesID) ;
               WS2J2( ) ;
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

      protected void GetHistoricoSolicitudesTotal( long A153HistoricoSolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A300HistoricoSolicitudesTotal = 0;
         /* Using cursor H002J2 */
         pr_default.execute(0, new Object[] {A153HistoricoSolicitudesID});
         while ( (pr_default.getStatus(0) != 101) && ( H002J2_A153HistoricoSolicitudesID[0] == A153HistoricoSolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( H002J2_A296HistoricoSolicitudesItemsSR[0])) || ( StringUtil.StrCmp(H002J2_A297HistoricoSolicitudesItemsCT[0], "N") == 0 ) )
            {
               A294HItemsSolicitudesItemsPrecioIn = (decimal)(H002J2_A295HItemsInventarioPrecioFinal[0]*H002J2_A293HItemsSolicitudesItemsCantidad[0]);
            }
            else
            {
               if ( ( StringUtil.StrCmp(H002J2_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(H002J2_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
               {
                  A294HItemsSolicitudesItemsPrecioIn = (decimal)((H002J2_A295HItemsInventarioPrecioFinal[0]*H002J2_A293HItemsSolicitudesItemsCantidad[0])-(H002J2_A298HistoricoSolicitudesItemsComis[0]*H002J2_A293HItemsSolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(H002J2_A297HistoricoSolicitudesItemsCT[0], "F") == 0 ) && ( StringUtil.StrCmp(H002J2_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                  {
                     A294HItemsSolicitudesItemsPrecioIn = (decimal)((H002J2_A295HItemsInventarioPrecioFinal[0]*H002J2_A293HItemsSolicitudesItemsCantidad[0])+(H002J2_A298HistoricoSolicitudesItemsComis[0]*H002J2_A293HItemsSolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(H002J2_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(H002J2_A296HistoricoSolicitudesItemsSR[0], "R") == 0 ) )
                     {
                        A294HItemsSolicitudesItemsPrecioIn = (decimal)((H002J2_A295HItemsInventarioPrecioFinal[0]*H002J2_A293HItemsSolicitudesItemsCantidad[0])-((H002J2_A295HItemsInventarioPrecioFinal[0]*H002J2_A293HItemsSolicitudesItemsCantidad[0])*(H002J2_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(H002J2_A297HistoricoSolicitudesItemsCT[0], "P") == 0 ) && ( StringUtil.StrCmp(H002J2_A296HistoricoSolicitudesItemsSR[0], "S") == 0 ) )
                        {
                           A294HItemsSolicitudesItemsPrecioIn = (decimal)((H002J2_A295HItemsInventarioPrecioFinal[0]*H002J2_A293HItemsSolicitudesItemsCantidad[0])+((H002J2_A295HItemsInventarioPrecioFinal[0]*H002J2_A293HItemsSolicitudesItemsCantidad[0])*(H002J2_A298HistoricoSolicitudesItemsComis[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A294HItemsSolicitudesItemsPrecioIn = 0;
                        }
                     }
                  }
               }
            }
            A300HistoricoSolicitudesTotal = (decimal)(A300HistoricoSolicitudesTotal+A294HItemsSolicitudesItemsPrecioIn);
            AssignAttri(sPrefix, false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
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
            context.SendWebValue( context.GetMessage( "Historico Solicitudes General", "")) ;
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
            GXEncryptionTmp = "historicosolicitudesgeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A153HistoricoSolicitudesID,18,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("historicosolicitudesgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA153HistoricoSolicitudesID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
      }

      protected void RenderHtmlCloseForm2J2( )
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
         return "HistoricoSolicitudesGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Historico Solicitudes General", "") ;
      }

      protected void WB2J0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "historicosolicitudesgeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesID_Internalname, context.GetMessage( "Solicitudes ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoSolicitudesID_Enabled!=0) ? context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,14);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesNombre_Internalname, context.GetMessage( "Solicitudes Nombre", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesNombre_Internalname, StringUtil.RTrim( A288HistoricoSolicitudesNombre), StringUtil.RTrim( context.localUtil.Format( A288HistoricoSolicitudesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtHistoricoSolicitudesNombre_Link, "", "", "", edtHistoricoSolicitudesNombre_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesTelefono_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesTelefono_Internalname, context.GetMessage( "Solicitudes Telefono", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            gxphoneLink = "tel:" + StringUtil.RTrim( A289HistoricoSolicitudesTelefono);
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesTelefono_Internalname, StringUtil.RTrim( A289HistoricoSolicitudesTelefono), StringUtil.RTrim( context.localUtil.Format( A289HistoricoSolicitudesTelefono, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtHistoricoSolicitudesTelefono_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesTelefono_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesMail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesMail_Internalname, context.GetMessage( "Solicitudes Mail", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesMail_Internalname, A290HistoricoSolicitudesMail, StringUtil.RTrim( context.localUtil.Format( A290HistoricoSolicitudesMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A290HistoricoSolicitudesMail, "", "", "", edtHistoricoSolicitudesMail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesMail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoPaisID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoPaisID_Internalname, context.GetMessage( "Pais ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoPaisID_Internalname, StringUtil.RTrim( A315HistoricoPaisID), StringUtil.RTrim( context.localUtil.Format( A315HistoricoPaisID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoPaisID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoPaisID_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoDepartamentoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoDepartamentoId_Internalname, context.GetMessage( "Departamento Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A316HistoricoDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoDepartamentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A316HistoricoDepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A316HistoricoDepartamentoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoDepartamentoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoDepartamentoId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoDepartamentoMunicipio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoDepartamentoMunicipio_Internalname, context.GetMessage( "Municipio Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoDepartamentoMunicipio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoDepartamentoMunicipio_Enabled!=0) ? context.localUtil.Format( (decimal)(A317HistoricoDepartamentoMunicipio), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A317HistoricoDepartamentoMunicipio), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoDepartamentoMunicipio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoDepartamentoMunicipio_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoZonasID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoZonasID_Internalname, context.GetMessage( "Zonas ID", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoZonasID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A318HistoricoZonasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoZonasID_Enabled!=0) ? context.localUtil.Format( (decimal)(A318HistoricoZonasID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A318HistoricoZonasID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,49);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoZonasID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoZonasID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesDireccion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesDireccion_Internalname, context.GetMessage( "Solicitudes Direccion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtHistoricoSolicitudesDireccion_Internalname, A291HistoricoSolicitudesDireccion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtHistoricoSolicitudesDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesAutoEnumer_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesAutoEnumer_Internalname, context.GetMessage( "Auto Enumerar", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesAutoEnumer_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoSolicitudesAutoEnumer_Enabled!=0) ? context.localUtil.Format( (decimal)(A292HistoricoSolicitudesAutoEnumer), "ZZZ9") : context.localUtil.Format( (decimal)(A292HistoricoSolicitudesAutoEnumer), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,59);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesAutoEnumer_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesAutoEnumer_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesCotizacion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesCotizacion_Internalname, context.GetMessage( "Solicitudes Cotizacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesCotizacion_Internalname, StringUtil.LTrim( StringUtil.NToC( A299HistoricoSolicitudesCotizacion, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoSolicitudesCotizacion_Enabled!=0) ? context.localUtil.Format( A299HistoricoSolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A299HistoricoSolicitudesCotizacion, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesCotizacion_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesCotizacion_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesTotal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesTotal_Internalname, context.GetMessage( "Solicitudes Total", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A300HistoricoSolicitudesTotal, 21, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoSolicitudesTotal_Enabled!=0) ? context.localUtil.Format( A300HistoricoSolicitudesTotal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A300HistoricoSolicitudesTotal, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,69);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesTotal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesTotal_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Precio", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudServicioSolC_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudServicioSolC_Internalname, context.GetMessage( "Sol Coti", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudServicioSolC_Internalname, StringUtil.RTrim( A301HistoricoSolicitudServicioSolC), StringUtil.RTrim( context.localUtil.Format( A301HistoricoSolicitudServicioSolC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudServicioSolC_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudServicioSolC_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudServicioPFin_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudServicioPFin_Internalname, context.GetMessage( "Servicio PFinal", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudServicioPFin_Internalname, StringUtil.LTrim( StringUtil.NToC( A302HistoricoSolicitudServicioPFin, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtHistoricoSolicitudServicioPFin_Enabled!=0) ? context.localUtil.Format( A302HistoricoSolicitudServicioPFin, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A302HistoricoSolicitudServicioPFin, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,79);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudServicioPFin_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudServicioPFin_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosSolTipo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEstadosSolTipo_Internalname, context.GetMessage( "Sol Tipo", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEstadosSolTipo_Internalname, StringUtil.RTrim( A130EstadosSolTipo), StringUtil.RTrim( context.localUtil.Format( A130EstadosSolTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosSolTipo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosSolTipo_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadosSolId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEstadosSolId_Internalname, context.GetMessage( "Sol Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtEstadosSolId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A131EstadosSolId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtEstadosSolId_Enabled!=0) ? context.localUtil.Format( (decimal)(A131EstadosSolId), "ZZZZ9") : context.localUtil.Format( (decimal)(A131EstadosSolId), "ZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,89);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadosSolId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEstadosSolId_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesOtros1_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesOtros1_Internalname, context.GetMessage( "Solicitudes Otros1", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesOtros1_Internalname, StringUtil.RTrim( A303HistoricoSolicitudesOtros1), StringUtil.RTrim( context.localUtil.Format( A303HistoricoSolicitudesOtros1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesOtros1_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesOtros1_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesOtros2_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesOtros2_Internalname, context.GetMessage( "Solicitudes Otros2", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtHistoricoSolicitudesOtros2_Internalname, StringUtil.RTrim( A304HistoricoSolicitudesOtros2), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", 0, 1, edtHistoricoSolicitudesOtros2_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesOtros3_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesOtros3_Internalname, context.GetMessage( "Solicitudes Otros3", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtHistoricoSolicitudesOtros3_Internalname, StringUtil.RTrim( A305HistoricoSolicitudesOtros3), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", 0, 1, edtHistoricoSolicitudesOtros3_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesFechaAlta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesFechaAlta_Internalname, context.GetMessage( "Fecha Alta", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtHistoricoSolicitudesFechaAlta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesFechaAlta_Internalname, context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99"), context.localUtil.Format( A306HistoricoSolicitudesFechaAlta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,109);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesFechaAlta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesFechaAlta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtHistoricoSolicitudesFechaAlta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHistoricoSolicitudesFechaAlta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_HistoricoSolicitudesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesFechaActua_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesFechaActua_Internalname, context.GetMessage( "Fecha Actualizacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtHistoricoSolicitudesFechaActua_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesFechaActua_Internalname, context.localUtil.TToC( A307HistoricoSolicitudesFechaActua, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A307HistoricoSolicitudesFechaActua, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,114);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesFechaActua_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesFechaActua_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtHistoricoSolicitudesFechaActua_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHistoricoSolicitudesFechaActua_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_HistoricoSolicitudesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesFechaInsta_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesFechaInsta_Internalname, context.GetMessage( "Fecha Instalacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtHistoricoSolicitudesFechaInsta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesFechaInsta_Internalname, context.localUtil.Format(A308HistoricoSolicitudesFechaInsta, "99/99/99"), context.localUtil.Format( A308HistoricoSolicitudesFechaInsta, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,119);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesFechaInsta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesFechaInsta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtHistoricoSolicitudesFechaInsta_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHistoricoSolicitudesFechaInsta_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "none", "HLP_HistoricoSolicitudesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesHoraInstal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesHoraInstal_Internalname, context.GetMessage( "Hora Instalacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesHoraInstal_Internalname, StringUtil.RTrim( A309HistoricoSolicitudesHoraInstal), StringUtil.RTrim( context.localUtil.Format( A309HistoricoSolicitudesHoraInstal, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,124);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesHoraInstal_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesHoraInstal_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesComentario_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesComentario_Internalname, context.GetMessage( "Solicitudes Comentario", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtHistoricoSolicitudesComentario_Internalname, A310HistoricoSolicitudesComentario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", 0, 1, edtHistoricoSolicitudesComentario_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMetodoPagosID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMetodoPagosID_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtMetodoPagosID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128MetodoPagosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtMetodoPagosID_Enabled!=0) ? context.localUtil.Format( (decimal)(A128MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A128MetodoPagosID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,134);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMetodoPagosID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMetodoPagosID_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesNota_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesNota_Internalname, context.GetMessage( "Solicitudes Nota", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtHistoricoSolicitudesNota_Internalname, StringUtil.RTrim( A311HistoricoSolicitudesNota), "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", 0, 1, edtHistoricoSolicitudesNota_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesNotificaci_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesNotificaci_Internalname, context.GetMessage( "Solicitudes Notificacion", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesNotificaci_Internalname, StringUtil.RTrim( A312HistoricoSolicitudesNotificaci), StringUtil.RTrim( context.localUtil.Format( A312HistoricoSolicitudesNotificaci, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesNotificaci_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesNotificaci_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHistoricoSolicitudesOrigenPago_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHistoricoSolicitudesOrigenPago_Internalname, context.GetMessage( "Origen Pago", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtHistoricoSolicitudesOrigenPago_Internalname, StringUtil.RTrim( A439HistoricoSolicitudesOrigenPago), StringUtil.RTrim( context.localUtil.Format( A439HistoricoSolicitudesOrigenPago, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,149);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoricoSolicitudesOrigenPago_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtHistoricoSolicitudesOrigenPago_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbHistoricoSolicitudesPagado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbHistoricoSolicitudesPagado_Internalname, context.GetMessage( "Solicitudes Pagado", ""), "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbHistoricoSolicitudesPagado, cmbHistoricoSolicitudesPagado_Internalname, StringUtil.RTrim( A442HistoricoSolicitudesPagado), 1, cmbHistoricoSolicitudesPagado_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbHistoricoSolicitudesPagado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", "", true, 0, "HLP_HistoricoSolicitudesGeneral.htm");
            cmbHistoricoSolicitudesPagado.CurrentValue = StringUtil.RTrim( A442HistoricoSolicitudesPagado);
            AssignProp(sPrefix, false, cmbHistoricoSolicitudesPagado_Internalname, "Values", (string)(cmbHistoricoSolicitudesPagado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", context.GetMessage( "GXM_update", ""), bttBtnupdate_Jsonclick, 5, context.GetMessage( "GXM_update", ""), "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoricoSolicitudesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtndelete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoricoSolicitudesGeneral.htm");
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
         wbLoad = true;
      }

      protected void START2J2( )
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
            Form.Meta.addItem("description", context.GetMessage( "Historico Solicitudes General", ""), 0) ;
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
               STRUP2J0( ) ;
            }
         }
      }

      protected void WS2J2( )
      {
         START2J2( ) ;
         EVT2J2( ) ;
      }

      protected void EVT2J2( )
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
                                 STRUP2J0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2J0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E112J2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2J0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E122J2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2J0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E132J2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2J0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E142J2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2J0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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
                                 STRUP2J0( ) ;
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2J2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2J2( ) ;
            }
         }
      }

      protected void PA2J2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "historicosolicitudesgeneral.aspx")), "historicosolicitudesgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "historicosolicitudesgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "HistoricoSolicitudesID");
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

      protected void send_integrity_hashes( )
      {
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
         if ( cmbHistoricoSolicitudesPagado.ItemCount > 0 )
         {
            A442HistoricoSolicitudesPagado = cmbHistoricoSolicitudesPagado.getValidValue(A442HistoricoSolicitudesPagado);
            AssignAttri(sPrefix, false, "A442HistoricoSolicitudesPagado", A442HistoricoSolicitudesPagado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbHistoricoSolicitudesPagado.CurrentValue = StringUtil.RTrim( A442HistoricoSolicitudesPagado);
            AssignProp(sPrefix, false, cmbHistoricoSolicitudesPagado_Internalname, "Values", cmbHistoricoSolicitudesPagado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "HistoricoSolicitudesGeneral";
      }

      protected void RF2J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H002J3 */
            pr_default.execute(1, new Object[] {A153HistoricoSolicitudesID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A442HistoricoSolicitudesPagado = H002J3_A442HistoricoSolicitudesPagado[0];
               AssignAttri(sPrefix, false, "A442HistoricoSolicitudesPagado", A442HistoricoSolicitudesPagado);
               A439HistoricoSolicitudesOrigenPago = H002J3_A439HistoricoSolicitudesOrigenPago[0];
               AssignAttri(sPrefix, false, "A439HistoricoSolicitudesOrigenPago", A439HistoricoSolicitudesOrigenPago);
               A312HistoricoSolicitudesNotificaci = H002J3_A312HistoricoSolicitudesNotificaci[0];
               AssignAttri(sPrefix, false, "A312HistoricoSolicitudesNotificaci", A312HistoricoSolicitudesNotificaci);
               A311HistoricoSolicitudesNota = H002J3_A311HistoricoSolicitudesNota[0];
               AssignAttri(sPrefix, false, "A311HistoricoSolicitudesNota", A311HistoricoSolicitudesNota);
               A128MetodoPagosID = H002J3_A128MetodoPagosID[0];
               AssignAttri(sPrefix, false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
               A310HistoricoSolicitudesComentario = H002J3_A310HistoricoSolicitudesComentario[0];
               AssignAttri(sPrefix, false, "A310HistoricoSolicitudesComentario", A310HistoricoSolicitudesComentario);
               A309HistoricoSolicitudesHoraInstal = H002J3_A309HistoricoSolicitudesHoraInstal[0];
               AssignAttri(sPrefix, false, "A309HistoricoSolicitudesHoraInstal", A309HistoricoSolicitudesHoraInstal);
               A308HistoricoSolicitudesFechaInsta = H002J3_A308HistoricoSolicitudesFechaInsta[0];
               AssignAttri(sPrefix, false, "A308HistoricoSolicitudesFechaInsta", context.localUtil.Format(A308HistoricoSolicitudesFechaInsta, "99/99/99"));
               A307HistoricoSolicitudesFechaActua = H002J3_A307HistoricoSolicitudesFechaActua[0];
               AssignAttri(sPrefix, false, "A307HistoricoSolicitudesFechaActua", context.localUtil.TToC( A307HistoricoSolicitudesFechaActua, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
               A306HistoricoSolicitudesFechaAlta = H002J3_A306HistoricoSolicitudesFechaAlta[0];
               AssignAttri(sPrefix, false, "A306HistoricoSolicitudesFechaAlta", context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99"));
               A305HistoricoSolicitudesOtros3 = H002J3_A305HistoricoSolicitudesOtros3[0];
               AssignAttri(sPrefix, false, "A305HistoricoSolicitudesOtros3", A305HistoricoSolicitudesOtros3);
               A304HistoricoSolicitudesOtros2 = H002J3_A304HistoricoSolicitudesOtros2[0];
               AssignAttri(sPrefix, false, "A304HistoricoSolicitudesOtros2", A304HistoricoSolicitudesOtros2);
               A303HistoricoSolicitudesOtros1 = H002J3_A303HistoricoSolicitudesOtros1[0];
               AssignAttri(sPrefix, false, "A303HistoricoSolicitudesOtros1", A303HistoricoSolicitudesOtros1);
               A131EstadosSolId = H002J3_A131EstadosSolId[0];
               AssignAttri(sPrefix, false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
               A130EstadosSolTipo = H002J3_A130EstadosSolTipo[0];
               AssignAttri(sPrefix, false, "A130EstadosSolTipo", A130EstadosSolTipo);
               A301HistoricoSolicitudServicioSolC = H002J3_A301HistoricoSolicitudServicioSolC[0];
               AssignAttri(sPrefix, false, "A301HistoricoSolicitudServicioSolC", A301HistoricoSolicitudServicioSolC);
               A292HistoricoSolicitudesAutoEnumer = H002J3_A292HistoricoSolicitudesAutoEnumer[0];
               AssignAttri(sPrefix, false, "A292HistoricoSolicitudesAutoEnumer", StringUtil.LTrimStr( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0));
               A291HistoricoSolicitudesDireccion = H002J3_A291HistoricoSolicitudesDireccion[0];
               AssignAttri(sPrefix, false, "A291HistoricoSolicitudesDireccion", A291HistoricoSolicitudesDireccion);
               A318HistoricoZonasID = H002J3_A318HistoricoZonasID[0];
               n318HistoricoZonasID = H002J3_n318HistoricoZonasID[0];
               AssignAttri(sPrefix, false, "A318HistoricoZonasID", StringUtil.LTrimStr( (decimal)(A318HistoricoZonasID), 18, 0));
               A317HistoricoDepartamentoMunicipio = H002J3_A317HistoricoDepartamentoMunicipio[0];
               AssignAttri(sPrefix, false, "A317HistoricoDepartamentoMunicipio", StringUtil.LTrimStr( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0));
               A316HistoricoDepartamentoId = H002J3_A316HistoricoDepartamentoId[0];
               AssignAttri(sPrefix, false, "A316HistoricoDepartamentoId", StringUtil.LTrimStr( (decimal)(A316HistoricoDepartamentoId), 18, 0));
               A315HistoricoPaisID = H002J3_A315HistoricoPaisID[0];
               AssignAttri(sPrefix, false, "A315HistoricoPaisID", A315HistoricoPaisID);
               A290HistoricoSolicitudesMail = H002J3_A290HistoricoSolicitudesMail[0];
               n290HistoricoSolicitudesMail = H002J3_n290HistoricoSolicitudesMail[0];
               AssignAttri(sPrefix, false, "A290HistoricoSolicitudesMail", A290HistoricoSolicitudesMail);
               A289HistoricoSolicitudesTelefono = H002J3_A289HistoricoSolicitudesTelefono[0];
               AssignAttri(sPrefix, false, "A289HistoricoSolicitudesTelefono", A289HistoricoSolicitudesTelefono);
               A288HistoricoSolicitudesNombre = H002J3_A288HistoricoSolicitudesNombre[0];
               AssignAttri(sPrefix, false, "A288HistoricoSolicitudesNombre", A288HistoricoSolicitudesNombre);
               A299HistoricoSolicitudesCotizacion = H002J3_A299HistoricoSolicitudesCotizacion[0];
               AssignAttri(sPrefix, false, "A299HistoricoSolicitudesCotizacion", StringUtil.LTrimStr( A299HistoricoSolicitudesCotizacion, 18, 2));
               if ( ( A299HistoricoSolicitudesCotizacion == Convert.ToDecimal( 0 )) )
               {
                  A302HistoricoSolicitudServicioPFin = A300HistoricoSolicitudesTotal;
                  AssignAttri(sPrefix, false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
               }
               else
               {
                  if ( ( A299HistoricoSolicitudesCotizacion > Convert.ToDecimal( 0 )) )
                  {
                     A302HistoricoSolicitudServicioPFin = A299HistoricoSolicitudesCotizacion;
                     AssignAttri(sPrefix, false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
                  }
                  else
                  {
                     A302HistoricoSolicitudServicioPFin = 0;
                     AssignAttri(sPrefix, false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
                  }
               }
               /* Execute user event: Load */
               E122J2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB2J0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2J2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "HistoricoSolicitudesGeneral";
         GetHistoricoSolicitudesTotal( A153HistoricoSolicitudesID) ;
         edtHistoricoSolicitudesID_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesID_Enabled), 5, 0), true);
         edtHistoricoSolicitudesNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesNombre_Enabled), 5, 0), true);
         edtHistoricoSolicitudesTelefono_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesTelefono_Enabled), 5, 0), true);
         edtHistoricoSolicitudesMail_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesMail_Enabled), 5, 0), true);
         edtHistoricoPaisID_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoPaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoPaisID_Enabled), 5, 0), true);
         edtHistoricoDepartamentoId_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoDepartamentoId_Enabled), 5, 0), true);
         edtHistoricoDepartamentoMunicipio_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoDepartamentoMunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoDepartamentoMunicipio_Enabled), 5, 0), true);
         edtHistoricoZonasID_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoZonasID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoZonasID_Enabled), 5, 0), true);
         edtHistoricoSolicitudesDireccion_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesDireccion_Enabled), 5, 0), true);
         edtHistoricoSolicitudesAutoEnumer_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesAutoEnumer_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesAutoEnumer_Enabled), 5, 0), true);
         edtHistoricoSolicitudesCotizacion_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesCotizacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesCotizacion_Enabled), 5, 0), true);
         edtHistoricoSolicitudesTotal_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesTotal_Enabled), 5, 0), true);
         edtHistoricoSolicitudServicioSolC_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudServicioSolC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudServicioSolC_Enabled), 5, 0), true);
         edtHistoricoSolicitudServicioPFin_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudServicioPFin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudServicioPFin_Enabled), 5, 0), true);
         edtEstadosSolTipo_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadosSolTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolTipo_Enabled), 5, 0), true);
         edtEstadosSolId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadosSolId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadosSolId_Enabled), 5, 0), true);
         edtHistoricoSolicitudesOtros1_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesOtros1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesOtros1_Enabled), 5, 0), true);
         edtHistoricoSolicitudesOtros2_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesOtros2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesOtros2_Enabled), 5, 0), true);
         edtHistoricoSolicitudesOtros3_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesOtros3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesOtros3_Enabled), 5, 0), true);
         edtHistoricoSolicitudesFechaAlta_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesFechaAlta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesFechaAlta_Enabled), 5, 0), true);
         edtHistoricoSolicitudesFechaActua_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesFechaActua_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesFechaActua_Enabled), 5, 0), true);
         edtHistoricoSolicitudesFechaInsta_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesFechaInsta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesFechaInsta_Enabled), 5, 0), true);
         edtHistoricoSolicitudesHoraInstal_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesHoraInstal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesHoraInstal_Enabled), 5, 0), true);
         edtHistoricoSolicitudesComentario_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesComentario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesComentario_Enabled), 5, 0), true);
         edtMetodoPagosID_Enabled = 0;
         AssignProp(sPrefix, false, edtMetodoPagosID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMetodoPagosID_Enabled), 5, 0), true);
         edtHistoricoSolicitudesNota_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesNota_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesNota_Enabled), 5, 0), true);
         edtHistoricoSolicitudesNotificaci_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesNotificaci_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesNotificaci_Enabled), 5, 0), true);
         edtHistoricoSolicitudesOrigenPago_Enabled = 0;
         AssignProp(sPrefix, false, edtHistoricoSolicitudesOrigenPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoricoSolicitudesOrigenPago_Enabled), 5, 0), true);
         cmbHistoricoSolicitudesPagado.Enabled = 0;
         AssignProp(sPrefix, false, cmbHistoricoSolicitudesPagado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbHistoricoSolicitudesPagado.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112J2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA153HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA153HistoricoSolicitudesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A288HistoricoSolicitudesNombre = cgiGet( edtHistoricoSolicitudesNombre_Internalname);
            AssignAttri(sPrefix, false, "A288HistoricoSolicitudesNombre", A288HistoricoSolicitudesNombre);
            A289HistoricoSolicitudesTelefono = cgiGet( edtHistoricoSolicitudesTelefono_Internalname);
            AssignAttri(sPrefix, false, "A289HistoricoSolicitudesTelefono", A289HistoricoSolicitudesTelefono);
            A290HistoricoSolicitudesMail = cgiGet( edtHistoricoSolicitudesMail_Internalname);
            n290HistoricoSolicitudesMail = false;
            AssignAttri(sPrefix, false, "A290HistoricoSolicitudesMail", A290HistoricoSolicitudesMail);
            A315HistoricoPaisID = cgiGet( edtHistoricoPaisID_Internalname);
            AssignAttri(sPrefix, false, "A315HistoricoPaisID", A315HistoricoPaisID);
            A316HistoricoDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A316HistoricoDepartamentoId", StringUtil.LTrimStr( (decimal)(A316HistoricoDepartamentoId), 18, 0));
            A317HistoricoDepartamentoMunicipio = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoDepartamentoMunicipio_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A317HistoricoDepartamentoMunicipio", StringUtil.LTrimStr( (decimal)(A317HistoricoDepartamentoMunicipio), 18, 0));
            A318HistoricoZonasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoZonasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n318HistoricoZonasID = false;
            AssignAttri(sPrefix, false, "A318HistoricoZonasID", StringUtil.LTrimStr( (decimal)(A318HistoricoZonasID), 18, 0));
            A291HistoricoSolicitudesDireccion = cgiGet( edtHistoricoSolicitudesDireccion_Internalname);
            AssignAttri(sPrefix, false, "A291HistoricoSolicitudesDireccion", A291HistoricoSolicitudesDireccion);
            A292HistoricoSolicitudesAutoEnumer = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesAutoEnumer_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A292HistoricoSolicitudesAutoEnumer", StringUtil.LTrimStr( (decimal)(A292HistoricoSolicitudesAutoEnumer), 4, 0));
            A299HistoricoSolicitudesCotizacion = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesCotizacion_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A299HistoricoSolicitudesCotizacion", StringUtil.LTrimStr( A299HistoricoSolicitudesCotizacion, 18, 2));
            A300HistoricoSolicitudesTotal = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesTotal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A300HistoricoSolicitudesTotal", StringUtil.LTrimStr( A300HistoricoSolicitudesTotal, 18, 2));
            A301HistoricoSolicitudServicioSolC = cgiGet( edtHistoricoSolicitudServicioSolC_Internalname);
            AssignAttri(sPrefix, false, "A301HistoricoSolicitudServicioSolC", A301HistoricoSolicitudServicioSolC);
            A302HistoricoSolicitudServicioPFin = context.localUtil.CToN( cgiGet( edtHistoricoSolicitudServicioPFin_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
            AssignAttri(sPrefix, false, "A302HistoricoSolicitudServicioPFin", StringUtil.LTrimStr( A302HistoricoSolicitudServicioPFin, 18, 2));
            A130EstadosSolTipo = cgiGet( edtEstadosSolTipo_Internalname);
            AssignAttri(sPrefix, false, "A130EstadosSolTipo", A130EstadosSolTipo);
            A131EstadosSolId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadosSolId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A131EstadosSolId", StringUtil.LTrimStr( (decimal)(A131EstadosSolId), 5, 0));
            A303HistoricoSolicitudesOtros1 = cgiGet( edtHistoricoSolicitudesOtros1_Internalname);
            AssignAttri(sPrefix, false, "A303HistoricoSolicitudesOtros1", A303HistoricoSolicitudesOtros1);
            A304HistoricoSolicitudesOtros2 = cgiGet( edtHistoricoSolicitudesOtros2_Internalname);
            AssignAttri(sPrefix, false, "A304HistoricoSolicitudesOtros2", A304HistoricoSolicitudesOtros2);
            A305HistoricoSolicitudesOtros3 = cgiGet( edtHistoricoSolicitudesOtros3_Internalname);
            AssignAttri(sPrefix, false, "A305HistoricoSolicitudesOtros3", A305HistoricoSolicitudesOtros3);
            A306HistoricoSolicitudesFechaAlta = context.localUtil.CToD( cgiGet( edtHistoricoSolicitudesFechaAlta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri(sPrefix, false, "A306HistoricoSolicitudesFechaAlta", context.localUtil.Format(A306HistoricoSolicitudesFechaAlta, "99/99/99"));
            A307HistoricoSolicitudesFechaActua = context.localUtil.CToT( cgiGet( edtHistoricoSolicitudesFechaActua_Internalname));
            AssignAttri(sPrefix, false, "A307HistoricoSolicitudesFechaActua", context.localUtil.TToC( A307HistoricoSolicitudesFechaActua, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            A308HistoricoSolicitudesFechaInsta = context.localUtil.CToD( cgiGet( edtHistoricoSolicitudesFechaInsta_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            AssignAttri(sPrefix, false, "A308HistoricoSolicitudesFechaInsta", context.localUtil.Format(A308HistoricoSolicitudesFechaInsta, "99/99/99"));
            A309HistoricoSolicitudesHoraInstal = cgiGet( edtHistoricoSolicitudesHoraInstal_Internalname);
            AssignAttri(sPrefix, false, "A309HistoricoSolicitudesHoraInstal", A309HistoricoSolicitudesHoraInstal);
            A310HistoricoSolicitudesComentario = cgiGet( edtHistoricoSolicitudesComentario_Internalname);
            AssignAttri(sPrefix, false, "A310HistoricoSolicitudesComentario", A310HistoricoSolicitudesComentario);
            A128MetodoPagosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMetodoPagosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A128MetodoPagosID", StringUtil.LTrimStr( (decimal)(A128MetodoPagosID), 18, 0));
            A311HistoricoSolicitudesNota = cgiGet( edtHistoricoSolicitudesNota_Internalname);
            AssignAttri(sPrefix, false, "A311HistoricoSolicitudesNota", A311HistoricoSolicitudesNota);
            A312HistoricoSolicitudesNotificaci = cgiGet( edtHistoricoSolicitudesNotificaci_Internalname);
            AssignAttri(sPrefix, false, "A312HistoricoSolicitudesNotificaci", A312HistoricoSolicitudesNotificaci);
            A439HistoricoSolicitudesOrigenPago = cgiGet( edtHistoricoSolicitudesOrigenPago_Internalname);
            AssignAttri(sPrefix, false, "A439HistoricoSolicitudesOrigenPago", A439HistoricoSolicitudesOrigenPago);
            cmbHistoricoSolicitudesPagado.CurrentValue = cgiGet( cmbHistoricoSolicitudesPagado_Internalname);
            A442HistoricoSolicitudesPagado = cgiGet( cmbHistoricoSolicitudesPagado_Internalname);
            AssignAttri(sPrefix, false, "A442HistoricoSolicitudesPagado", A442HistoricoSolicitudesPagado);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E112J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E112J2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E122J2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoRelaciones", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( AV12TempBoolean )
         {
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "historicorelacionesview.aspx"+UrlEncode(StringUtil.LTrimStr(A153HistoricoSolicitudesID,18,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtHistoricoSolicitudesNombre_Link = formatLink("historicorelacionesview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtHistoricoSolicitudesNombre_Internalname, "Link", edtHistoricoSolicitudesNombre_Link, true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoSolicitudes_Update", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWHistoricoSolicitudes_Delete", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( ! ( AV12TempBoolean ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E132J2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "historicosolicitudes.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.LTrimStr(A153HistoricoSolicitudesID,18,0));
         CallWebObject(formatLink("historicosolicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E142J2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "historicosolicitudes.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.LTrimStr(A153HistoricoSolicitudesID,18,0));
         CallWebObject(formatLink("historicosolicitudes.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "HistoricoSolicitudes";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A153HistoricoSolicitudesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
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
         PA2J2( ) ;
         WS2J2( ) ;
         WE2J2( ) ;
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
         sCtrlA153HistoricoSolicitudesID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2J2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "historicosolicitudesgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2J2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A153HistoricoSolicitudesID = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
         }
         wcpOA153HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA153HistoricoSolicitudesID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A153HistoricoSolicitudesID != wcpOA153HistoricoSolicitudesID ) ) )
         {
            setjustcreated();
         }
         wcpOA153HistoricoSolicitudesID = A153HistoricoSolicitudesID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA153HistoricoSolicitudesID = cgiGet( sPrefix+"A153HistoricoSolicitudesID_CTRL");
         if ( StringUtil.Len( sCtrlA153HistoricoSolicitudesID) > 0 )
         {
            A153HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA153HistoricoSolicitudesID), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A153HistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(A153HistoricoSolicitudesID), 18, 0));
         }
         else
         {
            A153HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A153HistoricoSolicitudesID_PARM"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
         PA2J2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2J2( ) ;
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
         WS2J2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A153HistoricoSolicitudesID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA153HistoricoSolicitudesID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A153HistoricoSolicitudesID_CTRL", StringUtil.RTrim( sCtrlA153HistoricoSolicitudesID));
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
         WE2J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302111472", true, true, false);
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
         context.AddJavascriptSource("historicosolicitudesgeneral.js", "?20267302111472", false, true, false);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbHistoricoSolicitudesPagado.Name = "HISTORICOSOLICITUDESPAGADO";
         cmbHistoricoSolicitudesPagado.WebTags = "";
         cmbHistoricoSolicitudesPagado.addItem("S", context.GetMessage( "Pagado", ""), 0);
         cmbHistoricoSolicitudesPagado.addItem("N", context.GetMessage( "Pendiente de Pago", ""), 0);
         if ( cmbHistoricoSolicitudesPagado.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtHistoricoSolicitudesID_Internalname = sPrefix+"HISTORICOSOLICITUDESID";
         edtHistoricoSolicitudesNombre_Internalname = sPrefix+"HISTORICOSOLICITUDESNOMBRE";
         edtHistoricoSolicitudesTelefono_Internalname = sPrefix+"HISTORICOSOLICITUDESTELEFONO";
         edtHistoricoSolicitudesMail_Internalname = sPrefix+"HISTORICOSOLICITUDESMAIL";
         edtHistoricoPaisID_Internalname = sPrefix+"HISTORICOPAISID";
         edtHistoricoDepartamentoId_Internalname = sPrefix+"HISTORICODEPARTAMENTOID";
         edtHistoricoDepartamentoMunicipio_Internalname = sPrefix+"HISTORICODEPARTAMENTOMUNICIPIO";
         edtHistoricoZonasID_Internalname = sPrefix+"HISTORICOZONASID";
         edtHistoricoSolicitudesDireccion_Internalname = sPrefix+"HISTORICOSOLICITUDESDIRECCION";
         edtHistoricoSolicitudesAutoEnumer_Internalname = sPrefix+"HISTORICOSOLICITUDESAUTOENUMER";
         edtHistoricoSolicitudesCotizacion_Internalname = sPrefix+"HISTORICOSOLICITUDESCOTIZACION";
         edtHistoricoSolicitudesTotal_Internalname = sPrefix+"HISTORICOSOLICITUDESTOTAL";
         edtHistoricoSolicitudServicioSolC_Internalname = sPrefix+"HISTORICOSOLICITUDSERVICIOSOLC";
         edtHistoricoSolicitudServicioPFin_Internalname = sPrefix+"HISTORICOSOLICITUDSERVICIOPFIN";
         edtEstadosSolTipo_Internalname = sPrefix+"ESTADOSSOLTIPO";
         edtEstadosSolId_Internalname = sPrefix+"ESTADOSSOLID";
         edtHistoricoSolicitudesOtros1_Internalname = sPrefix+"HISTORICOSOLICITUDESOTROS1";
         edtHistoricoSolicitudesOtros2_Internalname = sPrefix+"HISTORICOSOLICITUDESOTROS2";
         edtHistoricoSolicitudesOtros3_Internalname = sPrefix+"HISTORICOSOLICITUDESOTROS3";
         edtHistoricoSolicitudesFechaAlta_Internalname = sPrefix+"HISTORICOSOLICITUDESFECHAALTA";
         edtHistoricoSolicitudesFechaActua_Internalname = sPrefix+"HISTORICOSOLICITUDESFECHAACTUA";
         edtHistoricoSolicitudesFechaInsta_Internalname = sPrefix+"HISTORICOSOLICITUDESFECHAINSTA";
         edtHistoricoSolicitudesHoraInstal_Internalname = sPrefix+"HISTORICOSOLICITUDESHORAINSTAL";
         edtHistoricoSolicitudesComentario_Internalname = sPrefix+"HISTORICOSOLICITUDESCOMENTARIO";
         edtMetodoPagosID_Internalname = sPrefix+"METODOPAGOSID";
         edtHistoricoSolicitudesNota_Internalname = sPrefix+"HISTORICOSOLICITUDESNOTA";
         edtHistoricoSolicitudesNotificaci_Internalname = sPrefix+"HISTORICOSOLICITUDESNOTIFICACI";
         edtHistoricoSolicitudesOrigenPago_Internalname = sPrefix+"HISTORICOSOLICITUDESORIGENPAGO";
         cmbHistoricoSolicitudesPagado_Internalname = sPrefix+"HISTORICOSOLICITUDESPAGADO";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         cmbHistoricoSolicitudesPagado_Jsonclick = "";
         cmbHistoricoSolicitudesPagado.Enabled = 0;
         edtHistoricoSolicitudesOrigenPago_Jsonclick = "";
         edtHistoricoSolicitudesOrigenPago_Enabled = 0;
         edtHistoricoSolicitudesNotificaci_Jsonclick = "";
         edtHistoricoSolicitudesNotificaci_Enabled = 0;
         edtHistoricoSolicitudesNota_Enabled = 0;
         edtMetodoPagosID_Jsonclick = "";
         edtMetodoPagosID_Enabled = 0;
         edtHistoricoSolicitudesComentario_Enabled = 0;
         edtHistoricoSolicitudesHoraInstal_Jsonclick = "";
         edtHistoricoSolicitudesHoraInstal_Enabled = 0;
         edtHistoricoSolicitudesFechaInsta_Jsonclick = "";
         edtHistoricoSolicitudesFechaInsta_Enabled = 0;
         edtHistoricoSolicitudesFechaActua_Jsonclick = "";
         edtHistoricoSolicitudesFechaActua_Enabled = 0;
         edtHistoricoSolicitudesFechaAlta_Jsonclick = "";
         edtHistoricoSolicitudesFechaAlta_Enabled = 0;
         edtHistoricoSolicitudesOtros3_Enabled = 0;
         edtHistoricoSolicitudesOtros2_Enabled = 0;
         edtHistoricoSolicitudesOtros1_Jsonclick = "";
         edtHistoricoSolicitudesOtros1_Enabled = 0;
         edtEstadosSolId_Jsonclick = "";
         edtEstadosSolId_Enabled = 0;
         edtEstadosSolTipo_Jsonclick = "";
         edtEstadosSolTipo_Enabled = 0;
         edtHistoricoSolicitudServicioPFin_Jsonclick = "";
         edtHistoricoSolicitudServicioPFin_Enabled = 0;
         edtHistoricoSolicitudServicioSolC_Jsonclick = "";
         edtHistoricoSolicitudServicioSolC_Enabled = 0;
         edtHistoricoSolicitudesTotal_Jsonclick = "";
         edtHistoricoSolicitudesTotal_Enabled = 0;
         edtHistoricoSolicitudesCotizacion_Jsonclick = "";
         edtHistoricoSolicitudesCotizacion_Enabled = 0;
         edtHistoricoSolicitudesAutoEnumer_Jsonclick = "";
         edtHistoricoSolicitudesAutoEnumer_Enabled = 0;
         edtHistoricoSolicitudesDireccion_Enabled = 0;
         edtHistoricoZonasID_Jsonclick = "";
         edtHistoricoZonasID_Enabled = 0;
         edtHistoricoDepartamentoMunicipio_Jsonclick = "";
         edtHistoricoDepartamentoMunicipio_Enabled = 0;
         edtHistoricoDepartamentoId_Jsonclick = "";
         edtHistoricoDepartamentoId_Enabled = 0;
         edtHistoricoPaisID_Jsonclick = "";
         edtHistoricoPaisID_Enabled = 0;
         edtHistoricoSolicitudesMail_Jsonclick = "";
         edtHistoricoSolicitudesMail_Enabled = 0;
         edtHistoricoSolicitudesTelefono_Jsonclick = "";
         edtHistoricoSolicitudesTelefono_Enabled = 0;
         edtHistoricoSolicitudesNombre_Jsonclick = "";
         edtHistoricoSolicitudesNombre_Link = "";
         edtHistoricoSolicitudesNombre_Enabled = 0;
         edtHistoricoSolicitudesID_Jsonclick = "";
         edtHistoricoSolicitudesID_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A153HistoricoSolicitudesID',fld:'HISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E132J2',iparms:[{av:'A153HistoricoSolicitudesID',fld:'HISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E142J2',iparms:[{av:'A153HistoricoSolicitudesID',fld:'HISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESID","{handler:'Valid_Historicosolicitudesid',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESID",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESCOTIZACION","{handler:'Valid_Historicosolicitudescotizacion',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESCOTIZACION",",oparms:[]}");
         setEventMetadata("VALID_HISTORICOSOLICITUDESTOTAL","{handler:'Valid_Historicosolicitudestotal',iparms:[]");
         setEventMetadata("VALID_HISTORICOSOLICITUDESTOTAL",",oparms:[]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV13Pgmname = "";
         H002J2_A153HistoricoSolicitudesID = new long[1] ;
         H002J2_A154HistoricoSolicitudesItemsID = new short[1] ;
         H002J2_A298HistoricoSolicitudesItemsComis = new decimal[1] ;
         H002J2_A297HistoricoSolicitudesItemsCT = new string[] {""} ;
         H002J2_A296HistoricoSolicitudesItemsSR = new string[] {""} ;
         H002J2_A293HItemsSolicitudesItemsCantidad = new short[1] ;
         H002J2_A295HItemsInventarioPrecioFinal = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         TempTags = "";
         A288HistoricoSolicitudesNombre = "";
         gxphoneLink = "";
         A289HistoricoSolicitudesTelefono = "";
         A290HistoricoSolicitudesMail = "";
         A315HistoricoPaisID = "";
         ClassString = "";
         StyleString = "";
         A291HistoricoSolicitudesDireccion = "";
         A301HistoricoSolicitudServicioSolC = "";
         A130EstadosSolTipo = "";
         A303HistoricoSolicitudesOtros1 = "";
         A304HistoricoSolicitudesOtros2 = "";
         A305HistoricoSolicitudesOtros3 = "";
         A306HistoricoSolicitudesFechaAlta = DateTime.MinValue;
         A307HistoricoSolicitudesFechaActua = (DateTime)(DateTime.MinValue);
         A308HistoricoSolicitudesFechaInsta = DateTime.MinValue;
         A309HistoricoSolicitudesHoraInstal = "";
         A310HistoricoSolicitudesComentario = "";
         A311HistoricoSolicitudesNota = "";
         A312HistoricoSolicitudesNotificaci = "";
         A439HistoricoSolicitudesOrigenPago = "";
         A442HistoricoSolicitudesPagado = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H002J3_A153HistoricoSolicitudesID = new long[1] ;
         H002J3_A442HistoricoSolicitudesPagado = new string[] {""} ;
         H002J3_A439HistoricoSolicitudesOrigenPago = new string[] {""} ;
         H002J3_A312HistoricoSolicitudesNotificaci = new string[] {""} ;
         H002J3_A311HistoricoSolicitudesNota = new string[] {""} ;
         H002J3_A128MetodoPagosID = new long[1] ;
         H002J3_A310HistoricoSolicitudesComentario = new string[] {""} ;
         H002J3_A309HistoricoSolicitudesHoraInstal = new string[] {""} ;
         H002J3_A308HistoricoSolicitudesFechaInsta = new DateTime[] {DateTime.MinValue} ;
         H002J3_A307HistoricoSolicitudesFechaActua = new DateTime[] {DateTime.MinValue} ;
         H002J3_A306HistoricoSolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H002J3_A305HistoricoSolicitudesOtros3 = new string[] {""} ;
         H002J3_A304HistoricoSolicitudesOtros2 = new string[] {""} ;
         H002J3_A303HistoricoSolicitudesOtros1 = new string[] {""} ;
         H002J3_A131EstadosSolId = new int[1] ;
         H002J3_A130EstadosSolTipo = new string[] {""} ;
         H002J3_A301HistoricoSolicitudServicioSolC = new string[] {""} ;
         H002J3_A292HistoricoSolicitudesAutoEnumer = new short[1] ;
         H002J3_A291HistoricoSolicitudesDireccion = new string[] {""} ;
         H002J3_A318HistoricoZonasID = new long[1] ;
         H002J3_n318HistoricoZonasID = new bool[] {false} ;
         H002J3_A317HistoricoDepartamentoMunicipio = new long[1] ;
         H002J3_A316HistoricoDepartamentoId = new long[1] ;
         H002J3_A315HistoricoPaisID = new string[] {""} ;
         H002J3_A290HistoricoSolicitudesMail = new string[] {""} ;
         H002J3_n290HistoricoSolicitudesMail = new bool[] {false} ;
         H002J3_A289HistoricoSolicitudesTelefono = new string[] {""} ;
         H002J3_A288HistoricoSolicitudesNombre = new string[] {""} ;
         H002J3_A299HistoricoSolicitudesCotizacion = new decimal[1] ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA153HistoricoSolicitudesID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historicosolicitudesgeneral__default(),
            new Object[][] {
                new Object[] {
               H002J2_A153HistoricoSolicitudesID, H002J2_A154HistoricoSolicitudesItemsID, H002J2_A298HistoricoSolicitudesItemsComis, H002J2_A297HistoricoSolicitudesItemsCT, H002J2_A296HistoricoSolicitudesItemsSR, H002J2_A293HItemsSolicitudesItemsCantidad, H002J2_A295HItemsInventarioPrecioFinal
               }
               , new Object[] {
               H002J3_A153HistoricoSolicitudesID, H002J3_A442HistoricoSolicitudesPagado, H002J3_A439HistoricoSolicitudesOrigenPago, H002J3_A312HistoricoSolicitudesNotificaci, H002J3_A311HistoricoSolicitudesNota, H002J3_A128MetodoPagosID, H002J3_A310HistoricoSolicitudesComentario, H002J3_A309HistoricoSolicitudesHoraInstal, H002J3_A308HistoricoSolicitudesFechaInsta, H002J3_A307HistoricoSolicitudesFechaActua,
               H002J3_A306HistoricoSolicitudesFechaAlta, H002J3_A305HistoricoSolicitudesOtros3, H002J3_A304HistoricoSolicitudesOtros2, H002J3_A303HistoricoSolicitudesOtros1, H002J3_A131EstadosSolId, H002J3_A130EstadosSolTipo, H002J3_A301HistoricoSolicitudServicioSolC, H002J3_A292HistoricoSolicitudesAutoEnumer, H002J3_A291HistoricoSolicitudesDireccion, H002J3_A318HistoricoZonasID,
               H002J3_n318HistoricoZonasID, H002J3_A317HistoricoDepartamentoMunicipio, H002J3_A316HistoricoDepartamentoId, H002J3_A315HistoricoPaisID, H002J3_A290HistoricoSolicitudesMail, H002J3_n290HistoricoSolicitudesMail, H002J3_A289HistoricoSolicitudesTelefono, H002J3_A288HistoricoSolicitudesNombre, H002J3_A299HistoricoSolicitudesCotizacion
               }
            }
         );
         AV13Pgmname = "HistoricoSolicitudesGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "HistoricoSolicitudesGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short A292HistoricoSolicitudesAutoEnumer ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtHistoricoSolicitudesID_Enabled ;
      private int edtHistoricoSolicitudesNombre_Enabled ;
      private int edtHistoricoSolicitudesTelefono_Enabled ;
      private int edtHistoricoSolicitudesMail_Enabled ;
      private int edtHistoricoPaisID_Enabled ;
      private int edtHistoricoDepartamentoId_Enabled ;
      private int edtHistoricoDepartamentoMunicipio_Enabled ;
      private int edtHistoricoZonasID_Enabled ;
      private int edtHistoricoSolicitudesDireccion_Enabled ;
      private int edtHistoricoSolicitudesAutoEnumer_Enabled ;
      private int edtHistoricoSolicitudesCotizacion_Enabled ;
      private int edtHistoricoSolicitudesTotal_Enabled ;
      private int edtHistoricoSolicitudServicioSolC_Enabled ;
      private int edtHistoricoSolicitudServicioPFin_Enabled ;
      private int edtEstadosSolTipo_Enabled ;
      private int A131EstadosSolId ;
      private int edtEstadosSolId_Enabled ;
      private int edtHistoricoSolicitudesOtros1_Enabled ;
      private int edtHistoricoSolicitudesOtros2_Enabled ;
      private int edtHistoricoSolicitudesOtros3_Enabled ;
      private int edtHistoricoSolicitudesFechaAlta_Enabled ;
      private int edtHistoricoSolicitudesFechaActua_Enabled ;
      private int edtHistoricoSolicitudesFechaInsta_Enabled ;
      private int edtHistoricoSolicitudesHoraInstal_Enabled ;
      private int edtHistoricoSolicitudesComentario_Enabled ;
      private int edtMetodoPagosID_Enabled ;
      private int edtHistoricoSolicitudesNota_Enabled ;
      private int edtHistoricoSolicitudesNotificaci_Enabled ;
      private int edtHistoricoSolicitudesOrigenPago_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int idxLst ;
      private long A153HistoricoSolicitudesID ;
      private long wcpOA153HistoricoSolicitudesID ;
      private long A316HistoricoDepartamentoId ;
      private long A317HistoricoDepartamentoMunicipio ;
      private long A318HistoricoZonasID ;
      private long A128MetodoPagosID ;
      private decimal A300HistoricoSolicitudesTotal ;
      private decimal A294HItemsSolicitudesItemsPrecioIn ;
      private decimal A299HistoricoSolicitudesCotizacion ;
      private decimal A302HistoricoSolicitudServicioPFin ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtHistoricoSolicitudesID_Internalname ;
      private string TempTags ;
      private string edtHistoricoSolicitudesID_Jsonclick ;
      private string edtHistoricoSolicitudesNombre_Internalname ;
      private string A288HistoricoSolicitudesNombre ;
      private string edtHistoricoSolicitudesNombre_Link ;
      private string edtHistoricoSolicitudesNombre_Jsonclick ;
      private string edtHistoricoSolicitudesTelefono_Internalname ;
      private string gxphoneLink ;
      private string A289HistoricoSolicitudesTelefono ;
      private string edtHistoricoSolicitudesTelefono_Jsonclick ;
      private string edtHistoricoSolicitudesMail_Internalname ;
      private string edtHistoricoSolicitudesMail_Jsonclick ;
      private string edtHistoricoPaisID_Internalname ;
      private string A315HistoricoPaisID ;
      private string edtHistoricoPaisID_Jsonclick ;
      private string edtHistoricoDepartamentoId_Internalname ;
      private string edtHistoricoDepartamentoId_Jsonclick ;
      private string edtHistoricoDepartamentoMunicipio_Internalname ;
      private string edtHistoricoDepartamentoMunicipio_Jsonclick ;
      private string edtHistoricoZonasID_Internalname ;
      private string edtHistoricoZonasID_Jsonclick ;
      private string edtHistoricoSolicitudesDireccion_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string edtHistoricoSolicitudesAutoEnumer_Internalname ;
      private string edtHistoricoSolicitudesAutoEnumer_Jsonclick ;
      private string edtHistoricoSolicitudesCotizacion_Internalname ;
      private string edtHistoricoSolicitudesCotizacion_Jsonclick ;
      private string edtHistoricoSolicitudesTotal_Internalname ;
      private string edtHistoricoSolicitudesTotal_Jsonclick ;
      private string edtHistoricoSolicitudServicioSolC_Internalname ;
      private string A301HistoricoSolicitudServicioSolC ;
      private string edtHistoricoSolicitudServicioSolC_Jsonclick ;
      private string edtHistoricoSolicitudServicioPFin_Internalname ;
      private string edtHistoricoSolicitudServicioPFin_Jsonclick ;
      private string edtEstadosSolTipo_Internalname ;
      private string A130EstadosSolTipo ;
      private string edtEstadosSolTipo_Jsonclick ;
      private string edtEstadosSolId_Internalname ;
      private string edtEstadosSolId_Jsonclick ;
      private string edtHistoricoSolicitudesOtros1_Internalname ;
      private string A303HistoricoSolicitudesOtros1 ;
      private string edtHistoricoSolicitudesOtros1_Jsonclick ;
      private string edtHistoricoSolicitudesOtros2_Internalname ;
      private string A304HistoricoSolicitudesOtros2 ;
      private string edtHistoricoSolicitudesOtros3_Internalname ;
      private string A305HistoricoSolicitudesOtros3 ;
      private string edtHistoricoSolicitudesFechaAlta_Internalname ;
      private string edtHistoricoSolicitudesFechaAlta_Jsonclick ;
      private string edtHistoricoSolicitudesFechaActua_Internalname ;
      private string edtHistoricoSolicitudesFechaActua_Jsonclick ;
      private string edtHistoricoSolicitudesFechaInsta_Internalname ;
      private string edtHistoricoSolicitudesFechaInsta_Jsonclick ;
      private string edtHistoricoSolicitudesHoraInstal_Internalname ;
      private string A309HistoricoSolicitudesHoraInstal ;
      private string edtHistoricoSolicitudesHoraInstal_Jsonclick ;
      private string edtHistoricoSolicitudesComentario_Internalname ;
      private string edtMetodoPagosID_Internalname ;
      private string edtMetodoPagosID_Jsonclick ;
      private string edtHistoricoSolicitudesNota_Internalname ;
      private string A311HistoricoSolicitudesNota ;
      private string edtHistoricoSolicitudesNotificaci_Internalname ;
      private string A312HistoricoSolicitudesNotificaci ;
      private string edtHistoricoSolicitudesNotificaci_Jsonclick ;
      private string edtHistoricoSolicitudesOrigenPago_Internalname ;
      private string A439HistoricoSolicitudesOrigenPago ;
      private string edtHistoricoSolicitudesOrigenPago_Jsonclick ;
      private string cmbHistoricoSolicitudesPagado_Internalname ;
      private string A442HistoricoSolicitudesPagado ;
      private string cmbHistoricoSolicitudesPagado_Jsonclick ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlA153HistoricoSolicitudesID ;
      private DateTime A307HistoricoSolicitudesFechaActua ;
      private DateTime A306HistoricoSolicitudesFechaAlta ;
      private DateTime A308HistoricoSolicitudesFechaInsta ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n318HistoricoZonasID ;
      private bool n290HistoricoSolicitudesMail ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A310HistoricoSolicitudesComentario ;
      private string A290HistoricoSolicitudesMail ;
      private string A291HistoricoSolicitudesDireccion ;
      private GXWebForm Form ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbHistoricoSolicitudesPagado ;
      private IDataStoreProvider pr_default ;
      private long[] H002J2_A153HistoricoSolicitudesID ;
      private short[] H002J2_A154HistoricoSolicitudesItemsID ;
      private decimal[] H002J2_A298HistoricoSolicitudesItemsComis ;
      private string[] H002J2_A297HistoricoSolicitudesItemsCT ;
      private string[] H002J2_A296HistoricoSolicitudesItemsSR ;
      private short[] H002J2_A293HItemsSolicitudesItemsCantidad ;
      private short[] H002J2_A295HItemsInventarioPrecioFinal ;
      private long[] H002J3_A153HistoricoSolicitudesID ;
      private string[] H002J3_A442HistoricoSolicitudesPagado ;
      private string[] H002J3_A439HistoricoSolicitudesOrigenPago ;
      private string[] H002J3_A312HistoricoSolicitudesNotificaci ;
      private string[] H002J3_A311HistoricoSolicitudesNota ;
      private long[] H002J3_A128MetodoPagosID ;
      private string[] H002J3_A310HistoricoSolicitudesComentario ;
      private string[] H002J3_A309HistoricoSolicitudesHoraInstal ;
      private DateTime[] H002J3_A308HistoricoSolicitudesFechaInsta ;
      private DateTime[] H002J3_A307HistoricoSolicitudesFechaActua ;
      private DateTime[] H002J3_A306HistoricoSolicitudesFechaAlta ;
      private string[] H002J3_A305HistoricoSolicitudesOtros3 ;
      private string[] H002J3_A304HistoricoSolicitudesOtros2 ;
      private string[] H002J3_A303HistoricoSolicitudesOtros1 ;
      private int[] H002J3_A131EstadosSolId ;
      private string[] H002J3_A130EstadosSolTipo ;
      private string[] H002J3_A301HistoricoSolicitudServicioSolC ;
      private short[] H002J3_A292HistoricoSolicitudesAutoEnumer ;
      private string[] H002J3_A291HistoricoSolicitudesDireccion ;
      private long[] H002J3_A318HistoricoZonasID ;
      private bool[] H002J3_n318HistoricoZonasID ;
      private long[] H002J3_A317HistoricoDepartamentoMunicipio ;
      private long[] H002J3_A316HistoricoDepartamentoId ;
      private string[] H002J3_A315HistoricoPaisID ;
      private string[] H002J3_A290HistoricoSolicitudesMail ;
      private bool[] H002J3_n290HistoricoSolicitudesMail ;
      private string[] H002J3_A289HistoricoSolicitudesTelefono ;
      private string[] H002J3_A288HistoricoSolicitudesNombre ;
      private decimal[] H002J3_A299HistoricoSolicitudesCotizacion ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class historicosolicitudesgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH002J2;
          prmH002J2 = new Object[] {
          new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmH002J3;
          prmH002J3 = new Object[] {
          new ParDef("@HistoricoSolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002J2", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID], [HistoricoSolicitudesItemsComis], [HistoricoSolicitudesItemsCT], [HistoricoSolicitudesItemsSR], [HItemsSolicitudesItemsCantidad], [HItemsInventarioPrecioFinal] FROM [HistoricoSolicitudesItems] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ORDER BY [HistoricoSolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002J2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002J3", "SELECT [HistoricoSolicitudesID], [HistoricoSolicitudesPagado], [HistoricoSolicitudesOrigenPago], [HistoricoSolicitudesNotificaci], [HistoricoSolicitudesNota], [MetodoPagosID], [HistoricoSolicitudesComentario], [HistoricoSolicitudesHoraInstal], [HistoricoSolicitudesFechaInsta], [HistoricoSolicitudesFechaActua], [HistoricoSolicitudesFechaAlta], [HistoricoSolicitudesOtros3], [HistoricoSolicitudesOtros2], [HistoricoSolicitudesOtros1], [EstadosSolId], [EstadosSolTipo], [HistoricoSolicitudServicioSolC], [HistoricoSolicitudesAutoEnumer], [HistoricoSolicitudesDireccion], [HistoricoZonasID], [HistoricoDepartamentoMunicipio], [HistoricoDepartamentoId], [HistoricoPaisID], [HistoricoSolicitudesMail], [HistoricoSolicitudesTelefono], [HistoricoSolicitudesNombre], [HistoricoSolicitudesCotizacion] FROM [HistoricoSolicitudes] WHERE [HistoricoSolicitudesID] = @HistoricoSolicitudesID ORDER BY [HistoricoSolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002J3,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 500);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 1);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 500);
                ((string[]) buf[12])[0] = rslt.getString(13, 1000);
                ((string[]) buf[13])[0] = rslt.getString(14, 1);
                ((int[]) buf[14])[0] = rslt.getInt(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 3);
                ((string[]) buf[16])[0] = rslt.getString(17, 1);
                ((short[]) buf[17])[0] = rslt.getShort(18);
                ((string[]) buf[18])[0] = rslt.getVarchar(19);
                ((long[]) buf[19])[0] = rslt.getLong(20);
                ((bool[]) buf[20])[0] = rslt.wasNull(20);
                ((long[]) buf[21])[0] = rslt.getLong(21);
                ((long[]) buf[22])[0] = rslt.getLong(22);
                ((string[]) buf[23])[0] = rslt.getString(23, 2);
                ((string[]) buf[24])[0] = rslt.getVarchar(24);
                ((bool[]) buf[25])[0] = rslt.wasNull(24);
                ((string[]) buf[26])[0] = rslt.getString(25, 20);
                ((string[]) buf[27])[0] = rslt.getString(26, 100);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
                return;
       }
    }

 }

}

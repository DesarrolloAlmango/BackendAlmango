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
   public class gx0171 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0171( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0171( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pHistoricoSolicitudesID ,
                           out short aP1_pHistoricoSolicitudesItemsID )
      {
         this.AV12pHistoricoSolicitudesID = aP0_pHistoricoSolicitudesID;
         this.AV13pHistoricoSolicitudesItemsID = 0 ;
         ExecutePrivate();
         aP1_pHistoricoSolicitudesItemsID=this.AV13pHistoricoSolicitudesItemsID;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pHistoricoSolicitudesID");
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
               gxfirstwebparm = GetFirstPar( "pHistoricoSolicitudesID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pHistoricoSolicitudesID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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
               AV12pHistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pHistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(AV12pHistoricoSolicitudesID), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pHistoricoSolicitudesItemsID = (short)(Math.Round(NumberUtil.Val( GetPar( "pHistoricoSolicitudesItemsID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pHistoricoSolicitudesItemsID", StringUtil.LTrimStr( (decimal)(AV13pHistoricoSolicitudesItemsID), 4, 0));
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_74 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cHistoricoSolicitudesItemsID = (short)(Math.Round(NumberUtil.Val( GetPar( "cHistoricoSolicitudesItemsID"), "."), 18, MidpointRounding.ToEven));
         AV7cHItemsRubrosId = (long)(Math.Round(NumberUtil.Val( GetPar( "cHItemsRubrosId"), "."), 18, MidpointRounding.ToEven));
         AV8cHItemsRubrosNombre = GetPar( "cHItemsRubrosNombre");
         AV9cHItemsMedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "cHItemsMedidasID"), "."), 18, MidpointRounding.ToEven));
         AV10cHItemsInventarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "cHItemsInventarioId"), "."), 18, MidpointRounding.ToEven));
         AV11cHItemsInventarioNombre = GetPar( "cHItemsInventarioNombre");
         AV12pHistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "pHistoricoSolicitudesID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cHistoricoSolicitudesItemsID, AV7cHItemsRubrosId, AV8cHItemsRubrosNombre, AV9cHItemsMedidasID, AV10cHItemsInventarioId, AV11cHItemsInventarioNombre, AV12pHistoricoSolicitudesID) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA9J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9J2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0171.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pHistoricoSolicitudesID,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pHistoricoSolicitudesItemsID,4,0))}, new string[] {"pHistoricoSolicitudesID","pHistoricoSolicitudesItemsID"}) +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCHISTORICOSOLICITUDESITEMSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cHistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHITEMSRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cHItemsRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHITEMSRUBROSNOMBRE", StringUtil.RTrim( AV8cHItemsRubrosNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCHITEMSMEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cHItemsMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHITEMSINVENTARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cHItemsInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHITEMSINVENTARIONOMBRE", StringUtil.RTrim( AV11cHItemsInventarioNombre));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPHISTORICOSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pHistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPHISTORICOSOLICITUDESITEMSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pHistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESITEMSIDFILTERCONTAINER_Class", StringUtil.RTrim( divHistoricosolicitudesitemsidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HITEMSRUBROSIDFILTERCONTAINER_Class", StringUtil.RTrim( divHitemsrubrosidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HITEMSRUBROSNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divHitemsrubrosnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HITEMSMEDIDASIDFILTERCONTAINER_Class", StringUtil.RTrim( divHitemsmedidasidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HITEMSINVENTARIOIDFILTERCONTAINER_Class", StringUtil.RTrim( divHitemsinventarioidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HITEMSINVENTARIONOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divHitemsinventarionombrefiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE9J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9J2( ) ;
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
         return formatLink("gx0171.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pHistoricoSolicitudesID,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pHistoricoSolicitudesItemsID,4,0))}, new string[] {"pHistoricoSolicitudesID","pHistoricoSolicitudesItemsID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0171" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Items", "") ;
      }

      protected void WB9J0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHistoricosolicitudesitemsidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divHistoricosolicitudesitemsidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhistoricosolicitudesitemsidfilter_Internalname, context.GetMessage( "Historico Solicitudes Items ID", ""), "", "", lblLblhistoricosolicitudesitemsidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e119j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0171.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChistoricosolicitudesitemsid_Internalname, context.GetMessage( "Historico Solicitudes Items ID", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChistoricosolicitudesitemsid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cHistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavChistoricosolicitudesitemsid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cHistoricoSolicitudesItemsID), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cHistoricoSolicitudesItemsID), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChistoricosolicitudesitemsid_Jsonclick, 0, "Attribute", "", "", "", "", edtavChistoricosolicitudesitemsid_Visible, edtavChistoricosolicitudesitemsid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0171.htm");
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
            GxWebStd.gx_div_start( context, divHitemsrubrosidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divHitemsrubrosidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhitemsrubrosidfilter_Internalname, context.GetMessage( "HItems Rubros Id", ""), "", "", lblLblhitemsrubrosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e129j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0171.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChitemsrubrosid_Internalname, context.GetMessage( "HItems Rubros Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChitemsrubrosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cHItemsRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavChitemsrubrosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cHItemsRubrosId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7cHItemsRubrosId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChitemsrubrosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavChitemsrubrosid_Visible, edtavChitemsrubrosid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0171.htm");
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
            GxWebStd.gx_div_start( context, divHitemsrubrosnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divHitemsrubrosnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhitemsrubrosnombrefilter_Internalname, context.GetMessage( "HItems Rubros Nombre", ""), "", "", lblLblhitemsrubrosnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e139j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0171.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChitemsrubrosnombre_Internalname, context.GetMessage( "HItems Rubros Nombre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChitemsrubrosnombre_Internalname, StringUtil.RTrim( AV8cHItemsRubrosNombre), StringUtil.RTrim( context.localUtil.Format( AV8cHItemsRubrosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChitemsrubrosnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavChitemsrubrosnombre_Visible, edtavChitemsrubrosnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0171.htm");
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
            GxWebStd.gx_div_start( context, divHitemsmedidasidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divHitemsmedidasidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhitemsmedidasidfilter_Internalname, context.GetMessage( "HItems Medidas ID", ""), "", "", lblLblhitemsmedidasidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e149j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0171.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChitemsmedidasid_Internalname, context.GetMessage( "HItems Medidas ID", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChitemsmedidasid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cHItemsMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavChitemsmedidasid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cHItemsMedidasID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV9cHItemsMedidasID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChitemsmedidasid_Jsonclick, 0, "Attribute", "", "", "", "", edtavChitemsmedidasid_Visible, edtavChitemsmedidasid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0171.htm");
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
            GxWebStd.gx_div_start( context, divHitemsinventarioidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divHitemsinventarioidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhitemsinventarioidfilter_Internalname, context.GetMessage( "HItems Inventario Id", ""), "", "", lblLblhitemsinventarioidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e159j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0171.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChitemsinventarioid_Internalname, context.GetMessage( "HItems Inventario Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChitemsinventarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cHItemsInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavChitemsinventarioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cHItemsInventarioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV10cHItemsInventarioId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChitemsinventarioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavChitemsinventarioid_Visible, edtavChitemsinventarioid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0171.htm");
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
            GxWebStd.gx_div_start( context, divHitemsinventarionombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divHitemsinventarionombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhitemsinventarionombrefilter_Internalname, context.GetMessage( "Producto Nombre", ""), "", "", lblLblhitemsinventarionombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e169j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0171.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChitemsinventarionombre_Internalname, context.GetMessage( "Producto Nombre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChitemsinventarionombre_Internalname, StringUtil.RTrim( AV11cHItemsInventarioNombre), StringUtil.RTrim( context.localUtil.Format( AV11cHItemsInventarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChitemsinventarionombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavChitemsinventarionombre_Visible, edtavChitemsinventarionombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0171.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e179j1_client"+"'", TempTags, "", 2, "HLP_Gx0171.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl74( ) ;
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0171.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START9J2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Items", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9J0( ) ;
      }

      protected void WS9J2( )
      {
         START9J2( ) ;
         EVT9J2( ) ;
      }

      protected void EVT9J2( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A154HistoricoSolicitudesItemsID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesItemsID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A330HItemsRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A327HItemsMedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsMedidasID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A328HItemsInventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsInventarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A295HItemsInventarioPrecioFinal = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHItemsInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A153HistoricoSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E189J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E199J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Chistoricosolicitudesitemsid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHISTORICOSOLICITUDESITEMSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cHistoricoSolicitudesItemsID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chitemsrubrosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHITEMSRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cHItemsRubrosId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chitemsrubrosnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHITEMSRUBROSNOMBRE"), AV8cHItemsRubrosNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chitemsmedidasid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHITEMSMEDIDASID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV9cHItemsMedidasID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chitemsinventarioid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHITEMSINVENTARIOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV10cHItemsInventarioId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chitemsinventarionombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHITEMSINVENTARIONOMBRE"), AV11cHItemsInventarioNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E209J2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE9J2( )
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

      protected void PA9J2( )
      {
         if ( nDonePA == 0 )
         {
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cHistoricoSolicitudesItemsID ,
                                        long AV7cHItemsRubrosId ,
                                        string AV8cHItemsRubrosNombre ,
                                        long AV9cHItemsMedidasID ,
                                        long AV10cHItemsInventarioId ,
                                        string AV11cHItemsInventarioNombre ,
                                        long AV12pHistoricoSolicitudesID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF9J2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_HISTORICOSOLICITUDESITEMSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A154HistoricoSolicitudesItemsID), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "HISTORICOSOLICITUDESITEMSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A154HistoricoSolicitudesItemsID), 4, 0, ".", "")));
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
         RF9J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cHItemsRubrosId ,
                                                 AV8cHItemsRubrosNombre ,
                                                 AV9cHItemsMedidasID ,
                                                 AV10cHItemsInventarioId ,
                                                 AV11cHItemsInventarioNombre ,
                                                 A330HItemsRubrosId ,
                                                 A331HItemsRubrosNombre ,
                                                 A327HItemsMedidasID ,
                                                 A328HItemsInventarioId ,
                                                 A329HItemsInventarioNombre ,
                                                 AV12pHistoricoSolicitudesID ,
                                                 AV6cHistoricoSolicitudesItemsID ,
                                                 A153HistoricoSolicitudesID } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG
                                                 }
            });
            lV8cHItemsRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV8cHItemsRubrosNombre), 100, "%");
            lV11cHItemsInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV11cHItemsInventarioNombre), 100, "%");
            /* Using cursor H009J2 */
            pr_default.execute(0, new Object[] {AV12pHistoricoSolicitudesID, AV6cHistoricoSolicitudesItemsID, AV7cHItemsRubrosId, lV8cHItemsRubrosNombre, AV9cHItemsMedidasID, AV10cHItemsInventarioId, lV11cHItemsInventarioNombre, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A329HItemsInventarioNombre = H009J2_A329HItemsInventarioNombre[0];
               A331HItemsRubrosNombre = H009J2_A331HItemsRubrosNombre[0];
               A153HistoricoSolicitudesID = H009J2_A153HistoricoSolicitudesID[0];
               A295HItemsInventarioPrecioFinal = H009J2_A295HItemsInventarioPrecioFinal[0];
               A328HItemsInventarioId = H009J2_A328HItemsInventarioId[0];
               A327HItemsMedidasID = H009J2_A327HItemsMedidasID[0];
               A330HItemsRubrosId = H009J2_A330HItemsRubrosId[0];
               A154HistoricoSolicitudesItemsID = H009J2_A154HistoricoSolicitudesItemsID[0];
               /* Execute user event: Load */
               E199J2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB9J0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9J2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_HISTORICOSOLICITUDESITEMSID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A154HistoricoSolicitudesItemsID), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((long)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cHItemsRubrosId ,
                                              AV8cHItemsRubrosNombre ,
                                              AV9cHItemsMedidasID ,
                                              AV10cHItemsInventarioId ,
                                              AV11cHItemsInventarioNombre ,
                                              A330HItemsRubrosId ,
                                              A331HItemsRubrosNombre ,
                                              A327HItemsMedidasID ,
                                              A328HItemsInventarioId ,
                                              A329HItemsInventarioNombre ,
                                              AV12pHistoricoSolicitudesID ,
                                              AV6cHistoricoSolicitudesItemsID ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG
                                              }
         });
         lV8cHItemsRubrosNombre = StringUtil.PadR( StringUtil.RTrim( AV8cHItemsRubrosNombre), 100, "%");
         lV11cHItemsInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV11cHItemsInventarioNombre), 100, "%");
         /* Using cursor H009J3 */
         pr_default.execute(1, new Object[] {AV12pHistoricoSolicitudesID, AV6cHistoricoSolicitudesItemsID, AV7cHItemsRubrosId, lV8cHItemsRubrosNombre, AV9cHItemsMedidasID, AV10cHItemsInventarioId, lV11cHItemsInventarioNombre});
         GRID1_nRecordCount = H009J3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHistoricoSolicitudesItemsID, AV7cHItemsRubrosId, AV8cHItemsRubrosNombre, AV9cHItemsMedidasID, AV10cHItemsInventarioId, AV11cHItemsInventarioNombre, AV12pHistoricoSolicitudesID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHistoricoSolicitudesItemsID, AV7cHItemsRubrosId, AV8cHItemsRubrosNombre, AV9cHItemsMedidasID, AV10cHItemsInventarioId, AV11cHItemsInventarioNombre, AV12pHistoricoSolicitudesID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHistoricoSolicitudesItemsID, AV7cHItemsRubrosId, AV8cHItemsRubrosNombre, AV9cHItemsMedidasID, AV10cHItemsInventarioId, AV11cHItemsInventarioNombre, AV12pHistoricoSolicitudesID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((long)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((long)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHistoricoSolicitudesItemsID, AV7cHItemsRubrosId, AV8cHItemsRubrosNombre, AV9cHItemsMedidasID, AV10cHItemsInventarioId, AV11cHItemsInventarioNombre, AV12pHistoricoSolicitudesID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHistoricoSolicitudesItemsID, AV7cHItemsRubrosId, AV8cHItemsRubrosNombre, AV9cHItemsMedidasID, AV10cHItemsInventarioId, AV11cHItemsInventarioNombre, AV12pHistoricoSolicitudesID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtHistoricoSolicitudesItemsID_Enabled = 0;
         edtHItemsRubrosId_Enabled = 0;
         edtHItemsMedidasID_Enabled = 0;
         edtHItemsInventarioId_Enabled = 0;
         edtHItemsInventarioPrecioFinal_Enabled = 0;
         edtHistoricoSolicitudesID_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E189J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavChistoricosolicitudesitemsid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavChistoricosolicitudesitemsid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCHISTORICOSOLICITUDESITEMSID");
               GX_FocusControl = edtavChistoricosolicitudesitemsid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cHistoricoSolicitudesItemsID = 0;
               AssignAttri("", false, "AV6cHistoricoSolicitudesItemsID", StringUtil.LTrimStr( (decimal)(AV6cHistoricoSolicitudesItemsID), 4, 0));
            }
            else
            {
               AV6cHistoricoSolicitudesItemsID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavChistoricosolicitudesitemsid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cHistoricoSolicitudesItemsID", StringUtil.LTrimStr( (decimal)(AV6cHistoricoSolicitudesItemsID), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavChitemsrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavChitemsrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCHITEMSRUBROSID");
               GX_FocusControl = edtavChitemsrubrosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cHItemsRubrosId = 0;
               AssignAttri("", false, "AV7cHItemsRubrosId", StringUtil.LTrimStr( (decimal)(AV7cHItemsRubrosId), 18, 0));
            }
            else
            {
               AV7cHItemsRubrosId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavChitemsrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cHItemsRubrosId", StringUtil.LTrimStr( (decimal)(AV7cHItemsRubrosId), 18, 0));
            }
            AV8cHItemsRubrosNombre = cgiGet( edtavChitemsrubrosnombre_Internalname);
            AssignAttri("", false, "AV8cHItemsRubrosNombre", AV8cHItemsRubrosNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavChitemsmedidasid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavChitemsmedidasid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCHITEMSMEDIDASID");
               GX_FocusControl = edtavChitemsmedidasid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cHItemsMedidasID = 0;
               AssignAttri("", false, "AV9cHItemsMedidasID", StringUtil.LTrimStr( (decimal)(AV9cHItemsMedidasID), 18, 0));
            }
            else
            {
               AV9cHItemsMedidasID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavChitemsmedidasid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9cHItemsMedidasID", StringUtil.LTrimStr( (decimal)(AV9cHItemsMedidasID), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavChitemsinventarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavChitemsinventarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCHITEMSINVENTARIOID");
               GX_FocusControl = edtavChitemsinventarioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cHItemsInventarioId = 0;
               AssignAttri("", false, "AV10cHItemsInventarioId", StringUtil.LTrimStr( (decimal)(AV10cHItemsInventarioId), 18, 0));
            }
            else
            {
               AV10cHItemsInventarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavChitemsinventarioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10cHItemsInventarioId", StringUtil.LTrimStr( (decimal)(AV10cHItemsInventarioId), 18, 0));
            }
            AV11cHItemsInventarioNombre = cgiGet( edtavChitemsinventarionombre_Internalname);
            AssignAttri("", false, "AV11cHItemsInventarioNombre", AV11cHItemsInventarioNombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHISTORICOSOLICITUDESITEMSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cHistoricoSolicitudesItemsID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHITEMSRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cHItemsRubrosId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHITEMSRUBROSNOMBRE"), AV8cHItemsRubrosNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHITEMSMEDIDASID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV9cHItemsMedidasID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHITEMSINVENTARIOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV10cHItemsInventarioId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHITEMSINVENTARIONOMBRE"), AV11cHItemsInventarioNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E189J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E189J2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Items", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E199J2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            context.DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E209J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E209J2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pHistoricoSolicitudesItemsID = A154HistoricoSolicitudesItemsID;
         AssignAttri("", false, "AV13pHistoricoSolicitudesItemsID", StringUtil.LTrimStr( (decimal)(AV13pHistoricoSolicitudesItemsID), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pHistoricoSolicitudesItemsID});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pHistoricoSolicitudesItemsID"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12pHistoricoSolicitudesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pHistoricoSolicitudesID", StringUtil.LTrimStr( (decimal)(AV12pHistoricoSolicitudesID), 18, 0));
         AV13pHistoricoSolicitudesItemsID = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV13pHistoricoSolicitudesItemsID", StringUtil.LTrimStr( (decimal)(AV13pHistoricoSolicitudesItemsID), 4, 0));
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
         PA9J2( ) ;
         WS9J2( ) ;
         WE9J2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20267302126024", true, true, false);
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
         context.AddJavascriptSource("gx0171.js", "?20267302126024", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtHistoricoSolicitudesItemsID_Internalname = "HISTORICOSOLICITUDESITEMSID_"+sGXsfl_74_idx;
         edtHItemsRubrosId_Internalname = "HITEMSRUBROSID_"+sGXsfl_74_idx;
         edtHItemsMedidasID_Internalname = "HITEMSMEDIDASID_"+sGXsfl_74_idx;
         edtHItemsInventarioId_Internalname = "HITEMSINVENTARIOID_"+sGXsfl_74_idx;
         edtHItemsInventarioPrecioFinal_Internalname = "HITEMSINVENTARIOPRECIOFINAL_"+sGXsfl_74_idx;
         edtHistoricoSolicitudesID_Internalname = "HISTORICOSOLICITUDESID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtHistoricoSolicitudesItemsID_Internalname = "HISTORICOSOLICITUDESITEMSID_"+sGXsfl_74_fel_idx;
         edtHItemsRubrosId_Internalname = "HITEMSRUBROSID_"+sGXsfl_74_fel_idx;
         edtHItemsMedidasID_Internalname = "HITEMSMEDIDASID_"+sGXsfl_74_fel_idx;
         edtHItemsInventarioId_Internalname = "HITEMSINVENTARIOID_"+sGXsfl_74_fel_idx;
         edtHItemsInventarioPrecioFinal_Internalname = "HITEMSINVENTARIOPRECIOFINAL_"+sGXsfl_74_fel_idx;
         edtHistoricoSolicitudesID_Internalname = "HISTORICOSOLICITUDESID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WB9J0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A154HistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesItemsID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A154HistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A154HistoricoSolicitudesItemsID), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesItemsID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtHItemsRubrosId_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A154HistoricoSolicitudesItemsID), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtHItemsRubrosId_Internalname, "Link", edtHItemsRubrosId_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A330HItemsRubrosId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A330HItemsRubrosId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtHItemsRubrosId_Link,(string)"",(string)"",(string)"",(string)edtHItemsRubrosId_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsMedidasID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A327HItemsMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A327HItemsMedidasID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsMedidasID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsInventarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A328HItemsInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A328HItemsInventarioId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsInventarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHItemsInventarioPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A295HItemsInventarioPrecioFinal), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A295HItemsInventarioPrecioFinal), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHItemsInventarioPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes9J2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl74( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Items ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rubros Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Medidas ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Inventario Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Final", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Historico Solicitudes ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A154HistoricoSolicitudesItemsID), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A330HItemsRubrosId), 18, 0, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtHItemsRubrosId_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A327HItemsMedidasID), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A328HItemsInventarioId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A295HItemsInventarioPrecioFinal), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblhistoricosolicitudesitemsidfilter_Internalname = "LBLHISTORICOSOLICITUDESITEMSIDFILTER";
         edtavChistoricosolicitudesitemsid_Internalname = "vCHISTORICOSOLICITUDESITEMSID";
         divHistoricosolicitudesitemsidfiltercontainer_Internalname = "HISTORICOSOLICITUDESITEMSIDFILTERCONTAINER";
         lblLblhitemsrubrosidfilter_Internalname = "LBLHITEMSRUBROSIDFILTER";
         edtavChitemsrubrosid_Internalname = "vCHITEMSRUBROSID";
         divHitemsrubrosidfiltercontainer_Internalname = "HITEMSRUBROSIDFILTERCONTAINER";
         lblLblhitemsrubrosnombrefilter_Internalname = "LBLHITEMSRUBROSNOMBREFILTER";
         edtavChitemsrubrosnombre_Internalname = "vCHITEMSRUBROSNOMBRE";
         divHitemsrubrosnombrefiltercontainer_Internalname = "HITEMSRUBROSNOMBREFILTERCONTAINER";
         lblLblhitemsmedidasidfilter_Internalname = "LBLHITEMSMEDIDASIDFILTER";
         edtavChitemsmedidasid_Internalname = "vCHITEMSMEDIDASID";
         divHitemsmedidasidfiltercontainer_Internalname = "HITEMSMEDIDASIDFILTERCONTAINER";
         lblLblhitemsinventarioidfilter_Internalname = "LBLHITEMSINVENTARIOIDFILTER";
         edtavChitemsinventarioid_Internalname = "vCHITEMSINVENTARIOID";
         divHitemsinventarioidfiltercontainer_Internalname = "HITEMSINVENTARIOIDFILTERCONTAINER";
         lblLblhitemsinventarionombrefilter_Internalname = "LBLHITEMSINVENTARIONOMBREFILTER";
         edtavChitemsinventarionombre_Internalname = "vCHITEMSINVENTARIONOMBRE";
         divHitemsinventarionombrefiltercontainer_Internalname = "HITEMSINVENTARIONOMBREFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtHistoricoSolicitudesItemsID_Internalname = "HISTORICOSOLICITUDESITEMSID";
         edtHItemsRubrosId_Internalname = "HITEMSRUBROSID";
         edtHItemsMedidasID_Internalname = "HITEMSMEDIDASID";
         edtHItemsInventarioId_Internalname = "HITEMSINVENTARIOID";
         edtHItemsInventarioPrecioFinal_Internalname = "HITEMSINVENTARIOPRECIOFINAL";
         edtHistoricoSolicitudesID_Internalname = "HISTORICOSOLICITUDESID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtHistoricoSolicitudesID_Jsonclick = "";
         edtHItemsInventarioPrecioFinal_Jsonclick = "";
         edtHItemsInventarioId_Jsonclick = "";
         edtHItemsMedidasID_Jsonclick = "";
         edtHItemsRubrosId_Jsonclick = "";
         edtHItemsRubrosId_Link = "";
         edtHistoricoSolicitudesItemsID_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtHistoricoSolicitudesID_Enabled = 0;
         edtHItemsInventarioPrecioFinal_Enabled = 0;
         edtHItemsInventarioId_Enabled = 0;
         edtHItemsMedidasID_Enabled = 0;
         edtHItemsRubrosId_Enabled = 0;
         edtHistoricoSolicitudesItemsID_Enabled = 0;
         edtavChitemsinventarionombre_Jsonclick = "";
         edtavChitemsinventarionombre_Enabled = 1;
         edtavChitemsinventarionombre_Visible = 1;
         edtavChitemsinventarioid_Jsonclick = "";
         edtavChitemsinventarioid_Enabled = 1;
         edtavChitemsinventarioid_Visible = 1;
         edtavChitemsmedidasid_Jsonclick = "";
         edtavChitemsmedidasid_Enabled = 1;
         edtavChitemsmedidasid_Visible = 1;
         edtavChitemsrubrosnombre_Jsonclick = "";
         edtavChitemsrubrosnombre_Enabled = 1;
         edtavChitemsrubrosnombre_Visible = 1;
         edtavChitemsrubrosid_Jsonclick = "";
         edtavChitemsrubrosid_Enabled = 1;
         edtavChitemsrubrosid_Visible = 1;
         edtavChistoricosolicitudesitemsid_Jsonclick = "";
         edtavChistoricosolicitudesitemsid_Enabled = 1;
         edtavChistoricosolicitudesitemsid_Visible = 1;
         divHitemsinventarionombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divHitemsinventarioidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divHitemsmedidasidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divHitemsrubrosnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divHitemsrubrosidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divHistoricosolicitudesitemsidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Items", "");
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHistoricoSolicitudesItemsID',fld:'vCHISTORICOSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV7cHItemsRubrosId',fld:'vCHITEMSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cHItemsRubrosNombre',fld:'vCHITEMSRUBROSNOMBRE',pic:'',type:'char'},{av:'AV9cHItemsMedidasID',fld:'vCHITEMSMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cHItemsInventarioId',fld:'vCHITEMSINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cHItemsInventarioNombre',fld:'vCHITEMSINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pHistoricoSolicitudesID',fld:'vPHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E179J1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLHISTORICOSOLICITUDESITEMSIDFILTER.CLICK","{handler:'E119J1',iparms:[{av:'divHistoricosolicitudesitemsidfiltercontainer_Class',ctrl:'HISTORICOSOLICITUDESITEMSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHISTORICOSOLICITUDESITEMSIDFILTER.CLICK",",oparms:[{av:'divHistoricosolicitudesitemsidfiltercontainer_Class',ctrl:'HISTORICOSOLICITUDESITEMSIDFILTERCONTAINER',prop:'Class'},{av:'edtavChistoricosolicitudesitemsid_Visible',ctrl:'vCHISTORICOSOLICITUDESITEMSID',prop:'Visible'}]}");
         setEventMetadata("LBLHITEMSRUBROSIDFILTER.CLICK","{handler:'E129J1',iparms:[{av:'divHitemsrubrosidfiltercontainer_Class',ctrl:'HITEMSRUBROSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHITEMSRUBROSIDFILTER.CLICK",",oparms:[{av:'divHitemsrubrosidfiltercontainer_Class',ctrl:'HITEMSRUBROSIDFILTERCONTAINER',prop:'Class'},{av:'edtavChitemsrubrosid_Visible',ctrl:'vCHITEMSRUBROSID',prop:'Visible'}]}");
         setEventMetadata("LBLHITEMSRUBROSNOMBREFILTER.CLICK","{handler:'E139J1',iparms:[{av:'divHitemsrubrosnombrefiltercontainer_Class',ctrl:'HITEMSRUBROSNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHITEMSRUBROSNOMBREFILTER.CLICK",",oparms:[{av:'divHitemsrubrosnombrefiltercontainer_Class',ctrl:'HITEMSRUBROSNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavChitemsrubrosnombre_Visible',ctrl:'vCHITEMSRUBROSNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLHITEMSMEDIDASIDFILTER.CLICK","{handler:'E149J1',iparms:[{av:'divHitemsmedidasidfiltercontainer_Class',ctrl:'HITEMSMEDIDASIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHITEMSMEDIDASIDFILTER.CLICK",",oparms:[{av:'divHitemsmedidasidfiltercontainer_Class',ctrl:'HITEMSMEDIDASIDFILTERCONTAINER',prop:'Class'},{av:'edtavChitemsmedidasid_Visible',ctrl:'vCHITEMSMEDIDASID',prop:'Visible'}]}");
         setEventMetadata("LBLHITEMSINVENTARIOIDFILTER.CLICK","{handler:'E159J1',iparms:[{av:'divHitemsinventarioidfiltercontainer_Class',ctrl:'HITEMSINVENTARIOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHITEMSINVENTARIOIDFILTER.CLICK",",oparms:[{av:'divHitemsinventarioidfiltercontainer_Class',ctrl:'HITEMSINVENTARIOIDFILTERCONTAINER',prop:'Class'},{av:'edtavChitemsinventarioid_Visible',ctrl:'vCHITEMSINVENTARIOID',prop:'Visible'}]}");
         setEventMetadata("LBLHITEMSINVENTARIONOMBREFILTER.CLICK","{handler:'E169J1',iparms:[{av:'divHitemsinventarionombrefiltercontainer_Class',ctrl:'HITEMSINVENTARIONOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHITEMSINVENTARIONOMBREFILTER.CLICK",",oparms:[{av:'divHitemsinventarionombrefiltercontainer_Class',ctrl:'HITEMSINVENTARIONOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavChitemsinventarionombre_Visible',ctrl:'vCHITEMSINVENTARIONOMBRE',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E209J2',iparms:[{av:'A154HistoricoSolicitudesItemsID',fld:'HISTORICOSOLICITUDESITEMSID',pic:'ZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pHistoricoSolicitudesItemsID',fld:'vPHISTORICOSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHistoricoSolicitudesItemsID',fld:'vCHISTORICOSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV7cHItemsRubrosId',fld:'vCHITEMSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cHItemsRubrosNombre',fld:'vCHITEMSRUBROSNOMBRE',pic:'',type:'char'},{av:'AV9cHItemsMedidasID',fld:'vCHITEMSMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cHItemsInventarioId',fld:'vCHITEMSINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cHItemsInventarioNombre',fld:'vCHITEMSINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pHistoricoSolicitudesID',fld:'vPHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHistoricoSolicitudesItemsID',fld:'vCHISTORICOSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV7cHItemsRubrosId',fld:'vCHITEMSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cHItemsRubrosNombre',fld:'vCHITEMSRUBROSNOMBRE',pic:'',type:'char'},{av:'AV9cHItemsMedidasID',fld:'vCHITEMSMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cHItemsInventarioId',fld:'vCHITEMSINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cHItemsInventarioNombre',fld:'vCHITEMSINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pHistoricoSolicitudesID',fld:'vPHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHistoricoSolicitudesItemsID',fld:'vCHISTORICOSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV7cHItemsRubrosId',fld:'vCHITEMSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cHItemsRubrosNombre',fld:'vCHITEMSRUBROSNOMBRE',pic:'',type:'char'},{av:'AV9cHItemsMedidasID',fld:'vCHITEMSMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cHItemsInventarioId',fld:'vCHITEMSINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cHItemsInventarioNombre',fld:'vCHITEMSINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pHistoricoSolicitudesID',fld:'vPHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHistoricoSolicitudesItemsID',fld:'vCHISTORICOSOLICITUDESITEMSID',pic:'ZZZ9',type:'int'},{av:'AV7cHItemsRubrosId',fld:'vCHITEMSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cHItemsRubrosNombre',fld:'vCHITEMSRUBROSNOMBRE',pic:'',type:'char'},{av:'AV9cHItemsMedidasID',fld:'vCHITEMSMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cHItemsInventarioId',fld:'vCHITEMSINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11cHItemsInventarioNombre',fld:'vCHITEMSINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pHistoricoSolicitudesID',fld:'vPHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Historicosolicitudesid',iparms:[]");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV8cHItemsRubrosNombre = "";
         AV11cHItemsInventarioNombre = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblhistoricosolicitudesitemsidfilter_Jsonclick = "";
         TempTags = "";
         lblLblhitemsrubrosidfilter_Jsonclick = "";
         lblLblhitemsrubrosnombrefilter_Jsonclick = "";
         lblLblhitemsmedidasidfilter_Jsonclick = "";
         lblLblhitemsinventarioidfilter_Jsonclick = "";
         lblLblhitemsinventarionombrefilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV15Linkselection_GXI = "";
         lV8cHItemsRubrosNombre = "";
         lV11cHItemsInventarioNombre = "";
         A331HItemsRubrosNombre = "";
         A329HItemsInventarioNombre = "";
         H009J2_A329HItemsInventarioNombre = new string[] {""} ;
         H009J2_A331HItemsRubrosNombre = new string[] {""} ;
         H009J2_A153HistoricoSolicitudesID = new long[1] ;
         H009J2_A295HItemsInventarioPrecioFinal = new short[1] ;
         H009J2_A328HItemsInventarioId = new long[1] ;
         H009J2_A327HItemsMedidasID = new long[1] ;
         H009J2_A330HItemsRubrosId = new long[1] ;
         H009J2_A154HistoricoSolicitudesItemsID = new short[1] ;
         H009J3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0171__default(),
            new Object[][] {
                new Object[] {
               H009J2_A329HItemsInventarioNombre, H009J2_A331HItemsRubrosNombre, H009J2_A153HistoricoSolicitudesID, H009J2_A295HItemsInventarioPrecioFinal, H009J2_A328HItemsInventarioId, H009J2_A327HItemsMedidasID, H009J2_A330HItemsRubrosId, H009J2_A154HistoricoSolicitudesItemsID
               }
               , new Object[] {
               H009J3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13pHistoricoSolicitudesItemsID ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cHistoricoSolicitudesItemsID ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A154HistoricoSolicitudesItemsID ;
      private short A295HItemsInventarioPrecioFinal ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavChistoricosolicitudesitemsid_Enabled ;
      private int edtavChistoricosolicitudesitemsid_Visible ;
      private int edtavChitemsrubrosid_Enabled ;
      private int edtavChitemsrubrosid_Visible ;
      private int edtavChitemsrubrosnombre_Visible ;
      private int edtavChitemsrubrosnombre_Enabled ;
      private int edtavChitemsmedidasid_Enabled ;
      private int edtavChitemsmedidasid_Visible ;
      private int edtavChitemsinventarioid_Enabled ;
      private int edtavChitemsinventarioid_Visible ;
      private int edtavChitemsinventarionombre_Visible ;
      private int edtavChitemsinventarionombre_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtHistoricoSolicitudesItemsID_Enabled ;
      private int edtHItemsRubrosId_Enabled ;
      private int edtHItemsMedidasID_Enabled ;
      private int edtHItemsInventarioId_Enabled ;
      private int edtHItemsInventarioPrecioFinal_Enabled ;
      private int edtHistoricoSolicitudesID_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pHistoricoSolicitudesID ;
      private long wcpOAV12pHistoricoSolicitudesID ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV7cHItemsRubrosId ;
      private long AV9cHItemsMedidasID ;
      private long AV10cHItemsInventarioId ;
      private long A330HItemsRubrosId ;
      private long A327HItemsMedidasID ;
      private long A328HItemsInventarioId ;
      private long A153HistoricoSolicitudesID ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divHistoricosolicitudesitemsidfiltercontainer_Class ;
      private string divHitemsrubrosidfiltercontainer_Class ;
      private string divHitemsrubrosnombrefiltercontainer_Class ;
      private string divHitemsmedidasidfiltercontainer_Class ;
      private string divHitemsinventarioidfiltercontainer_Class ;
      private string divHitemsinventarionombrefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV8cHItemsRubrosNombre ;
      private string AV11cHItemsInventarioNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divHistoricosolicitudesitemsidfiltercontainer_Internalname ;
      private string lblLblhistoricosolicitudesitemsidfilter_Internalname ;
      private string lblLblhistoricosolicitudesitemsidfilter_Jsonclick ;
      private string edtavChistoricosolicitudesitemsid_Internalname ;
      private string TempTags ;
      private string edtavChistoricosolicitudesitemsid_Jsonclick ;
      private string divHitemsrubrosidfiltercontainer_Internalname ;
      private string lblLblhitemsrubrosidfilter_Internalname ;
      private string lblLblhitemsrubrosidfilter_Jsonclick ;
      private string edtavChitemsrubrosid_Internalname ;
      private string edtavChitemsrubrosid_Jsonclick ;
      private string divHitemsrubrosnombrefiltercontainer_Internalname ;
      private string lblLblhitemsrubrosnombrefilter_Internalname ;
      private string lblLblhitemsrubrosnombrefilter_Jsonclick ;
      private string edtavChitemsrubrosnombre_Internalname ;
      private string edtavChitemsrubrosnombre_Jsonclick ;
      private string divHitemsmedidasidfiltercontainer_Internalname ;
      private string lblLblhitemsmedidasidfilter_Internalname ;
      private string lblLblhitemsmedidasidfilter_Jsonclick ;
      private string edtavChitemsmedidasid_Internalname ;
      private string edtavChitemsmedidasid_Jsonclick ;
      private string divHitemsinventarioidfiltercontainer_Internalname ;
      private string lblLblhitemsinventarioidfilter_Internalname ;
      private string lblLblhitemsinventarioidfilter_Jsonclick ;
      private string edtavChitemsinventarioid_Internalname ;
      private string edtavChitemsinventarioid_Jsonclick ;
      private string divHitemsinventarionombrefiltercontainer_Internalname ;
      private string lblLblhitemsinventarionombrefilter_Internalname ;
      private string lblLblhitemsinventarionombrefilter_Jsonclick ;
      private string edtavChitemsinventarionombre_Internalname ;
      private string edtavChitemsinventarionombre_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtHistoricoSolicitudesItemsID_Internalname ;
      private string edtHItemsRubrosId_Internalname ;
      private string edtHItemsMedidasID_Internalname ;
      private string edtHItemsInventarioId_Internalname ;
      private string edtHItemsInventarioPrecioFinal_Internalname ;
      private string edtHistoricoSolicitudesID_Internalname ;
      private string lV8cHItemsRubrosNombre ;
      private string lV11cHItemsInventarioNombre ;
      private string A331HItemsRubrosNombre ;
      private string A329HItemsInventarioNombre ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtHistoricoSolicitudesItemsID_Jsonclick ;
      private string edtHItemsRubrosId_Link ;
      private string edtHItemsRubrosId_Jsonclick ;
      private string edtHItemsMedidasID_Jsonclick ;
      private string edtHItemsInventarioId_Jsonclick ;
      private string edtHItemsInventarioPrecioFinal_Jsonclick ;
      private string edtHistoricoSolicitudesID_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV15Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H009J2_A329HItemsInventarioNombre ;
      private string[] H009J2_A331HItemsRubrosNombre ;
      private long[] H009J2_A153HistoricoSolicitudesID ;
      private short[] H009J2_A295HItemsInventarioPrecioFinal ;
      private long[] H009J2_A328HItemsInventarioId ;
      private long[] H009J2_A327HItemsMedidasID ;
      private long[] H009J2_A330HItemsRubrosId ;
      private short[] H009J2_A154HistoricoSolicitudesItemsID ;
      private long[] H009J3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP1_pHistoricoSolicitudesItemsID ;
   }

   public class gx0171__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009J2( IGxContext context ,
                                             long AV7cHItemsRubrosId ,
                                             string AV8cHItemsRubrosNombre ,
                                             long AV9cHItemsMedidasID ,
                                             long AV10cHItemsInventarioId ,
                                             string AV11cHItemsInventarioNombre ,
                                             long A330HItemsRubrosId ,
                                             string A331HItemsRubrosNombre ,
                                             long A327HItemsMedidasID ,
                                             long A328HItemsInventarioId ,
                                             string A329HItemsInventarioNombre ,
                                             long AV12pHistoricoSolicitudesID ,
                                             short AV6cHistoricoSolicitudesItemsID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [HItemsInventarioNombre], [HItemsRubrosNombre], [HistoricoSolicitudesID], [HItemsInventarioPrecioFinal], [HItemsInventarioId], [HItemsMedidasID], [HItemsRubrosId], [HistoricoSolicitudesItemsID]";
         sFromString = " FROM [HistoricoSolicitudesItems]";
         sOrderString = "";
         AddWhere(sWhereString, "([HistoricoSolicitudesID] = @AV12pHistoricoSolicitudesID and [HistoricoSolicitudesItemsID] >= @AV6cHistoricoSolicitudesItemsID)");
         if ( ! (0==AV7cHItemsRubrosId) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] >= @AV7cHItemsRubrosId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cHItemsRubrosNombre)) )
         {
            AddWhere(sWhereString, "([HItemsRubrosNombre] like @lV8cHItemsRubrosNombre)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV9cHItemsMedidasID) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] >= @AV9cHItemsMedidasID)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV10cHItemsInventarioId) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] >= @AV10cHItemsInventarioId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cHItemsInventarioNombre)) )
         {
            AddWhere(sWhereString, "([HItemsInventarioNombre] like @lV11cHItemsInventarioNombre)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [HistoricoSolicitudesID], [HistoricoSolicitudesItemsID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H009J3( IGxContext context ,
                                             long AV7cHItemsRubrosId ,
                                             string AV8cHItemsRubrosNombre ,
                                             long AV9cHItemsMedidasID ,
                                             long AV10cHItemsInventarioId ,
                                             string AV11cHItemsInventarioNombre ,
                                             long A330HItemsRubrosId ,
                                             string A331HItemsRubrosNombre ,
                                             long A327HItemsMedidasID ,
                                             long A328HItemsInventarioId ,
                                             string A329HItemsInventarioNombre ,
                                             long AV12pHistoricoSolicitudesID ,
                                             short AV6cHistoricoSolicitudesItemsID ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [HistoricoSolicitudesItems]";
         AddWhere(sWhereString, "([HistoricoSolicitudesID] = @AV12pHistoricoSolicitudesID and [HistoricoSolicitudesItemsID] >= @AV6cHistoricoSolicitudesItemsID)");
         if ( ! (0==AV7cHItemsRubrosId) )
         {
            AddWhere(sWhereString, "([HItemsRubrosId] >= @AV7cHItemsRubrosId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cHItemsRubrosNombre)) )
         {
            AddWhere(sWhereString, "([HItemsRubrosNombre] like @lV8cHItemsRubrosNombre)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV9cHItemsMedidasID) )
         {
            AddWhere(sWhereString, "([HItemsMedidasID] >= @AV9cHItemsMedidasID)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV10cHItemsInventarioId) )
         {
            AddWhere(sWhereString, "([HItemsInventarioId] >= @AV10cHItemsInventarioId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cHItemsInventarioNombre)) )
         {
            AddWhere(sWhereString, "([HItemsInventarioNombre] like @lV11cHItemsInventarioNombre)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H009J2(context, (long)dynConstraints[0] , (string)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H009J3(context, (long)dynConstraints[0] , (string)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (long)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH009J2;
          prmH009J2 = new Object[] {
          new ParDef("@AV12pHistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV6cHistoricoSolicitudesItemsID",GXType.Int16,4,0) ,
          new ParDef("@AV7cHItemsRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@lV8cHItemsRubrosNombre",GXType.NChar,100,0) ,
          new ParDef("@AV9cHItemsMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV10cHItemsInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@lV11cHItemsInventarioNombre",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009J3;
          prmH009J3 = new Object[] {
          new ParDef("@AV12pHistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV6cHistoricoSolicitudesItemsID",GXType.Int16,4,0) ,
          new ParDef("@AV7cHItemsRubrosId",GXType.Decimal,18,0) ,
          new ParDef("@lV8cHItemsRubrosNombre",GXType.NChar,100,0) ,
          new ParDef("@AV9cHItemsMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV10cHItemsInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@lV11cHItemsInventarioNombre",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009J2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009J3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

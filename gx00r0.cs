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
   public class gx00r0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00r0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00r0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pRubrosId ,
                           out long aP1_pMedidasID ,
                           out long aP2_pInventarioId )
      {
         this.AV13pRubrosId = 0 ;
         this.AV14pMedidasID = 0 ;
         this.AV15pInventarioId = 0 ;
         ExecutePrivate();
         aP0_pRubrosId=this.AV13pRubrosId;
         aP1_pMedidasID=this.AV14pMedidasID;
         aP2_pInventarioId=this.AV15pInventarioId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavCestadosgenericosid = new GXCombobox();
         dynEstadosGenericosId = new GXCombobox();
         dynMedidasID = new GXCombobox();
         dynInventarioId = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pRubrosId");
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
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLAMEDIDASIDD42( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"INVENTARIOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLAINVENTARIOIDD42( ) ;
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
               gxfirstwebparm = GetFirstPar( "pRubrosId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pRubrosId");
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
               AV13pRubrosId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pRubrosId", StringUtil.LTrimStr( (decimal)(AV13pRubrosId), 4, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pMedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "pMedidasID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pMedidasID", StringUtil.LTrimStr( (decimal)(AV14pMedidasID), 18, 0));
                  AV15pInventarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "pInventarioId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV15pInventarioId", StringUtil.LTrimStr( (decimal)(AV15pInventarioId), 18, 0));
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
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
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
         AV6cRubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "cRubrosId"), "."), 18, MidpointRounding.ToEven));
         AV7cMedidasNombre = GetPar( "cMedidasNombre");
         AV8cInventarioNombre = GetPar( "cInventarioNombre");
         AV9cInventarioCosto = NumberUtil.Val( GetPar( "cInventarioCosto"), ".");
         AV10cInventarioPrecioFinal = NumberUtil.Val( GetPar( "cInventarioPrecioFinal"), ".");
         AV11cEstadosTipo = GetPar( "cEstadosTipo");
         dynavCestadosgenericosid.FromJSonString( GetNextPar( ));
         AV12cEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "cEstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cRubrosId, AV7cMedidasNombre, AV8cInventarioNombre, AV9cInventarioCosto, AV10cInventarioPrecioFinal, AV11cEstadosTipo, AV12cEstadosGenericosId) ;
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
         PAD42( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTD42( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00r0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pRubrosId,4,0)),UrlEncode(StringUtil.LTrimStr(AV14pMedidasID,18,0)),UrlEncode(StringUtil.LTrimStr(AV15pInventarioId,18,0))}, new string[] {"pRubrosId","pMedidasID","pInventarioId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMEDIDASNOMBRE", StringUtil.RTrim( AV7cMedidasNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVENTARIONOMBRE", StringUtil.RTrim( AV8cInventarioNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVENTARIOCOSTO", StringUtil.LTrim( StringUtil.NToC( AV9cInventarioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVENTARIOPRECIOFINAL", StringUtil.LTrim( StringUtil.NToC( AV10cInventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOSTIPO", StringUtil.RTrim( AV11cEstadosTipo));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cEstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPMEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPINVENTARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15pInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "RUBROSIDFILTERCONTAINER_Class", StringUtil.RTrim( divRubrosidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MEDIDASNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divMedidasnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVENTARIONOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divInventarionombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVENTARIOCOSTOFILTERCONTAINER_Class", StringUtil.RTrim( divInventariocostofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVENTARIOPRECIOFINALFILTERCONTAINER_Class", StringUtil.RTrim( divInventariopreciofinalfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESTADOSTIPOFILTERCONTAINER_Class", StringUtil.RTrim( divEstadostipofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSIDFILTERCONTAINER_Class", StringUtil.RTrim( divEstadosgenericosidfiltercontainer_Class));
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
            WED42( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTD42( ) ;
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
         return formatLink("gx00r0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pRubrosId,4,0)),UrlEncode(StringUtil.LTrimStr(AV14pMedidasID,18,0)),UrlEncode(StringUtil.LTrimStr(AV15pInventarioId,18,0))}, new string[] {"pRubrosId","pMedidasID","pInventarioId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00R0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Inventario", "") ;
      }

      protected void WBD40( )
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
            GxWebStd.gx_div_start( context, divRubrosidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRubrosidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrubrosidfilter_Internalname, context.GetMessage( "Rubros Identificador ", ""), "", "", lblLblrubrosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11d41_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrubrosid_Internalname, context.GetMessage( "Rubros Identificador ", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrubrosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCrubrosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cRubrosId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cRubrosId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrubrosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrubrosid_Visible, edtavCrubrosid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_div_start( context, divMedidasnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divMedidasnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmedidasnombrefilter_Internalname, context.GetMessage( "Nombre de la Característica", ""), "", "", lblLblmedidasnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12d41_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmedidasnombre_Internalname, context.GetMessage( "Nombre de la Característica", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmedidasnombre_Internalname, StringUtil.RTrim( AV7cMedidasNombre), StringUtil.RTrim( context.localUtil.Format( AV7cMedidasNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmedidasnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmedidasnombre_Visible, edtavCmedidasnombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_div_start( context, divInventarionombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divInventarionombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinventarionombrefilter_Internalname, context.GetMessage( "Producto/Característica", ""), "", "", lblLblinventarionombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13d41_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinventarionombre_Internalname, context.GetMessage( "Producto/Característica", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinventarionombre_Internalname, StringUtil.RTrim( AV8cInventarioNombre), StringUtil.RTrim( context.localUtil.Format( AV8cInventarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinventarionombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinventarionombre_Visible, edtavCinventarionombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_div_start( context, divInventariocostofiltercontainer_Internalname, 1, 0, "px", 0, "px", divInventariocostofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinventariocostofilter_Internalname, context.GetMessage( "Costo", ""), "", "", lblLblinventariocostofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14d41_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinventariocosto_Internalname, context.GetMessage( "Costo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinventariocosto_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9cInventarioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCinventariocosto_Enabled!=0) ? context.localUtil.Format( AV9cInventarioCosto, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV9cInventarioCosto, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinventariocosto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinventariocosto_Visible, edtavCinventariocosto_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_div_start( context, divInventariopreciofinalfiltercontainer_Internalname, 1, 0, "px", 0, "px", divInventariopreciofinalfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinventariopreciofinalfilter_Internalname, context.GetMessage( "Precio", ""), "", "", lblLblinventariopreciofinalfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15d41_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinventariopreciofinal_Internalname, context.GetMessage( "Precio", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinventariopreciofinal_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cInventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCinventariopreciofinal_Enabled!=0) ? context.localUtil.Format( AV10cInventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV10cInventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, gx.thousandSeparator,gx.decimalPoint,'2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinventariopreciofinal_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinventariopreciofinal_Visible, edtavCinventariopreciofinal_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_div_start( context, divEstadostipofiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstadostipofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestadostipofilter_Internalname, context.GetMessage( "Tipo de Estados", ""), "", "", lblLblestadostipofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16d41_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCestadostipo_Internalname, context.GetMessage( "Tipo de Estados", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCestadostipo_Internalname, StringUtil.RTrim( AV11cEstadosTipo), StringUtil.RTrim( context.localUtil.Format( AV11cEstadosTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCestadostipo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCestadostipo_Visible, edtavCestadostipo_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00R0.htm");
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
            GxWebStd.gx_div_start( context, divEstadosgenericosidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstadosgenericosidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestadosgenericosidfilter_Internalname, context.GetMessage( "Identificador", ""), "", "", lblLblestadosgenericosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17d41_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCestadosgenericosid_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCestadosgenericosid, dynavCestadosgenericosid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV12cEstadosGenericosId), 5, 0)), 1, dynavCestadosgenericosid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavCestadosgenericosid.Visible, dynavCestadosgenericosid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "", true, 0, "HLP_Gx00R0.htm");
            dynavCestadosgenericosid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12cEstadosGenericosId), 5, 0));
            AssignProp("", false, dynavCestadosgenericosid_Internalname, "Values", (string)(dynavCestadosgenericosid.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18d41_client"+"'", TempTags, "", 2, "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00R0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 84 )
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

      protected void STARTD42( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Inventario", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPD40( ) ;
      }

      protected void WSD42( )
      {
         STARTD42( ) ;
         EVTD42( ) ;
      }

      protected void EVTD42( )
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
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A138MedidasNombre = cgiGet( edtMedidasNombre_Internalname);
                              A189InventarioImagen = cgiGet( edtInventarioImagen_Internalname);
                              AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40000InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
                              A190InventarioCosto = context.localUtil.CToN( cgiGet( edtInventarioCosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              A181InventarioPrecioFinal = context.localUtil.CToN( cgiGet( edtInventarioPrecioFinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
                              dynEstadosGenericosId.Name = dynEstadosGenericosId_Internalname;
                              dynEstadosGenericosId.CurrentValue = cgiGet( dynEstadosGenericosId_Internalname);
                              A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynEstadosGenericosId_Internalname), "."), 18, MidpointRounding.ToEven));
                              dynMedidasID.Name = dynMedidasID_Internalname;
                              dynMedidasID.CurrentValue = cgiGet( dynMedidasID_Internalname);
                              A137MedidasID = (long)(Math.Round(NumberUtil.Val( cgiGet( dynMedidasID_Internalname), "."), 18, MidpointRounding.ToEven));
                              dynInventarioId.Name = dynInventarioId_Internalname;
                              dynInventarioId.CurrentValue = cgiGet( dynInventarioId_Internalname);
                              A135InventarioId = (long)(Math.Round(NumberUtil.Val( cgiGet( dynInventarioId_Internalname), "."), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19D42 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20D42 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Crubrosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cRubrosId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmedidasnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMEDIDASNOMBRE"), AV7cMedidasNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinventarionombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCINVENTARIONOMBRE"), AV8cInventarioNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinventariocosto Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCINVENTARIOCOSTO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV9cInventarioCosto )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinventariopreciofinal Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCINVENTARIOPRECIOFINAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV10cInventarioPrecioFinal )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadostipo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSTIPO"), AV11cEstadosTipo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadosgenericosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESTADOSGENERICOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cEstadosGenericosId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21D42 ();
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

      protected void WED42( )
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

      protected void PAD42( )
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

      protected void GXDLVvCESTADOSGENERICOSIDD41( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCESTADOSGENERICOSID_dataD41( ) ;
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

      protected void GXVvCESTADOSGENERICOSID_htmlD41( )
      {
         int gxdynajaxvalue;
         GXDLVvCESTADOSGENERICOSID_dataD41( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCestadosgenericosid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavCestadosgenericosid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 5, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavCestadosgenericosid.ItemCount > 0 )
         {
            AV12cEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynavCestadosgenericosid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12cEstadosGenericosId), 5, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12cEstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV12cEstadosGenericosId), 5, 0));
         }
      }

      protected void GXDLVvCESTADOSGENERICOSID_dataD41( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00D42 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00D42_A108EstadosGenericosId[0]), 5, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00D42_A109EstadosGenericosNombre[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLAMEDIDASIDD42( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMEDIDASID_dataD42( ) ;
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

      protected void GXAMEDIDASID_htmlD42( )
      {
         long gxdynajaxvalue;
         GXDLAMEDIDASID_dataD42( ) ;
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

      protected void GXDLAMEDIDASID_dataD42( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H00D43 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00D43_A137MedidasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00D43_A138MedidasNombre[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLAINVENTARIOIDD42( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAINVENTARIOID_dataD42( ) ;
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

      protected void GXAINVENTARIOID_htmlD42( )
      {
         long gxdynajaxvalue;
         GXDLAINVENTARIOID_dataD42( ) ;
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

      protected void GXDLAINVENTARIOID_dataD42( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H00D44 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00D44_A135InventarioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00D44_A136InventarioNombre[0]));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cRubrosId ,
                                        string AV7cMedidasNombre ,
                                        string AV8cInventarioNombre ,
                                        decimal AV9cInventarioCosto ,
                                        decimal AV10cInventarioPrecioFinal ,
                                        string AV11cEstadosTipo ,
                                        int AV12cEstadosGenericosId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFD42( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RUBROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_MEDIDASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "MEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_INVENTARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A135InventarioId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "INVENTARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavCestadosgenericosid.Name = "vCESTADOSGENERICOSID";
            dynavCestadosgenericosid.WebTags = "";
            dynavCestadosgenericosid.removeAllItems();
            /* Using cursor H00D45 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynavCestadosgenericosid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00D45_A108EstadosGenericosId[0]), 5, 0)), H00D45_A109EstadosGenericosNombre[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynavCestadosgenericosid.ItemCount > 0 )
            {
               AV12cEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynavCestadosgenericosid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12cEstadosGenericosId), 5, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cEstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV12cEstadosGenericosId), 5, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavCestadosgenericosid.ItemCount > 0 )
         {
            AV12cEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynavCestadosgenericosid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12cEstadosGenericosId), 5, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12cEstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV12cEstadosGenericosId), 5, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCestadosgenericosid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12cEstadosGenericosId), 5, 0));
            AssignProp("", false, dynavCestadosgenericosid_Internalname, "Values", dynavCestadosgenericosid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFD42( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFD42( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
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
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV7cMedidasNombre ,
                                                 AV8cInventarioNombre ,
                                                 AV9cInventarioCosto ,
                                                 AV10cInventarioPrecioFinal ,
                                                 AV11cEstadosTipo ,
                                                 AV12cEstadosGenericosId ,
                                                 A138MedidasNombre ,
                                                 A136InventarioNombre ,
                                                 A190InventarioCosto ,
                                                 A181InventarioPrecioFinal ,
                                                 A107EstadosTipo ,
                                                 A108EstadosGenericosId ,
                                                 AV6cRubrosId } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT
                                                 }
            });
            lV7cMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV7cMedidasNombre), 50, "%");
            lV8cInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV8cInventarioNombre), 100, "%");
            lV11cEstadosTipo = StringUtil.PadR( StringUtil.RTrim( AV11cEstadosTipo), 3, "%");
            /* Using cursor H00D46 */
            pr_default.execute(4, new Object[] {AV6cRubrosId, lV7cMedidasNombre, lV8cInventarioNombre, AV9cInventarioCosto, AV10cInventarioPrecioFinal, lV11cEstadosTipo, AV12cEstadosGenericosId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(4) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A107EstadosTipo = H00D46_A107EstadosTipo[0];
               A136InventarioNombre = H00D46_A136InventarioNombre[0];
               A135InventarioId = H00D46_A135InventarioId[0];
               A137MedidasID = H00D46_A137MedidasID[0];
               A108EstadosGenericosId = H00D46_A108EstadosGenericosId[0];
               A181InventarioPrecioFinal = H00D46_A181InventarioPrecioFinal[0];
               A190InventarioCosto = H00D46_A190InventarioCosto[0];
               A40000InventarioImagen_GXI = H00D46_A40000InventarioImagen_GXI[0];
               AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40000InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
               A138MedidasNombre = H00D46_A138MedidasNombre[0];
               A121RubrosId = H00D46_A121RubrosId[0];
               A189InventarioImagen = H00D46_A189InventarioImagen[0];
               AssignProp("", false, edtInventarioImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40000InventarioImagen_GXI : context.convertURL( context.PathToRelativeUrl( A189InventarioImagen))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtInventarioImagen_Internalname, "SrcSet", context.GetImageSrcSet( A189InventarioImagen), true);
               A138MedidasNombre = H00D46_A138MedidasNombre[0];
               /* Execute user event: Load */
               E20D42 ();
               pr_default.readNext(4);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(4) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(4);
            wbEnd = 84;
            WBD40( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesD42( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RUBROSID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_MEDIDASID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A137MedidasID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INVENTARIOID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A135InventarioId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV7cMedidasNombre ,
                                              AV8cInventarioNombre ,
                                              AV9cInventarioCosto ,
                                              AV10cInventarioPrecioFinal ,
                                              AV11cEstadosTipo ,
                                              AV12cEstadosGenericosId ,
                                              A138MedidasNombre ,
                                              A136InventarioNombre ,
                                              A190InventarioCosto ,
                                              A181InventarioPrecioFinal ,
                                              A107EstadosTipo ,
                                              A108EstadosGenericosId ,
                                              AV6cRubrosId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV7cMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV7cMedidasNombre), 50, "%");
         lV8cInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV8cInventarioNombre), 100, "%");
         lV11cEstadosTipo = StringUtil.PadR( StringUtil.RTrim( AV11cEstadosTipo), 3, "%");
         /* Using cursor H00D47 */
         pr_default.execute(5, new Object[] {AV6cRubrosId, lV7cMedidasNombre, lV8cInventarioNombre, AV9cInventarioCosto, AV10cInventarioPrecioFinal, lV11cEstadosTipo, AV12cEstadosGenericosId});
         GRID1_nRecordCount = H00D47_AGRID1_nRecordCount[0];
         pr_default.close(5);
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRubrosId, AV7cMedidasNombre, AV8cInventarioNombre, AV9cInventarioCosto, AV10cInventarioPrecioFinal, AV11cEstadosTipo, AV12cEstadosGenericosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRubrosId, AV7cMedidasNombre, AV8cInventarioNombre, AV9cInventarioCosto, AV10cInventarioPrecioFinal, AV11cEstadosTipo, AV12cEstadosGenericosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRubrosId, AV7cMedidasNombre, AV8cInventarioNombre, AV9cInventarioCosto, AV10cInventarioPrecioFinal, AV11cEstadosTipo, AV12cEstadosGenericosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRubrosId, AV7cMedidasNombre, AV8cInventarioNombre, AV9cInventarioCosto, AV10cInventarioPrecioFinal, AV11cEstadosTipo, AV12cEstadosGenericosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cRubrosId, AV7cMedidasNombre, AV8cInventarioNombre, AV9cInventarioCosto, AV10cInventarioPrecioFinal, AV11cEstadosTipo, AV12cEstadosGenericosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         GXAMEDIDASID_htmlD42( ) ;
         GXAINVENTARIOID_htmlD42( ) ;
         edtRubrosId_Enabled = 0;
         edtMedidasNombre_Enabled = 0;
         edtInventarioImagen_Enabled = 0;
         edtInventarioCosto_Enabled = 0;
         edtInventarioPrecioFinal_Enabled = 0;
         dynEstadosGenericosId.Enabled = 0;
         dynMedidasID.Enabled = 0;
         dynInventarioId.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPD40( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19D42 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRUBROSID");
               GX_FocusControl = edtavCrubrosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cRubrosId = 0;
               AssignAttri("", false, "AV6cRubrosId", StringUtil.LTrimStr( (decimal)(AV6cRubrosId), 4, 0));
            }
            else
            {
               AV6cRubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cRubrosId", StringUtil.LTrimStr( (decimal)(AV6cRubrosId), 4, 0));
            }
            AV7cMedidasNombre = cgiGet( edtavCmedidasnombre_Internalname);
            AssignAttri("", false, "AV7cMedidasNombre", AV7cMedidasNombre);
            AV8cInventarioNombre = cgiGet( edtavCinventarionombre_Internalname);
            AssignAttri("", false, "AV8cInventarioNombre", AV8cInventarioNombre);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinventariocosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinventariocosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVENTARIOCOSTO");
               GX_FocusControl = edtavCinventariocosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cInventarioCosto = 0;
               AssignAttri("", false, "AV9cInventarioCosto", StringUtil.LTrimStr( AV9cInventarioCosto, 18, 2));
            }
            else
            {
               AV9cInventarioCosto = context.localUtil.CToN( cgiGet( edtavCinventariocosto_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV9cInventarioCosto", StringUtil.LTrimStr( AV9cInventarioCosto, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinventariopreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinventariopreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVENTARIOPRECIOFINAL");
               GX_FocusControl = edtavCinventariopreciofinal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cInventarioPrecioFinal = 0;
               AssignAttri("", false, "AV10cInventarioPrecioFinal", StringUtil.LTrimStr( AV10cInventarioPrecioFinal, 18, 2));
            }
            else
            {
               AV10cInventarioPrecioFinal = context.localUtil.CToN( cgiGet( edtavCinventariopreciofinal_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep"));
               AssignAttri("", false, "AV10cInventarioPrecioFinal", StringUtil.LTrimStr( AV10cInventarioPrecioFinal, 18, 2));
            }
            AV11cEstadosTipo = cgiGet( edtavCestadostipo_Internalname);
            AssignAttri("", false, "AV11cEstadosTipo", AV11cEstadosTipo);
            dynavCestadosgenericosid.Name = dynavCestadosgenericosid_Internalname;
            dynavCestadosgenericosid.CurrentValue = cgiGet( dynavCestadosgenericosid_Internalname);
            AV12cEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavCestadosgenericosid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12cEstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV12cEstadosGenericosId), 5, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cRubrosId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMEDIDASNOMBRE"), AV7cMedidasNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCINVENTARIONOMBRE"), AV8cInventarioNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCINVENTARIOCOSTO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV9cInventarioCosto )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCINVENTARIOPRECIOFINAL"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != AV10cInventarioPrecioFinal )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSTIPO"), AV11cEstadosTipo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESTADOSGENERICOSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV12cEstadosGenericosId )) )
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
         E19D42 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19D42( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Inventario", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV16ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E20D42( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E21D42 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21D42( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pRubrosId = A121RubrosId;
         AssignAttri("", false, "AV13pRubrosId", StringUtil.LTrimStr( (decimal)(AV13pRubrosId), 4, 0));
         AV14pMedidasID = A137MedidasID;
         AssignAttri("", false, "AV14pMedidasID", StringUtil.LTrimStr( (decimal)(AV14pMedidasID), 18, 0));
         AV15pInventarioId = A135InventarioId;
         AssignAttri("", false, "AV15pInventarioId", StringUtil.LTrimStr( (decimal)(AV15pInventarioId), 18, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pRubrosId,(long)AV14pMedidasID,(long)AV15pInventarioId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pRubrosId","AV14pMedidasID","AV15pInventarioId"});
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
         AV13pRubrosId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV13pRubrosId", StringUtil.LTrimStr( (decimal)(AV13pRubrosId), 4, 0));
         AV14pMedidasID = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV14pMedidasID", StringUtil.LTrimStr( (decimal)(AV14pMedidasID), 18, 0));
         AV15pInventarioId = Convert.ToInt64(getParm(obj,2));
         AssignAttri("", false, "AV15pInventarioId", StringUtil.LTrimStr( (decimal)(AV15pInventarioId), 18, 0));
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
         PAD42( ) ;
         WSD42( ) ;
         WED42( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202693200312", true, true, false);
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
         context.AddJavascriptSource("gx00r0.js", "?202693200312", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_84_idx;
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE_"+sGXsfl_84_idx;
         edtInventarioImagen_Internalname = "INVENTARIOIMAGEN_"+sGXsfl_84_idx;
         edtInventarioCosto_Internalname = "INVENTARIOCOSTO_"+sGXsfl_84_idx;
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL_"+sGXsfl_84_idx;
         dynEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_84_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_84_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_84_fel_idx;
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE_"+sGXsfl_84_fel_idx;
         edtInventarioImagen_Internalname = "INVENTARIOIMAGEN_"+sGXsfl_84_fel_idx;
         edtInventarioCosto_Internalname = "INVENTARIOCOSTO_"+sGXsfl_84_fel_idx;
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL_"+sGXsfl_84_fel_idx;
         dynEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_84_fel_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_84_fel_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WBD40( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidasNombre_Internalname,StringUtil.RTrim( A138MedidasNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidasNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A189InventarioImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000InventarioImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A189InventarioImagen)) ? A40000InventarioImagen_GXI : context.PathToRelativeUrl( A189InventarioImagen));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioImagen_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A189InventarioImagen_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioCosto_Internalname,StringUtil.LTrim( StringUtil.NToC( A190InventarioCosto, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A190InventarioCosto, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioCosto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInventarioPrecioFinal_Internalname,StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( A181InventarioPrecioFinal, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInventarioPrecioFinal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( dynEstadosGenericosId.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "ESTADOSGENERICOSID_" + sGXsfl_84_idx;
               dynEstadosGenericosId.Name = GXCCtl;
               dynEstadosGenericosId.WebTags = "";
               dynEstadosGenericosId.removeAllItems();
               /* Using cursor H00D48 */
               pr_default.execute(6);
               while ( (pr_default.getStatus(6) != 101) )
               {
                  dynEstadosGenericosId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00D48_A108EstadosGenericosId[0]), 5, 0)), H00D48_A109EstadosGenericosNombre[0], 0);
                  pr_default.readNext(6);
               }
               pr_default.close(6);
               if ( dynEstadosGenericosId.ItemCount > 0 )
               {
                  A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0))), "."), 18, MidpointRounding.ToEven));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynEstadosGenericosId,(string)dynEstadosGenericosId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0)),(short)1,(string)dynEstadosGenericosId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynEstadosGenericosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
            AssignProp("", false, dynEstadosGenericosId_Internalname, "Values", (string)(dynEstadosGenericosId.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            GXAMEDIDASID_htmlD42( ) ;
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( dynMedidasID.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MEDIDASID_" + sGXsfl_84_idx;
               dynMedidasID.Name = GXCCtl;
               dynMedidasID.WebTags = "";
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynMedidasID,(string)dynMedidasID_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)),(short)1,(string)dynMedidasID_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
            AssignProp("", false, dynMedidasID_Internalname, "Values", (string)(dynMedidasID.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            GXAINVENTARIOID_htmlD42( ) ;
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( dynInventarioId.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "INVENTARIOID_" + sGXsfl_84_idx;
               dynInventarioId.Name = GXCCtl;
               dynInventarioId.WebTags = "";
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynInventarioId,(string)dynInventarioId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0)),(short)1,(string)dynInventarioId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
            AssignProp("", false, dynInventarioId_Internalname, "Values", (string)(dynInventarioId.ToJavascriptSource()), !bGXsfl_84_Refreshing);
            send_integrity_lvl_hashesD42( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         dynavCestadosgenericosid.Name = "vCESTADOSGENERICOSID";
         dynavCestadosgenericosid.WebTags = "";
         dynavCestadosgenericosid.removeAllItems();
         /* Using cursor H00D49 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            dynavCestadosgenericosid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00D49_A108EstadosGenericosId[0]), 5, 0)), H00D49_A109EstadosGenericosNombre[0], 0);
            pr_default.readNext(7);
         }
         pr_default.close(7);
         if ( dynavCestadosgenericosid.ItemCount > 0 )
         {
            AV12cEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynavCestadosgenericosid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12cEstadosGenericosId), 5, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12cEstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV12cEstadosGenericosId), 5, 0));
         }
         GXCCtl = "ESTADOSGENERICOSID_" + sGXsfl_84_idx;
         dynEstadosGenericosId.Name = GXCCtl;
         dynEstadosGenericosId.WebTags = "";
         dynEstadosGenericosId.removeAllItems();
         /* Using cursor H00D410 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            dynEstadosGenericosId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00D410_A108EstadosGenericosId[0]), 5, 0)), H00D410_A109EstadosGenericosNombre[0], 0);
            pr_default.readNext(8);
         }
         pr_default.close(8);
         if ( dynEstadosGenericosId.ItemCount > 0 )
         {
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0))), "."), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "MEDIDASID_" + sGXsfl_84_idx;
         dynMedidasID.Name = GXCCtl;
         dynMedidasID.WebTags = "";
         GXCCtl = "INVENTARIOID_" + sGXsfl_84_idx;
         dynInventarioId.Name = GXCCtl;
         dynInventarioId.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
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
            context.SendWebValue( context.GetMessage( "Rubros Identificador ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre de la Característica", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Costo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Precio Armado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Items/Característica", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Detalle", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A138MedidasNombre)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A189InventarioImagen));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A190InventarioCosto, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A181InventarioPrecioFinal, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A137MedidasID), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A135InventarioId), 18, 0, ".", ""))));
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
         lblLblrubrosidfilter_Internalname = "LBLRUBROSIDFILTER";
         edtavCrubrosid_Internalname = "vCRUBROSID";
         divRubrosidfiltercontainer_Internalname = "RUBROSIDFILTERCONTAINER";
         lblLblmedidasnombrefilter_Internalname = "LBLMEDIDASNOMBREFILTER";
         edtavCmedidasnombre_Internalname = "vCMEDIDASNOMBRE";
         divMedidasnombrefiltercontainer_Internalname = "MEDIDASNOMBREFILTERCONTAINER";
         lblLblinventarionombrefilter_Internalname = "LBLINVENTARIONOMBREFILTER";
         edtavCinventarionombre_Internalname = "vCINVENTARIONOMBRE";
         divInventarionombrefiltercontainer_Internalname = "INVENTARIONOMBREFILTERCONTAINER";
         lblLblinventariocostofilter_Internalname = "LBLINVENTARIOCOSTOFILTER";
         edtavCinventariocosto_Internalname = "vCINVENTARIOCOSTO";
         divInventariocostofiltercontainer_Internalname = "INVENTARIOCOSTOFILTERCONTAINER";
         lblLblinventariopreciofinalfilter_Internalname = "LBLINVENTARIOPRECIOFINALFILTER";
         edtavCinventariopreciofinal_Internalname = "vCINVENTARIOPRECIOFINAL";
         divInventariopreciofinalfiltercontainer_Internalname = "INVENTARIOPRECIOFINALFILTERCONTAINER";
         lblLblestadostipofilter_Internalname = "LBLESTADOSTIPOFILTER";
         edtavCestadostipo_Internalname = "vCESTADOSTIPO";
         divEstadostipofiltercontainer_Internalname = "ESTADOSTIPOFILTERCONTAINER";
         lblLblestadosgenericosidfilter_Internalname = "LBLESTADOSGENERICOSIDFILTER";
         dynavCestadosgenericosid_Internalname = "vCESTADOSGENERICOSID";
         divEstadosgenericosidfiltercontainer_Internalname = "ESTADOSGENERICOSIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtRubrosId_Internalname = "RUBROSID";
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE";
         edtInventarioImagen_Internalname = "INVENTARIOIMAGEN";
         edtInventarioCosto_Internalname = "INVENTARIOCOSTO";
         edtInventarioPrecioFinal_Internalname = "INVENTARIOPRECIOFINAL";
         dynEstadosGenericosId_Internalname = "ESTADOSGENERICOSID";
         dynMedidasID_Internalname = "MEDIDASID";
         dynInventarioId_Internalname = "INVENTARIOID";
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
         dynInventarioId_Jsonclick = "";
         dynMedidasID_Jsonclick = "";
         dynEstadosGenericosId_Jsonclick = "";
         edtInventarioPrecioFinal_Jsonclick = "";
         edtInventarioCosto_Jsonclick = "";
         edtMedidasNombre_Jsonclick = "";
         edtRubrosId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         dynInventarioId.Enabled = 0;
         dynMedidasID.Enabled = 0;
         dynEstadosGenericosId.Enabled = 0;
         edtInventarioPrecioFinal_Enabled = 0;
         edtInventarioCosto_Enabled = 0;
         edtInventarioImagen_Enabled = 0;
         edtMedidasNombre_Enabled = 0;
         edtRubrosId_Enabled = 0;
         dynavCestadosgenericosid_Jsonclick = "";
         dynavCestadosgenericosid.Visible = 1;
         dynavCestadosgenericosid.Enabled = 1;
         edtavCestadostipo_Jsonclick = "";
         edtavCestadostipo_Enabled = 1;
         edtavCestadostipo_Visible = 1;
         edtavCinventariopreciofinal_Jsonclick = "";
         edtavCinventariopreciofinal_Enabled = 1;
         edtavCinventariopreciofinal_Visible = 1;
         edtavCinventariocosto_Jsonclick = "";
         edtavCinventariocosto_Enabled = 1;
         edtavCinventariocosto_Visible = 1;
         edtavCinventarionombre_Jsonclick = "";
         edtavCinventarionombre_Enabled = 1;
         edtavCinventarionombre_Visible = 1;
         edtavCmedidasnombre_Jsonclick = "";
         edtavCmedidasnombre_Enabled = 1;
         edtavCmedidasnombre_Visible = 1;
         edtavCrubrosid_Jsonclick = "";
         edtavCrubrosid_Enabled = 1;
         edtavCrubrosid_Visible = 1;
         divEstadosgenericosidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divEstadostipofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divInventariopreciofinalfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divInventariocostofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divInventarionombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMedidasnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divRubrosidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Inventario", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV7cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV8cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV9cInventarioCosto',fld:'vCINVENTARIOCOSTO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV10cInventarioPrecioFinal',fld:'vCINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cEstadosTipo',fld:'vCESTADOSTIPO',pic:'',type:'char'},{av:'dynavCestadosgenericosid'},{av:'AV12cEstadosGenericosId',fld:'vCESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18D41',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLRUBROSIDFILTER.CLICK","{handler:'E11D41',iparms:[{av:'divRubrosidfiltercontainer_Class',ctrl:'RUBROSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRUBROSIDFILTER.CLICK",",oparms:[{av:'divRubrosidfiltercontainer_Class',ctrl:'RUBROSIDFILTERCONTAINER',prop:'Class'},{av:'edtavCrubrosid_Visible',ctrl:'vCRUBROSID',prop:'Visible'}]}");
         setEventMetadata("LBLMEDIDASNOMBREFILTER.CLICK","{handler:'E12D41',iparms:[{av:'divMedidasnombrefiltercontainer_Class',ctrl:'MEDIDASNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMEDIDASNOMBREFILTER.CLICK",",oparms:[{av:'divMedidasnombrefiltercontainer_Class',ctrl:'MEDIDASNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCmedidasnombre_Visible',ctrl:'vCMEDIDASNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLINVENTARIONOMBREFILTER.CLICK","{handler:'E13D41',iparms:[{av:'divInventarionombrefiltercontainer_Class',ctrl:'INVENTARIONOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVENTARIONOMBREFILTER.CLICK",",oparms:[{av:'divInventarionombrefiltercontainer_Class',ctrl:'INVENTARIONOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCinventarionombre_Visible',ctrl:'vCINVENTARIONOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLINVENTARIOCOSTOFILTER.CLICK","{handler:'E14D41',iparms:[{av:'divInventariocostofiltercontainer_Class',ctrl:'INVENTARIOCOSTOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVENTARIOCOSTOFILTER.CLICK",",oparms:[{av:'divInventariocostofiltercontainer_Class',ctrl:'INVENTARIOCOSTOFILTERCONTAINER',prop:'Class'},{av:'edtavCinventariocosto_Visible',ctrl:'vCINVENTARIOCOSTO',prop:'Visible'}]}");
         setEventMetadata("LBLINVENTARIOPRECIOFINALFILTER.CLICK","{handler:'E15D41',iparms:[{av:'divInventariopreciofinalfiltercontainer_Class',ctrl:'INVENTARIOPRECIOFINALFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVENTARIOPRECIOFINALFILTER.CLICK",",oparms:[{av:'divInventariopreciofinalfiltercontainer_Class',ctrl:'INVENTARIOPRECIOFINALFILTERCONTAINER',prop:'Class'},{av:'edtavCinventariopreciofinal_Visible',ctrl:'vCINVENTARIOPRECIOFINAL',prop:'Visible'}]}");
         setEventMetadata("LBLESTADOSTIPOFILTER.CLICK","{handler:'E16D41',iparms:[{av:'divEstadostipofiltercontainer_Class',ctrl:'ESTADOSTIPOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTADOSTIPOFILTER.CLICK",",oparms:[{av:'divEstadostipofiltercontainer_Class',ctrl:'ESTADOSTIPOFILTERCONTAINER',prop:'Class'},{av:'edtavCestadostipo_Visible',ctrl:'vCESTADOSTIPO',prop:'Visible'}]}");
         setEventMetadata("LBLESTADOSGENERICOSIDFILTER.CLICK","{handler:'E17D41',iparms:[{av:'divEstadosgenericosidfiltercontainer_Class',ctrl:'ESTADOSGENERICOSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTADOSGENERICOSIDFILTER.CLICK",",oparms:[{av:'divEstadosgenericosidfiltercontainer_Class',ctrl:'ESTADOSGENERICOSIDFILTERCONTAINER',prop:'Class'},{av:'dynavCestadosgenericosid'}]}");
         setEventMetadata("ENTER","{handler:'E21D42',iparms:[{av:'A121RubrosId',fld:'RUBROSID',pic:'ZZZ9',hsh:true,type:'int'},{av:'dynMedidasID'},{av:'A137MedidasID',fld:'MEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'dynInventarioId'},{av:'A135InventarioId',fld:'INVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pRubrosId',fld:'vPRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV14pMedidasID',fld:'vPMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV15pInventarioId',fld:'vPINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV7cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV8cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV9cInventarioCosto',fld:'vCINVENTARIOCOSTO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV10cInventarioPrecioFinal',fld:'vCINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cEstadosTipo',fld:'vCESTADOSTIPO',pic:'',type:'char'},{av:'dynavCestadosgenericosid'},{av:'AV12cEstadosGenericosId',fld:'vCESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV7cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV8cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV9cInventarioCosto',fld:'vCINVENTARIOCOSTO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV10cInventarioPrecioFinal',fld:'vCINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cEstadosTipo',fld:'vCESTADOSTIPO',pic:'',type:'char'},{av:'dynavCestadosgenericosid'},{av:'AV12cEstadosGenericosId',fld:'vCESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV7cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV8cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV9cInventarioCosto',fld:'vCINVENTARIOCOSTO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV10cInventarioPrecioFinal',fld:'vCINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cEstadosTipo',fld:'vCESTADOSTIPO',pic:'',type:'char'},{av:'dynavCestadosgenericosid'},{av:'AV12cEstadosGenericosId',fld:'vCESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV7cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV8cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV9cInventarioCosto',fld:'vCINVENTARIOCOSTO',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV10cInventarioPrecioFinal',fld:'vCINVENTARIOPRECIOFINAL',pic:'ZZZZZZZZZZZZZZ9.99',type:'decimal'},{av:'AV11cEstadosTipo',fld:'vCESTADOSTIPO',pic:'',type:'char'},{av:'dynavCestadosgenericosid'},{av:'AV12cEstadosGenericosId',fld:'vCESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[]");
         setEventMetadata("VALID_RUBROSID",",oparms:[]}");
         setEventMetadata("VALID_MEDIDASID","{handler:'Valid_Medidasid',iparms:[]");
         setEventMetadata("VALID_MEDIDASID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Inventarioid',iparms:[]");
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
         AV7cMedidasNombre = "";
         AV8cInventarioNombre = "";
         AV11cEstadosTipo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblrubrosidfilter_Jsonclick = "";
         TempTags = "";
         lblLblmedidasnombrefilter_Jsonclick = "";
         lblLblinventarionombrefilter_Jsonclick = "";
         lblLblinventariocostofilter_Jsonclick = "";
         lblLblinventariopreciofinalfilter_Jsonclick = "";
         lblLblestadostipofilter_Jsonclick = "";
         lblLblestadosgenericosidfilter_Jsonclick = "";
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
         AV17Linkselection_GXI = "";
         A138MedidasNombre = "";
         A189InventarioImagen = "";
         A40000InventarioImagen_GXI = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00D42_A107EstadosTipo = new string[] {""} ;
         H00D42_A108EstadosGenericosId = new int[1] ;
         H00D42_A109EstadosGenericosNombre = new string[] {""} ;
         H00D43_A121RubrosId = new short[1] ;
         H00D43_A137MedidasID = new long[1] ;
         H00D43_A138MedidasNombre = new string[] {""} ;
         H00D43_A139MedidasEstado = new string[] {""} ;
         H00D43_n139MedidasEstado = new bool[] {false} ;
         H00D44_A121RubrosId = new short[1] ;
         H00D44_A137MedidasID = new long[1] ;
         H00D44_A135InventarioId = new long[1] ;
         H00D44_A136InventarioNombre = new string[] {""} ;
         H00D44_A107EstadosTipo = new string[] {""} ;
         H00D44_A108EstadosGenericosId = new int[1] ;
         H00D45_A107EstadosTipo = new string[] {""} ;
         H00D45_A108EstadosGenericosId = new int[1] ;
         H00D45_A109EstadosGenericosNombre = new string[] {""} ;
         lV7cMedidasNombre = "";
         lV8cInventarioNombre = "";
         lV11cEstadosTipo = "";
         A136InventarioNombre = "";
         A107EstadosTipo = "";
         H00D46_A107EstadosTipo = new string[] {""} ;
         H00D46_A136InventarioNombre = new string[] {""} ;
         H00D46_A135InventarioId = new long[1] ;
         H00D46_A137MedidasID = new long[1] ;
         H00D46_A108EstadosGenericosId = new int[1] ;
         H00D46_A181InventarioPrecioFinal = new decimal[1] ;
         H00D46_A190InventarioCosto = new decimal[1] ;
         H00D46_A40000InventarioImagen_GXI = new string[] {""} ;
         H00D46_A138MedidasNombre = new string[] {""} ;
         H00D46_A121RubrosId = new short[1] ;
         H00D46_A189InventarioImagen = new string[] {""} ;
         H00D47_AGRID1_nRecordCount = new long[1] ;
         AV16ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         H00D48_A107EstadosTipo = new string[] {""} ;
         H00D48_A108EstadosGenericosId = new int[1] ;
         H00D48_A109EstadosGenericosNombre = new string[] {""} ;
         H00D49_A107EstadosTipo = new string[] {""} ;
         H00D49_A108EstadosGenericosId = new int[1] ;
         H00D49_A109EstadosGenericosNombre = new string[] {""} ;
         H00D410_A107EstadosTipo = new string[] {""} ;
         H00D410_A108EstadosGenericosId = new int[1] ;
         H00D410_A109EstadosGenericosNombre = new string[] {""} ;
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00r0__default(),
            new Object[][] {
                new Object[] {
               H00D42_A107EstadosTipo, H00D42_A108EstadosGenericosId, H00D42_A109EstadosGenericosNombre
               }
               , new Object[] {
               H00D43_A121RubrosId, H00D43_A137MedidasID, H00D43_A138MedidasNombre, H00D43_A139MedidasEstado, H00D43_n139MedidasEstado
               }
               , new Object[] {
               H00D44_A121RubrosId, H00D44_A137MedidasID, H00D44_A135InventarioId, H00D44_A136InventarioNombre, H00D44_A107EstadosTipo, H00D44_A108EstadosGenericosId
               }
               , new Object[] {
               H00D45_A107EstadosTipo, H00D45_A108EstadosGenericosId, H00D45_A109EstadosGenericosNombre
               }
               , new Object[] {
               H00D46_A107EstadosTipo, H00D46_A136InventarioNombre, H00D46_A135InventarioId, H00D46_A137MedidasID, H00D46_A108EstadosGenericosId, H00D46_A181InventarioPrecioFinal, H00D46_A190InventarioCosto, H00D46_A40000InventarioImagen_GXI, H00D46_A138MedidasNombre, H00D46_A121RubrosId,
               H00D46_A189InventarioImagen
               }
               , new Object[] {
               H00D47_AGRID1_nRecordCount
               }
               , new Object[] {
               H00D48_A107EstadosTipo, H00D48_A108EstadosGenericosId, H00D48_A109EstadosGenericosNombre
               }
               , new Object[] {
               H00D49_A107EstadosTipo, H00D49_A108EstadosGenericosId, H00D49_A109EstadosGenericosNombre
               }
               , new Object[] {
               H00D410_A107EstadosTipo, H00D410_A108EstadosGenericosId, H00D410_A109EstadosGenericosNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13pRubrosId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cRubrosId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A121RubrosId ;
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
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int AV12cEstadosGenericosId ;
      private int edtavCrubrosid_Enabled ;
      private int edtavCrubrosid_Visible ;
      private int edtavCmedidasnombre_Visible ;
      private int edtavCmedidasnombre_Enabled ;
      private int edtavCinventarionombre_Visible ;
      private int edtavCinventarionombre_Enabled ;
      private int edtavCinventariocosto_Enabled ;
      private int edtavCinventariocosto_Visible ;
      private int edtavCinventariopreciofinal_Enabled ;
      private int edtavCinventariopreciofinal_Visible ;
      private int edtavCestadostipo_Visible ;
      private int edtavCestadostipo_Enabled ;
      private int A108EstadosGenericosId ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtRubrosId_Enabled ;
      private int edtMedidasNombre_Enabled ;
      private int edtInventarioImagen_Enabled ;
      private int edtInventarioCosto_Enabled ;
      private int edtInventarioPrecioFinal_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV14pMedidasID ;
      private long AV15pInventarioId ;
      private long GRID1_nFirstRecordOnPage ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV9cInventarioCosto ;
      private decimal AV10cInventarioPrecioFinal ;
      private decimal A190InventarioCosto ;
      private decimal A181InventarioPrecioFinal ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divRubrosidfiltercontainer_Class ;
      private string divMedidasnombrefiltercontainer_Class ;
      private string divInventarionombrefiltercontainer_Class ;
      private string divInventariocostofiltercontainer_Class ;
      private string divInventariopreciofinalfiltercontainer_Class ;
      private string divEstadostipofiltercontainer_Class ;
      private string divEstadosgenericosidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV7cMedidasNombre ;
      private string AV8cInventarioNombre ;
      private string AV11cEstadosTipo ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divRubrosidfiltercontainer_Internalname ;
      private string lblLblrubrosidfilter_Internalname ;
      private string lblLblrubrosidfilter_Jsonclick ;
      private string edtavCrubrosid_Internalname ;
      private string TempTags ;
      private string edtavCrubrosid_Jsonclick ;
      private string divMedidasnombrefiltercontainer_Internalname ;
      private string lblLblmedidasnombrefilter_Internalname ;
      private string lblLblmedidasnombrefilter_Jsonclick ;
      private string edtavCmedidasnombre_Internalname ;
      private string edtavCmedidasnombre_Jsonclick ;
      private string divInventarionombrefiltercontainer_Internalname ;
      private string lblLblinventarionombrefilter_Internalname ;
      private string lblLblinventarionombrefilter_Jsonclick ;
      private string edtavCinventarionombre_Internalname ;
      private string edtavCinventarionombre_Jsonclick ;
      private string divInventariocostofiltercontainer_Internalname ;
      private string lblLblinventariocostofilter_Internalname ;
      private string lblLblinventariocostofilter_Jsonclick ;
      private string edtavCinventariocosto_Internalname ;
      private string edtavCinventariocosto_Jsonclick ;
      private string divInventariopreciofinalfiltercontainer_Internalname ;
      private string lblLblinventariopreciofinalfilter_Internalname ;
      private string lblLblinventariopreciofinalfilter_Jsonclick ;
      private string edtavCinventariopreciofinal_Internalname ;
      private string edtavCinventariopreciofinal_Jsonclick ;
      private string divEstadostipofiltercontainer_Internalname ;
      private string lblLblestadostipofilter_Internalname ;
      private string lblLblestadostipofilter_Jsonclick ;
      private string edtavCestadostipo_Internalname ;
      private string edtavCestadostipo_Jsonclick ;
      private string divEstadosgenericosidfiltercontainer_Internalname ;
      private string lblLblestadosgenericosidfilter_Internalname ;
      private string lblLblestadosgenericosidfilter_Jsonclick ;
      private string dynavCestadosgenericosid_Internalname ;
      private string dynavCestadosgenericosid_Jsonclick ;
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
      private string edtRubrosId_Internalname ;
      private string A138MedidasNombre ;
      private string edtMedidasNombre_Internalname ;
      private string edtInventarioImagen_Internalname ;
      private string edtInventarioCosto_Internalname ;
      private string edtInventarioPrecioFinal_Internalname ;
      private string dynEstadosGenericosId_Internalname ;
      private string dynMedidasID_Internalname ;
      private string dynInventarioId_Internalname ;
      private string gxwrpcisep ;
      private string lV7cMedidasNombre ;
      private string lV8cInventarioNombre ;
      private string lV11cEstadosTipo ;
      private string A136InventarioNombre ;
      private string A107EstadosTipo ;
      private string AV16ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtRubrosId_Jsonclick ;
      private string edtMedidasNombre_Jsonclick ;
      private string edtInventarioCosto_Jsonclick ;
      private string edtInventarioPrecioFinal_Jsonclick ;
      private string GXCCtl ;
      private string dynEstadosGenericosId_Jsonclick ;
      private string dynMedidasID_Jsonclick ;
      private string dynInventarioId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private bool A189InventarioImagen_IsBlob ;
      private string AV17Linkselection_GXI ;
      private string A40000InventarioImagen_GXI ;
      private string AV5LinkSelection ;
      private string A189InventarioImagen ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavCestadosgenericosid ;
      private GXCombobox dynEstadosGenericosId ;
      private GXCombobox dynMedidasID ;
      private GXCombobox dynInventarioId ;
      private IDataStoreProvider pr_default ;
      private string[] H00D42_A107EstadosTipo ;
      private int[] H00D42_A108EstadosGenericosId ;
      private string[] H00D42_A109EstadosGenericosNombre ;
      private short[] H00D43_A121RubrosId ;
      private long[] H00D43_A137MedidasID ;
      private string[] H00D43_A138MedidasNombre ;
      private string[] H00D43_A139MedidasEstado ;
      private bool[] H00D43_n139MedidasEstado ;
      private short[] H00D44_A121RubrosId ;
      private long[] H00D44_A137MedidasID ;
      private long[] H00D44_A135InventarioId ;
      private string[] H00D44_A136InventarioNombre ;
      private string[] H00D44_A107EstadosTipo ;
      private int[] H00D44_A108EstadosGenericosId ;
      private string[] H00D45_A107EstadosTipo ;
      private int[] H00D45_A108EstadosGenericosId ;
      private string[] H00D45_A109EstadosGenericosNombre ;
      private string[] H00D46_A107EstadosTipo ;
      private string[] H00D46_A136InventarioNombre ;
      private long[] H00D46_A135InventarioId ;
      private long[] H00D46_A137MedidasID ;
      private int[] H00D46_A108EstadosGenericosId ;
      private decimal[] H00D46_A181InventarioPrecioFinal ;
      private decimal[] H00D46_A190InventarioCosto ;
      private string[] H00D46_A40000InventarioImagen_GXI ;
      private string[] H00D46_A138MedidasNombre ;
      private short[] H00D46_A121RubrosId ;
      private string[] H00D46_A189InventarioImagen ;
      private long[] H00D47_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string[] H00D48_A107EstadosTipo ;
      private int[] H00D48_A108EstadosGenericosId ;
      private string[] H00D48_A109EstadosGenericosNombre ;
      private string[] H00D49_A107EstadosTipo ;
      private int[] H00D49_A108EstadosGenericosId ;
      private string[] H00D49_A109EstadosGenericosNombre ;
      private string[] H00D410_A107EstadosTipo ;
      private int[] H00D410_A108EstadosGenericosId ;
      private string[] H00D410_A109EstadosGenericosNombre ;
      private short aP0_pRubrosId ;
      private long aP1_pMedidasID ;
      private long aP2_pInventarioId ;
   }

   public class gx00r0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00D46( IGxContext context ,
                                             string AV7cMedidasNombre ,
                                             string AV8cInventarioNombre ,
                                             decimal AV9cInventarioCosto ,
                                             decimal AV10cInventarioPrecioFinal ,
                                             string AV11cEstadosTipo ,
                                             int AV12cEstadosGenericosId ,
                                             string A138MedidasNombre ,
                                             string A136InventarioNombre ,
                                             decimal A190InventarioCosto ,
                                             decimal A181InventarioPrecioFinal ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId ,
                                             short AV6cRubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[EstadosTipo], T1.[InventarioNombre], T1.[InventarioId], T1.[MedidasID], T1.[EstadosGenericosId], T1.[InventarioPrecioFinal], T1.[InventarioCosto], T1.[InventarioImagen_GXI], T2.[MedidasNombre], T1.[RubrosId], T1.[InventarioImagen]";
         sFromString = " FROM ([Inventario] T1 INNER JOIN [RubrosMedidas] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[RubrosId] >= @AV6cRubrosId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cMedidasNombre)) )
         {
            AddWhere(sWhereString, "(T2.[MedidasNombre] like @lV7cMedidasNombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cInventarioNombre)) )
         {
            AddWhere(sWhereString, "(T1.[InventarioNombre] like @lV8cInventarioNombre)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cInventarioCosto) )
         {
            AddWhere(sWhereString, "(T1.[InventarioCosto] >= @AV9cInventarioCosto)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "(T1.[InventarioPrecioFinal] >= @AV10cInventarioPrecioFinal)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cEstadosTipo)) )
         {
            AddWhere(sWhereString, "(T1.[EstadosTipo] like @lV11cEstadosTipo)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cEstadosGenericosId) )
         {
            AddWhere(sWhereString, "(T1.[EstadosGenericosId] >= @AV12cEstadosGenericosId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY T1.[RubrosId], T1.[MedidasID], T1.[InventarioId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00D47( IGxContext context ,
                                             string AV7cMedidasNombre ,
                                             string AV8cInventarioNombre ,
                                             decimal AV9cInventarioCosto ,
                                             decimal AV10cInventarioPrecioFinal ,
                                             string AV11cEstadosTipo ,
                                             int AV12cEstadosGenericosId ,
                                             string A138MedidasNombre ,
                                             string A136InventarioNombre ,
                                             decimal A190InventarioCosto ,
                                             decimal A181InventarioPrecioFinal ,
                                             string A107EstadosTipo ,
                                             int A108EstadosGenericosId ,
                                             short AV6cRubrosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([Inventario] T1 INNER JOIN [RubrosMedidas] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID])";
         AddWhere(sWhereString, "(T1.[RubrosId] >= @AV6cRubrosId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cMedidasNombre)) )
         {
            AddWhere(sWhereString, "(T2.[MedidasNombre] like @lV7cMedidasNombre)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cInventarioNombre)) )
         {
            AddWhere(sWhereString, "(T1.[InventarioNombre] like @lV8cInventarioNombre)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cInventarioCosto) )
         {
            AddWhere(sWhereString, "(T1.[InventarioCosto] >= @AV9cInventarioCosto)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cInventarioPrecioFinal) )
         {
            AddWhere(sWhereString, "(T1.[InventarioPrecioFinal] >= @AV10cInventarioPrecioFinal)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cEstadosTipo)) )
         {
            AddWhere(sWhereString, "(T1.[EstadosTipo] like @lV11cEstadosTipo)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cEstadosGenericosId) )
         {
            AddWhere(sWhereString, "(T1.[EstadosGenericosId] >= @AV12cEstadosGenericosId)");
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
               case 4 :
                     return conditional_H00D46(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (short)dynConstraints[12] );
               case 5 :
                     return conditional_H00D47(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (short)dynConstraints[12] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00D42;
          prmH00D42 = new Object[] {
          };
          Object[] prmH00D43;
          prmH00D43 = new Object[] {
          };
          Object[] prmH00D44;
          prmH00D44 = new Object[] {
          };
          Object[] prmH00D45;
          prmH00D45 = new Object[] {
          };
          Object[] prmH00D48;
          prmH00D48 = new Object[] {
          };
          Object[] prmH00D49;
          prmH00D49 = new Object[] {
          };
          Object[] prmH00D410;
          prmH00D410 = new Object[] {
          };
          Object[] prmH00D46;
          prmH00D46 = new Object[] {
          new ParDef("@AV6cRubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV7cMedidasNombre",GXType.NChar,50,0) ,
          new ParDef("@lV8cInventarioNombre",GXType.NChar,100,0) ,
          new ParDef("@AV9cInventarioCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV10cInventarioPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@lV11cEstadosTipo",GXType.NChar,3,0) ,
          new ParDef("@AV12cEstadosGenericosId",GXType.Int32,5,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00D47;
          prmH00D47 = new Object[] {
          new ParDef("@AV6cRubrosId",GXType.Int16,4,0) ,
          new ParDef("@lV7cMedidasNombre",GXType.NChar,50,0) ,
          new ParDef("@lV8cInventarioNombre",GXType.NChar,100,0) ,
          new ParDef("@AV9cInventarioCosto",GXType.Decimal,18,2) ,
          new ParDef("@AV10cInventarioPrecioFinal",GXType.Decimal,18,2) ,
          new ParDef("@lV11cEstadosTipo",GXType.NChar,3,0) ,
          new ParDef("@AV12cEstadosGenericosId",GXType.Int32,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00D42", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] ORDER BY [EstadosGenericosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00D42,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00D43", "SELECT [RubrosId], [MedidasID], [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE [MedidasEstado] <> 'DES' ORDER BY [MedidasNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00D43,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00D44", "SELECT [RubrosId], [MedidasID], [InventarioId], [InventarioNombre], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE [EstadosGenericosId] = 1 ORDER BY [InventarioNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00D44,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00D45", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] ORDER BY [EstadosGenericosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00D45,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00D46", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00D46,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00D47", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00D47,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00D48", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] ORDER BY [EstadosGenericosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00D48,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00D49", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] ORDER BY [EstadosGenericosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00D49,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00D410", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] ORDER BY [EstadosGenericosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00D410,0, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaUri(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 50);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(8));
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
       }
    }

 }

}

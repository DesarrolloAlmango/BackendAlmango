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
   public class gx03s4 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx03s4( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx03s4( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pMapeoID ,
                           short aP1_pRubrosId ,
                           long aP2_pMedidasID ,
                           long aP3_pInventarioId ,
                           out string aP4_pMapeoListadoReferenciaId )
      {
         this.AV8pMapeoID = aP0_pMapeoID;
         this.AV9pRubrosId = aP1_pRubrosId;
         this.AV10pMedidasID = aP2_pMedidasID;
         this.AV11pInventarioId = aP3_pInventarioId;
         this.AV12pMapeoListadoReferenciaId = "" ;
         ExecutePrivate();
         aP4_pMapeoListadoReferenciaId=this.AV12pMapeoListadoReferenciaId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCmapeolistadoreferenciaestado = new GXCombobox();
         dynMedidasID = new GXCombobox();
         dynInventarioId = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pMapeoID");
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
               GXDLAMEDIDASIDJE2( ) ;
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
               GXDLAINVENTARIOIDJE2( ) ;
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
               gxfirstwebparm = GetFirstPar( "pMapeoID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pMapeoID");
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
               AV8pMapeoID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8pMapeoID", StringUtil.LTrimStr( (decimal)(AV8pMapeoID), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9pRubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "pRubrosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV9pRubrosId", StringUtil.LTrimStr( (decimal)(AV9pRubrosId), 4, 0));
                  AV10pMedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "pMedidasID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV10pMedidasID", StringUtil.LTrimStr( (decimal)(AV10pMedidasID), 18, 0));
                  AV11pInventarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "pInventarioId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11pInventarioId", StringUtil.LTrimStr( (decimal)(AV11pInventarioId), 18, 0));
                  AV12pMapeoListadoReferenciaId = GetPar( "pMapeoListadoReferenciaId");
                  AssignAttri("", false, "AV12pMapeoListadoReferenciaId", AV12pMapeoListadoReferenciaId);
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
         nRC_GXsfl_34 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_34"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_34_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_34_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_34_idx = GetPar( "sGXsfl_34_idx");
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
         AV6cMapeoListadoReferenciaNombre = GetPar( "cMapeoListadoReferenciaNombre");
         cmbavCmapeolistadoreferenciaestado.FromJSonString( GetNextPar( ));
         AV7cMapeoListadoReferenciaEstado = GetPar( "cMapeoListadoReferenciaEstado");
         AV8pMapeoID = (long)(Math.Round(NumberUtil.Val( GetPar( "pMapeoID"), "."), 18, MidpointRounding.ToEven));
         AV9pRubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "pRubrosId"), "."), 18, MidpointRounding.ToEven));
         AV10pMedidasID = (long)(Math.Round(NumberUtil.Val( GetPar( "pMedidasID"), "."), 18, MidpointRounding.ToEven));
         AV11pInventarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "pInventarioId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cMapeoListadoReferenciaNombre, AV7cMapeoListadoReferenciaEstado, AV8pMapeoID, AV9pRubrosId, AV10pMedidasID, AV11pInventarioId) ;
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
         PAJE2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTJE2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx03s4.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8pMapeoID,18,0)),UrlEncode(StringUtil.LTrimStr(AV9pRubrosId,4,0)),UrlEncode(StringUtil.LTrimStr(AV10pMedidasID,18,0)),UrlEncode(StringUtil.LTrimStr(AV11pInventarioId,18,0)),UrlEncode(StringUtil.RTrim(AV12pMapeoListadoReferenciaId))}, new string[] {"pMapeoID","pRubrosId","pMedidasID","pInventarioId","pMapeoListadoReferenciaId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCMAPEOLISTADOREFERENCIANOMBRE", StringUtil.RTrim( AV6cMapeoListadoReferenciaNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCMAPEOLISTADOREFERENCIAESTADO", StringUtil.RTrim( AV7cMapeoListadoReferenciaEstado));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_34", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_34), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPMAPEOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8pMapeoID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9pRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPMEDIDASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pMedidasID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPINVENTARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pInventarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPMAPEOLISTADOREFERENCIAID", StringUtil.RTrim( AV12pMapeoListadoReferenciaId));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "MAPEOLISTADOREFERENCIANOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divMapeolistadoreferencianombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MAPEOLISTADOREFERENCIAESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divMapeolistadoreferenciaestadofiltercontainer_Class));
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
            WEJE2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTJE2( ) ;
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
         return formatLink("gx03s4.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8pMapeoID,18,0)),UrlEncode(StringUtil.LTrimStr(AV9pRubrosId,4,0)),UrlEncode(StringUtil.LTrimStr(AV10pMedidasID,18,0)),UrlEncode(StringUtil.LTrimStr(AV11pInventarioId,18,0)),UrlEncode(StringUtil.RTrim(AV12pMapeoListadoReferenciaId))}, new string[] {"pMapeoID","pRubrosId","pMedidasID","pInventarioId","pMapeoListadoReferenciaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx03S4" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List MapeoListadoReferencia", "") ;
      }

      protected void WBJE0( )
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
            GxWebStd.gx_div_start( context, divMapeolistadoreferencianombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divMapeolistadoreferencianombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmapeolistadoreferencianombrefilter_Internalname, context.GetMessage( "Nombre", ""), "", "", lblLblmapeolistadoreferencianombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11je1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03S4.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCmapeolistadoreferencianombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_34_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmapeolistadoreferencianombre_Internalname, StringUtil.RTrim( AV6cMapeoListadoReferenciaNombre), StringUtil.RTrim( context.localUtil.Format( AV6cMapeoListadoReferenciaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmapeolistadoreferencianombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmapeolistadoreferencianombre_Visible, edtavCmapeolistadoreferencianombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx03S4.htm");
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
            GxWebStd.gx_div_start( context, divMapeolistadoreferenciaestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divMapeolistadoreferenciaestadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblmapeolistadoreferenciaestadofilter_Internalname, context.GetMessage( "Estado", ""), "", "", lblLblmapeolistadoreferenciaestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12je1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03S4.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCmapeolistadoreferenciaestado_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_34_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCmapeolistadoreferenciaestado, cmbavCmapeolistadoreferenciaestado_Internalname, StringUtil.RTrim( AV7cMapeoListadoReferenciaEstado), 1, cmbavCmapeolistadoreferenciaestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCmapeolistadoreferenciaestado.Visible, cmbavCmapeolistadoreferenciaestado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Gx03S4.htm");
            cmbavCmapeolistadoreferenciaestado.CurrentValue = StringUtil.RTrim( AV7cMapeoListadoReferenciaEstado);
            AssignProp("", false, cmbavCmapeolistadoreferenciaestado_Internalname, "Values", (string)(cmbavCmapeolistadoreferenciaestado.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e13je1_client"+"'", TempTags, "", 2, "HLP_Gx03S4.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl34( ) ;
         }
         if ( wbEnd == 34 )
         {
            wbEnd = 0;
            nRC_GXsfl_34 = (int)(nGXsfl_34_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx03S4.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 34 )
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

      protected void STARTJE2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List MapeoListadoReferencia", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPJE0( ) ;
      }

      protected void WSJE2( )
      {
         STARTJE2( ) ;
         EVTJE2( ) ;
      }

      protected void EVTJE2( )
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
                              nGXsfl_34_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
                              SubsflControlProps_342( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_34_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A920MapeoListadoReferenciaId = cgiGet( edtMapeoListadoReferenciaId_Internalname);
                              A918MapeoID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtMapeoID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
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
                                    E14JE2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E15JE2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cmapeolistadoreferencianombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAPEOLISTADOREFERENCIANOMBRE"), AV6cMapeoListadoReferenciaNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmapeolistadoreferenciaestado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAPEOLISTADOREFERENCIAESTADO"), AV7cMapeoListadoReferenciaEstado) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E16JE2 ();
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

      protected void WEJE2( )
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

      protected void PAJE2( )
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

      protected void GXDLAMEDIDASIDJE2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAMEDIDASID_dataJE2( ) ;
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

      protected void GXAMEDIDASID_htmlJE2( )
      {
         long gxdynajaxvalue;
         GXDLAMEDIDASID_dataJE2( ) ;
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

      protected void GXDLAMEDIDASID_dataJE2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H00JE2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00JE2_A137MedidasID[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00JE2_A138MedidasNombre[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLAINVENTARIOIDJE2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAINVENTARIOID_dataJE2( ) ;
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

      protected void GXAINVENTARIOID_htmlJE2( )
      {
         long gxdynajaxvalue;
         GXDLAINVENTARIOID_dataJE2( ) ;
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

      protected void GXDLAINVENTARIOID_dataJE2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add(context.GetMessage( "GX_EmptyItemText", ""));
         /* Using cursor H00JE3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00JE3_A135InventarioId[0]), 18, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00JE3_A136InventarioNombre[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_342( ) ;
         while ( nGXsfl_34_idx <= nRC_GXsfl_34 )
         {
            sendrow_342( ) ;
            nGXsfl_34_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_34_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        string AV6cMapeoListadoReferenciaNombre ,
                                        string AV7cMapeoListadoReferenciaEstado ,
                                        long AV8pMapeoID ,
                                        short AV9pRubrosId ,
                                        long AV10pMedidasID ,
                                        long AV11pInventarioId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFJE2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MAPEOLISTADOREFERENCIAID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A920MapeoListadoReferenciaId, "")), context));
         GxWebStd.gx_hidden_field( context, "MAPEOLISTADOREFERENCIAID", StringUtil.RTrim( A920MapeoListadoReferenciaId));
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
         if ( cmbavCmapeolistadoreferenciaestado.ItemCount > 0 )
         {
            AV7cMapeoListadoReferenciaEstado = cmbavCmapeolistadoreferenciaestado.getValidValue(AV7cMapeoListadoReferenciaEstado);
            AssignAttri("", false, "AV7cMapeoListadoReferenciaEstado", AV7cMapeoListadoReferenciaEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCmapeolistadoreferenciaestado.CurrentValue = StringUtil.RTrim( AV7cMapeoListadoReferenciaEstado);
            AssignProp("", false, cmbavCmapeolistadoreferenciaestado_Internalname, "Values", cmbavCmapeolistadoreferenciaestado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFJE2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFJE2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 34;
         nGXsfl_34_idx = 1;
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
         bGXsfl_34_Refreshing = true;
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
            SubsflControlProps_342( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV6cMapeoListadoReferenciaNombre ,
                                                 AV7cMapeoListadoReferenciaEstado ,
                                                 A928MapeoListadoReferenciaNombre ,
                                                 A929MapeoListadoReferenciaEstado ,
                                                 AV8pMapeoID ,
                                                 AV9pRubrosId ,
                                                 AV10pMedidasID ,
                                                 AV11pInventarioId ,
                                                 A918MapeoID ,
                                                 A121RubrosId ,
                                                 A137MedidasID ,
                                                 A135InventarioId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV6cMapeoListadoReferenciaNombre = StringUtil.PadR( StringUtil.RTrim( AV6cMapeoListadoReferenciaNombre), 80, "%");
            lV7cMapeoListadoReferenciaEstado = StringUtil.PadR( StringUtil.RTrim( AV7cMapeoListadoReferenciaEstado), 3, "%");
            /* Using cursor H00JE4 */
            pr_default.execute(2, new Object[] {AV8pMapeoID, AV9pRubrosId, AV10pMedidasID, AV11pInventarioId, lV6cMapeoListadoReferenciaNombre, lV7cMapeoListadoReferenciaEstado, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_34_idx = 1;
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
            while ( ( (pr_default.getStatus(2) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A929MapeoListadoReferenciaEstado = H00JE4_A929MapeoListadoReferenciaEstado[0];
               n929MapeoListadoReferenciaEstado = H00JE4_n929MapeoListadoReferenciaEstado[0];
               A928MapeoListadoReferenciaNombre = H00JE4_A928MapeoListadoReferenciaNombre[0];
               n928MapeoListadoReferenciaNombre = H00JE4_n928MapeoListadoReferenciaNombre[0];
               A135InventarioId = H00JE4_A135InventarioId[0];
               A137MedidasID = H00JE4_A137MedidasID[0];
               A121RubrosId = H00JE4_A121RubrosId[0];
               A918MapeoID = H00JE4_A918MapeoID[0];
               A920MapeoListadoReferenciaId = H00JE4_A920MapeoListadoReferenciaId[0];
               /* Execute user event: Load */
               E15JE2 ();
               pr_default.readNext(2);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(2);
            wbEnd = 34;
            WBJE0( ) ;
         }
         bGXsfl_34_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesJE2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_MAPEOLISTADOREFERENCIAID"+"_"+sGXsfl_34_idx, GetSecureSignedToken( sGXsfl_34_idx, StringUtil.RTrim( context.localUtil.Format( A920MapeoListadoReferenciaId, "")), context));
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
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV6cMapeoListadoReferenciaNombre ,
                                              AV7cMapeoListadoReferenciaEstado ,
                                              A928MapeoListadoReferenciaNombre ,
                                              A929MapeoListadoReferenciaEstado ,
                                              AV8pMapeoID ,
                                              AV9pRubrosId ,
                                              AV10pMedidasID ,
                                              AV11pInventarioId ,
                                              A918MapeoID ,
                                              A121RubrosId ,
                                              A137MedidasID ,
                                              A135InventarioId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV6cMapeoListadoReferenciaNombre = StringUtil.PadR( StringUtil.RTrim( AV6cMapeoListadoReferenciaNombre), 80, "%");
         lV7cMapeoListadoReferenciaEstado = StringUtil.PadR( StringUtil.RTrim( AV7cMapeoListadoReferenciaEstado), 3, "%");
         /* Using cursor H00JE5 */
         pr_default.execute(3, new Object[] {AV8pMapeoID, AV9pRubrosId, AV10pMedidasID, AV11pInventarioId, lV6cMapeoListadoReferenciaNombre, lV7cMapeoListadoReferenciaEstado});
         GRID1_nRecordCount = H00JE5_AGRID1_nRecordCount[0];
         pr_default.close(3);
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMapeoListadoReferenciaNombre, AV7cMapeoListadoReferenciaEstado, AV8pMapeoID, AV9pRubrosId, AV10pMedidasID, AV11pInventarioId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMapeoListadoReferenciaNombre, AV7cMapeoListadoReferenciaEstado, AV8pMapeoID, AV9pRubrosId, AV10pMedidasID, AV11pInventarioId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMapeoListadoReferenciaNombre, AV7cMapeoListadoReferenciaEstado, AV8pMapeoID, AV9pRubrosId, AV10pMedidasID, AV11pInventarioId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMapeoListadoReferenciaNombre, AV7cMapeoListadoReferenciaEstado, AV8pMapeoID, AV9pRubrosId, AV10pMedidasID, AV11pInventarioId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cMapeoListadoReferenciaNombre, AV7cMapeoListadoReferenciaEstado, AV8pMapeoID, AV9pRubrosId, AV10pMedidasID, AV11pInventarioId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         GXAMEDIDASID_htmlJE2( ) ;
         GXAINVENTARIOID_htmlJE2( ) ;
         edtMapeoListadoReferenciaId_Enabled = 0;
         edtMapeoID_Enabled = 0;
         edtRubrosId_Enabled = 0;
         dynMedidasID.Enabled = 0;
         dynInventarioId.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPJE0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14JE2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_34 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_34"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV6cMapeoListadoReferenciaNombre = cgiGet( edtavCmapeolistadoreferencianombre_Internalname);
            AssignAttri("", false, "AV6cMapeoListadoReferenciaNombre", AV6cMapeoListadoReferenciaNombre);
            cmbavCmapeolistadoreferenciaestado.Name = cmbavCmapeolistadoreferenciaestado_Internalname;
            cmbavCmapeolistadoreferenciaestado.CurrentValue = cgiGet( cmbavCmapeolistadoreferenciaestado_Internalname);
            AV7cMapeoListadoReferenciaEstado = cgiGet( cmbavCmapeolistadoreferenciaestado_Internalname);
            AssignAttri("", false, "AV7cMapeoListadoReferenciaEstado", AV7cMapeoListadoReferenciaEstado);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAPEOLISTADOREFERENCIANOMBRE"), AV6cMapeoListadoReferenciaNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMAPEOLISTADOREFERENCIAESTADO"), AV7cMapeoListadoReferenciaEstado) != 0 )
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
         E14JE2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E14JE2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "MapeoListadoReferencia", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E15JE2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV14Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_342( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_34_Refreshing )
         {
            context.DoAjaxLoad(34, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E16JE2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16JE2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pMapeoListadoReferenciaId = A920MapeoListadoReferenciaId;
         AssignAttri("", false, "AV12pMapeoListadoReferenciaId", AV12pMapeoListadoReferenciaId);
         context.setWebReturnParms(new Object[] {(string)AV12pMapeoListadoReferenciaId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pMapeoListadoReferenciaId"});
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
         AV8pMapeoID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV8pMapeoID", StringUtil.LTrimStr( (decimal)(AV8pMapeoID), 18, 0));
         AV9pRubrosId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV9pRubrosId", StringUtil.LTrimStr( (decimal)(AV9pRubrosId), 4, 0));
         AV10pMedidasID = Convert.ToInt64(getParm(obj,2));
         AssignAttri("", false, "AV10pMedidasID", StringUtil.LTrimStr( (decimal)(AV10pMedidasID), 18, 0));
         AV11pInventarioId = Convert.ToInt64(getParm(obj,3));
         AssignAttri("", false, "AV11pInventarioId", StringUtil.LTrimStr( (decimal)(AV11pInventarioId), 18, 0));
         AV12pMapeoListadoReferenciaId = (string)getParm(obj,4);
         AssignAttri("", false, "AV12pMapeoListadoReferenciaId", AV12pMapeoListadoReferenciaId);
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
         PAJE2( ) ;
         WSJE2( ) ;
         WEJE2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026932001441", true, true, false);
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
         context.AddJavascriptSource("gx03s4.js", "?2026932001441", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_342( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_34_idx;
         edtMapeoListadoReferenciaId_Internalname = "MAPEOLISTADOREFERENCIAID_"+sGXsfl_34_idx;
         edtMapeoID_Internalname = "MAPEOID_"+sGXsfl_34_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_34_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_34_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_34_idx;
      }

      protected void SubsflControlProps_fel_342( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_34_fel_idx;
         edtMapeoListadoReferenciaId_Internalname = "MAPEOLISTADOREFERENCIAID_"+sGXsfl_34_fel_idx;
         edtMapeoID_Internalname = "MAPEOID_"+sGXsfl_34_fel_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_34_fel_idx;
         dynMedidasID_Internalname = "MEDIDASID_"+sGXsfl_34_fel_idx;
         dynInventarioId_Internalname = "INVENTARIOID_"+sGXsfl_34_fel_idx;
      }

      protected void sendrow_342( )
      {
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
         WBJE0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_34_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_34_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_34_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A920MapeoListadoReferenciaId))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_34_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV14Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMapeoListadoReferenciaId_Internalname,StringUtil.RTrim( A920MapeoListadoReferenciaId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMapeoListadoReferenciaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMapeoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A918MapeoID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A918MapeoID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMapeoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            GXAMEDIDASID_htmlJE2( ) ;
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( dynMedidasID.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "MEDIDASID_" + sGXsfl_34_idx;
               dynMedidasID.Name = GXCCtl;
               dynMedidasID.WebTags = "";
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynMedidasID,(string)dynMedidasID_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0)),(short)1,(string)dynMedidasID_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynMedidasID.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A137MedidasID), 18, 0));
            AssignProp("", false, dynMedidasID_Internalname, "Values", (string)(dynMedidasID.ToJavascriptSource()), !bGXsfl_34_Refreshing);
            GXAINVENTARIOID_htmlJE2( ) ;
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( dynInventarioId.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "INVENTARIOID_" + sGXsfl_34_idx;
               dynInventarioId.Name = GXCCtl;
               dynInventarioId.WebTags = "";
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynInventarioId,(string)dynInventarioId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0)),(short)1,(string)dynInventarioId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynInventarioId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A135InventarioId), 18, 0));
            AssignProp("", false, dynInventarioId_Internalname, "Values", (string)(dynInventarioId.ToJavascriptSource()), !bGXsfl_34_Refreshing);
            send_integrity_lvl_hashesJE2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_34_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_34_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         /* End function sendrow_342 */
      }

      protected void init_web_controls( )
      {
         cmbavCmapeolistadoreferenciaestado.Name = "vCMAPEOLISTADOREFERENCIAESTADO";
         cmbavCmapeolistadoreferenciaestado.WebTags = "";
         cmbavCmapeolistadoreferenciaestado.addItem("HAB", context.GetMessage( "Habilitado", ""), 0);
         cmbavCmapeolistadoreferenciaestado.addItem("DES", context.GetMessage( "Deshabilitado", ""), 0);
         cmbavCmapeolistadoreferenciaestado.addItem("PEN", context.GetMessage( "Pendiente", ""), 0);
         cmbavCmapeolistadoreferenciaestado.addItem("BLO", context.GetMessage( "Bloqueado", ""), 0);
         if ( cmbavCmapeolistadoreferenciaestado.ItemCount > 0 )
         {
            AV7cMapeoListadoReferenciaEstado = cmbavCmapeolistadoreferenciaestado.getValidValue(AV7cMapeoListadoReferenciaEstado);
            AssignAttri("", false, "AV7cMapeoListadoReferenciaEstado", AV7cMapeoListadoReferenciaEstado);
         }
         GXCCtl = "MEDIDASID_" + sGXsfl_34_idx;
         dynMedidasID.Name = GXCCtl;
         dynMedidasID.WebTags = "";
         GXCCtl = "INVENTARIOID_" + sGXsfl_34_idx;
         dynInventarioId.Name = GXCCtl;
         dynInventarioId.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl34( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"34\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Id Ref.: Externo (SKU)", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Mapeo ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rubros Identificador ", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A920MapeoListadoReferenciaId)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A918MapeoID), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
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
         lblLblmapeolistadoreferencianombrefilter_Internalname = "LBLMAPEOLISTADOREFERENCIANOMBREFILTER";
         edtavCmapeolistadoreferencianombre_Internalname = "vCMAPEOLISTADOREFERENCIANOMBRE";
         divMapeolistadoreferencianombrefiltercontainer_Internalname = "MAPEOLISTADOREFERENCIANOMBREFILTERCONTAINER";
         lblLblmapeolistadoreferenciaestadofilter_Internalname = "LBLMAPEOLISTADOREFERENCIAESTADOFILTER";
         cmbavCmapeolistadoreferenciaestado_Internalname = "vCMAPEOLISTADOREFERENCIAESTADO";
         divMapeolistadoreferenciaestadofiltercontainer_Internalname = "MAPEOLISTADOREFERENCIAESTADOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtMapeoListadoReferenciaId_Internalname = "MAPEOLISTADOREFERENCIAID";
         edtMapeoID_Internalname = "MAPEOID";
         edtRubrosId_Internalname = "RUBROSID";
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
         edtRubrosId_Jsonclick = "";
         edtMapeoID_Jsonclick = "";
         edtMapeoListadoReferenciaId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         dynInventarioId.Enabled = 0;
         dynMedidasID.Enabled = 0;
         edtRubrosId_Enabled = 0;
         edtMapeoID_Enabled = 0;
         edtMapeoListadoReferenciaId_Enabled = 0;
         cmbavCmapeolistadoreferenciaestado_Jsonclick = "";
         cmbavCmapeolistadoreferenciaestado.Visible = 1;
         cmbavCmapeolistadoreferenciaestado.Enabled = 1;
         edtavCmapeolistadoreferencianombre_Jsonclick = "";
         edtavCmapeolistadoreferencianombre_Enabled = 1;
         edtavCmapeolistadoreferencianombre_Visible = 1;
         divMapeolistadoreferenciaestadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMapeolistadoreferencianombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List MapeoListadoReferencia", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMapeoListadoReferenciaNombre',fld:'vCMAPEOLISTADOREFERENCIANOMBRE',pic:'',type:'char'},{av:'cmbavCmapeolistadoreferenciaestado'},{av:'AV7cMapeoListadoReferenciaEstado',fld:'vCMAPEOLISTADOREFERENCIAESTADO',pic:'',type:'char'},{av:'AV8pMapeoID',fld:'vPMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9pRubrosId',fld:'vPRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV10pMedidasID',fld:'vPMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11pInventarioId',fld:'vPINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E13JE1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLMAPEOLISTADOREFERENCIANOMBREFILTER.CLICK","{handler:'E11JE1',iparms:[{av:'divMapeolistadoreferencianombrefiltercontainer_Class',ctrl:'MAPEOLISTADOREFERENCIANOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAPEOLISTADOREFERENCIANOMBREFILTER.CLICK",",oparms:[{av:'divMapeolistadoreferencianombrefiltercontainer_Class',ctrl:'MAPEOLISTADOREFERENCIANOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCmapeolistadoreferencianombre_Visible',ctrl:'vCMAPEOLISTADOREFERENCIANOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLMAPEOLISTADOREFERENCIAESTADOFILTER.CLICK","{handler:'E12JE1',iparms:[{av:'divMapeolistadoreferenciaestadofiltercontainer_Class',ctrl:'MAPEOLISTADOREFERENCIAESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMAPEOLISTADOREFERENCIAESTADOFILTER.CLICK",",oparms:[{av:'divMapeolistadoreferenciaestadofiltercontainer_Class',ctrl:'MAPEOLISTADOREFERENCIAESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCmapeolistadoreferenciaestado'}]}");
         setEventMetadata("ENTER","{handler:'E16JE2',iparms:[{av:'A920MapeoListadoReferenciaId',fld:'MAPEOLISTADOREFERENCIAID',pic:'',hsh:true,type:'char'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pMapeoListadoReferenciaId',fld:'vPMAPEOLISTADOREFERENCIAID',pic:'',type:'char'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMapeoListadoReferenciaNombre',fld:'vCMAPEOLISTADOREFERENCIANOMBRE',pic:'',type:'char'},{av:'cmbavCmapeolistadoreferenciaestado'},{av:'AV7cMapeoListadoReferenciaEstado',fld:'vCMAPEOLISTADOREFERENCIAESTADO',pic:'',type:'char'},{av:'AV8pMapeoID',fld:'vPMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9pRubrosId',fld:'vPRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV10pMedidasID',fld:'vPMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11pInventarioId',fld:'vPINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMapeoListadoReferenciaNombre',fld:'vCMAPEOLISTADOREFERENCIANOMBRE',pic:'',type:'char'},{av:'cmbavCmapeolistadoreferenciaestado'},{av:'AV7cMapeoListadoReferenciaEstado',fld:'vCMAPEOLISTADOREFERENCIAESTADO',pic:'',type:'char'},{av:'AV8pMapeoID',fld:'vPMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9pRubrosId',fld:'vPRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV10pMedidasID',fld:'vPMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11pInventarioId',fld:'vPINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMapeoListadoReferenciaNombre',fld:'vCMAPEOLISTADOREFERENCIANOMBRE',pic:'',type:'char'},{av:'cmbavCmapeolistadoreferenciaestado'},{av:'AV7cMapeoListadoReferenciaEstado',fld:'vCMAPEOLISTADOREFERENCIAESTADO',pic:'',type:'char'},{av:'AV8pMapeoID',fld:'vPMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9pRubrosId',fld:'vPRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV10pMedidasID',fld:'vPMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11pInventarioId',fld:'vPINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cMapeoListadoReferenciaNombre',fld:'vCMAPEOLISTADOREFERENCIANOMBRE',pic:'',type:'char'},{av:'cmbavCmapeolistadoreferenciaestado'},{av:'AV7cMapeoListadoReferenciaEstado',fld:'vCMAPEOLISTADOREFERENCIAESTADO',pic:'',type:'char'},{av:'AV8pMapeoID',fld:'vPMAPEOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9pRubrosId',fld:'vPRUBROSID',pic:'ZZZ9',type:'int'},{av:'AV10pMedidasID',fld:'vPMEDIDASID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV11pInventarioId',fld:'vPINVENTARIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CMAPEOLISTADOREFERENCIAESTADO","{handler:'Validv_Cmapeolistadoreferenciaestado',iparms:[]");
         setEventMetadata("VALIDV_CMAPEOLISTADOREFERENCIAESTADO",",oparms:[]}");
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
         AV12pMapeoListadoReferenciaId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cMapeoListadoReferenciaNombre = "";
         AV7cMapeoListadoReferenciaEstado = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblmapeolistadoreferencianombrefilter_Jsonclick = "";
         TempTags = "";
         lblLblmapeolistadoreferenciaestadofilter_Jsonclick = "";
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
         AV14Linkselection_GXI = "";
         A920MapeoListadoReferenciaId = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00JE2_A121RubrosId = new short[1] ;
         H00JE2_A137MedidasID = new long[1] ;
         H00JE2_A138MedidasNombre = new string[] {""} ;
         H00JE2_A139MedidasEstado = new string[] {""} ;
         H00JE2_n139MedidasEstado = new bool[] {false} ;
         H00JE3_A121RubrosId = new short[1] ;
         H00JE3_A137MedidasID = new long[1] ;
         H00JE3_A135InventarioId = new long[1] ;
         H00JE3_A136InventarioNombre = new string[] {""} ;
         H00JE3_A107EstadosTipo = new string[] {""} ;
         H00JE3_A108EstadosGenericosId = new int[1] ;
         lV6cMapeoListadoReferenciaNombre = "";
         lV7cMapeoListadoReferenciaEstado = "";
         A928MapeoListadoReferenciaNombre = "";
         A929MapeoListadoReferenciaEstado = "";
         H00JE4_A929MapeoListadoReferenciaEstado = new string[] {""} ;
         H00JE4_n929MapeoListadoReferenciaEstado = new bool[] {false} ;
         H00JE4_A928MapeoListadoReferenciaNombre = new string[] {""} ;
         H00JE4_n928MapeoListadoReferenciaNombre = new bool[] {false} ;
         H00JE4_A135InventarioId = new long[1] ;
         H00JE4_A137MedidasID = new long[1] ;
         H00JE4_A121RubrosId = new short[1] ;
         H00JE4_A918MapeoID = new long[1] ;
         H00JE4_A920MapeoListadoReferenciaId = new string[] {""} ;
         H00JE5_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx03s4__default(),
            new Object[][] {
                new Object[] {
               H00JE2_A121RubrosId, H00JE2_A137MedidasID, H00JE2_A138MedidasNombre, H00JE2_A139MedidasEstado, H00JE2_n139MedidasEstado
               }
               , new Object[] {
               H00JE3_A121RubrosId, H00JE3_A137MedidasID, H00JE3_A135InventarioId, H00JE3_A136InventarioNombre, H00JE3_A107EstadosTipo, H00JE3_A108EstadosGenericosId
               }
               , new Object[] {
               H00JE4_A929MapeoListadoReferenciaEstado, H00JE4_n929MapeoListadoReferenciaEstado, H00JE4_A928MapeoListadoReferenciaNombre, H00JE4_n928MapeoListadoReferenciaNombre, H00JE4_A135InventarioId, H00JE4_A137MedidasID, H00JE4_A121RubrosId, H00JE4_A918MapeoID, H00JE4_A920MapeoListadoReferenciaId
               }
               , new Object[] {
               H00JE5_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9pRubrosId ;
      private short wcpOAV9pRubrosId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
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
      private int nRC_GXsfl_34 ;
      private int subGrid1_Rows ;
      private int nGXsfl_34_idx=1 ;
      private int edtavCmapeolistadoreferencianombre_Visible ;
      private int edtavCmapeolistadoreferencianombre_Enabled ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtMapeoListadoReferenciaId_Enabled ;
      private int edtMapeoID_Enabled ;
      private int edtRubrosId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV8pMapeoID ;
      private long AV10pMedidasID ;
      private long AV11pInventarioId ;
      private long wcpOAV8pMapeoID ;
      private long wcpOAV10pMedidasID ;
      private long wcpOAV11pInventarioId ;
      private long GRID1_nFirstRecordOnPage ;
      private long A918MapeoID ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string AV12pMapeoListadoReferenciaId ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divMapeolistadoreferencianombrefiltercontainer_Class ;
      private string divMapeolistadoreferenciaestadofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_34_idx="0001" ;
      private string AV6cMapeoListadoReferenciaNombre ;
      private string AV7cMapeoListadoReferenciaEstado ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divMapeolistadoreferencianombrefiltercontainer_Internalname ;
      private string lblLblmapeolistadoreferencianombrefilter_Internalname ;
      private string lblLblmapeolistadoreferencianombrefilter_Jsonclick ;
      private string edtavCmapeolistadoreferencianombre_Internalname ;
      private string TempTags ;
      private string edtavCmapeolistadoreferencianombre_Jsonclick ;
      private string divMapeolistadoreferenciaestadofiltercontainer_Internalname ;
      private string lblLblmapeolistadoreferenciaestadofilter_Internalname ;
      private string lblLblmapeolistadoreferenciaestadofilter_Jsonclick ;
      private string cmbavCmapeolistadoreferenciaestado_Internalname ;
      private string cmbavCmapeolistadoreferenciaestado_Jsonclick ;
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
      private string A920MapeoListadoReferenciaId ;
      private string edtMapeoListadoReferenciaId_Internalname ;
      private string edtMapeoID_Internalname ;
      private string edtRubrosId_Internalname ;
      private string dynMedidasID_Internalname ;
      private string dynInventarioId_Internalname ;
      private string gxwrpcisep ;
      private string lV6cMapeoListadoReferenciaNombre ;
      private string lV7cMapeoListadoReferenciaEstado ;
      private string A928MapeoListadoReferenciaNombre ;
      private string A929MapeoListadoReferenciaEstado ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_34_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtMapeoListadoReferenciaId_Jsonclick ;
      private string edtMapeoID_Jsonclick ;
      private string edtRubrosId_Jsonclick ;
      private string GXCCtl ;
      private string dynMedidasID_Jsonclick ;
      private string dynInventarioId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_34_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n929MapeoListadoReferenciaEstado ;
      private bool n928MapeoListadoReferenciaNombre ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV14Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCmapeolistadoreferenciaestado ;
      private GXCombobox dynMedidasID ;
      private GXCombobox dynInventarioId ;
      private IDataStoreProvider pr_default ;
      private short[] H00JE2_A121RubrosId ;
      private long[] H00JE2_A137MedidasID ;
      private string[] H00JE2_A138MedidasNombre ;
      private string[] H00JE2_A139MedidasEstado ;
      private bool[] H00JE2_n139MedidasEstado ;
      private short[] H00JE3_A121RubrosId ;
      private long[] H00JE3_A137MedidasID ;
      private long[] H00JE3_A135InventarioId ;
      private string[] H00JE3_A136InventarioNombre ;
      private string[] H00JE3_A107EstadosTipo ;
      private int[] H00JE3_A108EstadosGenericosId ;
      private string[] H00JE4_A929MapeoListadoReferenciaEstado ;
      private bool[] H00JE4_n929MapeoListadoReferenciaEstado ;
      private string[] H00JE4_A928MapeoListadoReferenciaNombre ;
      private bool[] H00JE4_n928MapeoListadoReferenciaNombre ;
      private long[] H00JE4_A135InventarioId ;
      private long[] H00JE4_A137MedidasID ;
      private short[] H00JE4_A121RubrosId ;
      private long[] H00JE4_A918MapeoID ;
      private string[] H00JE4_A920MapeoListadoReferenciaId ;
      private long[] H00JE5_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP4_pMapeoListadoReferenciaId ;
   }

   public class gx03s4__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00JE4( IGxContext context ,
                                             string AV6cMapeoListadoReferenciaNombre ,
                                             string AV7cMapeoListadoReferenciaEstado ,
                                             string A928MapeoListadoReferenciaNombre ,
                                             string A929MapeoListadoReferenciaEstado ,
                                             long AV8pMapeoID ,
                                             short AV9pRubrosId ,
                                             long AV10pMedidasID ,
                                             long AV11pInventarioId ,
                                             long A918MapeoID ,
                                             short A121RubrosId ,
                                             long A137MedidasID ,
                                             long A135InventarioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [MapeoListadoReferenciaEstado], [MapeoListadoReferenciaNombre], [InventarioId], [MedidasID], [RubrosId], [MapeoID], [MapeoListadoReferenciaId]";
         sFromString = " FROM [MapeoListadoReferencia]";
         sOrderString = "";
         AddWhere(sWhereString, "([MapeoID] = @AV8pMapeoID and [RubrosId] = @AV9pRubrosId and [MedidasID] = @AV10pMedidasID and [InventarioId] = @AV11pInventarioId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6cMapeoListadoReferenciaNombre)) )
         {
            AddWhere(sWhereString, "([MapeoListadoReferenciaNombre] like @lV6cMapeoListadoReferenciaNombre)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cMapeoListadoReferenciaEstado)) )
         {
            AddWhere(sWhereString, "([MapeoListadoReferenciaEstado] like @lV7cMapeoListadoReferenciaEstado)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [MapeoID], [RubrosId], [MedidasID], [InventarioId], [MapeoListadoReferenciaId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00JE5( IGxContext context ,
                                             string AV6cMapeoListadoReferenciaNombre ,
                                             string AV7cMapeoListadoReferenciaEstado ,
                                             string A928MapeoListadoReferenciaNombre ,
                                             string A929MapeoListadoReferenciaEstado ,
                                             long AV8pMapeoID ,
                                             short AV9pRubrosId ,
                                             long AV10pMedidasID ,
                                             long AV11pInventarioId ,
                                             long A918MapeoID ,
                                             short A121RubrosId ,
                                             long A137MedidasID ,
                                             long A135InventarioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [MapeoListadoReferencia]";
         AddWhere(sWhereString, "([MapeoID] = @AV8pMapeoID and [RubrosId] = @AV9pRubrosId and [MedidasID] = @AV10pMedidasID and [InventarioId] = @AV11pInventarioId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6cMapeoListadoReferenciaNombre)) )
         {
            AddWhere(sWhereString, "([MapeoListadoReferenciaNombre] like @lV6cMapeoListadoReferenciaNombre)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cMapeoListadoReferenciaEstado)) )
         {
            AddWhere(sWhereString, "([MapeoListadoReferenciaEstado] like @lV7cMapeoListadoReferenciaEstado)");
         }
         else
         {
            GXv_int3[5] = 1;
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
               case 2 :
                     return conditional_H00JE4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (long)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] );
               case 3 :
                     return conditional_H00JE5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (long)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00JE2;
          prmH00JE2 = new Object[] {
          };
          Object[] prmH00JE3;
          prmH00JE3 = new Object[] {
          };
          Object[] prmH00JE4;
          prmH00JE4 = new Object[] {
          new ParDef("@AV8pMapeoID",GXType.Decimal,18,0) ,
          new ParDef("@AV9pRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV10pMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV11pInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@lV6cMapeoListadoReferenciaNombre",GXType.NChar,80,0) ,
          new ParDef("@lV7cMapeoListadoReferenciaEstado",GXType.NChar,3,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00JE5;
          prmH00JE5 = new Object[] {
          new ParDef("@AV8pMapeoID",GXType.Decimal,18,0) ,
          new ParDef("@AV9pRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV10pMedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV11pInventarioId",GXType.Decimal,18,0) ,
          new ParDef("@lV6cMapeoListadoReferenciaNombre",GXType.NChar,80,0) ,
          new ParDef("@lV7cMapeoListadoReferenciaEstado",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00JE2", "SELECT [RubrosId], [MedidasID], [MedidasNombre], [MedidasEstado] FROM [RubrosMedidas] WHERE [MedidasEstado] <> 'DES' ORDER BY [MedidasNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JE2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00JE3", "SELECT [RubrosId], [MedidasID], [InventarioId], [InventarioNombre], [EstadosTipo], [EstadosGenericosId] FROM [Inventario] WHERE [EstadosGenericosId] = 1 ORDER BY [InventarioNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JE3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00JE4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JE4,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00JE5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JE5,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 120);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

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
   public class gx03j0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx03j0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx03j0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pPublicacionesId )
      {
         this.AV13pPublicacionesId = 0 ;
         ExecutePrivate();
         aP0_pPublicacionesId=this.AV13pPublicacionesId;
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
            gxfirstwebparm = GetFirstPar( "pPublicacionesId");
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
               gxfirstwebparm = GetFirstPar( "pPublicacionesId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pPublicacionesId");
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
               AV13pPublicacionesId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pPublicacionesId", StringUtil.LTrimStr( (decimal)(AV13pPublicacionesId), 18, 0));
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
         AV6cPublicacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "cPublicacionesId"), "."), 18, MidpointRounding.ToEven));
         AV7cPublicacionesTitulo = GetPar( "cPublicacionesTitulo");
         AV8cDepartamentoId = (long)(Math.Round(NumberUtil.Val( GetPar( "cDepartamentoId"), "."), 18, MidpointRounding.ToEven));
         AV9cDepartamentoMunicipioId = (long)(Math.Round(NumberUtil.Val( GetPar( "cDepartamentoMunicipioId"), "."), 18, MidpointRounding.ToEven));
         AV10cPublicacionesFecTentInicio = context.localUtil.ParseDateParm( GetPar( "cPublicacionesFecTentInicio"));
         AV11cPublicacionesFecRealInicio = context.localUtil.ParseDateParm( GetPar( "cPublicacionesFecRealInicio"));
         AV12cPublicacionesFecFinPostulacion = context.localUtil.ParseDateParm( GetPar( "cPublicacionesFecFinPostulacion"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cPublicacionesId, AV7cPublicacionesTitulo, AV8cDepartamentoId, AV9cDepartamentoMunicipioId, AV10cPublicacionesFecTentInicio, AV11cPublicacionesFecRealInicio, AV12cPublicacionesFecFinPostulacion) ;
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
         PAIG2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTIG2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx03j0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pPublicacionesId,18,0))}, new string[] {"pPublicacionesId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPUBLICACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cPublicacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPUBLICACIONESTITULO", StringUtil.RTrim( AV7cPublicacionesTitulo));
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOMUNICIPIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cDepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPUBLICACIONESFECTENTINICIO", context.localUtil.Format(AV10cPublicacionesFecTentInicio, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCPUBLICACIONESFECREALINICIO", context.localUtil.Format(AV11cPublicacionesFecRealInicio, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCPUBLICACIONESFECFINPOSTULACION", context.localUtil.Format(AV12cPublicacionesFecFinPostulacion, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPPUBLICACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pPublicacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PUBLICACIONESIDFILTERCONTAINER_Class", StringUtil.RTrim( divPublicacionesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PUBLICACIONESTITULOFILTERCONTAINER_Class", StringUtil.RTrim( divPublicacionestitulofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOMUNICIPIOIDFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentomunicipioidfiltercontainer_Class));
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
            WEIG2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTIG2( ) ;
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
         return formatLink("gx03j0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pPublicacionesId,18,0))}, new string[] {"pPublicacionesId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx03J0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Publicaciones", "") ;
      }

      protected void WBIG0( )
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
            GxWebStd.gx_div_start( context, divPublicacionesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPublicacionesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpublicacionesidfilter_Internalname, context.GetMessage( "Referencia", ""), "", "", lblLblpublicacionesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11ig1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03J0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpublicacionesid_Internalname, context.GetMessage( "Referencia", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpublicacionesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cPublicacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCpublicacionesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cPublicacionesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cPublicacionesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpublicacionesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpublicacionesid_Visible, edtavCpublicacionesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03J0.htm");
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
            GxWebStd.gx_div_start( context, divPublicacionestitulofiltercontainer_Internalname, 1, 0, "px", 0, "px", divPublicacionestitulofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpublicacionestitulofilter_Internalname, context.GetMessage( "Título", ""), "", "", lblLblpublicacionestitulofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12ig1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03J0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpublicacionestitulo_Internalname, context.GetMessage( "Título", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpublicacionestitulo_Internalname, StringUtil.RTrim( AV7cPublicacionesTitulo), StringUtil.RTrim( context.localUtil.Format( AV7cPublicacionesTitulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpublicacionestitulo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpublicacionestitulo_Visible, edtavCpublicacionestitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx03J0.htm");
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
            GxWebStd.gx_div_start( context, divDepartamentoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentoidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentoidfilter_Internalname, context.GetMessage( "Departamento", ""), "", "", lblLbldepartamentoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13ig1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03J0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdepartamentoid_Internalname, context.GetMessage( "Departamento", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdepartamentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cDepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCdepartamentoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cDepartamentoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8cDepartamentoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdepartamentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdepartamentoid_Visible, edtavCdepartamentoid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03J0.htm");
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
            GxWebStd.gx_div_start( context, divDepartamentomunicipioidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentomunicipioidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentomunicipioidfilter_Internalname, context.GetMessage( "Identificador", ""), "", "", lblLbldepartamentomunicipioidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14ig1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx03J0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdepartamentomunicipioid_Internalname, context.GetMessage( "Identificador", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdepartamentomunicipioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cDepartamentoMunicipioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCdepartamentomunicipioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cDepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV9cDepartamentoMunicipioId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdepartamentomunicipioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdepartamentomunicipioid_Visible, edtavCdepartamentomunicipioid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03J0.htm");
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
            GxWebStd.gx_div_start( context, divPublicacionesfectentiniciofiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpublicacionesfectentiniciofilter_Internalname, context.GetMessage( "Publicaciones Fec Tent Inicio", ""), "", "", lblLblpublicacionesfectentiniciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx03J0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpublicacionesfectentinicio_Internalname, context.GetMessage( "Publicaciones Fec Tent Inicio", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCpublicacionesfectentinicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCpublicacionesfectentinicio_Internalname, context.localUtil.Format(AV10cPublicacionesFecTentInicio, "99/99/99"), context.localUtil.Format( AV10cPublicacionesFecTentInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpublicacionesfectentinicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCpublicacionesfectentinicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03J0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divPublicacionesfecrealiniciofiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpublicacionesfecrealiniciofilter_Internalname, context.GetMessage( "Publicaciones Fec Real Inicio", ""), "", "", lblLblpublicacionesfecrealiniciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx03J0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpublicacionesfecrealinicio_Internalname, context.GetMessage( "Publicaciones Fec Real Inicio", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCpublicacionesfecrealinicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCpublicacionesfecrealinicio_Internalname, context.localUtil.Format(AV11cPublicacionesFecRealInicio, "99/99/99"), context.localUtil.Format( AV11cPublicacionesFecRealInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpublicacionesfecrealinicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCpublicacionesfecrealinicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03J0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divPublicacionesfecfinpostulacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpublicacionesfecfinpostulacionfilter_Internalname, context.GetMessage( "Publicaciones Fec Fin Postulacion", ""), "", "", lblLblpublicacionesfecfinpostulacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx03J0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpublicacionesfecfinpostulacion_Internalname, context.GetMessage( "Publicaciones Fec Fin Postulacion", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCpublicacionesfecfinpostulacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCpublicacionesfecfinpostulacion_Internalname, context.localUtil.Format(AV12cPublicacionesFecFinPostulacion, "99/99/99"), context.localUtil.Format( AV12cPublicacionesFecFinPostulacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',0,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpublicacionesfecfinpostulacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCpublicacionesfecfinpostulacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx03J0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e15ig1_client"+"'", TempTags, "", 2, "HLP_Gx03J0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx03J0.htm");
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

      protected void STARTIG2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Publicaciones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPIG0( ) ;
      }

      protected void WSIG2( )
      {
         STARTIG2( ) ;
         EVTIG2( ) ;
      }

      protected void EVTIG2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A381PublicacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPublicacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A382PublicacionesTitulo = cgiGet( edtPublicacionesTitulo_Internalname);
                              A112DepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E16IG2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E17IG2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cpublicacionesid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPUBLICACIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cPublicacionesId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpublicacionestitulo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPUBLICACIONESTITULO"), AV7cPublicacionesTitulo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cDepartamentoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentomunicipioid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOMUNICIPIOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV9cDepartamentoMunicipioId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpublicacionesfectentinicio Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCPUBLICACIONESFECTENTINICIO"), 0) != AV10cPublicacionesFecTentInicio )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpublicacionesfecrealinicio Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCPUBLICACIONESFECREALINICIO"), 0) != AV11cPublicacionesFecRealInicio )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpublicacionesfecfinpostulacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCPUBLICACIONESFECFINPOSTULACION"), 0) != AV12cPublicacionesFecFinPostulacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E18IG2 ();
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

      protected void WEIG2( )
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

      protected void PAIG2( )
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
                                        long AV6cPublicacionesId ,
                                        string AV7cPublicacionesTitulo ,
                                        long AV8cDepartamentoId ,
                                        long AV9cDepartamentoMunicipioId ,
                                        DateTime AV10cPublicacionesFecTentInicio ,
                                        DateTime AV11cPublicacionesFecRealInicio ,
                                        DateTime AV12cPublicacionesFecFinPostulacion )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFIG2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PUBLICACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A381PublicacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PUBLICACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A381PublicacionesId), 18, 0, ".", "")));
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
         RFIG2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFIG2( )
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
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cPublicacionesTitulo ,
                                                 AV8cDepartamentoId ,
                                                 AV9cDepartamentoMunicipioId ,
                                                 AV10cPublicacionesFecTentInicio ,
                                                 AV11cPublicacionesFecRealInicio ,
                                                 AV12cPublicacionesFecFinPostulacion ,
                                                 A382PublicacionesTitulo ,
                                                 A112DepartamentoId ,
                                                 A114DepartamentoMunicipioId ,
                                                 A843PublicacionesFecTentInicio ,
                                                 A844PublicacionesFecRealInicio ,
                                                 A845PublicacionesFecFinPostulacion ,
                                                 AV6cPublicacionesId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.LONG
                                                 }
            });
            lV7cPublicacionesTitulo = StringUtil.PadR( StringUtil.RTrim( AV7cPublicacionesTitulo), 80, "%");
            /* Using cursor H00IG2 */
            pr_default.execute(0, new Object[] {AV6cPublicacionesId, lV7cPublicacionesTitulo, AV8cDepartamentoId, AV9cDepartamentoMunicipioId, AV10cPublicacionesFecTentInicio, AV11cPublicacionesFecRealInicio, AV12cPublicacionesFecFinPostulacion, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A845PublicacionesFecFinPostulacion = H00IG2_A845PublicacionesFecFinPostulacion[0];
               A844PublicacionesFecRealInicio = H00IG2_A844PublicacionesFecRealInicio[0];
               A843PublicacionesFecTentInicio = H00IG2_A843PublicacionesFecTentInicio[0];
               A114DepartamentoMunicipioId = H00IG2_A114DepartamentoMunicipioId[0];
               A112DepartamentoId = H00IG2_A112DepartamentoId[0];
               A382PublicacionesTitulo = H00IG2_A382PublicacionesTitulo[0];
               A381PublicacionesId = H00IG2_A381PublicacionesId[0];
               /* Execute user event: Load */
               E17IG2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WBIG0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesIG2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PUBLICACIONESID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A381PublicacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cPublicacionesTitulo ,
                                              AV8cDepartamentoId ,
                                              AV9cDepartamentoMunicipioId ,
                                              AV10cPublicacionesFecTentInicio ,
                                              AV11cPublicacionesFecRealInicio ,
                                              AV12cPublicacionesFecFinPostulacion ,
                                              A382PublicacionesTitulo ,
                                              A112DepartamentoId ,
                                              A114DepartamentoMunicipioId ,
                                              A843PublicacionesFecTentInicio ,
                                              A844PublicacionesFecRealInicio ,
                                              A845PublicacionesFecFinPostulacion ,
                                              AV6cPublicacionesId } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.LONG
                                              }
         });
         lV7cPublicacionesTitulo = StringUtil.PadR( StringUtil.RTrim( AV7cPublicacionesTitulo), 80, "%");
         /* Using cursor H00IG3 */
         pr_default.execute(1, new Object[] {AV6cPublicacionesId, lV7cPublicacionesTitulo, AV8cDepartamentoId, AV9cDepartamentoMunicipioId, AV10cPublicacionesFecTentInicio, AV11cPublicacionesFecRealInicio, AV12cPublicacionesFecFinPostulacion});
         GRID1_nRecordCount = H00IG3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPublicacionesId, AV7cPublicacionesTitulo, AV8cDepartamentoId, AV9cDepartamentoMunicipioId, AV10cPublicacionesFecTentInicio, AV11cPublicacionesFecRealInicio, AV12cPublicacionesFecFinPostulacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPublicacionesId, AV7cPublicacionesTitulo, AV8cDepartamentoId, AV9cDepartamentoMunicipioId, AV10cPublicacionesFecTentInicio, AV11cPublicacionesFecRealInicio, AV12cPublicacionesFecFinPostulacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPublicacionesId, AV7cPublicacionesTitulo, AV8cDepartamentoId, AV9cDepartamentoMunicipioId, AV10cPublicacionesFecTentInicio, AV11cPublicacionesFecRealInicio, AV12cPublicacionesFecFinPostulacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPublicacionesId, AV7cPublicacionesTitulo, AV8cDepartamentoId, AV9cDepartamentoMunicipioId, AV10cPublicacionesFecTentInicio, AV11cPublicacionesFecRealInicio, AV12cPublicacionesFecFinPostulacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPublicacionesId, AV7cPublicacionesTitulo, AV8cDepartamentoId, AV9cDepartamentoMunicipioId, AV10cPublicacionesFecTentInicio, AV11cPublicacionesFecRealInicio, AV12cPublicacionesFecFinPostulacion) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtPublicacionesId_Enabled = 0;
         edtPublicacionesTitulo_Enabled = 0;
         edtDepartamentoId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPIG0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16IG2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpublicacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpublicacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPUBLICACIONESID");
               GX_FocusControl = edtavCpublicacionesid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cPublicacionesId = 0;
               AssignAttri("", false, "AV6cPublicacionesId", StringUtil.LTrimStr( (decimal)(AV6cPublicacionesId), 18, 0));
            }
            else
            {
               AV6cPublicacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCpublicacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cPublicacionesId", StringUtil.LTrimStr( (decimal)(AV6cPublicacionesId), 18, 0));
            }
            AV7cPublicacionesTitulo = cgiGet( edtavCpublicacionestitulo_Internalname);
            AssignAttri("", false, "AV7cPublicacionesTitulo", AV7cPublicacionesTitulo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDEPARTAMENTOID");
               GX_FocusControl = edtavCdepartamentoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cDepartamentoId = 0;
               AssignAttri("", false, "AV8cDepartamentoId", StringUtil.LTrimStr( (decimal)(AV8cDepartamentoId), 18, 0));
            }
            else
            {
               AV8cDepartamentoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cDepartamentoId", StringUtil.LTrimStr( (decimal)(AV8cDepartamentoId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentomunicipioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentomunicipioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDEPARTAMENTOMUNICIPIOID");
               GX_FocusControl = edtavCdepartamentomunicipioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cDepartamentoMunicipioId = 0;
               AssignAttri("", false, "AV9cDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV9cDepartamentoMunicipioId), 18, 0));
            }
            else
            {
               AV9cDepartamentoMunicipioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCdepartamentomunicipioid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9cDepartamentoMunicipioId", StringUtil.LTrimStr( (decimal)(AV9cDepartamentoMunicipioId), 18, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCpublicacionesfectentinicio_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Publicaciones Fec Tent Inicio", "")}), 1, "vCPUBLICACIONESFECTENTINICIO");
               GX_FocusControl = edtavCpublicacionesfectentinicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cPublicacionesFecTentInicio = DateTime.MinValue;
               AssignAttri("", false, "AV10cPublicacionesFecTentInicio", context.localUtil.Format(AV10cPublicacionesFecTentInicio, "99/99/99"));
            }
            else
            {
               AV10cPublicacionesFecTentInicio = context.localUtil.CToD( cgiGet( edtavCpublicacionesfectentinicio_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV10cPublicacionesFecTentInicio", context.localUtil.Format(AV10cPublicacionesFecTentInicio, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCpublicacionesfecrealinicio_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Publicaciones Fec Real Inicio", "")}), 1, "vCPUBLICACIONESFECREALINICIO");
               GX_FocusControl = edtavCpublicacionesfecrealinicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cPublicacionesFecRealInicio = DateTime.MinValue;
               AssignAttri("", false, "AV11cPublicacionesFecRealInicio", context.localUtil.Format(AV11cPublicacionesFecRealInicio, "99/99/99"));
            }
            else
            {
               AV11cPublicacionesFecRealInicio = context.localUtil.CToD( cgiGet( edtavCpublicacionesfecrealinicio_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV11cPublicacionesFecRealInicio", context.localUtil.Format(AV11cPublicacionesFecRealInicio, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCpublicacionesfecfinpostulacion_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {context.GetMessage( "Publicaciones Fec Fin Postulacion", "")}), 1, "vCPUBLICACIONESFECFINPOSTULACION");
               GX_FocusControl = edtavCpublicacionesfecfinpostulacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cPublicacionesFecFinPostulacion = DateTime.MinValue;
               AssignAttri("", false, "AV12cPublicacionesFecFinPostulacion", context.localUtil.Format(AV12cPublicacionesFecFinPostulacion, "99/99/99"));
            }
            else
            {
               AV12cPublicacionesFecFinPostulacion = context.localUtil.CToD( cgiGet( edtavCpublicacionesfecfinpostulacion_Internalname), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AssignAttri("", false, "AV12cPublicacionesFecFinPostulacion", context.localUtil.Format(AV12cPublicacionesFecFinPostulacion, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPUBLICACIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cPublicacionesId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPUBLICACIONESTITULO"), AV7cPublicacionesTitulo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV8cDepartamentoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOMUNICIPIOID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV9cDepartamentoMunicipioId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCPUBLICACIONESFECTENTINICIO"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV10cPublicacionesFecTentInicio ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCPUBLICACIONESFECREALINICIO"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV11cPublicacionesFecRealInicio ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCPUBLICACIONESFECFINPOSTULACION"), DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))) ) != DateTimeUtil.ResetTime ( AV12cPublicacionesFecFinPostulacion ) )
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
         E16IG2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16IG2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Publicaciones", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E17IG2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E18IG2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18IG2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pPublicacionesId = A381PublicacionesId;
         AssignAttri("", false, "AV13pPublicacionesId", StringUtil.LTrimStr( (decimal)(AV13pPublicacionesId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pPublicacionesId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pPublicacionesId"});
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
         AV13pPublicacionesId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pPublicacionesId", StringUtil.LTrimStr( (decimal)(AV13pPublicacionesId), 18, 0));
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
         PAIG2( ) ;
         WSIG2( ) ;
         WEIG2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021262311", true, true, false);
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
         context.AddJavascriptSource("gx03j0.js", "?202673021262311", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtPublicacionesId_Internalname = "PUBLICACIONESID_"+sGXsfl_84_idx;
         edtPublicacionesTitulo_Internalname = "PUBLICACIONESTITULO_"+sGXsfl_84_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtPublicacionesId_Internalname = "PUBLICACIONESID_"+sGXsfl_84_fel_idx;
         edtPublicacionesTitulo_Internalname = "PUBLICACIONESTITULO_"+sGXsfl_84_fel_idx;
         edtDepartamentoId_Internalname = "DEPARTAMENTOID_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WBIG0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A381PublicacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPublicacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A381PublicacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A381PublicacionesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPublicacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtPublicacionesTitulo_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A381PublicacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtPublicacionesTitulo_Internalname, "Link", edtPublicacionesTitulo_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPublicacionesTitulo_Internalname,StringUtil.RTrim( A382PublicacionesTitulo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtPublicacionesTitulo_Link,(string)"",(string)"",(string)"",(string)edtPublicacionesTitulo_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDepartamentoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A112DepartamentoId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDepartamentoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesIG2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
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
            context.SendWebValue( context.GetMessage( "Referencia:", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Título", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Departamento", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A381PublicacionesId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A382PublicacionesTitulo)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtPublicacionesTitulo_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A112DepartamentoId), 18, 0, ".", ""))));
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
         lblLblpublicacionesidfilter_Internalname = "LBLPUBLICACIONESIDFILTER";
         edtavCpublicacionesid_Internalname = "vCPUBLICACIONESID";
         divPublicacionesidfiltercontainer_Internalname = "PUBLICACIONESIDFILTERCONTAINER";
         lblLblpublicacionestitulofilter_Internalname = "LBLPUBLICACIONESTITULOFILTER";
         edtavCpublicacionestitulo_Internalname = "vCPUBLICACIONESTITULO";
         divPublicacionestitulofiltercontainer_Internalname = "PUBLICACIONESTITULOFILTERCONTAINER";
         lblLbldepartamentoidfilter_Internalname = "LBLDEPARTAMENTOIDFILTER";
         edtavCdepartamentoid_Internalname = "vCDEPARTAMENTOID";
         divDepartamentoidfiltercontainer_Internalname = "DEPARTAMENTOIDFILTERCONTAINER";
         lblLbldepartamentomunicipioidfilter_Internalname = "LBLDEPARTAMENTOMUNICIPIOIDFILTER";
         edtavCdepartamentomunicipioid_Internalname = "vCDEPARTAMENTOMUNICIPIOID";
         divDepartamentomunicipioidfiltercontainer_Internalname = "DEPARTAMENTOMUNICIPIOIDFILTERCONTAINER";
         lblLblpublicacionesfectentiniciofilter_Internalname = "LBLPUBLICACIONESFECTENTINICIOFILTER";
         edtavCpublicacionesfectentinicio_Internalname = "vCPUBLICACIONESFECTENTINICIO";
         divPublicacionesfectentiniciofiltercontainer_Internalname = "PUBLICACIONESFECTENTINICIOFILTERCONTAINER";
         lblLblpublicacionesfecrealiniciofilter_Internalname = "LBLPUBLICACIONESFECREALINICIOFILTER";
         edtavCpublicacionesfecrealinicio_Internalname = "vCPUBLICACIONESFECREALINICIO";
         divPublicacionesfecrealiniciofiltercontainer_Internalname = "PUBLICACIONESFECREALINICIOFILTERCONTAINER";
         lblLblpublicacionesfecfinpostulacionfilter_Internalname = "LBLPUBLICACIONESFECFINPOSTULACIONFILTER";
         edtavCpublicacionesfecfinpostulacion_Internalname = "vCPUBLICACIONESFECFINPOSTULACION";
         divPublicacionesfecfinpostulacionfiltercontainer_Internalname = "PUBLICACIONESFECFINPOSTULACIONFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtPublicacionesId_Internalname = "PUBLICACIONESID";
         edtPublicacionesTitulo_Internalname = "PUBLICACIONESTITULO";
         edtDepartamentoId_Internalname = "DEPARTAMENTOID";
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
         edtDepartamentoId_Jsonclick = "";
         edtPublicacionesTitulo_Jsonclick = "";
         edtPublicacionesTitulo_Link = "";
         edtPublicacionesId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtDepartamentoId_Enabled = 0;
         edtPublicacionesTitulo_Enabled = 0;
         edtPublicacionesId_Enabled = 0;
         edtavCpublicacionesfecfinpostulacion_Jsonclick = "";
         edtavCpublicacionesfecfinpostulacion_Enabled = 1;
         edtavCpublicacionesfecrealinicio_Jsonclick = "";
         edtavCpublicacionesfecrealinicio_Enabled = 1;
         edtavCpublicacionesfectentinicio_Jsonclick = "";
         edtavCpublicacionesfectentinicio_Enabled = 1;
         edtavCdepartamentomunicipioid_Jsonclick = "";
         edtavCdepartamentomunicipioid_Enabled = 1;
         edtavCdepartamentomunicipioid_Visible = 1;
         edtavCdepartamentoid_Jsonclick = "";
         edtavCdepartamentoid_Enabled = 1;
         edtavCdepartamentoid_Visible = 1;
         edtavCpublicacionestitulo_Jsonclick = "";
         edtavCpublicacionestitulo_Enabled = 1;
         edtavCpublicacionestitulo_Visible = 1;
         edtavCpublicacionesid_Jsonclick = "";
         edtavCpublicacionesid_Enabled = 1;
         edtavCpublicacionesid_Visible = 1;
         divDepartamentomunicipioidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divDepartamentoidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divPublicacionestitulofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divPublicacionesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Publicaciones", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPublicacionesId',fld:'vCPUBLICACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cPublicacionesTitulo',fld:'vCPUBLICACIONESTITULO',pic:'',type:'char'},{av:'AV8cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cPublicacionesFecTentInicio',fld:'vCPUBLICACIONESFECTENTINICIO',pic:'',type:'date'},{av:'AV11cPublicacionesFecRealInicio',fld:'vCPUBLICACIONESFECREALINICIO',pic:'',type:'date'},{av:'AV12cPublicacionesFecFinPostulacion',fld:'vCPUBLICACIONESFECFINPOSTULACION',pic:'',type:'date'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E15IG1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPUBLICACIONESIDFILTER.CLICK","{handler:'E11IG1',iparms:[{av:'divPublicacionesidfiltercontainer_Class',ctrl:'PUBLICACIONESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPUBLICACIONESIDFILTER.CLICK",",oparms:[{av:'divPublicacionesidfiltercontainer_Class',ctrl:'PUBLICACIONESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCpublicacionesid_Visible',ctrl:'vCPUBLICACIONESID',prop:'Visible'}]}");
         setEventMetadata("LBLPUBLICACIONESTITULOFILTER.CLICK","{handler:'E12IG1',iparms:[{av:'divPublicacionestitulofiltercontainer_Class',ctrl:'PUBLICACIONESTITULOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPUBLICACIONESTITULOFILTER.CLICK",",oparms:[{av:'divPublicacionestitulofiltercontainer_Class',ctrl:'PUBLICACIONESTITULOFILTERCONTAINER',prop:'Class'},{av:'edtavCpublicacionestitulo_Visible',ctrl:'vCPUBLICACIONESTITULO',prop:'Visible'}]}");
         setEventMetadata("LBLDEPARTAMENTOIDFILTER.CLICK","{handler:'E13IG1',iparms:[{av:'divDepartamentoidfiltercontainer_Class',ctrl:'DEPARTAMENTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOIDFILTER.CLICK",",oparms:[{av:'divDepartamentoidfiltercontainer_Class',ctrl:'DEPARTAMENTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCdepartamentoid_Visible',ctrl:'vCDEPARTAMENTOID',prop:'Visible'}]}");
         setEventMetadata("LBLDEPARTAMENTOMUNICIPIOIDFILTER.CLICK","{handler:'E14IG1',iparms:[{av:'divDepartamentomunicipioidfiltercontainer_Class',ctrl:'DEPARTAMENTOMUNICIPIOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOMUNICIPIOIDFILTER.CLICK",",oparms:[{av:'divDepartamentomunicipioidfiltercontainer_Class',ctrl:'DEPARTAMENTOMUNICIPIOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCdepartamentomunicipioid_Visible',ctrl:'vCDEPARTAMENTOMUNICIPIOID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E18IG2',iparms:[{av:'A381PublicacionesId',fld:'PUBLICACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pPublicacionesId',fld:'vPPUBLICACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPublicacionesId',fld:'vCPUBLICACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cPublicacionesTitulo',fld:'vCPUBLICACIONESTITULO',pic:'',type:'char'},{av:'AV8cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cPublicacionesFecTentInicio',fld:'vCPUBLICACIONESFECTENTINICIO',pic:'',type:'date'},{av:'AV11cPublicacionesFecRealInicio',fld:'vCPUBLICACIONESFECREALINICIO',pic:'',type:'date'},{av:'AV12cPublicacionesFecFinPostulacion',fld:'vCPUBLICACIONESFECFINPOSTULACION',pic:'',type:'date'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPublicacionesId',fld:'vCPUBLICACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cPublicacionesTitulo',fld:'vCPUBLICACIONESTITULO',pic:'',type:'char'},{av:'AV8cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cPublicacionesFecTentInicio',fld:'vCPUBLICACIONESFECTENTINICIO',pic:'',type:'date'},{av:'AV11cPublicacionesFecRealInicio',fld:'vCPUBLICACIONESFECREALINICIO',pic:'',type:'date'},{av:'AV12cPublicacionesFecFinPostulacion',fld:'vCPUBLICACIONESFECFINPOSTULACION',pic:'',type:'date'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPublicacionesId',fld:'vCPUBLICACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cPublicacionesTitulo',fld:'vCPUBLICACIONESTITULO',pic:'',type:'char'},{av:'AV8cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cPublicacionesFecTentInicio',fld:'vCPUBLICACIONESFECTENTINICIO',pic:'',type:'date'},{av:'AV11cPublicacionesFecRealInicio',fld:'vCPUBLICACIONESFECREALINICIO',pic:'',type:'date'},{av:'AV12cPublicacionesFecFinPostulacion',fld:'vCPUBLICACIONESFECFINPOSTULACION',pic:'',type:'date'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPublicacionesId',fld:'vCPUBLICACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cPublicacionesTitulo',fld:'vCPUBLICACIONESTITULO',pic:'',type:'char'},{av:'AV8cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV9cDepartamentoMunicipioId',fld:'vCDEPARTAMENTOMUNICIPIOID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cPublicacionesFecTentInicio',fld:'vCPUBLICACIONESFECTENTINICIO',pic:'',type:'date'},{av:'AV11cPublicacionesFecRealInicio',fld:'vCPUBLICACIONESFECREALINICIO',pic:'',type:'date'},{av:'AV12cPublicacionesFecFinPostulacion',fld:'vCPUBLICACIONESFECFINPOSTULACION',pic:'',type:'date'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CPUBLICACIONESFECTENTINICIO","{handler:'Validv_Cpublicacionesfectentinicio',iparms:[]");
         setEventMetadata("VALIDV_CPUBLICACIONESFECTENTINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_CPUBLICACIONESFECREALINICIO","{handler:'Validv_Cpublicacionesfecrealinicio',iparms:[]");
         setEventMetadata("VALIDV_CPUBLICACIONESFECREALINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_CPUBLICACIONESFECFINPOSTULACION","{handler:'Validv_Cpublicacionesfecfinpostulacion',iparms:[]");
         setEventMetadata("VALIDV_CPUBLICACIONESFECFINPOSTULACION",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Departamentoid',iparms:[]");
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
         AV7cPublicacionesTitulo = "";
         AV10cPublicacionesFecTentInicio = DateTime.MinValue;
         AV11cPublicacionesFecRealInicio = DateTime.MinValue;
         AV12cPublicacionesFecFinPostulacion = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblpublicacionesidfilter_Jsonclick = "";
         TempTags = "";
         lblLblpublicacionestitulofilter_Jsonclick = "";
         lblLbldepartamentoidfilter_Jsonclick = "";
         lblLbldepartamentomunicipioidfilter_Jsonclick = "";
         lblLblpublicacionesfectentiniciofilter_Jsonclick = "";
         lblLblpublicacionesfecrealiniciofilter_Jsonclick = "";
         lblLblpublicacionesfecfinpostulacionfilter_Jsonclick = "";
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
         A382PublicacionesTitulo = "";
         lV7cPublicacionesTitulo = "";
         A843PublicacionesFecTentInicio = DateTime.MinValue;
         A844PublicacionesFecRealInicio = DateTime.MinValue;
         A845PublicacionesFecFinPostulacion = DateTime.MinValue;
         H00IG2_A845PublicacionesFecFinPostulacion = new DateTime[] {DateTime.MinValue} ;
         H00IG2_A844PublicacionesFecRealInicio = new DateTime[] {DateTime.MinValue} ;
         H00IG2_A843PublicacionesFecTentInicio = new DateTime[] {DateTime.MinValue} ;
         H00IG2_A114DepartamentoMunicipioId = new long[1] ;
         H00IG2_A112DepartamentoId = new long[1] ;
         H00IG2_A382PublicacionesTitulo = new string[] {""} ;
         H00IG2_A381PublicacionesId = new long[1] ;
         H00IG3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx03j0__default(),
            new Object[][] {
                new Object[] {
               H00IG2_A845PublicacionesFecFinPostulacion, H00IG2_A844PublicacionesFecRealInicio, H00IG2_A843PublicacionesFecTentInicio, H00IG2_A114DepartamentoMunicipioId, H00IG2_A112DepartamentoId, H00IG2_A382PublicacionesTitulo, H00IG2_A381PublicacionesId
               }
               , new Object[] {
               H00IG3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
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
      private int edtavCpublicacionesid_Enabled ;
      private int edtavCpublicacionesid_Visible ;
      private int edtavCpublicacionestitulo_Visible ;
      private int edtavCpublicacionestitulo_Enabled ;
      private int edtavCdepartamentoid_Enabled ;
      private int edtavCdepartamentoid_Visible ;
      private int edtavCdepartamentomunicipioid_Enabled ;
      private int edtavCdepartamentomunicipioid_Visible ;
      private int edtavCpublicacionesfectentinicio_Enabled ;
      private int edtavCpublicacionesfecrealinicio_Enabled ;
      private int edtavCpublicacionesfecfinpostulacion_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtPublicacionesId_Enabled ;
      private int edtPublicacionesTitulo_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pPublicacionesId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cPublicacionesId ;
      private long AV8cDepartamentoId ;
      private long AV9cDepartamentoMunicipioId ;
      private long A381PublicacionesId ;
      private long A112DepartamentoId ;
      private long GRID1_nCurrentRecord ;
      private long A114DepartamentoMunicipioId ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divPublicacionesidfiltercontainer_Class ;
      private string divPublicacionestitulofiltercontainer_Class ;
      private string divDepartamentoidfiltercontainer_Class ;
      private string divDepartamentomunicipioidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV7cPublicacionesTitulo ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divPublicacionesidfiltercontainer_Internalname ;
      private string lblLblpublicacionesidfilter_Internalname ;
      private string lblLblpublicacionesidfilter_Jsonclick ;
      private string edtavCpublicacionesid_Internalname ;
      private string TempTags ;
      private string edtavCpublicacionesid_Jsonclick ;
      private string divPublicacionestitulofiltercontainer_Internalname ;
      private string lblLblpublicacionestitulofilter_Internalname ;
      private string lblLblpublicacionestitulofilter_Jsonclick ;
      private string edtavCpublicacionestitulo_Internalname ;
      private string edtavCpublicacionestitulo_Jsonclick ;
      private string divDepartamentoidfiltercontainer_Internalname ;
      private string lblLbldepartamentoidfilter_Internalname ;
      private string lblLbldepartamentoidfilter_Jsonclick ;
      private string edtavCdepartamentoid_Internalname ;
      private string edtavCdepartamentoid_Jsonclick ;
      private string divDepartamentomunicipioidfiltercontainer_Internalname ;
      private string lblLbldepartamentomunicipioidfilter_Internalname ;
      private string lblLbldepartamentomunicipioidfilter_Jsonclick ;
      private string edtavCdepartamentomunicipioid_Internalname ;
      private string edtavCdepartamentomunicipioid_Jsonclick ;
      private string divPublicacionesfectentiniciofiltercontainer_Internalname ;
      private string lblLblpublicacionesfectentiniciofilter_Internalname ;
      private string lblLblpublicacionesfectentiniciofilter_Jsonclick ;
      private string edtavCpublicacionesfectentinicio_Internalname ;
      private string edtavCpublicacionesfectentinicio_Jsonclick ;
      private string divPublicacionesfecrealiniciofiltercontainer_Internalname ;
      private string lblLblpublicacionesfecrealiniciofilter_Internalname ;
      private string lblLblpublicacionesfecrealiniciofilter_Jsonclick ;
      private string edtavCpublicacionesfecrealinicio_Internalname ;
      private string edtavCpublicacionesfecrealinicio_Jsonclick ;
      private string divPublicacionesfecfinpostulacionfiltercontainer_Internalname ;
      private string lblLblpublicacionesfecfinpostulacionfilter_Internalname ;
      private string lblLblpublicacionesfecfinpostulacionfilter_Jsonclick ;
      private string edtavCpublicacionesfecfinpostulacion_Internalname ;
      private string edtavCpublicacionesfecfinpostulacion_Jsonclick ;
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
      private string edtPublicacionesId_Internalname ;
      private string A382PublicacionesTitulo ;
      private string edtPublicacionesTitulo_Internalname ;
      private string edtDepartamentoId_Internalname ;
      private string lV7cPublicacionesTitulo ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtPublicacionesId_Jsonclick ;
      private string edtPublicacionesTitulo_Link ;
      private string edtPublicacionesTitulo_Jsonclick ;
      private string edtDepartamentoId_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV10cPublicacionesFecTentInicio ;
      private DateTime AV11cPublicacionesFecRealInicio ;
      private DateTime AV12cPublicacionesFecFinPostulacion ;
      private DateTime A843PublicacionesFecTentInicio ;
      private DateTime A844PublicacionesFecRealInicio ;
      private DateTime A845PublicacionesFecFinPostulacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
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
      private DateTime[] H00IG2_A845PublicacionesFecFinPostulacion ;
      private DateTime[] H00IG2_A844PublicacionesFecRealInicio ;
      private DateTime[] H00IG2_A843PublicacionesFecTentInicio ;
      private long[] H00IG2_A114DepartamentoMunicipioId ;
      private long[] H00IG2_A112DepartamentoId ;
      private string[] H00IG2_A382PublicacionesTitulo ;
      private long[] H00IG2_A381PublicacionesId ;
      private long[] H00IG3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pPublicacionesId ;
   }

   public class gx03j0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00IG2( IGxContext context ,
                                             string AV7cPublicacionesTitulo ,
                                             long AV8cDepartamentoId ,
                                             long AV9cDepartamentoMunicipioId ,
                                             DateTime AV10cPublicacionesFecTentInicio ,
                                             DateTime AV11cPublicacionesFecRealInicio ,
                                             DateTime AV12cPublicacionesFecFinPostulacion ,
                                             string A382PublicacionesTitulo ,
                                             long A112DepartamentoId ,
                                             long A114DepartamentoMunicipioId ,
                                             DateTime A843PublicacionesFecTentInicio ,
                                             DateTime A844PublicacionesFecRealInicio ,
                                             DateTime A845PublicacionesFecFinPostulacion ,
                                             long AV6cPublicacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [PublicacionesFecFinPostulacion], [PublicacionesFecRealInicio], [PublicacionesFecTentInicio], [DepartamentoMunicipioId], [DepartamentoId], [PublicacionesTitulo], [PublicacionesId]";
         sFromString = " FROM [Publicaciones]";
         sOrderString = "";
         AddWhere(sWhereString, "([PublicacionesId] >= @AV6cPublicacionesId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cPublicacionesTitulo)) )
         {
            AddWhere(sWhereString, "([PublicacionesTitulo] like @lV7cPublicacionesTitulo)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cDepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV8cDepartamentoId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] >= @AV9cDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cPublicacionesFecTentInicio) )
         {
            AddWhere(sWhereString, "([PublicacionesFecTentInicio] >= @AV10cPublicacionesFecTentInicio)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cPublicacionesFecRealInicio) )
         {
            AddWhere(sWhereString, "([PublicacionesFecRealInicio] >= @AV11cPublicacionesFecRealInicio)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cPublicacionesFecFinPostulacion) )
         {
            AddWhere(sWhereString, "([PublicacionesFecFinPostulacion] >= @AV12cPublicacionesFecFinPostulacion)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [PublicacionesId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00IG3( IGxContext context ,
                                             string AV7cPublicacionesTitulo ,
                                             long AV8cDepartamentoId ,
                                             long AV9cDepartamentoMunicipioId ,
                                             DateTime AV10cPublicacionesFecTentInicio ,
                                             DateTime AV11cPublicacionesFecRealInicio ,
                                             DateTime AV12cPublicacionesFecFinPostulacion ,
                                             string A382PublicacionesTitulo ,
                                             long A112DepartamentoId ,
                                             long A114DepartamentoMunicipioId ,
                                             DateTime A843PublicacionesFecTentInicio ,
                                             DateTime A844PublicacionesFecRealInicio ,
                                             DateTime A845PublicacionesFecFinPostulacion ,
                                             long AV6cPublicacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Publicaciones]";
         AddWhere(sWhereString, "([PublicacionesId] >= @AV6cPublicacionesId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cPublicacionesTitulo)) )
         {
            AddWhere(sWhereString, "([PublicacionesTitulo] like @lV7cPublicacionesTitulo)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cDepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV8cDepartamentoId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cDepartamentoMunicipioId) )
         {
            AddWhere(sWhereString, "([DepartamentoMunicipioId] >= @AV9cDepartamentoMunicipioId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cPublicacionesFecTentInicio) )
         {
            AddWhere(sWhereString, "([PublicacionesFecTentInicio] >= @AV10cPublicacionesFecTentInicio)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cPublicacionesFecRealInicio) )
         {
            AddWhere(sWhereString, "([PublicacionesFecRealInicio] >= @AV11cPublicacionesFecRealInicio)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cPublicacionesFecFinPostulacion) )
         {
            AddWhere(sWhereString, "([PublicacionesFecFinPostulacion] >= @AV12cPublicacionesFecFinPostulacion)");
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
                     return conditional_H00IG2(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00IG3(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00IG2;
          prmH00IG2 = new Object[] {
          new ParDef("@AV6cPublicacionesId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cPublicacionesTitulo",GXType.NChar,80,0) ,
          new ParDef("@AV8cDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV9cDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV10cPublicacionesFecTentInicio",GXType.Date,8,0) ,
          new ParDef("@AV11cPublicacionesFecRealInicio",GXType.Date,8,0) ,
          new ParDef("@AV12cPublicacionesFecFinPostulacion",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00IG3;
          prmH00IG3 = new Object[] {
          new ParDef("@AV6cPublicacionesId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cPublicacionesTitulo",GXType.NChar,80,0) ,
          new ParDef("@AV8cDepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV9cDepartamentoMunicipioId",GXType.Decimal,18,0) ,
          new ParDef("@AV10cPublicacionesFecTentInicio",GXType.Date,8,0) ,
          new ParDef("@AV11cPublicacionesFecRealInicio",GXType.Date,8,0) ,
          new ParDef("@AV12cPublicacionesFecFinPostulacion",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00IG2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00IG2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00IG3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00IG3,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

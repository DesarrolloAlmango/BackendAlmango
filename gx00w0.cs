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
   public class gx00w0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00w0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00w0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pSolicitudesID ,
                           out long aP1_pRelacionesId )
      {
         this.AV13pSolicitudesID = 0 ;
         this.AV14pRelacionesId = 0 ;
         ExecutePrivate();
         aP0_pSolicitudesID=this.AV13pSolicitudesID;
         aP1_pRelacionesId=this.AV14pRelacionesId;
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
            gxfirstwebparm = GetFirstPar( "pSolicitudesID");
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
               gxfirstwebparm = GetFirstPar( "pSolicitudesID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pSolicitudesID");
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
               AV13pSolicitudesID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pSolicitudesID", StringUtil.LTrimStr( (decimal)(AV13pSolicitudesID), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14pRelacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "pRelacionesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14pRelacionesId", StringUtil.LTrimStr( (decimal)(AV14pRelacionesId), 18, 0));
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
         AV6cSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "cSolicitudesID"), "."), 18, MidpointRounding.ToEven));
         AV7cRelacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "cRelacionesId"), "."), 18, MidpointRounding.ToEven));
         AV8cProfesionalesId = GetPar( "cProfesionalesId");
         AV9cEstadoSGTipo = GetPar( "cEstadoSGTipo");
         AV10cEstadoSGNombre = GetPar( "cEstadoSGNombre");
         AV11cSolicitudesRelacionesFechaAlta = context.localUtil.ParseDTimeParm( GetPar( "cSolicitudesRelacionesFechaAlta"));
         AV12cSolicitudesRelacionesFechaModif = context.localUtil.ParseDTimeParm( GetPar( "cSolicitudesRelacionesFechaModif"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesID, AV7cRelacionesId, AV8cProfesionalesId, AV9cEstadoSGTipo, AV10cEstadoSGNombre, AV11cSolicitudesRelacionesFechaAlta, AV12cSolicitudesRelacionesFechaModif) ;
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
         PAJO2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTJO2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00w0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pSolicitudesID,18,0)),UrlEncode(StringUtil.LTrimStr(AV14pRelacionesId,18,0))}, new string[] {"pSolicitudesID","pRelacionesId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRELACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROFESIONALESID", StringUtil.RTrim( AV8cProfesionalesId));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOSGTIPO", StringUtil.RTrim( AV9cEstadoSGTipo));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOSGNOMBRE", StringUtil.RTrim( AV10cEstadoSGNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDESRELACIONESFECHAALTA", context.localUtil.TToC( AV11cSolicitudesRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOLICITUDESRELACIONESFECHAMODIF", context.localUtil.TToC( AV12cSolicitudesRelacionesFechaModif, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPRELACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14pRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESIDFILTERCONTAINER_Class", StringUtil.RTrim( divSolicitudesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RELACIONESIDFILTERCONTAINER_Class", StringUtil.RTrim( divRelacionesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROFESIONALESIDFILTERCONTAINER_Class", StringUtil.RTrim( divProfesionalesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESTADOSGTIPOFILTERCONTAINER_Class", StringUtil.RTrim( divEstadosgtipofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESTADOSGNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divEstadosgnombrefiltercontainer_Class));
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
            WEJO2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTJO2( ) ;
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
         return formatLink("gx00w0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pSolicitudesID,18,0)),UrlEncode(StringUtil.LTrimStr(AV14pRelacionesId,18,0))}, new string[] {"pSolicitudesID","pRelacionesId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00W0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Relaciones", "") ;
      }

      protected void WBJO0( )
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
            GxWebStd.gx_div_start( context, divSolicitudesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSolicitudesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicitudesidfilter_Internalname, context.GetMessage( "Solicitudes Id", ""), "", "", lblLblsolicitudesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11jo1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00W0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsolicitudesid_Internalname, context.GetMessage( "Solicitudes Id", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsolicitudesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCsolicitudesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cSolicitudesID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cSolicitudesID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsolicitudesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsolicitudesid_Visible, edtavCsolicitudesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00W0.htm");
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
            GxWebStd.gx_div_start( context, divRelacionesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRelacionesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrelacionesidfilter_Internalname, context.GetMessage( "Enumerar", ""), "", "", lblLblrelacionesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12jo1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00W0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrelacionesid_Internalname, context.GetMessage( "Enumerar", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrelacionesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCrelacionesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cRelacionesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7cRelacionesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrelacionesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrelacionesid_Visible, edtavCrelacionesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00W0.htm");
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
            GxWebStd.gx_div_start( context, divProfesionalesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProfesionalesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprofesionalesidfilter_Internalname, context.GetMessage( "Identidad", ""), "", "", lblLblprofesionalesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13jo1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00W0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprofesionalesid_Internalname, context.GetMessage( "Identidad", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprofesionalesid_Internalname, StringUtil.RTrim( AV8cProfesionalesId), StringUtil.RTrim( context.localUtil.Format( AV8cProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "123456789", edtavCprofesionalesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprofesionalesid_Visible, edtavCprofesionalesid_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00W0.htm");
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
            GxWebStd.gx_div_start( context, divEstadosgtipofiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstadosgtipofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestadosgtipofilter_Internalname, context.GetMessage( "Estado SGTipo", ""), "", "", lblLblestadosgtipofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14jo1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00W0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCestadosgtipo_Internalname, context.GetMessage( "Estado SGTipo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCestadosgtipo_Internalname, StringUtil.RTrim( AV9cEstadoSGTipo), StringUtil.RTrim( context.localUtil.Format( AV9cEstadoSGTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCestadosgtipo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCestadosgtipo_Visible, edtavCestadosgtipo_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00W0.htm");
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
            GxWebStd.gx_div_start( context, divEstadosgnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstadosgnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestadosgnombrefilter_Internalname, context.GetMessage( "Estado SGNombre", ""), "", "", lblLblestadosgnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15jo1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00W0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCestadosgnombre_Internalname, context.GetMessage( "Estado SGNombre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCestadosgnombre_Internalname, StringUtil.RTrim( AV10cEstadoSGNombre), StringUtil.RTrim( context.localUtil.Format( AV10cEstadoSGNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCestadosgnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCestadosgnombre_Visible, edtavCestadosgnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00W0.htm");
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
            GxWebStd.gx_div_start( context, divSolicitudesrelacionesfechaaltafiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicitudesrelacionesfechaaltafilter_Internalname, context.GetMessage( "Fecha Alta", ""), "", "", lblLblsolicitudesrelacionesfechaaltafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx00W0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsolicitudesrelacionesfechaalta_Internalname, context.GetMessage( "Fecha Alta", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCsolicitudesrelacionesfechaalta_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCsolicitudesrelacionesfechaalta_Internalname, context.localUtil.TToC( AV11cSolicitudesRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV11cSolicitudesRelacionesFechaAlta, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsolicitudesrelacionesfechaalta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCsolicitudesrelacionesfechaalta_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00W0.htm");
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
            GxWebStd.gx_div_start( context, divSolicitudesrelacionesfechamodiffiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsolicitudesrelacionesfechamodiffilter_Internalname, context.GetMessage( "Fecha Modificación", ""), "", "", lblLblsolicitudesrelacionesfechamodiffilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx00W0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsolicitudesrelacionesfechamodif_Internalname, context.GetMessage( "Fecha Modificación", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCsolicitudesrelacionesfechamodif_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCsolicitudesrelacionesfechamodif_Internalname, context.localUtil.TToC( AV12cSolicitudesRelacionesFechaModif, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV12cSolicitudesRelacionesFechaModif, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsolicitudesrelacionesfechamodif_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCsolicitudesrelacionesfechamodif_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00W0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16jo1_client"+"'", TempTags, "", 2, "HLP_Gx00W0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00W0.htm");
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

      protected void STARTJO2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Relaciones", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPJO0( ) ;
      }

      protected void WSJO2( )
      {
         STARTJO2( ) ;
         EVTJO2( ) ;
      }

      protected void EVTJO2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A127SolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSolicitudesID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A140RelacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtRelacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A120ProfesionalesId = cgiGet( edtProfesionalesId_Internalname);
                              A141EstadoSGTipo = cgiGet( edtEstadoSGTipo_Internalname);
                              A219SolicitudesRelacionesFechaAlta = context.localUtil.CToT( cgiGet( edtSolicitudesRelacionesFechaAlta_Internalname), 0);
                              A220SolicitudesRelacionesFechaModi = context.localUtil.CToT( cgiGet( edtSolicitudesRelacionesFechaModi_Internalname), 0);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17JO2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18JO2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Csolicitudesid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cSolicitudesID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crelacionesid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRELACIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cRelacionesId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprofesionalesid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESID"), AV8cProfesionalesId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadosgtipo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSGTIPO"), AV9cEstadoSGTipo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadosgnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSGNOMBRE"), AV10cEstadoSGNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csolicitudesrelacionesfechaalta Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCSOLICITUDESRELACIONESFECHAALTA"), 0) != AV11cSolicitudesRelacionesFechaAlta )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csolicitudesrelacionesfechamodif Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCSOLICITUDESRELACIONESFECHAMODIF"), 0) != AV12cSolicitudesRelacionesFechaModif )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19JO2 ();
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

      protected void WEJO2( )
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

      protected void PAJO2( )
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
                                        long AV6cSolicitudesID ,
                                        long AV7cRelacionesId ,
                                        string AV8cProfesionalesId ,
                                        string AV9cEstadoSGTipo ,
                                        string AV10cEstadoSGNombre ,
                                        DateTime AV11cSolicitudesRelacionesFechaAlta ,
                                        DateTime AV12cSolicitudesRelacionesFechaModif )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFJO2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SOLICITUDESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_RELACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A140RelacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "RELACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, ".", "")));
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
         RFJO2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFJO2( )
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
                                                 AV8cProfesionalesId ,
                                                 AV9cEstadoSGTipo ,
                                                 AV10cEstadoSGNombre ,
                                                 AV11cSolicitudesRelacionesFechaAlta ,
                                                 AV12cSolicitudesRelacionesFechaModif ,
                                                 A120ProfesionalesId ,
                                                 A141EstadoSGTipo ,
                                                 A143EstadoSGNombre ,
                                                 A219SolicitudesRelacionesFechaAlta ,
                                                 A220SolicitudesRelacionesFechaModi ,
                                                 AV6cSolicitudesID ,
                                                 AV7cRelacionesId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV8cProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV8cProfesionalesId), 20, "%");
            lV9cEstadoSGTipo = StringUtil.PadR( StringUtil.RTrim( AV9cEstadoSGTipo), 3, "%");
            lV10cEstadoSGNombre = StringUtil.PadR( StringUtil.RTrim( AV10cEstadoSGNombre), 80, "%");
            /* Using cursor H00JO2 */
            pr_default.execute(0, new Object[] {AV6cSolicitudesID, AV7cRelacionesId, lV8cProfesionalesId, lV9cEstadoSGTipo, lV10cEstadoSGNombre, AV11cSolicitudesRelacionesFechaAlta, AV12cSolicitudesRelacionesFechaModif, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A142EstadoSGId = H00JO2_A142EstadoSGId[0];
               A143EstadoSGNombre = H00JO2_A143EstadoSGNombre[0];
               A220SolicitudesRelacionesFechaModi = H00JO2_A220SolicitudesRelacionesFechaModi[0];
               A219SolicitudesRelacionesFechaAlta = H00JO2_A219SolicitudesRelacionesFechaAlta[0];
               A141EstadoSGTipo = H00JO2_A141EstadoSGTipo[0];
               A120ProfesionalesId = H00JO2_A120ProfesionalesId[0];
               A140RelacionesId = H00JO2_A140RelacionesId[0];
               A127SolicitudesID = H00JO2_A127SolicitudesID[0];
               A143EstadoSGNombre = H00JO2_A143EstadoSGNombre[0];
               /* Execute user event: Load */
               E18JO2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WBJO0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesJO2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SOLICITUDESID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_RELACIONESID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A140RelacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV8cProfesionalesId ,
                                              AV9cEstadoSGTipo ,
                                              AV10cEstadoSGNombre ,
                                              AV11cSolicitudesRelacionesFechaAlta ,
                                              AV12cSolicitudesRelacionesFechaModif ,
                                              A120ProfesionalesId ,
                                              A141EstadoSGTipo ,
                                              A143EstadoSGNombre ,
                                              A219SolicitudesRelacionesFechaAlta ,
                                              A220SolicitudesRelacionesFechaModi ,
                                              AV6cSolicitudesID ,
                                              AV7cRelacionesId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV8cProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV8cProfesionalesId), 20, "%");
         lV9cEstadoSGTipo = StringUtil.PadR( StringUtil.RTrim( AV9cEstadoSGTipo), 3, "%");
         lV10cEstadoSGNombre = StringUtil.PadR( StringUtil.RTrim( AV10cEstadoSGNombre), 80, "%");
         /* Using cursor H00JO3 */
         pr_default.execute(1, new Object[] {AV6cSolicitudesID, AV7cRelacionesId, lV8cProfesionalesId, lV9cEstadoSGTipo, lV10cEstadoSGNombre, AV11cSolicitudesRelacionesFechaAlta, AV12cSolicitudesRelacionesFechaModif});
         GRID1_nRecordCount = H00JO3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesID, AV7cRelacionesId, AV8cProfesionalesId, AV9cEstadoSGTipo, AV10cEstadoSGNombre, AV11cSolicitudesRelacionesFechaAlta, AV12cSolicitudesRelacionesFechaModif) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesID, AV7cRelacionesId, AV8cProfesionalesId, AV9cEstadoSGTipo, AV10cEstadoSGNombre, AV11cSolicitudesRelacionesFechaAlta, AV12cSolicitudesRelacionesFechaModif) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesID, AV7cRelacionesId, AV8cProfesionalesId, AV9cEstadoSGTipo, AV10cEstadoSGNombre, AV11cSolicitudesRelacionesFechaAlta, AV12cSolicitudesRelacionesFechaModif) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesID, AV7cRelacionesId, AV8cProfesionalesId, AV9cEstadoSGTipo, AV10cEstadoSGNombre, AV11cSolicitudesRelacionesFechaAlta, AV12cSolicitudesRelacionesFechaModif) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSolicitudesID, AV7cRelacionesId, AV8cProfesionalesId, AV9cEstadoSGTipo, AV10cEstadoSGNombre, AV11cSolicitudesRelacionesFechaAlta, AV12cSolicitudesRelacionesFechaModif) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtSolicitudesID_Enabled = 0;
         edtRelacionesId_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtEstadoSGTipo_Enabled = 0;
         edtSolicitudesRelacionesFechaAlta_Enabled = 0;
         edtSolicitudesRelacionesFechaModi_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPJO0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17JO2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsolicitudesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSOLICITUDESID");
               GX_FocusControl = edtavCsolicitudesid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cSolicitudesID = 0;
               AssignAttri("", false, "AV6cSolicitudesID", StringUtil.LTrimStr( (decimal)(AV6cSolicitudesID), 18, 0));
            }
            else
            {
               AV6cSolicitudesID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsolicitudesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cSolicitudesID", StringUtil.LTrimStr( (decimal)(AV6cSolicitudesID), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrelacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrelacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRELACIONESID");
               GX_FocusControl = edtavCrelacionesid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cRelacionesId = 0;
               AssignAttri("", false, "AV7cRelacionesId", StringUtil.LTrimStr( (decimal)(AV7cRelacionesId), 18, 0));
            }
            else
            {
               AV7cRelacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCrelacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cRelacionesId", StringUtil.LTrimStr( (decimal)(AV7cRelacionesId), 18, 0));
            }
            AV8cProfesionalesId = cgiGet( edtavCprofesionalesid_Internalname);
            AssignAttri("", false, "AV8cProfesionalesId", AV8cProfesionalesId);
            AV9cEstadoSGTipo = cgiGet( edtavCestadosgtipo_Internalname);
            AssignAttri("", false, "AV9cEstadoSGTipo", AV9cEstadoSGTipo);
            AV10cEstadoSGNombre = cgiGet( edtavCestadosgnombre_Internalname);
            AssignAttri("", false, "AV10cEstadoSGNombre", AV10cEstadoSGNombre);
            if ( context.localUtil.VCDateTime( cgiGet( edtavCsolicitudesrelacionesfechaalta_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha Alta", "")}), 1, "vCSOLICITUDESRELACIONESFECHAALTA");
               GX_FocusControl = edtavCsolicitudesrelacionesfechaalta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cSolicitudesRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV11cSolicitudesRelacionesFechaAlta", context.localUtil.TToC( AV11cSolicitudesRelacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV11cSolicitudesRelacionesFechaAlta = context.localUtil.CToT( cgiGet( edtavCsolicitudesrelacionesfechaalta_Internalname));
               AssignAttri("", false, "AV11cSolicitudesRelacionesFechaAlta", context.localUtil.TToC( AV11cSolicitudesRelacionesFechaAlta, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavCsolicitudesrelacionesfechamodif_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha Modificación", "")}), 1, "vCSOLICITUDESRELACIONESFECHAMODIF");
               GX_FocusControl = edtavCsolicitudesrelacionesfechamodif_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cSolicitudesRelacionesFechaModif = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV12cSolicitudesRelacionesFechaModif", context.localUtil.TToC( AV12cSolicitudesRelacionesFechaModif, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV12cSolicitudesRelacionesFechaModif = context.localUtil.CToT( cgiGet( edtavCsolicitudesrelacionesfechamodif_Internalname));
               AssignAttri("", false, "AV12cSolicitudesRelacionesFechaModif", context.localUtil.TToC( AV12cSolicitudesRelacionesFechaModif, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSOLICITUDESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cSolicitudesID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRELACIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cRelacionesId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPROFESIONALESID"), AV8cProfesionalesId) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSGTIPO"), AV9cEstadoSGTipo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSGNOMBRE"), AV10cEstadoSGNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCSOLICITUDESRELACIONESFECHAALTA")) != AV11cSolicitudesRelacionesFechaAlta )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCSOLICITUDESRELACIONESFECHAMODIF")) != AV12cSolicitudesRelacionesFechaModif )
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
         E17JO2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17JO2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Relaciones", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV15ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E18JO2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV16Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E19JO2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19JO2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pSolicitudesID = A127SolicitudesID;
         AssignAttri("", false, "AV13pSolicitudesID", StringUtil.LTrimStr( (decimal)(AV13pSolicitudesID), 18, 0));
         AV14pRelacionesId = A140RelacionesId;
         AssignAttri("", false, "AV14pRelacionesId", StringUtil.LTrimStr( (decimal)(AV14pRelacionesId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pSolicitudesID,(long)AV14pRelacionesId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pSolicitudesID","AV14pRelacionesId"});
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
         AV13pSolicitudesID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pSolicitudesID", StringUtil.LTrimStr( (decimal)(AV13pSolicitudesID), 18, 0));
         AV14pRelacionesId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV14pRelacionesId", StringUtil.LTrimStr( (decimal)(AV14pRelacionesId), 18, 0));
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
         PAJO2( ) ;
         WSJO2( ) ;
         WEJO2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20268622585180", true, true, false);
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
         context.AddJavascriptSource("gx00w0.js", "?20268622585182", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtSolicitudesID_Internalname = "SOLICITUDESID_"+sGXsfl_84_idx;
         edtRelacionesId_Internalname = "RELACIONESID_"+sGXsfl_84_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_84_idx;
         edtEstadoSGTipo_Internalname = "ESTADOSGTIPO_"+sGXsfl_84_idx;
         edtSolicitudesRelacionesFechaAlta_Internalname = "SOLICITUDESRELACIONESFECHAALTA_"+sGXsfl_84_idx;
         edtSolicitudesRelacionesFechaModi_Internalname = "SOLICITUDESRELACIONESFECHAMODI_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtSolicitudesID_Internalname = "SOLICITUDESID_"+sGXsfl_84_fel_idx;
         edtRelacionesId_Internalname = "RELACIONESID_"+sGXsfl_84_fel_idx;
         edtProfesionalesId_Internalname = "PROFESIONALESID_"+sGXsfl_84_fel_idx;
         edtEstadoSGTipo_Internalname = "ESTADOSGTIPO_"+sGXsfl_84_fel_idx;
         edtSolicitudesRelacionesFechaAlta_Internalname = "SOLICITUDESRELACIONESFECHAALTA_"+sGXsfl_84_fel_idx;
         edtSolicitudesRelacionesFechaModi_Internalname = "SOLICITUDESRELACIONESFECHAMODI_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         WBJO0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV16Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A127SolicitudesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRelacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A140RelacionesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRelacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProfesionalesId_Internalname,StringUtil.RTrim( A120ProfesionalesId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"123456789",(string)edtProfesionalesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"NoIdentidad",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoSGTipo_Internalname,StringUtil.RTrim( A141EstadoSGTipo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoSGTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesRelacionesFechaAlta_Internalname,context.localUtil.TToC( A219SolicitudesRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A219SolicitudesRelacionesFechaAlta, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesRelacionesFechaAlta_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSolicitudesRelacionesFechaModi_Internalname,context.localUtil.TToC( A220SolicitudesRelacionesFechaModi, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "),context.localUtil.Format( A220SolicitudesRelacionesFechaModi, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSolicitudesRelacionesFechaModi_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesJO2( ) ;
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
            context.SendWebValue( context.GetMessage( "Solicitudes Id", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Enumerar", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identidad", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "SGTipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Alta", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Modificación", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A127SolicitudesID), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A140RelacionesId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A120ProfesionalesId)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A141EstadoSGTipo)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A219SolicitudesRelacionesFechaAlta, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A220SolicitudesRelacionesFechaModi, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " ")));
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
         lblLblsolicitudesidfilter_Internalname = "LBLSOLICITUDESIDFILTER";
         edtavCsolicitudesid_Internalname = "vCSOLICITUDESID";
         divSolicitudesidfiltercontainer_Internalname = "SOLICITUDESIDFILTERCONTAINER";
         lblLblrelacionesidfilter_Internalname = "LBLRELACIONESIDFILTER";
         edtavCrelacionesid_Internalname = "vCRELACIONESID";
         divRelacionesidfiltercontainer_Internalname = "RELACIONESIDFILTERCONTAINER";
         lblLblprofesionalesidfilter_Internalname = "LBLPROFESIONALESIDFILTER";
         edtavCprofesionalesid_Internalname = "vCPROFESIONALESID";
         divProfesionalesidfiltercontainer_Internalname = "PROFESIONALESIDFILTERCONTAINER";
         lblLblestadosgtipofilter_Internalname = "LBLESTADOSGTIPOFILTER";
         edtavCestadosgtipo_Internalname = "vCESTADOSGTIPO";
         divEstadosgtipofiltercontainer_Internalname = "ESTADOSGTIPOFILTERCONTAINER";
         lblLblestadosgnombrefilter_Internalname = "LBLESTADOSGNOMBREFILTER";
         edtavCestadosgnombre_Internalname = "vCESTADOSGNOMBRE";
         divEstadosgnombrefiltercontainer_Internalname = "ESTADOSGNOMBREFILTERCONTAINER";
         lblLblsolicitudesrelacionesfechaaltafilter_Internalname = "LBLSOLICITUDESRELACIONESFECHAALTAFILTER";
         edtavCsolicitudesrelacionesfechaalta_Internalname = "vCSOLICITUDESRELACIONESFECHAALTA";
         divSolicitudesrelacionesfechaaltafiltercontainer_Internalname = "SOLICITUDESRELACIONESFECHAALTAFILTERCONTAINER";
         lblLblsolicitudesrelacionesfechamodiffilter_Internalname = "LBLSOLICITUDESRELACIONESFECHAMODIFFILTER";
         edtavCsolicitudesrelacionesfechamodif_Internalname = "vCSOLICITUDESRELACIONESFECHAMODIF";
         divSolicitudesrelacionesfechamodiffiltercontainer_Internalname = "SOLICITUDESRELACIONESFECHAMODIFFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtSolicitudesID_Internalname = "SOLICITUDESID";
         edtRelacionesId_Internalname = "RELACIONESID";
         edtProfesionalesId_Internalname = "PROFESIONALESID";
         edtEstadoSGTipo_Internalname = "ESTADOSGTIPO";
         edtSolicitudesRelacionesFechaAlta_Internalname = "SOLICITUDESRELACIONESFECHAALTA";
         edtSolicitudesRelacionesFechaModi_Internalname = "SOLICITUDESRELACIONESFECHAMODI";
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
         edtSolicitudesRelacionesFechaModi_Jsonclick = "";
         edtSolicitudesRelacionesFechaAlta_Jsonclick = "";
         edtEstadoSGTipo_Jsonclick = "";
         edtProfesionalesId_Jsonclick = "";
         edtRelacionesId_Jsonclick = "";
         edtSolicitudesID_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtSolicitudesRelacionesFechaModi_Enabled = 0;
         edtSolicitudesRelacionesFechaAlta_Enabled = 0;
         edtEstadoSGTipo_Enabled = 0;
         edtProfesionalesId_Enabled = 0;
         edtRelacionesId_Enabled = 0;
         edtSolicitudesID_Enabled = 0;
         edtavCsolicitudesrelacionesfechamodif_Jsonclick = "";
         edtavCsolicitudesrelacionesfechamodif_Enabled = 1;
         edtavCsolicitudesrelacionesfechaalta_Jsonclick = "";
         edtavCsolicitudesrelacionesfechaalta_Enabled = 1;
         edtavCestadosgnombre_Jsonclick = "";
         edtavCestadosgnombre_Enabled = 1;
         edtavCestadosgnombre_Visible = 1;
         edtavCestadosgtipo_Jsonclick = "";
         edtavCestadosgtipo_Enabled = 1;
         edtavCestadosgtipo_Visible = 1;
         edtavCprofesionalesid_Jsonclick = "";
         edtavCprofesionalesid_Enabled = 1;
         edtavCprofesionalesid_Visible = 1;
         edtavCrelacionesid_Jsonclick = "";
         edtavCrelacionesid_Enabled = 1;
         edtavCrelacionesid_Visible = 1;
         edtavCsolicitudesid_Jsonclick = "";
         edtavCsolicitudesid_Enabled = 1;
         edtavCsolicitudesid_Visible = 1;
         divEstadosgnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divEstadosgtipofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divProfesionalesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divRelacionesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divSolicitudesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Relaciones", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesID',fld:'vCSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cRelacionesId',fld:'vCRELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'AV9cEstadoSGTipo',fld:'vCESTADOSGTIPO',pic:'',type:'char'},{av:'AV10cEstadoSGNombre',fld:'vCESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV11cSolicitudesRelacionesFechaAlta',fld:'vCSOLICITUDESRELACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV12cSolicitudesRelacionesFechaModif',fld:'vCSOLICITUDESRELACIONESFECHAMODIF',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E16JO1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLSOLICITUDESIDFILTER.CLICK","{handler:'E11JO1',iparms:[{av:'divSolicitudesidfiltercontainer_Class',ctrl:'SOLICITUDESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSOLICITUDESIDFILTER.CLICK",",oparms:[{av:'divSolicitudesidfiltercontainer_Class',ctrl:'SOLICITUDESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsolicitudesid_Visible',ctrl:'vCSOLICITUDESID',prop:'Visible'}]}");
         setEventMetadata("LBLRELACIONESIDFILTER.CLICK","{handler:'E12JO1',iparms:[{av:'divRelacionesidfiltercontainer_Class',ctrl:'RELACIONESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRELACIONESIDFILTER.CLICK",",oparms:[{av:'divRelacionesidfiltercontainer_Class',ctrl:'RELACIONESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCrelacionesid_Visible',ctrl:'vCRELACIONESID',prop:'Visible'}]}");
         setEventMetadata("LBLPROFESIONALESIDFILTER.CLICK","{handler:'E13JO1',iparms:[{av:'divProfesionalesidfiltercontainer_Class',ctrl:'PROFESIONALESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROFESIONALESIDFILTER.CLICK",",oparms:[{av:'divProfesionalesidfiltercontainer_Class',ctrl:'PROFESIONALESIDFILTERCONTAINER',prop:'Class'},{av:'edtavCprofesionalesid_Visible',ctrl:'vCPROFESIONALESID',prop:'Visible'}]}");
         setEventMetadata("LBLESTADOSGTIPOFILTER.CLICK","{handler:'E14JO1',iparms:[{av:'divEstadosgtipofiltercontainer_Class',ctrl:'ESTADOSGTIPOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTADOSGTIPOFILTER.CLICK",",oparms:[{av:'divEstadosgtipofiltercontainer_Class',ctrl:'ESTADOSGTIPOFILTERCONTAINER',prop:'Class'},{av:'edtavCestadosgtipo_Visible',ctrl:'vCESTADOSGTIPO',prop:'Visible'}]}");
         setEventMetadata("LBLESTADOSGNOMBREFILTER.CLICK","{handler:'E15JO1',iparms:[{av:'divEstadosgnombrefiltercontainer_Class',ctrl:'ESTADOSGNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTADOSGNOMBREFILTER.CLICK",",oparms:[{av:'divEstadosgnombrefiltercontainer_Class',ctrl:'ESTADOSGNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCestadosgnombre_Visible',ctrl:'vCESTADOSGNOMBRE',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E19JO2',iparms:[{av:'A127SolicitudesID',fld:'SOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'},{av:'A140RelacionesId',fld:'RELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pSolicitudesID',fld:'vPSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV14pRelacionesId',fld:'vPRELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesID',fld:'vCSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cRelacionesId',fld:'vCRELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'AV9cEstadoSGTipo',fld:'vCESTADOSGTIPO',pic:'',type:'char'},{av:'AV10cEstadoSGNombre',fld:'vCESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV11cSolicitudesRelacionesFechaAlta',fld:'vCSOLICITUDESRELACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV12cSolicitudesRelacionesFechaModif',fld:'vCSOLICITUDESRELACIONESFECHAMODIF',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesID',fld:'vCSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cRelacionesId',fld:'vCRELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'AV9cEstadoSGTipo',fld:'vCESTADOSGTIPO',pic:'',type:'char'},{av:'AV10cEstadoSGNombre',fld:'vCESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV11cSolicitudesRelacionesFechaAlta',fld:'vCSOLICITUDESRELACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV12cSolicitudesRelacionesFechaModif',fld:'vCSOLICITUDESRELACIONESFECHAMODIF',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesID',fld:'vCSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cRelacionesId',fld:'vCRELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'AV9cEstadoSGTipo',fld:'vCESTADOSGTIPO',pic:'',type:'char'},{av:'AV10cEstadoSGNombre',fld:'vCESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV11cSolicitudesRelacionesFechaAlta',fld:'vCSOLICITUDESRELACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV12cSolicitudesRelacionesFechaModif',fld:'vCSOLICITUDESRELACIONESFECHAMODIF',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSolicitudesID',fld:'vCSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cRelacionesId',fld:'vCRELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV8cProfesionalesId',fld:'vCPROFESIONALESID',pic:'',type:'char'},{av:'AV9cEstadoSGTipo',fld:'vCESTADOSGTIPO',pic:'',type:'char'},{av:'AV10cEstadoSGNombre',fld:'vCESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV11cSolicitudesRelacionesFechaAlta',fld:'vCSOLICITUDESRELACIONESFECHAALTA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV12cSolicitudesRelacionesFechaModif',fld:'vCSOLICITUDESRELACIONESFECHAMODIF',pic:'99/99/99 99:99',type:'dtime'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CSOLICITUDESRELACIONESFECHAALTA","{handler:'Validv_Csolicitudesrelacionesfechaalta',iparms:[]");
         setEventMetadata("VALIDV_CSOLICITUDESRELACIONESFECHAALTA",",oparms:[]}");
         setEventMetadata("VALIDV_CSOLICITUDESRELACIONESFECHAMODIF","{handler:'Validv_Csolicitudesrelacionesfechamodif',iparms:[]");
         setEventMetadata("VALIDV_CSOLICITUDESRELACIONESFECHAMODIF",",oparms:[]}");
         setEventMetadata("VALID_ESTADOSGTIPO","{handler:'Valid_Estadosgtipo',iparms:[]");
         setEventMetadata("VALID_ESTADOSGTIPO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Solicitudesrelacionesfechamodi',iparms:[]");
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
         AV8cProfesionalesId = "";
         AV9cEstadoSGTipo = "";
         AV10cEstadoSGNombre = "";
         AV11cSolicitudesRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV12cSolicitudesRelacionesFechaModif = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblsolicitudesidfilter_Jsonclick = "";
         TempTags = "";
         lblLblrelacionesidfilter_Jsonclick = "";
         lblLblprofesionalesidfilter_Jsonclick = "";
         lblLblestadosgtipofilter_Jsonclick = "";
         lblLblestadosgnombrefilter_Jsonclick = "";
         lblLblsolicitudesrelacionesfechaaltafilter_Jsonclick = "";
         lblLblsolicitudesrelacionesfechamodiffilter_Jsonclick = "";
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
         AV16Linkselection_GXI = "";
         A120ProfesionalesId = "";
         A141EstadoSGTipo = "";
         A219SolicitudesRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A220SolicitudesRelacionesFechaModi = (DateTime)(DateTime.MinValue);
         lV8cProfesionalesId = "";
         lV9cEstadoSGTipo = "";
         lV10cEstadoSGNombre = "";
         A143EstadoSGNombre = "";
         H00JO2_A142EstadoSGId = new int[1] ;
         H00JO2_A143EstadoSGNombre = new string[] {""} ;
         H00JO2_A220SolicitudesRelacionesFechaModi = new DateTime[] {DateTime.MinValue} ;
         H00JO2_A219SolicitudesRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         H00JO2_A141EstadoSGTipo = new string[] {""} ;
         H00JO2_A120ProfesionalesId = new string[] {""} ;
         H00JO2_A140RelacionesId = new long[1] ;
         H00JO2_A127SolicitudesID = new long[1] ;
         H00JO3_AGRID1_nRecordCount = new long[1] ;
         AV15ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00w0__default(),
            new Object[][] {
                new Object[] {
               H00JO2_A142EstadoSGId, H00JO2_A143EstadoSGNombre, H00JO2_A220SolicitudesRelacionesFechaModi, H00JO2_A219SolicitudesRelacionesFechaAlta, H00JO2_A141EstadoSGTipo, H00JO2_A120ProfesionalesId, H00JO2_A140RelacionesId, H00JO2_A127SolicitudesID
               }
               , new Object[] {
               H00JO3_AGRID1_nRecordCount
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
      private int edtavCsolicitudesid_Enabled ;
      private int edtavCsolicitudesid_Visible ;
      private int edtavCrelacionesid_Enabled ;
      private int edtavCrelacionesid_Visible ;
      private int edtavCprofesionalesid_Visible ;
      private int edtavCprofesionalesid_Enabled ;
      private int edtavCestadosgtipo_Visible ;
      private int edtavCestadosgtipo_Enabled ;
      private int edtavCestadosgnombre_Visible ;
      private int edtavCestadosgnombre_Enabled ;
      private int edtavCsolicitudesrelacionesfechaalta_Enabled ;
      private int edtavCsolicitudesrelacionesfechamodif_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A142EstadoSGId ;
      private int edtSolicitudesID_Enabled ;
      private int edtRelacionesId_Enabled ;
      private int edtProfesionalesId_Enabled ;
      private int edtEstadoSGTipo_Enabled ;
      private int edtSolicitudesRelacionesFechaAlta_Enabled ;
      private int edtSolicitudesRelacionesFechaModi_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pSolicitudesID ;
      private long AV14pRelacionesId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cSolicitudesID ;
      private long AV7cRelacionesId ;
      private long A127SolicitudesID ;
      private long A140RelacionesId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divSolicitudesidfiltercontainer_Class ;
      private string divRelacionesidfiltercontainer_Class ;
      private string divProfesionalesidfiltercontainer_Class ;
      private string divEstadosgtipofiltercontainer_Class ;
      private string divEstadosgnombrefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV8cProfesionalesId ;
      private string AV9cEstadoSGTipo ;
      private string AV10cEstadoSGNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divSolicitudesidfiltercontainer_Internalname ;
      private string lblLblsolicitudesidfilter_Internalname ;
      private string lblLblsolicitudesidfilter_Jsonclick ;
      private string edtavCsolicitudesid_Internalname ;
      private string TempTags ;
      private string edtavCsolicitudesid_Jsonclick ;
      private string divRelacionesidfiltercontainer_Internalname ;
      private string lblLblrelacionesidfilter_Internalname ;
      private string lblLblrelacionesidfilter_Jsonclick ;
      private string edtavCrelacionesid_Internalname ;
      private string edtavCrelacionesid_Jsonclick ;
      private string divProfesionalesidfiltercontainer_Internalname ;
      private string lblLblprofesionalesidfilter_Internalname ;
      private string lblLblprofesionalesidfilter_Jsonclick ;
      private string edtavCprofesionalesid_Internalname ;
      private string edtavCprofesionalesid_Jsonclick ;
      private string divEstadosgtipofiltercontainer_Internalname ;
      private string lblLblestadosgtipofilter_Internalname ;
      private string lblLblestadosgtipofilter_Jsonclick ;
      private string edtavCestadosgtipo_Internalname ;
      private string edtavCestadosgtipo_Jsonclick ;
      private string divEstadosgnombrefiltercontainer_Internalname ;
      private string lblLblestadosgnombrefilter_Internalname ;
      private string lblLblestadosgnombrefilter_Jsonclick ;
      private string edtavCestadosgnombre_Internalname ;
      private string edtavCestadosgnombre_Jsonclick ;
      private string divSolicitudesrelacionesfechaaltafiltercontainer_Internalname ;
      private string lblLblsolicitudesrelacionesfechaaltafilter_Internalname ;
      private string lblLblsolicitudesrelacionesfechaaltafilter_Jsonclick ;
      private string edtavCsolicitudesrelacionesfechaalta_Internalname ;
      private string edtavCsolicitudesrelacionesfechaalta_Jsonclick ;
      private string divSolicitudesrelacionesfechamodiffiltercontainer_Internalname ;
      private string lblLblsolicitudesrelacionesfechamodiffilter_Internalname ;
      private string lblLblsolicitudesrelacionesfechamodiffilter_Jsonclick ;
      private string edtavCsolicitudesrelacionesfechamodif_Internalname ;
      private string edtavCsolicitudesrelacionesfechamodif_Jsonclick ;
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
      private string edtSolicitudesID_Internalname ;
      private string edtRelacionesId_Internalname ;
      private string A120ProfesionalesId ;
      private string edtProfesionalesId_Internalname ;
      private string A141EstadoSGTipo ;
      private string edtEstadoSGTipo_Internalname ;
      private string edtSolicitudesRelacionesFechaAlta_Internalname ;
      private string edtSolicitudesRelacionesFechaModi_Internalname ;
      private string lV8cProfesionalesId ;
      private string lV9cEstadoSGTipo ;
      private string lV10cEstadoSGNombre ;
      private string A143EstadoSGNombre ;
      private string AV15ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtSolicitudesID_Jsonclick ;
      private string edtRelacionesId_Jsonclick ;
      private string edtProfesionalesId_Jsonclick ;
      private string edtEstadoSGTipo_Jsonclick ;
      private string edtSolicitudesRelacionesFechaAlta_Jsonclick ;
      private string edtSolicitudesRelacionesFechaModi_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV11cSolicitudesRelacionesFechaAlta ;
      private DateTime AV12cSolicitudesRelacionesFechaModif ;
      private DateTime A219SolicitudesRelacionesFechaAlta ;
      private DateTime A220SolicitudesRelacionesFechaModi ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV16Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H00JO2_A142EstadoSGId ;
      private string[] H00JO2_A143EstadoSGNombre ;
      private DateTime[] H00JO2_A220SolicitudesRelacionesFechaModi ;
      private DateTime[] H00JO2_A219SolicitudesRelacionesFechaAlta ;
      private string[] H00JO2_A141EstadoSGTipo ;
      private string[] H00JO2_A120ProfesionalesId ;
      private long[] H00JO2_A140RelacionesId ;
      private long[] H00JO2_A127SolicitudesID ;
      private long[] H00JO3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pSolicitudesID ;
      private long aP1_pRelacionesId ;
   }

   public class gx00w0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00JO2( IGxContext context ,
                                             string AV8cProfesionalesId ,
                                             string AV9cEstadoSGTipo ,
                                             string AV10cEstadoSGNombre ,
                                             DateTime AV11cSolicitudesRelacionesFechaAlta ,
                                             DateTime AV12cSolicitudesRelacionesFechaModif ,
                                             string A120ProfesionalesId ,
                                             string A141EstadoSGTipo ,
                                             string A143EstadoSGNombre ,
                                             DateTime A219SolicitudesRelacionesFechaAlta ,
                                             DateTime A220SolicitudesRelacionesFechaModi ,
                                             long AV6cSolicitudesID ,
                                             long AV7cRelacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[EstadoSGId] AS EstadoSGId, T2.[EstadosGenericosNombre] AS EstadoSGNombre, T1.[SolicitudesRelacionesFechaModi], T1.[SolicitudesRelacionesFechaAlta], T1.[EstadoSGTipo] AS EstadoSGTipo, T1.[ProfesionalesId], T1.[RelacionesId], T1.[SolicitudesID]";
         sFromString = " FROM ([Relaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV6cSolicitudesID and T1.[RelacionesId] >= @AV7cRelacionesId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cProfesionalesId)) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] like @lV8cProfesionalesId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cEstadoSGTipo)) )
         {
            AddWhere(sWhereString, "(T1.[EstadoSGTipo] like @lV9cEstadoSGTipo)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cEstadoSGNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] like @lV10cEstadoSGNombre)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cSolicitudesRelacionesFechaAlta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesRelacionesFechaAlta] >= @AV11cSolicitudesRelacionesFechaAlta)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cSolicitudesRelacionesFechaModif) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesRelacionesFechaModi] >= @AV12cSolicitudesRelacionesFechaModif)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY T1.[SolicitudesID], T1.[RelacionesId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00JO3( IGxContext context ,
                                             string AV8cProfesionalesId ,
                                             string AV9cEstadoSGTipo ,
                                             string AV10cEstadoSGNombre ,
                                             DateTime AV11cSolicitudesRelacionesFechaAlta ,
                                             DateTime AV12cSolicitudesRelacionesFechaModif ,
                                             string A120ProfesionalesId ,
                                             string A141EstadoSGTipo ,
                                             string A143EstadoSGNombre ,
                                             DateTime A219SolicitudesRelacionesFechaAlta ,
                                             DateTime A220SolicitudesRelacionesFechaModi ,
                                             long AV6cSolicitudesID ,
                                             long AV7cRelacionesId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([Relaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId])";
         AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV6cSolicitudesID and T1.[RelacionesId] >= @AV7cRelacionesId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cProfesionalesId)) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] like @lV8cProfesionalesId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cEstadoSGTipo)) )
         {
            AddWhere(sWhereString, "(T1.[EstadoSGTipo] like @lV9cEstadoSGTipo)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cEstadoSGNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] like @lV10cEstadoSGNombre)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cSolicitudesRelacionesFechaAlta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesRelacionesFechaAlta] >= @AV11cSolicitudesRelacionesFechaAlta)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cSolicitudesRelacionesFechaModif) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesRelacionesFechaModi] >= @AV12cSolicitudesRelacionesFechaModif)");
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
                     return conditional_H00JO2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] );
               case 1 :
                     return conditional_H00JO3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] );
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
          Object[] prmH00JO2;
          prmH00JO2 = new Object[] {
          new ParDef("@AV6cSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV7cRelacionesId",GXType.Decimal,18,0) ,
          new ParDef("@lV8cProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@lV9cEstadoSGTipo",GXType.NChar,3,0) ,
          new ParDef("@lV10cEstadoSGNombre",GXType.NChar,80,0) ,
          new ParDef("@AV11cSolicitudesRelacionesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@AV12cSolicitudesRelacionesFechaModif",GXType.DateTime,8,5) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00JO3;
          prmH00JO3 = new Object[] {
          new ParDef("@AV6cSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV7cRelacionesId",GXType.Decimal,18,0) ,
          new ParDef("@lV8cProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@lV9cEstadoSGTipo",GXType.NChar,3,0) ,
          new ParDef("@lV10cEstadoSGNombre",GXType.NChar,80,0) ,
          new ParDef("@AV11cSolicitudesRelacionesFechaAlta",GXType.DateTime,8,5) ,
          new ParDef("@AV12cSolicitudesRelacionesFechaModif",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H00JO2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JO2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00JO3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00JO3,1, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

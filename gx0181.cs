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
   public class gx0181 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0181( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0181( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pHistoricoSolicitudesID ,
                           out long aP1_pHistoricoRelacionesId )
      {
         this.AV12pHistoricoSolicitudesID = aP0_pHistoricoSolicitudesID;
         this.AV13pHistoricoRelacionesId = 0 ;
         ExecutePrivate();
         aP1_pHistoricoRelacionesId=this.AV13pHistoricoRelacionesId;
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
                  AV13pHistoricoRelacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "pHistoricoRelacionesId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pHistoricoRelacionesId", StringUtil.LTrimStr( (decimal)(AV13pHistoricoRelacionesId), 18, 0));
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
         AV6cHistoricoRelacionesId = (long)(Math.Round(NumberUtil.Val( GetPar( "cHistoricoRelacionesId"), "."), 18, MidpointRounding.ToEven));
         AV7cHistoricoRelacionesProfesionalesId = GetPar( "cHistoricoRelacionesProfesionalesId");
         AV8cHistoricoRelacionesNombre = GetPar( "cHistoricoRelacionesNombre");
         AV9cHistoricoRelacionesApellido = GetPar( "cHistoricoRelacionesApellido");
         AV10cEstadoSGTipo = GetPar( "cEstadoSGTipo");
         AV11cEstadoSGNombre = GetPar( "cEstadoSGNombre");
         AV12pHistoricoSolicitudesID = (long)(Math.Round(NumberUtil.Val( GetPar( "pHistoricoSolicitudesID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cHistoricoRelacionesId, AV7cHistoricoRelacionesProfesionalesId, AV8cHistoricoRelacionesNombre, AV9cHistoricoRelacionesApellido, AV10cEstadoSGTipo, AV11cEstadoSGNombre, AV12pHistoricoSolicitudesID) ;
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
         PA9K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9K2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0181.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pHistoricoSolicitudesID,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pHistoricoRelacionesId,18,0))}, new string[] {"pHistoricoSolicitudesID","pHistoricoRelacionesId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCHISTORICORELACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cHistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCHISTORICORELACIONESPROFESIONALESID", StringUtil.RTrim( AV7cHistoricoRelacionesProfesionalesId));
         GxWebStd.gx_hidden_field( context, "GXH_vCHISTORICORELACIONESNOMBRE", StringUtil.RTrim( AV8cHistoricoRelacionesNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCHISTORICORELACIONESAPELLIDO", StringUtil.RTrim( AV9cHistoricoRelacionesApellido));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOSGTIPO", StringUtil.RTrim( AV10cEstadoSGTipo));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOSGNOMBRE", StringUtil.RTrim( AV11cEstadoSGNombre));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPHISTORICOSOLICITUDESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pHistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPHISTORICORELACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pHistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "HISTORICORELACIONESIDFILTERCONTAINER_Class", StringUtil.RTrim( divHistoricorelacionesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HISTORICORELACIONESPROFESIONALESIDFILTERCONTAINER_Class", StringUtil.RTrim( divHistoricorelacionesprofesionalesidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HISTORICORELACIONESNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divHistoricorelacionesnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HISTORICORELACIONESAPELLIDOFILTERCONTAINER_Class", StringUtil.RTrim( divHistoricorelacionesapellidofiltercontainer_Class));
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
            WE9K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9K2( ) ;
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
         return formatLink("gx0181.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pHistoricoSolicitudesID,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pHistoricoRelacionesId,18,0))}, new string[] {"pHistoricoSolicitudesID","pHistoricoRelacionesId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0181" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Relaciones", "") ;
      }

      protected void WB9K0( )
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
            GxWebStd.gx_div_start( context, divHistoricorelacionesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divHistoricorelacionesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhistoricorelacionesidfilter_Internalname, context.GetMessage( "Correlativo", ""), "", "", lblLblhistoricorelacionesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e119k1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0181.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChistoricorelacionesid_Internalname, context.GetMessage( "Correlativo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChistoricorelacionesid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cHistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavChistoricorelacionesid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cHistoricoRelacionesId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cHistoricoRelacionesId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChistoricorelacionesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavChistoricorelacionesid_Visible, edtavChistoricorelacionesid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0181.htm");
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
            GxWebStd.gx_div_start( context, divHistoricorelacionesprofesionalesidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divHistoricorelacionesprofesionalesidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhistoricorelacionesprofesionalesidfilter_Internalname, context.GetMessage( "Profesional ID", ""), "", "", lblLblhistoricorelacionesprofesionalesidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e129k1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0181.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChistoricorelacionesprofesionalesid_Internalname, context.GetMessage( "Profesional ID", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChistoricorelacionesprofesionalesid_Internalname, StringUtil.RTrim( AV7cHistoricoRelacionesProfesionalesId), StringUtil.RTrim( context.localUtil.Format( AV7cHistoricoRelacionesProfesionalesId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChistoricorelacionesprofesionalesid_Jsonclick, 0, "Attribute", "", "", "", "", edtavChistoricorelacionesprofesionalesid_Visible, edtavChistoricorelacionesprofesionalesid_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0181.htm");
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
            GxWebStd.gx_div_start( context, divHistoricorelacionesnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divHistoricorelacionesnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhistoricorelacionesnombrefilter_Internalname, context.GetMessage( "Nombre", ""), "", "", lblLblhistoricorelacionesnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e139k1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0181.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChistoricorelacionesnombre_Internalname, context.GetMessage( "Nombre", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChistoricorelacionesnombre_Internalname, StringUtil.RTrim( AV8cHistoricoRelacionesNombre), StringUtil.RTrim( context.localUtil.Format( AV8cHistoricoRelacionesNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChistoricorelacionesnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavChistoricorelacionesnombre_Visible, edtavChistoricorelacionesnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0181.htm");
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
            GxWebStd.gx_div_start( context, divHistoricorelacionesapellidofiltercontainer_Internalname, 1, 0, "px", 0, "px", divHistoricorelacionesapellidofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhistoricorelacionesapellidofilter_Internalname, context.GetMessage( "Apellido", ""), "", "", lblLblhistoricorelacionesapellidofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e149k1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0181.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChistoricorelacionesapellido_Internalname, context.GetMessage( "Apellido", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavChistoricorelacionesapellido_Internalname, StringUtil.RTrim( AV9cHistoricoRelacionesApellido), StringUtil.RTrim( context.localUtil.Format( AV9cHistoricoRelacionesApellido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChistoricorelacionesapellido_Jsonclick, 0, "Attribute", "", "", "", "", edtavChistoricorelacionesapellido_Visible, edtavChistoricorelacionesapellido_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0181.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblestadosgtipofilter_Internalname, context.GetMessage( "Estado SGTipo", ""), "", "", lblLblestadosgtipofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e159k1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0181.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCestadosgtipo_Internalname, StringUtil.RTrim( AV10cEstadoSGTipo), StringUtil.RTrim( context.localUtil.Format( AV10cEstadoSGTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCestadosgtipo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCestadosgtipo_Visible, edtavCestadosgtipo_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0181.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblestadosgnombrefilter_Internalname, context.GetMessage( "Estado SGNombre", ""), "", "", lblLblestadosgnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e169k1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0181.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCestadosgnombre_Internalname, StringUtil.RTrim( AV11cEstadoSGNombre), StringUtil.RTrim( context.localUtil.Format( AV11cEstadoSGNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCestadosgnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCestadosgnombre_Visible, edtavCestadosgnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0181.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e179k1_client"+"'", TempTags, "", 2, "HLP_Gx0181.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0181.htm");
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

      protected void START9K2( )
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
         STRUP9K0( ) ;
      }

      protected void WS9K2( )
      {
         START9K2( ) ;
         EVT9K2( ) ;
      }

      protected void EVT9K2( )
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
                              A156HistoricoRelacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoricoRelacionesId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A320HistoricoRelacionesProfesional = cgiGet( edtHistoricoRelacionesProfesional_Internalname);
                              A323HistoricoRelacionesNombre = cgiGet( edtHistoricoRelacionesNombre_Internalname);
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
                                    E189K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E199K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Chistoricorelacionesid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHISTORICORELACIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cHistoricoRelacionesId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chistoricorelacionesprofesionalesid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHISTORICORELACIONESPROFESIONALESID"), AV7cHistoricoRelacionesProfesionalesId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chistoricorelacionesnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHISTORICORELACIONESNOMBRE"), AV8cHistoricoRelacionesNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chistoricorelacionesapellido Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCHISTORICORELACIONESAPELLIDO"), AV9cHistoricoRelacionesApellido) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadosgtipo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSGTIPO"), AV10cEstadoSGTipo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadosgnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSGNOMBRE"), AV11cEstadoSGNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E209K2 ();
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

      protected void WE9K2( )
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

      protected void PA9K2( )
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
                                        long AV6cHistoricoRelacionesId ,
                                        string AV7cHistoricoRelacionesProfesionalesId ,
                                        string AV8cHistoricoRelacionesNombre ,
                                        string AV9cHistoricoRelacionesApellido ,
                                        string AV10cEstadoSGTipo ,
                                        string AV11cEstadoSGNombre ,
                                        long AV12pHistoricoSolicitudesID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF9K2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_HISTORICORELACIONESID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A156HistoricoRelacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "HISTORICORELACIONESID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A156HistoricoRelacionesId), 18, 0, ".", "")));
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
         RF9K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9K2( )
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
                                                 AV7cHistoricoRelacionesProfesionalesId ,
                                                 AV8cHistoricoRelacionesNombre ,
                                                 AV9cHistoricoRelacionesApellido ,
                                                 AV10cEstadoSGTipo ,
                                                 AV11cEstadoSGNombre ,
                                                 A320HistoricoRelacionesProfesional ,
                                                 A323HistoricoRelacionesNombre ,
                                                 A324HistoricoRelacionesApellido ,
                                                 A141EstadoSGTipo ,
                                                 A143EstadoSGNombre ,
                                                 AV12pHistoricoSolicitudesID ,
                                                 AV6cHistoricoRelacionesId ,
                                                 A153HistoricoSolicitudesID } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV7cHistoricoRelacionesProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV7cHistoricoRelacionesProfesionalesId), 20, "%");
            lV8cHistoricoRelacionesNombre = StringUtil.PadR( StringUtil.RTrim( AV8cHistoricoRelacionesNombre), 80, "%");
            lV9cHistoricoRelacionesApellido = StringUtil.PadR( StringUtil.RTrim( AV9cHistoricoRelacionesApellido), 80, "%");
            lV10cEstadoSGTipo = StringUtil.PadR( StringUtil.RTrim( AV10cEstadoSGTipo), 3, "%");
            lV11cEstadoSGNombre = StringUtil.PadR( StringUtil.RTrim( AV11cEstadoSGNombre), 80, "%");
            /* Using cursor H009K2 */
            pr_default.execute(0, new Object[] {AV12pHistoricoSolicitudesID, AV6cHistoricoRelacionesId, lV7cHistoricoRelacionesProfesionalesId, lV8cHistoricoRelacionesNombre, lV9cHistoricoRelacionesApellido, lV10cEstadoSGTipo, lV11cEstadoSGNombre, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A142EstadoSGId = H009K2_A142EstadoSGId[0];
               A143EstadoSGNombre = H009K2_A143EstadoSGNombre[0];
               A141EstadoSGTipo = H009K2_A141EstadoSGTipo[0];
               A324HistoricoRelacionesApellido = H009K2_A324HistoricoRelacionesApellido[0];
               A153HistoricoSolicitudesID = H009K2_A153HistoricoSolicitudesID[0];
               A323HistoricoRelacionesNombre = H009K2_A323HistoricoRelacionesNombre[0];
               A320HistoricoRelacionesProfesional = H009K2_A320HistoricoRelacionesProfesional[0];
               A156HistoricoRelacionesId = H009K2_A156HistoricoRelacionesId[0];
               A143EstadoSGNombre = H009K2_A143EstadoSGNombre[0];
               /* Execute user event: Load */
               E199K2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB9K0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9K2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_HISTORICORELACIONESID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A156HistoricoRelacionesId), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cHistoricoRelacionesProfesionalesId ,
                                              AV8cHistoricoRelacionesNombre ,
                                              AV9cHistoricoRelacionesApellido ,
                                              AV10cEstadoSGTipo ,
                                              AV11cEstadoSGNombre ,
                                              A320HistoricoRelacionesProfesional ,
                                              A323HistoricoRelacionesNombre ,
                                              A324HistoricoRelacionesApellido ,
                                              A141EstadoSGTipo ,
                                              A143EstadoSGNombre ,
                                              AV12pHistoricoSolicitudesID ,
                                              AV6cHistoricoRelacionesId ,
                                              A153HistoricoSolicitudesID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV7cHistoricoRelacionesProfesionalesId = StringUtil.PadR( StringUtil.RTrim( AV7cHistoricoRelacionesProfesionalesId), 20, "%");
         lV8cHistoricoRelacionesNombre = StringUtil.PadR( StringUtil.RTrim( AV8cHistoricoRelacionesNombre), 80, "%");
         lV9cHistoricoRelacionesApellido = StringUtil.PadR( StringUtil.RTrim( AV9cHistoricoRelacionesApellido), 80, "%");
         lV10cEstadoSGTipo = StringUtil.PadR( StringUtil.RTrim( AV10cEstadoSGTipo), 3, "%");
         lV11cEstadoSGNombre = StringUtil.PadR( StringUtil.RTrim( AV11cEstadoSGNombre), 80, "%");
         /* Using cursor H009K3 */
         pr_default.execute(1, new Object[] {AV12pHistoricoSolicitudesID, AV6cHistoricoRelacionesId, lV7cHistoricoRelacionesProfesionalesId, lV8cHistoricoRelacionesNombre, lV9cHistoricoRelacionesApellido, lV10cEstadoSGTipo, lV11cEstadoSGNombre});
         GRID1_nRecordCount = H009K3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHistoricoRelacionesId, AV7cHistoricoRelacionesProfesionalesId, AV8cHistoricoRelacionesNombre, AV9cHistoricoRelacionesApellido, AV10cEstadoSGTipo, AV11cEstadoSGNombre, AV12pHistoricoSolicitudesID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHistoricoRelacionesId, AV7cHistoricoRelacionesProfesionalesId, AV8cHistoricoRelacionesNombre, AV9cHistoricoRelacionesApellido, AV10cEstadoSGTipo, AV11cEstadoSGNombre, AV12pHistoricoSolicitudesID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHistoricoRelacionesId, AV7cHistoricoRelacionesProfesionalesId, AV8cHistoricoRelacionesNombre, AV9cHistoricoRelacionesApellido, AV10cEstadoSGTipo, AV11cEstadoSGNombre, AV12pHistoricoSolicitudesID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHistoricoRelacionesId, AV7cHistoricoRelacionesProfesionalesId, AV8cHistoricoRelacionesNombre, AV9cHistoricoRelacionesApellido, AV10cEstadoSGTipo, AV11cEstadoSGNombre, AV12pHistoricoSolicitudesID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cHistoricoRelacionesId, AV7cHistoricoRelacionesProfesionalesId, AV8cHistoricoRelacionesNombre, AV9cHistoricoRelacionesApellido, AV10cEstadoSGTipo, AV11cEstadoSGNombre, AV12pHistoricoSolicitudesID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtHistoricoRelacionesId_Enabled = 0;
         edtHistoricoRelacionesProfesional_Enabled = 0;
         edtHistoricoRelacionesNombre_Enabled = 0;
         edtHistoricoSolicitudesID_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E189K2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavChistoricorelacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavChistoricorelacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCHISTORICORELACIONESID");
               GX_FocusControl = edtavChistoricorelacionesid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cHistoricoRelacionesId = 0;
               AssignAttri("", false, "AV6cHistoricoRelacionesId", StringUtil.LTrimStr( (decimal)(AV6cHistoricoRelacionesId), 18, 0));
            }
            else
            {
               AV6cHistoricoRelacionesId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavChistoricorelacionesid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cHistoricoRelacionesId", StringUtil.LTrimStr( (decimal)(AV6cHistoricoRelacionesId), 18, 0));
            }
            AV7cHistoricoRelacionesProfesionalesId = cgiGet( edtavChistoricorelacionesprofesionalesid_Internalname);
            AssignAttri("", false, "AV7cHistoricoRelacionesProfesionalesId", AV7cHistoricoRelacionesProfesionalesId);
            AV8cHistoricoRelacionesNombre = cgiGet( edtavChistoricorelacionesnombre_Internalname);
            AssignAttri("", false, "AV8cHistoricoRelacionesNombre", AV8cHistoricoRelacionesNombre);
            AV9cHistoricoRelacionesApellido = cgiGet( edtavChistoricorelacionesapellido_Internalname);
            AssignAttri("", false, "AV9cHistoricoRelacionesApellido", AV9cHistoricoRelacionesApellido);
            AV10cEstadoSGTipo = cgiGet( edtavCestadosgtipo_Internalname);
            AssignAttri("", false, "AV10cEstadoSGTipo", AV10cEstadoSGTipo);
            AV11cEstadoSGNombre = cgiGet( edtavCestadosgnombre_Internalname);
            AssignAttri("", false, "AV11cEstadoSGNombre", AV11cEstadoSGNombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCHISTORICORELACIONESID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cHistoricoRelacionesId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHISTORICORELACIONESPROFESIONALESID"), AV7cHistoricoRelacionesProfesionalesId) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHISTORICORELACIONESNOMBRE"), AV8cHistoricoRelacionesNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCHISTORICORELACIONESAPELLIDO"), AV9cHistoricoRelacionesApellido) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSGTIPO"), AV10cEstadoSGTipo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSGNOMBRE"), AV11cEstadoSGNombre) != 0 )
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
         E189K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E189K2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Relaciones", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E199K2( )
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
         E209K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E209K2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pHistoricoRelacionesId = A156HistoricoRelacionesId;
         AssignAttri("", false, "AV13pHistoricoRelacionesId", StringUtil.LTrimStr( (decimal)(AV13pHistoricoRelacionesId), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pHistoricoRelacionesId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pHistoricoRelacionesId"});
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
         AV13pHistoricoRelacionesId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV13pHistoricoRelacionesId", StringUtil.LTrimStr( (decimal)(AV13pHistoricoRelacionesId), 18, 0));
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
         PA9K2( ) ;
         WS9K2( ) ;
         WE9K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20268622295372", true, true, false);
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
         context.AddJavascriptSource("gx0181.js", "?20268622295372", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtHistoricoRelacionesId_Internalname = "HISTORICORELACIONESID_"+sGXsfl_74_idx;
         edtHistoricoRelacionesProfesional_Internalname = "HISTORICORELACIONESPROFESIONAL_"+sGXsfl_74_idx;
         edtHistoricoRelacionesNombre_Internalname = "HISTORICORELACIONESNOMBRE_"+sGXsfl_74_idx;
         edtHistoricoSolicitudesID_Internalname = "HISTORICOSOLICITUDESID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtHistoricoRelacionesId_Internalname = "HISTORICORELACIONESID_"+sGXsfl_74_fel_idx;
         edtHistoricoRelacionesProfesional_Internalname = "HISTORICORELACIONESPROFESIONAL_"+sGXsfl_74_fel_idx;
         edtHistoricoRelacionesNombre_Internalname = "HISTORICORELACIONESNOMBRE_"+sGXsfl_74_fel_idx;
         edtHistoricoSolicitudesID_Internalname = "HISTORICOSOLICITUDESID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WB9K0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A156HistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A156HistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A156HistoricoRelacionesId), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtHistoricoRelacionesProfesional_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A156HistoricoRelacionesId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtHistoricoRelacionesProfesional_Internalname, "Link", edtHistoricoRelacionesProfesional_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesProfesional_Internalname,StringUtil.RTrim( A320HistoricoRelacionesProfesional),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtHistoricoRelacionesProfesional_Link,(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesProfesional_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoRelacionesNombre_Internalname,StringUtil.RTrim( A323HistoricoRelacionesNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoRelacionesNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHistoricoSolicitudesID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A153HistoricoSolicitudesID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A153HistoricoSolicitudesID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHistoricoSolicitudesID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes9K2( ) ;
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
            context.SendWebValue( context.GetMessage( "Correlativo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A156HistoricoRelacionesId), 18, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A320HistoricoRelacionesProfesional)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtHistoricoRelacionesProfesional_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A323HistoricoRelacionesNombre)));
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
         lblLblhistoricorelacionesidfilter_Internalname = "LBLHISTORICORELACIONESIDFILTER";
         edtavChistoricorelacionesid_Internalname = "vCHISTORICORELACIONESID";
         divHistoricorelacionesidfiltercontainer_Internalname = "HISTORICORELACIONESIDFILTERCONTAINER";
         lblLblhistoricorelacionesprofesionalesidfilter_Internalname = "LBLHISTORICORELACIONESPROFESIONALESIDFILTER";
         edtavChistoricorelacionesprofesionalesid_Internalname = "vCHISTORICORELACIONESPROFESIONALESID";
         divHistoricorelacionesprofesionalesidfiltercontainer_Internalname = "HISTORICORELACIONESPROFESIONALESIDFILTERCONTAINER";
         lblLblhistoricorelacionesnombrefilter_Internalname = "LBLHISTORICORELACIONESNOMBREFILTER";
         edtavChistoricorelacionesnombre_Internalname = "vCHISTORICORELACIONESNOMBRE";
         divHistoricorelacionesnombrefiltercontainer_Internalname = "HISTORICORELACIONESNOMBREFILTERCONTAINER";
         lblLblhistoricorelacionesapellidofilter_Internalname = "LBLHISTORICORELACIONESAPELLIDOFILTER";
         edtavChistoricorelacionesapellido_Internalname = "vCHISTORICORELACIONESAPELLIDO";
         divHistoricorelacionesapellidofiltercontainer_Internalname = "HISTORICORELACIONESAPELLIDOFILTERCONTAINER";
         lblLblestadosgtipofilter_Internalname = "LBLESTADOSGTIPOFILTER";
         edtavCestadosgtipo_Internalname = "vCESTADOSGTIPO";
         divEstadosgtipofiltercontainer_Internalname = "ESTADOSGTIPOFILTERCONTAINER";
         lblLblestadosgnombrefilter_Internalname = "LBLESTADOSGNOMBREFILTER";
         edtavCestadosgnombre_Internalname = "vCESTADOSGNOMBRE";
         divEstadosgnombrefiltercontainer_Internalname = "ESTADOSGNOMBREFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtHistoricoRelacionesId_Internalname = "HISTORICORELACIONESID";
         edtHistoricoRelacionesProfesional_Internalname = "HISTORICORELACIONESPROFESIONAL";
         edtHistoricoRelacionesNombre_Internalname = "HISTORICORELACIONESNOMBRE";
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
         edtHistoricoRelacionesNombre_Jsonclick = "";
         edtHistoricoRelacionesProfesional_Jsonclick = "";
         edtHistoricoRelacionesProfesional_Link = "";
         edtHistoricoRelacionesId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtHistoricoSolicitudesID_Enabled = 0;
         edtHistoricoRelacionesNombre_Enabled = 0;
         edtHistoricoRelacionesProfesional_Enabled = 0;
         edtHistoricoRelacionesId_Enabled = 0;
         edtavCestadosgnombre_Jsonclick = "";
         edtavCestadosgnombre_Enabled = 1;
         edtavCestadosgnombre_Visible = 1;
         edtavCestadosgtipo_Jsonclick = "";
         edtavCestadosgtipo_Enabled = 1;
         edtavCestadosgtipo_Visible = 1;
         edtavChistoricorelacionesapellido_Jsonclick = "";
         edtavChistoricorelacionesapellido_Enabled = 1;
         edtavChistoricorelacionesapellido_Visible = 1;
         edtavChistoricorelacionesnombre_Jsonclick = "";
         edtavChistoricorelacionesnombre_Enabled = 1;
         edtavChistoricorelacionesnombre_Visible = 1;
         edtavChistoricorelacionesprofesionalesid_Jsonclick = "";
         edtavChistoricorelacionesprofesionalesid_Enabled = 1;
         edtavChistoricorelacionesprofesionalesid_Visible = 1;
         edtavChistoricorelacionesid_Jsonclick = "";
         edtavChistoricorelacionesid_Enabled = 1;
         edtavChistoricorelacionesid_Visible = 1;
         divEstadosgnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divEstadosgtipofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divHistoricorelacionesapellidofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divHistoricorelacionesnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divHistoricorelacionesprofesionalesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divHistoricorelacionesidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHistoricoRelacionesId',fld:'vCHISTORICORELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cHistoricoRelacionesProfesionalesId',fld:'vCHISTORICORELACIONESPROFESIONALESID',pic:'',type:'char'},{av:'AV8cHistoricoRelacionesNombre',fld:'vCHISTORICORELACIONESNOMBRE',pic:'',type:'char'},{av:'AV9cHistoricoRelacionesApellido',fld:'vCHISTORICORELACIONESAPELLIDO',pic:'',type:'char'},{av:'AV10cEstadoSGTipo',fld:'vCESTADOSGTIPO',pic:'',type:'char'},{av:'AV11cEstadoSGNombre',fld:'vCESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV12pHistoricoSolicitudesID',fld:'vPHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E179K1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLHISTORICORELACIONESIDFILTER.CLICK","{handler:'E119K1',iparms:[{av:'divHistoricorelacionesidfiltercontainer_Class',ctrl:'HISTORICORELACIONESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHISTORICORELACIONESIDFILTER.CLICK",",oparms:[{av:'divHistoricorelacionesidfiltercontainer_Class',ctrl:'HISTORICORELACIONESIDFILTERCONTAINER',prop:'Class'},{av:'edtavChistoricorelacionesid_Visible',ctrl:'vCHISTORICORELACIONESID',prop:'Visible'}]}");
         setEventMetadata("LBLHISTORICORELACIONESPROFESIONALESIDFILTER.CLICK","{handler:'E129K1',iparms:[{av:'divHistoricorelacionesprofesionalesidfiltercontainer_Class',ctrl:'HISTORICORELACIONESPROFESIONALESIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHISTORICORELACIONESPROFESIONALESIDFILTER.CLICK",",oparms:[{av:'divHistoricorelacionesprofesionalesidfiltercontainer_Class',ctrl:'HISTORICORELACIONESPROFESIONALESIDFILTERCONTAINER',prop:'Class'},{av:'edtavChistoricorelacionesprofesionalesid_Visible',ctrl:'vCHISTORICORELACIONESPROFESIONALESID',prop:'Visible'}]}");
         setEventMetadata("LBLHISTORICORELACIONESNOMBREFILTER.CLICK","{handler:'E139K1',iparms:[{av:'divHistoricorelacionesnombrefiltercontainer_Class',ctrl:'HISTORICORELACIONESNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHISTORICORELACIONESNOMBREFILTER.CLICK",",oparms:[{av:'divHistoricorelacionesnombrefiltercontainer_Class',ctrl:'HISTORICORELACIONESNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavChistoricorelacionesnombre_Visible',ctrl:'vCHISTORICORELACIONESNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLHISTORICORELACIONESAPELLIDOFILTER.CLICK","{handler:'E149K1',iparms:[{av:'divHistoricorelacionesapellidofiltercontainer_Class',ctrl:'HISTORICORELACIONESAPELLIDOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHISTORICORELACIONESAPELLIDOFILTER.CLICK",",oparms:[{av:'divHistoricorelacionesapellidofiltercontainer_Class',ctrl:'HISTORICORELACIONESAPELLIDOFILTERCONTAINER',prop:'Class'},{av:'edtavChistoricorelacionesapellido_Visible',ctrl:'vCHISTORICORELACIONESAPELLIDO',prop:'Visible'}]}");
         setEventMetadata("LBLESTADOSGTIPOFILTER.CLICK","{handler:'E159K1',iparms:[{av:'divEstadosgtipofiltercontainer_Class',ctrl:'ESTADOSGTIPOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTADOSGTIPOFILTER.CLICK",",oparms:[{av:'divEstadosgtipofiltercontainer_Class',ctrl:'ESTADOSGTIPOFILTERCONTAINER',prop:'Class'},{av:'edtavCestadosgtipo_Visible',ctrl:'vCESTADOSGTIPO',prop:'Visible'}]}");
         setEventMetadata("LBLESTADOSGNOMBREFILTER.CLICK","{handler:'E169K1',iparms:[{av:'divEstadosgnombrefiltercontainer_Class',ctrl:'ESTADOSGNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTADOSGNOMBREFILTER.CLICK",",oparms:[{av:'divEstadosgnombrefiltercontainer_Class',ctrl:'ESTADOSGNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCestadosgnombre_Visible',ctrl:'vCESTADOSGNOMBRE',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E209K2',iparms:[{av:'A156HistoricoRelacionesId',fld:'HISTORICORELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pHistoricoRelacionesId',fld:'vPHISTORICORELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHistoricoRelacionesId',fld:'vCHISTORICORELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cHistoricoRelacionesProfesionalesId',fld:'vCHISTORICORELACIONESPROFESIONALESID',pic:'',type:'char'},{av:'AV8cHistoricoRelacionesNombre',fld:'vCHISTORICORELACIONESNOMBRE',pic:'',type:'char'},{av:'AV9cHistoricoRelacionesApellido',fld:'vCHISTORICORELACIONESAPELLIDO',pic:'',type:'char'},{av:'AV10cEstadoSGTipo',fld:'vCESTADOSGTIPO',pic:'',type:'char'},{av:'AV11cEstadoSGNombre',fld:'vCESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV12pHistoricoSolicitudesID',fld:'vPHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHistoricoRelacionesId',fld:'vCHISTORICORELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cHistoricoRelacionesProfesionalesId',fld:'vCHISTORICORELACIONESPROFESIONALESID',pic:'',type:'char'},{av:'AV8cHistoricoRelacionesNombre',fld:'vCHISTORICORELACIONESNOMBRE',pic:'',type:'char'},{av:'AV9cHistoricoRelacionesApellido',fld:'vCHISTORICORELACIONESAPELLIDO',pic:'',type:'char'},{av:'AV10cEstadoSGTipo',fld:'vCESTADOSGTIPO',pic:'',type:'char'},{av:'AV11cEstadoSGNombre',fld:'vCESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV12pHistoricoSolicitudesID',fld:'vPHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHistoricoRelacionesId',fld:'vCHISTORICORELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cHistoricoRelacionesProfesionalesId',fld:'vCHISTORICORELACIONESPROFESIONALESID',pic:'',type:'char'},{av:'AV8cHistoricoRelacionesNombre',fld:'vCHISTORICORELACIONESNOMBRE',pic:'',type:'char'},{av:'AV9cHistoricoRelacionesApellido',fld:'vCHISTORICORELACIONESAPELLIDO',pic:'',type:'char'},{av:'AV10cEstadoSGTipo',fld:'vCESTADOSGTIPO',pic:'',type:'char'},{av:'AV11cEstadoSGNombre',fld:'vCESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV12pHistoricoSolicitudesID',fld:'vPHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cHistoricoRelacionesId',fld:'vCHISTORICORELACIONESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cHistoricoRelacionesProfesionalesId',fld:'vCHISTORICORELACIONESPROFESIONALESID',pic:'',type:'char'},{av:'AV8cHistoricoRelacionesNombre',fld:'vCHISTORICORELACIONESNOMBRE',pic:'',type:'char'},{av:'AV9cHistoricoRelacionesApellido',fld:'vCHISTORICORELACIONESAPELLIDO',pic:'',type:'char'},{av:'AV10cEstadoSGTipo',fld:'vCESTADOSGTIPO',pic:'',type:'char'},{av:'AV11cEstadoSGNombre',fld:'vCESTADOSGNOMBRE',pic:'',type:'char'},{av:'AV12pHistoricoSolicitudesID',fld:'vPHISTORICOSOLICITUDESID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]");
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
         AV7cHistoricoRelacionesProfesionalesId = "";
         AV8cHistoricoRelacionesNombre = "";
         AV9cHistoricoRelacionesApellido = "";
         AV10cEstadoSGTipo = "";
         AV11cEstadoSGNombre = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblhistoricorelacionesidfilter_Jsonclick = "";
         TempTags = "";
         lblLblhistoricorelacionesprofesionalesidfilter_Jsonclick = "";
         lblLblhistoricorelacionesnombrefilter_Jsonclick = "";
         lblLblhistoricorelacionesapellidofilter_Jsonclick = "";
         lblLblestadosgtipofilter_Jsonclick = "";
         lblLblestadosgnombrefilter_Jsonclick = "";
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
         A320HistoricoRelacionesProfesional = "";
         A323HistoricoRelacionesNombre = "";
         lV7cHistoricoRelacionesProfesionalesId = "";
         lV8cHistoricoRelacionesNombre = "";
         lV9cHistoricoRelacionesApellido = "";
         lV10cEstadoSGTipo = "";
         lV11cEstadoSGNombre = "";
         A324HistoricoRelacionesApellido = "";
         A141EstadoSGTipo = "";
         A143EstadoSGNombre = "";
         H009K2_A142EstadoSGId = new int[1] ;
         H009K2_A143EstadoSGNombre = new string[] {""} ;
         H009K2_A141EstadoSGTipo = new string[] {""} ;
         H009K2_A324HistoricoRelacionesApellido = new string[] {""} ;
         H009K2_A153HistoricoSolicitudesID = new long[1] ;
         H009K2_A323HistoricoRelacionesNombre = new string[] {""} ;
         H009K2_A320HistoricoRelacionesProfesional = new string[] {""} ;
         H009K2_A156HistoricoRelacionesId = new long[1] ;
         H009K3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0181__default(),
            new Object[][] {
                new Object[] {
               H009K2_A142EstadoSGId, H009K2_A143EstadoSGNombre, H009K2_A141EstadoSGTipo, H009K2_A324HistoricoRelacionesApellido, H009K2_A153HistoricoSolicitudesID, H009K2_A323HistoricoRelacionesNombre, H009K2_A320HistoricoRelacionesProfesional, H009K2_A156HistoricoRelacionesId
               }
               , new Object[] {
               H009K3_AGRID1_nRecordCount
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
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavChistoricorelacionesid_Enabled ;
      private int edtavChistoricorelacionesid_Visible ;
      private int edtavChistoricorelacionesprofesionalesid_Visible ;
      private int edtavChistoricorelacionesprofesionalesid_Enabled ;
      private int edtavChistoricorelacionesnombre_Visible ;
      private int edtavChistoricorelacionesnombre_Enabled ;
      private int edtavChistoricorelacionesapellido_Visible ;
      private int edtavChistoricorelacionesapellido_Enabled ;
      private int edtavCestadosgtipo_Visible ;
      private int edtavCestadosgtipo_Enabled ;
      private int edtavCestadosgnombre_Visible ;
      private int edtavCestadosgnombre_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A142EstadoSGId ;
      private int edtHistoricoRelacionesId_Enabled ;
      private int edtHistoricoRelacionesProfesional_Enabled ;
      private int edtHistoricoRelacionesNombre_Enabled ;
      private int edtHistoricoSolicitudesID_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pHistoricoSolicitudesID ;
      private long AV13pHistoricoRelacionesId ;
      private long wcpOAV12pHistoricoSolicitudesID ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cHistoricoRelacionesId ;
      private long A156HistoricoRelacionesId ;
      private long A153HistoricoSolicitudesID ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divHistoricorelacionesidfiltercontainer_Class ;
      private string divHistoricorelacionesprofesionalesidfiltercontainer_Class ;
      private string divHistoricorelacionesnombrefiltercontainer_Class ;
      private string divHistoricorelacionesapellidofiltercontainer_Class ;
      private string divEstadosgtipofiltercontainer_Class ;
      private string divEstadosgnombrefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV7cHistoricoRelacionesProfesionalesId ;
      private string AV8cHistoricoRelacionesNombre ;
      private string AV9cHistoricoRelacionesApellido ;
      private string AV10cEstadoSGTipo ;
      private string AV11cEstadoSGNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divHistoricorelacionesidfiltercontainer_Internalname ;
      private string lblLblhistoricorelacionesidfilter_Internalname ;
      private string lblLblhistoricorelacionesidfilter_Jsonclick ;
      private string edtavChistoricorelacionesid_Internalname ;
      private string TempTags ;
      private string edtavChistoricorelacionesid_Jsonclick ;
      private string divHistoricorelacionesprofesionalesidfiltercontainer_Internalname ;
      private string lblLblhistoricorelacionesprofesionalesidfilter_Internalname ;
      private string lblLblhistoricorelacionesprofesionalesidfilter_Jsonclick ;
      private string edtavChistoricorelacionesprofesionalesid_Internalname ;
      private string edtavChistoricorelacionesprofesionalesid_Jsonclick ;
      private string divHistoricorelacionesnombrefiltercontainer_Internalname ;
      private string lblLblhistoricorelacionesnombrefilter_Internalname ;
      private string lblLblhistoricorelacionesnombrefilter_Jsonclick ;
      private string edtavChistoricorelacionesnombre_Internalname ;
      private string edtavChistoricorelacionesnombre_Jsonclick ;
      private string divHistoricorelacionesapellidofiltercontainer_Internalname ;
      private string lblLblhistoricorelacionesapellidofilter_Internalname ;
      private string lblLblhistoricorelacionesapellidofilter_Jsonclick ;
      private string edtavChistoricorelacionesapellido_Internalname ;
      private string edtavChistoricorelacionesapellido_Jsonclick ;
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
      private string edtHistoricoRelacionesId_Internalname ;
      private string A320HistoricoRelacionesProfesional ;
      private string edtHistoricoRelacionesProfesional_Internalname ;
      private string A323HistoricoRelacionesNombre ;
      private string edtHistoricoRelacionesNombre_Internalname ;
      private string edtHistoricoSolicitudesID_Internalname ;
      private string lV7cHistoricoRelacionesProfesionalesId ;
      private string lV8cHistoricoRelacionesNombre ;
      private string lV9cHistoricoRelacionesApellido ;
      private string lV10cEstadoSGTipo ;
      private string lV11cEstadoSGNombre ;
      private string A324HistoricoRelacionesApellido ;
      private string A141EstadoSGTipo ;
      private string A143EstadoSGNombre ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtHistoricoRelacionesId_Jsonclick ;
      private string edtHistoricoRelacionesProfesional_Link ;
      private string edtHistoricoRelacionesProfesional_Jsonclick ;
      private string edtHistoricoRelacionesNombre_Jsonclick ;
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
      private int[] H009K2_A142EstadoSGId ;
      private string[] H009K2_A143EstadoSGNombre ;
      private string[] H009K2_A141EstadoSGTipo ;
      private string[] H009K2_A324HistoricoRelacionesApellido ;
      private long[] H009K2_A153HistoricoSolicitudesID ;
      private string[] H009K2_A323HistoricoRelacionesNombre ;
      private string[] H009K2_A320HistoricoRelacionesProfesional ;
      private long[] H009K2_A156HistoricoRelacionesId ;
      private long[] H009K3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP1_pHistoricoRelacionesId ;
   }

   public class gx0181__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009K2( IGxContext context ,
                                             string AV7cHistoricoRelacionesProfesionalesId ,
                                             string AV8cHistoricoRelacionesNombre ,
                                             string AV9cHistoricoRelacionesApellido ,
                                             string AV10cEstadoSGTipo ,
                                             string AV11cEstadoSGNombre ,
                                             string A320HistoricoRelacionesProfesional ,
                                             string A323HistoricoRelacionesNombre ,
                                             string A324HistoricoRelacionesApellido ,
                                             string A141EstadoSGTipo ,
                                             string A143EstadoSGNombre ,
                                             long AV12pHistoricoSolicitudesID ,
                                             long AV6cHistoricoRelacionesId ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[EstadoSGId] AS EstadoSGId, T2.[EstadosGenericosNombre] AS EstadoSGNombre, T1.[EstadoSGTipo] AS EstadoSGTipo, T1.[HistoricoRelacionesApellido], T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesNombre], T1.[HistoricoRelacionesProfesional], T1.[HistoricoRelacionesId]";
         sFromString = " FROM ([HistoricoRelacionesRelaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV12pHistoricoSolicitudesID and T1.[HistoricoRelacionesId] >= @AV6cHistoricoRelacionesId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cHistoricoRelacionesProfesionalesId)) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesProfesional] like @lV7cHistoricoRelacionesProfesionalesId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cHistoricoRelacionesNombre)) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesNombre] like @lV8cHistoricoRelacionesNombre)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cHistoricoRelacionesApellido)) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesApellido] like @lV9cHistoricoRelacionesApellido)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cEstadoSGTipo)) )
         {
            AddWhere(sWhereString, "(T1.[EstadoSGTipo] like @lV10cEstadoSGTipo)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cEstadoSGNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] like @lV11cEstadoSGNombre)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY T1.[HistoricoSolicitudesID], T1.[HistoricoRelacionesId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H009K3( IGxContext context ,
                                             string AV7cHistoricoRelacionesProfesionalesId ,
                                             string AV8cHistoricoRelacionesNombre ,
                                             string AV9cHistoricoRelacionesApellido ,
                                             string AV10cEstadoSGTipo ,
                                             string AV11cEstadoSGNombre ,
                                             string A320HistoricoRelacionesProfesional ,
                                             string A323HistoricoRelacionesNombre ,
                                             string A324HistoricoRelacionesApellido ,
                                             string A141EstadoSGTipo ,
                                             string A143EstadoSGNombre ,
                                             long AV12pHistoricoSolicitudesID ,
                                             long AV6cHistoricoRelacionesId ,
                                             long A153HistoricoSolicitudesID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ([HistoricoRelacionesRelaciones] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadoSGTipo] AND T2.[EstadosGenericosId] = T1.[EstadoSGId])";
         AddWhere(sWhereString, "(T1.[HistoricoSolicitudesID] = @AV12pHistoricoSolicitudesID and T1.[HistoricoRelacionesId] >= @AV6cHistoricoRelacionesId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cHistoricoRelacionesProfesionalesId)) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesProfesional] like @lV7cHistoricoRelacionesProfesionalesId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cHistoricoRelacionesNombre)) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesNombre] like @lV8cHistoricoRelacionesNombre)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cHistoricoRelacionesApellido)) )
         {
            AddWhere(sWhereString, "(T1.[HistoricoRelacionesApellido] like @lV9cHistoricoRelacionesApellido)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cEstadoSGTipo)) )
         {
            AddWhere(sWhereString, "(T1.[EstadoSGTipo] like @lV10cEstadoSGTipo)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cEstadoSGNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] like @lV11cEstadoSGNombre)");
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
                     return conditional_H009K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H009K3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH009K2;
          prmH009K2 = new Object[] {
          new ParDef("@AV12pHistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV6cHistoricoRelacionesId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cHistoricoRelacionesProfesionalesId",GXType.NChar,20,0) ,
          new ParDef("@lV8cHistoricoRelacionesNombre",GXType.NChar,80,0) ,
          new ParDef("@lV9cHistoricoRelacionesApellido",GXType.NChar,80,0) ,
          new ParDef("@lV10cEstadoSGTipo",GXType.NChar,3,0) ,
          new ParDef("@lV11cEstadoSGNombre",GXType.NChar,80,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009K3;
          prmH009K3 = new Object[] {
          new ParDef("@AV12pHistoricoSolicitudesID",GXType.Decimal,18,0) ,
          new ParDef("@AV6cHistoricoRelacionesId",GXType.Decimal,18,0) ,
          new ParDef("@lV7cHistoricoRelacionesProfesionalesId",GXType.NChar,20,0) ,
          new ParDef("@lV8cHistoricoRelacionesNombre",GXType.NChar,80,0) ,
          new ParDef("@lV9cHistoricoRelacionesApellido",GXType.NChar,80,0) ,
          new ParDef("@lV10cEstadoSGTipo",GXType.NChar,3,0) ,
          new ParDef("@lV11cEstadoSGNombre",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H009K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009K2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009K3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

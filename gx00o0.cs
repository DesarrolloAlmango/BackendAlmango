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
   public class gx00o0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00o0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx00o0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_pEstadosTipo ,
                           out int aP1_pEstadosGenericosId )
      {
         this.AV11pEstadosTipo = "" ;
         this.AV12pEstadosGenericosId = 0 ;
         ExecutePrivate();
         aP0_pEstadosTipo=this.AV11pEstadosTipo;
         aP1_pEstadosGenericosId=this.AV12pEstadosGenericosId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCestadosnotificacioncliente = new GXCheckbox();
         chkavCestadosnotificacionprofesional = new GXCheckbox();
         chkavCestadosnotificacionoperador = new GXCheckbox();
         dynEstadosGenericosId = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pEstadosTipo");
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
               gxfirstwebparm = GetFirstPar( "pEstadosTipo");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pEstadosTipo");
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
               AV11pEstadosTipo = gxfirstwebparm;
               AssignAttri("", false, "AV11pEstadosTipo", AV11pEstadosTipo);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12pEstadosGenericosId = (int)(Math.Round(NumberUtil.Val( GetPar( "pEstadosGenericosId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12pEstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV12pEstadosGenericosId), 5, 0));
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
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
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
         AV6cEstadosTipo = GetPar( "cEstadosTipo");
         AV7cEstadosGenericosNombre = GetPar( "cEstadosGenericosNombre");
         AV8cEstadosNotificacionCliente = GetPar( "cEstadosNotificacionCliente");
         AV9cEstadosNotificacionProfesional = GetPar( "cEstadosNotificacionProfesional");
         AV10cEstadosNotificacionOperador = GetPar( "cEstadosNotificacionOperador");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cEstadosTipo, AV7cEstadosGenericosNombre, AV8cEstadosNotificacionCliente, AV9cEstadosNotificacionProfesional, AV10cEstadosNotificacionOperador) ;
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
         PA992( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START992( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00o0.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11pEstadosTipo)),UrlEncode(StringUtil.LTrimStr(AV12pEstadosGenericosId,5,0))}, new string[] {"pEstadosTipo","pEstadosGenericosId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOSTIPO", StringUtil.RTrim( AV6cEstadosTipo));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOSGENERICOSNOMBRE", StringUtil.RTrim( AV7cEstadosGenericosNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOSNOTIFICACIONCLIENTE", StringUtil.RTrim( AV8cEstadosNotificacionCliente));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOSNOTIFICACIONPROFESIONAL", StringUtil.RTrim( AV9cEstadosNotificacionProfesional));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOSNOTIFICACIONOPERADOR", StringUtil.RTrim( AV10cEstadosNotificacionOperador));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPESTADOSTIPO", StringUtil.RTrim( AV11pEstadosTipo));
         GxWebStd.gx_hidden_field( context, "vPESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pEstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "ESTADOSTIPOFILTERCONTAINER_Class", StringUtil.RTrim( divEstadostipofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divEstadosgenericosnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESTADOSNOTIFICACIONCLIENTEFILTERCONTAINER_Class", StringUtil.RTrim( divEstadosnotificacionclientefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESTADOSNOTIFICACIONPROFESIONALFILTERCONTAINER_Class", StringUtil.RTrim( divEstadosnotificacionprofesionalfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESTADOSNOTIFICACIONOPERADORFILTERCONTAINER_Class", StringUtil.RTrim( divEstadosnotificacionoperadorfiltercontainer_Class));
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
            WE992( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT992( ) ;
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
         return formatLink("gx00o0.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11pEstadosTipo)),UrlEncode(StringUtil.LTrimStr(AV12pEstadosGenericosId,5,0))}, new string[] {"pEstadosTipo","pEstadosGenericosId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00O0" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Genericos", "") ;
      }

      protected void WB990( )
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
            GxWebStd.gx_div_start( context, divEstadostipofiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstadostipofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestadostipofilter_Internalname, context.GetMessage( "Tipo de Estados", ""), "", "", lblLblestadostipofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11991_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00O0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCestadostipo_Internalname, StringUtil.RTrim( AV6cEstadosTipo), StringUtil.RTrim( context.localUtil.Format( AV6cEstadosTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCestadostipo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCestadostipo_Visible, edtavCestadostipo_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00O0.htm");
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
            GxWebStd.gx_div_start( context, divEstadosgenericosnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstadosgenericosnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestadosgenericosnombrefilter_Internalname, context.GetMessage( "Estado", ""), "", "", lblLblestadosgenericosnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12991_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00O0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCestadosgenericosnombre_Internalname, context.GetMessage( "Estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCestadosgenericosnombre_Internalname, StringUtil.RTrim( AV7cEstadosGenericosNombre), StringUtil.RTrim( context.localUtil.Format( AV7cEstadosGenericosNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCestadosgenericosnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCestadosgenericosnombre_Visible, edtavCestadosgenericosnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx00O0.htm");
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
            GxWebStd.gx_div_start( context, divEstadosnotificacionclientefiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstadosnotificacionclientefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestadosnotificacionclientefilter_Internalname, context.GetMessage( "Notificar al cliente el nuevo estado", ""), "", "", lblLblestadosnotificacionclientefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13991_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00O0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCestadosnotificacioncliente_Internalname, context.GetMessage( "Notificar al cliente el nuevo estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCestadosnotificacioncliente_Internalname, AV8cEstadosNotificacionCliente, "", context.GetMessage( "Notificar al cliente el nuevo estado", ""), chkavCestadosnotificacioncliente.Visible, chkavCestadosnotificacioncliente.Enabled, "S", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,36);\"");
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
            GxWebStd.gx_div_start( context, divEstadosnotificacionprofesionalfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstadosnotificacionprofesionalfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestadosnotificacionprofesionalfilter_Internalname, context.GetMessage( "Notificar al profesional el nuevo estado", ""), "", "", lblLblestadosnotificacionprofesionalfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14991_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00O0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCestadosnotificacionprofesional_Internalname, context.GetMessage( "Notificar al profesional el nuevo estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCestadosnotificacionprofesional_Internalname, AV9cEstadosNotificacionProfesional, "", context.GetMessage( "Notificar al profesional el nuevo estado", ""), chkavCestadosnotificacionprofesional.Visible, chkavCestadosnotificacionprofesional.Enabled, "S", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(46, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,46);\"");
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
            GxWebStd.gx_div_start( context, divEstadosnotificacionoperadorfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstadosnotificacionoperadorfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestadosnotificacionoperadorfilter_Internalname, context.GetMessage( "Notificar al operador el nuevo estado", ""), "", "", lblLblestadosnotificacionoperadorfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15991_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00O0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCestadosnotificacionoperador_Internalname, context.GetMessage( "Notificar al operador el nuevo estado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCestadosnotificacionoperador_Internalname, AV10cEstadosNotificacionOperador, "", context.GetMessage( "Notificar al operador el nuevo estado", ""), chkavCestadosnotificacionoperador.Visible, chkavCestadosnotificacionoperador.Enabled, "S", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16991_client"+"'", TempTags, "", 2, "HLP_Gx00O0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl64( ) ;
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00O0.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 64 )
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

      protected void START992( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Genericos", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP990( ) ;
      }

      protected void WS992( )
      {
         START992( ) ;
         EVT992( ) ;
      }

      protected void EVT992( )
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
                              nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A107EstadosTipo = cgiGet( edtEstadosTipo_Internalname);
                              A109EstadosGenericosNombre = cgiGet( edtEstadosGenericosNombre_Internalname);
                              dynEstadosGenericosId.Name = dynEstadosGenericosId_Internalname;
                              dynEstadosGenericosId.CurrentValue = cgiGet( dynEstadosGenericosId_Internalname);
                              A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynEstadosGenericosId_Internalname), "."), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17992 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18992 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cestadostipo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSTIPO"), AV6cEstadosTipo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadosgenericosnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSGENERICOSNOMBRE"), AV7cEstadosGenericosNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadosnotificacioncliente Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSNOTIFICACIONCLIENTE"), AV8cEstadosNotificacionCliente) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadosnotificacionprofesional Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSNOTIFICACIONPROFESIONAL"), AV9cEstadosNotificacionProfesional) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadosnotificacionoperador Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSNOTIFICACIONOPERADOR"), AV10cEstadosNotificacionOperador) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19992 ();
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

      protected void WE992( )
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

      protected void PA992( )
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
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        string AV6cEstadosTipo ,
                                        string AV7cEstadosGenericosNombre ,
                                        string AV8cEstadosNotificacionCliente ,
                                        string AV9cEstadosNotificacionProfesional ,
                                        string AV10cEstadosNotificacionOperador )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF992( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ESTADOSTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "ESTADOSTIPO", StringUtil.RTrim( A107EstadosTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_ESTADOSGENERICOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ESTADOSGENERICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", "")));
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
         AV8cEstadosNotificacionCliente = ((StringUtil.StrCmp(StringUtil.RTrim( AV8cEstadosNotificacionCliente), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV8cEstadosNotificacionCliente", AV8cEstadosNotificacionCliente);
         AV9cEstadosNotificacionProfesional = ((StringUtil.StrCmp(StringUtil.RTrim( AV9cEstadosNotificacionProfesional), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV9cEstadosNotificacionProfesional", AV9cEstadosNotificacionProfesional);
         AV10cEstadosNotificacionOperador = ((StringUtil.StrCmp(StringUtil.RTrim( AV10cEstadosNotificacionOperador), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV10cEstadosNotificacionOperador", AV10cEstadosNotificacionOperador);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF992( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF992( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
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
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cEstadosGenericosNombre ,
                                                 AV8cEstadosNotificacionCliente ,
                                                 AV9cEstadosNotificacionProfesional ,
                                                 AV10cEstadosNotificacionOperador ,
                                                 A109EstadosGenericosNombre ,
                                                 A263EstadosNotificacionCliente ,
                                                 A264EstadosNotificacionProfesional ,
                                                 A265EstadosNotificacionOperador ,
                                                 A107EstadosTipo ,
                                                 AV6cEstadosTipo } ,
                                                 new int[]{
                                                 }
            });
            lV6cEstadosTipo = StringUtil.PadR( StringUtil.RTrim( AV6cEstadosTipo), 3, "%");
            lV7cEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV7cEstadosGenericosNombre), 80, "%");
            lV8cEstadosNotificacionCliente = StringUtil.PadR( StringUtil.RTrim( AV8cEstadosNotificacionCliente), 1, "%");
            lV9cEstadosNotificacionProfesional = StringUtil.PadR( StringUtil.RTrim( AV9cEstadosNotificacionProfesional), 1, "%");
            lV10cEstadosNotificacionOperador = StringUtil.PadR( StringUtil.RTrim( AV10cEstadosNotificacionOperador), 1, "%");
            /* Using cursor H00992 */
            pr_default.execute(0, new Object[] {lV6cEstadosTipo, lV7cEstadosGenericosNombre, lV8cEstadosNotificacionCliente, lV9cEstadosNotificacionProfesional, lV10cEstadosNotificacionOperador, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A265EstadosNotificacionOperador = H00992_A265EstadosNotificacionOperador[0];
               A264EstadosNotificacionProfesional = H00992_A264EstadosNotificacionProfesional[0];
               A263EstadosNotificacionCliente = H00992_A263EstadosNotificacionCliente[0];
               A108EstadosGenericosId = H00992_A108EstadosGenericosId[0];
               A109EstadosGenericosNombre = H00992_A109EstadosGenericosNombre[0];
               A107EstadosTipo = H00992_A107EstadosTipo[0];
               /* Execute user event: Load */
               E18992 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB990( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes992( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ESTADOSTIPO"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, StringUtil.RTrim( context.localUtil.Format( A107EstadosTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_ESTADOSGENERICOSID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A108EstadosGenericosId), "ZZZZ9"), context));
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
                                              AV7cEstadosGenericosNombre ,
                                              AV8cEstadosNotificacionCliente ,
                                              AV9cEstadosNotificacionProfesional ,
                                              AV10cEstadosNotificacionOperador ,
                                              A109EstadosGenericosNombre ,
                                              A263EstadosNotificacionCliente ,
                                              A264EstadosNotificacionProfesional ,
                                              A265EstadosNotificacionOperador ,
                                              A107EstadosTipo ,
                                              AV6cEstadosTipo } ,
                                              new int[]{
                                              }
         });
         lV6cEstadosTipo = StringUtil.PadR( StringUtil.RTrim( AV6cEstadosTipo), 3, "%");
         lV7cEstadosGenericosNombre = StringUtil.PadR( StringUtil.RTrim( AV7cEstadosGenericosNombre), 80, "%");
         lV8cEstadosNotificacionCliente = StringUtil.PadR( StringUtil.RTrim( AV8cEstadosNotificacionCliente), 1, "%");
         lV9cEstadosNotificacionProfesional = StringUtil.PadR( StringUtil.RTrim( AV9cEstadosNotificacionProfesional), 1, "%");
         lV10cEstadosNotificacionOperador = StringUtil.PadR( StringUtil.RTrim( AV10cEstadosNotificacionOperador), 1, "%");
         /* Using cursor H00993 */
         pr_default.execute(1, new Object[] {lV6cEstadosTipo, lV7cEstadosGenericosNombre, lV8cEstadosNotificacionCliente, lV9cEstadosNotificacionProfesional, lV10cEstadosNotificacionOperador});
         GRID1_nRecordCount = H00993_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEstadosTipo, AV7cEstadosGenericosNombre, AV8cEstadosNotificacionCliente, AV9cEstadosNotificacionProfesional, AV10cEstadosNotificacionOperador) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEstadosTipo, AV7cEstadosGenericosNombre, AV8cEstadosNotificacionCliente, AV9cEstadosNotificacionProfesional, AV10cEstadosNotificacionOperador) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEstadosTipo, AV7cEstadosGenericosNombre, AV8cEstadosNotificacionCliente, AV9cEstadosNotificacionProfesional, AV10cEstadosNotificacionOperador) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEstadosTipo, AV7cEstadosGenericosNombre, AV8cEstadosNotificacionCliente, AV9cEstadosNotificacionProfesional, AV10cEstadosNotificacionOperador) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cEstadosTipo, AV7cEstadosGenericosNombre, AV8cEstadosNotificacionCliente, AV9cEstadosNotificacionProfesional, AV10cEstadosNotificacionOperador) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtEstadosTipo_Enabled = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         dynEstadosGenericosId.Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP990( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17992 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV6cEstadosTipo = cgiGet( edtavCestadostipo_Internalname);
            AssignAttri("", false, "AV6cEstadosTipo", AV6cEstadosTipo);
            AV7cEstadosGenericosNombre = cgiGet( edtavCestadosgenericosnombre_Internalname);
            AssignAttri("", false, "AV7cEstadosGenericosNombre", AV7cEstadosGenericosNombre);
            AV8cEstadosNotificacionCliente = ((StringUtil.StrCmp(cgiGet( chkavCestadosnotificacioncliente_Internalname), "S")==0) ? "S" : "N");
            AssignAttri("", false, "AV8cEstadosNotificacionCliente", AV8cEstadosNotificacionCliente);
            AV9cEstadosNotificacionProfesional = ((StringUtil.StrCmp(cgiGet( chkavCestadosnotificacionprofesional_Internalname), "S")==0) ? "S" : "N");
            AssignAttri("", false, "AV9cEstadosNotificacionProfesional", AV9cEstadosNotificacionProfesional);
            AV10cEstadosNotificacionOperador = ((StringUtil.StrCmp(cgiGet( chkavCestadosnotificacionoperador_Internalname), "S")==0) ? "S" : "N");
            AssignAttri("", false, "AV10cEstadosNotificacionOperador", AV10cEstadosNotificacionOperador);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSTIPO"), AV6cEstadosTipo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSGENERICOSNOMBRE"), AV7cEstadosGenericosNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSNOTIFICACIONCLIENTE"), AV8cEstadosNotificacionCliente) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSNOTIFICACIONPROFESIONAL"), AV9cEstadosNotificacionProfesional) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTADOSNOTIFICACIONOPERADOR"), AV10cEstadosNotificacionOperador) != 0 )
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
         E17992 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17992( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Genericos", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E18992( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV14Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            context.DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E19992 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19992( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pEstadosTipo = A107EstadosTipo;
         AssignAttri("", false, "AV11pEstadosTipo", AV11pEstadosTipo);
         AV12pEstadosGenericosId = A108EstadosGenericosId;
         AssignAttri("", false, "AV12pEstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV12pEstadosGenericosId), 5, 0));
         context.setWebReturnParms(new Object[] {(string)AV11pEstadosTipo,(int)AV12pEstadosGenericosId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pEstadosTipo","AV12pEstadosGenericosId"});
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
         AV11pEstadosTipo = (string)getParm(obj,0);
         AssignAttri("", false, "AV11pEstadosTipo", AV11pEstadosTipo);
         AV12pEstadosGenericosId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV12pEstadosGenericosId", StringUtil.LTrimStr( (decimal)(AV12pEstadosGenericosId), 5, 0));
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
         PA992( ) ;
         WS992( ) ;
         WE992( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202673021255551", true, true, false);
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
         context.AddJavascriptSource("gx00o0.js", "?202673021255552", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtEstadosTipo_Internalname = "ESTADOSTIPO_"+sGXsfl_64_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_64_idx;
         dynEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtEstadosTipo_Internalname = "ESTADOSTIPO_"+sGXsfl_64_fel_idx;
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE_"+sGXsfl_64_fel_idx;
         dynEstadosGenericosId_Internalname = "ESTADOSGENERICOSID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         WB990( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A107EstadosTipo))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosTipo_Internalname,StringUtil.RTrim( A107EstadosTipo),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadosTipo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtEstadosGenericosNombre_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A107EstadosTipo))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtEstadosGenericosNombre_Internalname, "Link", edtEstadosGenericosNombre_Link, !bGXsfl_64_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadosGenericosNombre_Internalname,StringUtil.RTrim( A109EstadosGenericosNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtEstadosGenericosNombre_Link,(string)"",(string)"",(string)"",(string)edtEstadosGenericosNombre_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            if ( ( dynEstadosGenericosId.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "ESTADOSGENERICOSID_" + sGXsfl_64_idx;
               dynEstadosGenericosId.Name = GXCCtl;
               dynEstadosGenericosId.WebTags = "";
               dynEstadosGenericosId.removeAllItems();
               /* Using cursor H00994 */
               pr_default.execute(2);
               while ( (pr_default.getStatus(2) != 101) )
               {
                  dynEstadosGenericosId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00994_A108EstadosGenericosId[0]), 5, 0)), H00994_A109EstadosGenericosNombre[0], 0);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               if ( dynEstadosGenericosId.ItemCount > 0 )
               {
                  A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0))), "."), 18, MidpointRounding.ToEven));
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynEstadosGenericosId,(string)dynEstadosGenericosId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0)),(short)1,(string)dynEstadosGenericosId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)0,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",(string)"",(string)"",(bool)true,(short)0});
            dynEstadosGenericosId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0));
            AssignProp("", false, dynEstadosGenericosId_Internalname, "Values", (string)(dynEstadosGenericosId.ToJavascriptSource()), !bGXsfl_64_Refreshing);
            send_integrity_lvl_hashes992( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         chkavCestadosnotificacioncliente.Name = "vCESTADOSNOTIFICACIONCLIENTE";
         chkavCestadosnotificacioncliente.WebTags = "";
         chkavCestadosnotificacioncliente.Caption = context.GetMessage( "Notificar al cliente el nuevo estado", "");
         AssignProp("", false, chkavCestadosnotificacioncliente_Internalname, "TitleCaption", chkavCestadosnotificacioncliente.Caption, true);
         chkavCestadosnotificacioncliente.CheckedValue = "N";
         AV8cEstadosNotificacionCliente = ((StringUtil.StrCmp(StringUtil.RTrim( AV8cEstadosNotificacionCliente), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV8cEstadosNotificacionCliente", AV8cEstadosNotificacionCliente);
         chkavCestadosnotificacionprofesional.Name = "vCESTADOSNOTIFICACIONPROFESIONAL";
         chkavCestadosnotificacionprofesional.WebTags = "";
         chkavCestadosnotificacionprofesional.Caption = context.GetMessage( "Notificar al profesional el nuevo estado", "");
         AssignProp("", false, chkavCestadosnotificacionprofesional_Internalname, "TitleCaption", chkavCestadosnotificacionprofesional.Caption, true);
         chkavCestadosnotificacionprofesional.CheckedValue = "N";
         AV9cEstadosNotificacionProfesional = ((StringUtil.StrCmp(StringUtil.RTrim( AV9cEstadosNotificacionProfesional), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV9cEstadosNotificacionProfesional", AV9cEstadosNotificacionProfesional);
         chkavCestadosnotificacionoperador.Name = "vCESTADOSNOTIFICACIONOPERADOR";
         chkavCestadosnotificacionoperador.WebTags = "";
         chkavCestadosnotificacionoperador.Caption = context.GetMessage( "Notificar al operador el nuevo estado", "");
         AssignProp("", false, chkavCestadosnotificacionoperador_Internalname, "TitleCaption", chkavCestadosnotificacionoperador.Caption, true);
         chkavCestadosnotificacionoperador.CheckedValue = "N";
         AV10cEstadosNotificacionOperador = ((StringUtil.StrCmp(StringUtil.RTrim( AV10cEstadosNotificacionOperador), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV10cEstadosNotificacionOperador", AV10cEstadosNotificacionOperador);
         GXCCtl = "ESTADOSGENERICOSID_" + sGXsfl_64_idx;
         dynEstadosGenericosId.Name = GXCCtl;
         dynEstadosGenericosId.WebTags = "";
         dynEstadosGenericosId.removeAllItems();
         /* Using cursor H00995 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            dynEstadosGenericosId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00995_A108EstadosGenericosId[0]), 5, 0)), H00995_A109EstadosGenericosNombre[0], 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( dynEstadosGenericosId.ItemCount > 0 )
         {
            A108EstadosGenericosId = (int)(Math.Round(NumberUtil.Val( dynEstadosGenericosId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A108EstadosGenericosId), 5, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl64( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
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
            context.SendWebValue( context.GetMessage( "Tipo de Estados", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Estado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Identificador", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A107EstadosTipo)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A109EstadosGenericosNombre)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtEstadosGenericosNombre_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A108EstadosGenericosId), 5, 0, ".", ""))));
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
         lblLblestadostipofilter_Internalname = "LBLESTADOSTIPOFILTER";
         edtavCestadostipo_Internalname = "vCESTADOSTIPO";
         divEstadostipofiltercontainer_Internalname = "ESTADOSTIPOFILTERCONTAINER";
         lblLblestadosgenericosnombrefilter_Internalname = "LBLESTADOSGENERICOSNOMBREFILTER";
         edtavCestadosgenericosnombre_Internalname = "vCESTADOSGENERICOSNOMBRE";
         divEstadosgenericosnombrefiltercontainer_Internalname = "ESTADOSGENERICOSNOMBREFILTERCONTAINER";
         lblLblestadosnotificacionclientefilter_Internalname = "LBLESTADOSNOTIFICACIONCLIENTEFILTER";
         chkavCestadosnotificacioncliente_Internalname = "vCESTADOSNOTIFICACIONCLIENTE";
         divEstadosnotificacionclientefiltercontainer_Internalname = "ESTADOSNOTIFICACIONCLIENTEFILTERCONTAINER";
         lblLblestadosnotificacionprofesionalfilter_Internalname = "LBLESTADOSNOTIFICACIONPROFESIONALFILTER";
         chkavCestadosnotificacionprofesional_Internalname = "vCESTADOSNOTIFICACIONPROFESIONAL";
         divEstadosnotificacionprofesionalfiltercontainer_Internalname = "ESTADOSNOTIFICACIONPROFESIONALFILTERCONTAINER";
         lblLblestadosnotificacionoperadorfilter_Internalname = "LBLESTADOSNOTIFICACIONOPERADORFILTER";
         chkavCestadosnotificacionoperador_Internalname = "vCESTADOSNOTIFICACIONOPERADOR";
         divEstadosnotificacionoperadorfiltercontainer_Internalname = "ESTADOSNOTIFICACIONOPERADORFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtEstadosTipo_Internalname = "ESTADOSTIPO";
         edtEstadosGenericosNombre_Internalname = "ESTADOSGENERICOSNOMBRE";
         dynEstadosGenericosId_Internalname = "ESTADOSGENERICOSID";
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
         chkavCestadosnotificacionoperador.Caption = context.GetMessage( "Notificar al operador el nuevo estado", "");
         chkavCestadosnotificacionprofesional.Caption = context.GetMessage( "Notificar al profesional el nuevo estado", "");
         chkavCestadosnotificacioncliente.Caption = context.GetMessage( "Notificar al cliente el nuevo estado", "");
         dynEstadosGenericosId_Jsonclick = "";
         edtEstadosGenericosNombre_Jsonclick = "";
         edtEstadosGenericosNombre_Link = "";
         edtEstadosTipo_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         dynEstadosGenericosId.Enabled = 0;
         edtEstadosGenericosNombre_Enabled = 0;
         edtEstadosTipo_Enabled = 0;
         chkavCestadosnotificacionoperador.Enabled = 1;
         chkavCestadosnotificacionoperador.Visible = 1;
         chkavCestadosnotificacionprofesional.Enabled = 1;
         chkavCestadosnotificacionprofesional.Visible = 1;
         chkavCestadosnotificacioncliente.Enabled = 1;
         chkavCestadosnotificacioncliente.Visible = 1;
         edtavCestadosgenericosnombre_Jsonclick = "";
         edtavCestadosgenericosnombre_Enabled = 1;
         edtavCestadosgenericosnombre_Visible = 1;
         edtavCestadostipo_Jsonclick = "";
         edtavCestadostipo_Enabled = 1;
         edtavCestadostipo_Visible = 1;
         divEstadosnotificacionoperadorfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divEstadosnotificacionprofesionalfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divEstadosnotificacionclientefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divEstadosgenericosnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divEstadostipofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Genericos", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEstadosTipo',fld:'vCESTADOSTIPO',pic:'',type:'char'},{av:'AV7cEstadosGenericosNombre',fld:'vCESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV8cEstadosNotificacionCliente',fld:'vCESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'AV9cEstadosNotificacionProfesional',fld:'vCESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'AV10cEstadosNotificacionOperador',fld:'vCESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E16991',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLESTADOSTIPOFILTER.CLICK","{handler:'E11991',iparms:[{av:'divEstadostipofiltercontainer_Class',ctrl:'ESTADOSTIPOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTADOSTIPOFILTER.CLICK",",oparms:[{av:'divEstadostipofiltercontainer_Class',ctrl:'ESTADOSTIPOFILTERCONTAINER',prop:'Class'},{av:'edtavCestadostipo_Visible',ctrl:'vCESTADOSTIPO',prop:'Visible'}]}");
         setEventMetadata("LBLESTADOSGENERICOSNOMBREFILTER.CLICK","{handler:'E12991',iparms:[{av:'divEstadosgenericosnombrefiltercontainer_Class',ctrl:'ESTADOSGENERICOSNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTADOSGENERICOSNOMBREFILTER.CLICK",",oparms:[{av:'divEstadosgenericosnombrefiltercontainer_Class',ctrl:'ESTADOSGENERICOSNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCestadosgenericosnombre_Visible',ctrl:'vCESTADOSGENERICOSNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLESTADOSNOTIFICACIONCLIENTEFILTER.CLICK","{handler:'E13991',iparms:[{av:'divEstadosnotificacionclientefiltercontainer_Class',ctrl:'ESTADOSNOTIFICACIONCLIENTEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTADOSNOTIFICACIONCLIENTEFILTER.CLICK",",oparms:[{av:'divEstadosnotificacionclientefiltercontainer_Class',ctrl:'ESTADOSNOTIFICACIONCLIENTEFILTERCONTAINER',prop:'Class'},{av:'chkavCestadosnotificacioncliente.Visible',ctrl:'vCESTADOSNOTIFICACIONCLIENTE',prop:'Visible'}]}");
         setEventMetadata("LBLESTADOSNOTIFICACIONPROFESIONALFILTER.CLICK","{handler:'E14991',iparms:[{av:'divEstadosnotificacionprofesionalfiltercontainer_Class',ctrl:'ESTADOSNOTIFICACIONPROFESIONALFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTADOSNOTIFICACIONPROFESIONALFILTER.CLICK",",oparms:[{av:'divEstadosnotificacionprofesionalfiltercontainer_Class',ctrl:'ESTADOSNOTIFICACIONPROFESIONALFILTERCONTAINER',prop:'Class'},{av:'chkavCestadosnotificacionprofesional.Visible',ctrl:'vCESTADOSNOTIFICACIONPROFESIONAL',prop:'Visible'}]}");
         setEventMetadata("LBLESTADOSNOTIFICACIONOPERADORFILTER.CLICK","{handler:'E15991',iparms:[{av:'divEstadosnotificacionoperadorfiltercontainer_Class',ctrl:'ESTADOSNOTIFICACIONOPERADORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTADOSNOTIFICACIONOPERADORFILTER.CLICK",",oparms:[{av:'divEstadosnotificacionoperadorfiltercontainer_Class',ctrl:'ESTADOSNOTIFICACIONOPERADORFILTERCONTAINER',prop:'Class'},{av:'chkavCestadosnotificacionoperador.Visible',ctrl:'vCESTADOSNOTIFICACIONOPERADOR',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E19992',iparms:[{av:'A107EstadosTipo',fld:'ESTADOSTIPO',pic:'',hsh:true,type:'char'},{av:'dynEstadosGenericosId'},{av:'A108EstadosGenericosId',fld:'ESTADOSGENERICOSID',pic:'ZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11pEstadosTipo',fld:'vPESTADOSTIPO',pic:'',type:'char'},{av:'AV12pEstadosGenericosId',fld:'vPESTADOSGENERICOSID',pic:'ZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEstadosTipo',fld:'vCESTADOSTIPO',pic:'',type:'char'},{av:'AV7cEstadosGenericosNombre',fld:'vCESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV8cEstadosNotificacionCliente',fld:'vCESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'AV9cEstadosNotificacionProfesional',fld:'vCESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'AV10cEstadosNotificacionOperador',fld:'vCESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEstadosTipo',fld:'vCESTADOSTIPO',pic:'',type:'char'},{av:'AV7cEstadosGenericosNombre',fld:'vCESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV8cEstadosNotificacionCliente',fld:'vCESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'AV9cEstadosNotificacionProfesional',fld:'vCESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'AV10cEstadosNotificacionOperador',fld:'vCESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEstadosTipo',fld:'vCESTADOSTIPO',pic:'',type:'char'},{av:'AV7cEstadosGenericosNombre',fld:'vCESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV8cEstadosNotificacionCliente',fld:'vCESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'AV9cEstadosNotificacionProfesional',fld:'vCESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'AV10cEstadosNotificacionOperador',fld:'vCESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cEstadosTipo',fld:'vCESTADOSTIPO',pic:'',type:'char'},{av:'AV7cEstadosGenericosNombre',fld:'vCESTADOSGENERICOSNOMBRE',pic:'',type:'char'},{av:'AV8cEstadosNotificacionCliente',fld:'vCESTADOSNOTIFICACIONCLIENTE',pic:'',type:'char'},{av:'AV9cEstadosNotificacionProfesional',fld:'vCESTADOSNOTIFICACIONPROFESIONAL',pic:'',type:'char'},{av:'AV10cEstadosNotificacionOperador',fld:'vCESTADOSNOTIFICACIONOPERADOR',pic:'',type:'char'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Estadosgenericosid',iparms:[]");
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
         AV11pEstadosTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cEstadosTipo = "";
         AV7cEstadosGenericosNombre = "";
         AV8cEstadosNotificacionCliente = "";
         AV9cEstadosNotificacionProfesional = "";
         AV10cEstadosNotificacionOperador = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblestadostipofilter_Jsonclick = "";
         TempTags = "";
         lblLblestadosgenericosnombrefilter_Jsonclick = "";
         lblLblestadosnotificacionclientefilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblestadosnotificacionprofesionalfilter_Jsonclick = "";
         lblLblestadosnotificacionoperadorfilter_Jsonclick = "";
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
         A107EstadosTipo = "";
         A109EstadosGenericosNombre = "";
         lV6cEstadosTipo = "";
         lV7cEstadosGenericosNombre = "";
         lV8cEstadosNotificacionCliente = "";
         lV9cEstadosNotificacionProfesional = "";
         lV10cEstadosNotificacionOperador = "";
         A263EstadosNotificacionCliente = "";
         A264EstadosNotificacionProfesional = "";
         A265EstadosNotificacionOperador = "";
         H00992_A265EstadosNotificacionOperador = new string[] {""} ;
         H00992_A264EstadosNotificacionProfesional = new string[] {""} ;
         H00992_A263EstadosNotificacionCliente = new string[] {""} ;
         H00992_A108EstadosGenericosId = new int[1] ;
         H00992_A109EstadosGenericosNombre = new string[] {""} ;
         H00992_A107EstadosTipo = new string[] {""} ;
         H00993_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         H00994_A107EstadosTipo = new string[] {""} ;
         H00994_A108EstadosGenericosId = new int[1] ;
         H00994_A109EstadosGenericosNombre = new string[] {""} ;
         H00995_A107EstadosTipo = new string[] {""} ;
         H00995_A108EstadosGenericosId = new int[1] ;
         H00995_A109EstadosGenericosNombre = new string[] {""} ;
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00o0__default(),
            new Object[][] {
                new Object[] {
               H00992_A265EstadosNotificacionOperador, H00992_A264EstadosNotificacionProfesional, H00992_A263EstadosNotificacionCliente, H00992_A108EstadosGenericosId, H00992_A109EstadosGenericosNombre, H00992_A107EstadosTipo
               }
               , new Object[] {
               H00993_AGRID1_nRecordCount
               }
               , new Object[] {
               H00994_A107EstadosTipo, H00994_A108EstadosGenericosId, H00994_A109EstadosGenericosNombre
               }
               , new Object[] {
               H00995_A107EstadosTipo, H00995_A108EstadosGenericosId, H00995_A109EstadosGenericosNombre
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
      private int AV12pEstadosGenericosId ;
      private int nRC_GXsfl_64 ;
      private int subGrid1_Rows ;
      private int nGXsfl_64_idx=1 ;
      private int edtavCestadostipo_Visible ;
      private int edtavCestadostipo_Enabled ;
      private int edtavCestadosgenericosnombre_Visible ;
      private int edtavCestadosgenericosnombre_Enabled ;
      private int A108EstadosGenericosId ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtEstadosTipo_Enabled ;
      private int edtEstadosGenericosNombre_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string AV11pEstadosTipo ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divEstadostipofiltercontainer_Class ;
      private string divEstadosgenericosnombrefiltercontainer_Class ;
      private string divEstadosnotificacionclientefiltercontainer_Class ;
      private string divEstadosnotificacionprofesionalfiltercontainer_Class ;
      private string divEstadosnotificacionoperadorfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV6cEstadosTipo ;
      private string AV7cEstadosGenericosNombre ;
      private string AV8cEstadosNotificacionCliente ;
      private string AV9cEstadosNotificacionProfesional ;
      private string AV10cEstadosNotificacionOperador ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divEstadostipofiltercontainer_Internalname ;
      private string lblLblestadostipofilter_Internalname ;
      private string lblLblestadostipofilter_Jsonclick ;
      private string edtavCestadostipo_Internalname ;
      private string TempTags ;
      private string edtavCestadostipo_Jsonclick ;
      private string divEstadosgenericosnombrefiltercontainer_Internalname ;
      private string lblLblestadosgenericosnombrefilter_Internalname ;
      private string lblLblestadosgenericosnombrefilter_Jsonclick ;
      private string edtavCestadosgenericosnombre_Internalname ;
      private string edtavCestadosgenericosnombre_Jsonclick ;
      private string divEstadosnotificacionclientefiltercontainer_Internalname ;
      private string lblLblestadosnotificacionclientefilter_Internalname ;
      private string lblLblestadosnotificacionclientefilter_Jsonclick ;
      private string chkavCestadosnotificacioncliente_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divEstadosnotificacionprofesionalfiltercontainer_Internalname ;
      private string lblLblestadosnotificacionprofesionalfilter_Internalname ;
      private string lblLblestadosnotificacionprofesionalfilter_Jsonclick ;
      private string chkavCestadosnotificacionprofesional_Internalname ;
      private string divEstadosnotificacionoperadorfiltercontainer_Internalname ;
      private string lblLblestadosnotificacionoperadorfilter_Internalname ;
      private string lblLblestadosnotificacionoperadorfilter_Jsonclick ;
      private string chkavCestadosnotificacionoperador_Internalname ;
      private string divGridtable_Internalname ;
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
      private string A107EstadosTipo ;
      private string edtEstadosTipo_Internalname ;
      private string A109EstadosGenericosNombre ;
      private string edtEstadosGenericosNombre_Internalname ;
      private string dynEstadosGenericosId_Internalname ;
      private string lV6cEstadosTipo ;
      private string lV7cEstadosGenericosNombre ;
      private string lV8cEstadosNotificacionCliente ;
      private string lV9cEstadosNotificacionProfesional ;
      private string lV10cEstadosNotificacionOperador ;
      private string A263EstadosNotificacionCliente ;
      private string A264EstadosNotificacionProfesional ;
      private string A265EstadosNotificacionOperador ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtEstadosTipo_Jsonclick ;
      private string edtEstadosGenericosNombre_Link ;
      private string edtEstadosGenericosNombre_Jsonclick ;
      private string GXCCtl ;
      private string dynEstadosGenericosId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV14Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCestadosnotificacioncliente ;
      private GXCheckbox chkavCestadosnotificacionprofesional ;
      private GXCheckbox chkavCestadosnotificacionoperador ;
      private GXCombobox dynEstadosGenericosId ;
      private IDataStoreProvider pr_default ;
      private string[] H00992_A265EstadosNotificacionOperador ;
      private string[] H00992_A264EstadosNotificacionProfesional ;
      private string[] H00992_A263EstadosNotificacionCliente ;
      private int[] H00992_A108EstadosGenericosId ;
      private string[] H00992_A109EstadosGenericosNombre ;
      private string[] H00992_A107EstadosTipo ;
      private long[] H00993_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string[] H00994_A107EstadosTipo ;
      private int[] H00994_A108EstadosGenericosId ;
      private string[] H00994_A109EstadosGenericosNombre ;
      private string[] H00995_A107EstadosTipo ;
      private int[] H00995_A108EstadosGenericosId ;
      private string[] H00995_A109EstadosGenericosNombre ;
      private string aP0_pEstadosTipo ;
      private int aP1_pEstadosGenericosId ;
   }

   public class gx00o0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00992( IGxContext context ,
                                             string AV7cEstadosGenericosNombre ,
                                             string AV8cEstadosNotificacionCliente ,
                                             string AV9cEstadosNotificacionProfesional ,
                                             string AV10cEstadosNotificacionOperador ,
                                             string A109EstadosGenericosNombre ,
                                             string A263EstadosNotificacionCliente ,
                                             string A264EstadosNotificacionProfesional ,
                                             string A265EstadosNotificacionOperador ,
                                             string A107EstadosTipo ,
                                             string AV6cEstadosTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [EstadosNotificacionOperador], [EstadosNotificacionProfesional], [EstadosNotificacionCliente], [EstadosGenericosId], [EstadosGenericosNombre], [EstadosTipo]";
         sFromString = " FROM [EstadosGenericos]";
         sOrderString = "";
         AddWhere(sWhereString, "([EstadosTipo] like @lV6cEstadosTipo)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cEstadosGenericosNombre)) )
         {
            AddWhere(sWhereString, "([EstadosGenericosNombre] like @lV7cEstadosGenericosNombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cEstadosNotificacionCliente)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionCliente] like @lV8cEstadosNotificacionCliente)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cEstadosNotificacionProfesional)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionProfesional] like @lV9cEstadosNotificacionProfesional)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cEstadosNotificacionOperador)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionOperador] like @lV10cEstadosNotificacionOperador)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString += " ORDER BY [EstadosTipo], [EstadosGenericosId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00993( IGxContext context ,
                                             string AV7cEstadosGenericosNombre ,
                                             string AV8cEstadosNotificacionCliente ,
                                             string AV9cEstadosNotificacionProfesional ,
                                             string AV10cEstadosNotificacionOperador ,
                                             string A109EstadosGenericosNombre ,
                                             string A263EstadosNotificacionCliente ,
                                             string A264EstadosNotificacionProfesional ,
                                             string A265EstadosNotificacionOperador ,
                                             string A107EstadosTipo ,
                                             string AV6cEstadosTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [EstadosGenericos]";
         AddWhere(sWhereString, "([EstadosTipo] like @lV6cEstadosTipo)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cEstadosGenericosNombre)) )
         {
            AddWhere(sWhereString, "([EstadosGenericosNombre] like @lV7cEstadosGenericosNombre)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cEstadosNotificacionCliente)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionCliente] like @lV8cEstadosNotificacionCliente)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cEstadosNotificacionProfesional)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionProfesional] like @lV9cEstadosNotificacionProfesional)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cEstadosNotificacionOperador)) )
         {
            AddWhere(sWhereString, "([EstadosNotificacionOperador] like @lV10cEstadosNotificacionOperador)");
         }
         else
         {
            GXv_int3[4] = 1;
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
                     return conditional_H00992(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
               case 1 :
                     return conditional_H00993(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
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
          Object[] prmH00994;
          prmH00994 = new Object[] {
          };
          Object[] prmH00995;
          prmH00995 = new Object[] {
          };
          Object[] prmH00992;
          prmH00992 = new Object[] {
          new ParDef("@lV6cEstadosTipo",GXType.NChar,3,0) ,
          new ParDef("@lV7cEstadosGenericosNombre",GXType.NChar,80,0) ,
          new ParDef("@lV8cEstadosNotificacionCliente",GXType.NChar,1,0) ,
          new ParDef("@lV9cEstadosNotificacionProfesional",GXType.NChar,1,0) ,
          new ParDef("@lV10cEstadosNotificacionOperador",GXType.NChar,1,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00993;
          prmH00993 = new Object[] {
          new ParDef("@lV6cEstadosTipo",GXType.NChar,3,0) ,
          new ParDef("@lV7cEstadosGenericosNombre",GXType.NChar,80,0) ,
          new ParDef("@lV8cEstadosNotificacionCliente",GXType.NChar,1,0) ,
          new ParDef("@lV9cEstadosNotificacionProfesional",GXType.NChar,1,0) ,
          new ParDef("@lV10cEstadosNotificacionOperador",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00992", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00992,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00993", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00993,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00994", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] ORDER BY [EstadosGenericosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00994,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00995", "SELECT [EstadosTipo], [EstadosGenericosId], [EstadosGenericosNombre] FROM [EstadosGenericos] ORDER BY [EstadosGenericosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00995,0, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
       }
    }

 }

}

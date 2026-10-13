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
   public class gx01a1 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx01a1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx01a1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_pusuariosId ,
                           out string aP1_pusuariosNotificacionTipo ,
                           out long aP2_pusuariosNotificacionCodigo )
      {
         this.AV11pusuariosId = aP0_pusuariosId;
         this.AV12pusuariosNotificacionTipo = "" ;
         this.AV13pusuariosNotificacionCodigo = 0 ;
         ExecutePrivate();
         aP1_pusuariosNotificacionTipo=this.AV12pusuariosNotificacionTipo;
         aP2_pusuariosNotificacionCodigo=this.AV13pusuariosNotificacionCodigo;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCusuariosnotificaciontipo = new GXCombobox();
         chkavCusuariosnotificacionnotificado = new GXCheckbox();
         cmbusuariosNotificacionTipo = new GXCombobox();
         chkusuariosNotificacionNotificado = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pusuariosId");
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
               gxfirstwebparm = GetFirstPar( "pusuariosId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pusuariosId");
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
               AV11pusuariosId = gxfirstwebparm;
               AssignAttri("", false, "AV11pusuariosId", AV11pusuariosId);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12pusuariosNotificacionTipo = GetPar( "pusuariosNotificacionTipo");
                  AssignAttri("", false, "AV12pusuariosNotificacionTipo", AV12pusuariosNotificacionTipo);
                  AV13pusuariosNotificacionCodigo = (long)(Math.Round(NumberUtil.Val( GetPar( "pusuariosNotificacionCodigo"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pusuariosNotificacionCodigo", StringUtil.LTrimStr( (decimal)(AV13pusuariosNotificacionCodigo), 10, 0));
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
         cmbavCusuariosnotificaciontipo.FromJSonString( GetNextPar( ));
         AV6cusuariosNotificacionTipo = GetPar( "cusuariosNotificacionTipo");
         AV7cusuariosNotificacionCodigo = (long)(Math.Round(NumberUtil.Val( GetPar( "cusuariosNotificacionCodigo"), "."), 18, MidpointRounding.ToEven));
         AV8cusuariosNotificacionNotificado = GetPar( "cusuariosNotificacionNotificado");
         AV9cusuariosNotificacionObjeto = GetPar( "cusuariosNotificacionObjeto");
         AV10cusuariosNotificacionFecha = context.localUtil.ParseDTimeParm( GetPar( "cusuariosNotificacionFecha"));
         AV11pusuariosId = GetPar( "pusuariosId");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cusuariosNotificacionTipo, AV7cusuariosNotificacionCodigo, AV8cusuariosNotificacionNotificado, AV9cusuariosNotificacionObjeto, AV10cusuariosNotificacionFecha, AV11pusuariosId) ;
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
         PA9M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START9M2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx01a1.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11pusuariosId)),UrlEncode(StringUtil.RTrim(AV12pusuariosNotificacionTipo)),UrlEncode(StringUtil.LTrimStr(AV13pusuariosNotificacionCodigo,10,0))}, new string[] {"pusuariosId","pusuariosNotificacionTipo","pusuariosNotificacionCodigo"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSNOTIFICACIONTIPO", StringUtil.RTrim( AV6cusuariosNotificacionTipo));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSNOTIFICACIONCODIGO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cusuariosNotificacionCodigo), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSNOTIFICACIONNOTIFICADO", StringUtil.RTrim( AV8cusuariosNotificacionNotificado));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSNOTIFICACIONOBJETO", StringUtil.RTrim( AV9cusuariosNotificacionObjeto));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSNOTIFICACIONFECHA", context.localUtil.TToC( AV10cusuariosNotificacionFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPUSUARIOSID", StringUtil.RTrim( AV11pusuariosId));
         GxWebStd.gx_hidden_field( context, "vPUSUARIOSNOTIFICACIONTIPO", StringUtil.RTrim( AV12pusuariosNotificacionTipo));
         GxWebStd.gx_hidden_field( context, "vPUSUARIOSNOTIFICACIONCODIGO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pusuariosNotificacionCodigo), 10, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONTIPOFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosnotificaciontipofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONCODIGOFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosnotificacioncodigofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONNOTIFICADOFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosnotificacionnotificadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONOBJETOFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosnotificacionobjetofiltercontainer_Class));
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
            WE9M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT9M2( ) ;
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
         return formatLink("gx01a1.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11pusuariosId)),UrlEncode(StringUtil.RTrim(AV12pusuariosNotificacionTipo)),UrlEncode(StringUtil.LTrimStr(AV13pusuariosNotificacionCodigo,10,0))}, new string[] {"pusuariosId","pusuariosNotificacionTipo","pusuariosNotificacionCodigo"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx01A1" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Notificacion", "") ;
      }

      protected void WB9M0( )
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
            GxWebStd.gx_div_start( context, divUsuariosnotificaciontipofiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosnotificaciontipofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosnotificaciontipofilter_Internalname, context.GetMessage( "Tipo", ""), "", "", lblLblusuariosnotificaciontipofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e119m1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01A1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCusuariosnotificaciontipo_Internalname, context.GetMessage( "Tipo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCusuariosnotificaciontipo, cmbavCusuariosnotificaciontipo_Internalname, StringUtil.RTrim( AV6cusuariosNotificacionTipo), 1, cmbavCusuariosnotificaciontipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCusuariosnotificaciontipo.Visible, cmbavCusuariosnotificaciontipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "", true, 0, "HLP_Gx01A1.htm");
            cmbavCusuariosnotificaciontipo.CurrentValue = StringUtil.RTrim( AV6cusuariosNotificacionTipo);
            AssignProp("", false, cmbavCusuariosnotificaciontipo_Internalname, "Values", (string)(cmbavCusuariosnotificaciontipo.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divUsuariosnotificacioncodigofiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosnotificacioncodigofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosnotificacioncodigofilter_Internalname, context.GetMessage( "Codigo", ""), "", "", lblLblusuariosnotificacioncodigofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e129m1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01A1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosnotificacioncodigo_Internalname, context.GetMessage( "Codigo", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosnotificacioncodigo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cusuariosNotificacionCodigo), 10, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCusuariosnotificacioncodigo_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cusuariosNotificacionCodigo), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7cusuariosNotificacionCodigo), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosnotificacioncodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosnotificacioncodigo_Visible, edtavCusuariosnotificacioncodigo_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01A1.htm");
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
            GxWebStd.gx_div_start( context, divUsuariosnotificacionnotificadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosnotificacionnotificadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosnotificacionnotificadofilter_Internalname, context.GetMessage( "Notificado", ""), "", "", lblLblusuariosnotificacionnotificadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e139m1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01A1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCusuariosnotificacionnotificado_Internalname, context.GetMessage( "Notificado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCusuariosnotificacionnotificado_Internalname, AV8cusuariosNotificacionNotificado, "", context.GetMessage( "Notificado", ""), chkavCusuariosnotificacionnotificado.Visible, chkavCusuariosnotificacionnotificado.Enabled, "S", context.GetMessage( "Notificado", ""), StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 'S', 'N',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,36);\"");
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
            GxWebStd.gx_div_start( context, divUsuariosnotificacionobjetofiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosnotificacionobjetofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosnotificacionobjetofilter_Internalname, context.GetMessage( "Objeto", ""), "", "", lblLblusuariosnotificacionobjetofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e149m1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx01A1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosnotificacionobjeto_Internalname, context.GetMessage( "Objeto", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosnotificacionobjeto_Internalname, StringUtil.RTrim( AV9cusuariosNotificacionObjeto), StringUtil.RTrim( context.localUtil.Format( AV9cusuariosNotificacionObjeto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosnotificacionobjeto_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosnotificacionobjeto_Visible, edtavCusuariosnotificacionobjeto_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx01A1.htm");
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
            GxWebStd.gx_div_start( context, divUsuariosnotificacionfechafiltercontainer_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerItem AdvancedContainerItemExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosnotificacionfechafilter_Internalname, context.GetMessage( "Fecha", ""), "", "", lblLblusuariosnotificacionfechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "WWAdvancedLabel WWDateFilterLabel", 0, "", 1, 1, 0, 1, "HLP_Gx01A1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosnotificacionfecha_Internalname, context.GetMessage( "Fecha", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCusuariosnotificacionfecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCusuariosnotificacionfecha_Internalname, context.localUtil.TToC( AV10cusuariosNotificacionFecha, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( AV10cusuariosNotificacionFecha, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosnotificacionfecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCusuariosnotificacionfecha_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx01A1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e159m1_client"+"'", TempTags, "", 2, "HLP_Gx01A1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx01A1.htm");
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

      protected void START9M2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Notificacion", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP9M0( ) ;
      }

      protected void WS9M2( )
      {
         START9M2( ) ;
         EVT9M2( ) ;
      }

      protected void EVT9M2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              cmbusuariosNotificacionTipo.Name = cmbusuariosNotificacionTipo_Internalname;
                              cmbusuariosNotificacionTipo.CurrentValue = cgiGet( cmbusuariosNotificacionTipo_Internalname);
                              A146usuariosNotificacionTipo = cgiGet( cmbusuariosNotificacionTipo_Internalname);
                              A147usuariosNotificacionCodigo = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtusuariosNotificacionCodigo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A234usuariosNotificacionNotificado = ((StringUtil.StrCmp(cgiGet( chkusuariosNotificacionNotificado_Internalname), "S")==0) ? "S" : "N");
                              A421usuariosNotificacionObjeto = cgiGet( edtusuariosNotificacionObjeto_Internalname);
                              A145usuariosId = cgiGet( edtusuariosId_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E169M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E179M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cusuariosnotificaciontipo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSNOTIFICACIONTIPO"), AV6cusuariosNotificacionTipo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariosnotificacioncodigo Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOSNOTIFICACIONCODIGO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cusuariosNotificacionCodigo )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariosnotificacionnotificado Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSNOTIFICACIONNOTIFICADO"), AV8cusuariosNotificacionNotificado) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariosnotificacionobjeto Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSNOTIFICACIONOBJETO"), AV9cusuariosNotificacionObjeto) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariosnotificacionfecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCUSUARIOSNOTIFICACIONFECHA"), 0) != AV10cusuariosNotificacionFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E189M2 ();
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

      protected void WE9M2( )
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

      protected void PA9M2( )
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
                                        string AV6cusuariosNotificacionTipo ,
                                        long AV7cusuariosNotificacionCodigo ,
                                        string AV8cusuariosNotificacionNotificado ,
                                        string AV9cusuariosNotificacionObjeto ,
                                        DateTime AV10cusuariosNotificacionFecha ,
                                        string AV11pusuariosId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF9M2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSNOTIFICACIONTIPO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A146usuariosNotificacionTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONTIPO", StringUtil.RTrim( A146usuariosNotificacionTipo));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSNOTIFICACIONCODIGO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A147usuariosNotificacionCodigo), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSNOTIFICACIONCODIGO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A147usuariosNotificacionCodigo), 10, 0, ".", "")));
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
         if ( cmbavCusuariosnotificaciontipo.ItemCount > 0 )
         {
            AV6cusuariosNotificacionTipo = cmbavCusuariosnotificaciontipo.getValidValue(AV6cusuariosNotificacionTipo);
            AssignAttri("", false, "AV6cusuariosNotificacionTipo", AV6cusuariosNotificacionTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCusuariosnotificaciontipo.CurrentValue = StringUtil.RTrim( AV6cusuariosNotificacionTipo);
            AssignProp("", false, cmbavCusuariosnotificaciontipo_Internalname, "Values", cmbavCusuariosnotificaciontipo.ToJavascriptSource(), true);
         }
         AV8cusuariosNotificacionNotificado = ((StringUtil.StrCmp(StringUtil.RTrim( AV8cusuariosNotificacionNotificado), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV8cusuariosNotificacionNotificado", AV8cusuariosNotificacionNotificado);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF9M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF9M2( )
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
                                                 AV8cusuariosNotificacionNotificado ,
                                                 AV9cusuariosNotificacionObjeto ,
                                                 AV10cusuariosNotificacionFecha ,
                                                 A234usuariosNotificacionNotificado ,
                                                 A421usuariosNotificacionObjeto ,
                                                 A235usuariosNotificacionFecha ,
                                                 A146usuariosNotificacionTipo ,
                                                 AV6cusuariosNotificacionTipo ,
                                                 A147usuariosNotificacionCodigo ,
                                                 AV7cusuariosNotificacionCodigo ,
                                                 AV11pusuariosId ,
                                                 A145usuariosId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            lV6cusuariosNotificacionTipo = StringUtil.PadR( StringUtil.RTrim( AV6cusuariosNotificacionTipo), 1, "%");
            lV8cusuariosNotificacionNotificado = StringUtil.PadR( StringUtil.RTrim( AV8cusuariosNotificacionNotificado), 1, "%");
            lV9cusuariosNotificacionObjeto = StringUtil.PadR( StringUtil.RTrim( AV9cusuariosNotificacionObjeto), 100, "%");
            /* Using cursor H009M2 */
            pr_default.execute(0, new Object[] {AV11pusuariosId, lV6cusuariosNotificacionTipo, AV7cusuariosNotificacionCodigo, lV8cusuariosNotificacionNotificado, lV9cusuariosNotificacionObjeto, AV10cusuariosNotificacionFecha, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A235usuariosNotificacionFecha = H009M2_A235usuariosNotificacionFecha[0];
               A145usuariosId = H009M2_A145usuariosId[0];
               A421usuariosNotificacionObjeto = H009M2_A421usuariosNotificacionObjeto[0];
               A234usuariosNotificacionNotificado = H009M2_A234usuariosNotificacionNotificado[0];
               A147usuariosNotificacionCodigo = H009M2_A147usuariosNotificacionCodigo[0];
               A146usuariosNotificacionTipo = H009M2_A146usuariosNotificacionTipo[0];
               /* Execute user event: Load */
               E179M2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB9M0( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes9M2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSNOTIFICACIONTIPO"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, StringUtil.RTrim( context.localUtil.Format( A146usuariosNotificacionTipo, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSNOTIFICACIONCODIGO"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A147usuariosNotificacionCodigo), "ZZZZZZZZZ9"), context));
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
                                              AV8cusuariosNotificacionNotificado ,
                                              AV9cusuariosNotificacionObjeto ,
                                              AV10cusuariosNotificacionFecha ,
                                              A234usuariosNotificacionNotificado ,
                                              A421usuariosNotificacionObjeto ,
                                              A235usuariosNotificacionFecha ,
                                              A146usuariosNotificacionTipo ,
                                              AV6cusuariosNotificacionTipo ,
                                              A147usuariosNotificacionCodigo ,
                                              AV7cusuariosNotificacionCodigo ,
                                              AV11pusuariosId ,
                                              A145usuariosId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV6cusuariosNotificacionTipo = StringUtil.PadR( StringUtil.RTrim( AV6cusuariosNotificacionTipo), 1, "%");
         lV8cusuariosNotificacionNotificado = StringUtil.PadR( StringUtil.RTrim( AV8cusuariosNotificacionNotificado), 1, "%");
         lV9cusuariosNotificacionObjeto = StringUtil.PadR( StringUtil.RTrim( AV9cusuariosNotificacionObjeto), 100, "%");
         /* Using cursor H009M3 */
         pr_default.execute(1, new Object[] {AV11pusuariosId, lV6cusuariosNotificacionTipo, AV7cusuariosNotificacionCodigo, lV8cusuariosNotificacionNotificado, lV9cusuariosNotificacionObjeto, AV10cusuariosNotificacionFecha});
         GRID1_nRecordCount = H009M3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cusuariosNotificacionTipo, AV7cusuariosNotificacionCodigo, AV8cusuariosNotificacionNotificado, AV9cusuariosNotificacionObjeto, AV10cusuariosNotificacionFecha, AV11pusuariosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cusuariosNotificacionTipo, AV7cusuariosNotificacionCodigo, AV8cusuariosNotificacionNotificado, AV9cusuariosNotificacionObjeto, AV10cusuariosNotificacionFecha, AV11pusuariosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cusuariosNotificacionTipo, AV7cusuariosNotificacionCodigo, AV8cusuariosNotificacionNotificado, AV9cusuariosNotificacionObjeto, AV10cusuariosNotificacionFecha, AV11pusuariosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cusuariosNotificacionTipo, AV7cusuariosNotificacionCodigo, AV8cusuariosNotificacionNotificado, AV9cusuariosNotificacionObjeto, AV10cusuariosNotificacionFecha, AV11pusuariosId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cusuariosNotificacionTipo, AV7cusuariosNotificacionCodigo, AV8cusuariosNotificacionNotificado, AV9cusuariosNotificacionObjeto, AV10cusuariosNotificacionFecha, AV11pusuariosId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         cmbusuariosNotificacionTipo.Enabled = 0;
         edtusuariosNotificacionCodigo_Enabled = 0;
         chkusuariosNotificacionNotificado.Enabled = 0;
         edtusuariosNotificacionObjeto_Enabled = 0;
         edtusuariosId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP9M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E169M2 ();
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
            cmbavCusuariosnotificaciontipo.Name = cmbavCusuariosnotificaciontipo_Internalname;
            cmbavCusuariosnotificaciontipo.CurrentValue = cgiGet( cmbavCusuariosnotificaciontipo_Internalname);
            AV6cusuariosNotificacionTipo = cgiGet( cmbavCusuariosnotificaciontipo_Internalname);
            AssignAttri("", false, "AV6cusuariosNotificacionTipo", AV6cusuariosNotificacionTipo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCusuariosnotificacioncodigo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCusuariosnotificacioncodigo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUSUARIOSNOTIFICACIONCODIGO");
               GX_FocusControl = edtavCusuariosnotificacioncodigo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cusuariosNotificacionCodigo = 0;
               AssignAttri("", false, "AV7cusuariosNotificacionCodigo", StringUtil.LTrimStr( (decimal)(AV7cusuariosNotificacionCodigo), 10, 0));
            }
            else
            {
               AV7cusuariosNotificacionCodigo = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCusuariosnotificacioncodigo_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cusuariosNotificacionCodigo", StringUtil.LTrimStr( (decimal)(AV7cusuariosNotificacionCodigo), 10, 0));
            }
            AV8cusuariosNotificacionNotificado = ((StringUtil.StrCmp(cgiGet( chkavCusuariosnotificacionnotificado_Internalname), "S")==0) ? "S" : "N");
            AssignAttri("", false, "AV8cusuariosNotificacionNotificado", AV8cusuariosNotificacionNotificado);
            AV9cusuariosNotificacionObjeto = cgiGet( edtavCusuariosnotificacionobjeto_Internalname);
            AssignAttri("", false, "AV9cusuariosNotificacionObjeto", AV9cusuariosNotificacionObjeto);
            if ( context.localUtil.VCDateTime( cgiGet( edtavCusuariosnotificacionfecha_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Fecha", "")}), 1, "vCUSUARIOSNOTIFICACIONFECHA");
               GX_FocusControl = edtavCusuariosnotificacionfecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cusuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV10cusuariosNotificacionFecha", context.localUtil.TToC( AV10cusuariosNotificacionFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               AV10cusuariosNotificacionFecha = context.localUtil.CToT( cgiGet( edtavCusuariosnotificacionfecha_Internalname));
               AssignAttri("", false, "AV10cusuariosNotificacionFecha", context.localUtil.TToC( AV10cusuariosNotificacionFecha, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSNOTIFICACIONTIPO"), AV6cusuariosNotificacionTipo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOSNOTIFICACIONCODIGO"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cusuariosNotificacionCodigo )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSNOTIFICACIONNOTIFICADO"), AV8cusuariosNotificacionNotificado) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSNOTIFICACIONOBJETO"), AV9cusuariosNotificacionObjeto) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCUSUARIOSNOTIFICACIONFECHA")) != AV10cusuariosNotificacionFecha )
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
         E169M2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E169M2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Notificacion", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E179M2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "SelectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
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
         E189M2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E189M2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pusuariosNotificacionTipo = A146usuariosNotificacionTipo;
         AssignAttri("", false, "AV12pusuariosNotificacionTipo", AV12pusuariosNotificacionTipo);
         AV13pusuariosNotificacionCodigo = A147usuariosNotificacionCodigo;
         AssignAttri("", false, "AV13pusuariosNotificacionCodigo", StringUtil.LTrimStr( (decimal)(AV13pusuariosNotificacionCodigo), 10, 0));
         context.setWebReturnParms(new Object[] {(string)AV12pusuariosNotificacionTipo,(long)AV13pusuariosNotificacionCodigo});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pusuariosNotificacionTipo","AV13pusuariosNotificacionCodigo"});
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
         AV11pusuariosId = (string)getParm(obj,0);
         AssignAttri("", false, "AV11pusuariosId", AV11pusuariosId);
         AV12pusuariosNotificacionTipo = (string)getParm(obj,1);
         AssignAttri("", false, "AV12pusuariosNotificacionTipo", AV12pusuariosNotificacionTipo);
         AV13pusuariosNotificacionCodigo = Convert.ToInt64(getParm(obj,2));
         AssignAttri("", false, "AV13pusuariosNotificacionCodigo", StringUtil.LTrimStr( (decimal)(AV13pusuariosNotificacionCodigo), 10, 0));
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
         PA9M2( ) ;
         WS9M2( ) ;
         WE9M2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2026730212623", true, true, false);
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
         context.AddJavascriptSource("gx01a1.js", "?2026730212624", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         cmbusuariosNotificacionTipo_Internalname = "USUARIOSNOTIFICACIONTIPO_"+sGXsfl_64_idx;
         edtusuariosNotificacionCodigo_Internalname = "USUARIOSNOTIFICACIONCODIGO_"+sGXsfl_64_idx;
         chkusuariosNotificacionNotificado_Internalname = "USUARIOSNOTIFICACIONNOTIFICADO_"+sGXsfl_64_idx;
         edtusuariosNotificacionObjeto_Internalname = "USUARIOSNOTIFICACIONOBJETO_"+sGXsfl_64_idx;
         edtusuariosId_Internalname = "USUARIOSID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         cmbusuariosNotificacionTipo_Internalname = "USUARIOSNOTIFICACIONTIPO_"+sGXsfl_64_fel_idx;
         edtusuariosNotificacionCodigo_Internalname = "USUARIOSNOTIFICACIONCODIGO_"+sGXsfl_64_fel_idx;
         chkusuariosNotificacionNotificado_Internalname = "USUARIOSNOTIFICACIONNOTIFICADO_"+sGXsfl_64_fel_idx;
         edtusuariosNotificacionObjeto_Internalname = "USUARIOSNOTIFICACIONOBJETO_"+sGXsfl_64_fel_idx;
         edtusuariosId_Internalname = "USUARIOSID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         WB9M0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.RTrim( A146usuariosNotificacionTipo))+"'"+", "+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A147usuariosNotificacionCodigo), 10, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl),(string)"none"});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbusuariosNotificacionTipo.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "USUARIOSNOTIFICACIONTIPO_" + sGXsfl_64_idx;
               cmbusuariosNotificacionTipo.Name = GXCCtl;
               cmbusuariosNotificacionTipo.WebTags = "";
               cmbusuariosNotificacionTipo.addItem("E", context.GetMessage( "Eventos", ""), 0);
               cmbusuariosNotificacionTipo.addItem("T", context.GetMessage( "Tags", ""), 0);
               cmbusuariosNotificacionTipo.addItem("M", context.GetMessage( "Mensaje", ""), 0);
               cmbusuariosNotificacionTipo.addItem("C", context.GetMessage( "Correo", ""), 0);
               cmbusuariosNotificacionTipo.addItem("N", context.GetMessage( "Notificaciones", ""), 0);
               cmbusuariosNotificacionTipo.addItem("I", context.GetMessage( "Me Interesa", ""), 0);
               if ( cmbusuariosNotificacionTipo.ItemCount > 0 )
               {
                  A146usuariosNotificacionTipo = cmbusuariosNotificacionTipo.getValidValue(A146usuariosNotificacionTipo);
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbusuariosNotificacionTipo,(string)cmbusuariosNotificacionTipo_Internalname,StringUtil.RTrim( A146usuariosNotificacionTipo),(short)1,(string)cmbusuariosNotificacionTipo_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbusuariosNotificacionTipo.CurrentValue = StringUtil.RTrim( A146usuariosNotificacionTipo);
            AssignProp("", false, cmbusuariosNotificacionTipo_Internalname, "Values", (string)(cmbusuariosNotificacionTipo.ToJavascriptSource()), !bGXsfl_64_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosNotificacionCodigo_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A147usuariosNotificacionCodigo), 10, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A147usuariosNotificacionCodigo), "ZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosNotificacionCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "DescriptionAttribute";
            StyleString = "";
            GXCCtl = "USUARIOSNOTIFICACIONNOTIFICADO_" + sGXsfl_64_idx;
            chkusuariosNotificacionNotificado.Name = GXCCtl;
            chkusuariosNotificacionNotificado.WebTags = "";
            chkusuariosNotificacionNotificado.Caption = "";
            AssignProp("", false, chkusuariosNotificacionNotificado_Internalname, "TitleCaption", chkusuariosNotificacionNotificado.Caption, !bGXsfl_64_Refreshing);
            chkusuariosNotificacionNotificado.CheckedValue = "N";
            A234usuariosNotificacionNotificado = ((StringUtil.StrCmp(StringUtil.RTrim( A234usuariosNotificacionNotificado), "S")==0) ? "S" : "N");
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkusuariosNotificacionNotificado_Internalname,(string)A234usuariosNotificacionNotificado,(string)"",(string)"",(short)-1,(short)0,(string)"S",context.GetMessage( "Notificado", ""),(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosNotificacionObjeto_Internalname,StringUtil.RTrim( A421usuariosNotificacionObjeto),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosNotificacionObjeto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtusuariosId_Internalname,StringUtil.RTrim( A145usuariosId),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtusuariosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"NickName",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes9M2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         cmbavCusuariosnotificaciontipo.Name = "vCUSUARIOSNOTIFICACIONTIPO";
         cmbavCusuariosnotificaciontipo.WebTags = "";
         cmbavCusuariosnotificaciontipo.addItem("E", context.GetMessage( "Eventos", ""), 0);
         cmbavCusuariosnotificaciontipo.addItem("T", context.GetMessage( "Tags", ""), 0);
         cmbavCusuariosnotificaciontipo.addItem("M", context.GetMessage( "Mensaje", ""), 0);
         cmbavCusuariosnotificaciontipo.addItem("C", context.GetMessage( "Correo", ""), 0);
         cmbavCusuariosnotificaciontipo.addItem("N", context.GetMessage( "Notificaciones", ""), 0);
         cmbavCusuariosnotificaciontipo.addItem("I", context.GetMessage( "Me Interesa", ""), 0);
         if ( cmbavCusuariosnotificaciontipo.ItemCount > 0 )
         {
            AV6cusuariosNotificacionTipo = cmbavCusuariosnotificaciontipo.getValidValue(AV6cusuariosNotificacionTipo);
            AssignAttri("", false, "AV6cusuariosNotificacionTipo", AV6cusuariosNotificacionTipo);
         }
         chkavCusuariosnotificacionnotificado.Name = "vCUSUARIOSNOTIFICACIONNOTIFICADO";
         chkavCusuariosnotificacionnotificado.WebTags = "";
         chkavCusuariosnotificacionnotificado.Caption = context.GetMessage( "Notificado", "");
         AssignProp("", false, chkavCusuariosnotificacionnotificado_Internalname, "TitleCaption", chkavCusuariosnotificacionnotificado.Caption, true);
         chkavCusuariosnotificacionnotificado.CheckedValue = "N";
         AV8cusuariosNotificacionNotificado = ((StringUtil.StrCmp(StringUtil.RTrim( AV8cusuariosNotificacionNotificado), "S")==0) ? "S" : "N");
         AssignAttri("", false, "AV8cusuariosNotificacionNotificado", AV8cusuariosNotificacionNotificado);
         GXCCtl = "USUARIOSNOTIFICACIONTIPO_" + sGXsfl_64_idx;
         cmbusuariosNotificacionTipo.Name = GXCCtl;
         cmbusuariosNotificacionTipo.WebTags = "";
         cmbusuariosNotificacionTipo.addItem("E", context.GetMessage( "Eventos", ""), 0);
         cmbusuariosNotificacionTipo.addItem("T", context.GetMessage( "Tags", ""), 0);
         cmbusuariosNotificacionTipo.addItem("M", context.GetMessage( "Mensaje", ""), 0);
         cmbusuariosNotificacionTipo.addItem("C", context.GetMessage( "Correo", ""), 0);
         cmbusuariosNotificacionTipo.addItem("N", context.GetMessage( "Notificaciones", ""), 0);
         cmbusuariosNotificacionTipo.addItem("I", context.GetMessage( "Me Interesa", ""), 0);
         if ( cmbusuariosNotificacionTipo.ItemCount > 0 )
         {
            A146usuariosNotificacionTipo = cmbusuariosNotificacionTipo.getValidValue(A146usuariosNotificacionTipo);
         }
         GXCCtl = "USUARIOSNOTIFICACIONNOTIFICADO_" + sGXsfl_64_idx;
         chkusuariosNotificacionNotificado.Name = GXCCtl;
         chkusuariosNotificacionNotificado.WebTags = "";
         chkusuariosNotificacionNotificado.Caption = "";
         AssignProp("", false, chkusuariosNotificacionNotificado_Internalname, "TitleCaption", chkusuariosNotificacionNotificado.Caption, !bGXsfl_64_Refreshing);
         chkusuariosNotificacionNotificado.CheckedValue = "N";
         A234usuariosNotificacionNotificado = ((StringUtil.StrCmp(StringUtil.RTrim( A234usuariosNotificacionNotificado), "S")==0) ? "S" : "N");
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
            context.SendWebValue( context.GetMessage( "Tipo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Codigo", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Notificado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Objeto", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "NickName", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A146usuariosNotificacionTipo)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A147usuariosNotificacionCodigo), 10, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A234usuariosNotificacionNotificado)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A421usuariosNotificacionObjeto)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A145usuariosId)));
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
         lblLblusuariosnotificaciontipofilter_Internalname = "LBLUSUARIOSNOTIFICACIONTIPOFILTER";
         cmbavCusuariosnotificaciontipo_Internalname = "vCUSUARIOSNOTIFICACIONTIPO";
         divUsuariosnotificaciontipofiltercontainer_Internalname = "USUARIOSNOTIFICACIONTIPOFILTERCONTAINER";
         lblLblusuariosnotificacioncodigofilter_Internalname = "LBLUSUARIOSNOTIFICACIONCODIGOFILTER";
         edtavCusuariosnotificacioncodigo_Internalname = "vCUSUARIOSNOTIFICACIONCODIGO";
         divUsuariosnotificacioncodigofiltercontainer_Internalname = "USUARIOSNOTIFICACIONCODIGOFILTERCONTAINER";
         lblLblusuariosnotificacionnotificadofilter_Internalname = "LBLUSUARIOSNOTIFICACIONNOTIFICADOFILTER";
         chkavCusuariosnotificacionnotificado_Internalname = "vCUSUARIOSNOTIFICACIONNOTIFICADO";
         divUsuariosnotificacionnotificadofiltercontainer_Internalname = "USUARIOSNOTIFICACIONNOTIFICADOFILTERCONTAINER";
         lblLblusuariosnotificacionobjetofilter_Internalname = "LBLUSUARIOSNOTIFICACIONOBJETOFILTER";
         edtavCusuariosnotificacionobjeto_Internalname = "vCUSUARIOSNOTIFICACIONOBJETO";
         divUsuariosnotificacionobjetofiltercontainer_Internalname = "USUARIOSNOTIFICACIONOBJETOFILTERCONTAINER";
         lblLblusuariosnotificacionfechafilter_Internalname = "LBLUSUARIOSNOTIFICACIONFECHAFILTER";
         edtavCusuariosnotificacionfecha_Internalname = "vCUSUARIOSNOTIFICACIONFECHA";
         divUsuariosnotificacionfechafiltercontainer_Internalname = "USUARIOSNOTIFICACIONFECHAFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         cmbusuariosNotificacionTipo_Internalname = "USUARIOSNOTIFICACIONTIPO";
         edtusuariosNotificacionCodigo_Internalname = "USUARIOSNOTIFICACIONCODIGO";
         chkusuariosNotificacionNotificado_Internalname = "USUARIOSNOTIFICACIONNOTIFICADO";
         edtusuariosNotificacionObjeto_Internalname = "USUARIOSNOTIFICACIONOBJETO";
         edtusuariosId_Internalname = "USUARIOSID";
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
         chkavCusuariosnotificacionnotificado.Caption = context.GetMessage( "Notificado", "");
         edtusuariosId_Jsonclick = "";
         edtusuariosNotificacionObjeto_Jsonclick = "";
         chkusuariosNotificacionNotificado.Caption = "";
         edtusuariosNotificacionCodigo_Jsonclick = "";
         cmbusuariosNotificacionTipo_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtusuariosId_Enabled = 0;
         edtusuariosNotificacionObjeto_Enabled = 0;
         chkusuariosNotificacionNotificado.Enabled = 0;
         edtusuariosNotificacionCodigo_Enabled = 0;
         cmbusuariosNotificacionTipo.Enabled = 0;
         edtavCusuariosnotificacionfecha_Jsonclick = "";
         edtavCusuariosnotificacionfecha_Enabled = 1;
         edtavCusuariosnotificacionobjeto_Jsonclick = "";
         edtavCusuariosnotificacionobjeto_Enabled = 1;
         edtavCusuariosnotificacionobjeto_Visible = 1;
         chkavCusuariosnotificacionnotificado.Enabled = 1;
         chkavCusuariosnotificacionnotificado.Visible = 1;
         edtavCusuariosnotificacioncodigo_Jsonclick = "";
         edtavCusuariosnotificacioncodigo_Enabled = 1;
         edtavCusuariosnotificacioncodigo_Visible = 1;
         cmbavCusuariosnotificaciontipo_Jsonclick = "";
         cmbavCusuariosnotificaciontipo.Visible = 1;
         cmbavCusuariosnotificaciontipo.Enabled = 1;
         divUsuariosnotificacionobjetofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divUsuariosnotificacionnotificadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divUsuariosnotificacioncodigofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divUsuariosnotificaciontipofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Notificacion", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'cmbavCusuariosnotificaciontipo'},{av:'AV6cusuariosNotificacionTipo',fld:'vCUSUARIOSNOTIFICACIONTIPO',pic:'',type:'char'},{av:'AV7cusuariosNotificacionCodigo',fld:'vCUSUARIOSNOTIFICACIONCODIGO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV9cusuariosNotificacionObjeto',fld:'vCUSUARIOSNOTIFICACIONOBJETO',pic:'',type:'char'},{av:'AV10cusuariosNotificacionFecha',fld:'vCUSUARIOSNOTIFICACIONFECHA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV11pusuariosId',fld:'vPUSUARIOSID',pic:'',type:'char'},{av:'AV8cusuariosNotificacionNotificado',fld:'vCUSUARIOSNOTIFICACIONNOTIFICADO',pic:'',type:'char'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E159M1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLUSUARIOSNOTIFICACIONTIPOFILTER.CLICK","{handler:'E119M1',iparms:[{av:'divUsuariosnotificaciontipofiltercontainer_Class',ctrl:'USUARIOSNOTIFICACIONTIPOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSNOTIFICACIONTIPOFILTER.CLICK",",oparms:[{av:'divUsuariosnotificaciontipofiltercontainer_Class',ctrl:'USUARIOSNOTIFICACIONTIPOFILTERCONTAINER',prop:'Class'},{av:'cmbavCusuariosnotificaciontipo'}]}");
         setEventMetadata("LBLUSUARIOSNOTIFICACIONCODIGOFILTER.CLICK","{handler:'E129M1',iparms:[{av:'divUsuariosnotificacioncodigofiltercontainer_Class',ctrl:'USUARIOSNOTIFICACIONCODIGOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSNOTIFICACIONCODIGOFILTER.CLICK",",oparms:[{av:'divUsuariosnotificacioncodigofiltercontainer_Class',ctrl:'USUARIOSNOTIFICACIONCODIGOFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosnotificacioncodigo_Visible',ctrl:'vCUSUARIOSNOTIFICACIONCODIGO',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSNOTIFICACIONNOTIFICADOFILTER.CLICK","{handler:'E139M1',iparms:[{av:'divUsuariosnotificacionnotificadofiltercontainer_Class',ctrl:'USUARIOSNOTIFICACIONNOTIFICADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSNOTIFICACIONNOTIFICADOFILTER.CLICK",",oparms:[{av:'divUsuariosnotificacionnotificadofiltercontainer_Class',ctrl:'USUARIOSNOTIFICACIONNOTIFICADOFILTERCONTAINER',prop:'Class'},{av:'chkavCusuariosnotificacionnotificado.Visible',ctrl:'vCUSUARIOSNOTIFICACIONNOTIFICADO',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSNOTIFICACIONOBJETOFILTER.CLICK","{handler:'E149M1',iparms:[{av:'divUsuariosnotificacionobjetofiltercontainer_Class',ctrl:'USUARIOSNOTIFICACIONOBJETOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSNOTIFICACIONOBJETOFILTER.CLICK",",oparms:[{av:'divUsuariosnotificacionobjetofiltercontainer_Class',ctrl:'USUARIOSNOTIFICACIONOBJETOFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosnotificacionobjeto_Visible',ctrl:'vCUSUARIOSNOTIFICACIONOBJETO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E189M2',iparms:[{av:'cmbusuariosNotificacionTipo'},{av:'A146usuariosNotificacionTipo',fld:'USUARIOSNOTIFICACIONTIPO',pic:'',hsh:true,type:'char'},{av:'A147usuariosNotificacionCodigo',fld:'USUARIOSNOTIFICACIONCODIGO',pic:'ZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pusuariosNotificacionTipo',fld:'vPUSUARIOSNOTIFICACIONTIPO',pic:'',type:'char'},{av:'AV13pusuariosNotificacionCodigo',fld:'vPUSUARIOSNOTIFICACIONCODIGO',pic:'ZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'cmbavCusuariosnotificaciontipo'},{av:'AV6cusuariosNotificacionTipo',fld:'vCUSUARIOSNOTIFICACIONTIPO',pic:'',type:'char'},{av:'AV7cusuariosNotificacionCodigo',fld:'vCUSUARIOSNOTIFICACIONCODIGO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV9cusuariosNotificacionObjeto',fld:'vCUSUARIOSNOTIFICACIONOBJETO',pic:'',type:'char'},{av:'AV10cusuariosNotificacionFecha',fld:'vCUSUARIOSNOTIFICACIONFECHA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV11pusuariosId',fld:'vPUSUARIOSID',pic:'',type:'char'},{av:'AV8cusuariosNotificacionNotificado',fld:'vCUSUARIOSNOTIFICACIONNOTIFICADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'cmbavCusuariosnotificaciontipo'},{av:'AV6cusuariosNotificacionTipo',fld:'vCUSUARIOSNOTIFICACIONTIPO',pic:'',type:'char'},{av:'AV7cusuariosNotificacionCodigo',fld:'vCUSUARIOSNOTIFICACIONCODIGO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV9cusuariosNotificacionObjeto',fld:'vCUSUARIOSNOTIFICACIONOBJETO',pic:'',type:'char'},{av:'AV10cusuariosNotificacionFecha',fld:'vCUSUARIOSNOTIFICACIONFECHA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV11pusuariosId',fld:'vPUSUARIOSID',pic:'',type:'char'},{av:'AV8cusuariosNotificacionNotificado',fld:'vCUSUARIOSNOTIFICACIONNOTIFICADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'cmbavCusuariosnotificaciontipo'},{av:'AV6cusuariosNotificacionTipo',fld:'vCUSUARIOSNOTIFICACIONTIPO',pic:'',type:'char'},{av:'AV7cusuariosNotificacionCodigo',fld:'vCUSUARIOSNOTIFICACIONCODIGO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV9cusuariosNotificacionObjeto',fld:'vCUSUARIOSNOTIFICACIONOBJETO',pic:'',type:'char'},{av:'AV10cusuariosNotificacionFecha',fld:'vCUSUARIOSNOTIFICACIONFECHA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV11pusuariosId',fld:'vPUSUARIOSID',pic:'',type:'char'},{av:'AV8cusuariosNotificacionNotificado',fld:'vCUSUARIOSNOTIFICACIONNOTIFICADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'cmbavCusuariosnotificaciontipo'},{av:'AV6cusuariosNotificacionTipo',fld:'vCUSUARIOSNOTIFICACIONTIPO',pic:'',type:'char'},{av:'AV7cusuariosNotificacionCodigo',fld:'vCUSUARIOSNOTIFICACIONCODIGO',pic:'ZZZZZZZZZ9',type:'int'},{av:'AV9cusuariosNotificacionObjeto',fld:'vCUSUARIOSNOTIFICACIONOBJETO',pic:'',type:'char'},{av:'AV10cusuariosNotificacionFecha',fld:'vCUSUARIOSNOTIFICACIONFECHA',pic:'99/99/99 99:99',type:'dtime'},{av:'AV11pusuariosId',fld:'vPUSUARIOSID',pic:'',type:'char'},{av:'AV8cusuariosNotificacionNotificado',fld:'vCUSUARIOSNOTIFICACIONNOTIFICADO',pic:'',type:'char'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CUSUARIOSNOTIFICACIONFECHA","{handler:'Validv_Cusuariosnotificacionfecha',iparms:[]");
         setEventMetadata("VALIDV_CUSUARIOSNOTIFICACIONFECHA",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Usuariosid',iparms:[]");
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
         AV12pusuariosNotificacionTipo = "";
         wcpOAV11pusuariosId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cusuariosNotificacionTipo = "";
         AV8cusuariosNotificacionNotificado = "";
         AV9cusuariosNotificacionObjeto = "";
         AV10cusuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblusuariosnotificaciontipofilter_Jsonclick = "";
         TempTags = "";
         lblLblusuariosnotificacioncodigofilter_Jsonclick = "";
         lblLblusuariosnotificacionnotificadofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblusuariosnotificacionobjetofilter_Jsonclick = "";
         lblLblusuariosnotificacionfechafilter_Jsonclick = "";
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
         A146usuariosNotificacionTipo = "";
         A234usuariosNotificacionNotificado = "";
         A421usuariosNotificacionObjeto = "";
         A145usuariosId = "";
         lV6cusuariosNotificacionTipo = "";
         lV8cusuariosNotificacionNotificado = "";
         lV9cusuariosNotificacionObjeto = "";
         A235usuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
         H009M2_A235usuariosNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         H009M2_A145usuariosId = new string[] {""} ;
         H009M2_A421usuariosNotificacionObjeto = new string[] {""} ;
         H009M2_A234usuariosNotificacionNotificado = new string[] {""} ;
         H009M2_A147usuariosNotificacionCodigo = new long[1] ;
         H009M2_A146usuariosNotificacionTipo = new string[] {""} ;
         H009M3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         GXCCtl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx01a1__default(),
            new Object[][] {
                new Object[] {
               H009M2_A235usuariosNotificacionFecha, H009M2_A145usuariosId, H009M2_A421usuariosNotificacionObjeto, H009M2_A234usuariosNotificacionNotificado, H009M2_A147usuariosNotificacionCodigo, H009M2_A146usuariosNotificacionTipo
               }
               , new Object[] {
               H009M3_AGRID1_nRecordCount
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
      private int nRC_GXsfl_64 ;
      private int subGrid1_Rows ;
      private int nGXsfl_64_idx=1 ;
      private int edtavCusuariosnotificacioncodigo_Enabled ;
      private int edtavCusuariosnotificacioncodigo_Visible ;
      private int edtavCusuariosnotificacionobjeto_Visible ;
      private int edtavCusuariosnotificacionobjeto_Enabled ;
      private int edtavCusuariosnotificacionfecha_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtusuariosNotificacionCodigo_Enabled ;
      private int edtusuariosNotificacionObjeto_Enabled ;
      private int edtusuariosId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV13pusuariosNotificacionCodigo ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV7cusuariosNotificacionCodigo ;
      private long A147usuariosNotificacionCodigo ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string AV11pusuariosId ;
      private string AV12pusuariosNotificacionTipo ;
      private string wcpOAV11pusuariosId ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divUsuariosnotificaciontipofiltercontainer_Class ;
      private string divUsuariosnotificacioncodigofiltercontainer_Class ;
      private string divUsuariosnotificacionnotificadofiltercontainer_Class ;
      private string divUsuariosnotificacionobjetofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string AV6cusuariosNotificacionTipo ;
      private string AV8cusuariosNotificacionNotificado ;
      private string AV9cusuariosNotificacionObjeto ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divUsuariosnotificaciontipofiltercontainer_Internalname ;
      private string lblLblusuariosnotificaciontipofilter_Internalname ;
      private string lblLblusuariosnotificaciontipofilter_Jsonclick ;
      private string cmbavCusuariosnotificaciontipo_Internalname ;
      private string TempTags ;
      private string cmbavCusuariosnotificaciontipo_Jsonclick ;
      private string divUsuariosnotificacioncodigofiltercontainer_Internalname ;
      private string lblLblusuariosnotificacioncodigofilter_Internalname ;
      private string lblLblusuariosnotificacioncodigofilter_Jsonclick ;
      private string edtavCusuariosnotificacioncodigo_Internalname ;
      private string edtavCusuariosnotificacioncodigo_Jsonclick ;
      private string divUsuariosnotificacionnotificadofiltercontainer_Internalname ;
      private string lblLblusuariosnotificacionnotificadofilter_Internalname ;
      private string lblLblusuariosnotificacionnotificadofilter_Jsonclick ;
      private string chkavCusuariosnotificacionnotificado_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divUsuariosnotificacionobjetofiltercontainer_Internalname ;
      private string lblLblusuariosnotificacionobjetofilter_Internalname ;
      private string lblLblusuariosnotificacionobjetofilter_Jsonclick ;
      private string edtavCusuariosnotificacionobjeto_Internalname ;
      private string edtavCusuariosnotificacionobjeto_Jsonclick ;
      private string divUsuariosnotificacionfechafiltercontainer_Internalname ;
      private string lblLblusuariosnotificacionfechafilter_Internalname ;
      private string lblLblusuariosnotificacionfechafilter_Jsonclick ;
      private string edtavCusuariosnotificacionfecha_Internalname ;
      private string edtavCusuariosnotificacionfecha_Jsonclick ;
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
      private string cmbusuariosNotificacionTipo_Internalname ;
      private string A146usuariosNotificacionTipo ;
      private string edtusuariosNotificacionCodigo_Internalname ;
      private string A234usuariosNotificacionNotificado ;
      private string chkusuariosNotificacionNotificado_Internalname ;
      private string A421usuariosNotificacionObjeto ;
      private string edtusuariosNotificacionObjeto_Internalname ;
      private string A145usuariosId ;
      private string edtusuariosId_Internalname ;
      private string lV6cusuariosNotificacionTipo ;
      private string lV8cusuariosNotificacionNotificado ;
      private string lV9cusuariosNotificacionObjeto ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string GXCCtl ;
      private string cmbusuariosNotificacionTipo_Jsonclick ;
      private string ROClassString ;
      private string edtusuariosNotificacionCodigo_Jsonclick ;
      private string edtusuariosNotificacionObjeto_Jsonclick ;
      private string edtusuariosId_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV10cusuariosNotificacionFecha ;
      private DateTime A235usuariosNotificacionFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
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
      private GXCombobox cmbavCusuariosnotificaciontipo ;
      private GXCheckbox chkavCusuariosnotificacionnotificado ;
      private GXCombobox cmbusuariosNotificacionTipo ;
      private GXCheckbox chkusuariosNotificacionNotificado ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H009M2_A235usuariosNotificacionFecha ;
      private string[] H009M2_A145usuariosId ;
      private string[] H009M2_A421usuariosNotificacionObjeto ;
      private string[] H009M2_A234usuariosNotificacionNotificado ;
      private long[] H009M2_A147usuariosNotificacionCodigo ;
      private string[] H009M2_A146usuariosNotificacionTipo ;
      private long[] H009M3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP1_pusuariosNotificacionTipo ;
      private long aP2_pusuariosNotificacionCodigo ;
   }

   public class gx01a1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H009M2( IGxContext context ,
                                             string AV8cusuariosNotificacionNotificado ,
                                             string AV9cusuariosNotificacionObjeto ,
                                             DateTime AV10cusuariosNotificacionFecha ,
                                             string A234usuariosNotificacionNotificado ,
                                             string A421usuariosNotificacionObjeto ,
                                             DateTime A235usuariosNotificacionFecha ,
                                             string A146usuariosNotificacionTipo ,
                                             string AV6cusuariosNotificacionTipo ,
                                             long A147usuariosNotificacionCodigo ,
                                             long AV7cusuariosNotificacionCodigo ,
                                             string AV11pusuariosId ,
                                             string A145usuariosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [usuariosNotificacionFecha], [usuariosId], [usuariosNotificacionObjeto], [usuariosNotificacionNotificado], [usuariosNotificacionCodigo], [usuariosNotificacionTipo]";
         sFromString = " FROM [usuariosNotificacion]";
         sOrderString = "";
         AddWhere(sWhereString, "([usuariosId] = @AV11pusuariosId)");
         AddWhere(sWhereString, "([usuariosNotificacionTipo] like @lV6cusuariosNotificacionTipo)");
         AddWhere(sWhereString, "([usuariosNotificacionCodigo] >= @AV7cusuariosNotificacionCodigo)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cusuariosNotificacionNotificado)) )
         {
            AddWhere(sWhereString, "([usuariosNotificacionNotificado] like @lV8cusuariosNotificacionNotificado)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cusuariosNotificacionObjeto)) )
         {
            AddWhere(sWhereString, "([usuariosNotificacionObjeto] like @lV9cusuariosNotificacionObjeto)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cusuariosNotificacionFecha) )
         {
            AddWhere(sWhereString, "([usuariosNotificacionFecha] >= @AV10cusuariosNotificacionFecha)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H009M3( IGxContext context ,
                                             string AV8cusuariosNotificacionNotificado ,
                                             string AV9cusuariosNotificacionObjeto ,
                                             DateTime AV10cusuariosNotificacionFecha ,
                                             string A234usuariosNotificacionNotificado ,
                                             string A421usuariosNotificacionObjeto ,
                                             DateTime A235usuariosNotificacionFecha ,
                                             string A146usuariosNotificacionTipo ,
                                             string AV6cusuariosNotificacionTipo ,
                                             long A147usuariosNotificacionCodigo ,
                                             long AV7cusuariosNotificacionCodigo ,
                                             string AV11pusuariosId ,
                                             string A145usuariosId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [usuariosNotificacion]";
         AddWhere(sWhereString, "([usuariosId] = @AV11pusuariosId)");
         AddWhere(sWhereString, "([usuariosNotificacionTipo] like @lV6cusuariosNotificacionTipo)");
         AddWhere(sWhereString, "([usuariosNotificacionCodigo] >= @AV7cusuariosNotificacionCodigo)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cusuariosNotificacionNotificado)) )
         {
            AddWhere(sWhereString, "([usuariosNotificacionNotificado] like @lV8cusuariosNotificacionNotificado)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cusuariosNotificacionObjeto)) )
         {
            AddWhere(sWhereString, "([usuariosNotificacionObjeto] like @lV9cusuariosNotificacionObjeto)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cusuariosNotificacionFecha) )
         {
            AddWhere(sWhereString, "([usuariosNotificacionFecha] >= @AV10cusuariosNotificacionFecha)");
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
               case 0 :
                     return conditional_H009M2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
               case 1 :
                     return conditional_H009M3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
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
          Object[] prmH009M2;
          prmH009M2 = new Object[] {
          new ParDef("@AV11pusuariosId",GXType.NChar,20,0) ,
          new ParDef("@lV6cusuariosNotificacionTipo",GXType.NChar,1,0) ,
          new ParDef("@AV7cusuariosNotificacionCodigo",GXType.Decimal,10,0) ,
          new ParDef("@lV8cusuariosNotificacionNotificado",GXType.NChar,1,0) ,
          new ParDef("@lV9cusuariosNotificacionObjeto",GXType.NChar,100,0) ,
          new ParDef("@AV10cusuariosNotificacionFecha",GXType.DateTime,8,5) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH009M3;
          prmH009M3 = new Object[] {
          new ParDef("@AV11pusuariosId",GXType.NChar,20,0) ,
          new ParDef("@lV6cusuariosNotificacionTipo",GXType.NChar,1,0) ,
          new ParDef("@AV7cusuariosNotificacionCodigo",GXType.Decimal,10,0) ,
          new ParDef("@lV8cusuariosNotificacionNotificado",GXType.NChar,1,0) ,
          new ParDef("@lV9cusuariosNotificacionObjeto",GXType.NChar,100,0) ,
          new ParDef("@AV10cusuariosNotificacionFecha",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("H009M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009M2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H009M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH009M3,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}

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
   public class gx0381 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0381( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gx0381( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_pProveedorID ,
                           out long aP1_pComercioProductosRubrosID )
      {
         this.AV12pProveedorID = aP0_pProveedorID;
         this.AV13pComercioProductosRubrosID = 0 ;
         ExecutePrivate();
         aP1_pComercioProductosRubrosID=this.AV13pComercioProductosRubrosID;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCcomerciorubrosestado = new GXCombobox();
         chkavCcomercioitemsestado = new GXCheckbox();
         cmbComercioRubrosEstado = new GXCombobox();
         chkComercioItemsEstado = new GXCheckbox();
         chkComercioRubrosInventarioActiva = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pProveedorID");
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
               gxfirstwebparm = GetFirstPar( "pProveedorID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pProveedorID");
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
               AV12pProveedorID = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12pProveedorID", StringUtil.LTrimStr( (decimal)(AV12pProveedorID), 18, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13pComercioProductosRubrosID = (long)(Math.Round(NumberUtil.Val( GetPar( "pComercioProductosRubrosID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13pComercioProductosRubrosID", StringUtil.LTrimStr( (decimal)(AV13pComercioProductosRubrosID), 18, 0));
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
         AV6cComercioProductosRubrosID = (long)(Math.Round(NumberUtil.Val( GetPar( "cComercioProductosRubrosID"), "."), 18, MidpointRounding.ToEven));
         AV7cRubrosId = (short)(Math.Round(NumberUtil.Val( GetPar( "cRubrosId"), "."), 18, MidpointRounding.ToEven));
         cmbavCcomerciorubrosestado.FromJSonString( GetNextPar( ));
         AV8cComercioRubrosEstado = StringUtil.StrToBool( GetPar( "cComercioRubrosEstado"));
         AV9cMedidasNombre = GetPar( "cMedidasNombre");
         AV10cComercioItemsEstado = StringUtil.StrToBool( GetPar( "cComercioItemsEstado"));
         AV11cInventarioNombre = GetPar( "cInventarioNombre");
         AV12pProveedorID = (long)(Math.Round(NumberUtil.Val( GetPar( "pProveedorID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cComercioProductosRubrosID, AV7cRubrosId, AV8cComercioRubrosEstado, AV9cMedidasNombre, AV10cComercioItemsEstado, AV11cInventarioNombre, AV12pProveedorID) ;
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
         PADL2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            STARTDL2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0381.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pProveedorID,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pComercioProductosRubrosID,18,0))}, new string[] {"pProveedorID","pComercioProductosRubrosID"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCOMERCIOPRODUCTOSRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cComercioProductosRubrosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOMERCIORUBROSESTADO", StringUtil.BoolToStr( AV8cComercioRubrosEstado));
         GxWebStd.gx_hidden_field( context, "GXH_vCMEDIDASNOMBRE", StringUtil.RTrim( AV9cMedidasNombre));
         GxWebStd.gx_hidden_field( context, "GXH_vCCOMERCIOITEMSESTADO", StringUtil.BoolToStr( AV10cComercioItemsEstado));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVENTARIONOMBRE", StringUtil.RTrim( AV11cInventarioNombre));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPPROVEEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPCOMERCIOPRODUCTOSRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pComercioProductosRubrosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "COMERCIOPRODUCTOSRUBROSIDFILTERCONTAINER_Class", StringUtil.RTrim( divComercioproductosrubrosidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RUBROSIDFILTERCONTAINER_Class", StringUtil.RTrim( divRubrosidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COMERCIORUBROSESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divComerciorubrosestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MEDIDASNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divMedidasnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "COMERCIOITEMSESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divComercioitemsestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVENTARIONOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divInventarionombrefiltercontainer_Class));
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
            WEDL2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVTDL2( ) ;
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
         return formatLink("gx0381.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pProveedorID,18,0)),UrlEncode(StringUtil.LTrimStr(AV13pComercioProductosRubrosID,18,0))}, new string[] {"pProveedorID","pComercioProductosRubrosID"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0381" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Selection List Rubros", "") ;
      }

      protected void WBDL0( )
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
            GxWebStd.gx_div_start( context, divComercioproductosrubrosidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divComercioproductosrubrosidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcomercioproductosrubrosidfilter_Internalname, context.GetMessage( "Comercio Productos Rubros ID", ""), "", "", lblLblcomercioproductosrubrosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11dl1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0381.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcomercioproductosrubrosid_Internalname, context.GetMessage( "Comercio Productos Rubros ID", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcomercioproductosrubrosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cComercioProductosRubrosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCcomercioproductosrubrosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cComercioProductosRubrosID), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cComercioProductosRubrosID), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcomercioproductosrubrosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcomercioproductosrubrosid_Visible, edtavCcomercioproductosrubrosid_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0381.htm");
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
            GxWebStd.gx_div_start( context, divRubrosidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRubrosidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrubrosidfilter_Internalname, context.GetMessage( "Rubros Identificador ", ""), "", "", lblLblrubrosidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12dl1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0381.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrubrosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cRubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtavCrubrosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cRubrosId), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cRubrosId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrubrosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrubrosid_Visible, edtavCrubrosid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0381.htm");
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
            GxWebStd.gx_div_start( context, divComerciorubrosestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divComerciorubrosestadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcomerciorubrosestadofilter_Internalname, context.GetMessage( "Activado", ""), "", "", lblLblcomerciorubrosestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13dl1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0381.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCcomerciorubrosestado_Internalname, context.GetMessage( "Activado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCcomerciorubrosestado, cmbavCcomerciorubrosestado_Internalname, StringUtil.BoolToStr( AV8cComercioRubrosEstado), 1, cmbavCcomerciorubrosestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", cmbavCcomerciorubrosestado.Visible, cmbavCcomerciorubrosestado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_Gx0381.htm");
            cmbavCcomerciorubrosestado.CurrentValue = StringUtil.BoolToStr( AV8cComercioRubrosEstado);
            AssignProp("", false, cmbavCcomerciorubrosestado_Internalname, "Values", (string)(cmbavCcomerciorubrosestado.ToJavascriptSource()), true);
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
            GxWebStd.gx_label_ctrl( context, lblLblmedidasnombrefilter_Internalname, context.GetMessage( "Nombre de la Característica", ""), "", "", lblLblmedidasnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14dl1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0381.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCmedidasnombre_Internalname, StringUtil.RTrim( AV9cMedidasNombre), StringUtil.RTrim( context.localUtil.Format( AV9cMedidasNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCmedidasnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCmedidasnombre_Visible, edtavCmedidasnombre_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0381.htm");
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
            GxWebStd.gx_div_start( context, divComercioitemsestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divComercioitemsestadofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcomercioitemsestadofilter_Internalname, context.GetMessage( "Activado", ""), "", "", lblLblcomercioitemsestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15dl1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0381.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCcomercioitemsestado_Internalname, context.GetMessage( "Activado", ""), "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCcomercioitemsestado_Internalname, StringUtil.BoolToStr( AV10cComercioItemsEstado), "", context.GetMessage( "Activado", ""), chkavCcomercioitemsestado.Visible, chkavCcomercioitemsestado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
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
            GxWebStd.gx_label_ctrl( context, lblLblinventarionombrefilter_Internalname, context.GetMessage( "Producto/Característica", ""), "", "", lblLblinventarionombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16dl1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0381.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinventarionombre_Internalname, StringUtil.RTrim( AV11cInventarioNombre), StringUtil.RTrim( context.localUtil.Format( AV11cInventarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinventarionombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinventarionombre_Visible, edtavCinventarionombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0381.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e17dl1_client"+"'", TempTags, "", 2, "HLP_Gx0381.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0381.htm");
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

      protected void STARTDL2( )
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
         Form.Meta.addItem("description", context.GetMessage( "Selection List Rubros", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUPDL0( ) ;
      }

      protected void WSDL2( )
      {
         STARTDL2( ) ;
         EVTDL2( ) ;
      }

      protected void EVTDL2( )
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
                              A713ComercioProductosRubrosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtComercioProductosRubrosID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              A121RubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtRubrosId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              cmbComercioRubrosEstado.Name = cmbComercioRubrosEstado_Internalname;
                              cmbComercioRubrosEstado.CurrentValue = cgiGet( cmbComercioRubrosEstado_Internalname);
                              A692ComercioRubrosEstado = StringUtil.StrToBool( cgiGet( cmbComercioRubrosEstado_Internalname));
                              n692ComercioRubrosEstado = false;
                              A138MedidasNombre = cgiGet( edtMedidasNombre_Internalname);
                              A695ComercioItemsEstado = StringUtil.StrToBool( cgiGet( chkComercioItemsEstado_Internalname));
                              n695ComercioItemsEstado = false;
                              A696ComercioRubrosInventarioActiva = StringUtil.StrToBool( cgiGet( chkComercioRubrosInventarioActiva_Internalname));
                              n696ComercioRubrosInventarioActiva = false;
                              A133ProveedorID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProveedorID_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18DL2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E19DL2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccomercioproductosrubrosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOMERCIOPRODUCTOSRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cComercioProductosRubrosID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crubrosid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cRubrosId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccomerciorubrosestado Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCCOMERCIORUBROSESTADO")) != AV8cComercioRubrosEstado )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cmedidasnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCMEDIDASNOMBRE"), AV9cMedidasNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccomercioitemsestado Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCCOMERCIOITEMSESTADO")) != AV10cComercioItemsEstado )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinventarionombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCINVENTARIONOMBRE"), AV11cInventarioNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E20DL2 ();
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

      protected void WEDL2( )
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

      protected void PADL2( )
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
                                        long AV6cComercioProductosRubrosID ,
                                        short AV7cRubrosId ,
                                        bool AV8cComercioRubrosEstado ,
                                        string AV9cMedidasNombre ,
                                        bool AV10cComercioItemsEstado ,
                                        string AV11cInventarioNombre ,
                                        long AV12pProveedorID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RFDL2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COMERCIOPRODUCTOSRUBROSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A713ComercioProductosRubrosID), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "COMERCIOPRODUCTOSRUBROSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A713ComercioProductosRubrosID), 18, 0, ".", "")));
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
         if ( cmbavCcomerciorubrosestado.ItemCount > 0 )
         {
            AV8cComercioRubrosEstado = StringUtil.StrToBool( cmbavCcomerciorubrosestado.getValidValue(StringUtil.BoolToStr( AV8cComercioRubrosEstado)));
            AssignAttri("", false, "AV8cComercioRubrosEstado", AV8cComercioRubrosEstado);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCcomerciorubrosestado.CurrentValue = StringUtil.BoolToStr( AV8cComercioRubrosEstado);
            AssignProp("", false, cmbavCcomerciorubrosestado_Internalname, "Values", cmbavCcomerciorubrosestado.ToJavascriptSource(), true);
         }
         AV10cComercioItemsEstado = StringUtil.StrToBool( StringUtil.BoolToStr( AV10cComercioItemsEstado));
         AssignAttri("", false, "AV10cComercioItemsEstado", AV10cComercioItemsEstado);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RFDL2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RFDL2( )
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
                                                 AV7cRubrosId ,
                                                 AV8cComercioRubrosEstado ,
                                                 AV9cMedidasNombre ,
                                                 AV10cComercioItemsEstado ,
                                                 AV11cInventarioNombre ,
                                                 A121RubrosId ,
                                                 A692ComercioRubrosEstado ,
                                                 A138MedidasNombre ,
                                                 A695ComercioItemsEstado ,
                                                 A136InventarioNombre ,
                                                 AV12pProveedorID ,
                                                 AV6cComercioProductosRubrosID ,
                                                 A133ProveedorID } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.LONG
                                                 }
            });
            lV9cMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV9cMedidasNombre), 50, "%");
            lV11cInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV11cInventarioNombre), 100, "%");
            /* Using cursor H00DL2 */
            pr_default.execute(0, new Object[] {AV12pProveedorID, AV6cComercioProductosRubrosID, AV7cRubrosId, AV8cComercioRubrosEstado, lV9cMedidasNombre, AV10cComercioItemsEstado, lV11cInventarioNombre, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A137MedidasID = H00DL2_A137MedidasID[0];
               n137MedidasID = H00DL2_n137MedidasID[0];
               A135InventarioId = H00DL2_A135InventarioId[0];
               n135InventarioId = H00DL2_n135InventarioId[0];
               A136InventarioNombre = H00DL2_A136InventarioNombre[0];
               A133ProveedorID = H00DL2_A133ProveedorID[0];
               A696ComercioRubrosInventarioActiva = H00DL2_A696ComercioRubrosInventarioActiva[0];
               n696ComercioRubrosInventarioActiva = H00DL2_n696ComercioRubrosInventarioActiva[0];
               A695ComercioItemsEstado = H00DL2_A695ComercioItemsEstado[0];
               n695ComercioItemsEstado = H00DL2_n695ComercioItemsEstado[0];
               A138MedidasNombre = H00DL2_A138MedidasNombre[0];
               A692ComercioRubrosEstado = H00DL2_A692ComercioRubrosEstado[0];
               n692ComercioRubrosEstado = H00DL2_n692ComercioRubrosEstado[0];
               A121RubrosId = H00DL2_A121RubrosId[0];
               A713ComercioProductosRubrosID = H00DL2_A713ComercioProductosRubrosID[0];
               A138MedidasNombre = H00DL2_A138MedidasNombre[0];
               A136InventarioNombre = H00DL2_A136InventarioNombre[0];
               /* Execute user event: Load */
               E19DL2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WBDL0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashesDL2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_COMERCIOPRODUCTOSRUBROSID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A713ComercioProductosRubrosID), "ZZZZZZZZZZZZZZZZZ9"), context));
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
                                              AV7cRubrosId ,
                                              AV8cComercioRubrosEstado ,
                                              AV9cMedidasNombre ,
                                              AV10cComercioItemsEstado ,
                                              AV11cInventarioNombre ,
                                              A121RubrosId ,
                                              A692ComercioRubrosEstado ,
                                              A138MedidasNombre ,
                                              A695ComercioItemsEstado ,
                                              A136InventarioNombre ,
                                              AV12pProveedorID ,
                                              AV6cComercioProductosRubrosID ,
                                              A133ProveedorID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG
                                              }
         });
         lV9cMedidasNombre = StringUtil.PadR( StringUtil.RTrim( AV9cMedidasNombre), 50, "%");
         lV11cInventarioNombre = StringUtil.PadR( StringUtil.RTrim( AV11cInventarioNombre), 100, "%");
         /* Using cursor H00DL3 */
         pr_default.execute(1, new Object[] {AV12pProveedorID, AV6cComercioProductosRubrosID, AV7cRubrosId, AV8cComercioRubrosEstado, lV9cMedidasNombre, AV10cComercioItemsEstado, lV11cInventarioNombre});
         GRID1_nRecordCount = H00DL3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cComercioProductosRubrosID, AV7cRubrosId, AV8cComercioRubrosEstado, AV9cMedidasNombre, AV10cComercioItemsEstado, AV11cInventarioNombre, AV12pProveedorID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cComercioProductosRubrosID, AV7cRubrosId, AV8cComercioRubrosEstado, AV9cMedidasNombre, AV10cComercioItemsEstado, AV11cInventarioNombre, AV12pProveedorID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cComercioProductosRubrosID, AV7cRubrosId, AV8cComercioRubrosEstado, AV9cMedidasNombre, AV10cComercioItemsEstado, AV11cInventarioNombre, AV12pProveedorID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cComercioProductosRubrosID, AV7cRubrosId, AV8cComercioRubrosEstado, AV9cMedidasNombre, AV10cComercioItemsEstado, AV11cInventarioNombre, AV12pProveedorID) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cComercioProductosRubrosID, AV7cRubrosId, AV8cComercioRubrosEstado, AV9cMedidasNombre, AV10cComercioItemsEstado, AV11cInventarioNombre, AV12pProveedorID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtComercioProductosRubrosID_Enabled = 0;
         edtRubrosId_Enabled = 0;
         cmbComercioRubrosEstado.Enabled = 0;
         edtMedidasNombre_Enabled = 0;
         chkComercioItemsEstado.Enabled = 0;
         chkComercioRubrosInventarioActiva.Enabled = 0;
         edtProveedorID_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUPDL0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18DL2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcomercioproductosrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcomercioproductosrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCOMERCIOPRODUCTOSRUBROSID");
               GX_FocusControl = edtavCcomercioproductosrubrosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cComercioProductosRubrosID = 0;
               AssignAttri("", false, "AV6cComercioProductosRubrosID", StringUtil.LTrimStr( (decimal)(AV6cComercioProductosRubrosID), 18, 0));
            }
            else
            {
               AV6cComercioProductosRubrosID = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCcomercioproductosrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cComercioProductosRubrosID", StringUtil.LTrimStr( (decimal)(AV6cComercioProductosRubrosID), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRUBROSID");
               GX_FocusControl = edtavCrubrosid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cRubrosId = 0;
               AssignAttri("", false, "AV7cRubrosId", StringUtil.LTrimStr( (decimal)(AV7cRubrosId), 4, 0));
            }
            else
            {
               AV7cRubrosId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCrubrosid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cRubrosId", StringUtil.LTrimStr( (decimal)(AV7cRubrosId), 4, 0));
            }
            cmbavCcomerciorubrosestado.Name = cmbavCcomerciorubrosestado_Internalname;
            cmbavCcomerciorubrosestado.CurrentValue = cgiGet( cmbavCcomerciorubrosestado_Internalname);
            AV8cComercioRubrosEstado = StringUtil.StrToBool( cgiGet( cmbavCcomerciorubrosestado_Internalname));
            AssignAttri("", false, "AV8cComercioRubrosEstado", AV8cComercioRubrosEstado);
            AV9cMedidasNombre = cgiGet( edtavCmedidasnombre_Internalname);
            AssignAttri("", false, "AV9cMedidasNombre", AV9cMedidasNombre);
            AV10cComercioItemsEstado = StringUtil.StrToBool( cgiGet( chkavCcomercioitemsestado_Internalname));
            AssignAttri("", false, "AV10cComercioItemsEstado", AV10cComercioItemsEstado);
            AV11cInventarioNombre = cgiGet( edtavCinventarionombre_Internalname);
            AssignAttri("", false, "AV11cInventarioNombre", AV11cInventarioNombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCOMERCIOPRODUCTOSRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV6cComercioProductosRubrosID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRUBROSID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) != Convert.ToDecimal( AV7cRubrosId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCCOMERCIORUBROSESTADO")) != AV8cComercioRubrosEstado )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCMEDIDASNOMBRE"), AV9cMedidasNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCCOMERCIOITEMSESTADO")) != AV10cComercioItemsEstado )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCINVENTARIONOMBRE"), AV11cInventarioNombre) != 0 )
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
         E18DL2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18DL2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( context.GetMessage( "GXSPC_SelectionList", ""), context.GetMessage( "Rubros", ""), "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = context.GetMessage( "%1 <strong>%2</strong>", "");
      }

      private void E19DL2( )
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
         E20DL2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20DL2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pComercioProductosRubrosID = A713ComercioProductosRubrosID;
         AssignAttri("", false, "AV13pComercioProductosRubrosID", StringUtil.LTrimStr( (decimal)(AV13pComercioProductosRubrosID), 18, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pComercioProductosRubrosID});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pComercioProductosRubrosID"});
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
         AV12pProveedorID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pProveedorID", StringUtil.LTrimStr( (decimal)(AV12pProveedorID), 18, 0));
         AV13pComercioProductosRubrosID = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV13pComercioProductosRubrosID", StringUtil.LTrimStr( (decimal)(AV13pComercioProductosRubrosID), 18, 0));
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
         PADL2( ) ;
         WSDL2( ) ;
         WEDL2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20269321401877", true, true, false);
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
         context.AddJavascriptSource("gx0381.js", "?20269321401877", false, true, false);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtComercioProductosRubrosID_Internalname = "COMERCIOPRODUCTOSRUBROSID_"+sGXsfl_74_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_74_idx;
         cmbComercioRubrosEstado_Internalname = "COMERCIORUBROSESTADO_"+sGXsfl_74_idx;
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE_"+sGXsfl_74_idx;
         chkComercioItemsEstado_Internalname = "COMERCIOITEMSESTADO_"+sGXsfl_74_idx;
         chkComercioRubrosInventarioActiva_Internalname = "COMERCIORUBROSINVENTARIOACTIVA_"+sGXsfl_74_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtComercioProductosRubrosID_Internalname = "COMERCIOPRODUCTOSRUBROSID_"+sGXsfl_74_fel_idx;
         edtRubrosId_Internalname = "RUBROSID_"+sGXsfl_74_fel_idx;
         cmbComercioRubrosEstado_Internalname = "COMERCIORUBROSESTADO_"+sGXsfl_74_fel_idx;
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE_"+sGXsfl_74_fel_idx;
         chkComercioItemsEstado_Internalname = "COMERCIOITEMSESTADO_"+sGXsfl_74_fel_idx;
         chkComercioRubrosInventarioActiva_Internalname = "COMERCIORUBROSINVENTARIOACTIVA_"+sGXsfl_74_fel_idx;
         edtProveedorID_Internalname = "PROVEEDORID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WBDL0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A713ComercioProductosRubrosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
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
            edtComercioProductosRubrosID_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A713ComercioProductosRubrosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")))+"'"+"]);";
            AssignProp("", false, edtComercioProductosRubrosID_Internalname, "Link", edtComercioProductosRubrosID_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtComercioProductosRubrosID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A713ComercioProductosRubrosID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A713ComercioProductosRubrosID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtComercioProductosRubrosID_Link,(string)"",(string)"",(string)"",(string)edtComercioProductosRubrosID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRubrosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRubrosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbComercioRubrosEstado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "COMERCIORUBROSESTADO_" + sGXsfl_74_idx;
               cmbComercioRubrosEstado.Name = GXCCtl;
               cmbComercioRubrosEstado.WebTags = "";
               cmbComercioRubrosEstado.addItem(StringUtil.BoolToStr( false), context.GetMessage( "Sin Acción", ""), 0);
               cmbComercioRubrosEstado.addItem(StringUtil.BoolToStr( true), context.GetMessage( "Si", ""), 0);
               cmbComercioRubrosEstado.addItem(StringUtil.BoolToStr( false), context.GetMessage( "No", ""), 0);
               if ( cmbComercioRubrosEstado.ItemCount > 0 )
               {
                  A692ComercioRubrosEstado = StringUtil.StrToBool( cmbComercioRubrosEstado.getValidValue(StringUtil.BoolToStr( A692ComercioRubrosEstado)));
                  n692ComercioRubrosEstado = false;
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbComercioRubrosEstado,(string)cmbComercioRubrosEstado_Internalname,StringUtil.BoolToStr( A692ComercioRubrosEstado),(short)1,(string)cmbComercioRubrosEstado_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"boolean",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbComercioRubrosEstado.CurrentValue = StringUtil.BoolToStr( A692ComercioRubrosEstado);
            AssignProp("", false, cmbComercioRubrosEstado_Internalname, "Values", (string)(cmbComercioRubrosEstado.ToJavascriptSource()), !bGXsfl_74_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMedidasNombre_Internalname,StringUtil.RTrim( A138MedidasNombre),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMedidasNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "COMERCIOITEMSESTADO_" + sGXsfl_74_idx;
            chkComercioItemsEstado.Name = GXCCtl;
            chkComercioItemsEstado.WebTags = "";
            chkComercioItemsEstado.Caption = "";
            AssignProp("", false, chkComercioItemsEstado_Internalname, "TitleCaption", chkComercioItemsEstado.Caption, !bGXsfl_74_Refreshing);
            chkComercioItemsEstado.CheckedValue = "false";
            A695ComercioItemsEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A695ComercioItemsEstado));
            n695ComercioItemsEstado = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkComercioItemsEstado_Internalname,StringUtil.BoolToStr( A695ComercioItemsEstado),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "COMERCIORUBROSINVENTARIOACTIVA_" + sGXsfl_74_idx;
            chkComercioRubrosInventarioActiva.Name = GXCCtl;
            chkComercioRubrosInventarioActiva.WebTags = "";
            chkComercioRubrosInventarioActiva.Caption = "";
            AssignProp("", false, chkComercioRubrosInventarioActiva_Internalname, "TitleCaption", chkComercioRubrosInventarioActiva.Caption, !bGXsfl_74_Refreshing);
            chkComercioRubrosInventarioActiva.CheckedValue = "false";
            A696ComercioRubrosInventarioActiva = StringUtil.StrToBool( StringUtil.BoolToStr( A696ComercioRubrosInventarioActiva));
            n696ComercioRubrosInventarioActiva = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkComercioRubrosInventarioActiva_Internalname,StringUtil.BoolToStr( A696ComercioRubrosInventarioActiva),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProveedorID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProveedorID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashesDL2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         cmbavCcomerciorubrosestado.Name = "vCCOMERCIORUBROSESTADO";
         cmbavCcomerciorubrosestado.WebTags = "";
         cmbavCcomerciorubrosestado.addItem(StringUtil.BoolToStr( false), context.GetMessage( "Sin Acción", ""), 0);
         cmbavCcomerciorubrosestado.addItem(StringUtil.BoolToStr( true), context.GetMessage( "Si", ""), 0);
         cmbavCcomerciorubrosestado.addItem(StringUtil.BoolToStr( false), context.GetMessage( "No", ""), 0);
         if ( cmbavCcomerciorubrosestado.ItemCount > 0 )
         {
            AV8cComercioRubrosEstado = StringUtil.StrToBool( cmbavCcomerciorubrosestado.getValidValue(StringUtil.BoolToStr( AV8cComercioRubrosEstado)));
            AssignAttri("", false, "AV8cComercioRubrosEstado", AV8cComercioRubrosEstado);
         }
         chkavCcomercioitemsestado.Name = "vCCOMERCIOITEMSESTADO";
         chkavCcomercioitemsestado.WebTags = "";
         chkavCcomercioitemsestado.Caption = context.GetMessage( "Activado", "");
         AssignProp("", false, chkavCcomercioitemsestado_Internalname, "TitleCaption", chkavCcomercioitemsestado.Caption, true);
         chkavCcomercioitemsestado.CheckedValue = "false";
         AV10cComercioItemsEstado = StringUtil.StrToBool( StringUtil.BoolToStr( AV10cComercioItemsEstado));
         AssignAttri("", false, "AV10cComercioItemsEstado", AV10cComercioItemsEstado);
         GXCCtl = "COMERCIORUBROSESTADO_" + sGXsfl_74_idx;
         cmbComercioRubrosEstado.Name = GXCCtl;
         cmbComercioRubrosEstado.WebTags = "";
         cmbComercioRubrosEstado.addItem(StringUtil.BoolToStr( false), context.GetMessage( "Sin Acción", ""), 0);
         cmbComercioRubrosEstado.addItem(StringUtil.BoolToStr( true), context.GetMessage( "Si", ""), 0);
         cmbComercioRubrosEstado.addItem(StringUtil.BoolToStr( false), context.GetMessage( "No", ""), 0);
         if ( cmbComercioRubrosEstado.ItemCount > 0 )
         {
            A692ComercioRubrosEstado = StringUtil.StrToBool( cmbComercioRubrosEstado.getValidValue(StringUtil.BoolToStr( A692ComercioRubrosEstado)));
            n692ComercioRubrosEstado = false;
         }
         GXCCtl = "COMERCIOITEMSESTADO_" + sGXsfl_74_idx;
         chkComercioItemsEstado.Name = GXCCtl;
         chkComercioItemsEstado.WebTags = "";
         chkComercioItemsEstado.Caption = "";
         AssignProp("", false, chkComercioItemsEstado_Internalname, "TitleCaption", chkComercioItemsEstado.Caption, !bGXsfl_74_Refreshing);
         chkComercioItemsEstado.CheckedValue = "false";
         A695ComercioItemsEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A695ComercioItemsEstado));
         n695ComercioItemsEstado = false;
         GXCCtl = "COMERCIORUBROSINVENTARIOACTIVA_" + sGXsfl_74_idx;
         chkComercioRubrosInventarioActiva.Name = GXCCtl;
         chkComercioRubrosInventarioActiva.WebTags = "";
         chkComercioRubrosInventarioActiva.Caption = "";
         AssignProp("", false, chkComercioRubrosInventarioActiva_Internalname, "TitleCaption", chkComercioRubrosInventarioActiva.Caption, !bGXsfl_74_Refreshing);
         chkComercioRubrosInventarioActiva.CheckedValue = "false";
         A696ComercioRubrosInventarioActiva = StringUtil.StrToBool( StringUtil.BoolToStr( A696ComercioRubrosInventarioActiva));
         n696ComercioRubrosInventarioActiva = false;
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
            context.SendWebValue( context.GetMessage( "Rubros ID", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Rubros Identificador ", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Activado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Nombre de la Característica", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Activado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Activado", "")) ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( context.GetMessage( "Comercio", "")) ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A713ComercioProductosRubrosID), 18, 0, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtComercioProductosRubrosID_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A121RubrosId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A692ComercioRubrosEstado)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A138MedidasNombre)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A695ComercioItemsEstado)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A696ComercioRubrosInventarioActiva)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A133ProveedorID), 18, 0, ".", ""))));
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
         lblLblcomercioproductosrubrosidfilter_Internalname = "LBLCOMERCIOPRODUCTOSRUBROSIDFILTER";
         edtavCcomercioproductosrubrosid_Internalname = "vCCOMERCIOPRODUCTOSRUBROSID";
         divComercioproductosrubrosidfiltercontainer_Internalname = "COMERCIOPRODUCTOSRUBROSIDFILTERCONTAINER";
         lblLblrubrosidfilter_Internalname = "LBLRUBROSIDFILTER";
         edtavCrubrosid_Internalname = "vCRUBROSID";
         divRubrosidfiltercontainer_Internalname = "RUBROSIDFILTERCONTAINER";
         lblLblcomerciorubrosestadofilter_Internalname = "LBLCOMERCIORUBROSESTADOFILTER";
         cmbavCcomerciorubrosestado_Internalname = "vCCOMERCIORUBROSESTADO";
         divComerciorubrosestadofiltercontainer_Internalname = "COMERCIORUBROSESTADOFILTERCONTAINER";
         lblLblmedidasnombrefilter_Internalname = "LBLMEDIDASNOMBREFILTER";
         edtavCmedidasnombre_Internalname = "vCMEDIDASNOMBRE";
         divMedidasnombrefiltercontainer_Internalname = "MEDIDASNOMBREFILTERCONTAINER";
         lblLblcomercioitemsestadofilter_Internalname = "LBLCOMERCIOITEMSESTADOFILTER";
         chkavCcomercioitemsestado_Internalname = "vCCOMERCIOITEMSESTADO";
         divComercioitemsestadofiltercontainer_Internalname = "COMERCIOITEMSESTADOFILTERCONTAINER";
         lblLblinventarionombrefilter_Internalname = "LBLINVENTARIONOMBREFILTER";
         edtavCinventarionombre_Internalname = "vCINVENTARIONOMBRE";
         divInventarionombrefiltercontainer_Internalname = "INVENTARIONOMBREFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtComercioProductosRubrosID_Internalname = "COMERCIOPRODUCTOSRUBROSID";
         edtRubrosId_Internalname = "RUBROSID";
         cmbComercioRubrosEstado_Internalname = "COMERCIORUBROSESTADO";
         edtMedidasNombre_Internalname = "MEDIDASNOMBRE";
         chkComercioItemsEstado_Internalname = "COMERCIOITEMSESTADO";
         chkComercioRubrosInventarioActiva_Internalname = "COMERCIORUBROSINVENTARIOACTIVA";
         edtProveedorID_Internalname = "PROVEEDORID";
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
         chkavCcomercioitemsestado.Caption = context.GetMessage( "Activado", "");
         edtProveedorID_Jsonclick = "";
         chkComercioRubrosInventarioActiva.Caption = "";
         chkComercioItemsEstado.Caption = "";
         edtMedidasNombre_Jsonclick = "";
         cmbComercioRubrosEstado_Jsonclick = "";
         edtRubrosId_Jsonclick = "";
         edtComercioProductosRubrosID_Jsonclick = "";
         edtComercioProductosRubrosID_Link = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtProveedorID_Enabled = 0;
         chkComercioRubrosInventarioActiva.Enabled = 0;
         chkComercioItemsEstado.Enabled = 0;
         edtMedidasNombre_Enabled = 0;
         cmbComercioRubrosEstado.Enabled = 0;
         edtRubrosId_Enabled = 0;
         edtComercioProductosRubrosID_Enabled = 0;
         edtavCinventarionombre_Jsonclick = "";
         edtavCinventarionombre_Enabled = 1;
         edtavCinventarionombre_Visible = 1;
         chkavCcomercioitemsestado.Enabled = 1;
         chkavCcomercioitemsestado.Visible = 1;
         edtavCmedidasnombre_Jsonclick = "";
         edtavCmedidasnombre_Enabled = 1;
         edtavCmedidasnombre_Visible = 1;
         cmbavCcomerciorubrosestado_Jsonclick = "";
         cmbavCcomerciorubrosestado.Visible = 1;
         cmbavCcomerciorubrosestado.Enabled = 1;
         edtavCrubrosid_Jsonclick = "";
         edtavCrubrosid_Enabled = 1;
         edtavCrubrosid_Visible = 1;
         edtavCcomercioproductosrubrosid_Jsonclick = "";
         edtavCcomercioproductosrubrosid_Enabled = 1;
         edtavCcomercioproductosrubrosid_Visible = 1;
         divInventarionombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divComercioitemsestadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divMedidasnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divComerciorubrosestadofiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divRubrosidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divComercioproductosrubrosidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Selection List Rubros", "");
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cComercioProductosRubrosID',fld:'vCCOMERCIOPRODUCTOSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'cmbavCcomerciorubrosestado'},{av:'AV8cComercioRubrosEstado',fld:'vCCOMERCIORUBROSESTADO',pic:'',type:'boolean'},{av:'AV9cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV11cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pProveedorID',fld:'vPPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cComercioItemsEstado',fld:'vCCOMERCIOITEMSESTADO',pic:'',type:'boolean'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E17DL1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCOMERCIOPRODUCTOSRUBROSIDFILTER.CLICK","{handler:'E11DL1',iparms:[{av:'divComercioproductosrubrosidfiltercontainer_Class',ctrl:'COMERCIOPRODUCTOSRUBROSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOMERCIOPRODUCTOSRUBROSIDFILTER.CLICK",",oparms:[{av:'divComercioproductosrubrosidfiltercontainer_Class',ctrl:'COMERCIOPRODUCTOSRUBROSIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcomercioproductosrubrosid_Visible',ctrl:'vCCOMERCIOPRODUCTOSRUBROSID',prop:'Visible'}]}");
         setEventMetadata("LBLRUBROSIDFILTER.CLICK","{handler:'E12DL1',iparms:[{av:'divRubrosidfiltercontainer_Class',ctrl:'RUBROSIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRUBROSIDFILTER.CLICK",",oparms:[{av:'divRubrosidfiltercontainer_Class',ctrl:'RUBROSIDFILTERCONTAINER',prop:'Class'},{av:'edtavCrubrosid_Visible',ctrl:'vCRUBROSID',prop:'Visible'}]}");
         setEventMetadata("LBLCOMERCIORUBROSESTADOFILTER.CLICK","{handler:'E13DL1',iparms:[{av:'divComerciorubrosestadofiltercontainer_Class',ctrl:'COMERCIORUBROSESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOMERCIORUBROSESTADOFILTER.CLICK",",oparms:[{av:'divComerciorubrosestadofiltercontainer_Class',ctrl:'COMERCIORUBROSESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCcomerciorubrosestado'}]}");
         setEventMetadata("LBLMEDIDASNOMBREFILTER.CLICK","{handler:'E14DL1',iparms:[{av:'divMedidasnombrefiltercontainer_Class',ctrl:'MEDIDASNOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMEDIDASNOMBREFILTER.CLICK",",oparms:[{av:'divMedidasnombrefiltercontainer_Class',ctrl:'MEDIDASNOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCmedidasnombre_Visible',ctrl:'vCMEDIDASNOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLCOMERCIOITEMSESTADOFILTER.CLICK","{handler:'E15DL1',iparms:[{av:'divComercioitemsestadofiltercontainer_Class',ctrl:'COMERCIOITEMSESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCOMERCIOITEMSESTADOFILTER.CLICK",",oparms:[{av:'divComercioitemsestadofiltercontainer_Class',ctrl:'COMERCIOITEMSESTADOFILTERCONTAINER',prop:'Class'},{av:'chkavCcomercioitemsestado.Visible',ctrl:'vCCOMERCIOITEMSESTADO',prop:'Visible'}]}");
         setEventMetadata("LBLINVENTARIONOMBREFILTER.CLICK","{handler:'E16DL1',iparms:[{av:'divInventarionombrefiltercontainer_Class',ctrl:'INVENTARIONOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVENTARIONOMBREFILTER.CLICK",",oparms:[{av:'divInventarionombrefiltercontainer_Class',ctrl:'INVENTARIONOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCinventarionombre_Visible',ctrl:'vCINVENTARIONOMBRE',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E20DL2',iparms:[{av:'A713ComercioProductosRubrosID',fld:'COMERCIOPRODUCTOSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true,type:'int'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pComercioProductosRubrosID',fld:'vPCOMERCIOPRODUCTOSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cComercioProductosRubrosID',fld:'vCCOMERCIOPRODUCTOSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'cmbavCcomerciorubrosestado'},{av:'AV8cComercioRubrosEstado',fld:'vCCOMERCIORUBROSESTADO',pic:'',type:'boolean'},{av:'AV9cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV11cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pProveedorID',fld:'vPPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cComercioItemsEstado',fld:'vCCOMERCIOITEMSESTADO',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cComercioProductosRubrosID',fld:'vCCOMERCIOPRODUCTOSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'cmbavCcomerciorubrosestado'},{av:'AV8cComercioRubrosEstado',fld:'vCCOMERCIORUBROSESTADO',pic:'',type:'boolean'},{av:'AV9cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV11cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pProveedorID',fld:'vPPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cComercioItemsEstado',fld:'vCCOMERCIOITEMSESTADO',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cComercioProductosRubrosID',fld:'vCCOMERCIOPRODUCTOSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'cmbavCcomerciorubrosestado'},{av:'AV8cComercioRubrosEstado',fld:'vCCOMERCIORUBROSESTADO',pic:'',type:'boolean'},{av:'AV9cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV11cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pProveedorID',fld:'vPPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cComercioItemsEstado',fld:'vCCOMERCIOITEMSESTADO',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage',type:'int'},{av:'GRID1_nEOF',type:'int'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cComercioProductosRubrosID',fld:'vCCOMERCIOPRODUCTOSRUBROSID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV7cRubrosId',fld:'vCRUBROSID',pic:'ZZZ9',type:'int'},{av:'cmbavCcomerciorubrosestado'},{av:'AV8cComercioRubrosEstado',fld:'vCCOMERCIORUBROSESTADO',pic:'',type:'boolean'},{av:'AV9cMedidasNombre',fld:'vCMEDIDASNOMBRE',pic:'',type:'char'},{av:'AV11cInventarioNombre',fld:'vCINVENTARIONOMBRE',pic:'',type:'char'},{av:'AV12pProveedorID',fld:'vPPROVEEDORID',pic:'ZZZZZZZZZZZZZZZZZ9',type:'int'},{av:'AV10cComercioItemsEstado',fld:'vCCOMERCIOITEMSESTADO',pic:'',type:'boolean'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALID_RUBROSID","{handler:'Valid_Rubrosid',iparms:[]");
         setEventMetadata("VALID_RUBROSID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Proveedorid',iparms:[]");
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
         AV9cMedidasNombre = "";
         AV11cInventarioNombre = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcomercioproductosrubrosidfilter_Jsonclick = "";
         TempTags = "";
         lblLblrubrosidfilter_Jsonclick = "";
         lblLblcomerciorubrosestadofilter_Jsonclick = "";
         lblLblmedidasnombrefilter_Jsonclick = "";
         lblLblcomercioitemsestadofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblinventarionombrefilter_Jsonclick = "";
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
         A138MedidasNombre = "";
         lV9cMedidasNombre = "";
         lV11cInventarioNombre = "";
         A136InventarioNombre = "";
         H00DL2_A137MedidasID = new long[1] ;
         H00DL2_n137MedidasID = new bool[] {false} ;
         H00DL2_A135InventarioId = new long[1] ;
         H00DL2_n135InventarioId = new bool[] {false} ;
         H00DL2_A136InventarioNombre = new string[] {""} ;
         H00DL2_A133ProveedorID = new long[1] ;
         H00DL2_A696ComercioRubrosInventarioActiva = new bool[] {false} ;
         H00DL2_n696ComercioRubrosInventarioActiva = new bool[] {false} ;
         H00DL2_A695ComercioItemsEstado = new bool[] {false} ;
         H00DL2_n695ComercioItemsEstado = new bool[] {false} ;
         H00DL2_A138MedidasNombre = new string[] {""} ;
         H00DL2_A692ComercioRubrosEstado = new bool[] {false} ;
         H00DL2_n692ComercioRubrosEstado = new bool[] {false} ;
         H00DL2_A121RubrosId = new short[1] ;
         H00DL2_A713ComercioProductosRubrosID = new long[1] ;
         H00DL3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0381__default(),
            new Object[][] {
                new Object[] {
               H00DL2_A137MedidasID, H00DL2_n137MedidasID, H00DL2_A135InventarioId, H00DL2_n135InventarioId, H00DL2_A136InventarioNombre, H00DL2_A133ProveedorID, H00DL2_A696ComercioRubrosInventarioActiva, H00DL2_n696ComercioRubrosInventarioActiva, H00DL2_A695ComercioItemsEstado, H00DL2_n695ComercioItemsEstado,
               H00DL2_A138MedidasNombre, H00DL2_A692ComercioRubrosEstado, H00DL2_n692ComercioRubrosEstado, H00DL2_A121RubrosId, H00DL2_A713ComercioProductosRubrosID
               }
               , new Object[] {
               H00DL3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cRubrosId ;
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
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCcomercioproductosrubrosid_Enabled ;
      private int edtavCcomercioproductosrubrosid_Visible ;
      private int edtavCrubrosid_Enabled ;
      private int edtavCrubrosid_Visible ;
      private int edtavCmedidasnombre_Visible ;
      private int edtavCmedidasnombre_Enabled ;
      private int edtavCinventarionombre_Visible ;
      private int edtavCinventarionombre_Enabled ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtComercioProductosRubrosID_Enabled ;
      private int edtRubrosId_Enabled ;
      private int edtMedidasNombre_Enabled ;
      private int edtProveedorID_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long AV12pProveedorID ;
      private long AV13pComercioProductosRubrosID ;
      private long wcpOAV12pProveedorID ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cComercioProductosRubrosID ;
      private long A713ComercioProductosRubrosID ;
      private long A133ProveedorID ;
      private long GRID1_nCurrentRecord ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divComercioproductosrubrosidfiltercontainer_Class ;
      private string divRubrosidfiltercontainer_Class ;
      private string divComerciorubrosestadofiltercontainer_Class ;
      private string divMedidasnombrefiltercontainer_Class ;
      private string divComercioitemsestadofiltercontainer_Class ;
      private string divInventarionombrefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV9cMedidasNombre ;
      private string AV11cInventarioNombre ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divComercioproductosrubrosidfiltercontainer_Internalname ;
      private string lblLblcomercioproductosrubrosidfilter_Internalname ;
      private string lblLblcomercioproductosrubrosidfilter_Jsonclick ;
      private string edtavCcomercioproductosrubrosid_Internalname ;
      private string TempTags ;
      private string edtavCcomercioproductosrubrosid_Jsonclick ;
      private string divRubrosidfiltercontainer_Internalname ;
      private string lblLblrubrosidfilter_Internalname ;
      private string lblLblrubrosidfilter_Jsonclick ;
      private string edtavCrubrosid_Internalname ;
      private string edtavCrubrosid_Jsonclick ;
      private string divComerciorubrosestadofiltercontainer_Internalname ;
      private string lblLblcomerciorubrosestadofilter_Internalname ;
      private string lblLblcomerciorubrosestadofilter_Jsonclick ;
      private string cmbavCcomerciorubrosestado_Internalname ;
      private string cmbavCcomerciorubrosestado_Jsonclick ;
      private string divMedidasnombrefiltercontainer_Internalname ;
      private string lblLblmedidasnombrefilter_Internalname ;
      private string lblLblmedidasnombrefilter_Jsonclick ;
      private string edtavCmedidasnombre_Internalname ;
      private string edtavCmedidasnombre_Jsonclick ;
      private string divComercioitemsestadofiltercontainer_Internalname ;
      private string lblLblcomercioitemsestadofilter_Internalname ;
      private string lblLblcomercioitemsestadofilter_Jsonclick ;
      private string chkavCcomercioitemsestado_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divInventarionombrefiltercontainer_Internalname ;
      private string lblLblinventarionombrefilter_Internalname ;
      private string lblLblinventarionombrefilter_Jsonclick ;
      private string edtavCinventarionombre_Internalname ;
      private string edtavCinventarionombre_Jsonclick ;
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
      private string edtComercioProductosRubrosID_Internalname ;
      private string edtRubrosId_Internalname ;
      private string cmbComercioRubrosEstado_Internalname ;
      private string A138MedidasNombre ;
      private string edtMedidasNombre_Internalname ;
      private string chkComercioItemsEstado_Internalname ;
      private string chkComercioRubrosInventarioActiva_Internalname ;
      private string edtProveedorID_Internalname ;
      private string lV9cMedidasNombre ;
      private string lV11cInventarioNombre ;
      private string A136InventarioNombre ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtComercioProductosRubrosID_Link ;
      private string edtComercioProductosRubrosID_Jsonclick ;
      private string edtRubrosId_Jsonclick ;
      private string GXCCtl ;
      private string cmbComercioRubrosEstado_Jsonclick ;
      private string edtMedidasNombre_Jsonclick ;
      private string edtProveedorID_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8cComercioRubrosEstado ;
      private bool AV10cComercioItemsEstado ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool A692ComercioRubrosEstado ;
      private bool n692ComercioRubrosEstado ;
      private bool A695ComercioItemsEstado ;
      private bool n695ComercioItemsEstado ;
      private bool A696ComercioRubrosInventarioActiva ;
      private bool n696ComercioRubrosInventarioActiva ;
      private bool gxdyncontrolsrefreshing ;
      private bool n137MedidasID ;
      private bool n135InventarioId ;
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
      private GXCombobox cmbavCcomerciorubrosestado ;
      private GXCheckbox chkavCcomercioitemsestado ;
      private GXCombobox cmbComercioRubrosEstado ;
      private GXCheckbox chkComercioItemsEstado ;
      private GXCheckbox chkComercioRubrosInventarioActiva ;
      private IDataStoreProvider pr_default ;
      private long[] H00DL2_A137MedidasID ;
      private bool[] H00DL2_n137MedidasID ;
      private long[] H00DL2_A135InventarioId ;
      private bool[] H00DL2_n135InventarioId ;
      private string[] H00DL2_A136InventarioNombre ;
      private long[] H00DL2_A133ProveedorID ;
      private bool[] H00DL2_A696ComercioRubrosInventarioActiva ;
      private bool[] H00DL2_n696ComercioRubrosInventarioActiva ;
      private bool[] H00DL2_A695ComercioItemsEstado ;
      private bool[] H00DL2_n695ComercioItemsEstado ;
      private string[] H00DL2_A138MedidasNombre ;
      private bool[] H00DL2_A692ComercioRubrosEstado ;
      private bool[] H00DL2_n692ComercioRubrosEstado ;
      private short[] H00DL2_A121RubrosId ;
      private long[] H00DL2_A713ComercioProductosRubrosID ;
      private long[] H00DL3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP1_pComercioProductosRubrosID ;
   }

   public class gx0381__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00DL2( IGxContext context ,
                                             short AV7cRubrosId ,
                                             bool AV8cComercioRubrosEstado ,
                                             string AV9cMedidasNombre ,
                                             bool AV10cComercioItemsEstado ,
                                             string AV11cInventarioNombre ,
                                             short A121RubrosId ,
                                             bool A692ComercioRubrosEstado ,
                                             string A138MedidasNombre ,
                                             bool A695ComercioItemsEstado ,
                                             string A136InventarioNombre ,
                                             long AV12pProveedorID ,
                                             long AV6cComercioProductosRubrosID ,
                                             long A133ProveedorID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[MedidasID], T1.[InventarioId], T3.[InventarioNombre], T1.[ProveedorID], T1.[ComercioRubrosInventarioActiva], T1.[ComercioItemsEstado], T2.[MedidasNombre], T1.[ComercioRubrosEstado], T1.[RubrosId], T1.[ComercioProductosRubrosID]";
         sFromString = " FROM (([ComercioProductosRubros] T1 LEFT JOIN [RubrosMedidas] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[ProveedorID] = @AV12pProveedorID and T1.[ComercioProductosRubrosID] >= @AV6cComercioProductosRubrosID)");
         if ( ! (0==AV7cRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV7cRubrosId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (false==AV8cComercioRubrosEstado) )
         {
            AddWhere(sWhereString, "(T1.[ComercioRubrosEstado] >= @AV8cComercioRubrosEstado)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cMedidasNombre)) )
         {
            AddWhere(sWhereString, "(T2.[MedidasNombre] like @lV9cMedidasNombre)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (false==AV10cComercioItemsEstado) )
         {
            AddWhere(sWhereString, "(T1.[ComercioItemsEstado] >= @AV10cComercioItemsEstado)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cInventarioNombre)) )
         {
            AddWhere(sWhereString, "(T3.[InventarioNombre] like @lV11cInventarioNombre)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY T1.[ProveedorID], T1.[ComercioProductosRubrosID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00DL3( IGxContext context ,
                                             short AV7cRubrosId ,
                                             bool AV8cComercioRubrosEstado ,
                                             string AV9cMedidasNombre ,
                                             bool AV10cComercioItemsEstado ,
                                             string AV11cInventarioNombre ,
                                             short A121RubrosId ,
                                             bool A692ComercioRubrosEstado ,
                                             string A138MedidasNombre ,
                                             bool A695ComercioItemsEstado ,
                                             string A136InventarioNombre ,
                                             long AV12pProveedorID ,
                                             long AV6cComercioProductosRubrosID ,
                                             long A133ProveedorID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([ComercioProductosRubros] T1 LEFT JOIN [RubrosMedidas] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID]) LEFT JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId])";
         AddWhere(sWhereString, "(T1.[ProveedorID] = @AV12pProveedorID and T1.[ComercioProductosRubrosID] >= @AV6cComercioProductosRubrosID)");
         if ( ! (0==AV7cRubrosId) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV7cRubrosId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (false==AV8cComercioRubrosEstado) )
         {
            AddWhere(sWhereString, "(T1.[ComercioRubrosEstado] >= @AV8cComercioRubrosEstado)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cMedidasNombre)) )
         {
            AddWhere(sWhereString, "(T2.[MedidasNombre] like @lV9cMedidasNombre)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (false==AV10cComercioItemsEstado) )
         {
            AddWhere(sWhereString, "(T1.[ComercioItemsEstado] >= @AV10cComercioItemsEstado)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11cInventarioNombre)) )
         {
            AddWhere(sWhereString, "(T3.[InventarioNombre] like @lV11cInventarioNombre)");
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
                     return conditional_H00DL2(context, (short)dynConstraints[0] , (bool)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00DL3(context, (short)dynConstraints[0] , (bool)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH00DL2;
          prmH00DL2 = new Object[] {
          new ParDef("@AV12pProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV6cComercioProductosRubrosID",GXType.Decimal,18,0) ,
          new ParDef("@AV7cRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV8cComercioRubrosEstado",GXType.Boolean,4,0) ,
          new ParDef("@lV9cMedidasNombre",GXType.NChar,50,0) ,
          new ParDef("@AV10cComercioItemsEstado",GXType.Boolean,4,0) ,
          new ParDef("@lV11cInventarioNombre",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00DL3;
          prmH00DL3 = new Object[] {
          new ParDef("@AV12pProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV6cComercioProductosRubrosID",GXType.Decimal,18,0) ,
          new ParDef("@AV7cRubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV8cComercioRubrosEstado",GXType.Boolean,4,0) ,
          new ParDef("@lV9cMedidasNombre",GXType.NChar,50,0) ,
          new ParDef("@AV10cComercioItemsEstado",GXType.Boolean,4,0) ,
          new ParDef("@lV11cInventarioNombre",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00DL2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DL2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00DL3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00DL3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 100);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.getBool(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getString(7, 50);
                ((bool[]) buf[11])[0] = rslt.getBool(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((short[]) buf[13])[0] = rslt.getShort(9);
                ((long[]) buf[14])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
